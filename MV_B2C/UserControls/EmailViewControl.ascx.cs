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
using System.Collections.Generic;
using Spring.Web.UI;
using log4net;
using Terms.Sales.Service;
using Terms.Sales.Utility;
using Terms.Base.Domain;
using System.Globalization;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Common;

public partial class EmailViewControl : Spring.Web.UI.UserControl
{
    private List<HotelOrderItem> _hotelDetails;
    public List<HotelOrderItem> HotelDetails
    {
        set
        {
            if (value is List<HotelOrderItem>)
            {
                ddlHotel.DataSource = HotelOrderUtility.GetHotelDataSource(value);
                ddlHotel.DataBind();
            }
        }
        get
        {
            if (_hotelDetails == null)
            {
                _hotelDetails = new List<HotelOrderItem>();
            }

            return _hotelDetails;
        }
    }

    private IList<SubAirTrip> _airDetails;
    public IList<SubAirTrip> AirDetails
    {
        set
        {
            if (value is List<SubAirTrip>)
            {
                dlDeparture.DataSource = value[0].Flights;
                dlDeparture.DataBind();

                if (value.Count > 1)
                    if (value[1] != null)
                    {
                        dlReturn.DataSource = value[1].Flights;
                        dlReturn.DataBind();
                        dlReturn.Visible = true;
                    }
                    else
                    {
                        dlReturn.Visible = false;
                    }
                else
                    dlReturn.Visible = false;

            }
        }
        get
        {
            if (_airDetails == null)
            {
                _airDetails = new List<SubAirTrip>();
            }
            return _airDetails;
        }
    }

    private IList<TERMS.Business.Centers.SalesCenter.Passenger> _passenger;
    public IList<TERMS.Business.Centers.SalesCenter.Passenger> Passenger
    {
        set
        {
            if (value is List<TERMS.Business.Centers.SalesCenter.Passenger>)
            {
                dlPassengers.DataSource = value;
                dlPassengers.DataBind();
            }
        }
        get
        {
            if (_passenger == null)
                _passenger = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

            return _passenger;
        }
    }

    private Contact _orderContract;
    public Contact OrderContract
    {
        set { _orderContract = value; }
        get { return _orderContract; }
    }

    public EmailViewControl()
    {
        this.InitializeControls += new EventHandler(EmailViewControl_InitializeControls);
    }

    private void EmailViewControl_InitializeControls(object sender, EventArgs e)
    {
        if (Utility.Transaction.CurrentTransactionObject != null)
        {
            if (!IsPostBack)
            {
                SetCondition();
                BinderPrice();
                BinderContact();
            }
        }
        else
        { 
            //出错处理
        }

    }


