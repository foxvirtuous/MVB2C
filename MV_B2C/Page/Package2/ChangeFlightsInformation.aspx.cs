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


using Terms.Sales.Domain;
using Terms.Sales.Service;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Sales.Business;
using System.Collections.Generic;

public partial class ChangeFlightsInformation : SalseBasePage
{
    private decimal m_hotelTotal = 0M;
    public decimal HotelTotal
    {
        get
        {
            return m_hotelTotal;
        }
        set
        {
            m_hotelTotal = value;
        }
    }
    private Guid m_HotelID;
    public Guid HotelID
    {
        set { m_HotelID = value; }
        get { return m_HotelID; }
    }
    private string m_url;
    public string URL
    {
        get { return m_url; }
        set { m_url = value; }
    }

    protected PackageMerchandise pgMerchandise
    {
        get { return (PackageMerchandise)this.OnSearch(); }

    }
    public ChangeFlightsInformation()
    {
        this.InitializeControls += new EventHandler(ChangeFlightsInformation_InitializeControls);
    }

    private void ChangeFlightsInformation_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        this.PackageLeftSelect1.ReturnURL = "ChangeFlightsInformation.aspx";
        if (Request.QueryString["URL"] != null)
            URL = Request.QueryString["URL"];
        if (Request.QueryString["HotelID"] != null)
        {
            GetHotelPrice();
        }
        this.PKGShowAllFlightsControl1.URL = URL;
        try
        {
            InitSetCondition();
            if (!IsPostBack)
            {
                InitSetSearchCondition();

            } 
            
        }
        catch(Exception ex)
        {
            string str = ex.Message;
        }
    }

    private void GetHotelPrice()
    {
        PackageMerchandise packageMerchandise = (PackageMerchandise)this.OnSearch();
        //if (packageMerchandise.MaterialList != null)
        //{
        //    if (PackageMerchandise.MaterialList.Count > 0)
        //    {
        //        foreach (HotelMaterial hm in PackageMerchandise.MaterialList)
        //        {
        //            if (hm.Hotel.Id.Equals(HotelID))
        //            {
        //                HotelTotal += hm.Price.Total;
        //            }
        //        }

        //    }
        //}
        //if (PackageMerchandise.MaterialList2 != null)
        //{
        //    foreach (HotelMaterial hm in PackageMerchandise.MaterialList2)
        //    {
        //        if (hm.Hotel.Id.Equals(HotelID))
        //        {
        //            HotelTotal += hm.Price.Total;
        //        }
        //    }
        //}
    }

    private void InitSetSearchCondition()
    {
        PackageSearchCondition pakcageSearch = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;
        this.PackageLeftSelect1.From = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].Departure.City.Name;
        this.PackageLeftSelect1.To = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].Destination.City.Name;
        this.PackageLeftSelect1.DepartureDate = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].DepartureDate;
        this.PackageLeftSelect1.ReturnDate = pakcageSearch.AirSearchCondition.GetAddTripCondition()[1].DepartureDate;
        this.PackageLeftSelect1.CheckInDate = pakcageSearch.HotelSearchCondition.CheckIn;
        this.PackageLeftSelect1.CheckOutDate = pakcageSearch.HotelSearchCondition.CheckOut;
        //this.lbFrom.Text = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].Departure.City.Name;
        //this.lbTo.Text = pakcageSearch.AirSearchCondition.GetAddTripCondition()[0].Destination.City.Name;
        //int Passengers = pakcageSearch.AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult) + pakcageSearch.AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);

        //List<PackageMaterial> MVHotelList = pgMerchandise.GetPackageMaterials(0);


        //decimal tempAvgPrice = 0M;
        //decimal tempTotal = 0M;
        //tempTotal = ((PackageMaterial)MVHotelList[Convert.ToInt32(pgMerchandise.DefaultIndex[0])]).TotalPrice;
        //tempAvgPrice = ((PackageMaterial)MVHotelList[Convert.ToInt32(pgMerchandise.DefaultIndex[0])]).AvgPrice;
        //this.lbTotalPrice.Text = Decimal.Round(tempTotal, 0).ToString();
        //this.lbAvgPrice.Text = Decimal.Round(tempAvgPrice, 0).ToString();
    }



    private void InitSetCondition()
    {
       
        List<AirMaterial> airMaterialList = new List<AirMaterial>();
        airMaterialList.Add((AirMaterial)pgMerchandise.DefaultMerchandise[0]);
        this.PKGShowAllFlightsControl1.PgMerchandise = pgMerchandise;
        this.PKGChangeDefaultFlightControl1.FlightDetails = airMaterialList;

        List<PackageMaterial> packageMaterialList = (List<PackageMaterial>)pgMerchandise.GetPackageMaterials(0);
        this.PKGShowAllFlightsControl1.FlightDetails = packageMaterialList;

        decimal tempAvgPrice = 0M;
        decimal tempTotal = 0M;
        tempTotal = ((PackageMaterial)packageMaterialList[Convert.ToInt32(pgMerchandise.DefaultIndex[0])]).TotalPrice;
        tempAvgPrice = ((PackageMaterial)packageMaterialList[Convert.ToInt32(pgMerchandise.DefaultIndex[0])]).AvgPrice;
        this.lblTotalPrice.Text = Decimal.Round(tempTotal, 0).ToString("#,###.##");
        this.lblAvgPrice.Text = Decimal.Round(tempAvgPrice, 0).ToString("#,###.##");
       
    }

    protected void btnKeep_Click(object sender, EventArgs e)
    {
        Response.Redirect(URL + "?ConditionID=" + Request.Params["ConditionID"]);
    }

    //protected void lbReturn_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("ViewYourPackages.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
    //}
}

