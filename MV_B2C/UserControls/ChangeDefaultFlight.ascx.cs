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
using Terms.Material.Domain;
using Terms.Common.Domain;

using System.Globalization;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Common;
public partial class ChangeDefaultFlight : Spring.Web.UI.UserControl
{
   
    private IList<AirMaterial> _FlightDetails;
    public IList<AirMaterial> FlightDetails
    {
        set
        {
            if (value is List<AirMaterial>)
            {
                this.dlAirGroup.DataSource = value;

                dlAirGroup.DataBind();
            }
            _FlightDetails = value;
        }
        get
        {
            if (_FlightDetails == null)
            {
                _FlightDetails = new List<AirMaterial>();
            }

            return _FlightDetails;
        }
    }

    public ChangeDefaultFlight()
    {
        this.InitializeControls += new EventHandler(ChangeDefaultFlight_InitializeControls);
    }

    private void ChangeDefaultFlight_InitializeControls(object sender, EventArgs e)
    {
        
    }

    protected void dlSubTrips_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbDeptOrRtn = (Label)e.Item.FindControl("lbDeptOrRtn");
            Label lbDepartureDate = (Label)e.Item.FindControl("lbDepartureDate");

            if (e.Item.ItemIndex == 0)
                lbDeptOrRtn.Text = "Departure";

            else
                lbDeptOrRtn.Text = "Return";

            lbDepartureDate.Text = ((SubAirTrip)e.Item.DataItem).Flights[0].DepartureTime.ToString("MMM dd,yyyy", DateTimeFormatInfo.InvariantInfo);

           

        }
        
    }
    protected void dlFlights_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            AirLeg airLeg = (AirLeg)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("AirImgRtn");
            image.ImageUrl = "~/images/airline/defult_air.jpg";
            string airImgName = airLeg.AirLine.Code.Trim().ToString() + ".gif";

            if (System.IO.File.Exists(Request.PhysicalApplicationPath + @"images\airline\" + airImgName))
            {
                image.ImageUrl = "~/images/airline/" + airImgName;
            }
        }
    }
}
