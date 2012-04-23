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

using Terms.Common.Service;
using Terms.Common.Dao;
using Terms.Common.Domain;
using Terms.Sales.Service;
using Terms.Sales.Dao;
using Terms.Sales.Domain;
using Terms.Sales.Business;
using TERMS.Common;

public partial class HotelOnlySearchControl : SalesBaseUserControl
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

    public HotelOnlySearchControl()
    {
        this.InitializeControls += new EventHandler(HotelOnlySearchControl_InitializeControls);
    }

    void HotelOnlySearchControl_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (Utility.Transaction.CurrentSearchConditions != null)
        {
            txtCheckinDate.Path = txtCheckoutDate.Path = "../../";

            txtCheckinDate.IsCoercion = true;
            txtCheckinDate.CoercionID = "txtCheckoutDate";

            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                txtCheckinDate.BeginDate = DateTime.Now.AddDays(4);
                txtCheckoutDate.BeginDate = DateTime.Now.AddDays(4);
            }
            else
            {
                txtCheckinDate.BeginDate = DateTime.Now.AddDays(7);
                txtCheckoutDate.BeginDate = DateTime.Now.AddDays(7);
            }

            if (((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).UserInputInfo != null && ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).UserInputInfo.Trim().Length > 0)
            {
                txtFullName.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).UserInputInfo;
            }
            else
            {
                txtFullName.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).Location;
            }
            

            if (!this.IsPostBack)
            {
                SetPageValidationGroup();
            }

            TextBox departureCalendarDate = (TextBox)this.txtCheckinDate.FindControl("calendarDate");
            departureCalendarDate.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            TextBox returnCalendarDate = (TextBox)this.txtCheckoutDate.FindControl("calendarDate");
            returnCalendarDate.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            ddlRooms.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count.ToString();

            for (int i = 0; i < ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count; i++)
            {
                if (i != 0)
                {
                    System.Web.UI.HtmlControls.HtmlTable tabAdult = (System.Web.UI.HtmlControls.HtmlTable)this.FindControl("pAdult" + (i + 1).ToString());
                    System.Web.UI.HtmlControls.HtmlTable tabChild = (System.Web.UI.HtmlControls.HtmlTable)this.FindControl("pChild" + (i + 1).ToString());
                    tabAdult.Style["display"] = "";
                    tabChild.Style["display"] = "";
                }
            }
            if (((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count == 1)
            {
                ddlAdult1.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[0].AdultNumber.ToString();
                ddlChild1.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[0].ChildNumber.ToString();
            }
            if (((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count == 2)
            {
                ddlAdult1.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[0].AdultNumber.ToString();
                ddlChild1.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[0].ChildNumber.ToString();
                ddlAdult2.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[1].AdultNumber.ToString();
                ddlChild2.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[1].ChildNumber.ToString();
            }
            if (((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count == 3)
            {
                ddlAdult1.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[0].AdultNumber.ToString();
                ddlChild1.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[0].ChildNumber.ToString();
                ddlAdult2.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[1].AdultNumber.ToString();
                ddlChild2.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[1].ChildNumber.ToString();
                ddlAdult3.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[2].AdultNumber.ToString();
                ddlChild3.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[2].ChildNumber.ToString();
            }
            if (((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count == 4)
            {
                ddlAdult1.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[0].AdultNumber.ToString();
                ddlChild1.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[0].ChildNumber.ToString();
                ddlAdult2.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[1].AdultNumber.ToString();
                ddlChild2.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[1].ChildNumber.ToString();
                ddlAdult3.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[2].AdultNumber.ToString();
                ddlChild3.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[2].ChildNumber.ToString();
                ddlAdult4.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[3].AdultNumber.ToString();
                ddlChild4.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[3].ChildNumber.ToString();
            }
        }
        else
        {
            //出错处理
        }
    }

    private void SetPageValidationGroup()
    {
        this.imgbSearch.ValidationGroup = "HotelOnlySearch";

    }

    public void imgbSearch_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(this.txtCheckinDate.CDate) < DateTime.Now.AddDays(7))
        {
            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                if (Convert.ToDateTime(this.txtCheckinDate.CDate) < DateTime.Now.AddDays(3))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Departure date is greater than the current date seven days.');</script>");
                    return;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Departure date is greater than the current date seven days.');</script>");
                return;
            }
        }

        if (Convert.ToDateTime(this.txtCheckoutDate.CDate) < DateTime.Now.AddDays(7))
        {
            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                if (Convert.ToDateTime(this.txtCheckoutDate.CDate) < DateTime.Now.AddDays(3))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Return date is greater than the current date seven days.');</script>");
                    return;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Return date is greater than the current date seven days.');</script>");
                return;
            }
        }

        if (!Utility.IsSearchConditionNull)
        {
            HotelSearchCondition hotelSearchCondition = new HotelSearchCondition();
            if (ddlRooms.SelectedValue == "1")
            {
                RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

                roomSearchCondition.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult1.SelectedValue));
                roomSearchCondition.Passengers.Add(PassengerType.Child, int.Parse(ddlChild1.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
            }
            if (ddlRooms.SelectedValue == "2")
            {
                RoomSearchCondition roomSearchCondition1 = new RoomSearchCondition();

                roomSearchCondition1.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult1.SelectedValue));
                roomSearchCondition1.Passengers.Add(PassengerType.Child, int.Parse(ddlChild1.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition1);

                RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

                roomSearchCondition.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult2.SelectedValue));
                roomSearchCondition.Passengers.Add(PassengerType.Child, int.Parse(ddlChild2.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
            }
            if (ddlRooms.SelectedValue == "3")
            {
                RoomSearchCondition roomSearchCondition1 = new RoomSearchCondition();

                roomSearchCondition1.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult1.SelectedValue));
                roomSearchCondition1.Passengers.Add(PassengerType.Child, int.Parse(ddlChild1.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition1);

                RoomSearchCondition roomSearchCondition2 = new RoomSearchCondition();

                roomSearchCondition2.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult2.SelectedValue));
                roomSearchCondition2.Passengers.Add(PassengerType.Child, int.Parse(ddlChild2.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition2);

                RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

                roomSearchCondition.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult3.SelectedValue));
                roomSearchCondition.Passengers.Add(PassengerType.Child, int.Parse(ddlChild3.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
            }
            if (ddlRooms.SelectedValue == "4")
            {
                RoomSearchCondition roomSearchCondition1 = new RoomSearchCondition();

                roomSearchCondition1.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult1.SelectedValue));
                roomSearchCondition1.Passengers.Add(PassengerType.Child, int.Parse(ddlChild1.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition1);

                RoomSearchCondition roomSearchCondition2 = new RoomSearchCondition();

                roomSearchCondition2.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult2.SelectedValue));
                roomSearchCondition2.Passengers.Add(PassengerType.Child, int.Parse(ddlChild2.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition2);

                RoomSearchCondition roomSearchCondition3 = new RoomSearchCondition();

                roomSearchCondition3.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult3.SelectedValue));
                roomSearchCondition3.Passengers.Add(PassengerType.Child, int.Parse(ddlChild3.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition3);

                RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

                roomSearchCondition.Passengers.Add(PassengerType.Adult, int.Parse(ddlAdult4.SelectedValue));
                roomSearchCondition.Passengers.Add(PassengerType.Child, int.Parse(ddlChild4.SelectedValue));

                hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
            }

            //hotelSearchCondition.Location = this.ddlCity.SelectedValue;
            hotelSearchCondition.LocationIndicator = LocationIndicator.City;
            hotelSearchCondition.CheckIn = Convert.ToDateTime(txtCheckinDate.CDate);
            hotelSearchCondition.CheckOut = Convert.ToDateTime(txtCheckoutDate.CDate);
            //hotelSearchCondition.Country = this.ddlCountry.SelectedValue;
            Utility.Transaction.CurrentSearchConditions = hotelSearchCondition;
            Utility.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
            Utility.IsTourMain = false;//设置是否是Tour标志

            if (this.txtFullName.Text.Trim().Length == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please input city name or code or airport');</script>");
                return;
            }

            hotelSearchCondition.UserInputInfo = this.txtFullName.Text.Trim();

            this.txtName.Text = ConvertName();

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
                            this.Response.Redirect(PageUtility.UrlSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtName.Text);
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
                            this.Response.Redirect(PageUtility.UrlSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtName.Text);
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
                    this.Response.Redirect(PageUtility.UrlSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtName.Text);
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
                        this.Response.Redirect(PageUtility.UrlSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtName.Text);
                    }
                }
            }

            this.Response.Redirect(PageUtility.UrlSuffix + "Page/Common/Searching1.aspx?target=~/Page/Hotel2/SearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
        }
        else
        {
            this.Response.Redirect(PageUtility.UrlSuffix + "Index.aspx");
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
}
