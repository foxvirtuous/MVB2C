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
using Terms.Global.Utility;

public partial class PageNumber : System.Web.UI.UserControl
{
    public static string FilePath = string.Empty;
    private UpdatePanel m_targetUpdatePanel = null;

    public string PrefixID
    {
        get
        {
            return this.UniqueID;
        }
    }

    public void Update()
    {
        this.UpdatePanel1.Update();
    }

    public UpdatePanelUpdateMode UpdateMode
    {
        get { return this.UpdatePanel1.UpdateMode; }
        set { this.UpdatePanel1.UpdateMode = value; }
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
            if (currentPageNum.Value == "-1")
            {
                return 0;
            }
            //if (HttpContext.Current.Session["Session_FlightPageNumber"] != null)
            //{
            //    //currentPageNum.Value = HttpContext.Current.Session["Session_FlightPageNumber"].ToString();
            //    return int.Parse(HttpContext.Current.Session["Session_FlightPageNumber"].ToString());
            //}

            return Convert.ToInt32(currentPageNum.Value) - 1;
        }
        set
        {
            int temp = value + 1;
            currentPageNum.Value = temp.ToString();
        }
    }

    public void Refresh()
    {
        Page_Load(null, null);
    }

    public void RefreshDll()
    {
        DrawingNum(0);

        LblTotal.Text = PageAmount.ToString();
        ddlPageNumber.Items.Clear();
        for (int i = 1; i <= PageAmount; i++)
        {
            ddlPageNumber.Items.Add(i.ToString());
        }
        ddlPageNumber.SelectedValue = (CurrentPageIndex + 1).ToString();

        ddlPageNumber.Attributes["onchange"] = BuildToPageClientString("parseInt(this.options[this.selectedIndex].value)");
    }

    private void Page_Load(object sender, System.EventArgs e)
    {
        FilePath = Server.MapPath(@"Css/");
        //Lblnum.Text = (CurrentPageIndex + 1).ToString();
        LblTotal.Text = PageAmount.ToString();
        ddlPageNumber.Items.Clear();
        for (int i = 1; i <= PageAmount; i++)
        {
            ddlPageNumber.Items.Add(i.ToString());
        }
        try
        {
            ddlPageNumber.SelectedValue = (CurrentPageIndex + 1).ToString();
        }
        catch
        {

        }

        ddlPageNumber.Attributes["onchange"] = BuildToPageClientString("parseInt(this.options[this.selectedIndex].value)");

        if (pageFlag.Value.Trim().Length > 0)
        {
            DrawingNum(Convert.ToInt32(currentPageNum.Value.Trim()));
            pageFlag.Value = "";
        }
        else
        {
            LinkFirstPage.Enabled = false;
            LinkPrevPage.Enabled = false;
            if (PageAmount <= 1)
            {
                LinkLastPage.Enabled = false;
                LinkNextPage.Enabled = false;
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


        //ViewState["TabFlag"] = this.ID;
        //LinkNextPage.Attributes.Add("href", "#pnlSelectFare");
    }

    private string BuildToPageClientString(string idx)
    {
        string spt = "ToPage(" + idx + ",'" + currentPageNum.ClientID + "','" + pageFlag.ClientID + "');";
        return spt;
    }

    private string BuildToPageClientString(int index)
    {
        string spt = "ToPage(" + index.ToString() + ",'" + currentPageNum.ClientID + "','" + pageFlag.ClientID + "');";
        return spt;
    }
    public void DrawingNum()
    {
        DrawingNum(0);
    }

    public void DrawingNum(int currentindex)
    {
        //One page only, no need paging
        if (PageAmount == 1 || PageAmount == 0)
        {
            LinkFirstPage.Attributes["onclick"] = "";
            LinkLastPage.Attributes["onclick"] = "";
            LinkPrevPage.Attributes["onclick"] = "";
            LinkNextPage.Attributes["onclick"] = "";

            LinkFirstPage.Enabled = false;
            LinkLastPage.Enabled = false;
            LinkPrevPage.Enabled = false;
            LinkNextPage.Enabled = false;

            return;
        }

        LinkFirstPage.Enabled = true;
        LinkLastPage.Enabled = true;
        LinkFirstPage.Attributes["onclick"] = BuildToPageClientString(1);
        LinkLastPage.Attributes["onclick"] = BuildToPageClientString(PageAmount);

        //Invalid current index
        if (currentindex < 0)
            return;

        //Enable link button
        LinkPrevPage.Enabled = true;
        LinkNextPage.Enabled = true;

        GlobalUtility.SelectDropDownList(ddlPageNumber, currentindex.ToString(), true);

        if (currentindex == 0 || currentindex == 1)
        {
            LinkFirstPage.Attributes["onclick"] = "";
            LinkFirstPage.Enabled = false;

            LinkPrevPage.Enabled = false;
            LinkPrevPage.Attributes["onclick"] = "";

            LinkNextPage.Attributes["onclick"] = BuildToPageClientString(2);
        }
        else if (currentindex == PageAmount)
        {
            LinkPrevPage.Attributes["onclick"] = BuildToPageClientString(PageAmount - 1);

            LinkNextPage.Enabled = false;
            LinkNextPage.Attributes["onclick"] = "";

            LinkLastPage.Attributes["onclick"] = "";
            LinkLastPage.Enabled = false;
        }
        else
        {
            LinkPrevPage.Attributes["onclick"] = BuildToPageClientString(currentindex - 1);
            LinkNextPage.Attributes["onclick"] = BuildToPageClientString(currentindex + 1);
        }
    }
}