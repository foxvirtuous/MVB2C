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
using Terms.Base.Domain;
using Terms.Base.Utility;
using Terms.Base.Service;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

public partial class CreditCardInfoControl : GlobalBaseControl
{
     private IBaseService _BaseService;
    public IBaseService BaseService
    {
        set
        {
            this._BaseService = value;
        }
    }
    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    public string ValidationGroup
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                this.txtCardNumber1.ValidationGroup = value;
                this.txtCardNumber2.ValidationGroup = value;
                this.txtCardNumber3.ValidationGroup = value;
                this.txtCardNumber4.ValidationGroup = value;
                this.txtCardIdentification.ValidationGroup = value;
                this.txtFirst.ValidationGroup = value;
                this.txtLast.ValidationGroup = value;
                this.txtPrimaryFirst.ValidationGroup = value;
                this.txtPrimaryLast.ValidationGroup = value;
                this.txtCompany.ValidationGroup = value;
                this.txtStreet.ValidationGroup = value;
                this.txtCity.ValidationGroup = value;
                this.txtZip.ValidationGroup = value;
                //this.txtArea.ValidationGroup = value;
                this.txtTel.ValidationGroup = value;
                this.txtExt.ValidationGroup = value;
                this.txtCreditCardBankName.ValidationGroup = value;
                this.txtCreditCardCustomerServicePhoneNumber.ValidationGroup = value;
            }
        }
    }

    public CreditCardInfoControl()
    {
        this.InitializeControls += new EventHandler(CreditCardInfoControl_InitializeControls); 
    }

    void CreditCardInfoControl_InitializeControls(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindCountry();
            BindYear();
            BindPaymentType();
            BindCardType();
            BindContact();

            if (Utility.IsSubAgent)
            {
                trPaymentType.Visible = true;
            }
            else
            {
                trPaymentType.Visible = false;
            }

            this.txtCompany.MaxLength = 50;
            this.txtStreet.MaxLength = 200;
        }
    }

    private void BindCountry()
    {
        ListItem itemNew = new ListItem("United States", "US");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("CANADA", "CA");

        ddlCountry.Items.Add(itemNew);

        BindState();

    }

    private void BindYear()
    {
        int year = DateTime.Now.Year;

        for (int i = 0; i < 6; i++)
        {
            int temp = year + i;

            ListItem item = new ListItem(temp.ToString(), temp.ToString());

            ddlYear.Items.Insert(i, item);
        }
    }

    private void BindCardType()
    {
        ddlCardType.DataSource = _BaseService.LoadAllTypeDetails(typeof(Terms.Base.Domain.CreditCardType));

        ddlCardType.DataTextField = "Name";
        ddlCardType.DataValueField = "DetailType";
        if (!this.IsPostBack)
        {
            ddlCardType.DataBind();
        }

        ListItem item = new ListItem("-- Select Card Type --", string.Empty);

        ddlCardType.Items.Insert(0, item);
    }

    private void BindPaymentType()
    {
        ddlPaymentType.DataSource = _BaseService.LoadAllTypeDetails(typeof(Terms.Base.Domain.PaymentTypeDetail));

        ddlPaymentType.DataTextField = "Name";
        ddlPaymentType.DataValueField = "DetailType";
        if (!this.IsPostBack)
        {
            ddlPaymentType.DataBind();

            ddlPaymentType.Items.Remove(ddlPaymentType.Items.FindByValue("0"));

            //add zyl  当是subagent网站的时候把信用卡付款拿掉 2009-9-1
            if (Utility.IsSubAgent)
            {
                ddlPaymentType.Items.Remove(ddlPaymentType.Items.FindByValue("2"));
                ddlPaymentType.SelectedIndex = 0;

                trCard1.Visible = false;
                trCard2.Visible = false;
                trCard3.Visible = false;
                trCard4.Visible = false;
                trCard5.Visible = false;
                trCard6.Visible = false;
                trCard7.Visible = false;
            }
            else
            {
                ddlPaymentType.SelectedIndex = 1;
            }
        }
    }

    public bool PaddingPassengerInfo()
    {
        if (string.IsNullOrEmpty(ddlState.SelectedValue))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select state.');</script>");
            return false;
        }

        if (ddlPaymentType.SelectedValue == "2" && this.ddlCardType.SelectedIndex == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select Card Type.');</script>");
            return false;
        }

        if (string.IsNullOrEmpty(ddlCountry.SelectedValue))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select country.');</script>");
            return false;
        }

        if (Utility.Transaction.CurrentTransactionObject.GetPayments() != null && Utility.Transaction.CurrentTransactionObject.GetPayments().Count > 0)
        {
            Utility.Transaction.CurrentTransactionObject.GetPayments().Clear();
        }

        Payment payment = null;

        if (ddlPaymentType.SelectedValue == "1")
        {
            payment = new Check();
        }
        
        if (ddlPaymentType.SelectedValue == "2")
        {
            if (this.ddlCardType.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select Card Type.');</script>");
                return false;
            }

            bool passengers = false;

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.GetPassengers().Count; i++)
            {
                if (Utility.Transaction.CurrentTransactionObject.GetPassengers()[i].FirstName.Trim().ToUpper() == this.txtFirst.Text.Trim().ToUpper() &&
                    Utility.Transaction.CurrentTransactionObject.GetPassengers()[i].LastName.Trim().ToUpper() == this.txtLast.Text.Trim().ToUpper() && Utility.Transaction.CurrentTransactionObject.GetPassengers()[i].PassengerType == TERMS.Common.PassengerType.Adult )
                {
                    passengers = true;
                }
            }
            if (!passengers)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Credit card holder should be one of passengers.');</script>");
                return false;
            }

            payment = new CreditCard();
            ((CreditCard)payment).CardExpirationDate = new DateTime(Convert.ToInt32(this.ddlYear.SelectedValue), Convert.ToInt32(this.ddlMonth.SelectedValue), 1);
            ((CreditCard)payment).CardIdentificationNumber = this.txtCardIdentification.Text;
            ((CreditCard)payment).CardNumber = this.txtCardNumber1.Text + "-" + this.txtCardNumber2.Text + "-" + this.txtCardNumber3.Text + "-" + this.txtCardNumber4.Text;
            ((CreditCard)payment).CardType = (TERMS.Business.Centers.SalesCenter.CreditCardType)Convert.ToInt16(this.ddlCardType.SelectedValue);
            ((CreditCard)payment).CreditCardBankName = txtCreditCardBankName.Text;
            ((CreditCard)payment).CreditCardBankTollFreeNumber = txtCreditCardCustomerServicePhoneNumber.Text;

            //add zyl 2009-9-16
            ((CreditCard)payment).CardHolderFirstName = txtFirst.Text;
            ((CreditCard)payment).CardHolderLastName = txtLast.Text;
        }
        
        payment.Payer = new Payer();

        payment.Payer.CompanyName = this.txtCompany.Text;        

        payment.Payer.Person = new TERMS.Common.Person(this.txtFirst.Text, this.txtLast.Text);

        TERMS.Common.City city = new TERMS.Common.City();

        city.Name = this.txtCity.Text;

        city.Country.Name = ddlCountry.SelectedItem.Text;
        city.ProvinceName = ddlState.SelectedItem.Text;

        TERMS.Common.Address address = new TERMS.Common.Address(city, this.txtStreet.Text, this.txtZip.Text);

        payment.Payer.Person.AddAddress(address);

        TERMS.Common.Country country = new TERMS.Common.Country();

        country.Code = this.ddlState.SelectedValue;

        Phone phone = new Phone(country, "", this.txtTel.Text, this.txtExt.Text);

        phone.ContactOptions = ContactOptions.DayTime;

        payment.Payer.Person.AddPhone(phone);

        Utility.Transaction.CurrentTransactionObject.AddPayment(payment);

        return true;
    }

    private void BindContact()
    {
        if (Utility.IsLogin)
        {
            this.txtFirst.Text = Utility.Transaction.Member.FirstName;
            this.txtLast.Text = Utility.Transaction.Member.LastName;
            this.txtPrimaryFirst.Text = Utility.Transaction.Member.FirstName;
            this.txtPrimaryLast.Text = Utility.Transaction.Member.LastName;
            this.txtStreet.Text = Utility.Transaction.Member.StreetAddress;
            this.txtCity.Text = Utility.Transaction.Member.City;
            this.txtZip.Text = Utility.Transaction.Member.ZipCode;

            this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(Utility.Transaction.Member.Nation));
            ddlCountry_SelectedIndexChanged(null, new EventArgs());
            this.ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(Utility.Transaction.Member.Province));

            //for (int i = 0; i < ddlCountry.Items.Count; i++)
            //{
            //    this.ddlCountry.SelectedIndex = i;
            //    ddlCountry_SelectedIndexChanged(null, new EventArgs());
            //    this.ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(Utility.Transaction.Member.Province));
            //    if (ddlState.SelectedIndex == -1)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
        }
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindState();
    }

    private void BindState()
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

        ddlState.DataSource = ilist;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Name";
        ddlState.DataBind();
       // ddlState.Items.Insert(0, new ListItem("-SELECT-", "select"));
    }
}
