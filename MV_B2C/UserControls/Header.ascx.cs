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
using System.Threading;

public partial class Header : GlobalBaseControl
{
    private string path = string.Empty;

    #region Property
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

    public string WebsitImageName
    {
        get
        {
            if (Utility.IsSubAgent)
            {
                return "logob2b.gif";
            }
            else
            {
                return "logo.gif";
            }
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
                return "http://" + UrlHost + path + "/";

        }
    }

    public string CurrentTabName
    {
        set 
        {
            this.CurrentTab.Value = value;
        }
    }

    #endregion

    public Header()
    {
        this.InitializeControls += new EventHandler(Header_InitializeControls);
    }

    protected void Header_InitializeControls(object sender, EventArgs e)
    {
        ibnChinese.Command += new CommandEventHandler(this.SetLanguage);
        ibnEnglish.Command += new CommandEventHandler(this.SetLanguage);
        if (UserCulture.Name.Contains("zh-CN"))
        {
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsLogin)
        {
            lbName.Text = "welcome, " + Utility.Transaction.Member.FirstName + "|";
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
            PlaceHolder3.Visible = true;
            phSubTour.Visible = true;
            phSubInsurance.Visible = true;
            phSubIncentiveTour.Visible = true;
        }
        else
        {
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = false;
            phSubTour.Visible = false;
            phSubInsurance.Visible = false;
            phSubIncentiveTour.Visible = false;

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

        if (Utility.IsSubAgent)
        {

        }
        else
        {
            aHeaderHome.NavigateUrl = SaleWebSuffix + "Index.aspx";
            aHeaderF.NavigateUrl = SaleWebSuffix + "Flightindex.aspx?tab=F";
            aHeaderT.NavigateUrl = SaleWebSuffix + "Tourindex.aspx?tab=T";
            aHeaderAH.NavigateUrl = SaleWebSuffix + "PackageIndex.aspx?tab=AH";
            aHeaderH.NavigateUrl = SaleWebSuffix + "HotelIndex.aspx?tab=H";
            aHeaderC.NavigateUrl = SaleWebSuffix + "CruiseIndex.aspx?tab=C";
            aHeaderI.NavigateUrl = SaleWebSuffix + "Page/IncentiveTour/InputIncentiveTour.aspx?tab=I";
            aHeaderB.NavigateUrl = SaleWebSuffix + "B2B_SUB/Login.aspx?tab=B";

            switch (Tagle)
            {
                case "F":
                    aHeaderHome.CssClass = "header_off";
                    aHeaderF.CssClass = "header_on";
                    aHeaderT.CssClass = "header_off";
                    aHeaderAH.CssClass = "header_off";
                    aHeaderH.CssClass = "header_off";
                    aHeaderC.CssClass = "header_off";
                    aHeaderI.CssClass = "header_off";
                    aHeaderB.CssClass = "header_off";

                    tdHeaderHome.Attributes.Add("class", "");
                    tdHeaderF.Attributes.Add("class", "D_header");
                    tdHeaderT.Attributes.Add("class", "");
                    tdHeaderAH.Attributes.Add("class", "");
                    tdHeaderH.Attributes.Add("class", "");
                    tdHeaderC.Attributes.Add("class", "");
                    tdIncentiveTour.Attributes.Add("class", "");
                    tdSubAgent.Attributes.Add("class", "");
                    break;
                case "T":
                    aHeaderHome.CssClass = "header_off";
                    aHeaderF.CssClass = "header_off";
                    aHeaderT.CssClass = "header_on";
                    aHeaderAH.CssClass = "header_off";
                    aHeaderH.CssClass = "header_off";
                    aHeaderC.CssClass = "header_off";
                    aHeaderI.CssClass = "header_off";
                    aHeaderB.CssClass = "header_off";
                    tdHeaderHome.Attributes.Add("class", "");
                    tdHeaderF.Attributes.Add("class", "");
                    tdHeaderT.Attributes.Add("class", "D_header");
                    tdHeaderAH.Attributes.Add("class", "");
                    tdHeaderH.Attributes.Add("class", "");
                    tdHeaderC.Attributes.Add("class", "");
                    tdIncentiveTour.Attributes.Add("class", "");
                    tdSubAgent.Attributes.Add("class", "");
                    break;
                case "AH":
                    aHeaderHome.CssClass = "header_off";
                    aHeaderF.CssClass = "header_off";
                    aHeaderT.CssClass = "header_off";
                    aHeaderAH.CssClass = "header_on";
                    aHeaderH.CssClass = "header_off";
                    aHeaderC.CssClass = "header_off";
                    aHeaderI.CssClass = "header_off";
                    aHeaderB.CssClass = "header_off";
                    tdHeaderHome.Attributes.Add("class", "");
                    tdHeaderF.Attributes.Add("class", "");
                    tdHeaderT.Attributes.Add("class", "");
                    tdHeaderAH.Attributes.Add("class", "D_header");
                    tdHeaderH.Attributes.Add("class", "");
                    tdHeaderC.Attributes.Add("class", "");
                    tdIncentiveTour.Attributes.Add("class", "");
                    tdSubAgent.Attributes.Add("class", "");
                    break;
                case "H":
                    aHeaderHome.CssClass = "header_off";
                    aHeaderF.CssClass = "header_off";
                    aHeaderT.CssClass = "header_off";
                    aHeaderAH.CssClass = "header_off";
                    aHeaderH.CssClass = "header_on";
                    aHeaderC.CssClass = "header_off";
                    aHeaderI.CssClass = "header_off";
                    aHeaderB.CssClass = "header_off";
                    tdHeaderHome.Attributes.Add("class", "");
                    tdHeaderF.Attributes.Add("class", "");
                    tdHeaderT.Attributes.Add("class", "");
                    tdHeaderAH.Attributes.Add("class", "");
                    tdHeaderH.Attributes.Add("class", "D_header");
                    tdHeaderC.Attributes.Add("class", "");
                    tdIncentiveTour.Attributes.Add("class", "");
                    tdSubAgent.Attributes.Add("class", "");
                    break;
                case "C":
                    aHeaderHome.CssClass = "header_off";
                    aHeaderF.CssClass = "header_off";
                    aHeaderT.CssClass = "header_off";
                    aHeaderAH.CssClass = "header_off";
                    aHeaderH.CssClass = "header_off";
                    aHeaderC.CssClass = "header_on";
                    aHeaderI.CssClass = "header_off";
                    aHeaderB.CssClass = "header_off";
                    tdHeaderHome.Attributes.Add("class", "");
                    tdHeaderF.Attributes.Add("class", "");
                    tdHeaderT.Attributes.Add("class", "");
                    tdHeaderAH.Attributes.Add("class", "");
                    tdHeaderH.Attributes.Add("class", "");
                    tdHeaderC.Attributes.Add("class", "D_header");
                    tdIncentiveTour.Attributes.Add("class", "");
                    tdSubAgent.Attributes.Add("class", "");
                    break;
                case "I":
                    aHeaderHome.CssClass = "header_off";
                    aHeaderF.CssClass = "header_off";
                    aHeaderT.CssClass = "header_off";
                    aHeaderAH.CssClass = "header_off";
                    aHeaderH.CssClass = "header_off";
                    aHeaderC.CssClass = "header_off";
                    aHeaderI.CssClass = "header_on";
                    aHeaderB.CssClass = "header_off";
                    tdHeaderHome.Attributes.Add("class", "");
                    tdHeaderF.Attributes.Add("class", "");
                    tdHeaderT.Attributes.Add("class", "");
                    tdHeaderAH.Attributes.Add("class", "");
                    tdHeaderH.Attributes.Add("class", "");
                    tdHeaderC.Attributes.Add("class", "");
                    tdIncentiveTour.Attributes.Add("class", "D_header");
                    tdSubAgent.Attributes.Add("class", "");
                    break;
                case "B":
                    aHeaderHome.CssClass = "header_off";
                    aHeaderF.CssClass = "header_off";
                    aHeaderT.CssClass = "header_off";
                    aHeaderAH.CssClass = "header_off";
                    aHeaderH.CssClass = "header_off";
                    aHeaderC.CssClass = "header_off";
                    aHeaderI.CssClass = "header_off";
                    aHeaderB.CssClass = "header_on";
                    tdHeaderHome.Attributes.Add("class", "");
                    tdHeaderF.Attributes.Add("class", "");
                    tdHeaderT.Attributes.Add("class", "");
                    tdHeaderAH.Attributes.Add("class", "");
                    tdHeaderH.Attributes.Add("class", "");
                    tdHeaderC.Attributes.Add("class", "");
                    tdIncentiveTour.Attributes.Add("class", "");
                    tdSubAgent.Attributes.Add("class", "D_header");
                    break;
                default:
                    aHeaderHome.CssClass = "header_on";
                    aHeaderF.CssClass = "header_off";
                    aHeaderT.CssClass = "header_off";
                    aHeaderAH.CssClass = "header_off";
                    aHeaderH.CssClass = "header_off";
                    aHeaderC.CssClass = "header_off";
                    aHeaderI.CssClass = "header_off";
                    aHeaderB.CssClass = "header_off";
                    tdHeaderHome.Attributes.Add("class", "D_header");
                    tdHeaderF.Attributes.Add("class", "");
                    tdHeaderT.Attributes.Add("class", "");
                    tdHeaderAH.Attributes.Add("class", "");
                    tdHeaderH.Attributes.Add("class", "");
                    tdHeaderC.Attributes.Add("class", "");
                    tdIncentiveTour.Attributes.Add("class", "");
                    tdSubAgent.Attributes.Add("class", "");
                    break;
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

    public void SetLanguageAndPhone()
    {
        lblMoreInfo.Visible = false;
        lblPhone.Visible = false;
        pButton.Visible = false;
    }

    public string Tagle
    {
        get
        {
            if (Request["tab"] != null)
                return Request["tab"].Trim().ToUpper();
            else
                return string.Empty;
        }
    }
}
