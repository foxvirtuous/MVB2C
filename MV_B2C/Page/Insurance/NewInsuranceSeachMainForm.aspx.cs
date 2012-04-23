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
using TERMS.Business.Centers.SalesCenter;

public partial class NewInsuranceSeachMainForm : SalseBasePage
{
    private string _ErrorText = string.Empty;

    public int InsuranceIntKey
    {
        set
        {
            ViewState["InsuranceIntKey"] = value;
        }
        get
        {
            if (ViewState["InsuranceIntKey"] == null)
                return 0;

            return Convert.ToInt32(ViewState["InsuranceIntKey"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Utility.IsLogin || !Utility.IsSubAgent)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Searching", @"<script>aa();</script>");
            return;
        }
    }

    protected void btnPricing_Click(object sender, EventArgs e)
    {
        lblError.Visible = false;

        if (CheckValidator())
        {
            lblError.Text = _ErrorText;
            lblError.Visible = true;
            btnPruchase.Enabled = false;

            lblGTTReference.Text = string.Empty;
            lblSellingPrice.Text = string.Empty;

            return;
        }

        Terms.Sales.Business.InsuranceSearchCondition Condition = new Terms.Sales.Business.InsuranceSearchCondition();

        Condition.InsuranceType = GetCheckInsuranceType();

        Condition.DepartureDate = Convert.ToDateTime(txtTravelFrom.Text);

        Condition.ReturnDate = Convert.ToDateTime(txtTravelTo.Text);

        Condition.TotalTripCost = Convert.ToDecimal(txtTotalTripCost.Text);

        if (txtChilds.Text.Trim().Length == 0)
        {
            Condition.TravelerCount = Convert.ToInt32(txtAdult.Text);

            Condition.Adults = Convert.ToInt32(txtAdult.Text);

            Condition.Childs = 0;
        }
        else
        {
            Condition.TravelerCount = Convert.ToInt32(txtAdult.Text) + Convert.ToInt32(txtChilds.Text);

            Condition.Adults = Convert.ToInt32(txtAdult.Text);

            Condition.Childs = Convert.ToInt32(txtChilds.Text);
        }

        Session["InsuranceSearchCondition"] = Condition;

        InsuranceMaterial insuranceMaterial = this.OnSearchInsuranceByB2B(Condition);

        //SetSubPrice(insuranceMaterial);

        if (insuranceMaterial != null && insuranceMaterial.PolicyQuote.Status.IsSuccess)
        {
            if (cbtEmergency.Checked)
            {
                insuranceMaterial.PolicyQuote.PolicyInformation.Product.IncludeEmt = true;
            }

            InsuranceOrderItem insuranceOrderItem = new InsuranceOrderItem(insuranceMaterial, null);
            insuranceOrderItem.InsuranceType = Condition.InsuranceType;

            if (!string.IsNullOrEmpty(txtCaseNumber.Text.Trim()))
            {
                insuranceOrderItem.RelationCaseNumber = txtCaseNumber.Text.Trim();
            }

            if (!string.IsNullOrEmpty(txtTicketNumber.Text.Trim()))
            {
                insuranceOrderItem.TicketNumber = txtTicketNumber.Text.Trim();
            }

            insuranceOrderItem.TotalTripCost = Convert.ToDecimal(txtTotalTripCost.Text);

            DateTime TicketingDate = Convert.ToDateTime(txtTicketingDate.Text);
            insuranceOrderItem.TicketDate = TicketingDate;

            Utility.Transaction.IntKey = Condition.GetHashCode();
            InsuranceIntKey = Condition.GetHashCode();
            Utility.Transaction.CurrentSearchConditions = Condition;
            Utility.Transaction.CurrentTransactionObject = new TransactionObject();
            Utility.Transaction.CurrentTransactionObject.AddItem(insuranceOrderItem);

            Session["InsuranceMaterial"] = insuranceMaterial;

            SetPriceShow((decimal)insuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount, (decimal)insuranceMaterial.PolicyQuote.PolicyInformation.Premium.Markup, insuranceMaterial);

            btnPruchase.Enabled = true;
        }
        else
        {
            if (insuranceMaterial != null && !insuranceMaterial.PolicyQuote.Status.IsSuccess)
            {
                lblError.Text = insuranceMaterial.PolicyQuote.Status.ErrorDescription;
                lblError.Visible = true;
            }
            else
            {
                lblError.Text = "Unknown Error";
                lblError.Visible = true;
            }
        }
    }

    protected void btnPruchase_Click(object sender, EventArgs e)
    {
        if (!lblError.Visible)
        {
            Response.Redirect("NewInsuranceTravelerInfoForm.aspx?ConditionID=" + InsuranceIntKey.ToString());
        }
    }

    private bool CheckValidator()
    {
        bool flag = false;

        Session["InsuranceSearchCondition"] = null;
        Session["InsuranceMaterial"] = null;

        if (!rbtInsurancep1.Checked && !rbtInsurancep2.Checked && !rbtInsurancep4.Checked && !rbtInsurancep5.Checked)
        {
            _ErrorText = "请选择一种保险";
            flag = true;
        }

        if (txtTicketingDate.Text.Trim().Length == 0)
        {
            _ErrorText = "Invalid Travel Dates";
            flag = true;
        }
        else
        {
            DateTime TicketingDate = DateTime.MinValue;

            try
            {
                TicketingDate = Convert.ToDateTime(txtTicketingDate.Text);

                if (TicketingDate.AddDays(14).Date <= DateTime.Now.Date)
                {
                    _ErrorText = "Ticketing Travel Dates";
                    flag = true;
                }
            }
            catch
            {
                _ErrorText = "Ticketing Date From invalid";
                flag = true;
            }
        }


        DateTime dateTravelFrom = DateTime.MinValue;

        DateTime dateTravelTo = DateTime.MinValue;

        try
        {
            dateTravelFrom = Convert.ToDateTime(txtTravelFrom.Text);

            if (dateTravelFrom < DateTime.Now.AddDays(1))
            {
                _ErrorText = "Invalid Travel Dates";
                flag = true;
            }
        }
        catch
        {
            _ErrorText = "Travel Date From invalid";
            flag = true;
        }

        try
        {
            dateTravelTo = Convert.ToDateTime(txtTravelTo.Text);

            if (dateTravelFrom > dateTravelTo)
            {
                _ErrorText = "Policies must be purchased at least 24 hrs before departure date";
                flag = true;
            }
        }
        catch
        {
            _ErrorText = "Travel Date To invalid";
            flag = true;
        }

        int iAdults = 0;

        if (txtAdult.Text.Trim().Length == 0)
        {
            _ErrorText = "Check the Adults Fromat";
            flag = true;
        }
        else
        {
            try
            {
                iAdults = Convert.ToInt32(txtAdult.Text);

                if (iAdults <= 0)
                {
                    _ErrorText = "Check the Adults Fromat";
                    flag = true;
                }
            }
            catch
            {
                _ErrorText = "Check the Adults Fromat";
                flag = true;
            }
        }

        int iChilds = 0;

        if (txtChilds.Text.Trim().Length > 0)
        {
            try
            {
                iChilds = Convert.ToInt32(txtChilds.Text);

                if (iChilds < 0)
                {
                    _ErrorText = "Check the Childs Fromat";
                    flag = true;
                }
            }
            catch
            {
                _ErrorText = "Check the Childs Fromat";
                flag = true;
            }
        }

        if (iAdults + iChilds > 15)
        {
            _ErrorText = "This product allows no more than 15 insureds per policy.";
            flag = true;
        }

        if (txtTotalTripCost.Text.Trim().Length == 0)
        {
            _ErrorText = " Check the Total trip cost format";
            flag = true;
        }
        else
        {
            try
            {
                decimal decTotalTripCost = Convert.ToDecimal(txtTotalTripCost.Text);

                if (decTotalTripCost < decimal.Zero)
                {
                    _ErrorText = "Check the Total trip cost format";
                    flag = true;
                }
            }
            catch
            {
                _ErrorText = " Check the Total trip cost format";
                flag = true;
            }
        }

        return flag;
    }

    private TERMS.Common.InsuranceType GetCheckInsuranceType()
    {
        if (rbtInsurancep1.Checked)
        {
            if (cbtEmergency.Checked)
            {
                return TERMS.Common.InsuranceType.TourUVEmt;
            }
            else
            {
                return TERMS.Common.InsuranceType.TourUV;
            }
        }
        else if (rbtInsurancep2.Checked)
        {
            if (cbtP3.Checked)
            {
                return TERMS.Common.InsuranceType.Tour1;
            }
            else
            {
                return TERMS.Common.InsuranceType.Tour;
            }
        }
        else if (rbtInsurancep4.Checked)
        {
            return TERMS.Common.InsuranceType.Package;
        }
        else
            return TERMS.Common.InsuranceType.AirOnly;
    }

    private void SetPriceShow(decimal TotalPrice, decimal TotalMarkup, InsuranceMaterial insuranceMaterial)
    {
        this.lblSellingPrice.Text = TotalPrice.ToString("N");
        double Gtt = SetSubPrice(insuranceMaterial);
        this.lblGTTReference.Text = Gtt.ToString("N");
        this.lblError.Text = "";
        this.lblError.Visible = false;
    }

    private double SetSubPrice(InsuranceMaterial insuranceMaterial)
    {
        double result = 0d;

        if (insuranceMaterial.items != null)
        {
            for (int i = 0; i < insuranceMaterial.items.Count; i++ )
            {
                result += SetSubAgentPrice(insuranceMaterial.items[i]);
            }
        }
        else
        {
            result = SetSubAgentPrice(insuranceMaterial);
        }

        return result;
    }

    private double SetSubAgentPrice(InsuranceMaterial insuranceMaterial)
    {
        double result = 0d;
        double decmarkup = insuranceMaterial.PolicyQuote.PolicyInformation.Premium.Markup;

        if (decmarkup != 0d)
        {
            double total = insuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount;

            result = total * 0.2d;
        }

        return result;
    }

    public NewInsuranceSeachMainForm()
    {
        this.PreRender += new EventHandler(NewInsuranceSeachMainForm_PreRender);
    }

    void NewInsuranceSeachMainForm_PreRender(object sender, EventArgs e)
    {
        
    }
}
