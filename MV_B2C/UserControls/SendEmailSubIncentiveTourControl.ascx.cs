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


public partial class SendEmailSubIncentiveTourControl : SalesBaseUserControl
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
            if (Session["SubMeta"] != null)
            {
                OrderMaterialSubIncentiveTourMeta meta = (OrderMaterialSubIncentiveTourMeta)Session["SubMeta"];

                lblCasenNmber.Text = meta.CaseNumber;
                lblContactPerson.Text = meta.ContactPerson;
                lblFullName.Text = meta.ContactPerson;
                lblDeptDate.Text = meta.DeptDate.Value.ToString("MM/dd/yyyy");
                lblEmail.Text = meta.Email;
                lblLanguageSpeaking.Text = meta.LanguageSpeaking;
                lblPax.Text = meta.Pax.ToString();
                lblTel.Text = meta.Tel;
                lblTourCode.Text = meta.TourCode;
            }
        }
    }
}