using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using TERMS.Common.Search;
using TERMS.Core.Product;
using Terms.Configuration.Domain;
using Spring.Aspects.AirOperate;
using Spring.Context.Support;
using System.Threading;


public class SalesBaseUserControl : Spring.Web.UI.UserControl
{
    private const string TOUR_CN = "tour_cn";
    private const string TOUR_EN = "tour_en";

    public string tourType
    {
        get
        {
            if (UserCulture.Name.Contains("zh-CN"))
            {
                return TOUR_CN;
            }
            else
            {
                return TOUR_EN;
            }
        }
    }
    private MerchandiseSearcher _MerchandiseSearcher;
    public MerchandiseSearcher MerchandiseSearcher
    {
        set
        {
            this._MerchandiseSearcher = value;
        }
        get { return _MerchandiseSearcher; }
    }

    public virtual AirStepConfirmLogAdvice OperaterAdvice
    {
        get
        {
            return new AirStepConfirmLogAdvice();
        }
    }

    public string ImageUrlHead
    {

        get { return System.Configuration.ConfigurationManager.AppSettings["URL.Head"]; }
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

    protected string PATH = "";


    public bool IsSearchConditionNull
    {
        get
        {
            return Utility.IsSearchConditionNull;
        }
    }

    //出错时重定向的页面地址
    public string ReturnUrlPath
    {
        set
        {
            System.Web.HttpContext.Current.Session["ReturnUrlPath"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["ReturnUrlPath"] == null)
            {
                System.Web.HttpContext.Current.Session["ReturnUrlPath"] = string.Empty;
            }

            return System.Web.HttpContext.Current.Session["ReturnUrlPath"].ToString();
        }
    }

    public Merchandise OnSearch()
    {
        if (this.IsSearchConditionNull)
        {
            return null;
        }
        else
        {
            if (!HttpContext.Current.Request.RawUrl.Contains("Searching1")) //Search出错，返回最后一个操作页面。如遇到Searching1.aspx则跳过，因为返回Searching1.aspx会导致重复出错
                ReturnUrlPath = HttpContext.Current.Request.RawUrl;

            ISearchCondition searchCondition = this.Transaction.CurrentSearchConditions;

            //Merchandise _Merchandise = MerchandiseSearcher.Search(searchCondition);

            MVMerchandiseSearcher searcher = new MVMerchandiseSearcher();

            if (searchCondition is Terms.Sales.Business.AirSearchCondition)
            {
                if (Session["LOG_RANDOM"] != null)
                {
                    searcher.LogRandomID = Session["LOG_RANDOM"].ToString();
                }
            }
            else if (searchCondition is Terms.Sales.Business.HotelSearchCondition)
            {
                searcher.LogRandomID = PageUtility.HotelLogRandomNumber.ToString();
            }

            Merchandise _Merchandise;

            if (searchCondition is Terms.Sales.Business.TourSearchCondition && Utility.IsTourMain)
            {
                if (Utility.IsTourMore)
                {
                    _Merchandise = (Merchandise)searcher.TourSearch(searchCondition, Utility.TourCitys, UserCulture.Name);
                }
                else
                {
                    _Merchandise = (Merchandise)searcher.TourSearch(UserCulture.Name);
                }
            }
            else if (searchCondition is Terms.Sales.Business.TourSearchCondition)
            {
                _Merchandise = (Merchandise)searcher.Search(searchCondition, UserCulture.Name);
            }
            else
            {
                _Merchandise = (Merchandise)searcher.Search(searchCondition);
            }

            if (_Merchandise == null)
            {
                if (searchCondition is Terms.Sales.Business.AirSearchCondition)
                    Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx");
                else if (searchCondition is Terms.Sales.Business.HotelSearchCondition)
                    this.Response.Redirect("~/Page/Hotel2/SearchConditionsMeassageHForm.aspx?ErrorMessage=123");
                else if (searchCondition is Terms.Sales.Business.TourSearchCondition)
                    Response.Redirect("~/Page/Tour/SearchConditionsMeassageTForm.aspx");
                else if (searchCondition is Terms.Sales.Business.VehcileSearchCondition)
                    Response.Redirect("~/index.aspx");
                else
                    this.Response.Redirect("~/Page/Package2/SearchConditionsMeassageAHForm.aspx?ErrorMessage=" + searcher.Errors);
            }
            else if (_Merchandise != null)
            {
                if (searchCondition is Terms.Sales.Business.AirSearchCondition && ((AirMerchandise)_Merchandise).Items == null)
                    Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx");
                else if (searchCondition is Terms.Sales.Business.PackageSearchCondition && ((PackageMerchandise)_Merchandise).Items == null)
                {
                    this.Response.Redirect("~/Page/Package2/SearchConditionsMeassageAHForm.aspx?ErrorMessage=" + searcher.Errors);
                }
                else if (searchCondition is Terms.Sales.Business.HotelSearchCondition && ((HotelMerchandise)_Merchandise).Items == null)
                {
                    this.Response.Redirect("~/Page/Hotel2/SearchConditionsMeassageHForm.aspx?ErrorMessage=123");
                }
                else if (searchCondition is Terms.Sales.Business.VehcileSearchCondition && ((VehcileMerchandise)_Merchandise).Items == null)
                {
                    Response.Redirect("~/index.aspx");
                }
                else if (searchCondition is Terms.Sales.Business.TourSearchCondition && ((TourMerchandise)_Merchandise).Items == null)
                    Response.Redirect("~/Page/Tour/SearchConditionsMeassageTForm.aspx");
            }
            return _Merchandise;
        }
    }
    public Merchandise TourOnSearch()
    {
        MVMerchandiseSearcher searcher = new MVMerchandiseSearcher();
        Merchandise _Merchandise = (Merchandise)searcher.TourSearch(UserCulture.Name);
        if (_Merchandise == null)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=" + searcher.Errors);
        }
        return _Merchandise;
    }

