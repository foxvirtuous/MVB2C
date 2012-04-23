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
using Terms.Base.Service;
using TERMS.Business.Centers.SalesCenter;
using System.Collections.Generic;

public partial class NewInsuranceTravelersInformationControl : SalesBaseUserControl
{
    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    private IBaseService _BaseService;
    public IBaseService BaseService
    {
        set
        {
            this._BaseService = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int iAdult = 0;
            int iChild = 0;

            GetNumberOfPeople(ref iAdult, ref iChild);

            List<Passenger> m_OrderPassengerInfoAdults = new List<Passenger>();

            for (int i = 0; i < iAdult; i++)
            {
                if (i == 0)
                {
                    Passenger pass = new Passenger(TERMS.Common.PassengerType.Adult);
                    m_OrderPassengerInfoAdults.Add(pass);
                }
                else
                {
                    m_OrderPassengerInfoAdults.Add(new Passenger(TERMS.Common.PassengerType.Adult));
                }
            }

            this.dlAdult.DataSource = m_OrderPassengerInfoAdults;


            List<Passenger> m_OrderPassengerInfoChilds = new List<Passenger>();

            for (int i = 0; i < iChild; i++)
            {
                m_OrderPassengerInfoChilds.Add(new Passenger(TERMS.Common.PassengerType.Child));
            }

            TERMS.Common.InsuranceType  insurancetype = TERMS.Common.InsuranceType.AirOnly;

            if (Session["InsuranceSearchCondition"] != null && Session["InsuranceMaterial"] != null)
            {
                Terms.Sales.Business.InsuranceSearchCondition insurancesearchcondition = (Terms.Sales.Business.InsuranceSearchCondition)Session["InsuranceSearchCondition"];

                insurancetype = insurancesearchcondition.InsuranceType;
            }

            this.dlChild.DataSource = m_OrderPassengerInfoChilds;
            this.dlAdult.DataBind();
            this.dlChild.DataBind();

            for (int i = 0; i < dlAdult.Items.Count; i++)
            {
                if (i == 0)
                {
                    CheckBox chkSam = ((CheckBox)dlAdult.Items[i].FindControl("chkAdultSam"));
                    chkSam.Visible = false;
                }
                else
                {
                    CheckBox chkSam = ((CheckBox)dlAdult.Items[i].FindControl("chkAdultSam"));
                    string strname = "NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl" + i.ToString().PadLeft(2, '0') + "_chkAdultSam";
                    chkSam.Attributes.Add("onclick", "GetAdultSame('" + i.ToString().PadLeft(2, '0') + "','" + strname + "')");
                }

                BindCountry(((DropDownList)dlAdult.Items[i].FindControl("ddlAdultCountry")));

                BindState(((DropDownList)dlAdult.Items[i].FindControl("ddlAdultState")));

                if (insurancetype == TERMS.Common.InsuranceType.Package)
                {
                    dlAdult.Items[i].FindControl("divAdultTicketNumber").Visible = true;
                }
                else
                {
                    dlAdult.Items[i].FindControl("divAdultTicketNumber").Visible = false;
                }
            }

            for (int i = 0; i < dlChild.Items.Count; i++)
            {
                CheckBox chkSam = ((CheckBox)dlChild.Items[i].FindControl("chkChildSam"));
                string strname = "NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlChild_ctl" + i.ToString().PadLeft(2, '0') + "_chkChildSam";
                chkSam.Attributes.Add("onclick", "GetChildSame('" + i.ToString().PadLeft(2, '0') + "','" + strname + "')");

                BindCountry(((DropDownList)dlChild.Items[i].FindControl("ddlChildCountry")));

                BindState(((DropDownList)dlChild.Items[i].FindControl("ddlChildState")));

                if (insurancetype == TERMS.Common.InsuranceType.Package)
                {
                    dlChild.Items[i].FindControl("divChildTicketNumber").Visible = true;
                }
                else
                {
                    dlChild.Items[i].FindControl("divChildTicketNumber").Visible = false;
                }
            }
        }
    }

