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

public partial class B2B_Logout : Spring.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.Transaction.Member = null;
        this.Response.Redirect("~/B2B_SUB/Index.aspx");
    }
}
