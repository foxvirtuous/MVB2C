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
using System.Globalization;

using log4net;

using Terms.Global.Utility;
using Terms.Sales.Service;
using Terms.Common.Service;
using Terms.Common.Domain;

using Terms.Sales.Business;
using TERMS.Common;

public partial class SearchConditionsForm : AirBook.Base.BookingPage
{
    private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger("AirSearchTime");

    private CommonService _commonService;
    public CommonService CommonService
    {
        set
        {
            _commonService = value;
        }
    }

    public Transaction Transaction
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
    private Terms.Material.Service.AirService m_airService;
    protected Terms.Material.Service.AirService AirService
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
        
        departureCalendar.Path = returnCalendar.Path = "../../";

        try
        {
            if (!IsPostBack)
            {
                //Navigation1.PageCode = 1;

                departureCalendar.IsCoercion = true;
                departureCalendar.CoercionID = "returnCalendar";
                InitSet();
                InitAirline();
                InitCondition();
                OnlyInputENChar();

                if (Request["DateErrorMsg"] != null)
                {
                    Label2.Visible = false;
                    lblDateErrorMsg.Visible = true;
                    lblDateErrorMsg.Text = Request["DateErrorMsg"];
                }
            }
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }

    private void OnlyInputENChar()
    {
        txtDepartureFrom.Attributes.Add("onKeyPress", "JHshTextPlus();");
        txtDepartureFrom.Attributes.Add("onblur", "CheckCondition(this);");

        txtReturnFrom.Attributes.Add("onKeyPress", "JHshTextPlus();");
        txtReturnFrom.Attributes.Add("onblur", "CheckCondition(this);");

        txtReturnTo.Attributes.Add("onKeyPress", "JHshTextPlus();");
        txtReturnTo.Attributes.Add("onblur", "CheckCondition(this);");

        txtTo.Attributes.Add("onKeyPress", "JHshTextPlus();");
        txtTo.Attributes.Add("onblur", "CheckCondition(this);");

        txtAirline.Attributes.Add("onKeyPress", "InputAirline();");
        txtAirline.Attributes.Add("onblur", "CheckCondition(this);");
 
    }

    private void InitSet()
    {

        if (CurrentSession.FromAirports != null)
        {
            this.txtDepartureFrom.Text = ((Terms.Common.Domain.Airport)CurrentSession.FromAirports[0]).City.Name;
            this.div_From.Visible = true;
        }
        if (CurrentSession.ToAirports != null)
        {
            this.txtTo.Text = ((Terms.Common.Domain.Airport)CurrentSession.ToAirports[0]).City.Name;
            this.div_To.Visible = true;
        }

        if (CurrentSession.ReturnFromAirports != null)
        {
            this.txtReturnFrom.Text = ((Terms.Common.Domain.Airport)CurrentSession.ReturnFromAirports[0]).City.Name;
            this.div_ReturnFrom.Visible = true;
            this.div_OpenJw.Visible = true;
        }
        if (CurrentSession.ReturnToAirports != null)
        {
            this.txtReturnTo.Text = ((Terms.Common.Domain.Airport)CurrentSession.ReturnToAirports[0]).City.Name;
            this.div_ReturnTo.Visible = true;
            this.div_OpenJw.Visible = true;
        }
    }