    private void SetCondition()
    {
        if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
        {
            //IList<SubAirTrip> tempList = new List<SubAirTrip>();

            AirMaterial airMaterial = (AirMaterial)((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Merchandise;

            AirDetails = airMaterial.AirTrip.SubTrips;
            //}

            //显示Flight type, edit by cjc
            AirSearchCondition airCondition;

            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
                airCondition = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition;
            else
                airCondition = (AirSearchCondition)Utility.Transaction.CurrentSearchConditions;

            if (airCondition.FlightType.ToLower() == "oneway")
                this.lblFlightType.Text = "One Way";
            else if (airCondition.FlightType.ToLower() == "roundtrip")
                this.lblFlightType.Text = "Round trip";
            else
                this.lblFlightType.Text = "Multiple Cities";

            //显示Ticket number，edit by cjc
            lblTicketNumber.Text = Convert.ToString(airCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult) +
                airCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child) +
                airCondition.GetPassengerNumber(TERMS.Common.PassengerType.Infant));
        }
        if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            //IList<SubAirTrip> tempList = new List<SubAirTrip>();

            AirMaterial airMaterial = (AirMaterial)((AirOrderItem)((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items[0]).Merchandise;

            AirDetails = airMaterial.AirTrip.SubTrips;
            //}

            //显示Flight type, edit by cjc
            AirSearchCondition airCondition;

            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
                airCondition = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition;
            else
                airCondition = (AirSearchCondition)Utility.Transaction.CurrentSearchConditions;

            if (airCondition.FlightType.ToLower() == "oneway")
                this.lblFlightType.Text = "One Way";
            else if (airCondition.FlightType.ToLower() == "roundtrip")
                this.lblFlightType.Text = "Round trip";
            else
                this.lblFlightType.Text = "Multiple Cities";

            //显示Ticket number，edit by cjc
            lblTicketNumber.Text = Convert.ToString(airCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult) +
                airCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child) +
                airCondition.GetPassengerNumber(TERMS.Common.PassengerType.Infant));

            //显示Hotel信息

            List<HotelOrderItem> hotelMaterial = new List<HotelOrderItem>();

            for (int i = 0; i < ((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items.Count; i++)
            {
                if (((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items[i] is HotelOrderItem)
                {
                    hotelMaterial.Add((HotelOrderItem)((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items[i]);
                }
            }


            HotelDetails = hotelMaterial;
        }

        if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            List<HotelOrderItem> hotelMaterial = new List<HotelOrderItem>();

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                if (Utility.Transaction.CurrentTransactionObject.Items[i] is HotelOrderItem)
                {
                    hotelMaterial.Add((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]);
                }
            }

            HotelDetails = hotelMaterial;
            this.tbFlight.Visible = false;


        }
        Passenger = Utility.Transaction.CurrentTransactionObject.GetPassengers();
        OrderContract = Utility.Transaction.CurrentTransactionObject.Contacts[0];
        lbRemark.Text = Utility.Transaction.CurrentTransactionObject.Remark;
    }

    private void BinderContact()
    {
        OrderContract = Utility.Transaction.CurrentTransactionObject.Contacts[0];
        this.lbName.Text = OrderContract.Person.FirstName + " " + OrderContract.Person.MiddleName + " " + OrderContract.Person.LastName;
        this.lbEmail.Text = OrderContract.Person.Email;

        if (OrderContract.Person.Address.Count > 0)
        {
            this.lbAddress.Text = OrderContract.Person.Address[0].AddressString;
            this.lbStateCity.Text = OrderContract.Person.Address[0].City.Name;
            this.lbZipPostCode.Text = OrderContract.Person.Address[0].ZipCode;
        }

        if (OrderContract.Person.Faxes.Count > 0)
            this.lbFax.Text = OrderContract.Person.GetFax(TERMS.Common.ContactOptions.Office).Number;

        if (OrderContract.Person.Phones.Count > 0)
        {
            this.lbDayTimePhone.Text = OrderContract.Person.GetPhone(TERMS.Common.ContactOptions.DayTime).Number;
            this.lbEveningPhone.Text = OrderContract.Person.GetPhone(TERMS.Common.ContactOptions.NightTime).Number;
        }
    }

    private void BinderPrice()
    {
        decimal AirTotalPrice = 0M;
        decimal AirTotalTax = 0M;
        decimal HotelTotalPrice = 0M;
        int Adults = 0;
        int Childs = 0;
        //if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition )
        //{
        //    Adults = ((AirComponentGroup)Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.ComponentGroup.Items[0].Component).AdultNumber;

        //    Childs = ((AirComponentGroup)Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.ComponentGroup.Items[0].Component).ChildNumber;

        //    AirTotalPrice = ((AirComponentGroup)Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.ComponentGroup.Items[0].Component).Total;
        //    AirTotalTax = ((AirComponentGroup)Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.ComponentGroup.Items[0].Component).Tax;
        //}
        if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            Adults = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult);

            Childs = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);
            PackageOrderItem packageOrderItem =(PackageOrderItem) Utility.Transaction.CurrentTransactionObject.Items[0];

            decimal decIn = 0M;

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                if (Utility.Transaction.CurrentTransactionObject.Items[i] is InsuranceOrderItem)
                {
                    decIn = ((InsuranceOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).TotalPremiumAmount;
                }

                //if (Utility.Transaction.CurrentTransactionObject.Items[i] is SubagentMarkupOrderItem)
                //{
                //    decIn += ((SubagentMarkupOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Markup;
                //}

                decIn += Utility.Transaction.CurrentTransactionObject.SubagentMarkup.GetTotalMarkup(PassengerType.Adult);

                if (Utility.Transaction.CurrentTransactionObject.Items[i] is TransferOrderItem)
                {
                    decIn += ((TransferOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Price;
                }
            }

            this.lbTotalPrice.Text = Decimal.Round(packageOrderItem.TotalPrice + decIn, 0).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
            this.lbAvgPrice.Text = Decimal.Round((packageOrderItem.TotalPrice + decIn) / (Adults + Childs), 0).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);

            //this.lbTotalPrice.Text = Decimal.Round(packageOrderItem.TotalPrice, 2).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
            //this.lbAvgPrice.Text = Decimal.Round(packageOrderItem.TotalPrice / (Adults + Childs), 2).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);

        }
        if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            this.tbFlight.Visible = false;
            for (int i = 0; i < ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count; i++)
            {
                Adults += ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Adult];
                Childs += ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Child];
            }

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                if (Utility.Transaction.CurrentTransactionObject.Items[i] is HotelOrderItem)
                {
                    HotelTotalPrice += ((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).TotalPrice;
                }

                //if (Utility.Transaction.CurrentTransactionObject.Items[i] is SubagentMarkupOrderItem)
                //{
                //    HotelTotalPrice += ((SubagentMarkupOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Markup;
                //}

                HotelTotalPrice += Utility.Transaction.CurrentTransactionObject.SubagentMarkup.GetTotalMarkup(PassengerType.Adult);

            }

