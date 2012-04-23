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
using Spring.Web.UI;
using Terms.Material.Service;
using Terms.Common.Service;
using Terms.Sales.Service;
using Terms.Base.Service;
using System.Globalization;


public partial class PromosIndex : IndexPageBase
{
    public Terms.Sales.Business.Transaction Transaction
    {
        set
        {
            Utility.Transaction = value;
        }
        get
        {
            return Utility.Transaction;
        }
    }

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

            if (port == 80)
                return "http://" + UrlHost + path + "/";
            else
                return "http://" + UrlHost + ":" + port.ToString() + path + "/";
        }
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Header1.SetLanguageAndPhone();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["tab"] != null && Request.QueryString["tab"] != "")
            {
                this.CurrentTab.Value = Request.QueryString["tab"].ToString();
            }
            else
            {
            }

            Header1.CurrentTabName = "P";
        }

        //重定义KeyWords
        if (UserCulture.Name.Contains("zh-CN"))
        {
            PageUtility.AddHtmlMeta(this.Page, "keywords", "明星假期旅遊網, 美國國內機票, 亞洲機票, 台灣,香港,北京,上海 特廉機票, 中國國內機票優惠, 最便宜酒店, 全球酒店線上訂購, 套裝行程,機票+酒店, 旅遊, 超值旅遊,台灣旅遊,中國旅遊,美國東岸,西岸,夏威夷,奧蘭多, 亞洲旅遊, 兩人成行, 郵輪旅遊, 皇家旅遊,公主郵輪, 旅遊同業中心, 機票代理中心");
            PageUtility.AddHtmlMeta(this.Page, "description", "明星假期旅遊, 最豐富,最便宜, 最便宜機票, 美國到中國機票, 酒店, 兩人成行自由行, 旅遊, 郵輪假期");
        }
        else
        {
            PageUtility.AddHtmlMeta(this.Page, "keywords", "Majestic Vacations, Cheap air tickets, Cheap flights to china, Cheap hotels, hotel rooms, vacation packages, group tours, cruises, cruise deals, depart from american, online ticket booking, China travel, US travel agency");
            PageUtility.AddHtmlMeta(this.Page, "description", "airline tickets, hotel reservations, find vacation packages, find tours , cruise deals and purchase, China Tours, China Tour Packages, Beijing tour, Shanghai tour, Yangtze River Cruise tours, China Hotel, China Travel Packages");
        }

        //加CSS
        PageUtility.AddHtmlLink(this.Page, SaleWebSuffix + MainCssPath + "style_index.css");

        
        Ajax.Utility.RegisterTypeForAjax(typeof(Index));
    }
}
