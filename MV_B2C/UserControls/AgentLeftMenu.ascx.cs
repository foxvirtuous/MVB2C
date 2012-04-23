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

public partial class AgentLeftMenu : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsLogin)
        {
            if (Utility.Transaction.Member.Source != null && Utility.Transaction.Member.Source.Trim().ToLower() == "Subagent".Trim().ToLower())
            {
                this.divGttglobal.Visible = false;
            }
        }
    }

    protected void lbnMyAccount_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/B2B_SUB/AgentMyAccountForm.aspx");
    }
    protected void lbnUpdateAccount_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/B2B_SUB/AgentUpdateAccountForm.aspx");
    }
    protected void lbnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/B2B_SUB/AgentChangePassword.aspx");
    }

    protected void lbnMyOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/B2B_SUB/AgentOrderSearch.aspx");
    }
    protected void lbnLogOut_Click(object sender, EventArgs e)
    {
        Utility.Transaction.Member = null;
        Response.Redirect("Index.aspx");
    }

    public void ResetControl()
    {
        lbnMyAccount.Enabled = false;
        lbnUpdateAccount.Enabled = false;
        lbnChangePassword.Enabled = false;
        lbnMyOrder.Enabled = false;
    }
}
