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
using System.Text.RegularExpressions;


public partial class VehcilePriceTravelForm : SalseBasePage
{
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
        NavigationControl1.PageCode = 4;
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (!this.IsPostBack)
        {
            BindCountry();
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {

    }

    private void BindCountry()
    {
        ListItem itemNew = new ListItem("United States", "US");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("CANADA", "CA");

        ddlCountry.Items.Add(itemNew);

        BindState();
    }

    private void BindState()
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

        ddlState.DataSource = ilist;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Name";
        ddlState.DataBind();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindState();
    }

    public bool PaddingContactInfo()
    {
        Contact contact = new Contact();

        contact.Person = new TERMS.Common.Person(this.txtFirst.Text, this.txtLast.Text, this.txtMiddle.Text);
        contact.Person.Salutationn = (TERMS.Common.Salutation)Convert.ToInt16(this.rbtContactGender.SelectedValue);

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

        if (Utility.Transaction.CurrentTransactionObject.GetContacts() != null && Utility.Transaction.CurrentTransactionObject.GetContacts().Count > 0)
        {
            Utility.Transaction.CurrentTransactionObject.ClearContact();
        }

        Utility.Transaction.CurrentTransactionObject.AddContact(contact);

        return true;

    }


    public bool PaddingPassengerInfo()
    {
        try
        {
            Utility.Transaction.CurrentTransactionObject.ClearPassenger();

            DataListItem item;

            System.Text.RegularExpressions.Regex reg = new Regex("^[A-Za-z.]+$");

            string firstName = txtPassengerFirst.Text;
            string middleName = txtPassengerMiddle.Text;
            string lastName = txtPassengerLast.Text;
            if (!reg.IsMatch(firstName + middleName + lastName))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Name format error.');</script>");
                return false;
            }

            if (string.IsNullOrEmpty(firstName))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('First Name format error.');</script>");
                return false;
            }

            if (string.IsNullOrEmpty(lastName))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Last Name format error.');</script>");
                return false;
            }

            TERMS.Business.Centers.SalesCenter.Passenger adultorderPassengerInfo = new TERMS.Business.Centers.SalesCenter.Passenger(firstName, lastName, middleName, TERMS.Common.PassengerType.Adult);
            adultorderPassengerInfo.Salutationn = (TERMS.Common.Salutation)Convert.ToInt32(rbtPassengerGender.SelectedValue);
            adultorderPassengerInfo.PassengerType = TERMS.Common.PassengerType.Adult;
            Utility.Transaction.CurrentTransactionObject.AddPassenger(adultorderPassengerInfo);
            Utility.Transaction.CurrentTransactionObject.Items[0].Passengers.Add(adultorderPassengerInfo);
 
            return true;
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + ex.Message + "');</script>");
            return false;
        }
    }
}