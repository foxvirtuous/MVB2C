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
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Core.Product;
using Resources;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using TERMS.Business.Centers.ProductCenter.Profiles;
using Terms.Sales.Service;
using Terms.Product.Business;


public partial class NewTourSearchEngineerListForm : SalseBasePage
{
    private ITopDestinationsDetailConfigService m_TopDestinationsDetailConfigService;
    public ITopDestinationsDetailConfigService TopDestinationsDetailConfigService
    {
        set
        {
            m_TopDestinationsDetailConfigService = value;
        }
    }

    private bool rePageNumber = false;

    public TourMerchandise tourMerchandise
    {
        get
        {
            TourMerchandise tourMerchandiseNew = new TourMerchandise();

            TourMerchandise tourMerchandiseAll = (TourMerchandise)this.OnSearch();

            tourMerchandiseNew.TourProductList = tourMerchandiseAll.TourProductList;

            if (CityCode != string.Empty)
            {
                for (int i = 0; i < tourMerchandiseAll.Items.Count; i++)
                {
                    TourMaterial tourMaterial = (TourMaterial)tourMerchandiseAll.Items[i];
                    TourMaterial tourMaterialCN = (TourMaterial)tourMerchandiseAll.TourMCN[i];

                    TourProfile tourprofile = (TourProfile)tourMaterial.Profile;

                    TERMS.Common.City StartCity = tourprofile.StartCity;

                    if (CityCode.Trim().ToUpper() == StartCity.Code.Trim().ToUpper())
                    {
                        tourMerchandiseNew.Add(tourMaterial);
                        tourMerchandiseNew.TourMCN.Add(tourMaterialCN);
                        continue;
                    }
                }
            }
            else if (Price != string.Empty)
            {
                for (int i = 0; i < tourMerchandiseAll.Items.Count; i++)
                {
                    TourMaterial tourMaterial = (TourMaterial)tourMerchandiseAll.Items[i];
                    TourMaterial tourMaterialCN = (TourMaterial)tourMerchandiseAll.TourMCN[i];

                    TourProfile tourprofile = (TourProfile)tourMaterial.Profile;

                    if (((Terms.Product.Business.MVTourProfile)tourprofile).StartFromLandOnlyFare.ToString() == Price)
                    {
                        tourMerchandiseNew.Add(tourMaterial);
                        tourMerchandiseNew.TourMCN.Add(tourMaterialCN);
                        continue;
                    }
                }
            }
            else if (TourSearchEngineer != string.Empty)
            {
                for (int i = 0; i < tourMerchandiseAll.Items.Count; i++)
                {
                    TourMaterial tourMaterial = (TourMaterial)tourMerchandiseAll.Items[i];
                    TourMaterial tourMaterialCN = (TourMaterial)tourMerchandiseAll.TourMCN[i];

                    TourProfile tourprofile = (TourProfile)tourMaterial.Profile;

                    List<string> tourcodes = new List<string>();

                    if (((Terms.Product.Business.MVTourProfile)tourprofile).Code.ToLower().Trim().Contains(TourSearchEngineer.ToLower().Trim()))
                    {
                        tourMerchandiseNew.Add(tourMaterial);
                        tourMerchandiseNew.TourMCN.Add(tourMaterialCN);
                        tourcodes.Add(((Terms.Product.Business.MVTourProfile)tourprofile).Code.ToLower().Trim());
                        continue;
                    }
                    else if (((Terms.Product.Business.MVTourProfile)tourprofile).Name.ToLower().Trim().Contains(TourSearchEngineer.ToLower().Trim()) && !tourcodes.Contains(((Terms.Product.Business.MVTourProfile)tourprofile).Code.ToLower().Trim()))
                    {
                        tourMerchandiseNew.Add(tourMaterial);
                        tourMerchandiseNew.TourMCN.Add(tourMaterialCN);
                        tourcodes.Add(((Terms.Product.Business.MVTourProfile)tourprofile).Code.ToLower().Trim());
                        continue;
                    }
                }
            }
            else
                return tourMerchandiseAll;

            return tourMerchandiseNew;
        }
    }

    private const int FIRST_PAGE_LEN = 5;

    public NewTourSearchEngineerListForm()
    {
        this.InitializeControls += new EventHandler(NewTourSearchEngineerListForm_InitializeControls);
        this.PreRender += new EventHandler(NewTourSearchEngineerListForm_PreRender);
    }

    private void Initial()
    {
        bool bclException = false;
        string strMessage = string.Empty;
        try
        {
            InitPageNumber(0);
            BindInfo();
        }
        catch (Exception ex)
        {
            bclException = true;
            strMessage = ex.Message;
        }
    }

