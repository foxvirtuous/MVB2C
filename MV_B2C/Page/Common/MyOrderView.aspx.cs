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

using log4net;
using Spring.Web.UI;

using Terms.Sales.Domain;
using Terms.Sales.Dao;
using Terms.Sales.Service;
using TERMS.Business.Centers.SalesCenter;

public partial class MyOrderView : Spring.Web.UI.Page
{
    private IOrderService orderService;
    public IOrderService OrderService
    {
        set { this.orderService = value; }
    }

    private ISaleOrderService _saleOrderService;
    public ISaleOrderService SaleOrderService
    {
        set { this._saleOrderService = value; }
    }

    private IOrderContractService _OrderContractService;
    public IOrderContractService OrderContractService
    {
        set { this._OrderContractService = value; }
    }

    private IOPSaleOrderService _OPSaleOrderService;
    public IOPSaleOrderService OPSaleOrderService
    {
        set { this._OPSaleOrderService = value; }
    }


    public string OrderId
    {
        get { return this.Request["OrderId"];}
    }

    public MyOrderView()
    {
        this.InitializeControls += new EventHandler(MyOrderView_InitializeControls);
    }

    void MyOrderView_InitializeControls(object sender, EventArgs e)
    {
        if (!Utility.IsLogin)
        {
            this.Response.Redirect("~/Index.aspx");
        }

        if (!this.IsPostBack)
        {
            BindOrderByMember();
        }
    }

    private void BindOrderByMember()
    {
        IList order = null;

        if (Utility.Transaction.Member.Source != null && Utility.Transaction.Member.Source.Trim().ToLower() == "Subagent".Trim().ToLower())
        {
            order = orderService.FindOrderByMember(Utility.Transaction.Member.EmailAddress, OrderId);
        }
        else
        {
            order = orderService.FindOrderByMember(Utility.Transaction.Member.MemberCode, OrderId);
        }
        if (order.Count == 1)
        {
            lblCaseNumber.Text = ((OrderMeta)order[0]).CaseNumber;

            lblRecordLocator.Text = ((OrderMeta)order[0]).RcordLocator;

            lblPaymentStatus.Text = ((OrderMeta)order[0]).PayStatus.ToString();

            lblOPStatus.Text = ((OrderMeta)order[0]).OPStatus.ToString();

            lblAdultNumber.Text = ((OrderMeta)order[0]).AdultNumber.ToString();

            lblChildNumber.Text = ((OrderMeta)order[0]).ChildNumber.ToString();

            if(((OrderMeta)order[0]).Remark != null)
                lbCompent.Text = ((OrderMeta)order[0]).Remark.ToString();
            else
                lbCompent.Text = "";

            BindOrderContract();

            BindOrderPassengerInfo();
            if(!((OrderMeta)order[0]).Type.Trim().Equals("T"))
                BindOrderPayer();

            BindAirLine();

            BindOrderTourInfo();

            BindOrderTourItineraryInfo();

            BindHotel();

            BindPire();

            BindInsurance();

            BindTransfer();

            BindHandler();
        }
    }

    private void BindOrderContract()
    {
        IList OrderContract = null;

        OrderContract = _OrderContractService.Find(OrderId);
        if (OrderContract != null && OrderContract.Count == 1)
        {
            lblContactName.Text = ((OrderContractMeta)OrderContract[0]).FirstName + " " + ((OrderContractMeta)OrderContract[0]).MiddleName + " " + ((OrderContractMeta)OrderContract[0]).LastName;

            lblContactEmail.Text = ((OrderContractMeta)OrderContract[0]).Email;

            lblContactDayTel.Text = ((OrderContractMeta)OrderContract[0]).TelDaytime;

            lblContactEveningTel.Text = ((OrderContractMeta)OrderContract[0]).TelNightTime;

            lblContactFax.Text = ((OrderContractMeta)OrderContract[0]).Fax;

            lblContactZip.Text = ((OrderContractMeta)OrderContract[0]).ZipCode;

            lblContactAddress.Text = ((OrderContractMeta)OrderContract[0]).StreetAddress;

        }
    }

