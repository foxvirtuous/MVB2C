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

using log4net;
using Spring.Web.UI;

using Terms.Sales.Domain;
using Terms.Sales.Dao;
using Terms.Sales.Service;
using System.Collections.Generic;


public partial class AllOrderSearch : Spring.Web.UI.Page
{
    public AllOrderSearch()
    {
        this.InitializeControls += new EventHandler(AllOrderSearch_InitializeControls);
    }

    private IOrderService orderService;
    public IOrderService OrderService
    {
        set { this.orderService = value; }
        //get { return this.orderService;  }
    }

    private IOrderOperationService orderOperationService;
    public IOrderOperationService OrderOperationService
    {
        set { this.orderOperationService = value; }
    }

    private IOrderMaterialService orderMaterialService;
    public IOrderMaterialService OrderMaterialService
    {
        set { this.orderMaterialService = value; }
    }

    private IOrderMerchandiseService orderMerchandiseService;
    public IOrderMerchandiseService OrderMerchandiseService
    {
        set { this.orderMerchandiseService = value; }
    }

    private IOrderMaterialHotelService orderMaterialHotelService;
    public IOrderMaterialHotelService OrderMaterialHotelService
    {
        set { this.orderMaterialHotelService = value; }
    }

    private DateTime dateFrom;

    public DateTime DateFrom
    {
        get { return dateFrom; }
        set { dateFrom = value; }
    }

    private DateTime dateTo;

    public DateTime DateTo
    {
        get { return dateTo; }
        set { dateTo = value; }
    }

    private DateTime bookingDateFrom;

    public DateTime BookingDateFrom
    {
        get { return bookingDateFrom; }
        set { bookingDateFrom = value; }
    }

    private DateTime bookingDateTo;

    public DateTime BookingDateTo
    {
        get { return bookingDateTo; }
        set { bookingDateTo = value; }
    }

    private string strPersonName;

    public string PersonName
    {
        get { return strPersonName; }
        set { strPersonName = value; }
    }

    private string strContactName;

    public string ContactName
    {
        get { return strContactName; }
        set { strContactName = value; }
    }

    private string strCaseNumber;

    public string CaseNumber
    {
        get { return strCaseNumber; }
        set { strCaseNumber = value; }
    }

    void AllOrderSearch_InitializeControls(object sender, EventArgs e)
    {
        this.txtFromBookingDate.Path = this.txtFromDate.Path = this.txtToBookingDate.Path = this.txtToDate.Path = "../../";
        //if (!Utility.IsLogin)
        //{
        //    this.Response.Redirect("~/Index.aspx");
        //}

        if (!this.IsPostBack)
        {
            SearchOrderByMember(null);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            SearchOrder();
        }
    }

    private void SearchOrder()
    {
        Hashtable hsb = new Hashtable();

        if (!string.IsNullOrEmpty(txtFromDate.CDate) && txtFromDate.CDate != "__/__/____")
        {
            DateFrom = Convert.ToDateTime(txtFromDate.CDate);

            hsb.Add("DateFrom", DateFrom);
        }
        else
        {
            hsb.Add("DateFrom", null);
        }

        if (!string.IsNullOrEmpty(txtToDate.CDate) && txtToDate.CDate != "__/__/____")
        {
            DateTo = Convert.ToDateTime(txtToDate.CDate);

            hsb.Add("DateTo", DateTo);
        }
        else
        {
            hsb.Add("DateTo", null);
        }

        if (!string.IsNullOrEmpty(txtFromBookingDate.CDate) && txtFromBookingDate.CDate != "__/__/____")
        {
            BookingDateFrom = Convert.ToDateTime(txtFromBookingDate.CDate);

            hsb.Add("BookingDateFrom", BookingDateFrom);
        }
        else
        {
            hsb.Add("BookingDateFrom", null);
        }

        if (!string.IsNullOrEmpty(txtToBookingDate.CDate) && txtToBookingDate.CDate != "__/__/____")
        {
            BookingDateTo = Convert.ToDateTime(txtToBookingDate.CDate);

            hsb.Add("BookingDateTo", BookingDateTo);
        }
        else
        {
            hsb.Add("BookingDateTo", null);
        }

        if (!string.IsNullOrEmpty(txtContactName.Text))
        {
            ContactName = txtContactName.Text.Replace(" ", "").ToLower();

            hsb.Add("ContactName", ContactName);
        }
        else
        {
            hsb.Add("ContactName", null);
        }

        if (!string.IsNullOrEmpty(txtPassengersName.Text))
        {
            PersonName = txtPassengersName.Text.Replace(" ", "").ToLower(); ;

            hsb.Add("PersonName", PersonName);
        }
        else
        {
            hsb.Add("PersonName", null);
        }

        if (!string.IsNullOrEmpty(txtCaseNumber.Text))
        {
            CaseNumber = txtCaseNumber.Text;

            hsb.Add("CaseNumber", CaseNumber);
        }
        else
        {
            hsb.Add("CaseNumber", null);
        }

        SearchOrderByMember(hsb);
    }



