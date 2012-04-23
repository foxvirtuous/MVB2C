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
using System.Collections.Generic;
using Terms.Sales.Service;

public partial class InputIncentiveTour : SalseBasePage
{
    private IIncentiveTourService _IncentiveTourService;
    public IIncentiveTourService IncentiveTourService
    {
        set
        {
            this._IncentiveTourService = value;
        }
    }

    private void InitializeComponent()
    {
        this.PreRender += new EventHandler(InputIncentiveTour_PreRender);
    }

    void InputIncentiveTour_PreRender(object sender, EventArgs e)
    {
        txtSpecialRequest.Text = txtSpecialRequest.Text.Replace(@"<", "");
        txtSpecialRequest.Text = txtSpecialRequest.Text.Replace(@">", "");
        txtSpecialRequest.Text = txtSpecialRequest.Text.Replace(@" ", "");
        txtSpecialRequest.Text = txtSpecialRequest.Text.Replace("\"", "");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        txtEstimateArrivalChina.Path = txtEstimateDeptChina.Path = "../../";
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        this.lblErrorMassage.Text = string.Empty;

        txtSpecialRequest.Text = txtSpecialRequest.Text.Replace(@"<", "");
        txtSpecialRequest.Text = txtSpecialRequest.Text.Replace(@">", "");
        txtSpecialRequest.Text = txtSpecialRequest.Text.Replace(@" ", "");
        txtSpecialRequest.Text = txtSpecialRequest.Text.Replace("\"", "");

        string strContactPerson = txtContactPerson.Text.Trim();
        string strCompanyName = txtCompanyName.Text.Trim();
        string strTel = txtTel.Text.Trim();
        string strCell = txtCell.Text.Trim();
        string strEmail = txtEmail.Text.Trim();
        string strFax = txtFax.Text.Trim();
        string strContactBy = GetCheckBoxListValues(chkContactBy);
        string strAddress = txtAddress.Text.Trim();
        string strCity = txtCity.Text.Trim();
        string strState = txtState.Text.Trim();
        string strZipCode = txtZipCode.Text.Trim();
        string strBudgetAmount = txtBudgetAmount.Text.Trim();
        string strEstimateArrivalChina = txtEstimateArrivalChina.CDate;
        string strEstimateDeptChina = txtEstimateDeptChina.CDate;
        string strTripPlan = txtTripPlan.Text.Trim();
        string strEstimateRegister = txtEstimateRegister.Text.Trim();
        string strVisitCities = GetCheckBoxListValues(chkVisitCities);
        string strVisitCitiesOther = txtVisitCities.Text.Trim();
        string strHotelChoose = GetRadioButtonListValues(rbtnHotelChoose);
        string strSpecificHotel = txtSpecificHotel.Text.Trim();
        string strMealPlan = GetCheckBoxListValues(chkMealPlan);
        string strMealPlanOther = txtMealPlan.Text.Trim();
        string strLocalGuideRequest = GetRadioButtonListValues(rbtnLocalGuideRequest);
        string strLocalGuideLanguageSpeaking = GetRadioButtonListValues(rbtnLocalGuideLanguageSpeaking);
        string strLocalGuideLanguageSpeakingOther = txtLocalGuideLanguageSpeaking.Text.Trim();
        string strSpecialRequest = txtSpecialRequest.Text.Trim();

        decimal decBudgetAmount = decimal.Zero;

        DateTime dateEstimateArrivalChina = DateTime.MinValue;
        DateTime dateEstimateDeptChina = DateTime.MinValue;

        int iTripPlan = 0;
        int iEstimateRegister = 0;

        if (string.IsNullOrEmpty(strContactPerson))
        {
            this.lblErrorMassage.Text += "  Please enter contact person " + "<BR>";
        }

        if (string.IsNullOrEmpty(strCompanyName))
        {
            this.lblErrorMassage.Text += "  Please enter company came " + "<BR>";
        }

        if (string.IsNullOrEmpty(strTel))
        {
            this.lblErrorMassage.Text += " Please enter tel " + "<BR>";
        }

        if (string.IsNullOrEmpty(strEmail))
        {
            this.lblErrorMassage.Text += " Please entere-mail " + "<BR>";
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(strEmail, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
        {
            this.lblErrorMassage.Text += " Email Format error. Choose another " + "<BR>";
        }

        if (string.IsNullOrEmpty(strContactBy))
        {
            this.lblErrorMassage.Text += " Please enter contact by " + "<BR>";
        }

        if (string.IsNullOrEmpty(strAddress))
        {
            this.lblErrorMassage.Text += " Please enter address " + "<BR>";
        }

        if (string.IsNullOrEmpty(strCity))
        {
            this.lblErrorMassage.Text += " Please enter city " + "<BR>";
        }

        if (string.IsNullOrEmpty(strState))
        {
            this.lblErrorMassage.Text += " Please enter state " + "<BR>";
        }

        if (string.IsNullOrEmpty(strZipCode))
        {
            this.lblErrorMassage.Text += " Please enter zip code " + "<BR>";
        }

        if (!string.IsNullOrEmpty(strBudgetAmount))
        {
            if (!decimal.TryParse(strBudgetAmount, out decBudgetAmount))
            {
                this.lblErrorMassage.Text += " Budget amount format error " + "<BR>";
            }
        }

        if (string.IsNullOrEmpty(strEstimateArrivalChina))
        {
            this.lblErrorMassage.Text += " Please enterestimate arrival china " + "<BR>";
        }

        if (string.IsNullOrEmpty(strEstimateDeptChina))
        {
            this.lblErrorMassage.Text += " Please enterestimate dept. china " + "<BR>";
        }

        if (!DateTime.TryParse(strEstimateArrivalChina, out dateEstimateArrivalChina))
        {
            this.lblErrorMassage.Text += " Estimate arrival china  format error " + "<BR>";
        }
        if (!DateTime.TryParse(strEstimateDeptChina, out dateEstimateDeptChina))
        {
            this.lblErrorMassage.Text += " Estimate dept. china  format error " + "<BR>";
        }

        if (dateEstimateArrivalChina >= dateEstimateDeptChina )
        {
            this.lblErrorMassage.Text += " Estimate Arrival China must be before Estimate Dept. China " + "<BR>";
        }

        if (string.IsNullOrEmpty(strTripPlan))
        {
            this.lblErrorMassage.Text += " Please enter trip plan " + "<BR>";
        }

        if (!int.TryParse(strTripPlan, out iTripPlan))
        {
            this.lblErrorMassage.Text += " Trip plan format error " + "<BR>";
        }

        if (string.IsNullOrEmpty(strEstimateRegister))
        {
            this.lblErrorMassage.Text += " Please enter estimate register " + "<BR>";
        }

        if (!int.TryParse(strEstimateRegister, out iEstimateRegister))
        {
            this.lblErrorMassage.Text += " Estimate register format error " + "<BR>";
        }

        if (string.IsNullOrEmpty(strVisitCities) && string.IsNullOrEmpty(strVisitCitiesOther))
        {
            this.lblErrorMassage.Text += " Please choose visit cities or enter other " + "<BR>";
        }

        if (string.IsNullOrEmpty(strLocalGuideRequest))
        {
            this.lblErrorMassage.Text += " Please choose local guide request " + "<BR>";
        }

        if (string.IsNullOrEmpty(strLocalGuideLanguageSpeaking) && string.IsNullOrEmpty(strLocalGuideLanguageSpeakingOther))
        {
            this.lblErrorMassage.Text += " Please choose local guide language speaking or enter other" + "<BR>";
        }

        if (!string.IsNullOrEmpty(this.lblErrorMassage.Text.Trim()))
        {
            lblErrorMassage.Visible = true;
            return;
        }

        Terms.Sales.Domain.OrderMaterialIncentiveTourMeta meta = new Terms.Sales.Domain.OrderMaterialIncentiveTourMeta();

        meta.Id = new Guid();

        meta.Address = strAddress;
        meta.BudgetAmount = decBudgetAmount;
        meta.Cell = strCell;
        meta.City = strCity;
        meta.CompanyName = strCompanyName;
        meta.ContactBy = strContactBy;
        meta.ContactPerson = strContactPerson;
        meta.Email = strEmail;
        if (dateEstimateArrivalChina != DateTime.MinValue)
        {
            meta.EstimateArrivalChina = dateEstimateArrivalChina;
        }
        if (dateEstimateDeptChina != DateTime.MinValue)
        {
            meta.EstimateDeptChina = dateEstimateDeptChina;
        }
        meta.EstimateRegister = iEstimateRegister;
        meta.Fax = strFax;
        meta.HotelChoose = strHotelChoose;
        meta.LocalGuideLanguageSpeaking = strLocalGuideLanguageSpeaking;
        if (rbtnLocalGuideLanguageSpeaking.SelectedValue == "3")
        {
            meta.LocalGuideLanguageSpeakingOther = strLocalGuideLanguageSpeakingOther;
        }
        meta.LocalGuideRequest = strLocalGuideRequest;
        meta.MealPlan = strMealPlan;
        if (chkMealPlan.Items[4].Selected)
        {
            meta.MealPlanOther = strMealPlanOther;
        }

        meta.SendDateTime = DateTime.Now;
        meta.SpecialRequest = strSpecialRequest;
        meta.SpecificHotel = strSpecificHotel;
        meta.State = strState;
        meta.Tel = strTel;
        meta.TripPlan = iTripPlan;
        meta.VisitCities = strVisitCities;
        if (chkVisitCities.Items[3].Selected)
        {
            meta.VisitCitiesOther = strVisitCitiesOther;
        }
        meta.ZipCode = strZipCode;

        try
        {
            _IncentiveTourService.Add(meta);
            Session["Meta"] = meta;
        }
        catch(Exception ex)
        {
            lblErrorMassage.Text = " save error, please call tel:1-(888)-288-7528 " ;
            lblErrorMassage.Visible = true;
            return;
        }        

        Response.Redirect("SuccessIncentiveTour.aspx");
    }

    private string GetCheckBoxListValues(CheckBoxList obj)
    {
        List<string> values = new List<string>();

        if (obj != null)
        {
            foreach (ListItem item in obj.Items)
            {
                if (item.Selected)
                {
                    values.Add(item.Value);
                }
            }
        }

        return string.Join("", values.ToArray());
    }

    private string GetRadioButtonListValues(RadioButtonList obj)
    {
        List<string> values = new List<string>();

        if (obj != null)
        {
            foreach (ListItem item in obj.Items)
            {
                if (item.Selected)
                {
                    values.Add(item.Value);
                }
            }
        }

        return string.Join("", values.ToArray());
    }
}
