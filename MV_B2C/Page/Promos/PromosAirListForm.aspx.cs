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


using Terms.Material.Service;

using Terms.Global.Utility;
using Terms.Base.Utility;


using Terms.Sales.Domain;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Core.Profiles;
using TERMS.Business.Centers.ProductCenter.Profiles;
using Spring.Aspects.AirContact;
using TERMS.Core.Product;
using Terms.Product.Utility;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;


public partial class PromosAirListForm : AirBook.Base.BookingPage
{
    //private bool rePageNumber = false;
    private bool colorAdded = false;
    private bool isClickAvailable = true;
    private int lowestSeletctFareItemIndex;
    private bool notRebind = false;
    private bool filtered = false;
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

    public Itinerary Itinerary
    {
        get
        {
            return CurrentSession.CurrentItinerary;
        }
    }

    protected List<Component> SelectContactFlightList
    {
        get
        {
            return (List<Component>)Session["SelectContactFlightList"];
        }
        set
        {
            Session.Add("SelectContactFlightList", value);
        }
    }

    protected List<Component> TotalSelectContactFlightList
    {
        get
        {
            return (List<Component>)Session["TotalSelectContactFlightList"];
        }
        set
        {
            Session.Add("TotalSelectContactFlightList", value);
        }
    }

    protected List<Component> AvailableFlightList
    {
        get
        {
            return (List<Component>)Session["AvailableFlightList"];
        }
        set
        {
            Session.Add("AvailableFlightList", value);
        }
    }

    protected List<Component> TotalAvailableFlightList
    {
        get
        {
            return (List<Component>)Session["TotalAvailableFlightList"];
        }
        set
        {
            Session.Add("TotalAvailableFlightList", value);
        }
    }

    protected List<AirMatrixFlightMeta> AirMatrixList
    {
        get
        {
            return (List<AirMatrixFlightMeta>)Session["AirMatrixList"];
        }

        set
        {
            Session.Add("AirMatrixList", value);
        }
    }

    protected List<AirMatrixFlightMeta> AllAirMatrixList
    {
        get
        {
            return (List<AirMatrixFlightMeta>)Session["AllAirMatrixList"];
        }
        set
        {
            Session.Add("AllAirMatrixList", value);
        }
    }

    protected AirMerchandise FlightMerchandise
    {
        get
        {
            if (SessionExpired)
            {
                DoSessionExpiredProcess();

                return null;
            }

            return (AirMerchandise)this.OnSearch();
        }
    }

    protected AirMaterial SelectAirMaterial
    {

        get
        {
            return (AirMaterial)HttpContext.Current.Session["SelectAirMaterial"];
        }
        set
        {
            HttpContext.Current.Session["SelectAirMaterial"] = value;
        }
    }

    protected string TabFlag
    {

        get
        {
            if (HttpContext.Current.Session["Step2_TabFlag"] == null || (string)HttpContext.Current.Session["Step2_TabFlag"] == string.Empty)
            {
                return "0";
            }

            return (string)HttpContext.Current.Session["Step2_TabFlag"];
        }
        set
        {
            HttpContext.Current.Session["Step2_TabFlag"] = value;
        }
    }

    private List<Component> TotalFlightList
    {
        get
        {
            return (List<Component>)Session["FlightDetailList"];
        }
        set
        {
            Session.Add("FlightDetailList", value);
        }
    }

    private int MAX_MATRIX_COUNT_SHORT
    {
        get
        {
            if (ConfigurationSettings.AppSettings.Get("MAX_MATRIX_COUNT_SHORT") != null)
            {
                return int.Parse(ConfigurationSettings.AppSettings.Get("MAX_MATRIX_COUNT_SHORT"));
            }
            else
            {
                return 7;
            }
        }
    }

    public PromosAirListForm()
    {
        this.InitializeControls += new EventHandler(PromosAirListForm_InitializeControls);
    }

    void PromosAirListForm_InitializeControls(object sender, EventArgs e)
    {
        this.Form.DefaultButton = "ctl00$btn_Search";
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        this.OrderId.Value = Request.Params["ConditionID"];
        SetEvent();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        colorAdded = false;
        lowestSeletctFareItemIndex = 0;

        DateTime dtTime = System.DateTime.Now;
        log.Info(Session["LOG_RANDOM"] == null ? "" : Session["LOG_RANDOM"].ToString() + " >Load Step2.aspx Begin Start time : " + dtTime);
        Master.StepNumber = 2;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = true;
        if (!Transaction.IsLogin)
        {
            pnlContactMsg.Visible = false;
            pnlSelectMsg.Visible = false;

        }
        if (SessionExpired)
        {
            Err(Resources.HintInfo.TheResearch, "", "Step2.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {

                SetTabFlag();

                if (!notRebind)
                {
                    if (Request != null
                        && Request.UrlReferrer != null
                        && !(Request.UrlReferrer.AbsoluteUri.Contains("Step3_confirm.aspx")))
                    {
                        CreateFlightDetailList();

                        CreateAirMatrixList();

                        //如果没有Flight 提示
                        if (AirMatrixList == null || AirMatrixList.Count == 0)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Serarch", "<script>alert('We were unable to find available flights on this search condition. Please research.');</script>");
                        }

                        //}
                    }
                    else
                    {
                        if (IsFiltered())
                        {
                            DisplayBackToAllResultPanel();
                        }
                    }

                    Initial(true);

                }

                else
                {
                    SetAvailableDataSource(0);
                    SetSelectContactDataSource(0);
                }

                BindAirMatrix();

                BindItinerary();
            }
            else
            {
                SetAvailableDataSource(PageNumber1.CurrentPageIndex);
                SetSelectContactDataSource(PageNumber2.CurrentPageIndex);

                SetAirMatrixDataSource();
            }

            HiddenShowAllAirlinesIfNoMore();


        }

        log.Info(Session["LOG_RANDOM"] == null ? "" : Session["LOG_RANDOM"].ToString() + " >Load Step2.aspx End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtTime)).ToString());
    }

    private void HiddenShowAllAirlinesIfNoMore()
    {
        if (AllAirMatrixList == null || (AirMatrixList.Count == AllAirMatrixList.Count && AllAirMatrixList.Count <= MAX_MATRIX_COUNT_SHORT))
        {
            lbShowAllAirlines.Visible = false;
            lbHideMoreAirlines.Visible = false;
        }
        else
        {
            if (AirMatrixList == null || AirMatrixList.Count < AllAirMatrixList.Count)
            {
                lbShowAllAirlines.Visible = true;
                lbHideMoreAirlines.Visible = false;
            }
        }

        if (AirMatrixList != null && AirMatrixList.Count > MAX_MATRIX_COUNT_SHORT)
        {
            lbShowAllAirlines.Visible = false;
            lbHideMoreAirlines.Visible = true;
        }

        upShowAllAirline.Update();
    }

    private void SetTabFlag()
    {
        if (Request.UrlReferrer != null && Request.UrlReferrer.AbsoluteUri.Contains("Step3"))
        {
            hfTabFlag.Value = TabFlag;
        }
    }

    private void BindItinerary()
    {
        lblDepartureCity.Text = Itinerary.SearchInfo.AirTripCondition[0].Departure.City.Name;
        lblDepartureCityCopy.Text = Itinerary.SearchInfo.AirTripCondition[0].Departure.City.Name;
        lblArrivalCity.Text = Itinerary.SearchInfo.AirTripCondition[0].Destination.City.Name;
        lblArrivalCityCopy.Text = Itinerary.SearchInfo.AirTripCondition[0].Destination.City.Name;

        if (Itinerary.SearchInfo.FlightType == "openjaw")
        {
            lblArrivalCity.Text = Itinerary.SearchInfo.AirTripCondition[0].Destination.City.Name;
            lblArrivalCityCopy.Text = Itinerary.SearchInfo.AirTripCondition[0].Destination.City.Name;
            if (Itinerary.SearchInfo.AirTripCondition[0].Destination.City.Name != Itinerary.SearchInfo.AirTripCondition[1].Departure.City.Name)
            {
                lblArrivalCity.Text += "-" + Itinerary.SearchInfo.AirTripCondition[1].Departure.City.Name;
                lblArrivalCityCopy.Text += "-" + Itinerary.SearchInfo.AirTripCondition[1].Departure.City.Name;
            }
            lblArrivalCity.Text += "-" + Itinerary.SearchInfo.AirTripCondition[1].Destination.City.Name;
            lblArrivalCityCopy.Text += "-" + Itinerary.SearchInfo.AirTripCondition[1].Destination.City.Name;
        }

        lblDepartureDate.Text = Itinerary.SearchInfo.AirTripCondition[0].DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        lblDepartureDateCopy.Text = Itinerary.SearchInfo.AirTripCondition[0].DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        if (Itinerary.SearchInfo.FlightType == "oneway")
        {
            lblReturnDateMsg.Visible = false;
            lblReturnDateMsgCopy.Visible = false;
            lblReturnDate.Visible = false;
            lblReturnDateCopy.Visible = false;
        }
        else
        {
            lblReturnDate.Text = "" + Itinerary.SearchInfo.AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            lblReturnDateCopy.Text = "" + Itinerary.SearchInfo.AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }

    }

    private void DoSessionExpiredProcess()
    {
        Err(Resources.HintInfo.TheResearch, "", "Step3_bulk.aspx");
    }

    private bool IsSearchConditionChanged()
    {
        return true;
    }

    private void CreateAirMatrixList()
    {
        AllAirMatrixList = new AirLineMatricsManager().EditFlightsToAirMatrixStyle(TotalAvailableFlightList, GetTotalSelectFlightList(TotalSelectContactFlightList));

        AirMatrixList = new AirLineMatricsManager().GetShortedMatrixList(AllAirMatrixList);
    }

    private List<Component> GetTotalSelectFlightList(List<Component> totalSelectContactFlightList)
    {
        List<Component> totalSelectFlightList = new List<Component>();

        AirMaterial currentFlight;

        for (int flightIndex = 0; flightIndex < totalSelectContactFlightList.Count; flightIndex++)
        {
            currentFlight = (AirMaterial)totalSelectContactFlightList[flightIndex];

            totalSelectFlightList.Add(currentFlight);
        }

        return totalSelectFlightList;
    }

    private void SetAirMatrixDataSource()
    {
        dlAirlineMatrics.DataSource = InitAirMatrixPageNumber(0, AirMatrixList);
        dlAirlineMatricsCopy.DataSource = InitAirMatrixPageNumber(0, AllAirMatrixList);
    }

    private void BindAirMatrix()
    {
        dlAirlineMatrics.DataSource = InitAirMatrixPageNumber(0, AirMatrixList);

        dlAirlineMatrics.DataBind();

        dlAirlineMatricsCopy.DataSource = InitAirMatrixPageNumber(0, AllAirMatrixList);

        dlAirlineMatricsCopy.DataBind();
    }

    /// <summary>
    /// Init the Page number
    /// </summary>
    /// <param name="index"></param>
    private PagedDataSource InitAirMatrixPageNumber(int index, List<AirMatrixFlightMeta> dataSoure)
    {
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = dataSoure;

        pds.AllowPaging = false;

        return pds;
    }

    private List<Component> GteReBindContactAgentList(List<Component> currentitems)
    {
        List<Component> newItems = new List<Component>();

        List<Component> copiedCurrentitems = new List<Component>();

        if ( currentitems == null)
        {
            return newItems;
        }

        for (int currentItemIndex = 0; currentItemIndex < currentitems.Count; currentItemIndex++)
        {
            copiedCurrentitems.Add(currentitems[currentItemIndex]);
        }

        if (copiedCurrentitems != null)
        {

            //遍历Fare列表
            for (int index = 0; index < copiedCurrentitems.Count; index++)
            {
                //如果不是ContactAgent，加入新列表
                if (!IsContactAgentItem((AirMerchandise)copiedCurrentitems[index]))
                {
                    newItems.Add(copiedCurrentitems[index]);
                }

                    //如果是ContactAgent，把余下的相同Airlines的Items删掉
                else
                {
                    newItems.Add(copiedCurrentitems[index]);

                    for (int leftIndex = index + 1; leftIndex < copiedCurrentitems.Count; leftIndex++)
                    {
                        //如果是ContactAgent
                        if (IsContactAgentItem((AirMerchandise)copiedCurrentitems[leftIndex]))
                        {
                            //如果Airlines同当前Item的相同
                            if (IsAirlinesTheSame((AirMerchandise)copiedCurrentitems[index], (AirMerchandise)copiedCurrentitems[leftIndex]))
                            {
                                copiedCurrentitems.Remove(copiedCurrentitems[leftIndex]);
                                leftIndex--;
                            }
                        }
                    }
                }
            }
        }

        return newItems;


    }

    private bool IsContactAgentItem(AirMaterial item)
    {
        if (item.AirTrip.SubTrips.Count > 0 && item.AirTrip.SubTrips[0].Flights.Count > 0)
        {
            return false;
        }

        return ((bool)item.Profile.GetParam("SHOULD_CALL"));
    }

    private bool IsContactAgentItem(AirMerchandise item)
    {
        if (item.Items != null && item.Items.Count > 0)
        {
            return false;
        }

        return ((bool)item.Profile.GetParam("SHOULD_CALL"));
    }

    private bool IsAirlinesTheSame(AirMerchandise leftItem, AirMerchandise curretnItem)
    {
        return ((TERMS.Business.Centers.ProductCenter.Profiles.AirProfile)leftItem.Profile).Airlines[0].Code
            == ((TERMS.Business.Centers.ProductCenter.Profiles.AirProfile)curretnItem.Profile).Airlines[0].Code;
    }

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void InitializeComponent()
    {
        this.PreRender +=new EventHandler(PromosAirListForm_PreRender);
    }

