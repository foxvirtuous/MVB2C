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
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Sales.Business;
using TERMS.Common;

public partial class PriceInfoControl : Spring.Web.UI.UserControl
{
    private bool m_IsInsurance = false;
    public bool IsInsurance
    {
        set { m_IsInsurance = value; }
        get
        {
            if (Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
            {
                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is InsuranceOrderItem)
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }
    }

    public decimal AgentMarkup
    {
        get 
        {
            decimal result = 0;

            if (this.txtAgentAdultUnitMarkup.Text.Trim() != "")
            {
                try
                {
                    result = Convert.ToDecimal(this.txtAgentAdultUnitMarkup.Text.Trim());
                }
                catch
                { 
                    //转换成Decimal失败说明没有AgentMarkup
                }
            }

            return result;
        }
    }

    /// <summary>
    /// 机票总价。不包含AgentMarkup和Insurance
    /// </summary>
    public decimal TicketTotalPrice
    {
        get 
        {
            decimal ticketTotalPrice = decimal.Zero;

            if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
            {
                if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
                {
                    int adult = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Adult); //大人数
                    int child = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Child); //小孩数
                    AirOrderItem airOrderItem = (AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];
                    decimal AirTotalPrice = 0.0m; //总价
                    decimal adultTax = 0.0m; //大人单税
                    decimal childTax = 0.0m; //小孩单税
                    decimal adultPrice = 0.0m; //大人含税单价
                    decimal childPrice = 0.0m; //小孩含税单价
                    decimal adultMarkup = 0.0m;
                    decimal childMarkup = 0.0m;
                    decimal adultBasePrice = 0.0m; //大人不含税单价
                    decimal childBasePrice = 0.0m; //小孩不含税单价
                    decimal serviceFee = 10.0m; //PUB的服务费（包括webfare），$5是GTT的，$5是Subagent的，大家都有钱赚

                    if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "COMM" || airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "NET")
                    {
                        adultTax = airOrderItem.Profile.GetParam("ADULT_TAX") == null ? adultTax : Convert.ToDecimal(airOrderItem.Profile.GetParam("ADULT_TAX"));
                        childTax = airOrderItem.Profile.GetParam("CHILD_TAX") == null ? childTax : Convert.ToDecimal(airOrderItem.Profile.GetParam("CHILD_TAX"));

                        childMarkup = airOrderItem.GetPrice().GetMarkup(PassengerType.Child);//Profile.GetParam("CHILD_MARKUP") == null ? childMarkup : Convert.ToDecimal(airOrderItem.Profile.GetParam("CHILD_MARKUP"));
                        adultMarkup = airOrderItem.GetPrice().GetMarkup(PassengerType.Adult);//Profile.GetParam("ADULT_MARKUP") == null ? adultMarkup : Convert.ToDecimal(airOrderItem.Profile.GetParam("ADULT_MARKUP"));

                        adultBasePrice = airOrderItem.Profile.GetParam("PUBLISHED_ADULT_FARE") == null ? adultBasePrice : Convert.ToDecimal(airOrderItem.Profile.GetParam("PUBLISHED_ADULT_FARE"));
                        childBasePrice = airOrderItem.Profile.GetParam("PUBLISHED_CHILD_FARE") == null ? childBasePrice : Convert.ToDecimal(airOrderItem.Profile.GetParam("PUBLISHED_CHILD_FARE"));
                        int commision = airOrderItem.Profile.GetParam("COMMISION") == null ? 0 : Convert.ToInt32(airOrderItem.Profile.GetParam("COMMISION"));

                        if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "NET") commision = 0;

                        if (child > 0)
                            if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "NET")
                                childPrice = airOrderItem.Merchandise.ChildBaseFareWithCCSurcharge + airOrderItem.Merchandise.ChildMarkup + childTax;
                            else
                                if (Convert.ToBoolean(airOrderItem.Profile.GetParam("ISWEBFARE")))
                                    childPrice = childBasePrice + serviceFee + childTax;
                                else
                                    childPrice = childBasePrice * (100 - commision) / 100 + airOrderItem.Merchandise.ChildMarkup + childTax;

                        if (adult > 0)
                            if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "NET")
                                adultPrice = airOrderItem.Merchandise.AdultBaseFareWithCCSurcharge + airOrderItem.Merchandise.AdultMarkup + adultTax;
                            else
                                if (Convert.ToBoolean(airOrderItem.Profile.GetParam("ISWEBFARE")))
                                    adultPrice = adultBasePrice + serviceFee + adultTax;
                                else
                                    adultPrice = adultBasePrice * (100 - commision) / 100 + airOrderItem.Merchandise.AdultMarkup + adultTax;
                    }
                    else
                    {
                        adultTax = airOrderItem.GetPrice().GetTax(PassengerType.Adult);
                        childTax = airOrderItem.GetPrice().GetTax(PassengerType.Child);

                        if (child > 0)
                            childPrice = airOrderItem.GetPrice().GetBase(PassengerType.Child) + airOrderItem.GetPrice().GetMarkup(PassengerType.Child) + childTax;

                        if (adult > 0)
                            adultPrice = airOrderItem.GetPrice().GetBase(PassengerType.Adult) + airOrderItem.GetPrice().GetMarkup(PassengerType.Adult) + adultTax;
                    }

                    ticketTotalPrice = adultPrice * adult + childPrice * child;
                }

                if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
                {
                    //int adult = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(PassengerType.Adult); //大人数
                    //int child = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(PassengerType.Child); //小孩数
                    PackageOrderItem packageOrderItem = (PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];
                    //adultPrice = packageOrderItem.TotalPrice / (adult + child);
                    //childPrice = packageOrderItem.TotalPrice / (adult + child);
                    //this.lbAdultPrice.Text = adultPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                    //this.lbChildPrice.Text = childPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                    //this.lbTotalPrice.Text = packageOrderItem.TotalPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                    ticketTotalPrice = packageOrderItem.TotalPrice;
                }

            }

            return ticketTotalPrice;
        }
    }

    public decimal InsuranceTotalPrice
    {
        get
        {
            decimal insurancePrice = decimal.Zero;

            if (IsInsurance)
            {
                if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
                {
                    if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
                    {
                        int adult = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Adult); //大人数
                        int child = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Child); //小孩数

                        for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                            if (Utility.Transaction.CurrentTransactionObject.Items[i] is InsuranceOrderItem)
                                insurancePrice = ((InsuranceOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).TotalPremiumAmount / (adult + child);
                    }
                }
            }

            return insurancePrice;
        }
    }

    public decimal TotalPrice
    {
        get
        {
            return TicketTotalPrice + AgentMarkup + InsuranceTotalPrice;
        }
    }

    public PriceInfoControl()
    {
        this.InitializeControls += new EventHandler(PriceInfoControl_InitializeControls);
    }

    protected void txtAgentAdultUnitMarkup_TextChanged(object sender, EventArgs e)
    {
        this.lbTotalPrice.Text = TotalPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat); ;
    }

    void PriceInfoControl_InitializeControls(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitBinderInfo();

            InitAgentFlightMarkup();
        }
    }
    public void InitBinderInfo()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {
            int adult = 0;
            int child = 0;
            decimal adultPrice = 0.0m; //大人含税单价
            decimal childPrice = 0.0m; //小孩含税单价
            AirOrderItem airOrderItem = null;
            if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
            {
                lbl_FlightTag.Visible = true;
                adult = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Adult); //大人数
                child = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Child); //小孩数
                airOrderItem = (AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];

                decimal AirTotalPrice = 0.0m; //总价
                decimal adultTax = 0.0m; //大人单税
                decimal childTax = 0.0m; //小孩单税

                decimal adultMarkup = 0.0m;
                decimal childMarkup = 0.0m;

                decimal adultBasePrice = 0.0m; //大人不含税单价
                decimal childBasePrice = 0.0m; //小孩不含税单价
                decimal serviceFee = 10.0m; //PUB的服务费（包括webfare），$5是GTT的，$5是Subagent的，大家都有钱赚

                if (child == 0)
                {
                    this.phChild.Visible = false;
                }
                else
                {
                    this.lbChilds.Text = child.ToString();
                    this.lbChildNum.Text = child.ToString();
                }

                if (adult == 0)
                {
                    this.phAdult.Visible = false;
                }
                else
                {
                    this.lbAdults.Text = adult.ToString();
                    this.lbAdultNum.Text = adult.ToString();
                }
                adultPrice = airOrderItem.Merchandise.AdultBaseFareWithCCSurcharge + airOrderItem.Merchandise.AdultMarkup + airOrderItem.Merchandise.AdultTax;
                childPrice = airOrderItem.Merchandise.ChildBaseFareWithCCSurcharge + airOrderItem.Merchandise.ChildMarkup + airOrderItem.Merchandise.ChildTax;

                AirTotalPrice = (airOrderItem.Merchandise.AdultBaseFareWithCCSurcharge + airOrderItem.Merchandise.AdultMarkup + airOrderItem.Merchandise.AdultTax) * adult
                    + (airOrderItem.Merchandise.ChildBaseFareWithCCSurcharge + airOrderItem.Merchandise.ChildMarkup + airOrderItem.Merchandise.ChildTax) * child;

                this.lbAdultNum.Text = adult.ToString();
                this.lbAdults.Text = adult.ToString();
                if (IsInsurance)
                {
                    for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                    {
                        if (Utility.Transaction.CurrentTransactionObject.Items[i] is InsuranceOrderItem)
                        {
                            decimal decInsurance = ((InsuranceOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).TotalPremiumAmount / (adult + child);

                            decimal InsuranceadultPrice = (decInsurance * adult);

                            decimal InsurancechildPrice = (decInsurance * child);

                            adultPrice += InsuranceadultPrice;

                            childPrice += InsurancechildPrice;

                            AirTotalPrice += (InsuranceadultPrice + InsurancechildPrice);
                        }
                    }
                }
                this.lbAdultPrice.Text = adultPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                this.lbChildPrice.Text = childPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                this.lbTotalPrice.Text = AirTotalPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
            }
            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                lbl_PackageTag.Visible = true;
                adult = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(PassengerType.Adult); //大人数
                child = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(PassengerType.Child); //小孩数
                PackageOrderItem packageOrderItem = (PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];
                adultPrice = packageOrderItem.TotalPrice / (adult + child);
                childPrice = packageOrderItem.TotalPrice / (adult + child);
                this.lbAdultPrice.Text = adultPrice.ToString("#,###.##");//.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                this.lbChildPrice.Text = childPrice.ToString("#,###.##");//.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                this.lbTotalPrice.Text = packageOrderItem.TotalPrice.ToString("#,###.##");//.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                if (child == 0)
                {
                    this.phChild.Visible = false;
                }
                else
                {
                    this.lbChilds.Text = child.ToString();
                    this.lbChildNum.Text = child.ToString();
       
                }

                if (adult == 0)
                {
                    this.phAdult.Visible = false;
                }
                else
                {
                    this.lbAdults.Text = adult.ToString();
 
                }


                this.lbAdultNum.Text = adult.ToString();
                this.lbAdults.Text = adult.ToString();

            }          
        }
    }

    /// <summary>
    /// 同时满足以下条件时，才要求用户输入Agent Flight Markup
    /// 1. 当前用户是Subagent
    /// 2. 当前订购的是Flight产品
    /// 3. 当前订购的机票的类型不是PUB或者WEB Fare
    /// </summary>
    private void InitAgentFlightMarkup()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
            if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
                if (Utility.IsSubAgent)
                {
                    //int temp = 0;
                    decimal decTemp = 0M;

                    //for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                    //{
                    //if (Utility.Transaction.CurrentTransactionObject.Items[i] is SubagentMarkupOrderItem)
                    //{
                    //temp++;
                    //decTemp +=  ((SubagentMarkupOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Markup;

                    decTemp += Utility.Transaction.CurrentTransactionObject.SubagentMarkup.GetTotalMarkup(PassengerType.Adult);
                    //}
                    //}

                    if (decTemp > 0)
                    {
                        this.phAgentFlightMarkup.Visible = true;
                        lblAgentAdultUnitMarkup.Visible = true;
                        lblAgentAdultUnitMarkup.Text = decTemp.ToString("N2");
                        lbTotalPrice.Text = (TotalPrice + decTemp).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat); ;
                    }
                    else
                    {
                        AirOrderItem airOrderItem = (AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];

                        if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() != "PUB")
                            if (!Convert.ToBoolean(airOrderItem.Profile.GetParam("ISWEBFARE")))
                            {
                                this.phAgentFlightMarkup.Visible = true;
                                txtAgentAdultUnitMarkup.Visible = true;
                            }
                    }
                }
    }

    /// <summary>
    /// 同时满足以下条件时，才显示Agent Service Fee
    /// 1. 当前用户是Subagent
    /// 2. 当前订购的是Flight产品
    /// 3. 当前订购的机票的类型是PUB或者WEB Fare
    /// </summary>
    private void InitAgentServiceFee()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
            if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
                if (Utility.IsSubAgent)
                {
                    AirOrderItem airOrderItem = (AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];

                    if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "PUB" || 
                        Convert.ToBoolean(airOrderItem.Profile.GetParam("ISWEBFARE")))
                        {
                            this.phAgentFlightServiceFee.Visible = true;

                            int adult = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Adult); //大人数
                            int child = ((AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(PassengerType.Child); //小孩数
                            int ticketNumber = adult + child;
                            this.lblAgentServiceFeeQuantity.Text = ticketNumber.ToString();
                            this.lblAgentServiceFeeQuantity2.Text = ticketNumber.ToString();
                            this.lblMVServiceFeeQuantity.Text = ticketNumber.ToString();
                            this.lblMVServiceFeeQuantity2.Text = ticketNumber.ToString();

                            string ServiceFee = "5";
                            this.lblAgentServiceFee.Text = ServiceFee;
                            this.lblMVServiceFee.Text = ServiceFee;

                            lbAdultPrice.Text = (Convert.ToDecimal(lbAdultPrice.Text)  - Convert.ToDecimal(ServiceFee) * 2).ToString("N2");
                        }
                }
    }

    public bool AddMarkup()
    {
        bool falg = true;

        if (Utility.IsSubAgent)
        {
            if (!string.IsNullOrEmpty(this.txtAgentAdultUnitMarkup.Text))
            {
                try
                {
                    decimal decmarkup = Convert.ToDecimal(txtAgentAdultUnitMarkup.Text);

                    if (decmarkup <= 0M)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Markup format input error');</script>");
                        return false;
                    }
                    else
                    {
                        //SubagentMarkupOrderItem markup = new SubagentMarkupOrderItem(new TERMS.Business.Centers.ProductCenter.Profiles.SubagentMarkupProfile(""));

                        //markup.Markup = decmarkup;

                        //Utility.Transaction.CurrentTransactionObject.AddItem(markup);

                        Utility.Transaction.CurrentTransactionObject.SubagentMarkup.SetAmount(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(decmarkup));
                    }
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Markup format input error');</script>");
                    return false;
                }
            }
        }

        return falg;
    }
}
