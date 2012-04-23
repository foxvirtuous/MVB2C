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
using Terms.Sales.Service;
using Terms.Sales.Domain;

public partial class Test : Spring.Web.UI.Page
{
    private IOrderService _orderService;
    public IOrderService OrderService
    {
        set { this._orderService = value; }
        //get { return this.orderService;  }
    }
    private IOrderMaterialService _orderMaterialService;
    public IOrderMaterialService OrderMaterialService
    {
        set { this._orderMaterialService = value; }
        //get { return this.orderService;  }
    }

    private IOrderMaterialHotelService _orderMaterialHotelService;
    public IOrderMaterialHotelService OrderMaterialHotelService
    {
        set { this._orderMaterialHotelService = value; }
        //get { return this.orderService;  }
    }

    private IOPSaleOrderService oPSaleOrderService;
    public IOPSaleOrderService OPSaleOrderService
    {
        set { this.oPSaleOrderService = value; }
        //get { return this.orderService;  }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DateTime finaltripdepositdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //txtURL.Text = finaltripdepositdate.ToString("MM/dd/yyyy");
        }
    }

    void Test_InitializeControls(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //string str = "";
        ////oPSaleOrderService.GetOrder("1d3a5461-1ca5-4789-b9c8-9acf0127b1ee");
        //IList listHotelOrder = _orderMaterialHotelService.GetOrderMaterialHotel();

        //IList<TShipmentHotelOrder> listHotelOrderView = new List<TShipmentHotelOrder>();
        ////IList orderMate = _orderService.GetAllOrders(htTemp, "H");

        //for (int i = 0; i < listHotelOrder.Count; i++)
        //{
        //    IList md = (IList)listHotelOrder[i];

        //    TShipmentHotelOrder HotelOrder = new TShipmentHotelOrder();

        //    IList hotellist = _orderMaterialHotelService.GetOrderMaterialHotel(md[0].ToString(), md[2].ToString(), md[3].ToString(), md[4].ToString());
        //    OrderMaterialHotelMeta MaterialHotelMeta = (OrderMaterialHotelMeta)hotellist[0];

        //    OrderMaterialMeta MaterialMeta = _orderMaterialService.GetOrderMaterial(MaterialHotelMeta.OrderMaterialid.Id);


        //    OrderMeta orderList = _orderService.GetOrder(new Guid(md[0].ToString()));
        //    HotelOrder.PaymentStatus = orderList.PayStatus;


        //    listHotelOrderView.Add(HotelOrder);
        //}

        this.Response.Redirect("~/B2B_SUB/GttGlobalSkipIndex.aspx?MJVID=" + Server.UrlEncode(txtURL.Text));
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(this.GetType(), "Searching", @"<script>aa('1');</script>");

        this.Response.Redirect("~/B2B_SUB/GttGlobalSkipIndex.aspx?MJVID=" + Server.UrlEncode(txtURL.Text));
    }
}
