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

using Terms.Base.Utility;
using Terms.Product.Utility;

using Terms.Material.Service;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Business.Centers.ProductCenter.Profiles;
public partial class Step3_confirm : AirBook.Base.BookingPage
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
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.StepNumber = 2;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = true;
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (Utility.IsLogin)
        {
            this.divSignIn.Visible = false;
           // this.P_table.Visible = true;
        }
        else
        {
            //设定回车键默认控件为Login
            Button btn = (Button)UserLoginControl1.FindControl("btnLogin");
            this.Form.DefaultButton = btn.UniqueID;
            TextBox txtUser = (TextBox)UserLoginControl1.FindControl("txtUserName");

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "SetCalendarMainArray", "<script>document.getElementById('ctl00$MainContent$UserLoginControl1$txtUserName').focus(); </script>");

            UserLoginControl1.NextUrl = "~/Page/Common/TravelerForm.aspx";
            UserLoginControl1.ReturnUrl = "~/Page/Flight/Step3_confirm.aspx";
            this.divSignIn.Visible = true;
            //this.P_table.Visible = false;
        }

        UserLoginControl1.loginClick = DoContinueProcess;

        if (SessionExpired)
            Err(Resources.HintInfo.TheResearch, "", "Step3_bulk.aspx");
        else
        {
            if (!Page.IsPostBack)
            {

                Initial();
            }
        }
    }

    #region User define event

    /// <summary>
    /// Init page
    /// </summary>
    private void Initial()
    {
        
        //ItineraryInfo.IsShowFareDetail = true;
       // ItineraryInfo.IsShowFlightInfo = true;
        Itinerary itinerary = new Itinerary();
        itinerary = CurrentSession.CurrentItinerary;
       // ItineraryInfo.Itinerary = itinerary;
        //FlightDetailsControl1.Itinerary = itinerary;
        //FlightDetailsControl1.BinderFlight();
    }
    #endregion

    protected void btn_button_Click(object sender, EventArgs e)
    {
        if (SessionExpired)
            Err(Resources.HintInfo.TheResearch, "", "Step3_confirm.aspx");
        else
        {
            DoContinueProcess();

        }
    }

    #region user define
    private void GetAirBookingCondition( AirMaterial airMaterial,ref IList<TERMS.Business.Centers.SalesCenter.Passenger> passengers)
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
    #endregion

    public void DoContinueProcess()
    {
        //AirMaterial airMaterial = (AirMaterial)((TERMS.Business.Centers.SalesCenter.AirOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).Merchandise;

        //IList<Passenger> passengers = new List<Passenger>();
        //if (((AirProfile)airMaterial.Profile).GetParam("FARE_TYPE").Equals(FlightFareType.SR.ToString()) || ((AirProfile)airMaterial.Profile).GetParam("FARE_TYPE").Equals(FlightFareType.PUB.ToString()))
        //{
        //    GetAirBookingCondition(airMaterial, ref passengers);
        //    bool bclException = false;
        //    string strMessage = string.Empty;
        //    try
        //    {
        //        AirService.PreBookAirline(ref airMaterial, passengers);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message, ex);
        //        bclException = true;
        //        strMessage = ex.Message;
        //    }

        //    if (bclException)
        //    {
        //        Err(strMessage, "Booking failed", "Step_confirm.aspx");
        //    }

        //}

        if (PriceInfoControl1.AddMarkup())
            Response.Redirect("~/Page/Common/TravelerForm.aspx?ConditionID=" + Request.Params["ConditionID"]);
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {

        if (SessionExpired)
            Err("The search condition has been removed from cache, please re-search.", "", "Step3_confirm.aspx");
        else
        {
            //if (((TERMS.Business.Centers.SalesCenter.AirOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).Merchandise.Profile.GetParam("FARE_TYPE").Equals(FlightFareType.COMM.ToString()) || ((TERMS.Business.Centers.SalesCenter.AirOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).Merchandise.Profile.GetParam("FARE_TYPE").Equals(FlightFareType.NET.ToString()))
            //    Response.Redirect("Step3_net.aspx");
            //else
            Response.Redirect("NewStep2.aspx?ConditionID=" + Request.Params["ConditionID"]);
        }
    }
}