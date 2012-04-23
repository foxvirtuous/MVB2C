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


    public partial class PromosSuccForm : SalseBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Header1.SetLanguageAndPhone();
        }

        protected void hkBack_Click(object sender, EventArgs e)
        {
            if (Request.Params["ConditionID"] != null)
            {
                this.Response.Redirect("PromosAirListForm.aspx?ConditionID=" + Request.Params["ConditionID"]);
            }
            else
            {
                this.Response.Redirect("~/flytochina.aspx");
            }
        }
    }
