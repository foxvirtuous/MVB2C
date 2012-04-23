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


public partial class TravelerChange : Spring.Web.UI.UserControl
{
    private Object[] AdultName = new Object[4] { "ddlAdult1","ddlAdult2","ddlAdult3","ddlAdult4"};
    private Object[] ChildName = new Object[4] { "ddlChild1", "ddlChild2", "ddlChild3", "ddlChild4" };
    private int[] _adults;
    public int[] Adults
    {
        get
        {
            return SetAdultValue();
        }
    }

    private int[] _childs;
    public int[] Childs
    {
        get
        {
            return SetChildValue();
        }
    }
 
    public int Rooms
    {
        get
        {
            return Convert.ToInt32(dllRooms.SelectedValue) ;
        }
        set
        {
            dllRooms.SelectedIndex = dllRooms.Items.IndexOf(dllRooms.Items.FindByValue(value.ToString()));
        }
    }

    public int TotalAdults
    {
        get
        {
            int totalAdults = 0;
            foreach (int adult in Adults)
            {
                totalAdults += adult;
            }
            return totalAdults;
        }
    }

    public int TotalChilds
    {
        get
        {
            int totalChilds = 0;
            foreach (int child in Childs)
            {
                totalChilds += child;
            }
            return totalChilds;
        }
    }

    public string ControlName
    {
        get { return hdControlName.Value; }
        set { hdControlName.Value = value; }
    }
    
    public TravelerChange()
    {
        this.InitializeControls += new EventHandler(TravelerChange_InitializeControls);
    }

    void TravelerChange_InitializeControls(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
               // SetCondition();

                this.dllRooms.Attributes.Add("OnSelect", "javascript:ShowHidePassengers();");

                if (Utility.Transaction.CurrentSearchConditions != null)
                {
                    HotelSearchCondition hCondition = null;

                    if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
                    {
                        hCondition = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition;
                    }
                    else if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
                    {
                        hCondition =(HotelSearchCondition) Utility.Transaction.CurrentSearchConditions;
                    }
                }

                SetRoomsCondition();
            }
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }

    private int[] SetAdultValue()
    { 
        int[] Adults = new int[Rooms];
        int adult = 0;
        for (int i = 0; i < Rooms; i++)
        {
            Adults[i] = Convert.ToInt32(((DropDownList)this.FindControl(AdultName[i].ToString())).SelectedValue);
        }
        return Adults;
    }

    private int[] SetChildValue()
    {
        int[] Childs = new int[Rooms];
        int child = 0;
        for (int i = 0; i < Rooms; i++)
        {
            Childs[i] = Convert.ToInt32(((DropDownList)this.FindControl(ChildName[i].ToString())).SelectedValue);
        }
        return Childs;
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
                        System.Web.UI.HtmlControls.HtmlTable tab = (System.Web.UI.HtmlControls.HtmlTable)this.FindControl("tbRoom" + (i + 1).ToString());
                        tab.Style["display"] = "";
                    }

                    ((DropDownList)this.FindControl(AdultName[i].ToString())).SelectedIndex = ((DropDownList)this.FindControl(AdultName[i].ToString())).Items.IndexOf(((DropDownList)this.FindControl(AdultName[i].ToString())).Items.FindByValue((roomSearchCondition.Passengers[TERMS.Common.PassengerType.Adult]).ToString()));
                    ((DropDownList)this.FindControl(ChildName[i].ToString())).SelectedIndex = ((DropDownList)this.FindControl(AdultName[i].ToString())).Items.IndexOf(((DropDownList)this.FindControl(AdultName[i].ToString())).Items.FindByValue((roomSearchCondition.Passengers[TERMS.Common.PassengerType.Child] + 1).ToString()));
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
                        System.Web.UI.HtmlControls.HtmlTable tab = (System.Web.UI.HtmlControls.HtmlTable)this.FindControl("tbRoom" + (i + 1).ToString());
                        tab.Style["display"] = "";
                    }

                    ((DropDownList)this.FindControl(AdultName[i].ToString())).SelectedIndex = ((DropDownList)this.FindControl(AdultName[i].ToString())).Items.IndexOf(((DropDownList)this.FindControl(AdultName[i].ToString())).Items.FindByValue((roomSearchCondition.Passengers[TERMS.Common.PassengerType.Adult]).ToString()));
                    ((DropDownList)this.FindControl(ChildName[i].ToString())).SelectedIndex = ((DropDownList)this.FindControl(AdultName[i].ToString())).Items.IndexOf(((DropDownList)this.FindControl(AdultName[i].ToString())).Items.FindByValue((roomSearchCondition.Passengers[TERMS.Common.PassengerType.Child] + 1).ToString()));
                }
            }
        }
    }
   
}
