using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using Terms.Product.Utility;
using Terms.Base.Utility;
using Terms.Material.Service;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Sales.Business;

public partial class Step3_net : AirBook.Base.BookingPage
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

    private int Index
    {
        get
        {
            return (int)CurrentSession.OriginalIndex;
        }
    }
    protected AirMerchandise FlightMerchandise
    {
        get
        {
            return (AirMerchandise)this.OnSearch();
        }
    }

    private AirMerchandise SelectedAirMerchandise //Group
    {
        get
        {
            return (AirMerchandise)((AirMerchandise)FlightMerchandise).Items[Index];
        }
    }


    private const int FIRST_PAGE_LEN = 3;

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.StepNumber = 2;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = true;
        if (SessionExpired)
            Err("The search condition has been removed from cache, please re-search.", "", "Step3_net.aspx");
        else
        {
            if (!Page.IsPostBack)
            {
                Initial();
            }
        }
    }
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }


    private void InitializeComponent()
    {
        this.PreRender += new System.EventHandler(this.Step3_net_PreRender);
    }

    #region User define event

    /// <summary>
    /// Init page
    /// </summary>
    private void Initial()
    {
        InitialResult();
    }


    /// <summary>
    /// Init Result
    /// </summary>
    private void InitialResult()
    {
        //CurrentSession.CurrentItinerary.FareInfo.AdultFare = Group.AdultFare;
        //CurrentSession.CurrentItinerary.FareInfo.ChildFare = Group.ChildFare;
        ItineraryInfo.Itinerary = CurrentSession.CurrentItinerary;

        BindDept(0);
        if (!((AirSearchCondition)this.Transaction.CurrentSearchConditions).FlightType.ToUpper().Equals("ONEWAY"))
        {
            BindRtn(0);
        }
        else
        {
            divRtn.Visible = false;
        }
    }

    private void BindDept(int index)
    {
        PagedDataSource pdsDept = new PagedDataSource();

        pdsDept.DataSource = ((AirMerchandise)SelectedAirMerchandise.Items[0]).Items;
        pdsDept.PageSize = FIRST_PAGE_LEN;
        PageNumber1.PageSize = FIRST_PAGE_LEN;
        pdsDept.AllowPaging = true;
        pdsDept.CurrentPageIndex = index >= 0 ? index : 0;

        PageNumber1.PageAmount = pdsDept.PageCount;

        if (pdsDept.DataSourceCount < FIRST_PAGE_LEN + 1)
            PageNumber1.Visible = false;
        else
            PageNumber1.Visible = true;

        dlDeptTrip.DataSource = pdsDept;
        dlDeptTrip.DataBind();
    }

    private void BindRtn(int index)
    {
        PagedDataSource pdsRtn = new PagedDataSource();

        pdsRtn.DataSource = ((AirMerchandise)SelectedAirMerchandise.Items[1]).Items;
        pdsRtn.PageSize = FIRST_PAGE_LEN;
        PageNumber2.PageSize = FIRST_PAGE_LEN;
        pdsRtn.AllowPaging = true;
        pdsRtn.CurrentPageIndex = index >= 0 ? index : 0;

        PageNumber2.PageAmount = pdsRtn.PageCount;

        if (pdsRtn.DataSourceCount < FIRST_PAGE_LEN + 1)
            PageNumber2.Visible = false;
        else
            PageNumber2.Visible = true;

        dlRtnTrip.DataSource = pdsRtn;
        dlRtnTrip.DataBind();
    }
    private void GetAirBookingCondition(ref IList<Passenger> passengers)
    {

        AirMaterial airMaterial = new AirMaterial(SelectedAirMerchandise.Profile);
        airMaterial.SetAdultBaseFare(SelectedAirMerchandise.AdultBaseFare);
        airMaterial.SetChildBaseFare(SelectedAirMerchandise.ChildBaseFare);

        //ADD PengZhaohui
        TERMS.Common.Markup markup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(SelectedAirMerchandise.AdultMarkup));
        markup.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(SelectedAirMerchandise.ChildMarkup));

        airMaterial.Price.SetMarkup(markup);
        //airMaterial.Price.AddMarkup(new TERMS.Common.Markup(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(SelectedAirMerchandise.ChildMarkup)));
        //ADD END

        if (Request["rdDept"] != null)
        {
            //IList<Terms.Product.Domain.ComponentGroupItem> componentGroupItems = ((AirComponentGroup)((ComponentGroup)CurrentSession.SecondSearchResults[Index.ToString()]).Items[0].Component).Items;
            //airBooking.AdultNumber =((AirProfile) Group.Profile).AdultNumber;
            //airBooking.ChildNumber = ((AirProfile)Group.Profile).ChildNumber;



            //airBooking.IsMexico = CurrentSession.SearchCondition.IsMexico;
            //airBooking.FareType = ((AirProfile)Group.Profile).FareType.ToUpper().Equals("COMM") ? FlightFareType.COMM : FlightFareType.NET;
            //airBooking.AdultAirFare.SetConsolidatorBase(0, Group.AdultBaseFare, airBooking.FareType);
            //airBooking.AdultAirFare.SetConsolidatorMarkup(Group.AdultMarkup, airBooking.FareType == FlightFareType.COMM);
            //airBooking.ChildAirFare.SetConsolidatorBase(0, Group.ChildBaseFare, airBooking.FareType);
            //airBooking.ChildAirFare.SetConsolidatorMarkup(Group.ChildMarkup, airBooking.FareType == FlightFareType.COMM);
            //componentGroup.SetAdultConsolidatorBase(0, componentGroup.AdultBaseFare);
            //componentGroup.SetChildConsolidatorBase(0, componentGroup.ChildBaseFare);
            //componentGroup.SetConsolidatorAdultMarkup(componentGroup.AdultMarkup, componentGroup.FareType == FlightFareType.COMM);
            //componentGroup.SetConsolidatorChildMarkup(componentGroup.ChildMarkup, componentGroup.FareType == FlightFareType.COMM);
            //AirTrip airTrip = ((Terms.Product.Domain.AirMaterial)componentGroupItems[Convert.ToInt32(Request["rdDept"].ToString())].Component).AirTrip;
            //airBooking.Trips.Add(airTrip);

            //AirComponentGroup gourp = new AirComponentGroup((AirProfile)((ComponentGroup)CurrentSession.SecondSearchResults[Index.ToString()]).Profile);
            //gourp.Items.Add(componentGroupItems[Convert.ToInt32(Request["rdDept"].ToString())]);

            AirMaterial depAirMaterial =(AirMaterial) ((AirMerchandise)SelectedAirMerchandise.Items[0]).Items[Convert.ToInt32(Request["rdDept"].ToString())];

            airMaterial.AirTrip.SubTrips.Add(depAirMaterial.AirTrip.SubTrips[0]);
            



        }

        if (Request["rdRtn"] != null && !((AirSearchCondition)this.Transaction.CurrentSearchConditions).FlightType.ToUpper().Equals("ONEWAY"))
        {

            //IList<Terms.Product.Domain.ComponentGroupItem> componentGroupItems = ((AirComponentGroup)((ComponentGroup)CurrentSession.SecondSearchResults[Index.ToString()]).Items[1].Component).Items;
            //AirTrip airTrip = ((Terms.Product.Domain.AirMaterial)componentGroupItems[Convert.ToInt32(Request["rdRtn"].ToString())].Component).AirTrip;
            //airBooking.Trips.Add(airTrip);

            //AirComponentGroup gourp = new AirComponentGroup((AirProfile)((ComponentGroup)CurrentSession.SecondSearchResults[Index.ToString()]).Profile);
            //gourp.Items.Add(componentGroupItems[Convert.ToInt32(Request["rdRtn"].ToString())]);
            //componentGroup.Items.Add(new ComponentGroupItem(gourp));

            AirMaterial depAirMaterial = (AirMaterial)((AirMerchandise)SelectedAirMerchandise.Items[1]).Items[Convert.ToInt32(Request["rdRtn"].ToString())];

            airMaterial.AirTrip.SubTrips.Add(depAirMaterial.AirTrip.SubTrips[0]);
        }
        //ComponentGroupItem componentGroupItem = new ComponentGroupItem(componentGroup);

        //ComponentGroup newComponentGroup = new ComponentGroup(((ComponentGroup)PackageMerchandise.ComponentGroup.Items[0].Component).Profile);
        //newComponentGroup.Items.Add(componentGroupItem);
        //SaleMerchandise saleMerchandise = new SaleMerchandise();
        //saleMerchandise.ComponentGroup = newComponentGroup;
        //this.Transaction.CurrentTransactionObject.Items.Clear();
        //this.Transaction.CurrentTransactionObject.AddItem(saleMerchandise);
        AirOrderItem airOrderItem = new AirOrderItem(airMaterial);
       
        this.Transaction.CurrentTransactionObject.Items.Clear();
        this.Transaction.CurrentTransactionObject.AddItem(airOrderItem);

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
    #endregion

    protected void dlFlightTours_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl_DeptOrRtn = (Label)e.Item.FindControl("lbl_DeptOrRtn");

            if (e.Item.ItemIndex == 0)
                lbl_DeptOrRtn.Text = "Outbound Itinerary";
            else
                lbl_DeptOrRtn.Text = "Inbound Itinerary";

        }
    }

    protected void dlDeptTrip_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int index = e.Item.ItemIndex + PageNumber1.PageSize * PageNumber1.CurrentPageIndex;
            Label lbl_radio = (Label)e.Item.FindControl("lbl_radio");
            string isChecked = string.Empty;
            if (index % FIRST_PAGE_LEN == 0)
            {
                isChecked = "checked";
            }
            lbl_radio.Text = "<input type=\"radio\" name=\"rdDept\" id=\"rdDept" + index + "\" value=\"" + index + "\" " + isChecked + ">";
        }
    }

    protected void dlRtnTrip_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int index = e.Item.ItemIndex + PageNumber2.PageSize * PageNumber2.CurrentPageIndex;
            Label lbl_radio = (Label)e.Item.FindControl("lbl_radio");
            string isChecked = string.Empty;
            if (index % FIRST_PAGE_LEN == 0)
            {
                isChecked = "checked";
            }
            lbl_radio.Text = "<input type=\"radio\" name=\"rdRtn\" id=\"rdRtn" + index + "\" value=\"" + index + "\" " + isChecked + ">";
        }
    }
    protected void btn_book_Click(object sender, EventArgs e)
    {
        if (SessionExpired)
            Err("The search condition has been removed from cache, please re-search.", "", "Step3_net.aspx");
        else
        {

            IList<Passenger> passengers = new List<Passenger>();
            try
            {

                GetAirBookingCondition(ref passengers);
            }
            catch (Exception E)
            {
                log.Error(E.Message, E);
            }
            AirMaterial airMaterial = (AirMaterial)((TERMS.Business.Centers.SalesCenter.AirOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).Merchandise;

            bool bclError = false;


            try
            {
                string[] requestXML = new string[3];
                //ws.PreBookAirline(ref group, SearchArray, requestXML);
                AirService.PreBookAirline(ref airMaterial, passengers);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                bclError = true;
            }

            if (bclError)
                this.Err("Sorry, can not booking the routing.  please choose others routing again.", "", "Step3_net.aspx");

            SessionClass sc = (SessionClass)Session["CurrentSession"];
            //AirComponentGroup airGroup = ((AirComponentGroup)group.Items[0].Component);
            //CurrentSession.CurrentAirBooking = airBooking;
            //CurrentSession.CurrentItinerary.FareInfo.AdultFare = airGroup.TotalAdultConsolidatorBase + airGroup.TotalConsolidatorAdultMarkup;
            //CurrentSession.CurrentItinerary.FareInfo.ChildFare = airGroup.TotalChildConsolidatorBase + airGroup.TotalConsolidatorChildMarkup;

            //AirTrip airTrip = new AirTrip();


            //if (airGroup.FareType == FlightFareType.COMM || airGroup.FareType == FlightFareType.NET)
            //{
            //    foreach (ComponentGroupItem groupItem1 in airGroup.Items)
            //    {
            //        foreach (ComponentGroupItem groupItem2 in ((AirComponentGroup)groupItem1.Component).Items)
            //        {
            //            foreach (SubAirTrip subAirTrip in ((AirMaterial)groupItem2.Component).AirTrip.SubTrips)
            //            {
            //                airTrip.SubTrips.Add(subAirTrip);
            //            }
            //        }
            //    }

            //}
            //else if (airGroup.FareType == FlightFareType.SR || airGroup.FareType == FlightFareType.PUB)
            //{
            //    foreach (ComponentGroupItem groupItem in airGroup.Items)
            //    {
            //        foreach (SubAirTrip subAirTrip in ((AirMaterial)groupItem.Component).AirTrip.SubTrips)
            //        {
            //            airTrip.SubTrips.Add(subAirTrip);
            //        }
            //    }

            //}

            //CurrentSession.CurrentItinerary.FlightInfo = airTrip;
            Response.Redirect("Step3_confirm.aspx");
        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        if (SessionExpired)
            Err("The search condition has been removed from cache, please re-search.", "", "Step3_net.aspx");
        else
            Response.Redirect("Step2.aspx");

    }
    /// <summary>
    /// PreRender Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Step3_net_PreRender(object sender, EventArgs e)
    {
        BindDept(PageNumber1.CurrentPageIndex);
        if (!((AirSearchCondition)this.Transaction.CurrentSearchConditions).FlightType.ToUpper().Equals("ONEWAY"))
            BindRtn(PageNumber2.CurrentPageIndex);
    }

}