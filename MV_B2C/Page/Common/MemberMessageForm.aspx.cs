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
using Spring.Web.UI;

public partial class MemberMessageForm : Spring.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.UrlReferrer.LocalPath.Contains("MemberChangePwdForm.aspx"))
            lblMessageInfo.Text = " Password updated successfully.";
        if(Request.UrlReferrer.LocalPath.Contains("MemberUpdateAccountForm.aspx"))
            lblMessageInfo.Text = " Account updated successfully.";

        //this.MemberLeftMenu1.ResetControl();

        //Utility.Transaction.Member = null;
    }
}
