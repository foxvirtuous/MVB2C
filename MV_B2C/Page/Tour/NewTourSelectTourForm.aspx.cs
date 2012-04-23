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
using TERMS.Core.Product;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Profiles;
using Terms.Sales.Business;
using System.Collections.Generic;
using Terms.Material.Service;
using TERMS.Business.Centers.ProductCenter.Search;
using Spring.Context;
using Terms.Sales.Service;
using Spring.Context.Support;
using Terms.Configuration.Service;
using System.IO;
using Terms.Sales.Domain;
using System.Globalization;

public partial class NewTourSelectTourForm : SalseBasePage
{
    public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.OnSearch();
        }
    }

    public string SelectTourCode
    {
        get
        {
            if (Request["TourCode"] != null)
                return Request["TourCode"].Trim().ToLower();
            else
                return string.Empty;
        }
    }

    private TourMaterial _tourmaterial = null;
    public TourMaterial SelectTourMaterial
    {
        get
        {
            if (_tourmaterial == null || ((TourProfile)_tourmaterial.Profile).Code.Trim().ToLower() != SelectTourCode)
            {
                if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.Items.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.Items[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            _tourmaterial = (TourMaterial)tourMerchandise.Items[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return _tourmaterial;
        }
    }

    private TourProduct tourproduct = null;
    public TourProduct TourProduct
    {
        get
        {
            if (tourproduct == null || ((TourProfile)tourproduct.Profile).Code.Trim().ToLower() != SelectTourCode)
            {

                if (tourMerchandise != null && tourMerchandise.TourProductList != null && tourMerchandise.TourProductList.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.TourProductList.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.TourProductList[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            tourproduct = (TourProduct)tourMerchandise.TourProductList[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return tourproduct;
        }
    }

    private static int MAX_MONTH_NUMBER = 12;
    private static int MAX_COLUM_NUMBER = 11;

    public int MaxMonthNumber
    {
        get
        {
            if (Session["MaxMonthNumber"] == null)
            {
                return 12;
            }

            return (int)Session["MaxMonthNumber"];
        }
    }

    private List<PriceDate> m_PriceDateList;
    public List<PriceDate> PriceDateList
    {
        get { return m_PriceDateList; }
        set { m_PriceDateList = value; }
    }
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

    protected string ReturnURL
    {
        get
        {
            if (Request.QueryString["ReturnURL"] != null)
            {
                return Request.QueryString["ReturnURL"];
            }
            else
            {
                return "TourMoreSearchResultForm.aspx";
            }
        }
    }

    public List<OrderNumber> OrderNumbers = new List<OrderNumber>();

    public List<OrderMeta> Orders = new List<OrderMeta>();


    protected void Page_Load(object sender, EventArgs e)
    {
        BindMaster();

        if (!IsPostBack)
        {            
            BindTourInfo();
            BindItinerary();
            BindHighlights();
            BindTermsAndConditions();
            BindBooking();
        }
    }

    private void BindMaster()
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        Master.StepNumber = 2;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = false;
        Master.DeparturePlace = false;

        Page.Session["IsSelectDate"] = null;
    }

    private void BindTourInfo()
    {
        TourProfile tourProfile = (TourProfile)SelectTourMaterial.Profile;

        lblTourName.Text = tourProfile.Name;
        lblTourCode.Text = tourProfile.Code;
        lblDeparturePlace.Text = tourProfile.DefaultDepartureCity.Name;
        lblDurationDays.Text = tourProfile.Days.ToString();
        lblProductLink.Text = @"http://www.majestic-vacations.com/Tourindex.aspx?tab=T&code=" + lblTourCode.Text;
        lblPrice.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).StartFromMinFare.ToString("#,###");
        lblOperating.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).Operating;

        if (((Terms.Product.Business.MVTourProfile)tourProfile).JourneyPDF != null && ((Terms.Product.Business.MVTourProfile)tourProfile).JourneyPDF.Length > 0)
        {
            lblItineraryPDF.Visible = true;
            hlItineraryPDF.Visible = true;
            hlEmailPDF.Visible = true;
            lblEmailPDF.Visible = true;
            hlItineraryPDF.NavigateUrl = ((Terms.Product.Business.MVTourProfile)tourProfile).JourneyPDF;
            hlEmailPDF.NavigateUrl = "~/Page/Tour/EmailTourPDF.aspx?Code=" + ((Terms.Product.Business.MVTourProfile)tourProfile).JourneyPDF.Substring(((Terms.Product.Business.MVTourProfile)tourProfile).JourneyPDF.LastIndexOf(@"/") + 1)
            + @"&Name=" + tourProfile.Name + "&ConditionID=" + Request.Params["ConditionID"] + "&TourCode=" + SelectTourCode;
        }
        else
        {
            lblItineraryPDF.Visible = false;
            hlItineraryPDF.Visible = false;
            hlEmailPDF.Visible = false;
            lblEmailPDF.Visible = false;
        }
        if (tourProfile.PassCities != null && tourProfile.PassCities.Count > 0)
        {
            List<string> CityNames = new List<string>();

            for (int i = 0; i < tourProfile.PassCities.Count; i++)
            {
                CityNames.Add(tourProfile.PassCities[i].Name);
            }            
                
            lblVisiting.Text = string.Join(@", ", CityNames.ToArray());
        }

        imgTour.ImageUrl = @"http://terms.majestic-vacations.com/" + tourProfile.Logo.Replace(@"~", "");

        if (((Terms.Product.Business.MVTourProfile)tourProfile).PromotionType != null && ((Terms.Product.Business.MVTourProfile)tourProfile).PromotionType.Length > 0)
        {
            string type = ((Terms.Product.Business.MVTourProfile)tourProfile).PromotionType;

            string typeSale = type.Substring(3, 1);

            if (typeSale == "1")
            {
                imgSale.Visible = true;
                imgSale.ImageUrl = "http://www.majestic-vacations.com/images/icon_sale.png";
            }
            else
                imgSale.Visible = false;

            string type21 = type.Substring(4, 1);

            if (type21 == "1")
                Icon21.Visible = true;
            else
                Icon21.Visible = false;

            string type22 = type.Substring(5, 1);

            if (type22 == "1")
                Icon22.Visible = true;
            else
                Icon22.Visible = false;

            if (type.Length > 6)
            {
                string typeSaleChina = type.Substring(6, 1);

                if (typeSaleChina == "1")
                {
                    imgSale.Visible = true;
                    imgSale.ImageUrl = "http://www.majestic-vacations.com/images/icon_sale_02.png";
                    Label31.Visible = false;
                    Label39.Visible = true;
                    Label8.Visible = false;
                    Label40.Visible = true;
                }
                else
                {
                    imgSale.Visible = false;
                    Label31.Visible = true;
                    Label39.Visible = false;
                    Label8.Visible = true;
                    Label40.Visible = false;
                }
            }
        }
        else
        {
            imgSale.Visible = false;
            Icon22.Visible = false;
            Icon22.Visible = false;
        }
    }

    private void BindItinerary()
    {
        dlItinerary.DataSource = SelectTourMaterial.Itinerarys;
        dlItinerary.DataBind();

        for (int i = 0; i < dlItinerary.Items.Count; i++)
        {
            DataListItem item = dlItinerary.Items[i];
            TourItinerary itinerary = SelectTourMaterial.Itinerarys[i];
            ((Label)item.FindControl("lblDays")).Text = ((TourItineraryProfile)itinerary.Profile).Day.ToString();
            ((Label)item.FindControl("lblFrom")).Text = ((TourItineraryProfile)itinerary.Profile).Summary.ToString();
            ((Label)item.FindControl("lblItinerary")).Text = ((TourItineraryProfile)itinerary.Profile).Description.ToString();
            ((Image)item.FindControl("imgItinerary")).ImageUrl = @"http://terms.majestic-vacations.com/" + itinerary.Profile.Logo.Replace(@"~", "");

            for (int j = 0; j < itinerary.Items.Count; j++)
            {
                string strYorN = string.Empty;

                if (itinerary.Items[j] is MealMaterial)
                {
                    string mealType = string.Empty;
                    if (((MealMaterial)itinerary.Items[j]).MealType == TERMS.Common.MealType.Breakfast)
                        if (((MealMaterial)itinerary.Items[j]).Profile.Name.ToString() != "")
                        {
                            ((Label)item.FindControl("lblBreakfast")).Text = ((MealMaterial)itinerary.Items[j]).Profile.Name.ToString();
                        }
                        else
                        {
                            ((Label)item.FindControl("lblBreakfast")).Text = @"N/A";
                        }
                    if (((MealMaterial)itinerary.Items[j]).MealType == TERMS.Common.MealType.Lunch)
                        if (((MealMaterial)itinerary.Items[j]).Profile.Name.ToString() != "")
                        {
                            ((Label)item.FindControl("lblLunch")).Text = ((MealMaterial)itinerary.Items[j]).Profile.Name.ToString();
                        }
                        else
                        {
                            ((Label)item.FindControl("lblLunch")).Text = @"N/A";
                        }
                    if (((MealMaterial)itinerary.Items[j]).MealType == TERMS.Common.MealType.Dinner)
                        if (((MealMaterial)itinerary.Items[j]).Profile.Name.ToString() != "")
                        {
                            ((Label)item.FindControl("lblDinner")).Text = ((MealMaterial)itinerary.Items[j]).Profile.Name.ToString();
                        }
                        else
                        {
                            ((Label)item.FindControl("lblDinner")).Text = @"N/A";
                        }
                }
                else
                {
                    if (((ComponentGroup)itinerary.Items[j]).Profile.Name.ToString() != "")
                    {
                        ((Label)item.FindControl("lblHotel")).Text = ((ComponentGroup)itinerary.Items[j]).Profile.Name.ToString();
                    }
                    else
                    {
                        ((Label)item.FindControl("lblHotel")).Text = @"N/A";
                    }
                }
            }
        }
    }

    private void BindHighlights()
    {
        TourProfile tourProfile = (TourProfile)SelectTourMaterial.Profile;
        lblHighlights.Text = tourProfile.Description;

        List<string> hotelnames = new List<string>();

        for (int i = 0; i < SelectTourMaterial.Itinerarys.Count - 1; i++)
        {
            TourItinerary itinerary = SelectTourMaterial.Itinerarys[i];

            for (int j = 0; j < itinerary.Items.Count; j++)
            {
                if (itinerary.Items[j] is MealMaterial)
                {

                }
                else
                {
                    hotelnames.Add(((ComponentGroup)itinerary.Items[j]).Profile.Name.ToString());
                }
            }
        }

        rpHotelList.DataSource = hotelnames;
        rpHotelList.DataBind();

        for (int i = 0; i < rpHotelList.Items.Count; i++)
        {
            Label lblHotel = (Label)rpHotelList.Items[i].FindControl("lblHotel");
            Label lblDayss = (Label)rpHotelList.Items[i].FindControl("lblDayss");
            lblDayss.Text = (i + 1).ToString();
            lblHotel.Text = hotelnames[i];
        }
    }

    private void BindTermsAndConditions()
    {
        TourProfile tourProfile = (TourProfile)SelectTourMaterial.Profile;
        lblTermsandConditions.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).Attention;
        lblFAQ.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).FAQ;
        lblPackageIncludes.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).PackageIncludes;
        lblPackageExcludes.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).PackageExcludes;
    }

    private void BindBooking()
    {
        Session["MaxMonthNumber"] = 12;

        BindSeason();
        InitBinderInfo();
        if (!((TourSearchCondition)this.Transaction.CurrentSearchConditions).IsLandOnly)
        {
            this.tbDeptPlace.Visible = true;
            IApplicationContext ctx = ContextRegistry.GetContext();
            List<Terms.Common.Domain.City> temp = new List<Terms.Common.Domain.City>();

            IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;
            temp = applicationCacheFoundationDate.FindCityByCountry("US"); //只取美国城市
            List<Terms.Common.Domain.City> Citys = new List<Terms.Common.Domain.City>();
            foreach (Terms.Common.Domain.City city in temp)
            {
                Terms.Common.Domain.City tempcity = new Terms.Common.Domain.City();
                tempcity.Code = city.Code;
                if (city.ProvinceName != "")
                    tempcity.Name = city.Name + ", " + city.ProvinceName;
                else
                    tempcity.Name = city.Name;
                Citys.Add(tempcity);
            }
            ddlUsaCity.DataSource = Citys;
            ddlUsaCity.DataTextField = "Name";
            ddlUsaCity.DataValueField = "Code";
            ddlUsaCity.DataBind();
            lblDisplay.Visible = false;
        }
        else
        {
            lblDisplay.Visible = IsDisPlay(((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).Counrty);
        }

        TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;
        //lblHighlight.Text = ((TourMaterial)SelectTourMaterial).Profile.Description;
        BindTravelerChange(tourProfile);
        dlFrices.DataSource = PriceDateList;
        dlFrices.DataBind();

        dlPrices.DataSource = PriceDateList;
        dlPrices.DataBind();
    }

    private void BindTravelerChange(TourProfile tourProfile)
    {
        ddlUsaCity.SelectedIndex = ddlUsaCity.Items.IndexOf(ddlUsaCity.Items.FindByValue(tourProfile.DefaultDepartureCity.Code.ToString()));
    }
    private void BindSeason()
    {
        bool flag = true;
        if (SelectTourMaterial.PriceType == TERMS.Common.TourPriceType.AirLand)
            flag = false;

        TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;

        List<Decimal> priceList = new List<decimal>();
        Hashtable seasonHash = new Hashtable();

        Decimal defaultPrice = decimal.Zero;

        for (int i = 0; i < tourProfile.Seasons.Count; i++)
        {
            defaultPrice = decimal.Zero;

            for (int ii = 0; ii < tourProfile.RoomTypes.Count; ii++)
            {
                decimal roomePrice = (Decimal)tourProfile.GetPrice(tourProfile.Seasons[i], tourProfile.RoomTypes[ii], flag, false).GetAmount(TERMS.Common.PassengerType.Adult)
                    + (Decimal)tourProfile.GetPrice(tourProfile.Seasons[i], tourProfile.RoomTypes[ii], flag, false).GetMarkup(TERMS.Common.PassengerType.Adult);

                if (defaultPrice == decimal.Zero)
                    defaultPrice = roomePrice;
                else
                {
                    if (roomePrice < defaultPrice)
                        defaultPrice = roomePrice;
                }
            }

            priceList.Add(defaultPrice);

            seasonHash.Add((TERMS.Common.Season)tourProfile.Seasons[i], defaultPrice);
        }
        priceList.Sort();

        List<PriceDate> myPriceDateList = new List<PriceDate>();

        PriceDate priceDate = null;

        decimal LowFare = 0M;

        List<DateTime> dtList = null;

        foreach (TERMS.Common.Season season in seasonHash.Keys)
        {
            LowFare = (Decimal)seasonHash[season];

            priceDate = new PriceDate();

            dtList = new List<DateTime>();

            for (int j = 0; j < season.Periods.Count; j++)
            {
                dtList.AddRange(GetDateList(season.Periods[j].PeriodFrom, season.Periods[j].PeriodTo));
            }
            priceDate.LowFare = (Decimal)seasonHash[season];
            priceDate.RoomTypeFares = new List<RoomTypeAndFare>();
            for (int index = 0; index < ((Terms.Product.Business.MVTourProfile)tourProfile).RoomTypes.Count; index++)
            {
                RoomTypeAndFare roomfare = new RoomTypeAndFare();

                roomfare.RoomType = ((Terms.Product.Business.MVTourProfile)tourProfile).RoomTypes[index];
                roomfare.Fare = ((Decimal)tourProfile.GetPrice(season, ((Terms.Product.Business.MVTourProfile)tourProfile).RoomTypes[index], flag, false).GetAmount(TERMS.Common.PassengerType.Adult)).ToString("N0");
                priceDate.RoomTypeFares.Add(roomfare);
            }

            dtList.Sort();
            priceDate.DateElementList = (List<DateTime>)dtList;

            if (!IsExeists(myPriceDateList, priceDate.LowFare))
            {
                if (priceDate.DateElementList.Count > 0)
                    myPriceDateList.Add(priceDate);
            }
            else
            {
                foreach (PriceDate pd in myPriceDateList)
                {
                    if (pd.LowFare == priceDate.LowFare)
                    {
                        if (priceDate.DateElementList.Count > 0)
                        {
                            foreach (DateTime dt in priceDate.DateElementList)
                            {
                                pd.DateElementList.Add(dt);
                            }
                        }
                    }
                }
            }

        }
        SeasonFareList seasonFareList = new SeasonFareList();
        seasonFareList.Items = myPriceDateList;
        seasonFareList.SortByPrice();
        //对最后结果排序
        List<PriceDate> priceDates = new List<PriceDate>();
        List<DateTime> tempDates = null;
        PriceDate tempPriceDate = null;
        decimal tempPrice = 0M;
        foreach (PriceDate pd in seasonFareList.Items)
        {
            if (tempPrice != pd.LowFare)
            {
                tempPrice = pd.LowFare;
                tempDates = new List<DateTime>();
                tempPriceDate = new PriceDate();
                foreach (DateTime date in pd.DateElementList)
                {
                    tempDates.Add(date);
                }
                tempDates.Sort();
                tempPriceDate.LowFare = tempPrice;
                tempPriceDate.DateElementList = (List<DateTime>)tempDates;
                tempPriceDate.RoomTypeFares = pd.RoomTypeFares;
                if (tempPriceDate != null && tempPriceDate.DateElementList.Count > 0)
                    priceDates.Add(tempPriceDate);
            }
            else
            {
                foreach (DateTime date in pd.DateElementList)
                {
                    tempDates.Add(date);
                }
                tempDates.Sort();
                tempPriceDate.DateElementList = (List<DateTime>)tempDates;
                tempPriceDate.RoomTypeFares = pd.RoomTypeFares;
                if (!IsExeists(priceDates, tempPriceDate.LowFare))
                {
                    if (tempPriceDate.DateElementList.Count > 0)
                        myPriceDateList.Add(tempPriceDate);
                }

            }
        }

        priceDates.Sort(delegate(PriceDate c1, PriceDate c2) { return (c1.DateElementList[0].CompareTo(c2.DateElementList[0])); });

        PriceDateList = priceDates;
    }

    private List<PriceDate> FilterCondtion(List<PriceDate> priceDateList)
    {
        List<PriceDate> tempPricedateList = new List<PriceDate>();
        List<DateTime> result = new List<DateTime>();
        DateTime defaultDate = DateTime.MinValue;
        for (int j = 0; j < priceDateList.Count; j++)
        {
            for (int i = 0; i < priceDateList[j].DateElementList.Count; i++)
            {
                if (defaultDate != priceDateList[j].DateElementList[i])
                {
                    result.Add(priceDateList[j].DateElementList[i]);
                    defaultDate = priceDateList[j].DateElementList[i];
                }
                else
                {
                    continue;
                }
            }
            result.Sort();
            priceDateList[j].DateElementList = result;
            tempPricedateList.Add(priceDateList[j]);
        }
        return tempPricedateList;
    }

    private bool IsExeists(List<PriceDate> priceDates, decimal fare)
    {
        bool result = false;
        foreach (PriceDate pd in priceDates)
        {
            if (pd.LowFare == fare)
                result = true;
        }
        return result;
    }

    private bool IsDisPlay(string CountryCode)
    {
        foreach (string code in Utility.SetTourLandOnlyCitys)
        {
            if (CountryCode.Equals(code))
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        return false;
    }

    private List<DateTime> GetDateList(DateTime dateFrom, DateTime DateTo)
    {
        DateTime beginDate = ((TourSearchCondition)this.Transaction.CurrentSearchConditions).TravelBeginDate;
        List<DateTime> dtList = new List<DateTime>();
        int year = beginDate.AddMonths(MaxMonthNumber).Year;
        int month = beginDate.AddMonths(MaxMonthNumber).Month;
        int day = 30;
        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12: day = 31; break;
            case 2: day = DateTime.IsLeapYear(year) ? 29 : 28; break;
        }

        DateTime endDate = new DateTime(year, month, day);

        if (dateFrom >= beginDate && dateFrom <= endDate)
            dtList.Add(dateFrom);
        while (dateFrom.AddDays(1) <= DateTo)
        {
            dateFrom = dateFrom.AddDays(1);
            if (dateFrom >= beginDate && dateFrom <= endDate)
                dtList.Add(dateFrom);
        }
        return dtList;
    }

    private void InitBinderInfo()
    {
        if (SelectTourMaterial.PriceType == TERMS.Common.TourPriceType.LandOnly || SelectTourMaterial.PriceType == TERMS.Common.TourPriceType.All)
        {
            divLandOnly.Visible = true;
            divAirLand.Visible = false;
            rbtnPriceType.SelectedIndex = 0;
        }
        else
        {
            divLandOnly.Visible = false;
            divAirLand.Visible = true;
            rbtnPriceType.SelectedIndex = 1;
        }

        if (SelectTourMaterial.PriceType == TERMS.Common.TourPriceType.LandOnly)
        {
            rbtnPriceType.Items[1].Enabled = false;
            BindRoomTypeByPriceType(true);
        }
        else if (SelectTourMaterial.PriceType == TERMS.Common.TourPriceType.AirLand)
        {
            rbtnPriceType.Items[0].Enabled = false;
            BindRoomTypeByPriceType(false);
        }
        else
        {
            BindRoomTypeByPriceType(true);
            BindRoomTypeByPriceType(false);
        }
    }

    private void BindRoomTypeByPriceType(bool pricetype)
    {
        if (!IsSearchConditionNull)
        {
            List<PriceDate> tempPriceDates = PriceDateList;
            tempPriceDates.Sort(delegate(PriceDate c1, PriceDate c2) { return (c1.LowFare.CompareTo(c2.LowFare)); });
            DateTime date = tempPriceDates[0].DateElementList[0];
            TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;
            decimal DefaultPrice = 0M;
            string RoomType = string.Empty;

            DataTable dt = new DataTable("TourRoomTypes");

            DataColumn dcRoomTypeName = new DataColumn("RoomTypeName", Type.GetType("System.String"));
            DataColumn dcRoomPrice = new DataColumn("RoomPrice", Type.GetType("System.String"));

            dt.Columns.Add(dcRoomTypeName);
            dt.Columns.Add(dcRoomPrice);

            for (int i = 0; i < tourProfile.RoomTypes.Count; i++)
            {
                RoomType = tourProfile.RoomTypes[i];
                TERMS.Common.Price price = tourProfile.GetPrice(date, RoomType, false, false);

                DefaultPrice = (Decimal)tourProfile.GetPrice(date, RoomType, pricetype, false).GetAmount(TERMS.Common.PassengerType.Adult)
                            + (Decimal)tourProfile.GetPrice(date, RoomType, pricetype, false).GetMarkup(TERMS.Common.PassengerType.Adult);

                if (DefaultPrice > 0M)
                {
                    DataRow dr = dt.NewRow();
                    dr["RoomTypeName"] = RoomType;
                    dr["RoomPrice"] = DefaultPrice.ToString("#,###");
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count > 0)
            {
                if (pricetype)
                {
                    dlTourRoomTypeList.DataSource = dt;
                    dlTourRoomTypeList.DataBind();
                }
                else
                {
                    dlTourRoomTypeList1.DataSource = dt;
                    dlTourRoomTypeList1.DataBind();
                }
            }
        }
        else
        {
            Response.Redirect("~/Page/Common/ErrorMessage.aspx");
        }
    }

    public int GetPersonNumber(int[] person)
    {
        int number = 0;
        for (int i = 0; i < person.Length; i++)
        {
            number += person[i];
        }
        return number;
    }

    private InsuranceMaterial SetInsurance()
    {
        Terms.Sales.Business.InsuranceSearchCondition Condition = new Terms.Sales.Business.InsuranceSearchCondition();

        Condition.InsuranceType = TERMS.Common.InsuranceType.Tour;

        Condition.DepartureDate = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).BeginDate;
        Condition.ReturnDate = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).EndDate;

        Condition.TravelerCount = 1;

        Condition.TotalTripCost = 0M;

        InsuranceMaterial insuranceMaterial = this.OnSearchInsurance(Condition);

        return insuranceMaterial;
    }

    private bool CheckSelectRooms()
    {
        bool result = false;

        if (rbtnPriceType.SelectedIndex == 0)
            for (int i = 0; i < dlTourRoomTypeList.Items.Count; i++)
            {
                if (((DropDownList)dlTourRoomTypeList.Items[i].FindControl("dllRooms")).SelectedIndex > 0)
                {
                    result = true;
                    break;
                }
            }
        else
            for (int i = 0; i < dlTourRoomTypeList1.Items.Count; i++)
            {
                if (((DropDownList)dlTourRoomTypeList1.Items[i].FindControl("dllRooms")).SelectedIndex > 0)
                {
                    result = true;
                    break;
                }
            }

        return result;
    }

    private bool IsDate(string datestring)
    {
        try
        {
            DateTime date = Convert.ToDateTime(datestring);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private void PriceChangedByPrice(bool pricetype)
    {
        TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;
        DateTime date = Convert.ToDateTime(txtDate.Text);
        decimal DefaultPrice = 0M;
        string RoomType = string.Empty;

        DataTable dt = new DataTable("TourRoomTypes");

        DataColumn dcRoomTypeName = new DataColumn("RoomTypeName", Type.GetType("System.String"));
        DataColumn dcRoomPrice = new DataColumn("RoomPrice", Type.GetType("System.String"));

        dt.Columns.Add(dcRoomTypeName);
        dt.Columns.Add(dcRoomPrice);

        for (int i = 0; i < tourProfile.RoomTypes.Count; i++)
        {
            RoomType = tourProfile.RoomTypes[i];
            DefaultPrice = (Decimal)tourProfile.GetPrice(date, RoomType, pricetype, false).GetAmount(TERMS.Common.PassengerType.Adult)
                        + (Decimal)tourProfile.GetPrice(date, RoomType, pricetype, false).GetMarkup(TERMS.Common.PassengerType.Adult);
            if (DefaultPrice > 0M)
            {
                DataRow dr = dt.NewRow();
                dr["RoomTypeName"] = RoomType;
                dr["RoomPrice"] = DefaultPrice.ToString("#,###");
                dt.Rows.Add(dr);
            }
        }

        if (dt.Rows.Count > 0)
        {
            if (pricetype)
            {
                dlTourRoomTypeList.DataSource = dt;
                dlTourRoomTypeList.DataBind();
            }
            else
            {
                dlTourRoomTypeList1.DataSource = dt;
                dlTourRoomTypeList1.DataBind();
            }
        }
    }

    private int GetOrderNumber(DateTime date)
    {
        if (Orders.Count == 0)
        {
            string tourcode = ((TourMaterial)SelectTourMaterial).Profile.Code;

            IApplicationContext ctx = ContextRegistry.GetContext();
            IOPSaleOrderService optourgroupservice = ctx["OPSaleOrderService"] as IOPSaleOrderService;

            Orders = optourgroupservice.GetOrderPassengerNumberByTourCode(tourcode);
        }

        int pass = 0;

        if (Orders.Count > 0)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].BeginDate == date)
                {
                    pass += Orders[i].AdultNumber + Orders[i].ChildNumber;
                }
            }
        }

        return pass;
    }


    public class PriceDate
    {
        private decimal m_LowFare = 0.0m;
        private List<RoomTypeAndFare> m_RoomTypeFares = new List<RoomTypeAndFare>();
        private List<DateTime> m_DateElementList = new List<DateTime>();
        private List<string> m_OrderPassNumber = new List<string>();
        public decimal LowFare
        {
            get { return m_LowFare; }
            set { m_LowFare = value; }
        }

        public List<DateTime> DateElementList
        {
            get { return m_DateElementList; }
            set { m_DateElementList = value; }
        }

        public List<RoomTypeAndFare> RoomTypeFares
        {
            get { return m_RoomTypeFares; }
            set { m_RoomTypeFares = value; }
        }
    }

    public class SeasonFareList
    {
        /// <summary>
        /// 将Items中的内容按照Price升序排序
        /// </summary>
        protected new List<PriceDate> m_items;
        public new List<PriceDate> Items
        {
            get
            {
                return m_items;
            }
            set
            {
                m_items = value;
            }
        }

        public void SortByPrice()
        {
            Items.Sort(CompareByPrice);
        }

        protected static int CompareByPrice(PriceDate priceX, PriceDate priceY)
        {
            if (priceX.LowFare == 0M)
            {
                if (priceY.LowFare == 0M)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (priceY.LowFare == 0M)
                {
                    return 1;
                }
                else
                {
                    if (priceX.LowFare > priceY.LowFare)
                    {
                        return 1;
                    }
                    else if (priceX.LowFare == priceY.LowFare)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
    }

    public class OrderNumber
    {
        private DateTime _dep = DateTime.MinValue;
        private int _number = 0;

        public DateTime Dep
        {
            set
            {
                _dep = value;
            }
            get
            {
                return _dep;
            }
        }

        public int Number
        {
            set
            {
                _number = value;
            }
            get
            {
                return _number;
            }
        }
    }

    public class RoomTypeAndFare
    {
        private string m_RoomType;

        public string RoomType
        {
            get { return m_RoomType; }
            set { m_RoomType = value; }
        }

        private string m_Fare;

        public string Fare
        {
            get { return m_Fare; }
            set { m_Fare = value; }
        }
    }

    protected void dlDates_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl_br = (Label)e.Item.FindControl("lbl_br");
            int parentIndex = ((DataListItem)((DataList)e.Item.Parent).Parent).ItemIndex;
            int index = e.Item.ItemIndex;
            Label lkbDate = (Label)e.Item.FindControl("lbt_date");
            string date = PriceDateList[parentIndex].DateElementList[index].ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            lkbDate.Attributes["Onclick"] = "SelectDate('" + date + "',this)";
            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                int pass = GetOrderNumber(PriceDateList[parentIndex].DateElementList[index]);
                Label lblNumber = (Label)e.Item.FindControl("lbl_Number");
                lblNumber.Visible = true;
                lblNumber.Text = "(" + pass.ToString() + ")";
            }
            string strBr = string.Empty;
            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                if ((e.Item.ItemIndex + 1) % 8 == 0)
                    lbl_br.Text = "<BR>";
            }
            else if ((e.Item.ItemIndex + 1) % MAX_COLUM_NUMBER == 0)
                lbl_br.Text = "<BR>";
        }
    }
    protected void dlFrices_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlTable divideLine = (HtmlTable)e.Item.FindControl("divideLine");
            int index = e.Item.ItemIndex;
            if (index > 0)
                divideLine.Visible = true;

        }
    }

    protected void dlDates_ItemCommand(object sender, DataListCommandEventArgs e)
    {
        BindSeason();
        int parentIndex = ((DataListItem)((DataList)e.Item.Parent).Parent).ItemIndex;
        int index = e.Item.ItemIndex;
        if (e.CommandName == "SelectDate")
        {
        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        if (ReturnURL.Equals("TourIndex.aspx"))
            Response.Redirect("~/" + ReturnURL);
        else
            Response.Redirect(ReturnURL + "?ConditionID=" + Request.Params["ConditionID"]);
    }

    protected void btn_button_Click(object sender, EventArgs e)
    {
        BindSeason();

        if (!CheckSelectRooms())
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "TourWarting", "<script language=javascript>alert('Please choose room number');</script>");
            return;
        }
        if (IsDate(this.txtDate.Text))
        {
            bool pricetype = true;

            if (rbtnPriceType.SelectedIndex == 1)
                pricetype = false;

            DateTime date = Convert.ToDateTime(this.txtDate.Text);
            ((TourSearchCondition)this.Transaction.CurrentSearchConditions).FlightDeptDate = date;
            TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;

            TourOrderItem tourOrderItem = new TourOrderItem(tourProfile);
            AirMaterial am = null;
            for (int i = 0; i < ((TourMaterial)SelectTourMaterial).Items.Count; i++)
            {

                if (((TourMaterial)SelectTourMaterial).Items[i] is TourItinerary)
                    tourOrderItem.Add(((TourMaterial)SelectTourMaterial).Items[i]);
            }
            tourOrderItem.Destination = ((Terms.Product.Business.MVTourProfile)((TourMaterial)SelectTourMaterial).Profile).StartCity;
            tourOrderItem.SetBeginDate(date);
            tourOrderItem.ChildNumber = 0;//GetPersonNumber(this.TourTravelerChangeControl1.Childs);
            tourOrderItem.AdultNumber = 0;// GetPersonNumber(this.TourTravelerChangeControl1.Adults);
            tourOrderItem.ChildWithOutNumber = 0;// GetPersonNumber(this.TourTravelerChangeControl1.ChildsWithOut);
            tourOrderItem.SetEndDate(date.AddDays(tourProfile.Days - 1));


            Page.Session["IsSelectDate"] = true;

            this.Transaction.CurrentTransactionObject.Items.Clear();
            this.Transaction.CurrentTransactionObject.AddItem(tourOrderItem);

            List<TourOrderFareType> FareTypeList = new List<TourOrderFareType>();
            TourOrderFareType landType = new TourOrderFareType();
            List<TourRoom> tourRooms = new List<TourRoom>();//this.TourTravelerChangeControl1.GetTourRooms(tourProfile, date);
            TourRoom tourRoom = null;
            decimal totalPrice = 0M;

            if (pricetype)
                for (int i = 0; i < dlTourRoomTypeList.Items.Count; i++)
                {
                    DropDownList dllRooms = (DropDownList)dlTourRoomTypeList.Items[i].FindControl("dllRooms");

                    if (dllRooms != null && dllRooms.SelectedIndex > 0)
                    {
                        Label lblRoomType = (Label)dlTourRoomTypeList.Items[i].FindControl("lblRoomType");

                        for (int number = 0; number < Convert.ToInt32(dllRooms.SelectedValue); number++)
                        {
                            tourRoom = new TourRoom();
                            tourRoom.RoomType = lblRoomType.Text.ToString();
                            tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, tourRoom.RoomType, pricetype, false).GetAmount(TERMS.Common.PassengerType.Adult)
                                               + (Decimal)tourProfile.GetPrice(date, tourRoom.RoomType, pricetype, false).GetMarkup(TERMS.Common.PassengerType.Adult);
                            tourRoom.RoomIndex = number + 1;
                            tourRoom.Quantity = 0;
                            landType.AddTourRoom(tourRoom);
                        }
                    }
                }
            else
                for (int i = 0; i < dlTourRoomTypeList1.Items.Count; i++)
                {
                    DropDownList dllRooms = (DropDownList)dlTourRoomTypeList1.Items[i].FindControl("dllRooms");

                    if (dllRooms != null && dllRooms.SelectedIndex > 0)
                    {
                        Label lblRoomType = (Label)dlTourRoomTypeList1.Items[i].FindControl("lblRoomType");

                        for (int number = 0; number < Convert.ToInt32(dllRooms.SelectedValue); number++)
                        {
                            tourRoom = new TourRoom();
                            tourRoom.RoomType = lblRoomType.Text.ToString();
                            tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, tourRoom.RoomType, pricetype, false).GetAmount(TERMS.Common.PassengerType.Adult)
                                               + (Decimal)tourProfile.GetPrice(date, tourRoom.RoomType, pricetype, false).GetMarkup(TERMS.Common.PassengerType.Adult);
                            tourRoom.RoomIndex = number + 1;
                            tourRoom.Quantity = 0;
                            landType.AddTourRoom(tourRoom);
                        }
                    }
                }

            landType.Type = TourFareType.LAND;
            FareTypeList.Add(landType);
            decimal diffFare = 0.0m;
            if (((TourSearchCondition)this.Transaction.CurrentSearchConditions).IsLandOnly)
            {
            }
            else
            {

                bool HasError = false;
                ((TourSearchCondition)this.Transaction.CurrentSearchConditions).DeptCity = ddlUsaCity.SelectedValue;
                if (TourProduct.AirGroup.Profile.SearchRules.Count > 0)
                {
                    AirSearchRule airSearchRule = (AirSearchRule)TourProduct.AirGroup.Profile.SearchRules[0];
                    diffFare = m_airService.GetFareDiff(tourProfile.DefaultDepartureCity.Code, ddlUsaCity.SelectedValue, tourProfile.StartCity.Code, tourProfile.EndCity.Code, date, date.AddDays(tourProfile.Days), airSearchRule.Airlines[0].Code, airSearchRule.BookingClasses[0], out HasError);
                    tourOrderItem.AirLine = airSearchRule.Airlines[0].Code;
                    tourOrderItem.BookingClass = airSearchRule.BookingClasses[0];

                    if (HasError)
                    {
                        tourOrderItem.DepartureCity = tourProfile.DefaultDepartureCity.Code;//取差价失败，采用默认出发地
                    }
                    else
                    {
                        tourOrderItem.DepartureCity = ddlUsaCity.SelectedValue;
                    }
                }
                else
                {
                    //todo
                }

                #region 机票addOn 部分价格类型处理
                if (diffFare > 0)
                {
                    TourOrderFareType addOnType = new TourOrderFareType();

                    addOnType.Price = diffFare;
                    addOnType.Quantity = tourOrderItem.AdultNumber + tourOrderItem.ChildNumber;
                    addOnType.Type = TourFareType.ADDON;
                    totalPrice += addOnType.Quantity * addOnType.Price;
                    FareTypeList.Add(addOnType);
                }
                #endregion
            }


            tourOrderItem.TotalPrice = totalPrice;
            tourOrderItem.FareTypeList = FareTypeList;

            tourOrderItem.InsuranceMaterial = SetInsurance();//取保险；
            this.Response.Redirect("TourSelectAirForm.aspx?ReturnURL=" + ReturnURL + "&ConditionID=" + Request.Params["ConditionID"] + "&TourCode=" + SelectTourCode + "&PriceType=" + pricetype);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "TourWarting", "<script language=javascript>alert('Please choose departure date');</script>");
            return;
        }
    }

    protected void btn_PriceChanged_Click(object sender, EventArgs e)
    {
        if (SelectTourMaterial.PriceType == TERMS.Common.TourPriceType.LandOnly)
        {
            PriceChangedByPrice(true);
        }
        else if (SelectTourMaterial.PriceType == TERMS.Common.TourPriceType.AirLand)
        {
            PriceChangedByPrice(false);
        }
        else
        {
            PriceChangedByPrice(true);
            PriceChangedByPrice(false);
        }
    }

    protected void lbtnMore_Click(object sender, EventArgs e)
    {
        if (MaxMonthNumber == 6)
        {
            Session["MaxMonthNumber"] = 12;
            BindBooking();
        }
        else
        {
            Session["MaxMonthNumber"] = 6;
            BindBooking();
        }
    }

    protected void rbtnPriceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnPriceType.SelectedIndex == 0)
        {
            divLandOnly.Visible = true;
            divAirLand.Visible = false;
        }
        else
        {
            divLandOnly.Visible = false;
            divAirLand.Visible = true;
        }
    }

    public string TopDes
    {
        get
        {
            if (Request["TopDestinations"] != null)
                return Request["TopDestinations"].Trim();

            return string.Empty;
        }
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        if (Request["Preference"] != null)
            Response.Redirect("NewTourMoreSearchResultForm.aspx?TopDestinations=" + TopDes + "&ConditionID=" + this.Transaction.IntKey.ToString() + "&Preference=" + Request["Preference"]);
        else
            Response.Redirect("NewTourMoreSearchResultForm.aspx?TopDestinations=" + TopDes + "&ConditionID=" + this.Transaction.IntKey.ToString());
    }

    protected void dlPrices_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            PriceDate pricedate = (PriceDate)e.Item.DataItem;

            if (pricedate.RoomTypeFares != null)
            {
                DataList dlRooms = (DataList)e.Item.FindControl("dlRooms");

                dlRooms.DataSource = pricedate.RoomTypeFares;
                dlRooms.DataBind();

                for (int i = 0; i < dlRooms.Items.Count; i++)
                {
                    Label lblRoomType = (Label)dlRooms.Items[i].FindControl("lblRoomType");
                    Label lblRoomPrice = (Label)dlRooms.Items[i].FindControl("lblRoomPrice");
                    lblRoomType.Text = pricedate.RoomTypeFares[i].RoomType;
                    lblRoomPrice.Text = pricedate.RoomTypeFares[i].Fare;
                }
            }
        }
    }

    protected void dlPriceDates_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl_br = (Label)e.Item.FindControl("lbl_br");
            int parentIndex = ((DataListItem)((DataList)e.Item.Parent).Parent).ItemIndex;
            int index = e.Item.ItemIndex;
            Label lkbDate = (Label)e.Item.FindControl("lbt_date");

            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                int pass = GetOrderNumber(PriceDateList[parentIndex].DateElementList[index]);
                Label lblNumber = (Label)e.Item.FindControl("lbl_Number");
                lblNumber.Visible = true;
                lblNumber.Text = "(" + pass.ToString() + ")";
            }
            string strBr = string.Empty;
            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                if ((e.Item.ItemIndex + 1) % 8 == 0)
                    lbl_br.Text = "<BR>";
            }
            else if ((e.Item.ItemIndex + 1) % 13 == 0)
                lbl_br.Text = "<BR>";
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        btn_button_Click(sender, e);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        btn_back_Click(sender, e);
    }
}
