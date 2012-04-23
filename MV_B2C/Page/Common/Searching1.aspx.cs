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
using Terms.Sales.Domain;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Search;
using TERMS.Core.Product;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Global.Utility;
using TERMS.Common;
using Terms.Common.Service;
using Terms.Material.Service;
using Terms.Sales.Service;
using System.IO;

public partial class Searching1 : SalseBasePage
{
    //记录Air Search时间的日志对象
    private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger("HotelSearchTime");

    private static readonly log4net.ILog hotelSearchHotelByZyl =
         log4net.LogManager.GetLogger("HotelSearchPerformanceDebugging");

    //Search成功后重定向的页面地址
    private string target;
    public string Target
    {
        get 
        {
            if (ViewState["target"] != null)
            {
                return ViewState["target"].ToString();
            }
            else
            {
                if (Request.QueryString["target"] != null)
                    ViewState["target"] = Request.QueryString["target"];
                else
                    ViewState["target"] = string.Empty;

                return ViewState["target"].ToString();
            }
        }
        set
        {
            ViewState["target"] = value;
        }
    }

    public string ConditionID
    {
        get 
        {
            if (ViewState["ConditionID"] != null)
            {
                return ViewState["ConditionID"].ToString();
            }
            else
            {
                if (Request.QueryString["ConditionID"] != null)
                    ViewState["ConditionID"] = Request.QueryString["ConditionID"];
                else
                    ViewState["ConditionID"] = string.Empty;

                return ViewState["ConditionID"].ToString();
            }
        }
        set
        {
            ViewState["ConditionID"] = value;
        }
    }

    private Merchandise _merchandise;
    public Merchandise merchandise
    {
        set
        {
            _merchandise = value;
        }
        get
        {
            return _merchandise;
        }
    }

    private DateTime dtBeginTime
    {
        get 
        {
            if (ViewState["dtBeginTime"] == null)
                ViewState["dtBeginTime"] = new DateTime();

            return Convert.ToDateTime(ViewState["dtBeginTime"]);
        }
        set 
        {
            ViewState["dtBeginTime"] = value;
        }
    }

    private ICityService _cityService;
    public ICityService CityService
    {
        set
        {
            this._cityService = value;
        }
    }

    private IAirportService _airportService;
    public IAirportService AirportService
    {
        set
        {
            this._airportService = value;
        }
    }

    private AirService m_airService;

    protected AirService AirService
    {
        get
        {
            return m_airService;

        }
        set
        {
            m_airService = value;
        }
    }

    private IApplicationCacheFoundationDate _ApplicationCacheFoundationDate;
    public IApplicationCacheFoundationDate ApplicationCacheFoundationDate
    {
        set
        {
            this._ApplicationCacheFoundationDate = value;
        }
    }

    private ICommonService _CommonService;

    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        if (!Page.IsPostBack)
        {
            try
            {
                using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\SearchTour1" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".txt"))
                {
                    sw.Write("Star");
                }
            }
            catch
            {
            }            

            SearchAllType();

            DateTime dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Info("MV_B2C Hotel Serach To Searching1 Conclusion : " + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

            if (this.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                this.loadPackage.Visible = false;
                this.loadTour.Visible = false;

                //log
                dtBeginTime = System.DateTime.Now;
                log.Info( PageUtility.HotelLogRandomNumber.ToString() + " >Load Searching1.aspx Begin time : " + dtBeginTime);
            }
            else if(this.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                this.loadHotel.Visible = false;
                this.loadTour.Visible = false;
            }
            else if (this.Transaction.CurrentSearchConditions is TourSearchCondition)
            {
                this.loadPackage.Visible = false;
                this.loadHotel.Visible = false;

                //log
                dtBeginTime = System.DateTime.Now;
                PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >Load Searching1.aspx at: " + dtBeginTime);
            }
            else
            {
                this.loadPackage.Visible = false;
                this.loadHotel.Visible = false;
            }
            
            ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>OnSearch('s');</script>");
        }
    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.PreRender += new System.EventHandler(this.Searching_PreRender);
    }
    #endregion

