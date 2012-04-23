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
using Terms.Sales.Domain;
using Terms.Sales.Service;

namespace Terms.Web.Page.Hotel2
{
    public partial class HotelPrintInvoice : SalseBasePage
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
            get { return this.Request["OrderId"]; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInvoice();
            }
        }

        private void BindInvoice()
        {
            IList order = null;

            order = orderService.FindOrderByMember(Utility.Transaction.Member.MemberCode, OrderId);

            if (((OrderMeta)order[0]).OPStatus == Terms.Sales.Utility.OrderMaterialStatus.Confirmed && ((OrderMeta)order[0]).PayStatus == Terms.Sales.Utility.OrderPaymentStatus.FullPayment)
            {
                BindOrderPassengerInfo();

                if (((OrderMeta)order[0]).InvoiceNumber != null || ((OrderMeta)order[0]).InvoicePNR != null)
                { 
                    //string 
                }
            }
        }

        private void BindOrderPassengerInfo()
        {
            IList order = null;

            order = _saleOrderService.FindOrderPassengerInfo(OrderId);

            if (order != null && order.Count > 0)
            {
                dlPassenger.DataSource = order;
                dlPassenger.DataBind();
            }
        }
    }
}
