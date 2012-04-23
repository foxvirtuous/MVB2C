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

using Terms.Material.Domain;
using Terms.Material.Service;
using Terms.Base.Domain;
using Terms.Base.Utility;
using Terms.Sales.Domain;
using Terms.Sales.Service;
//using Terms.Product.Domain;
using System.Text.RegularExpressions;
using System.Net.Mail;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

public partial class CreditCardInfoForm : SalseBasePage
{
    private SaleOrderService m_SaleOrderService;

    public SaleOrderService SaleOrderService
    {
        set
        {
            m_SaleOrderService = value;
        }
    }

    public CreditCardInfoForm()
    {
        this.InitializeControls += new EventHandler(CreditCardInfoForm_InitializeControls);
        this.PreRender +=new EventHandler(CreditCardInfoForm_PreRender);
    }

    private void CreditCardInfoForm_PreRender(object sender, EventArgs e)
    {
        
    }

    void CreditCardInfoForm_InitializeControls(object sender, EventArgs e)
    {
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (this.IsSearchConditionNull)
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The search condition has been removed from cache, please re-search.&&GoToPage=~/Page/Common/CreditCardInfoForm.aspx");
        }
        else
        {
            this.StatesControl1.PageCode = 3;
            if (!IsPostBack)
            {
                this.lblEmail.Text = Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email;

                if (!string.IsNullOrEmpty(Request.QueryString["ErrMsg"]))
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + Request.QueryString["ErrMsg"] + "');</script>");
            }
            //如果航空公司的CODE是UA，那么不能够订购这张机票

            string strAirlineCode = string.Empty;

            if (ConfigurationManager.AppSettings.Get("HiddenCreditCardAirline") != null)
                strAirlineCode = ConfigurationManager.AppSettings.Get("HiddenCreditCardAirline").ToString().ToUpper();

            bool isAirlineCode = false;

            if (!string.IsNullOrEmpty(strAirlineCode))
            {
                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is PackageOrderItem)
                    {
                        PackageOrderItem packageorderitem = (PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                        foreach (OrderItem orderitem in packageorderitem.Items)
                        {
                            if (orderitem is AirOrderItem)
                            {
                                foreach (SubAirTrip subTrip in ((AirOrderItem)orderitem).Merchandise.AirTrip.SubTrips)
                                {
                                    foreach (AirLeg airleg in subTrip.Flights)
                                    {
                                        if (strAirlineCode.Contains(airleg.AirLine.Code))
                                        {
                                            isAirlineCode = true;
                                            break;
                                        }
                                    }
                                    if (isAirlineCode)
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        if (isAirlineCode)
                        {
                            break;
                        }
                    }
                    else if (Utility.Transaction.CurrentTransactionObject.Items[i] is AirOrderItem)
                    {
                        foreach (SubAirTrip subTrip in ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips)
                        {
                            foreach (AirLeg airleg in subTrip.Flights)
                            {
                                if (strAirlineCode.Contains(airleg.AirLine.Code))
                                {
                                    isAirlineCode = true;
                                    break;
                                }
                            }

                            if (isAirlineCode)
                            {
                                break;
                            }
                        }

                        if (isAirlineCode)
                        {
                            break;
                        }
                    }
                }

                if (isAirlineCode)
                {
                    CreditCardInfoControl1.Visible = false;
                    divCCInfo.Visible = false;
                    divDisplay.Visible = true;
                }
            }
        }    
    }
    protected void btnPurchase_Click(object sender, EventArgs e)
    {
        if (hdFlag.Value == "YES")
        {
            if (this.txtEmail.Text == "")
            {
                //lbMessage.Visible = true;
                //lbMessage.Text = "Please enter e-mail address.";
                //return;
            }
            else
            {
                string RegularExpressions = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

                Match m = Regex.Match(this.txtEmail.Text, RegularExpressions);

                if (!m.Success)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The mail address pattern is wrong');</script>");
                    return;
                }

                Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email = this.txtEmail.Text;
                lbMessage.Visible = false;
                lbMessage.Text = "";
            }
        }
        else
        {
            lbMessage.Visible = false;
            lbMessage.Text = "";
        }

        if (!divDisplay.Visible)
        {
            if (!CreditCardInfoControl1.PaddingPassengerInfo())
            {
                return;
            }
        }
        if (Utility.Transaction.CurrentTransactionObject == null)
        {

        }
        else
        {
            //if (!Utility.IsLogin)
            //{
            //    //错误
            //    return;
            //}

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
                if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
                {
                    //Utility.Transaction.EmailVersion = this.flagSearch.Value;

                    //this.SendEmailViewControl1.PNR = m_SaleOrderService.RcordLocator;
                    //this.SendEmailViewControl1.CaseNumber = m_SaleOrderService.CaseNumber;
                    SendEmailViewControl1.BindValueToControls();

                    System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo(UserCulture.ToString(), true);
                    System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
                    System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
                    this.SendEmailViewControl1.RenderControl(oHtmlTextWriter);

                    flagSearch.Value = oHtmlTextWriter.InnerWriter.ToString();

                    Utility.Transaction.EmailVersion = flagSearch.Value;

                    this.Response.Redirect("~/page/Common/SaveOrderWaiting.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);

                }

                if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                {
                }

                if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                {
                }

            }

            catch (Exception ex)
            {
                string strError = ex.Message.Replace("\r", " ").Replace("\n", " ");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + strError + "');</script>");
                return;
            }
        }
    }

    
}
