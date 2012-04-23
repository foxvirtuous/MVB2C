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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

/// <summary>
/// Summary description for CombineScripts
/// </summary>
public class CombineScripts
{
    private static Regex _FindScriptTags = new Regex(@"<script\s*src\s*=\s*""(?<url>.[^""]+)"".[^>]*>\s*</script>", RegexOptions.Compiled);
    
    /// <summary>
    /// Combine script references using file sets defined in a configuration file.
    /// It will replace multiple script references using one 
    /// </summary>
    public static string CombineScriptBlocks(string scripts)
    {
        List<UrlMapSet> sets = LoadSets();
        string output = scripts;

        foreach (UrlMapSet UrlMapSet in sets)
        {
            int setStartPos = -1;
            List<string> names = new List<string>();
                
            output = _FindScriptTags.Replace(output, new MatchEvaluator(delegate(Match match)
            {
                string url = match.Groups["url"].Value;

                UrlMap urlMatch = UrlMapSet.Urls.Find(
                    new Predicate<UrlMap>(
                        delegate(UrlMap map)
                        {
                            return map.Url == url;
                        }));

                if( null != urlMatch )
                {
                    // Rememer the first script tag that matched in this UrlMapSet because
                    // this is where the combined script tag will be inserted
                    if (setStartPos < 0) setStartPos = match.Index;
                
                    names.Add(urlMatch.Name);
                    return string.Empty;
                }
                else
                {
                    return match.Value;
                }
                
            }));

            if (setStartPos >= 0)
            {
                names.Sort();

                string setName = string.Join(",", names.ToArray());
                string urlPrefix = HttpContext.Current.Request.Path.Substring(0, HttpContext.Current.Request.Path.LastIndexOf('/')+1);
                string newScriptTag = "<script type=\"text/javascript\" src=\"Scripts.ashx?" + UrlMapSet.Name + "=" + setName + "&" + urlPrefix + "\"></script>";

                output = output.Insert(setStartPos, newScriptTag);
            }
        }

        return output;
    }

    public static List<UrlMapSet> LoadSets()
    {
        List<UrlMapSet> sets = new List<UrlMapSet>();

        using (XmlReader reader = new XmlTextReader(new StreamReader(HttpContext.Current.Server.MapPath("~/Config/FileSets.xml"))))
        {
            reader.MoveToContent();
            while (reader.Read())
            {
                if ("set" == reader.Name)
                {
                    string setName = reader.GetAttribute("name");
                    UrlMapSet UrlMapSet = new UrlMapSet();
                    UrlMapSet.Name = setName;

                    while (reader.Read())
                    {
                        if ("url" == reader.Name)
                        {
                            string urlName = reader.GetAttribute("name");
                            string url = reader.ReadElementContentAsString();
                            UrlMapSet.Urls.Add(new UrlMap(urlName, url));
                        }
                        else if ("set" == reader.Name)
                            break;
                    }

                    sets.Add(UrlMapSet);
                }
            }
        }

        return sets;
    }

    
    
}

public class UrlMapSet
{
    public string Name;
    public List<UrlMap> Urls = new List<UrlMap>();
}

public class UrlMap
{
    public string Name;
    public string Url;

    public UrlMap(string name, string url)
    {
        this.Name = name;
        this.Url = url;
    }
}
