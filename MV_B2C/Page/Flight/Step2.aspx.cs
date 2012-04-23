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
using System.Globalization;

using Terms.Material.Service;
using Terms.Global.Utility;
using Terms.Base.Utility;


using Terms.Sales.Domain;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Core.Profiles;
using TERMS.Business.Centers.ProductCenter.Profiles;


public partial class Step2 : AirBook.Base.BookingPage
{
    private bool rePageNumber = false;

    //private AirService m_airService;

    //protected AirService AirService
    //{
    //    get
    //    {
    //        return m_airService;
    //    }
    //    set
    //    {
    //        m_airService = value;
    //    }
    //}

    protected AirMerchandise FlightMerchandise
    {
        get
        {
            return (AirMerchandise)this.OnSearch();
        }
    }

    public string ContactUsOnClick
    {
        get
        {
            string contactUsOnClick = "lpButtonCTTUrl = 'http://server.iad.liveperson.net/hc/52394737/?cmd=file&file=visitorWantsToChat&site=52394737&SESSIONVAR!skill=MV-General&imageUrl=http://www.majestic-vacations.com/images/livechat&referrer='+escape(document.location); lpButtonCTTUrl = (typeof(lpAppendVisitorCookies) != 'undefined' ? lpAppendVisitorCookies(lpButtonCTTUrl) : lpButtonCTTUrl); window.open(lpButtonCTTUrl,'chat52394737','width=475,height=400,resizable=yes');return false;";
            return contactUsOnClick;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        Master.StepNumber = 2;
        Master.IsShowBookingManage = false;
        Master.IsShowModifySearch = true;
        if (SessionExpired)
            Err("The search condition has been removed from cache, please re-search.", "", "Step3_bulk.aspx");
        else
        {
            if (!Page.IsPostBack)
            {
                Initial(true);
            }
        }
    }

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }


    private void InitializeComponent()
    {
        this.PreRender += new System.EventHandler(this.Step2_PreRender);
    }

    private const int FIRST_PAGE_LEN = 20;
    private const int MIN_BULK_LEN = 3;

    #region User define event

