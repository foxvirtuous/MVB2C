using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

using Terms.Common.Service;
using Terms.Common.Domain;
using Terms.Base.Service;

using Spring.Context;
using Spring.Context.Support;

using System.Web.Services;
using AjaxControlToolkit;
using Terms.Sales.Service;
using Spring.Aspects.AirOperate;
using Terms.Configuration.Domain;
using System.IO;

/// <summary>
/// Summary description for IndexPageBase
/// </summary>
public class IndexPageBase : Spring.Web.UI.Page
{
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

    public string MainMapPath
    {
        get
        {
            return @"Html/" + CulturePath;
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

    public virtual AirStepConfirmLogAdvice OperaterAdvice
    {
        get
        {
            return new AirStepConfirmLogAdvice();
        }
    }

    public IndexPageBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected string PATH = "";
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void InitializeComponent()
    {
        this.Load += new EventHandler(PageBase_Load);
        this.PreRender += new EventHandler(PageBase_PreRender);
        this.Error += new EventHandler(PageBase_Error);
    }

    private void PageBase_Load(object sender, EventArgs e)
    {
        //PersistScrollPosition();
    }

    private void PageBase_PreRender(object sender, EventArgs e)
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

    private void PageBase_Error(object sender, EventArgs e)
    {

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

    protected bool IsKeepingScrollPosition = false;

    private void PersistScrollPosition()
    {
        StringBuilder saveScrollPosition = new StringBuilder();
        StringBuilder setScrollPosition = new StringBuilder();

        RegisterHiddenField("__SCROLLPOS", "0");

        saveScrollPosition.Append("<script language='javascript'>");
        saveScrollPosition.Append("function saveScrollPosition() {");
        saveScrollPosition.Append(" document.forms[0].__SCROLLPOS.value = document.documentElement.scrollTop;");
        saveScrollPosition.Append("}");
        saveScrollPosition.Append("document.documentElement.onscroll=saveScrollPosition;");
        saveScrollPosition.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "saveScroll", saveScrollPosition.ToString());

        if (Page.IsPostBack && IsKeepingScrollPosition)
        {
            setScrollPosition.Append("<script language='javascript'>");
            setScrollPosition.Append("function setScrollPosition() {");
            setScrollPosition.Append(" document.documentElement.scrollTop = " + Request["__SCROLLPOS"] + ";");
            setScrollPosition.Append("}");
            setScrollPosition.Append("document.body.onload=setScrollPosition;");
            setScrollPosition.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "setScroll", setScrollPosition.ToString());
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

        //using (StreamWriter sw = File.CreateText("C:\\GTAStateSouceForMVB2C" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ".txt"))
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

    /// <summary>
    /// …Ë÷√WebSite–≈œ¢
    /// </summary>
    public void SetWebSiteInfomation()
    {
        if (CurrentWebSite == null) return;

        if (CurrentWebSite.Id != Guid.Empty)
        {
            ConfigurationSettings.AppSettings.Set(WebSiteName, CurrentWebSite.Name);
        }
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string GetCityNames(string name)
    {
        string CityNames = "";

        List<City> Citys = new List<City>();

        IApplicationContext ctx = ContextRegistry.GetContext();
        ICommonService commonService = ctx["CommonService"] as ICommonService;
        IBaseService baseService = ctx["BaseService"] as IBaseService;

        AjaxControlToolkit.CascadingDropDownNameValue[] dvs = null;

        IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;

        
        List<Airport> AirportTable = applicationCacheFoundationDate.FindAllAirport();

        List<Airport> newAir = new List<Airport>();

        List<City> temp = null; //applicationCacheFoundationDate.FindAllCity();

        for (int index = 0; index < temp.Count; index++)
        {
            if (temp[index] != null)
            {
                if (temp[index].Name.ToUpper().Contains(name.ToUpper()) || temp[index].Code.ToUpper().Contains(name.ToUpper()))
                {
                    Citys.Add(temp[index]);
                }
            }
        }

        for (int index = 0; index < AirportTable.Count; index++)
        {
            if (AirportTable[index] != null)
            {
                if (AirportTable[index].Name.ToUpper().Contains(name.ToUpper()) || AirportTable[index].Code.ToUpper().Contains(name.ToUpper()))
                {
                    newAir.Add(AirportTable[index]);
                }
            }
        }

        Citys.Sort(delegate(City r1, City r2) { return r1.Name.CompareTo(r2.Name); });
        newAir.Sort(delegate(Airport r1, Airport r2) { return r1.Name.CompareTo(r2.Name); });

        for (int index = 0; index < Citys.Count; index++)
        {
            CityNames = CityNames + Citys[index].Name + " - " + Citys[index].Code + ", " + Citys[index].CountryCode + "||";
        }

        for (int index = 0; index < newAir.Count; index++)
        {
            CityNames = CityNames + newAir[index].Name + " - " + newAir[index].Code + ", " + newAir[index].CountryName + "||";
        }

        return CityNames;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string GetCityNamesH(string name)
    {
        string CityNames = "";

        List<City> Citys = new List<City>();

        IApplicationContext ctx = ContextRegistry.GetContext();
        ICommonService commonService = ctx["CommonService"] as ICommonService;
        IBaseService baseService = ctx["BaseService"] as IBaseService;

        AjaxControlToolkit.CascadingDropDownNameValue[] dvs = null;

        IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;

        List<Country> CountryTable = applicationCacheFoundationDate.FindCountry();

        for (int i = 0; i < CountryTable.Count; i++)
        {
            List<City> temp = applicationCacheFoundationDate.FindCityByCountry(CountryTable[i].Code);

            for (int index = 0; index < temp.Count; index++)
            {
                if (temp[index] != null)
                {
                    if (temp[index].Name.ToUpper().Contains(name.ToUpper()) || temp[index].Code.ToUpper().Contains(name.ToUpper()))
                    {

                        Citys.Add(temp[index]);
                        //CityNames = CityNames + temp[index].Name + " - " + temp[index].Code + ", " + CountryTable[i].Name + "||";
                    }
                }
            }
        }

        Citys.Sort(delegate(City r1, City r2) { return r1.Name.CompareTo(r2.Name); });

        for (int index = 0; index < Citys.Count; index++)
        {
            CityNames = CityNames + Citys[index].Name + " - " + Citys[index].Code + ", " + Citys[index].CountryCode + "||";
        }

        return CityNames;
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string GetRegions()
    {
        string Regions = string.Empty;

        IApplicationContext ctx = ContextRegistry.GetContext();
        ICommonService commonService = ctx["CommonService"] as ICommonService;
        IBaseService baseService = ctx["BaseService"] as IBaseService;

        IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;

        List<TERMS.Common.Area> areaTable = applicationCacheFoundationDate.FindTourArea();

        try
        {
            for (int i = 0; i < areaTable.Count; i++)
            {
                Regions += areaTable[i].Name + "||";
            }
        }
        catch (Exception ex)
        {
            string s = ex.Message;
        }

        return Regions;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string GetCountry(string Region)
    {
        string Regions = string.Empty;

        IApplicationContext ctx = ContextRegistry.GetContext();
        ICommonService commonService = ctx["CommonService"] as ICommonService;
        IBaseService baseService = ctx["BaseService"] as IBaseService;

        IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;

        List<TERMS.Common.Country> CountryTable = applicationCacheFoundationDate.FindTourCountry(Region.Trim());

        CountryTable.Sort(delegate(TERMS.Common.Country c1, TERMS.Common.Country c2) { return (c1.Name.CompareTo(c2.Name)); });

        try
        {
            for (int i = 0; i < CountryTable.Count; i++)
            {
                Regions += CountryTable[i].Name + " - " + CountryTable[i].Code + "||";
            }
        }
        catch (Exception ex)
        {
            string s = ex.Message;
        }

        return Regions;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string GetCity(string strCountry)
    {
        string Regions = string.Empty;

        IApplicationContext ctx = ContextRegistry.GetContext();
        ICommonService commonService = ctx["CommonService"] as ICommonService;
        IBaseService baseService = ctx["BaseService"] as IBaseService;

        IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;

        int index = strCountry.IndexOf("-");

        strCountry = strCountry.Substring(index + 1);

        List<TERMS.Common.City> temp = applicationCacheFoundationDate.FindTourCity(strCountry.Trim());

        temp.Sort(delegate(TERMS.Common.City c1, TERMS.Common.City c2) { return (c1.Name.CompareTo(c2.Name)); });

        try
        {
            for (int i = 0; i < temp.Count; i++)
            {
                Regions += temp[i].Name + " - " + temp[i].Code + "||";
            }
        }
        catch (Exception ex)
        {
            string s = ex.Message;
        }

        return Regions;
    }
}
