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
using Terms.Sales.Business;
using Terms.Common.Service;
using System.Globalization;

public partial class SearchConditionsMeassageForm : SalseBasePage
{
    private CommonService _commonService;
    public CommonService CommonService
    {
        set
        {
            _commonService = value;
        }
    }

    public SearchConditionsMeassageForm()
    {
        this.InitializeControls += new EventHandler(SearchConditionsMeassageForm_InitializeControls);
    }

    void SearchConditionsMeassageForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        try
        {
            departureCalendar.Path = returnCalendar.Path  = this.dateCheckIn.Path = this.dateCheckOut.Path =  "../../";
            //this.dateDepatrue.ArrDate = "'3/4/2008|3/6/2008', '3/14/2008|3/26/2008', '4/4/2008|4/6/2008', '4/14/2008|4/26/2008','6/14/2008|12/26/2008'".Split(',');
            //this.dateReturn.ArrDate = "'4/5/2008|4/7/2008', '4/15/2008|4/27/2008', '5/5/2008|5/7/2008', '6/15/2008|6/27/2008','7/14/2008|11/26/2008'".Split(',');

            if (!IsPostBack)
            {
                departureCalendar.IsCoercion = true;
                departureCalendar.CoercionID = "returnCalendar";
                dateCheckIn.IsCoercion = true;
                dateCheckIn.CoercionID = "dateCheckOut";

                InitSet();
                InitCondition();
            }
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }

    private void InitSet()
    {
        txtDepartureFrom.Text = "";

        txtTo.Text = ((Terms.Common.Domain.Airport)((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts[0]).City.Name;
        TextBox dateDep = (TextBox)this.departureCalendar.FindControl("calendarDate");
        dateDep.Text = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
        TextBox dateCheckin = (TextBox)this.dateCheckIn.FindControl("calendarDate");
        dateCheckin.Text = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate.AddDays(1).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

        TextBox dateRtn = (TextBox)this.returnCalendar.FindControl("calendarDate");
        dateRtn.Text = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
        TextBox dateCheckout = (TextBox)this.dateCheckOut.FindControl("calendarDate");
        dateCheckout.Text = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);


    }

    private void InitCondition()
    {

        if (((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts != null && ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts.Count > 1)
        {
            string name = ((Terms.Common.Domain.Airport)((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts[0]).DisplayWholeName;
            this.listBDepartureAirport.DataValueField = "Code";
            this.listBDepartureAirport.DataTextField = "DisplayWholeName";
            this.listBDepartureAirport.DataSource = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DepatrueAirPorts;
            this.listBDepartureAirport.DataBind();
            this.listBDepartureAirport.Visible = true;
            this.div_From1.Visible = true;
            this.lbSelect.Visible = true;
        }
        if (((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts.Count > 1)
        {
            this.listBReturnAirport.DataValueField = "Code";
            this.listBReturnAirport.DataTextField = "DisplayWholeName";
            this.listBReturnAirport.DataSource = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts;
            this.listBReturnAirport.DataBind();
            this.listBReturnAirport.Visible = true;
            this.lbRtnSelect.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if (listBDepartureAirport.Visible == true && listBDepartureAirport.SelectedIndex == -1)
        //{
        //    return;
        //}
        //if (listBReturnAirport.Visible == true && listBReturnAirport.SelectedIndex == -1)
        //{
        //    return;
        //}


        PackageSearchCondition PacakgeSearch = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;

        if (this.departureCalendar.CDate == "__/__/____")
        {
            this.lbDepDateErr.Visible = true;
            return;
        }

        if (this.returnCalendar.CDate == "__/__/____")
        {
            this.lbRtnDateErr.Visible = true;
            return;
        }

        DateTime dateDept_A = Convert.ToDateTime(this.departureCalendar.CDate);
        DateTime dateRtn_A = Convert.ToDateTime(this.returnCalendar.CDate);
        DateTime dateChinkIn_H;
        DateTime dateChinkOut_H;

        if (this.dateCheckIn.CDate == "__/__/____")
            dateChinkIn_H = dateDept_A.AddDays(1);  //若Check in为空，则默认为Air出发日期加一天

        else
            dateChinkIn_H = Convert.ToDateTime(this.dateCheckIn.CDate);

        if (this.dateCheckOut.CDate == "__/__/____")
            dateChinkOut_H = dateRtn_A;             //若Check out为空，则默认为Air返回日期
        else
            dateChinkOut_H = Convert.ToDateTime(this.dateCheckOut.CDate);



        if (dateChinkIn_H < DateTime.Today && dateChinkOut_H < DateTime.Today)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We can only accept dates that occur between " + DateTime.Today.AddDays(1).ToString("MM/dd/yyyy") + " and 12/27/2008. Please enter a new date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx");
            return;
        }

        if (dateChinkIn_H <= DateTime.Today)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-in date must occur after the today date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx");
            return;
        }

        if (dateChinkIn_H > dateChinkOut_H)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-out date must occur after the check-in date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx");
            return;
        }

        if (dateDept_A >= dateRtn_A)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The Depart date must occur after the Return date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx");
            return;
        }

        if (dateDept_A > dateChinkIn_H)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-in date must occur after the Depart date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx");
            return;
        }

        if (dateChinkOut_H > dateRtn_A)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The Return date must occur after the check-out date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx");
            return;
        }



        PacakgeSearch.HotelSearchCondition.CheckIn = dateChinkIn_H;
        PacakgeSearch.HotelSearchCondition.CheckOut = dateChinkOut_H;

        IList departureAirPorts = _commonService.FindAirportByCityName(this.txtDepartureFrom.Text.Trim());
        PacakgeSearch.DepatrueAirPorts = departureAirPorts;
       

        //判断输入的出发地和目的地有没有机场

        if (PacakgeSearch.DepatrueAirPorts.Count == 0)
        {
            Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDepartureFrom.Text.Trim() + "\"&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx");
        }

        //if (PacakgeSearch.DestinationAirPorts.Count == 0)
        //{
        //    Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDestinationOne.Text + "\"&GoToPage=PackageSearch2dForm.aspx");
        //}

        //if (PacakgeSearch.DestinationAirPortsTwo.Count == 0)
        //{
        //    Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDestinationTwo.Text + "\"&GoToPage=PackageSearch2dForm.aspx");
        //}

        for (int i = 0; i < TravelerChange1.Rooms; i++)
        {
            RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

            roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Adult, TravelerChange1.Adults[i]);
            roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Child, TravelerChange1.Childs[i]);
        }

