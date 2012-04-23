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
//using TERMS.Common;
using Terms.Sales.Business;
using TERMS.Common;
using System.Web.Services;
using AjaxControlToolkit;
using Terms.Base.Service;
using Spring.Context;
using Spring.Context.Support;
using Terms.Configuration.Domain;
using Spring.Aspects.AirOperate;
using TERMS.Business.Centers.ProductCenter.Profiles;
using System.IO;

public partial class TourBookingPage : Spring.Web.UI.MasterPage
{
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

    private IAdvertiseService m_AdvertiseService;
    public IAdvertiseService AdvertiseService
    {
        set
        {
            m_AdvertiseService = value;
        }
    }

    private ITopDestinationsDetailConfigService m_TopDestinationsDetailConfigService;
    public ITopDestinationsDetailConfigService TopDestinationsDetailConfigService
    {
        set
        {
            m_TopDestinationsDetailConfigService = value;
        }
    }

    private ICommonService m_CommonService;

    public ICommonService CommonService
    {
        set
        {
            m_CommonService = value;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentWebSite == null) return;

        if (CurrentWebSite.Id != Guid.Empty)
        {
            ConfigurationSettings.AppSettings.Set(WebSiteName, CurrentWebSite.Name);
        }

        if (Utility.IsSearchConditionNull)
        {
            Response.Redirect("~/Page/Common/ErrorMessage.aspx");
        }

        depCalendar.Path  ="../../";
       
        Header1.Path = "../../";

        InitStepBar();

        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (Utility.Transaction.CurrentSearchConditions != null)
        {
            if (!IsPostBack)
            {
                BindAdvertise();
                BindMostPopular();
                BindDeparturePlace();

                if (Request["IsSkip"] != null && Request["IsSkip"] == "Y")
                {
                    ClearSession();
                }


                phModifySearch.Visible = m_isShowModifySearch;

                this.btn_Search.ValidationGroup = "TourSearch";

                ((TextBox)this.depCalendar.FindControl("calendarDate")).CssClass = "search_inp";
                TourSearchCondition tourSearchCondition = (TourSearchCondition)Transaction.CurrentSearchConditions;
                cddArea.SelectedValue = tourSearchCondition.Region;
                cddCountry.SelectedValue = tourSearchCondition.Counrty;

                cddCity.SelectedValue = tourSearchCondition.City;



                TextBox depTourCalendar = (TextBox)this.depCalendar.FindControl("calendarDate");

                depTourCalendar.Text = tourSearchCondition.TravelBeginDate.ToString("d", DateTimeFormatInfo.InvariantInfo);

                if (tourSearchCondition.IsLandOnly)
                {
                    rdbLandOnly.Checked = true;

                }
                else
                {
                    rdbAirLand.Checked = true;

                }

                switch (tourSearchCondition.TravelDaysTo + tourSearchCondition.TravelDaysFrom)
                {
                    case 11: ddlTravelDate.SelectedIndex = 0; break;
                    case 26: ddlTravelDate.SelectedIndex = 1; break;
                    case 816: ddlTravelDate.SelectedIndex = 2; break;
                    default: ddlTravelDate.SelectedIndex = 3; break;
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

    public virtual bool DeparturePlace
    {
        set
        {
            this.tbDeparturePlace.Visible = value;
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
                            url = "Step2.aspx";
                            break;
                        case 3:
                            //if (((AirComponentGroup)((OrderMerchandise)Transaction.CurrentTransactionObject.Items[0]).Merchandise.ComponentGroup.Items[0].Component).FareType == FlightFareType.COMM ||
                            //    ((AirComponentGroup)((OrderMerchandise)Transaction.CurrentTransactionObject.Items[0]).Merchandise.ComponentGroup.Items[0].Component).FareType == FlightFareType.NET)
                            //{
                            //    url = "Step3_net.aspx";
                            //}
                            //else
                            //{
                            //    url = "Step3_bulk.aspx";
                            //}
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
                //sessonClass.OriginalSearchResults = new ComponentGroup( new AirProfile());
                //sessonClass.SecondSearchResults = new Hashtable();
                sessonClass.CurrentItinerary = new Itinerary();
                //sessonClass.CurrentAirBooking = new AirBooking();
                break;
            case 2:
                //sessonClass.CurrentItinerary.FlightInfo = new AirTrip();
                //sessonClass.CurrentItinerary.FareInfo = new Fare();
                //sessonClass.SelectedResult = new ComponentGroup(new Profile());
                break;
            case 3:
                //sessonClass.CurrentItinerary.FlightInfo = new AirTrip();
                //if (((AirComponentGroup)((OrderMerchandise)Transaction.CurrentTransactionObject.Items[0]).Merchandise.ComponentGroup.Items[0].Component).FareType == Terms.Product.Utility.FlightFareType.NET ||
                //    ((AirComponentGroup)((OrderMerchandise)Transaction.CurrentTransactionObject.Items[0]).Merchandise.ComponentGroup.Items[0].Component).FareType == FlightFareType.COMM)
                //{
                //    sessonClass.CurrentItinerary.FareInfo = new Fare(); ;
                //}
                //SaleMerchandise saleMerchandise = new SaleMerchandise();
                //saleMerchandise.ComponentGroup = new ComponentGroup(new Profile());
                //Transaction.CurrentTransactionObject.Items.Clear();
                //Transaction.CurrentTransactionObject.AddItem(saleMerchandise);


                break;
            case 4:
                break;
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
        if (this.depCalendar.CDate == "__/__/____" || this.depCalendar.CDate == "")
        {
            this.lblMsg.Visible = true;
            return;
        }

        //log begin 20090312 Leon
        PageUtility.TourSearchingTimeLog.Info("\r\n");

        if (!Utility.IsLogin)
            PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >====================Not Login========================");
        else
            PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >==========================Login========================");

        PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >Tour Searching(1) Begin at: " + System.DateTime.Now);

        //log end 20090312 Leon

        TourSearchCondition tourSearchCondition = new TourSearchCondition();
        tourSearchCondition.Region = this.ddlArea_T.SelectedValue.ToString();
        tourSearchCondition.Counrty = this.ddlCountry_T.SelectedValue.ToString();
        tourSearchCondition.City = this.ddlCity_T.SelectedValue.ToString();
        if (rdbAirLand.Checked == true)
        {
            tourSearchCondition.IsLandOnly = false;
        }
        else
        {
            tourSearchCondition.IsLandOnly = true;
        }
        tourSearchCondition.TravelBeginDate = GlobalUtility.GetDateTime(depCalendar.CDate.Trim());

        switch (ddlTravelDate.SelectedIndex)
        {
            case 0: tourSearchCondition.TravelDaysFrom = 1;
                tourSearchCondition.TravelDaysTo = 10;
                break;
            case 1: tourSearchCondition.TravelDaysFrom = 11;
                tourSearchCondition.TravelDaysTo = 15;
                break;
            case 2: tourSearchCondition.TravelDaysFrom = 16;
                tourSearchCondition.TravelDaysTo = 800;
                break;
            default:
                tourSearchCondition.TravelDaysFrom = 1;
                tourSearchCondition.TravelDaysTo = 800;
                break;
        }
        Utility.IsTourMain = false;//设置是否是Tour标志
        Utility.IsTourMore = false;//设置是否是Tour More
        this.Transaction.IntKey = tourSearchCondition.GetHashCode();
        this.Transaction.CurrentSearchConditions = tourSearchCondition;
        this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

        if (tourSearchCondition.TravelBeginDate < DateTime.Now.AddDays(3))
        {
            List<TourErrorMsg> errors = new List<TourErrorMsg>();

            TourErrorMsg error1 = new TourErrorMsg();
            errors.Add(error1);
            TourErrorMsg error2 = new TourErrorMsg();
            errors.Add(error2);
            TourErrorMsg error3 = new TourErrorMsg();
            errors.Add(error3);
            TourErrorMsg error4 = new TourErrorMsg();
            error4.IsError = true;
            error4.ErrorMsg = Resources.HintInfo.Tour_Error5;
            errors.Add(error4);

            Session["ErrorMsg"] = errors;
            Response.Redirect("~/Page/Tour/SearchConditionsMeassageTForm.aspx");
        }
        //记录Search Tour事件
        OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchTour, this);
        Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlDecode(tourSearchCondition.Region) + "&target=~/Page/Tour/TourMoreSearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
       
    }
    protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        //RefreshAmount();
        //ShowAmounts();
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

    public string TopDes
    {
        get
        {
            if (Request["TopDestinations"] != null)
                return Request["TopDestinations"].Trim();

            return string.Empty;
        }
    }

    private void BindAdvertise()
    {
        IList list = null;

        if (string.IsNullOrEmpty(TopDes))
        {
            phAdvertise.Visible = true;

            string starCity = string.Empty;

            if (SelectTourCode != string.Empty)
            {
                starCity = ((TourProfile)SelectTourMaterial.Profile).StartCity.Code;
            }
            else
            {
                if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
                {
                    TourMaterial tourmaterial = (TourMaterial)tourMerchandise.Items[0];

                    starCity = ((TourProfile)tourmaterial.Profile).StartCity.Code;
                }
            }

            list = m_TopDestinationsDetailConfigService.FindByCityCode(starCity);
        }
        else
        {
            phAdvertise.Visible = true;

            list = m_TopDestinationsDetailConfigService.FindByID(new Guid(TopDes));            
        }

        if (list != null && list.Count > 0)
        {
            Guid masterid = ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)list[0]).Masterid.Id;

            IList Advertises = m_AdvertiseService.FindByMasterId(masterid);

            if (Advertises != null && Advertises.Count > 0)
            {
                rpAdvertise.DataSource = Advertises;
                rpAdvertise.DataBind();

                for (int i = 0; i < rpAdvertise.Items.Count; i++)
                {
                    System.Web.UI.WebControls.Image imgbtn = (System.Web.UI.WebControls.Image)rpAdvertise.Items[i].FindControl("imgbtnAdvertise");
                    System.Web.UI.HtmlControls.HtmlAnchor aAdvertise = (System.Web.UI.HtmlControls.HtmlAnchor)rpAdvertise.Items[i].FindControl("aAdvertise");

                    imgbtn.ImageUrl = ((Terms.Sales.Domain.AdvertiseMeta)Advertises[i]).ImageLine;
                    //imgbtn.PostBackUrl = ((Terms.Sales.Domain.AdvertiseMeta)Advertises[i]).UrlLine;
                    aAdvertise.HRef = ((Terms.Sales.Domain.AdvertiseMeta)Advertises[i]).UrlLine;
                }
            }
        }
    }

    public TourMerchandise tourMerchandise
    {
        get
        {
            SalseBasePage salsebasepage = new SalseBasePage();

            return (TourMerchandise)salsebasepage.OnSearch();
        }

    }

    public string SelectTourCode
    {
        get
        {
            if (Request["TourCode"] != null)
                return Request["TourCode"].Trim().ToLower();
            else
                return string.Empty;
        }
    }

    private TourMaterial _tourmaterial = null;
    public TourMaterial SelectTourMaterial
    {
        get
        {
            if (_tourmaterial == null || ((TourProfile)_tourmaterial.Profile).Code.Trim().ToLower() != SelectTourCode)
            {
                if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.Items.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.Items[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            _tourmaterial = (TourMaterial)tourMerchandise.Items[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return _tourmaterial;
        }
    }

    private void BindMostPopular()
    {
        IList list = null;

        if (string.IsNullOrEmpty(TopDes))
        {
            string starCity = string.Empty;

            if (SelectTourCode != string.Empty)
            {
                starCity = ((TourProfile)SelectTourMaterial.Profile).StartCity.Code;
            }
            else
            {
                if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
                {
                    TourMaterial tourmaterial = (TourMaterial)tourMerchandise.Items[0];

                    starCity = ((TourProfile)tourmaterial.Profile).StartCity.Code;
                }
            }

            list = m_TopDestinationsDetailConfigService.FindByCityCode(starCity);

            if (this.Request.QueryString["CityCode"] == null)
            {
                string[] requests = new string[this.Request.QueryString.Count + 1];

                for (int i = 0; i < this.Request.QueryString.Count; i++)
                {
                    requests[i] = this.Request.QueryString.AllKeys[i] + "=" + this.Request.QueryString[i];
                }

                requests[requests.Length - 1] = "&CityCode=" + starCity;

                string request = string.Join(@"&", requests);

                //this.Response.Redirect("NewTourMoreSearchResultForm.aspx?" + request);
            }
        }
        else
        {
            list = m_TopDestinationsDetailConfigService.FindByID(new Guid(TopDes));            
        }

        if (list != null && list.Count > 0)
        {
            Guid masterid = ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)list[0]).Masterid.Id;

            IList Masters = m_TopDestinationsDetailConfigService.FindByMasterId(masterid);

            if (Masters != null && Masters.Count > 0)
            {
                for (int i = 0; i < Masters.Count; i++)
                {
                    if (((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)Masters[i]).Id == ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)list[0]).Id)
                    {
                        Masters.Remove(Masters[i]);
                        break;
                    }
                }

                rpMostPopular.DataSource = Masters;
                rpMostPopular.DataBind();

                for (int i = 0; i < Masters.Count; i++)
                {
                    LinkButton lblName = (LinkButton)rpMostPopular.Items[i].FindControl("lblName");
                    Label lblLine = (Label)rpMostPopular.Items[i].FindControl("lblLine");
                    Label lblID = (Label)rpMostPopular.Items[i].FindControl("lblID");
                    System.Web.UI.WebControls.Image imgMost = (System.Web.UI.WebControls.Image)rpMostPopular.Items[i].FindControl("imgMost");
                    System.Web.UI.HtmlControls.HtmlGenericControl hrCCCCC = (System.Web.UI.HtmlControls.HtmlGenericControl)rpMostPopular.Items[i].FindControl("hrCCCCC");
                    if (UserCulture.Name.Contains("zh-CN"))
                        lblName.Text = ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)Masters[i]).DetailCN;
                    else
                        lblName.Text = ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)Masters[i]).DetailEN;
                    lblLine.Text = ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)Masters[i]).DetailLine;
                    lblID.Text = ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)Masters[i]).Id.ToString();
                    imgMost.ImageUrl = ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)Masters[i]).ReduceImage;
                    if (i == Masters.Count - 1)
                        hrCCCCC.Visible = false;

                    if (((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)Masters[i]).TourCode1 == null || ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)Masters[i]).TourCode2 == null)
                        continue;

                    Label lblTourCode1 = (Label)rpMostPopular.Items[i].FindControl("lblTourCode1");
                    Label lblTourCode2 = (Label)rpMostPopular.Items[i].FindControl("lblTourCode2");

                    string TourCodes = ((Terms.Sales.Domain.TopDestinationsDetailConfigMeta)Masters[i]).TourCode1.Trim().Replace(@",", @";");

                    string[] listTourCode = TourCodes.Split(new char[] { ';' });

                    if (listTourCode.Length > 0)
                    {
                        if (listTourCode.Length == 2)
                        {
                            lblTourCode1.Text = listTourCode[0];
                            lblTourCode2.Text = listTourCode[1];
                        }
                        if (listTourCode.Length == 1)
                        {
                            lblTourCode1.Text = listTourCode[0];
                        }
                    }

                    MVMerchandiseSearcher mvmerchandisesearcher = new MVMerchandiseSearcher();

                    TourMerchandise merchandiseTour1 = mvmerchandisesearcher.SearchTourByTourCode(lblTourCode1.Text, UserCulture.Name);
                    TourMerchandise merchandiseTour2 = mvmerchandisesearcher.SearchTourByTourCode(lblTourCode2.Text, UserCulture.Name);

                    if (merchandiseTour1 != null && merchandiseTour1.Items != null && merchandiseTour1.Items.Count > 0)
                    {
                        TourMaterial tm = (TourMaterial)merchandiseTour1.Items[0];

                        TourProfile tourProfile = (TourProfile)tm.Profile;
                        LinkButton imgbtnCity1 = (LinkButton)rpMostPopular.Items[i].FindControl("imgbtnCity1");
                        LinkButton imgbtnPrice1 = (LinkButton)rpMostPopular.Items[i].FindControl("imgbtnPrice1");
                        imgbtnCity1.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).StartCity.Name;
                        imgbtnPrice1.Text = "From $" + ((Terms.Product.Business.MVTourProfile)tourProfile).StartFromLandOnlyFare.ToString("#,###");

                        Label lblCityCode1 = (Label)rpMostPopular.Items[i].FindControl("lblCityCode1");
                        Label lblPrice1 = (Label)rpMostPopular.Items[i].FindControl("lblPrice1");

                        lblCityCode1.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).StartCity.Code;
                        lblPrice1.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).StartFromLandOnlyFare.ToString();
                    }

                    if (merchandiseTour2 != null && merchandiseTour2.Items != null && merchandiseTour2.Items.Count > 0)
                    {
                        TourMaterial tm = (TourMaterial)merchandiseTour2.Items[0];

                        TourProfile tourProfile = (TourProfile)tm.Profile;

                        LinkButton imgbtnCity2 = (LinkButton)rpMostPopular.Items[i].FindControl("imgbtnCity2");
                        LinkButton imgbtnPrice2 = (LinkButton)rpMostPopular.Items[i].FindControl("imgbtnPrice2");
                        imgbtnCity2.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).StartCity.Name;
                        imgbtnPrice2.Text = "From $" + ((Terms.Product.Business.MVTourProfile)tourProfile).StartFromLandOnlyFare.ToString("#,###");

                        Label lblCityCode2 = (Label)rpMostPopular.Items[i].FindControl("lblCityCode2");
                        Label lblPrice2 = (Label)rpMostPopular.Items[i].FindControl("lblPrice2");
                        lblCityCode2.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).StartCity.Code;
                        lblPrice2.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).StartFromLandOnlyFare.ToString();
                    }
                }
            }
        }
    }

    private void BindDeparturePlace()
    {
        List<string> CityCodes = new List<string>();
        List<string> CityNames = new List<string>();

        if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
        {
            for (int i = 0; i < tourMerchandise.Items.Count; i++)
            {
                TourMaterial tourmaterial = (TourMaterial)tourMerchandise.Items[i];

                string CityCode = ((TourProfile)tourmaterial.Profile).StartCity.Code;
                string CityName = ((TourProfile)tourmaterial.Profile).StartCity.Name;

                if (!CityCodes.Contains(CityCode) && ExceptionViewCode(((TourProfile)tourmaterial.Profile).Code))
                {
                    CityCodes.Add(CityCode);
                    CityNames.Add(CityName);
                }
            }

            if (CityCodes.Count > 0)
            {
                rpDeparturePlace.DataSource = CityCodes;
                rpDeparturePlace.DataBind();

                for (int i = 0; i < rpDeparturePlace.Items.Count; i++)
                {
                    RepeaterItem item = rpDeparturePlace.Items[i];

                    HyperLink hl = (HyperLink)item.FindControl("hlDeparturePlace");

                    hl.Text = CityNames[i];

                    hl.NavigateUrl = @"~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode("U.S.") + "&ConditionID=" + Utility.Transaction.IntKey.ToString() + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm" + "&CityCode=" + CityCodes[i];
                }
            }
        }
    }

    private bool ExceptionViewCode(string tourcode)
    {
        string filePath = string.Empty;

        string codes = string.Empty;

        bool flag = true;

        filePath = @"/Config/TourExceptionViewCode.xml";

        if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + filePath))
        {
            DataSet ds = new DataSet();

            ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + filePath);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                codes = ds.Tables[0].Rows[0]["EN"].ToString();

                List<string> codeList = new List<string>();

                codeList.AddRange(codes.Split(new char[] { ',' }));

                if (codeList.Contains(tourcode))
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
        }

        return flag;
    }

    protected void rpMostPopular_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Label lblLine = (Label)e.Item.FindControl("lblLine");

            if (!string.IsNullOrEmpty(lblLine.Text.Trim()))
            {
                string citys = lblLine.Text.Trim().Replace(@",", @";");

                string[] Citys = citys.Split(new char[] { ';' });

                List<string> listCity = new List<string>();

                for (int i = 0; i < Citys.Length; i++)
                {
                    listCity.Add(Citys[i]);
                }

                string city = listCity[0];

                Terms.Common.Domain.City City = m_CommonService.FindCityByCityCode(city);

                if (City != null)
                {
                    Label lblID = (Label)e.Item.FindControl("lblID");

                    Utility.TourCitys = listCity;
                    Utility.IsTourMain = true;
                    Utility.IsTourMore = true;

                    TourSearchCondition tourSearchCondition = new TourSearchCondition();
                    tourSearchCondition.Region = "U.S.";
                    tourSearchCondition.Counrty = City.CountryCode;
                    tourSearchCondition.CityList = listCity;
                    tourSearchCondition.City = city;
                    tourSearchCondition.DeptCity = city;
                    tourSearchCondition.IsLandOnly = true;
                    tourSearchCondition.PriceType = TERMS.Common.TourPriceType.All;
                    tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
                    tourSearchCondition.TravelDaysFrom = 1;
                    tourSearchCondition.TravelDaysTo = 800;
                    this.Transaction.IntKey = tourSearchCondition.GetHashCode();
                    this.Transaction.CurrentSearchConditions = tourSearchCondition;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                    //记录Search More事件
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchMoreTour, this);
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode("U.S.") + "&ConditionID=" + Utility.Transaction.IntKey.ToString() + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm" + "&TopDestinations=" + lblID.Text);
                }
            }
        }

        if (e.CommandName == "CityCode1")
        {
            Label lblLine = (Label)e.Item.FindControl("lblLine");

            if (!string.IsNullOrEmpty(lblLine.Text.Trim()))
            {
                string citys = lblLine.Text.Trim().Replace(@",", @";");

                string[] Citys = citys.Split(new char[] { ';' });

                List<string> listCity = new List<string>();

                for (int i = 0; i < Citys.Length; i++)
                {
                    listCity.Add(Citys[i]);
                }

                string city = listCity[0];

                Terms.Common.Domain.City City = m_CommonService.FindCityByCityCode(city);

                if (City != null)
                {
                    Label lblID = (Label)e.Item.FindControl("lblID");
                    Label lblCityCode1 = (Label)e.Item.FindControl("lblCityCode1");

                    Utility.TourCitys = listCity;
                    Utility.IsTourMain = true;
                    Utility.IsTourMore = true;

                    TourSearchCondition tourSearchCondition = new TourSearchCondition();
                    tourSearchCondition.Region = "U.S.";
                    tourSearchCondition.Counrty = City.CountryCode;
                    tourSearchCondition.CityList = listCity;
                    tourSearchCondition.City = city;
                    tourSearchCondition.DeptCity = city;
                    tourSearchCondition.IsLandOnly = true;
                    tourSearchCondition.PriceType = TERMS.Common.TourPriceType.All;
                    tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
                    tourSearchCondition.TravelDaysFrom = 1;
                    tourSearchCondition.TravelDaysTo = 800;
                    this.Transaction.IntKey = tourSearchCondition.GetHashCode();
                    this.Transaction.CurrentSearchConditions = tourSearchCondition;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                    //记录Search More事件
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchMoreTour, this);
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode("U.S.") + "&ConditionID=" + Utility.Transaction.IntKey.ToString() + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm" + "&TopDestinations=" + lblID.Text + "&CityCode=" + lblCityCode1.Text);
                }
            }
        }

        if (e.CommandName == "Price1")
        {
            Label lblLine = (Label)e.Item.FindControl("lblLine");

            if (!string.IsNullOrEmpty(lblLine.Text.Trim()))
            {
                string citys = lblLine.Text.Trim().Replace(@",", @";");

                string[] Citys = citys.Split(new char[] { ';' });

                List<string> listCity = new List<string>();

                for (int i = 0; i < Citys.Length; i++)
                {
                    listCity.Add(Citys[i]);
                }

                string city = listCity[0];

                Terms.Common.Domain.City City = m_CommonService.FindCityByCityCode(city);

                if (City != null)
                {
                    Label lblID = (Label)e.Item.FindControl("lblID");

                    Label lblPrice1 = (Label)e.Item.FindControl("lblPrice1");

                    Utility.TourCitys = listCity;
                    Utility.IsTourMain = true;
                    Utility.IsTourMore = true;

                    TourSearchCondition tourSearchCondition = new TourSearchCondition();
                    tourSearchCondition.Region = "U.S.";
                    tourSearchCondition.Counrty = City.CountryCode;
                    tourSearchCondition.CityList = listCity;
                    tourSearchCondition.City = city;
                    tourSearchCondition.DeptCity = city;
                    tourSearchCondition.IsLandOnly = true;
                    tourSearchCondition.PriceType = TERMS.Common.TourPriceType.All;
                    tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
                    tourSearchCondition.TravelDaysFrom = 1;
                    tourSearchCondition.TravelDaysTo = 800;
                    this.Transaction.IntKey = tourSearchCondition.GetHashCode();
                    this.Transaction.CurrentSearchConditions = tourSearchCondition;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                    //记录Search More事件
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchMoreTour, this);
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode("U.S.") + "&ConditionID=" + Utility.Transaction.IntKey.ToString() + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm" + "&TopDestinations=" + lblID.Text + "&Price=" + lblPrice1.Text);
                }
            }
        }
        if (e.CommandName == "CityCode2")
        {
            Label lblLine = (Label)e.Item.FindControl("lblLine");

            if (!string.IsNullOrEmpty(lblLine.Text.Trim()))
            {
                string citys = lblLine.Text.Trim().Replace(@",", @";");

                string[] Citys = citys.Split(new char[] { ';' });

                List<string> listCity = new List<string>();

                for (int i = 0; i < Citys.Length; i++)
                {
                    listCity.Add(Citys[i]);
                }

                string city = listCity[0];

                Terms.Common.Domain.City City = m_CommonService.FindCityByCityCode(city);

                if (City != null)
                {
                    Label lblID = (Label)e.Item.FindControl("lblID");
                    Label lblCityCode2 = (Label)e.Item.FindControl("lblCityCode2");

                    Utility.TourCitys = listCity;
                    Utility.IsTourMain = true;
                    Utility.IsTourMore = true;

                    TourSearchCondition tourSearchCondition = new TourSearchCondition();
                    tourSearchCondition.Region = "U.S.";
                    tourSearchCondition.Counrty = City.CountryCode;
                    tourSearchCondition.CityList = listCity;
                    tourSearchCondition.City = city;
                    tourSearchCondition.DeptCity = city;
                    tourSearchCondition.IsLandOnly = true;
                    tourSearchCondition.PriceType = TERMS.Common.TourPriceType.All;
                    tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
                    tourSearchCondition.TravelDaysFrom = 1;
                    tourSearchCondition.TravelDaysTo = 800;
                    this.Transaction.IntKey = tourSearchCondition.GetHashCode();
                    this.Transaction.CurrentSearchConditions = tourSearchCondition;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                    //记录Search More事件
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchMoreTour, this);
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode("U.S.") + "&ConditionID=" + Utility.Transaction.IntKey.ToString() + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm" + "&TopDestinations=" + lblID.Text + "&CityCode=" + lblCityCode2.Text);
                }
            }
        }

        if (e.CommandName == "Price2")
        {
            Label lblLine = (Label)e.Item.FindControl("lblLine");

            if (!string.IsNullOrEmpty(lblLine.Text.Trim()))
            {
                string citys = lblLine.Text.Trim().Replace(@",", @";");

                string[] Citys = citys.Split(new char[] { ';' });

                List<string> listCity = new List<string>();

                for (int i = 0; i < Citys.Length; i++)
                {
                    listCity.Add(Citys[i]);
                }

                string city = listCity[0];

                Terms.Common.Domain.City City = m_CommonService.FindCityByCityCode(city);

                if (City != null)
                {
                    Label lblID = (Label)e.Item.FindControl("lblID");
                    Label lblPrice2 = (Label)e.Item.FindControl("lblPrice2");

                    Utility.TourCitys = listCity;
                    Utility.IsTourMain = true;
                    Utility.IsTourMore = true;

                    TourSearchCondition tourSearchCondition = new TourSearchCondition();
                    tourSearchCondition.Region = "U.S.";
                    tourSearchCondition.Counrty = City.CountryCode;
                    tourSearchCondition.CityList = listCity;
                    tourSearchCondition.City = city;
                    tourSearchCondition.DeptCity = city;
                    tourSearchCondition.IsLandOnly = true;
                    tourSearchCondition.PriceType = TERMS.Common.TourPriceType.All;
                    tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
                    tourSearchCondition.TravelDaysFrom = 1;
                    tourSearchCondition.TravelDaysTo = 800;
                    this.Transaction.IntKey = tourSearchCondition.GetHashCode();
                    this.Transaction.CurrentSearchConditions = tourSearchCondition;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                    //记录Search More事件
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchMoreTour, this);
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode("U.S.") + "&ConditionID=" + Utility.Transaction.IntKey.ToString() + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm" + "&TopDestinations=" + lblID.Text + "&Price=" + lblPrice2.Text);
                }
            }
        }
    }
}