    private void BindOrderPassengerInfo()
    {
        IList order = null;

        order = _saleOrderService.FindOrderPassengerInfo(OrderId);

        if (order != null && order.Count > 0)
        {
            gvPassengerDetail.DataSource = order;
            gvPassengerDetail.DataBind();
        }
    }

    private void BindOrderTourItineraryInfo()
    {
        IList order = null;

        order = _saleOrderService.FindOrderMaterialItineraryMeta(OrderId);

        if (order != null && order.Count > 0)
        {
            divTourItinerary.Visible = true;
            gvItineraryInfo.DataSource = order;
            gvItineraryInfo.DataBind();
        }
    }

    private void BindOrderTourInfo()
    {
        IList order = null;

        order = _saleOrderService.FindOrderMerchandiseTourMeta(OrderId);

        if (order != null && order.Count > 0)
        {
            divTourItinerary.Visible = true;
            gvTourInfo.DataSource = order;
            gvTourInfo.DataBind();
        }
    }
    private void BindOrderPayer()
    {
        ArrayList arr = _saleOrderService.FindPayer(OrderId);

        if (arr != null && arr.Count > 0)
        {
            OrderPaymentMeta orderPayment = (OrderPaymentMeta)arr[0];

            OrderPayerMeta orderPayer = (OrderPayerMeta)arr[1];

            if (orderPayment.PaymentType.DetailType.ToString().Trim() == "2")
            {
                lblCreditCard.Text = orderPayment.CreditCardType.Name;

                lblBankName.Text = orderPayment.CreditCardBankName;
                lblCustomerPhone.Text = orderPayment.CreditCardBankTollFreeNumber;

                string strTemp = orderPayment.CreditCardNumber.Substring(orderPayment.CreditCardNumber.LastIndexOf("-"));

                lblCardNumber.Text = "XXXX-XXXX-XXXX" + strTemp;

                lblExpirationDate.Text = orderPayment.CreditCardExpirationDate.Value.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                if (orderPayment.CardHolderFirstName != null && orderPayment.CardHolderLastName != null)
                {
                    lblCardHolderName.Text = orderPayment.CardHolderFirstName.Trim() + " " + orderPayment.CardHolderLastName.Trim();
                }
            }
            lblPaymentType.Text = orderPayment.PaymentType.Name;

            lblPayerName.Text = orderPayer.FirstName.Trim() + " " + orderPayer.LastName.Trim();

            lblCity.Text = orderPayer.CityName;

            lblState.Text = orderPayer.ProvinceName;

            lblZip.Text = orderPayer.ZipCode;

            lblBillingAddress.Text = orderPayer.StreetAddress;

            lblTel.Text = orderPayer.TelDaytime;
        }

        //lblEmail.Text = orderPayer.Email;
    }

    private void BindAirLine()
    {
        List<OrderMaterialAirLegMeta> order = new List<OrderMaterialAirLegMeta>();

        order = _saleOrderService.FindAirLineLeg(OrderId);

        if (order != null && order.Count > 0)
        {
            divFlight.Visible = true;

            order.Sort(delegate(OrderMaterialAirLegMeta r1, OrderMaterialAirLegMeta r2) { return r1.SortNumber.CompareTo(r2.SortNumber); });

            gvFlightInfo.DataSource = order;

            
            
            gvFlightInfo.DataBind();
            //gvFlightInfo.DataSourceID = "SortNumber";
            //gvFlightInfo.Sort("SortNumber", SortDirection.Ascending);
        }
        else
        {
            divFlight.Visible = false;
        }
    }

