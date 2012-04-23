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

//using Terms.Material.Domain;
using Terms.Sales.Dao;
using Terms.Product.Domain;
using Terms.Sales.Business;

public partial class FlightHeaderControl : Spring.Web.UI.UserControl
{
    public FlightHeaderControl()
    {
        this.InitializeControls += new EventHandler(FlightHeaderControl_InitializeControls);
    }

    void FlightHeaderControl_InitializeControls(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDate();
        }
    }

    public void BindDate()
    {
        //判断是否是Package
        if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            PackageSearchCondition PackageSearch = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;
            this.lbAdults.Text = PackageSearch.AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult).ToString();
            this.lbChilds.Text = PackageSearch.AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child).ToString();
            //this.lbDays.Text = ((TimeSpan)PackageSearch.AirSearchCondition.AirTripCondition[1].DepartureDate.Subtract(PackageSearch.AirSearchCondition.AirTripCondition[0].DepartureDate.AddDays(-1))).Days.ToString();
            //this.lbNights.Text = ((TimeSpan)PackageSearch.AirSearchCondition.AirTripCondition[1].DepartureDate.Subtract(PackageSearch.AirSearchCondition.AirTripCondition[0].DepartureDate)).Days.ToString();
            this.lbDeparture.Text = ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[0]).Departure.Name + " (" + ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[0]).Departure.Code + ")" ;
            this.lbDestination.Text = ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[0]).Destination.Name + " (" + ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[0]).Destination.Code + ")";
            //if ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[1] != null)
            //{
            //    this.lbDestination2.Text = ",Form " + ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[1]).Departure.Name + "(" + ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[1]).Departure.Code + ")" + " To " + ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[1]).Destination.Name + "(" + ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[1]).Destination.Code + ")";
            //}
        }
        //判断是否是Air
        if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
        {
            AirSearchCondition airSearch = (AirSearchCondition)Utility.Transaction.CurrentSearchConditions;

            this.lbAdults.Text = airSearch.GetPassengerNumber(TERMS.Common.PassengerType.Adult).ToString();
            this.lbChilds.Text = airSearch.GetPassengerNumber(TERMS.Common.PassengerType.Child).ToString();
            //this.lbDays.Text = ((TimeSpan)airSearch.AirTripCondition[1].DepartureDate.Subtract(airSearch.AirTripCondition[0].DepartureDate.AddDays(-1))).Days.ToString();
            //this.lbNights.Text = ((TimeSpan)airSearch.AirTripCondition[1].DepartureDate.Subtract(airSearch.AirTripCondition[0].DepartureDate)).Days.ToString();
            this.lbDeparture.Text = ((AirTripCondition)airSearch.GetAddTripCondition()[0]).Departure.City.Name + " (" + ((AirTripCondition)airSearch.GetAddTripCondition()[0]).Departure.Code + ")";
            this.lbDestination.Text = ((AirTripCondition)airSearch.GetAddTripCondition()[0]).Destination.City.Name + " (" + ((AirTripCondition)airSearch.GetAddTripCondition()[0]).Destination.Code + ")";
            //if ((AirTripCondition)airSearch.GetAddTripCondition()[1] != null)
            //{
            //    this.lbDestination2.Text = ",Form " + ((AirTripCondition)airSearch.GetAddTripCondition()[1]).Departure.Name + "(" + ((AirTripCondition)airSearch.GetAddTripCondition()[1]).Departure.Code + ")" + " To " + ((AirTripCondition)airSearch.GetAddTripCondition()[1]).Destination.Name + "(" + ((AirTripCondition)airSearch.GetAddTripCondition()[1]).Destination.Code + ")";
            //}
        }
        
        //decimal tempAirPrice = 0M;
        //decimal tempAirTax = 0M;
        //decimal tempHotelPrice = 0M;

        //if (Utility.SelectAirGroup != null)
        //{
        //    tempAirPrice = ((AirComponentGroup)Utility.SelectAirGroup.Items[0].Component).Total;
        //    tempAirTax = ((AirComponentGroup)Utility.SelectAirGroup.Items[0].Component).Tax;
        //    if (Utility.Transaction.CurrentTransactionObject.Items != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        //    {
        //        if (Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList != null && Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Count > 0)
        //        {
        //            foreach (HotelMaterial hm in Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList)
        //            {
        //                tempHotelPrice += hm.Price.Total;
        //            }
        //            if (Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList2 != null && Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList2.Count > 0)
        //            {
        //                foreach (HotelMaterial hm in Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList2)
        //                {
        //                    tempHotelPrice += hm.Price.Total;
        //                }
        //            }
        //            this.lbTotalPrice.Text = Decimal.Round(tempAirPrice + tempHotelPrice, 0).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
        //        }
        //        else
        //        {
        //            this.lbTotalPrice.Text = Decimal.Round(tempAirPrice, 0).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
        //        }


        //    }
        //    else
        //    {
        //        this.lbTotalPrice.Text = Decimal.Round(tempAirPrice, 0).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
        //    }
        //}
        //else
        //{
        //    return;
        //}
        //this.lbAvgPrice.Text = Decimal.Round(Convert.ToDecimal(lbTotalPrice.Text)/ (Convert.ToInt32(lbAdults.Text) + Convert.ToInt32(lbChilds.Text)), 0).ToString();
    }

}