    private void BindGender(object obj1, object obj2)
    {
        RadioButtonList rbl = (RadioButtonList)obj1;
        Label lbl = (Label)obj2;
        for (int i = 0; i < rbl.Items.Count; i++)
        {
            if (rbl.Items[i].Text.Trim() == lbl.Text.Trim())
            {
                rbl.Items[i].Selected = true;
            }
        }

    }

    public void GetNumberOfPeople(ref int adult, ref int child)
    {
        if (Session["InsuranceSearchCondition"] != null && Session["InsuranceMaterial"] != null)
        {
            Terms.Sales.Business.InsuranceSearchCondition insurancesearchcondition = (Terms.Sales.Business.InsuranceSearchCondition)Session["InsuranceSearchCondition"];

            adult = insurancesearchcondition.Adults;

            child = insurancesearchcondition.Childs;
        }
    }

    public bool PaddingPassengerInfo()
    {
        try
        {


            Utility.Transaction.CurrentTransactionObject.ClearPassenger();

            DataListItem item;

            List<Passenger> OrderPassengerInfos = new List<Passenger>();

            int iAdult = dlAdult.Items.Count;
            int iChild = dlChild.Items.Count;
            //System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^\x00-\xff]");
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[A-Za-z.]+$");
            for (int i = 0; i < iAdult; i++)
            {

                item = dlAdult.Items[i];
                string firstName = ((TextBox)item.FindControl("txtAdultFirst")).Text;
                string middleName = ((TextBox)item.FindControl("txtAdultMiddle")).Text;
                string lastName = ((TextBox)item.FindControl("txtAdultLast")).Text;

                string address = ((TextBox)item.FindControl("txtAdultStreet")).Text;
                string city = ((TextBox)item.FindControl("txtAdultCity")).Text;
                string zip = ((TextBox)item.FindControl("txtAdultZip")).Text;

                string country = ((DropDownList)item.FindControl("ddlAdultCountry")).SelectedItem.Text;
                string state = ((DropDownList)item.FindControl("ddlAdultState")).SelectedValue;
                string ticketnumber = ((TextBox)item.FindControl("txtAdultTicketNumber")).Text;

                if (!reg.IsMatch(firstName + middleName + lastName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert(' Adult " + (i + 1).ToString() + "# Passenger Name should only contain english character.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(firstName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# First Name format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(lastName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# Last Name format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(address))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# Address format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(city))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# City format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(zip))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# Zip format error.');</script>");
                    return false;
                }

                DateTime dateBirthday;

                try
                {
                    dateBirthday = Convert.ToDateTime(((TextBox)item.FindControl("txtAdultBirthday")).Text);
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# birthday format error.');</script>");
                    return false;
                }

                if (dateBirthday >= DateTime.Now.AddYears(-12))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# 12+.');</script>");
                    return false;
                }

                Passenger adultorderPassengerInfo = new Passenger(firstName, lastName, middleName, TERMS.Common.PassengerType.Adult);
                adultorderPassengerInfo.Birthday = dateBirthday;
                adultorderPassengerInfo.Salutationn = (TERMS.Common.Salutation)Convert.ToInt32(((RadioButtonList)item.FindControl("rbtnAdultGender")).SelectedValue);
                adultorderPassengerInfo.PassportNumber = ((TextBox)item.FindControl("txtAdultPassport")).Text;
                adultorderPassengerInfo.PassengerType = TERMS.Common.PassengerType.Adult;
                adultorderPassengerInfo.CityName = city;
                adultorderPassengerInfo.ZipCode = zip;
                adultorderPassengerInfo.StreetAddress = address;
                adultorderPassengerInfo.CountryName = country;
                adultorderPassengerInfo.ProvinceName = state;
                adultorderPassengerInfo.TicketNumber = ticketnumber;


                Utility.Transaction.CurrentTransactionObject.AddPassenger(adultorderPassengerInfo);
            }

            for (int i = 0; i < iChild; i++)
            {
                item = dlChild.Items[i];
                string firstName = ((TextBox)item.FindControl("txtChildFirst")).Text;
                string middleName = ((TextBox)item.FindControl("txtChildMiddle")).Text;
                string lastName = ((TextBox)item.FindControl("txtChildLast")).Text;

                string address = ((TextBox)item.FindControl("txtChildStreet")).Text;
                string city = ((TextBox)item.FindControl("txtChildCity")).Text;
                string zip = ((TextBox)item.FindControl("txtChildZip")).Text;

                string country = ((DropDownList)item.FindControl("ddlChildCountry")).SelectedItem.Text;
                string state = ((DropDownList)item.FindControl("ddlChildState")).SelectedValue;
                string ticketnumber = ((TextBox)item.FindControl("txtChildTicketNumber")).Text;

                if (!reg.IsMatch(firstName + middleName + lastName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert(' Child " + (i + 1).ToString() + "# Passenger Name should only contain english character.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(firstName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# First Name format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(lastName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# Last Name format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(address))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# Address format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(city))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# City format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(zip))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# Zip format error.');</script>");
                    return false;
                }

                Passenger childOrderPassengerInfo = new Passenger(firstName, lastName, middleName, TERMS.Common.PassengerType.Child);

                DateTime dateBirthday;

                try
                {
                    dateBirthday = Convert.ToDateTime(((TextBox)item.FindControl("txtChildBirthday")).Text);
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# birthday format error.');</script>");
                    return false;
                }

                childOrderPassengerInfo.Salutationn = (TERMS.Common.Salutation)Convert.ToInt32(((RadioButtonList)item.FindControl("rbtnChildGender")).SelectedValue);
                childOrderPassengerInfo.Birthday = dateBirthday;
                childOrderPassengerInfo.PassportNumber = ((TextBox)item.FindControl("txtChildPassport")).Text;
                childOrderPassengerInfo.PassengerType = TERMS.Common.PassengerType.Child;
                childOrderPassengerInfo.CityName = city;
                childOrderPassengerInfo.ZipCode = zip;
                childOrderPassengerInfo.StreetAddress = address;
                childOrderPassengerInfo.CountryName = country;
                childOrderPassengerInfo.ProvinceName = state;
                childOrderPassengerInfo.TicketNumber = ticketnumber;


                Utility.Transaction.CurrentTransactionObject.AddPassenger(childOrderPassengerInfo);
            }

            return true;
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + ex.Message + "');</script>");
            return false;
        }
    }
    protected void ddlChildCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList item = (DropDownList)((DropDownList)sender).Parent.FindControl("ddlChildState");

        IList ilist = _CommonService.FindProvincesByCountryCode(((DropDownList)sender).SelectedValue);

        item.DataSource = ilist;
        item.DataTextField = "Name";
        item.DataValueField = "Name";
        item.DataBind();
    }
    protected void ddlAdultCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList item = (DropDownList)((DropDownList)sender).Parent.FindControl("ddlAdultState");

        IList ilist = _CommonService.FindProvincesByCountryCode(((DropDownList)sender).SelectedValue);

        item.DataSource = ilist;
        item.DataTextField = "Name";
        item.DataValueField = "Name";
        item.DataBind();
    }


    private void BindCountry(DropDownList item)
    {
        ListItem itemNew = new ListItem("United States", "US");

        item.Items.Add(itemNew);

        itemNew = new ListItem("CANADA", "CA");

        item.Items.Add(itemNew);
    }

    private void BindState(DropDownList item)
    {
        IList ilist = _CommonService.FindProvincesByCountryCode("US");

        item.DataSource = ilist;
        item.DataTextField = "Name";
        item.DataValueField = "Name";
        item.DataBind();
    }
}