    private PagedDataSource InitPageNumber(int index)
    {
        PagedDataSource pds = new PagedDataSource();

        List<TourMaterial> TourMaterials = new List<TourMaterial>();

        if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
        {
            for (int i = 0; i < tourMerchandise.Items.Count; i++)
            {
                TourMaterials.Add(((TourMaterial)tourMerchandise.Items[i]));
            }
        }
        TourMaterials.Sort(CompareByStartFromLandOnlyFareAndTourCode);

        pds.DataSource = TourMaterials;
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

    private void BindInfo()
    {
    }

    private void Bind(int index)
    {
        dlTourList.DataSource = null;
        dlTourList.DataBind();

        dlTourList.DataSource = InitPageNumber(index);
        dlTourList.DataBind();
    }

    private void NewTourSearchEngineerListForm_PreRender(object sender, EventArgs e)
    {
        if (!IsSearchConditionNull)
        {
            if (!rePageNumber)
                Bind(PageNumber1.CurrentPageIndex);
            else
            {
                this.PageNumber1.DrawingNum();
                Bind(0);
            }
        }
    }

    private void NewTourSearchEngineerListForm_InitializeControls(object sender, EventArgs e)
    {
        if (IsSearchConditionNull)
        {
            Response.Redirect("~/ErrorPages/GenericErrorPage.aspx", true);
        }
        
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        tourMerchandise.LanguageFlag = UserCulture.Name;
        Page.Session["IsSelectDate"] = null;
       
        this.SetWebSiteInfomation();
        try
        {
            if (!IsPostBack)
            {
                if (!UserCulture.Name.Contains("zh-CN"))
                {
                    if (Request["Preference"] != null)
                    {

                    }
                }

                if (!IsSearchConditionNull)
                {
                    //Log
                    TurboTT.Log.Core.TimeLog tlLoad = new TurboTT.Log.Core.TimeLog(PageUtility.TourLogRandomNumber.ToString() + "Load Tour More Search Result From:");
                    tlLoad.Start();

                    Initial();

                    //log
                    tlLoad.Stop();
                    PageUtility.TourSearchingTimeLog.Info(tlLoad);
                }                
            }
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }

        if (!IsPostBack)
        {
            if (!IsSearchConditionNull)
            {
                //如果Session国旗或者Utility.Transaction.Difference为空  Add zyl 2009-8-18
                Utility.Transaction.Difference.To = "Page List";
                Utility.Transaction.Difference.ToTime = DateTime.Now;
                Utility.Transaction.Difference.EndTime = DateTime.Now;
            }
        }

        try
        {
            using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\SearchTour4" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".txt"))
            {
                sw.Write("Star");
            }
        }
        catch
        {
        }
    }


    protected void dlTourList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl_PriceValue = (Label)e.Item.FindControl("lbl_PriceValue");
            TourMaterial tourMaterial = (TourMaterial)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
            lbl_PriceValue.Text = ((Terms.Product.Business.MVTourProfile)tourMaterial.Profile).StartFromMinFare.ToString("#,###");

            TourProfile tourProfile = (TourProfile)tourMaterial.Profile;
            Label lbl_DeptCity = (Label)e.Item.FindControl("lblDeparturePlace");
            lbl_DeptCity.Text = ((Terms.Product.Business.MVTourProfile)tourProfile).StartCity.Name;

            Label lblVisiting = (Label)e.Item.FindControl("lblVisiting");

            if (tourProfile.PassCities != null && tourProfile.PassCities.Count > 0)
            {
                List<string> CityNames = new List<string>();

                for (int i = 0; i < tourProfile.PassCities.Count; i++)
                {
                    CityNames.Add(tourProfile.PassCities[i].Name);
                }

                lblVisiting.Text = string.Join(@", ", CityNames.ToArray());
            }

            Label lbl_Highlight = (Label)e.Item.FindControl("lblHighlight");
            lbl_Highlight.Text = ((TourMaterial)tourMaterial).Profile.Description;

            Label lblOperating = (Label)e.Item.FindControl("lblOperating");
            lblOperating.Text = ((MVTourProfile)((TourMaterial)tourMaterial).Profile).Operating ;

            Image img_Tour = (Image)e.Item.FindControl("imgTour");
            System.Web.UI.HtmlControls.HtmlImage Icon21 = (System.Web.UI.HtmlControls.HtmlImage)e.Item.FindControl("Icon21");
            System.Web.UI.HtmlControls.HtmlImage Icon22 = (System.Web.UI.HtmlControls.HtmlImage)e.Item.FindControl("Icon22");
            img_Tour.ImageUrl = @"http://terms.majestic-vacations.com/" + ((TourMaterial)tourMaterial).Profile.Logo.Replace(@"~", "");

            Image imgSale = (Image)e.Item.FindControl("imgSale");
            if (((MVTourProfile)((TourMaterial)tourMaterial).Profile).PromotionType != null && ((MVTourProfile)((TourMaterial)tourMaterial).Profile).PromotionType.Length > 0)
            {
                string type = ((MVTourProfile)((TourMaterial)tourMaterial).Profile).PromotionType;

                string typeSale = type.Substring(3, 1);

                if (typeSale == "1")
                {
                    imgSale.Visible = true;
                    imgSale.ImageUrl = "http://www.majestic-vacations.com/images/icon_sale.png";
                }
                else
                    imgSale.Visible = false;

                string type21 = type.Substring(4, 1);

                if (type21 == "1")
                    Icon21.Visible = true;
                else
                    Icon21.Visible = false;

                string type22 = type.Substring(5, 1);

                if (type22 == "1")
                    Icon22.Visible = true;
                else
                    Icon22.Visible = false;

                if (type.Length > 6)
                {
                    string typeSaleChina = type.Substring(6, 1);

                    if (typeSaleChina == "1")
                    {
                        imgSale.Visible = true;
                        imgSale.ImageUrl = "http://www.majestic-vacations.com/images/icon_sale_02.png";
                    }
                    else
                        imgSale.Visible = false;
                }

            }
            else
            {
                imgSale.Visible = false;
                Icon22.Visible = false;
                Icon22.Visible = false;
            }
        }
    }

    protected void dlTourList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int index = 0;//lblTourCode
        Label lkTourName = (Label)e.Item.FindControl("lblTourName");
        Label lblPrice = (Label)e.Item.FindControl("lbl_PriceValue");
        Label lblTourCode = (Label)e.Item.FindControl("lblTourCode");
        for (int i = 0; i < tourMerchandise.Items.Count; i++)
        {
            TourMaterial tm = (TourMaterial)tourMerchandise.Items[i];
            string price = string.Empty;
            if (((TourSearchCondition)this.Transaction.CurrentSearchConditions).IsLandOnly)
                price = ((Terms.Product.Business.MVTourProfile)tm.Profile).StartFromLandOnlyFare.ToString("#,###");
            else
                price = ((Terms.Product.Business.MVTourProfile)tm.Profile).StartFromAirLandFare.ToString("#,###");
            if (tm.Profile.Name.Equals(lkTourName.Text) && price == lblPrice.Text)
            {
                index = i;
                break;
            }
        }

        if (e.CommandName == "Select" || e.CommandName == "SelectName")
        {
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SelectTour, this);
            TourSearchCondition tourSearchCondition = (TourSearchCondition)Utility.Transaction.CurrentSearchConditions;
            tourSearchCondition.Counrty = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[index]).Profile).StartCity.Country.Code;
            tourSearchCondition.DeptCity = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[index]).Profile).DefaultDepartureCity.Code;
            this.Transaction.IntKey = tourSearchCondition.GetHashCode();
            this.Transaction.CurrentSearchConditions = tourSearchCondition;
            this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

            List<string> lTousrCode = new List<string>();
            lTousrCode.Add("11MVCN-A");
            lTousrCode.Add("11MVCN-B");
            lTousrCode.Add("11MVCN-C");
            lTousrCode.Add("11MVCN-D");

            if (lTousrCode.Contains(lblTourCode.Text))
            {
                UserCulture = new CultureInfo("zh-CN");
            }
            this.Response.Redirect("NewTourSelectTourForm.aspx?ReturnURL=NewTourMoreSearchResultForm.aspx" + "&ConditionID=" + this.Transaction.IntKey.ToString() + "&PriceType=L&TourCode=" + lblTourCode.Text + "&TopDestinations=" + TopDes + "&Preference=0");
        }
    }

    //首先根据Tour的StartFromLandOnlyFare排序，如果价格一样再根据TourCode排序
    protected static int CompareByStartFromLandOnlyFareAndTourCode(Component c1, Component c2)
    {
        int result = ((Terms.Product.Business.MVTourProfile)c1.Profile).StartFromLandOnlyFare.CompareTo(((Terms.Product.Business.MVTourProfile)c2.Profile).StartFromLandOnlyFare);

        if (result == 0)
        {
            return ((Terms.Product.Business.MVTourProfile)c1.Profile).Code.CompareTo(((Terms.Product.Business.MVTourProfile)c2.Profile).Code);
        }

        return result;
    }


    public string TopDes
    {
        get
        {
            if (Request["TopDestinations"] != null)
                return Request["TopDestinations"].Trim();

            return string.Empty;
        }
    }

    public string CityCode
    {
        get
        {
            if (Request["CityCode"] != null)
                return Request["CityCode"].Trim();

            return string.Empty;
        }
    }

    public string Price
    {
        get
        {
            if (Request["Price"] != null)
                return Request["Price"].Trim();

            return string.Empty;
        }
    }

    public string TourSearchEngineer
    {
        get
        {
            if (Request["TourSearchEngineer"] != null)
                return Request["TourSearchEngineer"].Trim();

            return string.Empty;
        }
    }
}