    #region PreRender Event
    /// <summary>
    /// Searching PreRender event
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    private void Searching_PreRender(object sender, EventArgs e)
    {
        //if (SessionExpired)
        //{
        //    Err("The search condition has been removed from cache, please re-search.", "", "Searching.aspx");
        //}

        if (Request.Params["IsOnSearch"] != null
            && Request.Params["IsOnSearch"].ToString().Trim().Length > 0)
        {
            if (Request["TourSearchEngineer"] != null)
            {
                Response.Redirect("~/page/Tour/NewTourSearchEngineerListForm.aspx?TourSearchEngineer=" + Request["TourSearchEngineer"] + "&ConditionID=" + Request["ConditionID"]);
            }

            //log
            if (this.Transaction.CurrentSearchConditions is HotelSearchCondition)
                log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >Load Searching1.aspx End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtBeginTime)).ToString());
            else if (this.Transaction.CurrentSearchConditions is TourSearchCondition)
                PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >Load Searching1.aspx End at: " + ((TimeSpan)System.DateTime.Now.Subtract(dtBeginTime)).ToString());

            Utility.Transaction.Difference.To = "Redirect End";
            Utility.Transaction.Difference.EndTime = DateTime.Now;
            Utility.Transaction.Difference.From = "OnSearch Start";
            Utility.Transaction.Difference.StarTime = DateTime.Now;

            this.IsOnSearch.Value = "";


            //log
            DateTime start = DateTime.Now;

            if (this.Transaction.CurrentSearchConditions is HotelSearchCondition)
                log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >DoSearch Begin time : " + start.ToString());
            else if (this.Transaction.CurrentSearchConditions is TourSearchCondition)
                PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >DoSearch Begin at: " + start.ToString());

            DateTime dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Info("MV_B2C Hotel DoSearch Start : " + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

            DoSearch();
            dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Info("MV_B2C Hotel DoSearch Conclusion : " + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);


            //log
            DateTime end = DateTime.Now;

            if (this.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >DoSearch End time : " + ((TimeSpan)end.Subtract(start)).ToString());
                log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >Redirect to Search Result Page time : " + System.DateTime.Now);
            }
            else if (this.Transaction.CurrentSearchConditions is TourSearchCondition)
            {
                PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >DoSearch End at: " + ((TimeSpan)end.Subtract(start)).ToString());
                PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >Redirect to Search Result Page at: " + System.DateTime.Now);
            }

            try
            {
                using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\SearchTour2" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".txt"))
                {
                    sw.Write("Star");
                }
            }
            catch
            {
            }

            dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Info("MV_B2C Hotel Searching1 To HotelSelectForm Start : " + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

            if (this.Request["Destination"] != null )
                if (this.Request["ChooseHotelID"] != null)
                    this.Response.Redirect(Target + ".aspx" + "?Destination=" + this.Request["Destination"] + "&ChooseHotelID=" + this.Request["ChooseHotelID"] + "&ConditionID=" + ConditionID);
                else
                    this.Response.Redirect(Target + ".aspx" + "?Destination=" + this.Request["Destination"] + "&ConditionID=" + ConditionID);
            else if (merchandise is PackageMerchandise)
            {
                int defaultIndex = ((PackageMerchandise)merchandise).Items.Count - 2;
                this.Response.Redirect(Target + ".aspx" + "?HotelIndex=" + defaultIndex + "&ConditionID=" + ConditionID);
            }
            else if (merchandise is TourMerchandise)
                if (this.Request.QueryString["TourArea"] != null)
                {
                    //if (Utility.IsSubAgent)
                    //    this.Response.Redirect(Target + ".aspx" + "?TourArea=" + Server.UrlEncode(this.Request.QueryString["TourArea"]) + "&ConditionID=" + ConditionID + "&ReturnURL=~/B2B_SUB/TourIndex.aspx");
                    //else

                    string temp = string.Empty;

                    if (this.Request.QueryString["TopDestinations"] != null)
                        temp += "&TopDestinations=" + this.Request.QueryString["TopDestinations"];

                    if (this.Request.QueryString["CityCode"] != null)
                        temp += "&CityCode=" + this.Request.QueryString["CityCode"];

                    if (this.Request.QueryString["Price"] != null)
                        temp += "&Price=" + this.Request.QueryString["Price"];

                    if (this.Request.QueryString["Preference"] != null)
                        temp += "&Preference=" + this.Request.QueryString["Preference"];
                                        
                    this.Response.Redirect(Target + ".aspx" + "?TourArea=" + Server.UrlEncode(this.Request.QueryString["TourArea"]) + "&ConditionID=" + ConditionID + temp);
                }
                else
                {
                    //if(Utility.IsSubAgent)
                    //    this.Response.Redirect(Target + ".aspx?ConditionID=" + ConditionID + "&ReturnURL=~/B2B_SUB/TourIndex.aspx");
                    //else
                        this.Response.Redirect(Target + ".aspx?ConditionID=" + ConditionID);
                }
            else
                this.Response.Redirect(Target + ".aspx" + "?ConditionID=" + ConditionID);
                
        }
    }
    #endregion

    #region User Define event
    /// <summary>
    /// the Search event
    /// </summary>
    private void DoSearch()
    {
         merchandise = this.OnSearch();
    }

    #endregion


    private void SearchAllType()
    {
        if (Request["searchtype"] == null || Request["searchtype"].Trim().Length == 0)
        {
            return;
        }

        string searchtype = Request["searchtype"].Trim();

        switch (searchtype)
        {
            case "A":
                string depCity = ConvertName(Request["fromcity"].Trim());
                string toCity = ConvertName(Request["tocity"].Trim());
                string rtnFromCity = ConvertName(Request["rtnfromah"].Trim());
                string rtnToCity = ConvertName(Request["rtntoah"].Trim());

                //log begin 20090312 Leon
                log.Info("\r\n");
                System.Random rd = new Random();

                Session["LOG_RANDOM"] = rd.Next(999999999);


                if (!Utility.IsLogin)
                {
                    log.Info(Session["LOG_RANDOM"].ToString() + " >====================Not Login========================");
                }
                else
                {
                    log.Info(Session["LOG_RANDOM"].ToString() + " >==========================Login========================");
                }
                string logAirline = Request["aircode"].Trim().Trim().Equals(string.Empty) ? "All" : Request["aircode"].Trim();
                log.Info(Session["LOG_RANDOM"].ToString() + " >==========================AirLine:" + logAirline + "========================");
                log.Info(Session["LOG_RANDOM"].ToString() + " >SearchClick Begin Start time : " + System.DateTime.Now);
                //log end 20090312 Leon


                if (Utility.IsSubAgent)
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchAir, this);
                else
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchAir, this);

                Session["HasReminder"] = true;


                //if (!Page.IsValid)
                //    return;
                bool IsSelectAirport = false;
                bool IsRealCity = true;

                Session["CurrentSession"] = new SessionClass();
                SessionClass sc = (SessionClass)Session["CurrentSession"];

                AirSearchCondition airSearchCondition = new AirSearchCondition();

                airSearchCondition.SetPassengerNumber(PassengerType.Adult, Convert.ToInt32(Convert.ToInt32(Request["adults"].Trim())));

                CabinType cabinA = new CabinType();
                if (Request["airclass"].Trim() == "ECONOMY")
                {
                    cabinA = CabinType.Economy;
                }
                else if (Request["airclass"].Trim() == "BUSINESS")
                {
                    cabinA = CabinType.Business;
                }
                else if (Request["airclass"].Trim() == "FIRST")
                {
                    cabinA = CabinType.First;
                }
                else
                {
                    cabinA = CabinType.All;
                }

                airSearchCondition.SetPassengerNumber(PassengerType.Child, Convert.ToInt32(Convert.ToInt32(Request["children"].Trim())));

                airSearchCondition.FlightType = Request["airtype"].Trim();

                airSearchCondition.FlexibleDays = 0;

                AirTripCondition deptCondition = new AirTripCondition();
                deptCondition.Cabin = cabinA;

                sc.FromCityName = depCity.Trim();
                if (depCity.Trim().Length > 3)
                {
                    IList departureAirPorts = _CommonService.FindAirportByCityName(depCity.Trim());

                    if (departureAirPorts.Count > 1)
                    {
                        IsSelectAirport = true;
                        sc.FromAirports = departureAirPorts;
                    }
                    else if (departureAirPorts.Count == 1)
                    {
                        deptCondition.Departure = (Terms.Common.Domain.Airport)departureAirPorts[0];
                    }
                    else
                    {

                        List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                        Terms.Common.Domain.Airport airport = MatchAirport(depCity.Trim(), airportList);
                        if (airport != null)
                            deptCondition.Departure = airport;
                        else
                            sc.IsRealFromCity = IsRealCity = false;
                        //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDepCity.Value + "\"&GoToPage=~/index.aspx");
                    }

                }
                else
                {
                    deptCondition.Departure = AirService.CommAirportDao.FindByAirport(depCity.Trim());

                    if (deptCondition.Departure == null)
                    {
                        deptCondition.Departure = new Terms.Common.Domain.Airport();
                        deptCondition.Departure.Code = depCity.Trim();
                    }
                }

                deptCondition.DepartureDate = GlobalUtility.GetDateTime(Request["fromdate"].Trim());

                bool IsDataError = true;

                if (deptCondition.DepartureDate < DateTime.Now.AddDays(3))
                {
                    IsRealCity = false;
                    IsDataError = false;

                }

                sc.ToCityName = toCity.Trim();
                if (toCity.Trim().Length > 3)
                {
                    IList destinationAirPorts = _CommonService.FindAirportByCityName(toCity.Trim());

                    if (destinationAirPorts.Count > 1)
                    {
                        IsSelectAirport = true;
                        sc.ToAirports = destinationAirPorts;
                    }
                    else if (destinationAirPorts.Count == 1)
                    {
                        deptCondition.Destination = (Terms.Common.Domain.Airport)destinationAirPorts[0];
                    }
                    else
                    {
                        List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                        Terms.Common.Domain.Airport airport = MatchAirport(toCity.Trim(), airportList);
                        if (airport != null)
                            deptCondition.Destination = airport;
                        else
                            sc.IsRealToCity = IsRealCity = false;
                        // Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDesCity.Value + "\"&GoToPage=~/index.aspx");
                    }

                }
                else
                {
                    deptCondition.Destination = AirService.CommAirportDao.FindByAirport(toCity.Trim());

                    if (deptCondition.Destination == null)
                    {
                        deptCondition.Destination = new Terms.Common.Domain.Airport();
                        deptCondition.Destination.Code = toCity.Trim();
                    }
                }



                AirTripCondition rtnCondition = new AirTripCondition();
                rtnCondition.Cabin = cabinA;




                if (Request["airtype"].Trim().ToLower().Equals("oneway"))
                {
                    rtnCondition.Departure = deptCondition.Destination;
                    rtnCondition.Destination = deptCondition.Departure;
                    rtnCondition.DepartureDate = DateTime.MaxValue;
                }
                else if (Request["airtype"].Trim().ToLower().Equals("roundtrip"))
                {
                    rtnCondition.Departure = deptCondition.Destination;
                    rtnCondition.Destination = deptCondition.Departure;
                    rtnCondition.DepartureDate = GlobalUtility.GetDateTime(Request["todate"].Trim());
                }
                else if (Request["airtype"].Trim().ToLower().Equals("openjaw"))
                {
                    rtnCondition.DepartureDate = GlobalUtility.GetDateTime(Request["todate"].Trim());
                    sc.ReturnFromCityName = rtnFromCity.Trim();
                    if (rtnFromCity.Trim().Length > 3)
                    {
                        IList returnFromAirPorts = _CommonService.FindAirportByCityName(rtnFromCity.Trim());

                        if (returnFromAirPorts.Count > 1)
                        {
                            IsSelectAirport = true;
                            sc.ReturnFromAirports = returnFromAirPorts;
                        }
                        else if (returnFromAirPorts.Count == 1)
                        {
                            rtnCondition.Departure = (Terms.Common.Domain.Airport)returnFromAirPorts[0];
                        }
                        else
                        {
                            List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                            Terms.Common.Domain.Airport airport = MatchAirport(rtnFromCity.Trim(), airportList);
                            if (airport != null)
                                rtnCondition.Departure = airport;
                            else
                                sc.IsRealReturnFromCity = IsRealCity = false;
                            //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtRtnFrom.Value + "\"&GoToPage=~/index.aspx");
                        }
                    }
                    else
                    {
                        rtnCondition.Departure = AirService.CommAirportDao.FindByAirport(rtnFromCity.Trim());
                        if (rtnCondition.Departure == null)
                        {
                            rtnCondition.Departure = new Terms.Common.Domain.Airport();
                            rtnCondition.Departure.Code = rtnFromCity.Trim();
                        }
                    }
                    sc.ReturnToCityName = rtnToCity.Trim();
                    if (rtnToCity.Trim().Length > 3)
                    {
                        IList returnToAirPorts = _CommonService.FindAirportByCityName(rtnToCity.Trim());

                        if (returnToAirPorts.Count > 1)
                        {
                            IsSelectAirport = true;
                            sc.ReturnToAirports = returnToAirPorts;
                        }
                        else if (returnToAirPorts.Count == 1)
                        {
                            rtnCondition.Destination = (Terms.Common.Domain.Airport)returnToAirPorts[0];
                        }
                        else
                        {
                            List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                            Terms.Common.Domain.Airport airport = MatchAirport(rtnToCity.Trim(), airportList);
                            if (airport != null)
                                rtnCondition.Destination = airport;
                            else
                                sc.IsRealReturnToCity = IsRealCity = false;
                            //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtRtnTo.Value + "\"&GoToPage=~/index.aspx");
                        }

                    }
                    else
                    {
                        rtnCondition.Destination = AirService.CommAirportDao.FindByAirport(rtnToCity.Trim());
                        if (rtnCondition.Destination == null)
                        {
                            rtnCondition.Destination = new Terms.Common.Domain.Airport();
                            rtnCondition.Destination.Code = rtnToCity.Trim();
                        }
                    }
                }

                airSearchCondition.AddTripCondition(deptCondition);
                airSearchCondition.AddTripCondition(rtnCondition);


                //if (ddlAirline.SelectedItem.Text != "Search All Airlines")
                if (Request["aircode"].Trim().Trim() != "")
                {
                    //param.Airways = ddlAirline.SelectedValue.Split(',');
                    airSearchCondition.Airlines = Request["aircode"].Trim().Split(',');
                }

                sc.CurrentItinerary.SearchInfo = airSearchCondition;
                Utility.IsTourMain = false;//设置是否是Tour标志
                this.Transaction.IntKey = airSearchCondition.GetHashCode();
                this.Transaction.CurrentSearchConditions = airSearchCondition;
                this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

                ForbiddenAirportControl f = new ForbiddenAirportControl();

                bool IsErrorAir = f.HasForbiddenAirport(sc);

                if (IsErrorAir)
                {
                    Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.ForbiddenAirport);
                }

                if (!IsRealCity)
                {
                    if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                    {
                        if (IsDataError)
                        {
                            Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&IsRealCity=" + IsRealCity.ToString() + "&IsSelectAirport=" + IsSelectAirport.ToString());
                        }
                        else
                        {
                            Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&IsRealCity=" + IsRealCity.ToString() + "&IsSelectAirport=" + IsSelectAirport.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                        }
                    }

                    if (IsDataError)
                    {
                        Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                    }
                }
                else
                {
                    if (IsSelectAirport)
                    {
                        if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                        {
                            if (IsDataError)
                            {
                                Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&IsRealCity=" + IsRealCity.ToString() + "&IsSelectAirport=" + IsSelectAirport.ToString());
                            }
                            else
                            {
                                Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&IsRealCity=" + IsRealCity.ToString() + "&IsSelectAirport=" + IsSelectAirport.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                            }
                        }

                        if (IsDataError)
                        {
                            Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                        }
                        else
                        {
                            Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                        }
                    }
                    else
                    {
                        if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                        {
                            if (IsDataError)
                            {
                                Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&IsRealCity=" + IsRealCity.ToString() + "&IsSelectAirport=" + IsSelectAirport.ToString());
                            }
                            else
                            {
                                Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&IsRealCity=" + IsRealCity.ToString() + "&IsSelectAirport=" + IsSelectAirport.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                            }
                        }

                        log.Info(Session["LOG_RANDOM"].ToString() + " >Redirect Searching.aspx Begin Start time : " + System.DateTime.Now);

                        if (IsDataError)
                        {
                            Response.Redirect("~/Page/Flight/Searching.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                        }
                        else
                        {
                            Response.Redirect("~/Page/Flight/Searching.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                        }
                    }
                }

                break;
            case "AH":
                if (Utility.IsSubAgent)
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchPackage, this);
                else
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchPackage, this);

                List<TourErrorMsg> errorsP = new List<TourErrorMsg>();

                DateTime dateDept_A = Convert.ToDateTime(Request["fromdate"].Trim());
                DateTime dateRtn_A = Convert.ToDateTime(Request["todate"].Trim());
                DateTime dateChinkIn_H;
                DateTime dateChinkOut_H;

                Session["CurrentSession"] = new SessionClass();
                SessionClass scAH = (SessionClass)Session["CurrentSession"];

                if (Request["fromcity"].Trim().Length == 0)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Error_City1;
                    errorsP.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsP.Add(error);
                }

                if (Request["tocity"].Trim().Length == 0)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Error_City2;
                    errorsP.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsP.Add(error);
                }

                string txtFrom_AH = ConvertName(Request["fromcity"].Trim());
                string txtTo_AH = ConvertName(Request["tocity"].Trim());

                //Utility.SelectAirGroup = null;
                PackageSearchCondition PacakgeSearch = new PackageSearchCondition();
                PacakgeSearch.IsReset = true;
                


                PacakgeSearch.DepatrueAirPorts = new List<Terms.Common.Domain.Airport>();
                scAH.FromCityName = txtFrom_AH.Trim();
                if (txtFrom_AH.Trim().Length > 3)
                {
                    IList departureAirPorts = _CommonService.FindAirportByCityName(txtFrom_AH.Trim());

                    if (departureAirPorts.Count >= 1)
                    {
                        PacakgeSearch.DepatrueAirPorts = departureAirPorts;
                        scAH.FromAirports = departureAirPorts;
                    }
                    else
                    {
                        List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                        Terms.Common.Domain.Airport airport = MatchAirport(txtFrom_AH.Trim(), airportList);
                        if (airport != null)
                        {
                            PacakgeSearch.DepatrueAirPorts.Add(airport);
                        }
                        else
                        {
                            scAH.IsRealFromCity = false;
                            TourErrorMsg error = new TourErrorMsg();
                            error.IsError = true;
                            error.ErrorMsg = Resources.HintInfo.Package_Error_City3;
                            errorsP.Add(error);
                        }
                    }
                }
                else
                {
                    Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(txtFrom_AH.Trim());

                    if (airport != null)
                    {
                        PacakgeSearch.DepatrueAirPorts.Add(airport);
                    }
                    else
                    {
                        IList departureAirPorts = AirService.CommAirportDao.FindByCityCode(txtFrom_AH.Trim());

                        if (departureAirPorts.Count >= 1)
                        {
                            PacakgeSearch.DepatrueAirPorts = departureAirPorts;
                        }
                        else
                        {
                            scAH.IsRealFromCity = false;
                            TourErrorMsg error = new TourErrorMsg();
                            error.IsError = true;
                            error.ErrorMsg = Resources.HintInfo.Package_Error_City3;
                            errorsP.Add(error);
                        }
                    }
                }

                PacakgeSearch.DestinationAirPorts = new List<Terms.Common.Domain.Airport>();
                scAH.ToCityName = txtTo_AH.Trim();
                if (txtTo_AH.Trim().Length > 3)
                {
                    IList DestinationOneAirPorts = _CommonService.FindAirportByCityName(txtTo_AH.Trim());

                    if (DestinationOneAirPorts.Count >= 1)
                    {
                        PacakgeSearch.DestinationAirPorts = DestinationOneAirPorts;
                        scAH.ToAirports = DestinationOneAirPorts;
                    }
                    else
                    {
                        List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                        Terms.Common.Domain.Airport airport = MatchAirport(txtTo_AH.Trim(), airportList);
                        if (airport != null)
                        {
                            PacakgeSearch.DestinationAirPorts.Add(airport);
                        }
                        else
                        {
                            scAH.IsRealToCity = false;
                            TourErrorMsg error = new TourErrorMsg();
                            error.IsError = true;
                            error.ErrorMsg = Resources.HintInfo.Package_Error_City4;
                            errorsP.Add(error);
                        }
                    }
                }
                else
                {
                    Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(txtTo_AH.Trim());

                    if (airport != null)
                    {
                        PacakgeSearch.DestinationAirPorts.Add(airport);
                    }
                    else
                    {
                        IList DestinationOneAirPorts = AirService.CommAirportDao.FindByCityCode(txtTo_AH.Trim());

                        if (DestinationOneAirPorts.Count >= 1)
                        {
                            PacakgeSearch.DestinationAirPorts = DestinationOneAirPorts;
                        }
                        else
                        {
                            scAH.IsRealToCity = false;
                            TourErrorMsg error = new TourErrorMsg();
                            error.IsError = true;
                            error.ErrorMsg = Resources.HintInfo.Package_Error_City4;
                            errorsP.Add(error);
                        }
                    }
                }



                //判断输入的出发地和目的地有没有机场
                if (PacakgeSearch.DepatrueAirPorts.Count == 0)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Error_City3;
                    errorsP.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsP.Add(error);
                }

                if (PacakgeSearch.DestinationAirPorts.Count == 0)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Error_City4;
                    errorsP.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsP.Add(error);
                }


                //如果目的地的国家是美国和加拿大，那么酒店的入住日期就是出发日期。
                if (Request["checkin"].Trim() == "__/__/____" || Request["checkin"].Trim() == "")
                {
                    if (((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.CountryCode == "US" || ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.CountryCode == "CA")
                    {
                        dateChinkIn_H = dateDept_A;  //若Check in为空，则默认为Air出发日期加一天
                    }
                    else
                    {
                        dateChinkIn_H = dateDept_A.AddDays(1);  //若Check in为空，则默认为Air出发日期加一天
                    }
                }
                else
                {
                    dateChinkIn_H = Convert.ToDateTime(Request["checkin"].Trim());
                }

                if (Request["checkout"].Trim() == "__/__/____" || Request["checkout"].Trim() == "")
                    dateChinkOut_H = dateRtn_A;             //若Check out为空，则默认为Air返回日期
                else
                    dateChinkOut_H = Convert.ToDateTime(Request["checkout"].Trim());

                if (dateDept_A < DateTime.Now.AddDays(7))
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Date_Error1;
                    errorsP.Add(error);
                }
                else if (dateRtn_A < DateTime.Now.AddDays(7))
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Date_Error2;
                    errorsP.Add(error);
                }
                else if (dateChinkIn_H < DateTime.Now.AddDays(7))
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Date_Error3;
                    errorsP.Add(error);
                }
                else if (dateChinkOut_H < DateTime.Now.AddDays(7))
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Date_Error4;
                    errorsP.Add(error);
                }
                else if (dateChinkIn_H <= DateTime.Today)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Date_Error5;
                    errorsP.Add(error);
                }
                else if (dateChinkIn_H > dateChinkOut_H)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Date_Error6;
                    errorsP.Add(error);
                }
                else if (dateDept_A >= dateRtn_A)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Date_Error7;
                    errorsP.Add(error);
                }
                else if (dateDept_A > dateChinkIn_H)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Date_Error8;
                    errorsP.Add(error);
                }
                else if (dateChinkOut_H > dateRtn_A)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Package_Date_Error9;
                    errorsP.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsP.Add(error);
                }

                int adult = 0;
                int child = 0;

                for (int i = 0; i < Convert.ToInt32(Request["roomnumber"].Trim()); i++)
                {
                    adult += Convert.ToInt32(Request["a" + (i + 1)].Trim());
                    child += Convert.ToInt32(Request["c" + (i + 1)].Trim());

                    RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

                    roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Adult, Convert.ToInt32(Request["a" + (i + 1)].Trim()));
                    roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Child, Convert.ToInt32(Request["c" + (i + 1)].Trim()));

                    PacakgeSearch.HotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
                }

                PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Adult, adult);
                PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Child, child);

                if (PacakgeSearch.DestinationAirPorts.Count > 0 && PacakgeSearch.DepatrueAirPorts.Count > 0)
                {
                    PacakgeSearch.HotelSearchCondition.CheckIn = dateChinkIn_H.AddDays(0);
                    PacakgeSearch.HotelSearchCondition.CheckOut = dateChinkOut_H;
                    PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).CityCode;// "PVG";
                    PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
                    PacakgeSearch.HotelSearchCondition.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Country.Code;

                    AirTripCondition DPTairTripCondition = new AirTripCondition();
                    DPTairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
                    DPTairTripCondition.DepartureDate = Convert.ToDateTime(dateDept_A);
                    DPTairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0];
                    DPTairTripCondition.IsDepartureTimeSpecified = Convert.ToBoolean(Request["isadd"].Trim());
                    PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
                    AirTripCondition RTNairTripCondition = new AirTripCondition();
                    RTNairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0];
                    RTNairTripCondition.DepartureDate = Convert.ToDateTime(dateRtn_A);
                    RTNairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
                    RTNairTripCondition.IsDepartureTimeSpecified = Convert.ToBoolean(Request["isadd"].Trim());
                    PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);
                    PacakgeSearch.AirSearchCondition.FlightType = "roundtrip";

                    if (Request["aircode"].Trim() != "all")
                    {
                        PacakgeSearch.AirSearchCondition.Airlines = new string[1] { Request["aircode"].Trim() };
                    }
                    else
                    {
                        PacakgeSearch.AirSearchCondition.Airlines = null;
                    }

                    Utility.IsTourMain = false;//设置是否是Tour标志
                    this.Transaction.IntKey = PacakgeSearch.GetHashCode();
                    this.Transaction.CurrentSearchConditions = PacakgeSearch;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

                    //设置Cabin
                    TERMS.Common.CabinType cabin = new TERMS.Common.CabinType();
                    if (Request["airclass"].Trim() == "ECONOMY")
                    {
                        cabin = TERMS.Common.CabinType.Economy;
                    }
                    else if (Request["airclass"].Trim() == "BUSINESS")
                    {
                        cabin = TERMS.Common.CabinType.Business;
                    }
                    else if (Request["airclass"].Trim() == "FIRST")
                    {
                        cabin = TERMS.Common.CabinType.First;
                    }

                    for (int i = 0; i < PacakgeSearch.AirSearchCondition.AirTripCondition.Count; i++)
                        PacakgeSearch.AirSearchCondition.AirTripCondition[i].Cabin = cabin;

                    if (PacakgeSearch.DestinationAirPorts.Count > 1 || PacakgeSearch.DepatrueAirPorts.Count > 1)
                    {
                        this.Page.Response.Redirect("~/Page/Package2/PackageMoreSearch.aspx?ConditionID=" + this.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        Utility.Transaction.Difference.Clear();
                        Utility.Transaction.Difference.FromTime = DateTime.Now;
                        Utility.Transaction.Difference.StarTime = DateTime.Now;
                        Utility.Transaction.Difference.From = "PackageSearchMoreForm Redirect Start";
                        ConditionID = this.Transaction.IntKey.ToString();
                        Target = @"~/Page/Package2/ViewYourPackages";
                    }
                }
                else
                {
                    PacakgeSearch.HotelSearchCondition.CheckIn = dateChinkIn_H.AddDays(0);
                    PacakgeSearch.HotelSearchCondition.CheckOut = dateChinkOut_H;
                    PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;

                    AirTripCondition DPTairTripCondition = new AirTripCondition();
                    DPTairTripCondition.DepartureDate = Convert.ToDateTime(dateDept_A);
                    DPTairTripCondition.IsDepartureTimeSpecified = Convert.ToBoolean(Request["isadd"].Trim());
                    PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
                    AirTripCondition RTNairTripCondition = new AirTripCondition();
                    RTNairTripCondition.DepartureDate = Convert.ToDateTime(dateRtn_A);
                    RTNairTripCondition.IsDepartureTimeSpecified = Convert.ToBoolean(Request["isadd"].Trim());
                    PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);
                    PacakgeSearch.AirSearchCondition.FlightType = "roundtrip";

                    if (Request["aircode"].Trim() != "all")
                    {
                        PacakgeSearch.AirSearchCondition.Airlines = new string[1] { Request["aircode"].Trim() };
                    }
                    else
                    {
                        PacakgeSearch.AirSearchCondition.Airlines = null;
                    }

                    Utility.IsTourMain = false;//设置是否是Tour标志
                    this.Transaction.IntKey = PacakgeSearch.GetHashCode();
                    this.Transaction.CurrentSearchConditions = PacakgeSearch;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

                    //设置Cabin
                    TERMS.Common.CabinType cabin = new TERMS.Common.CabinType();
                    if (Request["aircode"].Trim() == "ECONOMY")
                    {
                        cabin = TERMS.Common.CabinType.Economy;
                    }
                    else if (Request["aircode"].Trim() == "BUSINESS")
                    {
                        cabin = TERMS.Common.CabinType.Business;
                    }
                    else if (Request["aircode"].Trim() == "FIRST")
                    {
                        cabin = TERMS.Common.CabinType.First;
                    }

                    for (int i = 0; i < PacakgeSearch.AirSearchCondition.AirTripCondition.Count; i++)
                        PacakgeSearch.AirSearchCondition.AirTripCondition[i].Cabin = cabin;

                    if (PacakgeSearch.DestinationAirPorts.Count > 1 || PacakgeSearch.DepatrueAirPorts.Count > 1)
                    {
                        this.Page.Response.Redirect("~/Page/Package2/PackageMoreSearch.aspx?ConditionID=" + this.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        Utility.Transaction.Difference.Clear();
                        Utility.Transaction.Difference.FromTime = DateTime.Now;
                        Utility.Transaction.Difference.StarTime = DateTime.Now;
                        Utility.Transaction.Difference.From = "PackageSearchMoreForm Redirect Start";
                        ConditionID = this.Transaction.IntKey.ToString();
                        Target = @"~/Page/Package2/ViewYourPackages";
                    }
                }

                scAH.CurrentItinerary.SearchInfo = PacakgeSearch.AirSearchCondition;

                ForbiddenAirportControl fAH = new ForbiddenAirportControl();

                bool IsErrorAirH = fAH.HasForbiddenAirport(scAH);

                if (IsErrorAirH)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.ForbiddenAirport;
                    errorsP.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsP.Add(error);
                }
                bool IsErrorP = false;
                for (int i = 0; i < errorsP.Count; i++)
                {
                    if (errorsP[i].IsError)
                    {
                        IsErrorP = true;
                    }
                }
                if (IsErrorP)
                {
                    Session["ErrorMsg"] = errorsP;
                    Response.Redirect("~/Page/Package2/SearchConditionsMeassageAHForm.aspx");
                }
                break;
            case "H":
                List<TourErrorMsg> errors = new List<TourErrorMsg>();

                if (Request["city"].Trim().Trim().Length == 0)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Hotel_Error_City;
                    errors.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errors.Add(error);
                }

                string txtName = ConvertName(Request["city"].Trim());

                DateTime dtNow = DateTime.Now;
                hotelSearchHotelByZyl.Info("MV_B2C Hotel Serach Start : " + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

                if (Utility.IsSubAgent)
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchHotel, this);
                else
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchHotel, this);

                try
                {
                    //log begin 20090312 Leon
                    log.Info("\r\n");

                    if (!Utility.IsLogin)
                    {
                        log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >====================Not Login========================");
                    }
                    else
                    {
                        log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >==========================Login========================");
                    }

                    log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >SearchClick Begin Start time : " + System.DateTime.Now);
                    //log end 20090312 Leon
                }
                catch
                {

                }

                DateTime ChinkIn_H = Convert.ToDateTime(Request["checkin"].Trim());
                DateTime ChinkOut_H = Convert.ToDateTime(Request["checkout"].Trim());

                if (ChinkIn_H < DateTime.Now.AddDays(7))
                {
                    if (Utility.IsLogin && Utility.IsSubAgent)
                    {
                        if (ChinkIn_H < DateTime.Now.AddDays(3))
                        {
                            TourErrorMsg error = new TourErrorMsg();
                            error.IsError = true;
                            error.ErrorMsg = Resources.HintInfo.Hotel_Date_Error1;
                            errors.Add(error);
                        }                        
                    }
                    else
                    {
                        TourErrorMsg error = new TourErrorMsg();
                        error.IsError = true;
                        error.ErrorMsg = Resources.HintInfo.Hotel_Date_Error1;
                        errors.Add(error);
                    }                    
                }
                else if (ChinkOut_H < DateTime.Now.AddDays(7))
                {
                    if (Utility.IsLogin && Utility.IsSubAgent)
                    {
                        if (ChinkOut_H < DateTime.Now.AddDays(3))
                        {
                            TourErrorMsg error = new TourErrorMsg();
                            error.IsError = true;
                            error.ErrorMsg = Resources.HintInfo.Hotel_Date_Error2;
                            errors.Add(error);
                        }
                    }
                    else
                    {
                        TourErrorMsg error = new TourErrorMsg();
                        error.IsError = true;
                        error.ErrorMsg = Resources.HintInfo.Hotel_Date_Error2;
                        errors.Add(error);
                    }
                }
                else if (ChinkIn_H < DateTime.Today && ChinkOut_H < DateTime.Today)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Hotel_Date_Error3;
                    errors.Add(error);
                }
                else if (ChinkIn_H <= DateTime.Today)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Hotel_Date_Error4;
                    errors.Add(error);
                }
                else if (ChinkOut_H <= ChinkIn_H)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Hotel_Date_Error5;
                    errors.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errors.Add(error);
                }

                HotelSearchCondition hotelSearchCondition = new HotelSearchCondition();

                for (int i = 0; i < Convert.ToInt32(Request["roomnumber"].Trim()); i++)
                {
                    RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

                    roomSearchCondition.Passengers.Add(PassengerType.Adult, Convert.ToInt32(Request["a" + (i + 1)].Trim()));
                    roomSearchCondition.Passengers.Add(PassengerType.Child, Convert.ToInt32(Request["c" + (i + 1)].Trim()));

                    hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
                }

                hotelSearchCondition.UserInputInfo = Request["city"].Trim();
                hotelSearchCondition.LocationIndicator = LocationIndicator.City;
                hotelSearchCondition.CheckIn = ChinkIn_H;
                hotelSearchCondition.CheckOut = ChinkOut_H;
                this.Transaction.IntKey = hotelSearchCondition.GetHashCode();
                this.Transaction.CurrentSearchConditions = hotelSearchCondition;
                this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                Utility.IsTourMain = false;//设置是否是Tour标志
                ConditionID = this.Transaction.IntKey.ToString();
                Target = @"~/Page/Hotel2/SearchResultForm";

                bool IsError = false;
                for (int i = 0; i < errors.Count; i++)
                {
                    if (errors[i].IsError)
                    {
                        IsError = true;
                    }
                }

                if (IsError)
                {
                    Session["ErrorMsg"] = errors;
                    Response.Redirect("~/Page/Hotel2/SearchConditionsMeassageHForm.aspx");
                }

                if (txtName.Trim().Length == 3)
                {
                    Terms.Common.Domain.City CityName = _cityService.Get(txtName);

                    if (CityName != null)
                    {
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = CityName.Code;
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = CityName.CountryCode;
                    }
                    else
                    {
                        Terms.Common.Domain.Airport airport = _airportService.Get(txtName);
                        if (airport != null)
                        {
                            ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = airport.City.Code;
                            ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = airport.City.CountryCode;
                        }
                        else
                        {
                            IList ilCityName = _cityService.FindSomeCityByName(txtName);
                            if (ilCityName.Count > 1)
                            {
                                Session["CityNameList"] = ilCityName;
                                this.Response.Redirect(SaleWebSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + txtName);
                            }
                            else if (ilCityName.Count == 1)
                            {
                                Terms.Common.Domain.City citylist = (Terms.Common.Domain.City)ilCityName[0];
                                ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = citylist.Code;
                                ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = citylist.CountryCode;
                            }
                            else if (ilCityName == null || ilCityName.Count == 0)
                            {
                                Session["CityNameList"] = null;
                                this.Response.Redirect(SaleWebSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + txtName);
                            }
                        }
                    }

                }
                else
                {
                    //判断是否有多个.如果有相同则到SerachMore页面进行选择,如果没有则进入搜索页面
                    IList ilCityName = _cityService.FindSomeCityByName(txtName);

                    if (ilCityName.Count > 1)
                    {
                        Session["CityNameList"] = ilCityName;
                        this.Response.Redirect(SaleWebSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + txtName);
                    }
                    else if (ilCityName.Count == 1)
                    {
                        Terms.Common.Domain.City citylist = (Terms.Common.Domain.City)ilCityName[0];
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = citylist.Code;
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = citylist.CountryCode;
                    }
                    else if (ilCityName == null || ilCityName.Count == 0)
                    {
                        Terms.Common.Domain.Airport airport = _airportService.Get(txtName);
                        if (airport != null)
                        {
                            ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = airport.City.Code;
                            ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = airport.City.CountryCode;
                        }
                        else
                        {
                            this.Response.Redirect(SaleWebSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + txtName);
                        }
                    }
                }


                log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >Redirect Searching1.aspx Begin Start time : " + System.DateTime.Now);

                hotelSearchHotelByZyl.Debug("Hotel Start :" + DateTime.Now.ToLongTimeString());

                dtNow = DateTime.Now;
                hotelSearchHotelByZyl.Info("MV_B2C Hotel Serach To Searching1 Start : " + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);
                break;
            case "T":
                if (Utility.IsSubAgent)
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchTour, this);
                else
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchTour, this);

                List<TourErrorMsg> errorsT = new List<TourErrorMsg>();

                //log begin 20090312 Leon
                PageUtility.TourSearchingTimeLog.Info("\r\n");

                if (!Utility.IsLogin)
                    PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >====================Not Login========================");
                else
                    PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >==========================Login========================");

                PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >Tour Searching(1) Begin at: " + System.DateTime.Now);

                //log end 20090312 Leon


                TourSearchCondition tourSearchCondition = new TourSearchCondition();
                tourSearchCondition.Region = Request["region"].Trim();
                if (tourSearchCondition.Region.Trim() == "Please select a area")
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Tour_Error1;
                    errorsT.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsT.Add(error);
                }
                string country = Request["counrty"].Trim();
                int index = country.IndexOf("-");
                if (index < 0)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Tour_Error2;
                    errorsT.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsT.Add(error);
                }
                tourSearchCondition.Counrty = country.Substring(index + 1).Trim();
                string city = Request["city"].Trim();
                index = city.IndexOf("-");
                if (index < 0)
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Tour_Error3;
                    errorsT.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsT.Add(error);
                }
                tourSearchCondition.City = city.Substring(index + 1).Trim();
                tourSearchCondition.IsLandOnly = Convert.ToBoolean(Request["landonly"].Trim());
                tourSearchCondition.TravelBeginDate = GlobalUtility.GetDateTime(Request["tourdate"].Trim());
                if (Request["tourdate"].Trim() == "__/__/____" || Request["tourdate"].Trim() == "")
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Tour_Error4;
                    errorsT.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsT.Add(error);
                }

                if (tourSearchCondition.TravelBeginDate < DateTime.Now.AddDays(3))
                {
                    TourErrorMsg error = new TourErrorMsg();
                    error.IsError = true;
                    error.ErrorMsg = Resources.HintInfo.Tour_Error5;
                    errorsT.Add(error);
                }
                else
                {
                    TourErrorMsg error = new TourErrorMsg();
                    errorsT.Add(error);
                }
                switch (Request["traveldate"].Trim())
                {
                    case "5": tourSearchCondition.TravelDaysFrom = 1;
                        tourSearchCondition.TravelDaysTo = 10;
                        break;
                    case "11": tourSearchCondition.TravelDaysFrom = 11;
                        tourSearchCondition.TravelDaysTo = 15;
                        break;
                    case "15": tourSearchCondition.TravelDaysFrom = 16;
                        tourSearchCondition.TravelDaysTo = 800;
                        break;
                    default:
                        tourSearchCondition.TravelDaysFrom = 1;
                        tourSearchCondition.TravelDaysTo = 800;
                        break;
                }

                
                
                this.Transaction.IntKey = tourSearchCondition.GetHashCode();
                this.Transaction.CurrentSearchConditions = tourSearchCondition;
                this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                Utility.IsTourMain = false;//设置是否是Tour标志
                Utility.IsTourMore = false;//设置是否是Tour More
                ConditionID = this.Transaction.IntKey.ToString();
                Target = @"~/Page/Tour/TourMoreSearchResultForm";
                bool IsErrorT = false;
                for (int i = 0; i < errorsT.Count; i++)
                {
                    if (errorsT[i].IsError)
                    {
                        IsErrorT = true;
                    }
                }

                if (IsErrorT)
                {
                    Session["ErrorMsg"] = errorsT;
                    Response.Redirect("~/Page/Tour/SearchConditionsMeassageTForm.aspx");
                }
                break;
            case "P":
                SearchPromos();

                break;

            case "C":
                string fromcity = ConvertName(Request["fromcity"].Trim());
                string tocity = ConvertName(Request["tocity"].Trim());
                string checkindate = ConvertName(Request["checkindate"].Trim());
                string checkoutdate = ConvertName(Request["checkoutdate"].Trim());

                string CheckInTimeCode = Request["checkintime"].Trim();
                string CheckOutTimeCode = Request["checkouttime"].Trim();

                string checkintime = CheckInTimeCode.Substring(0, 4);
                string checkouttime = CheckOutTimeCode.Substring(0, 4);

                string checkintimeX = CheckInTimeCode.Substring(4);
                string checkouttimeX = CheckOutTimeCode.Substring(4);

                string cartype = ConvertName(Request["cartype"].Trim());
                string carcodetype = ConvertName(Request["carcodetype"].Trim());

                DateTime fromDate = DateTime.MinValue;
                DateTime toDate = DateTime.MinValue;

                if (checkintimeX == "A")
                {
                    fromDate = Convert.ToDateTime(checkindate).AddHours(Convert.ToDouble(checkintime.Substring(0, 2))).AddMinutes(Convert.ToDouble(checkintime.Substring(2)));
                }
                else
                {
                    if (checkintime == "1200")
                    {
                        fromDate = Convert.ToDateTime(checkindate);
                    }
                    else
                    {
                        fromDate = Convert.ToDateTime(checkindate).AddHours(Convert.ToDouble(checkintime.Substring(0, 2)) + Convert.ToDouble("12")).AddMinutes(Convert.ToDouble(checkintime.Substring(2)));
                    }
                }
                if (checkouttimeX == "A")
                {
                    toDate = Convert.ToDateTime(checkoutdate).AddHours(Convert.ToDouble(checkouttime.Substring(0, 2))).AddMinutes(Convert.ToDouble(checkouttime.Substring(2)));
                }
                else
                {
                    if (checkouttime == "1200")
                    {
                        toDate = Convert.ToDateTime(checkoutdate);
                    }
                    else
                    {
                        toDate = Convert.ToDateTime(checkoutdate).AddHours(Convert.ToDouble(checkouttime.Substring(0, 2)) + Convert.ToDouble("12")).AddMinutes(Convert.ToDouble(checkouttime.Substring(2)));
                    }
                }                

                string UserInputInfoFrom = Request["fromcity"].Trim();

                string UserInputInfoTo = Request["tocity"].Trim();

                if (carcodetype.Trim().ToUpper() == "D")
                {
                }
                else
                {
                    UserInputInfoTo = Request["fromcity"].Trim();
                    tocity = fromcity;
                }

                string PickupAirportCode = string.Empty;
                string PickupISOCountryCode = string.Empty;

                string DropoffAirportCode = string.Empty;
                string DropoffISOCountryCode = string.Empty;

                if (fromcity.Trim().Length == 3)
                {
                    Terms.Common.Domain.Airport airport = _airportService.Get(fromcity);
                    if (airport != null)
                    {
                        PickupAirportCode = airport.Code;
                        PickupISOCountryCode = airport.City.CountryCode;
                    }
                    else
                    {
                        IList ilCityName = _cityService.FindSomeCityByName(fromcity);

                        if (ilCityName.Count > 1)
                        {

                        }
                        else if (ilCityName.Count == 1)
                        {
                            Terms.Common.Domain.City citylist = (Terms.Common.Domain.City)ilCityName[0];

                            PickupAirportCode = citylist.Code;
                            PickupISOCountryCode = citylist.CountryCode;
                        }
                    }
                }
                else
                {
                    //判断是否有多个.如果有相同则到SerachMore页面进行选择,如果没有则进入搜索页面
                    IList DestinationOneAirPorts = _CommonService.FindAirportByCityName(fromcity);

                    if (DestinationOneAirPorts.Count >= 1)
                    {
                        PickupAirportCode = ((Airport)DestinationOneAirPorts[0]).Code;
                        PickupISOCountryCode = ((Airport)DestinationOneAirPorts[0]).City.CountryCode ;
                    }
                    else
                    {
                        List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                        Terms.Common.Domain.Airport airport = MatchAirport(fromcity, airportList);
                        if (airport != null)
                        {
                            PickupAirportCode = airport.Code;
                            PickupISOCountryCode = airport.City.CountryCode;
                        }
                    }
                }

                if (tocity.Trim().Length == 3)
                {
                    Terms.Common.Domain.Airport airport = _airportService.Get(tocity);
                    if (airport != null)
                    {
                        DropoffAirportCode = airport.Code;
                        DropoffISOCountryCode = airport.City.CountryCode;
                    }
                    else
                    {
                        IList ilCityName = _cityService.FindSomeCityByName(tocity);

                        if (ilCityName.Count > 1)
                        {

                        }
                        else if (ilCityName.Count == 1)
                        {
                            Terms.Common.Domain.City citylist = (Terms.Common.Domain.City)ilCityName[0];
                            DropoffAirportCode = citylist.Code;
                            DropoffISOCountryCode = citylist.CountryCode;
                        }
                    }
                }
                else
                {
                    //判断是否有多个.如果有相同则到SerachMore页面进行选择,如果没有则进入搜索页面
                    IList DestinationOneAirPorts = _CommonService.FindAirportByCityName(tocity);

                    if (DestinationOneAirPorts.Count >= 1)
                    {
                        DropoffAirportCode = ((Airport)DestinationOneAirPorts[0]).Code;
                        DropoffISOCountryCode = ((Airport)DestinationOneAirPorts[0]).City.CountryCode;
                    }
                    else
                    {
                        List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                        Terms.Common.Domain.Airport airport = MatchAirport(tocity, airportList);
                        if (airport != null)
                        {
                            DropoffAirportCode = airport.Code;
                            DropoffISOCountryCode = airport.City.CountryCode;
                        }
                    }
                }

                TERMS.Common.Search.VehcileSearchCondition sear = null;


                if (carcodetype.Trim().ToUpper() != "D")
                {
                    sear = new TERMS.Common.Search.VehcileSearchCondition(PickupISOCountryCode, PickupAirportCode, UserInputInfoFrom, fromDate, toDate);
                }
                else
                {
                    sear = new TERMS.Common.Search.VehcileSearchCondition(PickupISOCountryCode, PickupAirportCode, UserInputInfoFrom, fromDate, DropoffISOCountryCode, DropoffAirportCode, UserInputInfoTo, toDate);
                }

                sear.Category = cartype;

                Terms.Sales.Business.VehcileSearchCondition vehcilesearchcondition = new Terms.Sales.Business.VehcileSearchCondition(sear);

                this.Transaction.IntKey = vehcilesearchcondition.GetHashCode();
                this.Transaction.CurrentSearchConditions = vehcilesearchcondition;
                this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                Utility.IsTourMain = false;//设置是否是Tour标志
                ConditionID = this.Transaction.IntKey.ToString();
                Target = @"~/Page/Vehcile/SearchConditionsMeassageCForm";
                break;
        }
    }

    private void SearchPromos()
    {
        string depCity = ConvertName(Request["fromcity"].Trim());
        string toCity = ConvertName(Request["tocity"].Trim());
        string rtnFromCity = ConvertName(Request["rtnfromah"].Trim());
        string rtnToCity = ConvertName(Request["rtntoah"].Trim());

        //log begin 20090312 Leon
        log.Info("\r\n");
        System.Random rd = new Random();

        Session["LOG_RANDOM"] = rd.Next(999999999);


        if (!Utility.IsLogin)
        {
            log.Info(Session["LOG_RANDOM"].ToString() + " >====================Not Login========================");
        }
        else
        {
            log.Info(Session["LOG_RANDOM"].ToString() + " >==========================Login========================");
        }
        string logAirline = Request["aircode"].Trim().Trim().Equals(string.Empty) ? "All" : Request["aircode"].Trim();
        log.Info(Session["LOG_RANDOM"].ToString() + " >==========================AirLine:" + logAirline + "========================");
        log.Info(Session["LOG_RANDOM"].ToString() + " >SearchClick Begin Start time : " + System.DateTime.Now);
        //log end 20090312 Leon


        if (Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchAir, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchAir, this);

        Session["HasReminder"] = true;


        //if (!Page.IsValid)
        //    return;
        bool IsSelectAirport = false;
        bool IsRealCity = true;

        Session["CurrentSession"] = new SessionClass();
        SessionClass sc = (SessionClass)Session["CurrentSession"];

        AirSearchCondition airSearchCondition = new AirSearchCondition();

        airSearchCondition.SetPassengerNumber(PassengerType.Adult, Convert.ToInt32(Convert.ToInt32(Request["adults"].Trim())));

        CabinType cabinA = new CabinType();
        if (Request["airclass"].Trim() == "ECONOMY")
        {
            cabinA = CabinType.Economy;
        }
        else if (Request["airclass"].Trim() == "BUSINESS")
        {
            cabinA = CabinType.Business;
        }
        else if (Request["airclass"].Trim() == "FIRST")
        {
            cabinA = CabinType.First;
        }
        else
        {
            cabinA = CabinType.All;
        }

        airSearchCondition.SetPassengerNumber(PassengerType.Child, Convert.ToInt32(Convert.ToInt32(Request["children"].Trim())));

        airSearchCondition.FlightType = Request["airtype"].Trim();

        airSearchCondition.FlexibleDays = 0;

        AirTripCondition deptCondition = new AirTripCondition();
        deptCondition.Cabin = cabinA;

        sc.FromCityName = depCity.Trim();
        if (depCity.Trim().Length > 3)
        {
            IList departureAirPorts = _CommonService.FindAirportByCityName(depCity.Trim());

            if (departureAirPorts.Count > 1)
            {
                IsSelectAirport = true;
                sc.FromAirports = departureAirPorts;
            }
            else if (departureAirPorts.Count == 1)
            {
                deptCondition.Departure = (Terms.Common.Domain.Airport)departureAirPorts[0];
            }
            else
            {

                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(depCity.Trim(), airportList);
                if (airport != null)
                    deptCondition.Departure = airport;
                else
                    sc.IsRealFromCity = IsRealCity = false;
                //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDepCity.Value + "\"&GoToPage=~/index.aspx");
            }

        }
        else
        {
            deptCondition.Departure = AirService.CommAirportDao.FindByAirport(depCity.Trim());

            if (deptCondition.Departure == null)
            {
                deptCondition.Departure = new Terms.Common.Domain.Airport();
                deptCondition.Departure.Code = depCity.Trim();
            }
        }

        deptCondition.DepartureDate = GlobalUtility.GetDateTime(Request["fromdate"].Trim());

        bool IsDataError = true;

        if (deptCondition.DepartureDate < DateTime.Now.AddDays(3))
        {
            IsRealCity = false;
            IsDataError = false;

        }

        sc.ToCityName = toCity.Trim();
        if (toCity.Trim().Length > 3)
        {
            IList destinationAirPorts = _CommonService.FindAirportByCityName(toCity.Trim());

            if (destinationAirPorts.Count > 1)
            {
                IsSelectAirport = true;
                sc.ToAirports = destinationAirPorts;
            }
            else if (destinationAirPorts.Count == 1)
            {
                deptCondition.Destination = (Terms.Common.Domain.Airport)destinationAirPorts[0];
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(toCity.Trim(), airportList);
                if (airport != null)
                    deptCondition.Destination = airport;
                else
                    sc.IsRealToCity = IsRealCity = false;
                // Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDesCity.Value + "\"&GoToPage=~/index.aspx");
            }

        }
        else
        {
            deptCondition.Destination = AirService.CommAirportDao.FindByAirport(toCity.Trim());

            if (deptCondition.Destination == null)
            {
                deptCondition.Destination = new Terms.Common.Domain.Airport();
                deptCondition.Destination.Code = toCity.Trim();
            }
        }



        AirTripCondition rtnCondition = new AirTripCondition();
        rtnCondition.Cabin = cabinA;




        if (Request["airtype"].Trim().ToLower().Equals("oneway"))
        {
            rtnCondition.Departure = deptCondition.Destination;
            rtnCondition.Destination = deptCondition.Departure;
            rtnCondition.DepartureDate = DateTime.MaxValue;
        }
        else if (Request["airtype"].Trim().ToLower().Equals("roundtrip"))
        {
            rtnCondition.Departure = deptCondition.Destination;
            rtnCondition.Destination = deptCondition.Departure;
            rtnCondition.DepartureDate = GlobalUtility.GetDateTime(Request["todate"].Trim());
        }
        else if (Request["airtype"].Trim().ToLower().Equals("openjaw"))
        {
            rtnCondition.DepartureDate = GlobalUtility.GetDateTime(Request["todate"].Trim());
            sc.ReturnFromCityName = rtnFromCity.Trim();
            if (rtnFromCity.Trim().Length > 3)
            {
                IList returnFromAirPorts = _CommonService.FindAirportByCityName(rtnFromCity.Trim());

                if (returnFromAirPorts.Count > 1)
                {
                    IsSelectAirport = true;
                    sc.ReturnFromAirports = returnFromAirPorts;
                }
                else if (returnFromAirPorts.Count == 1)
                {
                    rtnCondition.Departure = (Terms.Common.Domain.Airport)returnFromAirPorts[0];
                }
                else
                {
                    List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                    Terms.Common.Domain.Airport airport = MatchAirport(rtnFromCity.Trim(), airportList);
                    if (airport != null)
                        rtnCondition.Departure = airport;
                    else
                        sc.IsRealReturnFromCity = IsRealCity = false;
                    //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtRtnFrom.Value + "\"&GoToPage=~/index.aspx");
                }
            }
            else
            {
                rtnCondition.Departure = AirService.CommAirportDao.FindByAirport(rtnFromCity.Trim());
                if (rtnCondition.Departure == null)
                {
                    rtnCondition.Departure = new Terms.Common.Domain.Airport();
                    rtnCondition.Departure.Code = rtnFromCity.Trim();
                }
            }
            sc.ReturnToCityName = rtnToCity.Trim();
            if (rtnToCity.Trim().Length > 3)
            {
                IList returnToAirPorts = _CommonService.FindAirportByCityName(rtnToCity.Trim());

                if (returnToAirPorts.Count > 1)
                {
                    IsSelectAirport = true;
                    sc.ReturnToAirports = returnToAirPorts;
                }
                else if (returnToAirPorts.Count == 1)
                {
                    rtnCondition.Destination = (Terms.Common.Domain.Airport)returnToAirPorts[0];
                }
                else
                {
                    List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                    Terms.Common.Domain.Airport airport = MatchAirport(rtnToCity.Trim(), airportList);
                    if (airport != null)
                        rtnCondition.Destination = airport;
                    else
                        sc.IsRealReturnToCity = IsRealCity = false;
                    //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtRtnTo.Value + "\"&GoToPage=~/index.aspx");
                }

            }
            else
            {
                rtnCondition.Destination = AirService.CommAirportDao.FindByAirport(rtnToCity.Trim());
                if (rtnCondition.Destination == null)
                {
                    rtnCondition.Destination = new Terms.Common.Domain.Airport();
                    rtnCondition.Destination.Code = rtnToCity.Trim();
                }
            }
        }

        airSearchCondition.AddTripCondition(deptCondition);
        airSearchCondition.AddTripCondition(rtnCondition);


        //if (ddlAirline.SelectedItem.Text != "Search All Airlines")
        if (Request["aircode"].Trim().Trim() != "")
        {
            //param.Airways = ddlAirline.SelectedValue.Split(',');
            airSearchCondition.Airlines = Request["aircode"].Trim().Split(',');
        }

        sc.CurrentItinerary.SearchInfo = airSearchCondition;
        Utility.IsTourMain = false;//设置是否是Tour标志
        this.Transaction.IntKey = airSearchCondition.GetHashCode();
        this.Transaction.CurrentSearchConditions = airSearchCondition;
        this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

        ForbiddenAirportControl f = new ForbiddenAirportControl();

        bool IsErrorAir = f.HasForbiddenAirport(sc);

        if (IsErrorAir)
        {
            Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.ForbiddenAirport);
        }

        if (!IsRealCity)
        {
            if (!Utility.IsLogin && Session["IndexForFlight"] == null)
            {
                if (IsDataError)
                {
                    Response.Redirect("~/Page/Promos/PromosSearching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    Response.Redirect("~/Page/Promos/PromosSearching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
            }

            if (IsDataError)
            {
                Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
            }
            else
            {
                Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
            }
        }
        else
        {
            if (IsSelectAirport)
            {
                if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                {
                    if (IsDataError)
                    {
                        Response.Redirect("~/Page/Promos/PromosSearching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Page/Promos/PromosSearching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }
                }

                if (IsDataError)
                {
                    Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                }
            }
            else
            {
                if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                {
                    if (IsDataError)
                    {
                        Response.Redirect("~/Page/Promos/PromosSearching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Page/Promos/PromosSearching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }
                }

                log.Info(Session["LOG_RANDOM"].ToString() + " >Redirect Searching.aspx Begin Start time : " + System.DateTime.Now);

                if (IsDataError)
                {
                    Response.Redirect("~/Page/Promos/PromosSearching.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    Response.Redirect("~/Page/Promos/PromosSearching.aspxx?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                }
            }
        }
    }


    private string ConvertName(string txtFullName)
    {
        int index = txtFullName.IndexOf("-");

        if (index > 0)
        {
            int end = txtFullName.Substring(index + 1).IndexOf(",");

            if (end > 0)
            {
                return txtFullName.Substring(index + 1, end).Trim();
            }
            else
            {
                return txtFullName.Substring(index + 1).Trim();
            }
        }
        else
        {
            return txtFullName.Trim();
        }
    }

    private Terms.Common.Domain.Airport MatchAirport(string AirportName, List<Terms.Common.Domain.Airport> AirportList)
    {
        foreach (Terms.Common.Domain.Airport airport in AirportList)
        {
            if (airport.Name.Equals(AirportName))
                return airport;
        }
        return null;
    }
}
    