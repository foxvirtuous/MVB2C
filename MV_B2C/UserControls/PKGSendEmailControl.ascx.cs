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
using System.Collections.Generic;
using TERMS.Business.Centers.SalesCenter;

namespace Terms.Web.UserControls
{
    public partial class PKGSendEmailControl : SalesBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitSet();

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

        private void InitSet()
        {
            if (!IsSearchConditionNull)
            {
                PackageSearchCondition packageSearchCondition = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;
                lblDeparture.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.City.Name + ", " + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.City.Country.Code + " (" + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.Code + ")";
                lblTo.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.City.Name + ", " + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.City.Country.Code + " (" + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.Code + ")";
                if (packageSearchCondition.HotelSearchCondition.RoomSearchConditions.Count > 0)
                {
                    int adult = 0;
                    int child = 0;
                    int rooms = 0;
                    for (int i = 0; i < packageSearchCondition.HotelSearchCondition.RoomSearchConditions.Count; i++)
                    {
                        rooms++;
                        adult += packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Adult];
                        child += packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Child];
                    }
                    this.lblRoomAndPassengers.Text = rooms.ToString() + " room(s), " + adult.ToString() + " Adult(s), " + child.ToString() + " Child(ren)";
                }
                this.lblDateNow.Text = DateTime.Now.ToString("MM/dd/yyy hh:mm");
                this.lblMember.Text = Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.FirstName + " " + Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.MiddleName + " " + Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.LastName;
            }

            SetCondition();
        }

        public void BindValueToControls()
        {
            this.CreditCardEmailControl1.BindValueToControls();
        }


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


        private void SetCondition()
        {
            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                List<HotelOrderItem> hotelMaterial = new List<HotelOrderItem>();
                foreach (OrderItem orderItem in Utility.Transaction.CurrentTransactionObject.Items)
                {
                    for (int childItemCount = 0; childItemCount < orderItem.Items.Count; childItemCount++)
                    {
                        if (orderItem.Items[childItemCount] is HotelOrderItem)
                        {
                            hotelMaterial.Add((HotelOrderItem)orderItem.Items[childItemCount]);
                        }
                    }
                }

                HotelDetails = hotelMaterial;
            }
        }
    }
}