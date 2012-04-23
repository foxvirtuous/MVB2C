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

public partial class HotelTravelerInsuranceForm : SalseBasePage
{
    public HotelTravelerInsuranceForm()
    {
        this.InitializeControls += new EventHandler(HotelTravelerInsuranceForm_InitializeControls);
    }

    void HotelTravelerInsuranceForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (!this.IsPostBack)
        {
            cnlNavigationControl.PageCode = 2;
        }
    }
    protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (Utility.IsLogin)
        {
            bool flag = InsuranceControl1.PaddingPassengerInfo();

            if (flag)
            {
                this.Response.Redirect("../Common/CreditCardInfoForm.aspx" + "&ConditionID=" + Request.Params["ConditionID"]);
            }
        }
    }
}