        if (PacakgeSearch.DestinationAirPorts.Count > 0 || PacakgeSearch.DepatrueAirPorts.Count > 0 )//|| PacakgeSearch.DestinationAirPortsTwo.Count > 0)
        {
            if (PacakgeSearch.DestinationAirPorts.Count > 1 || PacakgeSearch.DepatrueAirPorts.Count > 1 )//|| PacakgeSearch.DestinationAirPortsTwo.Count > 1)
            {
                this.Transaction.CurrentSearchConditions = PacakgeSearch;
                //多机场设置

                MoreAirportsSelect();
                this.btnSearch.Visible = false;
                this.btnSearch1.Visible = true;

            }
            else
            {
                PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateCheckIn.CDate);
                PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateCheckOut.CDate);

                if (PacakgeSearch.DestinationAirPorts.Count > 1)
                    PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[this.listBReturnAirport.SelectedIndex]).City.Code;//"PVG";
                else
                    PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Code;
                PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
                PacakgeSearch.HotelSearchCondition.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Country.Code;
                PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Adult, TravelerChange1.TotalAdults);
                PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Child, TravelerChange1.TotalChilds);

                AirTripCondition DPTairTripCondition = new AirTripCondition();
                if (PacakgeSearch.DepatrueAirPorts.Count > 1)
                    DPTairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[this.listBDepartureAirport.SelectedIndex];
                else
                    DPTairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
                DPTairTripCondition.DepartureDate = Convert.ToDateTime(this.departureCalendar.CDate);
                if (PacakgeSearch.DestinationAirPorts.Count > 1)
                    DPTairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[this.listBReturnAirport.SelectedIndex];
                else
                    DPTairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0];
                //DPTairTripCondition.IsDepartureTimeSpecified = this.chkflexible.Checked;
                PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
                PacakgeSearch.AirSearchCondition.Airlines = null;


                AirTripCondition RTNairTripCondition = new AirTripCondition();
                if (PacakgeSearch.DestinationAirPorts.Count > 1)
                    RTNairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[this.listBReturnAirport.SelectedIndex];
                else
                    RTNairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0];
                RTNairTripCondition.DepartureDate = Convert.ToDateTime(this.returnCalendar.CDate);
                if (PacakgeSearch.DepatrueAirPorts.Count > 1)
                    RTNairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[this.listBDepartureAirport.SelectedIndex];
                else
                    RTNairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
                //RTNairTripCondition.IsDepartureTimeSpecified = this.chkflexible.Checked;
                PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);

                PacakgeSearch.AirSearchCondition.FlightType = "roundtrip";
                //PacakgeSearch.AirSearchCondition.ProductType = TERMS.Common.ProductType.Package;
                PacakgeSearch.OptionalHotelSearchConditions.Clear();
                this.Transaction.IntKey = PacakgeSearch.GetHashCode();
                this.Transaction.CurrentSearchConditions = PacakgeSearch;

                this.Page.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package/PackageSearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString(), false);
            }
        }
        else
        {

        }

    }

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
            this.lbSelect.Visible = true;
            this.div_From1.Visible = true;
        }
        if (((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts.Count > 1)
        {
            this.listBReturnAirport.DataValueField = "Code";
            this.listBReturnAirport.DataTextField = "DisplayWholeName";
            this.listBReturnAirport.DataSource = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).DestinationAirPorts;
            this.listBReturnAirport.DataBind();
            this.listBReturnAirport.Visible = true;
            this.lbRtnSelect.Visible = true;
        }

    }

    protected void btnSearch1_Click(object sender, EventArgs e)
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

        if (this.departureCalendar.CDate == "__/__/____")
        {
            this.lbDepDateErr.Visible = true;
            return;
        }

        if (this.returnCalendar.CDate == "__/__/____")
        {
            this.lbRtnDateErr.Visible = true;
            return;
        }

        DateTime dateDept_A = Convert.ToDateTime(this.departureCalendar.CDate);
        DateTime dateRtn_A = Convert.ToDateTime(this.returnCalendar.CDate);
        DateTime dateChinkIn_H;
        DateTime dateChinkOut_H;

        if (this.dateCheckIn.CDate == "__/__/____")
            dateChinkIn_H = dateDept_A.AddDays(1);  //若Check in为空，则默认为Air出发日期加一天

        else
            dateChinkIn_H = Convert.ToDateTime(this.dateCheckIn.CDate);

        if (this.dateCheckOut.CDate == "__/__/____")
            dateChinkOut_H = dateRtn_A;             //若Check out为空，则默认为Air返回日期
        else
            dateChinkOut_H = Convert.ToDateTime(this.dateCheckOut.CDate);



        if (dateChinkIn_H < DateTime.Today && dateChinkOut_H < DateTime.Today)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We can only accept dates that occur between " + DateTime.Today.AddDays(1).ToString("MM/dd/yyyy") + " and 12/27/2008. Please enter a new date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx", false);
            return;
        }

        if (dateChinkIn_H <= DateTime.Today)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-in date must occur after the today date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx", false);
            return;
        }

        if (dateChinkIn_H > dateChinkOut_H)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-out date must occur after the check-in date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx", false);
            return;
        }

        if (dateDept_A >= dateRtn_A)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The Depart date must occur after the Return date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx", false);
            return;
        }

        if (dateDept_A > dateChinkIn_H)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The check-in date must occur after the Depart date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx", false);
            return;
        }

        if (dateChinkOut_H > dateRtn_A)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The Return date must occur after the check-out date. Please change the date.&&GoToPage=~/Page/Package/SearchConditionsMeassageForm.aspx", false);
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

        PacakgeSearch.AirSearchCondition.AirTripCondition.Clear();

        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Adult, TravelerChange1.TotalAdults);
        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Child, TravelerChange1.TotalChilds);

        AirTripCondition DPTairTripCondition = new AirTripCondition();
        if (PacakgeSearch.DepatrueAirPorts.Count > 1)
            DPTairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[this.listBDepartureAirport.SelectedIndex];
        else
            DPTairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
        DPTairTripCondition.DepartureDate = Convert.ToDateTime(this.departureCalendar.CDate);
        if (PacakgeSearch.DestinationAirPorts.Count > 1)
            DPTairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[this.listBReturnAirport.SelectedIndex];
        else
            DPTairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0];
        //DPTairTripCondition.IsDepartureTimeSpecified = this.chkflexible.Checked;
        PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
        PacakgeSearch.AirSearchCondition.Airlines = null;


        AirTripCondition RTNairTripCondition = new AirTripCondition();
        if (PacakgeSearch.DestinationAirPorts.Count > 1)
            RTNairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[this.listBReturnAirport.SelectedIndex];
        else
            RTNairTripCondition.Departure = (Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0];
        RTNairTripCondition.DepartureDate = Convert.ToDateTime(this.returnCalendar.CDate);
        if (PacakgeSearch.DepatrueAirPorts.Count > 1)
            RTNairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[this.listBDepartureAirport.SelectedIndex];
        else
            RTNairTripCondition.Destination = (Terms.Common.Domain.Airport)PacakgeSearch.DepatrueAirPorts[0];
        //RTNairTripCondition.IsDepartureTimeSpecified = this.chkflexible.Checked;
        PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);

        PacakgeSearch.AirSearchCondition.FlightType = "roundtrip";
        //PacakgeSearch.AirSearchCondition.ProductType = TERMS.Common.ProductType.Package;
        PacakgeSearch.OptionalHotelSearchConditions.Clear();
        this.Transaction.CurrentSearchConditions = PacakgeSearch;

        this.Page.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package/PackageSearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString(), false);
    }
}
