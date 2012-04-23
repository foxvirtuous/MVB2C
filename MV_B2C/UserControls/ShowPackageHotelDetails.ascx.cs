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
using System.Collections.Generic;
using Spring.Web.UI;
using log4net;
using Terms.Sales.Domain;
using Terms.Sales.Service;

using Terms.Base.Domain;
using Terms.Product.Domain;
using Terms.Common.Service;
using Terms.Common.Dao;
using Terms.Common.Domain;
using Terms.Base.Utility;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;

public partial class ShowPackageHotelDetails : SalesBaseUserControl
{
    public static int PAGE_SIZE = 10;
    private int m_previousPageIndex = 0;

    private bool rePageNumber = false;

    public int PreviousPageIndex
    {
        get
        {
            return m_previousPageIndex;
        }
        set
        {
            m_previousPageIndex = value;
        }
    }

    private int m_HotelListIndex = 0;

    public int HotelListIndex
    {
        get
        {
            return m_HotelListIndex;
        }
        set
        {
            m_HotelListIndex = value;
        }
    }

    public int Adult
    {
        get { return (int)ViewState["adult"]; }
        set { ViewState["adult"] = value; }
    }

    public int Child
    {
        get { return (int)ViewState["child"]; }
        set { ViewState["child"] = value; }
    }

    public string HotelId
    {
        get
        {
            if (dlHotelDetails != null)
            {
                if (dlHotelDetails.Items.Count != 0)
                {
                    DataListItem item = dlHotelDetails.Items[0];

                    Label lbl = (Label)item.FindControl("lblHotelID");

                    if (lbl != null)
                    {
                        return lbl.Text;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }

    private int m_sonIndex = 0;

    public int SonIndex
    {
        get
        {
            return m_sonIndex;
        }
        set
        {
            m_sonIndex = value;
        }
    }
    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }
    private ISaleMerchandiseSearcherService _SaleMerchandiseSearcherService;
    public ISaleMerchandiseSearcherService SaleMerchandiseSearcherService
    {
        set { _SaleMerchandiseSearcherService = value; }
    }

    private List<PackageMaterial> _hotelDetails;
    public List<PackageMaterial> HotelDetails
    {
        

        set
        {
            if (value is List<PackageMaterial>)
            {
                _hotelDetails = value;
                BindDataList(0);
               
            }
        }
        get
        {
            if (_hotelDetails == null)
            {
                _hotelDetails = new List<PackageMaterial>();
            }

            return _hotelDetails;
        }
    }

    private PackageMerchandise _packageMerchandise;
    public PackageMerchandise PgMerchandise
    {
        set
        {
            _packageMerchandise = value;    
        }
        get
        {
            return _packageMerchandise;
        }
    }


    public ShowPackageHotelDetails()
    {
        this.InitializeControls += new EventHandler(ShowPackageHotelDetails_InitializeControls);
        this.PreRender +=new EventHandler(ShowPackageHotelDetails_PreRender);
    }

    private void ShowPackageHotelDetails_InitializeControls(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        try
        {
            if (!IsPostBack)
            {

             
                BindCountry();
                this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.Country));
                ddlCountry_SelectedIndexChanged(null, new EventArgs());
                this.ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByValue(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.Location));
                //if (HotelDetails == null || HotelDetails.Count == 0)
                //{
                //    BinderHotelDetails();
                //}
                //else
                //{
                //    //List<MVHotel> hotelMaterialNew = new List<MVHotel>();

                //    //FilterHotel(_hotelDetails, ref hotelMaterialNew);

                //    BindDataList(_hotelDetails);
                //}
            }
        }
        catch
        {

        }
    }
   
