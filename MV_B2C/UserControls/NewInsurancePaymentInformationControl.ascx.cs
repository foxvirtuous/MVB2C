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
using Terms.Base.Service;
using Terms.Common.Service;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

public partial class NewInsurancePaymentInformationControl : SalesBaseUserControl
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindCountry();
            BindYear();
            BindCardType();
            BindPaymentType();
            BindContact();
        }
    }

    private void BindCountry()
    {
        ListItem itemNew = new ListItem("United States", "US");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("CANADA", "CA");

        ddlCountry.Items.Add(itemNew);

        ddlCountry.SelectedIndex = 0;

        ddlCountry_SelectedIndexChanged(new object(), new EventArgs());
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

        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.GetPayments() != null && Utility.Transaction.CurrentTransactionObject.GetPayments().Count > 0)
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
                    Utility.Transaction.CurrentTransactionObject.GetPassengers()[i].LastName.Trim().ToUpper() == this.txtLast.Text.Trim().ToUpper())
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

        payment.Payer.Person = new TERMS.Common.Person(this.txtFirstName.Text, this.txtLastName.Text);

        TERMS.Common.City city = new TERMS.Common.City();
        city.Name = this.txtCity.Text;
        city.Country.Code = this.ddlCountry.SelectedValue;

        city.ProvinceName = this.ddlState.SelectedItem.Text;

        payment.Payer.Person.AddAddress(new TERMS.Common.Address(city, this.txtStreet.Text, this.txtZip.Text));

        Phone phoneDay = new Phone(new TERMS.Common.Country(), txtArea.Text, this.txtTel.Text, this.txtExt.Text);
        phoneDay.ContactOptions = ContactOptions.DayTime;
        payment.Payer.Person.AddPhone(phoneDay);

        payment.Payer.CompanyName = this.txtCompany.Text;

        Utility.Transaction.CurrentTransactionObject.AddPayment(payment);

        return true;
    }

    private void BindContact()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.GetPayments() != null && Utility.Transaction.CurrentTransactionObject.GetPayments().Count > 0)
        {
            Payment payment = Utility.Transaction.CurrentTransactionObject.GetPayments()[0];

            if (payment.PaymentType == PaymentType.CreditCard)
            {
                trCard1.Visible = true;
                trCard2.Visible = true;
                trCard3.Visible = true;
                trCard4.Visible = true;
                trCard5.Visible = true;
                trCard6.Visible = true;
                trCard7.Visible = true;

                this.ddlPaymentType.SelectedIndex = ddlPaymentType.Items.IndexOf(ddlPaymentType.Items.FindByValue("2"));


                CreditCard creditcard = (CreditCard)payment;

                if (creditcard.CardType == CreditCardType.Master)
                {
                    this.ddlPaymentType.SelectedIndex = ddlPaymentType.Items.IndexOf(ddlPaymentType.Items.FindByValue("0"));
                }
                else if (creditcard.CardType == CreditCardType.Visa)
                {
                    this.ddlCardType.SelectedIndex = ddlCardType.Items.IndexOf(ddlCardType.Items.FindByValue("1"));
                }
                else if (creditcard.CardType == CreditCardType.Discover)
                {
                    this.ddlCardType.SelectedIndex = ddlCardType.Items.IndexOf(ddlCardType.Items.FindByValue("3"));

                    txtCardNumber4.Visible = false;
                    separator5.Visible = false;
                }
                else
                {
                    this.ddlCardType.SelectedIndex = ddlCardType.Items.IndexOf(ddlCardType.Items.FindByValue("2"));
                }

                string[] cardnumbers = creditcard.CardNumber.Split('-');

                if (cardnumbers.Length == 4)
                {
                    txtCardNumber1.Text = cardnumbers[0];
                    txtCardNumber2.Text = cardnumbers[1];
                    txtCardNumber3.Text = cardnumbers[2];
                    txtCardNumber4.Text = cardnumbers[3];
                }

                DateTime cardexpirationdate = creditcard.CardExpirationDate;

                this.ddlMonth.SelectedIndex = ddlMonth.Items.IndexOf(ddlMonth.Items.FindByValue(cardexpirationdate.Month.ToString().PadLeft(2, '0')));

                this.ddlYear.SelectedIndex = ddlYear.Items.IndexOf(ddlYear.Items.FindByValue(cardexpirationdate.Year.ToString().PadLeft(2, '0')));

                txtCardIdentification.Text = creditcard.CardIdentificationNumber;

                txtCreditCardBankName.Text = creditcard.CreditCardBankName;

                txtCreditCardCustomerServicePhoneNumber.Text = creditcard.CreditCardBankTollFreeNumber;

                txtFirst.Text = creditcard.CardHolderFirstName;

                txtLast.Text = creditcard.CardHolderLastName;
            }
            else if (payment.PaymentType == PaymentType.Check)
            {
                trCard1.Visible = false;
                trCard2.Visible = false;
                trCard3.Visible = false;
                trCard4.Visible = false;
                trCard5.Visible = false;
                trCard6.Visible = false;
                trCard7.Visible = false;

                this.ddlPaymentType.SelectedIndex = ddlPaymentType.Items.IndexOf(ddlPaymentType.Items.FindByValue("1"));
            }
            else
            {
                trCard1.Visible = false;
                trCard2.Visible = false;
                trCard3.Visible = false;
                trCard4.Visible = false;
                trCard5.Visible = false;
                trCard6.Visible = false;
                trCard7.Visible = false;

                this.ddlPaymentType.SelectedIndex = ddlPaymentType.Items.IndexOf(ddlPaymentType.Items.FindByValue("0"));
            }


            txtFirstName.Text = payment.Payer.Person.FirstName;
            txtLastName.Text = payment.Payer.Person.LastName;
            txtCompany.Text = payment.Payer.CompanyName;
            txtStreet.Text = payment.Payer.Person.Address[0].AddressString;
            txtCity.Text = payment.Payer.Person.Address[0].City.Name;

            this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText(payment.Payer.Person.Address[0].City.Country.Name.Trim().ToUpper()));
            ddlCountry_SelectedIndexChanged(null, new EventArgs());

            //如果通过查找名称在下拉列表中没查找到就到Code中查找州
            int StateIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(payment.Payer.Person.Address[0].City.ProvinceName.Trim().ToUpper()));
            if (StateIndex >= 0)
            {
                this.ddlState.SelectedIndex = StateIndex;
            }
            else
            {
                this.ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(payment.Payer.Person.Address[0].City.ProvinceName.Trim().ToUpper()));
            }

            txtZip.Text = payment.Payer.Person.Address[0].ZipCode;

            txtTel.Text = payment.Payer.Person.GetPhone(TERMS.Common.ContactOptions.DayTime).Number;
            txtExt.Text = payment.Payer.Person.GetPhone(TERMS.Common.ContactOptions.DayTime).Extension;
            txtArea.Text = payment.Payer.Person.GetPhone(TERMS.Common.ContactOptions.DayTime).AreaCode;
        }
        else if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.GetContacts() != null && Utility.Transaction.CurrentTransactionObject.GetContacts().Count > 0)
        {
            Contact contact = Utility.Transaction.CurrentTransactionObject.GetContacts()[0];

            if (ddlPaymentType.SelectedValue == "1")
            {
                this.txtFirstName.Text = contact.Person.FirstName;
                this.txtLastName.Text = contact.Person.LastName;
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
                this.txtFirstName.Text = contact.Person.FirstName;
                this.txtLastName.Text = contact.Person.LastName;
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
            if (Utility.Transaction.Member != null)
            {
                this.txtFirstName.Text = Utility.Transaction.Member.FirstName;
                this.txtLastName.Text = Utility.Transaction.Member.LastName;
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
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

        ddlState.DataSource = ilist;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Name";
        ddlState.DataBind();
    }
}