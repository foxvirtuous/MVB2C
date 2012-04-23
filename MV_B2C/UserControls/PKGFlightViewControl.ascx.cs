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
using TERMS.Common;
using System.Collections.Generic;
using TERMS.Business.Centers.ProductCenter.Components;

namespace Terms.Web.UserControls
{
    public partial class PKGFlightViewControl : SalesBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFlihtInfo();
            }
        }

        private void BindFlihtInfo()
        {
            if (!IsSearchConditionNull)
            {
                if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
                { 
                    PackageOrderItem packageOrderItem = (PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];
                    AirOrderItem airOrderItem = (AirOrderItem)packageOrderItem.Items[0];
                    this.dlFlight.DataSource = GetAirLegList(airOrderItem);
                    this.dlFlight.DataBind();
                }
            }
        }

        private object GetAirLegList(AirOrderItem airOrderItem)
        {
            IList<AirLeg> airLegList = new List<AirLeg>();

            foreach (SubAirTrip subAirTrip in airOrderItem.Merchandise.AirTrip.SubTrips)
            {
                foreach (AirLeg airLeg in subAirTrip.Flights)
                {
                    airLegList.Add(airLeg);
                }
            }

            return airLegList;
        }

        protected void dlFlight_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                AirLeg airLeg = (AirLeg)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));

                if (!string.IsNullOrEmpty(airLeg.OperatingAirlineInfo))
                {
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = true;
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Text = "Operated by: " + airLeg.OperatingAirlineInfo;

                    //if (flightInfohider.IsNeedToHide(airCode, fareType))
                    //{
                    //    ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = false;

                    //    System.Web.UI.WebControls.Image imgCodeShared = (System.Web.UI.WebControls.Image)e.Item.Parent.Parent.FindControl("imgCodeShared");

                    //    imgCodeShared.Visible = false;
                    //}
                }
                else
                {
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = false;
                }
            }
        }
    }
}