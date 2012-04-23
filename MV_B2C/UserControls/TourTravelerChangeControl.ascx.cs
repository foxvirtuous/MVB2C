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
using Spring.Context;
using Spring.Context.Support;
using Terms.Sales.Service;
using System.Collections.Generic;
using Terms.Common.Domain;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Profiles;

public partial class TourTravelerChangeControl : SalesBaseUserControl
{

    private Object[] AdultName = new Object[4] { "ddlAdult1", "ddlAdult2", "ddlAdult3", "ddlAdult4" };
    private Object[] ChildName = new Object[4] { "ddlChild1", "ddlChild2", "ddlChild3", "ddlChild4" };
    private object[] ChildWithOutName = new object[4] { "ddlChildWithOut1", "ddlChildWithOut2", "ddlChildWithOut3", "ddlChildWithOut4" };
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

    private int[] _childsWithOut;
    public int[] ChildsWithOut
    {
        get
        {
            return SetChildWithOutValue();
        }
    }

    private String[] _roomTypes;
    public String[] RoomTypes
    {
        get
        {
            return SetSelectedRoomTypeValue();
        }
    }

    public int Rooms
    {
        get
        {
            return Convert.ToInt32(dllRooms.SelectedValue);
        }
        set
        {
            dllRooms.SelectedIndex = dllRooms.Items.IndexOf(dllRooms.Items.FindByValue(value.ToString()));
        }
    }




    //public string DeptCity
    //{
    //    get
    //    {
    //        return ddlUsaCity.SelectedValue;
    //    }
    //    set
    //    {
    //        ddlUsaCity.SelectedIndex = ddlUsaCity.Items.IndexOf(ddlUsaCity.Items.FindByValue(value.ToString()));
    //    }
    //}

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

    public TourTravelerChangeControl()
    {
        this.InitializeControls += new EventHandler(TourTravelerChangeControl_InitializeControls);
        this.PreRender += new EventHandler(TourTravelerChangeControl_PreRender);
    }
    void TourTravelerChangeControl_PreRender(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Load", "<script language=javascript>ShowHidePassengers();</script>");

    }
    void TourTravelerChangeControl_InitializeControls(object sender, EventArgs e)
    {

        //if (!((TourSearchCondition)this.Transaction.CurrentSearchConditions).IsLandOnly)
        //{
        //    //this.tbDeptPlace.Visible = true;
        //    //IApplicationContext ctx = ContextRegistry.GetContext();


        //    //IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;
        //    //List<City> temp = applicationCacheFoundationDate.FindCityByCountry("US"); //只取美国城市

        //    //ddlUsaCity.DataSource = temp;
        //    //ddlUsaCity.DataTextField = "Name";
        //    //ddlUsaCity.DataValueField = "Code";
        //    //ddlUsaCity.DataBind();
        //}

    }

