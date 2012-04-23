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

using Terms.Global.Utility;
using Terms.Product.Utility;
using Terms.Base.Utility;
using Terms.Common.Dao;
using Terms.Common.Service;
using Terms.Sales.Dao;
using Terms.Sales.Domain;
using Terms.Sales.Utility;
using Terms.Sales.Service;
using Terms.Base.Service;
using Terms.Sales.Business;
using System.Globalization;
using Terms.Common.Domain;
using Terms.Material.Service;
using System.Collections.Generic;

public partial class SearchEngineAH : SalesBaseUserControl
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
        if (!IsPostBack)
        {
            dateDeparture_AH.IsCoercion = true;
            dateDeparture_AH.CoercionID = "dateReturn_AH";
            CheckIn_AH.IsCoercion = true;
            CheckIn_AH.CoercionID = "CheckOut_AH";
            txtFullFrom_AH.CssClass = "search_inp";
            txtFullTo_AH.CssClass = "search_inp";

            SetPageValidationGroup();

            dateDeparture_AH.BeginDate = DateTime.Now.AddDays(7);
            dateReturn_AH.BeginDate = DateTime.Now.AddDays(7);
            CheckIn_AH.BeginDate = DateTime.Now.AddDays(7);
            CheckOut_AH.BeginDate = DateTime.Now.AddDays(7);
        }
    }

    /// <summary>
    /// Only can input the letter
    /// </summary>
    public void OnlyInputENChar()
    {
        txtFullTo_AH.Attributes.Add("onKeyPress", "JHshTextPlus();");
        txtFullTo_AH.Attributes.Add("onblur", "CheckCondition(this);");

        txtFullFrom_AH.Attributes.Add("onblur", "CheckCondition(this);");
        txtFullFrom_AH.Attributes.Add("onKeyPress", "JHshTextPlus();");
    }

    public void SetPageValidationGroup()
    {
        ((TextBox)dateDeparture_AH.FindControl("calendarDate")).CssClass = "search_inp";
        ((TextBox)dateReturn_AH.FindControl("calendarDate")).CssClass = "search_inp";

        if (!IsSearchConditionNull)
        {
            BindHotelSearchCondition();

            if (this.Transaction.CurrentSearchConditions is HotelSearchCondition || this.Transaction.CurrentSearchConditions is AirSearchCondition)
            {
                ((TextBox)dateDeparture_AH.FindControl("calendarDate")).Text = DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                ((TextBox)dateReturn_AH.FindControl("calendarDate")).Text = DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            }
        }
        else
        {
            ((TextBox)dateDeparture_AH.FindControl("calendarDate")).Text = DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            ((TextBox)dateReturn_AH.FindControl("calendarDate")).Text = DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
        }
    }

    private void BindHotelSearchCondition()
    {
        if (this.Transaction == null) return;
        if (this.Transaction.CurrentSearchConditions == null) return;
        if ((this.Transaction.CurrentSearchConditions is HotelSearchCondition) == false) return;

        if (this.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            PackageSearchCondition packageSearchCondition = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;
            TextBox checkinCalendar = (TextBox)this.dateDeparture_AH.FindControl("calendarDate");
            TextBox checkoutCalendar = (TextBox)this.dateReturn_AH.FindControl("calendarDate");
            checkinCalendar.Text = packageSearchCondition.AirSearchCondition.GetAddTripCondition()[0].DepartureDate.ToString("d", DateTimeFormatInfo.InvariantInfo);
            checkoutCalendar.Text = packageSearchCondition.AirSearchCondition.GetAddTripCondition()[1].DepartureDate.ToString("d", DateTimeFormatInfo.InvariantInfo);

            TextBox checkinCalendarH = (TextBox)this.CheckIn_AH.FindControl("calendarDate");
            TextBox checkoutCalendarH = (TextBox)this.CheckOut_AH.FindControl("calendarDate");
            checkinCalendarH.Text = packageSearchCondition.HotelSearchCondition.CheckIn.ToString("d", DateTimeFormatInfo.InvariantInfo);
            checkoutCalendarH.Text = packageSearchCondition.HotelSearchCondition.CheckOut.ToString("d", DateTimeFormatInfo.InvariantInfo);
        }
    }

    protected void btn_Search_AH_Click(object sender, EventArgs e)
    {
        if (Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchPackage, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchPackage, this);

        if (!Page.IsValid)
            return;

        DateTime dateDept_A = Convert.ToDateTime(this.dateDeparture_AH.CDate);
        DateTime dateRtn_A = Convert.ToDateTime(this.dateReturn_AH.CDate);
        DateTime dateChinkIn_H;
        DateTime dateChinkOut_H;

        txtFrom_AH.Text = ConvertName(txtFullFrom_AH.Text);
        txtTo_AH.Text = ConvertName(txtFullTo_AH.Text);

        if (this.CheckIn_AH.CDate == "__/__/____" || this.CheckIn_AH.CDate == "")
            dateChinkIn_H = dateDept_A.AddDays(1);  //若Check in为空，则默认为Air出发日期加一天
        else
            dateChinkIn_H = Convert.ToDateTime(this.CheckIn_AH.CDate);

        if (this.CheckOut_AH.CDate == "__/__/____" || this.CheckOut_AH.CDate == "")
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

        //Utility.SelectAirGroup = null;
        PackageSearchCondition PacakgeSearch = new PackageSearchCondition();
        PacakgeSearch.IsReset = true;

        PacakgeSearch.DepatrueAirPorts = new List<Terms.Common.Domain.Airport>();
        if (txtFrom_AH.Text.Trim().Length > 3)
        {
            IList departureAirPorts = _CommonService.FindAirportByCityName(txtFrom_AH.Text.Trim());

            if (departureAirPorts.Count >= 1)
            {
                PacakgeSearch.DepatrueAirPorts = departureAirPorts;
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(txtFrom_AH.Text.Trim(), airportList);
                if (airport != null)
                {
                    PacakgeSearch.DepatrueAirPorts.Add(airport);
                }
            }
        }
        else
        {
            //PacakgeSearch.DepatrueAirPorts.Add(AirService.CommAirportDao.FindByAirport(txtDepartureFrom.Text.Trim()));
            Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(txtFrom_AH.Text.Trim());

            if (airport != null)
            {
                PacakgeSearch.DepatrueAirPorts.Add(airport);
            }
            else
            {
                IList departureAirPorts = AirService.CommAirportDao.FindByCityCode(txtFrom_AH.Text.Trim());

                if (departureAirPorts.Count >= 1)
                {
                    PacakgeSearch.DepatrueAirPorts = departureAirPorts;
                }
            }
        }

        PacakgeSearch.DestinationAirPorts = new List<Terms.Common.Domain.Airport>();
        if (txtTo_AH.Text.Trim().Length > 3)
        {
            IList DestinationOneAirPorts = _CommonService.FindAirportByCityName(txtTo_AH.Text.Trim());

            if (DestinationOneAirPorts.Count >= 1)
            {
                PacakgeSearch.DestinationAirPorts = DestinationOneAirPorts;
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(txtTo_AH.Text.Trim(), airportList);
                if (airport != null)
                {
                    PacakgeSearch.DestinationAirPorts.Add(airport);
                }
            }
        }
        else
        {
            Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(txtTo_AH.Text.Trim());

            if (airport != null)
            {
                PacakgeSearch.DestinationAirPorts.Add(airport);
            }
            else
            {
                IList DestinationOneAirPorts = AirService.CommAirportDao.FindByCityCode(txtTo_AH.Text.Trim());

                if (DestinationOneAirPorts.Count >= 1)
                {
                    PacakgeSearch.DestinationAirPorts = DestinationOneAirPorts;
                }
            }
        }

        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Adult, TravelerChange2.TotalAdults);
        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Child, TravelerChange2.TotalChilds);

        //判断输入的出发地和目的地有没有机场
        if (PacakgeSearch.DepatrueAirPorts.Count == 0)
        {
            Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtFrom_AH.Text + "\"&GoToPage=~/index.aspx");
        }

        if (PacakgeSearch.DestinationAirPorts.Count == 0)
        {
            Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtTo_AH.Text + "\"&GoToPage=~/index.aspx");
        }

        for (int i = 0; i < TravelerChange2.Rooms; i++)
        {
            RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

            roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Adult, TravelerChange2.Adults[i]);
            roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Child, TravelerChange2.Childs[i]);

            PacakgeSearch.HotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
        }

        if (PacakgeSearch.DestinationAirPorts.Count > 0 || PacakgeSearch.DepatrueAirPorts.Count > 0)
        {
            PacakgeSearch.HotelSearchCondition.CheckIn = dateChinkIn_H.AddDays(0);
            PacakgeSearch.HotelSearchCondition.CheckOut = dateChinkOut_H;
            PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).CityCode;// "PVG";
            PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
            PacakgeSearch.HotelSearchCondition.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Country.Code;

            AirTripCondition DPTairTripCondition = new AirTripCondition();
            DPTairTripCondition.Departure = (Airport)PacakgeSearch.DepatrueAirPorts[0];
            DPTairTripCondition.DepartureDate = Convert.ToDateTime(this.dateDeparture_AH.CDate);
            DPTairTripCondition.Destination = (Airport)PacakgeSearch.DestinationAirPorts[0];
            DPTairTripCondition.IsDepartureTimeSpecified = this.chbFlexible_AH.Checked;
            PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
            AirTripCondition RTNairTripCondition = new AirTripCondition();
            RTNairTripCondition.Departure = (Airport)PacakgeSearch.DestinationAirPorts[0];
            RTNairTripCondition.DepartureDate = Convert.ToDateTime(this.dateReturn_AH.CDate);
            RTNairTripCondition.Destination = (Airport)PacakgeSearch.DepatrueAirPorts[0];
            RTNairTripCondition.IsDepartureTimeSpecified = this.chbFlexible_AH.Checked;
            PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);
            PacakgeSearch.AirSearchCondition.FlightType = "roundtrip";

            if (ddlAirline.SelectedValue != "all")
            {
                PacakgeSearch.AirSearchCondition.Airlines = new string[1] { ddlAirline.SelectedValue.Trim() };
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
            if (rdoLstCabin_AH.SelectedIndex == 0)
            {
                cabin = TERMS.Common.CabinType.Economy;
            }
            else if (rdoLstCabin_AH.SelectedIndex == 1)
            {
                cabin = TERMS.Common.CabinType.Business;
            }
            else if (rdoLstCabin_AH.SelectedIndex == 2)
            {
                cabin = TERMS.Common.CabinType.First;
            }

            for (int i = 0; i < PacakgeSearch.AirSearchCondition.AirTripCondition.Count; i++)
                PacakgeSearch.AirSearchCondition.AirTripCondition[i].Cabin = cabin;

            if (PacakgeSearch.DestinationAirPorts.Count > 1 || PacakgeSearch.DepatrueAirPorts.Count > 1)
            {
                this.Page.Response.Redirect("~/Page/Package/PackageSearchMoreForm.aspx?ConditionID=" + this.Transaction.IntKey.ToString());
            }
            else
            {
                Utility.Transaction.Difference.Clear();
                Utility.Transaction.Difference.FromTime = DateTime.Now;
                Utility.Transaction.Difference.StarTime = DateTime.Now;
                Utility.Transaction.Difference.From = "PackageSearchMoreForm Redirect Start";
                this.Page.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package2/ViewYourPackages" + "&ConditionID=" + this.Transaction.IntKey.ToString());
            }
        }
        else
        {

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

    private string ConvertName(string fullname)
    {
        int index = fullname.IndexOf("-");

        if (index > 0)
        {
            int end = fullname.Substring(index + 1).IndexOf(",");
            if (end > 0)
            {
                return fullname.Substring(index + 1, end).Trim();
            }
            else
            {
                return fullname.Substring(index + 1).Trim();
            }
        }
        else
        {
            return fullname.Trim();
        }
    }
}
