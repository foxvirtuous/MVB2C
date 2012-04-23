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
using System.Collections.Generic;
using Spring.Web.UI;
using log4net;
using Terms.Sales.Service;
using Terms.Sales.Utility;
using Terms.Base.Domain;
using System.Globalization;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Common;

public partial class HTLContactControl : Spring.Web.UI.UserControl
{
    private Contact _orderContract;
    public Contact OrderContract
    {
        set { _orderContract = value; }
        get { return _orderContract; }
    }

    public HTLContactControl()
    {
        this.InitializeControls += new EventHandler(HTLContactControl_InitializeControls);
    }

    private void HTLContactControl_InitializeControls(object sender, EventArgs e)
    {
        if (Utility.Transaction.CurrentTransactionObject != null)
        {
            if (!IsPostBack)
            {
                SetCondition();
                BinderContact();
            }
        }
        else
        {
            //³ö´í´¦Àí
        }

    }


    private void SetCondition()
    {
        OrderContract = Utility.Transaction.CurrentTransactionObject.Contacts[0];
    }

    private void BinderContact()
    {
        OrderContract = Utility.Transaction.CurrentTransactionObject.Contacts[0];
        this.lbName.Text = OrderContract.Person.FirstName + " " + OrderContract.Person.MiddleName + " " + OrderContract.Person.LastName;
        this.lbEmail.Text = OrderContract.Person.Email;

        if (OrderContract.Person.Address.Count > 0)
        {
            this.lbAddress.Text = OrderContract.Person.Address[0].AddressString;
            this.lbStateCity.Text = OrderContract.Person.Address[0].City.Name;
            this.lbZipPostCode.Text = OrderContract.Person.Address[0].ZipCode;
        }

        if (OrderContract.Person.Faxes.Count > 0)
            this.lbFax.Text = OrderContract.Person.GetFax(TERMS.Common.ContactOptions.Office).Number;

        if (OrderContract.Person.Phones.Count > 0)
        {
            this.lbDayTimePhone.Text = OrderContract.Person.GetPhone(TERMS.Common.ContactOptions.DayTime).Number;
            this.lbEveningPhone.Text = OrderContract.Person.GetPhone(TERMS.Common.ContactOptions.NightTime).Number;
        }
    }
}