    private void SearchOrderByMember(Hashtable pHashtable)
    {
        IList order = null;

        if (pHashtable == null)
        {
            //order = orderService.FindOrderByMember(Utility.Transaction.Member.MemberCode);
            order = orderService.FindAllOrders();
        }
        else
        {
            //order = orderService.FindOrderByMember(Utility.Transaction.Member.MemberCode, pHashtable);
            order = orderService.GetAllOrders(pHashtable);
        }

        if (order != null)
        {
            if (order.Count > 0)
            {

                GridView1.DataSource = SpellOrders(order);
                GridView1.DataKeyNames = new string[] { "Id" };
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }

    private IList SpellOrders(IList order)
    {
        IList Orders = new List<OrderMeta>();
        foreach (OrderMeta om in order)
        {
            IList orderMaterialHotels = orderMaterialHotelService.FindOrderOfByOrderID(om.Id.ToString());
            if (orderMaterialHotels != null)
            {
                string strCfm = string.Empty;
                if (orderMaterialHotels.Count == 1)
                {
                    OrderMaterialHotelMeta omh = (OrderMaterialHotelMeta)orderMaterialHotels[0];
                    if (omh.HotelReferenceNumber != null && omh.HotelReferenceNumber.Trim() != "")
                    {
                        if (omh.RoomReferenceNumber != null && omh.RoomReferenceNumber.Trim() != "" || omh.TOKEN != null && omh.TOKEN.Trim() != "" || omh.API != null && omh.API.Trim() != "")
                            strCfm = omh.RoomReferenceNumber + " " + omh.TOKEN + " " + omh.API + "," + omh.HotelReferenceNumber;
                        else
                            strCfm = omh.HotelReferenceNumber;
                    }
                    else
                    {
                        if (omh.RoomReferenceNumber != null && omh.RoomReferenceNumber.Trim() != "" || omh.TOKEN != null && omh.TOKEN.Trim() != "" || omh.API != null && omh.API.Trim() != "")
                            strCfm = omh.RoomReferenceNumber + " " + omh.TOKEN + " " + omh.API ;
                        else
                            strCfm = "";
                    }
                }
                else
                {
                    OrderMaterialHotelMeta temp = (OrderMaterialHotelMeta)orderMaterialHotels[0];
                    string[] FCM = new string[4];
                    FCM[0] = temp.HotelReferenceNumber;
                    FCM[1] = temp.API;
                    FCM[2] = temp.TOKEN;
                    FCM[3] = temp.RoomReferenceNumber;
                    if (temp.HotelReferenceNumber != null && temp.HotelReferenceNumber.Trim() != "")
                    {

                        if (temp.RoomReferenceNumber != null && temp.RoomReferenceNumber.Trim() != "" || temp.TOKEN != null && temp.TOKEN.Trim() != "" || temp.API != null && temp.API.Trim() != "")
                            strCfm = temp.RoomReferenceNumber + " " + temp.TOKEN + " " + temp.API + "," + temp.HotelReferenceNumber;
                        else
                            strCfm = temp.HotelReferenceNumber;
                    }
                    else
                    {
                        if (temp.RoomReferenceNumber != null && temp.RoomReferenceNumber.Trim() != "" || temp.TOKEN != null && temp.TOKEN.Trim() != "" || temp.API != null && temp.API.Trim() != "")
                            strCfm = temp.API + " " + temp.TOKEN + " " + temp.RoomReferenceNumber;
                    }
                    for (int i = 1; i < orderMaterialHotels.Count;i++ )
                    {
                        OrderMaterialHotelMeta OMHM = (OrderMaterialHotelMeta)orderMaterialHotels[i];
                        if (FCM[0] == OMHM.HotelReferenceNumber && FCM[1] == OMHM.API && FCM[2] == OMHM.TOKEN && FCM[3] == OMHM.RoomReferenceNumber)
                        {

                            continue;
                        }
                        else
                        {
                            if (OMHM.HotelReferenceNumber != null && OMHM.HotelReferenceNumber.Trim() != "")
                            {

                                if (OMHM.RoomReferenceNumber != null && OMHM.RoomReferenceNumber.Trim() != "" || OMHM.TOKEN != null && OMHM.TOKEN.Trim() != "" || OMHM.API != null && OMHM.API.Trim() != "")
                                {
                                    if (strCfm.Trim() != "")
                                        strCfm += "," + OMHM.RoomReferenceNumber + " " + OMHM.TOKEN + " " + OMHM.API + "," + OMHM.HotelReferenceNumber;
                                    else
                                        strCfm += OMHM.RoomReferenceNumber + " " + OMHM.TOKEN + " " + OMHM.API + "," + OMHM.HotelReferenceNumber;
                                }
                                else
                                {
                                    if(strCfm.Trim() != null)
                                        strCfm += "," + OMHM.HotelReferenceNumber;
                                    else
                                        strCfm += OMHM.HotelReferenceNumber;
                                }
                              
                            }
                            else
                            {
                                if (OMHM.RoomReferenceNumber != null && OMHM.RoomReferenceNumber.Trim() != "" || OMHM.TOKEN != null && OMHM.TOKEN.Trim() != "" || OMHM.API != null && OMHM.API.Trim() != "")
                                {
                                    if(strCfm.Trim() != "")
                                        strCfm += "," + OMHM.API + " " + OMHM.TOKEN + " " + OMHM.RoomReferenceNumber;
                                    else
                                        strCfm += OMHM.API + " " + OMHM.TOKEN + " " + OMHM.RoomReferenceNumber;
                                }
                            }
                            FCM[0] = temp.HotelReferenceNumber;
                            FCM[1] = temp.API;
                            FCM[2] = temp.TOKEN;
                            FCM[3] = temp.RoomReferenceNumber;

                        }

                    }
                }
                om.CFM = strCfm;
            }
            Orders.Add(om);
        }
        return Orders;
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = GridView1.SelectedIndex;

        string strTemp = GridView1.DataKeys[i]["Id"].ToString();

        //更改Ｏｒｄｅｒ的ＰａｙｍｅｎｔＳｔａｔｕｓ
        OrderMeta order = orderService.GetOrder(new Guid(strTemp));

        order.PayStatus = Terms.Sales.Utility.OrderPaymentStatus.Cancel;

        //order.OPStatus = Terms.Sales.Utility.OrderMaterialStatus.RequestCancel;

        orderService.Update(order);

        //更改Order的OP Status
        OrderOperationMeta orderOperation = orderOperationService.GetOperation(strTemp);

        if (orderOperation != null)
        {
            orderOperation.Status = 9;

            orderOperationService.Update(orderOperation);
        }

        OrderMerchandiseMeta OrderMerchandises = orderMerchandiseService.GetMerchandise(strTemp);

        if (OrderMerchandises != null)
        {
            IList orderMaterials = orderMaterialService.Find(OrderMerchandises.Id.ToString());

            if (orderMaterials.Count > 0)
            {
                for (int j = 0; j < orderMaterials.Count; j++)
                {
                    OrderMaterialMeta orderMaterial = (OrderMaterialMeta)orderMaterials[j];
                    orderMaterial.Status.DetailType = (short)Terms.Sales.Utility.OrderMaterialStatus.RequestCancel;
                    orderMaterialService.Update(orderMaterial);
                }
            }
        }

        //重新显示Order
        SearchOrder();
     
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[8].Text.Trim() == "RequestCancel" && e.Row.Cells[9].Text.Trim() == "Cancel")
        {
            e.Row.Cells[10].Enabled = false;
        }
    }
}
