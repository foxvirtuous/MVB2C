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
using TERMS.Business.Centers.SalesCenter;
using System.Collections.Generic;
using TERMS.Business.Centers.ProductCenter.Components;

public partial class SearchTransportationControl : SalesBaseUserControl
{
    private List<Terms.Contract.Business_0407.GTATransferMaterial> transfersFrom = new List<Terms.Contract.Business_0407.GTATransferMaterial>();
    private List<Terms.Contract.Business_0407.GTATransferMaterial> transfersTo = new List<Terms.Contract.Business_0407.GTATransferMaterial>();

    private string FromDate = string.Empty;
    private string ToDate = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchNew();
            BindTransfers();
        }

        this.Page.FindControl("divTransportation").Visible = false;
        this.Page.FindControl("div5").Visible = false;
        this.Page.FindControl("div4").Visible = true;
    }


    private void SearchNew()
    {
        TransferSearchCondition searchConditionFrom = new TransferSearchCondition();
        searchConditionFrom.CurrencyCode = ConfigurationManager.AppSettings.Get("OrderCurrency");
        TransferSearchCondition searchConditionTo = new TransferSearchCondition();
        searchConditionTo.CurrencyCode = ConfigurationManager.AppSettings.Get("OrderCurrency");
        
        if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
        }

        if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            PackageSearchCondition packageSearchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;

            if (Utility.Transaction.CurrentTransactionObject.Items[0] is TERMS.Business.Centers.SalesCenter.PackageOrderItem)
            {
                foreach (OrderItem item in ((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items)
                {
                    if (item is AirOrderItem)
                    {
                        AirOrderItem air = (AirOrderItem)item;

                        TERMS.Common.AirLeg airlegFrom = air.Merchandise.AirTrip.SubTrips[0].Flights[air.Merchandise.AirTrip.SubTrips[0].Flights.Count - 1];

                        searchConditionFrom.PreferredLanguage = "E";
                        searchConditionFrom.Passengers = packageSearchCondition.AirSearchCondition.Passengers.Count;
                        if (string.IsNullOrEmpty(((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CityCode_Travco))
                        {
                            searchConditionFrom.Country = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CountryCode;
                            searchConditionFrom.PickupCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.Code;
                        }
                        else
                        {
                            searchConditionFrom.Country = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CountryCode;
                            searchConditionFrom.PickupCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CityCode_Travco;
                        }
                        searchConditionFrom.PickupCode = "A";


                        if (string.IsNullOrEmpty(((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CityCode_Travco))
                        {
                            searchConditionFrom.DropOffCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.Code;
                        }
                        else
                        {
                            searchConditionFrom.DropOffCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CityCode_Travco;
                        }
                        searchConditionFrom.DropOffCode = "H";

                        searchConditionFrom.TransferDate = airlegFrom.ArriveTime;

                        TERMS.Common.AirLeg airlegTo = air.Merchandise.AirTrip.SubTrips[1].Flights[0];

                        if (packageSearchCondition.DestinationAirPortsTwo != null)
                        {
                            searchConditionTo.PreferredLanguage = "E";
                            searchConditionTo.Passengers = packageSearchCondition.AirSearchCondition.Passengers.Count;

                            if (string.IsNullOrEmpty(((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPortsTwo[0]).City.CityCode_Travco))
                            {
                                searchConditionTo.Country = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPortsTwo[0]).City.CountryCode;
                                searchConditionTo.PickupCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPortsTwo[0]).City.Code;
                            }
                            else
                            {
                                searchConditionTo.Country = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPortsTwo[0]).City.Country.Code;
                                searchConditionTo.PickupCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPortsTwo[0]).City.CityCode_Travco;
                            }
                            searchConditionTo.PickupCode = "H";

                            if (string.IsNullOrEmpty(((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPortsTwo[0]).City.CityCode_Travco))
                            {
                                searchConditionTo.DropOffCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPortsTwo[0]).City.Code;
                            }
                            else
                            {
                                searchConditionTo.DropOffCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPortsTwo[0]).City.CityCode_Travco;
                            }
                            searchConditionTo.DropOffCode = "A";

                            searchConditionTo.TransferDate = airlegTo.DepartureTime;
                        }
                        else
                        {
                            searchConditionTo.PreferredLanguage = "E";
                            searchConditionTo.Passengers = packageSearchCondition.AirSearchCondition.Passengers.Count;
                            if (string.IsNullOrEmpty(((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CityCode_Travco))
                            {
                                searchConditionTo.Country = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CountryCode;
                                searchConditionTo.PickupCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.Code;
                            }
                            else
                            {
                                searchConditionTo.Country = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CountryCode;
                                searchConditionTo.PickupCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CityCode_Travco;
                            }
                            searchConditionTo.PickupCode = "H";

                            if (string.IsNullOrEmpty(((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CityCode_Travco))
                            {
                                searchConditionTo.DropOffCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.Code;
                            }
                            else
                            {
                                searchConditionTo.DropOffCityCode = ((Terms.Common.Domain.Airport)packageSearchCondition.DestinationAirPorts[0]).City.CityCode_Travco;
                            }
                            searchConditionTo.DropOffCode = "A";

                            searchConditionTo.TransferDate = airlegTo.DepartureTime;
                        }
                    }
                }
            }
        }

        TERMS.Business.Centers.ProductCenter.Components.TransferProduct product = SearchTransfer(searchConditionFrom);

        if (product != null)
        {
            for (int i = 0; i < product.Items.Count; i++)
            {
                transfersFrom.Add((Terms.Contract.Business_0407.GTATransferMaterial)((TERMS.Core.Product.ComponentGroup)product.Items[i]).Items[0]);
            }
            FromDate = searchConditionFrom.TransferDate.ToString("MM/dd/yyyy");
        }

        product = SearchTransfer(searchConditionTo);

        if (product != null)
        {
            for (int i = 0; i < product.Items.Count; i++)
            {
                transfersTo.Add((Terms.Contract.Business_0407.GTATransferMaterial)((TERMS.Core.Product.ComponentGroup)product.Items[i]).Items[0]);
            }
            ToDate = searchConditionTo.TransferDate.ToString("MM/dd/yyyy");
        }
    }

    private void BindTransfers()
    {
        PackageSearchCondition packageSearchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;

        bool flag = false;

        List<string> list = new List<string>(2);
        list.Add("A");
        list.Add("B");
        dlTransfers.DataSource = list;
        dlTransfers.DataBind();

        int addPassengers = Convert.ToInt32(ConfigurationManager.AppSettings.Get("AddPassengers"));

        AirOrderItem air = null;

        if (Utility.Transaction.CurrentTransactionObject.Items[0] is TERMS.Business.Centers.SalesCenter.PackageOrderItem)
        {
            foreach (OrderItem item in ((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items)
            {
                if (item is AirOrderItem)
                {
                    air = (AirOrderItem)item;
                }
            }
        }

        if (transfersFrom.Count > 0)
        {
            TERMS.Common.AirLeg airlegFrom = air.Merchandise.AirTrip.SubTrips[0].Flights[air.Merchandise.AirTrip.SubTrips[0].Flights.Count - 1];

            DataListItem item = dlTransfers.Items[0];

            DataList dl = (DataList)item.FindControl("dlTransfer");

            List<SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer>> all = new List<SortedList<int, Terms.Contract.Business_0407.GTA.Transfer>>();

            for (int i = 0; i < transfersFrom.Count; i++)
            {
                for (int j = 0; j < transfersFrom[i].Transfer.TransferVehicles.Length; j++)
                {
                    if (packageSearchCondition.AirSearchCondition.Passengers[TERMS.Common.PassengerType.Adult] + packageSearchCondition.AirSearchCondition.Passengers[TERMS.Common.PassengerType.Child] <= transfersFrom[i].Transfer.TransferVehicles[j].MaximumPassengers &&
                        packageSearchCondition.AirSearchCondition.Passengers[TERMS.Common.PassengerType.Adult] + packageSearchCondition.AirSearchCondition.Passengers[TERMS.Common.PassengerType.Child] + addPassengers >= transfersFrom[i].Transfer.TransferVehicles[j].MaximumPassengers)
                    {
                        int minute = Convert.ToInt32(transfersFrom[i].Transfer.TimeCode.Substring(transfersFrom[i].Transfer.TimeCode.IndexOf(".") + 1));
                        int hour = Convert.ToInt32(transfersFrom[i].Transfer.TimeCode.Substring(0, transfersFrom[i].Transfer.TimeCode.IndexOf(".")));
                        DateTime dateFrom = airlegFrom.ArriveTime;

                        if (dateFrom.AddHours(hour).AddMinutes(minute) >= new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 08, 00, 00) &&
                            dateFrom.AddHours(hour).AddMinutes(minute) <= new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 20, 00, 00) &&
                            dateFrom >= new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 08, 00, 00) &&
                            dateFrom <= new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 20, 00, 00) ||
                            Convert.ToDouble(transfersFrom[i].Transfer.TimeCode) <= 2.00)
                        { 
                             SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer> listTransfer = new SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer>();
                            listTransfer.Add(j, transfersFrom[i].Transfer);
                            all.Add(listTransfer);
                        }
                    }
                }
            }

            all.Sort(delegate(SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer> r1, SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer> r2) { return r1.Values[0].TransferVehicles[r1.Keys[0]].Price.CompareTo(r2.Values[0].TransferVehicles[r2.Keys[0]].Price); });

            dl.DataSource = all;
            dl.DataBind();

            Label lblFromTo = (Label)item.FindControl("lblFromTo");

            if (all.Count > 0)
            {
                flag = true;

                lblFromTo.Text = FromDate + " From Airport To Hotel";

                lblFromTo.Visible = true;
            }
            else
            {
                lblFromTo.Visible = false;
            }
            for (int i = 0; i < dl.Items.Count; i++)
            {
                DataListItem info = dl.Items[i];

                Label lbl = (Label)info.FindControl("lblName");

                lbl.Text = all[i].Values[0].ItemName;

                lbl = (Label)info.FindControl("lblInfo");

                lbl.Text = "Vehicle: " + all[i].Values[0].TransferVehicles[all[i].Keys[0]].Description + ", Maximum Passengers: " + all[i].Values[0].TransferVehicles[all[i].Keys[0]].MaximumPassengers + ", Maximum Luggage:" + all[i].Values[0].TransferVehicles[all[i].Keys[0]].MaximumLuggage;

                lbl = (Label)info.FindControl("lblPrice");

                //lbl.Text = all[i].Values[0].TransferVehicles[all[i].Keys[0]].Price.ToString("N2");

                if (Utility.IsSubAgent)
                {
                    lbl.Text = (all[i].Values[0].TransferVehicles[all[i].Keys[0]].Price * 1.1M).ToString("N2");
                }
                else
                {
                    lbl.Text = (all[i].Values[0].TransferVehicles[all[i].Keys[0]].Price * 1.15M).ToString("N2");
                }

                lbl = (Label)info.FindControl("lblItemCode");

                lbl.Text = all[i].Values[0].ItemCode;

                lbl = (Label)info.FindControl("lblVehiclesCode");

                lbl.Text = all[i].Values[0].TransferVehicles[all[i].Keys[0]].Code;

                lbl = (Label)info.FindControl("lblMaxPassengers");

                lbl.Text = all[i].Values[0].TransferVehicles[all[i].Keys[0]].MaximumPassengers.ToString();

                lbl = (Label)info.FindControl("lblMaxLuggage");

                lbl.Text = all[i].Values[0].TransferVehicles[all[i].Keys[0]].MaximumLuggage.ToString();

                lbl = (Label)info.FindControl("lblTime");

                lbl.Text = "transfer time :" + all[i].Values[0].TimeName;

                HyperLink hp = (HyperLink)info.FindControl("hpDetail");

                hp.NavigateUrl = "~/Page/Common/TransferDetail.aspx?city=" + all[i].Values[0].CityCode + "&&item=" + all[i].Values[0].ItemCode;

                RadioButton rbten = (RadioButton)info.FindControl("rbnSelect");

                if (i == 0)
                {
                    rbten.Checked = false;
                }
                else
                {
                    rbten.Checked = false;
                }

                rbten.ToolTip = "From";

                rbten.Attributes["onclick"] = "javascript:CancelSelect(this,'SearchTransportationControl1$dlTransfers$ctl00$dlTransfer$ctl" + i.ToString().PadLeft(2,'0') + "');";
            }
        }

        if (transfersTo.Count > 0)
        {
            DataListItem item = dlTransfers.Items[1];

            DataList dl = (DataList)item.FindControl("dlTransfer");

            List<SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer>> all = new List<SortedList<int, Terms.Contract.Business_0407.GTA.Transfer>>();

            TERMS.Common.AirLeg airlegTo = air.Merchandise.AirTrip.SubTrips[1].Flights[0];

            for (int i = 0; i < transfersTo.Count; i++)
            {
                for (int j = 0; j < transfersTo[i].Transfer.TransferVehicles.Length; j++)
                {
                    if (packageSearchCondition.AirSearchCondition.Passengers[TERMS.Common.PassengerType.Adult] + packageSearchCondition.AirSearchCondition.Passengers[TERMS.Common.PassengerType.Child] <= transfersTo[i].Transfer.TransferVehicles[j].MaximumPassengers &&
                        packageSearchCondition.AirSearchCondition.Passengers[TERMS.Common.PassengerType.Adult] + packageSearchCondition.AirSearchCondition.Passengers[TERMS.Common.PassengerType.Child] + addPassengers >= transfersTo[i].Transfer.TransferVehicles[j].MaximumPassengers)
                    {
                        int minute = Convert.ToInt32(transfersTo[i].Transfer.TimeCode.Substring(transfersTo[i].Transfer.TimeCode.IndexOf(".") + 1));
                        int hour = Convert.ToInt32(transfersTo[i].Transfer.TimeCode.Substring(0, transfersTo[i].Transfer.TimeCode.IndexOf(".")));
                        DateTime dateTo = airlegTo.DepartureTime;

                        if (dateTo.AddHours(-hour).AddMinutes(-minute) >= new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 08, 00, 00) &&
                            dateTo.AddHours(-hour).AddMinutes(-minute) <= new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 20, 00, 00) &&
                            dateTo >= new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 08, 00, 00) &&
                            dateTo <= new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 20, 00, 00) ||                            
                            Convert.ToDouble(transfersTo[i].Transfer.TimeCode) <= 2.00)
                        {
                            SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer> listTransfer = new SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer>();
                            listTransfer.Add(j, transfersTo[i].Transfer);
                            all.Add(listTransfer);
                        }
                    }
                }
            }

            all.Sort(delegate(SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer> r1, SortedList<Int32, Terms.Contract.Business_0407.GTA.Transfer> r2) { return r1.Values[0].TransferVehicles[r1.Keys[0]].Price.CompareTo(r2.Values[0].TransferVehicles[r2.Keys[0]].Price); });

            dl.DataSource = all;
            dl.DataBind();

            Label lblFromTo = (Label)item.FindControl("lblFromTo");

            if (all.Count > 0)
            {
                flag = true;

                lblFromTo.Text = ToDate + " From Hotel To Airport";

                lblFromTo.Visible = true;
            }
            else
            {
                lblFromTo.Visible = false;
            }

            for (int i = 0; i < dl.Items.Count; i++)
            {
                DataListItem info = dl.Items[i];

                Label lbl = (Label)info.FindControl("lblName");

                lbl.Text = all[i].Values[0].ItemName;

                lbl = (Label)info.FindControl("lblInfo");

                lbl.Text = "Vehicle: " + all[i].Values[0].TransferVehicles[all[i].Keys[0]].Description + ", Maximum Passengers: " + all[i].Values[0].TransferVehicles[all[i].Keys[0]].MaximumPassengers + ", Maximum Luggage:" + all[i].Values[0].TransferVehicles[all[i].Keys[0]].MaximumLuggage;

                lbl = (Label)info.FindControl("lblPrice");

                if (Utility.IsSubAgent)
                {
                    lbl.Text = (all[i].Values[0].TransferVehicles[all[i].Keys[0]].Price * 1.1M).ToString("N2");
                }
                else
                {
                    lbl.Text = (all[i].Values[0].TransferVehicles[all[i].Keys[0]].Price * 1.15M).ToString("N2");
                }

                lbl = (Label)info.FindControl("lblItemCode");

                lbl.Text = all[i].Values[0].ItemCode;

                lbl = (Label)info.FindControl("lblVehiclesCode");

                lbl.Text = all[i].Values[0].TransferVehicles[all[i].Keys[0]].Code;

                lbl = (Label)info.FindControl("lblMaxPassengers");

                lbl.Text = all[i].Values[0].TransferVehicles[all[i].Keys[0]].MaximumPassengers.ToString();

                lbl = (Label)info.FindControl("lblMaxLuggage");

                lbl.Text = all[i].Values[0].TransferVehicles[all[i].Keys[0]].MaximumLuggage.ToString();

                lbl = (Label)info.FindControl("lblTime");

                lbl.Text = "transfer time :" + all[i].Values[0].TimeName;

                HyperLink hp = (HyperLink)info.FindControl("hpDetail");

                hp.NavigateUrl = "~/Page/Common/TransferDetail.aspx?city=" + all[i].Values[0].CityCode + "&&item=" + all[i].Values[0].ItemCode;

                RadioButton rbten = (RadioButton)info.FindControl("rbnSelect");

                rbten.Attributes["onclick"] = "javascript:CancelSelect(this,'SearchTransportationControl1$dlTransfers$ctl01$dlTransfer$ctl" + i.ToString().PadLeft(2, '0') + "');";

                if (i == 0)
                {
                    rbten.Checked = false;
                }
                else
                {
                    rbten.Checked = false;
                }

                rbten.ToolTip = "To";
            }
        }

        if (!flag)
        {
            dlTransfers.Visible = false;

            this.Page.FindControl("divTransportation").Visible = false;
            this.Page.FindControl("div5").Visible = false;
            this.Page.FindControl("div4").Visible = true;
        }
    }

    public void AddTransfer()
    {
        SearchNew();

        //bool flag = false;

        for (int index = 0; index < dlTransfers.Items.Count; index++)
        {
            DataListItem item = dlTransfers.Items[index];

            DataList dl = (DataList)item.FindControl("dlTransfer");

            TransferOrderItem orderitem = new TransferOrderItem(new TERMS.Business.Centers.ProductCenter.Profiles.TransferProfile("Transfer"));

            for (int i = 0; i < dl.Items.Count; i++)
            {
                RadioButton rbten = (RadioButton)dl.Items[i].FindControl("rbnSelect");

                if (rbten.Checked)
                {
                    Label lbl = (Label)dl.Items[i].FindControl("lblItemCode");

                    string itemCode = lbl.Text;

                    lbl = (Label)dl.Items[i].FindControl("lblVehiclesCode");

                    string vehiclesCode = lbl.Text;

                    lbl = (Label)dl.Items[i].FindControl("lblMaxPassengers");

                    string maximumPassengers = lbl.Text;

                    lbl = (Label)dl.Items[i].FindControl("lblMaxLuggage");

                    string maximumLuggage = lbl.Text;

                    if (rbten.ToolTip == "From")
                    {
                        foreach (Terms.Contract.Business_0407.GTATransferMaterial gta in transfersFrom)
                        {
                            if (gta.Transfer.ItemCode == itemCode)
                            {
                                foreach (Terms.Contract.Business_0407.GTA.TransferVehicle vehicle in gta.Transfer.TransferVehicles)
                                {
                                    if (vehicle.Code == vehiclesCode && vehicle.MaximumPassengers == Convert.ToInt32(maximumPassengers) && vehicle.MaximumLuggage == Convert.ToInt32(maximumLuggage))
                                    {
                                        orderitem.CityCode = gta.Transfer.CityCode;
                                        orderitem.CityName = gta.Transfer.CityName;
                                        orderitem.DropOffAirportCode = gta.Transfer.DropOffAirportCode;
                                        orderitem.DropOffAirportName = gta.Transfer.DropOffAirportName;

                                        orderitem.DropOffCityCode = gta.Transfer.DropOffCityCode;
                                        orderitem.DropOffCityName = gta.Transfer.DropOffCityName;
                                        orderitem.DropOffCode = gta.Transfer.DropOffCode;
                                        orderitem.DropOffName = gta.Transfer.DropOffName;

                                        orderitem.ItemCode = gta.Transfer.ItemCode;
                                        orderitem.ItemName = gta.Transfer.ItemName;
                                        orderitem.PickUpAirportCode = gta.Transfer.PickUpAirportCode;
                                        orderitem.PickUpAirportName = gta.Transfer.PickUpAirportName;

                                        orderitem.PickUpCityCode = gta.Transfer.PickUpCityCode;
                                        orderitem.PickUpCityName = gta.Transfer.PickUpCityName;
                                        orderitem.PickUpCode = gta.Transfer.PickUpCode;
                                        orderitem.PickUpName = gta.Transfer.PickUpName;

                                        orderitem.TimeCode = gta.Transfer.TimeCode;
                                        orderitem.TimeName = gta.Transfer.TimeName;

                                        TransferVehicleItem vehicleItem = new TransferVehicleItem();

                                        vehicleItem.Code = vehicle.Code;
                                        vehicleItem.Confirmation = vehicle.Confirmation;
                                        vehicleItem.ConfirmationCode = vehicle.ConfirmationCode;
                                        vehicleItem.CurrencyCode = vehicle.CurrencyCode;
                                        vehicleItem.Description = vehicle.Description;
                                        vehicleItem.Language = vehicle.Language;
                                        vehicleItem.LanguageCode = vehicle.LanguageCode;
                                        vehicleItem.LeadPaxId = vehicle.LeadPaxId;
                                        vehicleItem.MaximumLuggage = vehicle.MaximumLuggage;
                                        vehicleItem.MaximumPassengers = vehicle.MaximumPassengers;
                                        vehicleItem.Passengers = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.Passengers.Count;
                                        //vehicleItem.Price = vehicle.Price;
                                        if (Utility.IsSubAgent)
                                        {
                                            vehicleItem.Price = vehicle.Price * 1.15M;
                                        }
                                        else
                                        {
                                            vehicleItem.Price = vehicle.Price * 1.1M;
                                        }
                                        orderitem.AddVehicle(vehicleItem);

                                        for (int count = 0; count < gta.Transfer.OutOfHoursSupplements.Length; count++)
                                        {
                                            OutOfHoursSupplementItem outOfHoursSupplementItem = new OutOfHoursSupplementItem();

                                            outOfHoursSupplementItem.From = gta.Transfer.OutOfHoursSupplements[count].From;
                                            outOfHoursSupplementItem.Supplement1 = gta.Transfer.OutOfHoursSupplements[count].Supplement;
                                            outOfHoursSupplementItem.To = gta.Transfer.OutOfHoursSupplements[count].To;

                                            orderitem.AddOutOfHoursSupplement(outOfHoursSupplementItem);
                                        }

                                        orderitem.Type = 0;

                                        Utility.Transaction.CurrentTransactionObject.AddItem(orderitem);
                                    }   
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Terms.Contract.Business_0407.GTATransferMaterial gta in transfersTo)
                        {
                            if (gta.Transfer.ItemCode == itemCode)
                            {
                                foreach (Terms.Contract.Business_0407.GTA.TransferVehicle vehicle in gta.Transfer.TransferVehicles)
                                {
                                    if (vehicle.Code == vehiclesCode && vehicle.MaximumPassengers == Convert.ToInt32(maximumPassengers) && vehicle.MaximumLuggage == Convert.ToInt32(maximumLuggage))
                                    {
                                        orderitem.CityCode = gta.Transfer.CityCode;
                                        orderitem.CityName = gta.Transfer.CityName;
                                        orderitem.DropOffAirportCode = gta.Transfer.DropOffAirportCode;
                                        orderitem.DropOffAirportName = gta.Transfer.DropOffAirportName;

                                        orderitem.DropOffCityCode = gta.Transfer.DropOffCityCode;
                                        orderitem.DropOffCityName = gta.Transfer.DropOffCityName;
                                        orderitem.DropOffCode = gta.Transfer.DropOffCode;
                                        orderitem.DropOffName = gta.Transfer.DropOffName;

                                        orderitem.ItemCode = gta.Transfer.ItemCode;
                                        orderitem.ItemName = gta.Transfer.ItemName;
                                        orderitem.PickUpAirportCode = gta.Transfer.PickUpAirportCode;
                                        orderitem.PickUpAirportName = gta.Transfer.PickUpAirportName;

                                        orderitem.PickUpCityCode = gta.Transfer.PickUpCityCode;
                                        orderitem.PickUpCityName = gta.Transfer.PickUpCityName;
                                        orderitem.PickUpCode = gta.Transfer.PickUpCode;
                                        orderitem.PickUpName = gta.Transfer.PickUpName;

                                        orderitem.TimeCode = gta.Transfer.TimeCode;
                                        orderitem.TimeName = gta.Transfer.TimeName;

                                        TransferVehicleItem vehicleItem = new TransferVehicleItem();

                                        vehicleItem.Code = vehicle.Code;
                                        vehicleItem.Confirmation = vehicle.Confirmation;
                                        vehicleItem.ConfirmationCode = vehicle.ConfirmationCode;
                                        vehicleItem.CurrencyCode = vehicle.CurrencyCode;
                                        vehicleItem.Description = vehicle.Description;
                                        vehicleItem.Language = vehicle.Language;
                                        vehicleItem.LanguageCode = vehicle.LanguageCode;
                                        vehicleItem.LeadPaxId = vehicle.LeadPaxId;
                                        vehicleItem.MaximumLuggage = vehicle.MaximumLuggage;
                                        vehicleItem.MaximumPassengers = vehicle.MaximumPassengers;
                                        vehicleItem.Passengers = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.Passengers.Count;
                                        if (Utility.IsSubAgent)
                                        {
                                            vehicleItem.Price = vehicle.Price * 1.15M;
                                        }
                                        else
                                        {
                                            vehicleItem.Price = vehicle.Price * 1.1M; 
                                        }

                                        orderitem.AddVehicle(vehicleItem);

                                        for (int count = 0; count < gta.Transfer.OutOfHoursSupplements.Length; count++)
                                        {
                                            OutOfHoursSupplementItem outOfHoursSupplementItem = new OutOfHoursSupplementItem();

                                            outOfHoursSupplementItem.From = gta.Transfer.OutOfHoursSupplements[count].From;
                                            outOfHoursSupplementItem.Supplement1 = gta.Transfer.OutOfHoursSupplements[count].Supplement;
                                            outOfHoursSupplementItem.To = gta.Transfer.OutOfHoursSupplements[count].To;

                                            orderitem.AddOutOfHoursSupplement(outOfHoursSupplementItem);
                                        }

                                        orderitem.Type = 1;

                                        Utility.Transaction.CurrentTransactionObject.AddItem(orderitem);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //return flag;
    }
}


//<ListDetails>
//  <Description Code="A"><![CDATA[Airport]]></Description>
//  <Description Code="H"><![CDATA[Accommodation]]></Description>
//  <Description Code="P"><![CDATA[Port]]></Description>
//  <Description Code="S"><![CDATA[Station]]></Description>
//  <Description Code="O"><![CDATA[Other]]></Description>
//</ListDetails>
