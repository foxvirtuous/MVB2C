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
using TERMS.Core.Product;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Sales.Business;
using System.Globalization;
using Terms.Sales.Service;
using Spring.Context;
using Spring.Context.Support;
using System.Collections.Generic;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Profiles;

public partial class CurrentItineraryControl : SalesBaseUserControl
{
    private bool m_IsShowPart2 = false;
    public bool IsShowPart2
    {
        set { m_IsShowPart2 = value; }
    }

    private bool m_IsShowPrint = false;
    public bool IsShowPrint
    {
        set { m_IsShowPrint = value; }
    }

    public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.OnSearch();

        }        
    }

    public string SelectTourCode
    {
        get
        {
            if (Request["TourCode"] != null)
                return Request["TourCode"].Trim().ToLower();
            else
                return string.Empty;
        }
    }

    private TourMaterial _tourmaterial = null;
    public TourMaterial SelectTourMaterial
    {
        get
        {
            if (_tourmaterial == null || ((TourProfile)_tourmaterial.Profile).Code.Trim().ToLower() != SelectTourCode)
            {
                if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.Items.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.Items[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            _tourmaterial = (TourMaterial)tourMerchandise.Items[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return _tourmaterial;
        }
    }

    private TourProduct tourproduct = null;
    public TourProduct TourProduct
    {
        get
        {
            if (tourproduct == null || ((TourProfile)tourproduct.Profile).Code.Trim().ToLower() != SelectTourCode)
            {

                if (tourMerchandise != null && tourMerchandise.TourProductList != null && tourMerchandise.TourProductList.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.TourProductList.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.TourProductList[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            tourproduct = (TourProduct)tourMerchandise.TourProductList[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return tourproduct;
        }
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                IsDownChineseItinerary();
                InitPage();


            }

            //SearchToBinder();
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }
    public void InitPage()
    {
        IApplicationContext ctx = ContextRegistry.GetContext();

        IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;
        TourSearchCondition tourSearchCondition = (TourSearchCondition)this.Transaction.CurrentSearchConditions;

        TourProfile tourProfile = (TourProfile)SelectTourMaterial.Profile;
        this.lbl_DeptCity.Text = tourProfile.DefaultDepartureCity.Name;
        lbl_travelDate.Text = tourProfile.Days.ToString() + " Days";
        if (m_IsShowPrint)
            this.printLink.Visible = true;
        if (SelectTourMaterial != null && m_IsShowPart2)
        {
            TourMaterial tourMaterial = (TourMaterial)SelectTourMaterial;
            lbl_TourName.Text = tourMaterial.Profile.Name;
            lbl_TourCode.Text = tourMaterial.Profile.Code;
        }

        lbl_Price.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).StartFromMinFare.ToString("#,###");
        lbl_Link.Text = @"http://www.majestic-vacations.com/Tourindex.aspx?tab=T&code=" + lbl_TourCode.Text.Trim();
    }

    private void IsDownChineseItinerary()
    {
        TourMaterial tourMaterial = (TourMaterial)SelectTourMaterial;
        string FileName = string.Empty;
        string path = this.Server.MapPath("~");
        string dummyFileName = string.Empty;
        FileName = path + "\\Files\\ItineraryTC\\" + tourMaterial.Profile.Code + ".pdf";
        dummyFileName = SaleWebSuffix + "Files/ItineraryTC/" + tourMaterial.Profile.Code + ".pdf";
        try
        {
            if (System.IO.File.Exists(FileName) == true)
            {
                this.hlItinerary.NavigateUrl = dummyFileName;
                this.hlItinerary.Target = "_blank";
            }
            else
            {
                this.hlItinerary.Visible = false;
            }
        }
        catch
        {
            throw;
        }
    }

}
