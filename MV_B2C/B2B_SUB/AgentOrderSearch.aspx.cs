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

public partial class AgentOrderSearch : SalseBasePage
{
    public AgentOrderSearch()
    {
        this.InitializeControls += new EventHandler(AgentOrderSearch_InitializeControls);
    }

    void AgentOrderSearch_InitializeControls(object sender, EventArgs e)
    {
        this.txtFromBookingDate.Path = this.txtFromDate.Path = this.txtToBookingDate.Path = this.txtToDate.Path = "../";
        if (!Utility.IsLogin)
        {
            this.Response.Redirect("~/Index.aspx");
        }

        if (!this.IsPostBack)
        {
            SearchOrderByMember(null);
        }
    }

    private IOrderService orderService;
    public IOrderService OrderService
    {
        set { this.orderService = value; }
        //get { return this.orderService;  }
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
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
                ContactName = txtContactName.Text.Replace(" ","").ToLower();

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
    }

    private void SearchOrderByMember(Hashtable pHashtable)
    {
        IList order = null;

        if (pHashtable == null)
        {
            order = orderService.FindOrderByMember(Utility.Transaction.Member.MemberCode);
        }
        else
        {
            order = orderService.FindOrderByMember(Utility.Transaction.Member.MemberCode, pHashtable);
        }

        if (order != null)
        {
            if (order.Count > 0)
            {
                GridView1.DataSource = order;
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = GridView1.SelectedIndex;

        string strTemp = GridView1.DataKeys[i]["Id"].ToString();

        this.Response.Redirect("AgentOrderView.aspx?OrderId=" + strTemp);
    }
}
