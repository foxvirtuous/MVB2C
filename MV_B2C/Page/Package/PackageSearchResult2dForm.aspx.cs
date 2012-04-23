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
using Terms.Sales.Utility;



using Terms.Base.Utility;
using Terms.Material.Service;
using Terms.Product.Utility;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Sales.Business;

public partial class PackageSearchResult2dForm : SalseBasePage
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

    public List<AirMaterial> AirMaterialList
    {
        get
        {
            List<AirMaterial> airMaterialList = new List<AirMaterial>();

            airMaterialList.Add((AirMaterial)pgMerchandise.DefaultMerchandise[0]);
            return airMaterialList;
        }

    }

    protected PackageMerchandise pgMerchandise
    {
        get { return (PackageMerchandise)this.OnSearch(); }
    }
    public PackageSearchResult2dForm()
    {
        this.InitializeControls += new EventHandler(PackageSearchResult2dForm_InitializeControls);
    }

    void PackageSearchResult2dForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (Utility.IsLogin)
        {
            divLongin.Visible = true;
            UserLogin1.Visible = false;
            divHead.Visible = false;

            //if (Utility.IsSubAgent)
            //{
            //    divSubagent.Visible = true;
            //    phAgentFlightMarkup.Visible = true;
            //}
            //else
            //{
            //    divSubagent.Visible = false;
            //    phAgentFlightMarkup.Visible = false;
            //}
        }
        else
        {
            divLongin.Visible = false;
            UserLogin1.Visible = true;
            UserLogin1.NextUrl = "~/Page/Package/PackageTravelerForm.aspx";
            UserLogin1.ReturnUrl = "~/Page/Package/PackageSearchResult2dForm.aspx";
            divHead.Visible = true;
        }
        this.FlightHeader1.FlagCode = 1;
        this.FlightHeader1.SubIndex = 0;
        ChangeTravelers1.ReturnURL = "PackageSearchResult2dForm.aspx";
        this.DefaultFlightDetails1.URL = "PackageSearchResult2dForm.aspx?PostBack=false";
        UserLogin1.loginClick = DoContinueProcess;
        if (this.Request["PostBack"] != null)
        {
            InitSet();
            this.DefaultFlightDetails1.FlightDetails = AirMaterialList;
            this.FlightHeader1.ReBind();
            this.ShowPackageHotels1.pgMerchandise = pgMerchandise;
            this.ShowPackageHotels1.BindHotels();

            //如果Hotel的checkin checkout 的差大于5天 edit by tll
            SetChooseDisable();

            SearchToBinder();
            BinderPrice();
        }
        else
        {
            if (!IsPostBack)
            {
                InitSet();
                SearchToBinder();
                BinderPrice();
            }
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

        //获取Terms Conditions
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
            lbConditons.Text = TermsCondtions.Conditions;
            this.Transaction.TermsConditions = TermsCondtions.Conditions;
        }
        
    }

    private void SearchToBinder()
    {

        //if (Utility.SelectAirGroup == null)
        //{
        //    ComponentGroup group = new ComponentGroup();
        //    AirComponentGroup airGroup = (AirComponentGroup)((ComponentGroup)PackageMerchandise.ComponentGroup.Items[1].Component).Items[ParentIndex].Component;
        //    ComponentGroupItem componentGroupItem = new ComponentGroupItem(airGroup.Items[SonIndex].Component);
        //    AirComponentGroup lastGroup = new AirComponentGroup((AirProfile)airGroup.Profile);
        //    lastGroup = (AirComponentGroup)airGroup.Clone();
        //    lastGroup.Items.Add(componentGroupItem);
        //    group.Profile = PackageMerchandise.ComponentGroup.Profile;
        //    group.Items.Clear();
        //    group.Items.Add(new ComponentGroupItem(lastGroup));
        //    Utility.SelectAirGroup = group;


        //    if (Utility.Transaction.CurrentTransactionObject.Items.Count == 0)
        //    {
        //        SaleMerchandise saleMerchandise = new SaleMerchandise();
        //        saleMerchandise.ComponentGroup = group;
        //        Utility.Transaction.CurrentTransactionObject.AddItem(saleMerchandise);

        //    }
        //    else
        //    {
        //        Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.ComponentGroup = group;
        //    }
        //}
        if (pgMerchandise != null && pgMerchandise.Items.Count > 0)
        {
            //int index = m_SaleMerchandise.DefaultMerchandise.Length - 1;

            PackageOrderItem packageOrderItem = new PackageOrderItem(new PackageProfile("PackageProfile"));

            int hotelIndex = Convert.ToInt32(((List<int>)pgMerchandise.DefaultIndex[1 + pgMerchandise.CurrentHotelListNumber])[0]);
            List<PackageMaterial> MVHotelList = pgMerchandise.GetPackageMaterials(1 + pgMerchandise.CurrentHotelListNumber);
            packageOrderItem.RoomPrice = ((PackageMaterial)MVHotelList[hotelIndex]).RoomPrice;
            packageOrderItem.Nights = ((PackageMaterial)MVHotelList[hotelIndex]).Nights;
            packageOrderItem.RoomPricePerNight = ((PackageMaterial)MVHotelList[hotelIndex]).RoomPricePerNight;
            packageOrderItem.AirPrice = ((PackageMaterial)MVHotelList[hotelIndex]).AirPrice;
            packageOrderItem.TotalPrice = ((PackageMaterial)MVHotelList[hotelIndex]).TotalPrice;

            AirOrderItem airOrderItem = new AirOrderItem((AirMaterial)pgMerchandise.DefaultMerchandise[0]);


            packageOrderItem.Add(airOrderItem);

            for (int i = 1; i < pgMerchandise.Items.Count; i++)
            {
                for (int k = 0; k < ((List<Hotel>)pgMerchandise.DefaultMerchandise[i]).Count; k++)
                {
                    MVHotel mvHotel = (MVHotel)((List<Hotel>)pgMerchandise.DefaultMerchandise[i])[k];

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


        this.DefaultFlightDetails1.FlightDetails = AirMaterialList;
        this.FlightHeader1.ReBind();
        this.ShowPackageHotels1.pgMerchandise = pgMerchandise;

        this.ShowPackageHotels1.BindHotels();

        //如果Hotel的checkin checkout 的差大于5天 edit by tll
        SetChooseDisable();
    }

    private void SetChooseDisable()
    {
        List<object> hotels = pgMerchandise.GetDefaultPackageMaterial().Hotels;

        int totalCount;

        totalCount = 0;

        for (int index = 0; index < hotels.Count; index++)
        {
            totalCount = totalCount + ((TimeSpan)(((MVHotel)(((IList)(hotels[index]))[0])).Profile.CheckOutDate - ((MVHotel)(((IList)(hotels[index]))[0])).Profile.CheckInDate)).Days;
        }

        if (totalCount < 5)
        {
            divLongin.Visible = false;
            divHead.Visible = false;
            divMinStaysMessage.Visible = true;
        }
        else
        {
            if (Utility.IsLogin || Utility.IsSubAgent)
            {
                divLongin.Visible = true;
                divHead.Visible = false;
            }
            else
            {
                divLongin.Visible = false;
                divHead.Visible = true;
            }

            divMinStaysMessage.Visible = false;
        }
    }

    private void BinderPrice()
    {
        
        PackageMaterial DefualtPackageMaterial = pgMerchandise.GetDefaultPackageMaterial();

        this.lbTotalPrice.Text = Decimal.Round(DefualtPackageMaterial.TotalPrice, 0).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
        //this.lbAvgPrice.Text = Decimal.Round(DefualtPackageMaterial.AddPrice, 0).ToString();
    }

    public void btnContinue_Click2(object sender, ImageClickEventArgs e)
    {
        DoContinueProcess();
    }

    public void DoContinueProcess()
    {
        SearchTransportationControl1.AddTransfer();

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
        {
            if (Utility.IsSubAgent)
            {
                if (!string.IsNullOrEmpty(this.txtSubagentMarkup.Text))
                {
                    try
                    {
                        decimal decmarkup = Convert.ToDecimal(txtSubagentMarkup.Text);

                        if (decmarkup <= 0M)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Markup format input error');</script>");
                            return;
                        }
                        else
                        {
                            //SubagentMarkupOrderItem markup = new SubagentMarkupOrderItem(new TERMS.Business.Centers.ProductCenter.Profiles.SubagentMarkupProfile(""));

                            //markup.Markup = decmarkup;

                            //Utility.Transaction.CurrentTransactionObject.AddItem(markup);
                            Utility.Transaction.CurrentTransactionObject.SubagentMarkup.SetAmount(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(decmarkup));
                        }
                    }
                    catch
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Markup format input error');</script>");
                        return;
                    }
                }
            }

            this.Response.Redirect("~/Page/Package/PackageTravelerForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }

    private void GetAirBookingCondition(AirMaterial airMaterial, ref IList<Passenger> passengers)
    {


        for (int i = 0; i < Convert.ToInt32(airMaterial.Profile.GetParam("ADULT_NUMBER")); i++)
        {
            Passenger passenger = new Passenger(ProductConst.PASSFIRSTNAME, ProductConst.ADTPASSLASTNAME,ProductConst.PASSMIDDLENAME, TERMS.Common.PassengerType.Adult);

            passengers.Add(passenger);
        }
        for (int i = 0; i < Convert.ToInt32(airMaterial.Profile.GetParam("CHILD_NUMBER")); i++)
        {

            Passenger passenger = new Passenger(ProductConst.PASSFIRSTNAME, ProductConst.CHDPASSLASTNAME, ProductConst.PASSMIDDLENAME, TERMS.Common.PassengerType.Child);


            passengers.Add(passenger);
        }

    }

    private void AddMarkup()
    {
        //if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        //{
        //    if (!string.IsNullOrEmpty(txtSubagentMarkup.Text))
        //    {
        //        decimal decSum = 0M;

        //        PackageMaterial DefualtPackageMaterial = pgMerchandise.GetDefaultPackageMaterial();

        //        decSum = Decimal.Round(DefualtPackageMaterial.TotalPrice, 0);

        //        decimal decMarkup;
        //        try
        //        {
        //            decMarkup = Convert.ToDecimal(lblAgentAdultUnitMarkup.Text);
        //        }
        //        catch
        //        {
        //            decMarkup = 0M;
        //        }
        //        if (decMarkup >= 0)
        //        {
        //            lbTotalPrice.Text = (decSum + decMarkup).ToString("N2");
        //        }
        //    }
        //}
    }

    protected void txtAgentAdultUnitMarkup_TextChanged(object sender, EventArgs e)
    {
        this.lblAgentAdultUnitMarkup.Text = txtSubagentMarkup.Text; ;

        if (Utility.IsSubAgent)
        {
            AddMarkup();
        }

    }
}