    private void BindHotel()
    {
        List<OrderMaterialHotelMeta> order = new List<OrderMaterialHotelMeta>();

        order = _saleOrderService.FindOrderHotel(OrderId);
        if (order != null && order.Count > 0)
        {
            for (int i = 0; i < order.Count; i++)
            {
                for (int j = order.Count-1; j > i ; j--)
                {
                    if (((OrderMaterialHotelMeta)order[i]).BeginDate == ((OrderMaterialHotelMeta)order[j]).BeginDate &&
                        ((OrderMaterialHotelMeta)order[i]).Enddate == ((OrderMaterialHotelMeta)order[j]).Enddate &&
                        ((OrderMaterialHotelMeta)order[i]).HotelCode == ((OrderMaterialHotelMeta)order[j]).HotelCode)
                    {
                        ((OrderMaterialHotelMeta)order[i]).RoomsDetailedInformation += ", " + ((OrderMaterialHotelMeta)order[j]).RoomsDetailedInformation;
                        order.Remove((OrderMaterialHotelMeta)order[j]);
                    }
                    
                }
            }
            divHotel.Visible = true;
            dlHotel.DataSource = order;
            dlHotel.DataBind();

            List<OrderMaterialMeta> orderMaterialMeta = new List<OrderMaterialMeta>();

            orderMaterialMeta = _saleOrderService.FindOrderMaterialMeta(OrderId);

            int iNew = 0;

            int iProcessing = 0;

            for (int i = 0; i < dlHotel.Items.Count; i++)
            {
                for (int j = 0; j < orderMaterialMeta.Count; j++)
                {
                    if (orderMaterialMeta[j].Id.ToString() == order[i].OrderMaterialid.Id.ToString())
                    {
                        if (((Terms.Sales.Utility.OrderMaterialStatus)(int)orderMaterialMeta[j].Status.DetailType) == Terms.Sales.Utility.OrderMaterialStatus.New)
                        {
                            iNew++;
                        }

                        if (((Terms.Sales.Utility.OrderMaterialStatus)(int)orderMaterialMeta[j].Status.DetailType) == Terms.Sales.Utility.OrderMaterialStatus.Processing)
                        {
                            iProcessing++;
                        }

                        Label lblOPState = (Label)dlHotel.Items[i].FindControl("lblState");

                        lblOPState.Text = ((Terms.Sales.Utility.OrderMaterialStatus)(int)orderMaterialMeta[j].Status.DetailType).ToString();
                    }
                }
            }

            if (iNew > 0)
            {
                lblOPStatus.Text = Terms.Sales.Utility.OrderMaterialStatus.New.ToString();
            }
            else
            {
                if (iProcessing > 0)
                {
                    lblOPStatus.Text = Terms.Sales.Utility.OrderMaterialStatus.Processing.ToString();
                }
                else
                {
                    lblOPStatus.Text = Terms.Sales.Utility.OrderMaterialStatus.Confirmed.ToString();
                }
            }
        }
        else
        {
            divHotel.Visible = false;
        }
    }

    private void BindInsurance()
    {
        List<OrderInsuranceMeta> order = new List<OrderInsuranceMeta>();

        order = _saleOrderService.FindOrderInsuranceMeta(OrderId);

        if (order != null && order.Count > 0)
        {
            divInsurance.Visible = true;

            lblInsuranceName.Text = order[0].InsuranceOrderName;
            lblInsuranceStatus.Text = (Convert.ToBoolean(order[0].InsuranceOrderStatus)).ToString();
            lblInsuranceTotal.Text = order[0].TotalPremiumAmount.ToString();
        }
        else
        {
            divInsurance.Visible = false;
        }
    }

