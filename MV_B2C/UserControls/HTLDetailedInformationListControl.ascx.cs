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
using Spring.Context.Support;


public partial class HTLDetailedInformationListControl : SalesBaseUserControl
{
    public ICommonService CommonService
    {
        get
        {
            return ContextRegistry.GetContext()["CommonService"] as ICommonService;
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

    public IAreaInCityService AreaInCityService
    {
        get
        {
            return ContextRegistry.GetContext()["AreaInCityService"] as IAreaInCityService;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
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

                dlHotelInfo.DataSource = objPds;
                dlHotelInfo.DataBind();

                #region old
                for (int i = 0; i < dlHotelInfo.Items.Count; i++)
                {
                    Label lblList = (Label)dlHotelInfo.Items[i].FindControl("lblList");
                    Image imgHotel = (Image)dlHotelInfo.Items[i].FindControl("imgHotel");
                    Image imgstar3 = (Image)dlHotelInfo.Items[i].FindControl("imgstar3");
                    Label lblAddress2 = (Label)dlHotelInfo.Items[i].FindControl("lblAddress2");
                    Label lblLocation = (Label)dlHotelInfo.Items[i].FindControl("lblLocation");
                    Image imgMapUrl = (Image)dlHotelInfo.Items[i].FindControl("imgMapUrl");
                    Repeater GridView1 = (Repeater)dlHotelInfo.Items[i].FindControl("GridView1");
                    Image plStayOffe = (Image)this.dlHotelInfo.Items[i].FindControl("imgstayOffer");
                    Image plEssentialInformatio = (Image)this.dlHotelInfo.Items[i].FindControl("imgEssentialInformation");
                    HyperLink hlEssentialInformation = (HyperLink)this.dlHotelInfo.Items[i].FindControl("hlEssentialInformation");
                    HyperLink hlStayOffer = (HyperLink)this.dlHotelInfo.Items[i].FindControl("hlStayOffer");
                    Label lbINTotalPrice = (Label)dlHotelInfo.Items[i].FindControl("lbINTotalPrice");
                    Image imgSpiOff = (Image)this.dlHotelInfo.Items[i].FindControl("imgSpiOff");
                    Image imgstayOffer1 = (Image)this.dlHotelInfo.Items[i].FindControl("imgstayOffer1");
                    if (hotelMaterialNew[i].HotelInformation.Essential != null)
                    {
                        if (hotelMaterialNew[i].HotelInformation.Essential.Length > 0)
                        {
                            plEssentialInformatio.Visible = true;
                            hlEssentialInformation.Visible = true;
                            hlEssentialInformation.NavigateUrl = "~/Page/Hotel2/GTAEssentialInformation.aspx?hotelcode=" + hotelMaterialNew[i].HotelInformation.HotelCode;
                        }
                        else
                        {
                           
                            hlEssentialInformation.Visible = false;
                            plEssentialInformatio.Visible = false;
                        }
                    }
                    else
                    {
                        hlEssentialInformation.Visible = false;
                        plEssentialInformatio.Visible = false;
                    }
                    if (hotelMaterialNew[i].Items[0].Items[0].Room != null)
                    {
                        if ((hotelMaterialNew[i].Items[0].Items[0].Room).HasStayOffer)
                        {
                            plStayOffe.Visible = true;
                            hlStayOffer.Visible = true;
                            imgstayOffer1.Visible = true;
                            hlStayOffer.NavigateUrl = "~/Page/Hotel2/GTAStayOffer.aspx?hotelcode=" + hotelMaterialNew[i].HotelInformation.HotelCode +
                                "&CityCode=" + hotelMaterialNew[i].HotelInformation.City.Code +
                                "&CheckInDate=" + ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) +
                                "&CheckOutDate=" + ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            decimal dltempGTA = hotelMaterialNew[i].CostOfProduction / hotelMaterialNew[i].Nights;// / dataSource[index * 10 + i].Items.Count;
                            lbINTotalPrice.Text = dltempGTA.ToString("N2");
                            lbINTotalPrice.Visible = hotelMaterialNew[i].Items[0].Items[0].Room.HasStayOffer;

                        }
                        else
                        {
                            imgstayOffer1.Visible = false;
                            hlStayOffer.Visible = false;
                            plStayOffe.Visible = false;
                            lbINTotalPrice.Visible = false;
                        }
                    }
                    else
                    {
                        imgstayOffer1.Visible = false;
                        hlStayOffer.Visible = false;
                        plStayOffe.Visible = false;
                        lbINTotalPrice.Visible = false;
                    }

                    if (hotelMaterialNew[i].HotelInformation.Recommended)
                    {
                        imgSpiOff.Visible = true;
                    }
                    else
                    {
                        imgSpiOff.Visible = false;
                    }

                    Label lbHotelName = (Label)dlHotelInfo.Items[i].FindControl("lbHotelName");
                    if (Utility.IsLogin && Utility.IsSubAgent)
                    {
                        if (hotelMaterialNew[i].Profile.GetParam("STATUS").ToString() == "IM")
                        {
                            lbHotelName.Text += " - AVAILABLE";
                        }
                        else
                        {
                            lbHotelName.Text += " - On Request";
                        }
                    }


                    string temp = string.Empty;

                    if (hotelMaterialNew[i].HotelInformation.GetImage("FRONT") != null && hotelMaterialNew[i].HotelInformation.GetImage("FRONT").Filename != null)
                        imgHotel.ImageUrl = hotelMaterialNew[i].HotelInformation.GetImage("FRONT").Filename.Trim();
                    else
                        imgHotel.ImageUrl = "~/images/v1/defaulth.gif";
                    if (hotelMaterialNew[i].HotelInformation.Class != null && hotelMaterialNew[i].HotelInformation.Class.ToString() != "")
                        imgstar3.ImageUrl = "~/images/star" + hotelMaterialNew[i].HotelInformation.Class.ToString().Trim() + ".gif";
                    lblAddress2.Text = hotelMaterialNew[i].HotelInformation.Address;
                    lblLocation.Text = hotelMaterialNew[i].HotelInformation.Description;
                    if (string.IsNullOrEmpty(hotelMaterialNew[i].HotelInformation.MapUrl))
                    {
                        imgMapUrl.Visible = false;
                    }
                    else
                    {
                        imgMapUrl.Visible = true;
                        imgMapUrl.ImageUrl = hotelMaterialNew[i].HotelInformation.MapUrl;
                    }

                    for (int iTEMP = 0; iTEMP < hotelMaterialNew[i].HotelInformation.Features.Count; iTEMP++)
                    {
                        temp += "<li>" + hotelMaterialNew[i].HotelInformation.Features[iTEMP] + "</li>";
                    }


                    lblList.Text = temp;

                    List<TERMS.Common.Image> images = (List<TERMS.Common.Image>)hotelMaterialNew[i].HotelInformation.Images;

                    for (int j = images.Count - 1; j >= 0; j--)
                    {
                        if (images[j].Filename == null || images[j].Filename.Trim().Length <= 0)
                        {
                            images.Remove(images[j]);
                        }
                    }

                    GridView1.DataSource = images;
                    ViewState["ImageList"] = images;
                    GridView1.DataBind();
                }

                #endregion
               
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

        this.lblCityName.Text = CommonService.FindCityByCityCode(((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).Location).Name;

    }

    public HTLDetailedInformationListControl()
    {
        this.InitializeControls += new EventHandler(HTLDetailedInformationListControl_InitializeControls);
        this.PreRender += new EventHandler(HTLDetailedInformationListControl_PreRender);
    }

    void HTLDetailedInformationListControl_PreRender(object sender, EventArgs e)
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

    void HTLDetailedInformationListControl_InitializeControls(object sender, EventArgs e)
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
            hotelSortRule.Add(ddlSort.SelectedValue);

            Utility.HotelSortRule = hotelSortRule;

            Session["HotelID"] = e.Item.FindControl("lblHotelID");
            Session["HTLName"] = e.Item.FindControl("lbHotelName");

            this.Response.Redirect("PriceingForm.aspx?HotelID=" + ((Label)e.Item.FindControl("lblHotelID")).Text.Trim() + "&HotelName=" + ((Label)e.Item.FindControl("lbHotelName")).Text.Trim() + "&ConditionID=" + Request.Params["ConditionID"] + "&GTACITYCODE=" + ((Label)e.Item.FindControl("lblGTACityCode")).Text.Trim());
        }
    }

    public void btnShow_Click(object sender, EventArgs e)
    {
        PageNumberControl1.CurrentPageIndex = 0;
        rePageNumber = true;
        List<MVHotel> hotelMaterialNew = new List<MVHotel>();

        FilterHotel(m_HotelMaterial, ref hotelMaterialNew);
        PagedDataSource objPds = BindDataList(hotelMaterialNew);
        dlHotelInfo.DataSource = objPds;
        dlHotelInfo.DataBind();

        #region old
        for (int i = 0; i < dlHotelInfo.Items.Count; i++)
        {
            Label lblList = (Label)dlHotelInfo.Items[i].FindControl("lblList");
            Image imgHotel = (Image)dlHotelInfo.Items[i].FindControl("imgHotel");
            Image imgstar3 = (Image)dlHotelInfo.Items[i].FindControl("imgstar3");
            Label lblAddress2 = (Label)dlHotelInfo.Items[i].FindControl("lblAddress2");
            Label lblLocation = (Label)dlHotelInfo.Items[i].FindControl("lblLocation");
            Image imgMapUrl = (Image)dlHotelInfo.Items[i].FindControl("imgMapUrl");
            Repeater GridView1 = (Repeater)dlHotelInfo.Items[i].FindControl("GridView1");
            Image plStayOffe = (Image)this.dlHotelInfo.Items[i].FindControl("imgstayOffer");
            Image plEssentialInformatio = (Image)this.dlHotelInfo.Items[i].FindControl("imgEssentialInformation");
            HyperLink hlEssentialInformation = (HyperLink)this.dlHotelInfo.Items[i].FindControl("hlEssentialInformation");
            HyperLink hlStayOffer = (HyperLink)this.dlHotelInfo.Items[i].FindControl("hlStayOffer");
            Label lbINTotalPrice = (Label)dlHotelInfo.Items[i].FindControl("lbINTotalPrice");
            Image imgSpiOff = (Image)this.dlHotelInfo.Items[i].FindControl("imgSpiOff");
            Image imgstayOffer1 = (Image)this.dlHotelInfo.Items[i].FindControl("imgstayOffer1");

            if (hotelMaterialNew[i].HotelInformation.Essential != null)
            {
                if (hotelMaterialNew[i].HotelInformation.Essential.Length > 0)
                {
                    plEssentialInformatio.Visible = true;
                    hlEssentialInformation.Visible = true;
                    hlEssentialInformation.NavigateUrl = "~/Page/Hotel2/GTAEssentialInformation.aspx?hotelcode=" + hotelMaterialNew[i].HotelInformation.HotelCode;
                }
                else
                {
                    hlEssentialInformation.Visible = false;
                    plEssentialInformatio.Visible = false;
                }
            }
            else
            {
                hlEssentialInformation.Visible = false;
                plEssentialInformatio.Visible = false;
            }

            if (hotelMaterialNew[i].Items[0].Items[0].Room != null)
            {
                if ((hotelMaterialNew[i].Items[0].Items[0].Room).HasStayOffer)
                {
                    plStayOffe.Visible = true;
                    hlStayOffer.Visible = true;
                    imgstayOffer1.Visible = true;
                    hlStayOffer.NavigateUrl = "~/Page/Hotel2/GTAStayOffer.aspx?hotelcode=" + hotelMaterialNew[i].HotelInformation.HotelCode +
                        "&CityCode=" + hotelMaterialNew[i].HotelInformation.City.Code +
                        "&CheckInDate=" + ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) +
                        "&CheckOutDate=" + ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    decimal dltempGTA = hotelMaterialNew[i].CostOfProduction / hotelMaterialNew[i].Nights;// / dataSource[index * 10 + i].Items.Count;
                    lbINTotalPrice.Text = dltempGTA.ToString("N2");
                    lbINTotalPrice.Visible = hotelMaterialNew[i].Items[0].Items[0].Room.HasStayOffer;

                }
                else
                {
                    hlStayOffer.Visible = false;
                    plStayOffe.Visible = false;
                    lbINTotalPrice.Visible = false;
                    imgstayOffer1.Visible = false;
                }
            }
            else
            {
                lbINTotalPrice.Visible = false;
                hlStayOffer.Visible = false;
                plStayOffe.Visible = false;
                imgstayOffer1.Visible = false;
            }

            if (hotelMaterialNew[i].HotelInformation.Recommended)
            {
                imgSpiOff.Visible = true;
            }
            else
            {
                imgSpiOff.Visible = false;
            }

            Label lbHotelName = (Label)dlHotelInfo.Items[i].FindControl("lbHotelName");
            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                if (hotelMaterialNew[i].Profile.GetParam("STATUS").ToString() == "IM")
                {
                    lbHotelName.Text += " - AVAILABLE";
                }
                else
                {
                    lbHotelName.Text += " - On Request";
                }
            }


            string temp = string.Empty;

            if (hotelMaterialNew[i].HotelInformation.GetImage("FRONT") != null && hotelMaterialNew[i].HotelInformation.GetImage("FRONT").Filename != null)
                imgHotel.ImageUrl = hotelMaterialNew[i].HotelInformation.GetImage("FRONT").Filename.Trim();
            else
                imgHotel.ImageUrl = "~/images/v1/defaulth.gif";
            if (hotelMaterialNew[i].HotelInformation.Class != null && hotelMaterialNew[i].HotelInformation.Class.ToString() != "")
                imgstar3.ImageUrl = "~/images/star" + hotelMaterialNew[i].HotelInformation.Class.ToString().Trim() + ".gif";
            lblAddress2.Text = hotelMaterialNew[i].HotelInformation.Address;
            lblLocation.Text = hotelMaterialNew[i].HotelInformation.Description;
            if (string.IsNullOrEmpty(hotelMaterialNew[i].HotelInformation.MapUrl))
            {
                imgMapUrl.Visible = false;
            }
            else
            {
                imgMapUrl.Visible = true;
                imgMapUrl.ImageUrl = hotelMaterialNew[i].HotelInformation.MapUrl;
            }

            for (int iTEMP = 0; iTEMP < hotelMaterialNew[i].HotelInformation.Features.Count; iTEMP++)
            {
                temp += "<li>" + hotelMaterialNew[i].HotelInformation.Features[iTEMP] + "</li>";
            }


            lblList.Text = temp;

            List<TERMS.Common.Image> images = (List<TERMS.Common.Image>)hotelMaterialNew[i].HotelInformation.Images;

            for (int j = images.Count - 1; j >= 0; j--)
            {
                if (images[j].Filename == null || images[j].Filename.Trim().Length <= 0)
                {
                    images.Remove(images[j]);
                }
            }

            GridView1.DataSource = images;
            ViewState["ImageList"] = images;
            GridView1.DataBind();
        }

