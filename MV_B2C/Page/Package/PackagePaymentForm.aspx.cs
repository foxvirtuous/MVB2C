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

public partial class PackagePaymentForm : Spring.Web.UI.Page
{
    public PackagePaymentForm()
    {
        this.InitializeControls += new EventHandler(PackagePaymentForm_InitializeControls);
    }

    void PackagePaymentForm_InitializeControls(object sender, EventArgs e)
    {
        
    }
}
