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
using Terms.Sales.Domain;
using Terms.Sales.Service;
using Terms.Sales.Utility;
using Terms.Material.Domain;
using Terms.Base.Domain;
using Terms.Product.Domain;
using System.Globalization;
using TERMS.Business.Centers.SalesCenter;

public partial class ContactViewControl : Spring.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinderContact();
        }
    }

    public void BinderContact()
    {
        if (Utility.Transaction.CurrentTransactionObject.GetContacts() != null && Utility.Transaction.CurrentTransactionObject.GetContacts().Count > 0)
        {
            Contact OrderContract = Utility.Transaction.CurrentTransactionObject.GetContacts()[0];
            this.lbName.Text = OrderContract.Person.FirstName + " " + OrderContract.Person.MiddleName + " " + OrderContract.Person.LastName;
            this.lbEmail.Text = OrderContract.Person.Email;
            this.lbAddress.Text = OrderContract.Person.Address[0].AddressString;
            this.lbState.Text = OrderContract.Person.Address[0].City.ProvinceName;
            this.lbCity.Text = OrderContract.Person.Address[0].City.Name;
            this.lbZipPostCode.Text = OrderContract.Person.Address[0].ZipCode;
            this.lbRemark.Text = Utility.Transaction.CurrentTransactionObject.Remark;
            if (OrderContract.Person.Faxes.Count > 0)
            {
                this.lbFax.Text = OrderContract.Person.Faxes[0].Number;
            }
            this.lbDayTimePhone.Text = OrderContract.Person.GetPhone(TERMS.Common.ContactOptions.DayTime).Number;
            this.lbEveningPhone.Text = OrderContract.Person.GetPhone(TERMS.Common.ContactOptions.NightTime).Number;

            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                lblAccountCode.Text = Utility.Transaction.Member.AccountCode;
            }
            else
            {
                lblAccountCode.Text = "N/L";
            }
        }
    }
}
