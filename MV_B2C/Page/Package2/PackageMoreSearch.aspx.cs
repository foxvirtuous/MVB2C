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
using System.Globalization;
using log4net;

using Terms.Sales.Domain;
using Terms.Sales.Service;
using Terms.Common.Service;
using Terms.Common.Domain;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;


public partial class PackageMoreSearch : SalseBasePage
{
     private CommonService _commonService;
    public CommonService CommonService
    {
        set
        {
            _commonService = value;
        }
    }
    public PackageMoreSearch()
    {
        this.InitializeControls += new EventHandler(PackageMoreSearch_InitializeControls);
    }

    private void PackageMoreSearch_InitializeControls(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        try
        {
            dateDepatrue.Path = dateReturn.Path = CheckIn_AH.Path = CheckOut_AH.Path = "../../";
            //this.dateDepatrue.ArrDate = "'3/4/2008|3/6/2008', '3/14/2008|3/26/2008', '4/4/2008|4/6/2008', '4/14/2008|4/26/2008','6/14/2008|12/26/2008'".Split(',');
            //this.dateReturn.ArrDate = "'4/5/2008|4/7/2008', '4/15/2008|4/27/2008', '5/5/2008|5/7/2008', '6/15/2008|6/27/2008','7/14/2008|11/26/2008'".Split(',');

            if (!IsPostBack)
            {
                Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
                Navigation1.PageCode = 1;

                dateDepatrue.IsCoercion = true;
                dateDepatrue.CoercionID = "dateReturn";

                CheckIn_AH.IsCoercion = true;
                CheckIn_AH.CoercionID = "CheckOut_AH";

                InitSet();
                InitCondition();

                dateDepatrue.BeginDate = DateTime.Now.AddDays(7);
                dateReturn.BeginDate = DateTime.Now.AddDays(7);
                CheckIn_AH.BeginDate = DateTime.Now.AddDays(7);
                CheckOut_AH.BeginDate = DateTime.Now.AddDays(7);

                OnlyInputENChar();
            }
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }

    private void OnlyInputENChar()
    {
        this.txtDepartureFrom.Attributes.Add("onKeyPress", "JHshTextPlus();");
        this.txtDepartureFrom.Attributes.Add("onkeydown", "fncKeyStop(event);");
        this.txtDepartureFrom.Attributes.Add("onpaste", "return false;");
        this.txtDepartureFrom.Attributes.Add("oncontextmenu", "return false;");
        this.txtReturn.Attributes.Add("onKeyPress", "JHshTextPlus();");
        this.txtReturn.Attributes.Add("onkeydown", "fncKeyStop(event);");
        this.txtReturn.Attributes.Add("onpaste", "return false;");
        this.txtReturn.Attributes.Add("oncontextmenu", "return false;");
    }

    private void InitSet()
    {
        this.txtDepartureFrom.Text = ((Terms.Common.Domain.Airport)((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts[0]).City.Name;
        this.txtReturn.Text = ((Terms.Common.Domain.Airport)((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts[0]).City.Name;
        TextBox dateDep = (TextBox)this.dateDepatrue.FindControl("calendarDate");
        dateDep.Text = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
        if (((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.Airlines != null)
            ddlAirLine.SelectedIndex = ddlAirLine.Items.IndexOf(ddlAirLine.Items.FindByValue(((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.Airlines[0]));

        TextBox dateRtn = (TextBox)this.dateReturn.FindControl("calendarDate");
        dateRtn.Text = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

        TextBox checkIn = (TextBox)this.CheckIn_AH.FindControl("calendarDate");
        checkIn.Text = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn.AddDays(0).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);


        TextBox checkOut = (TextBox)this.CheckOut_AH.FindControl("calendarDate");
        checkOut.Text = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);


        this.TravelerChange1.Rooms = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).HotelSearchCondition.RoomSearchConditions.Count;

    }

    private void InitCondition()
    {

        if (((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts.Count > 1)
        {
            string name = ((Terms.Common.Domain.Airport)((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts[0]).DisplayWholeName;
            this.listBDepartureAirport.DataValueField = "Code";
            this.listBDepartureAirport.DataTextField = "DisplayWholeName";
            this.listBDepartureAirport.DataSource = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts;
            this.listBDepartureAirport.DataBind();
            this.listBDepartureAirport.Visible = true;
            this.lbSelect.Visible = true;
        }
        if (((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts.Count > 1)
        {
            this.listBReturnAirport.DataValueField = "Code";
            this.listBReturnAirport.DataTextField = "DisplayWholeName";
            this.listBReturnAirport.DataSource = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts;
            this.listBReturnAirport.DataBind();
            this.listBReturnAirport.Visible = true;
            this.lbRTSelect.Visible = true;
        }
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {

        if (listBDepartureAirport.Visible == true && listBDepartureAirport.SelectedIndex == -1)
        {
            return;
        }
        if (listBReturnAirport.Visible == true && listBReturnAirport.SelectedIndex == -1)
        {
            return;
        }
        PackageSearchCondition PacakgeSearch = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;

        DateTime dateDept_A = Convert.ToDateTime(this.dateDepatrue.CDate);
        DateTime dateRtn_A = Convert.ToDateTime(this.dateReturn.CDate);
        DateTime dateChinkIn_H;
        DateTime dateChinkOut_H;

        if (this.CheckIn_AH.CDate == "__/__/____")
            dateChinkIn_H = dateDept_A.AddDays(1);  //若Check in为空，则默认为Air出发日期加一天
        else
            dateChinkIn_H = Convert.ToDateTime(this.CheckIn_AH.CDate);

        if (this.CheckOut_AH.CDate == "__/__/____")
            dateChinkOut_H = dateRtn_A;             //若Check out为空，则默认为Air返回日期
        else
            dateChinkOut_H = Convert.ToDateTime(this.CheckOut_AH.CDate);

        if (dateDept_A < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Departure date is greater than the current date seven days.');</script>");
            return;
        }

        if (dateRtn_A < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Return date is greater than the current date seven days.');</script>");
            return;
        }

        if (dateChinkIn_H < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Departure date is greater than the current date seven days.');</script>");
            return;
        }

        if (dateChinkOut_H < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Return date is greater than the current date seven days.');</script>");
            return;
        }

        if (dateChinkIn_H < DateTime.Today && dateChinkOut_H < DateTime.Today)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We can only accept dates that occur between " + DateTime.Today.AddDays(1).ToString("MM/dd/yyyy") + " and 12/27/2008. Please enter a new date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateChinkIn_H <= DateTime.Today)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-in date must occur after the today date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateChinkIn_H > dateChinkOut_H)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-out date must occur after the check-in date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateDept_A >= dateRtn_A)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The Depart date must occur after the Return date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateDept_A > dateChinkIn_H)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-in date must occur after the Depart date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }

        if (dateChinkOut_H > dateRtn_A)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The Return date must occur after the check-out date. Please change the date.&&GoToPage=~/Index.aspx");
            return;
        }



        PacakgeSearch.HotelSearchCondition.CheckIn = dateChinkIn_H;
        PacakgeSearch.HotelSearchCondition.CheckOut = dateChinkOut_H;

        if (PacakgeSearch.DestinationAirPorts.Count > 1)
            PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[this.listBReturnAirport.SelectedIndex]).City.Code;//"PVG";
        else
            PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Code;
        PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
        PacakgeSearch.HotelSearchCondition.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Country.Code;

        PacakgeSearch.HotelSearchCondition.RoomSearchConditions.Clear();
        for (int i = 0; i < TravelerChange1.Rooms; i++)
        {
            RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

            roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Adult, TravelerChange1.Adults[i]);
            roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Child, TravelerChange1.Childs[i]);

            PacakgeSearch.HotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
        }


        //保存Cabin
        TERMS.Common.CabinType cabin = TERMS.Common.CabinType.Economy;

        if (PacakgeSearch.AirSearchCondition.AirTripCondition != null)
            if (PacakgeSearch.AirSearchCondition.AirTripCondition.Count > 0)
                cabin = PacakgeSearch.AirSearchCondition.AirTripCondition[0].Cabin;


        PacakgeSearch.AirSearchCondition.AirTripCondition.Clear();

        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Adult, TravelerChange1.TotalAdults);
        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Child, TravelerChange1.TotalChilds);

        AirTripCondition DPTairTripCondition = new AirTripCondition();
        if (PacakgeSearch.DepatrueAirPorts.Count > 1)
            DPTairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[this.listBDepartureAirport.SelectedIndex];
        else
            DPTairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
        DPTairTripCondition.DepartureDate = Convert.ToDateTime(this.dateDepatrue.CDate);
        if (PacakgeSearch.DestinationAirPorts.Count > 1)
            DPTairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[this.listBReturnAirport.SelectedIndex];
        else
            DPTairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0];
        DPTairTripCondition.IsDepartureTimeSpecified = this.chkflexible.Checked;
        DPTairTripCondition.Cabin = cabin; //还原Cabin

        PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);

        if (ddlAirLine.SelectedValue != "all")
        {
            PacakgeSearch.AirSearchCondition.Airlines = ddlAirLine.SelectedValue.Split(',');
        }
        else
        {
            PacakgeSearch.AirSearchCondition.Airlines = null;
        }
       
        AirTripCondition RTNairTripCondition = new AirTripCondition();
        if (PacakgeSearch.DestinationAirPorts.Count > 1)
            RTNairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[this.listBReturnAirport.SelectedIndex];
        else
            RTNairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0];
        RTNairTripCondition.DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);
        if (PacakgeSearch.DepatrueAirPorts.Count > 1)
            RTNairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[this.listBDepartureAirport.SelectedIndex];
        else
            RTNairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
        RTNairTripCondition.IsDepartureTimeSpecified = this.chkflexible.Checked;
        RTNairTripCondition.Cabin = cabin; //还原Cabin

        PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);

        PacakgeSearch.AirSearchCondition.FlightType = "roundtrip";
        //PacakgeSearch.AirSearchCondition.ProductType = TERMS.Common.ProductType.Package;
        PacakgeSearch.OptionalHotelSearchConditions.Clear();
        this.Transaction.CurrentSearchConditions = PacakgeSearch;

        this.Page.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package2/ViewYourPackages" + "&ConditionID=" + Request.Params["ConditionID"]);

    }
}

