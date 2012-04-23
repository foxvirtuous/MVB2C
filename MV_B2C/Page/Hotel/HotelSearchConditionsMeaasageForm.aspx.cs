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

using log4net;
using Spring.Web.UI;
using Terms.Sales.Business;
using TERMS.Common;
using System.Globalization;
using Terms.Common.Service;

public partial class HotelSearchConditionsMeaasageForm : SalseBasePage
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

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (this.Request["ErrorMessage"] != null && this.Request["ErrorMessage"].ToString().Trim() != "")
        {
            plCityName.Visible = false;
            PLCiytName3.Visible = true;
        }
        else
        {
            plCityName.Visible = true;
            PLCiytName3.Visible = false;
        }

        if (!IsPostBack)
        {
            txtCheckin_h.Path = txtCheckout_h.Path = "../../"; //this.PATH;
            txtCheckout_h.Path = txtCheckout_h.Path = "../../"; //this.PATH;

            this.btnSearch_h.ValidationGroup = "HotelOnlySearch";

            txtCheckin_h.IsCoercion = true;
            txtCheckin_h.CoercionID = "txtCheckout_h";

            ((TextBox)txtCheckin_h.FindControl("calendarDate")).CssClass = "search_inp";
            ((TextBox)txtCheckout_h.FindControl("calendarDate")).CssClass = "search_inp";

            if (!IsSearchConditionNull)
            {
                

                if (this.Transaction.CurrentSearchConditions is PackageSearchCondition || this.Transaction.CurrentSearchConditions is AirSearchCondition)
                {
                    ((TextBox)txtCheckin_h.FindControl("calendarDate")).Text = DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                    ((TextBox)txtCheckout_h.FindControl("calendarDate")).Text = DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                }
            }
            else
            {
                ((TextBox)txtCheckin_h.FindControl("calendarDate")).Text = DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                ((TextBox)txtCheckout_h.FindControl("calendarDate")).Text = DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            }

            BindHotelSearchCondition();
            //cddHotel.SelectedValue = this.Request["CountryCode"];
            //cddCity.SelectedValue = this.Request["CityCode"];
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DateTime dateChinkIn_H;
        DateTime dateChinkOut_H;

        try
        {
            dateChinkIn_H = Convert.ToDateTime(this.txtCheckin_h.CDate);
            dateChinkOut_H = Convert.ToDateTime(this.txtCheckout_h.CDate);
        }
        catch
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The wrong date format&&GoToPage=~/Index.aspx");
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

        HotelSearchCondition hotelSearchCondition = new HotelSearchCondition();

        for (int i = 0; i < TravelerChange1.Rooms; i++)
        {
            RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

            roomSearchCondition.Passengers.Add(PassengerType.Adult, TravelerChange1.Adults[i]);
            roomSearchCondition.Passengers.Add(PassengerType.Child, TravelerChange1.Childs[i]);

            hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
        }
        //hotelSearchCondition.Country = this.ddlCountry_h.SelectedValue;
        //hotelSearchCondition.Location = this.ddlCity_h.SelectedValue;
        hotelSearchCondition.LocationIndicator = LocationIndicator.City;
        hotelSearchCondition.CheckIn = Convert.ToDateTime(this.txtCheckin_h.CDate);
        hotelSearchCondition.CheckOut = Convert.ToDateTime(this.txtCheckout_h.CDate);
        this.Transaction.IntKey = hotelSearchCondition.GetHashCode();
        this.Transaction.CurrentSearchConditions = hotelSearchCondition;
        this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

        if (this.txtName.Text.Trim().Length == 3)
        {
            Terms.Common.Domain.City CityName = _cityService.Get(this.txtName.Text);

            if (CityName != null)
            {
                ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = CityName.Code;
                ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = CityName.CountryCode;
                //Session["CityNameList"] = ilCityName;
                //this.Response.Redirect("~/Page/Common/SearchMoreForm.aspx?CityName=" + this.txtCityName.Text);
            }
            else
            {
                Terms.Common.Domain.Airport airport = _airportService.Get(this.txtName.Text);
                if (airport != null)
                {
                    ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = airport.City.Code;
                    ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = airport.City.CountryCode;
                }
                else
                {
                    IList ilCityName = _cityService.FindSomeCityByName(this.txtName.Text);
                    if (ilCityName.Count > 1)
                    {
                        Session["CityNameList"] = ilCityName;
                        this.Response.Redirect(SaleWebSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtName.Text);
                    }
                    else if (ilCityName.Count == 1)
                    {
                        Terms.Common.Domain.City citylist = (Terms.Common.Domain.City)ilCityName[0];
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = citylist.Code;
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = citylist.CountryCode;
                    }
                    else if (ilCityName == null || ilCityName.Count == 0)
                    {
                        Session["CityNameList"] = null;
                        this.Response.Redirect(SaleWebSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtName.Text);
                    }
                }
            }

        }
        else
        {
            //判断是否有多个.如果有相同则到SerachMore页面进行选择,如果没有则进入搜索页面
            IList ilCityName = _cityService.FindSomeCityByName(this.txtName.Text);

            if (ilCityName.Count > 1)
            {
                Session["CityNameList"] = ilCityName;
                this.Response.Redirect(SaleWebSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtName.Text);
            }
            else if (ilCityName.Count == 1)
            {
                Terms.Common.Domain.City citylist = (Terms.Common.Domain.City)ilCityName[0];
                ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = citylist.Code;
                ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = citylist.CountryCode;
            }
            else if (ilCityName == null || ilCityName.Count == 0)
            {
                Terms.Common.Domain.Airport airport = _airportService.Get(this.txtName.Text);
                if (airport != null)
                {
                    ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = airport.City.Code;
                    ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = airport.City.CountryCode;
                }
                else
                {
                    this.Response.Redirect(SaleWebSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtName.Text);
                }
            }
        }


        this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Hotel2/SearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
    }

    private void BindHotelSearchCondition()
    {
        if (this.Transaction == null) return;
        if (this.Transaction.CurrentSearchConditions == null) return;
        if ((this.Transaction.CurrentSearchConditions is HotelSearchCondition) == false) return;

        if (this.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            HotelSearchCondition hotelSearchCondition = (HotelSearchCondition)this.Transaction.CurrentSearchConditions;
            TextBox checkinCalendar = (TextBox)this.txtCheckin_h.FindControl("calendarDate");
            TextBox checkoutCalendar = (TextBox)this.txtCheckout_h.FindControl("calendarDate");
            checkinCalendar.Text = hotelSearchCondition.CheckIn.ToString("d", DateTimeFormatInfo.InvariantInfo);
            checkoutCalendar.Text = hotelSearchCondition.CheckOut.ToString("d", DateTimeFormatInfo.InvariantInfo);
            if (this.Request["CityCode"] != null)
            {
                this.txtName.Text = this.Request["CityCode"];
            }
            else
            {
                this.txtName.Text = hotelSearchCondition.Location;
            }

            txtName.Text = hotelSearchCondition.UserInputInfo;
            //cddHotel.SelectedValue = hotelSearchCondition.Country;
            //cddCity.SelectedValue = hotelSearchCondition.Location;
        }
    }
}
