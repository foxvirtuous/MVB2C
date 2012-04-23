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
using log4net;

public partial class PackageCreditForm : Spring.Web.UI.Page
{
    public PackageCreditForm()
    {
        this.InitializeControls += new EventHandler(PackageCreditForm_InitializeControls);
    }

    void PackageCreditForm_InitializeControls(object sender, EventArgs e)
    {
        
    }

    protected void btnPurchase_Click(object sender, ImageClickEventArgs e)
    {

    }
}
