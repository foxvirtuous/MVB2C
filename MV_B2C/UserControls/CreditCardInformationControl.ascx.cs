using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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
using Terms.Base.Domain;
using Terms.Base.Utility;
using Terms.Base.Service;

using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

public partial class CreditCardInformationControl : SalesBaseUserControl
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
                this.txtPayerFirst.ValidationGroup = value;
                this.txtPayerLast.ValidationGroup = value;
                this.txtCompany.ValidationGroup = value;
                this.txtTel.ValidationGroup = value;
                this.txtCreditCardBankName.ValidationGroup = value;
                this.txtCreditCardCustomerServicePhoneNumber.ValidationGroup = value;
                this.txtStreet.ValidationGroup = value;
                this.txtCity.ValidationGroup = value;
                this.txtZip.ValidationGroup = value;

                if (Utility.IsSubAgent)
                {
                    this.txtStreet.IsValidEmpty = true;
                    this.txtCity.IsValidEmpty = true;
                    this.txtZip.IsValidEmpty = true;
                    this.txtTel.IsValidEmpty = true;
                }

                this.txtExt.IsValidEmpty = true;
            }
        }
    }

    public CreditCardInformationControl()
    {
        this.InitializeControls += new EventHandler(CreditCardInformationControl_InitializeControls); 
    }

    void CreditCardInformationControl_InitializeControls(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindCountry();
            BindYear();
            BindCardType();
            BindPaymentType();
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

        if (!Utility.IsSubAgent)
        {
            itemNew = new ListItem("CANADA", "CA");

            ddlCountry.Items.Add(itemNew);
        }

        ddlCountry.SelectedIndex = 0;

        ddlCountry_SelectedIndexChanged(new object(), new EventArgs());
    }

    protected void ddlCountry_SelectedIndexChanged(object p, EventArgs eventArgs)
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

        ddlState.DataSource = ilist;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Code";
        ddlState.DataBind();
        ddlState.Items.Insert(0, new ListItem("-SELECT-", "select"));
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

            if (Utility.IsLogin)
                if (Utility.IsSubAgent)
                    ddlPaymentType.Items.Remove(ddlPaymentType.Items.FindByValue("2"));

            ddlPaymentType.SelectedIndex = 0;
        }
    }

    public bool PaddingPassengerInfo()
    {
        if (ddlPaymentType.SelectedValue == "2" && this.ddlCardType.SelectedIndex == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select Card Type.');</script>");
            return false;
        }

        if (Utility.Transaction.CurrentTransactionObject.GetPayments() != null && Utility.Transaction.CurrentTransactionObject.GetPayments().Count > 0)
        {
            Utility.Transaction.CurrentTransactionObject.GetPayments().Clear();
        }

        if (ddlPaymentType.SelectedValue == "2" && Utility.IsSubAgent)
        {
            if (string.IsNullOrEmpty(txtStreet.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter Street.');</script>");
                return false;
            }

            if (string.IsNullOrEmpty(txtCity.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter City.');</script>");
                return false;
            }

            if (string.IsNullOrEmpty(txtZip.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter Zip/Postal Code.');</script>");
                return false;
            }

            if (string.IsNullOrEmpty(txtTel.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter Phone Number Associated With This Billing Address.');</script>");
                return false;
            }

            if (string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select country.');</script>");
                return false;
            }

            if (string.IsNullOrEmpty(ddlState.SelectedValue))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select state.');</script>");
                return false;
            }
            
        }

        Payment payment = null;

        if (ddlPaymentType.SelectedValue == "1" && ddlPaymentType.Visible == true)
        {
            payment = new Check();
        }
        if (ddlPaymentType.SelectedValue == "2" || ddlPaymentType.Visible == false)
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
                    Utility.Transaction.CurrentTransactionObject.GetPassengers()[i].LastName.Trim().ToUpper() == this.txtLast.Text.Trim().ToUpper() &&
                    Utility.Transaction.CurrentTransactionObject.GetPassengers()[i].PassengerType == TERMS.Common.PassengerType.Adult )
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

        payment.Payer.Person = new TERMS.Common.Person(this.txtPayerFirst.Text, this.txtPayerLast.Text);

        TERMS.Common.City city = new TERMS.Common.City();
        city.Name = this.txtCity.Text;
        city.Country.Code = this.ddlCountry.SelectedValue;
        city.ProvinceName = this.ddlState.SelectedValue;

        //if (this.txtStreet.Text.Length > 200)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Street length can not exceed 200 characters.');</script>");
        //    return false;
        //}

        payment.Payer.Person.AddAddress(new TERMS.Common.Address(city, this.txtStreet.Text, this.txtZip.Text));

        Phone phoneDay = new Phone(new TERMS.Common.Country(),"", this.txtTel.Text, this.txtExt.Text);
        phoneDay.ContactOptions = ContactOptions.DayTime;
        payment.Payer.Person.AddPhone(phoneDay);

        //if (this.txtCompany.Text.Length > 50)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Company Name length can not exceed 50 characters.');</script>");
        //    return false;
        //}

        payment.Payer.CompanyName = this.txtCompany.Text;

        Utility.Transaction.CurrentTransactionObject.AddPayment(payment);

        return true;
    }

    private void BindContact()
    {
        if (Utility.IsLogin)
        {
            if (Utility.IsSubAgent)
            {
                Contact contact = Utility.Transaction.CurrentTransactionObject.GetContacts()[0];

                if (ddlPaymentType.SelectedValue == "1")
                {
                    this.txtPayerFirst.Text = contact.Person.FirstName;
                    this.txtPayerLast.Text = contact.Person.LastName;
                    this.txtStreet.Text = contact.Person.Address[0].AddressString;
                    this.txtCity.Text = contact.Person.Address[0].City.Name;
                    this.txtZip.Text = contact.Person.Address[0].ZipCode;
                    this.txtTel.Text = contact.Person.GetPhone(ContactOptions.DayTime).Number;
                    this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText(contact.Person.Address[0].City.Country.Name.Trim().ToUpper()));
                    ddlCountry_SelectedIndexChanged(null, new EventArgs());

                    //如果通过查找名称在下拉列表中没查找到就到Code中查找州
                    int StateIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(contact.Person.Address[0].City.ProvinceName.Trim().ToUpper()));
                    if (StateIndex >= 0)
                    {
                        this.ddlState.SelectedIndex = StateIndex;
                    }
                    else
                    {
                        this.ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(contact.Person.Address[0].City.ProvinceName.Trim().ToUpper()));
                    }
                }
                else if (ddlPaymentType.SelectedValue == "2")
                {
                    this.txtPayerFirst.Text = contact.Person.FirstName;
                    this.txtPayerLast.Text = contact.Person.LastName;
                    this.txtStreet.Text = contact.Person.Address[0].AddressString;
                    this.txtCity.Text = contact.Person.Address[0].City.Name;
                    this.txtZip.Text = contact.Person.Address[0].ZipCode;
                    this.txtTel.Text = contact.Person.GetPhone(ContactOptions.DayTime).Number;
                    this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText(contact.Person.Address[0].City.Country.Name.Trim().ToUpper()));
                    ddlCountry_SelectedIndexChanged(null, new EventArgs());

                    //如果通过查找名称在下拉列表中没查找到就到Code中查找州
                    int StateIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(contact.Person.Address[0].City.ProvinceName.Trim().ToUpper()));
                    if (StateIndex >= 0)
                    {
                        this.ddlState.SelectedIndex = StateIndex;
                    }
                    else
                    {
                        this.ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(contact.Person.Address[0].City.ProvinceName.Trim().ToUpper()));
                    }
                }
            }
            else
            {
                this.txtPayerFirst.Text = Utility.Transaction.Member.FirstName;
                this.txtPayerLast.Text = Utility.Transaction.Member.LastName;
                this.txtStreet.Text = Utility.Transaction.Member.StreetAddress;
                this.txtCity.Text = Utility.Transaction.Member.City;
                this.txtZip.Text = Utility.Transaction.Member.ZipCode;
                this.txtTel.Text = Utility.Transaction.Member.PhoneDay;
                this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(Utility.Transaction.Member.Nation.Trim().ToUpper()));
                ddlCountry_SelectedIndexChanged(null, new EventArgs());

                //如果通过查找名称在下拉列表中没查找到就到Code中查找州
                int StateIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(Utility.Transaction.Member.Province.Trim().ToUpper()));
                if (StateIndex >= 0)
                {
                    this.ddlState.SelectedIndex = StateIndex;
                }
                else
                {
                    this.ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(Utility.Transaction.Member.Province.Trim().ToUpper()));
                }

                
            }
        }
    }
}
