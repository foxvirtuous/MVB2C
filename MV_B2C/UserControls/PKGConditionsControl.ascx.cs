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
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;

namespace Terms.Web.UserControls
{
    public partial class PKGConditionsControl : SalesBaseUserControl
    {
        public PackageMerchandise packageMerchandise
        {
            get
            {
                return (PackageMerchandise)this.OnSearch();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSearchCondition();
            }
        }

        private void BindSearchCondition()
        {
            if (!this.IsSearchConditionNull)
            {
                if (this.Transaction.CurrentSearchConditions is PackageSearchCondition)
                {
                    PackageSearchCondition packageSearchCondition = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;
                    this.lblDeparture.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.City.Name + ", " + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.City.Country.Code + " (" + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.Code + ")";
                    this.lblDestination.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.City.Name + ", " + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.City.Country.Code + " (" + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.Code + ")";
                    this.lblDepDate.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].DepartureDate.ToString("MM/dd/yy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    this.lblReturnDate.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[1].DepartureDate.ToString("MM/dd/yy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    if (packageSearchCondition.HotelSearchCondition.RoomSearchConditions.Count > 0)
                    {
                        for (int i = 0; i < packageSearchCondition.HotelSearchCondition.RoomSearchConditions.Count; i++)
                        {
                            this.lblRoomAndPassengers.Text += Resources.Global.Room  +  " #" + (i + 1).ToString() + ": " + packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Adult].ToString() + " Adult(s)," + packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Child].ToString() + " Child(ren)" + "<br>";
                        }
                    }
                    //foreach (PackageMaterial pm in packageMerchandise.GetPackageMaterials(1))
                    //{
                    //    if (((MVHotel)pm.Hotels[0]).HotelId.ToString() == Request.QueryString["HotelID"])
                    //    {
                    //        this.lblHotelName.Text = ((MVHotel)pm.Hotels[0]).HotelInformation.Name;
                    //        return;
                    //    }
                    //}
                    //this.lblHotelName.Text = ((HotelOrderItem)((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items[1]).Profile.Name;
                }
            }
        }
    }
}