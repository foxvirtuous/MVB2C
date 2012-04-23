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

using Spring.Web.UI;
using log4net;

using Terms.Common.Service;
using Terms.Common.Dao;
using Terms.Common.Domain;
using Terms.Material.Domain;
using Terms.Merchandise.Dao;
using Terms.Product.Domain;
using Terms.Sales.Domain;
using Terms.Base.Domain;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;

public partial class HotelDetailedInformationListControl : Spring.Web.UI.UserControl
{
    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    private bool rePageNumber = false;

    private List<MVHotel> m_HotelMaterial;

    public List<MVHotel> HotelMaterial
    {
        set
        {
            if (value is List<MVHotel>)
            {
                List<MVHotel> hotelMaterialNew = new List<MVHotel>();

                m_HotelMaterial = value;

                FilterHotel(m_HotelMaterial, ref hotelMaterialNew);

                BindDataList(hotelMaterialNew);
            }            
        }
        get
        {
            if (m_HotelMaterial == null)
            {
                m_HotelMaterial = new List<MVHotel>();
            }

            return m_HotelMaterial;
        }
    }


    public HotelDetailedInformationListControl()
    {
        this.InitializeControls += new EventHandler(HotelDetailedInformationListControl_InitializeControls);
        this.PreRender += new EventHandler(HotelDetailedInformationListControl_PreRender);
    }

    void HotelDetailedInformationListControl_PreRender(object sender, EventArgs e)
    {
        List<MVHotel> hotelMaterialNew = new List<MVHotel>();

        if (!rePageNumber)
        {
            FilterHotel(m_HotelMaterial, ref hotelMaterialNew);
            BindDataList(hotelMaterialNew, PageNumberControl1.CurrentPageIndex);
            this.PageNumberControl1.DrawingNum();
        }
        else
        {
            FilterHotel(m_HotelMaterial, ref hotelMaterialNew);
            this.PageNumberControl1.DrawingNum();
            BindDataList(hotelMaterialNew, 0);
        }
    }

    void HotelDetailedInformationListControl_InitializeControls(object sender, EventArgs e)
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

