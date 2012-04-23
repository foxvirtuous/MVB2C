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
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;
using Terms.Sales.Business;
using Terms.Material.Service;
using Terms.Product.Utility;
using Terms.Sales.Service;

public partial class SelectRoomRates : SalseBasePage
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

    private OrderTermsConditionsService m_OrderTermsConditionsService;

    protected OrderTermsConditionsService OrderTermsConditionsService
    {
        get
        {
            return m_OrderTermsConditionsService;

        }
        set
        {
            m_OrderTermsConditionsService = value;
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
        if (Utility.IsLogin)
        {
            //phLogin.Visible = true;
            divUserLogin.Visible = false;
        }
        else
        {
            //phLogin.Visible = false;
            divUserLogin.Visible = true;
            this.UserLoginControl1.NextUrl = "TravelersContactInformation.aspx";
            this.UserLoginControl1.ReturnUrl = "SelectRoomRates.aspx";
        }
        if (!IsSearchConditionNull)
        {
            this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
            this.PackageLeftSelect1.ReturnURL = "ViewYourPackages.aspx";
            this.PKGFlightDetailsControl1.URL = "SelectRoomRates.aspx";
            //this.PKGPackageDetailsControl1.pgMerchandise = packageMerchandise;
            //this.PKGPackageDetailsControl1.BindHotels();
            this.UserLoginControl1.loginClick = DoContinueProcess;
            NavigationControl1.PageCode = 2;
            if (!IsPostBack)
            {
                this.PKGPackageDetailsControl1.pgMerchandise = packageMerchandise;
                this.PKGPackageDetailsControl1.BindHotels();
                InitSet();
                SearchAndBind();
                BindPrice();
                SetChooseDisable();
            }
        }
    }

    private void SetChooseDisable()
    {
        List<object> hotels = packageMerchandise.GetDefaultPackageMaterial().Hotels;

        int totalCount;

        totalCount = 0;

        for (int index = 0; index < hotels.Count; index++)
        {
            totalCount = totalCount + ((TimeSpan)(((MVHotel)(((IList)(hotels[index]))[0])).Profile.CheckOutDate - ((MVHotel)(((IList)(hotels[index]))[0])).Profile.CheckInDate)).Days;
        }

        if (totalCount < 5)
        {
            divUserLogin.Visible = false;
            lblMsg.Visible = false;
            ImageButton1.Visible = false;
            divMinStaysMessage.Visible = true;
        }
        else
        {
            divMinStaysMessage.Visible = false;
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
        string ConditionsType = "";
        if (this.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            ConditionsType = "MVPackage";
        }
        if (this.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            ConditionsType = "MVHotel";
        }

        Terms.Sales.Domain.TermsConditionsMeta TermsCondtions = m_OrderTermsConditionsService.GetTermsConditions(ConditionsType);
        if (TermsCondtions != null)
        {
            lblConditions.Text = TermsCondtions.Conditions;
            this.Transaction.TermsConditions = TermsCondtions.Conditions;
        }

    }

    private void SearchToBinder()
    {

        if (packageMerchandise != null && packageMerchandise.Items.Count > 0)
        {
            //int index = m_SaleMerchandise.DefaultMerchandise.Length - 1;

            PackageOrderItem packageOrderItem = new PackageOrderItem(new PackageProfile("PackageProfile"));

            int hotelIndex = Convert.ToInt32(((List<int>)packageMerchandise.DefaultIndex[1 + packageMerchandise.CurrentHotelListNumber])[0]);
            List<PackageMaterial> MVHotelList = packageMerchandise.GetPackageMaterials(1 + packageMerchandise.CurrentHotelListNumber);
            packageOrderItem.RoomPrice = ((PackageMaterial)MVHotelList[hotelIndex]).RoomPrice;
            packageOrderItem.Nights = ((PackageMaterial)MVHotelList[hotelIndex]).Nights;
            packageOrderItem.RoomPricePerNight = ((PackageMaterial)MVHotelList[hotelIndex]).RoomPricePerNight;
            packageOrderItem.AirPrice = ((PackageMaterial)MVHotelList[hotelIndex]).AirPrice;
            packageOrderItem.TotalPrice = ((PackageMaterial)MVHotelList[hotelIndex]).TotalPrice;

            AirOrderItem airOrderItem = new AirOrderItem((AirMaterial)packageMerchandise.DefaultMerchandise[0]);


            packageOrderItem.Add(airOrderItem);

            for (int i = 1; i < packageMerchandise.Items.Count; i++)
            {
                for (int k = 0; k < ((List<Hotel>)packageMerchandise.DefaultMerchandise[i]).Count; k++)
                {
                    MVHotel mvHotel = (MVHotel)((List<Hotel>)packageMerchandise.DefaultMerchandise[i])[k];

                    for (int roomIndex = 0; roomIndex < mvHotel.Items.Count; roomIndex++)
                    {
                        MVRoom mvRoom = (MVRoom)mvHotel.Items[roomIndex];

                        //mvRoom.DefaultRoomType.Room.Hotel.SetAddress(new TERMS.Common.Address(mvRoom.DefaultRoomType.Room.Hotel.City, mvRoom.DefaultRoomType.Room.Hotel.Address, mvHotel.GetAddress().ZipCode));

                        HotelOrderItem hotelOrderItem = new HotelOrderItem(mvRoom.DefaultRoomType, mvRoom.Profile);

                        packageOrderItem.Add(hotelOrderItem);
                    }
                }
                if (Utility.Transaction.CurrentTransactionObject != null)
                    Utility.Transaction.CurrentTransactionObject.Items.Clear();
                Utility.Transaction.CurrentTransactionObject.Items.Add(packageOrderItem);
            }
        }


        //this.DefaultFlightDetails1.FlightDetails = AirMaterialList;
        //this.FlightHeader1.ReBind();
        //this.PKGPackageDetailsControl1.pgMerchandise = packageMerchandise;

        //this.PKGPackageDetailsControl1.BindHotels();

        ////如果Hotel的checkin checkout 的差大于5天 edit by tll
        //SetChooseDisable();
    }

    private void SearchAndBind()
    {
        List<AirMaterial> airMaterialList = new List<AirMaterial>();
        airMaterialList.Add((AirMaterial)packageMerchandise.DefaultMerchandise[0]);
        this.PKGPackageDetailsControl1.FlightDetails = airMaterialList;
        this.PKGFlightDetailsControl1.FlightDetails = airMaterialList;
        if (packageMerchandise.DefaultMerchandise.Length > 1)
        {
            List<MVHotel> MvHotels = new List<MVHotel>();
            PackageMaterial temp = packageMerchandise.GetDefaultPackageMaterial();
            //foreach (Hotel obj in ((List<Hotel>)packageMerchandise.DefaultMerchandise[HotelListIndex + 1]))
            foreach (List<Hotel> obj in temp.Hotels)
            {
                this.PKGPackageDetailsControl1.HotelListIndex = HotelListIndex;
                //this.PKGPackageDetailsControl1.HotelMaterial = (MVHotel)obj;
                //this.PKGSearchConditionControl1.HotelDetails = (MVHotel)obj;
                MvHotels.Add((MVHotel)obj[0]);
                //return;

            }
            this.PKGSearchConditionControl1.HotelDetails = MvHotels;

        }
        else
        {
            //this.Response.Redirect("HotelSeachForm.aspx");
        }

    }

    private void BindPrice()
    {

        PackageMaterial DefualtPackageMaterial = packageMerchandise.GetDefaultPackageMaterial();
        this.lblAvgPrice.Text = DefualtPackageMaterial.AvgPrice.ToString("#,###");
        this.lblTotalPrice.Text = DefualtPackageMaterial.TotalPrice.ToString("#,###");

    }

    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        if (this.chkConditions.Checked)
        {
            if(!IsSearchConditionNull)
                DoContinueProcess();
            else
                this.Response.Redirect("~/Page/Common/ErrorMessage.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please read & confirm the Terms and Conditions to continue');</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alt", "if(document.getElementById('clickLink')!= null){document.getElementById('clickLink').click();}", true);
        }
    }

    public void DoContinueProcess()
    {
        this.PKGPackageDetailsControl1.SetRoomType();
        SearchToBinder();
        //SearchTransportationControl1.AddTransfer();

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
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=" + ex.Message);

        }

        if (!bclException)
        {
            if (Utility.IsSubAgent)
            {
                //if (!string.IsNullOrEmpty(this.txtSubagentMarkup.Text))
                //{
                //    try
                //    {
                //        decimal decmarkup = Convert.ToDecimal(txtSubagentMarkup.Text);

                //        if (decmarkup <= 0M)
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Markup format input error');</script>");
                //            return;
                //        }
                //        else
                //        {

                //            Utility.Transaction.CurrentTransactionObject.SubagentMarkup.SetAmount(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(decmarkup));
                //        }
                //    }
                //    catch
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Markup format input error');</script>");
                //        return;
                //    }
                //}
            }

            this.Response.Redirect("~/Page/Package2/TravelersContactInformation.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }

    private void GetAirBookingCondition(AirMaterial airMaterial, ref IList<Passenger> passengers)
    {


        for (int i = 0; i < Convert.ToInt32(airMaterial.Profile.GetParam("ADULT_NUMBER")); i++)
        {
            Passenger passenger = new Passenger(ProductConst.PASSFIRSTNAME, ProductConst.ADTPASSLASTNAME, ProductConst.PASSMIDDLENAME, TERMS.Common.PassengerType.Adult);

            passengers.Add(passenger);
        }
        for (int i = 0; i < Convert.ToInt32(airMaterial.Profile.GetParam("CHILD_NUMBER")); i++)
        {

            Passenger passenger = new Passenger(ProductConst.PASSFIRSTNAME, ProductConst.CHDPASSLASTNAME, ProductConst.PASSMIDDLENAME, TERMS.Common.PassengerType.Child);


            passengers.Add(passenger);
        }

    }

    protected void lkChange_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Page/Package2/ViewYourPackages.aspx?HotelIndex=0" +  "&ConditionID=" + Request.Params["ConditionID"]);
    }

    protected void txtConditions_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Page/Package2/ViewYourPackages.aspx?HotelIndex=0" + "&ConditionID=" + Request.Params["ConditionID"]);
    }



}

