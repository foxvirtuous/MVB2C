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
using Terms.Sales.Business;
using Resources;

public partial class TourItineraryControl : SalesBaseUserControl
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

    public bool IsSelectDate
    {
        get
        {
            if (Page.Session["IsSelectDate"] == null)
                return false;
            return (bool)Page.Session["IsSelectDate"];
        }
        set
        {
            Page.Session["IsSelectDate"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {  
                InitPage();
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
            Label lbl_AirTour = (Label)e.Item.FindControl("lbl_AirTour");
            TourItinerary tourItinerary = null;
            if ((((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem))) is TourItinerary)
            {
                TourItinerary tt = (TourItinerary)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
                string htmlStr = "<tr>";
                int mealCount = 0;
                for (int i = 0; i < tt.Items.Count; i++)
                {
                    string strYorN = string.Empty;

                    if (tt.Items[i] is MealMaterial)
                    {
                        string mealType = string.Empty;
                        if (((MealMaterial)tt.Items[i]).MealType == TERMS.Common.MealType.Breakfast)
                            mealType = Global.Breakfast;
                        if (((MealMaterial)tt.Items[i]).MealType == TERMS.Common.MealType.Lunch)
                            mealType = Global.Lunch;
                        if (((MealMaterial)tt.Items[i]).MealType == TERMS.Common.MealType.Dinner)
                            mealType = Global.Dinner;

                        mealCount++;
                        htmlStr += "<td width=\"33%\">";
                        if (((MealMaterial)tt.Items[i]).Profile.Name.ToString() != "")
                        {
                            strYorN = ((MealMaterial)tt.Items[i]).Profile.Name.ToString();
                        }
                        else
                        {
                            strYorN = "-";
                        }
                        htmlStr += mealType + "&#58;&nbsp;" + strYorN;
                        htmlStr += "</td>";
                    }
                    else
                    {
                        if (((ComponentGroup)tt.Items[i]).Profile.Name.ToString() != "")
                        {
                            strYorN = ((ComponentGroup)tt.Items[i]).Profile.Name.ToString();
                        }
                        else
                        {
                            strYorN = "-";
                        }
                        htmlStr += "</tr>";
                        htmlStr += "<tr><td colspan=\"" + mealCount.ToString() + "\">";
                        htmlStr += Global.Hotel + "&#58;&nbsp;" + strYorN;
                        
                        htmlStr += "</td>";

                    }
                }
                htmlStr += "</tr>";
                lbl_MealAndHotel.Text = htmlStr;

                string htmlStr1 = string.Empty;
                if (((TourItineraryProfile)tt.Profile).DomesticAirlines != null)
                {
                    htmlStr1 += @"<tr><td width='100%'>";

                    TourItineraryProfile.DomesticAirline dom = ((TourItineraryProfile)tt.Profile).DomesticAirlines;

                    htmlStr1 += "Airline: ";

                    if (!string.IsNullOrEmpty(dom.Airline))
                        htmlStr1 += dom.Airline + " ";
                    else
                        htmlStr1 += @"N/A ";

                    htmlStr1 += " FlightNo: ";

                    if (!string.IsNullOrEmpty(dom.FlightNo))
                        htmlStr1 += dom.FlightNo + " ";
                    else
                        htmlStr1 += @"N/A ";

                    htmlStr1 += "DepAirportCode: ";

                    if (!string.IsNullOrEmpty(dom.DepAirportCode))
                        htmlStr1 += dom.DepAirportCode + " ";
                    else
                        htmlStr1 += @"N/A ";

                    htmlStr1 += "DesAirportCode: ";

                    if (!string.IsNullOrEmpty(dom.DesAirportCode))
                        htmlStr1 += dom.DesAirportCode + " ";
                    else
                        htmlStr1 += @"N/A ";

                    htmlStr1 += "DepartureTime: ";

                    if (!string.IsNullOrEmpty(dom.DepartureTime))
                        htmlStr1 += dom.DepartureTime + " ";
                    else
                        htmlStr1 += @"N/A ";

                    htmlStr1 += "ArrivelTime: ";

                    if (!string.IsNullOrEmpty(dom.ArrivelTime))
                        htmlStr1 += dom.ArrivelTime + " ";
                    else
                        htmlStr1 += @"N/A ";

                    htmlStr1 += "</td></tr>";
                }
                lbl_AirTour.Text = htmlStr1;                
                tourItinerary = tt;
            }
            Image img = (Image)e.Item.FindControl("imgTour");
            if (tourItinerary.Profile.Logo != "~/")
                img.ImageUrl = img.ImageUrl.ToString().Replace("~/", string.Empty);
            else
                img.Visible = false;

                //img.ImageUrl = "~/images/v1/defaulth.gif";

            if (IsSelectDate)
            {
                Label lblDay = (Label)e.Item.FindControl("lblDay");
                Label lblD = (Label)e.Item.FindControl("lblD");
                Label lblDisp = (Label)e.Item.FindControl("lblDisp");
                lblD.Visible = false;
                lblDisp.Visible = false;
                lblDay.Text = ((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).FlightDeptDate.AddDays(((TourItineraryProfile)tourItinerary.Profile).Day -1).ToString("MM/dd/yyyy",System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            
        }
    }
}