        #endregion
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
                if ( Convert.ToDouble(hotelMaterials[i].HotelInformation.Class) == Convert.ToDouble(strStar))
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

        List<MVHotel> hotelMaterialsNew1 = new List<MVHotel>();

        if (ddlArea.SelectedValue == "NO" || ddlArea.SelectedValue == "")
        {
        }
        else
        {
            string strCode = ddlArea.SelectedValue;

            for (int i = 0; i < hotelMaterialsNew.Count; i++)
            {
                if (hotelMaterialsNew[i].HotelInformation.AreaInCity.ToUpper().Trim() == strCode.ToUpper().Trim())
                {
                    hotelMaterialsNew1.Add(hotelMaterialsNew[i]);
                }
            }
            hotelMaterialsNew = hotelMaterialsNew1; 
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
        objPds.PageSize = 10;
        PageNumberControl1.PageSize = 10;
        PageNumberControl1.PageAmount = objPds.PageCount;

        if (objPds.DataSourceCount < 10 + 1)
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
        objPds.PageSize = 10;
        objPds.CurrentPageIndex = index >= 0 ? index : 0;
        PageNumberControl1.PageAmount = objPds.PageCount;

        if (objPds.DataSourceCount < 10 + 1)
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

        #region old
        for (int i = 0; i < dlHotelInfo.Items.Count; i++)
        {
            Label lblList = (Label)dlHotelInfo.Items[i].FindControl("lblList");
            Image imgHotel = (Image)dlHotelInfo.Items[i].FindControl("imgHotel");
            Image imgstar3 = (Image)dlHotelInfo.Items[i].FindControl("imgstar3");
            Label lblAddress2 = (Label)dlHotelInfo.Items[i].FindControl("lblAddress2");
            Label lblLocation = (Label)dlHotelInfo.Items[i].FindControl("lblLocation");
            Image imgMapUrl = (Image)dlHotelInfo.Items[i].FindControl("imgMapUrl");
            Repeater GridView1 = (Repeater)dlHotelInfo.Items[i].FindControl("GridView1");
            Image plStayOffe = (Image)this.dlHotelInfo.Items[i].FindControl("imgstayOffer");
            Image plEssentialInformatio = (Image)this.dlHotelInfo.Items[i].FindControl("imgEssentialInformation");
            HyperLink hlEssentialInformation = (HyperLink)this.dlHotelInfo.Items[i].FindControl("hlEssentialInformation");
            HyperLink hlStayOffer = (HyperLink)this.dlHotelInfo.Items[i].FindControl("hlStayOffer");
            Label lbINTotalPrice = (Label)dlHotelInfo.Items[i].FindControl("lbINTotalPrice");
            Image imgSpiOff = (Image)this.dlHotelInfo.Items[i].FindControl("imgSpiOff");
            Image imgstayOffer1 = (Image)this.dlHotelInfo.Items[i].FindControl("imgstayOffer1");
                        
            if (dataSource[index * 10 + i].HotelInformation.Essential != null)
            {
                if (dataSource[index * 10 + i].HotelInformation.Essential.Length > 0)
                {
                    plEssentialInformatio.Visible = true;
                    hlEssentialInformation.Visible = true;
                    hlEssentialInformation.NavigateUrl = "~/Page/Hotel2/GTAEssentialInformation.aspx?hotelcode=" + dataSource[index * 10 + i].HotelInformation.HotelCode;
                }
                else
                {
                    hlEssentialInformation.Visible = false;
                    plEssentialInformatio.Visible = false;
                }
            }
            else
            {
                hlEssentialInformation.Visible = false;
                plEssentialInformatio.Visible = false;
            }

            if (dataSource[index * 10 + i].Items[0].Items[0].Room != null)
            {
                if (dataSource[index * 10 + i].Items[0].Items[0].Room.HasStayOffer)
                {
                    plStayOffe.Visible = true;
                    hlStayOffer.Visible = true;
                    imgstayOffer1.Visible = true;
                    hlStayOffer.NavigateUrl = "~/Page/Hotel2/GTAStayOffer.aspx?hotelcode=" + dataSource[index * 10 + i].HotelInformation.HotelCode +
                        "&CityCode=" + dataSource[index * 10 + i].HotelInformation.City.Code +
                        "&CheckInDate=" + ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) +
                        "&CheckOutDate=" + ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    decimal dltempGTA = dataSource[index * 10 + i].CostOfProduction / dataSource[index * 10 + i].Nights;// / dataSource[index * 10 + i].Items.Count;
                    lbINTotalPrice.Text = dltempGTA.ToString("N2");

                    lbINTotalPrice.Visible = dataSource[index * 10 + i].Items[0].Items[0].Room.HasStayOffer;


                }
                else
                {
                    //imgSpiOff.Visible = false;
                    hlStayOffer.Visible = false;
                    plStayOffe.Visible = false;
                    lbINTotalPrice.Visible = false;
                    imgstayOffer1.Visible = false;
                }
            }
            else
            {
                //imgSpiOff.Visible = false;
                hlStayOffer.Visible = false;
                plStayOffe.Visible = false;
                lbINTotalPrice.Visible = false;
                imgstayOffer1.Visible = false;
            }

            if (dataSource[index * 10 + i].HotelInformation.Recommended)
            {
                imgSpiOff.Visible = true;
            }
            else
            {
                imgSpiOff.Visible = false;
            }

            Label lbHotelName = (Label)dlHotelInfo.Items[i].FindControl("lbHotelName");
            if (Utility.IsLogin && Utility.IsSubAgent)
            {
                if (dataSource[index * 10 + i].Profile.GetParam("STATUS").ToString() == "IM")
                {
                    lbHotelName.Text += " - AVAILABLE";
                }
                else
                {
                    lbHotelName.Text += " - On Request";
                }
            }


            string temp = string.Empty;

            if (dataSource[index * 10 + i].HotelInformation.GetImage("FRONT") != null && dataSource[index * 10 + i].HotelInformation.GetImage("FRONT").Filename != null)
                imgHotel.ImageUrl = dataSource[index * 10 + i].HotelInformation.GetImage("FRONT").Filename.Trim();
            else
                imgHotel.ImageUrl = "~/images/v1/defaulth.gif";
            if (dataSource[index * 10 + i].HotelInformation.Class != null && dataSource[index * 10 + i].HotelInformation.Class.ToString() != "")
                imgstar3.ImageUrl = "~/images/star" + dataSource[index * 10 + i].HotelInformation.Class.ToString().Trim() + ".gif";
            lblAddress2.Text = dataSource[index * 10 + i].HotelInformation.Address;
            lblLocation.Text = dataSource[index * 10 + i].HotelInformation.Description;
            if (string.IsNullOrEmpty(dataSource[index * 10 + i].HotelInformation.MapUrl))
            {
                imgMapUrl.Visible = false;
            }
            else
            {
                imgMapUrl.Visible = true;
                imgMapUrl.ImageUrl = dataSource[index * 10 + i].HotelInformation.MapUrl;
            }

            for (int iTEMP = 0; iTEMP < dataSource[index * 10 + i].HotelInformation.Features.Count; iTEMP++)
            {
                temp += "<li>" + dataSource[index * 10 + i].HotelInformation.Features[iTEMP] + "</li>";
            }


            lblList.Text = temp;

            List<TERMS.Common.Image> images = (List<TERMS.Common.Image>)dataSource[index * 10 + i].HotelInformation.Images;

            for (int j = images.Count - 1; j >= 0; j--)
            {
                if (images[j].Filename == null || images[j].Filename.Trim().Length <= 0)
                {
                    images.Remove(images[j]);
                }
            }

            GridView1.DataSource = images;
            ViewState["ImageList"] = images;
            GridView1.DataBind();
        }

        #endregion       
    }

    protected void rbtnSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<MVHotel> hotelMaterialNew = new List<MVHotel>();

        FilterHotel(m_HotelMaterial, ref hotelMaterialNew);

        BindDataList(hotelMaterialNew);
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
            if (hotelOther[i].HotelInformation.Recommended)
            {
                pMVHotel.Add(hotelOther[i]);
            }
        }
        //后加入没有推荐标志的Hotel
        for (int i = 0; i < hotelOther.Count; i++)
        {
            if (!hotelOther[i].HotelInformation.Recommended)
            {
                pMVHotel.Add(hotelOther[i]);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("MapForm.aspx?ConditionID=" + Request.Params["ConditionID"]);
    }
    
}
