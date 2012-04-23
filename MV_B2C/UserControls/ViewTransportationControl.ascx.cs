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
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using System.Collections.Generic;

public partial class ViewTransportationControl : SalesBaseUserControl
{
    List<TransferOrderItem> transferOrderItems = new List<TransferOrderItem>();

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

                    lblName_Then.Text = transfer.ItemName;

                    lblArrivingFrom_Then.Text = transfer.ArrivingFrom;

                    lblAirline_Then.Text = transfer.FlightNumber;

                    lblArrival_Then.Text = transfer.EstimatedTimeofArrival.ToString("MM/dd/yyyy H:mm:ss");

                    lblHotelAddress_Then.Text = transfer.HotelAddress;

                    lblCity_Then.Text = transfer.City;

                    lblState_Then.Text = transfer.State;

                    lblZip_Then.Text = transfer.ZipCode;

                    lblTel_Then.Text = transfer.PhoneNumber;

                    hpDetailAndCancel_Then.NavigateUrl = "~/Page/Common/TransferDetail.aspx?city=" + transfer.PickUpCityCode + "&&item=" + transfer.ItemCode +
                            "&&Date=" + Server.UrlEncode(transfer.EstimatedTimeofArrival.ToString()) + "&&language=E&&car=" + transfer.TransferVehicles[0].Code + "&&passengers=" + transfer.TransferVehicles[0].MaximumPassengers;
                }
                if (transfer.Type == 1)
                {
                    divSend.Visible = true;

                    lblName_Send.Text = transfer.ItemName;

                    lblArrivingFrom_Send.Text = transfer.ArrivingFrom;

                    lblAirline_Send.Text = transfer.FlightNumber;

                    lblArrival_Send.Text = transfer.EstimatedTimeofArrival.ToString("MM/dd/yyyy H:mm:ss");

                    lblHotelAddress_Send.Text = transfer.HotelAddress;

                    lblCity_Send.Text = transfer.City;

                    lblState_Send.Text = transfer.State;

                    lblTel_Send.Text = transfer.PhoneNumber;

                    lblZip_Send.Text = transfer.ZipCode;

                    lblPickupTime.Text = transfer.Time.ToString("MM/dd/yyyy H:mm:ss");

                    hpDetailAndCancel_Send.NavigateUrl = "~/Page/Common/TransferDetail.aspx?city=" + transfer.PickUpCityCode + "&&item=" + transfer.ItemCode +
                           "&&Date=" + Server.UrlEncode(transfer.EstimatedTimeofArrival.ToString()) + "&&language=E&&car=" + transfer.TransferVehicles[0].Code + "&&passengers=" + transfer.TransferVehicles[0].MaximumPassengers;
                }
            }
        }
    }
}