    private void BindTransfer()
    {
        List<TransferOrderItem> transferOrderItems = new List<TransferOrderItem>();

        TERMS.Business.Centers.SalesCenter.TransactionObject obj = _OPSaleOrderService.GetTransactionObject(OrderId);

        if (obj != null)
        {
            this.divTransfer.Visible = true;

            foreach (OrderItem item in obj.Items)
            {
                if (item is TransferOrderItem)
                {
                    transferOrderItems.Add((TransferOrderItem)item);
                }
            }

            if (transferOrderItems.Count > 0)
            {
                foreach (TransferOrderItem transfer in transferOrderItems)
                {
                    if (transfer.Type == 0)
                    {
                        divThen.Visible = true;

                        lblName_Then.Text = transfer.ItemName;

                        lblCar_Then.Text = transfer.TransferVehicles[0].Description;

                        lblMaximumPassengers_Then.Text = transfer.TransferVehicles[0].MaximumPassengers.ToString();

                        lblMaximumLuggage_Then.Text = transfer.TransferVehicles[0].MaximumLuggage.ToString();

                        lblTransfertime_Then.Text = transfer.TimeName;

                        lblPirce_Then.Text = transfer.TransferVehicles[0].Price.ToString("N2");

                        lblArrivingFrom_Then.Text = transfer.ArrivingFrom;

                        lblAirline_Then.Text = transfer.FlightNumber;

                        lblArrival_Then.Text = transfer.EstimatedTimeofArrival.ToString("MM/dd/yyyy H:mm:ss");

                        lblHotelAddress_Then.Text = transfer.HotelAddress;

                        lblCity_Then.Text = transfer.City;

                        lblState_Then.Text = transfer.State;

                        lblTel_Then.Text = transfer.PhoneNumber;

                        lblZip_Then.Text = transfer.ZipCode;

                        hpDetailAndCancel_Then.NavigateUrl = "~/Page/Common/TransferDetail.aspx?city=" + transfer.PickUpCityCode + "&&item=" + transfer.ItemCode +
                            "&&Date=" + Server.UrlEncode(transfer.EstimatedTimeofArrival.ToString()) + "&&language=E&&car=" + transfer.TransferVehicles[0].Code + "&&passengers=" + transfer.TransferVehicles[0].MaximumPassengers;
                    }
                    if (transfer.Type == 1)
                    {
                        divSend.Visible = true;

                        lblName_Send.Text = transfer.ItemName;

                        lblCar_Send.Text = transfer.TransferVehicles[0].Description;

                        lblMaximumPassengers_Send.Text = transfer.TransferVehicles[0].MaximumPassengers.ToString();

                        lblMaximumLuggage_Send.Text = transfer.TransferVehicles[0].MaximumLuggage.ToString();

                        lblTransfertime_Send.Text = transfer.TimeName;

                        lblPirce_Send.Text = transfer.TransferVehicles[0].Price.ToString("N2");

                        lblArrivingFrom_Send.Text = transfer.ArrivingFrom;

                        lblArrivingFrom_Send.Text = transfer.ArrivingFrom;

                        lblAirline_Send.Text = transfer.FlightNumber;

                        lblArrival_Send.Text = transfer.EstimatedTimeofArrival.ToString("MM/dd/yyyy H:mm:ss");

                        lblHotelAddress_Send.Text = transfer.HotelAddress;

                        lblCity_Send.Text = transfer.City;

                        lblState_Send.Text = transfer.State;

                        lblTel_Send.Text = transfer.PhoneNumber;

                        lblZip_Send.Text = transfer.ZipCode;

                        lblPickupTime.Text = transfer.Time.ToString("MM/dd/yyyy H:mm:ss");

                        hpDetailAndCancel_Send.NavigateUrl = "~/Page/Common/TransferDetail.aspx?city=" + transfer.PickUpCityCode + "&&item=" + transfer.ItemCode +
                            "&&Date=" + Server.UrlEncode(transfer.EstimatedTimeofArrival.ToString()) + "&&language=E&&car=" + transfer.TransferVehicles[0].Code + "&&passengers=" + transfer.TransferVehicles[0].MaximumPassengers;
                    }
                }
            }
            else
            {
                this.divTransfer.Visible = false;
            }
        }
        else
        {
            this.divTransfer.Visible = false;
        }
    }


