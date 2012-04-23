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
using Terms.Sales.Business;

public partial class SendEmailViewControl : Spring.Web.UI.UserControl
{
    private string _pnr;
    public string PNR
    {
        get { return this.lblRcordLocator.Text; }
        set { this.lblRcordLocator.Text = value; }
    }

    private string _caseNumber;
    public string CaseNumber
    {
        get { return this.lblCaseNumber.Text; }
        set { this.lblCaseNumber.Text = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.FlightDetailsControl2.IsLetDisplay = false;
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                this.lblCaseNumber.Text = this.Request["CaseNumber"];
            }
            else
            {
                this.lblCaseNumber.Text = this.Request["CaseNumber"];
                this.lblRcordLocator.Text = this.Request["RcordLocator"];
            }
            lbName.Text = Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.FirstName + " " + Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.MiddleName + " " + Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.LastName;
            FlightDetailsControl2.IsSucceed = true;


            if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
            {
                lblSalesName.Text = "Kevin Piao, Tina You or Afra Wang";
                lblSalesEmail.Text = @"<a href='#' class='d07'>kpiao@majestic-vacations.com</a>, <a href='#' class='d07'>tyou@majestic-vacations.com</a>, <a href='#' class='d07'>awang@majestic-vacations.com</a>";
            }
            else if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
            {
                lblSalesName.Text = "Garfield Zhang";
                lblSalesEmail.Text = @"<a href='#' class='d07'>gzhang@majestic-vacations.com</a>";
            }
            else if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                lblSalesName.Text = "Garfield Zhang";
                lblSalesEmail.Text = @"<a href='#' class='d07'>gzhang@majestic-vacations.com</a>";
            }
            else if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                lblSalesName.Text = "Kevin Piao, Tina You or Afra Wang";
                lblSalesEmail.Text = @"<a href='#' class='d07'>kpiao@majestic-vacations.com</a>, <a href='#' class='d07'>tyou@majestic-vacations.com</a>, <a href='#' class='d07'>awang@majestic-vacations.com</a>";
            }
        }
    }

    public void BindValueToControls()
    {
        uclCreditCardEmailControl.BindValueToControls();
    }
}
