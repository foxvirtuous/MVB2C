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
using Terms.Sales.Business;

public partial class ChangeTravelersControl : Spring.Web.UI.UserControl
{
    public string ReturnURL
    {
        set
        {
            hlChangebtn.NavigateUrl += "?Returnurl=" + value + "&ConditionID=" + Request.Params["ConditionID"];
        }
    }

    public ChangeTravelersControl()
    {
        this.InitializeControls +=new EventHandler(ChangeTravelersControl_InitializeControls);
    }

    void ChangeTravelersControl_InitializeControls(object sender, EventArgs e)
    {
        if (!Utility.IsSearchConditionNull)
        {
            Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

            int Adult = 0;
            int Child = 0;

            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                PackageSearchCondition packageSearchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;

                HotelSearchCondition hotelSearchCondition = packageSearchCondition.HotelSearchCondition;

                foreach (RoomSearchCondition roomSearchCondition in hotelSearchCondition.RoomSearchConditions)
                {
                    int tempAdult = 0;
                    int tempChild = 0;

                    tempAdult = roomSearchCondition.Passengers[TERMS.Common.PassengerType.Adult];
                    Adult += tempAdult;

                    tempChild = roomSearchCondition.Passengers[TERMS.Common.PassengerType.Child];
                    Child += tempChild;
                }

                lblAdultNumber.Text = Adult.ToString();

                lblChildNumber.Text = Child.ToString();

                lblRooms.Text = hotelSearchCondition.RoomSearchConditions.Count.ToString();
            }
            else
            {
                HotelSearchCondition hotelSearchCondition = (HotelSearchCondition)Utility.Transaction.CurrentSearchConditions;

                foreach (RoomSearchCondition roomSearchCondition in hotelSearchCondition.RoomSearchConditions)
                {
                    int tempAdult = 0;
                    int tempChild = 0;

                    tempAdult = roomSearchCondition.Passengers[TERMS.Common.PassengerType.Adult];
                    Adult += tempAdult;

                    tempChild = roomSearchCondition.Passengers[TERMS.Common.PassengerType.Child];
                    Child += tempChild;
                }

                lblAdultNumber.Text = Adult.ToString();
                lblChildNumber.Text = Child.ToString();
                lblRooms.Text = hotelSearchCondition.RoomSearchConditions.Count.ToString();
            }
        }
    }
}
