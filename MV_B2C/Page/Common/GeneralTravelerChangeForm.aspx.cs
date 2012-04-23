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

using log4net;
using Spring.Web.UI;
using Terms.Sales.Business;
using TERMS.Common;

public partial class GeneralTravelerChangeForm : SalseBasePage
{
    private Object[] AdultName = new Object[4] { "ddlAdult1", "ddlAdult2", "ddlAdult3", "ddlAdult4" };
    private Object[] ChildName = new Object[4] { "ddlChild1", "ddlChild2", "ddlChild3", "ddlChild4" };

    public GeneralTravelerChangeForm()
    {
        this.InitializeControls += new EventHandler(GeneralTravelerChangeForm_InitializeControls);
    }

    void GeneralTravelerChangeForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        SetRoomsCondition();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (!Utility.IsSearchConditionNull)
        {
            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                HotelSearchCondition hotelSearchCondition = (HotelSearchCondition)Utility.Transaction.CurrentSearchConditions;

                hotelSearchCondition.RoomSearchConditions.Clear();

                for (int i = 0; i < Convert.ToInt32(dllRooms.SelectedValue); i++)
                {
                    RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

                    roomSearchCondition.Passengers.Add(PassengerType.Adult, Convert.ToInt32(((DropDownList)this.FindControl(AdultName[i].ToString())).SelectedValue));
                    roomSearchCondition.Passengers.Add(PassengerType.Child, Convert.ToInt32(((DropDownList)this.FindControl(ChildName[i].ToString())).SelectedValue));

                    hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
                }

                Utility.Transaction.CurrentSearchConditions = hotelSearchCondition;
                Utility.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

                if (this.Request["Returnurl"] == null)
                {
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Hotel/HotelSelectForm");
                }
                else
                {
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?target=" + this.Request["returnurl"].Replace(".aspx", ""));
                }
            }
            else
            {
                HotelSearchCondition hotelSearchCondition = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition;

                hotelSearchCondition.RoomSearchConditions.Clear();

                int iAdult = 0;
                int iChild = 0;

                for (int i = 0; i < Convert.ToInt32(dllRooms.SelectedValue); i++)
                {
                    RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

                    roomSearchCondition.Passengers.Add(PassengerType.Adult, Convert.ToInt32(((DropDownList)this.FindControl(AdultName[i].ToString())).SelectedValue));
                    roomSearchCondition.Passengers.Add(PassengerType.Child, Convert.ToInt32(((DropDownList)this.FindControl(ChildName[i].ToString())).SelectedValue));
                    iAdult += Convert.ToInt32(((DropDownList)this.FindControl(AdultName[i].ToString())).SelectedValue);
                    iChild += Convert.ToInt32(((DropDownList)this.FindControl(ChildName[i].ToString())).SelectedValue);
                    hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
                }

                ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition = hotelSearchCondition;
                Utility.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

                AirSearchCondition airSearchCondition = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition;

                airSearchCondition.SetPassengerNumber(PassengerType.Adult, iAdult);
                airSearchCondition.SetPassengerNumber(PassengerType.Child, iChild);

                ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition = airSearchCondition;
                ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition = hotelSearchCondition;

                if (this.Request["Returnurl"] == null)
                {
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package2/ViewYourPackages" + "&ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package/" + this.Request["returnurl"].Replace(".aspx", "") + "&ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
            }
        }
        else
        {
            this.Response.Redirect("~/Index.aspx");
        }


    }

    public void SetRoomsCondition()
    {
        if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            if (((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.RoomSearchConditions != null ||
               ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.RoomSearchConditions.Count > 0)
            {
                dllRooms.SelectedIndex = dllRooms.Items.IndexOf(dllRooms.Items.FindByValue(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.RoomSearchConditions.Count.ToString()));

                for (int i = 0; i < ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.RoomSearchConditions.Count; i++)
                {
                    RoomSearchCondition roomSearchCondition = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.RoomSearchConditions[i];

                    if (i > 0)
                    {
                        System.Web.UI.HtmlControls.HtmlTable tab = (System.Web.UI.HtmlControls.HtmlTable)this.FindControl("div" + (i + 1).ToString());
                        tab.Style["display"] = "";
                    }

                    ((DropDownList)this.FindControl(AdultName[i].ToString())).SelectedIndex = ((DropDownList)this.FindControl(AdultName[i].ToString())).Items.IndexOf(((DropDownList)this.FindControl(AdultName[i].ToString())).Items.FindByValue((roomSearchCondition.Passengers[PassengerType.Adult]).ToString()));
                    ((DropDownList)this.FindControl(ChildName[i].ToString())).SelectedIndex = ((DropDownList)this.FindControl(AdultName[i].ToString())).Items.IndexOf(((DropDownList)this.FindControl(AdultName[i].ToString())).Items.FindByValue((roomSearchCondition.Passengers[PassengerType.Child] + 1).ToString()));
                }
            }
        }

        if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            if (((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions != null ||
               ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count > 0)
            {
                dllRooms.SelectedIndex = dllRooms.Items.IndexOf(dllRooms.Items.FindByValue(((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count.ToString()));

                for (int i = 0; i < ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count; i++)
                {
                    RoomSearchCondition roomSearchCondition = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[i];

                    if (i > 0)
                    {
                        System.Web.UI.HtmlControls.HtmlTable tab = (System.Web.UI.HtmlControls.HtmlTable)this.FindControl("div" + (i + 1).ToString());
                        tab.Style["display"] = "";
                    }

                    ((DropDownList)this.FindControl(AdultName[i].ToString())).SelectedIndex = ((DropDownList)this.FindControl(AdultName[i].ToString())).Items.IndexOf(((DropDownList)this.FindControl(AdultName[i].ToString())).Items.FindByValue((roomSearchCondition.Passengers[PassengerType.Adult]).ToString()));
                    ((DropDownList)this.FindControl(ChildName[i].ToString())).SelectedIndex = ((DropDownList)this.FindControl(AdultName[i].ToString())).Items.IndexOf(((DropDownList)this.FindControl(AdultName[i].ToString())).Items.FindByValue((roomSearchCondition.Passengers[PassengerType.Child] + 1).ToString()));
                }
            }
        }
    }
}
