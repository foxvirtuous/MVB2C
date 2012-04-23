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

using Terms.Material.Domain;
using Terms.Material.Service;

namespace Terms.Web.Page.Hotel
{
    public partial class SucceedForm : SalseBasePage
    {
        public SucceedForm()
        {
            this.InitializeControls += new EventHandler(SucceedForm_InitializeControls);
        }

        void SucceedForm_InitializeControls(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Navigation1.PageCode = 4;

                if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                {
                    this.lblCaseNumber.Text = this.Request["CaseNumber"];
                }
                else
                {
                    this.lblCaseNumber.Text = this.Request["CaseNumber"];
                    this.lblRcordLocator.Text += this.Request["RcordLocator"];
                    this.lblRcordLocator.Visible = true;
                }

                lblDateNow.Text = DateTime.Now.ToString("MM/dd/yyy hh:mm");

                if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
                {
                    lblSalesName.Text = "Kevin Piao, Tina You or Afra Wang";
                    lblSalesEmail.Text = @"<a href='#' class='d07'>kpiao@majestic-vacations.com</a>, <a href='#' class='d07'>tyou@majestic-vacations.com</a>, <a href='#' class='d07'>awang@majestic-vacations.com</a>";
                }
                else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition)
                {
                    lblSalesName.Text = "Garfield Zhang";
                    lblSalesEmail.Text = @"<a href='#' class='d07'>gzhang@majestic-vacations.com</a>";
                }
                else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                {
                    lblSalesName.Text = "Garfield Zhang";
                    lblSalesEmail.Text = @"<a href='#' class='d07'>gzhang@majestic-vacations.com</a>";
                }
                else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                {
                    lblSalesName.Text = "Kevin Piao, Tina You or Afra Wang";
                    lblSalesEmail.Text = @"<a href='#' class='d07'>kpiao@majestic-vacations.com</a>, <a href='#' class='d07'>tyou@majestic-vacations.com</a>, <a href='#' class='d07'>awang@majestic-vacations.com</a>";
                }
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect(SaleWebSuffix + "Index.aspx");
        }
    }

}