    /// <summary>
    /// Init page
    /// </summary>
    private void Initial(bool isMore)
    {
        bool bclException = false;
        string strMessage = string.Empty;
        try
        {
            //add by cjc, at 2008-9-9, 如果没有Air的Search结果，应该提示客人No Flight
            List<TERMS.Core.Product.Component> flightResult = FlightMerchandise.Items;
            
            if(flightResult == null || flightResult.Count == 0)
                Err("", "No Flight", "Step2.aspx");

            ItineraryInfo.Itinerary = CurrentSession.CurrentItinerary;
            ReorganizeReulst();
            InitPageNumber(0);
        }
        catch (Exception ex)
        {
            log.Error(ex.Message, ex);
            bclException = true;
            strMessage = ex.Message;
        }

        if (bclException)
            Err(strMessage, "Unknow Error", "Step2.aspx");
    }
    /// <summary>
    /// Init the Page number
    /// </summary>
    /// <param name="index"></param>
    private PagedDataSource InitPageNumber(int index)
    {
        PagedDataSource pds = new PagedDataSource();
        AirMerchandise componentGroup = FlightMerchandise;

        ////在没有完全屏蔽各大航空公司的非Pub机票以前，不能显示这些机票
        //for (int i = FlightMerchandise.Items.Count - 1; i >= 0; i--)
        //{ 
        //    AirMerchandise merchandise = (AirMerchandise)FlightMerchandise.Items[i];

        //    if (!merchandise.Profile.GetParam("FARE_TYPE").Equals(Terms.Product.Utility.FlightFareType.PUB.ToString()))
        //    {
        //        string strAirLineCode = ((AirProfile)merchandise.Profile).Airlines[0].Code.Trim().ToString();
        //        //获得配置文件并转换为DataSet
        //        System.Data.DataSet dsAirLineConfig = PageUtility.GetReciever();
        //        //判断配置数据是否存在
        //        if (dsAirLineConfig.Tables.Count > 0 && dsAirLineConfig.Tables[0] != null && dsAirLineConfig.Tables[0].Rows.Count == 1)
        //        {
        //            //判断当前Code是否存在于配置数据中
        //            if (dsAirLineConfig.Tables[0].Columns.Contains(strAirLineCode.ToUpper().Trim()))
        //            {
        //                FlightMerchandise.Items.RemoveAt(i);
        //            }
        //        }
        //    }
        //}
        pds.DataSource = componentGroup.Items;

        //pds.PageSize            = FIRST_PAGE_LEN;//PageNumber1.PageSize;
        pds.PageSize = FIRST_PAGE_LEN;//PageNumber1.PageSize;
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
        //PagedDataSource pds = new PagedDataSource();
        //AirMerchandise componentGroup = FlightMerchandise;


        //pds.DataSource = componentGroup.Items;
        //pds.PageSize = FIRST_PAGE_LEN;//PageNumber1.PageSize;
        //pds.AllowPaging = true;
        //pds.CurrentPageIndex = index >= 0 ? index : 0;
        ////((AirProfile) componentGroup.Profile).BookingClasses;


        ////((PriceList)componentGroup.Prices[componentGroup.Prices.Keys[0]]).Prices[((PriceList)componentGroup.Prices[componentGroup.Prices.Keys[0]]).Prices.Keys[0]].GetAmoutByPaxType(TERMS.Common.PassengerType.Adult);
        //PageNumber1.PageAmount = pds.PageCount;

        //if (pds.DataSourceCount < FIRST_PAGE_LEN + 1)
        //    PageNumber1.Visible = false;
        //else
        //    PageNumber1.Visible = true;


        dlAirFare.DataSource = InitPageNumber(index);
        dlAirFare.DataBind();
    }
    /// <summary>
    /// 重新组织结果，保证前十条内有3条AVAILABLE
    /// </summary>
    private void ReorganizeReulst()
    {

        AirMerchandise result = FlightMerchandise;

        if (result.Items == null) return; //add by cjc, 2008-9-9

        int len = result.Items.Count;
        ArrayList bulkIdx = new ArrayList();

        //找到前3条Bulk
        for (int i = 0; i < len; i++)
        {
            AirMerchandise tGoup = (AirMerchandise)result.Items[i];

            if (tGoup.Profile.GetParam("FARE_TYPE").ToString().Equals(Terms.Product.Utility.FlightFareType.SR.ToString()) || tGoup.Profile.GetParam("FARE_TYPE").ToString().Equals(Terms.Product.Utility.FlightFareType.PUB.ToString()))
            {
                bulkIdx.Add(i);
            }

            if (bulkIdx.Count == MIN_BULK_LEN)
            {
                //找到前三条
                break;
            }
        }

        //判断是否需要插入
        int bulkLen = bulkIdx.Count;
        for (int i = 0; i < bulkLen; i++)
        {
            int idx = (int)bulkIdx[i];
            //idx + len - i - 10 为需要上移数
            int step = idx + bulkLen - i - FIRST_PAGE_LEN;
            if (step > 0)
            {
                int newIdx = idx - step;
                //移动
                TERMS.Core.Product.Component obj = result.Items[idx];
                for (int j = idx; j > newIdx; j--)
                {
                    result.Items[j] = result.Items[j - 1];
                }
                result.Items[newIdx] = obj;
            }
        }
    }
    #endregion