    protected void dlHotelInfo_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Trim().ToUpper() == "SELECT".Trim().ToUpper())
        {
            List<string> hotelSortRule = new List<string>();
            hotelSortRule.Add(ddlStar.SelectedValue);
            hotelSortRule.Add(txtContains.Text);
            hotelSortRule.Add(rbtnSort.SelectedValue);

            Utility.HotelSortRule = hotelSortRule;

            Session["HotelID"] = e.Item.FindControl("lblHotelID");

            this.Response.Redirect("HotelDetailedInformationForm.aspx?HotelID=" + ((Label)e.Item.FindControl("lblHotelID")).Text.Trim() + "&ConditionID=" + Request.Params["ConditionID"] + "&GTACITYCODE=" + ((Label)e.Item.FindControl("lblGTACityCode")).Text.Trim());
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        List<MVHotel> hotelMaterialNew = new List<MVHotel>();

        FilterHotel(m_HotelMaterial, ref hotelMaterialNew);
        BindDataList(hotelMaterialNew);
    }

    private void FilterHotel(List<MVHotel> hotelMaterials, ref List<MVHotel> hotelMaterialsNew)
    {
        if (Utility.HotelSortRule.Count == 3 && Utility.BackFlag == "1")
        {
            Utility.BackFlag = "0";
            ddlStar.SelectedValue = Utility.HotelSortRule[0];
            txtContains.Text = Utility.HotelSortRule[1];
            rbtnSort.SelectedValue = Utility.HotelSortRule[2];
        }

        if (this.ddlStar.SelectedIndex > 0)
        {
            string strStar = this.ddlStar.SelectedValue;

            for (int i = 0; i < hotelMaterials.Count; i++)
            {
                if (hotelMaterials[i].HotelInformation.Class == strStar)
                {
                    hotelMaterialsNew.Add(hotelMaterials[i]);
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
            //hotelMaterials.CopyTo(hotelMaterialsNew.ToArray()) ;
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
                    hotelMaterialsNew.Add(hotelMaterials[i]);
                }
            }
        }
        else
        {
            if (hotelMaterialsNew.Count == 0)
            {
                hotelMaterialsNew = hotelMaterials;
            }
        }

        //if (hotelMaterialsNew.Count == 0)
        //{
        //    hotelMaterialsNew = hotelMaterials;
        //}

        if (hotelMaterialsNew.Count > 0)
        {
            if (rbtnSort.SelectedIndex == 0)
            {
                //hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.RoomPrice.CompareTo(r2.RoomPrice); });
                MagesticPicksSort(ref hotelMaterialsNew);
            }
            if (rbtnSort.SelectedIndex == 1)
            {
                hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.RoomPricePerNight.CompareTo(r2.RoomPricePerNight); });
            }
            if (rbtnSort.SelectedIndex == 2)
            {
                hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.HotelInformation.Name.CompareTo(r2.HotelInformation.Name); });
            }
            if (rbtnSort.SelectedIndex == 3)
            {
                hotelMaterialsNew.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.HotelInformation.Class.CompareTo(r2.HotelInformation.Class); });
            }
        }
    }

    private void BindDataList(List<MVHotel> dataSource)
    {
        int iPageIndex;

        PagedDataSource objPds = new PagedDataSource();
        objPds.DataSource = dataSource;
        objPds.AllowPaging = true;
        objPds.PageSize = 10;

        PageNumberControl1.PageSize = 10;

        PageNumberControl1.CurrentPageIndex = objPds.CurrentPageIndex;
        PageNumberControl1.PageAmount = objPds.PageCount;
        PageNumberControl1.ItemAmount = objPds.DataSourceCount;
        if (objPds.DataSourceCount < 10 + 1)
            PageNumberControl1.Visible = false;
        else
            PageNumberControl1.Visible = true;

        //把PagedDataSource 对象赋给Repeater控件 
        dlHotelInfo.DataSource = objPds;
        dlHotelInfo.DataBind();

        for (int i = 0; i < dlHotelInfo.Items.Count; i++)
        {
            Image imgHotelIMG = (Image)dlHotelInfo.Items[i].FindControl("imgHotelIMG");

            imgHotelIMG.Attributes.Add("onerror", "this.src='http://www.majestic-vacations.com/images/v1/defaulth.gif';");
        }

    }

    private void BindDataList(List<MVHotel> dataSource, int index)
    {
        PagedDataSource objPds = new PagedDataSource();
        objPds.DataSource = dataSource;
        objPds.AllowPaging = true;
        objPds.PageSize = 10;
        objPds.CurrentPageIndex = index >= 0 ? index : 0;
        PageNumberControl1.PageSize = 10;

        PageNumberControl1.CurrentPageIndex = objPds.CurrentPageIndex;
        PageNumberControl1.PageAmount = objPds.PageCount;
        PageNumberControl1.ItemAmount = objPds.DataSourceCount;
        if (objPds.DataSourceCount < 10 + 1)
            PageNumberControl1.Visible = false;
        else
            PageNumberControl1.Visible = true;

        //把PagedDataSource 对象赋给Repeater控件 
        dlHotelInfo.DataSource = objPds;
        dlHotelInfo.DataBind();
    }

    protected void rbtnSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<MVHotel> hotelMaterialNew = new List<MVHotel>();

        FilterHotel(m_HotelMaterial, ref hotelMaterialNew);

        BindDataList(hotelMaterialNew);
    }

    private void MagesticPicksSort(ref List<MVHotel> pMVHotel)
    {
        //List<MVHotel> hotelLocal = new List<MVHotel>();

        List<MVHotel> hotelOther = new List<MVHotel>();

        for (int i = 0; i < pMVHotel.Count; i++)
        {
            //if (pMVHotel[i].Source.ToUpper() == "Local".ToUpper())
            //{
            //    hotelLocal.Add(pMVHotel[i]);
            //}
            //else
            //{
                hotelOther.Add(pMVHotel[i]);
            //}
        }

        //hotelLocal.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.RoomPricePerNight.CompareTo(r2.RoomPricePerNight); });
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

        //for (int i = 0; i < hotelLocal.Count; i++)
        //{
        //    if (!hotelLocal[i].IsRecommended)
        //    {
        //        pMVHotel.Add(hotelLocal[i]);
        //    }
        //}

        //for (int i = 0; i < hotelOther.Count; i++)
        //{
        //    pMVHotel.Add(hotelOther[i]);
        //}
    }
}
