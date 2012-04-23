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

public partial class UserControls_DropDownList : System.Web.UI.UserControl
{
    /// <summary>
    /// CSSÑùÊ½
    /// </summary>
    public string CssClass
    {
        set
        {
            ddlBase.CssClass = value;
        }
    }

    public DropDownList BaseControl
    {
        get
        {
            return ddlBase;
        }
        set
        {
            ddlBase = value;
        }
    }
}
