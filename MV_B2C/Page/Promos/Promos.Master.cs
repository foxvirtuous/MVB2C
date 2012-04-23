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
using Terms.Product.Utility;
using Terms.Product.Domain;

using Terms.Global.Utility;

using Terms.Common.Domain;
using Terms.Common.Dao;
using Terms.Material.Service;
using Terms.Common.Service;
using Terms.Sales.Service;
using TERMS.Business.Centers.SalesCenter;

using Terms.Sales.Business;
using TERMS.Common;
using Terms.Configuration.Domain;
using Spring.Context.Support;
using Spring.Aspects.AirOperate;

public partial class Promos : Spring.Web.UI.MasterPage
{
    private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger("AirSearchTime");

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

    private ICommonService _CommonService;

    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    #region PATH
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

    public string MainCssPath
    {
        get
        {
            return this.GetGlobalResourceObject("Resource", GlobalInfo.MainCssPath).ToString() + CulturePath;
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

    private string path = string.Empty;

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
            return UrlSuffix;
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

    public WebSiteMeta CurrentWebSite
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


    public const string Const_WebSite = "www.majestic-vacations.com";
    public const string WebSiteName = "WebSiteName";

    private IApplicationCacheFoundationDate _ApplicationCacheFoundationDate;
    public IApplicationCacheFoundationDate ApplicationCacheFoundationDate
    {
        set
        {
            this._ApplicationCacheFoundationDate = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentWebSite == null) return;

        Header1.SetLanguageAndPhone();

        if (CurrentWebSite.Id != Guid.Empty)
        {
            ConfigurationSettings.AppSettings.Set(WebSiteName, CurrentWebSite.Name);
        }

        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        ltxFrom.Path = ltxTo.Path = depCalendar.Path = rtnCalendar.Path = ltxRtnFrom.Path = ltxRtnTo.Path = "../../";
        ltxFrom.Size = ltxTo.Size = ltxRtnFrom.Size = ltxRtnTo.Size = 80;
        Header1.Path = "../../";

        depCalendar.IsCoercion = true;
        depCalendar.CoercionID = "rtnCalendar";

        //Set Path
        InitStepBar();
        ((TextBox)ltxFrom.FindControl("txtCity")).Attributes.Add("onblur", "SetReturnCity()");
        ((TextBox)ltxTo.FindControl("txtCity")).Attributes.Add("onblur", "SetReturnCity()");
        if (!IsPostBack)
        {
            ShowAmounts();

            if (Request["IsSkip"] != null && Request["IsSkip"] == "Y")
            {
                ClearSession();
            }

            phManage.Visible = m_isShowBookingManage;
            phModifySearch.Visible = m_isShowModifySearch;

            SessionClass sc = (SessionClass)Session["CurrentSession"];
            if (sc != null && m_isShowModifySearch)
            {
                TextBox departureCalendarDate = (TextBox)this.depCalendar.FindControl("calendarDate");


                TextBox returnCalendarDate = (TextBox)this.rtnCalendar.FindControl("calendarDate");

                TextBox txtDepCity = (TextBox)this.ltxFrom.FindControl("txtCity");

                TextBox txtDesCity = (TextBox)this.ltxTo.FindControl("txtCity");

                TextBox txtRtnFrom = (TextBox)this.ltxRtnFrom.FindControl("txtCity");

                TextBox txtRtnTo = (TextBox)this.ltxRtnTo.FindControl("txtCity");


                txtDepCity.Text = ((AirSearchCondition)Transaction.CurrentSearchConditions).AirTripCondition[0].Departure.Code;
                txtDesCity.Text = ((AirSearchCondition)Transaction.CurrentSearchConditions).AirTripCondition[0].Destination.Code;
                departureCalendarDate.Text = ((AirSearchCondition)Transaction.CurrentSearchConditions).AirTripCondition[0].DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                txtRtnFrom.Text = ((AirSearchCondition)Transaction.CurrentSearchConditions).AirTripCondition[1].Departure.Code;
                txtRtnTo.Text = ((AirSearchCondition)Transaction.CurrentSearchConditions).AirTripCondition[1].Destination.Code;
                returnCalendarDate.Text = ((AirSearchCondition)Transaction.CurrentSearchConditions).AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                ddlAdult.SelectedIndex = ((AirSearchCondition)Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Adult);
                ddlChild.SelectedIndex = ((AirSearchCondition)Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Child);
                ddlInfant.SelectedIndex = ((AirSearchCondition)Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Infant);

                if (((AirSearchCondition)Transaction.CurrentSearchConditions).FlightType == "roundtrip")
                {
                    rdbRoundTrip.Checked = true;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangeFlightType", "<script>ChangeFlightType('roundtrip');</script>");
                }
                else if (((AirSearchCondition)Transaction.CurrentSearchConditions).FlightType == "oneway")
                {
                    rdbOneway.Checked = true;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangeFlightType", "<script>ChangeFlightType('oneway');</script>");
                    returnCalendarDate.Text = DateTime.Now.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                }
                else if (((AirSearchCondition)Transaction.CurrentSearchConditions).FlightType == "openjaw")
                {
                    rdbOpenjaw.Checked = true;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangeFlightType", "<script>ChangeFlightType('openjaw');</script>");
                }

                CabinType cabin = ((AirSearchCondition)Transaction.CurrentSearchConditions).GetAddTripCondition()[0].Cabin;

                if (cabin == CabinType.Economy)
                {
                    ddlClass.SelectedIndex = 1;
                }
                else if (cabin == CabinType.Business)
                {
                    ddlClass.SelectedIndex = 2;
                }
                else if (cabin == CabinType.First)
                {
                    ddlClass.SelectedIndex = 3;
                }
                else
                {
                    ddlClass.SelectedIndex = 0;
                }
            }
        }
    }


    #region  StepBar 相关
    private int m_stepNumber = 1;
    public virtual int StepNumber
    {
        set
        {
            m_stepNumber = value;
        }
    }

    /// <summary>
    /// 初始化StepBar
    /// </summary>
    private void InitStepBar()
    {
        //Init Row 1
        List<TableCell> cellNums = new List<TableCell>();
        for (int i = 1; i <= 4; i++)
        {
            TableCell cellTmp = new TableCell();
            TableCell cellTmpWhite = new TableCell();
            if (i <= m_stepNumber)
            {

                cellTmp.CssClass = "D_stepon";
                cellTmp.Height = new Unit(3);
                cellTmpWhite.Width = new Unit(2);
            }
            else
            {
                cellTmp.CssClass = "D_stepof";
                cellTmp.Height = new Unit(3);
                cellTmpWhite.Width = new Unit(2);
            }
            cellTmp.Text = "";
            cellTmpWhite.Text = "";
            cellNums.Add(cellTmp);
            cellNums.Add(cellTmpWhite);
        }

        //Init Row 2
        string[] text = { Resources.Global.Search, Resources.Global.Select, Resources.Global.OrderPayment, Resources.Global.Confirm };
        List<TableCell> cellTexts = new List<TableCell>();
        SessionClass sc = (SessionClass)Session["CurrentSession"];
        bool isSikpable = sc == null;

        for (int i = 0; i < text.Length; i++)
        {
            TableCell cellTmp = new TableCell();
            TableCell cellTmpWhite = new TableCell();
            if (i + 1 <= m_stepNumber)
            {
                cellTmp.CssClass = "D_stepto";
                cellTmp.Text = "<strong>" + text[i] + "</strong>";
                cellTmpWhite.Width = new Unit(2);
                cellTmpWhite.Text = "&nbsp;";
            }
            else
            {
                cellTmp.CssClass = "D_steptf";
                if (i + 1 < m_stepNumber && isSikpable)
                {
                    HyperLink btnStep = new HyperLink();
                    btnStep.ID = "btnStep" + (i + 1).ToString();
                    btnStep.Text = text[i];
                    btnStep.CssClass = "StepSelect";
                    string url = "Step1.aspx";
                    switch (i + 1)
                    {
                        case 1:
                            url = "Step1.aspx";
                            break;
                        case 2:
                            url = "NewStep2.aspx";
                            break;
                        case 3:
                            break;
                        case 4:
                            url = "Step4.aspx";
                            break;
                    }
                    btnStep.NavigateUrl = url + "?IsSkip=Y";
                    cellTmp.Controls.Add(btnStep);
                }
                else
                {
                    cellTmp.CssClass = "D_steptf";
                    cellTmp.Text = text[i];
                }
                cellTmpWhite.Width = new Unit(2);
                cellTmpWhite.Text = "";
            }
            cellTexts.Add(cellTmp);
            cellTexts.Add(cellTmpWhite);
        }





        //Fill Bar
        TableRow row1 = new TableRow();
        row1.HorizontalAlign = HorizontalAlign.Center;

        TableRow row2 = new TableRow();
        row2.HorizontalAlign = HorizontalAlign.Center;

        for (int i = 0; i < cellNums.Count; i++)
        {
            row1.Cells.Add(cellNums[i]);
            row2.Cells.Add(cellTexts[i]);
        }

        tableStep.Rows.Add(row1);
        tableStep.Rows.Add(row2);
    }

    /// <summary>
    /// 清空Session
    /// </summary>
    private void ClearSession()
    {
        SessionClass sessonClass = null;
        if (Session["CurrentSession"] != null)
        {
            sessonClass = (SessionClass)Session["CurrentSession"];
        }
        if (sessonClass == null)
        {
            return;
        }
        switch (m_stepNumber)
        {
            case 1:
                sessonClass.CurrentItinerary = new Itinerary();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    #endregion

    #region  Booking Manage 相关
    private void ShowAmounts()
    {
        if (Session["CurrentSession"] == null)
        {
            return;
        }

        SessionClass sc = (SessionClass)Session["CurrentSession"];
        if (sc.BookingManage == null)
        {
            sc.BookingManage = new BookingManage();
            RefreshAmount();
        }

        lblHoldingAmount.Text = sc.BookingManage.HoldingAmount.ToString();
        lblPurchasedAmount.Text = (sc.BookingManage.PurchasedAmount + sc.BookingManage.ConfirmedAmount).ToString();
        lblDiscrepancyAmount.Text = sc.BookingManage.DiscrepancyAmount.ToString();
        lblTicketedAmount.Text = sc.BookingManage.TicketAmount.ToString();
        lblCancelledAmount.Text = sc.BookingManage.CancelledAmount.ToString();
        lblMsgAmount.Text = sc.BookingManage.MessageAmount.ToString();
    }
    public void RefreshAmount()
    {
        if (Session["CurrentSession"] == null)
        {
            Session["CurrentSession"] = new SessionClass();
        }

        if (Session["USERINFO"] == null)
        {
            return;
        }

        SessionClass sc = (SessionClass)Session["CurrentSession"];
        if (sc.BookingManage == null)
        {
            sc.BookingManage = new BookingManage();
        }
    }
    #endregion

    private bool m_isShowBookingManage = true;
    public virtual bool IsShowBookingManage
    {
        set
        {
            m_isShowBookingManage = value;
        }
    }

    private bool m_isShowModifySearch = false;
    public virtual bool IsShowModifySearch
    {
        set
        {
            m_isShowModifySearch = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        if (CheckSearch() == true)
        {
            if (!Page.IsValid)
                return;

            log.Info("\r\n");
            System.Random rd = new Random();

            Session["LOG_RANDOM"] = rd.Next(999999999);

            if (!Utility.IsLogin)
            {
                log.Info(Session["LOG_RANDOM"].ToString() + " >==================Not Login==============================");
            }
            else
            {
                log.Info(Session["LOG_RANDOM"].ToString() + " >==================Login==============================");
            }

            bool IsSelectAirport = false;
            bool IsRealCity = true;

            SessionClass sc = new SessionClass();

            AirSearchCondition airSearchCondition = new AirSearchCondition();

            airSearchCondition.SetPassengerNumber(PassengerType.Adult, Convert.ToInt32(ddlAdult.SelectedValue));
            airSearchCondition.SetPassengerNumber(PassengerType.Child, Convert.ToInt32(ddlChild.SelectedValue));
            airSearchCondition.SetPassengerNumber(PassengerType.Infant, Convert.ToInt32(ddlInfant.SelectedValue));

            SessionClass CurrentSession = (SessionClass)Session["CurrentSession"];


            airSearchCondition.FlightType = FlightType.Value.Trim();

            airSearchCondition.FlexibleDays = 0;

            CabinType cabin = new CabinType();
            if (ddlClass.SelectedIndex == 0)
            {
                cabin = CabinType.All;
            }
            else if (ddlClass.SelectedIndex == 1)
            {
                cabin = CabinType.Economy;
            }
            else if (ddlClass.SelectedIndex == 2)
            {
                cabin = CabinType.Business;
            }
            else if (ddlClass.SelectedIndex == 3)
            {
                cabin = CabinType.First;
            }

            AirTripCondition deptCondition = new AirTripCondition();
            deptCondition.Cabin = cabin;
            deptCondition.DepartureDate = GlobalUtility.GetDateTime(this.depCalendar.CDate.Trim());

            bool IsDataError = true;

            if (deptCondition.DepartureDate < DateTime.Now.AddDays(3))
            {
                IsRealCity = false;
                IsDataError = false;
            }

            sc.FromCityName = ltxFrom.City.Trim();
            if (ltxFrom.City.Trim().Length > 3)
            {
                IList departureAirPorts = _CommonService.FindAirportByCityName(ltxFrom.City.Trim());

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
                    Terms.Common.Domain.Airport airport = MatchAirport(ltxFrom.City.Trim(), airportList);
                    if (airport != null)
                        deptCondition.Departure = airport;
                    else
                        sc.IsRealFromCity = IsRealCity = false;
                }

            }
            else
            {
                deptCondition.Departure = AirService.CommAirportDao.FindByAirport(ltxFrom.City.Trim());
                if (deptCondition.Departure == null)
                {
                    deptCondition.Departure = new Terms.Common.Domain.Airport();
                    deptCondition.Departure.Code = ltxFrom.City.Trim();
                }
            }

            sc.ToCityName = ltxTo.City.Trim();
            if (ltxTo.City.Trim().Length > 3)
            {
                IList destinationAirPorts = _CommonService.FindAirportByCityName(ltxTo.City.Trim());

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
                    Terms.Common.Domain.Airport airport = MatchAirport(ltxTo.City.Trim(), airportList);
                    if (airport != null)
                        deptCondition.Destination = airport;
                    else
                        sc.IsRealToCity = IsRealCity = false;
                }

            }
            else
            {
                deptCondition.Destination = AirService.CommAirportDao.FindByAirport(ltxTo.City.Trim());
                if (deptCondition.Destination == null)
                {
                    deptCondition.Destination = new Terms.Common.Domain.Airport();
                    deptCondition.Destination.Code = ltxTo.City.Trim();
                }
            }


            AirTripCondition rtnCondition = new AirTripCondition();
            rtnCondition.Cabin = cabin;
            rtnCondition.DepartureDate = GlobalUtility.GetDateTime(rtnCalendar.CDate.Trim());
            if (airSearchCondition.FlightType.ToLower().Equals("oneway"))
            {
                rtnCondition.Departure = deptCondition.Destination;
                rtnCondition.Destination = deptCondition.Departure;
                rtnCondition.DepartureDate = DateTime.MaxValue;
            }
            else if (airSearchCondition.FlightType.ToLower().Equals("roundtrip"))
            {
                rtnCondition.Departure = deptCondition.Destination;
                rtnCondition.Destination = deptCondition.Departure;
                rtnCondition.DepartureDate = GlobalUtility.GetDateTime(rtnCalendar.CDate.Trim());
            }
            else if (airSearchCondition.FlightType.ToLower().Equals("openjaw"))
            {
                rtnCondition.DepartureDate = GlobalUtility.GetDateTime(rtnCalendar.CDate.Trim());
                sc.ReturnFromCityName = ltxRtnFrom.City.Trim();
                if (ltxRtnFrom.City.Trim().Length > 3)
                {
                    IList returnFromAirPorts = _CommonService.FindAirportByCityName(ltxRtnFrom.City.Trim());

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
                        Terms.Common.Domain.Airport airport = MatchAirport(ltxTo.City.Trim(), airportList);
                        airport = MatchAirport(ltxRtnFrom.City.Trim(), airportList);
                        if (airport != null)
                            rtnCondition.Departure = airport;
                        else
                            sc.IsRealReturnFromCity = IsRealCity = false;
                    }
                }
                else
                {
                    rtnCondition.Departure = AirService.CommAirportDao.FindByAirport(ltxRtnFrom.City.Trim());
                    if (rtnCondition.Departure == null)
                    {
                        rtnCondition.Departure = new Terms.Common.Domain.Airport();
                        rtnCondition.Departure.Code = ltxRtnFrom.City.Trim();
                    }
                }

                sc.ReturnToCityName = ltxRtnTo.City.Trim();
                if (ltxRtnTo.City.Trim().Length > 3)
                {
                    IList returnToAirPorts = _CommonService.FindAirportByCityName(ltxRtnTo.City.Trim());

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
                        Terms.Common.Domain.Airport airport = MatchAirport(ltxTo.City.Trim(), airportList);
                        airport = MatchAirport(ltxRtnTo.City.Trim(), airportList);
                        if (airport != null)
                            rtnCondition.Destination = airport;
                        else
                            sc.IsRealReturnToCity = IsRealCity = false;
                    }

                }
                else
                {
                    rtnCondition.Destination = AirService.CommAirportDao.FindByAirport(ltxRtnTo.City.Trim());
                    if (rtnCondition.Destination == null)
                    {
                        rtnCondition.Destination = new Terms.Common.Domain.Airport();
                        rtnCondition.Destination.Code = ltxRtnTo.City.Trim();
                    }

                }
            }

            airSearchCondition.AddTripCondition(deptCondition);
            airSearchCondition.AddTripCondition(rtnCondition);

            airSearchCondition.Airlines = ((AirSearchCondition)Transaction.CurrentSearchConditions).Airlines;


            string logAirline = airSearchCondition.Airlines == null ? "All" : string.Join(",", airSearchCondition.Airlines);
            log.Info(Session["LOG_RANDOM"].ToString() + " >====================AirLine:" + logAirline + "===========================");
            log.Info(Session["LOG_RANDOM"].ToString() + " >SearchClick Begin Start time : " + System.DateTime.Now);

            Utility.IsTourMain = false;//设置是否是Tour标志

            sc.CurrentItinerary.SearchInfo = airSearchCondition;//(AirSearchCondition)Transaction.CurrentSearchConditions;
            Session["CurrentSession"] = sc;
            if (ForbiddenAirportControl1.HasForbiddenAirport(sc))
            {
                string[] arrayCtrlID = new string[2];
                arrayCtrlID[0] = ddlAdult.ClientID;
                arrayCtrlID[1] = ddlChild.ClientID;

                ForbiddenAirportControl1.ShowMsgBox(arrayCtrlID, upSearch);
            }
            else
            {
                this.Transaction.IntKey = airSearchCondition.GetHashCode();
                Transaction.CurrentSearchConditions = airSearchCondition;
                this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

                if (!IsRealCity)
                {
                    if (IsDataError)
                    {
                        Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?DateErrorMsg=" + Resources.HintInfo.AirDateError);
                    }
                }
                else
                {
                    if (IsSelectAirport)
                    {
                        if (IsDataError)
                        {
                            Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx?DateErrorMsg=" + Resources.HintInfo.AirDateError);
                        }
                    }
                    else
                    {
                        if (Utility.IsSubAgent)
                            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchAir, this);
                        else
                            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchAir, this);

                        log.Info(Session["LOG_RANDOM"].ToString() + " >Redirect Searching.aspx Begin Start time : " + System.DateTime.Now + " By ");
                        if (IsDataError)
                        {
                            Response.Redirect("~/Page/Promos/PromosSearching.aspx" + "?ConditionID=" + this.Transaction.IntKey.ToString());
                        }
                        else
                        {
                            Response.Redirect("~/Page/Promos/PromosSearching.aspx" + "?ConditionID=" + this.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                        }
                    }
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Serarch", "<script>alert('Invaluable search condition.');</script>");
            return;
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

    /// <summary>
    /// 验证输入框是否合法
    /// </summary>
    private bool CheckSearch()
    {
        if (ltxFrom.City.Trim() == ""
            || ltxTo.City.Trim() == ""
            || depCalendar.CDate.Trim() == "")
        {
            return false;
        }

        if (rdbOneway.Checked == false)
        {
            if (rdbOpenjaw.Checked == true)
            {
                if (ltxRtnFrom.City.Trim() == ""
                    || ltxRtnTo.City.Trim() == "")
                {
                    return false;
                }
            }
            else
            {

                ((TextBox)this.ltxRtnFrom.FindControl("txtCity")).Text = this.ltxTo.City;
                ((TextBox)this.ltxRtnTo.FindControl("txtCity")).Text = this.ltxFrom.City;
            }

            if (!rtnCalendar.CDate.Equals(string.Empty)
                && (Convert.ToDateTime(rtnCalendar.CDate) <= Convert.ToDateTime(depCalendar.CDate)))
            {
                return false;
            }
        }

        if (ddlAdult.Text == "0"
            && ddlChild.Text == "0"
            && ddlInfant.Text == "0")
        {
            return false;
        }

        return true;
    }

    protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshAmount();
        ShowAmounts();
    }
}
