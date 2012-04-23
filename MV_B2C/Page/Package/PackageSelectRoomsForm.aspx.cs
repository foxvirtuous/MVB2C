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
using Terms.Sales.Domain;
using Terms.Sales.Utility;
using System.Globalization;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;

public partial class PackageSelectRoomsForm : SalseBasePage
{
    private int m_parentIndex = 0;

    public int ParentIndex
    {
        get
        {
            return m_parentIndex;
        }
        set
        {
            m_parentIndex = value;
        }
    }

    private int m_HotelListIndex = 0;

    public int HotelListIndex
    {
        get
        {
            return m_HotelListIndex;
        }
        set
        {
            m_HotelListIndex = value;
        }
    }


    private int m_sonIndex = 0;

    public int SonIndex
    {
        get
        {
            return m_sonIndex;
        }
        set
        {
            m_sonIndex = value;
        }
    }

    public PackageMerchandise packageMerchandise
    {
        get
        {
            return (PackageMerchandise)this.OnSearch();
        }
    }

    public PackageSelectRoomsForm()
    {
        this.InitializeControls += new EventHandler(PackageSelectRoomsForm_InitializeControls);
    }

    void PackageSelectRoomsForm_InitializeControls(object sender, EventArgs e)
    {
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (Request.QueryString["HotelIndex"] != null)
        {
            Session["HotelIndex"] = Request.QueryString["HotelIndex"];
            HotelListIndex = Convert.ToInt32(Session["HotelIndex"].ToString());
            //if (Request.QueryString["Edit"] != null)
            //{
            //    try
            //    {
            //        HotelSearchCondition hotelSearchCondition = null;
            //        if (HotelListIndex == 0)
            //            hotelSearchCondition = (HotelSearchCondition)((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition;
            //        else
            //            hotelSearchCondition = (HotelSearchCondition)((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).OptionalHotelSearchConditions[HotelListIndex - 1];
            //        String hotelCode = ((MVHotel)packageMerchandise.DefaultMerchandise[1 + HotelListIndex]).HotelInformation.HotelCode;
            //        DeleteBeingChangedHotelOrderItem(hotelCode, hotelSearchCondition.CheckIn.ToString());
            //    }
            //    catch (Exception Ex)
            //    {
            //        throw new Exception(Ex.Message);
            //    }
            //}
        }
        this.HotelCommonInfoControl1.HotelListIndex = HotelListIndex;
        if (Request.QueryString["PostBack"] != null)
        {
            BinderData();
            List<PackageMaterial> MVHotelList = packageMerchandise.GetPackageMaterials(1 + HotelListIndex);
            this.FlightHeader1.TotalPrice = ((PackageMaterial)MVHotelList[((List<int>)packageMerchandise.DefaultIndex[1 + HotelListIndex])[0]]).TotalPrice;

            this.FlightHeader1.BindDate();

            List<AirMaterial> airMaterialList = new List<AirMaterial>();
            airMaterialList.Add((AirMaterial)packageMerchandise.DefaultMerchandise[0]);
            this.DefaultFlightDetails1.FlightDetails = airMaterialList;
        }
        else
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PictureIndex"] == null)
                    CurrentTab.Value = "Room Types";

                if (Request.QueryString["TableName"] != null)
                    CurrentTab.Value = Request.QueryString["TableName"];
                else
                    CurrentTab.Value = "Room Types";
                Navigation1.PageCode = 2;
                InitSet();
                SearchAndBind();
                List<PackageMaterial> MVHotelList = packageMerchandise.GetPackageMaterials(1 + HotelListIndex);
                this.FlightHeader1.TotalPrice = ((PackageMaterial)MVHotelList[((List<int>)packageMerchandise.DefaultIndex[1 + HotelListIndex])[0]]).TotalPrice;

                this.FlightHeader1.BindDate();
            }
        }
        
        if (Request.QueryString["ParentIndex"] != null)
            ParentIndex = Convert.ToInt32(Request.QueryString["ParentIndex"]);
        if (Request.QueryString["SonIndex"] != null)
            SonIndex = Convert.ToInt32(Request.QueryString["SonIndex"]);
        this.DefaultFlightDetails1.URL = "PackageSelectRoomsForm.aspx";
        this.DefaultFlightDetails1.IsSelectHotel = false;
        this.FlightHeader1.FlagCode = 1;
        this.FlightHeader1.SubIndex = 1;
        //ChangeTravelers1.ReturnURL = "PackageSelectRoomsForm.aspx";
        this.HotelCommonInfoControl1.PgMerchandise = packageMerchandise;

    }

    private void BinderData()
    {
        if (packageMerchandise.DefaultMerchandise[1 + HotelListIndex] != null)
        {
            foreach (Hotel obj in (List<Hotel>)packageMerchandise.DefaultMerchandise[HotelListIndex + 1])
            {
                HotelCommonInfoControl1.HotelListIndex = HotelListIndex;
                HotelCommonInfoControl1.HotelMaterial = (MVHotel)obj;

                return;

            }
        }

    }

    private void InitSet()
    {
        this.HotelCommonInfoControl1.ProductType = Terms.Base.Utility.ProductType.Package;
        
        PackageSearchCondition pakcageSearch = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;
        this.PackageLeftSelect1.From = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].Departure.City.Name;
        this.PackageLeftSelect1.To = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].Destination.City.Name;
        this.PackageLeftSelect1.DepartureDate = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].DepartureDate;
        this.PackageLeftSelect1.ReturnDate = pakcageSearch.AirSearchCondition.GetAddTripCondition()[1].DepartureDate;
        this.PackageLeftSelect1.CheckInDate = pakcageSearch.HotelSearchCondition.CheckIn;
        this.PackageLeftSelect1.CheckOutDate = pakcageSearch.HotelSearchCondition.CheckOut;
    }

    private void SearchAndBind()
    {


        List<AirMaterial> airMaterialList = new List<AirMaterial>();
        airMaterialList.Add((AirMaterial)packageMerchandise.DefaultMerchandise[0]);
        this.DefaultFlightDetails1.FlightDetails = airMaterialList;
        if (packageMerchandise.DefaultMerchandise.Length > 1)
        {
            //List<HotelMaterial> hotelMaterial = new List<HotelMaterial>();

            foreach (Hotel obj in ((List<Hotel>)packageMerchandise.DefaultMerchandise[HotelListIndex + 1]))
            {
                //if (((HotelMaterial)m_SaleMerchandise.MaterialList[i]).Hotel.Id.ToString().Trim() == this.Request["HotelID"].Trim())
                //{
                //if (Utility.Transaction.CurrentTransactionObject.Items != null)
                //{
                //    if (Utility.Transaction.CurrentTransactionObject.Items.Count == 0)
                //    {
                //        SaleMerchandise saleMerchandise = new SaleMerchandise();
                //        saleMerchandise.MaterialList.Add(m_SaleMerchandise.MaterialList[i]);
                //        OrderMerchandise newOrderMerchandise = new OrderMerchandise(saleMerchandise);
                //        Utility.Transaction.CurrentTransactionObject.Items.Add(newOrderMerchandise);
                //    }
                //    else
                //    {
                //        if (this.Request["Condition"] == null)
                //        {
                //            Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Add(m_SaleMerchandise.MaterialList[i]);
                //        }
                //    }
                //}
                //else
                //{
                //    SaleMerchandise saleMerchandise = new SaleMerchandise();
                //    saleMerchandise.MaterialList.Add(m_SaleMerchandise.MaterialList[i]);
                //    OrderMerchandise newOrderMerchandise = new OrderMerchandise(saleMerchandise);
                //    Utility.Transaction.CurrentTransactionObject.Items.Add(newOrderMerchandise);
                //}
                HotelCommonInfoControl1.HotelListIndex = HotelListIndex;
                HotelCommonInfoControl1.HotelMaterial = (MVHotel)obj;
                lbHotelName.Text = obj.HotelInformation.Name;
                return;
                //}
            }
        }
        else
        {
            //this.Response.Redirect("HotelSeachForm.aspx");
        }

    }

    private void DeleteBeingChangedHotelOrderItem(string hotelCode, string strCheckin)
    {
        //删除Change的Room Type
        for (int i = ((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items.Count - 1; i > 0; i--)
        {
            HotelOrderItem hotelOrderItem = (HotelOrderItem)((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items[i];

            if ((hotelOrderItem.CheckIn == Convert.ToDateTime(strCheckin)) && (hotelOrderItem.Room.Hotel.HotelCode.Trim() == hotelCode.Trim()))
                ((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items.Remove(hotelOrderItem);
        }
    }
}
