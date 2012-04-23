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
using Terms.Sales.Domain;
using System.Collections.Generic;


public partial class SendEmailIncentiveTourControl : SalesBaseUserControl
{
    public string Email
    {
        get
        {
            return this.lblEmail.Text;
        }
    }

    public string CaseNumber
    {
        get
        {
            return this.lblCasenNmber.Text;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Meta"] != null)
            {
                OrderMaterialIncentiveTourMeta meta = (OrderMaterialIncentiveTourMeta)Session["Meta"];

                lblAddress.Text = meta.Address;
                if (meta.BudgetAmount > 0M)
                {
                    lblBudgetAmount.Text = "$ " + meta.BudgetAmount.ToString("N2");
                }
                lblCell.Text = meta.Cell;
                lblCasenNmber.Text = meta.CaseNumber;
                lblCity.Text = meta.City;
                lblCompanyName.Text = meta.CompanyName;

                List<string> ContactBys = new List<string>();

                if (meta.ContactBy.Contains("0"))
                {
                    ContactBys.Add("Tel");
                }
                if (meta.ContactBy.Contains("1"))
                {
                    ContactBys.Add("E-mail");
                }
                if (meta.ContactBy.Contains("2"))
                {
                    ContactBys.Add("Fax");
                }

                lblContactBy.Text = string.Join(", ", ContactBys.ToArray());
                lblContactPerson.Text = meta.ContactPerson;
                lblEmail.Text = meta.Email;
                lblEstimateArrivalChina.Text = meta.EstimateArrivalChina.Value.ToString("MM/dd/yyyy");
                lblEstimateDeptChina.Text = meta.EstimateDeptChina.Value.ToString("MM/dd/yyyy");
                lblEstimateRegister.Text = meta.EstimateRegister.ToString();
                lblFax.Text = meta.Fax;
                lblFullName.Text = meta.ContactPerson;

                List<string> HotelChooses = new List<string>();
                if (meta.HotelChoose.Contains("0"))
                    HotelChooses.Add("First/Tourism Class");
                if (meta.HotelChoose.Contains("1"))
                    HotelChooses.Add("4 Stars");
                if (meta.HotelChoose.Contains("2"))
                    HotelChooses.Add("5 Stars");
                if (meta.HotelChoose.Contains("3"))
                    HotelChooses.Add("Others");
                lblHotelChoose.Text = string.Join(", ", HotelChooses.ToArray());

                List<string> LocalGuideLanguageSpeakings = new List<string>();
                if (meta.LocalGuideLanguageSpeaking.Contains("0"))
                    LocalGuideLanguageSpeakings.Add("English");
                if (meta.LocalGuideLanguageSpeaking.Contains("1"))
                    LocalGuideLanguageSpeakings.Add("Spanish");
                if (meta.LocalGuideLanguageSpeaking.Contains("2"))
                    LocalGuideLanguageSpeakings.Add("Chinese");
                if (!string.IsNullOrEmpty(meta.LocalGuideLanguageSpeakingOther))
                    LocalGuideLanguageSpeakings.Add(meta.LocalGuideLanguageSpeakingOther);
                lblLocalGuideLanguageSpeaking.Text = string.Join(", ", LocalGuideLanguageSpeakings.ToArray());

                List<string> LocalGuideRequests = new List<string>();
                if (meta.LocalGuideRequest.Contains("0"))
                    LocalGuideRequests.Add("Yes");
                if (meta.LocalGuideRequest.Contains("1"))
                    LocalGuideRequests.Add("No");
                lblLocalGuideRequest.Text = string.Join(", ", LocalGuideRequests.ToArray());

                List<string> MealPlans = new List<string>();
                if (meta.MealPlan.Contains("0"))
                    MealPlans.Add("Chinese");
                if (meta.MealPlan.Contains("1"))
                    MealPlans.Add("Western");
                if (meta.MealPlan.Contains("2"))
                    MealPlans.Add("Local Cuisine");
                if (meta.MealPlan.Contains("3"))
                    MealPlans.Add("Buffet");
                if (!string.IsNullOrEmpty(meta.MealPlanOther))
                    MealPlans.Add(meta.MealPlanOther);
                lblMealPlan.Text = string.Join(", ", MealPlans.ToArray());
                lblSpecialRequest.Text = meta.SpecialRequest;
                lblSpecificHotel.Text = meta.SpecificHotel;
                lblState.Text = meta.State;
                lblTel.Text = meta.Tel;
                lblTripPlan.Text = meta.TripPlan.ToString();

                List<string> VisitCities = new List<string>();
                if (meta.VisitCities.Contains("0"))
                    VisitCities.Add("Beijing");
                if (meta.VisitCities.Contains("1"))
                    VisitCities.Add("Shanghai");
                if (meta.VisitCities.Contains("2"))
                    VisitCities.Add("Guangzhou");
                if (!string.IsNullOrEmpty(meta.VisitCitiesOther))
                    VisitCities.Add(meta.VisitCitiesOther);
                lblVisitCities.Text = string.Join(", ", VisitCities.ToArray());

                lblZipCode.Text = meta.ZipCode;

                //Session["Meta"] = null;
            }
        }
    }
}