    void PromosAirListForm_PreRender(object sender, EventArgs e)
    {
        if (this.flagSearch.Value != null
            && this.flagSearch.Value.ToString().Trim().Length > 0)
        {

            string airs = this.flagSearch.Value;

            string name = this.txtName.Text.Trim();

            string phone = this.txtPhone.Text.Trim();

            string email = this.txtEmail.Text.Trim();


            string boby = @"<table width='700' border='0' align='center' cellpadding='0' cellspacing='0'><tr><td align='center'>"
                + @"<table width='100%' border='0' align='center' cellpadding='3' cellspacing='0' class='T_table'><tr><td align='right' valign='top'>"
                + @"<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td align='left'>&#24744;&#22909;,<br><br>"
                + @"您的優惠機票訊息如下，客服人員將會與您聯繫。<br /><br /><table width='100%' border='0' cellpadding='0' cellspacing='2'>"
                + @"<tbody><tr><td align='left' width='12%'><font color='#666'>姓名:</font>&nbsp;&nbsp;&nbsp;</td><td align='left'>" + name + "</td></tr>"
                + @"<tr><td align='left'><font color='#666'>聯絡電話:</font>&nbsp;&nbsp;&nbsp;</td><td align='left'>" + phone + "</td></tr><tr><td align='left'>"
                + @"<font color='#666'>電郵信箱:</font>&nbsp;&nbsp;&nbsp;</td><td align='left'>" + email + "</td></tr></tbody></table><br />"
                + airs
                + @"<br /></td></tr></table><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='10'></td></tr></table>"
                + @"<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td><table width='100%' border='0' cellspacing='1' cellpadding='8' class='T_step02'>"
                + @"<tr class='R_stepw'><td align='left'>&#8226; &nbsp;明星假期 Majestic Vacations<br>&#8226; &nbsp;免費旅遊諮詢: 877-287-0869<br>"
                + @" &#8226; &nbsp;線上旅遊服務: <a href='http://www.majestic-vacations.com/' class='d07'>www.majestic-vacations.com</a></td></tr></table></td>"
                + @"</tr></table></td></tr></table></td></tr></table>";

            String subject = "Promos";
            String senderEmail = "sales@majestic-vacations.com";

            String reciever = email;
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                message.To.Add(reciever);
               
                message.From = new System.Net.Mail.MailAddress(senderEmail);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = boby ;//+ getTerms();;

                try
                {
                    using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\Promos.html"))
                    {
                        sw.Write(boby);
                    }
                }
                catch
                {
                }

                Terms.Member.Utility.MemberUtility.SendEmail(message, "Tour");
            }
            catch
            {

            }


            Response.Redirect("~/page/Promos/PromosSuccForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {

            DateTime dtTime = System.DateTime.Now;
            log.Info(Session["LOG_RANDOM"] == null ? "" : Session["LOG_RANDOM"].ToString() + " >Bind Begin Start time : " + dtTime);
            if (!notRebind)
            {
                BindSelectContact(PageNumber2.CurrentPageIndex);
                BindAvailable(PageNumber1.CurrentPageIndex);
            }

            log.Info(Session["LOG_RANDOM"] == null ? "" : Session["LOG_RANDOM"].ToString() + " >Bind End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtTime)).ToString());

        }
    }

    void Step2_InitComplete(object sender, EventArgs e)
    {
    }

    void Step2_DataBound(object sender, EventArgs e)
    {
        //AjaxControlToolkit.ToolkitScriptManager.RegisterStartupScript(upAvailable, upAvailable.GetType(), "alt", "alert(document.getElementById('testClick'));if(this.location.href.indexOf('#') == -1){this.location.href+='#divAvailableFlight';} else(this.location.href= this.location.href.substring(0,this.location.href.indexOf('#')) + '#divAvailableFlight');", true);
    }

    private int FIRST_PAGE_LEN
    {
        get
        {
            if (ConfigurationSettings.AppSettings.Get("PAGESIZE_FLIGHT") != null)
            {
                return int.Parse(ConfigurationSettings.AppSettings.Get("PAGESIZE_FLIGHT"));
            }
            else
            {
                return 10;
            }
        }
    }

    private const int MIN_BULK_LEN = 3;

    #region User define event

    /// <summary>
    /// Init page
    /// </summary>
    private void Initial(bool isMore)
    {
        bool bclException = false;
        string strMessage = string.Empty;
        try
        {
            ItineraryInfo.Itinerary = CurrentSession.CurrentItinerary;
            ReorganizeReulst();
            InitAvailablePageNumber(GetCurrentPageNumber(), AvailableFlightList);
            InitSelectContactPageNumber(0, SelectContactFlightList);
        }
        catch (Exception ex)
        {
            log.Error(ex.Message, ex);
            bclException = true;
            strMessage = ex.Message;
        }

        if (bclException)
            Err(strMessage, "Unknow Error", "NewStep2.aspx");
    }

    ///// <summary>
    ///// Init the Page number
    ///// </summary>
    ///// <param name="index"></param>
    //private PagedDataSource InitPageNumber(int index)
    //{
    //    //PagedDataSource pds = new PagedDataSource();

    //    ////pds.DataSource = GteReBindContactAgentList(componentGroup.Items);
    //    //pds.DataSource = dataSoure;
    //    ////}
    //    ////else
    //    ////{
    //    ////    pds.DataSource = FlightDetailList;
    //    ////}

    //    ////pds.PageSize            = FIRST_PAGE_LEN;//PageNumber1.PageSize;
    //    //pds.PageSize = FIRST_PAGE_LEN;//PageNumber1.PageSize;
    //    //pds.AllowPaging = true;
    //    //pds.CurrentPageIndex = index >= 0 ? index : 0;

    //    //PageNumber1.PageAmount = pds.PageCount;
    //    //PageNumber1.CurrentPageIndex = index;

    //    //if (pds.DataSourceCount < FIRST_PAGE_LEN + 1)
    //    //    PageNumber1.Visible = false;
    //    //else
    //    //    PageNumber1.Visible = true;

    //    //return pds;
    //}


    /// <summary>
    /// Init the Page number
    /// </summary>
    /// <param name="index"></param>
    private PagedDataSource InitAvailablePageNumber(int index, List<Component> dataSoure)
    {

        PagedDataSource pds = new PagedDataSource();

        //pds.DataSource = GteReBindContactAgentList(componentGroup.Items);

        pds.DataSource = dataSoure;
        //}
        //else
        //{
        //    pds.DataSource = FlightDetailList;
        //}

        //pds.PageSize            = FIRST_PAGE_LEN;//PageNumber1.PageSize;
        pds.PageSize = FIRST_PAGE_LEN;//PageNumber1.PageSize;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = index >= 0 ? index : 0;

        //PageNumber1.Dispose();

        PageNumber1.PageAmount = pds.PageCount;
        PageNumber1.CurrentPageIndex = index;
        PageNumber1.PageSize = FIRST_PAGE_LEN;

        if (pds.DataSourceCount < FIRST_PAGE_LEN + 1)
            PageNumber1.Visible = false;
        else
        {
            PageNumber1.Visible = true;
            PageNumber1.Update();
        }

        //PageNumber1.DataBind();
        //PageNumber1.DrawingNum(index);
        //PageNumber1.Refresh();

        //PageNumber1.RefreshDll();
        

        return GetCurrenPageSource(index, dataSoure);
    }

    private PagedDataSource GetCurrenPageSource(int index, List<Component> dataSoure)
    {
        List<Component> currentPageSource;

        currentPageSource = new List<Component>();

        int firstIndex = index * FIRST_PAGE_LEN;

        for (int itemIndex = firstIndex; itemIndex < firstIndex + FIRST_PAGE_LEN; itemIndex++)
        {
            if (itemIndex >= dataSoure.Count)
            {
                break;
            }

            currentPageSource.Add(dataSoure[itemIndex]);
        }

        PagedDataSource currentPDS = new PagedDataSource();
        currentPDS.DataSource = currentPageSource;
        currentPDS.PageSize = FIRST_PAGE_LEN;//PageNumber1.PageSize;
        currentPDS.AllowPaging = true;
        currentPDS.CurrentPageIndex = 0;

        return currentPDS;
    }
    
    /// <summary>
    /// Init the Page number
    /// </summary>
    /// <param name="index"></param>
    private PagedDataSource InitSelectContactPageNumber(int index, List<Component> dataSoure)
    {
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = dataSoure;

        pds.PageSize = FIRST_PAGE_LEN;//PageNumber1.PageSize;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = index >= 0 ? index : 0;

        PageNumber2.PageAmount = pds.PageCount;
        PageNumber2.CurrentPageIndex = index;
        PageNumber2.PageSize = FIRST_PAGE_LEN;

        if (pds.DataSourceCount < FIRST_PAGE_LEN + 1)
        {
            PageNumber2.Visible = false;
        }
        else
        {
            PageNumber2.Visible = true;
            PageNumber2.Update();
        }

        //PageNumber2.RefreshDll();
        

        return GetCurrenPageSource(index, dataSoure);
    }

    private const string Key_FlightMerchandisIndex = "Key_FlightMerchandisIndex";
    
    private void CreateFlightDetailList()
    {
        AirMerchandise componentGroup = FlightMerchandise;

        List<Component> flightList = GteReBindContactAgentList(componentGroup.Items);

        SubAirTrip subAirTrip = new SubAirTrip();

        List<Component> flightDetailList = new List<Component>();

        List<Component> selectContactFlightList = new List<Component>();
        List<Component> availableFlightList = new List<Component>();

        //遍历flightList,把所有的航班信息添加成一个list
        for (int flightIndex = 0; flightIndex < flightList.Count; flightIndex++)
        {
            AirMerchandise flight = (AirMerchandise)flightList[flightIndex];

            //for(int flightItemindex=0; index < flight.Items.Count; index++)
            //{
            //    AirMaterial tempairMaterial = (AirMaterial)flight.Items[flightItemindex];
            //    AirMaterial airMaterial = (AirMaterial)flight.Items[flightItemindex];

            //    for(int subairtripIndex = 0; subairtripIndex<(airMaterial.AirTrip.SubTrips.Count; subairtripIndex++)
            //    {
            //        SubAirTrip subAirTrip = ((AirMaterial)flight.Items[flightItemindex]).AirTrip.SubTrips[subairtripIndex];
            //        tempairMaterial = airMaterial.
            //    }
            //}

            if (flight.Items != null)
            {

                for (int mIndex = 0; mIndex < flight.Items.Count; mIndex++)
                {
                    AirMaterial currentFlight = ((AirMaterial)flight.Items[mIndex]);

                    currentFlight.Profile = flight.Profile;
                    currentFlight.Profile.SetParam(Key_FlightMerchandisIndex, flightIndex);

                    if (IsFlightAvailable(currentFlight))
                    {
                        availableFlightList.Add(currentFlight);
                    }
                    else
                    {
                        selectContactFlightList.Add(currentFlight);
                    }

                    flightDetailList.Add(currentFlight);
                }

                //flightDetailList.AddRange(flight.Items);

                //availableFlightList.AddRange(flight.Items);
            }

            else
            {
                AirMaterial airMaterial = new AirMaterial((AirProfile)flight.Profile);
                CopyMarkup(flight, airMaterial);

                airMaterial.Profile.SetParam(Key_FlightMerchandisIndex, flightIndex);

                //flight.Add(airMaterial);
                flightDetailList.Add(airMaterial);

                selectContactFlightList.Add(airMaterial);
            }
        }

        //作成AvailableFlightList
        availableFlightList = new AirLineMatricsManager().GetSortedByPriceFlightList(availableFlightList);
        TotalAvailableFlightList = availableFlightList;
        AvailableFlightList = availableFlightList;


        //作成SelectContactFlightList
        TotalSelectContactFlightList = selectContactFlightList;
        SelectContactFlightList = selectContactFlightList;

        TotalFlightList = flightDetailList;
    }

    private bool IsFlightAvailable(AirMaterial currentFlight)
    {
        return GetFlightInfoListCount(currentFlight) > 0 && currentFlight.AdultTax != 0;
    }

    private int GetFlightInfoListCount(AirMaterial currentFlight)
    {
        int flightInfoListCount = 0;
        for (int subTripIndex = 0; subTripIndex < currentFlight.AirTrip.SubTrips.Count; subTripIndex++)
        {
            flightInfoListCount += currentFlight.AirTrip.SubTrips[subTripIndex].Flights.Count;
        }

        return flightInfoListCount;
    }

    private List<Component> GetFlightDetailList(List<Component> flightList)
    {
        SubAirTrip subAirTrip = new SubAirTrip();

        List<Component> flightDetailList = new List<Component>();

        List<Component> selectContactFlightList = new List<Component>();
        List<Component> availableFlightList = new List<Component>();

        //遍历flightList,把所有的航班信息添加成一个list
        for (int flightIndex = 0; flightIndex < flightList.Count; flightIndex++)
        {
            AirMerchandise flight = (AirMerchandise)flightList[flightIndex];

            //for(int flightItemindex=0; index < flight.Items.Count; index++)
            //{
            //    AirMaterial tempairMaterial = (AirMaterial)flight.Items[flightItemindex];
            //    AirMaterial airMaterial = (AirMaterial)flight.Items[flightItemindex];

            //    for(int subairtripIndex = 0; subairtripIndex<(airMaterial.AirTrip.SubTrips.Count; subairtripIndex++)
            //    {
            //        SubAirTrip subAirTrip = ((AirMaterial)flight.Items[flightItemindex]).AirTrip.SubTrips[subairtripIndex];
            //        tempairMaterial = airMaterial.
            //    }
            //}

            if (flight.Items != null)
            {
                for (int mIndex = 0; mIndex < flight.Items.Count; mIndex++)
                {
                    ((AirMaterial)flight.Items[mIndex]).Profile = flight.Profile;
                    ((AirMaterial)flight.Items[mIndex]).Profile.SetParam(Key_FlightMerchandisIndex, flightIndex);
                }

                flightDetailList.AddRange(flight.Items);

                availableFlightList.AddRange(flight.Items);
            }

            else
            {
                AirMaterial airMaterial = new AirMaterial((AirProfile)flight.Profile);
                CopyMarkup(flight, airMaterial);

                airMaterial.Profile.SetParam(Key_FlightMerchandisIndex, flightIndex);

                flight.Add(airMaterial);
                flightDetailList.AddRange(flight.Items);

                selectContactFlightList.AddRange(flight.Items);
            }
        }

        //作成AvailableFlightList
        AvailableFlightList = availableFlightList;

        //作成SelectContactFlightList
        SelectContactFlightList = selectContactFlightList;

        return flightDetailList;
    }

    private void SetAvailableDataSource(int index)
    {
        dlAvailableFlight.DataSource = InitAvailablePageNumber(index, AvailableFlightList);
    }

    private void SetSelectContactDataSource(int index)
    {
        dlSelectContact.DataSource = InitSelectContactPageNumber(index, SelectContactFlightList);
    }

    private void BindAvailable(int index)
    {
        dlAvailableFlight.DataSource = InitAvailablePageNumber(index, AvailableFlightList);
        dlAvailableFlight.DataBind();
    }

    private void BindSelectContact(int index)
    {

        if (SelectContactFlightList.Count == 0)
        {
            pnlSelectFare.Visible = false;
        }
        else
        {
            dlSelectContact.DataSource = InitSelectContactPageNumber(index, SelectContactFlightList);

            dlSelectContact.DataBind();
        }

    }

    private void BindAfterSelect(int index)
    {
        PagedDataSource pds = new PagedDataSource();


        //pds.DataSource = GteReBindContactAgentList(componentGroup.Items);
        //pds.DataSource = FlightDetailList;

        //AirMerchandise componentGroup = FlightMerchandise;

        //List<Component> flightList = GteReBindContactAgentList(componentGroup.Items);

        //CreateFlightDetailList();

        //CreateAirMatrixList();

        SelectContactFlightList = new AirLineMatricsManager().GetSortedByPriceFlightList(SelectContactFlightList);
        List<Component> flightDetailList = SelectContactFlightList;

        //FlightDetailList = flightDetailList;


        //pds.DataSource = GteReBindContactAgentList(componentGroup.Items);
        pds.DataSource = flightDetailList;

        //pds.PageSize            = FIRST_PAGE_LEN;//PageNumber1.PageSize;
        pds.PageSize = FIRST_PAGE_LEN;//PageNumber1.PageSize;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = index >= 0 ? index : 0;

        PageNumber2.PageAmount = pds.PageCount;
        PageNumber2.CurrentPageIndex = index;

        if (pds.DataSourceCount < FIRST_PAGE_LEN + 1)
        {
            PageNumber2.Visible = false;
            PageNumber2.RefreshDll();
        }
        else
        {
            PageNumber2.Visible = true;
            PageNumber2.RefreshDll();
            PageNumber2.Update();
        }


        PageNumber2.RefreshDll();
        dlSelectContact.DataSource = GetCurrenPageSource(index, flightDetailList);

        dlSelectContact.DataBind();

        notRebind = true;

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "alt", "this.location.href+='#divSelectFare';", true);
    }

