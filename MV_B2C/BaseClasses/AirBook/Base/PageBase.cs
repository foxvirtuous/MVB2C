using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using System.Globalization;
using System.Text;


namespace AirBook.Base
{

    public class PageBase : System.Web.UI.Page
    {
        protected string PATH = "";
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new EventHandler(PageBase_Load);
            this.PreRender += new EventHandler(PageBase_PreRender);
            this.Error += new EventHandler(PageBase_Error);
        }

        private void PageBase_Load(object sender, EventArgs e)
        {
            //PersistScrollPosition();
        }

        private void PageBase_PreRender(object sender, EventArgs e)
        {

        }

        private void PageBase_Error(object sender, EventArgs e)
        {

        }

        protected void Err(string error, string errorFlag, string ErrPageName)
        {
            string[] errorMessage = new string[3];

            errorMessage[0] = error;
            errorMessage[1] = errorFlag;
            errorMessage[2] = ErrPageName;

            Session["Error"] = errorMessage;
            Response.Redirect(PATH + "Error.aspx");
        }

        protected bool IsKeepingScrollPosition = false;

        private void PersistScrollPosition()
        {
            StringBuilder saveScrollPosition = new StringBuilder();
            StringBuilder setScrollPosition = new StringBuilder();

            RegisterHiddenField("__SCROLLPOS", "0");

            saveScrollPosition.Append("<script language='javascript'>");
            saveScrollPosition.Append("function saveScrollPosition() {");
            saveScrollPosition.Append(" document.forms[0].__SCROLLPOS.value = document.documentElement.scrollTop;");
            saveScrollPosition.Append("}");
            saveScrollPosition.Append("document.documentElement.onscroll=saveScrollPosition;");
            saveScrollPosition.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "saveScroll", saveScrollPosition.ToString());

            if (Page.IsPostBack && IsKeepingScrollPosition)
            {
                setScrollPosition.Append("<script language='javascript'>");
                setScrollPosition.Append("function setScrollPosition() {");
                setScrollPosition.Append(" document.documentElement.scrollTop = " + Request["__SCROLLPOS"] + ";");
                setScrollPosition.Append("}");
                setScrollPosition.Append("document.body.onload=setScrollPosition;");
                setScrollPosition.Append("</script>");

                ClientScript.RegisterStartupScript(this.GetType(), "setScroll", setScrollPosition.ToString());
            }
        }
    }
}
