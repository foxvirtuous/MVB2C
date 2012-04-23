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
using System.IO;
using Terms.Material.Domain;
using Terms.Material.Service;
using Terms.Sales.Service;
using System.Net.Mail;

public partial class SucceedForm : SalseBasePage
{
    private SaleOrderService m_SaleOrderService;

    protected SaleOrderService SaleOrderService
    {
        set
        {
            m_SaleOrderService = value;
        }
    }

    public SucceedForm()
    {
        this.InitializeControls += new EventHandler(SucceedForm_InitializeControls);
        this.PreRender += new EventHandler(SucceedForm_PreRender);
    }

    void SucceedForm_PreRender(object sender, EventArgs e)
    {
        if (flagSearch.Value.Length > 0)
        {
            SendEmail(m_SaleOrderService);

            this.flagSearch.Value = "";
        }
    }

    void SucceedForm_InitializeControls(object sender, EventArgs e)
    {
        this.StatesControl1.PageCode = 4;
        this.btnPrint.Attributes["onClick"] = "javascript:doPrint();return true;";
        if (!this.IsPostBack)
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                this.lblCaseNumber.Text = this.Request["CaseNumber"];
            }
            else
            {
                this.lblCaseNumber.Text = this.Request["CaseNumber"];
                this.lblRcordLocator.Text = this.Request["RcordLocator"];
            }

            this.SendEmailViewControl1.PNR = m_SaleOrderService.RcordLocator;
            this.SendEmailViewControl1.CaseNumber = m_SaleOrderService.CaseNumber;

            this.Page.RegisterStartupScript("Searching1", "<script language='javascript'>OnSearch();</script>");

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            {
                lblSalesName.Text = "Afra Wang, Andrew Shang or Sara Yoon";
                lblSalesEmail.Text = @"<a href='#' class='d07'>awang@majestic-vacations.com</a>, <a href='#' class='d07'>ashang@majestic-vacations.com</a>, <a href='#' class='d07'>syoon@majestic-vacations.com</a>";
            }
            else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
            {
                lblSalesName.Text = "Garfield Zhang";
                lblSalesEmail.Text = @"<a href='#' class='d07'>gzhang@majestic-vacations.com</a>";
            }
            else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                lblSalesName.Text = "Garfield Zhang";
                lblSalesEmail.Text = @"<a href='#' class='d07'>gzhang@majestic-vacations.com</a>";
            }
            else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                lblSalesName.Text = "Afra Wang, Andrew Shang or Sara Yoon";
                lblSalesEmail.Text = @"<a href='#' class='d07'>gzhang@majestic-vacations.com</a>, <a href='#' class='d07'>ashang@majestic-vacations.com</a>, <a href='#' class='d07'>syoon@majestic-vacations.com</a>";
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(SaleWebSuffix + "Index.aspx");
    }

    private void SendEmail(SaleOrderService pSaleOrderService)
    {

        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
        mailMessage.To.Add(new MailAddress(Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email));
        mailMessage.IsBodyHtml = true;
        mailMessage.Subject = pSaleOrderService.CaseNumber + "(B2C - Preliminary Confirmation)";

        string strEmail = "<style type='text/css'>";
        strEmail += "table.T_table   { font-size: 14px; line-height: 19px; color: #000000; font-family: Verdana;}";
        strEmail += "table.T_step0l   { background: #FD4C00; border: 0;}";
        strEmail += "table.T_step02   { background: #999999; border: 0;}";
        strEmail += "table.T_step03   { background: #CCCCCC; border: 0;}";
        strEmail += "tr.R_step01  { background-image: url(../images/bg_s01.gif); font-size: 10px; line-height: 12px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}";
        strEmail += "tr.R_step02  { background: #EAEAEA;}";
        strEmail += "tr.R_step03  { background-image: url(../images/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}";
        strEmail += "tr.R_step04  { background-image: url(../images/bg_s04.gif);}";
        strEmail += "tr.R_stepbox  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana;}";
        strEmail += "td.D_stepto  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #F85000; font-family: Verdana;}";
        strEmail += "td.D_steptf  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #777777; font-family: Verdana;}";
        strEmail += "td.D_stepon  { background: #F85000;}";
        strEmail += "td.D_stepof  { background: #CCCCCC;}";
        strEmail += "tr.R_stepw  { background: #FFFFFF;}";
        strEmail += "tr.R_stepg  { background: #E9E9E9;}";
        strEmail += "tr.R_stepo  { background: #FDF1C1;}";
        strEmail += "td.D_stepb  { color: #FF6600; font-family: Verdana; font-weight: bold;}";
        strEmail += "td.D_stepr  { color:#000000; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}";
        strEmail += "td.D_stepg  { color:#000000; font-size: 9px; line-height: 18px; font-family: Verdana;}";
        strEmail += "td.D_stepl  { background: #CCCCCC;}";
        strEmail += "tr.R_order  { background: #EEEEEE; height: 25; color: #000000; font-family: Verdana; font-weight: bold;}";
        strEmail += "tr.R_order03  { background: #FF3300; height: 25; color: #FFFFFF; font-family: Verdana; font-weight: bold;}";
        strEmail += "tr.R_order01  { background-color: #FFFFFF; height: 25;}";
        strEmail += "tr.R_order02  { background-color: #E9E9E9; height: 25;}";
        strEmail += ".t01{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;}";
        strEmail += ".t02{ color:#FF3300; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}";
        strEmail += ".t03{ color:#FFFFFF; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}";
        strEmail += ".t04{ color:#000000; font-size: 9px; line-height: 16px; font-family: Verdana;}";
        strEmail += ".t05{ color:#CC0000; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}";
        strEmail += ".t06{ color:#000000; font-size: 14px; line-height: 16px; font-family: Verdana; font-weight: bold;}";
        strEmail += ".t07{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana; font-weight: bold;}";
        strEmail += ".t08{ color:#000000; font-size: 9px; line-height: 16px; font-family: Verdana;}";
        strEmail += ".t09  { color:#000000; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}";
        strEmail += ".t10  { color:#005599; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}";
        strEmail += ".head06{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}";
        strEmail += "a.d07 {   color: #0000EE; text-decoration: underline; font-family: Verdana;}";
        strEmail += "a.d07:hover {  color: #0000EE; text-decoration: none; font-family: Verdana;}</style>";

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

        if (string.IsNullOrEmpty(pSaleOrderService.RcordLocator))
        {
            strEmail += "Confirmation: N/A </span></font></b></p></td></tr></table>";
        }
        else
        {
            strEmail += "Confirmation: " + pSaleOrderService.RcordLocator + " </span></font></b></p></td></tr></table>";
        }

        mailMessage.Body = strEmail + TextBox1.Text + "<BR>" +this.Transaction.TermsConditions;

#if DEBUG
			try
			{
                using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\B2BTourEmail.html")) 
				{
					sw.Write(mailMessage.Body);
				}
			}
			catch
			{
				//防止未注释被XXX暴头
			}
#endif
        if (Utility.IsSubAgent)
        {
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BHotel");
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BAir");
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BPackage");
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BTour");
            }
        }
        else
        {
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Hotel");
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Air");
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Package");
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Tour");
            }
        }

        //Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2C");
    }
}
