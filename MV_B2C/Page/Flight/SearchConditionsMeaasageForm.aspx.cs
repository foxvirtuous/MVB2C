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

using log4net;



using Terms.Global.Utility;
using Terms.Sales.Domain;
using Terms.Sales.Service;
using Terms.Common.Service;
using Terms.Common.Domain;

using Terms.Material.Service;
using Terms.Sales.Business;
using TERMS.Common;

public partial class SearchConditionsMeaasageForm : AirBook.Base.BookingPage
{
    private static readonly log4net.ILog log =
             log4net.LogManager.GetLogger("AirSearchTime");

    private CommonService _CommonService;
    public CommonService CommonService
    {
        set
        {
            _CommonService = value;
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

    private IApplicationCacheFoundationDate _ApplicationCacheFoundationDate;
    public IApplicationCacheFoundationDate ApplicationCacheFoundationDate
    {
        set
        {
            this._ApplicationCacheFoundationDate = value;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.StepNumber = 1;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = false;
        this.rdoLstCabin.Items[0].Text = Resources.Global.Economy;
        this.rdoLstCabin.Items[1].Text = Resources.Global.Business;
        this.rdoLstCabin.Items[2].Text = Resources.Global.First;

        txtDepartureFrom.Path = txtTo.Path = departureCalendar.Path = returnCalendar.Path = "../../";
        txtReturnFrom.Path = txtReturnTo.Path = "../../";

        ((TextBox)txtDepartureFrom.FindControl("txtCity")).CssClass = "searchFormMain_input";
        ((TextBox)txtTo.FindControl("txtCity")).CssClass = "searchFormMain_input";
        ((TextBox)txtReturnFrom.FindControl("txtCity")).CssClass = "searchFormMain_input";
        ((TextBox)txtReturnTo.FindControl("txtCity")).CssClass = "searchFormMain_input";

        ((TextBox)departureCalendar.FindControl("calendarDate")).CssClass = "searchFormMain_input";
        ((TextBox)returnCalendar.FindControl("calendarDate")).CssClass = "searchFormMain_input";

        ((TextBox)txtDepartureFrom.FindControl("txtCity")).Style.Add("width", "250px");
        ((TextBox)txtTo.FindControl("txtCity")).Style.Add("width", "250px");
        ((TextBox)txtReturnFrom.FindControl("txtCity")).Style.Add("width", "250px");
        ((TextBox)txtReturnTo.FindControl("txtCity")).Style.Add("width", "250px");        

        departureCalendar.IsCoercion = true;
        departureCalendar.CoercionID = "returnCalendar";

        if (this.Request["TYPE"] != null)
        {
            this.divIsError.Style["display"] = "none";
            label2.Visible = false;
            label32.Visible = false;
            label3.Visible = false;
        }

        try
        {
            if (!IsPostBack)
            {
                //Navigation1.PageCode = 1;
                InitSet();
                InitAirline();
                InitCondition();

                if (Request["DateErrorMsg"] != null)
                {
                    label32.Visible = false; label3.Visible = false; label2.Visible = false; lblDateErrorMsg.Visible = true;
                    lblDateErrorMsg.Text = Request["DateErrorMsg"].Trim();
                }
            }
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }

    private void InitSet()
    {
        bool isAllRealCity = true;
        if (!CurrentSession.IsRealFromCity)
        {
            this.div_From.Style["display"] = "";
            TextBox city = (TextBox)this.txtDepartureFrom.FindControl("txtCity");
            this.lblFrom.Text = city.Text = CurrentSession.FromCityName;
            if (CurrentSession.FromCityName == "DestinationTest")
            {
                city.Text = "";
                this.div_From1.Style["display"] = "";
                this.div_From.Style["display"] = "none";
            }
            isAllRealCity = false;
        }
        else
        {
            this.div_From.Style["display"] = "none";
            TextBox city = (TextBox)this.txtDepartureFrom.FindControl("txtCity");
            city.Text = CurrentSession.FromCityName;
        }

        if (!CurrentSession.IsRealToCity)
        {
            this.div_To.Style["display"] = "";
            TextBox city = (TextBox)this.txtTo.FindControl("txtCity");
            this.lblTo.Text = city.Text = CurrentSession.ToCityName;
            isAllRealCity = false;
        }
        else
        {
            this.div_To.Style["display"] = "none";
            TextBox city = (TextBox)this.txtTo.FindControl("txtCity");
            city.Text = CurrentSession.ToCityName;
        }
        if (Transaction.CurrentSearchConditions != null)
        {
            if (((AirSearchCondition)Transaction.CurrentSearchConditions).FlightType.ToLower().Equals("openjaw"))
            {
                if (!CurrentSession.IsRealReturnFromCity)
                {
                    this.tr_ReturnFrom.Style["display"] = "";
                    tr_ReturnFromMessage.Style["display"] = "";
                    TextBox city = (TextBox)this.txtReturnFrom.FindControl("txtCity");
                    this.lblReturnFrom.Text = city.Text = CurrentSession.ReturnFromCityName;
                    isAllRealCity = false;
                }
                else
                {
                    this.tr_ReturnFrom.Style["display"] = "";
                    TextBox city = (TextBox)this.txtReturnFrom.FindControl("txtCity");
                    city.Text = CurrentSession.ReturnFromCityName;

                }

                if (!CurrentSession.IsRealReturnToCity)
                {
                    this.tr_ReturnTo.Style["display"] = "";
                    tr_ReturnToMessage.Style["display"] = "";
                    TextBox city = (TextBox)this.txtReturnTo.FindControl("txtCity");
                    this.lblReturnTo.Text = city.Text = CurrentSession.ReturnToCityName;
                    isAllRealCity = false;
                }
                else
                {
                    this.tr_ReturnTo.Style["display"] = "";
                    TextBox city = (TextBox)this.txtReturnTo.FindControl("txtCity");
                    city.Text = CurrentSession.ReturnToCityName;
                }

                //tr_OpenJw.Style["display"] = "";

            }
        }
        else
        {
            TextBox rtfCity = (TextBox)this.txtReturnFrom.FindControl("txtCity");
            rtfCity.Text = CurrentSession.ReturnFromCityName;

            TextBox rttCity = (TextBox)this.txtReturnTo.FindControl("txtCity");
            rttCity.Text = CurrentSession.ReturnToCityName;

        }

        if (isAllRealCity)
            this.div_NoFlights.Style["display"] = "";
        //if (CurrentSession.FromAirports != null)
        //{
        //    this.txtDepartureFrom.Text = ((CommAirportMeta)CurrentSession.FromAirports[0]).City.Name;
        //    this.div_From.Visible = true;
        //}
        //if (CurrentSession.ToAirports != null)
        //{
        //    this.txtTo.Text = ((CommAirportMeta)CurrentSession.ToAirports[0]).City.Name;
        //    this.div_To.Visible = true;
        //}

        //if (CurrentSession.ReturnFromAirports != null)
        //{
        //    this.txtReturnFrom.Text = ((CommAirportMeta)CurrentSession.ReturnFromAirports[0]).City.Name;
        //    this.div_ReturnFrom.Visible = true;
        //    this.div_OpenJw.Visible = true;
        //}
        //if (CurrentSession.ReturnToAirports != null)
        //{
        //    this.txtReturnTo.Text = ((CommAirportMeta)CurrentSession.ReturnToAirports[0]).City.Name;
        //    this.div_ReturnTo.Visible = true;
        //    this.div_OpenJw.Visible = true;
        //}
    }

    private void InitCondition()
    {
        string name = string.Empty;
        AirSearchCondition airSearchCondition = (AirSearchCondition)Transaction.CurrentSearchConditions;
        if (airSearchCondition != null)
        {
            TextBox departureCalendarDate = (TextBox)this.departureCalendar.FindControl("calendarDate");
            departureCalendarDate.Text = airSearchCondition.AirTripCondition[0].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

            TextBox returnCalendarDate = (TextBox)this.returnCalendar.FindControl("calendarDate");


            //20081029 tonglanli
            TextBox cityRtnFrom = (TextBox)this.txtReturnFrom.FindControl("txtCity");
            TextBox cityRtnTo = (TextBox)this.txtReturnTo.FindControl("txtCity");

            TextBox cityDepartureFrom = (TextBox)this.txtDepartureFrom.FindControl("txtCity");
            TextBox cityDepartureTo = (TextBox)this.txtTo.FindControl("txtCity");


            switch (airSearchCondition.FlightType.ToLower())
            {
                case "roundtrip":
                    this.rdbRoundTrip.Checked = true;
                    returnCalendarDate.Text = airSearchCondition.AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);



                    //20081029 tonglanli
                    cityRtnFrom.Text = cityDepartureTo.Text;
                    cityRtnTo.Text = cityDepartureFrom.Text;

                    break;
                case "oneway":
                    this.rdbOneway.Checked = true;
                    this.tr_OneWay.Style["display"] = "none";
                    //this.lbl_isOneWay.Text = string.Empty;
                    //this.lbl_isRoundTrip.Text = string.Empty;

                    //20081029 tonglanli
                    returnCalendarDate.Text = string.Format("{0:MM/DD/YYYY}", DateTime.Now.Date.AddDays(21).ToShortDateString());

                    cityRtnFrom.Text = cityDepartureTo.Text;
                    cityRtnTo.Text = cityDepartureFrom.Text;

                    break;
                case "openjaw":
                    this.rdbOpenjaw.Checked = true;
                    //this.lbl_isRoundTrip.Text = string.Empty;

                    returnCalendarDate.Text = airSearchCondition.AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                    break;

            }


            rdoLstCabin.SelectedIndex = rdoLstCabin.Items.IndexOf(rdoLstCabin.Items.FindByValue(airSearchCondition.GetAddTripCondition()[0].Cabin.ToString().ToUpper()));
            GlobalUtility.SelectDropDownList(ddlAdult, airSearchCondition.GetPassengerNumber(PassengerType.Adult).ToString(), true);
            GlobalUtility.SelectDropDownList(ddlChild, airSearchCondition.GetPassengerNumber(PassengerType.Child).ToString(), true);
            // GlobalUtility.SelectDropDownList(ddlInfant, airSearchCondition.GetPassengerNumber(PassengerType.Infant).ToString(), true);

            if (airSearchCondition.Airlines != null)
            {
                txtAirline.Text = string.Join(",", airSearchCondition.Airlines);
            }

        }
        else
        {
            this.div_NoFlights.Style["display"] = "none";
            TextBox departureCalendarDate = (TextBox)this.departureCalendar.FindControl("calendarDate");
            departureCalendarDate.Text = DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

            TextBox returnCalendarDate = (TextBox)this.returnCalendar.FindControl("calendarDate");
            returnCalendarDate.Text = DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
        }
    }

    private void InitAirline()
    {
        AirService airService = new AirService();

        if (Application["Allairways"] == null)
        {
            Application["Allairways"] = airService.GetAllAirLines();
        }

        DataSet ds = (DataSet)(Application["Allairways"]);

        for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
        {
            BulletedList1.Items.Add(new ListItem(ds.Tables[0].Rows[i][0].ToString(), "javascript:IntxtAirline('" + txtAirline.ClientID + "','" + ds.Tables[0].Rows[i][1].ToString() + "');"));
        }
    }

    /// <summary>
    /// 验证输入框是否合法
    /// </summary>
    private bool CheckSearch()
    {
        TextBox cityDep = (TextBox)this.txtDepartureFrom.FindControl("txtCity");
        TextBox cityDes = (TextBox)this.txtTo.FindControl("txtCity");
        TextBox depDate = (TextBox)this.departureCalendar.FindControl("calendarDate");

        if (cityDep.Text.Trim() == ""
            || cityDes.Text.Trim() == ""
            || depDate.Text.Trim() == "")
        {
            return false;
        }

        if (rdbOneway.Checked == false)
        {
            //oneway1.Style["display"] = "";
            //oneway2.Style["display"] = "";

            TextBox cityRtnFrom = (TextBox)this.txtReturnFrom.FindControl("txtCity");
            TextBox cityRtnTo = (TextBox)this.txtReturnTo.FindControl("txtCity");
            TextBox rtnDate = (TextBox)this.returnCalendar.FindControl("calendarDate");


            if (rdbOpenjaw.Checked == true)
            {
                if (cityRtnFrom.Text.Trim() == ""
                    || cityRtnTo.Text.Trim() == "")
                {
                    return false;
                }
            }
            else
            {
                // It is Round Trip and set as same as DEP AND DES
                //txtRtnFrom.Value = txtDesCity.Value;
                //txtRtnTo.Value = txtDepCity.Value;
            }

            if (!rtnDate.Text.Equals(string.Empty)
                && (Convert.ToDateTime(rtnDate.Text) <= Convert.ToDateTime(depDate.Text)))
            {
                return false;
            }
        }

        if (ddlAdult.Text == "0"
            && ddlChild.Text == "0")
        {
            return false;
        }

        return true;
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

    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        if (CheckSearch())
        {
            //if (!Page.IsValid)
            //    return;

            //log begin 20081017 henry
            Utility.IsTourMain = false;
            log.Info("\r\n");
            System.Random rd = new Random();

            Session["LOG_RANDOM"] = rd.Next(999999999);

            if (!Transaction.IsLogin)
            {
                log.Info(Session["LOG_RANDOM"].ToString() + " >====================Not Login========================");
            }
            else
            {
                log.Info(Session["LOG_RANDOM"].ToString() + " >==========================Login========================");
            }
            string logAirline = txtAirline.Text.Trim().Equals(string.Empty) ? "All" : txtAirline.Text;


            //log end 20081017 henry

            bool IsSelectAirport = false;
            bool IsRealCity = true;

            Session["CurrentSession"] = new SessionClass();
            SessionClass sc = (SessionClass)Session["CurrentSession"];

            AirSearchCondition airSearchCondition = new AirSearchCondition();

            airSearchCondition.SetPassengerNumber(PassengerType.Adult, Convert.ToInt32(ddlAdult.SelectedValue));

            CabinType cabin = new CabinType();
            if (rdoLstCabin.SelectedIndex == 0)
            {
                cabin = CabinType.Economy;
            }
            else if (rdoLstCabin.SelectedIndex == 1)
            {
                cabin = CabinType.Business;
            }
            else if (rdoLstCabin.SelectedIndex == 2)
            {
                cabin = CabinType.First;
            }
            else if (rdoLstCabin.SelectedIndex == 3)
            {
                cabin = CabinType.All;
            }

            airSearchCondition.SetPassengerNumber(PassengerType.Child, Convert.ToInt32(ddlChild.SelectedValue));
            //airSearchCondition.SetPassengerNumber(PassengerType.Infant, Convert.ToInt32(ddlInfant.SelectedValue));



            if (rdbOneway.Checked)
                airSearchCondition.FlightType = "oneway";
            else if (rdbOpenjaw.Checked)
                airSearchCondition.FlightType = "openjaw";
            else
                airSearchCondition.FlightType = "roundtrip";

            airSearchCondition.FlexibleDays = 0;

            AirTripCondition deptCondition = new AirTripCondition();
            deptCondition.Cabin = cabin;

            TextBox cityDep = (TextBox)this.txtDepartureFrom.FindControl("txtCity");
            TextBox cityDes = (TextBox)this.txtTo.FindControl("txtCity");
            TextBox depDate = (TextBox)this.departureCalendar.FindControl("calendarDate");

            sc.FromCityName = cityDep.Text.Trim();
            if (cityDep.Text.Trim().Length > 3)
            {
                IList departureAirPorts = _CommonService.FindAirportByCityName(cityDep.Text.Trim());

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
                    Terms.Common.Domain.Airport airport = MatchAirport(cityDep.Text.Trim(), airportList);
                    if (airport != null)
                        deptCondition.Departure = airport;
                    else
                        sc.IsRealFromCity = IsRealCity = false;
                    //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDepCity.Value + "\"&GoToPage=~/index.aspx");
                }

            }
            else
            {
                deptCondition.Departure = AirService.CommAirportDao.FindByAirport(cityDep.Text.Trim());

                if (deptCondition.Departure == null)
                {
                    deptCondition.Departure = new Terms.Common.Domain.Airport();
                    deptCondition.Departure.Code = cityDep.Text.Trim();
                }
            }

            deptCondition.DepartureDate = GlobalUtility.GetDateTime(depDate.Text.Trim());

            if (deptCondition.DepartureDate < DateTime.Now.AddDays(3))
            {
                label32.Visible = false; label3.Visible = false; label2.Visible = false; lblDateErrorMsg.Visible = true;
                lblDateErrorMsg.Text = Resources.HintInfo.AirDateError;
                return;
            }

            sc.ToCityName = cityDes.Text.Trim();
            if (cityDes.Text.Trim().Length > 3)
            {
                IList destinationAirPorts = _CommonService.FindAirportByCityName(cityDes.Text.Trim());

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
                    Terms.Common.Domain.Airport airport = MatchAirport(cityDes.Text.Trim(), airportList);
                    if (airport != null)
                        deptCondition.Destination = airport;
                    else
                        sc.IsRealToCity = IsRealCity = false;
                    //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDesCity.Value + "\"&GoToPage=~/index.aspx");
                }

            }
            else
            {
                deptCondition.Destination = AirService.CommAirportDao.FindByAirport(cityDes.Text.Trim());

                if (deptCondition.Destination == null)
                {
                    deptCondition.Destination = new Terms.Common.Domain.Airport();
                    deptCondition.Destination.Code = cityDes.Text.Trim();
                }
            }



            AirTripCondition rtnCondition = new AirTripCondition();
            rtnCondition.Cabin = cabin;

            TextBox cityRtnFrom = (TextBox)this.txtReturnFrom.FindControl("txtCity");
            TextBox cityRtnTo = (TextBox)this.txtReturnTo.FindControl("txtCity");
            TextBox rtnDate = (TextBox)this.returnCalendar.FindControl("calendarDate");


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
                rtnCondition.DepartureDate = GlobalUtility.GetDateTime(rtnDate.Text.Trim());
            }
            else if (airSearchCondition.FlightType.ToLower().Equals("openjaw"))
            {
                //rtnCondition.Departure = AirService.CommAirportDao.FindByAirport(txtRtnFrom.Value.Trim());
                //rtnCondition.Destination = AirService.CommAirportDao.FindByAirport(txtRtnTo.Value.Trim());
                rtnCondition.DepartureDate = GlobalUtility.GetDateTime(rtnDate.Text.Trim());
                sc.ReturnFromCityName = cityRtnFrom.Text.Trim();
                if (cityRtnFrom.Text.Trim().Length > 3)
                {
                    IList returnFromAirPorts = _CommonService.FindAirportByCityName(cityRtnFrom.Text.Trim());

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
                        Terms.Common.Domain.Airport airport = MatchAirport(cityRtnFrom.Text.Trim(), airportList);
                        if (airport != null)
                            rtnCondition.Departure = airport;
                        else
                            sc.IsRealReturnFromCity = IsRealCity = false;
                        //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtRtnFrom.Value + "\"&GoToPage=~/index.aspx");
                    }
                }
                else
                {
                    rtnCondition.Departure = AirService.CommAirportDao.FindByAirport(cityRtnFrom.Text.Trim());

                    if (rtnCondition.Departure == null)
                    {
                        rtnCondition.Departure = new Terms.Common.Domain.Airport();
                        rtnCondition.Departure.Code = cityRtnFrom.Text.Trim();
                    }
                }
                sc.ReturnToCityName = cityRtnTo.Text.Trim();
                if (cityRtnTo.Text.Trim().Length > 3)
                {
                    IList returnToAirPorts = _CommonService.FindAirportByCityName(cityRtnTo.Text.Trim());

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
                        Terms.Common.Domain.Airport airport = MatchAirport(cityRtnTo.Text.Trim(), airportList);
                        if (airport != null)
                            rtnCondition.Destination = airport;
                        else
                            sc.IsRealReturnToCity = IsRealCity = false;
                        //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtRtnTo.Value + "\"&GoToPage=~/index.aspx");
                    }

                }
                else
                {
                    rtnCondition.Destination = AirService.CommAirportDao.FindByAirport(cityRtnTo.Text.Trim());

                    if (rtnCondition.Destination == null)
                    {
                        rtnCondition.Destination = new Terms.Common.Domain.Airport();
                        rtnCondition.Destination.Code = cityRtnTo.Text.Trim();
                    }
                }
            }

            airSearchCondition.AddTripCondition(deptCondition);
            airSearchCondition.AddTripCondition(rtnCondition);


            //if (ddlAirline.SelectedItem.Text != "Search All Airlines")
            if (txtAirline.Text.Trim() != "")
            {
                //param.Airways = ddlAirline.SelectedValue.Split(',');
                airSearchCondition.Airlines = txtAirline.Text.Split(',');
            }

            sc.CurrentItinerary.SearchInfo = airSearchCondition;
            //this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

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
                    Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + this.Transaction.IntKey.ToString());
                }
                else
                {
                    if (IsSelectAirport)
                        Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx?ConditionID=" + this.Transaction.IntKey.ToString());
                    else
                    {
                        Response.Redirect("~/Page/Flight/Searching.aspx" + "?ConditionID=" + this.Transaction.IntKey.ToString());
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
}