    public TERMS.Business.Centers.ProductCenter.Components.TransferProduct SearchTransfer(Terms.Sales.Business.TransferSearchCondition transferSearchCondition)
    {
        //if (this.IsSearchConditionNull)
        //{
            return null;
        //}
        //else
        //{
        //    if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        MVMerchandiseSearcher searcher = new MVMerchandiseSearcher();

        //        return searcher.SearchTransfer(transferSearchCondition);
        //    }
        //}
    }

    public SalesBaseUserControl()
    {
        this.InitializeControls += new EventHandler(SalesBaseUserControl_InitializeControls);
        this.PreRender += new EventHandler(SalesBaseUserControl_PreRender);
    }

    void SalesBaseUserControl_PreRender(object sender, EventArgs e)
    {
        if (this.Request.RawUrl.ToUpper().Contains(@"/Index.aspx".ToUpper()))
        {
            if (Utility.IsSubAgent)
            {
                if (!this.Request.RawUrl.ToUpper().Contains(@"B2B_SUB/Index.aspx".ToUpper()))
                {
                    this.Response.Redirect("~/B2B_SUB/Index.aspx");
                }
            }
        }
    }

    private void SalesBaseUserControl_InitializeControls(object sender, EventArgs e)
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    }

    protected SessionClass CurrentSession
    {
        get
        {
            if (Session["CurrentSession"] == null)
                Session["CurrentSession"] = new SessionClass();

            return (SessionClass)Session["CurrentSession"];
        }
        set
        {
            Session["CurrentSession"] = value;
        }
    }

    protected bool SessionExpired
    {
        get
        {
            if (Session["CurrentSession"] == null)
                return true;
            else
                return false;
        }
    }

    protected void Err(string error, string errorFlag, string ErrPageName)
    {
        string[] errorMessage = new string[3];

        errorMessage[0] = error;
        errorMessage[1] = errorFlag;
        errorMessage[2] = ErrPageName;

        Session["Error"] = errorMessage;
        Response.Redirect(PATH + "Error.aspx");
    }

   

    #region "Path" 
    
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

    public string SecureUrlSuffix
    {
        get
        {
            return PageUtility.SecureUrlSuffix;
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
    public const string Const_WebSite = "www.majestic-vacations.com";
    public const string WebSiteName = "WebSiteName";

    public static WebSiteMeta CurrentWebSite
    {
        get
        {
            if (HttpContext.Current == null) return null;

            if (HttpContext.Current.Session["CurrentWebSite"] == null)
            {
                HttpContext.Current.Session["CurrentWebSite"] =
                    ((Terms.Configuration.Service.IWebSiteService)ContextRegistry.GetContext()["WebSiteService"]).Get(Const_WebSite);

                if (HttpContext.Current.Session["CurrentWebSite"] == null)
                {
                    HttpContext.Current.Session["CurrentWebSite"] = new WebSiteMeta();
                }
            }

            return (WebSiteMeta)HttpContext.Current.Session["CurrentWebSite"];
        }
        set
        {
            HttpContext.Current.Session.Add("CurrentWebSite", value);
        }
    }

    #endregion
    /// <summary>
    /// 设置WebSite信息
    /// </summary>
    public void SetWebSiteInfomation()
    {
        if (CurrentWebSite == null) return;

        if (CurrentWebSite.Id != Guid.Empty)
        {
            ConfigurationSettings.AppSettings.Set(WebSiteName, CurrentWebSite.Name);
        }
    }

    protected virtual string SourceName
    {
        get
        {
            return GlobalBaseUtility.GetClassName(GlobalBaseUtility.GetWebSite(Request.Url));
        }
    }
}
