using System;
using System.Data;
using System.Configuration;
//using System.Data.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Xml;

/// <summary>
/// Summary description for ScriptDeferFilter
/// </summary>
public class ScriptDeferFilter : Stream
{
    Stream responseStream;
    long position;

    /// <summary>
    /// When this is true, script blocks are suppressed and captured for 
    /// later rendering
    /// </summary>
    bool captureScripts;

    /// <summary>
    /// Holds all script blocks that are injected by the controls
    /// The script blocks will be moved after the form tag renders
    /// </summary>
    StringBuilder scriptBlocks;

    Encoding encoding;

    /// <summary>
    /// Holds characters from last Write(...) call where the start tag did not
    /// end and thus the remaining characters need to be preserved in a buffer so 
    /// that a complete tag can be parsed
    /// </summary>
    char[] pendingBuffer = null;

    bool isLoadFirst = false;

    public ScriptDeferFilter(HttpResponse response)
    {
        this.encoding = response.Output.Encoding;
        this.responseStream = response.Filter;

        this.scriptBlocks = new StringBuilder(5000);
        // When this is on, script blocks are captured and not written to output
        this.captureScripts = true;
    }

    #region Filter overrides
    public override bool CanRead
    {
        get { return false; }
    }

    public override bool CanSeek
    {
        get { return false; }
    }

    public override bool CanWrite
    {
        get { return true; }
    }

    public override void Close()
    {
        this.FlushPendingBuffer();
        responseStream.Close();
    }

    private void FlushPendingBuffer()
    {
        /// Some characters were left in the buffer 
        if (null != this.pendingBuffer)
        {
            this.WriteOutput(this.pendingBuffer, 0, this.pendingBuffer.Length);
            this.pendingBuffer = null;
        }

    }

    public override void Flush()
    {
        this.FlushPendingBuffer();
        responseStream.Flush();
    }

    public override long Length
    {
        get { return 0; }
    }

    public override long Position
    {
        get { return position; }
        set { position = value; }
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return responseStream.Seek(offset, origin);
    }

    public override void SetLength(long length)
    {
        responseStream.SetLength(length);
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        return responseStream.Read(buffer, offset, count);
    }
    #endregion

