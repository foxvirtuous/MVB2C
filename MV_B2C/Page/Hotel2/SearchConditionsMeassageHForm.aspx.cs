using Spring.Context;
using Spring.Context.Support;
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

using Terms.Sales.Business;
using TERMS.Common;
using Terms.Sales.Service;
using Resources;
using Terms.Common.Service;


public partial class SearchConditionsMeassageHForm : SalseBasePage
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

    //记录Air Search时间的日志对象
    private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger("HotelSearchTime");

    private static readonly log4net.ILog hotelSearchHotelByZyl =
         log4net.LogManager.GetLogger("HotelSearchPerformanceDebugging");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request["TYPE"] != null)
        {
            divIserror.Visible = false;

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            HotelSearchCondition search = new HotelSearchCondition();

            search.Country = this.Request["CountryCode"];
            search.LocationIndicator = LocationIndicator.City;
            search.Location = this.Request["CityCode"];
            search.CheckIn = DateTime.Now.AddDays(14);
            search.CheckOut = DateTime.Now.AddDays(21);

            this.Transaction.CurrentSearchConditions = search;
            this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
        }


        this.SetWebSiteInfomation();
        if (Utility.IsSubAgent)
        {
            txtCheckin_h.Path = txtCheckout_h.Path = "../../";
        }
        else
        {
            txtCheckin_h.Path = txtCheckout_h.Path = "../../";
        }

        if (!IsPostBack)
        {
            //txtCheckin_h.Path = txtCheckout_h.Path = ""; //this.PATH;

            txtCheckin_h.IsCoercion = true;
            txtCheckin_h.CoercionID = "txtCheckout_h";

            SetPageValidationGroup();

            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                txtCheckin_h.BeginDate = DateTime.Now.AddDays(4);
                txtCheckout_h.BeginDate = DateTime.Now.AddDays(4);
            }
            else
            {
                txtCheckin_h.BeginDate = DateTime.Now.AddDays(7);
                txtCheckout_h.BeginDate = DateTime.Now.AddDays(7);
            }

            if (Session["ErrorMsg"] != null)
            {
                List<TourErrorMsg> errors = (List<TourErrorMsg>)Session["ErrorMsg"];

                if (errors[0].IsError)
                {
                    div_1.Visible = true;
                    lblError1.Text = errors[0].ErrorMsg;
                }
                if (errors[1].IsError)
                {
                    div_2.Visible = true;
                    lblError2.Text = errors[1].ErrorMsg;
                }
            }
        }
    }

    public void SetPageValidationGroup()
    {
        this.btnSearch_h.ValidationGroup = "HotelOnlySearch";

        ((TextBox)txtCheckin_h.FindControl("calendarDate")).CssClass = "search_inp";
        ((TextBox)txtCheckout_h.FindControl("calendarDate")).CssClass = "search_inp";

        if (!IsSearchConditionNull)
        {
            BindHotelSearchCondition();

            if (this.Transaction.CurrentSearchConditions is PackageSearchCondition || this.Transaction.CurrentSearchConditions is AirSearchCondition)
            {
                ((TextBox)txtCheckin_h.FindControl("calendarDate")).Text = DateTime.Now.AddDays(4).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                ((TextBox)txtCheckout_h.FindControl("calendarDate")).Text = DateTime.Now.AddDays(11).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            }
        }
        else
        {
            ((TextBox)txtCheckin_h.FindControl("calendarDate")).Text = DateTime.Now.AddDays(4).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            ((TextBox)txtCheckout_h.FindControl("calendarDate")).Text = DateTime.Now.AddDays(11).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
        }
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

            if (hotelSearchCondition.UserInputInfo != null && hotelSearchCondition.UserInputInfo.Trim().Length > 0)
            {
                this.txtFullName.Text = hotelSearchCondition.UserInputInfo;
            }
            else
            {
                this.txtFullName.Text = hotelSearchCondition.Location;
            }

            TravelerChange1.SetRoomsCondition();
        }
    }

    private string ConvertName()
    {
        int index = txtFullName.Text.IndexOf("-");

        if (index > 0)
        {
            int end = txtFullName.Text.Substring(index + 1).IndexOf(",");

            if (end > 0)
            {
                return txtFullName.Text.Substring(index + 1, end).Trim();
            }
            else
            {
                return txtFullName.Text.Substring(index + 1).Trim();
            }
        }
        else
        {
            return txtFullName.Text.Trim();
        }
    }

    protected void btnSearch_h_Click(object sender, EventArgs e)
    {
        if (txtFullName.Text.Trim().Length == 0)
        {
            div_1.Visible = true;
            lblError1.Text = Resources.HintInfo.Hotel_Error_City;
            return;
        }

        txtName.Text = ConvertName();

        DateTime dtNow = DateTime.Now;
        hotelSearchHotelByZyl.Info("MV_B2C Hotel Serach Start : " + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

        if (Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchHotel, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchHotel, this);
        if (!Page.IsValid)
            return;

        try
        {
            //log begin 20090312 Leon
            log.Info("\r\n");

            if (!Utility.IsLogin)
            {
                log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >====================Not Login========================");
            }
            else
            {
                log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >==========================Login========================");
            }

            log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >SearchClick Begin Start time : " + System.DateTime.Now);
            //log end 20090312 Leon
        }
        catch
        {

        }

        DateTime dateChinkIn_H = Convert.ToDateTime(this.txtCheckin_h.CDate);
        DateTime dateChinkOut_H = Convert.ToDateTime(this.txtCheckout_h.CDate);

        if (dateChinkIn_H < DateTime.Now.AddDays(7))
        {
            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                if (dateChinkIn_H < DateTime.Now.AddDays(3))
                {
                    div_2.Visible = true;
                    lblError2.Text = Resources.HintInfo.Hotel_Date_Error1;
                    return;
                }
            }
            else
            {
                div_2.Visible = true;
                lblError2.Text = Resources.HintInfo.Hotel_Date_Error1;
                return;
            }
        }

        if (dateChinkOut_H < DateTime.Now.AddDays(7))
        {
            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                if (dateChinkOut_H < DateTime.Now.AddDays(3))
                {
                    div_2.Visible = true;
                    lblError2.Text = Resources.HintInfo.Hotel_Date_Error2;
                    return;
                }
            }
            else
            {
                div_2.Visible = true;
                lblError2.Text = Resources.HintInfo.Hotel_Date_Error2;
                return;
            }
        }

        if (dateChinkIn_H < DateTime.Today && dateChinkOut_H < DateTime.Today)
        {
            div_2.Visible = true;
            lblError2.Text = Resources.HintInfo.Hotel_Date_Error3;
            return;
        }

        if (dateChinkIn_H <= DateTime.Today)
        {
            div_2.Visible = true;
            lblError2.Text = Resources.HintInfo.Hotel_Date_Error4;
            return;
        }

        if (dateChinkIn_H > dateChinkOut_H)
        {
            div_2.Visible = true;
            lblError2.Text = Resources.HintInfo.Hotel_Date_Error5;
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

        hotelSearchCondition.UserInputInfo = txtFullName.Text;
        hotelSearchCondition.LocationIndicator = LocationIndicator.City;
        hotelSearchCondition.CheckIn = Convert.ToDateTime(this.txtCheckin_h.CDate);
        hotelSearchCondition.CheckOut = Convert.ToDateTime(this.txtCheckout_h.CDate);
        this.Transaction.IntKey = hotelSearchCondition.GetHashCode();
        this.Transaction.CurrentSearchConditions = hotelSearchCondition;
        this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
        Utility.IsTourMain = false;//设置是否是Tour标志

        if (this.txtName.Text.Trim().Length == 3)
        {
            Terms.Common.Domain.City CityName = _cityService.Get(this.txtName.Text);

            if (CityName != null)
            {
                ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = CityName.Code;
                ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = CityName.CountryCode;
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


        log.Info(PageUtility.HotelLogRandomNumber.ToString() + " >Redirect Searching1.aspx Begin Start time : " + System.DateTime.Now);

        hotelSearchHotelByZyl.Debug("Hotel Start :" + DateTime.Now.ToLongTimeString());

        dtNow = DateTime.Now;
        hotelSearchHotelByZyl.Info("MV_B2C Hotel Serach To Searching1 Start : " + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

        this.Response.Redirect(SaleWebSuffix + "Page/Common/Searching1.aspx?target=~/Page/Hotel2/SearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
    }

    protected void Header1_Load(object sender, EventArgs e)
    {

    }
}
