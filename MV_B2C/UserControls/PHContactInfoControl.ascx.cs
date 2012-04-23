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
using Terms.Sales.Service;
using Terms.Sales.Dao;
using Terms.Sales.Domain;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

public partial class ContactInfo : Spring.Web.UI.UserControl
{
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
                this.txtFirst.ValidationGroup = value;

                this.txtMiddle.ValidationGroup = value;

                this.txtLast.ValidationGroup = value;

                this.txtEmail.ValidationGroup = value;

                this.txtPhoneDay.ValidationGroup = value;

                this.txtPhoneNight.ValidationGroup = value;

                this.txtStreet.ValidationGroup = value;

                this.txtCity.ValidationGroup = value;

                this.txtZip.ValidationGroup = value;

                this.txtFax.ValidationGroup = value;

                if (Utility.IsSubAgent)
                {
                    this.txtPhoneDay.IsValidEmpty = true;

                    this.txtPhoneNight.IsValidEmpty = true;

                    this.txtStreet.IsValidEmpty = true;

                    this.txtCity.IsValidEmpty = true;

                    this.txtZip.IsValidEmpty = true;

                    this.txtFax.IsValidEmpty = true;
                }

                RequiredFieldValidator1.ValidationGroup = value;
            }
        }
    }

    public ContactInfo()
    {
        this.InitializeControls += new EventHandler(ContactInfo_InitializeControls);
    }

    void ContactInfo_InitializeControls(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindCountry();

            BindContact();
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
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

        ddlState.DataSource = ilist;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Code";
        ddlState.DataBind();
        ddlState.Items.Insert(0, new ListItem("-SELECT-", "select"));
    }

    public bool PaddingPassengerInfo()
    {
        Contact contact = new Contact();

        contact.Person = new TERMS.Common.Person(this.txtFirst.Text, this.txtLast.Text, this.txtMiddle.Text);
        contact.Person.Salutationn = (TERMS.Common.Salutation)Convert.ToInt16(this.rbtnGender.SelectedValue);

        City city = new City();

        city.Name = this.txtCity.Text;

        city.Country.Name = this.ddlCountry.SelectedItem.Text;

        if (this.ddlState.SelectedIndex > 0)
        {
            city.ProvinceName = this.ddlState.SelectedItem.Text;
        }

        TERMS.Common.Address address = new TERMS.Common.Address(city, this.txtStreet.Text, this.txtZip.Text);

        contact.Person.AddAddress(address);

        Country country = new Country();

        country.Code = this.ddlCountry.SelectedValue;

        Phone phone = new Phone(country, this.ddlState.SelectedValue, this.txtPhoneDay.Text, string.Empty);
        phone.ContactOptions = ContactOptions.DayTime;
        contact.Person.AddPhone(phone);

        phone = new Phone(country, this.ddlState.SelectedValue, this.txtPhoneNight.Text, string.Empty);
        phone.ContactOptions = ContactOptions.NightTime;
        contact.Person.AddPhone(phone);

        contact.Person.Email = this.txtEmail.Text;

        phone = new Phone(country, this.ddlState.SelectedValue, this.txtFax.Text, string.Empty);
        phone.ContactOptions = ContactOptions.Office;
        contact.Person.AddPhone(phone);

        Utility.Transaction.CurrentTransactionObject.AddContact(contact);

        return true;


    }

    private void BindContact()
    {
        if (Utility.IsLogin)
        {
            this.txtFirst.Text = Utility.Transaction.Member.FirstName;
            this.txtMiddle.Text = Utility.Transaction.Member.MiddleName;
            this.txtLast.Text = Utility.Transaction.Member.LastName;

            this.rbtnGender.SelectedValue = Utility.Transaction.Member.Gender.ToString();

            this.txtEmail.Text = Utility.Transaction.Member.EmailAddress;

            this.txtPhoneDay.Text = Utility.Transaction.Member.PhoneDay;
            this.txtPhoneNight.Text = Utility.Transaction.Member.PhoneNight;

            this.txtStreet.Text = Utility.Transaction.Member.StreetAddress;
            this.txtCity.Text = Utility.Transaction.Member.City;

            this.txtZip.Text = Utility.Transaction.Member.ZipCode;

            if (Utility.IsSubAgent)
            {
                lblRequired1.Visible = false;
                lblRequired2.Visible = false;
                lblRequired3.Visible = false;
                lblRequired4.Visible = false;
                lblRequired5.Visible = false;
            }
        }

        this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(Utility.Transaction.Member.Nation.Trim().ToUpper()));
        ddlCountry_SelectedIndexChanged(null, new EventArgs());
        //如果通过查找名称在下拉列表中没查找到就到Code中查找州
        int StateIndex = GetStateSelectIndexByText(Utility.Transaction.Member.Province.Trim().ToUpper());
        if (StateIndex >= 0)
        {
            this.ddlState.SelectedIndex = StateIndex;
        }
        else
        {
            this.ddlState.SelectedIndex = GetStateSelectIndexByValue(Utility.Transaction.Member.Province.Trim().ToUpper());
        }

    }

    private int GetStateSelectIndexByText(string text)
    {
        int index = 0;

        for (int i = 0; i < ddlState.Items.Count; i++)
        {
            string SelectText = ddlState.Items[i].Text;

            if (SelectText.Trim().ToUpper() == text.Trim().ToUpper())
            {
                index = i;
                break;
            }
        }

        return index;
    }

    private int GetStateSelectIndexByValue(string value)
    {
        int index = 0;

        for (int i = 0; i < ddlState.Items.Count; i++)
        {
            string SelectValue = ddlState.Items[i].Value;

            if (SelectValue.Trim().ToUpper() == value.Trim().ToUpper())
            {
                index = i;
                break;
            }
        }

        return index;
    }
}
