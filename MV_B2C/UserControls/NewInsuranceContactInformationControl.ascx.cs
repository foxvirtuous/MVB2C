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
using Terms.Common.Service;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;
using System.Collections.Generic;

public partial class NewInsuranceContactInformationControl : SalesBaseUserControl
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

                RequiredFieldValidator1.ValidationGroup = value;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindCountry();
        }
    }

    private void BindCountry()
    {
        ListItem itemNew = new ListItem("United States", "US");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("CANADA", "CA");

        ddlCountry.Items.Add(itemNew);

        ddlCountry_SelectedIndexChanged(new object(), new EventArgs());
    }

    public bool PaddingPassengerInfo()
    {
        Contact contact = new Contact();

        contact.Person = new TERMS.Common.Person(this.txtFirst.Text, this.txtLast.Text, this.txtMiddle.Text);
        contact.Person.Salutationn = (TERMS.Common.Salutation)Convert.ToInt16(this.rbtnGender.SelectedValue);

        TERMS.Common.City city = new TERMS.Common.City();

        city.Name = this.txtCity.Text;

        city.Country.Name = this.ddlCountry.SelectedItem.Text;
        city.ProvinceName = this.ddlState.SelectedItem.Text;

        TERMS.Common.Address address = new TERMS.Common.Address(city, this.txtStreet.Text, this.txtZip.Text);

        contact.Person.AddAddress(address);

        TERMS.Common.Country country = new TERMS.Common.Country();

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
        contact.Person.AddFax(phone);

        Utility.Transaction.CurrentTransactionObject.AddContact(contact);

        return true;

    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

        ddlState.DataSource = ilist;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Name";
        ddlState.DataBind();
    }

    private bool Verification()
    {
        List<bool> flags = new List<bool>();

        //First
        if (string.IsNullOrEmpty(txtFirst.Text.Trim()))
        {
            flags.Add(false);
        }

        //Last
        if (string.IsNullOrEmpty(txtLast.Text.Trim()))
        {
            flags.Add(false);
        }

        //Email
        if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
        {
            flags.Add(false);
        }

        //PhoneDay
        if (string.IsNullOrEmpty(txtPhoneDay.Text.Trim()))
        {
            flags.Add(false);
        }

        //Street
        if (string.IsNullOrEmpty(txtStreet.Text.Trim()))
        {
            flags.Add(false);
        }

        //City
        if (string.IsNullOrEmpty(txtCity.Text.Trim()))
        {
            flags.Add(false);
        }

        //Zip
        if (string.IsNullOrEmpty(txtZip.Text.Trim()))
        {
            flags.Add(false);
        }

        return true;
    }
}