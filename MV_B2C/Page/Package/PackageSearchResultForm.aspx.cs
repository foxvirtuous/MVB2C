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
using Terms.Sales.Dao;
using Terms.Sales.Service;
using Terms.Sales.Domain;
using Terms.Sales.Utility;


using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;

public partial class PackageSearchResultForm : SalseBasePage
{
    private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(typeof(PackageSearchResultForm));

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


    public PackageMerchandise packageMerchandise
    {
        get
        {
            return (PackageMerchandise)this.OnSearch();
        }
    }

    public PackageSearchResultForm()
    {
        this.InitializeControls += new EventHandler(PackageSearchResultForm_InitializeControls);
    }

    private void PackageSearchResultForm_InitializeControls(object sender, EventArgs e)
    {
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (Request.QueryString["HotelIndex"] != null)
        {
            HotelListIndex = Convert.ToInt32(Request.QueryString["HotelIndex"].ToString());
        }

        if (Request.QueryString["ParentIndex"] != null)
            ParentIndex = Convert.ToInt32(Request.QueryString["ParentIndex"]);
        if (Request.QueryString["SonIndex"] != null)
            SonIndex = Convert.ToInt32(Request.QueryString["SonIndex"]);
        ChangeTravelers1.ReturnURL = "PackageSearchResultForm.aspx";
        Navigation1.PageCode = 1;
        this.FlightHeader2.FlagCode = 1;
        this.FlightHeader2.SubIndex = 0;

        this.ShowPackageHotelDetails1.HotelListIndex = HotelListIndex;
        this.ShowPackageHotelDetails1.PgMerchandise = packageMerchandise;
        this.DefaultFlightDetails1.Index = SonIndex;
        this.DefaultFlightDetails1.URL = "PackageSearchResultForm.aspx";
        this.DefaultFlightDetails1.IsSelectHotel = false;
        try
        {
            if (!IsPostBack)
            {

                InitSet();

                this.FlightHeader2.BindDate();
            }

            SearchToBinder();
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }

        Utility.Transaction.Difference.To = "Page List";
        Utility.Transaction.Difference.ToTime = DateTime.Now;
        Utility.Transaction.Difference.EndTime = DateTime.Now;

        if (!IsPostBack)
        {
            log.Debug(Utility.Transaction.Difference.DiffList);
        }
    }

    private void InitSet()
    {
        PackageSearchCondition pakcageSearch = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;
        this.PackageLeftSelect1.From = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].Departure.City.Name;
        this.PackageLeftSelect1.To = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].Destination.City.Name;
        this.PackageLeftSelect1.DepartureDate = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].DepartureDate;
        this.PackageLeftSelect1.ReturnDate = pakcageSearch.AirSearchCondition.GetAddTripCondition()[1].DepartureDate;
        this.PackageLeftSelect1.CheckInDate = pakcageSearch.HotelSearchCondition.CheckIn;
        this.PackageLeftSelect1.CheckOutDate = pakcageSearch.HotelSearchCondition.CheckOut;
        PackageLeftSelect1.PackageSearchCondition = pakcageSearch;

        if (Utility.PackageBackFlag == "1")
        {
            divReturn.Visible = true;
        }
        else
        {
            divReturn.Visible = false;
        }
    }

    private void SearchToBinder()
    {
        List<PackageMaterial> MVHotelList = new List<PackageMaterial>();
        if (packageMerchandise.DefaultMerchandise != null)
        {

            MVHotelList = (List<PackageMaterial>)packageMerchandise.GetPackageMaterials(1 + HotelListIndex);
            this.ShowPackageHotelDetails1.PgMerchandise = packageMerchandise;
            this.ShowPackageHotelDetails1.HotelListIndex = HotelListIndex;
            this.ShowPackageHotelDetails1.HotelDetails = MVHotelList;

            List<AirMaterial> airMaterialList = new List<AirMaterial>();
            airMaterialList.Add((AirMaterial)packageMerchandise.DefaultMerchandise[0]);
            this.DefaultFlightDetails1.FlightDetails = airMaterialList;

        }
 
        this.FlightHeader2.ReBind();
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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Utility.PackageBackFlag = "0";
        PackageSearchCondition searchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;
        searchCondition.OptionalHotelSearchConditions.RemoveAt(searchCondition.OptionalHotelSearchConditions.Count - 1);
        this.Response.Redirect("PackageSearchResult2dForm.aspx?ConditionID=" + Request.Params["ConditionID"]);
    }
}
