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
using TERMS.Business.Centers.ProductCenter.Components;

public partial class NewInsuranceOrderSummaryControl : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["InsuranceSearchCondition"] != null && Session["InsuranceMaterial"] != null)
            {
                Terms.Sales.Business.InsuranceSearchCondition insurancesearchcondition = (Terms.Sales.Business.InsuranceSearchCondition)Session["InsuranceSearchCondition"];

                InsuranceMaterial insurancematerial = (InsuranceMaterial)Session["InsuranceMaterial"];

                lblInsurance.Text = insurancematerial.InsuranceName;

                lblDeptDate.Text = insurancesearchcondition.DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                lblRtnDate.Text = insurancesearchcondition.ReturnDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                if (insurancesearchcondition.Childs == 0)
                {
                    lblChildNumber.Visible = false;
                    lblAdultNumber.Text += insurancesearchcondition.Adults.ToString();
                }
                else
                {
                    lblChildNumber.Visible = true;
                    lblAdultNumber.Text += insurancesearchcondition.Adults.ToString();
                    lblChildNumber.Text += insurancesearchcondition.Childs.ToString();
                }
            }
        }
    }
}