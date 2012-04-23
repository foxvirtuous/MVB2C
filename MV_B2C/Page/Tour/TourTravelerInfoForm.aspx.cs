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
using Terms.Sales.Service;
using GTTWSpanClient.Message;
using System.Collections.Generic;
using TERMS.Common;
using Terms.Material.Service;
using TERMS.Business.Centers.ProductCenter.Components;

public partial class TourTravelerInfoForm : SalseBasePage
{
    private SaleOrderService m_SaleOrderService;

    protected SaleOrderService SaleOrderService
    {
        set
        {
            m_SaleOrderService = value;
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

    private List<string> adults = new List<string>();
    private List<string> childs = new List<string>();

    private List<object> adultss = new List<object>();
    private List<object> childss = new List<object>();

    private List<AirLeg> m_AirLegList = new List<AirLeg>();

    protected List<AirLeg> AirLegList
    {
        get
        {
            return m_AirLegList;

        }
        set
        {
            m_AirLegList = value;
        }
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

    private AirOrderItem m_NewAirOrderItem;

    protected AirOrderItem NewAirOrderItem
    {
        get
        {
            return m_NewAirOrderItem;

        }
        set
        {
            m_NewAirOrderItem = value;
        }
    }

    private bool isFinished = false;

    public bool IsFinished
    {
        get
        {
            return isFinished;
        }
        set
        {
            isFinished = value;
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


    protected void Page_Load(object sender, EventArgs e)
    {
        Header1.Path = "../../";
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        this.SetWebSiteInfomation();
        StatesControl1.PageCode = 3;
        if (((TourOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).IsInsurance)
            PriceInfoControl1.IsTourInsurance = true;
        if (!IsPostBack)
        {
            //InitSet();
            SetValidationGroup();

            //SetInsurance();
            ////this.FlightHeader1.BindDate();

            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                divPNR.Visible = true;
            }
            else
            {
                divPNR.Visible = false;
            }
        }    
    }
    protected void btn_button_Click(object sender, EventArgs e)
    {
        bool flag = false;
        Utility.Transaction.CurrentTransactionObject.Remark = this.txtRemark.Value;
        if (OrderPassengerInfoControl1.PaddingPassengerInfo())
        {
            if (ContactInfoControl1.PaddingPassengerInfo())
            {
                if (!m_SaleOrderService.MoreOrders(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member))
                {
                    flag = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>alert('Your ordering information with the number of orders for the xxxxxx duplication, please contact customer service 1-888-288-7528.')</script>");
                    return;
                }
            }
        }

        //bool isMore = m_SaleOrderService.MoreOrders(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);

        if (flag)
        {
            this.SendEmailTourControl1.ReBinder();
            ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>OnSearch();</script>");
            //IsFinished = true;
            //记录输入顾客信息事件
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.EnterTravels, this);
           
        }
        else
            return;
    }

    private void SetValidationGroup()
    {
        OrderPassengerInfoControl1.ValidationGroup = "PackageCreditForm";
        ContactInfoControl1.ValidationGroup = "PackageCreditForm";
        this.btn_button.ValidationGroup = "PackageCreditForm";
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("TourSelectAirForm.aspx?ReturnURL=" + ReturnURL + "&ConditionID=" + Request.Params["ConditionID"] + "&TourCode=" + SelectTourCode);
    }

    public TourTravelerInfoForm()
    {
        this.PreRender += new EventHandler(TourTravelerInfoForm_PreRender);
    }

    private void TourTravelerInfoForm_PreRender(object sender, EventArgs e)
    {
        if (Request.Params["IsFinised"] != null
            && Request.Params["IsFinised"].ToString().Trim().Length > 0)
        {
           
            Utility.Transaction.EmailVersion = this.flagSearch.Value;
            Response.Redirect("~/page/Common/SaveOrderWaiting.aspx" + "?ConditionID=" + Request.Params["ConditionID"] + "&TourCode=" + SelectTourCode);
        }
    }

    protected void btnLoadPNR_Click(object sender, EventArgs e)
    {
        string pnr = txtPNR.Text;

        pnr = pnr.Replace(";", ",");

        string[] pnrs = pnr.Split(new Char[] { ',' });

        for (int i = Transaction.CurrentTransactionObject.Items.Count - 1; i >= 0; i--)
        {
            if (Transaction.CurrentTransactionObject.Items[i] is AirOrderItem)
            {
                Transaction.CurrentTransactionObject.Items.Remove(Transaction.CurrentTransactionObject.Items[i]);
            }
        }

        List<Object> airs = new List<object>();

        for (int i = 0; i < pnrs.Length; i++)
        {
            m_AirLegList.Clear();
            adults.Clear();
            childs.Clear();

            GetFlights(pnrs[i]);

            airs.Add(m_AirLegList);

            List<string> adultsNew = new List<string>();
            List<string> childsNew = new List<string>();

            for (int index = 0; index < adults.Count; index++)
            {
                adultsNew.Add(adults[index]);
            }

            for (int index = 0; index < childs.Count; index++)
            {
                childsNew.Add(childs[index]);
            }

            adultss.Add(adultsNew);
            childss.Add(childsNew);
        }

        dlAirs.DataSource = airs;
        dlAirs.DataBind();

        for (int i = 0; i < dlAirs.Items.Count; i++)
        {
            GridView gvFlightInfo = (GridView)dlAirs.Items[i].FindControl("gvFlightInfo");
            gvFlightInfo.DataSource = (List<AirLeg>)airs[i];
            gvFlightInfo.DataBind();

            Label lblPassengers = (Label)dlAirs.Items[i].FindControl("lblPassengers");

            if (((List<string>)adultss[i]).Count > 0)
            {
                lblPassengers.Text = lblPassengers.Text + string.Join(", ", ((List<string>)adultss[i]).ToArray());

                if (((List<string>)childss[i]).Count > 0)
                {
                    lblPassengers.Text = lblPassengers.Text + ", " + string.Join(", ", ((List<string>)childss[i]).ToArray());
                }
            }

            Label lblPNR = (Label)dlAirs.Items[i].FindControl("lblPNR");

            lblPNR.Text = pnrs[i];
        }

        OrderPassengerInfoControl1.BindPassenageByPNR(adultss, childss);

        ContactInfoControl1.BindContactByPNR(adultss);
    }

    protected void gvFlightInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = Convert.ToDateTime(e.Row.Cells[2].Text).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }
    }

    protected bool GetFlights(string pnr)
    {
        string errMsg = string.Empty;
        DpwPNR dpwPNR = new DpwPNR();
        bool isMatchAirline = false;
        bool isMatchDeparture = false;
        bool isMatchBeginDate = false;
        bool isMatchEndDate = false;
        string originalAirline = ((TourOrderItem)Transaction.CurrentTransactionObject.Items[0]).AirLine;
        string originalDeparture = ((TourOrderItem)Transaction.CurrentTransactionObject.Items[0]).DepartureCity;
        //string originalDestination= ((TourOrderItem)Transaction.CurrentTransactionObject.Items[0]).;
        DateTime originalBeginDate = ((TourOrderItem)Transaction.CurrentTransactionObject.Items[0]).BeginDate;
        DateTime originalEndDate = ((TourOrderItem)Transaction.CurrentTransactionObject.Items[0]).EndDate;
        if (pnr.Equals(string.Empty))
        {
            errMsg = "Please Input PNR";

        }
        else if (pnr.Length != 6)
        {
            errMsg = "Please Input Correct PNR";

        }
        else
        {
            dpwPNR = m_airService.GetPnrData(pnr, out errMsg);

        }
        if (errMsg.Equals(string.Empty))
        {
            DpwFlightList flights = dpwPNR.Flights;

            AirMaterial airMaterial = new AirMaterial(new TERMS.Core.Profiles.Profile("air"));
            //int[] divideNumber =


            Hashtable timeSpan = new Hashtable();
            List<AirLeg> airLegList = m_AirLegList;
            bool isOneWay = false;

            if (flights.Count > 0)
            {
                if (!flights[0].DepartureAirport.Equals(flights[flights.Count - 1].ArrivalAirport))
                    isOneWay = true;
            }

            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].Airline.Contains(originalAirline))
                    isMatchAirline = true;
                AirLeg air = new AirLeg();
                air.AirLine = new Airline(flights[i].Airline);
                air.ArriveTime = flights[i].ArrivalDateTime;
                air.BookingClass = flights[i].BookingClass;
                Airport deptAirport = new Airport();
                City deptCity = new City();

                Terms.Common.Domain.Airport airport = m_airService.CommAirportDao.FindByAirport(flights[i].DepartureAirport);
                deptCity.Code = airport.City.Code;
                deptCity.Name = airport.City.Name;
                deptAirport.City = deptCity;
                deptAirport.Name = airport.Name;
                deptAirport.Code = airport.Code;
                air.DepartureAirport = deptAirport;
                air.DepartureTime = flights[i].DepartureDateTime;

                if (i == 0)
                {
                    if (deptCity.Code.Contains(originalDeparture))
                        isMatchDeparture = true;
                    if (air.DepartureTime.ToString("MM/dd/yyyy").Equals(originalBeginDate.ToString("MM/dd/yyyy")))
                        isMatchBeginDate = true;
                }

                Airport destAirport = new Airport();
                City destCity = new City();

                Terms.Common.Domain.Airport airtport2 = m_airService.CommAirportDao.FindByAirport(flights[i].ArrivalAirport);
                destCity.Code = airtport2.City.Code;
                destCity.Name = airtport2.City.Name;
                destAirport.City = destCity;
                destAirport.Name = airtport2.Name;
                destAirport.Code = airtport2.Code;
                air.DestinationAirport = destAirport;
                air.FlightNumber = flights[i].FlightNumber;

                if (i > 0)
                {
                    timeSpan.Add(i.ToString() + "-" + (i + 1).ToString(), flights[i].DepartureDateTime.Subtract(flights[i - 1].ArrivalDateTime));

                }

                airLegList.Add(air);
                //SubAirTrip subAirTrip = new SubAirTrip();
                //subAirTrip.
            }

            if (isOneWay)
            {
                SubAirTrip deptSubAirTrip = new SubAirTrip();
                for (int j = 0; j < airLegList.Count; j++)
                {
                    deptSubAirTrip.AddLeg(airLegList[j]);
                }
                airMaterial.AddSubTrip(deptSubAirTrip);
            }
            else
            {
                TimeSpan bigSpan = new TimeSpan();
                string bigSpanKey = string.Empty;
                foreach (string key in timeSpan.Keys)
                {
                    if (bigSpan.CompareTo(timeSpan[key]) < 0)
                    {
                        bigSpan = (TimeSpan)timeSpan[key];
                        bigSpanKey = key;
                    }
                }

                string[] flightNumber = bigSpanKey.Split('-');


                if (flightNumber.Length == 2)
                {
                    SubAirTrip deptSubAirTrip = new SubAirTrip();
                    SubAirTrip retnSubAirTrip = new SubAirTrip();

                    for (int j = 0; j < airLegList.Count; j++)
                    {
                        if (j <= (Convert.ToInt32(flightNumber[0]) - 1))
                            deptSubAirTrip.AddLeg(airLegList[j]);
                        else
                            retnSubAirTrip.AddLeg(airLegList[j]);

                    }

                    airMaterial.AddSubTrip(deptSubAirTrip);
                    airMaterial.AddSubTrip(retnSubAirTrip);
                    if (retnSubAirTrip.Flights[0].DepartureTime.ToString("MM/dd/yyyy").Equals(originalEndDate.ToString("MM/dd/yyyy")))
                        isMatchEndDate = true;
                }
            }

            m_NewAirOrderItem = new AirOrderItem(airMaterial);

            //Fare
            int fareLength = dpwPNR.FareInfo.Fares.Count;
            for (int fareCount = 0; fareCount < fareLength; fareCount++)
            {
                DpwFare fare = dpwPNR.FareInfo.Fares[fareCount];

                switch (fare.PTC)
                {
                    case GTTWSpanClient.PassengerType.Adult:
                        m_NewAirOrderItem.Merchandise.SetAdultBaseFare(fare.BaseFare);
                        m_NewAirOrderItem.Merchandise.SetAdultTax(fare.Tax);
                        break;
                    case GTTWSpanClient.PassengerType.Child:
                        m_NewAirOrderItem.Merchandise.SetChildBaseFare(fare.BaseFare);
                        m_NewAirOrderItem.Merchandise.SetChildTax(fare.Tax);
                        break;
                    case GTTWSpanClient.PassengerType.Infant:
                        break;
                    default:
                        break;
                }
            }
            m_NewAirOrderItem.WSpanRecordLocator = dpwPNR.RecordLoactor;

            Transaction.CurrentTransactionObject.Items.Add(m_NewAirOrderItem);

            int adultNumber = GetPassengers(dpwPNR.Passengers)[0];
            int childNumber = GetPassengers(dpwPNR.Passengers)[1];

            //TourPriceInfoControl1.Tax = m_NewAirOrderItem.Merchandise.AdultTax * adultNumber + m_NewAirOrderItem.Merchandise.ChildTax * childNumber;
            //TourPriceInfoControl1.ShowTotalPrice = GetNetPrice();// +TourPriceInfoControl1.Tax;
            if (Transaction.CurrentTransactionObject.Items[0].AdultNumber != adultNumber || Transaction.CurrentTransactionObject.Items[0].ChildNumber != childNumber)
            {
                lblError.Text = "PNR’s passenger number is not equal order’s traveler number.";
                return false;
            }
            else
            {
                if (!isMatchAirline)
                {
                    lblError.Text = "Warning: Not default airlines price may be different.";


                    lblError.Style.Add("color", "blue");
                }
                else if (!isMatchDeparture)
                {
                    lblError.Text = "Warning: Not default departure city/destination. Be careful.";
                    lblError.Style.Add("color", "blue");
                }
                else if (!isMatchBeginDate || !isMatchEndDate)
                {
                    lblError.Text = "Warning: Not default departure/return date. Be careful.";
                    lblError.Style.Add("color", "blue");
                }
                else
                {
                    lblError.Style.Add("color", "red");
                }
                return true;
            }



        }
        else
        {
            lblError.Text = errMsg;
            return false;
        }
    }


    protected int[] GetPassengers(DpwPassengerList passengerList)
    {
        adults.Clear();
        childs.Clear();
        int[] passengerNumber = new int[2];
        for (int i = 0; i < passengerList.Count; i++)
        {
            if (passengerList[i].PassengerType.Equals(GTTWSpanClient.PassengerType.Adult))
            {
                adults.Add(passengerList[i].Name);
                passengerNumber[0] += 1;
            }
            else if (passengerList[i].PassengerType.Equals(GTTWSpanClient.PassengerType.Child))
            {
                childs.Add(passengerList[i].Name);
                passengerNumber[1] += 1;
            }
        }
        return passengerNumber;
    }
}
