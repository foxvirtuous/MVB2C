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

public partial class Page_Common_HeaderPage : Spring.Web.UI.Page
{
    public string PageName
    {
        get
        {
            if (this.Request["pagename"] == null)
            {
                return @"../../Html/aboutus.htm";
            }
            else
            {
                if (this.Request["pagename"].StartsWith("http"))
                {
                    return this.Request["pagename"];
                }
                else
                {
                    return @"../../Html/" + this.Request["pagename"];
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}
