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

public partial class AgentOrderView : SalseBasePage
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

    public AgentOrderView()
    {
        this.InitializeControls += new EventHandler(AgentOrderView_InitializeControls);
    }

    void AgentOrderView_InitializeControls(object sender, EventArgs e)
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

        order = orderService.FindOrderByMember(Utility.Transaction.Member.MemberCode, OrderId);
        if (order.Count == 1)
        {
            lblCaseNumber.Text = ((OrderMeta)order[0]).CaseNumber;

            lblRecordLocator.Text = ((OrderMeta)order[0]).RcordLocator;

            if (lblRecordLocator.Text.Trim().Length > 0)
            {
                phPNR.Visible = true;
            }
            else
            {
                phPNR.Visible = false;
            }

            lblPaymentStatus.Text = ((OrderMeta)order[0]).PayStatus.ToString();

            lblOPStatus.Text = ((OrderMeta)order[0]).OPStatus.ToString();

            lblAdultNumber.Text = ((OrderMeta)order[0]).AdultNumber.ToString();

            lblChildNumber.Text = ((OrderMeta)order[0]).ChildNumber.ToString();

            if (!string.IsNullOrEmpty(((OrderMeta)order[0]).Source))
            {
                lblSourseType.Text = ((OrderMeta)order[0]).Source;
            }

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

            BindHandler();

            if (((OrderMeta)order[0]).InvoiceNumber != null && ((OrderMeta)order[0]).InvoiceNumber.Trim().Length > 0)
            {
                btnInvoice.Visible = true;
            }
            else
            {
                btnInvoice.Visible = false;
            }
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

            lblPaymentType.Text = orderPayment.PaymentType.Name;

            lblPayerName.Text = orderPayer.FirstName.Trim() + " " + orderPayer.LastName.Trim();

            if (orderPayment.CreditCardType != null && orderPayment.PaymentType.DetailType == (short)2)
            {
                lblCreditCard.Text = orderPayment.CreditCardType.Name;
            }

            if (orderPayment.CreditCardNumber != null && orderPayment.CreditCardNumber.Trim().Length > 0)
            {
                string strTemp = orderPayment.CreditCardNumber.Substring(orderPayment.CreditCardNumber.LastIndexOf("-"));

                if ( (int)orderPayment.CreditCardType.DetailType  == 2)
                    lblCardNumber.Text = "XXXX-XXXXXX" + strTemp;
                else
                    lblCardNumber.Text = "XXXX-XXXX-XXXX" + strTemp;
            }

            if (orderPayment.CreditCardExpirationDate != null)
            {
                lblExpirationDate.Text = orderPayment.CreditCardExpirationDate.Value.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }

            if (orderPayment.CreditCardBankName != null)
            {
                lblBankName.Text = orderPayment.CreditCardBankName;
            }

            if (orderPayment.CreditCardBankTollFreeNumber != null)
            {
                lblCustomerPhone.Text = orderPayment.CreditCardBankTollFreeNumber;
            }
            if (orderPayment.CardHolderFirstName != null && orderPayment.CardHolderLastName != null)
            {
                lblCardHolderName.Text = orderPayment.CardHolderFirstName.Trim() + " " + orderPayment.CardHolderLastName.Trim();
            }

            lblCity.Text = orderPayer.CityName;

            lblState.Text = orderPayer.ProvinceName;

            lblZip.Text = orderPayer.ZipCode;

            lblBillingAddress.Text = orderPayer.StreetAddress;

            lblTel.Text = orderPayer.TelDaytime;
        }
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


            for (int i = 0; i < dlHotel.Items.Count; i++)
            {
                DataListItem item = dlHotel.Items[i];

                Label lblHotelCode = (Label)item.FindControl("lblHotelCode");
                LinkButton lkbHotelVouche = (LinkButton)item.FindControl("lkbHotelVoucher");
                Label lblCheckin = (Label)item.FindControl("lblCheckin");

                if (lblPaymentStatus.Text.Trim() == "FullPayment".Trim() && lblOPStatus.Text.Trim() == "Confirmed".Trim())
                {
                    lkbHotelVouche.Visible = true;
                    lkbHotelVouche.PostBackUrl += "?HotelCode=" + lblHotelCode.Text + "&ReturnURL=~/B2B_SUB/AgentOrderView.aspx&OrderId=" + OrderId + "&Checkin=" + lblCheckin.Text;
                }
                else if (lblPaymentStatus.Text.Trim() == "FullPayment".Trim() && lblOPStatus.Text.Trim() == "Guarantee".Trim())
                {
                    lkbHotelVouche.Visible = true;
                    lkbHotelVouche.PostBackUrl += "?HotelCode=" + lblHotelCode.Text + "&ReturnURL=~/B2B_SUB/AgentOrderView.aspx&OrderId=" + OrderId + "&Checkin=" + lblCheckin.Text;
                }
            }

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
        IList list = _saleOrderService.GetMarkUpByOrderId(new Guid(OrderId));

        decimal decMarkup = 0M;

        if (list.Count > 0)
        {
            decMarkup = ((TAgentMarkup)list[0]).Markup;
            lblMarkup.Text = decMarkup.ToString("N2");
        }
        else
        {
            lblMarkup.Text = decMarkup.ToString("N2");
        }

        List<OrderMaterialAirLegMeta> order = new List<OrderMaterialAirLegMeta>();

        Decimal decPire = _saleOrderService.FindPire(OrderId);
        //当是Package时 加 100 * 人数
        if (this.gvFlightInfo.Rows.Count > 0 && this.dlHotel.Items.Count > 0)
        {
            if (lblSourseType.Text.Trim().ToUpper() == "MVB2C".Trim().ToUpper())
            {
                decPire += (Convert.ToInt32(lblAdultNumber.Text) + Convert.ToInt32(lblChildNumber.Text)) * 100M;
            }
            else
            {
                decPire += (Convert.ToInt32(lblAdultNumber.Text) + Convert.ToInt32(lblChildNumber.Text)) * 50M;
            }
        }

        //lblPrice.Text = (decPire + Convert.ToDecimal(lblMarkup.Text)).ToString("N2");

        lblPrice.Text = (decPire + decMarkup).ToString("N2");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
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

    protected void btnInvoice_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("TourPrintInvoice.aspx?OrderId=" + OrderId);
    }
}