    protected void dlAirlineMatrics_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
        {
            AirMatrixFlightMeta currentMatrix = null;
            string airlineCode = string.Empty;

            currentMatrix = (AirMatrixFlightMeta)e.Item.DataItem;
            airlineCode = currentMatrix.AirLine.Code;

            //AirLineImage
            System.Web.UI.WebControls.Image imgAirline = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgAirline");
            imgAirline.ImageUrl = GetImageUrl(airlineCode);

            //Set0Empty

            System.Web.UI.WebControls.Label lnbZeroBase = (System.Web.UI.WebControls.Label)e.Item.FindControl("lnbZeroBase");
            System.Web.UI.WebControls.Label lblZeroStopPrice = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblZeroStopPrice");
            if (currentMatrix.ZeroStopPrice.BaseFare == 0)
            {
                lnbZeroBase.Text = "&nbsp;";
                lnbZeroBase.Visible = false;
                lblZeroStopPrice.Text = "&nbsp;";
            }

            System.Web.UI.WebControls.Label lnbOneBase = (System.Web.UI.WebControls.Label)e.Item.FindControl("lnbOneBase");
            System.Web.UI.WebControls.Label lblSpaceOneStopPrice = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblSpaceOneStopPrice");
            if (currentMatrix.OneStopPrice.BaseFare == 0)
            {
                lnbOneBase.Text = "&nbsp;";
                lnbOneBase.Visible = false;
                lblSpaceOneStopPrice.Text = "&nbsp;";
            }

            System.Web.UI.WebControls.Label lnbTwoMoreBase = (System.Web.UI.WebControls.Label)e.Item.FindControl("lnbTwoMoreBase");
            System.Web.UI.WebControls.Label lblSpaceMoreThanTwoStopPrice = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblSpaceMoreThanTwoStopPrice");
            if (currentMatrix.MoreThanTwoStopPrice.BaseFare == 0)
            {
                lnbTwoMoreBase.Text = "&nbsp;";
                lnbTwoMoreBase.Visible = false;
                lblSpaceMoreThanTwoStopPrice.Text = "&nbsp;";
            }

            System.Web.UI.WebControls.Label lblLowFareSelect = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblLowFareSelect");
            System.Web.UI.WebControls.Label lblSpaceSelect = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblSpaceSelect");
            System.Web.UI.WebControls.Label lblLowFareSelectTooltip = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblLowFareSelectTooltip");
            System.Web.UI.WebControls.Label lnbSelect = (System.Web.UI.WebControls.Label)e.Item.FindControl("lnbSelect");
            if (currentMatrix.LowFareSelectPrice.BaseFare == 0)
            {
                lblLowFareSelect.Text = "&nbsp;";
                lblLowFareSelect.Visible = false;
                lblSpaceSelect.Text = "&nbsp;";
                lblLowFareSelectTooltip.Visible = false;
                lnbSelect.Visible = false;
            }

            //else
            //{
            //    lowestSeletctFareItemIndex = e.Item.ItemIndex;

            //    if (colorAdded == false)
            //    {
            //        lnbSelect.Style.Add("color", "Red");
            //        lnbSelect.Style.Add("font-weight","bold");
            //        colorAdded = true;

            //    }
            //}

            //在最后一条记录时，判断最小值，设置红色粗体样式。
            if (e.Item.ItemIndex == AirMatrixList.Count - 1)
            {
                //取得最小值的Item
                DataListItem lowestSelectFareItem = GetLowestSelectFareItem(e.Item);

                if (lowestSelectFareItem == null && ((AirMatrixFlightMeta)e.Item.DataItem).LowFareSelectPrice.BaseFare != 0)
                {
                    lowestSelectFareItem = e.Item;
                }
                //System.Web.UI.HtmlControls.HtmlAnchor lnbSelect;

                if (lowestSelectFareItem != null)
                {
                    //找到Select控件
                    lnbSelect = (System.Web.UI.WebControls.Label)lowestSelectFareItem.FindControl("lnbSelect");

                    if (lnbSelect.Visible != false)
                    {
                        //添加样式
                        lnbSelect.Style.Add("color", "Red");
                        lnbSelect.Style.Add("font-weight", "bold");
                    }
                }

            }
        }
    }

    private DataListItem GetLowestSelectFareItem(DataListItem lastdataListItem)
    {
        System.Web.UI.WebControls.Label currentLblLowFareSelect = null;
        System.Web.UI.WebControls.Label lowestLblLowFareSelect = null;
        IList airMatrixDataSource = null;

        DataListItem lowestSelectFareItem = null;
        DataListItem currentItem = null;
        //AirMatrixFlightMeta currentAirMatrix = null;
        //AirMatrixFlightMeta lowestAirMatrix = null;
        decimal currentFare = 0;
        decimal lowestFare = 0;
        //System.Web.UI.WebControls.Label lblLowFareSelect = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblLowFareSelect");

        lowestSelectFareItem = lastdataListItem;

        for (int itemIndex = 0; itemIndex < dlAirlineMatrics.Items.Count; itemIndex++)
        {
            currentItem = dlAirlineMatrics.Items[itemIndex];
            //currentAirMatrix = AirMatrixList[itemIndex];
            currentLblLowFareSelect = (System.Web.UI.WebControls.Label)currentItem.FindControl("lblLowFareSelect");

            if (lowestSelectFareItem == null)
            {
                lowestSelectFareItem = currentItem;
                //lowestAirMatrix = currentAirMatrix;
                lowestLblLowFareSelect = (System.Web.UI.WebControls.Label)lowestSelectFareItem.FindControl("lblLowFareSelect");
            }
            else
            {
                airMatrixDataSource = (IList)(((PagedDataSource)dlAirlineMatrics.DataSource).DataSource);

                if (((AirMatrixFlightMeta)(airMatrixDataSource)[currentItem.ItemIndex]).LowFareSelectPrice.BaseFare != 0)
                {
                    currentFare = ((AirMatrixFlightMeta)(airMatrixDataSource)[currentItem.ItemIndex]).LowFareSelectPrice.BaseFare;
                }
                if (((AirMatrixFlightMeta)(airMatrixDataSource)[lowestSelectFareItem.ItemIndex]).LowFareSelectPrice.BaseFare != 0)
                {
                    lowestFare = ((AirMatrixFlightMeta)(airMatrixDataSource)[lowestSelectFareItem.ItemIndex]).LowFareSelectPrice.BaseFare;
                }

                if (lowestFare == 0)
                {
                    lowestSelectFareItem = currentItem;
                }
                else
                {
                    if (currentFare > 0 && currentFare < lowestFare)
                    {
                        lowestSelectFareItem = currentItem;
                    }
                }
            }
        }

        return lowestSelectFareItem;
    }


    protected void dlAirlineMatrics_ItemCommand(object sender, DataListCommandEventArgs e)
    {

        AirMatrixFlightMeta currentMatrix = null;
        List<Component> matixFlightList = null;

        currentMatrix = (AirMatrixFlightMeta)((IList)((PagedDataSource)dlAirlineMatrics.DataSource).DataSource)[e.Item.ItemIndex];

        matixFlightList = currentMatrix.GetFlightList((MatrixStopType)Enum.Parse(typeof(MatrixStopType), e.CommandName));

        AvailableFlightList = matixFlightList;

        DoAfterFilter();
    }

    private void DisplayBackToAllResultPanel()
    {
        pnlBackToAllResults.Visible = true;
    }

    private string GetImageUrl(string airlineCode)
    {
        string imgUrl = string.Empty;
        string defaultUrl = string.Empty;

        defaultUrl = "~/images/airline/defult_air.jpg";

        if (System.IO.File.Exists(Request.PhysicalApplicationPath + @"images\airline\" + airlineCode + ".gif"))
        {
            imgUrl = "~/images/airline/" + airlineCode + ".gif";
        }
        else
        {
            imgUrl = defaultUrl;
        }

        return imgUrl;
    }

    /// <summary>
    /// 重新组织结果，保证前十条内有3条AVAILABLE
    /// </summary>
    private void ReorganizeReulst()
    {

        AirMerchandise result = FlightMerchandise;
        int len = result.Items.Count;
        ArrayList bulkIdx = new ArrayList();

        //找到前3条Bulk
        for (int i = 0; i < len; i++)
        {
            AirMerchandise tGoup = (AirMerchandise)result.Items[i];

            if (tGoup.Profile.GetParam("FARE_TYPE").ToString().Equals(Terms.Product.Utility.FlightFareType.SR.ToString()) || tGoup.Profile.GetParam("FARE_TYPE").ToString().Equals(Terms.Product.Utility.FlightFareType.PUB.ToString()))
            {
                bulkIdx.Add(i);
            }

            if (bulkIdx.Count == MIN_BULK_LEN)
            {
                //找到前三条
                break;
            }
        }

        //判断是否需要插入
        int bulkLen = bulkIdx.Count;
        for (int i = 0; i < bulkLen; i++)
        {
            int idx = (int)bulkIdx[i];
            //idx + len - i - 10 为需要上移数
            int step = idx + bulkLen - i - FIRST_PAGE_LEN;
            if (step > 0)
            {
                int newIdx = idx - step;
                //移动
                TERMS.Core.Product.Component obj = result.Items[idx];
                for (int j = idx; j > newIdx; j--)
                {
                    result.Items[j] = result.Items[j - 1];
                }
                result.Items[newIdx] = obj;
            }
        }
    }
    #endregion

    /// <summary>
    /// 隐藏飞机信息的标志，true代表隐藏，false代表不隐藏，默认false
    /// </summary>
    private bool HideFlightInfoFlag
    {
        get
        {
            if (ViewState["HideFlightInfoFlag"] == null)
                ViewState["HideFlightInfoFlag"] = false;

            return Convert.ToBoolean(ViewState["HideFlightInfoFlag"]);
        }
        set { ViewState["HideFlightInfoFlag"] = value; }
    }

    public FlightInfoHider flightInfohider = new FlightInfoHider();

    protected void dlAvailable_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        System.Web.UI.WebControls.Image image1 = (System.Web.UI.WebControls.Image)e.Item.FindControl("AirImgRtn1");
        image1.ImageUrl = "~/images/airline/defult_air.jpg";
        AirMaterial flight = (AirMaterial)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
        string airImgName = ((AirProfile)flight.Profile).Airlines[0].Code.Trim().ToString() + ".gif";
        if (System.IO.File.Exists(Request.PhysicalApplicationPath + @"images\airline\" + airImgName))
        {
            image1.ImageUrl = "~/images/airline/" + airImgName;
        }

        if (flight.Profile.GetParam("SHOW_WARN_MSG") != null)
        {
            System.Web.UI.WebControls.Label lbDispWarnMessage = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbDispWarnMessage");
            if (Convert.ToBoolean(flight.Profile.GetParam("SHOW_WARN_MSG")))
            {
                lbDispWarnMessage.Visible = true;
                lbDispWarnMessage.Text = Resources.HintInfo.BusinessClassWarnMessage;
            }
            else
            {
                //lbDispWarnMessage.Text = Resources.HintInfo.BusinessClassWarnMessage;
                lbDispWarnMessage.Visible = false;
            }


        }

        if (flight.AirTrip.HasOverNightConnection)
        {
            System.Web.UI.WebControls.Label lbDispOverNightMessage = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbDispOverNightMessage");

            lbDispOverNightMessage.Visible = true;
            lbDispOverNightMessage.Text = Resources.HintInfo.HasOverNightStay;
        }

        SetImageToolTip(image1, flight);

        if(Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
        {
            if (((Terms.Sales.Business.AirSearchCondition)Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Child) == 0)
            { 
                System.Web.UI.WebControls.Panel divChildFare = (Panel)e.Item.FindControl("divChildFare");
                //divChildFare.Visible = false;

                System.Web.UI.WebControls.Panel divChildFareDetail = (Panel)e.Item.FindControl("divChildFareDetail");
                divChildFareDetail.Visible = false;
            }
        }
        
        System.Web.UI.WebControls.Label lbDispMessage = (Label)e.Item.FindControl("lbDispMessage");
        if (flightInfohider.IsNeedToHide(flight))
        {
            image1.ImageUrl = "~/images/airline/defult_air.jpg";
            ((Label)e.Item.FindControl("lbl_Airline")).Text = flightInfohider.ReplaceFlightName(((AirProfile)flight.Profile).Airlines[0].Code.Trim().ToString(), flight.Profile.GetParam("FARE_TYPE").ToString());
            //显示提示信息，如果要隐藏
            lbDispMessage.Text = Resources.HintInfo.DISP_MESSAGE;
            lbDispMessage.Visible = true;
        }
        else
        {
            lbDispMessage.Visible = false;
        }

        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
        //{
        //    ImageButton btnAvail = (ImageButton)e.Item.FindControl("ImageButton1");

        //    btnAvail.ImageUrl = btnAvail.ImageUrl.ToLower().Replace("images/", "images/" + ImageCulturePath);
        //}


        //绑定DetailFlightList
        DataList dlFlights = (DataList)e.Item.FindControl("dlFlights");

        dlFlights.DataSource = GetAirLegList(flight);
        dlFlights.DataBind();

        //将相同的AirLine的相同的价格合起来。
        CollapseFlightOfSameAirlinePrice(e.Item);

        //显示Duration
        SetTotalDurationAndDistance(flight, e.Item);
    }

    private bool IsNeedCollapse(AirMaterial currentFlight, AirMaterial preFlight)
    {
        return IsAirlineEqual(currentFlight, preFlight) && IsPriceEqual(currentFlight, preFlight);
    }

    private bool IsPriceEqual(AirMaterial currentFlight, AirMaterial preFlight)
    {
        return currentFlight.AdultBaseFare + currentFlight.AdultMarkup + currentFlight.AdultTax
            == preFlight.AdultBaseFare + preFlight.AdultMarkup + preFlight.AdultTax;
    }

    private bool IsAirlineEqual(AirMaterial currentFlight, AirMaterial preFlight)
    {
        return new AirLineMatricsManager().CompareAirLine(preFlight, currentFlight) == 0;
    }

    private object GetAirLegList(AirMaterial flight)
    {
        IList<AirLeg> airLegList = new List<AirLeg>();

        foreach (SubAirTrip subAirTrip in flight.AirTrip.SubTrips)
        {
            foreach (AirLeg airLeg in subAirTrip.Flights)
            {
                airLegList.Add(airLeg);
            }
        }

        return airLegList;
    }


    private string GetDuration(AirMaterial flight)
    {
        string duration = string.Empty;
        TimeSpan flightTime = TimeSpan.Zero;
        TimeSpan connectionTime = TimeSpan.Zero;

        AirLineMatricsManager airManager = new AirLineMatricsManager();

        flightTime = airManager.GetFlightTime(flight);
        connectionTime = airManager.GetDuration(flight);

        return String.Format("{0} ({1}", airManager.FormatTimeSpan(flightTime), airManager.FormatTimeSpan(connectionTime));
    }

    private string GetDuration(AirLeg airLeg)
    {
        string duration;

        AirLineMatricsManager airManager = new AirLineMatricsManager();

        return airManager.FormatTimeSpan(airManager.GetDuration(airLeg));
    }

    private string GetFlightTime(AirLeg airLeg)
    {
        string duration;

        AirLineMatricsManager airManager = new AirLineMatricsManager();

        return airManager.FormatTimeSpan(airManager.GetFlightTime(airLeg));
    }

    private string GetDistance(AirMaterial flight)
    {
        int miles = 0;

        foreach (SubAirTrip subAirTrip in flight.AirTrip.SubTrips)
        {
            miles += subAirTrip.Miles;
        }

        if (miles == 0)
        {
            return string.Empty;
        }

        return String.Format("{0} miles ({1} km)", miles.ToString("#,###"), ConvertMilesToKilometers(miles).ToString("#,####"));
    }

    public int ConvertMilesToKilometers(int m)
    {
        return ((int)(m * 1.609344));
    }


    private int m_firstGroupIndex = 0;     //每一组的第一个索引
    private int m_lastGroupIndex = 0;  

    private void SetTotalDurationAndDistance(AirMaterial flight, DataListItem dataListItem)
    {
        System.Web.UI.WebControls.Label lblTotalDistance = (System.Web.UI.WebControls.Label)dataListItem.FindControl("lblTotalDistance");
        lblTotalDistance.Text = GetDistance(flight);

        System.Web.UI.WebControls.Label lblTotalDuration = (System.Web.UI.WebControls.Label)dataListItem.FindControl("lblTotalDuration");
        lblTotalDuration.Text = GetDuration(flight);

        System.Web.UI.WebControls.Label lblTotalDistanceMsg = (System.Web.UI.WebControls.Label)dataListItem.FindControl("lblTotalDistanceMsg");
        if (lblTotalDuration.Text.Trim() == string.Empty)
        {
            lblTotalDistanceMsg.Visible = false;
        }
    }

    private void CollapseFlightOfSameAirlinePrice(DataListItem currentItem)
    {
        AirMaterial preFlight = null;
        AirMaterial currentFlight = null;

        IList flightDataSource = (IList)(((PagedDataSource)dlAvailableFlight.DataSource).DataSource);

        //当为DataSource第一条记录时
        if (currentItem.ItemIndex == 0)
        {
            m_firstGroupIndex = currentItem.ItemIndex;

            //设置第一条样式
            //SetFirstGroupItemStyle(currentItem);
        }

        if (currentItem.ItemIndex > 0)
        {
            //取得当前flight和之前的Flight
            currentFlight = (AirMaterial)flightDataSource[currentItem.ItemIndex];
            preFlight = (AirMaterial)flightDataSource[currentItem.ItemIndex - 1];

            //循环,如果航空公司和价格都一样，需要隐藏折叠。反之，显示。
            if (IsNeedCollapse(currentFlight, preFlight))
            {
                //设置组内非第一条之样式
                SetGroupItemStyleAfterFirst(currentItem);

            }

                //重起一组
            else
            {
                m_lastGroupIndex = currentItem.ItemIndex - 1;

                //设置上一组最后一条样式及第一条样式
                SetGroupStyleAtGroupLastItem(currentItem);

                m_firstGroupIndex = currentItem.ItemIndex;

                //设置第一条样式
                //SetFirstGroupItemStyle(currentItem);
            }
        }

        //当为DataSource最后一条记录时，设置当前组样式
        if (currentItem.ItemIndex == flightDataSource.Count - 1)
        {
            m_lastGroupIndex = currentItem.ItemIndex;

            //设置上一组最后一条样式及第一条样式
            SetGroupStyleAtGroupLastItem(currentItem);
        }
    }

    private void SetGroupItemStyleAfterFirst(DataListItem currentItem)
    {
        //隐藏Show、Hide链接
        Label btnExpansion = GetExpansionControl(currentItem);
        Label btnShrink = GetShrinkControl(currentItem);
        Panel pnlWholeFlightItem = GetWholeFlightItemControl(currentItem);

        btnExpansion.Style["display"] = "none";
        btnShrink.Style["display"] = "block";

        pnlWholeFlightItem.Style["display"] = "none";
    }

    private void SetFirstGroupItemStyle(DataListItem firstGroupItem)
    {
        Label btnExpansion = GetExpansionControl(firstGroupItem);
        Label btnShrink = GetShrinkControl(firstGroupItem);
        int groupCount = m_lastGroupIndex - m_firstGroupIndex;

        // register the new airline client click event for + (first Row)
        btnExpansion.Attributes.Add("onclick",
                 "ShowHidePart(" + m_firstGroupIndex
            + "," + groupCount + ",this)");

        //// register the new airline client click event for - (first Row)
        //btnShrink.Attributes.Add("onclick",
        //    "HidePart(" + 0
        //    + "," + fareAyList.Count
        //    + ",'" + airlineName + "')");

        btnExpansion.Style["display"] = "block";
        btnShrink.Style["display"] = "none";

        btnExpansion.Text = String.Format(btnExpansion.Text, groupCount);
    }

    private void SetLastGroupItemStyle(DataListItem lastGroupItem)
    {
        Label btnExpansion = GetExpansionControl(lastGroupItem);
        Label btnShrink = GetShrinkControl(lastGroupItem);
        Panel pnlWholeFlightItem = GetWholeFlightItemControl(lastGroupItem);
        int groupCount = m_lastGroupIndex - m_firstGroupIndex;

        btnShrink.Attributes.Add("onclick",
                "HidePart(" + m_firstGroupIndex
                + "," + groupCount + ",this)");
        // register the new airline client click event for - (first Row)

        for (int itemIndex = m_lastGroupIndex - groupCount + 1; itemIndex < m_lastGroupIndex; itemIndex++)
        {
            btnShrink = GetShrinkControl(dlAvailableFlight.Items[itemIndex]);

            btnShrink.Attributes.Add("onclick",
                "HidePart(" + m_firstGroupIndex
                + "," + groupCount + ",this)");
        }

        btnExpansion.Style["display"] = "none";
        btnShrink.Style["display"] = "block";

        pnlWholeFlightItem.Style["display"] = "none";
    }

    private Label GetExpansionControl(DataListItem flightItem)
    {
        return (Label)flightItem.FindControl("lb_showSamePrice");
    }

    private Label GetShrinkControl(DataListItem flightItem)
    {
        return (Label)flightItem.FindControl("lb_hideSamePrice");
    }

    private Panel GetWholeFlightItemControl(DataListItem flightItem)
    {
        return (Panel)flightItem.FindControl("pnlWholeFlightItem");
    }

    private void SetGroupStyleAtGroupLastItem(DataListItem currentItem)
    {
        //如果改组只有一条记录设置第一条的样式
        if (m_lastGroupIndex == m_firstGroupIndex)
        {
            if (m_lastGroupIndex == currentItem.ItemIndex)
            {
                SetFirstGroupItemStyleWhenJustOneRecordInGroup(currentItem);
            }
            else
            {
                SetFirstGroupItemStyleWhenJustOneRecordInGroup(dlAvailableFlight.Items[m_firstGroupIndex]);
            }
        }
        else
        {
            //设置组内第一条样式
            if (currentItem.ItemIndex == m_firstGroupIndex)
            {
                SetFirstGroupItemStyle(currentItem);
            }
            else
            {
                SetFirstGroupItemStyle(dlAvailableFlight.Items[m_firstGroupIndex]);
            }

            //设置组内最后一条样式
            if (currentItem.ItemIndex == m_lastGroupIndex)
            {
                SetLastGroupItemStyle(currentItem);
            }
            else
            {
                SetLastGroupItemStyle(dlAvailableFlight.Items[m_lastGroupIndex]);
            }
        }
    }

    private void SetFirstGroupItemStyleWhenJustOneRecordInGroup(DataListItem firstGroupItem)
    {
        //隐藏Show、Hide链接
        Label btnExpansion = GetExpansionControl(firstGroupItem);
        Label btnShrink = GetShrinkControl(firstGroupItem);

        btnExpansion.Style["display"] = "none";
        btnShrink.Style["display"] = "none";
    }

    protected void dlSubTrips_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        System.Web.UI.WebControls.Label lblStops = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblStops");
        SubAirTrip subAirTrip = (SubAirTrip)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));

        AirLineMatricsManager airlineMatricsManager = new AirLineMatricsManager();
        lblStops.Text = airlineMatricsManager.GetStopsInsideFlight(subAirTrip).ToString();

        //Duration
        Label lblDuration = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblDuration");
        lblDuration.Text = airlineMatricsManager.FormatTimeSpan(airlineMatricsManager.GetDuration(subAirTrip));

    }

    protected void dlAirFare_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        System.Web.UI.WebControls.Image image1 = (System.Web.UI.WebControls.Image)e.Item.FindControl("AirImgRtn1");
        System.Web.UI.WebControls.Image imgAirlineSelect = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgAirlineSelect");
        image1.ImageUrl = "~/images/airline/defult_air.jpg";



        imgAirlineSelect.ImageUrl = image1.ImageUrl;
        AirMaterial flight = (AirMaterial)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
        string airImgName = ((AirProfile)flight.Profile).Airlines[0].Code.Trim().ToString() + ".gif";
        if (System.IO.File.Exists(Request.PhysicalApplicationPath + @"images\airline\" + airImgName))
        {
            image1.ImageUrl = "~/images/airline/" + airImgName;
            imgAirlineSelect.ImageUrl = image1.ImageUrl;
        }

        SetImageToolTip(image1, flight);
        SetImageToolTip(imgAirlineSelect, flight);

        //
        EditTaxTotalStyle(e.Item, flight);

        if (Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
        {
            if (((Terms.Sales.Business.AirSearchCondition)Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Child) == 0)
            {
                System.Web.UI.WebControls.Panel divChildFare = (Panel)e.Item.FindControl("divChildFare");
                //divChildFare.Visible = false;

                System.Web.UI.WebControls.Panel divChildFareDetail = (Panel)e.Item.FindControl("divChildFareDetail");
                divChildFareDetail.Visible = false;
            }
        }

        AirMaterial currentAirMaterial = (AirMaterial)SelectContactFlightList[e.Item.ItemIndex + PageNumber2.PageSize * PageNumber2.CurrentPageIndex];

        int index = int.Parse(currentAirMaterial.Profile.GetParam(Key_FlightMerchandisIndex).ToString());

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
        {

            //Label lbl_FareType = (Label)e.Item.FindControl("lbl_FareType");
            ImageButton btnSel = (ImageButton)e.Item.FindControl("btnSelect");
            ImageButton btnAvail = (ImageButton)e.Item.FindControl("btnAvail");
            ImageButton btnNotAvail = (ImageButton)e.Item.FindControl("btnNotAvail");
            ImageButton btnContactAgt = (ImageButton)e.Item.FindControl("btnContactAgt");
            //HtmlTableCell itemBookingClass = (HtmlTableCell)e.Item.FindControl("itemBookingClass");



            //只对 TurboTT 的demo 开发BookingClass
            //if (IsOpenBookingClass)
            //    itemBookingClass.Visible = tdBookingClass.Visible = true;
            //else
            //    itemBookingClass.Visible = tdBookingClass.Visible = false;

            //btnSel.ImageUrl = btnSel.ImageUrl.ToLower().Replace("images/", "images/" + ImageCulturePath);
            //btnAvail.ImageUrl = btnAvail.ImageUrl.ToLower().Replace("images/", "images/" + ImageCulturePath);
            //btnContactAgt.ImageUrl = btnContactAgt.ImageUrl.ToLower().Replace("images/", "images/" + ImageCulturePath);
            //btnContactAgt.OnClientClick = ContactUsOnClick;

            //Label tr = (Label)e.Item.FindControl("Mytr");

            AirMaterial merchandise = (AirMaterial)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));

            //判断机票是否是PUB机票
            if (!merchandise.Profile.GetParam("FARE_TYPE").Equals(Terms.Product.Utility.FlightFareType.PUB.ToString()))
            {
                //获得AirLineName显示所使用的Label控件
                Label lblAirLineName = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbl_Airline");

                //获得所绑定行的数据源中的AirLineCode
                string strAirLineCode = ((AirProfile)merchandise.Profile).Airlines[0].Code.Trim().ToString();
                //获得配置文件并转换为DataSet
                System.Data.DataSet dsAirLineConfig = PageUtility.GetReciever();
                //判断配置数据是否存在
                if (dsAirLineConfig.Tables.Count > 0 && dsAirLineConfig.Tables[0] != null && dsAirLineConfig.Tables[0].Rows.Count == 1)
                {
                    //判断当前Code是否存在于配置数据中
                    if (dsAirLineConfig.Tables[0].Columns.Contains(strAirLineCode.ToUpper().Trim()))
                    {
                        //Code存在 按规则替换 名称与图片
                        lblAirLineName.Text = dsAirLineConfig.Tables[0].Rows[0][strAirLineCode.ToUpper().Trim()].ToString();
                        image1.ImageUrl = "~/images/airline/defult_air.jpg";

                        imgAirlineSelect.ImageUrl = image1.ImageUrl;
                    }
                }
            }

            //if (e.Item.ItemIndex % 2 == 0)
            //    tr.Text = "<tr align=\"center\"  class =\"R_stepw\">";
            //else
            //    tr.Text = "<tr align=\"center\"  class =\"R_stepg\">";
            AirMaterial tGoup = (AirMaterial)e.Item.DataItem;

            //if (tGoup.AirTrip.SubTrips.Count > 0)
            //{
            //    btnSel.Visible = false;
            //    btnAvail.Visible = true;
            //}


            if (tGoup.Profile.GetParam("FARE_TYPE").Equals(Terms.Product.Utility.FlightFareType.SR.ToString()) || tGoup.Profile.GetParam("FARE_TYPE").Equals(Terms.Product.Utility.FlightFareType.PUB.ToString())
                || (tGoup.Profile.GetParam("SelectAvailable") != null && (bool)tGoup.Profile.GetParam("SelectAvailable") == true))
            {
                if (tGoup.AirTrip.SubTrips.Count == 0 || tGoup.AirTrip.SubTrips[0].Flights.Count == 0)
                {


                    //如果Should_Call标志为True，则使用Contact Agt图标代替Select

                    btnSel.Visible = false;

                    btnAvail.Visible = false;

                    btnNotAvail.Enabled = false;

                    btnContactAgt.Visible = true;

                    EditItemToSelectContactStyle(e.Item);

                }
                else
                {

                    btnSel.Visible = false;
                    btnAvail.Visible = true;
                    //lbl_FareType.Text = "Bulk";

                }
            }
            else
            {
                //更改画面为ContactSelect状态
                EditItemToSelectContactStyle(e.Item);

                AirMerchandise airMerchandise = (AirMerchandise)FlightMerchandise.Items[index];
                if ((bool)tGoup.Profile.GetParam("SHOULD_CALL"))
                {

                    //如果Should_Call标志为True，则使用Contact Agt图标代替Select

                    btnSel.Visible = false;

                    btnAvail.Visible = false;

                    btnNotAvail.Enabled = false;

                    btnContactAgt.Visible = true;

                }
                else
                {
                    if (airMerchandise.Profile.GetParam("ERR_MESSAGE") != null)
                    {

                        btnSel.Visible = false;

                        btnAvail.Visible = false;

                        btnNotAvail.Enabled = false;

                        btnContactAgt.Visible = true;
                    }
                }
                //lbl_FareType.Text = tGoup.FareType.ToString();


                //Label test = ((Label)e.Item.FindControl("ctl00_MainContent_dlAirFare_ctl03_dlSubTrips_ctl00_lblDepDate"));

                if (flightInfohider.IsNeedToHide(((AirProfile)tGoup.Profile).Airlines[0].Code.Trim().ToString(), tGoup.Profile.GetParam("FARE_TYPE").ToString()))
                {
                    //((Label)e.Item.FindControl("lblAirName")).Visible = true;
                    ((Label)e.Item.FindControl("lbl_Airline")).Text = flightInfohider.ReplaceFlightName(((AirProfile)tGoup.Profile).Airlines[0].Code.Trim().ToString(), tGoup.Profile.GetParam("FARE_TYPE").ToString());


                    //HideFlightInfoFlag = true;
                }
                else
                {

                }
            }

            if (flightInfohider.IsNeedToHide(currentAirMaterial))
            {
                ((Label)e.Item.FindControl("lbl_Airline")).Text = flightInfohider.ReplaceFlightName(((AirProfile)currentAirMaterial.Profile).Airlines[0].Code.Trim().ToString(), currentAirMaterial.Profile.GetParam("FARE_TYPE").ToString());
            }
        }

    }

    private void SetImageToolTip(System.Web.UI.WebControls.Image image, AirMaterial flight)
    {
        //if (IsDemo())
        //{
        //    image.ToolTip = ((AirProfile)flight.Profile).Airlines[0].Code + " " + flight.Profile.GetParam("FARE_TYPE").ToString();
        //}
        //else
        //{
            image.ToolTip = string.Empty;
        //}
    }

    private bool IsDemo()
    {
        return true;//Request.Url.AbsoluteUri.ToLower().Contains("demo");
    }

    private void EditTaxTotalStyle(DataListItem dataListItem, AirMaterial flight)
    {
        //TaxTotal
        Label lblAdultTaxTotal = (Label)dataListItem.FindControl("lblAdultTaxTotal");
        Label lblChildTaxTotal = (Label)dataListItem.FindControl("lblChildTaxTotal");

        if (flight.AdultTax == 0)
        {
            lblAdultTaxTotal.Visible = false;
            lblChildTaxTotal.Visible = false;
        }
    }

    private void EditItemToSelectContactStyle(DataListItem dataListItem)
    {
        //DisplayMoney
        Label lblDisplayMoney = (Label)dataListItem.FindControl("lblDisplayMoney");
        lblDisplayMoney.Visible = false;

        //PerPerson
        Label lblPerPerson = (Label)dataListItem.FindControl("lblPerPerson");
        lblPerPerson.Visible = false;

        //TaxTotal
        Label lblAdultTaxTotal = (Label)dataListItem.FindControl("lblAdultTaxTotal");
        lblAdultTaxTotal.Visible = false;
        Label lblChildTaxTotal = (Label)dataListItem.FindControl("lblChildTaxTotal");
        lblChildTaxTotal.Visible = false;

        //imgAirline
        System.Web.UI.WebControls.Image AirImgRtn1 = (System.Web.UI.WebControls.Image)dataListItem.FindControl("AirImgRtn1");
        AirImgRtn1.Visible = false;
        System.Web.UI.WebControls.Image imgAirlineSelect = (System.Web.UI.WebControls.Image)dataListItem.FindControl("imgAirlineSelect");
        imgAirlineSelect.Visible = true;
        Label lblAirlineSpace = (Label)dataListItem.FindControl("lblAirlineSpace");
        lblAirlineSpace.Visible = true;
    }

    protected void dlFlights_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        ////AirMerchandise tGoup = (AirMerchandise)(FlightMerchandise.Items[e.Item.ItemIndex]);

        ////int index = e.Item.ItemIndex + PageNumber1.PageSize * PageNumber1.CurrentPageIndex;
        //AirMaterial tGoup = (AirMaterial)(((DataListItem)e.Item.Parent.Parent).DataItem);

        //if (flightInfohider.IsNeedToHide(((AirProfile)tGoup.Profile).Airlines[0].Code.Trim().ToString(), tGoup.Profile.GetParam("FARE_TYPE").ToString()))
        //{
        //    //((Label)e.Item.FindControl("lblAirName")).Visible = true;
        //    //((Label)e.Item.Parent.FindControl("lbl_Airline")).Text = flightInfohider.ReplaceFlightName(((AirProfile)tGoup.Profile).Airlines[0].Code.Trim().ToString(), tGoup.Profile.GetParam("FARE_TYPE").ToString());
        //    ((Label)e.Item.FindControl("lblDepDateHide")).Text = flightInfohider.TimeToName(((Label)e.Item.FindControl("lblDepDate")).Text.Substring(0, 8)) + ((Label)e.Item.FindControl("lblDepDateHide")).Text;
        //    ((Label)e.Item.FindControl("lblArrDateHide")).Text = flightInfohider.TimeToName(((Label)e.Item.FindControl("lblArrDate")).Text.Substring(0, 8)) + ((Label)e.Item.FindControl("lblArrDateHide")).Text;
        //    //((Label)e.Item.FindControl("lblBookClass")).Visible = false;
        //    //((Label)e.Item.FindControl("lblFlightNo")).Visible = false;
        //    //((Label)e.Item.FindControl("lbl_AirCode")).Visible = false;
        //    ((Label)e.Item.FindControl("lblDepDate")).Visible = false;
        //    ((Label)e.Item.FindControl("lblArrDate")).Visible = false;

        //    //HideFlightInfoFlag = true;
        //}
        //else
        //{
        //    //((Label)e.Item.FindControl("lblAirName")).Visible = false;
        //    ((Label)e.Item.FindControl("lblDepDateHide")).Visible = false;
        //    ((Label)e.Item.FindControl("lblArrDateHide")).Visible = false;
        //    //if (IsOpenBookingClass)
        //    //    ((Label)e.Item.FindControl("lblBookClass")).Visible = true;
        //    //else
        //    //    ((Label)e.Item.FindControl("lblBookClass")).Visible = false;

        //    //((Label)e.Item.FindControl("lblFlightNo")).Visible = true;
        //    //((Label)e.Item.FindControl("lbl_AirCode")).Visible = true;
        //    ((Label)e.Item.FindControl("lblDepDate")).Visible = true;
        //    ((Label)e.Item.FindControl("lblArrDate")).Visible = true;
        //}

        AirMaterial tGoup = (AirMaterial)(((DataListItem)e.Item.Parent.Parent.Parent.Parent).DataItem);
        string airCode = ((AirProfile)tGoup.Profile).Airlines[0].Code.Trim().ToString();
        string fareType = tGoup.Profile.GetParam("FARE_TYPE").ToString();

        if (flightInfohider.IsNeedToHide(airCode, fareType))
        {
            //((Label)e.Item.FindControl("lblAirName")).Visible = true;
            //((Label)e.Item.FindControl("lbl_AirCode")).Text = flightInfohider.ReplaceFlightName(AirCode,FareType);
            //((Label)e.Item.FindControl("Label3")).Visible = true;
            //((Label)e.Item.FindControl("Label6")).Visible = true;
            ((Label)e.Item.FindControl("lbl_AirCode")).Text = flightInfohider.ReplaceFlightName(airCode, fareType);
            ((Label)e.Item.FindControl("Label3")).Text = flightInfohider.TimeToName(((Label)e.Item.FindControl("lblDepDate")).Text.Substring(0, 8)) + ((Label)e.Item.FindControl("Label3")).Text;
            ((Label)e.Item.FindControl("Label6")).Text = flightInfohider.TimeToName(((Label)e.Item.FindControl("lblArrDate")).Text.Substring(0, 8)) + ((Label)e.Item.FindControl("Label6")).Text;
            //((Label)e.Item.FindControl("lblBookClass")).Visible = false;
            ((Label)e.Item.FindControl("lblFlightNo")).Visible = false;
            ((Label)e.Item.FindControl("lblDepDate")).Visible = false;
            ((Label)e.Item.FindControl("lblArrDate")).Visible = false;
            HideFlightInfoFlag = true;
        }
        else
        {
            //((Label)e.Item.FindControl("lblAirName")).Visible = false;
            ((Label)e.Item.FindControl("Label3")).Visible = false;
            ((Label)e.Item.FindControl("Label6")).Visible = false;
            //((Label)e.Item.FindControl("lblBookClass")).Visible = true;
            ((Label)e.Item.FindControl("lblFlightNo")).Visible = true;
            //((Label)e.Item.FindControl("lbl_AirCode")).Visible = true;
            ((Label)e.Item.FindControl("lblDepDate")).Visible = true;
            ((Label)e.Item.FindControl("lblArrDate")).Visible = true;
        }

        ((Label)e.Item.FindControl("lblFlightDuration")).Text = GetFlightTime((AirLeg)(e.Item.DataItem));
    }

    protected void dlAvailable_ItemCommand(object sender, DataListCommandEventArgs e)
    {
        int merchandiseIndex;
        AirMaterial tempAirMaterial;

        if (SessionExpired)
        {
            //Err(Resources.HintInfo.TheResearch, "", "Step2.aspx");
        }
        else
        {
            int flightdetailIndex = e.Item.ItemIndex + PageNumber1.PageSize * PageNumber1.CurrentPageIndex;

            //AirMaterial merchandise = (AirMaterial)(AvailableFlightList[flightdetailIndex]);

            //AirProfile currentAirProfile = (AirProfile)merchandise.Profile;

            //AirMaterial currentAirMaterial = (AirMaterial)TotalFlightList[flightdetailIndex];

            //int index = int.Parse(currentAirMaterial.Profile.GetParam(Key_FlightMerchandisIndex).ToString());

            AirMaterial tGoup = (AirMaterial)(AvailableFlightList[flightdetailIndex]);

            if (e.CommandName == "Avail" || e.CommandName == "BeAvail")
            {
                isClickAvailable = true;
                DoAvailableProcess(flightdetailIndex, tGoup);
            }
            else if (e.CommandName == "NotAvail")
            {

            }

            else
            {
                SelectAirMaterial = tGoup;
                CurrentSession.OriginalIndex = flightdetailIndex;
                Response.Redirect("Step3_bulk.aspx");

            }


        }
    }

    void lb_sortArrival_Click(object sender, EventArgs e)
    {
        SortFlight(AirLineMatricsManager.SortByFlag.ArrivalDate);
    }

    void lb_sortDeparture_Click(object sender, EventArgs e)
    {
        SortFlight(AirLineMatricsManager.SortByFlag.DepartureDate);
    }

    void lb_sortPrice_Click(object sender, EventArgs e)
    {
        SortFlight(AirLineMatricsManager.SortByFlag.Price);
    }

    void lb_sortAirline_Click(object sender, EventArgs e)
    {
        SortFlight(AirLineMatricsManager.SortByFlag.Airline);
    }

    void lb_sortDuration_Click(object sender, EventArgs e)
    {
        SortFlight(AirLineMatricsManager.SortByFlag.Duration);
    }


    private void SetEvent()
    {
        lb_sortAirline.Click += new EventHandler(lb_sortAirline_Click);
        lb_sortPrice.Click += new EventHandler(lb_sortPrice_Click);
        lb_sortDeparture.Click += new EventHandler(lb_sortDeparture_Click);
        lb_sortArrival.Click += new EventHandler(lb_sortArrival_Click);
        lb_sortDuration.Click += new EventHandler(lb_sortDuration_Click);
    }

    private bool IsFiltered()
    {
        if (TotalAvailableFlightList == null)
        {
            return false;
        }

        if (AvailableFlightList == null && TotalAvailableFlightList != null)
        {
            return true;
        }

        return AvailableFlightList.Count < TotalAvailableFlightList.Count;
    }

    private void DoAvailableProcess(int flightdetailIndex, AirMaterial tGoup)
    {
        OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.ClickAvalibale, this);

        CurrentSession.OriginalIndex = flightdetailIndex;
        FlightMerchandiseManager flightMerchandiseManager = new FlightMerchandiseManager();
        AirMaterial airMaterial = tGoup;
        decimal originalPrice = GetTotalPrice(airMaterial);
        decimal newPrice = 0;

        bool bclError = false;

        //if (tGoup.Profile.GetParam("FARE_TYPE").Equals(FlightFareType.SR.ToString()) || tGoup.Profile.GetParam("FARE_TYPE").Equals("COMMNEW") || tGoup.Profile.GetParam("FARE_TYPE").Equals(FlightFareType.PUB.ToString()))
        //{
        //    //AirMaterial airMaterial = tGoup;

        //    AirOrderItem airOrderItem = new AirOrderItem(airMaterial);


        //    this.Transaction.CurrentTransactionObject.Items.Clear();
        //    this.Transaction.CurrentTransactionObject.AddItem(airOrderItem);


        //    IList<TERMS.Business.Centers.SalesCenter.Passenger> passengers = new List<TERMS.Business.Centers.SalesCenter.Passenger>();
        //    SetPreBookingPassengers(airMaterial, ref passengers);


        //    try
        //    {
        //        AirService.PreBookAirline2(ref airMaterial, passengers);
        //    }
        //    catch (Exception ex)
        //    {
        //        DoErrorProcess(ex);
        //        log.Error(ex.Message, ex);
        //        bclError = true;
        //    }

        //    if (bclError)
        //        this.Err("", "Booking failed", "NewStep2.aspx");

        //    FlightMerchandiseManager flightMerchandiseManager = new FlightMerchandiseManager();

        //    airMaterial = flightMerchandiseManager.EditMaterialGroupMarkup(airMaterial);

        //}
        //else
        //{
        //    IList<TERMS.Business.Centers.SalesCenter.Passenger> passengers = new List<TERMS.Business.Centers.SalesCenter.Passenger>();
        //    try
        //    {

        //        GetAirBookingCondition(ref passengers, tGoup);
        //    }
        //    catch (Exception E)
        //    {
        //        log.Error(E.Message, E);
        //    }
        //    //AirMaterial airMaterial = tGoup;

        //    bool bclError = false;

        //    try
        //    {
        //        string[] requestXML = new string[3];
        //        //ws.PreBookAirline(ref group, SearchArray, requestXML);
        //        AirService.PreBookAirline2(ref airMaterial, passengers);

        //        FlightMerchandiseManager flightMerchandiseManager = new FlightMerchandiseManager();

        //        airMaterial = flightMerchandiseManager.EditMaterialGroupMarkup(airMaterial);
        //    }
        //    catch (Exception ex)
        //    {
        //        DoErrorProcess(ex);
        //        log.Error(ex.Message, ex);
        //        bclError = true;
        //    }

        //    if (bclError)
        //        this.Err("", "Booking failed", "NewStep2.aspx");

        //}

        try
        {
            IList<TERMS.Business.Centers.SalesCenter.Passenger> passengers = new List<TERMS.Business.Centers.SalesCenter.Passenger>();


            if (tGoup.Profile.GetParam("FARE_TYPE").Equals(FlightFareType.SR.ToString()) || tGoup.Profile.GetParam("FARE_TYPE").Equals("COMMNEW") || tGoup.Profile.GetParam("FARE_TYPE").Equals(FlightFareType.PUB.ToString()))
            {
                AirOrderItem airOrderItem = new AirOrderItem(airMaterial);


                this.Transaction.CurrentTransactionObject.Items.Clear();
                this.Transaction.CurrentTransactionObject.AddItem(airOrderItem);



                SetPreBookingPassengers(airMaterial, ref passengers);

            }
            else
            {
                try
                {

                    GetAirBookingCondition(ref passengers, tGoup);
                }
                catch (Exception E)
                {
                    log.Error(E.Message, E);
                }

            }

            AirService.PreBookAirline2(ref airMaterial, passengers);

            airMaterial = flightMerchandiseManager.EditMaterialGroupMarkup(airMaterial);

        }
        catch (Exception ex)
        {
            DoErrorProcess(ex);
            log.Error(ex.Message, ex);
            bclError = true;

            DisplayCannotbook();
            return;
        }

        if (bclError)
        {
            DisplayCannotbook();
            return;
        }

        if (Convert.ToBoolean(tGoup.Profile.GetParam("ISWEBFARE")))
        {
            tGoup.FareType = AirFareType.Published;
            Price price = new Price();
            price.SetAmount(TERMS.Common.PassengerType.Adult,new FareAmount(Convert.ToDecimal(tGoup.Profile.GetParam("PUBLISHED_ADULT_FARE"))));
            price.SetAmount(TERMS.Common.PassengerType.Child,new FareAmount(Convert.ToDecimal(tGoup.Profile.GetParam("PUBLISHED_CHILD_FARE"))));
            Markup mk = FlightMerchandise.AirProduct.GetMarkup(tGoup);
            price.AddMarkup(mk);
            tGoup.SetPrice(price);
           
        }
        //
        //if (IsPriceChanged())

        airMaterial = EditFare(airMaterial);

        newPrice = GetTotalPrice(airMaterial);

        SelectAirMaterial = tGoup;

        //设置当前页号
        SetCurrentPageNumber();

        SetCurrentTabFlag();

        if (isClickAvailable == true && IsChangeNotLess(newPrice, originalPrice))
        {
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.IBE_AvailableFareChanged, this);

            ScriptManager.RegisterStartupScript(upSelect, upSelect.GetType(), "alt", "<script>$('ctl00_MainContent_pnlSelectProcessing').style.display ='none';</script>", false);

            Label lblCurrentMsg = null;
            Panel pnlCurrentComfirm = null;

            if (isClickAvailable == false)
            {
                lblCurrentMsg = lblSoldOutMsg_Select;
                pnlCurrentComfirm = pnlComfirm_Select;
            }
            else
            {
                lblCurrentMsg = lblSoldOutMsg;
                pnlCurrentComfirm = pnlComfirm;
            }

            if (IsLittleChanged(originalPrice, newPrice))
            {
                lblCurrentMsg.Text = string.Format(LittleChangedSoldoutMsg, ((decimal)(newPrice - originalPrice)).ToString("#,###.##"));
            }
            else
            {
                lblCurrentMsg.Text = string.Format(LargeChangedSoldoutMsg, ((decimal)(newPrice - originalPrice)).ToString("#,###.##"));
            }

            pnlCurrentComfirm.Attributes.Add("style", "display:block;");

        }
        else
        {
            ScriptManager.RegisterStartupScript(upSelect, upSelect.GetType(), "alt", "<script>$('ctl00_MainContent_pnlSelectProcessing').style.display ='none';document.getElementById('maskDIV').style.display = 'none';</script>", false);
            Response.Redirect("Step3_confirm.aspx?ConditionID=" + Request.Params["ConditionID"]);
        }

        //Response.Redirect("Step3_bulk.aspx");
    }

    private bool IsChangeNotLess(decimal newPrice, decimal originalPrice)
    {
        return newPrice > originalPrice && (newPrice - originalPrice > LITTLE_EDGE);
    }

    private decimal LITTLE_EDGE
    {
        get
        {
            if (ConfigurationSettings.AppSettings.Get("LITTLE_EDGE") != null)
            {
                return decimal.Parse(ConfigurationSettings.AppSettings.Get("LITTLE_EDGE").ToString());
            }
            else
            {
                return 5;
            }
        }
    }

    private void DisplayCannotbook()
    {
        //UpdatePanel upCurrent = null;

        //if (isClickAvailable == false)
        //{
        //    upCurrent = upSelect;
        //}
        //else
        //{
        //    upCurrent = upAvailable;
        //}

        //if (UserCulture.Name == "zh-CN")
        //{
        //    ScriptManager.RegisterStartupScript(upCurrent, upCurrent.GetType(), "alt", "<script>alert('對不起，該機票已經售完或停止銷售。您可以選擇其他機票繼續訂購。');document.getElementById('maskDIV').style.display = 'none';</script>", false);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(upCurrent, upCurrent.GetType(), "alt", "<script>alert('Sorry, the selected flight has been sold out, please select other flight to continue.');document.getElementById('maskDIV').style.display = 'none';</script>", false);
        //}
        ScriptManager.RegisterStartupScript(upSelect, upSelect.GetType(), "alt", "<script>$('ctl00_MainContent_pnlSelectProcessing').style.display ='none';</script>", false);

        Label lblCurrentMsg = null;
        Panel pnlCurrentComfirm = null;

        if (isClickAvailable == false)
        {
            lblCurrentMsg = lbl_pnlCannotBookMsg_Select;
            pnlCurrentComfirm = pnlCannotBookMsg_Select;
        }
        else
        {
            lblCurrentMsg = lbl_pnlCannotBookMsg;
            pnlCurrentComfirm = pnlCannotBookMsg;
        }

        lblCurrentMsg.Text = Resources.HintInfo.CannotBookMsg;

        pnlCurrentComfirm.Attributes.Add("style", "display:block;");
    }

    private AirMaterial EditFare(AirMaterial airMaterial)
    {
        int adult = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Adult); //大人数
        int child = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Child); //小孩数
        decimal AirTotalPrice = 0.0m; //总价
        decimal adultTax = 0.0m; //大人单税
        decimal childTax = 0.0m; //小孩单税
        decimal adultPrice = 0.0m; //大人含税单价
        decimal childPrice = 0.0m; //小孩含税单价
        decimal adultMarkup = 0.0m;
        decimal childMarkup = 0.0m;

        decimal adultBasePrice = 0.0m; //大人不含税单价
        decimal childBasePrice = 0.0m; //小孩不含税单价

        if (airMaterial.Profile.GetParam("FARE_TYPE").ToString() == "COMM" || airMaterial.Profile.GetParam("FARE_TYPE").ToString() == "COMMNEW" || airMaterial.Profile.GetParam("FARE_TYPE").ToString() == "NET")
        {
            adultTax = airMaterial.Profile.GetParam("ADULT_TAX") == null ? adultTax : Convert.ToDecimal(airMaterial.Profile.GetParam("ADULT_TAX"));
            childTax = airMaterial.Profile.GetParam("CHILD_TAX") == null ? childTax : Convert.ToDecimal(airMaterial.Profile.GetParam("CHILD_TAX"));
            airMaterial.SetAdultTax(adultTax);
            airMaterial.SetChildTax(childTax);


            adultBasePrice = airMaterial.Profile.GetParam("PUBLISHED_ADULT_FARE") == null ? adultBasePrice : Convert.ToDecimal(airMaterial.Profile.GetParam("PUBLISHED_ADULT_FARE"));
            childBasePrice = airMaterial.Profile.GetParam("PUBLISHED_CHILD_FARE") == null ? childBasePrice : Convert.ToDecimal(airMaterial.Profile.GetParam("PUBLISHED_CHILD_FARE"));
            int commision = airMaterial.Profile.GetParam("COMMISION") == null ? 0 : Convert.ToInt32(airMaterial.Profile.GetParam("COMMISION"));

            if (airMaterial.Profile.GetParam("FARE_TYPE").ToString() == "NET") commision = 0;
            if (child > 0)
            {
                if (airMaterial.Profile.GetParam("FARE_TYPE").ToString() == "NET")
                {
                    childPrice = airMaterial.ChildBaseFare + airMaterial.ChildMarkup + childTax;
                }
                else
                {
                    if (Convert.ToBoolean(airMaterial.Profile.GetParam("ISWEBFARE")))
                    {
                        childPrice = childBasePrice + airMaterial.ChildMarkup + childTax;
                        airMaterial.SetChildBaseFare(childBasePrice);
                        airMaterial.GetPrice().SetServiceFee(TERMS.Common.PassengerType.Child, new FareAmount(airMaterial.ChildMarkup, new Currency(), new Currency()));
                    }
                    else
                    {
                        decimal childFinalBasePrice = decimal.Ceiling(childBasePrice * (100 - commision) / 100);
                        airMaterial.SetChildBaseFare(childFinalBasePrice);
                        childPrice = childFinalBasePrice + airMaterial.ChildMarkup + childTax;

                    }
                }
            }

            if (adult > 0)
            {
                if (airMaterial.Profile.GetParam("FARE_TYPE").ToString() == "NET")
                {
                    adultPrice = airMaterial.AdultBaseFare + airMaterial.AdultMarkup + adultTax;
                }
                else
                {
                    if (Convert.ToBoolean(airMaterial.Profile.GetParam("ISWEBFARE")))
                    {
                        adultPrice = adultBasePrice + airMaterial.AdultMarkup + adultTax;
                        airMaterial.SetAdultBaseFare(adultBasePrice);
                        airMaterial.GetPrice().SetServiceFee(TERMS.Common.PassengerType.Adult, new FareAmount(airMaterial.AdultMarkup, new Currency(), new Currency()));
                    }
                    else
                    {
                        decimal adultFinalBasePrice = decimal.Ceiling(adultBasePrice * (100 - commision) / 100);
                        airMaterial.SetAdultBaseFare(adultFinalBasePrice);
                        adultPrice = adultFinalBasePrice + airMaterial.AdultMarkup + adultTax;

                    }
                }
            }

        }

        return airMaterial;
    }

    private const string CULTURE_CHINA = "zh-CN";

    private string LittleChangedSoldoutMsg
    {
        get
        {
            return Resources.HintInfo.LittleChangedSoldoutMsg;
        }
    }

    private string LargeChangedSoldoutMsg
    {
        get
        {
            return Resources.HintInfo.LargeChangedSoldoutMsg;
        }
    }

    private decimal LittleLargeEdge
    {
        get
        {
            if (ConfigurationSettings.AppSettings.Get("LITTLE_LARGER_EDGE") != null)
            {
                return decimal.Parse(ConfigurationSettings.AppSettings.Get("LITTLE_LARGER_EDGE").ToString());
            }
            else
            {
                return 50;
            }
        }
    }

    private void SetCurrentTabFlag()
    {
        TabFlag = hfTabFlag.Value.Trim();
    }

    private bool IsLittleChanged(decimal originalPrice, decimal newPrice)
    {
        bool isLittleChanged = false;
        decimal littleLargeEdge = LittleLargeEdge;

        if (newPrice - originalPrice <= littleLargeEdge)
        {
            isLittleChanged = true;
        }

        return isLittleChanged;
    }

    private decimal GetTotalPrice(AirMaterial airMaterial)
    {
        decimal totalPrice = 0;

        if (isClickAvailable == false)
        {
            totalPrice = airMaterial.AdultBaseFare;
        }
        else
        {
            totalPrice = airMaterial.AdultBaseFare + airMaterial.AdultMarkup + airMaterial.AdultTax;
        }

        return totalPrice;
    }

    protected void dlAirFare_ItemCommand(object sender, DataListCommandEventArgs e)
    {
        int merchandiseIndex;
        AirMaterial tempAirMaterial;

        if (SessionExpired)
        {
            //Err(Resources.HintInfo.TheResearch, "", "Step2.aspx");
        }
        else
        {
            int flightdetailIndex = e.Item.ItemIndex + PageNumber2.PageSize * PageNumber2.CurrentPageIndex;

            AirMaterial merchandise = (AirMaterial)(SelectContactFlightList[flightdetailIndex]);

            AirProfile currentAirProfile = (AirProfile)merchandise.Profile;

            AirMaterial currentAirMaterial = (AirMaterial)SelectContactFlightList[flightdetailIndex];

            int index = int.Parse(currentAirMaterial.Profile.GetParam(Key_FlightMerchandisIndex).ToString());

            AirMaterial tGoup = (AirMaterial)SelectContactFlightList[flightdetailIndex];
            if (e.CommandName == "Select")
            {

                FlightMerchandiseManager manager = new FlightMerchandiseManager();

                OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SelectAir, this);

                //System.Threading.Thread.Sleep(1000);

                ImageButton btnSel = (ImageButton)e.Item.FindControl("btnSelect");
                btnSel.Visible = false;

                //currentGroup 只为了触发一次事件GteReBindContactAgentList(componentGroup.Items)
                IList<TERMS.Core.Product.Component> currentGroup = null;
                if (((TERMS.Core.Product.ComponentGroup)FlightMerchandise.AirProduct.Items[index]).ItemGetter != null)
                {
                    currentGroup = ((TERMS.Core.Product.ComponentGroup)FlightMerchandise.AirProduct.Items[index]).ItemGetter.Get();
                }
                else
                {
                    tGoup.Profile.SetParam("SHOULD_CALL", true);
                    runFlag.Value = "0";

                    return;
                }

                for (int i = 0; i < FlightMerchandise.Items.Count; i++)
                {
                    TERMS.Core.Product.ComponentGroup componentGroup = (TERMS.Core.Product.ComponentGroup)FlightMerchandise.AirProduct.Items[i];
                    if (componentGroup.Profile.GetParam("VISITTED") == null && componentGroup.ItemGetter != null && componentGroup.ItemGetter.GetStatus() == ComponentGetterStatus.HasGot)
                    {
                        //未访问过 && 有getter(SR,PUB没有) && getter已取过数据
                        AirMerchandise airMerchandise = (AirMerchandise)FlightMerchandise.Items[i];

                        if (componentGroup.Items != null && componentGroup.Items.Count > 0)
                        {
                            //先删除掉该Merchandise的Select
                            merchandiseIndex = 0;

                            int firstIndex = 0;

                            for (int materialIndex = 0; materialIndex < SelectContactFlightList.Count; materialIndex++)
                            {
                                tempAirMaterial = (AirMaterial)SelectContactFlightList[materialIndex];

                                merchandiseIndex = int.Parse(tempAirMaterial.Profile.GetParam(Key_FlightMerchandisIndex).ToString());

                                if (merchandiseIndex == i)
                                {
                                    if (firstIndex == 0)
                                    {
                                        firstIndex = materialIndex;
                                    }


                                    //materialIndex--;
                                }
                            }

                            IList<TERMS.Core.Product.Component> group = componentGroup.Items;
                            foreach (TERMS.Core.Product.ComponentGroup cGroup in group)
                            {
                                if (cGroup.Items != null && cGroup.Items.Count > 0)
                                {
                                    int currentInsertIndex = firstIndex;

                                    AirMaterial airMaterial;
                                    for (int airMaterialindex = 0; airMaterialindex < cGroup.Items.Count; airMaterialindex++)
                                    {
                                        airMaterial = (AirMaterial)cGroup.Items[airMaterialindex];

                                        airMaterial.Profile = (AirProfile)SelectContactFlightList[firstIndex].Profile;
                                        //airMaterial.Profile = (AirProfile)airMerchandise.Profile;
                                        airMaterial.Profile.SetParam(Key_FlightMerchandisIndex, i);

                                        //airMaterial.Profile.SetParam("FARE_TYPE", Terms.Product.Utility.FlightFareType.PUB.ToString());
                                        //((AirProfile)airMaterial.Profile).set

                                        //SetFare
                                        //airMaterial.SetAdultBaseFare(airMerchandise.AdultBaseFare);
                                        //airMaterial.SetAdultMarkup(airMerchandise.AdultMarkup);
                                        //airMaterial.SetAdultTax(airMerchandise.AdultTax);
                                        //airMaterial.SetChildBaseFare(airMerchandise.ChildBaseFare);
                                        //airMaterial.SetChildMarkup(airMerchandise.ChildMarkup);
                                        //airMaterial.SetChildTax(airMerchandise.ChildTax);
                                        CopyMarkup(airMerchandise, airMaterial);

                                        //airMaterial.Profile.SetParam("FARE_TYPE", Terms.Product.Utility.FlightFareType.NET.ToString());

                                        //airMaterial.Profile.SetParam("VISITTED", true); //设置为已访问

                                        airMaterial.Profile.SetParam("SelectAvailable", true);

                                        //airMaterial = EditGroupMarkupAfterSelect(airMaterial, groupMarkup);
                                        airMaterial = manager.EditMaterialGroupMarkup(airMaterial);

                                        airMerchandise.Add(airMaterial);
                                        SelectContactFlightList.Insert(currentInsertIndex + 1, airMaterial);
                                        currentInsertIndex++;
                                        //firstIndex++;
                                    }


                                }

                                SelectContactFlightList[firstIndex].Profile.SetParam("SHOULD_CALL", true);

                                //else
                                //{
                                //    SelectContactFlightList[firstIndex].Profile.SetParam("SHOULD_CALL", true);
                                //    //cGroup.Profile.SetParam("SHOULD_CALL", true);
                                //}
                            }


                        }
                        else
                        {

                            for (int materialIndex = 0; materialIndex < SelectContactFlightList.Count; materialIndex++)
                            {
                                tempAirMaterial = (AirMaterial)SelectContactFlightList[materialIndex];

                                merchandiseIndex = int.Parse(tempAirMaterial.Profile.GetParam(Key_FlightMerchandisIndex).ToString());

                                if (merchandiseIndex == i)
                                {

                                    tempAirMaterial.Profile.SetParam("SHOULD_CALL", true);
                                }
                            }


                        }


                        bool isAvailable = true;
                        string errMessage = string.Empty;

                        if (airMerchandise.Items == null || airMerchandise.Items.Count == 0)
                        {
                            isAvailable = false;
                            //errMessage = Resources.HintInfo.NoAvailableFlight;
                        }

                        if (isAvailable)
                        {
                            //ImageButton btnAvail = (ImageButton)e.Item.FindControl("btnAvail");
                            //btnAvail.Visible = true;
                            //btnAvail.CommandName = "BeAvail";
                        }
                        else
                        {
                            //ImageButton btnNotAvail = (ImageButton)e.Item.FindControl("btnNotAvail");
                            //btnNotAvail.Visible = true;
                            //btnSel.Visible = false;
                            //btnNotAvail.Enabled = true;
                            //Panel p = (Panel)e.Item.FindControl("PopupMenu");
                            //Label lbl_ErrorMessage = (Label)e.Item.FindControl("lbl_ErrorMessage");
                            //lbl_ErrorMessage.Text = errMessage;
                            //airMerchandise.Profile.SetParam("ERR_MESSAGE", errMessage);

                            merchandiseIndex = 0;

                            for (int materialIndex = 0; materialIndex < SelectContactFlightList.Count; materialIndex++)
                            {
                                tempAirMaterial = (AirMaterial)SelectContactFlightList[materialIndex];

                                merchandiseIndex = int.Parse(tempAirMaterial.Profile.GetParam(Key_FlightMerchandisIndex).ToString());

                                if (merchandiseIndex == i)
                                {
                                    tempAirMaterial.Profile.SetParam("ERR_MESSAGE", errMessage);
                                }
                            }
                            //p.Visible = true;

                        }

                        componentGroup.Profile.SetParam("VISITTED", true); //设置为已访问

                        merchandiseIndex = 0;

                        //for (int materialIndex = 0; materialIndex < FlightDetailList.Count; materialIndex++)
                        //{
                        //    tempAirMaterial = (AirMaterial)FlightDetailList[materialIndex];

                        //    merchandiseIndex = int.Parse(tempAirMaterial.Profile.GetParam(Key_FlightMerchandisIndex).ToString());

                        //    if (merchandiseIndex == i)
                        //    {
                        //        tempAirMaterial.Profile.SetParam("VISITTED", true); //设置为已访问
                        //    }
                        //}


                    }
                }

                //TERMS.Business.Centers.ProductCenter.Profiles.AirProfile profile = (TERMS.Business.Centers.ProductCenter.Profiles.AirProfile)airMerchandise.Profile;
                //foreach (TERMS.Core.Product.ComponentGroup componentGroup in group)
                //{
                //    if (componentGroup.Items != null && componentGroup.Items.Count > 0)
                //    {
                //        foreach (AirMaterial airMaterial in componentGroup.Items)
                //        {
                //            airMerchandise.Add(airMaterial);
                //        }
                //    }
                //}

                tGoup.Profile.SetParam("SHOULD_CALL", true);

                BindAfterSelect(PageNumber2.CurrentPageIndex);



                runFlag.Value = "0";
            }
            else if (e.CommandName == "Avail" || e.CommandName == "BeAvail")
            {
                isClickAvailable = false;
                DoAvailableProcess(flightdetailIndex, tGoup);
                isClickAvailable = true;
            }
            //tonglanli 20080918
            else if (e.CommandName == "ContactAgt")
            {
                AnalyseContactAgt();
            }
            else if (e.CommandName == "NotAvail")
            {

            }

            else
            {
                SelectAirMaterial = tGoup;
                CurrentSession.OriginalIndex = flightdetailIndex;
                Response.Redirect("Step3_bulk.aspx");

            }


        }
    }

    //设置当前页号
    private void SetCurrentPageNumber()
    {
        HttpContext.Current.Session["Session_FlightPageNumber"] = PageNumber1.CurrentPageIndex;
    }

    private int GetCurrentPageNumber()
    {
        if ((HttpContext.Current.Request.UrlReferrer != null
                && HttpContext.Current.Request.UrlReferrer.AbsoluteUri != null
                && HttpContext.Current.Request.UrlReferrer.AbsoluteUri.ToLower().Contains("step3_confirm.aspx")))
        {
            if (HttpContext.Current.Session["Session_FlightPageNumber"] != null)
            {
                return int.Parse(HttpContext.Current.Session["Session_FlightPageNumber"].ToString());
            }

            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    private void DoErrorProcess(Exception ex)
    {
        string pageName = string.Empty;
        pageName = Request.Url.ToString().Split('/')[Request.Url.ToString().Split('/').Length - 1];

        Spring.Aspects.Error.SystemErrorAdvice systemErrorAdvice = new Spring.Aspects.Error.SystemErrorAdvice();
        systemErrorAdvice.DoErrorProcess(this, pageName, ex, "ApplicationError");
    }

    private void CopyMarkup(AirMerchandise copyFrom, AirMaterial copyTo)
    {
        //TERMS.Common.Markup newMarkup = new TERMS.Common.Markup();

        //newMarkup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(copyFrom.AdultMarkup));
        //newMarkup.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(copyFrom.ChildMarkup));
        //copyTo.Price.AddMarkup(newMarkup);

        //copyTo.SetAdultBaseFare(copyFrom.AdultBaseFare);
        //copyTo.SetAdultTax(copyFrom.AdultTax);
        //copyTo.SetChildBaseFare(copyFrom.ChildBaseFare);
        //copyTo.SetChildTax(copyFrom.ChildTax);
        if (copyFrom != null && copyFrom.Price != null && copyTo != null )
        {
            copyTo.Price = (Price)copyFrom.Price.Clone();
        }
    }

    private void GetAirBookingCondition(ref IList<TERMS.Business.Centers.SalesCenter.Passenger> passengers, AirMaterial airMaterial)
    {

        //AirMaterial newAirMaterial = new AirMaterial(airMaterial.Profile);
        //newAirMaterial.SetAdultBaseFare(airMaterial.AdultBaseFare);
        //newAirMaterial.SetChildBaseFare(airMaterial.ChildBaseFare);

        //TERMS.Common.Markup newMarkup = new TERMS.Common.Markup();

        //newMarkup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(airMaterial.AdultMarkup));
        //newMarkup.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(airMaterial.ChildMarkup));
        //newAirMaterial.Price.AddMarkup(newMarkup);

        //ADD PengZhaohui
        //newAirMaterial.SetAdultMarkup(airMaterial.AdultMarkup);
        //newAirMaterial.SetChildMarkup(airMaterial.ChildMarkup);
        //ADD END

        //int tourIndex = Convert.ToInt32(Request["selectedTour"].ToString());

        //AirMaterial airMaterial = (AirMaterial)airMaterial.Items[tourIndex];
        //newAirMaterial.AirTrip = airMaterial.AirTrip;

        AirOrderItem airOrderItem = new AirOrderItem(airMaterial);


        this.Transaction.CurrentTransactionObject.Items.Clear();
        this.Transaction.CurrentTransactionObject.AddItem(airOrderItem);

        SetPreBookingPassengers(airMaterial, ref passengers);
        //for (int i = 0; i < Convert.ToInt32(newAirMaterial.Profile.GetParam("ADULT_NUMBER")); i++)
        //{
        //    TERMS.Business.Centers.SalesCenter.Passenger passenger = new TERMS.Business.Centers.SalesCenter.Passenger(ProductConst.PASSFIRSTNAME, ProductConst.ADTPASSLASTNAME, ProductConst.PASSMIDDLENAME, TERMS.Common.PassengerType.Adult);
        //    passengers.Add(passenger);
        //}
        //for (int i = 0; i < Convert.ToInt32(newAirMaterial.Profile.GetParam("CHILD_NUMBER")); i++)
        //{
        //    TERMS.Business.Centers.SalesCenter.Passenger passenger = new TERMS.Business.Centers.SalesCenter.Passenger(ProductConst.PASSFIRSTNAME, ProductConst.CHDPASSLASTNAME, ProductConst.PASSMIDDLENAME, TERMS.Common.PassengerType.Child);
        //    passengers.Add(passenger);
        //}

    }

    private void SetPreBookingPassengers(AirMaterial airMaterial, ref IList<TERMS.Business.Centers.SalesCenter.Passenger> passengers)
    {

        for (int i = 0; i < Convert.ToInt32(airMaterial.Profile.GetParam("ADULT_NUMBER")); i++)
        {
            TERMS.Business.Centers.SalesCenter.Passenger passenger = new TERMS.Business.Centers.SalesCenter.Passenger(ProductConst.PASSFIRSTNAME, ProductConst.ADTPASSLASTNAME, ProductConst.PASSMIDDLENAME, TERMS.Common.PassengerType.Adult);

            passengers.Add(passenger);
        }
        for (int i = 0; i < Convert.ToInt32(airMaterial.Profile.GetParam("CHILD_NUMBER")); i++)
        {

            TERMS.Business.Centers.SalesCenter.Passenger passenger = new TERMS.Business.Centers.SalesCenter.Passenger(ProductConst.PASSFIRSTNAME, ProductConst.CHDPASSLASTNAME, ProductConst.PASSMIDDLENAME, TERMS.Common.PassengerType.Child);


            passengers.Add(passenger);
        }

    }

    private void AnalyseContactAgt()
    {
        AirContactAgentAdvice airContactAgentAdvice = new AirContactAgentAdvice();

        airContactAgentAdvice.CreateContactAgentLog(this);
    }



    /// <summary>
    /// PreRender Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Step2_PreRender(object sender, EventArgs e)
    {
        
    }

    protected void OnLoadComplete(object sender, EventArgs e)
    {
        if (filtered == true)
        {
            AjaxControlToolkit.ToolkitScriptManager.RegisterStartupScript(upAvailable, upAvailable.GetType(), "alt", "alert(document.getElementById('testClick'));if(this.location.href.indexOf('#') == -1){this.location.href+='#divAvailableFlight';} else(this.location.href= this.location.href.substring(0,this.location.href.indexOf('#')) + '#divAvailableFlight');", true);
            filtered = false;
        }
    }

    /// <summary>
    /// Control the compnent Regarding to the diff situation(CALL GTT) 
    /// </summary>
    /// <param name="e"></param>
    /// <param name="errMessage"></param>
    /// <param name="index"></param>
    private void DoCallGTTCompnent(DataListCommandEventArgs e, int index, Profile profile)
    {
        ImageButton btn_Sel = (ImageButton)e.Item.FindControl("btnSelect");
        btn_Sel.Visible = false;

        ImageButton btnNotAvail = (ImageButton)e.Item.FindControl("btnNotAvail");
        btnNotAvail.Visible = true;
        //btnNotAvail.Text = "CALL";
        btnNotAvail.Enabled = true;

        Panel p = (Panel)e.Item.FindControl("PopupMenu");
        Label lbl_ErrorMessage = (Label)e.Item.FindControl("lbl_ErrorMessage");
        //lbl_ErrorMessage.Text = Resources.HintInfo.PLEASECALL + CompanyName + Resources.HintInfo.FORDETAIL;
        profile.SetParam("ERR_MESSAGE", lbl_ErrorMessage.Text);

        p.Visible = true;
        runFlag.Value = "0";
    }

    private void ShowFlightByStop(MatrixStopType stopType)
    {
        List<Component> matixFlightList = null;

        matixFlightList = new AirLineMatricsManager().GetFlightListByStop(stopType);

        AvailableFlightList = matixFlightList;

        
        

        DoAfterFilter();



    }

    private void DoAfterFilter()
    {
        DoAfterAvailableRebind();

        DisplayBackToAllResultPanel();
    }

    private void DoAfterAvailableRebind()
    {
        //ScriptManager.RegisterStartupScript(upAvailable, this.GetType(), "alt", "if(this.location.href.indexOf('#') == -1){this.location.href+='#divAvailableFlight';} else(this.location.href= this.location.href.substring(0,this.location.href.indexOf('#')) + '#divAvailableFlight');", true);
        
        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alt", "SetOnfocus();", true);

        hfTabFlag.Value = "0";

        InitAvailablePageNumber(0, AvailableFlightList);

        //upAvailable.RenderMode = UpdatePanelRenderMode.Block;
        //upAvailable.Update();

        PageNumber1.RefreshDll();
        PageNumber1.Update();

        //AjaxControlToolkit.ToolkitScriptManager.RegisterStartupScript(upAvailable, upAvailable.GetType(), "alt", "alert(document.getElementById('testClick'));if(this.location.href.indexOf('#') == -1){this.location.href+='#divAvailableFlight';} else(this.location.href= this.location.href.substring(0,this.location.href.indexOf('#')) + '#divAvailableFlight');", true);
        //ScriptManager.RegisterStartupScript(upAvailable, this.GetType(), "alt", "alert(document.getElementById('testClick'));document.getElementById('testClick').click();", true);\

        upAvailable.Update();

        filtered = true;
        hfFilteredLoad.Value = "1";

        upFilterMessage.Update();
        //upAvailable.
    }

    protected void lnkOneStopTotal_OnClick(object sender, EventArgs e)
    {
        ShowFlightByStop(MatrixStopType.OneStop);
    }

    protected void lnkZeroStopTotal_OnClick(object sender, EventArgs e)
    {
        ShowFlightByStop(MatrixStopType.ZeroStop);
    }

    protected void lnkMoreThanTwoStopTotal_OnClick(object sender, EventArgs e)
    {
        ShowFlightByStop(MatrixStopType.MoreThanTwoStop);
    }

    protected void lbnAvailable_OnClick(object sender, EventArgs e)
    {
        ViewState["Tab"] = 1;
    }

    protected void lbnSelect_OnClick(object sender, EventArgs e)
    {
    }

    protected void lnkBackToAllResults_OnClick(object sender, EventArgs e)
    {
        ShowAllResult();
    }

    private void ShowAllResult()
    {
        AvailableFlightList = TotalAvailableFlightList;

        AirLineMatricsManager airManager = new AirLineMatricsManager();
        //排序
        AvailableFlightList = airManager.GetSortedList(AvailableFlightList, m_sortByFlag, m_sortFlag);

        DoAfterAvailableRebind();

        HiddenBackToAllResultPanel();
    }

    private void HiddenBackToAllResultPanel()
    {
        pnlBackToAllResults.Visible = false;
    }

    protected void lbShowAllAirlines_Click(object sender, EventArgs e)
    {
        AirMatrixList = AllAirMatrixList;
        BindAirMatrix();

        lbShowAllAirlines.Visible = false;
        lbHideMoreAirlines.Visible = true;
        upAirMatrix.Update();
    }

    protected void lbHiddenMoreAirlines_Click(object sender, EventArgs e)
    {
        AirMatrixList = new AirLineMatricsManager().GetShortedMatrixList(AllAirMatrixList);
        BindAirMatrix();

        lbShowAllAirlines.Visible = true;
        lbHideMoreAirlines.Visible = false;
        upAirMatrix.Update();
    }

    private void SortFlight(AirLineMatricsManager.SortByFlag sortbyFlag)
    {
        SetSortFlag(sortbyFlag);

        AvailableFlightList = GetSortedList(sortbyFlag);
        DoAvailableRebind();

        SetLinkBttonColor();
    }

    private void DoAvailableRebind()
    {
        InitAvailablePageNumber(0, AvailableFlightList);

        PageNumber1.RefreshDll();
        PageNumber1.Update();

        upAvailable.Update();

    }

    private void SetLinkBttonColor()
    {
        upSrotByMessage.Update();
        ScriptManager.RegisterStartupScript(upSrotByMessage, upSrotByMessage.GetType(), "alt", "<script>sortChangeColor(" + m_lb_Sort.ClientID + ");</script>", false);

    }

    private void SetSortFlag(AirLineMatricsManager.SortByFlag sortByFlag)
    {
        AirLineMatricsManager.SortFlag current_sortFlag = AirLineMatricsManager.SortFlag.None;
        m_sortByFlag = sortByFlag;

        switch (sortByFlag)
        {
            case AirLineMatricsManager.SortByFlag.Airline:

                current_sortFlag = m_sortFlag_Airline;
                SetSortUpDownFlag(ref m_sortFlag_Airline, current_sortFlag);

                SetImageUpDownVisible(lb_sortAirline, img_airlineUp, img_airlineDown, m_sortFlag_Airline);

                //l

                break;

            case AirLineMatricsManager.SortByFlag.ArrivalDate:

                current_sortFlag = m_sortFlag_Airline;
                SetSortUpDownFlag(ref m_sortFlag_Arrival, current_sortFlag);

                SetImageUpDownVisible(lb_sortArrival, img_arrivalUp, img_arrivalDown, m_sortFlag_Airline);

                break;

            case AirLineMatricsManager.SortByFlag.DepartureDate:

                current_sortFlag = m_sortFlag_Departure;
                SetSortUpDownFlag(ref m_sortFlag_Departure, current_sortFlag);

                SetImageUpDownVisible(lb_sortDeparture, img_departureUp, img_departureDown, m_sortFlag_Departure);

                break;
            case AirLineMatricsManager.SortByFlag.Price:

                current_sortFlag = m_sortFlag_Price;
                SetSortUpDownFlag(ref m_sortFlag_Price, current_sortFlag);

                SetImageUpDownVisible(lb_sortPrice, img_priceUp, img_priceDown, m_sortFlag_Price);

                break;

            case AirLineMatricsManager.SortByFlag.Duration:

                current_sortFlag = m_sortFlag_Duration;
                SetSortUpDownFlag(ref m_sortFlag_Duration, current_sortFlag);

                SetImageUpDownVisible(lb_sortDuration, img_DurationUp, img_DurationDown, m_sortFlag_Duration);

                break;
        }
    }

    private static Color m_defaultColor;
    private const string DEFAULT_COLOR = "#3366CC";
    private const string CLICK_COLOR = "#3366CC";

    private static LinkButton m_lb_Sort;

    private void SetImageUpDownVisible(LinkButton lb_sort, System.Web.UI.WebControls.Image img_Up, System.Web.UI.WebControls.Image img_Down, AirLineMatricsManager.SortFlag sortFlag)
    {
        m_lb_Sort = lb_sort;

        img_airlineUp.Visible = false;
        img_airlineDown.Visible = false;
        img_arrivalUp.Visible = false;
        img_arrivalDown.Visible = false;
        img_departureUp.Visible = false;
        img_departureDown.Visible = false;
        img_priceUp.Visible = false;
        img_priceDown.Visible = false;
        img_DurationUp.Visible = false;
        img_DurationDown.Visible = false;

        List<LinkButton> lbList = new List<LinkButton>();
        lbList.Add(lb_sortAirline);
        lbList.Add(lb_sortDeparture);
        lbList.Add(lb_sortDuration);
        lbList.Add(lb_sortPrice);
        lbList.Add(lb_sortArrival);

        foreach (LinkButton linkButton in lbList)
        {
            //linkButton.Style["color"] = DEFAULT_COLOR;
        }

        //lb_sort.Style["color"] = "#FF3300";

        switch (sortFlag)
        {
            case AirLineMatricsManager.SortFlag.Asc:
                img_Up.Visible = true;
                img_Down.Visible = false;
                break;

            case AirLineMatricsManager.SortFlag.Desc:
                img_Up.Visible = false;
                img_Down.Visible = true;
                break;
        }
    }

    private void SetSortUpDownFlag(ref AirLineMatricsManager.SortFlag sortFlag, AirLineMatricsManager.SortFlag current_sortFlag)
    {
        m_sortFlag_Airline = AirLineMatricsManager.SortFlag.None;
        m_sortFlag_Arrival = AirLineMatricsManager.SortFlag.None;
        m_sortFlag_Departure = AirLineMatricsManager.SortFlag.None;
        m_sortFlag_Price = AirLineMatricsManager.SortFlag.None;
        m_sortFlag_Duration = AirLineMatricsManager.SortFlag.None;

        switch (current_sortFlag)
        {
            case AirLineMatricsManager.SortFlag.None:
                sortFlag = AirLineMatricsManager.SortFlag.Asc;
                break;

            case AirLineMatricsManager.SortFlag.Asc:
                sortFlag = AirLineMatricsManager.SortFlag.Desc;
                break;

            case AirLineMatricsManager.SortFlag.Desc:
                sortFlag = AirLineMatricsManager.SortFlag.Asc;
                break;
        }

        m_sortFlag = sortFlag;
    }

    private static AirLineMatricsManager.SortByFlag m_sortByFlag;
    private static AirLineMatricsManager.SortFlag m_sortFlag;
    private static AirLineMatricsManager.SortFlag m_sortFlag_Airline;
    private static AirLineMatricsManager.SortFlag m_sortFlag_Price;
    private static AirLineMatricsManager.SortFlag m_sortFlag_Duration;
    private static AirLineMatricsManager.SortFlag m_sortFlag_Departure;
    private static AirLineMatricsManager.SortFlag m_sortFlag_Arrival;

    private List<Component> GetSortedList(AirLineMatricsManager.SortByFlag sortbyFlag)
    {
        AirLineMatricsManager airLineMatricsManager = new AirLineMatricsManager();
        List<Component> sortedList = null;

        sortedList = airLineMatricsManager.GetSortedList(AvailableFlightList, sortbyFlag, m_sortFlag);

        return sortedList;
    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        if (this.txtName.Text.Trim().Length > 0 && this.txtPhone.Text.Trim().Length > 0 && this.txtEmail.Text.Trim().Length > 0)
        {
            string RegularExpressions = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            Match m = Regex.Match(this.txtEmail.Text, RegularExpressions);

            if (m.Success)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The mail address pattern is wrong');</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>OnSearch();</script>");
            }

            
        }
    }

    protected void dlAirlineMatricsCopy_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
        {
            AirMatrixFlightMeta currentMatrix = null;
            string airlineCode = string.Empty;

            currentMatrix = (AirMatrixFlightMeta)e.Item.DataItem;
            airlineCode = currentMatrix.AirLine.Code;

            //AirLineImage
            //System.Web.UI.WebControls.Image imgAirline = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgAirlineCopy");
            //imgAirline.ImageUrl = GetImageUrl(airlineCode);

            //Set0Empty

            System.Web.UI.WebControls.Label lnbZeroBase = (System.Web.UI.WebControls.Label)e.Item.FindControl("lnbZeroBaseCopy");
            System.Web.UI.WebControls.Label lblZeroStopPrice = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblZeroStopPriceCopy");
            if (currentMatrix.ZeroStopPrice.BaseFare == 0)
            {
                lnbZeroBase.Text = "&nbsp;";
                lnbZeroBase.Visible = false;
                lblZeroStopPrice.Text = "&nbsp;";
            }

            System.Web.UI.WebControls.Label lnbOneBase = (System.Web.UI.WebControls.Label)e.Item.FindControl("lnbOneBaseCopy");
            System.Web.UI.WebControls.Label lblSpaceOneStopPrice = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblSpaceOneStopPriceCopy");
            if (currentMatrix.OneStopPrice.BaseFare == 0)
            {
                lnbOneBase.Text = "&nbsp;";
                lnbOneBase.Visible = false;
                lblSpaceOneStopPrice.Text = "&nbsp;";
            }

            System.Web.UI.WebControls.Label lnbTwoMoreBase = (System.Web.UI.WebControls.Label)e.Item.FindControl("lnbTwoMoreBaseCopy");
            System.Web.UI.WebControls.Label lblSpaceMoreThanTwoStopPrice = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblSpaceMoreThanTwoStopPriceCopy");
            if (currentMatrix.MoreThanTwoStopPrice.BaseFare == 0)
            {
                lnbTwoMoreBase.Text = "&nbsp;";
                lnbTwoMoreBase.Visible = false;
                lblSpaceMoreThanTwoStopPrice.Text = "&nbsp;";
            }

            System.Web.UI.WebControls.Label lblLowFareSelect = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblLowFareSelectCopy");
            System.Web.UI.WebControls.Label lblSpaceSelect = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblSpaceSelectCopy");
            System.Web.UI.WebControls.Label lblLowFareSelectTooltip = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblLowFareSelectTooltipCopy");
            System.Web.UI.WebControls.Label lnbSelect = (System.Web.UI.WebControls.Label)e.Item.FindControl("lnbSelect");
            if (currentMatrix.LowFareSelectPrice.BaseFare == 0)
            {
                lblLowFareSelect.Text = "&nbsp;";
                lblLowFareSelect.Visible = false;
                lblSpaceSelect.Text = "&nbsp;";
                lblLowFareSelectTooltip.Visible = false;
                lnbSelect.Visible = false;
            }

            //在最后一条记录时，判断最小值，设置红色粗体样式。
            if (e.Item.ItemIndex == AirMatrixList.Count - 1)
            {
                //取得最小值的Item
                DataListItem lowestSelectFareItem = GetLowestSelectFareItem(e.Item);

                if (lowestSelectFareItem == null && ((AirMatrixFlightMeta)e.Item.DataItem).LowFareSelectPrice.BaseFare != 0)
                {
                    lowestSelectFareItem = e.Item;
                }

                if (lowestSelectFareItem != null)
                {
                    //找到Select控件
                    lnbSelect = (System.Web.UI.WebControls.Label)lowestSelectFareItem.FindControl("lnbSelect");

                    if (lnbSelect.Visible != false)
                    {
                        //添加样式
                        lnbSelect.Style.Add("color", "Red");
                        lnbSelect.Style.Add("font-weight", "bold");
                    }
                }

            }
        }
    }
}