            this.lbTotalPrice.Text = Decimal.Round(AirTotalPrice + HotelTotalPrice, 2).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
            this.lbAvgPrice.Text = Decimal.Round((AirTotalPrice + HotelTotalPrice) / (Adults + Childs), 2).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);

        }
    }
    protected void dlPassengers_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
        {
            Label lbl = (Label)e.Item.FindControl("Label3");

            if (lbl.Text.Trim() == "0".Trim())
            {
                lbl.Text = "Mr";
            }
            if (lbl.Text.Trim() == "1".Trim())
            {
                lbl.Text = "Mrs";
            }
            if (lbl.Text.Trim() == "2".Trim())
            {
                lbl.Text = "Ms";
            }

            if (((Label)e.Item.FindControl("lbBirth")).Text.Trim() != "")
            {
                DateTime birthDay = Convert.ToDateTime(((Label)e.Item.FindControl("lbBirth")).Text);
                if (IsDateTimeCurrent(birthDay))
                {
                    ((Label)e.Item.FindControl("lbBirth")).Visible = true;
                    ((Label)e.Item.FindControl("lbBirth")).Text = Convert.ToDateTime(((Label)e.Item.FindControl("lbBirth")).Text).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                }
                else
                {
                    ((Label)e.Item.FindControl("lbBirth")).Visible = false;
                }
            }
        }
    }

    private bool IsDateTimeCurrent(DateTime dateTime)
    {
        return dateTime.CompareTo(new DateTime(1753, 1, 1)) >= 0 && dateTime.CompareTo(new DateTime(9999, 1, 1)) <= 0;
    }

    protected void ddlHotel_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int iCount = e.Item.ItemIndex;

            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                //((Label)e.Item.FindControl("lbNights")).Text = ((TimeSpan)((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.Subtract(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn)).Days.ToString();
                ////((Label)e.Item.FindControl("lbCheckDate")).Text = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn.ToString("MMM dd,yyyy",DateTimeFormatInfo.InvariantInfo)+ "|" + ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.ToString("MMM dd,yyyy",DateTimeFormatInfo.InvariantInfo);

                //string strHotelDetails = string.Empty;
                //List<HotelOrderItem> tempHotelOrderItem = new List<HotelOrderItem>();



                //for (int i = 1; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                //{
                //    HotelOrderItem hm = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];
                //    tempHotelOrderItem.Add(hm);
                //}

                //for (int i = 0; i < tempHotelOrderItem.Count; i++)
                //{
                //    HotelOrderItem hotelOrderItem = (HotelOrderItem)tempHotelOrderItem[i];

                //    if (i == 0)
                //    {
                //        strHotelDetails += "Room #" + (i + 1).ToString() + ": " + hotelOrderItem.Room.Description;
                //    }
                //    else
                //    {
                //        strHotelDetails += @"<BR /> Room #" + (i + 1).ToString() + ": " + hotelOrderItem.Room.Description;
                //    }

                //}
                //((Label)e.Item.FindControl("lbCheckDate")).Text = ((HotelOrderItem)tempHotelOrderItem[0]).CheckIn.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo) + " | " + ((HotelOrderItem)tempHotelOrderItem[0]).CheckOut.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                //((Label)e.Item.FindControl("lbHotelDetails")).Text = strHotelDetails;
            }
            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                //((Label)e.Item.FindControl("lbNights")).Text = ((TimeSpan)((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.Subtract(((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn)).Days.ToString();
                //((Label)e.Item.FindControl("lbCheckDate")).Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo) + " | " + ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

                //string strHotelDetails = string.Empty;

                //for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                //{
                //    HotelOrderItem hotelOrderItem = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                //    if (i == 0)
                //    {
                //        strHotelDetails += "Room #" + (i + 1).ToString() + ": " + hotelOrderItem.Room.Description;
                //    }
                //    else
                //    {
                //        strHotelDetails += @"<BR /> Room #" + (i + 1).ToString() + ": " + hotelOrderItem.Room.Description;
                //    }
                //}

                //((Label)e.Item.FindControl("lbHotelDetails")).Text = strHotelDetails;
            }

        }
    }
}
