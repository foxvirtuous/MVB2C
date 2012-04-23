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
using TERMS.Business.Centers.ProductCenter.Components;

public partial class VehcilePriceForm : SalseBasePage
{
    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    public VehcilePriceForm()
    {
        this.PreRender += new EventHandler(VehcilePriceForm_PreRender);
    }

    void VehcilePriceForm_PreRender(object sender, EventArgs e)
    {
        if (Request.Params["IsFinised"] != null
            && Request.Params["IsFinised"].ToString().Trim().Length > 0)
        {

            Utility.Transaction.EmailVersion = this.flagSearch.Value;

            this.Response.Redirect("~/Page/Common/SaveOrderWaiting.aspx" + "?ConditionID=" + Request.Params["ConditionID"] + "&VendorCode=" + VendorCode + "&CarCode=" + CarCode);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        NavigationControl1.PageCode = 3;

        if (!IsPostBack)
        {
            BindCountry();            
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        if (cbIsAgree.Checked)
        {
            Response.Redirect("VehcilePriceTravelForm.aspx?ConditionID=" + Request.Params["ConditionID"] + "&VendorCode=" + VendorCode + "&CarCode=" + CarCode);
        }
    }

    public string VendorCode
    {
        get
        {
            return Request.Params["VendorCode"];
        }
    }

    public string CarCode
    {
        get
        {
            return Request.Params["CarCode"];
        }
    }

    protected void btnBooking_Click(object sender, EventArgs e)
    {
        if (!cbIsAgree.Checked)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please read & confirm the Terms and Conditions to continue');</script>");
            return;
        }

        if (ddlState.SelectedIndex == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select state');</script>");
            return;
        }
        try
        {
            Utility.Transaction.CurrentTransactionObject.ClearPassenger();

            string firstName = txtFrist.Text;
            string middleName = txtMiddle.Text;
            string lastName = txtLast.Text;

            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[A-Za-z.]+$");

            if (!reg.IsMatch(firstName + middleName + lastName))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Name format error.');</script>");
                return;
            }

            if (middleName == "Middle Name")
            {
                middleName = string.Empty;
            }

            TERMS.Business.Centers.SalesCenter.Passenger adultorderPassengerInfo = new TERMS.Business.Centers.SalesCenter.Passenger(firstName, lastName, middleName, TERMS.Common.PassengerType.Adult);
            adultorderPassengerInfo.PassengerType = TERMS.Common.PassengerType.Adult;

            switch (ddlSex.SelectedValue)
            {
                case "0":
                    adultorderPassengerInfo.Salutationn = TERMS.Common.Salutation.Dr;
                    break;
                case "1":
                    adultorderPassengerInfo.Salutationn = TERMS.Common.Salutation.Miss;
                    break;
                case "2":
                    adultorderPassengerInfo.Salutationn = TERMS.Common.Salutation.Mr;
                    break;
                case "3":
                    adultorderPassengerInfo.Salutationn = TERMS.Common.Salutation.Mrs;
                    break;
                case "4":
                    adultorderPassengerInfo.Salutationn = TERMS.Common.Salutation.Ms;
                    break;
                case "99":
                    adultorderPassengerInfo.Salutationn = TERMS.Common.Salutation.None;
                    break;
                case "5":
                    adultorderPassengerInfo.Salutationn = TERMS.Common.Salutation.Rev;
                    break;
            }
            Utility.Transaction.CurrentTransactionObject.AddPassenger(adultorderPassengerInfo);
        }
        catch
        {
            return;
        }

        Contact contact = new Contact();

        string firstNameContact = txtContactFirst.Text;
        string middleNameContact = txtMiddle.Text;
        string lastNameContact = txtContactLast.Text;

        if (middleNameContact == "Middle Name")
        {
            middleNameContact = string.Empty;
        }

        contact.Person = new TERMS.Common.Person(firstNameContact, lastNameContact, middleNameContact);

        TERMS.Common.Country country = new TERMS.Common.Country();

        country.Code = this.ddlCountry.SelectedValue;

        string Phone = string.Empty;

        if (txtExt.Text.Trim().Length > 0)
        {
            Phone = txtPhone.Text.Trim() + " " + txtExt.Text.Trim();
        }
        else
        {
            Phone = txtPhone.Text.Trim();
        }

        TERMS.Common.Phone phone = new TERMS.Common.Phone(country, this.ddlState.SelectedValue, Phone, string.Empty);
        phone.ContactOptions = TERMS.Common.ContactOptions.DayTime;
        contact.Person.AddPhone(phone);

        contact.Person.Email = this.txtEmail.Text;

        TERMS.Common.City city = new TERMS.Common.City();

        city.Name = this.txtCity.Text;

        city.Country.Name = this.ddlCountry.SelectedItem.Text;
        city.ProvinceName = this.ddlState.SelectedItem.Text;


        string Address = string.Empty;

        if (txtAddress2.Text.Trim().Length > 0)
        {
            Address = txtAddress1.Text.Trim() + "-" + txtAddress2.Text.Trim();
        }
        else
        {
            Address = txtAddress1.Text.Trim();
        }

        TERMS.Common.Address address = new TERMS.Common.Address(city, Address, txtZip.Text.Trim());

        contact.Person.AddAddress(address);

        if (Utility.Transaction.CurrentTransactionObject.GetContacts() != null && Utility.Transaction.CurrentTransactionObject.GetContacts().Count > 0)
        {
            Utility.Transaction.CurrentTransactionObject.ClearContact();
        }

        Utility.Transaction.CurrentTransactionObject.AddContact(contact);

        VehcileOrderItem vehcileorderitem = new VehcileOrderItem(new PackageProfile("Car"));

        VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

        for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
        {
            VehcileMaterial vehcilematerial = (TERMS.Business.Centers.ProductCenter.Components.VehcileMaterial)m_SaleMerchandise.Items[i];

            if (vehcilematerial.VendorCode == VendorCode && vehcilematerial.Vehciles.MakeModelCode == CarCode)
            {
                vehcileorderitem.Vehcile = vehcilematerial;
            }
        }

        Utility.Transaction.CurrentTransactionObject.Items.Add(vehcileorderitem);

        this.NewVehcileSendEamilControl1.AddItems();
        //this.Response.Redirect("~/Page/Common/SaveOrderWaiting.aspx" + "?ConditionID=" + Request.Params["ConditionID"] + "&VendorCode=" + VendorCode + "&CarCode=" + CarCode);
        ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>OnSearch();</script>");        
    }

    private void BindCountry()
    {
        ListItem itemNew = new ListItem("United States", "US");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("CANADA", "CA");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("CHINA", "CN");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("TAIWAN", "TW");

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

        ddlState.Items.Insert(0, new ListItem("Select", "NONE"));
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindState();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("VehcileInfoViewForm.aspx?VendorCode=" + VendorCode + "&CarCode=" + CarCode + "&ConditionID=" + Request.Params["ConditionID"]);
    }
}