    private void BindCountry()
    {
        IList ilist = _CommonService.FindCountryAll();

        ddlCountry.DataSource = ilist;
        ddlCountry.DataTextField = "Name";
        ddlCountry.DataValueField = "Code";
        ddlCountry.DataBind();

        ListItem item = new ListItem("--Select--", string.Empty);

        ddlCountry.Items.Insert(0, item);

        ddlCountry_SelectedIndexChanged(null, new EventArgs());
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCity.Items.Clear();
        ddlCity.DataBind();

        if (ddlCountry.SelectedIndex > 0)
        {
            IList ilist = _CommonService.FindCitiesByCountryCode(ddlCountry.SelectedValue);

            ddlCity.DataSource = ilist;
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Code";
            ddlCity.DataBind();
        }

        ListItem item = new ListItem("--Select--", string.Empty);

        ddlCity.Items.Insert(0, item);
    }

    private void FilterHotel()
    {
        List<MVHotel> currentList = new List<MVHotel>();
       
        if (this.ddlCountry.SelectedIndex > 0 && this.ddlCity.SelectedIndex > 0)
        {
            string strCityCode = this.ddlCity.SelectedValue;

            for (int i = 0; i < ((HotelMerchandise)PgMerchandise.Items[1 + HotelListIndex]).Items.Count; i++)
            {
                if (((MVHotel)((HotelMerchandise)PgMerchandise.Items[1 + HotelListIndex]).Items[i]).HotelInformation.City.Code.Trim() == strCityCode.Trim())
                {
                    currentList.Add((MVHotel)((HotelMerchandise)PgMerchandise.Items[1 + HotelListIndex]).Items[i]);
                }
            }
        }
        else
        {
            foreach (MVHotel mvHotel in ((HotelMerchandise)PgMerchandise.Items[1 + HotelListIndex]).Items)
            {
                currentList.Add(mvHotel);
            }
        }

        if (currentList.Count > 0)
        {
            ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Clear();
            foreach (MVHotel mvHotel in currentList)
            {
                ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Add(mvHotel);
            }
            currentList = new List<MVHotel>();
        }
        if (this.ddlStar.SelectedIndex > 0)
        {
            string strStar = this.ddlStar.SelectedValue;

            for (int i = 0; i < ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Count; i++)
            {
                if (((MVHotel)((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items[i]).HotelInformation.Class == strStar)
                {
                    currentList.Add((MVHotel)((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items[i]);
                }
            }
        }
        else
        {
            foreach (MVHotel mvHotel in ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items)
            {
                currentList.Add(mvHotel);
            }
        }

        if (currentList.Count > 0)
        {
            ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Clear();
            foreach (MVHotel mvHotel in currentList)
            {
                ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Add(mvHotel);
            }
            currentList = new List<MVHotel>();
        }

        if (this.txtContains.Text.Trim().Length > 0)
        {
            string strContains = txtContains.Text.Trim();

            for (int i = 0; i < ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Count; i++)
            {
                if (((MVHotel)((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items[i]).HotelInformation.Name.ToLower().Contains(strContains.ToLower()))
                {
                    currentList.Add((MVHotel)((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items[i]);
                }
            }
        }
        else
        {
            foreach (MVHotel mvHotel in ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items)
            {
                currentList.Add(mvHotel);
            }
        }

        if (currentList.Count == 0)
        {
            currentList = new List<MVHotel>();
        }
        ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Clear();
        foreach (MVHotel mvHotel in currentList)
        {
            ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Add(mvHotel);
        }
       


        //if (RadioButtonList1.SelectedIndex == 0)
        //{
        //    hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.RoomRates[r1.Hotel.Rooms[0].RoomTypes[0]].BaseFare.CompareTo(r2.RoomRates[r2.Hotel.Rooms[0].RoomTypes[0]].BaseFare); });
        //}
        if (RadioButtonList1.SelectedIndex == 0)
        {
            //((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).SortByPrice();

            MagesticPicksSort(((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items);
        }
        if (RadioButtonList1.SelectedIndex == 1)
        {
            ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).SortByPrice();
        }
        if (RadioButtonList1.SelectedIndex == 2)
        {
            ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).SortByHotelName();
            //hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.HotelInformation.Name.CompareTo(r2.HotelInformation.Name); });
        }
        if (RadioButtonList1.SelectedIndex == 3)
        {
            ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).SortByRating();
           // hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.HotelInformation.Class.Value.CompareTo(r2.HotelInformation.Class.Value); });
        }
    }

    private void BindDataList(int index)
    {
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = PgMerchandise.GetPackageMaterials(1 + HotelListIndex);
        pds.PageSize = PAGE_SIZE;
        PageNumberControl1.PageSize = PAGE_SIZE;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = index >= 0 ? index : 0;
        PageNumberControl1.CurrentPageIndex = pds.CurrentPageIndex;
        PageNumberControl1.PageAmount = pds.PageCount;
        PageNumberControl1.ItemAmount = pds.DataSourceCount;
        if (pds.DataSourceCount < PAGE_SIZE + 1)
            PageNumberControl1.Visible = false;
        else
            PageNumberControl1.Visible = true;

        
        this.dlHotelDetails.DataSource = pds;
        this.dlHotelDetails.DataBind();
    }
    
    protected void btnShow_Click(object sender, EventArgs e)
    {
        List<PackageMaterial> hotelMaterialNew = new List<PackageMaterial>();
        //this.Request["PageIndex"] = 1;
        FilterHotel();
        BindDataList(0);
    }

    private void BinderHotelDetails()
    {
        this.dlHotelDetails.DataSource = HotelDetails;
        this.dlHotelDetails.DataBind();
    }
    protected void dlHotelDetails_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Trim().ToUpper() == "SELECT".Trim().ToUpper() || e.CommandName.Trim().ToUpper() == "CHOOSE".Trim().ToUpper())
        {
            if (this.Request["Destination"] != null)
            {
                //if (this.Request["ChooseHotelID"] != null)
                //{
                //    for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Count; i++)
                //    {
                //        if (((HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList[i]).Hotel.Id.ToString() == this.Request["ChooseHotelID"])
                //        {
                //            string hotelid = ((Label)e.Item.FindControl("lblHotelID")).Text;
                //            Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Remove((HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList[i]);
                //            foreach (HotelMaterial hm in HotelDetails)
                //            {
                //                if (hm.Hotel.Id.ToString() == hotelid)
                //                {
                //                    Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Insert(i, hm);
                //                }
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Add((HotelMaterial)HotelDetails[e.Item.ItemIndex]);
                //}

                this.Response.Redirect("PackageSearchResult2dFrom.aspx?PostBack=false" + "&ConditionID=" + Request.Params["ConditionID"]);
            }
            //else if (Destination != null && this.Request["Add"] != null && Destination == "Two")
            //{
            //    Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Add((HotelMaterial)HotelDetails[e.Item.ItemIndex]);
            //    this.Response.Redirect("PackageSearchResult2dFrom.aspx?PostBack=false");
            //}
            //else if (this.Request["Add"] != null && Destination != null && Destination == "1")
            //{
            //    Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Add((HotelMaterial)HotelDetails[e.Item.ItemIndex]);
            //    Session["HotelID"] = e.Item.FindControl("lblHotelID");
            //    this.Response.Redirect("PackageSelectRoomsForm.aspx?HotelID=" + ((Label)e.Item.FindControl("lblHotelID")).Text.Trim() + "&ParentIndex=" + ParentIndex.ToString() + "&SonIndex=" + SonIndex.ToString());
            //}
            else
            {
               
                Session["HotelID"] = e.Item.FindControl("lblHotelID");
                ((List<int>)this.PgMerchandise.DefaultIndex[1 + HotelListIndex])[0] = (PageNumberControl1.CurrentPageIndex * PAGE_SIZE) + e.Item.ItemIndex;
                string TableName = "";
                if (e.CommandName.Trim().ToUpper() == "CHOOSE".Trim().ToUpper())
                    TableName = "&TableName=Features";
                //记录选择了Package事件
                if (Utility.IsSubAgent)
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SelectPackage, this);
                else
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SelectPackage, this);

                this.Response.Redirect("PackageSelectRoomsForm.aspx?HotelIndex=" + HotelListIndex.ToString() + TableName + "&ConditionID=" + Request.Params["ConditionID"]);
               
            }
        }
       
        
    }
    protected void dlHotelDetails_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //((Label)e.Item.FindControl("lbNights")).Text = ((TimeSpan)((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.Subtract(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn)).Days.ToString();
            //if (Utility.SelectAirGroup != null)
            //{
            //    int adult = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(PassengerType.Adult);
            //    int child = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(PassengerType.Child);
            //    ((Label)e.Item.FindControl("lbTotalPrice")).Text = Decimal.Round(Convert.ToDecimal(((Label)e.Item.FindControl("lbTotalPrice")).Text) + ((AirComponentGroup)Utility.SelectAirGroup.Items[0].Component).Total, 2).ToString();
            //    ((Label)e.Item.FindControl("lbTempPrice")).Text = Decimal.Round(Convert.ToDecimal(((Label)e.Item.FindControl("lbTotalPrice")).Text) * 1.1M, 2).ToString();
            //    ((Label)e.Item.FindControl("lbSubStrctPrice")).Text = Decimal.Round(Convert.ToDecimal(((Label)e.Item.FindControl("lbTotalPrice")).Text) * 0.1M, 2).ToString();
            //    ((Label)e.Item.FindControl("lbAvgPrice")).Text = Decimal.Round(Convert.ToDecimal(((Label)e.Item.FindControl("lbTotalPrice")).Text) / (adult + child), 2).ToString();
            //}

        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<PackageMaterial> hotelMaterialNew = new List<PackageMaterial>();
        
        FilterHotel();
        
        BindDataList(0);
    }

    //public void ReBind()
    //{
    //    List<PackageMaterial> hotelMaterialNew = new List<PackageMaterial>();

    //    FilterHotel();

    //    BindDataList(0,PgMerchandise.GetPackageMaterials(1));
    //}

    /// <summary>
    /// PreRender Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ShowPackageHotelDetails_PreRender(object sender, EventArgs e)
    {
        if (!rePageNumber)
        {
            FilterHotel();
            BindDataList(PageNumberControl1.CurrentPageIndex);
            this.PageNumberControl1.DrawingNum();
        }
        else
        {
            FilterHotel();
            this.PageNumberControl1.DrawingNum();
            BindDataList(0);
        }

        //BODY.Attributes["onload"] = "toggleNLayer('" + ADVANCEDOPTION + "',1);ChangeFlightType('" + ONEWAYFLAG.ToLower() + "');";
    }


    private void MagesticPicksSort(List<TERMS.Business.Centers.SalesCenter.Hotel> pMVHotel)
    {
        //List<MVHotel> hotelLocal = new List<MVHotel>();

        List<MVHotel> hotelOther = new List<MVHotel>();

        for (int i = 0; i < pMVHotel.Count; i++)
        {
            //if (pMVHotel[i].Source.ToUpper() == "Local".ToUpper())
            //{
            //    hotelLocal.Add((MVHotel)pMVHotel[i]);
            //}
            //else
            //{
                hotelOther.Add((MVHotel)pMVHotel[i]);
            //}
        }

        //hotelLocal.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.RoomPricePerNight.CompareTo(r2.RoomPricePerNight); });

        hotelOther.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.RoomPricePerNight.CompareTo(r2.RoomPricePerNight); });

        pMVHotel.Clear();


        //for (int i = 0; i < hotelLocal.Count; i++)
        //{
        //    pMVHotel.Add(hotelLocal[i]);
        //}

        for (int i = 0; i < hotelOther.Count; i++)
        {
            if (hotelOther[i].IsRecommended)
            {
                pMVHotel.Add(hotelOther[i]);
            }
        }

        for (int i = 0; i < hotelOther.Count; i++)
        {
            if (!hotelOther[i].IsRecommended)
            {
                pMVHotel.Add(hotelOther[i]);
            }
        }
    }

}
