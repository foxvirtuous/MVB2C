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

public partial class TravelerInfoOfInsuranceControl : Spring.Web.UI.UserControl
{
    public TravelerInfoOfInsuranceControl()
    {
        this.InitializeControls += new EventHandler(TravelerInfoOfInsuranceControl_InitializeControls);
    }

    void TravelerInfoOfInsuranceControl_InitializeControls(object sender, EventArgs e)
    {
        
    }
}
