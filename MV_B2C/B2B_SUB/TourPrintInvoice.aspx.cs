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
using System.Collections.Generic;
using System.Globalization;
using TurboTT.Security;
using System.IO;

using Terms.Sales.Domain;
using Terms.Sales.Dao;
using Terms.Sales.Service;

public partial class TourPrintInvoice : SalseBasePage
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

    private IOPSaleOrderService _OPSaleOrderService;
    public IOPSaleOrderService OPSaleOrderService
    {
        set { this._OPSaleOrderService = value; }
    }


    public string OrderId
    {
        get { return this.Request["OrderId"]; }
    }

    public string ReturnURL
    {
        get { return Request["ReturnUrl"]; }
    }

    public User user
    {
        get
        {
            User user = (User)Session["User"];

            if (user != null)
            {
                return user;
            }
            else
            {
                user = UserManager.GetUser(Request.Cookies["User"].Value);

                return user;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSendEmail.Attributes["onClick"] = "javascript:OnSearch();return true;";
            btnPrint.Attributes["onClick"] = "javascript:doPrint();return true;";

            lblDateNow.Text = DateTime.Now.ToString("ddMMMyy", DateTimeFormatInfo.InvariantInfo);

            IList order = null;

            order = orderService.FindOrderByMember(Utility.Transaction.Member.MemberCode, OrderId);

            string invoice = ((OrderMeta)order[0]).InvoiceNumber;

            int index = invoice.IndexOf("-");

            if (index > 0)
            {
                lblOnvoiceNumber.Text = invoice.Substring(index + 1).Trim();

                lblPNR.Text = invoice.Substring(0, index).Trim();
            }

            List<string> InvoiceSegments = new List<string>();

            IList InvoiceSegmentMetas = _saleOrderService.FindInvoices(OrderId);

            if (InvoiceSegmentMetas != null && InvoiceSegmentMetas.Count > 0)
            {
                for (int i = 0; i < InvoiceSegmentMetas.Count; i++)
                {
                    InvoiceSegments.Add(((OrderInvoiceMeta)InvoiceSegmentMetas[i]).InvoiceSegment);
                }
            }

            List<string> Passengers = new List<string>();

            List<string> Turs = new List<string>();

            if (InvoiceSegments != null && InvoiceSegments.Count > 0)
            {
                for (int i = 0; i < InvoiceSegments.Count; i++)
                {
                    if (InvoiceSegments[i] == @"7T/")
                    {
                        break;
                    }

                    Passengers.Add(InvoiceSegments[i]);
                }

                dlPassenger.DataSource = Passengers;
                dlPassenger.DataBind();


                for (int i = 0; i < InvoiceSegments.Count; i++)
                {
                    if (InvoiceSegments[i].IndexOf(@"TNZZMK1TUR") >= 0)
                    {
                        Turs.Add(InvoiceSegments[i]);
                    }

                    if (InvoiceSegments[i].IndexOf(@"5-CA") >= 0)
                    {
                        //lblAcountCode.Text = InvoiceSegments[i].Replace("5-CA", string.Empty).Trim();
                    }

                    if (InvoiceSegments[i].IndexOf(@"4-DI#NT#L") >= 0)
                    {
                        string total = InvoiceSegments[i];

                        int index1 = total.LastIndexOf("T");

                        total = total.Substring(index1 + 1);

                        decimal decTotal = decimal.Zero;

                        if (decimal.TryParse(total, out decTotal))
                        {
                            lblTax.Text = decimal.Zero.ToString("N2");
                            lblSubPrice.Text = decTotal.ToString("N2");
                            lblSubPrice2.Text = decTotal.ToString("N2");
                            lblSubPrice3.Text = decTotal.ToString("N2");
                        }
                    }
                }

                if (Turs.Count > 0)
                {
                    DataTable dtTur = new DataTable("Tur");

                    DataColumn dcMonthAndDay = new DataColumn("MonthAndDay", System.Type.GetType("System.String"));
                    DataColumn dcVenderCode = new DataColumn("VenderCode", System.Type.GetType("System.String"));
                    DataColumn dcYear = new DataColumn("Year", System.Type.GetType("System.String"));
                    DataColumn dcFF1 = new DataColumn("FF1", System.Type.GetType("System.String"));
                    DataColumn dcFF2 = new DataColumn("FF2", System.Type.GetType("System.String"));
                    DataColumn dcFF3 = new DataColumn("FF3", System.Type.GetType("System.String"));
                    DataColumn dcFF4 = new DataColumn("FF4", System.Type.GetType("System.String"));

                    dtTur.Columns.Add(dcMonthAndDay);
                    dtTur.Columns.Add(dcVenderCode);
                    dtTur.Columns.Add(dcYear);
                    dtTur.Columns.Add(dcFF1);
                    dtTur.Columns.Add(dcFF2);
                    dtTur.Columns.Add(dcFF3);
                    dtTur.Columns.Add(dcFF4);

                    for (int i = 0; i < Turs.Count; i++)
                    {
                        string segment = Turs[i];

                        string[] items = segment.Split(new char[] { '/' });

                        DataRow drNew = dtTur.NewRow();

                        for (int j = 0; j < items.Length; j++)
                        {
                            if (items[j].IndexOf(@"TNZZMK1TUR") >= 0)
                            {
                                string date = items[j].Replace("TNZZMK1TUR", string.Empty).Trim().Substring(0, 7);

                                drNew["MonthAndDay"] = date.Substring(0, 5);
                                drNew["Year"] = date.Substring(5);
                            }

                            if (items[j].IndexOf(@"VC-") >= 0)
                            {
                                drNew["VenderCode"] = items[j].Replace(@"VC-", string.Empty).Trim();
                            }

                            if (items[j].IndexOf(@"FF1-") >= 0)
                            {
                                drNew["FF1"] = items[j].Replace(@"FF1-", string.Empty).Trim();
                            }

                            if (items[j].IndexOf(@"FF2-") >= 0)
                            {
                                drNew["FF2"] = items[j].Replace(@"FF2-", string.Empty).Trim();
                            }

                            if (items[j].IndexOf(@"FF3-") >= 0)
                            {
                                drNew["FF3"] = items[j].Replace(@"FF3-", string.Empty).Trim();
                            }

                            if (items[j].IndexOf(@"FF4-") >= 0)
                            {
                                drNew["FF4"] = items[j].Replace(@"FF4-", string.Empty).Trim();
                            }
                        }

                        dtTur.Rows.Add(drNew);
                    }

                    dlInfo.DataSource = dtTur;
                    dlInfo.DataBind();
                }
            }
        }
    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>OnReSearch();</script>");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgentOrderView.aspx?OrderID=" + OrderId);
    }

    public TourPrintInvoice()
    {
        this.PreRender += new EventHandler(TourPrintInvoice_PreRender);
    }

    void TourPrintInvoice_PreRender(object sender, EventArgs e)
    {
        if (Request.Params["IsFinised"] != null && Request.Params["IsFinised"].ToString().Trim().Length > 0)
        {
            sendEmail();
        }
    }

    protected void sendEmail()
    {
        string mailContent = txtFormContent.Value;

        String style = "";
        style += "<style type='text/css'>.frame_border{width:920px; margin:0 auto;}"
            + ".top{ background:url(http://www.majestic-vacations.com/images/GatewayTravel_Logo.gif) no-repeat; text-align:right; width:100%; float:left;}"
            + ".content{ width:100%; float:left; font-size:16px; font-family:Verdana, Arial, Helvetica, sans-serif;}</style>";


        String subject = "Invoice";
        String senderEmail = "sales@majestic-vacations.com";

        String reciever = txtEmail.Text.Replace(@";", @",");
        try
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            message.Bcc.Add("jianchang.chen@gmail.com");

            message.To.Add(reciever);
            if (user.Email != null && user.Email != "")
            {
                message.From = new System.Net.Mail.MailAddress(user.Email);
            }
            else
            {
                message.From = new System.Net.Mail.MailAddress(senderEmail);
            }
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = style + mailContent + "<br>";//+ getTerms();;

            try
            {
                using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\TourBookingForm.html"))
                {
                    sw.Write(style + mailContent + "<br>");
                }
            }
            catch
            {
            }

            Terms.Member.Utility.MemberUtility.SendEmail(message, "Tour");
        }
        catch
        {

        }
        Response.Redirect("AgentOrderView.aspx?OrderID=" + OrderId);
    }
}
