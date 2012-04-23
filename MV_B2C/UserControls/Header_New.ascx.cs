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
using System.Globalization;


public partial class Header_New : GlobalBaseControl
{
    #region Property

    private string path = string.Empty;

    /// <summary>
    /// The Path
    /// </summary>
    public string Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }

    public string SaleWebSuffix
    {
        get
        {
            return PageUtility.UrlSuffix;
        }
    }

    public string RawUrl
    {
        get
        {
            return this.Request.RawUrl;
        }
    }

    private string AbsolutePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
    private string UrlHost
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Request.Url.Host;
            else
                return string.Empty;
        }

    }

    private string VirtualPath
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Request.ApplicationPath;
            else
                return string.Empty;
        }

    }

    private string UrlSuffix
    {
        get
        {
            //段口
            int port = HttpContext.Current.Request.Url.Port;

            //虚拟目录
            string path = VirtualPath;
            if (path == "/") path = "";

            //if (port == 80)
            return "http://" + UrlHost + path + "/";
            //else
            //    return "http://" + UrlHost + ":" + port.ToString() + path + "/";
        }
    }

    #endregion

    public Header_New()
    {
        this.InitializeControls += new EventHandler(Header_New_InitializeControls);
    }

    protected void Header_New_InitializeControls(object sender, EventArgs e)
    {
        ibnChinese.Command += new CommandEventHandler(this.SetLanguage);
        ibnEnglish.Command += new CommandEventHandler(this.SetLanguage);
        if (UserCulture.Name.Contains("zh-CN"))
        {
            tdSubAgent.Visible = false;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsLogin)
        {
            lbName.Text = Utility.Transaction.Member.FirstName + ",";
            lbtnJoin.Visible = false;
            lbtnLogin.Visible = false;
            lbtnLogout.Visible = true;
            lbtnMyAccount.Visible = true;
        }
        else
        {
            lbtnJoin.Visible = true;
            lbtnLogin.Visible = true;
            lbtnLogout.Visible = false;
            lbtnMyAccount.Visible = false;
        }

        if (Utility.IsSubAgent)
        {
            divChat.Visible = false;
            PlaceHolder1.Visible = false;
            lbtnJoin.NavigateUrl = SaleWebSuffix + "B2B_SUB/Join.aspx";
            lbtnLogin.NavigateUrl = SaleWebSuffix + "B2B_SUB/Login.aspx";
            lbtnLogout.NavigateUrl = SaleWebSuffix + "B2B_SUB/Logout.aspx";
            lbtnMyAccount.NavigateUrl = SaleWebSuffix + "B2B_SUB/AgentMyAccountForm.aspx";
            PlaceHolder2.Visible = true;
        }
        else
        {
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;

            if (HttpContext.Current.Request.Url.ToString().ToUpper().Contains("b2b".ToUpper()))
            {
                divChat.Visible = false;
                lbtnJoin.NavigateUrl = SaleWebSuffix + "B2B_SUB/Join.aspx";
                lbtnLogin.NavigateUrl = SaleWebSuffix + "B2B_SUB/Login.aspx";
                lbtnLogout.NavigateUrl = SaleWebSuffix + "B2B_SUB/Logout.aspx";
                lbtnMyAccount.NavigateUrl = SaleWebSuffix + "B2B_SUB/AgentMyAccountForm.aspx";
            }
            else
            {
                divChat.Visible = true;
                lbtnJoin.NavigateUrl = SaleWebSuffix + "Page/Common/register.aspx";
                lbtnLogin.NavigateUrl = SaleWebSuffix + "Page/Common/SalesLogin.aspx";
                lbtnLogout.NavigateUrl = SaleWebSuffix + "Page/Common/Logout.aspx";
                lbtnMyAccount.NavigateUrl = SaleWebSuffix + "Page/Common/MemberMyAccountForm.aspx";
            }
        }
    }

    public void SetLanguage(object sender, CommandEventArgs e)
    {
        string cultureString = e.CommandArgument as string;
        if (cultureString != null)
        {
            UserCulture = new CultureInfo(cultureString);

        }
        //重定向页面
        Response.Redirect(Request.Url.PathAndQuery);
    }
}
