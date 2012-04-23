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

public partial class RemarkAndCall : Spring.Web.UI.UserControl
{
    public RemarkAndCall()
    {
        this.InitializeControls += new EventHandler(RemarkAndCall_InitializeControls);
    }

    void RemarkAndCall_InitializeControls(object sender, EventArgs e)
    {
        
    }
}
