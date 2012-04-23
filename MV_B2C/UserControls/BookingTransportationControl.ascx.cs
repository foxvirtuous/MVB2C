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
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;

public partial class BookingTransportationControl : SalesBaseUserControl
{
    List<TransferOrderItem> transferOrderItems = new List<TransferOrderItem>();

    private string _Warning;
    public string Warning
    {
        get
        {
            return _Warning;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Utility.Transaction.CurrentTransactionObject != null)
            {
                foreach (OrderItem item in Utility.Transaction.CurrentTransactionObject.Items)
                {
                    if (item is TransferOrderItem)
                    {
                        transferOrderItems.Add((TransferOrderItem)item);
                    }
                }
            }

            BindInfo();
        }
    }

    private void BindInfo()
    {
        if (transferOrderItems.Count > 0)
        {
            HotelOrderItem hotelFrom = null;
            HotelOrderItem hotelTo = null;

            foreach (OrderItem item in ((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items)
            {
                if (item is HotelOrderItem)
                {
                    if (hotelFrom == null && hotelTo == null)
                    {
                        hotelFrom = (HotelOrderItem)item;
                        hotelTo = (HotelOrderItem)item;
                    }
                    else
                    { 
                        HotelOrderItem hotel = (HotelOrderItem)item;

                        if (hotel.CheckIn < hotelFrom.CheckIn)
                        {
                            hotelFrom = hotel;
                        }

                        if (hotel.CheckIn > hotelTo.CheckIn)
                        {
                            hotelTo = hotel;
                        }
                    }
                }
            }

            foreach (TransferOrderItem transfer in transferOrderItems)
            {
                if (transfer.Type == 0)
                {
                    divThen.Visible = true;

                    PackageSearchCondition packageSearchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;

                    if (Utility.Transaction.CurrentTransactionObject.Items[0] is TERMS.Business.Centers.SalesCenter.PackageOrderItem)
                    {
                        foreach (OrderItem item in ((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items)
                        {
                            if (item is AirOrderItem)
                            {
                                AirOrderItem air = (AirOrderItem)item;

                                TERMS.Common.AirLeg airlegFrom = air.Merchandise.AirTrip.SubTrips[0].Flights[air.Merchandise.AirTrip.SubTrips[0].Flights.Count - 1];

                                if (!string.IsNullOrEmpty(airlegFrom.DestinationAirport.Name))
                                {
                                    txtArrivingFrom_Then.Text = airlegFrom.DestinationAirport.City.Name + " , " + airlegFrom.DestinationAirport.Name;
                                }
                                else
                                {
                                    txtArrivingFrom_Then.Text = airlegFrom.DestinationAirport.City.Name + " (" + airlegFrom.DestinationAirport.Code + ")";
                                }

                                lblName_Then.Text = transfer.ItemName;

                                txtAirline_Then.Text = airlegFrom.AirLine.Code + "#" + airlegFrom.FlightNumber;

                                txtArrival_Then.Text = airlegFrom.ArriveTime.ToString("MM/dd/yyyy H:mm:ss");

                                if (hotelFrom.Room.Hotel.Address.Length > 40)
                                {
                                    txtHotelAddress_Then.Text = hotelFrom.Room.Hotel.Address.Substring(0, 40);
                                    txtHotelAddress1_Then.Visible = true;
                                    txtHotelAddress1_Then.Text = hotelFrom.Room.Hotel.Address.Substring(40);
                                }
                                else
                                {
                                    txtHotelAddress_Then.Text = hotelFrom.Room.Hotel.Address;
                                }

                                txtZip_Then.Text = hotelFrom.Room.Hotel.GetAddress().ZipCode;

                                txtCity_Then.Text = hotelFrom.Room.Hotel.City.Name;

                                //txtState_Then.Text = hotelFrom.Room.Hotel.City.Country.Name;
                                cddThen.SelectedValue = hotelFrom.Room.Hotel.City.CountryCode;

                                dllCountry_Then.SelectedValue = hotelFrom.Room.Hotel.City.Country.Code;

                                txtTel_Then.Text = hotelFrom.Room.Hotel.Telephone;

                                lblHotelCode_Then.Text = hotelFrom.Room.Hotel.HotelCode;

                                lblHotelName_Then.Text = hotelFrom.Room.Hotel.Name;

                                lblCityCode_Then.Text = hotelFrom.Room.Hotel.City.Code;
                            }
                        }
                    }
                }
                if (transfer.Type == 1)
                {
                    divSend.Visible = true;

                    PackageSearchCondition packageSearchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;

                    if (Utility.Transaction.CurrentTransactionObject.Items[0] is TERMS.Business.Centers.SalesCenter.PackageOrderItem)
                    {
                        foreach (OrderItem item in ((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items)
                        {
                            if (item is AirOrderItem)
                            {
                                AirOrderItem air = (AirOrderItem)item;

                                TERMS.Common.AirLeg airlegFrom = air.Merchandise.AirTrip.SubTrips[1].Flights[0];

                                //txtArrivingFrom_Send.Text = airlegFrom.DepartureAirport.City.Name;

                                if (!string.IsNullOrEmpty(airlegFrom.DestinationAirport.Name))
                                {
                                    txtArrivingFrom_Send.Text = airlegFrom.DestinationAirport.City.Name + " , " + airlegFrom.DestinationAirport.Name;
                                }
                                else
                                {
                                    txtArrivingFrom_Send.Text = airlegFrom.DestinationAirport.City.Name + " (" + airlegFrom.DestinationAirport.Code + ")";
                                }

                                lblName_Send.Text = transfer.ItemName;

                                txtAirline_Send.Text = airlegFrom.AirLine.Code + "#" + airlegFrom.FlightNumber;

                                txtArrival_Send.Text = airlegFrom.DepartureTime.ToString("MM/dd/yyyy H:mm:ss");

                                if (hotelTo.Room.Hotel.Address.Length > 40)
                                {
                                    txtHotelAddress_Send.Text = hotelTo.Room.Hotel.Address.Substring(0, 40);
                                    txtHotelAddress1_Send.Visible = true;
                                    txtHotelAddress1_Send.Text = hotelTo.Room.Hotel.Address.Substring(40);
                                }
                                else
                                {
                                    txtHotelAddress_Send.Text = hotelTo.Room.Hotel.Address;
                                }
                                txtZip_Send.Text = hotelTo.Room.Hotel.GetAddress().ZipCode;

                                txtCity_Send.Text = hotelTo.Room.Hotel.City.Name;

                                //txtState_Send.Text = hotelTo.Room.Hotel.City.Country.Name;
                                //dllCountry_Send.SelectedIndex = dllCountry_Send.Items.IndexOf(dllCountry_Send.Items.FindByText(hotelTo.Room.Hotel.City.Country.Name));
                                cddSend.SelectedValue = hotelTo.Room.Hotel.City.CountryCode;

                                txtTel_Send.Text = hotelTo.Room.Hotel.Telephone;

                                lblHotelCode_Send.Text = hotelTo.Room.Hotel.HotelCode;

                                lblHotelName_Send.Text = hotelTo.Room.Hotel.Name;

                                lblCityCode_Send.Text = hotelTo.Room.Hotel.City.Code;

                                lblMinTime.Text = "Pickup Time must earlier than Estimated Time of Arrival " + (Convert.ToDouble(transfer.TimeCode) + 1).ToString() + " hours";
                            }
                        }
                    }
                }
            }
        }
    }

    public bool UpdateTransfer()
    {
        _Warning = string.Empty;

        if (Utility.Transaction.CurrentTransactionObject != null)
        {
            foreach (OrderItem item in Utility.Transaction.CurrentTransactionObject.Items)
            {
                if (item is TransferOrderItem)
                {
                    transferOrderItems.Add((TransferOrderItem)item);
                }
            }
        }

        foreach (TransferOrderItem item in transferOrderItems)
        {
            if (item.Type == 0)
            {
                if (string.IsNullOrEmpty(txtArrivingFrom_Then.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Arriving From Then can not be empty');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(txtAirline_Then.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Flight Number and Airline code Then can not be empty');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(txtHotelAddress_Then.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('HotelAddress Then can not be empty');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(txtZip_Then.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Zip Code Then can not be empty');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(txtArrival_Then.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Estimated Time of Arrival Then can not be empty');</script>");
                    return false;
                }

                try
                {
                    DateTime time = Convert.ToDateTime(txtArrival_Then.Text);
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Estimated Time of Arrival is error format');</script>");
                    return false;
                }
            }

            if (item.Type == 1)
            {
                if (string.IsNullOrEmpty(txtArrivingFrom_Send.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Arriving From Send can not be empty');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(txtAirline_Send.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Flight Number and Airline code Send can not be empty');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(txtHotelAddress_Send.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('HotelAddress Send can not be empty');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(txtZip_Send.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Zip Code Send can not be empty');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(txtArrival_Send.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Estimated Time of Arrival Send can not be empty');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(txtPickupTime.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Pickup Time Send can not be empty');</script>");
                    return false;
                }


                try
                {
                    DateTime time = Convert.ToDateTime(txtArrival_Send.Text);
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Estimated Time of Arrival is error format');</script>");
                    return false;
                }

                try
                {
                    DateTime time = Convert.ToDateTime(txtPickupTime.Text);
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Estimated Time of Arrival is error format');</script>");
                    return false;
                }


                for (int j = 0; j < item.OutOfHoursSupplements.Count; j++)
                {
                    DateTime time = Convert.ToDateTime(txtPickupTime.Text);

                    if (ComparativeTime(time, item.OutOfHoursSupplements[j].From, item.OutOfHoursSupplements[j].To))
                    {
                        if (!lblwarning.Visible)
                        {
                            lblwarning.Text = "Because the service you require is between " +
                            item.OutOfHoursSupplements[j].From.Substring(0, item.OutOfHoursSupplements[j].From.LastIndexOf(".")) + ":" +
                            item.OutOfHoursSupplements[j].From.Substring(item.OutOfHoursSupplements[j].From.LastIndexOf(".") + 1) + "-" +
                            item.OutOfHoursSupplements[j].To.Substring(0, item.OutOfHoursSupplements[j].To.LastIndexOf(".")) + ":" +
                            item.OutOfHoursSupplements[j].To.Substring(item.OutOfHoursSupplements[j].To.LastIndexOf(".") + 1) + " hours, a " + item.OutOfHoursSupplements[j].Supplement1 +
                            " supplement has been added to the price shown previously. If you would like to amend the timing of your service" +
                            "please adjust the pickup details. If you wish to proceed and book this service please click on the Yes button.";

                            _Warning = lblwarning.Text;
                        }
                    }
                }

                string minute = item.TimeCode.Substring(item.TimeCode.IndexOf(".") + 1);

                if (Convert.ToDateTime(txtPickupTime.Text).AddHours(Convert.ToDouble(item.TimeCode) + 1) > Convert.ToDateTime(txtArrival_Send.Text).AddMinutes(-1))
                {
                    if (minute.Trim().ToUpper() == "00".Trim())
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Pickup Time must earlier than Estimated Time of Arrival " + (Convert.ToDouble(item.TimeCode) + 1).ToString() + " hours " + minute + " minute');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Pickup Time must earlier than Estimated Time of Arrival " + (Convert.ToDouble(item.TimeCode) + 1).ToString() + " hours');</script>");
                    }
                        return false;
                }
            }
        }

        return true;
    }


    public bool DoUpdateTransfer()
    {
        if (Utility.Transaction.CurrentTransactionObject != null)
        {
            foreach (OrderItem item in Utility.Transaction.CurrentTransactionObject.Items)
            {
                if (item is TransferOrderItem)
                {
                    transferOrderItems.Add((TransferOrderItem)item);
                }
            }
        }

        foreach (TransferOrderItem item in transferOrderItems)
        {
            if (item.Type == 0)
            {
                item.ArrivingFrom = txtArrivingFrom_Then.Text;
                item.FlightNumber = txtAirline_Then.Text;
                item.EstimatedTimeofArrival = Convert.ToDateTime(txtArrival_Then.Text);
                if (txtHotelAddress1_Then.Visible)
                {
                    item.HotelAddress = txtHotelAddress_Then.Text + txtHotelAddress1_Then.Text;
                }
                else
                {
                    item.HotelAddress = txtHotelAddress_Then.Text;
                }
                item.ZipCode = txtZip_Then.Text;
                item.City = txtCity_Then.Text;
                item.Country = dllCountry_Then.SelectedValue;
                item.State = dllCountry_Then.SelectedItem.Text;
                item.PhoneNumber = txtTel_Then.Text;
                item.HotelCode = lblHotelCode_Then.Text;
                item.HotelName = lblHotelName_Then.Text;
                if (string.IsNullOrEmpty(item.PickUpCityCode))
                {
                    item.PickUpCityCode = lblCityCode_Then.Text;
                }
            }
            else
            {
                item.ArrivingFrom = txtArrivingFrom_Send.Text;
                item.FlightNumber = txtAirline_Send.Text;
                item.EstimatedTimeofArrival = Convert.ToDateTime(txtArrival_Send.Text);
                if (txtHotelAddress1_Send.Visible)
                {
                    item.HotelAddress = txtHotelAddress_Send.Text + txtHotelAddress1_Send.Text;
                }
                else
                {
                    item.HotelAddress = txtHotelAddress_Send.Text;
                }
                item.ZipCode = txtZip_Send.Text;
                item.City = txtCity_Send.Text;
                item.Country = dllCountry_Send.SelectedValue;
                item.State = dllCountry_Send.SelectedItem.Text;
                item.PhoneNumber = txtTel_Send.Text;
                item.HotelCode = lblHotelCode_Send.Text;
                item.HotelName = lblHotelName_Send.Text;
                item.Time = Convert.ToDateTime(txtPickupTime.Text);

                if (string.IsNullOrEmpty(item.PickUpCityCode))
                {
                    item.PickUpCityCode = lblCityCode_Send.Text;
                }
            }
        }

        return true;
    }


    private bool ComparativeTime(DateTime time, string from, string to)
    {
        int hour = time.Hour;

        int minute = time.Minute;

        int hourTo = Convert.ToInt32(to.Substring(0, to.LastIndexOf(".")));

        int minuteTo = Convert.ToInt32(to.Substring(to.LastIndexOf(".") + 1));

        int hourFrom = Convert.ToInt32(from.Substring(0, from.LastIndexOf(".")));

        int minuteFrom = Convert.ToInt32(from.Substring(from.LastIndexOf(".") + 1));

        DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);

        DateTime dateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourFrom, minuteFrom, 0);

        DateTime dateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourTo, minuteTo, 0);

        if (dateNow >= dateFrom && dateNow <= dateTo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
