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

using Spring.Web.UI;
using log4net;
using System.Collections;
using Terms.Common.Service;
using Terms.Common.Domain;
using Terms.Base.Service;

using Spring.Context;
using Spring.Context.Support;

using System.Web.Services;
using AjaxControlToolkit;


using TERMS.Business.Centers.SalesCenter;
using TERMS.Common.Search;
using Terms.Sales.Business;
//using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Service;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Core.Product;
using Spring.Aspects.AirOperate;
using Terms.Configuration.Domain;
using System.Threading;
using System.IO;




/// <summary>
/// SalseBasePage 的摘要说明
/// </summary>
public class SalseBasePage : Spring.Web.UI.Page
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

    private static readonly log4net.ILog log =
             log4net.LogManager.GetLogger("AirSearchTime");

    private static readonly log4net.ILog hotelLog =
         log4net.LogManager.GetLogger("HotelSearchTime");

    private static readonly log4net.ILog hotelSearchHotelByZyl =
         log4net.LogManager.GetLogger("HotelSearchPerformanceDebugging");


    private MerchandiseSearcher _MerchandiseSearcher;
    public MerchandiseSearcher MerchandiseSearcher
    {
        set
        {
            this._MerchandiseSearcher = value;
        }
        get { return _MerchandiseSearcher; }
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

    public virtual AirStepConfirmLogAdvice OperaterAdvice
    {
        get
        {
            return new AirStepConfirmLogAdvice();
        }
    }



    public bool IsSearchConditionNull
    {
        get
        {
            return Utility.IsSearchConditionNull;
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
            DateTime dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Debug("MV_B2C Hotel OnSearch Start :" + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

            if (!HttpContext.Current.Request.RawUrl.Contains("Searching1")) //Search出错，返回最后一个操作页面。如遇到Searching1.aspx则跳过，因为返回Searching1.aspx会导致重复出错
                ReturnUrlPath = HttpContext.Current.Request.RawUrl;


            hotelSearchHotelByZyl.Debug("ISearchCondition Start :" + DateTime.Now.ToLongTimeString());
            ISearchCondition searchCondition = this.Transaction.CurrentSearchConditions;
            hotelSearchHotelByZyl.Debug("ISearchCondition End :" + DateTime.Now.ToLongTimeString());

            hotelSearchHotelByZyl.Debug("MVMerchandiseSearcher Start :" + DateTime.Now.ToLongTimeString());
            MVMerchandiseSearcher searcher = new MVMerchandiseSearcher();
            hotelSearchHotelByZyl.Debug("MVMerchandiseSearcher End :" + DateTime.Now.ToLongTimeString());

            if (searchCondition is Terms.Sales.Business.AirSearchCondition)
            {
                if (Session["LOG_RANDOM"] != null)
                {
                    log.Info(Session["LOG_RANDOM"].ToString() + " >To SalseBasePage Begin Start time : " + System.DateTime.Now);
                    searcher.LogRandomID = Session["LOG_RANDOM"].ToString();
                }
            }
            else if (searchCondition is Terms.Sales.Business.HotelSearchCondition)
            {
                hotelLog.Info(PageUtility.HotelLogRandomNumber.ToString() + " >To SalseBasePage Begin Start time : " + System.DateTime.Now);
                searcher.LogRandomID = PageUtility.HotelLogRandomNumber.ToString();
            }

            Utility.Transaction.Difference.To = "OnSearch End";
            Utility.Transaction.Difference.EndTime = DateTime.Now;
            Utility.Transaction.Difference.From = "OnSearch1 Start";
            Utility.Transaction.Difference.StarTime = DateTime.Now;

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
                hotelSearchHotelByZyl.Debug("Merchandise Search Start :" + DateTime.Now.ToLongTimeString());
                _Merchandise = (Merchandise)searcher.Search(searchCondition, UserCulture.Name);
                hotelSearchHotelByZyl.Debug("Merchandise Search  End :" + DateTime.Now.ToLongTimeString());
            }
            else
            {
                hotelSearchHotelByZyl.Debug("Merchandise Search Start :" + DateTime.Now.ToLongTimeString());
                _Merchandise = (Merchandise)searcher.Search(searchCondition);
                hotelSearchHotelByZyl.Debug("Merchandise Search  End :" + DateTime.Now.ToLongTimeString());
            }

            if (_Merchandise == null)
            {
                if (searchCondition is Terms.Sales.Business.AirSearchCondition)
                    Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Request.QueryString["ConditionID"]);
                else if (searchCondition is Terms.Sales.Business.HotelSearchCondition)
                    this.Response.Redirect("~/Page/Hotel2/SearchConditionsMeassageHForm.aspx?ErrorMessage=123&ConditionID=" + Request.QueryString["ConditionID"]);
                else if (searchCondition is Terms.Sales.Business.TourSearchCondition)
                    Response.Redirect("~/Page/Tour/SearchConditionsMeassageTForm.aspx");
                else if (searchCondition is Terms.Sales.Business.VehcileSearchCondition)
                    Response.Redirect("~/Page/Vehcile/SearchConditionsErrorMeassageCForm.aspx?ErrorMessage=" + searcher.Errors + "&ConditionID=" + Request.QueryString["ConditionID"]);
                else
                    this.Response.Redirect("~/Page/Package2/SearchConditionsMeassageAHForm.aspx?ErrorMessage=" + searcher.Errors);
            }
            else if (_Merchandise != null)
            {
                if (searchCondition is Terms.Sales.Business.AirSearchCondition && ((AirMerchandise)_Merchandise).Items == null)
                    Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Request.QueryString["ConditionID"]);
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
                    this.Response.Redirect("~/Page/Vehcile/SearchConditionsErrorMeassageCForm.aspx?ErrorMessage=" + searcher.Errors);
                }
                else if (searchCondition is Terms.Sales.Business.TourSearchCondition && ((TourMerchandise)_Merchandise).Items == null)
                    Response.Redirect("~/Page/Tour/SearchConditionsMeassageTForm.aspx");
            }
            dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Debug("MV_B2C Hotel OnSearch Conclusion :" + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

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

    public InsuranceMaterial OnSearchInsurance(Terms.Sales.Business.InsuranceSearchCondition Condition)
    {
        if (this.IsSearchConditionNull)
        {
            return null;
        }
        else
        {
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                return null;
            }
            else
            {
                MVMerchandiseSearcher searcher = new MVMerchandiseSearcher();

                return searcher.SearchInsurance(Condition);
            }
        }
    }

    public InsuranceMaterial OnSearchInsuranceByB2B(Terms.Sales.Business.InsuranceSearchCondition Condition)
    {
        if (Condition is Terms.Sales.Business.InsuranceSearchCondition)
        {
            MVMerchandiseSearcher searcher = new MVMerchandiseSearcher();

            return searcher.SearchInsuranceByB2B(Condition);
        }
        else
        {
            InsuranceMaterial insurance = new InsuranceMaterial(new TERMS.Core.Profiles.Profile("insurance"));

            insurance.PolicyQuote = new TERMS.Common.PolicyQuote();

            insurance.PolicyQuote.Status = new TERMS.Common.Status();

            insurance.PolicyQuote.Status.IsSuccess = false;

            insurance.PolicyQuote.Status.ErrorDescription = "SearchCondition Type Error";

            return insurance;

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

    public SalseBasePage()
    {
        this.InitializeControls += new EventHandler(SalseBasePage_InitializeControls);
        this.PreRender += new EventHandler(SalseBasePage_PreRender);
    }

    void SalseBasePage_PreRender(object sender, EventArgs e)
    {
        if (this.Request != null && this.Request.RawUrl != null && this.Request.RawUrl.ToUpper().Contains(@"/Index.aspx".ToUpper()))
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

    void SalseBasePage_InitializeControls(object sender, EventArgs e)
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    }
    public ArrayList SearchArray
    {
        get
        {
            ArrayList searchArray = new ArrayList();
            //AirSearchCondition airSearchCondition = new AirSearchCondition();
            //if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            //    airSearchCondition = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition;
            //else if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
            //    airSearchCondition = (AirSearchCondition)Utility.Transaction.CurrentSearchConditions;

            //searchArray.Add(airSearchCondition.GetAddTripCondition()[0].Departure);
            //searchArray.Add(airSearchCondition.GetAddTripCondition()[0].Destination);
            //searchArray.Add(airSearchCondition.GetAddTripCondition()[1].Departure);
            //searchArray.Add(airSearchCondition.GetAddTripCondition()[1].Destination);
            //searchArray.Add(airSearchCondition.GetAddTripCondition()[0].DepartureDate);
            //searchArray.Add(airSearchCondition.GetAddTripCondition()[1].DepartureDate);
            //searchArray.Add(airSearchCondition.FlightType);
            return searchArray;
        }

    }

    public bool SessionExpired()
    {
        if (System.Web.HttpContext.Current.Session["Transaction"] == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static CascadingDropDownNameValue[] GetDropDownContents(string knownCategoryValues, string category)
    {
        IApplicationContext ctx = ContextRegistry.GetContext();
        ICommonService commonService = ctx["CommonService"] as ICommonService;
        IBaseService baseService = ctx["BaseService"] as IBaseService;

        AjaxControlToolkit.CascadingDropDownNameValue[] dvs = null;

        IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;

        //List<Airport> airports = applicationCacheFoundationDate.FindAllAirport();

        //string strCitys = string.Empty;

        //for (int index = 0; index < airports.Count; index++)
        //{
        //    strCitys += airports[index].Name + " - " + airports[index].Code + " , " + airports[index].City.Name + " , " + airports[index].City.CountryCode + " || ";
        //}

        //using (StreamWriter sw = File.CreateText("C:\\AirportCode" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ".txt"))
        //{
        //    sw.Write(strCitys);
        //}

        //List<City> Citys = applicationCacheFoundationDate.FindAllCity();

        //string strCitys = string.Empty;

        //for (int index = 0; index < Citys.Count; index++)
        //{
        //    strCitys += Citys[index].Name + " - " + Citys[index].Code + " , " + Citys[index].CountryCode + " || ";
        //}

        //using (StreamWriter sw = File.CreateText("C:\\CityCode" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ".txt"))
        //{
        //    sw.Write(strCitys);
        //}


        System.Collections.ArrayList List = new ArrayList();

        if (category == "Country")
        {
            List<Country> CountryTable = applicationCacheFoundationDate.FindCountry();

            for (int index = 0; index < CountryTable.Count; index++)
            {
                if (CountryTable[index] != null)
                {
                    AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(CountryTable[index].Name, CountryTable[index].Code);
                    List.Add(dv);
                }
            }
        }

        if (category == "City")
        {
            string CountryCode = GetCategoryValueString(knownCategoryValues);

            List<City> temp = applicationCacheFoundationDate.FindCityByCountry(CountryCode);

            for (int index = 0; index < temp.Count; index++)
            {
                if (temp[index] != null)
                {
                    AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(temp[index].Name, temp[index].Code);
                    List.Add(dv);
                }
            }
        }

        if (category == "Provinces")
        {
            string CountryCode = GetCategoryValueString(knownCategoryValues);

            List<Province> Provinces = applicationCacheFoundationDate.FindProvinceByCountry(CountryCode);

            for (int index = 0; index < Provinces.Count; index++)
            {
                if (Provinces[index] != null)
                {
                    AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(Provinces[index].Name, Provinces[index].Name);
                    List.Add(dv);
                }
            }
        }
        if (category == "TourArea")
        {
            List<TERMS.Common.Area> areaTable = applicationCacheFoundationDate.FindTourArea();

            for (int index = 0; index < areaTable.Count; index++)
            {
                if (areaTable[index] != null)
                {
                    AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(areaTable[index].Name, areaTable[index].Name);
                    List.Add(dv);
                }
            }
        }

        if (category == "TourCountry")
        {
            string AreaCode = GetCategoryValueString(knownCategoryValues);

            List<TERMS.Common.Country> CountryTable = applicationCacheFoundationDate.FindTourCountry(AreaCode);

            for (int index = 0; index < CountryTable.Count; index++)
            {
                if (CountryTable[index] != null)
                {
                    AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(CountryTable[index].Name, CountryTable[index].Code);
                    List.Add(dv);
                }
            }
        }

        if (category == "TourCity")
        {
            string CountryCode = GetCategoryValueString(knownCategoryValues);

            List<TERMS.Common.City> temp = applicationCacheFoundationDate.FindTourCity(CountryCode);

            temp.Sort(delegate(TERMS.Common.City c1, TERMS.Common.City c2) { return (c1.Name.CompareTo(c2.Name)); });

            for (int index = 0; index < temp.Count; index++)
            {
                if (temp[index] != null)
                {
                    AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(temp[index].Name, temp[index].Code);
                    List.Add(dv);
                }
            }

        }
        if (List.Count > 0)
        {
            dvs = (AjaxControlToolkit.CascadingDropDownNameValue[])List.ToArray(typeof(AjaxControlToolkit.CascadingDropDownNameValue));
        }

        return dvs;

    }

    public static CascadingDropDownNameValue[] GetDropDownContentsByCounty(string knownCategoryValues, string category)
    {
        IApplicationContext ctx = ContextRegistry.GetContext();
        ICommonService commonService = ctx["CommonService"] as ICommonService;
        IBaseService baseService = ctx["BaseService"] as IBaseService;

        AjaxControlToolkit.CascadingDropDownNameValue[] dvs = null;

        IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;

        System.Collections.ArrayList List = new ArrayList();

        if (category == "Country")
        {
            List<Country> CountryTable = new List<Country>();

            Country country1 = new Country("CANADA");
            country1.Code = "CA";

            Country country2 = new Country("United States");
            country2.Code = "US";

            CountryTable.Add(country1);
            CountryTable.Add(country2);

            for (int index = 0; index < CountryTable.Count; index++)
            {
                if (CountryTable[index] != null)
                {
                    AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(CountryTable[index].Name, CountryTable[index].Code);
                    List.Add(dv);
                }
            }
        }

        if (List.Count > 0)
        {
            dvs = (AjaxControlToolkit.CascadingDropDownNameValue[])List.ToArray(typeof(AjaxControlToolkit.CascadingDropDownNameValue));
        }

        return dvs;

    }

    private static string GetCategoryValueString(string knownCategoryValues)
    {

        if (knownCategoryValues != null && knownCategoryValues != "")
        {
            string[] Categorys = knownCategoryValues.Split(';');

            if (Categorys != null)
            {
                string Category = Categorys[Categorys.Length - 2];

                string[] CategoryValues = Category.Split(':');

                if (CategoryValues != null && CategoryValues.Length == 2)
                {
                    return CategoryValues[1];
                }

            }

            return null;
        }
        else
        {
            return null;
        }
    }

    protected virtual string SourceName
    {
        get
        {
            return GlobalBaseUtility.GetClassName(GlobalBaseUtility.GetWebSite(Request.Url));
        }
    }

    protected void Err(string error, string errorFlag, string ErrPageName)
    {
        string[] errorMessage = new string[3];

        errorMessage[0] = error;
        errorMessage[1] = errorFlag;
        errorMessage[2] = ErrPageName;

        Session["Error"] = errorMessage;
        Response.Redirect("Error.aspx");
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
            string urlHead = "http://";

            //虚拟目录
            string path = VirtualPath;
            if (path == "/") path = "";

            //if (port == 80)
            return urlHead + UrlHost + path + "/";
            //else
            //    return urlHead + UrlHost + ":" + port.ToString() + path + "/";
        }
    }

    public string SecureUrlSuffix
    {
        get
        {
            return PageUtility.SecureUrlSuffix;
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

    public string HtmlPath
    {
        get
        {
            return this.GetGlobalResourceObject("Resource", GlobalInfo.HtmlPath).ToString() + HtmlCulturePath;
        }
    }

    public string MainImagesPath
    {
        get
        {
            return this.GetGlobalResourceObject("Resource", GlobalInfo.MainImagePath).ToString() + ImageCulturePath;
        }
    }

    public string ImagesPath
    {
        get
        {
            return this.GetGlobalResourceObject("Resource", GlobalInfo.ImagePath).ToString() + ImageCulturePath;
        }
    }

    public string MainCssPath
    {
        get
        {
            return this.GetGlobalResourceObject("Resource", GlobalInfo.MainCssPath).ToString() + CulturePath;
        }
    }

    public string MainJSPath
    {
        get
        {
            return @"CommJs/" + CulturePath;
        }
    }

    public string CultureName
    {
        get
        {
            if (UserCulture.Name.Equals("en-US"))
                return null;
            else
                return UserCulture.Name;
        }
    }

    //css Culture Path
    public string CulturePath
    {
        get
        {
            if (CultureName == null)
                return string.Empty;
            else
                return CultureName + "/";
        }
    }

    //image Culture Path
    public string ImageCulturePath
    {
        get
        {
            if (CultureName == null)
                return string.Empty;
            else
                return CultureName + "/";
        }
    }

    //Html Culture Path
    public string HtmlCulturePath
    {
        get
        {
            if (CultureName == null)
                return string.Empty;
            else
                return CultureName + "/";
        }
    }

    public void ResetTour()
    {
        MVMerchandisePool.ResetTour();
    }

    public string GoogleMapKey
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["MapKey"].ToString();
        }
    }

    public ShoppingCart OrderShoppingCart
    {
        get
        {
            if (Session["SHOPPINGCART"] != null)
                return (ShoppingCart)Session["SHOPPINGCART"];
            else
                return new ShoppingCart();
        }
        set
        {
            if (value == null)
                Session["SHOPPINGCART"] = new ShoppingCart();
            else
                Session["SHOPPINGCART"] = value;
        }
    }

}

public class TourErrorMsg
{
    private bool isError = false;

    private string errorMsg = string.Empty;

    public bool IsError
    {
        set
        {
            isError = value;
        }
        get
        {
            return isError;
        }
    }

    public string ErrorMsg
    {
        set
        {
            errorMsg = value;
        }
        get
        {
            return errorMsg;
        }
    }

    public TourErrorMsg()
    { 
    
    }
}
