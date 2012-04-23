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
using System.Text.RegularExpressions;


public partial class IncentiveTourSelectForm : SalseBasePage
{
    private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(typeof(TourSelectTourForm));
    public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.OnSearch();
        }
    }
    private static int MAX_MONTH_NUMBER = 6;
    private static int MAX_COLUM_NUMBER = 11;

    public int MaxMonthNumber
    {
        get
        {
            if (Session["MaxMonthNumber"] == null)
            {
                return 6;
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

    private ISubIncentiveTourConfigService m_SubIncentiveTourConfigService;
    public ISubIncentiveTourConfigService SubIncentiveTourConfigService
    {
        set { m_SubIncentiveTourConfigService = value; }
    }

    private ISubIncentiveTourService m_SubIncentiveTourService;
    protected ISubIncentiveTourService SubIncentiveTourService
    {
        get
        {
            return m_SubIncentiveTourService;
        }
        set
        {
            m_SubIncentiveTourService = value;
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

    public List<OrderNumber> OrderNumber = new List<OrderNumber>();

    public List<OrderMeta> Orders = new List<OrderMeta>();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        Master.StepNumber = 2;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = true;
        CurrentItineraryControl.IsShowPart2 = true;
        CurrentItineraryControl.IsShowPrint = true;
        //CurrentItineraryControl.SelectTourIndex = tourMerchandise.DefaultNumber;
        Page.Session["IsSelectDate"] = null;

        try
        {
            if (!Page.IsPostBack)
            {
                Session["MaxMonthNumber"] = 6;

                //Log
                TurboTT.Log.Core.TimeLog tlLoad = new TurboTT.Log.Core.TimeLog(PageUtility.TourLogRandomNumber.ToString() + "Load Tour Select From:");
                tlLoad.Start();

                Initial();

                //log
                tlLoad.Stop();
                PageUtility.TourSearchingTimeLog.Info(tlLoad);
            }

            //SearchToBinder();
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }

    /// <summary>
    /// Init page
    /// </summary>
    private void Initial()
    {
        //TourItineraryControl1.SelectTourIndex = SelectTourIndex;
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
            isIndex4Or5.Text = "4";
            isIndex5Or6.Text = "5";
            lblDisplay.Visible = IsDisPlay(((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).Counrty);
        }

        TourProfile tourProfile = (TourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile;
        lblHighlight.Text = ((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile.Description;
        lblRemark.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).Attention;//((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile.
        BindTravelerChange(tourProfile);
        dlFrices.DataSource = PriceDateList;
        dlFrices.DataBind();

    }

    private void BindTravelerChange(TourProfile tourProfile)
    {
        //TourTravelerChangeControl1.SetRoomTypes(tourProfile.RoomTypes, ((Terms.Product.Business.MVTourProfile)tourProfile).DefaultFareKey);
        //TourTravelerChangeControl1.DeptCity = tourProfile.DefaultDepartureCity.Code;
        ddlUsaCity.SelectedIndex = ddlUsaCity.Items.IndexOf(ddlUsaCity.Items.FindByValue(tourProfile.DefaultDepartureCity.Code.ToString()));
    }
    private void BindSeason()
    {
        TourProfile tourProfile = (TourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile;

        List<Decimal> priceList = new List<decimal>();
        Hashtable seasonHash = new Hashtable();

        for (int i = 0; i < tourProfile.Seasons.Count; i++)
        {
            Decimal defaultPrice = (Decimal)tourProfile.GetPrice(tourProfile.Seasons[i], ((Terms.Product.Business.MVTourProfile)tourProfile).DefaultFareKey, ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Adult);
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
                if (!IsExeists(priceDates, tempPriceDate.LowFare))
                {
                    if (tempPriceDate.DateElementList.Count > 0)
                        myPriceDateList.Add(tempPriceDate);
                }

            }
        }

        priceDates.Sort(delegate(PriceDate c1, PriceDate c2) { return (c1.DateElementList[0].CompareTo(c2.DateElementList[0])); });

        PriceDateList = priceDates;// seasonFareList.Items;
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

    protected void btn_Continue_Click(object sender, EventArgs e)
    {

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

        //int parentIndex = ((DataListItem)((UpdatePanel)((DataList)e.Item.Parent).Parent.Parent).Parent).ItemIndex;
        int parentIndex = ((DataListItem)((DataList)e.Item.Parent).Parent).ItemIndex;
        int index = e.Item.ItemIndex;
        if (e.CommandName == "SelectDate")
        {
        }
    }

    private void InitBinderInfo()
    {
        if (!IsSearchConditionNull)
        {
            List<PriceDate> tempPriceDates = PriceDateList;
            tempPriceDates.Sort(delegate(PriceDate c1, PriceDate c2) { return (c1.LowFare.CompareTo(c2.LowFare)); });
            DateTime date = tempPriceDates[0].DateElementList[0];
            TourProfile tourProfile = (TourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile;
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
                DefaultPrice = (Decimal)tourProfile.GetPrice(date, RoomType, ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Adult)
                            + (Decimal)tourProfile.GetPrice(date, RoomType, ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Adult);

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
                dlTourRoomTypeList.DataSource = dt;
                dlTourRoomTypeList.DataBind();
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

    protected void btn_back_Click(object sender, EventArgs e)
    {
        if (ReturnURL.Equals("TourIndex.aspx"))
            Response.Redirect("~/" + ReturnURL);
        else
            Response.Redirect(ReturnURL + "?ConditionID=" + Request.Params["ConditionID"]);
    }

    private InsuranceMaterial SetInsurance()
    {
        Terms.Sales.Business.InsuranceSearchCondition Condition = new Terms.Sales.Business.InsuranceSearchCondition();

        Condition.InsuranceType = TERMS.Common.InsuranceType.Tour;

        Condition.DepartureDate = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).BeginDate;
        Condition.ReturnDate = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).EndDate;

        Condition.TravelerCount = 1;//((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).AdultNumber + ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).ChildNumber;

        Condition.TotalTripCost = 0M;// ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).TotalPrice;


        InsuranceMaterial insuranceMaterial = this.OnSearchInsurance(Condition);

        return insuranceMaterial;
    }

    protected void btn_button_Click(object sender, EventArgs e)
    {
        if (checkDepDate.Checked)
        {
            GoToNewIncentiveOrder();
        }
        else
        {
            BindSeason();
            if (!CheckSelectRooms())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "TourWarting", "<script language=javascript>alert('Please choose room number');</script>");
                return;
            }
            if (IsDate(this.txtDate.Text))
            {
                //DateTime date = Convert.ToDateTime(Request.Params["ctl00$MainContent$txtDate"]);
                DateTime date = Convert.ToDateTime(this.txtDate.Text);
                ((TourSearchCondition)this.Transaction.CurrentSearchConditions).FlightDeptDate = date;
                TourProfile tourProfile = (TourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile;

                TourOrderItem tourOrderItem = new TourOrderItem(tourProfile);
                AirMaterial am = null;
                for (int i = 0; i < ((TourMaterial)tourMerchandise.DefaultTourMaterial).Items.Count; i++)
                {

                    if (((TourMaterial)tourMerchandise.DefaultTourMaterial).Items[i] is TourItinerary)
                        tourOrderItem.Add(((TourMaterial)tourMerchandise.DefaultTourMaterial).Items[i]);
                    else
                    {
                    }

                }
                tourOrderItem.Destination = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile).StartCity;
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
                            tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, tourRoom.RoomType, ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Adult)
                                               + (Decimal)tourProfile.GetPrice(date, tourRoom.RoomType, ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Adult);
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
                    if (tourMerchandise.DefaultTourProduct.AirGroup.Profile.SearchRules.Count > 0)
                    {
                        AirSearchRule airSearchRule = (AirSearchRule)tourMerchandise.DefaultTourProduct.AirGroup.Profile.SearchRules[0];
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

                this.Response.Redirect("TourSelectAirForm.aspx?ReturnURL=" + ReturnURL + "&ConditionID=" + Request.Params["ConditionID"]);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "TourWarting", "<script language=javascript>alert('Please choose departure date');</script>");
                return;
            }
        }
    }

    private bool CheckSelectRooms()
    {
        bool result = false;

        for (int i = 0; i < dlTourRoomTypeList.Items.Count; i++)
        {
            if (((DropDownList)dlTourRoomTypeList.Items[i].FindControl("dllRooms")).SelectedIndex > 0)
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

    protected void btn_PriceChanged_Click(object sender, EventArgs e)
    {
        //if (!IsSearchConditionNull)
        //{
        TourProfile tourProfile = (TourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile;
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
            DefaultPrice = (Decimal)tourProfile.GetPrice(date, RoomType, ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetAmount(TERMS.Common.PassengerType.Adult)
                        + (Decimal)tourProfile.GetPrice(date, RoomType, ((TourSearchCondition)Transaction.CurrentSearchConditions).IsLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Adult);
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
            dlTourRoomTypeList.DataSource = dt;
            dlTourRoomTypeList.DataBind();
        }
    }

    protected void lbtnMore_Click(object sender, EventArgs e)
    {
        if (MaxMonthNumber == 6)
        {
            Session["MaxMonthNumber"] = 12;
            lbtnMore.Text = "Hide";
            Initial();
        }
        else
        {
            Session["MaxMonthNumber"] = 6;
            lbtnMore.Text = "More";
            Initial();
        }
    }

    private int GetOrderNumber(DateTime date)
    {
        if (Orders.Count == 0)
        {
            string tourcode = ((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile.Code;

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

    private void GoToNewIncentiveOrder()
    {
        lblErrorMsg.Visible = false;

        string pax = txtPax.Text.Trim();
        string deptdate = txtDepDate.Text.Trim();
        string contact = txtContactPerson.Text.Trim();
        string email = txtEmail.Text.Trim();
        string language = txtLanguage.Text.Trim();
        string tel = txtTel.Text.Trim();
        string tourcode = ((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile.Code;
        string membercode = Utility.Transaction.Member.MemberCode;

        IList list = m_SubIncentiveTourConfigService.Find(tourcode, true, false);

        SubIncentiveTourConfigMeta meta = (SubIncentiveTourConfigMeta)list[0];

        int paxNumber = 0;

        DateTime DeptDate = DateTime.MinValue;

        try
        {
            paxNumber = Convert.ToInt32(pax);

            int iPax = Convert.ToInt32(meta.MinPax);

            if (iPax > paxNumber)
            {
                lblErrorMsg.Text = "must be greater than " + iPax.ToString() + " pax";
                lblErrorMsg.Visible = true;
                return;
            }
        }
        catch
        {
            lblErrorMsg.Text = "Pax Format Error";
            lblErrorMsg.Visible = true;
            return;
        }

        try
        {            
            DeptDate = Convert.ToDateTime(deptdate);


            TimeSpan span = DeptDate.Subtract(DateTime.Now);
            int days = span.Days;

            int iDays = Convert.ToInt32(meta.MinDate);

            if (iDays > days)
            {
                lblErrorMsg.Text = "must be greater than " + iDays.ToString() + " depdate";
                lblErrorMsg.Visible = true;
                return;
            }
        }
        catch
        {
            lblErrorMsg.Text = "Departure date Format Error";
            lblErrorMsg.Visible = true;
        }

        if (!Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
        {
            lblErrorMsg.Text = "Email Format Error";
            lblErrorMsg.Visible = true;
            return;
        }

        if (string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(language) || string.IsNullOrEmpty(tel))
        {
            lblErrorMsg.Text = "Please fill out all data";
            lblErrorMsg.Visible = true;
            return;
        }
        
        OrderMaterialSubIncentiveTourMeta metaNew = new OrderMaterialSubIncentiveTourMeta();

        metaNew.ContactPerson = contact;
        metaNew.DeptDate = DeptDate;
        metaNew.Email = email;
        metaNew.Id = new Guid();
        metaNew.LanguageSpeaking = language;
        metaNew.MemberCode = membercode;
        metaNew.Pax = paxNumber;
        metaNew.Tel = tel;
        metaNew.TourCode = tourcode;
        metaNew.Remark = txtRemark.Value;

        m_SubIncentiveTourService.Add(metaNew);

        Session["SubMeta"] = metaNew;

        Response.Redirect("SuccessSubIncentiveTourForm.aspx?CaseNumber=" + metaNew.CaseNumber);
    }
}