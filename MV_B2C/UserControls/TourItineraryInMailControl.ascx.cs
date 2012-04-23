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
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Profiles;

public partial class TourItineraryInMailControl : SalesBaseUserControl
{
    
   public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.TourOnSearch();
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
                InitPage();
            }
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }
    public void InitPage()
    {
        if (SelectTourMaterial != null)
        {

            dlTourItinerary.DataSource = ((TourMaterial)SelectTourMaterial).Itinerarys;
            dlTourItinerary.DataBind();
        }
    }

    protected void dlTourItinerary_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl_MealAndHotel = (Label)e.Item.FindControl("lbl_MealAndHotel");
            if ((((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem))) is TourItinerary)
            {
                TourItinerary tt = (TourItinerary)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
                string htmlStr = "<hr size=\"1\" color=\"#dddddd\" />";
                     htmlStr +="<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr>";
                int mealCount = 0;
                for (int i = 0; i < tt.Items.Count; i++)
                {
                    if (tt.Items[i] is MealMaterial)
                    {
                        mealCount++;
                        htmlStr += "<td width=\"33%\">";
                        htmlStr += ((MealMaterial)tt.Items[i]).MealType.ToString() + "&#58;&nbsp;" + ((MealMaterial)tt.Items[i]).Profile.Name.ToString();
                        htmlStr += "</td>";
                    }
                    else
                    {
                        htmlStr += "</tr>";
                        htmlStr += "<tr><td colspan=\"" + mealCount.ToString() + "\">";
                        htmlStr += "Hotel&#58;&nbsp;" + ((ComponentGroup)tt.Items[i]).Profile.Name.ToString();
                        htmlStr += "</td><tr>";

                    }
                }
                htmlStr += "</tr>";
                lbl_MealAndHotel.Text = htmlStr;
            }
        }
    }
}
