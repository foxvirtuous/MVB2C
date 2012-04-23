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
using Spring.Web.UI;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;
using Terms.Common.Service;
using Spring.Context.Support;


public partial class MapForm : SalseBasePage
{
    protected string mapName = "";
    protected string mapAreaX = "";
    protected string mapAreaY = "";
    protected string location = "";

    private ICommonService m_CommonService;

    public ICommonService CommonService
    {
        set
        {
            m_CommonService = value;
        }
    }

    public IAreaInCityService AreaInCityService
    {
        get
        {
            return ContextRegistry.GetContext()["AreaInCityService"] as IAreaInCityService;
        }
    }

    private bool rePageNumber = false;

    private bool istrue = true;

    private List<MVHotel> m_HotelMaterial;

    public List<MVHotel> HotelMaterial
    {
        set
        {
            if (value is List<MVHotel>)
            {
                m_HotelMaterial = value;
                Session["m_HotelMaterial"] = value;
            }
        }
        get
        {
            m_HotelMaterial = (List<MVHotel>)Session["m_HotelMaterial"];
            if (m_HotelMaterial == null)
            {
                m_HotelMaterial = new List<MVHotel>();
            }

            return m_HotelMaterial;
        }
    }

    public MapForm()
    {
        this.InitializeControls += new EventHandler(MapForm_InitializeControls);
        this.PreRender += new EventHandler(MapForm_PreRender);
    }

    void MapForm_InitializeControls(object sender, EventArgs e)
    {
        if (!Utility.IsSearchConditionNull)
        {
            if (!this.IsPostBack)
            {
                Navigation1.PageCode = 2;

                if (this.Request["Country"] != null)
                {
                    if (!this.IsSearchConditionNull)
                    {
                        HotelSearchCondition hotelSearchCondition = (HotelSearchCondition)Utility.Transaction.CurrentSearchConditions;

                        string hotelName = this.Request["HotelName"];
                        hotelSearchCondition.Location = this.Request["CityCode"];
                        hotelSearchCondition.LocationIndicator = LocationIndicator.City;
                        hotelSearchCondition.CheckIn = Convert.ToDateTime(this.Request["CheckIn"]);
                        hotelSearchCondition.CheckOut = Convert.ToDateTime(this.Request["CheckOut"]);
                        hotelSearchCondition.Country = this.Request["Country"];
                        Utility.Transaction.CurrentSearchConditions = hotelSearchCondition;

                        if (this.Request["edit"] == "y")
                            DeleteBeingChangedHotelOrderItem(hotelName, this.Request["CheckIn"]);

                        this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Hotel2/SearchResultForm");
                    }
                    else
                    {
                        this.Response.Redirect("../../Index.aspx");
                    }
                }
                SearchAndBind();
            }

        }
        else
        {
            //出错处理。

            Err("The search condition has been removed from cache, please re-search.", "", "SearchResultForm.aspx");
        }
    }

    void MapForm_PreRender(object sender, EventArgs e)
    {
        List<MVHotel> hotelMaterialNew = new List<MVHotel>();

        if (!rePageNumber)
        {
            FilterHotel(m_HotelMaterial, ref hotelMaterialNew);
            BindDataList(hotelMaterialNew, PageNumberControl1.CurrentPageIndex);
        }
        else
        {
            FilterHotel(m_HotelMaterial, ref hotelMaterialNew);
            this.PageNumberControl1.DrawingNum();
            BindDataList(hotelMaterialNew, 0);
        }
    }

    private void DeleteBeingChangedHotelOrderItem(string hotelName, string strCheckin)
    {
        //把需要删除的HotelOrderItem缓存在Session中
        List<string> deleteList = new List<string>();
        deleteList.Add(hotelName);
        deleteList.Add(strCheckin);
        Utility.DeleteHotel = deleteList;
    }

