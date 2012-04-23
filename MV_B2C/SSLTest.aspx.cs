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

namespace Terms.Web
{
    public partial class SSLTest : SalseBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            Response.Write(HttpContext.Current.Request.Url.Host);
            Response.Write(SaleWebSuffix + "Page/common/Sign.aspx");
        }
    }
}
