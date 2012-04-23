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

public partial class NewInsuranceOrderPriceInfo : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["InsuranceSearchCondition"] != null && Session["InsuranceMaterial"] != null)
            {
                Terms.Sales.Business.InsuranceSearchCondition insurancesearchcondition = (Terms.Sales.Business.InsuranceSearchCondition)Session["InsuranceSearchCondition"];

                InsuranceMaterial insurancematerial = (InsuranceMaterial)Session["InsuranceMaterial"];

                lblHotelOrderTotalPrice.Text = ((decimal)insurancematerial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount - (decimal)SetSubPrice(insurancematerial)).ToString("N2", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                lblCommission.Text = SetSubPrice(insurancematerial).ToString("N2");
                DataTable dt = new DataTable("Price");

                DataColumn dcItemName = new DataColumn("ItemName", System.Type.GetType("System.String"));
                DataColumn dcRoomCount = new DataColumn("RoomCount", System.Type.GetType("System.String"));
                DataColumn dcPrice = new DataColumn("Price", System.Type.GetType("System.String"));

                dt.Columns.Add(dcItemName);
                dt.Columns.Add(dcRoomCount);
                dt.Columns.Add(dcPrice);


                if (insurancematerial.items != null && insurancematerial.items.Count > 0)
                {
                    for (int i = 0; i < insurancematerial.items.Count; i++)
                    {
                        InsuranceMaterial insurancematerialitem = insurancematerial.items[i];

                        DataRow dr = dt.NewRow();

                        dr["ItemName"] = insurancematerialitem.InsuranceName;
                        dr["RoomCount"] = insurancesearchcondition.TravelerCount;
                        dr["Price"] = (((decimal)insurancematerialitem.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount) / insurancesearchcondition.TravelerCount).ToString("N2", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                        dt.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();

                    dr["ItemName"] = insurancematerial.InsuranceName;
                    dr["RoomCount"] = insurancesearchcondition.TravelerCount;
                    dr["Price"] = (((decimal)insurancematerial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount) / insurancesearchcondition.TravelerCount).ToString("N2", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                    dt.Rows.Add(dr);
                }

                dlPrice.DataSource = dt;
                dlPrice.DataBind();
            }
        }
    }
    
    private double SetSubPrice(InsuranceMaterial insuranceMaterial)
    {
        double result = 0d;

        if (insuranceMaterial.items != null)
        {
            for (int i = 0; i < insuranceMaterial.items.Count; i++)
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
}