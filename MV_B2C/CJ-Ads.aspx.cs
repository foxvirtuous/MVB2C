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


public partial class CJ_Ads : IndexPageBase
{
    public string SaleWebSuffix
    {
        get
        {
            return PageUtility.UrlSuffix;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        if (Request.Params["Lan"] != null)
        {
            if (Request.Params["Lan"].ToString().ToUpper().Equals("CN"))
            {
                UserCulture = new CultureInfo("zh-CN");
                //重定向页面
                Response.Redirect(Request.Url.LocalPath);
            }
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


        if (!Page.IsPostBack)
        {
            //记录Index方面访问
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.DirectFrom, this);

            if (Request.QueryString["tab"] != null && Request.QueryString["tab"] != "")
            {
                this.CurrentTab.Value = Request.QueryString["tab"].ToString();
            }
            else
            {
            }
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(CJ_Ads));
    }
}