    public override void Write(byte[] buffer, int offset, int count)
    {
        // If we are not capturing script blocks anymore, just redirect to response stream
        if (!this.captureScripts)
        {
            this.responseStream.Write(buffer, offset, count);
            return;
        }

        /* 
         * Script and HTML can be in one of the following combinations in the specified buffer:          
         * .....<script ....>.....</script>.....
         * <script ....>.....</script>.....
         * <script ....>.....</script>
         * <script ....>.....</script> .....
         * ....<script ....>..... 
         * <script ....>..... 
         * .....</script>.....
         * .....</script>
         * <script>.....
         * .... </script>
         * ......
         * Here, "...." means html content between and outside script tags
        */

        char[] content;
        char[] charBuffer = this.encoding.GetChars(buffer, offset, count);

        /// If some bytes were left for processing during last Write call
        /// then consider those into the current buffer
        if (null != this.pendingBuffer)
        {
            content = new char[charBuffer.Length + this.pendingBuffer.Length];
            Array.Copy(this.pendingBuffer, 0, content, 0, this.pendingBuffer.Length);
            Array.Copy(charBuffer, 0, content, this.pendingBuffer.Length, charBuffer.Length);
            this.pendingBuffer = null;
        }
        else
        {
            content = charBuffer;
        }

        int scriptTagStart = 0;
        int lastScriptTagEnd = 0;
        bool scriptTagStarted = false;

        int pos;
        for (pos = 0; pos < content.Length; pos++)
        {
            // See if tag start
            char c = content[pos];
            if (c == '<')
            {
                /*
                    Make sure there are enough characters available in the buffer to finish 
                    tag start. This will happen when a tag partially starts but does not end
                    For example, a partial script tag
                    <script
                    Or it's the ending html tag or some tag closing that ends the whole response
                    </html>
                */
                if (pos + "script".Length >= content.Length)
                {
                    // a tag started but there are less than 10 characters available. So, let's
                    // store the remaining content in a buffer and wait for another Write(...) or
                    // flush call.
                    this.pendingBuffer = new char[content.Length - pos];
                    Array.Copy(content, pos, this.pendingBuffer, 0, content.Length - pos);
                    break;
                }

                int tagStart = pos;
                // Check if it's a tag ending
                if (content[pos + 1] == '/')
                {
                    pos += 2; // go past the </ 

                    // See if script tag is ending
                    if (isScriptTag(content, pos))
                    {
                        /// Script tag just ended. Get the whole script
                        /// and store in buffer
                        pos = pos + "script>".Length;
                        scriptBlocks.Append(content, scriptTagStart, pos - scriptTagStart);
                        scriptBlocks.Append(Environment.NewLine);
                        lastScriptTagEnd = pos;

                        scriptTagStarted = false;

                        pos--; // continue will increase pos by one again
                        continue;
                    }
                    else if (isBodyTag(content, pos))
                    {
                        /// body tag has just end. Time for rendering all the script
                        /// blocks we have suppressed so far and stop capturing script blocks

                        if (this.scriptBlocks.Length > 0)
                        {
                            // Render all pending html output till now
                            this.WriteOutput(content, lastScriptTagEnd, tagStart - lastScriptTagEnd);

                            // Render the script blocks
                            this.RenderAllScriptBlocks();

                            // Stop capturing for script blocks
                            this.captureScripts = false;

                            // Write from the body tag start to the end of the inut buffer and return
                            // from the function. We are done.
                            this.WriteOutput(content, tagStart, content.Length - tagStart);
                            return;
                        }
                    }
                    else
                    {
                        // some other tag's closing. safely skip one character as smallest
                        // html tag is one character e.g. <b>. just an optimization to save one loop
                        pos++;
                    }
                }
                else
                {
                    if (isScriptTag(content, pos + 1))
                    {
                        /// Script tag started. Record the position as we will 
                        /// capture the whole script tag including its content
                        /// and store in an internal buffer.
                        scriptTagStart = pos;

                        // Write html content since last script tag closing upto this script tag 
                        this.WriteOutput(content, lastScriptTagEnd, scriptTagStart - lastScriptTagEnd);

                        // Skip the tag start to save some loops
                        pos += "<script".Length;

                        scriptTagStarted = true;
                    }
                    else
                    {
                        // some other tag started
                        // safely skip 2 character because the smallest tag is one character e.g. <b>
                        // just an optimization to eliminate one loop 
                        pos++;
                    }
                }
            }
        }

        // If a script tag is partially sent to buffer, then the remaining content
        // is part of the last script block
        if (scriptTagStarted)
        {
            this.scriptBlocks.Append(content, scriptTagStart, pos - scriptTagStart);
        }
        else
        {
            /// Render the characters since the last script tag ending
            this.WriteOutput(content, lastScriptTagEnd, pos - lastScriptTagEnd);
        }
    }

    /// <summary>
    /// Render collected scripts blocks all together
    /// </summary>
    private void RenderAllScriptBlocks()
    {
        string output = CombineScripts.CombineScriptBlocks(this.scriptBlocks.ToString());
        byte[] scriptBytes = this.encoding.GetBytes(output);
        this.responseStream.Write(scriptBytes, 0, scriptBytes.Length);
    }

    private void WriteOutput(char[] content, int pos, int length)
    {
        if (length == 0) return;

        byte[] buffer = this.encoding.GetBytes(content, pos, length);
        this.responseStream.Write(buffer, 0, buffer.Length);
    }