    private void SearchAndBind()
    {
        HotelMerchandise m_SaleMerchandise = (HotelMerchandise)this.OnSearch();

        if (m_SaleMerchandise.Items.Count > 0)
        {
            List<MVHotel> hotelMaterialNew = new List<MVHotel>();

            for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
            {
                hotelMaterialNew.Add((MVHotel)m_SaleMerchandise.Items[i]);
            }

            HotelMaterial = hotelMaterialNew;
        }
        else
        {
            this.Response.Redirect("../../Index.aspx");
        }
    }

    private void FilterHotel(List<MVHotel> hotelMaterials, ref List<MVHotel> hotelMaterialsNew)
    {
        if (Utility.HotelSortRule.Count == 3 && Utility.BackFlag == "1")
        {
            Utility.BackFlag = "0";
            ddlStar.SelectedValue = Utility.HotelSortRule[0];
            txtContains.Text = Utility.HotelSortRule[1];
            ddlSort.SelectedValue = Utility.HotelSortRule[2];
        }

        if (this.ddlStar.SelectedIndex > 0)
        {
            string strStar = this.ddlStar.SelectedValue;

            for (int i = 0; i < hotelMaterials.Count; i++)
            {
                if ( Convert.ToDouble(hotelMaterials[i].HotelInformation.Class) >= Convert.ToDouble(strStar))
                {
                    if (hotelMaterials[i].HotelInformation.Position.LatitudeNoun != null && hotelMaterials[i].HotelInformation.Position.LongitudeNoun != null)
                    {
                        if (hotelMaterials[i].HotelInformation.Position.LatitudeNoun.DecimalCode != "0" && hotelMaterials[i].HotelInformation.Position.LongitudeNoun.DecimalCode != "0")
                        {
                            hotelMaterialsNew.Add(hotelMaterials[i]);
                        }
                    }
                }
            }
        }
        else
        {
            if (hotelMaterialsNew.Count > 0)
            {
                hotelMaterials = hotelMaterialsNew;
                hotelMaterialsNew = new List<MVHotel>();
            }
        }

        if (hotelMaterials.Count != hotelMaterialsNew.Count && hotelMaterialsNew.Count > 0)
        {
            hotelMaterials = new List<MVHotel>();
            MVHotel[] arr = new MVHotel[hotelMaterialsNew.Count];
            hotelMaterialsNew.CopyTo(arr);
            hotelMaterials.AddRange(arr);
            hotelMaterialsNew = new List<MVHotel>();
        }

        if (hotelMaterials.Count == hotelMaterialsNew.Count)
        {
            hotelMaterialsNew = new List<MVHotel>();
        }

        if (this.txtContains.Text.Trim().Length > 0)
        {
            string strContains = txtContains.Text.Trim();

            for (int i = 0; i < hotelMaterials.Count; i++)
            {
                if (hotelMaterials[i].HotelInformation.Name.ToUpper().Contains(strContains.ToUpper()))
                {
                    if (hotelMaterials[i].HotelInformation.Position.LatitudeNoun != null && hotelMaterials[i].HotelInformation.Position.LongitudeNoun != null)
                    {
                        if (hotelMaterials[i].HotelInformation.Position.LatitudeNoun.DecimalCode != "0" && hotelMaterials[i].HotelInformation.Position.LongitudeNoun.DecimalCode != "0")
                        {
                            hotelMaterialsNew.Add(hotelMaterials[i]);
                        }
                    }
                }
            }
        }
        else
        {
            if (hotelMaterialsNew.Count == 0)
            {
                for (int i = 0; i < hotelMaterials.Count; i++)
                {
                    if (hotelMaterials[i].HotelInformation.Position.LatitudeNoun != null && hotelMaterials[i].HotelInformation.Position.LongitudeNoun != null)
                    {
                        if (hotelMaterials[i].HotelInformation.Position.LatitudeNoun.DecimalCode != "0" && hotelMaterials[i].HotelInformation.Position.LongitudeNoun.DecimalCode != "0")
                        {
                            hotelMaterialsNew.Add(hotelMaterials[i]);
                        }
                    }
                }
            }
        }

        if (hotelMaterials.Count != hotelMaterialsNew.Count && hotelMaterialsNew.Count > 0)
        {
            hotelMaterials = new List<MVHotel>();
            MVHotel[] arr = new MVHotel[hotelMaterialsNew.Count];
            hotelMaterialsNew.CopyTo(arr);
            hotelMaterials.AddRange(arr);
            hotelMaterialsNew = new List<MVHotel>();
        }

        if (hotelMaterials.Count == hotelMaterialsNew.Count)
        {
            hotelMaterialsNew = new List<MVHotel>();
        }

        if (ddlArea.SelectedValue == "NO")
        {
            hotelMaterialsNew = hotelMaterials;
        }
        else
        {
            string strCode = ddlArea.SelectedValue;

            for (int i = 0; i < hotelMaterials.Count; i++)
            {
                if (hotelMaterials[i].HotelInformation.AreaInCity.ToUpper().Trim() == strCode.ToUpper().Trim())
                {
                    hotelMaterialsNew.Add(hotelMaterials[i]);
                }
            }
        }

        if (hotelMaterialsNew.Count > 0)
        {
            if (ddlSort.SelectedIndex == 0)
            {
                MagesticPicksSort(ref hotelMaterialsNew);
            }
            if (ddlSort.SelectedIndex == 1)
            {
                hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.RoomPricePerNight.CompareTo(r2.RoomPricePerNight); });
            }
            if (ddlSort.SelectedIndex == 2)
            {
                hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.HotelInformation.Name.CompareTo(r2.HotelInformation.Name); });
            }
            if (ddlSort.SelectedIndex == 3)
            {
                hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.HotelInformation.Class.CompareTo(r2.HotelInformation.Class); });
            }
        }
    }

    private PagedDataSource BindDataList(List<MVHotel> dataSource)
    {
        int iPageIndex;

        PagedDataSource objPds = new PagedDataSource();
        objPds.DataSource = dataSource;
        objPds.AllowPaging = true;
        objPds.PageSize = 14;
        PageNumberControl1.PageSize = 14;

        PageNumberControl1.PageAmount = objPds.PageCount;

        if (objPds.DataSourceCount < 14 + 1)
        {
            PageNumberControl1.Visible = false;
        }
        else
        {
            PageNumberControl1.Visible = true;
            PageNumberControl1.Update();
        }

        //把PagedDataSource 对象赋给Repeater控件 
        return objPds;
    }

    private void BindDataList(List<MVHotel> dataSource, int index)
    {
        PagedDataSource objPds = new PagedDataSource();
        objPds.DataSource = dataSource;
        objPds.AllowPaging = true;
        objPds.PageSize = 14;
        objPds.CurrentPageIndex = index >= 0 ? index : 0;
        PageNumberControl1.PageAmount = objPds.PageCount;

        if (objPds.DataSourceCount < 14 + 1)
        {
            PageNumberControl1.Visible = false;
        }
        else
        {
            PageNumberControl1.Visible = true;
            PageNumberControl1.Update();
        }

        //把PagedDataSource 对象赋给Repeater控件 
        dlHotelInfo.DataSource = objPds;
        dlHotelInfo.DataBind();

        mapName = "";
        mapAreaX = "";
        mapAreaY = "";
        location = "";

        for (int i = 0; i < dlHotelInfo.Items.Count; i++)
        {
            if (i > 0)
            {
                mapName += ",";
                mapAreaX += ",";
                mapAreaY += ",";
                location += "~~~~";
            }
            mapName += "'" + ((Label)dlHotelInfo.Items[i].FindControl("lbHotelName")).Text.Replace(",","") + "'";
            mapAreaX += "'" + ((Label)dlHotelInfo.Items[i].FindControl("lbx")).Text + "'";
            mapAreaY += "'" + ((Label)dlHotelInfo.Items[i].FindControl("lby")).Text + "'";
            string str = "<div class=\"IBE_hotel_hotelMapWidth\"><div class=\"IBE_hotel_map_hotel\"><div class=\"IBE_hotel_map_hotel_img\"><img src=\"" + ((System.Web.UI.WebControls.Image)dlHotelInfo.Items[i].FindControl("imgHotelIMG")).ImageUrl + "\" width=\"65\" height=\"65\" border=\"0\" onerror=\"this.src='http://www.majestic-vacations.com/images/v1/defaulth.gif';\" /></div><div class=\"IBE_hotel_map_hotel_rote\"><ul><li class=\"IBE_hotel_map_hotelName_style\">" + ((Label)dlHotelInfo.Items[i].FindControl("lbHotelName")).Text.Replace("'", " ") + " </li><li class=\"IBE_hotel_map_hotel_link\"><a href=\"DetailForm.aspx?TableName=Photo&HotelID=" + ((Label)dlHotelInfo.Items[i].FindControl("lblHotelID")).Text.Trim() + "&HotelName=" + ((Label)dlHotelInfo.Items[i].FindControl("lbHotelName")).Text.Trim() + "&ConditionID=" + Request.Params["ConditionID"] + "&GTACITYCODE=" + ((Label)dlHotelInfo.Items[i].FindControl("lblGTACityCode")).Text.Trim() + "\">Photos</a> |  <a href=\"DetailForm.aspx?TableName=Features&HotelID=" + ((Label)dlHotelInfo.Items[i].FindControl("lblHotelID")).Text.Trim() + "&HotelName=" + ((Label)dlHotelInfo.Items[i].FindControl("lbHotelName")).Text.Trim() + "&ConditionID=" + Request.Params["ConditionID"] + "&GTACITYCODE=" + ((Label)dlHotelInfo.Items[i].FindControl("lblGTACityCode")).Text.Trim() + "\">Features & Amenities</a></li></ul><div class=\"clear\"></div></div><div class=\"IBE_hotel_map_hotel_btn\"></div></div><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"IBE_hotel_map_hotel_collection\"><tr><td width=\"266\" style=\"border-right:1px solid #ccc;\">" +
                "<br />Address: " + ((Label)dlHotelInfo.Items[i].FindControl("Label3")).Text.Replace("'", " ") + "<br /></td><td align=\"center\">Majestic Special Rate <br /><span class=\"IBE_hotel_map_hotel_price_style1\">$</span><span class=\"IBE_hotel_map_hotel_price_style2\">" + ((Label)dlHotelInfo.Items[i].FindControl("lbTotalPrice")).Text + "</span><br /><span class=\"IBE_hotel_map_hotel_price_style3\">avg per night</span><br /><a href=\"PriceingForm.aspx?HotelID=" + ((Label)dlHotelInfo.Items[i].FindControl("lblHotelID")).Text.Trim() + "&HotelName=" + ((Label)dlHotelInfo.Items[i].FindControl("lbHotelName")).Text.Trim() + "&ConditionID=" + Request.Params["ConditionID"] + "&GTACITYCODE=" + ((Label)dlHotelInfo.Items[i].FindControl("lblGTACityCode")).Text.Trim() + "\" class=\"button_link\"></a></td></tr></table></div>";

            location += "'" + str + "'";
        }

        lbMapName.Text = mapName;
        lbMapAreaX.Text = mapAreaX;
        lbMapAreaY.Text = mapAreaY;
        lblocation.Text = location;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        Header1.Path = "../../";
        if (!IsPostBack)
        {
            if (HotelMaterial == null || HotelMaterial.Count == 0)
            {

            }
            else
            {
                DataTable dttemp = new DataTable();

                dttemp.Columns.Add("Name");
                dttemp.Columns.Add("Code");
                dttemp.Columns.Add("Index");

                for (int i = 0; i < HotelMaterial.Count; i++)
                {
                    if (dttemp.Rows.Count > 0)
                    {
                        bool istrue = false;
                        for (int count = 0; count < dttemp.Rows.Count; count++)
                        {
                            if (dttemp.Rows[count]["Code"].ToString().ToUpper() == (HotelMaterial[i].HotelInformation.AreaInCity.ToUpper()))
                            {
                                dttemp.Rows[count]["Index"] = int.Parse(dttemp.Rows[count]["Index"].ToString()) + 1;
                                istrue = true;
                            }
                        }

                        if (!istrue)
                        {
                            IList areaInCityList = AreaInCityService.GetName(HotelMaterial[i].HotelInformation.AreaInCity);
                            if (areaInCityList != null && areaInCityList.Count > 0)
                            {

                                DataRow drtemp = dttemp.NewRow();
                                drtemp["Name"] = areaInCityList[0].ToString();
                                drtemp["Code"] = HotelMaterial[i].HotelInformation.AreaInCity;
                                drtemp["Index"] = "1";
                                dttemp.Rows.Add(drtemp);

                            }
                        }
                    }
                    else
                    {
                        IList areaInCityList = AreaInCityService.GetName(HotelMaterial[i].HotelInformation.AreaInCity);
                        if (areaInCityList != null && areaInCityList.Count > 0)
                        {

                            DataRow drtemp = dttemp.NewRow();
                            drtemp["Name"] = areaInCityList[0].ToString();
                            drtemp["Code"] = HotelMaterial[i].HotelInformation.AreaInCity;
                            drtemp["Index"] = "1";
                            dttemp.Rows.Add(drtemp);

                        }
                    }
                }

                for (int i = 0; i < dttemp.Rows.Count; i++)
                {
                    dttemp.Rows[i]["Name"] = dttemp.Rows[i]["Name"] + "(" + dttemp.Rows[i]["Index"].ToString() + ")";
                }

                DataView dv = dttemp.DefaultView;

                dv.Sort = "Name";

                ddlArea.DataTextField = "Name";
                ddlArea.DataValueField = "Code";
                ddlArea.DataSource = dv;
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("-- ALL --", "NO"));

                List<MVHotel> hotelMaterialNew = new List<MVHotel>();

                FilterHotel(m_HotelMaterial, ref hotelMaterialNew);

                PagedDataSource objPds = BindDataList(hotelMaterialNew);

            }
        }
        else
        {
            if (HotelMaterial == null || HotelMaterial.Count == 0)
            {

            }
            else
            {
                List<MVHotel> hotelMaterialNew = new List<MVHotel>();

                FilterHotel(m_HotelMaterial, ref hotelMaterialNew);

                BindDataList(hotelMaterialNew);

            }
        }

        this.lblCityName.Text = m_CommonService.FindCityByCityCode(((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).Location).Name;

    }

    private void MagesticPicksSort(ref List<MVHotel> pMVHotel)
    {

        List<MVHotel> hotelOther = new List<MVHotel>();

        for (int i = 0; i < pMVHotel.Count; i++)
        {
            hotelOther.Add(pMVHotel[i]);
        }

        //按价格排序
        hotelOther.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.RoomPricePerNight.CompareTo(r2.RoomPricePerNight); });

        pMVHotel.Clear();

        //先加入有推荐标志的Hotel
        for (int i = 0; i < hotelOther.Count; i++)
        {
            if (hotelOther[i].IsRecommended)
            {
                pMVHotel.Add(hotelOther[i]);
            }
        }
        //后加入没有推荐标志的Hotel
        for (int i = 0; i < hotelOther.Count; i++)
        {
            if (!hotelOther[i].IsRecommended)
            {
                pMVHotel.Add(hotelOther[i]);
            }
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        PageNumberControl1.CurrentPageIndex = 0;
        rePageNumber = true;
        List<MVHotel> hotelMaterialNew = new List<MVHotel>();

        FilterHotel(m_HotelMaterial, ref hotelMaterialNew);
        PagedDataSource objPds = BindDataList(hotelMaterialNew);
        dlHotelInfo.DataSource = objPds;
        dlHotelInfo.DataBind();
    }

    protected void dlHotelInfo_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
             e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //鼠标移动到每项时颜色交替效果
            ((HtmlTable)e.Item.FindControl("Table1")).Attributes.Add("OnMouseOut", "this.style.backgroundColor='';this.style.color='#003399'");
            ((HtmlTable)e.Item.FindControl("Table1")).Attributes.Add("OnMouseOver", "this.style.backgroundColor='#eaeaea';this.style.color='#8C4510'");

            ((Label)e.Item.FindControl("lby")).Style.Add("display", "none");
            ((Label)e.Item.FindControl("lbx")).Style.Add("display", "none");


            string str = "<div class=\"IBE_hotel_hotelMapWidth\"><div class=\"IBE_hotel_map_hotel\"><div class=\"IBE_hotel_map_hotel_img\"><img src=\"" + ((System.Web.UI.WebControls.Image)e.Item.FindControl("imgHotelIMG")).ImageUrl + "\" width=\"65\" height=\"65\" border=\"0\" onerror=\"this.src=&quot;http://www.majestic-vacations.com/images/v1/defaulth.gif&quot;;\" /></div><div class=\"IBE_hotel_map_hotel_rote\"><ul><li class=\"IBE_hotel_map_hotelName_style\">" + ((Label)e.Item.FindControl("lbHotelName")).Text.Replace("'", " ") + " </li><li class=\"IBE_hotel_map_hotel_link\"><a href=\"DetailForm.aspx?TableName=Photo&HotelID=" + ((Label)e.Item.FindControl("lblHotelID")).Text.Trim() + "&HotelName=" + ((Label)e.Item.FindControl("lbHotelName")).Text.Trim() + "&ConditionID=" + Request.Params["ConditionID"] + "&GTACITYCODE=" + ((Label)e.Item.FindControl("lblGTACityCode")).Text.Trim() + "\">Photos</a> |  <a href=\"DetailForm.aspx?TableName=Features&HotelID=" + ((Label)e.Item.FindControl("lblHotelID")).Text.Trim() + "&HotelName=" + ((Label)e.Item.FindControl("lbHotelName")).Text.Trim() + "&ConditionID=" + Request.Params["ConditionID"] + "&GTACITYCODE=" + ((Label)e.Item.FindControl("lblGTACityCode")).Text.Trim() + "\">Features & Amenities</a></li></ul><div class=\"clear\"></div></div><div class=\"IBE_hotel_map_hotel_btn\"></div></div><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"IBE_hotel_map_hotel_collection\"><tr><td width=\"266\" style=\"border-right:1px solid #ccc;\">" +
                "<br />Address: " + ((Label)e.Item.FindControl("Label3")).Text.Replace("'", " ") + "<br /></td><td align=\"center\">Majestic Special Rate <br /><span class=\"IBE_hotel_map_hotel_price_style1\">$</span><span class=\"IBE_hotel_map_hotel_price_style2\">" + ((Label)e.Item.FindControl("lbTotalPrice")).Text + "</span><br /><span class=\"IBE_hotel_map_hotel_price_style3\">avg per night</span><br /><a href=\"PriceingForm.aspx?HotelID=" + ((Label)e.Item.FindControl("lblHotelID")).Text.Trim() + "&HotelName=" + ((Label)e.Item.FindControl("lbHotelName")).Text.Trim() + "&ConditionID=" + Request.Params["ConditionID"] + "&GTACITYCODE=" + ((Label)e.Item.FindControl("lblGTACityCode")).Text.Trim() + "\" class=\"button_link\"></a></td></tr></table></div>";

            //单击 事件
            ((HtmlTable)e.Item.FindControl("temp1")).Attributes.Add("OnClick", "ItemOver(this,'" + str + "','" + ((Label)e.Item.FindControl("lbx")).Text + "','" + ((Label)e.Item.FindControl("lby")).Text + "')");

            //鼠标划过 事件
            ((HtmlTable)e.Item.FindControl("temp1")).Attributes.Add("onMouseover", "ItemOver(this,'" + str + "','" + ((Label)e.Item.FindControl("lbx")).Text + "','" + ((Label)e.Item.FindControl("lby")).Text + "')");


            //设置悬浮鼠标指针形状为"小手"
            ((HtmlTable)e.Item.FindControl("temp1")).Attributes["style"] = "Cursor:pointer";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("SearchResultForm.aspx?ConditionID=" + Request.Params["ConditionID"]);
    }
}