    public void InitCheck(TourMerchandise tourMerchandise, DateTime date)
    {
        TourProfile tourProfile = (TourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile;
        decimal ChildWithOutPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[0], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Infant);
        if (ChildWithOutPrice == null || ChildWithOutPrice == 0M)
        {
            this.ddlChildWithOut1.Enabled = false;
            this.ddlChildWithOut2.Enabled = false;
            this.ddlChildWithOut3.Enabled = false;
            this.ddlChildWithOut4.Enabled = false;
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

    private int[] SetChildWithOutValue()
    {
        int[] WithOutChilds = new int[Rooms];
        int child = 0;
        for (int i = 0; i < Rooms; i++)
        {
            WithOutChilds[i] = Convert.ToInt32(((DropDownList)this.FindControl(ChildWithOutName[i].ToString())).SelectedValue);
        }
        return WithOutChilds;
    }

    private String[] SetSelectedRoomTypeValue()
    {
        String[] SelectedRoomTypes = new String[Rooms];
        for (int i = 1; i <= Rooms; i++)
        {
            DropDownList ddlRoomType = (DropDownList)this.FindControl("ddlRoomType" + i.ToString());
            SelectedRoomTypes[i - 1] = ddlRoomType.SelectedValue;
        }
        return SelectedRoomTypes;
    }
    public Hashtable RoomTypeAndRoomNumber()
    {
        Hashtable hTRoomType = new Hashtable();
        for (int i = 0; i < Rooms; i++)
        {
            if (hTRoomType.ContainsKey(RoomTypes[i]))
            {
                hTRoomType[RoomTypes[i]] = Convert.ToInt32(hTRoomType[RoomTypes[i]]) + 1;
            }
            else
            {
                hTRoomType.Add(RoomTypes[i], 1);
            }
        }
        return hTRoomType;
    }
    public Hashtable RoomTypeAndPersonNumber(TERMS.Common.PassengerType type)
    {
        Hashtable hTRoomType = new Hashtable();

        switch (type.ToString().ToUpper())
        {
            case "ADULT":
                for (int i = 0; i < Rooms; i++)
                {
                    if (hTRoomType.ContainsKey(RoomTypes[i]))
                        hTRoomType[RoomTypes[i]] = Convert.ToInt32(hTRoomType[RoomTypes[i]]) + Adults[i];
                    else
                    {
                        if (Adults[i] > 0)
                            hTRoomType.Add(RoomTypes[i], Adults[i]);
                    }
                }
                break;
            case "CHILD":

                for (int i = 0; i < Rooms; i++)
                {
                    if (hTRoomType.ContainsKey(RoomTypes[i]))
                        hTRoomType[RoomTypes[i]] = Convert.ToInt32(hTRoomType[RoomTypes[i]]) + Childs[i];
                    else
                    {

                        if (Childs[i] > 0)
                            hTRoomType.Add(RoomTypes[i], Childs[i]);
                    }

                }
                break;
            case "INFANT":
                for (int i = 0; i < Rooms; i++)
                {
                    if (hTRoomType.ContainsKey(RoomTypes[i]))
                        hTRoomType[RoomTypes[i]] = Convert.ToInt32(hTRoomType[RoomTypes[i]]) + ChildsWithOut[i];
                    else
                    {

                        if (Childs[i] > 0)
                            hTRoomType.Add(RoomTypes[i], ChildsWithOut[i]);
                    }

                }
                break;

        }

        return hTRoomType;
    }


    public void SetRoomTypes(IList<String> types, string defualtType)
    {
        for (int i = 1; i <= 4; i++)
        {
            DropDownList ddlRoomType = (DropDownList)this.FindControl("ddlRoomType" + i.ToString());
            ddlRoomType.Items.Clear();
            for (int j = 0; j < types.Count; j++)
            {
                ddlRoomType.Items.Add(new ListItem(types[j], types[j]));
                if (defualtType.Equals(types[j]))
                    ddlRoomType.Items[j].Selected = true;
                
            }
        }
    }
    public List<TourRoom> GetTourRooms(TourProfile tourProfile ,DateTime date)
    {
        List<TourRoom> tourRooms = new List<TourRoom>();
        for (int i = 0; i < Rooms; i++)
        {
            if (Adults[i] > 0)
            {
                TourRoom tourRoom = new TourRoom();
                tourRoom.RoomIndex = i + 1;
                tourRoom.PassengerType = TERMS.Common.PassengerType.Adult;
                tourRoom.Quantity = Adults[i];
                tourRoom.RoomType = RoomTypes[i];
                tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Adult)
                    + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Adult);              
                tourRooms.Add(tourRoom);
            }
            if (Childs[i] > 0)
            {
                TourRoom tourRoom = new TourRoom();
                tourRoom.RoomIndex = i + 1;
                tourRoom.PassengerType = TERMS.Common.PassengerType.Child;
                tourRoom.Quantity = Childs[i];
                tourRoom.RoomType = RoomTypes[i];
                tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Child)
                   + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Child);
                if (tourRoom.UnitPrice == null || tourRoom.UnitPrice == 0M)
                    tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Adult)
                    + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Adult);
                tourRooms.Add(tourRoom);
            }
            if (ChildsWithOut[i] > 0)
            {
                TourRoom tourRoom = new TourRoom();
                tourRoom.RoomIndex = i + 1;
                tourRoom.PassengerType = TERMS.Common.PassengerType.Infant;
                tourRoom.Quantity = ChildsWithOut[i];
                tourRoom.RoomType = RoomTypes[i];
                tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Infant)
                   + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Infant);
                if(tourRoom.UnitPrice == null || tourRoom.UnitPrice == 0M)
                    tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Adult)
                    + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Adult);
                tourRooms.Add(tourRoom);
            }
        }
        return tourRooms;
    }
    
}
