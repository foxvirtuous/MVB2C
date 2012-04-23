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

using log4net;
using Spring.Web.UI;

namespace Terms.Web.Page.Common
{
    public partial class ErrorMessage : SalseBasePage
    {
        public ErrorMessage()
        {
            this.InitializeControls += new EventHandler(ErrorMessage_InitializeControls);
        }

        void ErrorMessage_InitializeControls(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Request["ErrorMessage"] != null)
                {
                    if (string.IsNullOrEmpty(this.ReturnUrlPath))
                    {
                        ErrorMessageLabel.Text = this.Request["ErrorMessage"];
                        HyperLink1.NavigateUrl = "~/Index.aspx";
                        if (this.Request["GoToPage"] != null)
                        {
                            HyperLink2.NavigateUrl = this.Request["GoToPage"];
                        }
                    }
                    else
                    {
                        ErrorMessageLabel.Text = this.Request["ErrorMessage"];
                        HyperLink1.NavigateUrl = "~/Index.aspx";
                        HyperLink2.NavigateUrl = this.ReturnUrlPath;
                        this.ReturnUrlPath = string.Empty;  //清空ReturnUrlPath，防止每次出错都返回此次记录的ReturnUrlPath
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(this.ReturnUrlPath))
                    {
                        if (Application["error"] != null)
                        {
                            ErrorMessageLabel.Text = Application["error"].ToString();
                        }
                        HyperLink1.NavigateUrl = "~/Index.aspx";
                        if (this.Request.RawUrl != null)
                        {
                            HyperLink2.NavigateUrl = this.Request.RawUrl;
                        }
                    }
                    else
                    {
                        if (Application["error"] != null)
                        {
                            ErrorMessageLabel.Text = Application["error"].ToString();
                        }                        
                        HyperLink1.NavigateUrl = "~/Index.aspx";
                        HyperLink2.NavigateUrl = this.ReturnUrlPath;
                        this.ReturnUrlPath = string.Empty; //清空ReturnUrlPath，防止每次出错都返回此次记录的ReturnUrlPath
                    }
                }
            }
        }
    }
}
