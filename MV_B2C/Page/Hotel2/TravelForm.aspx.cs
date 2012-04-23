using System;
using System.Data;
using System.Collections.Generic;
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
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;


public partial class TravelForm : SalseBasePage
{
    public TravelForm()
    {
        this.InitializeControls += new EventHandler(TravelForm_InitializeControls);
    }

    void TravelForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (!this.IsSearchConditionNull)
        {
            if (!this.IsPostBack)
            {
                SetValidationGroup();
            }
        }
        else
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The search condition has been removed from cache, please re-search.&&GoToPage=~/Style1/Hotel/TravelForm.aspx");
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

    private void SetValidationGroup()
    {
        HotelOrderPassengerInfoControl1.ValidationGroup = "TravelForm";
        PHContactInfoControl1.ValidationGroup = "TravelForm";
        this.ibtnSubmit.ValidationGroup = "TravelForm";
    }

    protected void ibtnSubmit_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            Utility.Transaction.CurrentTransactionObject.Remark = this.txtRemark.Value;
            bool flag;
            flag = HotelOrderPassengerInfoControl1.PaddingPassengerInfo();
            if (!flag)
            {
                return;
            }
            flag = PHContactInfoControl1.PaddingPassengerInfo();
            if (!flag)
            {
                return;
            }
            this.Response.Redirect(PageUtility.SecureUrlSuffix + "Page/Hotel2/PaymentForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }
}
