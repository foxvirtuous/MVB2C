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

public partial class PackageTraveler2From : Spring.Web.UI.Page
{
    public PackageTraveler2From()
    {
        this.InitializeControls += new EventHandler(PackageTraveler2From_InitializeControls);
    }

    void PackageTraveler2From_InitializeControls(object sender, EventArgs e)
    {
        
    }

}
