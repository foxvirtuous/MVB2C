using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using AjaxControlToolkit;

public partial class PageNumberControl : System.Web.UI.UserControl
{

    public static string FilePath = string.Empty;

    public string PrefixID
    {
        get
        {
            return this.UniqueID;
        }
    }

    public int PageAmount
    {
        get
        {
            if (ViewState["PageAmount"] == null)
                return 0;

            return (int)ViewState["PageAmount"];
        }
        set
        {
            ViewState["PageAmount"] = value;
        }
    }

    public int ItemAmount
    {
        get
        {
            if (ViewState["ItemAmount"] == null)
                return 0;

            return (int)ViewState["ItemAmount"];
        }
        set
        {
            ViewState["ItemAmount"] = value;
        }
    }

    public int PageSize
    {
        get
        {
            if (ViewState["PageSize"] == null)
                return 20;

            return (int)ViewState["PageSize"];
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }

    public int CurrentPageIndex
    {
        get
        {
            if (currentPageNum.Value.Trim().Length == 0)
                return 0;

            return Convert.ToInt32(currentPageNum.Value) - 1;
        }
        set
        {
            currentPageNum.Value = (value + 1).ToString();

        }
    }

    private void Page_Load(object sender, System.EventArgs e)
    {
        FilePath = Server.MapPath(@"Css/");

        if (pageFlag.Value.Trim().Length > 0)
        {
            DrawingNum(Convert.ToInt32(currentPageNum.Value.Trim()));
            pageFlag.Value = "";
        }
        else
        {
            
            if (PageAmount <= 1)
            {
                hlStar.Enabled = false;
                hlEnd.Enabled = false;
                hlPrevious.Enabled = false;
                hlNext.Enabled = false;
            }
        }

        //×¢²á½Å±¾
        StringBuilder script = new StringBuilder();
        script.Append("<script language='javascript'>");
        script.Append("function ToPage(index, pageNumId, pageFlagId){");
        script.Append("document.getElementById(pageNumId).value = index;");
        script.Append("document.getElementById(pageFlagId).value =\"Paging\";");
        script.Append("document.forms[0].submit();}");
        script.Append("</script>");
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "SetPageChgFun", script.ToString());
     
    }
    private string BuildToPageClientString(string idx)
    {
        string spt = "ToPage(" + idx + ",'" + currentPageNum.ClientID + "','" + pageFlag.ClientID + "');";
        return spt;
    }

    public void DrawingNum()
    {
        DrawingNum(CurrentPageIndex);
    }

