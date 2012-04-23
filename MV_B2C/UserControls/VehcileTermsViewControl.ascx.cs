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
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;

public partial class VehcileTermsViewControl : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

        VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

        for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
        {
            VehcileMaterial vehcilematerial = (VehcileMaterial)m_SaleMerchandise.Items[i];

            if (vehcilematerial.VendorCode == VendorCode && vehcilematerial.Vehciles.MakeModelCode == CarCode)
            {
                //lblPayment.Text = ((Terms.Material.Service.Vehcile.LocationDetail)vehcilematerial.PickLocationDetail).CreditCard.Text;
            }
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
}