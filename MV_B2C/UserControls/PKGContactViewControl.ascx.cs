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

using Terms.Common.Service;
using Terms.Common.Dao;
using Terms.Common.Domain;
using Terms.Sales.Service;
using Terms.Sales.Dao;
using Terms.Sales.Domain;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

public partial class PKGContactViewControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinderContact();
        }
    }

    private void BinderContact()
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
    }
}
