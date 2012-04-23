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
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Sales.Business;


public partial class ViewYourPackages : SalseBasePage
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

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (Request.QueryString["HotelIndex"] != null)
        {
            HotelListIndex = Convert.ToInt32(Request.QueryString["HotelIndex"].ToString());
        }
        this.PKGPackageDetailsInfoControl1.HotelListIndex = HotelListIndex;
        this.PKGPackageDetailsInfoControl1.PgMerchandise = packageMerchandise;
        this.PackageLeftSelect1.ReturnURL = "ViewYourPackages.aspx";
    
        NavigationControl1.PageCode = 1;
        if (!IsSearchConditionNull)
        {
            if (!IsPostBack)
            {
                InitSet();
            }
            InitBind();
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

        //if (Utility.PackageBackFlag == "1")
        //{
        //    divReturn.Visible = true;
        //}
        //else
        //{
        //    divReturn.Visible = false;
        //}
    }

    private void InitBind()
    {
        List<PackageMaterial> MVPackageList = new List<PackageMaterial>();
        if (packageMerchandise.DefaultMerchandise != null)
        {

            List<AirMaterial> airMaterialList = new List<AirMaterial>();
            airMaterialList.Add((AirMaterial)packageMerchandise.DefaultMerchandise[0]);
            this.PKGPackageDetailsInfoControl1.FlightDetails = airMaterialList;

            MVPackageList = (List<PackageMaterial>)packageMerchandise.GetPackageMaterials(1 + HotelListIndex);
            this.PKGPackageDetailsInfoControl1.PgMerchandise = packageMerchandise;
            this.PKGPackageDetailsInfoControl1.HotelListIndex = HotelListIndex;
            this.PKGPackageDetailsInfoControl1.PackageDetails = MVPackageList;

            //List<AirMaterial> airMaterialList = new List<AirMaterial>();
            //airMaterialList.Add((AirMaterial)packageMerchandise.DefaultMerchandise[0]);
            //this.PKGPackageDetailsInfoControl1.FlightDetails = airMaterialList;
            //this.PKGPackageDetailsInfoControl1.BindFlight();
        }
    }
}