    private void BindHandler()
    {
        if (Utility.Transaction.Member != null)
        {
            string sourse = Utility.Transaction.Member.Source.Trim();

            if (sourse == "MVB2B" || sourse == "Subagent")
            {
                divHandler.Visible = true;

                string handler = Utility.Transaction.Member.Handler;

                if (handler == null || handler.Trim().Length == 0)
                {
                    handler = "DEFAULT";
                }

                List<Terms.Member.Utility.HandlerReceiver> Citys = Terms.Member.Utility.MemberUtility.GetHandlerReciever();

                Terms.Member.Utility.HandlerReceiver HandlerReceiver = new Terms.Member.Utility.HandlerReceiver();

                for (int i = 0; i < Citys.Count; i++)
                {
                    if (Citys[i].Name.Trim().ToUpper() == handler.Trim().ToUpper())
                    {
                        HandlerReceiver = Citys[i];
                    }
                }

                switch (handler)
                {
                    case "LAX":
                        lblHandlerName.Text = "Alhambra";
                        lblSalesName.Text = HandlerReceiver.SalesName.Replace(",", " or ");
                        lblSalesEmail.Text = @"<a href='#' class='d07'>" + HandlerReceiver.SalesEmail.Replace(",", @"</a> or <a href='#' class='d07'>") + @"</a>";
                        lblSalesTel.Text = HandlerReceiver.Tel;
                        break;
                    case "SFO":
                        lblHandlerName.Text = "San Francisco";
                        lblSalesName.Text = HandlerReceiver.SalesName.Replace(",", " or ");
                        lblSalesEmail.Text = @"<a href='#' class='d07'>" + HandlerReceiver.SalesEmail.Replace(",", @"</a> or <a href='#' class='d07'>") + @"</a>";
                        lblSalesTel.Text = HandlerReceiver.Tel;
                        break;
                    case "NYC":
                        lblHandlerName.Text = "New York City";
                        lblSalesName.Text = HandlerReceiver.SalesName.Replace(",", " or ");
                        lblSalesEmail.Text = @"<a href='#' class='d07'>" + HandlerReceiver.SalesEmail.Replace(",", @"</a> or <a href='#' class='d07'>") + @"</a>";
                        lblSalesTel.Text = HandlerReceiver.Tel;
                        break;
                    case "DEFAULT":
                        lblHandlerName.Text = "Other";
                        lblSalesName.Text = HandlerReceiver.SalesName.Replace(",", " or ");
                        lblSalesEmail.Text = @"<a href='#' class='d07'>" + HandlerReceiver.SalesEmail.Replace(",", @"</a> or <a href='#' class='d07'>") + @"</a>";
                        lblSalesTel.Text = HandlerReceiver.Tel;
                        break;
                }
            }
            else
            {
                divHandler.Visible = false;
            }
        }
        else
        {
            divHandler.Visible = false;
        }
    }