    public void DrawingNum(int currentindex)
    {
        //One page only, no need paging
        if (PageAmount == 1 || PageAmount == 0)
        {
            hlStar.Attributes["onclick"] = "";
            hlEnd.Attributes["onclick"] = "";
            hl1.Attributes["onclick"] = "";
            hl2.Attributes["onclick"] = "";
            hl3.Attributes["onclick"] = "";
            hl4.Attributes["onclick"] = "";
            hl5.Attributes["onclick"] = "";
            hlPrevious.Attributes["onclick"] = "";
            hlNext.Attributes["onclick"] = "";

            hlStar.Enabled = false;
            hlEnd.Enabled = false;
            hl1.Enabled = false;
            hl2.Enabled = false;
            hl3.Enabled = false;
            hl4.Enabled = false;
            hl5.Enabled = false;
            hlPrevious.Enabled = false;
            hlPrevious.Visible = false;
            hlNext.Enabled = false;
            return;
        }

        int iTemp = Convert.ToInt32(ItemAmount / PageSize);

        if (Convert.ToInt32(currentindex / 5) == 0)
        {
            hlStar.Visible = false;
        }
        else
        {
            hlStar.Visible = true;
            hlStar.Style["cursor"] = "hand";
            hlStar.Attributes["onclick"] = BuildToPageClientString(Convert.ToString(Convert.ToInt32(currentindex / 5) * 5));

        }

        int iMod = System.Data.SqlTypes.SqlInt32.Mod(new System.Data.SqlTypes.SqlInt32(ItemAmount), new System.Data.SqlTypes.SqlInt32(PageSize)).Value;

        if (iTemp == 0)
        {
            hlEnd.Visible = false;
        }
        else
        {
            if (Convert.ToInt32(currentindex / 5) == iTemp || ((Convert.ToInt32(currentindex / 5) * 5) + 6) > PageAmount)
            {
                hlEnd.Visible = false;
            }
            else
            {
                hlEnd.Visible = true;
                hlEnd.Style["cursor"] = "hand";
                hlEnd.Attributes["onclick"] = BuildToPageClientString(Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 6));


            }
        }
        if ((1 < iMod || Convert.ToInt32(currentindex / 5) < iTemp) && ((Convert.ToInt32(currentindex / 5) * 5) + 1) <= PageAmount)
        {
            //hl1.NavigateUrl = Request.CurrentExecutionFilePath + "?PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 1);
            hl1.Attributes["onclick"] = BuildToPageClientString(Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 1));
            hl1.Text = Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 1);
            if (hl1.Text.Equals((currentindex +1).ToString()))
            {
                hl1.Font.Size = new FontUnit("12");
                hl1.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                hl1.Font.Size = new FontUnit("10");
                hl1.ForeColor = System.Drawing.Color.Black;
            }
            hl1.Visible = true;
            hl1.Style["cursor"] = "hand";
        }
        else
        {
            hl1.Visible = false;
        }

        if ((11 < iMod || Convert.ToInt32(currentindex / 5) < iTemp) && ((Convert.ToInt32(currentindex / 5) * 5) + 2) <= PageAmount)
        {
            //hl2.NavigateUrl = Request.CurrentExecutionFilePath + "?PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 2);
            hl2.Attributes["onclick"] = BuildToPageClientString(Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 2));
            hl2.Text = Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 2);
            if (hl2.Text.Equals((currentindex + 1).ToString()))
            {
                hl2.Font.Size = new FontUnit("12");
                hl2.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                hl2.Font.Size = new FontUnit("10");
                hl2.ForeColor = System.Drawing.Color.Black;
            }
            hl2.Visible = true;
            hl2.Style["cursor"] = "hand";
        }
        else
        {
            hl2.Visible = false;
        }

        if ((21 < iMod || Convert.ToInt32(currentindex / 5) < iTemp) && ((Convert.ToInt32(currentindex / 5) * 5) + 3) <= PageAmount)
        {
            // hl3.NavigateUrl = Request.CurrentExecutionFilePath + "?PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 3);
            hl3.Attributes["onclick"] = BuildToPageClientString(Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 3));
            hl3.Text = Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 3);
            if (hl3.Text.Equals((currentindex + 1).ToString()))
            {
                hl3.Font.Size = new FontUnit("12");
                hl3.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                hl3.Font.Size = new FontUnit("10");
                hl3.ForeColor = System.Drawing.Color.Black;
            }
            hl3.Visible = true;
            hl3.Style["cursor"] = "hand";
        }
        else
        {
            hl3.Visible = false;
        }

        if ((31 < iMod || Convert.ToInt32(currentindex / 5) < iTemp) && ((Convert.ToInt32(currentindex / 5) * 5) + 4) <= PageAmount)
        {
            //hl4.NavigateUrl = Request.CurrentExecutionFilePath + "?PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 4);
            hl4.Attributes["onclick"] = BuildToPageClientString(Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 4));
            hl4.Text = Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 4);
            if (hl4.Text.Equals((currentindex + 1).ToString()))
            {
                hl4.Font.Size = new FontUnit("12");
                hl4.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                hl4.Font.Size = new FontUnit("10");
                hl4.ForeColor = System.Drawing.Color.Black;
            }
            hl4.Visible = true;
            hl4.Style["cursor"] = "hand";
        }
        else
        {
            hl4.Visible = false;
        }


        if ((41 < iMod || Convert.ToInt32(currentindex / 5) < iTemp) && ((Convert.ToInt32(currentindex / 5) * 5) + 5) <= PageAmount)
        {
            //hl5.NavigateUrl = Request.CurrentExecutionFilePath + "?PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 5);
            hl5.Attributes["onclick"] = BuildToPageClientString(Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 5));
            hl5.Text = Convert.ToString((Convert.ToInt32(currentindex / 5) * 5) + 5);
            if (hl5.Text.Equals((currentindex + 1).ToString()))
            {
                hl5.Font.Size = new FontUnit("12");
                hl5.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                hl5.Font.Size = new FontUnit("10");
                hl5.ForeColor = System.Drawing.Color.Black;
            }
            hl5.Visible = true;
            hl5.Style["cursor"] = "hand";
        }
        else
        {
            hl5.Visible = false;
        }

        if (CurrentPageIndex > 0)
        {
            hlPrevious.Attributes["onclick"] = BuildToPageClientString(Convert.ToString(currentindex - 1));
            hlPrevious.Style["cursor"] = "hand";
            hlPrevious.Enabled = true;
        }
        else
        {
            hlPrevious.Attributes["onclick"] = "";
            hlPrevious.Style["cursor"] = "";
            hlPrevious.Enabled = false;
        }
        if (CurrentPageIndex < PageAmount -1)
        {
            hlNext.Attributes["onclick"] = BuildToPageClientString(Convert.ToString(currentindex + 2));
            hlNext.Style["cursor"] = "hand";
            hlNext.Enabled = true;
        }
        else
        {
            hlNext.Attributes["onclick"] = "";
            hlNext.Style["cursor"] = "";
            hlNext.Enabled = false;
        }

    }

}
