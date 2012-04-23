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
using Terms.Sales.Dao;
using Terms.Sales.Domain;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

public partial class TourContactInfoControl : Spring.Web.UI.UserControl
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

    public TourContactInfoControl()
    {
        this.InitializeControls += new EventHandler(TourContactInfoControl_InitializeControls);
    }

    void TourContactInfoControl_InitializeControls(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindCountry();
            BindContact();
        }
    }

    private void BindCountry()
    {
        ListItem itemNew = new ListItem("CANADA", "CA");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("United States", "US");

        ddlCountry.Items.Add(itemNew);

        //ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue("US"));

    }

    public bool PaddingPassengerInfo()
    {
        if (string.IsNullOrEmpty(txtFirst.Text.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter first name.');</script>");
            return false;
        }

        if (string.IsNullOrEmpty(txtLast.Text.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter last name.');</script>");
            return false;
        }

        if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter email.');</script>");
            return false;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Email Format error. Choose another');</script>");
            return false;
        }


        if (string.IsNullOrEmpty(txtPhoneDay.Text.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter phone number.');</script>");
            return false;
        }

        if (string.IsNullOrEmpty(txtStreet.Text.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter address.');</script>");
            return false;
        }

        if (string.IsNullOrEmpty(txtCity.Text.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter city.');</script>");
            return false;
        }

        if (string.IsNullOrEmpty(txtZip.Text.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please enter zip code.');</script>");
            return false;
        }
        //if (string.IsNullOrEmpty(ddlState.SelectedValue))
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select State.');</script>");
        //    return false;
        //}

        Contact contact = new Contact();

        contact.Person = new TERMS.Common.Person(this.txtFirst.Text, this.txtLast.Text, this.txtMiddle.Text);
        contact.Person.Salutationn = (TERMS.Common.Salutation)Convert.ToInt16(this.rbtnGender.SelectedValue);

        TERMS.Common.City city = new TERMS.Common.City();

        city.Name = this.txtCity.Text;

        city.Country.Name = this.ddlCountry.SelectedItem.Text;
        city.ProvinceName = this.ddlState.SelectedValue;

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


            this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(Utility.Transaction.Member.Nation));
            ddlCountry_SelectedIndexChanged(null, new EventArgs());
            this.ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(Utility.Transaction.Member.Province));
           
        }
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

        ddlState.DataSource = ilist;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Name";
        ddlState.DataBind();
        ddlState.Items.Insert(0, new ListItem("-SELECT-", ""));
    }

    public void BindContactByPNR(List<object> adultss)
    {
        List<string> adults = new List<string>();

        for (int adultsindex = 0; adultsindex < adultss.Count; adultsindex++)
        {
            for (int i = 0; i < ((List<string>)adultss[adultsindex]).Count; i++)
            {
                adults.Add(((List<string>)adultss[adultsindex])[i]);
            }
        }

        if (adults.Count > 0)
        {
            int iCompart1 = adults[0].IndexOf(@"/");
            int iCompart2 = adults[0].IndexOf(@".");

            string LastName = string.Empty;
            string FirstName = string.Empty;
            string MiddleName = string.Empty;

            LastName = adults[0].Substring(0, iCompart1);
            if (iCompart2 > 0)
            {
                FirstName = adults[0].Substring(iCompart1 + 1, iCompart2 - (iCompart1 + 1));
                MiddleName = adults[0].Substring(iCompart2 + 1);
            }
            else
            {
                FirstName = adults[0].Substring(iCompart1 + 1);
            }

            txtFirst.Text = FirstName;
            txtLast.Text = LastName;
            txtMiddle.Text = MiddleName;
        }
    }
}
