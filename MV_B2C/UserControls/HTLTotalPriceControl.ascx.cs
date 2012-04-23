using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using TERMS.Common;


public partial class HTLTotalPriceControl : Spring.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<HotelOrderItem> listHotel = new List<HotelOrderItem>();

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                listHotel.Add((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]);
            }

            rptRooms.DataSource = listHotel;
            rptRooms.DataBind();

            lblHotelName.Text = ((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Room.Hotel.Name;
            lblCheckIn.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.ToString("MM/dd/yyyy");
            lblCheckOut.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.ToString("MM/dd/yyyy");

            decimal decSum = 0M;

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                decSum += ((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).TotalPrice;
            }

            if (Utility.IsSubAgent)
            {
                decimal decMArkup = Utility.Transaction.CurrentTransactionObject.SubagentMarkup.GetTotalMarkup(PassengerType.Adult);

                if (decMArkup > 0M)
                {
                    divMarkup.Visible = true;
                    decSum += decMArkup;
                    lblMArkup.Text = decMArkup.ToString("N2");
                }
                else
                {
                    divMarkup.Visible = false;
                }
            }
            else
            {
                divMarkup.Visible = false;
            }

            lblTotalPrice.Text = decSum.ToString("N2");
        }

    }
}
