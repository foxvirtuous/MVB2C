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
using Terms.Sales.Business;

public partial class VehcileInfoViewForm : SalseBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Header1.Path = "../../";
        NavigationControl1.PageCode = 2;

        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (!IsPostBack)
        {
            VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

            VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

            for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
            {
                VehcileMaterial vehcilematerial = (TERMS.Business.Centers.ProductCenter.Components.VehcileMaterial)m_SaleMerchandise.Items[i];

                if (vehcilematerial.VendorCode == VendorCode && vehcilematerial.Vehciles.MakeModelCode == CarCode)
                {
                    Terms.Sales.Business.VehcileLocation vehcilelocation = new Terms.Sales.Business.VehcileLocation();

                    TERMS.Common.Search.VehcileLocationSearchCondition vehcilelocationsearchconditionPick = new TERMS.Common.Search.VehcileLocationSearchCondition(vehcilematerial.VendorCode, vehcilematerial.PickupLocationCode, vehcilesearchcondition.DropoffISOCountryCode, vehcilematerial.CurrencyCode);

                    vehcilelocation.Searchlocdetail(vehcilelocationsearchconditionPick, vehcilematerial, true);
                    
                    TERMS.Common.Search.VehcileLocationSearchCondition vehcilelocationsearchconditionDrop = new TERMS.Common.Search.VehcileLocationSearchCondition(vehcilematerial.VendorCode, vehcilematerial.DropoffLocationCode, vehcilesearchcondition.DropoffISOCountryCode, vehcilematerial.CurrencyCode);

                    vehcilelocation.Searchlocdetail(vehcilelocationsearchconditionDrop, vehcilematerial, false);
                }
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

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        string error = string.Empty;

        if (VehcileAttachmentInfoControl1.AddSpecial(out error))
        {
            this.Response.Redirect("VehcilePriceForm.aspx?VendorCode=" + VendorCode + "&CarCode=" + CarCode + "&ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + error + "');</script>");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("SearchConditionsMeassageCForm.aspx?VendorCode=" + VendorCode + "&CarCode=" + CarCode + "&ConditionID=" + Request.Params["ConditionID"]);
    }
}