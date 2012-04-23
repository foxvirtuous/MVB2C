using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Core.Product;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Profiles;


public partial class TourSearchResultForm : SalseBasePage
{
    private bool rePageNumber = false;
    private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(typeof(TourSearchResultForm));
    public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.OnSearch();
        }
    }

    public TourSearchResultForm()
    {
        this.InitializeControls += new EventHandler(TourSearchResultForm_InitializeControls);
        this.PreRender +=new EventHandler(SearchResultForm_PreRender);
    }

    private const int FIRST_PAGE_LEN = 10;

    private void TourSearchResultForm_InitializeControls(object sender, EventArgs e)
    {
        Page.Session["IsSelectDate"] = null;
        Master.StepNumber = 2;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = false;
        try
        {
            if (!IsPostBack)
            {

                Initial();

                
            }

            //SearchToBinder();
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }

        Utility.Transaction.Difference.To = "Page List";
        Utility.Transaction.Difference.ToTime = DateTime.Now;
        Utility.Transaction.Difference.EndTime = DateTime.Now;

        if (!IsPostBack)
        {
            log.Debug(Utility.Transaction.Difference.DiffList);
        }
    }
    /// <summary>
    /// Init page
    /// </summary>
    private void Initial()
    {
        bool bclException = false;
        string strMessage = string.Empty;
        try
        {
            //ItineraryInfo.Itinerary = CurrentSession.CurrentItinerary;
            //ReorganizeReulst();
            InitPageNumber(0);
        }
        catch (Exception ex)
        {
            log.Error(ex.Message, ex);
            bclException = true;
            strMessage = ex.Message;
        }

        //if (bclException)
        //    Err(strMessage, "Unknow Error", "Step2.aspx");
    }

    /// <summary>
    /// Init Result
    /// </summary>
    private void InitialResult()
    {

        //CurrentSession.CurrentItinerary.FareInfo.SetAmout(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(SelectedAirMerchandise.AdultBaseFare, new TERMS.Common.Currency(), new TERMS.Common.Currency()));
        //CurrentSession.CurrentItinerary.FareInfo.SetAmout(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(SelectedAirMerchandise.ChildBaseFare, new TERMS.Common.Currency(), new TERMS.Common.Currency()));
        //CurrentSession.CurrentItinerary.FareInfo.SetMarkup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(SelectedAirMerchandise.AdultMarkup, new TERMS.Common.Currency(), new TERMS.Common.Currency()));
        //CurrentSession.CurrentItinerary.FareInfo.SetMarkup(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(SelectedAirMerchandise.ChildMarkup, new TERMS.Common.Currency(), new TERMS.Common.Currency()));

        //ItineraryInfo.Itinerary = CurrentSession.CurrentItinerary;
    }

    /// <summary>
    /// Init the Page number
    /// </summary>
    /// <param name="index"></param>
    private PagedDataSource InitPageNumber(int index)
    {
        PagedDataSource pds = new PagedDataSource();
        if (((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).IsLandOnly == true)
            tourMerchandise.Items.Sort(delegate(Component c1, Component c2) { return ((Terms.Product.Business.MVTourProfile)c1.Profile).StartFromLandOnlyFare.CompareTo(((Terms.Product.Business.MVTourProfile)c2.Profile).StartFromLandOnlyFare); });
        else
            tourMerchandise.Items.Sort(delegate(Component c1, Component c2) { return ((Terms.Product.Business.MVTourProfile)c1.Profile).StartFromAirLandFare.CompareTo(((Terms.Product.Business.MVTourProfile)c2.Profile).StartFromAirLandFare); }); 
        pds.DataSource = tourMerchandise.Items;
        //((TourProduct)componentGroup.Items[0]).GetSingleLand(;
        pds.PageSize = FIRST_PAGE_LEN;
        PageNumber1.PageSize = FIRST_PAGE_LEN;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = index >= 0 ? index : 0;

        PageNumber1.PageAmount = pds.PageCount;
        if (pds.DataSourceCount < FIRST_PAGE_LEN + 1)
            PageNumber1.Visible = false;
        else
            PageNumber1.Visible = true;

        return pds;
    }
    private void Bind(int index)
    {


        dlTourProduct.DataSource = InitPageNumber(index);
        dlTourProduct.DataBind(); 
    }

    /// <summary>
    /// PreRender Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SearchResultForm_PreRender(object sender, EventArgs e)
    {
        if (!rePageNumber)
            Bind(PageNumber1.CurrentPageIndex);
        else
        {
            this.PageNumber1.DrawingNum();
            Bind(0);
        }

        //BODY.Attributes["onload"] = "toggleNLayer('" + ADVANCEDOPTION + "',1);ChangeFlightType('" + ONEWAYFLAG.ToLower() + "');";
    }
    protected void dlTourProduct_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int index = 0;//e.Item.ItemIndex + PageNumber1.PageSize * PageNumber1.CurrentPageIndex;
        Label lkTourName = (Label)e.Item.FindControl("lblTourName");
        for (int i = 0; i < tourMerchandise.Items.Count; i++)
        {
            TourMaterial tm = (TourMaterial)tourMerchandise.Items[i];
            if (tm.Profile.Name.Equals(lkTourName.Text))
            {
                index = i;
                break;
            }
        }
         
         if (e.CommandName == "Select")
         {
             TourSearchCondition tourSearchCondition = (TourSearchCondition)Utility.Transaction.CurrentSearchConditions;
             tourSearchCondition.Counrty = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[index]).Profile).StartCity.Country.Code;
             tourSearchCondition.City = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[index]).Profile).StartCity.Code;
             tourSearchCondition.DeptCity = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[index]).Profile).DefaultDepartureCity.Code;
             this.Transaction.IntKey = tourSearchCondition.GetHashCode();
             this.Transaction.CurrentSearchConditions = tourSearchCondition;
             this.Response.Redirect("TourSelectTourForm.aspx?ReturnURL=TourSearchResultForm.aspx");
         }
         
    }
    protected void dlTourProduct_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl_HasAir = (Label)e.Item.FindControl("lbl_HasAir");
            Label lbl_DeptFrom = (Label)e.Item.FindControl("lbl_DeptFrom");
            Label lbl_Disp = (Label)e.Item.FindControl("lblDisp");
            Label lbl_PriceValue = (Label)e.Item.FindControl("lbl_PriceValue");
            HtmlTableRow trIsShowAirline = (HtmlTableRow)e.Item.FindControl("trIsShowAirline");

            TourMaterial tourMaterial= (TourMaterial)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
            //lbl_PriceValue.Text = ((TourProfile)tourMaterial.Profile)..
            if (((TourSearchCondition)this.Transaction.CurrentSearchConditions).IsLandOnly)
            {
                lbl_HasAir.Visible = lbl_DeptFrom.Visible = lbl_Disp.Visible = false;
                lbl_PriceValue.Text = ((Terms.Product.Business.MVTourProfile)tourMaterial.Profile).StartFromLandOnlyFare.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                trIsShowAirline.Visible = false;
            }
            else
            {
                lbl_DeptFrom.Text = ((Terms.Product.Business.MVTourProfile)tourMaterial.Profile).DefaultDepartureCity.Name + ")";
                lbl_PriceValue.Text = ((Terms.Product.Business.MVTourProfile)tourMaterial.Profile).StartFromAirLandFare.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
            }


            //if (((TourProfile)tourMaterial.Profile).Airlines.Count==0)
            //    trIsShowAirline.Visible=false;

            Image img = (Image)e.Item.FindControl("imgTour");
            img.ImageUrl = img.ImageUrl.ToString().Replace("~/", string.Empty);
        }
    }
}
