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
using System.Net.Mail;

using log4net;
using Spring.Web.UI;

using Terms.Material.Domain;
using Terms.Material.Service;
using Terms.Base.Domain;
using Terms.Base.Utility;
using Terms.Sales.Domain;
using Terms.Sales.Service;
using Terms.Product.Domain;
using System.Text.RegularExpressions;

using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;


public partial class PaymentForm : SalseBasePage
{
    private ISaleOrderService m_SaleOrderService;

    protected ISaleOrderService SaleOrderService
    {
        set
        {
            m_SaleOrderService = value;
        }
    }

    public PaymentForm()
    {
        this.InitializeControls += new EventHandler(PaymentForm_InitializeControls);
    }

    void PaymentForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (!this.IsSearchConditionNull)
        {
            if (!this.IsPostBack)
            {
                this.lblEmail.Text = Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email;
                this.txtEmail.Text = Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email;
                SetValidationGroup();
                if (!string.IsNullOrEmpty(Request.QueryString["ErrMsg"]))
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + Request.QueryString["ErrMsg"] + "');</script>");
            }
        }
        else
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=" + Resources.HintInfo.err1 + "&&GoToPage=~/Page/Hotel2/PaymentForm.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NavigationControl1.PageCode = 3;
        }
        Header1.Path = "../../";
    }

    private void SendEmail(ISaleOrderService pSaleOrderService)
    {
        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
        mailMessage.To.Add(new MailAddress(((Contact)Utility.Transaction.CurrentTransactionObject.GetContacts()[0]).Person.Email));
        mailMessage.IsBodyHtml = true;
        mailMessage.Subject = pSaleOrderService.CaseNumber + "(B2C - Preliminary Confirmation)";
        string strEmail = string.Empty;
        strEmail = flagSearch.Value;
        strEmail = strEmail.Replace("$ORDERNUMBER", pSaleOrderService.CaseNumber);
        strEmail = strEmail.Replace("$RECORDLOCATOR", pSaleOrderService.RcordLocator);
        Contact contact = (Contact)Utility.Transaction.CurrentTransactionObject.GetContacts()[0];
        strEmail = strEmail.Replace("$NAME", contact.Person.FirstName + " " + contact.Person.MiddleName + " " + contact.Person.LastName);

        mailMessage.Body = strEmail;

        Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2C");
    }
    protected void ibtnSubmit_Click(object sender, EventArgs e)
    {
        if (!CreditCardInformation1.PaddingPassengerInfo())
        {
            return;
        }

        if (Utility.Transaction.CurrentTransactionObject == null)
        {

        }
        else
        {
            if (!m_SaleOrderService.MoreOrders(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member))
            {
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script>alert('Your ordering information with the number of orders for the xxxxxx duplication, please contact customer service 1-888-288-7528.')</script>");
                return;
            }

            try
            {
                string RegularExpressions = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

                if (txtEmail.Text != "")
                {

                    Match m = Regex.Match(this.txtEmail.Text, RegularExpressions);

                    if (!m.Success)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + Resources.HintInfo.err14 + "');</script>");
                        return;
                    }
                    Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email = this.txtEmail.Text;

                }
                else
                {

                    Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email = this.lblEmail.Text;
                }

                SendEmailViewControl1.BindValueToControls();

                System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo(UserCulture.ToString(), true);
                System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
                System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
                oHtmlTextWriter.AddAttribute(HtmlTextWriterAttribute.Class, "T_table");
                this.SendEmailViewControl1.RenderControl(oHtmlTextWriter);

                flagSearch.Value = oHtmlTextWriter.InnerWriter.ToString();

                Utility.Transaction.EmailVersion = flagSearch.Value;

                this.Response.Redirect(PageUtility.SecureUrlSuffix + "page/Common/SaveOrderWaiting.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);

            }
            catch (Exception ex)
            {
                string strError = ex.Message.Replace("\r", " ").Replace("\n", " ");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + strError + "');</script>");
                return;
            }
        }
    }

    private void SetValidationGroup()
    {
        //CreditCardInformation1.ValidationGroup = "PackageCreditForm";
        this.ibtnSubmit.ValidationGroup = "PackageCreditForm";
    }
}