    private void InitCondition()
    {
        string name = string.Empty;
        AirSearchCondition airSearchCondition = (AirSearchCondition)Transaction.CurrentSearchConditions;
        TextBox departureCalendarDate = (TextBox)this.departureCalendar.FindControl("calendarDate");
        departureCalendarDate.Text = airSearchCondition.AirTripCondition[0].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

        if (!airSearchCondition.FlightType.ToUpper().Equals("ROUNDTRIP"))
            this.lbl_isRoundTrip.Text = string.Empty;
        if (airSearchCondition.FlightType.ToUpper().Equals("ONEWAY"))
        {
            this.div_OneWay.Visible = false;
            this.lbl_isOneWay.Text = string.Empty;
        }
        else
        {
            TextBox returnCalendarDate = (TextBox)this.returnCalendar.FindControl("calendarDate");
            returnCalendarDate.Text = airSearchCondition.AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
        }
        if (CurrentSession.FromAirports != null)
        {
            name = ((Terms.Common.Domain.Airport)CurrentSession.FromAirports[0]).City.Name;
            this.listBDepartureAirport.DataValueField = "Code";
            this.listBDepartureAirport.DataTextField = "DisplayWholeName";
            this.listBDepartureAirport.DataSource = CurrentSession.FromAirports;
            this.listBDepartureAirport.DataBind();
            this.listBDepartureAirport.Visible = true;
            this.lblFrom.Text = name;
        }
        if (CurrentSession.ToAirports != null)
        {
            name = ((Terms.Common.Domain.Airport)CurrentSession.ToAirports[0]).City.Name;
            this.listBToAirport.DataValueField = "Code";
            this.listBToAirport.DataTextField = "DisplayWholeName";
            this.listBToAirport.DataSource = CurrentSession.ToAirports;
            this.listBToAirport.DataBind();
            this.listBToAirport.Visible = true;
            this.lblTo.Text = name;
        }

        if (CurrentSession.ReturnFromAirports != null)
        {
            name = ((Terms.Common.Domain.Airport)CurrentSession.ReturnFromAirports[0]).City.Name;
            this.listBReturnFrom.DataValueField = "Code";
            this.listBReturnFrom.DataTextField = "DisplayWholeName";
            this.listBReturnFrom.DataSource = CurrentSession.ReturnFromAirports;
            this.listBReturnFrom.DataBind();
            this.listBReturnFrom.Visible = true;
            this.lblReturnFrom.Text = name;
        }
        if (CurrentSession.ReturnToAirports != null)
        {
            name = ((Terms.Common.Domain.Airport)CurrentSession.ReturnToAirports[0]).City.Name;
            this.listBReturnTo.DataValueField = "Code";
            this.listBReturnTo.DataTextField = "DisplayWholeName";
            this.listBReturnTo.DataSource = CurrentSession.ReturnToAirports;
            this.listBReturnTo.DataBind();
            this.listBReturnTo.Visible = true;
            this.lblReturnTo.Text = name;
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

   

    private void InitAirline()
    {
        Terms.Material.Service.AirService airService = new Terms.Material.Service.AirService();

        if (Application["Allairways"] == null)
        {
            Application["Allairways"] = airService.GetAllAirLines();
        }

        //DataSet ds = (DataSet)(Application["Allairways"]);

        //for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
        //{
        //    BulletedList1.Items.Add(new ListItem(ds.Tables[0].Rows[i][0].ToString(), "javascript:IntxtAirline('" + txtAirline.ClientID + "','" + ds.Tables[0].Rows[i][1].ToString() + "');"));
        //}

        BulletedList1.Items.Add(new ListItem());
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (CurrentSession == null)
        {
            Response.Redirect("~/Page/Sales/ErrorMessage.aspx?ErrorMessage=Time out,please back homepage and search again.&GoToPage=~/index.aspx");

        }

        try
        {
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
            string logAirline = txtAirline.Text.Trim().Equals(string.Empty) ? "All" : txtAirline.Text;
            log.Info(Session["LOG_RANDOM"].ToString() + " >==========================AirLine:" + logAirline + "========================");
            log.Info(Session["LOG_RANDOM"].ToString() + " >SearchClick Begin Start time : " + System.DateTime.Now);
            //log end 20090312 Leon
        }
        catch
        {

        }

        CurrentSession.CurrentItinerary.SearchInfo.SetPassengerNumber(PassengerType.Adult, Convert.ToInt32(ddlAdult.SelectedValue));

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

        if (txtAirline.Text.Trim() != "")
        {
            //param.Airways = ddlAirline.SelectedValue.Split(',');
            CurrentSession.CurrentItinerary.SearchInfo.Airlines = txtAirline.Text.Split(',');
        }

        CurrentSession.CurrentItinerary.SearchInfo.SetPassengerNumber(PassengerType.Child, Convert.ToInt32(ddlChild.SelectedValue));
        //CurrentSession.CurrentItinerary.SearchInfo.SetPassengerNumber(PassengerType.Infant, Convert.ToInt32(ddlInfant.SelectedValue));


        if (CurrentSession.FromAirports != null)
        {
            if (listBDepartureAirport.SelectedIndex == -1)
                return;
            Terms.Common.Domain.Airport airport = (Terms.Common.Domain.Airport)CurrentSession.FromAirports[listBDepartureAirport.SelectedIndex];
            CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[0].Departure = airport;

            // if (!CurrentSession.CurrentItinerary.SearchInfo.FlightType.ToUpper().Equals("ONEWAY"))
            CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[1].Destination = airport;
            //airTripCondition1.Departure = airport;

        }

        if (CurrentSession.ToAirports != null)
        {
            if (listBToAirport.SelectedIndex == -1)
                return;
            Terms.Common.Domain.Airport airport = (Terms.Common.Domain.Airport)CurrentSession.ToAirports[listBToAirport.SelectedIndex];
            CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[0].Destination = airport;
            //if (!CurrentSession.CurrentItinerary.SearchInfo.FlightType.ToUpper().Equals("ONEWAY"))
            CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[1].Departure = airport;
        }

        if (CurrentSession.ReturnFromAirports != null)
        {
            if (listBReturnFrom.SelectedIndex == -1)
                return;
            Terms.Common.Domain.Airport airport = (Terms.Common.Domain.Airport)CurrentSession.FromAirports[listBReturnFrom.SelectedIndex];
            CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[1].Departure = airport;
        }

        if (CurrentSession.ReturnToAirports != null)
        {
            if (listBReturnTo.SelectedIndex == -1)
                return;
            Terms.Common.Domain.Airport airport = (Terms.Common.Domain.Airport)CurrentSession.FromAirports[listBReturnTo.SelectedIndex];
            CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[1].Destination = airport;
        }


        CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[0].Cabin = cabin;
        CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[0].DepartureDate = GlobalUtility.GetDateTime(this.departureCalendar.CDate.Trim());

        if (CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[0].DepartureDate < DateTime.Now.AddDays(3))
        {
            Label2.Visible = false; lblDateErrorMsg.Visible = true;
            lblDateErrorMsg.Text = Resources.HintInfo.AirDateError;
            return;
        }

        if (!CurrentSession.CurrentItinerary.SearchInfo.FlightType.ToUpper().Equals("ONEWAY"))
        {
            CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[1].Cabin = cabin;
            CurrentSession.CurrentItinerary.SearchInfo.AirTripCondition[1].DepartureDate = GlobalUtility.GetDateTime(this.returnCalendar.CDate.Trim());
        }

        this.Transaction.CurrentSearchConditions = CurrentSession.CurrentItinerary.SearchInfo;

        log.Info(Session["LOG_RANDOM"].ToString() + " >Redirect Searching.aspx Begin Start time : " + System.DateTime.Now);

        Response.Redirect("~/Page/Flight/Searching.aspx?ConditionID=" + Request.Params["ConditionID"]);

    }
    protected void lnHelper_Click(object sender, EventArgs e)
    {
        BulletedList1.Items.Clear();

        DataSet ds = (DataSet)(Application["Allairways"]);

        for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
        {
            BulletedList1.Items.Add(new ListItem(ds.Tables[0].Rows[i][0].ToString(), "javascript:IntxtAirline('" + txtAirline.ClientID + "','" + ds.Tables[0].Rows[i][1].ToString() + "');"));
        }

        lnHelper.OnClientClick = "return false;";
    }
}