    private void BindPire()
    {
        List<OrderMaterialAirLegMeta> order = new List<OrderMaterialAirLegMeta>();

        Decimal decPire = _saleOrderService.FindPire(OrderId);
        //当是Package时 加 100 * 人数
        if (this.gvFlightInfo.Rows.Count > 0 && this.dlHotel.Items.Count > 0)
        {
            decPire += (Convert.ToInt32(lblAdultNumber.Text) + Convert.ToInt32(lblChildNumber.Text)) * 100M;
        }

        lblPrice.Text = decPire.ToString("N2");
    }
    protected void gvFlightInfo_DataBinding(object sender, EventArgs e)
    {
        //if()
    }
    protected void gvFlightInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsDate(e.Row.Cells[2].Text))
            {
                e.Row.Cells[2].Text = Convert.ToDateTime(e.Row.Cells[2].Text).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
        }
    }
    protected void gvPassengerDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsDate(e.Row.Cells[2].Text))
            {
                e.Row.Cells[2].Text = Convert.ToDateTime(e.Row.Cells[2].Text).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
        }
    }

    private bool IsDate(string StrDate)
    {
        try
        {
            DateTime date = Convert.ToDateTime(StrDate);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void dlHotel_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //if (lblPaymentStatus.Text.Trim() == "FullPayment".Trim() && lblOPStatus.Text.Trim() == "Confirmed".Trim())
        //{
        //    ((LinkButton)e.Item.FindControl("lkbHotelVouche")).Visible = true;
        //    ((LinkButton)e.Item.FindControl("lkbHotelVouche")).PostBackUrl += "?HotelCode=" + ((TextBox)e.Item.FindControl("lblHotelCode")).Text + "&ReturnURL=~/Page/Common/MyOrderView.aspx&OrderId=" + OrderId;
        //}
        //else if (lblPaymentStatus.Text.Trim() == "FullPayment".Trim() && lblOPStatus.Text.Trim() == "Guarantee".Trim())
        //{
        //    ((LinkButton)e.Item.FindControl("lkbHotelVouche")).PostBackUrl += "?HotelCode=" + ((TextBox)e.Item.FindControl("lblHotelCode")).Text + "&ReturnURL=~/Page/Common/MyOrderView.aspx&OrderId=" + OrderId;
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //_OPSaleOrderService.GetTransactionObject(OrderId);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //string strPNR = lblRecordLocator.Text;

        //bool falg = _saleOrderService.CancelPNR(strPNR);

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + falg.ToString() + "');</script>");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //string strPNR = string.Empty;

        //bool falg = _saleOrderService.CancelGta(strPNR);

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + falg.ToString() + "');</script>");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //TERMS.Business.Centers.SalesCenter.TransactionObject pTransactionObject = _OPSaleOrderService.GetTransactionObject(OrderId);

        //string strPNR = string.Empty;

        //bool falg = _saleOrderService.CancelTravco(strPNR, pTransactionObject);

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + falg.ToString() + "');</script>");
    }
    protected void gvItineraryInfo_DataBinding(object sender, EventArgs e)
    {

    }

    protected void gvItineraryInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            OrderMaterialItineraryMeta orderMaterialItineraryMeta = (OrderMaterialItineraryMeta)(((System.Object)(((System.Web.UI.WebControls.GridViewRow)(e.Row)).DataItem)));
            e.Row.Cells[2].Text = string.Empty;
                for (int i = 0; i < orderMaterialItineraryMeta.TOrderMaterialMealList.Count; i++)
                {
                    OrderMaterialMealMeta orderMaterialMealMeta = (OrderMaterialMealMeta)orderMaterialItineraryMeta.TOrderMaterialMealList[i];
                    string meal = string.Empty;
                    if (Convert.ToInt32(orderMaterialMealMeta.MealType) == Convert.ToInt32(TERMS.Common.MealType.Breakfast))
                    {
                        meal = TERMS.Common.MealType.Breakfast.ToString();
                    }
                    if (Convert.ToInt32(orderMaterialMealMeta.MealType) == Convert.ToInt32(TERMS.Common.MealType.Lunch))
                    {
                        meal = TERMS.Common.MealType.Lunch.ToString();
                    }
                    if (Convert.ToInt32(orderMaterialMealMeta.MealType) == Convert.ToInt32(TERMS.Common.MealType.Dinner))
                    {
                        meal = TERMS.Common.MealType.Dinner.ToString();
                    }
                    
                    TERMS.Common.MealType.Breakfast.ToString();
                    e.Row.Cells[2].Text += meal + ":" + orderMaterialMealMeta.Name + "<BR> ";
                }
            
        }
    }
    protected void gvTourInfo_DataBinding(object sender, EventArgs e)
    {

    }

    protected void gvTourInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
}
