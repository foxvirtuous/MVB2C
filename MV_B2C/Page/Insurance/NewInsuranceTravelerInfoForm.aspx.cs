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

public partial class NewInsuranceTravelerInfoForm : SalseBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (!Utility.IsLogin || !Utility.IsSubAgent)
        {
            if (!Utility.IsLogin || !Utility.IsSubAgent)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Searching", @"<script>aa();</script>");
            }
        }

        if (!IsPostBack)
        {
            if (Request.Params["ErrMsg"] != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + Request.Params["ErrMsg"].Trim() + "');</script>");
            }
        }
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        if (!Utility.IsLogin || !Utility.IsSubAgent)
        {
            if (!Utility.IsLogin || !Utility.IsSubAgent)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Searching", @"<script>aa();</script>");
            }

            return;
        }

        btnContinue.Enabled = false;

        bool flag = false;

        flag = NewInsuranceTravelersContactInformationControl1.PaddingPassengerInfo();

        if (flag)
        {
            flag = NewInsurancePaymentInformationControl1.PaddingPassengerInfo();

            if (flag)
            {
                Utility.Transaction.CurrentTransactionObject.Remark = txtRemark.Value;

                SendEmailInsuranceControl1.ReBinder();

                ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>OnSearch('s');</script>");
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("NewInsuranceSeachMainForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
    }

    public NewInsuranceTravelerInfoForm()
    {
        this.PreRender += new EventHandler(NewInsuranceTravelerInfoForm_PreRender);
    }

    void NewInsuranceTravelerInfoForm_PreRender(object sender, EventArgs e)
    {
        if (Request.Params["IsFinised"] != null
            && Request.Params["IsFinised"].ToString().Trim().Length > 0)
        {
            Utility.Transaction.EmailVersion = this.flagSearch.Value;
            Response.Redirect("~/Page/Common/SaveOrderWaiting.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }
}
