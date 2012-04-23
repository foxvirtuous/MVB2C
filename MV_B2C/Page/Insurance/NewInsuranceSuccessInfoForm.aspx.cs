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

public partial class NewInsuranceSuccessInfoForm : SalseBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StatesControl1.PageCode = 4;
    }
    protected void lbnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewInsuranceSeachMainForm.aspx");
    }
}