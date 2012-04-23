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

public partial class SearchConditionsMeassageCForm : SalseBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Header1.Path = "../../";
        NavigationControl1.PageCode = 2;

        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
    }
}
