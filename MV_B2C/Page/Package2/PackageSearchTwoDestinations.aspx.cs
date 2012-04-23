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
using log4net;

using Terms.Sales.Dao;
using Terms.Sales.Service;
using Terms.Sales.Domain;
using Terms.Sales.Utility;
using Terms.Common.Service;
using Terms.Common.Domain;
using Terms.Base.Domain;
using Terms.Base.Service;
using Terms.Material.Service;
using Terms.Product.Domain;
using System.Collections.Generic;
using Terms.Sales.Business;
using System.Globalization;


public partial class PackageSearchTwoDestinations : SalseBasePage
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

    private IApplicationCacheFoundationDate _ApplicationCacheFoundationDate;
    public IApplicationCacheFoundationDate ApplicationCacheFoundationDate
    {
        set
        {
            this._ApplicationCacheFoundationDate = value;
        }
    }

    private ICommonService _commonService;
    public ICommonService CommonService
    {
        set
        {
            _commonService = value;
        }
    }

    private IBaseService _baseService;
    public IBaseService BaseService
    {
        set { _baseService = value; }
    }

    public PackageSearchTwoDestinations()
    {
        this.InitializeControls += new EventHandler(PackageSearchTwoDestinations_InitializeControls);
    }

    void PackageSearchTwoDestinations_InitializeControls(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        //txtDepartureFrom.Path = txtDestinationOne.Path = txtDestinationTwo.Path = "../../";

        this.dateCheckInOne.Path = this.dateCheckInTwo.Path = this.dateCheckOutOne.Path = this.dateCheckOutTwo.Path = this.dateDeparture.Path = this.dateReturn.Path = "../../";
        if (!this.IsPostBack)
        {
            Navigation1.PageCode = 1;

            dateCheckInOne.IsCoercion = true;
            dateCheckInOne.CoercionID = "dateCheckOutOne";

            dateCheckInTwo.IsCoercion = true;
            dateCheckInTwo.CoercionID = "dateCheckOutTwo";

            txtDepartureFrom.CssClass = "search_inp";
            txtDestinationOne.CssClass = "search_inp";
            txtDestinationTwo.CssClass = "search_inp";

            dateDeparture.BeginDate = DateTime.Now.AddDays(7);
            dateReturn.BeginDate = DateTime.Now.AddDays(7);
            dateCheckInOne.BeginDate = DateTime.Now.AddDays(7);
            dateCheckOutOne.BeginDate = DateTime.Now.AddDays(7);
            dateCheckInTwo.BeginDate = DateTime.Now.AddDays(7);
            dateCheckOutTwo.BeginDate = DateTime.Now.AddDays(7);

            ((TextBox)dateDeparture.FindControl("calendarDate")).Text = DateTime.Now.AddDays(7).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            ((TextBox)dateReturn.FindControl("calendarDate")).Text = DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            ((TextBox)dateCheckInOne.FindControl("calendarDate")).Text = DateTime.Now.AddDays(8).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            ((TextBox)dateCheckOutOne.FindControl("calendarDate")).Text = DateTime.Now.AddDays(9).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            ((TextBox)dateCheckInTwo.FindControl("calendarDate")).Text = DateTime.Now.AddDays(10).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            ((TextBox)dateCheckOutTwo.FindControl("calendarDate")).Text = DateTime.Now.AddDays(11).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

            if (this.Request["Country"] != null)
            {
                if (!Utility.IsSearchConditionNull)
                {
                    PackageSearchCondition PacakgeSearch = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;
                    //HotelSearchCondition hotelSearchCondition = new HotelSearchCondition();
                    PacakgeSearch.HotelSearchCondition.Location = this.Request["CityCode"];
                    PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
                    PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.Request["CheckIn"]);
                    PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.Request["CheckOut"]);
                    PacakgeSearch.HotelSearchCondition.Country = this.Request["Country"];
                    PacakgeSearch.HotelSearchCondition2 = null;
                    Utility.Transaction.CurrentSearchConditions = PacakgeSearch;

                    this.Response.Redirect("~/Page/Common/Searching1.aspx?Destination=Two&ChooseHotelID=" + this.Request["HotelID"] + "&target=~/page/package2/SelectRoomRates");
                }
                else
                {
                    this.Response.Redirect("~/Page/Package2/PackageSearchTwoDestinations.aspx");
                }               
            }           

            OnlyInputENChar();
        }
    }

    private void OnlyInputENChar()
    {
        //((TextBox)txtDepartureFrom.FindControl("txtCity")).Attributes.Add("onKeyPress", "JHshTextPlus();");
        //((TextBox)txtDepartureFrom.FindControl("txtCity")).Attributes.Add("onblur", "CheckCondition(this);");

        //((TextBox)txtDestinationOne.FindControl("txtCity")).Attributes.Add("onKeyPress", "JHshTextPlus();");
        //((TextBox)txtDestinationOne.FindControl("txtCity")).Attributes.Add("onblur", "CheckCondition(this);");

        //((TextBox)txtDestinationTwo.FindControl("txtCity")).Attributes.Add("onKeyPress", "JHshTextPlus();");
        //((TextBox)txtDestinationTwo.FindControl("txtCity")).Attributes.Add("onblur", "CheckCondition(this);");

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //�ж�Search����
        if (!IsCheckSearch())
        {
            return;
        }
        //�ж�CheckIn,CheckOut����

        DateTime dateChinkIn_One = Convert.ToDateTime(this.dateCheckInOne.CDate);
        DateTime dateChinkOut_One = Convert.ToDateTime(this.dateCheckOutOne.CDate);
        DateTime dateChinkIn_Two = Convert.ToDateTime(this.dateCheckInTwo.CDate);
        DateTime dateChinkOut_Two = Convert.ToDateTime(this.dateCheckOutTwo.CDate);
        DateTime dateDeparture = Convert.ToDateTime(this.dateDeparture.CDate);
        DateTime dateReturn = Convert.ToDateTime(this.dateReturn.CDate);

        if (dateChinkIn_One < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Departure date is greater than the current date seven days.');</script>");
            return;
        }

        if (dateChinkOut_One < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Return date is greater than the current date seven days.');</script>");
            return;
        }

        if (dateChinkIn_Two < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Departure date is greater than the current date seven days.');</script>");
            return;
        }

        if (dateChinkOut_Two < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Return date is greater than the current date seven days.');</script>");
            return;
        }

        if (dateDeparture < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Departure date is greater than the current date seven days.');</script>");
            return;
        }

        if (dateReturn < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Return date is greater than the current date seven days.');</script>");
            return;
        }

        if ((dateChinkIn_One < DateTime.Today && dateChinkOut_One < DateTime.Today) || (dateChinkIn_Two < DateTime.Today && dateChinkOut_Two < DateTime.Today))
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We can only accept dates that occur between " + DateTime.Today.AddDays(1).ToString("MM/dd/yyyy") + " and 12/27/2008. Please enter a new date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateChinkIn_One <= DateTime.Today || dateChinkIn_Two < DateTime.Today)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-in date must occur after the today date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateChinkIn_One > dateChinkOut_One || dateChinkIn_One > dateChinkOut_Two)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-out date must occur after the check-in date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateChinkOut_One > dateChinkIn_Two)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The second destination check-in date must occur after the first destination check-out date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateDeparture > dateChinkIn_One || dateDeparture > dateChinkIn_Two)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The departure  date must occur before the  check-in date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateReturn < dateChinkOut_One || dateReturn < dateChinkOut_Two)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The return  date must occur after the  check-out date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }

        //Utility.SelectAirGroup = null;
        PackageSearchCondition PacakgeSearch = new PackageSearchCondition();
        HotelSearchCondition hotelSearchCondition2 = new HotelSearchCondition();

        PacakgeSearch.DepatrueAirPorts = new List<Terms.Common.Domain.Airport>();
        if (txtDepartureFrom.Text.Trim().Length > 3)
        {
            IList departureAirPorts = _commonService.FindAirportByCityName(txtDepartureFrom.Text.Trim());

            if (departureAirPorts.Count >= 1)
            {
                PacakgeSearch.DepatrueAirPorts = departureAirPorts;
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(txtDepartureFrom.Text.Trim(), airportList);
                if (airport != null)
                {
                    PacakgeSearch.DepatrueAirPorts.Add(airport);
                }
            }
        }
        else
        {
            //PacakgeSearch.DepatrueAirPorts.Add(AirService.CommAirportDao.FindByAirport(txtDepartureFrom.Text.Trim()));
            Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(txtDepartureFrom.Text.Trim());

            if (airport != null)
            {
                PacakgeSearch.DepatrueAirPorts.Add(airport);
            }
            else
            {
                IList departureAirPorts = AirService.CommAirportDao.FindByCityCode(txtDepartureFrom.Text.Trim());

                if (departureAirPorts.Count >= 1)
                {
                    PacakgeSearch.DepatrueAirPorts = departureAirPorts;
                }
            }
        }

        //IList departureAirPorts = _commonService.FindAirportByCityName(this.txtDepartureFrom.Text);
        //PacakgeSearch.DepatrueAirPorts = departureAirPorts;

        PacakgeSearch.DestinationAirPorts = new List<Terms.Common.Domain.Airport>();
        if (txtDestinationOne.Text.Trim().Length > 3)
        {
            IList DestinationOneAirPorts = _commonService.FindAirportByCityName(txtDestinationOne.Text.Trim());

            if (DestinationOneAirPorts.Count >= 1)
            {
                PacakgeSearch.DestinationAirPorts = DestinationOneAirPorts;
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(txtDestinationOne.Text.Trim(), airportList);
                if (airport != null)
                {
                    PacakgeSearch.DestinationAirPorts.Add(airport);
                }
            }
        }
        else
        {
            Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(txtDestinationOne.Text.Trim());

            if (airport != null)
            {
                PacakgeSearch.DestinationAirPorts.Add(airport);
            }
            else
            {
                IList DestinationOneAirPorts = AirService.CommAirportDao.FindByCityCode(txtDestinationOne.Text.Trim());

                if (DestinationOneAirPorts.Count >= 1)
                {
                    PacakgeSearch.DestinationAirPorts = DestinationOneAirPorts;
                }
            }
        }

        //IList DestinationOneAirPorts = _commonService.FindAirportByCityName(this.txtDestinationOne.Text);
        //PacakgeSearch.DestinationAirPorts = DestinationOneAirPorts;

        PacakgeSearch.DestinationAirPortsTwo = new List<Terms.Common.Domain.Airport>();
        if (txtDestinationTwo.Text.Trim().Length > 3)
        {
            IList ReturnAirPorts = _commonService.FindAirportByCityName(txtDestinationTwo.Text.Trim());

            if (ReturnAirPorts.Count >= 1)
            {
                PacakgeSearch.DestinationAirPortsTwo = ReturnAirPorts;
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(txtDestinationTwo.Text.Trim(), airportList);
                if (airport != null)
                {
                    PacakgeSearch.DestinationAirPortsTwo.Add(airport);
                }
            }
        }
        else
        {
            Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(txtDestinationTwo.Text.Trim());

            if (airport != null)
            {
                PacakgeSearch.DestinationAirPortsTwo.Add(airport);
            }
            else
            {
                IList ReturnAirPorts = AirService.CommAirportDao.FindByCityCode(txtDestinationTwo.Text.Trim());

                if (ReturnAirPorts.Count >= 1)
                {
                    PacakgeSearch.DestinationAirPortsTwo = ReturnAirPorts;
                }
            }
        }

        //IList ReturnAirPorts = _commonService.FindAirportByCityName(this.txtDestinationTwo.Text);
        //PacakgeSearch.DestinationAirPortsTwo = ReturnAirPorts;

        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Adult, TravelerChange1.TotalAdults);
        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Child, TravelerChange1.TotalChilds);

        //�ж�����ĳ����غ�Ŀ�ĵ���û�л���
        if (PacakgeSearch.DepatrueAirPorts.Count == 0)
        {
            Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDepartureFrom.Text + "\"&GoToPage=PackageSearchTwoDestinations.aspx");
        }

        if (PacakgeSearch.DestinationAirPorts.Count == 0)
        {
            Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDestinationOne.Text + "\"&GoToPage=PackageSearchTwoDestinations.aspx");
        }

        if (PacakgeSearch.DestinationAirPortsTwo.Count == 0)
        {
            Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDestinationTwo.Text + "\"&GoToPage=PackageSearchTwoDestinations.aspx");
        }

        for (int i = 0; i < TravelerChange1.Rooms; i++)
        {
            RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

            roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Adult, TravelerChange1.Adults[i]);
            roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Child, TravelerChange1.Childs[i]);

            PacakgeSearch.HotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
            hotelSearchCondition2.RoomSearchConditions.Add(roomSearchCondition);
            PacakgeSearch.HotelSearchCondition2 = hotelSearchCondition2;
        }

        if (PacakgeSearch.DestinationAirPorts.Count > 0 || PacakgeSearch.DepatrueAirPorts.Count > 0 || PacakgeSearch.DestinationAirPortsTwo.Count > 0)
        {
            if (PacakgeSearch.DestinationAirPorts.Count > 1 || PacakgeSearch.DepatrueAirPorts.Count > 1 || PacakgeSearch.DestinationAirPortsTwo.Count > 1)
            {
                this.Transaction.IntKey = PacakgeSearch.GetHashCode();
                this.Transaction.CurrentSearchConditions = PacakgeSearch;
                //���������
                MoreAirportsSelect();
                this.btnSearch.Visible = false;
                this.btnSearch1.Visible = true;

            }
            else
            {
                PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateCheckInOne.CDate);
                PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateCheckOutOne.CDate);
                hotelSearchCondition2.CheckIn = Convert.ToDateTime(this.dateCheckInTwo.CDate);
                hotelSearchCondition2.CheckOut = Convert.ToDateTime(this.dateCheckOutTwo.CDate);
                PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).CityCode;  //((City)_commonService.FindCitiesByName(this.txtDestinationOne.Text)[0]).Code;// "PVG";
                hotelSearchCondition2.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPortsTwo[0]).CityCode;  //((City)_commonService.FindCitiesByName(this.txtDestinationTwo.City)[0]).Code;// "PVG";
                PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
                hotelSearchCondition2.LocationIndicator = TERMS.Common.LocationIndicator.City;
                PacakgeSearch.HotelSearchCondition.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Country.Code; // ((City)_commonService.FindCitiesByName(this.txtDestinationTwo.City)[0]).Country.Code;
                hotelSearchCondition2.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPortsTwo[0]).City.Country.Code;
                //hotelSearchCondition2.Country = this.txtDestinationTwo.Text;

                //����Cabin
                TERMS.Common.CabinType cabin = new TERMS.Common.CabinType();
                if (ddlClass.SelectedIndex == 0)
                {
                    cabin = TERMS.Common.CabinType.Economy;
                }
                else if (ddlClass.SelectedIndex == 1)
                {
                    cabin = TERMS.Common.CabinType.Business;
                }
                else if (ddlClass.SelectedIndex == 2)
                {
                    cabin = TERMS.Common.CabinType.First;
                }

                AirTripCondition DPTairTripCondition = new AirTripCondition();
                DPTairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
                DPTairTripCondition.DepartureDate = Convert.ToDateTime(this.dateDeparture.CDate);
                DPTairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0];
                DPTairTripCondition.IsDepartureTimeSpecified = this.chbFlexible.Checked;
                DPTairTripCondition.Cabin = cabin;
                PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
                PacakgeSearch.AirSearchCondition.Airlines = null;
                AirTripCondition RTNairTripCondition = new AirTripCondition();
                RTNairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPortsTwo[0];
                RTNairTripCondition.DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);
                RTNairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
                RTNairTripCondition.IsDepartureTimeSpecified = this.chbFlexible.Checked;
                RTNairTripCondition.Cabin = cabin;
                PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);
                PacakgeSearch.AirSearchCondition.FlightType = "openjaw";
                //PacakgeSearch.AirSearchCondition.ProductType = Terms.Base.Utility.ProductType.Package;
                this.Transaction.IntKey = PacakgeSearch.GetHashCode();
                this.Transaction.CurrentSearchConditions = PacakgeSearch;
                this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                //PacakgeSearch.OptionalHotelSearchConditions.Clear();Ҫɾ������ȫ��ɾ��
                PacakgeSearch.SetOptionalHotelSearchConditions(hotelSearchCondition2);
                //��¼Search Package�¼�
                if(Utility.IsSubAgent)
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchPackage, this);
                else
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchPackage, this);
                this.Page.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package2/SelectRoomRates" + "&ConditionID=" + this.Transaction.IntKey.ToString());
            }
        }
        else
        {

        }


    }

    /// <summary>
    /// �������ж��������ѡ������һ��
    /// </summary>
    private void MoreAirportsSelect()
    {
        if (((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts.Count > 1)
        {
            string name = ((Terms.Common.Domain.Airport)((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts[0]).DisplayWholeName;
            this.listBDepartureAirport.DataValueField = "Code";
            this.listBDepartureAirport.DataTextField = "DisplayWholeName";
            this.listBDepartureAirport.DataSource = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts;
            this.listBDepartureAirport.DataBind();
            this.listBDepartureAirport.Visible = true;
            this.lbFromSelect.Visible = true;
        }
        if (((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPortsTwo.Count > 1)
        {
            this.listBReturnAirport.DataValueField = "Code";
            this.listBReturnAirport.DataTextField = "DisplayWholeName";
            this.listBReturnAirport.DataSource = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPortsTwo;
            this.listBReturnAirport.DataBind();
            this.listBReturnAirport.Visible = true;
            this.lbSelectTwo.Visible = true;
        }

        if (((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts.Count > 1)
        {
            this.listBDestinationOneAirport.DataValueField = "Code";
            this.listBDestinationOneAirport.DataTextField = "DisplayWholeName";
            this.listBDestinationOneAirport.DataSource = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts;
            this.listBDestinationOneAirport.DataBind();
            this.listBDestinationOneAirport.Visible = true;
            this.lbSelectOne.Visible = true;
        }
    }
    protected void btnSearch1_Click(object sender, EventArgs e)
    {
        //�ж�Search����
        if (!IsCheckSearch())
        {
            return;
        }

        if (listBDepartureAirport.Visible == true && listBDepartureAirport.SelectedIndex == -1)
        {
            return;
        }
        if (listBReturnAirport.Visible == true && listBReturnAirport.SelectedIndex == -1)
        {
            return;
        }
        PackageSearchCondition PacakgeSearch = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;
        HotelSearchCondition hotelSearchCondition2 = PacakgeSearch.HotelSearchCondition2;
        PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateCheckInOne.CDate);
        PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateCheckOutOne.CDate);
        hotelSearchCondition2.CheckIn = Convert.ToDateTime(this.dateCheckInTwo.CDate);
        hotelSearchCondition2.CheckOut = Convert.ToDateTime(this.dateCheckOutTwo.CDate);
        if (PacakgeSearch.DestinationAirPorts.Count > 1)
            PacakgeSearch.HotelSearchCondition.Location = ((Airport)PacakgeSearch.DestinationAirPorts[this.listBDestinationOneAirport.SelectedIndex]).City.Code;//"PVG";
        else
            PacakgeSearch.HotelSearchCondition.Location = ((Airport)PacakgeSearch.DestinationAirPorts[0]).City.Code;
        if (PacakgeSearch.DestinationAirPortsTwo.Count > 1)
            hotelSearchCondition2.Location = ((Airport)PacakgeSearch.DestinationAirPortsTwo[this.listBReturnAirport.SelectedIndex]).City.Code;//"PVG";
        else
            hotelSearchCondition2.Location = ((Airport)PacakgeSearch.DestinationAirPortsTwo[0]).City.Code;
        PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
        hotelSearchCondition2.LocationIndicator = TERMS.Common.LocationIndicator.City;
        PacakgeSearch.HotelSearchCondition.Country = this.txtDestinationOne.Text;
        hotelSearchCondition2.Country = this.txtDestinationTwo.Text;

        AirTripCondition DPTairTripCondition = new AirTripCondition();
        if (PacakgeSearch.DepatrueAirPorts.Count > 1)
            DPTairTripCondition.Departure = (Airport)PacakgeSearch.DepatrueAirPorts[this.listBDepartureAirport.SelectedIndex];
        else
            DPTairTripCondition.Departure = (Airport)PacakgeSearch.DepatrueAirPorts[0];
        DPTairTripCondition.DepartureDate = Convert.ToDateTime(this.dateDeparture.CDate);
        if (PacakgeSearch.DestinationAirPorts.Count > 1)
            DPTairTripCondition.Destination = (Airport)PacakgeSearch.DestinationAirPorts[this.listBDestinationOneAirport.SelectedIndex];
        else
            DPTairTripCondition.Destination = (Airport)PacakgeSearch.DestinationAirPorts[0];
        DPTairTripCondition.IsDepartureTimeSpecified = this.chbFlexible.Checked;
        PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
        PacakgeSearch.AirSearchCondition.Airlines = null;
        AirTripCondition RTNairTripCondition = new AirTripCondition();
        if (PacakgeSearch.DestinationAirPortsTwo.Count > 1)
            RTNairTripCondition.Departure = (Airport)PacakgeSearch.DestinationAirPortsTwo[this.listBReturnAirport.SelectedIndex];
        else
            RTNairTripCondition.Departure = (Airport)PacakgeSearch.DestinationAirPortsTwo[0];
        RTNairTripCondition.DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);
        if (PacakgeSearch.DepatrueAirPorts.Count > 1)
            RTNairTripCondition.Destination = (Airport)PacakgeSearch.DepatrueAirPorts[this.listBDepartureAirport.SelectedIndex];
        else
            RTNairTripCondition.Destination = (Airport)PacakgeSearch.DepatrueAirPorts[0];
        RTNairTripCondition.IsDepartureTimeSpecified = this.chbFlexible.Checked;
        PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);
        PacakgeSearch.AirSearchCondition.FlightType = "openjaw";
        //PacakgeSearch.AirSearchCondition.ProductType = Terms.Base.Utility.ProductType.Package;
        this.Transaction.IntKey = PacakgeSearch.GetHashCode();
        this.Transaction.CurrentSearchConditions = PacakgeSearch;
        this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
        PacakgeSearch.SetOptionalHotelSearchConditions(hotelSearchCondition2);
        //��¼Search Package�¼�
        if (Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchPackage, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchPackage, this);
        this.Page.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package2/SelectRoomRates" + "&ConditionID=" + this.Transaction.IntKey.ToString());
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
    /// ��֤������Ƿ�Ϸ�
    /// </summary>
    private bool IsCheckSearch()
    {
        bool result = true;

        if (this.dateDeparture.CDate == "__/__/____" || this.dateDeparture.CDate == "")
        {
            this.lblDateDepMsg.Visible = true;
            result = false;
        }
        else
        {
            this.lblDateDepMsg.Visible = false;
        }

        if (this.dateCheckInOne.CDate == "__/__/____" || this.dateCheckInOne.CDate == "")
        {
            this.lblCheckInOneMsg.Visible = true;
            result = false;
        }
        else
        {
            this.lblCheckInOneMsg.Visible = false;
        }

        if (this.dateCheckInTwo.CDate == "__/__/____" || this.dateCheckInTwo.CDate == "")
        {
            this.lblCheckInTwoMsg.Visible = true;
            result = false;
        }
        else
        {
            this.lblCheckInTwoMsg.Visible = false;
        }

        if (this.dateCheckOutOne.CDate == "__/__/____" || this.dateCheckOutOne.CDate == "")
        {
            this.lblCheckOutOneMsg.Visible = true;
            result = false;
        }
        else
        {
            this.lblCheckOutOneMsg.Visible = false;
        }

        if (this.dateCheckOutTwo.CDate == "__/__/____" || this.dateCheckOutTwo.CDate == "")
        {
            this.lblCheckOutTwoMsg.Visible = true;
            result = false;
        }
        else
        {
            this.lblCheckOutTwoMsg.Visible = false;
        }

        if (this.dateReturn.CDate == "__/__/____" || this.dateReturn.CDate == "")
        {
            this.lblReturnMsg.Visible = true;
            result = false;
        }
        else
        {
            this.lblReturnMsg.Visible = false;
        }

        if (this.txtDepartureFrom.Text.Trim() == "")
        {
            result = false;
        }

        if (this.txtDestinationOne.Text.Trim() == "")
        {
            result = false;
        }

        if (this.txtDestinationTwo.Text.Trim() == "")
        {
            result = false;
        }

        return result;
    }
}

