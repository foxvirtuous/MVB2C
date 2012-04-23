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

public partial class HotelCreditForm : SalseBasePage
{
    private SaleOrderService m_SaleOrderService;

    protected SaleOrderService SaleOrderService
    {
        set
        {
            m_SaleOrderService = value;
        }
    }

    public HotelCreditForm()
    {
        this.InitializeControls += new EventHandler(HotelCreditForm_InitializeControls);
    }

    void HotelCreditForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (!this.IsSearchConditionNull)
        {
            if (!this.IsPostBack)
            {
                Navigation.PageCode = 3;
                lblDate.Text = DateTime.Now.AddDays(3).Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                this.lblEmail.Text = Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email;
                this.txtEmail.Text = Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email;

                if (!string.IsNullOrEmpty(Request.QueryString["ErrMsg"]))
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + Server.UrlDecode(Request.QueryString["ErrMsg"]) + "');</script>");
            }
        }
        else
        {
            Response.Redirect(SecureUrlSuffix + "Page/Common/ErrorMessage.aspx?ErrorMessage=The search condition has been removed from cache, please re-search.&&GoToPage=" + SecureUrlSuffix + "Page/Hotel/HotelCreditForm.aspx");
        }
    }
    protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
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
            if (!Utility.IsLogin)
            {
                //错误
                return;
            }

            //验证信用卡是否合法
            TERMS.Business.Centers.SalesCenter.CreditCard currentCC = (TERMS.Business.Centers.SalesCenter.CreditCard)Utility.Transaction.CurrentTransactionObject.GetPayments()[0];
            int isCCValid = m_SaleOrderService.ValidateCreditCard(currentCC.CardType,
                currentCC.CardNumber,
                currentCC.CardExpirationDate,
                currentCC.Payer.Person.Address[0].AddressString,
                currentCC.Payer.Person.Address[0].ZipCode);

            if (isCCValid != 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The credit card is invalid.');</script>");
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
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The mail address pattern is wrong');</script>");
                        return;
                    }
                    Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email = this.txtEmail.Text;

                }
                else
                {

                    Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email = this.lblEmail.Text;
                }

                Utility.Transaction.EmailVersion = flagSearch.Value;

                this.Response.Redirect(SecureUrlSuffix + "page/Common/SaveOrderWaiting.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);

                //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
                //{
                //    if (((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition().Count == 2)
                //    {
                //        m_SaleOrderService.CheckIn = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].DepartureDate;
                //        m_SaleOrderService.CheckOut = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[1].DepartureDate;
                //    }
                //    else
                //    {
                //        m_SaleOrderService.CheckIn = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].DepartureDate;
                //        m_SaleOrderService.CheckOut = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].DepartureDate;
                //    }
                //    //Utility.Transaction.CurrentTransactionObject.MemberCode = Utility.Transaction.Member.MemberCode;
                //    //m_SaleOrderService.TransactionObject = Utility.Transaction.CurrentTransactionObject;

                //    m_SaleOrderService.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member.MemberCode);
                //}

                //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                //{
                //    m_SaleOrderService.CheckIn = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn;
                //    m_SaleOrderService.CheckOut = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut;
                //    //Utility.Transaction.CurrentTransactionObject.MemberCode = Utility.Transaction.MemberInformation.MemberCode;
                //    //m_SaleOrderService.TransactionObject = Utility.Transaction.CurrentTransactionObject;

                //    m_SaleOrderService.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member.MemberCode);
                //}

                //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                //{
                //    if (((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetAddTripCondition().Count == 2)
                //    {
                //        m_SaleOrderService.CheckIn = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                //        m_SaleOrderService.CheckOut = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[1].DepartureDate;
                //    }
                //    else
                //    {
                //        m_SaleOrderService.CheckIn = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                //        m_SaleOrderService.CheckOut = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                //    }
                //    //Utility.Transaction.CurrentTransactionObject.MemberCode = Utility.Transaction.MemberInformation.MemberCode;
                //    //m_SaleOrderService.TransactionObject = Utility.Transaction.CurrentTransactionObject;

                //    m_SaleOrderService.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member.MemberCode);
                //}
            }
            catch (Exception ex)
            {
                string strError = ex.Message.Replace("\r", " ").Replace("\n", " ");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + strError + "');</script>");
                return;
            }

            //SendEmail(m_SaleOrderService);

            //if (string.IsNullOrEmpty(m_SaleOrderService.RcordLocator))
            //{
            //    this.Response.Redirect("SucceedForm.aspx?CaseNumber=" + m_SaleOrderService.CaseNumber);
            //}
            //else
            //{
            //    this.Response.Redirect("SucceedForm.aspx?CaseNumber=" + m_SaleOrderService.CaseNumber + "&&RcordLocator=" + m_SaleOrderService.RcordLocator);
            //}

        }
    }

    private void SendEmail(SaleOrderService pSaleOrderService)
    {
        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
        mailMessage.To.Add(new MailAddress(((Contact)Utility.Transaction.CurrentTransactionObject.GetContacts()[0]).Person.Email));
        mailMessage.IsBodyHtml = true;
        mailMessage.Subject = pSaleOrderService.CaseNumber + "(B2C - Preliminary Confirmation)";


        string strEmail = "<div align=center><table border='0' cellpadding='0' style='width: 525pt' width='700'><tr>";
        strEmail += "<td style='padding-right: 0.75pt; padding-left: 0.75pt; padding-bottom: 0.75pt; padding-top: 0.75pt'>";
        strEmail += "<p align='center' style='text-align: center'><em><b><i><font face='Arial' size='4'>";
        strEmail += "<span lang='EN-US' style='font-weight: bold; font-size: 13.5pt; font-family: Arial'>";
        strEmail += "Some portions of your order are not confirmed yet.</span></font></i></b></em><b><font face='Arial' size='4'>";
        strEmail += "<span lang='EN-US' style='font-weight: bold; font-size: 13.5pt; font-family: Arial'><br /></span></font></b><b>";
        strEmail += "<font face='Arial' size='2'><span lang='EN-US' style='font-weight: bold; font-size: 10pt; font-family: Arial'>";
        strEmail += "The confirmation e-mail will be sent out within 3 business days.<br />";
        strEmail += "If you do not hear back from us within 3 business days, pls call us at 1-(888)-288-7528.</span></font></b></p></td></tr></table></div>";
        strEmail += "<table bgcolor='white' border='0' cellpadding='0' cellspacing='0' style='background: white; width: 100%' width='100%'>";
        strEmail += "<tr><td bgcolor='#edf1fa' colspan='2' style='padding-right: 0cm; padding-left: 0cm; background: #edf1fa; padding-bottom: 0cm; padding-top: 0cm'>";
        strEmail += "<h2><b><font color='Black' face='Arial' size='1'><span lang='EN-US' style='font-size: 9pt; font-family: Arial'>Order - ";
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
        {
            strEmail += "Hotel Only";
        }
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
        {
            strEmail += "Flight Only";
        }
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {
            strEmail += "Package (Flight + Hotel)";
        }

        strEmail += "</span></font></b></h2><p ><b><font face='Arial' size='1'>";
        strEmail += "<span lang='EN-US' style='font-weight: bold; font-size: 9pt; font-family: Arial'>&nbsp;Order was placed on: ";
        strEmail += "<span id='EC_lbOrderDateTime'> " + DateTime.Now.ToString("MM dd,yyyy hh:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "</span> Eastern Time </span></font></b></p></td></tr><tr>";
        strEmail += "<td bgcolor='#edf1fa' style='padding-right: 0cm; padding-left: 0cm; background: #edf1fa; padding-bottom: 0cm; width: 46%; padding-top: 0cm' width='46%'>";
        strEmail += "<p ><b><font face='Arial' size='1'><span lang='EN-US' style='font-weight: bold; font-size: 9pt; font-family: Arial'>&nbsp;Booking ID: ";
        strEmail += "<span id='EC_BookingID'>" + pSaleOrderService.CaseNumber + "</span></span></font></b></p></td>";
        strEmail += "<td bgcolor='#edf1fa' style='padding-right: 0cm; padding-left: 0cm; background: #edf1fa; padding-bottom: 0cm; width: 54%; padding-top: 0cm' width='54%'>";
        strEmail += "<p ><b><font face='Arial' size='1'><span lang='EN-US' style='font-weight: bold; font-size: 9pt; font-family: Arial'>";
        if (string.IsNullOrEmpty(pSaleOrderService.RcordLocator))
        {
            strEmail += "Confirmation: N/A </span></font></b></p></td></tr></table>";
        }
        else
        {
            strEmail += "Confirmation: " + pSaleOrderService.RcordLocator + " </span></font></b></p></td></tr></table>";
        }

        mailMessage.Body = strEmail + flagSearch.Value;

        Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2C");
    }
}
