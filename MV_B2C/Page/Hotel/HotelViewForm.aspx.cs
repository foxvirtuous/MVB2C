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

using log4net;
using Spring.Web.UI;

using Terms.Product.Domain;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Service;

public partial class HotelViewForm : SalseBasePage
{
    private OrderTermsConditionsService m_OrderTermsConditionsService;

    protected OrderTermsConditionsService OrderTermsConditionsService
    {
        get
        {
            return m_OrderTermsConditionsService;

        }
        set
        {
            m_OrderTermsConditionsService = value;
        }
    }

    public HotelViewForm()
    {
        this.InitializeControls += new EventHandler(HotelViewForm_InitializeControls);
    }

    void HotelViewForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (Utility.IsLogin)
        {
            if (Utility.IsSubAgent)
            {
                //divSubagent.Visible = true;
            }
            divLongin.Visible = true;
            UserLogin1.Visible = false;
            divHead.Visible = false;
        }
        else
        {
            divLongin.Visible = false;
            UserLogin1.Visible = true;
            UserLogin1.NextUrl = "~/Page/Hotel/HotelTravelerForm.aspx";
            UserLogin1.ReturnUrl = "~/Page/Hotel/HotelViewForm.aspx";
            divHead.Visible = true;
        }
        if (!this.IsSearchConditionNull)
        {
            ctlNavigationControl.PageCode = 2;

            InitSet();

            DeleteHotelById();

            decimal decSum = 0M;

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                decSum += ((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).TotalPrice;
            }

            lblSum.Text = decSum.ToString("N2");
        }
        else
        {
            //出错处理
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The search condition has been removed from cache, please re-search.&&GoToPage=~/Page/Hotel/HotelViewForm.aspx");
        }
    }

    private void InitSet()
    {
        //获取Terms Conditions
        string ConditionsType = "";
        if (this.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            ConditionsType = "MVPackage";
        }
        if (this.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            ConditionsType = "MVHotel";
        }

        Terms.Sales.Domain.TermsConditionsMeta TermsCondtions = m_OrderTermsConditionsService.GetTermsConditions(ConditionsType);
        if (TermsCondtions != null)
        {
            lbConditons.Text = TermsCondtions.Conditions;
            this.Transaction.TermsConditions = TermsCondtions.Conditions;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (this.chkConditions.Checked)
        {
            if (Utility.IsSubAgent)
            {
                if (!string.IsNullOrEmpty(this.txtSubagentMarkup.Text))
                {
                    try
                    {
                        decimal decmarkup = Convert.ToDecimal(txtSubagentMarkup.Text);

                        if (decmarkup <= 0M)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Markup format input error');</script>");
                            return;
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
                        return;
                    }
                }
            }
            this.Response.Redirect("HotelTravelerForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            //错误
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please read Terms & Conditions, And cancels elects');</script>");
            return;
        }
    }

    private void DeleteHotelById()
    {
        if (this.Request["Delete"] != null)
        {
            if (this.Request["Delete"].Trim().ToUpper() == "Y".Trim().ToUpper())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>return confirm('are you sure?');</script>");

                string strID = this.Request["HotelID"].Trim().ToUpper();

                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Room.Hotel.HotelCode == strID)
                    {
                        Utility.Transaction.CurrentTransactionObject.Items.Remove(Utility.Transaction.CurrentTransactionObject.Items[i]);
                    }
                }

                if (Utility.Transaction.CurrentTransactionObject.Items.Count == 0)
                {
                    this.Response.Redirect("~/Index.aspx");
                }
            }
        }
    }

    private void AddMarkup()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {
            if (!string.IsNullOrEmpty(txtSubagentMarkup.Text))
            {
                decimal decSum = 0M;

                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    decSum += ((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).TotalPrice;
                }

                decimal decMarkup;
                try
                {
                    decMarkup  = Convert.ToDecimal(lblAgentAdultUnitMarkup.Text);
                }
                catch
                {
                    decMarkup = 0M;
                }
                if (decMarkup >= 0)
                {
                    lblSum.Text = (decSum + decMarkup).ToString("N2");
                }
            }
        }
    }

    protected void txtAgentAdultUnitMarkup_TextChanged(object sender, EventArgs e)
    {
        this.lblAgentAdultUnitMarkup.Text = txtSubagentMarkup.Text; ;

        if (Utility.IsSubAgent)
            {
                //AddMarkup();
            }
       
    }
}
