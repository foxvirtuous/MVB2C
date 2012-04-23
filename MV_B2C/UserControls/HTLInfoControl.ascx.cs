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

using Terms.Common.Service;
using Terms.Common.Dao;
using Terms.Common.Domain;
using Terms.Product.Domain;
using Terms.Sales.Business;
using TERMS.Common;
using TERMS.Business.Centers.SalesCenter;


public partial class HTLInfoControl : Spring.Web.UI.UserControl
{
    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }


    public HTLInfoControl()
    {
        this.InitializeControls += new EventHandler(HTLInfoControl_InitializeControls);
    }

    void HTLInfoControl_InitializeControls(object sender, EventArgs e)
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {
            divReturn.Visible = true;
        }
        else
        {
            divReturn.Visible = false;
        }
        if (!Utility.IsSearchConditionNull)
        {
            DateTime checkin;
            DateTime checkout;

            if (this.Request["HotelName"] != null && this.Request["HotelName"].ToString() != "")
            {
                lblHotelName.Text = this.Request["HotelName"] + ", ";
            }
            else
            {
                lblHotelName.Text = "";
            }

            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                checkin = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn;
                checkout = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut;

                lblCheckIn.Text = checkin.ToString("MM/dd/yyyy");
                lblCheckOut.Text = checkout.ToString("MM/dd/yyyy");
                lblCheckIn.Visible = true;
                lblCheckOut.Visible = true;

                lblDayNumber.Text = ((TimeSpan)checkout.Subtract(checkin)).Days.ToString();

                this.lblCityName.Text = _CommonService.FindCityByCityCode(((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).Location).Name;


                int iCount = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count;

                for (int i = 0; i < iCount; i++)
                {
                    int iAdult = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[i].Passengers[PassengerType.Adult];
                    int iChild = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[i].Passengers[PassengerType.Child];

                    if (iAdult > 0)
                    {
                        lblRooms.Text += Resources.Global.Room + " #" + (i + 1).ToString() + " : " + iAdult.ToString() + " " + Resources.Global.Adult1;

                        if (iChild > 0)
                        {
                            lblRooms.Text += ", " + iChild.ToString() + " " + Resources.Global.Chlid1;
                        }
                    }
                    else
                    {
                        if (iChild > 0)
                        {
                            lblRooms.Text = Resources.Global.Room + " #" + (i + 1).ToString() + " : " + iChild.ToString() + " " + Resources.Global.Chlid1;
                        }
                    }
                    if (i != (iCount - 1))
                    {
                        lblRooms.Text += "<BR/>";
                    }
                }

                lblRooms.Visible = true;
            }

            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                checkin = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn;
                checkout = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut;

                lblDayNumber.Text = ((TimeSpan)checkout.Subtract(checkin)).Days.ToString();

                this.lblCityName.Text = _CommonService.FindCityByCityCode(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.Location).Name;

                int iCount = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.RoomSearchConditions.Count;

                for (int i = 0; i < iCount; i++)
                {
                    int iAdult = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.RoomSearchConditions[i].Passengers[PassengerType.Adult];
                    int iChild = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.RoomSearchConditions[i].Passengers[PassengerType.Child];

                    if (iAdult > 0)
                    {
                        lblRooms.Text += Resources.Global.Room + " #" + (i + 1).ToString() + " : " + iAdult.ToString() + " " + Resources.Global.Adult1;

                        if (iChild > 0)
                        {
                            lblRooms.Text += ", " + iChild.ToString() + " " + Resources.Global.Chlid1;
                        }
                    }
                    else
                    {
                        if (iChild > 0)
                        {
                            lblRooms.Text = Resources.Global.Room + " #" + (i + 1).ToString() + " : " + iChild.ToString() + " " + Resources.Global.Chlid1;
                        }
                    }
                    if (i != (iCount - 1))
                    {
                        lblRooms.Text += "<BR/>";
                    }
                }

                lblRooms.Visible = true;
            }

            if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
            {
                if (((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition().Count == 1)
                {
                    checkin = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].DepartureDate;
                    checkout = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].DepartureDate;
                }
                else
                {
                    checkin = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].DepartureDate;
                    checkout = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[1].DepartureDate;
                }

                lblDayNumber.Text = ((TimeSpan)checkout.Subtract(checkin)).Days.ToString();

                this.lblCityName.Text = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].Departure.City.Name;

                this.lblCityName.Text += "," + ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].Destination.City.Name;

                lblRooms.Visible = false;
            }
        }
    }
}
