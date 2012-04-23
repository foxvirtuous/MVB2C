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
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;

public partial class NewInsuranceOrderPriceInfoView : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Utility.Transaction.CurrentTransactionObject.Type == "I" && Utility.Transaction.CurrentTransactionObject.Items != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0
                && Utility.Transaction.CurrentTransactionObject.Items[0] is InsuranceOrderItem)
            {
                InsuranceOrderItem insuranceorderitem = (InsuranceOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];

                lblNetPrice.Text = (insuranceorderitem.TotalPremiumAmount - insuranceorderitem.InsuranceMarkUp).ToString("N2", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                decimal decSubAgent = decimal.Zero;

                if (Utility.Transaction.CurrentTransactionObject.CostMarkup != null)
                {
                    decSubAgent += Utility.Transaction.CurrentTransactionObject.CostMarkup.GetAmount(TERMS.Common.PassengerType.Adult);
                }

                lblSellPrice.Text = (insuranceorderitem.TotalPremiumAmount + decSubAgent - SetSubPrice(insuranceorderitem)).ToString("N2", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                lblCommission.Text = SetSubPrice(insuranceorderitem).ToString("N2");
                int iP = Utility.Transaction.CurrentTransactionObject.GetPassengers().Count;

                DataTable dt = new DataTable("Price");

                DataColumn dcItemName = new DataColumn("ItemName", System.Type.GetType("System.String"));
                DataColumn dcRoomCount = new DataColumn("RoomCount", System.Type.GetType("System.String"));
                DataColumn dcPrice = new DataColumn("Price", System.Type.GetType("System.String"));

                dt.Columns.Add(dcItemName);
                dt.Columns.Add(dcRoomCount);
                dt.Columns.Add(dcPrice);

                if (insuranceorderitem.Groups != null && insuranceorderitem.Groups.Count > 0 && !string.IsNullOrEmpty(insuranceorderitem.GroupId.Trim()))
                {
                    for (int i = 0; i < insuranceorderitem.Groups.Count; i++)
                    {
                        InsuranceOrderItem insuranceorderitemNew = (InsuranceOrderItem)insuranceorderitem.Groups[i];

                        DataRow dr = dt.NewRow();

                        dr["ItemName"] = insuranceorderitemNew.InsuranceOrderName;
                        dr["RoomCount"] = iP;
                        dr["Price"] = (((decimal)insuranceorderitemNew.TotalPremiumAmount) / iP).ToString("N2", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                        dt.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();

                    dr["ItemName"] = insuranceorderitem.InsuranceOrderName;
                    dr["RoomCount"] = iP;
                    dr["Price"] = (((decimal)insuranceorderitem.TotalPremiumAmount) / iP).ToString("N2", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                    dt.Rows.Add(dr);
                }

                dlPrice.DataSource = dt;
                dlPrice.DataBind();
            }
        }
    }

    private decimal SetSubPrice(InsuranceOrderItem insuranceMaterial)
    {
        decimal result = decimal.Zero;

        if (insuranceMaterial.Items != null)
        {
            //for (int i = 0; i < insuranceMaterial.items.Count; i++)
            //{
            //    result += SetSubAgentPrice(insuranceMaterial);
            //}
        }
        else
        {
            result = SetSubAgentPrice(insuranceMaterial);
        }

        return result;
    }

    private decimal SetSubAgentPrice(InsuranceOrderItem insuranceMaterial)
    {
        decimal result = decimal.Zero;
        
        decimal decmarkup = insuranceMaterial.InsuranceMarkUp;

        if (decmarkup != decimal.Zero)
        {
            decimal total = insuranceMaterial.TotalPremiumAmount;

            result = total * 0.2M;
        }

        return result;
    }
}