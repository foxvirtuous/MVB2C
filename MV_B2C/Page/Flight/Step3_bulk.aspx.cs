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
using TERMS.Business.Centers.ProductCenter.Profiles;
public partial class Step3_bulk : AirBook.Base.BookingPage
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

    public FlightInfoHider flightInfohider = new FlightInfoHider();

    private bool rePageNumber = false;
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

    /// <summary>
    /// 隐藏飞机信息的标志，true代表隐藏，false代表不隐藏，默认false
    /// </summary>
    private bool HideFlightInfoFlag
    {
        get
        {
            if (ViewState["HideFlightInfoFlag"] == null)
                ViewState["HideFlightInfoFlag"] = false;

            return Convert.ToBoolean(ViewState["HideFlightInfoFlag"]);
        }
        set { ViewState["HideFlightInfoFlag"] = value; }
    }

    public string FareType
    {
        get { return Request.QueryString["FARE_TYPE"]; }
    }

    private const int FIRST_PAGE_LEN = 3;

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.StepNumber = 2;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = true;
        if (SessionExpired)
            Err("The search condition has been removed from cache, please re-search.", "", "Step3_bulk.aspx");
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
        this.PreRender += new System.EventHandler(this.Step3_bulk_PreRender);
    }
    #region User define event

    /// <summary>
    /// Init page
    /// </summary>
    private void Initial()
    {
        InitialResult();

        this.ItineraryInfo.IsShowFareDetail = true;

        Bind(0);
    }


    /// <summary>
    /// Init Result
    /// </summary>
    private void InitialResult()
    {

        CurrentSession.CurrentItinerary.FareInfo.SetAmount(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(SelectedAirMerchandise.AdultBaseFare, new TERMS.Common.Currency(), new TERMS.Common.Currency()));
        CurrentSession.CurrentItinerary.FareInfo.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(SelectedAirMerchandise.ChildBaseFare, new TERMS.Common.Currency(), new TERMS.Common.Currency()));

        TERMS.Common.Markup markup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(SelectedAirMerchandise.AdultMarkup));
        markup.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(SelectedAirMerchandise.ChildMarkup));
        CurrentSession.CurrentItinerary.FareInfo.SetMarkup(markup);
        //CurrentSession.CurrentItinerary.FareInfo.AddMarkup(new TERMS.Common.Markup(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(SelectedAirMerchandise.ChildMarkup, new TERMS.Common.Currency(), new TERMS.Common.Currency())));

        ItineraryInfo.Itinerary = CurrentSession.CurrentItinerary;
    }

    private void Bind(int index)
    {
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = SelectedAirMerchandise.Items;
        pds.PageSize = FIRST_PAGE_LEN;
        PageNumber1.PageSize = FIRST_PAGE_LEN;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = index >= 0 ? index : 0;

        PageNumber1.PageAmount = pds.PageCount;
        if (pds.DataSourceCount < FIRST_PAGE_LEN + 1)
            PageNumber1.Visible = false;
        else
            PageNumber1.Visible = true;

        dlFlightTours.DataSource = pds;
        dlFlightTours.DataBind();
    }
    #endregion

    protected void dlFlightTours_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int index = e.Item.ItemIndex + PageNumber1.PageSize * PageNumber1.CurrentPageIndex;
            string isChecked = string.Empty;
            if (index % FIRST_PAGE_LEN == 0)
            {
                isChecked = "checked";
            }
            Label lbl_SelectRadio = (Label)e.Item.FindControl("lbl_SelectRadio");
            Label lbl_SelectNo = (Label)e.Item.FindControl("lbl_SelectNo");

            lbl_SelectRadio.Text = "<input  type=\"radio\" value=\"" + index + "\" name=\"selectedTour\" " + isChecked + "/>";
            lbl_SelectNo.Text = (index + 1).ToString();

            if (index % FIRST_PAGE_LEN == 2)
            {
                HtmlTable table = (HtmlTable)e.Item.FindControl("tableLine");
                table.Visible = false;
            }

            Label lbDispMessage = (Label)e.Item.FindControl("lbDispMessage");

            if (HideFlightInfoFlag)
            {
                if (lbDispMessage != null)
                {
                    lbDispMessage.Text = FlightInfoHider.DISP_MESSAGE;
                    lbDispMessage.Visible = true;
                }
            }
            else
            {
                lbDispMessage.Visible = false;
            }
        }
    }

    protected void dlFlights_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int index = e.Item.ItemIndex + PageNumber1.PageSize * PageNumber1.CurrentPageIndex;
            Label tr = (Label)e.Item.FindControl("Mytr");

            if (((DataListItem)((DataList)e.Item.Parent).Parent).ItemIndex % 2 == 0)
                tr.Text = "<tr align=\"left\"  class =\"R_stepw\">";
            else
                tr.Text = "<tr align=\"left\"  class =\"R_stepg\">";

            if (flightInfohider.IsNeedToHide(((AirProfile)SelectedAirMerchandise.Profile).Airlines[0].Code.Trim().ToString(), SelectedAirMerchandise.Profile.GetParam("FARE_TYPE").ToString()))
            {
                //((Label)e.Item.FindControl("lblAirName")).Visible = true;
                ((Label)e.Item.FindControl("lbl_AirCode")).Text = flightInfohider.ReplaceFlightName(((AirProfile)SelectedAirMerchandise.Profile).Airlines[0].Code.Trim().ToString(), SelectedAirMerchandise.Profile.GetParam("FARE_TYPE").ToString());
                ((Label)e.Item.FindControl("Label3")).Text = flightInfohider.TimeToName(((Label)e.Item.FindControl("lblDepDate")).Text.Substring(0, 8)) + ((Label)e.Item.FindControl("Label3")).Text;
                ((Label)e.Item.FindControl("Label6")).Text = flightInfohider.TimeToName(((Label)e.Item.FindControl("lblArrDate")).Text.Substring(0, 8)) + ((Label)e.Item.FindControl("Label6")).Text;
                ((Label)e.Item.FindControl("lblBookClass")).Visible = false;
                ((Label)e.Item.FindControl("lblFlightNo")).Visible = false;
                //((Label)e.Item.FindControl("lbl_AirCode")).Visible = false;
                ((Label)e.Item.FindControl("lblDepDate")).Visible = false;
                ((Label)e.Item.FindControl("lblArrDate")).Visible = false;

                HideFlightInfoFlag = true;
            }
            else
            {
                //((Label)e.Item.FindControl("lblAirName")).Visible = false;
                ((Label)e.Item.FindControl("Label3")).Visible = false;
                ((Label)e.Item.FindControl("Label6")).Visible = false;
                ((Label)e.Item.FindControl("lblBookClass")).Visible = true;
                ((Label)e.Item.FindControl("lblFlightNo")).Visible = true;
                //((Label)e.Item.FindControl("lbl_AirCode")).Visible = true;
                ((Label)e.Item.FindControl("lblDepDate")).Visible = true;
                ((Label)e.Item.FindControl("lblArrDate")).Visible = true;
            }
        }
    }


    protected void btnContinue_Click(object sender, EventArgs e)
    {
        if (SessionExpired)
            Err("The search condition has been removed from cache, please re-search.", "", "Step3_bulk.aspx");
        else if (SelectedAirMerchandise.Profile.GetParam("FARE_TYPE").Equals(FlightFareType.SR.ToString()) || SelectedAirMerchandise.Profile.GetParam("FARE_TYPE").Equals(FlightFareType.PUB.ToString()))
        {
            int tourIndex = Convert.ToInt32(Request["selectedTour"].ToString());

            AirMaterial airMaterial = (AirMaterial)SelectedAirMerchandise.Items[tourIndex];



            AirOrderItem airOrderItem = new AirOrderItem(airMaterial);


            this.Transaction.CurrentTransactionObject.Items.Clear();
            this.Transaction.CurrentTransactionObject.AddItem(airOrderItem);
            
        }
        else
        {
            AirMaterial airMaterial = (AirMaterial)SelectedAirMerchandise.Items[Index];
            IList<Passenger> passengers = new List<Passenger>();
            try
            {

                GetAirBookingCondition(ref passengers,airMaterial);
            }
            catch (Exception E)
            {
                log.Error(E.Message, E);
            }
            //AirMaterial airMaterial = (AirMaterial)((TERMS.Business.Centers.SalesCenter.AirOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).Merchandise;

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
                this.Err("Sorry, can not booking the routing.  please choose others routing again.", "", "Step3_bulk.aspx");
           
        }
        Response.Redirect("Step3_confirm.aspx");
    }

    /// <summary>
    /// PreRender Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Step3_bulk_PreRender(object sender, EventArgs e)
    {
        if (!rePageNumber)
            Bind(PageNumber1.CurrentPageIndex);
        else
        {
            this.PageNumber1.DrawingNum();
            Bind(0);
        }

        //BODY.Attributes["onload"] = "toggleNLayer('" + ADVANCEDOPTION + "',1);ChangeFlightType('" + ONEWAYFLAG.ToLower() + "');";
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        if (SessionExpired)
            Err("The search condition has been removed from cache, please re-search.", "", "Step3_bulk.aspx");
        else
            Response.Redirect("Step2.aspx");
    }

    private void GetAirBookingCondition(ref IList<Passenger> passengers,AirMaterial airMaterial)
    {

        //AirMaterial newAirMaterial = new AirMaterial(SelectedAirMerchandise.Profile);
        //newAirMaterial.SetAdultBaseFare(SelectedAirMerchandise.AdultBaseFare);
        //newAirMaterial.SetChildBaseFare(SelectedAirMerchandise.ChildBaseFare);

        ////ADD PengZhaohui
        //TERMS.Common.Markup markup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(SelectedAirMerchandise.AdultMarkup));
        //markup.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(SelectedAirMerchandise.ChildMarkup));

        //newAirMaterial.Price.SetMarkup(markup);

        ////newAirMaterial.Price.AddMarkup(new TERMS.Common.Markup(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(SelectedAirMerchandise.ChildMarkup)));
       
        ////ADD END

        //int tourIndex = Convert.ToInt32(Request["selectedTour"].ToString());

        //AirMaterial airMaterial = (AirMaterial)SelectedAirMerchandise.Items[tourIndex];

        //decimal distributeAdultMarkup = airMaterial.GetPrice().GetMarkup(TERMS.Common.PassengerType.Adult, "DISTRIBUTE_MARKUP");
        //decimal distributeChildMarkup = airMaterial.GetPrice().GetMarkup(TERMS.Common.PassengerType.Child, "DISTRIBUTE_MARKUP");

        

        //newAirMaterial.AirTrip = airMaterial.AirTrip;
        //int adultNumber = Convert.ToInt32(SelectedAirMerchandise.Profile.GetParam("ADULT_NUMBER"));
        //int childNumber = Convert.ToInt32(SelectedAirMerchandise.Profile.GetParam("CHILD_NUMBER"));

        //airMaterial.Profile.SetParam("ADULT_NUMBER",adultNumber);
        //airMaterial.Profile.SetParam("CHILD_NUMBER",childNumber);
        airMaterial.Profile = SelectedAirMerchandise.Profile;

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
}