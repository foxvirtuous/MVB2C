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

public partial class AgentJoinSucceedForm : SalseBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Request["Return"] != null)
            {
                this.hlReturn.NavigateUrl = "~/" + this.Request["Return"];
            }
            else
            {
                this.hlReturn.NavigateUrl = "~/B2B_SUB/Index.aspx";
            }
        }
    }
}
