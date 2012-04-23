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
using System.IO;
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
using System.Net.Mail;
using Terms.Sales.Utility;
using Resources;
using Spring.Context;
using Spring.Context.Support;
using Terms.Sales.Service.OrderManagements;
using System.Collections.Generic;

public partial class SaveOrderWaiting : SalseBasePage
{
    private SaleOrderService m_SaleOrderService;

    protected SaleOrderService SaleOrderService
    {
        set
        {
            m_SaleOrderService = value;
        }
    }

    public string SelectTourCode
    {
        get
        {
            if (Request["TourCode"] != null)
                return Request["TourCode"].Trim().ToLower();
            else
                return string.Empty;
        }
    }

    private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(typeof(SaveOrderWaiting));

    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        this.SetWebSiteInfomation();
        if (!Page.IsPostBack)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>OnSearch('s');</script>");
        }

        //DoSaveOrder();
    }

    private OrderSaveingResult ordersaveingresult = new OrderSaveingResult();

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.PreRender += new EventHandler(SaveOrderWaiting_PreRender);
    }

    void SaveOrderWaiting_PreRender(object sender, EventArgs e)
    {
        if (Request.Params["IsOnSearch"] != null
            && Request.Params["IsOnSearch"].ToString().Trim().Length > 0)
        {
            if (OrderShoppingCart != null && OrderShoppingCart.CanToBook == true)
            {
                OrderShoppingCart.CanToBook = false;

                DoSaveOrder();

            }
            else
            {
                System.Threading.Thread.Sleep(120000);
                if (!OrderShoppingCart.BookSuccessed)
                {
                    DoSaveOrder();
                }
            }
        }

    }
    #endregion

    private void DoSaveOrder()
    {
        SaleOrderService2 m_SaleOrderService2 = new SaleOrderService2();

        try
        {

            ((log4net.Appender.RollingFileAppender)log.Logger.Repository.GetAppenders()[0]).File = Server.MapPath("../../") + "Logs\\OrderInf" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            {
                if (((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition().Count == 2)
                {
                    m_SaleOrderService.CheckIn = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].DepartureDate;
                    m_SaleOrderService.CheckOut = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[1].DepartureDate;
                }
                else
                {
                    m_SaleOrderService.CheckIn = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].DepartureDate;
                    m_SaleOrderService.CheckOut = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetAddTripCondition()[0].DepartureDate;
                }

                //m_SaleOrderService.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                ordersaveingresult = m_SaleOrderService2.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                //记录Air Booking事件
                if (Utility.IsSubAgent)
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_ClickPurchaseAir, this);
                else
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_ClickPurchaseAir, this);
            }

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                m_SaleOrderService.CheckIn = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn;
                m_SaleOrderService.CheckOut = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut;

                //m_SaleOrderService.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                ordersaveingresult = m_SaleOrderService2.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                //记录Hotel Booking事件
                if (Utility.IsSubAgent)
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_ClickPurchaseHotel, this);
                else
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_ClickPurchaseHotel, this);
            }

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                if (((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetAddTripCondition().Count == 2)
                {
                    m_SaleOrderService.CheckIn = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                    m_SaleOrderService.CheckOut = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[1].DepartureDate;
                }
                else
                {
                    m_SaleOrderService.CheckIn = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                    m_SaleOrderService.CheckOut = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                }

                //m_SaleOrderService.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                ordersaveingresult = m_SaleOrderService2.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                //记录Package Booking事件
                if (Utility.IsSubAgent)
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_ClickPurchasePackage, this);
                else
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_ClickPurchasePackage, this);
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
            {
                //if (((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetAddTripCondition().Count == 2)
                //{
                //    m_SaleOrderService.CheckIn = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                //    m_SaleOrderService.CheckOut = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[1].DepartureDate;
                //}
                //else
                //{
                //    m_SaleOrderService.CheckIn = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                //    m_SaleOrderService.CheckOut = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                //}

                //m_SaleOrderService.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                ordersaveingresult = m_SaleOrderService2.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                //记录Tour Booking事件
                OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_ClickPurchaseTour, this);
            }

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.VehcileSearchCondition)
            {
                ordersaveingresult = m_SaleOrderService2.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                //m_SaleOrderService.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
            }

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.InsuranceSearchCondition)
            {
                ordersaveingresult = m_SaleOrderService2.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
                //m_SaleOrderService.SaveOrder(Utility.Transaction.CurrentTransactionObject, Utility.Transaction.Member);
            }
        }
        catch (Exception ex)
        {
            //OrderShoppingCart.CanToBook = true;

            //string strError = ex.Message.Replace("\r", " ").Replace("\n", " ");
            //strError = strError.Replace((char)10, ' ').Replace((char)13, ' ');
            //if (ex.Message.Contains("MAX_BOOKING_TIME"))
            //    strError = "The Flight is invalid. Please change another one.";
            //if (ex.Message.Contains("ACCT NUMBER"))
            //    strError = "Invalid Credit Card Information";
            ////Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + strError + "');</script>");
            ////捕捉错误,并发送Email
            //string PageName = this.Page.ToString();
            //Spring.Aspects.Error.SystemErrorAdvice systemErrorAdvice = new Spring.Aspects.Error.SystemErrorAdvice();
            //systemErrorAdvice.DoErrorProcess(this, PageName, ex, "ApplicationError");
            //m_SaleOrderService.MessageOrderItem.LogError.Add(strError);
            //log.Info(m_SaleOrderService.MessageOrderItem.GetLogTxt());
            //if (strError.Length > 100)
            //{
            //    strError = strError.Substring(0, 100);
            //}
            ////log4net.Config.BasicConfigurator.Configure(new log4net.Appender.FileAppender(new log4net.Layout.PatternLayout("%d [%t]%-5p %c [%x] - %m%n"), "Logs/OrderInf" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt")); 

            ////log4net.Config.BasicConfigurator.Configure(new log4net.Appender.FileAppender(new log4net.Layout.PatternLayout("%d [%t]%-5p %c [%x] - %m%n"), "Logs/log0318.txt")); 

            //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            //{

            //    Response.Redirect(SecureUrlSuffix + "Page/Common/CreditCardInfoForm.aspx?ErrMsg=" + strError + "&ConditionID=" + Request.Params["ConditionID"]);
            //}
            //else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
            //{
            //    this.Page.Response.Redirect(SaleWebSuffix + "Page/Tour/TourTravelerInfoForm.aspx?ErrMsg=" + strError + "&ConditionID=" + Request.Params["ConditionID"]);
            //}
            //else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            //{
            //    this.Page.Response.Redirect(SecureUrlSuffix + "Page/Package2/CreditCardInformation.aspx?ErrMsg=" + strError + "&ConditionID=" + Request.Params["ConditionID"]);
            //}
            //else
            //{
            //    this.Response.Redirect(SecureUrlSuffix + "Page/Hotel2/PaymentForm.aspx?ErrMsg=" + strError + "&ConditionID=" + Request.Params["ConditionID"]);
            //}
            //return;
        }

        if (ordersaveingresult.Success)
        {
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
            {
                if (string.IsNullOrEmpty(ordersaveingresult.RcordLocator))
                {
                    SendEmail(m_SaleOrderService);

                    Response.Redirect(SaleWebSuffix + "Page/Tour/TourSuccessInfoForm.aspx?CaseNumber=" + ordersaveingresult.CaseNumber + "&TourCode=" + SelectTourCode);
                }
                else
                {
                    SendEmail(m_SaleOrderService);

                    Response.Redirect(SaleWebSuffix + "Page/Tour/TourSuccessInfoForm.aspx?CaseNumber=" + ordersaveingresult.CaseNumber + "&&RcordLocator=" + ordersaveingresult.RcordLocator + "&TourCode=" + SelectTourCode);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(ordersaveingresult.RcordLocator))
                {
                    if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.VehcileSearchCondition)
                    {
                        SendEmailCar(m_SaleOrderService);
                        Response.Redirect(SecureUrlSuffix + "Page/Vehcile/VehcileSuccForm.aspx?CaseNumber=" + ordersaveingresult.CaseNumber + "&ConditionID=" + Request.Params["ConditionID"] + "&VendorCode=" + Request.Params["VendorCode"] + "&CarCode=" + Request.Params["CarCode"]);
                    }
                    else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.InsuranceSearchCondition)
                    {
                        SendEmailNew(m_SaleOrderService);
                        Response.Redirect(SecureUrlSuffix + "Page/Insurance/NewInsuranceSuccessInfoForm.aspx?CaseNumber=" + ordersaveingresult.CaseNumber + "&ConditionID=" + Request.Params["ConditionID"] + "&VendorCode=" + Request.Params["VendorCode"] + "&CarCode=" + Request.Params["CarCode"]);
                    }
                    else
                    {
                        SendEmailNew(m_SaleOrderService);
                        Response.Redirect(SecureUrlSuffix + "Page/Hotel2/SuccForm.aspx?CaseNumber=" + ordersaveingresult.CaseNumber + "&ConditionID=" + Request.Params["ConditionID"]);
                    }
                }
                else
                {
                    SendEmail(m_SaleOrderService);
                    if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                    {
                        Response.Redirect(SecureUrlSuffix + "Page/package2/SucceedFrom.aspx?CaseNumber=" + ordersaveingresult.CaseNumber + "&&RcordLocator=" + ordersaveingresult.RcordLocator + "&ConditionID=" + Request.Params["ConditionID"]);
                    }
                    else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.VehcileSearchCondition)
                    {
                        Response.Redirect(SecureUrlSuffix + "Page/Vehcile/VehcileSuccForm.aspx?CaseNumber=" + ordersaveingresult.CaseNumber);
                    }
                    else
                    {
                        Response.Redirect(SecureUrlSuffix + "Page/Hotel/SucceedForm.aspx?CaseNumber=" + ordersaveingresult.CaseNumber + "&&RcordLocator=" + ordersaveingresult.RcordLocator);
                    }
                }

            }

            
        }
        else
        {
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            {
                Response.Redirect(SecureUrlSuffix + "Page/Common/CreditCardInfoForm.aspx?ErrMsg=" + GetErrorText(ordersaveingresult.Reason) + "&ConditionID=" + Request.Params["ConditionID"]);
            }
            else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
            {
                this.Page.Response.Redirect(SaleWebSuffix + "Page/Tour/TourTravelerInfoForm.aspx?ErrMsg=" + GetErrorText(ordersaveingresult.Reason) + "&ConditionID=" + Request.Params["ConditionID"]);
            }
            else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                this.Page.Response.Redirect(SecureUrlSuffix + "Page/Package2/CreditCardInformation.aspx?ErrMsg=" + GetErrorText(ordersaveingresult.Reason) + "&ConditionID=" + Request.Params["ConditionID"]);
            }
            else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.InsuranceSearchCondition)
            {
                this.Page.Response.Redirect(SecureUrlSuffix + "Page/Insurance/NewInsuranceTravelerInfoForm.aspx?ErrMsg=" + GetErrorText(ordersaveingresult.Reason) + "&ConditionID=" + Request.Params["ConditionID"]);
            }
            else
            {
                Response.Redirect(SecureUrlSuffix + "Page/Hotel2/PaymentForm.aspx?ErrMsg=" + GetErrorText(ordersaveingresult.Reason) + "&ConditionID=" + Request.Params["ConditionID"]);
            }

            return;
        }
        //log.Info(m_SaleOrderService.MessageOrderItem.GetLogTxt());        
    }

    private void SendEmailNew(ISaleOrderService pSaleOrderService)
    {
        MailMessage mailMessage = new MailMessage();


        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");

        if (!Utility.IsSubAgent)
        {
            mailMessage.To.Add(new MailAddress(((Contact)Utility.Transaction.CurrentTransactionObject.GetContacts()[0]).Person.Email));
        }
        else
        {
            mailMessage.To.Add(new MailAddress(Utility.Transaction.Member.EmailAddress ));
        }
        mailMessage.IsBodyHtml = true;
        mailMessage.Subject = ordersaveingresult.CaseNumber + " (B2C - Preliminary Confirmation)";

        string strEmail = string.Empty;

        const string CASENUMBER_TEMP = "<SPAN id=\"SendEmailViewControl1_lblCaseNumber\"></SPAN>";
        const string RECORDLOCATOR_TEMP = "<SPAN id=\"SendEmailViewControl1_lblRcordLocator\"></SPAN>";

        Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace("<span id=\"SendEmailViewControl1_lblCaseNumber\"></span>", CASENUMBER_TEMP);
        Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace("<span id=\"SendEmailViewControl1_lblRcordLocator\"></span>", RECORDLOCATOR_TEMP);

        string CASENUMBER_FINAL = "<SPAN id=\"SendEmailViewControl1_lblCaseNumber\">" + ordersaveingresult.CaseNumber + "</SPAN>";
        string RECORDLOCATOR_FINAL = "<SPAN id=\"SendEmailViewControl1_lblRcordLocator\">" + ordersaveingresult.RcordLocator + "</SPAN>";

        Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace(CASENUMBER_TEMP, CASENUMBER_FINAL);
        Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace(RECORDLOCATOR_TEMP, RECORDLOCATOR_FINAL);
        Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace("$ORDERNUMBER", ordersaveingresult.CaseNumber);
        
        //string strGTANUMBER = string.Empty;

        //if (pSaleOrderService.MyHotelOrderItem != null && pSaleOrderService.MyHotelOrderItem.Count > 0)
        //{
        //    for (int i = 0; i < pSaleOrderService.MyHotelOrderItem.Count ; i++)
        //    {
        //        HotelOrderItem hotel = pSaleOrderService.MyHotelOrderItem[i];

        //        if (hotel.Profile.GetParam("DATASOURCE").ToString().ToUpper() == "GTA")
        //        {
        //            strGTANUMBER = "(" + hotel.Profile.GetParam("TOKEN").ToString() + ")";
        //        }
        //    }
        //}

        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
        {
            bool hotelstate = true;

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                if (Utility.Transaction.CurrentTransactionObject.Items[i] is HotelOrderItem)
                {
                    if (((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).HotelState != 3)
                    {
                        hotelstate = false;
                        break;
                    }
                }
            }

            if (!hotelstate)
            {
                Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace(@"This is the confirmation e-mail", @"This is on request email");
            }
        }


        Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace("$GTANUMBER", ordersaveingresult.ExternalBookingId );

        mailMessage.Body = strEmail + Utility.Transaction.EmailVersion;
        if (this.Transaction.TermsConditions != null && Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
        {
            mailMessage.Body += "<BR>" + "<div class='under_rules'>" + this.Transaction.TermsConditions + "</div>";
        }


        log.Error(mailMessage.Body);

        //#if DEBUG
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
        //#endif

        //Spring.Aspect.Email.EmailUtility.m_GetWebSiteName = GlobalBaseUtility.GetWebSite;
        Session.Add("WebSiteName", GlobalBaseUtility.GetWebSite(Request.Url));

        if (Utility.IsSubAgent)
        {
            if (Utility.Transaction.Member.Source.Trim().ToUpper() == "Subagent".Trim().ToUpper())
            {
                try
                {
                    using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\MemberAccountCode.txt"))
                    {
                        sw.Write(Utility.Transaction.Member.ToString());
                    }
                }
                catch
                {
                    //防止未注释被XXX暴头
                }

                if (Utility.Transaction.Member.AccountCode != null && Utility.Transaction.Member.AccountCode.Trim().Length > 3)
                {
                    string strbrach = Utility.Transaction.Member.AccountCode.Trim().ToUpper();

                    if (strbrach.Length >= 3)
                    {
                        strbrach = strbrach.Substring(strbrach.Length - 3);
                    }

                    string emailPath = string.Empty;

                    emailPath = string.Empty;

                    emailPath = ConfigurationSettings.AppSettings.Get("BranchEmail");

                    if (String.IsNullOrEmpty(emailPath))
                    {
                        emailPath = @"/Config/BranchEmail.xml";
                    }

                    if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + emailPath))
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + emailPath);

                        if (ds.Tables[strbrach] != null)
                        {
                            for (int i = 0; i < ds.Tables[strbrach].Rows.Count; i++)
                            {
                                if (ds.Tables[strbrach].Rows[i]["cc"] != null && ds.Tables[strbrach].Rows[i]["cc"].ToString().Trim().Length > 0)
                                {
                                    mailMessage.CC.Add(ds.Tables[strbrach].Rows[i]["cc"].ToString());
                                }
                                if (ds.Tables[strbrach].Rows[i]["bcc"] != null && ds.Tables[strbrach].Rows[i]["bcc"].ToString().Trim().Length > 0)
                                {
                                    mailMessage.Bcc.Add(ds.Tables[strbrach].Rows[i]["bcc"].ToString());
                                }
                            }
                        }
                    }

                    emailPath = ConfigurationSettings.AppSettings.Get("Email");

                    if (String.IsNullOrEmpty(emailPath))
                    {
                        emailPath = @"/Config/Email.xml";
                    }

                    if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + emailPath))
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + emailPath);
                                                
                        if (ds.Tables["WESTBANK"] != null && ds.Tables["NOWESTBANK"] != null)
                        {
                            try
                            {
                                using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\MemberAccountCode.txt"))
                                {
                                    sw.Write(ds.Tables["WESTBANK"].Rows[0]["bcc"].ToString());
                                }
                            }
                            catch
                            {
                                //防止未注释被XXX暴头
                            }
                            
                            for (int i = 0; i < ds.Tables["WESTBANK"].Rows.Count; i++)
                            {
                                if (ds.Tables["WESTBANK"].Rows[i]["AccountCode"].ToString().Trim().Contains(strbrach))
                                {
                                    if (ds.Tables["WESTBANK"].Rows[i]["bcc"] != null)
                                    {
                                        List<string> emails = new List<string>();

                                        emails.AddRange(ds.Tables["WESTBANK"].Rows[i]["bcc"].ToString().Split(new char[] { ';' }));

                                        for (int xx = 0; xx < emails.Count; xx++)
                                        {
                                            mailMessage.Bcc.Add(emails[xx]);
                                        }
                                    }
                                }
                                else
                                {
                                    if (ds.Tables["NOWESTBANK"].Rows[i]["bcc"] != null)
                                    {
                                        List<string> emails = new List<string>();

                                        emails.AddRange(ds.Tables["NOWESTBANK"].Rows[i]["bcc"].ToString().Split(new char[] { ';' }));

                                        for (int xx = 0; xx < emails.Count; xx++)
                                        {
                                            mailMessage.Bcc.Add(emails[xx]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BHotel", Utility.Transaction.Member.Handler);
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BAir", Utility.Transaction.Member.Handler);
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BPackage", Utility.Transaction.Member.Handler);
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
            {
                //Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BTour", Utility.Transaction.Member.Handler);
                if (((Terms.Sales.Business.TourSearchCondition)Utility.Transaction.CurrentSearchConditions).Region.Trim().ToUpper() == "U.S.")
                {
                    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BTourUS", Utility.Transaction.Member.Handler);
                }
                else
                {
                    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BTourOther", Utility.Transaction.Member.Handler);
                }
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.InsuranceSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BInsurance", Utility.Transaction.Member.Handler);
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
                //Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Tour");

                if (((Terms.Sales.Business.TourSearchCondition)Utility.Transaction.CurrentSearchConditions).Region.Trim().ToUpper() == "U.S.")
                {
                    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2CTourUS");
                }
                else
                {
                    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2CTourOther");
                }
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.InsuranceSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Insurance", Utility.Transaction.Member.Handler);
            }
        }

        //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
        //{
        //    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Hotel");
        //}
        //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
        //{
        //    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Air");
        //}
        //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        //{
        //    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Package");
        //}

        //Spring.Aspect.Email.EmailUtility.SendEmail(mailMessage, "B2C");
    }

    private void SendEmail(SaleOrderService pSaleOrderService)
    {
        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
        if (!Utility.IsSubAgent)
        {
            mailMessage.To.Add(new MailAddress(((Contact)Utility.Transaction.CurrentTransactionObject.GetContacts()[0]).Person.Email));
        }
        else
        {
            mailMessage.To.Add(new MailAddress(Utility.Transaction.Member.EmailAddress));
        }
        mailMessage.IsBodyHtml = true;
        if (Utility.IsSubAgent)
        {
            mailMessage.Subject = ordersaveingresult.CaseNumber + "(B2B - Preliminary Confirmation)";
        }
        else
        {
            mailMessage.Subject = ordersaveingresult.CaseNumber + "(B2C - Preliminary Confirmation)";
        }
        string strEmail = string.Empty;
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
        {
            Contact contact = (Contact)Utility.Transaction.CurrentTransactionObject.GetContacts()[0];
            strEmail = Utility.Transaction.EmailVersion;
            strEmail = strEmail.Replace("$ORDERNUMBER", ordersaveingresult.CaseNumber);
            strEmail = strEmail.Replace("$NAME",contact.Person.FirstName + " " + contact.Person.MiddleName + " " + contact.Person.LastName);
            strEmail = strEmail.Replace("$EMAIL",contact.Person.Email);
            strEmail = strEmail.Replace("$STREET",contact.Person.Address[0].AddressString);
            strEmail = strEmail.Replace("$STATECITY",contact.Person.Address[0].City.Name);
            strEmail = strEmail.Replace("$ZIP",contact.Person.Address[0].ZipCode);
            strEmail = strEmail.Replace("$FAX",contact.Person.Faxes[0].Number);
            strEmail = strEmail.Replace("$DAYPHONE",contact.Person.GetPhone(TERMS.Common.ContactOptions.DayTime).Number);
            strEmail = strEmail.Replace("$EVENINGPHONE",contact.Person.GetPhone(TERMS.Common.ContactOptions.NightTime).Number);

          
            mailMessage.Body = strEmail;
        }
        else
        {
            const string CASENUMBER_TEMP = "<SPAN id=\"SendEmailViewControl1_lblCaseNumber\"></SPAN>";
            const string RECORDLOCATOR_TEMP = "<SPAN id=\"SendEmailViewControl1_lblRcordLocator\"></SPAN>";

            Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace("<span id=\"SendEmailViewControl1_lblCaseNumber\"></span>", CASENUMBER_TEMP);
            Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace("<span id=\"SendEmailViewControl1_lblRcordLocator\"></span>", RECORDLOCATOR_TEMP);

            string CASENUMBER_FINAL = "<SPAN id=\"SendEmailViewControl1_lblCaseNumber\">" + ordersaveingresult.CaseNumber + "</SPAN>";
            string RECORDLOCATOR_FINAL = "<SPAN id=\"SendEmailViewControl1_lblRcordLocator\">" + ordersaveingresult.RcordLocator + "</SPAN>";

            Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace(CASENUMBER_TEMP, CASENUMBER_FINAL);
            Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace(RECORDLOCATOR_TEMP, RECORDLOCATOR_FINAL);

            //string strGTANUMBER = string.Empty;

            //if (pSaleOrderService.MyHotelOrderItem != null && pSaleOrderService.MyHotelOrderItem.Count > 0)
            //{

            //    for (int i = 0; i < pSaleOrderService.MyHotelOrderItem.Count; i++)
            //    {
            //        HotelOrderItem hotel = pSaleOrderService.MyHotelOrderItem[i];

            //        if (hotel.Profile.GetParam("DATASOURCE").ToString().ToUpper() == "GTA")
            //        {
            //            strGTANUMBER = "(" + hotel.Profile.GetParam("TOKEN").ToString() + ")";
            //        }
            //    }
            //}

            Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace("$GTANUMBER", ordersaveingresult.ExternalBookingId);

            mailMessage.Body = strEmail + Utility.Transaction.EmailVersion + "<BR>" + "<div class='under_rules'>" + this.Transaction.TermsConditions + "</div>";
        }

        mailMessage.Body.Replace("$ORDERNUMBER", ordersaveingresult.CaseNumber);

#if DEBUG
			try
			{
                using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\B2BTourEmail.html")) 
				{
					sw.Write( mailMessage.Body);
				}
			}
			catch
			{
				//防止未注释被XXX暴头
			}
#endif
        if (Utility.IsSubAgent)
        {
            if (Utility.Transaction.Member.Source.Trim().ToUpper() == "Subagent".Trim().ToUpper())
            {
                string strbrach = Utility.Transaction.Member.AccountCode.Trim().ToUpper();

                if (strbrach.Length >= 3)
                {
                    strbrach = strbrach.Substring(strbrach.Length - 3);
                }

                //string strbrach = Utility.Transaction.Member.Branch.Replace("GTT", "").Trim().ToUpper();

                string emailPath = string.Empty;

                emailPath = string.Empty;

                emailPath = ConfigurationSettings.AppSettings.Get("BranchEmail");

                if (String.IsNullOrEmpty(emailPath))
                {
                    emailPath = @"/Config/BranchEmail.xml";
                }

                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + emailPath))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + emailPath);

                    if (ds.Tables[strbrach] != null)
                    {
                        for (int i = 0; i < ds.Tables[strbrach].Rows.Count; i++)
                        {
                            if (ds.Tables[strbrach].Rows[i]["cc"] != null && ds.Tables[strbrach].Rows[i]["cc"].ToString().Trim().Length > 0)
                            {
                                mailMessage.CC.Add(ds.Tables[strbrach].Rows[i]["cc"].ToString());
                            }
                            if (ds.Tables[strbrach].Rows[i]["bcc"] != null && ds.Tables[strbrach].Rows[i]["bcc"].ToString().Trim().Length > 0)
                            {
                                mailMessage.Bcc.Add(ds.Tables[strbrach].Rows[i]["bcc"].ToString());
                            }
                        }
                    }
                }

                emailPath = ConfigurationSettings.AppSettings.Get("Email");

                if (String.IsNullOrEmpty(emailPath))
                {
                    emailPath = @"/Config/Email.xml";
                }

                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + emailPath))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + emailPath);

                    if (ds.Tables["WESTBANK"] != null && ds.Tables["NOWESTBANK"] != null)
                    {
                        for (int i = 0; i < ds.Tables["WESTBANK"].Rows.Count; i++)
                        {
                            if (ds.Tables["WESTBANK"].Rows[i]["AccountCode"].ToString().Trim().Contains(strbrach))
                            {
                                if (ds.Tables["WESTBANK"].Rows[i]["bcc"] != null)
                                {
                                    List<string> emails = new List<string>();

                                    emails.AddRange(ds.Tables["WESTBANK"].Rows[i]["bcc"].ToString().Split(new char[] { ';' }));

                                    for (int xx = 0; xx < emails.Count; xx++)
                                    {
                                        mailMessage.Bcc.Add(emails[xx]);
                                    }
                                }
                            }
                            else
                            {
                                if (ds.Tables["NOWESTBANK"].Rows[i]["bcc"] != null)
                                {
                                    List<string> emails = new List<string>();

                                    emails.AddRange(ds.Tables["NOWESTBANK"].Rows[i]["bcc"].ToString().Split(new char[] { ';' }));

                                    for (int xx = 0; xx < emails.Count; xx++)
                                    {
                                        mailMessage.Bcc.Add(emails[xx]);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BHotel", Utility.Transaction.Member.Handler);
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BAir", Utility.Transaction.Member.Handler);
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BPackage", Utility.Transaction.Member.Handler);
            }
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
            {
                //Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BTour", Utility.Transaction.Member.Handler);

                if (((Terms.Sales.Business.TourSearchCondition)Utility.Transaction.CurrentSearchConditions).Region.Trim().ToUpper() == "U.S.")
                {
                    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BTourUS", Utility.Transaction.Member.Handler);
                }
                else
                {
                    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BTourOther", Utility.Transaction.Member.Handler);
                }
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
                //Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Tour");

                if (((Terms.Sales.Business.TourSearchCondition)Utility.Transaction.CurrentSearchConditions).Region.Trim().ToUpper() == "U.S.")
                {
                    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2CTourUS");
                }
                else
                {
                    Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2CTourOther");
                }
            }
        }
        //Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2C");
    }

    private void SendEmailCar(SaleOrderService pSaleOrderService)
    {
        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
        if (!Utility.IsSubAgent)
        {
            mailMessage.To.Add(new MailAddress(((Contact)Utility.Transaction.CurrentTransactionObject.GetContacts()[0]).Person.Email));
        }
        else
        {
            mailMessage.To.Add(new MailAddress(Utility.Transaction.Member.EmailAddress));
        }
        mailMessage.IsBodyHtml = true;
        if (Utility.IsSubAgent)
        {
            mailMessage.Subject = ordersaveingresult.CaseNumber + "(B2B - Preliminary Confirmation)";
        }
        else
        {
            mailMessage.Subject = ordersaveingresult.CaseNumber + "(B2C - Preliminary Confirmation)";
        }
        string strEmail = string.Empty;

        string css = @"<style type='text/css'>";
        css += @"<!--";
        css += @"table.T_table   { font-size: 14px; line-height: 19px; color: #000000; font-family: Verdana;}";
        css += @"table.T_step0l   { background: #FD4C00; border: 0;}";
        css += @"table.T_step02   { border-top:solid #999999 1px; border-bottom:solid #999999 1px; border-left:solid #999999 1px; border-right:solid #999999 1px; border:1;}";
        css += @"table.T_step03   { border-top:solid #CCCCCC 1px; border-bottom:solid #CCCCCC 1px; border-left:solid #CCCCCC 1px; border-right:solid #CCCCCC 1px; border:1;}";
        css += @"tr.R_step01  { background-image: url(../images/bg_s01.gif); font-size: 10px; line-height: 12px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}";
        css += @"tr.R_step02  { background: #EAEAEA;}";
        css += @"tr.R_step03  { background-image: url(../images/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}";
        css += @"tr.R_step04  { background-image: url(../images/bg_s04.gif);}";
        css += @"tr.R_stepbox  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana;}";
        css += @"td.D_stepto  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #F85000; font-family: Verdana;}";
        css += @"td.D_steptf  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #777777; font-family: Verdana;}";
        css += @"td.D_stepon  { background: #F85000;}";
        css += @"td.D_stepof  { background: #CCCCCC;}";
        css += @"tr.R_stepw  { background: #FFFFFF;}";
        css += @"tr.R_stepg  { background: #E9E9E9;}";
        css += @"tr.R_stepo  { background: #FDF1C1;}";
        css += @"td.D_stepb  { color: #FF6600; font-family: Verdana; font-weight: bold;}";
        css += @"td.D_stepr  { color:#000000; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}";
        css += @"td.D_stepg  { color:#000000; font-size: 9px; line-height: 18px; font-family: Verdana;}";
        css += @"td.D_stepl  { background: #CCCCCC;}";
        css += @"tr.R_order  { background: #EEEEEE; height: 25; color: #000000; font-family: Verdana; font-weight: bold;}";
        css += @"tr.R_order03  { background: #FF3300; height: 25; color: #FFFFFF; font-family: Verdana; font-weight: bold;}";
        css += @"tr.R_order01  { background-color: #FFFFFF; height: 25;}";
        css += @"tr.R_order02  { background-color: #E9E9E9; height: 25;}";
        css += @".t01{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;}";
        css += @".t02{ color:#FF3300; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}";
        css += @".t03{ color:#FFFFFF; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}";
        css += @".t04{ color:#000000; font-size: 9px; line-height: 16px; font-family: Verdana;}";
        css += @".t05{ color:#CC0000; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}";
        css += @".t06{ color:#000000; font-size: 14px; line-height: 16px; font-family: Verdana; font-weight: bold;}";
        css += @".t07{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana; font-weight: bold;}";
        css += @".t08{ color:#000000; font-size: 9px; line-height: 16px; font-family: Verdana;}";
        css += @".t09  { color:#000000; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}";
        css += @".t10  { color:#005599; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}";
        css += @".head06{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}";
        css += @"a.d07 {   color: #0000EE; text-decoration: underline; font-family: Verdana;}";
        css += @"a.d07:hover {  color: #0000EE; text-decoration: none; font-family: Verdana;}";
        css += @"input {margin: 1px 1px 1px 1px; font-size: 16px; font-family:Verdana, Arial, Helvetica, sans-serif;}";
        css += @"-->";
        css += @"</style>";

        Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace("$OrderNumber", ordersaveingresult.CaseNumber);
        Utility.Transaction.EmailVersion = Utility.Transaction.EmailVersion.Replace("$Confirmationnumber", ((VehcileOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).BookingId);

        mailMessage.Body = css + Utility.Transaction.EmailVersion;


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
        if (!Utility.IsSubAgent)
        {
            Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Car");
        }
        else
        {
            Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BCar");
        }
    }

    private string GetErrorText(OrderSavingFailedReason type)
    {
        string result = string.Empty;

        switch (type)
        {
            case OrderSavingFailedReason.FlightFareChanged:
                result = "Fare Was Changed";
                break;
            case OrderSavingFailedReason.InvalidCreditCard:
                result = "Credit Card Error: There is issue about credit card informaition";
                break;
            case OrderSavingFailedReason.InvalidCreditCardExpirationDate:
                result = "Credit Card Error: Expiration Date is incorrect. Pls check and re-enter";
                break;
            case OrderSavingFailedReason.InvalidCreditCardNumber:
                result = "Credit Card Error: Numbers are incorrect. Pls check and re-enter";
                break;
            case OrderSavingFailedReason.InvalidFlight:
                result = "Booking Failure";
                break;
            case OrderSavingFailedReason.Unknow:
                result = "Booking Failure";
                break;
            default:
                result = "Booking Failure";
                break;
        }

        return result;
    }
}
