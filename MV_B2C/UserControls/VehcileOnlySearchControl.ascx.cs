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
using Terms.Sales.Business;
using Terms.Common.Service;
using Terms.Sales.Service;
using System.Collections.Generic;
using TERMS.Common;


public partial class VehcileOnlySearchControl : SalesBaseUserControl
{
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

    }

    public VehcileOnlySearchControl()
    {
        this.InitializeControls += new EventHandler(VehcileOnlySearchControl_InitializeControls);
    }

    void VehcileOnlySearchControl_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        this.txtPickupDate.Path = "../../";
        this.txtDropoffDate.Path = "../../";

        txtPickupDate.IsCoercion = true;
        txtPickupDate.CoercionID = "txtDropoffDate";

        if (!IsPostBack)
        {
            if (Utility.Transaction.CurrentSearchConditions != null)
            {
                VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

                if (vehcilesearchcondition.IsMoreDestinations)
                {
                    rbD.Checked = true;
                }
                else
                {
                    rbS.Checked = true;
                }

                if (vehcilesearchcondition.PickupLocation != null && vehcilesearchcondition.PickupLocation.Trim().Length > 0)
                {
                    txtCarFromFullName.Text = vehcilesearchcondition.PickupLocation;
                }
                else
                {
                    txtCarFromFullName.Text = vehcilesearchcondition.PickupAirportCode;
                }

                if (vehcilesearchcondition.DropoffLocation != null && vehcilesearchcondition.DropoffLocation.Trim().Length > 0)
                {
                    txtCarToFullName.Text = vehcilesearchcondition.DropoffLocation;
                }
                else
                {
                    txtCarToFullName.Text = vehcilesearchcondition.DropoffAirportCode;
                }

                TextBox departureCalendarDate = (TextBox)this.txtPickupDate.FindControl("calendarDate");
                departureCalendarDate.Text = vehcilesearchcondition.PickupTime.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                TextBox returnCalendarDate = (TextBox)this.txtDropoffDate.FindControl("calendarDate");
                returnCalendarDate.Text = vehcilesearchcondition.DropoffTime.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                int CheckInTime = vehcilesearchcondition.PickupTime.Hour;
                int CheckOutTime = vehcilesearchcondition.DropoffTime.Hour;

                int CheckInTimeMinute = vehcilesearchcondition.PickupTime.Minute;
                int CheckOutTimeMinute = vehcilesearchcondition.DropoffTime.Minute;

                string CheckInAP = "P";
                string CheckOutAP = "P";

                if (CheckInTime == 0)
                {
                    CheckInAP = "P";
                    CheckInTime = 12;
                }
                else
                {
                    if (CheckInTime <= 12)
                    {
                        CheckInAP = "A";
                    }
                    else
                    {
                        CheckInTime = CheckInTime - 12;
                    }
                }

                ddlPickupTime.SelectedIndex = ddlPickupTime.Items.IndexOf(ddlPickupTime.Items.FindByValue(CheckInTime.ToString().PadLeft(2, '0') + CheckInTimeMinute.ToString().PadLeft(2, '0') + CheckInAP));

                if (CheckOutTime == 0)
                {
                    CheckOutAP = "P";
                    CheckOutTime = 12;
                }
                else
                {
                    if (CheckOutTime <= 12)
                    {
                        CheckOutAP = "A";
                    }
                    else
                    {
                        CheckOutTime = CheckOutTime - 12;
                    }
                }


                ddlDropoffTime.SelectedIndex = ddlDropoffTime.Items.IndexOf(ddlDropoffTime.Items.FindByValue(CheckOutTime.ToString().PadLeft(2, '0') + CheckOutTimeMinute.ToString().PadLeft(2, '0') + CheckOutAP));


                ddlCarType.SelectedIndex = ddlCarType.Items.IndexOf(ddlCarType.Items.FindByValue(vehcilesearchcondition.Category));
            }
            else
            {
                //出错处理
            }
        }
    }

    protected void imgbSearch_Click(object sender, EventArgs e)
    {
        string CheckInTimeCode = ddlPickupTime.SelectedValue;
        string CheckOutTimeCode = ddlDropoffTime.SelectedValue;

        string checkintime = CheckInTimeCode.Substring(0, 4);
        string checkouttime = CheckOutTimeCode.Substring(0, 4);

        string checkintimeX = CheckInTimeCode.Substring(4);
        string checkouttimeX = CheckOutTimeCode.Substring(4);

        DateTime fromDate = DateTime.MinValue;
        DateTime toDate = DateTime.MinValue;

        if (checkintimeX == "A")
        {
            fromDate = Convert.ToDateTime(txtPickupDate.CDate).AddHours(Convert.ToDouble(checkintime.Substring(0, 2))).AddMinutes(Convert.ToDouble(checkintime.Substring(2)));
        }
        else
        {
            if (checkintime == "1200")
            {
                fromDate = Convert.ToDateTime(txtPickupDate.CDate);
            }
            else
            {
                fromDate = Convert.ToDateTime(txtPickupDate.CDate).AddHours(Convert.ToDouble(checkintime.Substring(0, 2)) + Convert.ToDouble("12")).AddMinutes(Convert.ToDouble(checkintime.Substring(2)));
            }
        }
        if (checkouttimeX == "A")
        {
            toDate = Convert.ToDateTime(txtDropoffDate.CDate).AddHours(Convert.ToDouble(checkouttime.Substring(0, 2))).AddMinutes(Convert.ToDouble(checkouttime.Substring(2)));
        }
        else
        {
            if (checkouttime == "1200")
            {
                toDate = Convert.ToDateTime(txtDropoffDate.CDate);
            }
            else
            {

                toDate = Convert.ToDateTime(txtDropoffDate.CDate).AddHours(Convert.ToDouble(checkouttime.Substring(0, 2)) + Convert.ToDouble("12")).AddMinutes(Convert.ToDouble(checkouttime.Substring(2)));
            }
        }


        string UserInputInfoFrom = txtCarFromFullName.Text;

        string UserInputInfoTo = txtCarToFullName.Text;

        string CarFromCity = ConvertName();

        string CarToCity = ConvertName1();

        if (rbS.Checked)
        {
            CarToCity = CarFromCity;
        }

        string PickupAirportCode = string.Empty;
        string PickupISOCountryCode = string.Empty;

        string DropoffAirportCode = string.Empty;
        string DropoffISOCountryCode = string.Empty;


        if (CarFromCity.Trim().Length == 3)
        {
            Terms.Common.Domain.Airport airport = _airportService.Get(CarFromCity);
            if (airport != null)
            {
                PickupAirportCode = airport.Code;
                PickupISOCountryCode = airport.City.CountryCode;
            }
            else
            {
                IList ilCityName = _cityService.FindSomeCityByName(CarFromCity);

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
            IList DestinationOneAirPorts = _CommonService.FindAirportByCityName(CarFromCity);

            if (DestinationOneAirPorts.Count >= 1)
            {
                PickupAirportCode = ((Airport)DestinationOneAirPorts[0]).Code;
                PickupISOCountryCode = ((Airport)DestinationOneAirPorts[0]).City.CountryCode;
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(CarFromCity, airportList);
                if (airport != null)
                {
                    PickupAirportCode = airport.Code;
                    PickupISOCountryCode = airport.City.CountryCode;
                }
            }
        }

        if (CarToCity.Trim().Length == 3)
        {
            Terms.Common.Domain.Airport airport = _airportService.Get(CarToCity);
            if (airport != null)
            {
                DropoffAirportCode = airport.Code;
                DropoffISOCountryCode = airport.City.CountryCode;
            }
            else
            {
                IList ilCityName = _cityService.FindSomeCityByName(CarToCity);

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
            IList DestinationOneAirPorts = _CommonService.FindAirportByCityName(CarToCity);

            if (DestinationOneAirPorts.Count >= 1)
            {
                DropoffAirportCode = ((Airport)DestinationOneAirPorts[0]).Code;
                DropoffISOCountryCode = ((Airport)DestinationOneAirPorts[0]).City.CountryCode;
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(CarToCity, airportList);
                if (airport != null)
                {
                    DropoffAirportCode = airport.Code;
                    DropoffISOCountryCode = airport.City.CountryCode;
                }
            }
        }

        TERMS.Common.Search.VehcileSearchCondition sear = null;


        if (rbS.Checked)
        {
            sear = new TERMS.Common.Search.VehcileSearchCondition(PickupISOCountryCode, PickupAirportCode, UserInputInfoFrom, fromDate, toDate);
        }
        else
        {
            sear = new TERMS.Common.Search.VehcileSearchCondition(PickupISOCountryCode, PickupAirportCode, UserInputInfoFrom, fromDate, DropoffISOCountryCode, DropoffAirportCode, UserInputInfoTo, toDate);
        }

        sear.Category = ddlCarType.SelectedValue;

        Terms.Sales.Business.VehcileSearchCondition vehcilesearchcondition = new Terms.Sales.Business.VehcileSearchCondition(sear);

        this.Transaction.IntKey = vehcilesearchcondition.GetHashCode();
        this.Transaction.CurrentSearchConditions = vehcilesearchcondition;
        this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
        Utility.IsTourMain = false;//设置是否是Tour标志

        this.Response.Redirect(PageUtility.UrlSuffix + "Page/Common/Searching1.aspx?target=~/Page/Vehcile/SearchConditionsMeassageCForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
    }

    private string ConvertName()
    {
        int index = txtCarFromFullName.Text.IndexOf("-");

        if (index > 0)
        {
            int end = txtCarFromFullName.Text.Substring(index + 1).IndexOf(",");

            if (end > 0)
            {
                return txtCarFromFullName.Text.Substring(index + 1, end).Trim();
            }
            else
            {
                return txtCarFromFullName.Text.Substring(index + 1).Trim();
            }
        }
        else
        {
            return txtCarFromFullName.Text.Trim();
        }
    }

    private string ConvertName1()
    {
        int index = txtCarToFullName.Text.IndexOf("-");

        if (index > 0)
        {
            int end = txtCarToFullName.Text.Substring(index + 1).IndexOf(",");

            if (end > 0)
            {
                return txtCarToFullName.Text.Substring(index + 1, end).Trim();
            }
            else
            {
                return txtCarToFullName.Text.Substring(index + 1).Trim();
            }
        }
        else
        {
            return txtCarToFullName.Text.Trim();
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