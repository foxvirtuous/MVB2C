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

public partial class TourMoreSearchResultForm : SalseBasePage
{
    private bool rePageNumber = false;
    private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(typeof(TourMoreSearchResultForm));
    public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.OnSearch();
        }
    }

    private const int FIRST_PAGE_LEN = 20;

    public TourMoreSearchResultForm()
    {
        this.InitializeControls += new EventHandler(TourMoreSearchResultForm_InitializeControls);
        this.PreRender += new EventHandler(TourMoreSearchResultForm_PreRender);
    }

    private void TourMoreSearchResultForm_PreRender(object sender, EventArgs e)
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

    private void TourMoreSearchResultForm_InitializeControls(object sender, EventArgs e)
    {
        try
        {
            using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\SearchTour3" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".txt"))
            {
                sw.Write("Star");
            }
        }
        catch
        {
        }

        if (IsSearchConditionNull)
        {
            Response.Redirect("~/ErrorPages/GenericErrorPage.aspx", true);
        }

        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        tourMerchandise.LanguageFlag = UserCulture.Name;
        Page.Session["IsSelectDate"] = null;
        Master.StepNumber = 2;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = false;
        this.SetWebSiteInfomation();
        try
        {
            if (!IsPostBack)
            {
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

        if (lblArea.Text != "" && Utility.IsTourMore )
        { 
            string Area = lblArea.Text;
            if (Area.ToUpper().Replace(" ", "") == Global.Tour_Area_EestCoast.ToString())
                divECBuy2Get1Free.Visible = true;
            if (Area.ToUpper().Replace(" ", "") == Global.Tour_Area_WestCoast.ToString())
                divWCBuy2Get1Free.Visible = true;
            if (Area.ToUpper().Replace(" ", "") == Global.Tour_Area_Hawaii.ToString())
                divHCBuy2Get1Free.Visible = true;
        }

        if (!IsPostBack)
        {
            if (!IsSearchConditionNull)
            {
                //如果Session国旗或者Utility.Transaction.Difference为空  Add zyl 2009-8-18
                Utility.Transaction.Difference.To = "Page List";
                Utility.Transaction.Difference.ToTime = DateTime.Now;
                Utility.Transaction.Difference.EndTime = DateTime.Now;
                log.Debug(Utility.Transaction.Difference.DiffList);
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
            log.Error(ex.Message, ex);
            bclException = true;
            strMessage = ex.Message;
        }
    }

    private PagedDataSource InitPageNumber(int index)
    {
        PagedDataSource pds = new PagedDataSource();

        List<TourMaterial> TourMaterials = new List<TourMaterial>();

        for (int i = 0; i < tourMerchandise.Items.Count; i++)
        {
            TourMaterials.Add(((TourMaterial)tourMerchandise.Items[i]));
        }

        ExceptionViewCode(TourMaterials);

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
        if (this.Session["IsDisplay2008Area"] != null && UserCulture.Name.Contains("en-US"))
            this.lblArea.Text = this.Session["IsDisplay2008Area"].ToString();
        if (this.Session["IsDisplay2008AreaCN"] != null && UserCulture.Name.Contains("zh-CN"))
            this.lblArea.Text = this.Session["IsDisplay2008AreaCN"].ToString();
    }

    private void Bind(int index)
    {
        dlTourList.DataSource = null;
        dlTourList.DataBind();

        dlTourList.DataSource = InitPageNumber(index);
        dlTourList.DataBind();
    }


    protected void dlTourList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int index = 0;//lblTourCode
        LinkButton lkTourName = (LinkButton)e.Item.FindControl("hlTourName");
        Label lblPrice = (Label)e.Item.FindControl("lbl_PriceValue");
        Label lblTourCode = (Label)e.Item.FindControl("lblTourCode");
        for (int i = 0;i< tourMerchandise.Items.Count;i++)
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

            if ( lTousrCode.Contains(lblTourCode.Text))
            {
                UserCulture = new CultureInfo("zh-CN");
            }
            this.Response.Redirect("TourSelectTourForm.aspx?ReturnURL=TourMoreSearchResultForm.aspx" + "&ConditionID=" + this.Transaction.IntKey.ToString() + "&PriceType=L&TourCode=" + lblTourCode.Text);
        }
    }
    protected void dlTourList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl_PriceValue = (Label)e.Item.FindControl("lbl_PriceValue");
            TourMaterial tourMaterial = (TourMaterial)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
            lbl_PriceValue.Text = ((Terms.Product.Business.MVTourProfile)tourMaterial.Profile).StartFromMinFare.ToString("#,###");

        }
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        if (Utility.IsSubAgent)
            Response.Redirect("~/B2B_SUB/TourIndex.aspx");
        else
            Response.Redirect("~/TourIndex.aspx");
    }


    private void ExceptionViewCode(List<TourMaterial> items)
    {
        string filePath = string.Empty;

        string codes = string.Empty;

        filePath = @"/Config/TourExceptionViewCode.xml";

        if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + filePath))
        {
            DataSet ds = new DataSet();

            ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + filePath);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                if (UserCulture.Name.Contains("zh-CN"))
                {
                    codes = ds.Tables[0].Rows[0]["CN"].ToString();
                }
                else
                {
                    codes = ds.Tables[0].Rows[0]["EN"].ToString();
                }

                List<string> codeList = new List<string>();

                codeList.AddRange(codes.Split(new char[] { ',' }));

                for (int i = items.Count - 1; i >= 0; i--)
                {
                    if (codeList.Contains((items[i]).Profile.Code.Trim()))
                    {
                        items.RemoveAt(i);
                    }
                }
            }
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
}
