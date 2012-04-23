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
using System.Collections.Generic;
using Terms.Common.Service;

public partial class InsuranceControl : Spring.Web.UI.UserControl
{
    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }


    public InsuranceControl()
    {
        this.InitializeControls += new EventHandler(InsuranceControl_InitializeControls);
    }

    void InsuranceControl_InitializeControls(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPassenger();
        }
    }

    private void BindPassenger()
    {
        IList<TERMS.Business.Centers.SalesCenter.Passenger> Passengers = Utility.Transaction.CurrentTransactionObject.GetPassengers();

        List<TERMS.Business.Centers.SalesCenter.Passenger> adult = new List<TERMS.Business.Centers.SalesCenter.Passenger>();
        List<TERMS.Business.Centers.SalesCenter.Passenger> child = new List<TERMS.Business.Centers.SalesCenter.Passenger>();


        for (int i = 0; i < Passengers.Count; i++)
        { 
            if (Passengers[i].PassengerType == TERMS.Common.PassengerType.Adult)
            {
                adult.Add(Passengers[i]);
            }

            if (Passengers[i].PassengerType == TERMS.Common.PassengerType.Child)
            {
                child.Add(Passengers[i]);
            }
        }



        dlAdult.DataSource = adult;
        dlAdult.DataBind();

        dlChild.DataSource = child;
        dlChild.DataBind();

        for (int i = 0; i < dlAdult.Items.Count; i++)
        {
            //((TermsCalendar)dlAdult.Items[i].FindControl("txtAdultBirthday")).Path = "../../";

            BindCountry(((DropDownList)dlAdult.Items[i].FindControl("ddlAdultCountry")));

            BindState(((DropDownList)dlAdult.Items[i].FindControl("ddlAdultState")));
        }

        for (int i = 0; i < dlChild.Items.Count; i++)
        {
            BindCountry(((DropDownList)dlChild.Items[i].FindControl("ddlChildCountry")));

            BindState(((DropDownList)dlChild.Items[i].FindControl("ddlChildState")));
        }
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
        //item.Items.Insert(0, new ListItem("-SELECT-", "select"));
    }

    public bool PaddingPassengerInfo()
    {
        try
        {
            DataListItem item;

            IList<TERMS.Business.Centers.SalesCenter.Passenger> Passengers = Utility.Transaction.CurrentTransactionObject.GetPassengers();

            List<TERMS.Business.Centers.SalesCenter.Passenger> OrderPassengerInfos = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

            int iAdult = dlAdult.Items.Count;
            int iChild = dlChild.Items.Count;

            List<string> list = new List<string>();

            for (int i = 0; i < iAdult; i++)
            {
                item = dlAdult.Items[i];

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

                for (int index = 0; index < Passengers.Count; index++)
                {
                    string firstname = ((Label)item.FindControl("lblAdultFirstName")).Text.Trim().ToUpper();
                    string lastname = ((Label)item.FindControl("lblAdultLastName")).Text.Trim().ToUpper();
                    if (firstname == Passengers[index].FirstName.ToUpper() && lastname == Passengers[index].LastName.ToUpper())
                    {
                        Passengers[index].Birthday = dateBirthday;

                        Passengers[index].StreetAddress = ((TermsTextBox)item.FindControl("txtAdultStreet")).Text;

                        if (string.IsNullOrEmpty(Passengers[index].StreetAddress))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# Street format error.');</script>");
                            return false;
                        }

                        Passengers[index].CityName = ((TermsTextBox)item.FindControl("txtAdultCity")).Text;

                        if (string.IsNullOrEmpty(Passengers[index].CityName))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# City format error.');</script>");
                            return false;
                        }

                        Passengers[index].CountryName = ((DropDownList)item.FindControl("ddlAdultCountry")).SelectedItem.Text;   //((TermsTextBox)item.FindControl("txtAdultCountry")).Text;

                        Passengers[index].ProvinceName = ((DropDownList)item.FindControl("ddlAdultState")).SelectedItem.Text; //((TermsTextBox)item.FindControl("txtAdultState")).Text;

                        Passengers[index].Email = ((TermsTextBox)item.FindControl("txtAdultEmail")).Text;

                        Passengers[index].ZipCode = ((TermsTextBox)item.FindControl("txtAdultZipCode")).Text;

                        if (string.IsNullOrEmpty(Passengers[index].ZipCode))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# ZipCode format error.');</script>");
                            return false;
                        }

                        TERMS.Common.City city = new TERMS.Common.City();
                        city.Name = ((TermsTextBox)item.FindControl("txtAdultCity")).Text;
                        TERMS.Common.Address address = new TERMS.Common.Address(city, ((TermsTextBox)item.FindControl("txtAdultStreet")).Text, ((TermsTextBox)item.FindControl("txtAdultZipCode")).Text);

                        Passengers[index].Address.Add(address);
                    }
                }
            }

            for (int i = 0; i < iChild; i++)
            {
                item = dlChild.Items[i];

                for (int index = 0; index < Passengers.Count; index++)
                {
                    string firstname = ((Label)item.FindControl("lblChildFirstName")).Text.Trim().ToUpper();
                    string lastname = ((Label)item.FindControl("lblChildLastName")).Text.Trim().ToUpper();
                    if (firstname == Passengers[index].FirstName.ToUpper() && lastname == Passengers[index].LastName.ToUpper())
                    {
                        Passengers[index].StreetAddress = ((TermsTextBox)item.FindControl("txtChildStreet")).Text;

                        if (string.IsNullOrEmpty(Passengers[index].ZipCode))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# Street format error.');</script>");
                            return false;
                        }

                        Passengers[index].CityName = ((TermsTextBox)item.FindControl("txtChildCity")).Text;

                        if (string.IsNullOrEmpty(Passengers[index].ZipCode))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# City format error.');</script>");
                            return false;
                        }

                        Passengers[index].CountryName = ((DropDownList)item.FindControl("ddlChildCountry")).SelectedItem.Text; //((TermsTextBox)item.FindControl("txtChildCountry")).Text;

                        Passengers[index].ProvinceName = ((DropDownList)item.FindControl("ddlChildState")).SelectedValue; //((TermsTextBox)item.FindControl("txtChildState")).Text;

                        Passengers[index].Email = ((TermsTextBox)item.FindControl("txtChildEmail")).Text;

                        Passengers[index].ZipCode = ((TermsTextBox)item.FindControl("txtChildZipCode")).Text;

                        if (string.IsNullOrEmpty(Passengers[index].ZipCode))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# ZipCode format error.');</script>");
                            return false;
                        }

                        TERMS.Common.City city = new TERMS.Common.City();
                        city.Name = ((TermsTextBox)item.FindControl("txtChildCity")).Text;
                        TERMS.Common.Address address = new TERMS.Common.Address(city, ((TermsTextBox)item.FindControl("txtChildStreet")).Text, ((TermsTextBox)item.FindControl("txtChildZipCode")).Text);

                        Passengers[index].Address.Add(address);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + ex.Message + "');</script>");
            return false;
        }

        return true;
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
}
