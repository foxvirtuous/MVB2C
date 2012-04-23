using Spring.Context;
using Spring.Context.Support;

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

using Terms.Global.Utility;
using Terms.Material.Service;
using Terms.Product.Utility;
using Terms.Common.Domain;
using Terms.Common.Dao;
using Terms.Common.Service;
using Terms.Sales.Dao;
using Terms.Sales.Domain;
using Terms.Sales.Utility;
using Terms.Sales.Service;
using Terms.Sales.Business;
using Terms.Base.Service;
using TERMS.Common;
using System.Text;
using System.Data.SqlClient;

public partial class Index : IndexPageBase
{
    private IApplicationCacheFoundationDate _ApplicationCacheFoundationDate;
    public IApplicationCacheFoundationDate ApplicationCacheFoundationDate
    {
        set
        {
            this._ApplicationCacheFoundationDate = value;
        }
    }

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

    public Index()
    {
        
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            //btn_SearchFare.Attributes.Add("onclick", "SeachOrder()");
            
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

        Ajax.Utility.RegisterTypeForAjax(typeof(Index));
    }
    private bool SearchA()
    {
        if (Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchAir, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchAir, this);

        Session["HasReminder"] = true;

        if (CheckSearch())
        {
            bool IsSelectAirport = false;
            bool IsRealCity = true;

            if (!IsRealCity)
            {
                if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                {
                    Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }

                Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
            }
            else
            {
                if (IsSelectAirport)
                {
                    Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                    {
                        Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }

                    Response.Redirect("~/Page/Flight/Searching.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Serarch", "<script>alert('Invaluable search condition.');</script>");
            return false;
        }

        return true;
    }

    private bool CheckSearch()
    {
        object obj = this.FindControl("SearchEngineA1_rdbRoundTrip");
        return true;
    }
}