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
using Terms.Base.Domain;
using Terms.Sales.Dao;
using Terms.Product.Utility;
using Terms.Base.Utility;
using Terms.Material.Service;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Sales.Business;

public partial class PackageSummaryFrom :SalseBasePage
{
    private AirService m_airService;

    protected AirService AirService
    {
        get
        {
            return m_airService;

        }
        set
        {
            m_airService = value;
        }
    }

    

    //protected PackageMerchandise packageMerchandise
    //{
    //    get
    //    {
    //        return this.OnSearch();

    //    }
       
    //}

    public PackageSummaryFrom()
    {
        this.InitializeControls += new EventHandler(PackageSummaryFrom_InitializeControls);
    }

    void PackageSummaryFrom_InitializeControls(object sender, EventArgs e)
    {
        if (Utility.IsLogin)
        {
            divLongin.Visible = true;
            UserLogin1.Visible = false;
            divHead.Visible = false;
        }
        else
        {
            divLongin.Visible = false;
            UserLogin1.Visible = true;
            UserLogin1.NextUrl = "~/Page/Package/PackageSummaryFrom.aspx";
            UserLogin1.ReturnUrl = "~/Page/Package/PackageSummaryFrom.aspx";
            divHead.Visible = true;
        }
        ChangeTravelers1.ReturnURL = "PackageSummaryFrom.aspx";
        this.FlightHeader1.FlagCode = 1;
        this.FlightHeader1.SubIndex = 2;
        UserLogin1.loginClick = DoContinueProcess;
        if (!IsPostBack)
        {
            DefaultFlightDetails1.FlagCode = 1;
            this.FlightHeader1.BindDate();
            DeleteHotelById();
            Navigation1.PageCode = 1;
            InitSet();    //初始化设置
            SearchAndBinderData();  //查询并绑定数据
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
    }

    private void SearchAndBinderData()
    {
        List<AirMaterial> airMaterialList = new List<AirMaterial>();
        airMaterialList.Add((AirMaterial)((TERMS.Business.Centers.SalesCenter.AirOrderItem)((TERMS.Business.Centers.SalesCenter.PackageOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).Items[0]).Merchandise);
        this.DefaultFlightDetails1.FlightDetails = airMaterialList;
        BindPrice();
    }

    private void BindPrice()
    {
        //decimal HotelPrice = 0M;
        //int adult = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult);
        //int child = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);
        //if (Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Count > 0)
        //{
        //    foreach (HotelMaterial hMaterial in Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList)
        //    {
        //        HotelPrice += hMaterial.Price.Total;
        //    }
        //}
        //if (Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList2 != null)
        //{
        //    if (Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList2.Count > 0)
        //    {
        //        foreach (HotelMaterial hMaterial in Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList2)
        //        {
        //            HotelPrice += hMaterial.Price.Total;
        //        }
        //    }
        //}
        PackageOrderItem packageOrderItem = (PackageOrderItem)this.Transaction.CurrentTransactionObject.Items[0];
        this.lbTotalPrice.Text = Decimal.Round(packageOrderItem.TotalPrice, 0).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
        //this.lbAvgPrice.Text = Decimal.Round(poi.AvgPrice, 0).ToString();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DoContinueProcess();
    }

    public void DoContinueProcess()
    {
        AirMaterial airMaterial = (AirMaterial)((TERMS.Business.Centers.SalesCenter.AirOrderItem)((TERMS.Business.Centers.SalesCenter.PackageOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).Items[0]).Merchandise;

       
        IList<Passenger> passengers = new List<Passenger>();

        GetAirBookingCondition(airMaterial, ref passengers);
        bool bclException = false;
        string strMessage = string.Empty;
        try
        {
            AirService.PreBookAirline(ref airMaterial, passengers);

        }
        catch (Exception ex)
        {
            //log.Error(ex.Message, ex);
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=" + ex.Message);
           // throw new Exception(ex.Message);

            //bclException = true;
            //strMessage = ex.Message;
        }

        if (!bclException)
            this.Response.Redirect("~/Page/Package/PackageTravelerForm.aspx?ConditionID=" + Request.Params["ConditionID"]);
    }

    private void GetAirBookingCondition(AirMaterial airMaterial, ref IList<Passenger> passengers)
    {


        for (int i = 0; i < Convert.ToInt32(airMaterial.Profile.GetParam("ADULT_NUMBER")); i++)
        {
            Passenger passenger = new Passenger(ProductConst.PASSFIRSTNAME, ProductConst.ADTPASSLASTNAME, ProductConst.PASSMIDDLENAME,TERMS.Common.PassengerType.Adult);

            passengers.Add(passenger);
        }
        for (int i = 0; i < Convert.ToInt32(airMaterial.Profile.GetParam("CHILD_NUMBER")); i++)
        {

            Passenger passenger = new Passenger(ProductConst.PASSFIRSTNAME, ProductConst.CHDPASSLASTNAME, ProductConst.PASSMIDDLENAME,TERMS.Common.PassengerType.Child);


            passengers.Add(passenger);
        }

    }

    private void DeleteHotelById()
    {
        //if (this.Request["Delete"] != null)
        //{
        //    if (this.Request["Delete"].Trim().ToUpper() == "Y".Trim().ToUpper())
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language='javascript'>return confirm('are you sure?');</script>");

        //        string strID = this.Request["HotelID"].Trim().ToUpper();

        //        for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Count; i++)
        //        {
        //            if (((HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList[i]).Hotel.Id.ToString().Trim().ToUpper() == strID)
        //            {
        //                Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Remove(Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList[i]);
        //            }
        //        }

        //        if (Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Count == 0)
        //        {
        //            this.Response.Redirect("~/Index.aspx");
        //        }
        //    }
        //}
    }
}
