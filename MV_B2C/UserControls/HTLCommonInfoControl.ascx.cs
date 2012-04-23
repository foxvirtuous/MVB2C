using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
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
using Terms.Sales.Domain;
using Terms.Base.Domain;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;


public partial class HTLCommonInfoControl : SalesBaseUserControl
{
    private string m_ReturnUrl;
    public string ReturnURL
    {
        get
        {
            return m_ReturnUrl;
        }
        set
        {
            m_ReturnUrl = value;
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
    private MVHotel m_HotelMaterial;

    public MVHotel HotelMaterial
    {
        set
        {
            lblList.Text = BindPageList(value);

            List<TERMS.Common.Image> images = (List<TERMS.Common.Image>)value.HotelInformation.Images;

            for (int i = images.Count - 1; i >= 0; i--)
            {
                if (images[i].Filename == null || images[i].Filename.Trim().Length <= 0)
                {
                    images.Remove(images[i]);
                }
            }

            GridView1.DataSource = images;
            ViewState["ImageList"] = images;
            GridView1.DataBind();
        }
        get
        {
            return m_HotelMaterial;
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

    public Terms.Base.Utility.ProductType ProductType
    {
        get
        {
            return (Terms.Base.Utility.ProductType)ViewState["ProductType"];
        }
        set
        {
            ViewState["ProductType"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public HTLCommonInfoControl()
    {
        this.InitializeControls += new EventHandler(HTLCommonInfoControl_InitializeControls);
    }

    void HTLCommonInfoControl_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (this.Request["ReturnUrl"] != null)
        {
            ReturnURL = this.Request["ReturnUrl"];
        }
        if (!this.IsPostBack)
        {
            //List<string> temp = new List<string>();
            //temp.Add("ÌìÊý");

            //dlCheckDate.DataSource = temp;
            //dlCheckDate.DataBind();
            string strCheckin;
            string strCheckout;
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                strCheckin = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                strCheckout = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                strCheckin = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                strCheckout = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }

            //for (int i = 0; i < dlCheckDate.Items.Count; i++)
            //{
            //    TermsCalendar checkin = (TermsCalendar)dlCheckDate.Items[i].FindControl("txtCheckin");
            //    checkin.CDate = strCheckin;
            //    TermsCalendar checkout = (TermsCalendar)dlCheckDate.Items[i].FindControl("txtCheckout");
            //    checkout.CDate = strCheckout;
            //}

            if (Request.QueryString["PictureIndex"] == null)
                CurrentTab.Value = "Room Types";

            if (Request.QueryString["TableName"] != null)
                CurrentTab.Value = Request.QueryString["TableName"];
            else
                CurrentTab.Value = "Room Types";
        }
    }


    private string BindPageList(MVHotel pHotelMaterial)
    {
        string temp = string.Empty;

        if (pHotelMaterial.HotelInformation.GetImage("FRONT") != null && pHotelMaterial.HotelInformation.GetImage("FRONT").Filename != null)
            imgHotel.ImageUrl = pHotelMaterial.HotelInformation.GetImage("FRONT").Filename.Trim();
        else
            imgHotel.ImageUrl = "~/images/v1/defaulth.gif";
        if (pHotelMaterial.HotelInformation.Class != null && pHotelMaterial.HotelInformation.Class.ToString() != "")
            imgstar3.ImageUrl = "~/images/star" + pHotelMaterial.HotelInformation.Class.ToString().Trim() + ".gif";
        lblHotelName.Text = pHotelMaterial.HotelInformation.Name;
        lblAddress.Text = pHotelMaterial.HotelInformation.Address;
        //lblLocation.Text = pHotelMaterial.HotelInformation.Description;
        //if (string.IsNullOrEmpty(pHotelMaterial.HotelInformation.MapUrl))
        //{
        //    imgMapUrl.Visible = false;
        //}
        //else
        //{
        //    imgMapUrl.Visible = true;
        //    imgMapUrl.ImageUrl = pHotelMaterial.HotelInformation.MapUrl;
        //}

        for (int i = 0; i < pHotelMaterial.HotelInformation.Features.Count; i++)
        {
            temp += "<li>" + pHotelMaterial.HotelInformation.Features[i] + "</li>";
        }

        return temp;
    }
    protected void imgBackLocation_Click(object sender, ImageClickEventArgs e)
    {
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {
            this.Response.Redirect("SearchResultForm.aspx?HotelIndex=" + HotelListIndex.ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            Utility.BackFlag = "1";
            this.Response.Redirect("SearchResultForm.aspx");
        }
    }
    protected void imgBackPhoto_Click(object sender, ImageClickEventArgs e)
    {
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {
            this.Response.Redirect("SearchResultForm.aspx?HotelIndex=" + HotelListIndex.ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            Utility.BackFlag = "1";
            this.Response.Redirect("SearchResultForm.aspx");
        }
    }
    protected void imgBackRoom_Click(object sender, ImageClickEventArgs e)
    {
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {
            this.Response.Redirect("SearchResultForm.aspx?HotelIndex=" + HotelListIndex.ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            Utility.BackFlag = "1";
            this.Response.Redirect("SearchResultForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int index = e.NewPageIndex;

        GridView1.DataSource = ViewState["ImageList"];
        GridView1.PageIndex = index;
        GridView1.DataBind();
    }
    protected void imgBackFeature_Click(object sender, EventArgs e)
    {
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {
            this.Response.Redirect("SearchResultForm.aspx?HotelIndex=" + HotelListIndex.ToString() + "&HotelName=" + this.Request["HotelName"].ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            Utility.BackFlag = "1";
            this.Response.Redirect("SearchResultForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }
    protected void ibtnSearch_Click(object sender, EventArgs e)
    {
        string hotelid = this.Request["HotelID"];

        this.Response.Redirect("~/Page/Hotel2/PriceingForm.aspx?HotelID=" + hotelid + "&HotelName=" + this.Request["HotelName"].ToString() + "&ConditionID=" + Request.Params["ConditionID"] + "&GTACITYCODE=" + Request.Params["GTACITYCODE"]);

    }
}