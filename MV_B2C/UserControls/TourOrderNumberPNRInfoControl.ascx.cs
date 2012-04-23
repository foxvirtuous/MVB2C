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

public partial class TourOrderNumberPNRInfoControl : Spring.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblCaseNumber.Text = this.Request["CaseNumber"];
        //this.lblRcordLocator.Text += this.Request["RcordLocator"];
        //this.lblRcordLocator.Visible = true;
    }
}