    private bool isScriptTag(char[] content, int pos)
    {
        if (pos + 5 < content.Length)
        {
            if ((content[pos] == 's' || content[pos] == 'S')
                && (content[pos + 1] == 'c' || content[pos + 1] == 'C')
                && (content[pos + 2] == 'r' || content[pos + 2] == 'R')
                && (content[pos + 3] == 'i' || content[pos + 3] == 'I')
                && (content[pos + 4] == 'p' || content[pos + 4] == 'P')
                && (content[pos + 5] == 't' || content[pos + 5] == 'T'))
            {
                if (pos + 13 < content.Length)
                {
                    if (isLoadFist(content, pos + 6))
                    {
                        isLoadFirst = true;
                        return false;
                    }
                    else
                    {
                        if (isLoadFirst)
                        {
                            isLoadFirst = false;
                            return false;
                        }
                        return true;
                    }
                }

                else if (isLoadFirst)
                {
                    isLoadFirst = false;
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }
        else
            return false;

    }

    private bool isBodyTag(char[] content, int pos)
    {
        if (pos + 3 < content.Length)
            return ((content[pos] == 'b' || content[pos] == 'B')
                && (content[pos + 1] == 'o' || content[pos + 1] == 'O')
                && (content[pos + 2] == 'd' || content[pos + 2] == 'D')
                && (content[pos + 3] == 'y' || content[pos + 3] == 'Y'));
        else
            return false;
    }

    private bool isLoadFist(char[] content, int pos)
    {
        if (pos + 8 < content.Length)
        {
            if ((content[pos] == ' ')
                && (content[pos + 1] == 'i' || content[pos + 1] == 'I')
                && (content[pos + 2] == 'd' || content[pos + 1] == 'D')
                && (content[pos + 3] == '=')
                && (content[pos + 4] == '"')
                && (content[pos + 5] == 'l' || content[pos + 1] == 'L')
                && (content[pos + 6] == 'o' || content[pos + 1] == 'O')
                && (content[pos + 7] == 'a' || content[pos + 2] == 'A')
                && (content[pos + 8] == 'd' || content[pos + 3] == 'D'))
                return true;
            else if (isLoadFistAjaxScript(content, pos))
            {
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    private bool isLoadFistAjaxScript(char[] content, int pos)
    {
        //string flag = " src=\"/ScriptResource.axd?d=ivNrAv-_QBXTA9xqLI_tAMDshcOrleANEgg0MmryFrTCfV7gHKFIZCpe2jO_1P1xUC3_sUOWsvdo1t2nhGaZUXmGWxvIkazwUGWugwrC8yE1";
        string flag = " src=\"/ScriptResource.axd";
        //string flag = " src=\"/www.esoon-travel.com/ScriptResource.axd?d=52a3Rlvwcvf0xejFaHnMBo0Fs1bcOJhls";

        string flag2 = " src=\"/WebResource.axd";

        if (pos + 25 < content.Length)
        {
            StringBuilder temp = new StringBuilder(200);
            StringBuilder temp2 = new StringBuilder(200);
            temp.Append(content, pos, 25);
            temp2.Append(content, pos, 22);
            if (temp.ToString().ToLower().Equals(flag.ToLower()))
                return true;
            else if (temp2.ToString().ToLower().Equals(flag2.ToLower()))
                return true;
            else
                return false;


        }
        //if (pos + 82 < content.Length)
        //{
        //    StringBuilder temp = new StringBuilder(200);
        //    StringBuilder temp2 = new StringBuilder(200);
        //    temp.Append(content, pos, 82);
        //    temp2.Append(content, pos, 43);
        //    if (temp.ToString().ToLower().Equals(flag.ToLower()))
        //        return true;
        //    else if (temp2.ToString().ToLower().Equals(flag2.ToLower()))
        //        return true;
        //    else
        //        return false;

         //}
        else
            return false;
    }
}

public class ExchangeHTTP : Stream
{
    Stream responseStream;
    long position;

    /// <summary>
    /// When this is true, script blocks are suppressed and captured for 
    /// later rendering
    /// </summary>
    bool captureScripts;

    /// <summary>
    /// Holds all script blocks that are injected by the controls
    /// The script blocks will be moved after the form tag renders
    /// </summary>
    StringBuilder scriptBlocks;

    Encoding encoding;

    /// <summary>
    /// Holds characters from last Write(...) call where the start tag did not
    /// end and thus the remaining characters need to be preserved in a buffer so 
    /// that a complete tag can be parsed
    /// </summary>
    char[] pendingBuffer = null;

    string flag = "http";
    public ExchangeHTTP(HttpResponse response, string flag)
    {
        this.encoding = response.Output.Encoding;
        this.responseStream = response.Filter;

        this.flag = flag;

    }


    #region Filter overrides
    public override bool CanRead
    {
        get { return false; }
    }

    public override bool CanSeek
    {
        get { return false; }
    }

    public override bool CanWrite
    {
        get { return true; }
    }

    public override void Close()
    {
        this.FlushPendingBuffer();
        responseStream.Close();
    }

    private void FlushPendingBuffer()
    {
        /// Some characters were left in the buffer 
        if (null != this.pendingBuffer)
        {
            //this.WriteOutput(this.pendingBuffer, 0, this.pendingBuffer.Length);
            this.pendingBuffer = null;
        }

    }

    public override void Flush()
    {
        this.FlushPendingBuffer();
        responseStream.Flush();
    }

    public override long Length
    {
        get { return 0; }
    }

    public override long Position
    {
        get { return position; }
        set { position = value; }
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return responseStream.Seek(offset, origin);
    }

    public override void SetLength(long length)
    {
        responseStream.SetLength(length);
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        return responseStream.Read(buffer, offset, count);
    }
    #endregion
    public override void Write(byte[] buffer, int offset, int count)
    {
        //char[] content;
        StringBuilder contentSB = new StringBuilder();
        //content.ToString().ToCharArray();

        char[] charBuffer = this.encoding.GetChars(buffer, offset, count);
        int pos;
        for (pos = 0; pos < charBuffer.Length; pos++)
        {
            if (this.flag.ToLower().Equals("https"))
            {
                if (pos < charBuffer.Length - 7)
                {
                    string tag = charBuffer[pos].ToString() + charBuffer[pos + 1].ToString() + charBuffer[pos + 2].ToString() + charBuffer[pos + 3].ToString() + charBuffer[pos + 4].ToString() + charBuffer[pos + 5].ToString() + charBuffer[pos + 6].ToString();
                    if (tag.Equals("http://"))
                    {
                        contentSB.Append("https://");
                        pos = pos + 6;
                    }
                    else
                    {
                        contentSB.Append(charBuffer[pos]);
                    }
                }
                else
                {
                    contentSB.Append(charBuffer[pos]);
                }

            }
            else
            {
                if (pos < charBuffer.Length - 8)
                {
                    string tag = charBuffer[pos].ToString() + charBuffer[pos + 1].ToString() + charBuffer[pos + 2].ToString() + charBuffer[pos + 3].ToString() + charBuffer[pos + 4].ToString() + charBuffer[pos + 5].ToString() + charBuffer[pos + 6].ToString() + charBuffer[pos + 7].ToString();
                    if (tag.Equals("https://"))
                    {
                        contentSB.Append("http://");
                        pos = pos + 7;
                    }
                    else
                    {
                        contentSB.Append(charBuffer[pos]);
                    }
                }
                else
                {
                    contentSB.Append(charBuffer[pos]);

                }
            }
        }
        char[] content = contentSB.ToString().ToCharArray();
        byte[] contentBuffer = this.encoding.GetBytes(content, 0, content.Length);
        this.responseStream.Write(contentBuffer, 0, contentBuffer.Length);
    }
}