    protected void dlAirFare_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        int index = e.Item.ItemIndex + PageNumber1.PageSize * PageNumber1.CurrentPageIndex;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
        {
            //Label lbl_FareType = (Label)e.Item.FindControl("lbl_FareType");
            ImageButton btnSel = (ImageButton)e.Item.FindControl("btnSelect");
            ImageButton btnAvail = (ImageButton)e.Item.FindControl("btnAvail");
            ImageButton lblNotAvail = (ImageButton)e.Item.FindControl("lblNotAvail");
            ImageButton btnContactAgt = (ImageButton)e.Item.FindControl("btnContactAgt");

            btnContactAgt.OnClientClick = ContactUsOnClick;

            Label tr = (Label)e.Item.FindControl("Mytr");
            Label lbl_FareType = (Label)e.Item.FindControl("lbl_FareType");
            AirMerchandise merchandise = (AirMerchandise)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("AirImgRtn");
            image.ImageUrl = "~/images/airline/defult_air.jpg";
            string airImgName = ((AirProfile)merchandise.Profile).Airlines[0].Code.Trim().ToString() + ".gif";

            if (System.IO.File.Exists(Request.PhysicalApplicationPath + @"images\airline\" + airImgName))
            {
                image.ImageUrl = "~/images/airline/" + airImgName;
            }

            //判断机票是否是PUB机票
            if (!merchandise.Profile.GetParam("FARE_TYPE").Equals(Terms.Product.Utility.FlightFareType.PUB.ToString()))
            {
                //获得AirLineName显示所使用的Label控件
                Label lblAirLineName = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbl_Airline");
                //获得所绑定行的数据源中的AirLineCode
                string strAirLineCode = ((AirProfile)merchandise.Profile).Airlines[0].Code.Trim().ToString();
                //获得配置文件并转换为DataSet
                System.Data.DataSet dsAirLineConfig = PageUtility.GetReciever();
                //判断配置数据是否存在
                if (dsAirLineConfig.Tables.Count > 0 && dsAirLineConfig.Tables[0] != null && dsAirLineConfig.Tables[0].Rows.Count == 1)
                {
                    //判断当前Code是否存在于配置数据中
                    if (dsAirLineConfig.Tables[0].Columns.Contains(strAirLineCode.ToUpper().Trim()))
                    {
                        //Code存在 按规则替换 名称与图片
                        lblAirLineName.Text = dsAirLineConfig.Tables[0].Rows[0][strAirLineCode.ToUpper().Trim()].ToString();
                        image.ImageUrl = "~/images/airline/defult_air.jpg";
                    }
                }
            }

            if (e.Item.ItemIndex % 2 == 0)
                tr.Text = "<tr align=\"center\"  class =\"R_stepw\">";
            else
                tr.Text = "<tr align=\"center\"  class =\"R_stepg\">";
            AirMerchandise tGoup = (AirMerchandise)e.Item.DataItem;

            if (tGoup.Profile.GetParam("FARE_TYPE").Equals(Terms.Product.Utility.FlightFareType.SR.ToString()) || tGoup.Profile.GetParam("FARE_TYPE").Equals(Terms.Product.Utility.FlightFareType.PUB.ToString()))
            {
                btnSel.Visible = false;
                btnAvail.Visible = true;
                btnContactAgt.Visible = false;
                //lbl_FareType.Text = "Bulk";
            }
            else
            {
                AirMerchandise airMerchandise = (AirMerchandise)FlightMerchandise.Items[index];

                if ((bool)tGoup.Profile.GetParam("SHOULD_CALL"))
                { 
                    //如果Should_Call标志为True，则使用Contact Agt图标代替Select
                    btnSel.Visible = false;
                    btnAvail.Visible = false;
                    lblNotAvail.Enabled = false;
                    btnContactAgt.Visible = true;
                }
                else if (airMerchandise.Items != null && airMerchandise.Items.Count != 0)
                {
                    if (airMerchandise.Profile.GetParam("ERR_MESSAGE") == null)
                    {
                        btnSel.Visible = false;
                        btnAvail.Visible = true;
                        btnAvail.CommandName = "BeAvail";
                        btnContactAgt.Visible = false;
                    }
                    else
                    {   //lblNotAvail.Visible = true;
                        ////lblNotAvail.Text = "Unavailable";
                        //lblNotAvail.Enabled = true;
                        //Panel p = (Panel)e.Item.FindControl("PopupMenu");
                        //Label lbl_ErrorMessage = (Label)e.Item.FindControl("lbl_ErrorMessage");
                        //lbl_ErrorMessage.Text = airMerchandise.Profile.GetParam("ERR_MESSAGE").ToString();
                        //p.Visible = true;

                        btnSel.Visible = false;
                        btnAvail.Visible = false;
                        lblNotAvail.Enabled = false;
                        btnContactAgt.Visible = true;
                    }
                }
                else
                {
                    if (airMerchandise.Profile.GetParam("ERR_MESSAGE") != null)
                    {
                        //lblNotAvail.Visible = true;
                        ////lblNotAvail.Text = "Unavailable";
                        //lblNotAvail.Enabled = true;
                        //btnContactAgt.Visible = false;
                        //Panel p = (Panel)e.Item.FindControl("PopupMenu");
                        //Label lbl_ErrorMessage = (Label)e.Item.FindControl("lbl_ErrorMessage");
                        //lbl_ErrorMessage.Text = airMerchandise.Profile.GetParam("ERR_MESSAGE").ToString();
                        //p.Visible = true;

                        btnSel.Visible = false;
                        btnAvail.Visible = false;
                        lblNotAvail.Enabled = false;
                        btnContactAgt.Visible = true;
                    }
                }
               
            }
            //lbl_FareType.Text = tGoup.Profile.GetParam("FARE_TYPE").ToString();
        }
    }
    protected void dlAirFare_ItemCommand(object sender, DataListCommandEventArgs e)
    {
        int index = e.Item.ItemIndex + PageNumber1.PageSize * PageNumber1.CurrentPageIndex;
        if (SessionExpired)
            Err("The search condition has been removed from cache, please re-search.", "", "Step2.aspx");
        else
        {
            if (e.CommandName == "Select")
            {
                OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SelectAir, this);
                System.Threading.Thread.Sleep(2000);
                ImageButton btnSel = (ImageButton)e.Item.FindControl("btnSelect");
                btnSel.Visible = false;


                //currentGroup 只为了触发一次事件
                IList<TERMS.Core.Product.Component> currentGroup = ((TERMS.Core.Product.ComponentGroup)FlightMerchandise.AirProduct.Items[index]).ItemGetter.Get();



                for (int i = 0; i < FlightMerchandise.AirProduct.Items.Count; i++)
                {
                    TERMS.Core.Product.ComponentGroup componentGroup = (TERMS.Core.Product.ComponentGroup)FlightMerchandise.AirProduct.Items[i];
                    if (componentGroup.Profile.GetParam("VISITTED") == null && componentGroup.ItemGetter != null && componentGroup.ItemGetter.GetStatus() == ComponentGetterStatus.HasGot)
                    {
                        AirMerchandise airMerchandise = null;

                        try
                        {
                            //未访问过 && 有getter(SR,PUB没有) && getter已取过数据
                            airMerchandise = (AirMerchandise)FlightMerchandise.Items[i];

                            if (componentGroup.Items != null && componentGroup.Items.Count > 0)
                            {

                                IList<TERMS.Core.Product.Component> group = componentGroup.Items;
                                foreach (TERMS.Core.Product.ComponentGroup cGroup in group)
                                {
                                    if (cGroup.Items != null && cGroup.Items.Count > 0)
                                    {
                                        foreach (AirMaterial airMaterial in cGroup.Items)
                                        {
                                            airMerchandise.Add(airMaterial);
                                        }
                                    }
                                }

                            }
                            else
                            {
                                //Unvailable
                            }
                        }
                        catch
                        { 
                            //防止服务器负担重时出现超时错误
                            airMerchandise = null;
                        }


                        bool isAvailable = true;
                        string errMessage = string.Empty;

                        if (airMerchandise == null || airMerchandise.Items == null || airMerchandise.Items.Count == 0)
                        {
                            isAvailable = false;
                            errMessage = "No Available Flight";
                        }

                        if (isAvailable)
                        {
                            //ImageButton btnAvail = (ImageButton)e.Item.FindControl("btnAvail");
                            //btnAvail.Visible = true;
                            //btnAvail.CommandName = "BeAvail";
                        }
                        else
                        {
                            //ImageButton lblNotAvail = (ImageButton)e.Item.FindControl("lblNotAvail");
                            //lblNotAvail.Visible = true;
                            //btnSel.Visible = false;
                            //lblNotAvail.Enabled = true;
                            //Panel p = (Panel)e.Item.FindControl("PopupMenu");
                            //Label lbl_ErrorMessage = (Label)e.Item.FindControl("lbl_ErrorMessage");
                            //lbl_ErrorMessage.Text = errMessage;
                            airMerchandise.Profile.SetParam("ERR_MESSAGE", errMessage);
                            //p.Visible = true;

                        }
                        componentGroup.Profile.SetParam("VISITTED",true); //设置为已访问


                    }
                }

                //TERMS.Business.Centers.ProductCenter.Profiles.AirProfile profile = (TERMS.Business.Centers.ProductCenter.Profiles.AirProfile)airMerchandise.Profile;
                //foreach (TERMS.Core.Product.ComponentGroup componentGroup in group)
                //{
                //    if (componentGroup.Items != null && componentGroup.Items.Count > 0)
                //    {
                //        foreach (AirMaterial airMaterial in componentGroup.Items)
                //        {
                //            airMerchandise.Add(airMaterial);
                //        }
                //    }
                //}

               
                runFlag.Value = "0";
            }
            else if (e.CommandName == "Avail")
            {
                OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.ClickAvalibale, this);
                CurrentSession.OriginalIndex = index;
                Response.Redirect("Step3_bulk.aspx");
            }
            else
            {
                CurrentSession.OriginalIndex = index;
                Response.Redirect("Step3_bulk.aspx");

            }
        }
    }



    /// <summary>
    /// PreRender Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Step2_PreRender(object sender, EventArgs e)
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


    /// <summary>
    /// Control the compnent Regarding to the diff situation(CALL GTT) 
    /// </summary>
    /// <param name="e"></param>
    /// <param name="errMessage"></param>
    /// <param name="index"></param>
    private void DoCallGTTCompnent(DataListCommandEventArgs e, int index, Profile profile)
    {
        ImageButton btn_Sel = (ImageButton)e.Item.FindControl("btnSelect");
        btn_Sel.Visible = false;

        ImageButton lblNotAvail = (ImageButton)e.Item.FindControl("lblNotAvail");
        lblNotAvail.Visible = true;
        //lblNotAvail.Text = "CALL";
        lblNotAvail.Enabled = true;

        Panel p = (Panel)e.Item.FindControl("PopupMenu");
        Label lbl_ErrorMessage = (Label)e.Item.FindControl("lbl_ErrorMessage");
        lbl_ErrorMessage.Text = "PLEASE CALL MAJESTIC VACATIONS FOR DETAIL";
        profile.SetParam("ERR_MESSAGE", lbl_ErrorMessage.Text);

        p.Visible = true;
        runFlag.Value = "0";
    }
}