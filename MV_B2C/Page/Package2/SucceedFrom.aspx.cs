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
using System.Text.RegularExpressions;
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;

public partial class SucceedFrom : SalseBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (this.IsSearchConditionNull)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The search condition has been removed from cache, please re-search.&&GoToPage=~/Page/Common/CreditCardInfoForm.aspx");
        }
        else
        {
            this.NavigationControl1.PageCode = 4;
            if (!IsPostBack)
            {
                InitSet();
                this.lblOrderNumber.Text = this.Request["CaseNumber"];
                this.lblPNR.Text = this.Request["RcordLocator"];
                this.lblDateNow.Text = DateTime.Now.ToString("MM/dd/yyy hh:mm");

                if (Utility.IsSubAgent)
                {
                    string Handler;

                    if (Utility.Transaction.Member.Handler == null || Utility.Transaction.Member.Handler.Trim().Length == 0)
                    {
                        Handler = "DEFAULT";
                    }
                    else
                    {
                        Handler = Utility.Transaction.Member.Handler;
                    }

                    List<Terms.Member.Utility.HandlerReceiver> Citys = Terms.Member.Utility.MemberUtility.GetHandlerReciever();

                    for (int i = 0; i < Citys.Count; i++)
                    {
                        if (Citys[i].Name.Trim().ToUpper() == Handler.Trim().ToUpper())
                        {
                            lblSalesName.Text = Citys[i].SalesName.Replace(",", " or ");
                            lblSalesEmail.Text = @"<a href='#' class='d07'>" + Citys[i].SalesEmail.Replace(",", @"</a> or <a href='#' class='d07'>") + @"</a>";
                        }
                    }
                }
                else
                {
                    lblSalesName.Text = "Kevin Piao, Tina You or Afra Wang";
                    lblSalesEmail.Text = @"<a href='#'>kpiao@majestic-vacations.com</a>, <a href='#'>tyou@majestic-vacations.com</a>, <a href='#'>awang@majestic-vacations.com</a>";
                }
            }
        }
    }

    private void InitSet()
    {
        if (!IsSearchConditionNull)
        {
            if (this.Transaction.CurrentTransactionObject != null && this.Transaction.CurrentTransactionObject.Items.Count > 0)
            {
                List<AirMaterial> FlightDetails = new List<AirMaterial>();
                FlightDetails.Add(((AirOrderItem)((PackageOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).Items[0]).Merchandise);
                this.PKGSelectedFlightControl1.FlightDetails = FlightDetails;
            }

            PackageSearchCondition packageSearchCondition = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;
            lblFrom.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.City.Name + ", " + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.City.Country.Code + " (" + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.Code + ")";
            lblTo.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.City.Name + ", " + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.City.Country.Code + " (" + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.Code + ")";
            lblDepartDate.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].DepartureDate.ToString("MM/dd/yy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            lblReturnDate.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[1].DepartureDate.ToString("MM/dd/yy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            if (packageSearchCondition.HotelSearchCondition.RoomSearchConditions.Count > 0)
            {
                for (int i = 0; i < packageSearchCondition.HotelSearchCondition.RoomSearchConditions.Count; i++)
                {
                    this.lblRoomsAndPassengers.Text += "Room #" + (i + 1).ToString() + ": " + packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Adult].ToString() + " Adult(s), " + packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Child].ToString() + " Child(ren)" + "<br>";
                }
            }
            this.CreditCardEmailControl1.BindValueToControls();
        }
    }

    protected void btnBackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index.aspx");
    }
}
