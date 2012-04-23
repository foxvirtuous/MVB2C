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
using TERMS.Common;

public partial class HTLSelectRoomTypeControl : SalesBaseUserControl
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

    private DateTime _dtcheckin = new DateTime();
    public DateTime _dtCheckIn
    {
        get
        {
            return _dtcheckin;
        }
        set
        {
            _dtcheckin = value;
        }
    }

    private DateTime _dtcheckout = new DateTime();
    public DateTime _dtCheckOut
    {
        get
        {
            return _dtcheckout;
        }
        set
        {
            _dtcheckout = value;
        }
    }

    private int _inight = 0;
    public int _inights
    {
        get
        {
            return _inight;
        }
        set
        {
            _inight = value;
        }
    }

    private List<HowWeek> _howWeek = new List<HowWeek>();

    public List<HowWeek> Wkdays
    {
        get
        {
            return _howWeek;
        }
        set
        {
            _howWeek = value;
        }
    }

    private RoomTypeList _roomCancel;

    public RoomTypeList RoomCancel
    {
        get
        {
            return _roomCancel;
        }
        set
        {
            _roomCancel = value;
        }
    }

    private RoomTypeList _roomDelete;

    public RoomTypeList RoomDelete
    {
        get
        {
            return _roomDelete;
        }
        set
        {
            _roomDelete = value;
        }
    }

    private MVHotel m_HotelMaterial;

    public MVHotel HotelMaterial
    {
        set
        {

            _dtCheckIn = value.Items[0].Profile.CheckInDate;
            _dtCheckOut = value.Items[0].Profile.CheckOutDate;
            _inights = (int)((TimeSpan)value.Items[0].Profile.CheckOutDate.Subtract(value.Items[0].Profile.CheckInDate)).TotalDays;

            dlHotel.DataSource = value.Items;

            dlHotel.DataBind();

            for (int i = 0; i < dlHotel.Items.Count; i++)
            {
                DataList dlRoom = (DataList)dlHotel.Items[i].FindControl("dlRoom");

                for (int j = 0; j < dlRoom.Items.Count; j++)
                {
                    Label lblHotelSTATUS = (Label)dlRoom.Items[j].FindControl("lblHotelSTATUS");
                    if (value.Items[i].Items[j].Profile.GetParam("STATUS") != null && Utility.IsSubAgent)
                    {
                        //lblHotelSTATUS.Text = value.Items[i].Items[j].Profile.GetParam("STATUS").ToString();

                        if (value.Items[i].Items[j].Profile.GetParam("STATUS").ToString() == "IM")
                        {
                            lblHotelSTATUS.Text = "AVAILABLE";
                            lblHotelSTATUS.Font.Bold = true;
                        }
                        else
                        {
                            lblHotelSTATUS.Text = "On Request";
                            lblHotelSTATUS.Font.Bold = false;
                        }
                    }
                    else
                    {
                        lblHotelSTATUS.Visible = false;
                    }

                    _howWeek.Clear();
                    if (_inights < 7)
                    {
                        HowWeek howWeek = new HowWeek();
                        howWeek.Weks = "1";
                        _howWeek.Add(howWeek);

                        for (int z = 0; z < _inights; z++)
                        {
                            WeekPrice _weekPrice = new WeekPrice();
                            Price price = value.Items[i].Items[j].GetAvgPerNightPrice(_dtCheckIn.AddDays(z), _dtCheckIn.AddDays(z + 1));
                            _weekPrice.WPrice = "$" + (price.GetAmount(TERMS.Common.PassengerType.Adult) + price.GetMarkup(TERMS.Common.PassengerType.Adult)).ToString("n");
                            _howWeek[0].WeekPrices.Add(_weekPrice);
                        }

                    }
                    else
                    {
                        int Zcount = _inights / 7;
                        int Ycount = _inights % 7;
                        if (Ycount > 0)
                        {
                            Zcount += 1;
                        }

                        for (int z = 0; z < Zcount; z++)
                        {
                            HowWeek howWeek1 = new HowWeek();
                            howWeek1.Weks = "1";
                            _howWeek.Add(howWeek1);

                            for (int a = 0; a < 7; a++)
                            {
                                if (_dtCheckIn.AddDays((z * 7) + a) < _dtCheckOut)
                                {
                                    WeekPrice _weekPrice3 = new WeekPrice();

                                    Price price2 = value.Items[i].Items[j].GetAvgPerNightPrice(_dtCheckIn.AddDays((z * 7) + a), _dtCheckIn.AddDays((z * 7) + a + 1));
                                    _weekPrice3.WPrice = "$" + (price2.GetAmount(TERMS.Common.PassengerType.Adult) + price2.GetMarkup(TERMS.Common.PassengerType.Adult)).ToString("n");
                                    _howWeek[z].WeekPrices.Add(_weekPrice3);
                                }
                                else
                                {
                                    WeekPrice _weekPrice4 = new WeekPrice();
                                    _weekPrice4.WPrice = "";
                                    _howWeek[z].WeekPrices.Add(_weekPrice4);
                                }
                            }
                        }
                    }

                    Repeater Repeater1 = (Repeater)dlRoom.Items[j].FindControl("Repeater2");

                    Repeater1.DataSource = _howWeek;
                    Repeater1.DataBind();

                    //List<Price> pricepros = value.Items[i].Items[j].GetPrices(value.Items[0].Profile.CheckInDate, value.Items[0].Profile.CheckOutDate);

                    //for (int iii = 0; iii < pricepros.Count; iii++)
                    //{
                    //    ((Label)dlRoom.Items[j].FindControl("lblProPrices")).Text += "$" + (pricepros[iii].GetAmount(TERMS.Common.PassengerType.Adult) + pricepros[iii].GetMarkup(TERMS.Common.PassengerType.Adult)).ToString("n");
                    //}
                }
            }

            lblHotelName.Text = value.HotelInformation.Name;


            decimal decSubtotal = decimal.Zero;

            for (int i = 0; i < dlHotel.Items.Count; i++)
            {
                DataList dl = (DataList)dlHotel.Items[i].FindControl("dlRoom");

                decimal decBasicOfPriceRoom = 0M;

                decimal decRoomPrice = 0M;

                for (int j = 0; j < dl.Items.Count; j++)
                {
                    //选中默认房型
                    DataListItem item = dl.Items[j];
                    RadioButton rbtn = (RadioButton)item.FindControl("rabRoomType");
                    Label lbl = (Label)item.FindControl("lblCode");
                    Label lblRoomId = (Label)item.FindControl("lblRoomID");
                    HtmlTable tab = (HtmlTable)item.FindControl("cell");

                    if (value.Items[i].Items[j].Profile.GetParam("CATEGORYID") != null)
                    {
                        lblRoomId.Text = value.Items[i].Items[j].Profile.GetParam("CATEGORYID").ToString().Trim();
                    }

                    string roomcode = value.Items[i].Items[j].Room.Code;
                    string roomid = lblRoomId.Text.Trim();

                    if (value.Profile.GetParam("DATASOURCE").ToString().Trim().ToUpper() == "GTA")
                    {
                        string mark = string.Empty;
                        if (roomid.Length > 0)
                        {
                            mark = roomcode + roomid;
                        }
                        else
                        {
                            mark = roomcode;
                        }

                        if (RoomCancel.RoomMarkers.Contains(mark))
                        {
                            rbtn.Enabled = false;
                            item.FindControl("divErrorMessage").Visible = true;
                            ((Label)item.FindControl("lblErrorMessage")).Text = "The cancellation deadline for this hotel is too close to booking date, please call our branch office for bookings.";
                        }
                        else if (RoomDelete.RoomMarkers.Contains(mark))
                        {
                            rbtn.Enabled = false;
                            item.FindControl("divErrorMessage").Visible = true;
                            ((Label)item.FindControl("lblErrorMessage")).Text = "Please pay attention to the room is non-refundable. please call our branch office for bookings.";
                        }
                        else
                        {
                            item.FindControl("divErrorMessage").Visible = false;
                        }
                    }

                    if (lbl.Text.Trim().ToUpper() == value.Items[i].DefaultRoomType.Room.Code.Trim().ToUpper())
                    {
                        if (value.Items[i].DefaultRoomType.Profile.GetParam("CATEGORYID") != null)
                        {
                            if (value.Items[i].DefaultRoomType.Profile.GetParam("CATEGORYID").ToString().Trim() == lblRoomId.Text.Trim())
                            {
                                if (rbtn.Enabled)
                                {
                                    rbtn.Checked = true;
                                    tab.BgColor = "#fdf1c1";
                                }                                
                            }
                            else
                            {
                                rbtn.Checked = false;
                                tab.BgColor = "";
                            }
                        }
                        else
                        {
                            if (rbtn.Enabled)
                            {
                                rbtn.Checked = true;
                                tab.BgColor = "#fdf1c1";
                            }
                        }
                    }
                    else
                    {
                        rbtn.Checked = false;
                        tab.BgColor = "";
                    }                   

                    //添加单选房型的事件
                    if (j >= 10)
                    {
                        rbtn.Attributes["onclick"] = "javascript:CancelSelect(this,'HTLSelectRoomTypeControl1$dlHotel$ctl0" + i.ToString() + "$dlRoom$ctl" + j.ToString() + "','HTLSelectRoomTypeControl1_dlHotel_ctl0" + i.ToString() + "_dlRoom_ctl" + j.ToString() + "_cell');";
                    }
                    else
                    {
                        rbtn.Attributes["onclick"] = "javascript:CancelSelect(this,'HTLSelectRoomTypeControl1$dlHotel$ctl0" + i.ToString() + "$dlRoom$ctl0" + j.ToString() + "','HTLSelectRoomTypeControl1_dlHotel_ctl0" + i.ToString() + "_dlRoom_ctl0" + j.ToString() + "_cell');";
                    }                    

                    lbl = (Label)item.FindControl("lblPireType");

                    if (j == 0)
                    {
                        lbl.Visible = true;

                        decBasicOfPriceRoom = value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetAmount(TERMS.Common.PassengerType.Adult);
                        //value.Items[i].Items[j].Room.OfferCode
                        decRoomPrice = decBasicOfPriceRoom + value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetMarkup(TERMS.Common.PassengerType.Adult);

                        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                        {
                            //Hotel产品显示每个房间的单价
                            if (rbtn.Checked)
                            {
                                decSubtotal += decRoomPrice;
                            }
                            lbl.Text = "$" + decRoomPrice.ToString("N2");
                        }
                        else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                        {
                            //Package产品不显示每个房间的单价
                            lbl.Text = "";
                        }
                    }
                    else
                    {
                        decimal temp = value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetAmount(TERMS.Common.PassengerType.Adult);

                        temp += value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetMarkup(TERMS.Common.PassengerType.Adult);
                        
                        if (temp >= 0)
                        {
                            if (rbtn.Checked)
                            {
                                decSubtotal += temp;
                            }
                            
                            lbl.Text = "$" + temp.ToString("N2");
                        }
                        else
                        {
                            if (rbtn.Checked)
                            {   
                                decSubtotal += temp;
                            }
                            lbl.Text = temp.ToString("N2");
                        }

                        lbl.Visible = true;

                    }
                }


                bool isSelectBtn = false;

                for (int j = 0; j < dl.Items.Count; j++)
                {
                    DataListItem item = dl.Items[j];

                    RadioButton rbtn = (RadioButton)item.FindControl("rabRoomType");

                    if (rbtn.Checked)
                    {
                        isSelectBtn = true;
                        break;
                    }
                }

                if (!isSelectBtn)
                {
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem item = dl.Items[j];

                        RadioButton rbtn = (RadioButton)item.FindControl("rabRoomType");
                        Label lbl = (Label)item.FindControl("lblCode");
                        Label lblRoomId = (Label)item.FindControl("lblRoomID");
                        HtmlTable tab = (HtmlTable)item.FindControl("cell");

                        if (rbtn.Enabled)
                        {
                            rbtn.Checked = true;
                            tab.BgColor = "#fdf1c1";

                            if (j >= 10)
                            {
                                rbtn.Attributes["onclick"] = "javascript:CancelSelect(this,'HTLSelectRoomTypeControl1$dlHotel$ctl0" + i.ToString() + "$dlRoom$ctl" + j.ToString() + "','HTLSelectRoomTypeControl1_dlHotel_ctl0" + i.ToString() + "_dlRoom_ctl" + j.ToString() + "_cell');";
                            }
                            else
                            {
                                rbtn.Attributes["onclick"] = "javascript:CancelSelect(this,'HTLSelectRoomTypeControl1$dlHotel$ctl0" + i.ToString() + "$dlRoom$ctl0" + j.ToString() + "','HTLSelectRoomTypeControl1_dlHotel_ctl0" + i.ToString() + "_dlRoom_ctl0" + j.ToString() + "_cell');";
                            }

                            lbl = (Label)item.FindControl("lblPireType");

                            if (j == 0)
                            {
                                lbl.Visible = true;

                                decBasicOfPriceRoom = value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetAmount(TERMS.Common.PassengerType.Adult);

                                decRoomPrice = decBasicOfPriceRoom + value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetMarkup(TERMS.Common.PassengerType.Adult);

                                if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                                {
                                    //Hotel产品显示每个房间的单价
                                    if (rbtn.Checked)
                                    {
                                        decSubtotal += decRoomPrice;
                                    }
                                    lbl.Text = "$" + decRoomPrice.ToString("N2");
                                }
                                else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                                {
                                    //Package产品不显示每个房间的单价
                                    lbl.Text = "";
                                }
                            }
                            else
                            {
                                decimal temp = value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetAmount(TERMS.Common.PassengerType.Adult);

                                temp += value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetMarkup(TERMS.Common.PassengerType.Adult);

                                if (temp >= 0)
                                {
                                    if (rbtn.Checked)
                                    {
                                        decSubtotal += temp;
                                    }

                                    lbl.Text = "$" + temp.ToString("N2");
                                }
                                else
                                {
                                    if (rbtn.Checked)
                                    {
                                        decSubtotal += temp;
                                    }
                                    lbl.Text = temp.ToString("N2");
                                }

                                lbl.Visible = true;

                            }

                            break;
                        }
                    }
                }
            }

            if (decSubtotal > 0)
            {
                lblSubtotal.Text = (decSubtotal * _inight).ToString("N2");
                lblSum.Text = (decSubtotal * _inight).ToString("N2");
            }
            else
            {
                lblSubtotal.Text = (0M).ToString("N2");
                lblSum.Text = (0M).ToString("N2");
                this.Page.FindControl("lblpleaseclick").Visible = false;
                this.Page.FindControl("btnContinue").Visible = false;
            }

            string temp1 = string.Empty;

            if (value.HotelInformation.GetImage("FRONT") != null && value.HotelInformation.GetImage("FRONT").Filename != null)
                imgHotel.ImageUrl = value.HotelInformation.GetImage("FRONT").Filename.Trim();
            else
                imgHotel.ImageUrl = "~/images/v1/defaulth.gif";
            if (value.HotelInformation.Class != null && value.HotelInformation.Class.ToString() != "")
                imgstar3.ImageUrl = "~/images/star" + value.HotelInformation.Class.ToString().Trim() + ".gif";
            lblHotelName.Text = value.HotelInformation.Name;
            lblAddress.Text = value.HotelInformation.Address;
            lblLocation.Text = value.HotelInformation.Description;
            if (string.IsNullOrEmpty(value.HotelInformation.MapUrl))
            {
                imgMapUrl.Visible = false;
            }
            else
            {
                imgMapUrl.Visible = true;
                imgMapUrl.ImageUrl = value.HotelInformation.MapUrl;
            }

            for (int i = 0; i < value.HotelInformation.Features.Count; i++)
            {
                temp1 += "<li>" + value.HotelInformation.Features[i] + "</li>";
            }

            lblList.Text = temp1;

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
    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
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

    public HTLSelectRoomTypeControl()
    {
        this.InitializeControls += new EventHandler(HTLSelectRoomTypeControl_InitializeControls);
    }

    void HTLSelectRoomTypeControl_InitializeControls(object sender, EventArgs e)
    {
        if (this.Request["ReturnUrl"] != null)
        {
            ReturnURL = this.Request["ReturnUrl"];
        }
        HyperLink1.NavigateUrl = SaleWebSuffix + "Page/Hotel2/SearchResultForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"];
                                       
        if (!this.IsPostBack)
        {

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

        }

        if (Utility.IsSubAgent)
        {
            phAgentFlightMarkup.Visible = true;
        }
        else
        {
            phAgentFlightMarkup.Visible = false;
        }
    }

    public void BookPrice()
    {
        string hotelid = this.Request["HotelID"];
        string hotelName = this.Request["HotelName"];
        string strCheckin = this.Request["CheckIn"];
        string GTACITYCODE = this.Request["GTACITYCODE"];

        if (this.lblSubtotal.Text.Trim() == "0.00")
        {
            return;
        }

        //如果有限制Mark最大值的时候 判断输入的markup是否小于最大值
        if (this.priceflag.Value.Trim().ToUpper() == "YES")
        {
            decimal decMarkup = 0M;

            if (decimal.TryParse(this.txtSubagentMarkup.Text.Trim(), out decMarkup))
            {
                decimal decsub = decimal.Parse(lblSubtotal.Text);

                if (decsub * 0.2M < decMarkup)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Max markup should be less than $" + (decsub * 0.2M).ToString("N2") + "');</script>");
                    return;
                }
            }
        }

        bool isSelectRoom = false;

        for (int roomIndex = 0; roomIndex < dlHotel.Items.Count; roomIndex++)
        {
            DataList dlRooms = (DataList)dlHotel.Items[roomIndex].FindControl("dlRoom");

            for (int indexroomscount = 0; indexroomscount < dlRooms.Items.Count; indexroomscount++)
            {
                RadioButton rb = (RadioButton)dlRooms.Items[indexroomscount].FindControl("rabRoomType");

                if (rb.Enabled && rb.Checked)
                {
                    isSelectRoom = true;
                }
            }
        }

        if (!isSelectRoom)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please select the room');</script>");
            return;
        }

        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {

            PackageMerchandise m_SaleMerchandise = (PackageMerchandise)this.OnSearch();
            for (int k = 0; k < ((List<TERMS.Business.Centers.SalesCenter.Hotel>)m_SaleMerchandise.DefaultMerchandise[HotelListIndex + 1]).Count; k++)
            {
                MVHotel mvHotel = (MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)m_SaleMerchandise.DefaultMerchandise[HotelListIndex + 1])[k];
                for (int roomIndex = 0; roomIndex < mvHotel.Items.Count; roomIndex++)
                {
                    MVRoom mvRoom = (MVRoom)mvHotel.Items[roomIndex];
                    DataList dlRooms = (DataList)dlHotel.Items[roomIndex].FindControl("dlRoom");

                    for (int indexroomscount = 0; indexroomscount < dlRooms.Items.Count; indexroomscount++)
                    {
                        RadioButton rb = (RadioButton)dlRooms.Items[indexroomscount].FindControl("rabRoomType");

                        if (rb.Checked)
                        {
                            Label lbltemp = (Label)dlRooms.Items[indexroomscount].FindControl("lblCode");
                            Label lblRoomId = (Label)dlRooms.Items[indexroomscount].FindControl("lblRoomID");

                            for (int iRomms = 0; iRomms < mvRoom.Items.Count; iRomms++)
                            {
                                mvRoom.Items[iRomms].Selected = false;

                                if (lblRoomId.Text.Trim().Length > 0)
                                {
                                    if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                                    {
                                        if (mvRoom.Items[iRomms].Profile.GetParam("CATEGORYID") != null && mvRoom.Items[iRomms].Profile.GetParam("CATEGORYID").ToString().Trim() == lblRoomId.Text.Trim())
                                        {
                                            mvRoom.Items[iRomms].Selected = true;
                                            mvRoom.SetDefaultRoomType(iRomms);
                                        }
                                    }
                                }
                                else
                                {
                                    if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                                    {
                                        mvRoom.Items[iRomms].Selected = true;
                                        mvRoom.SetDefaultRoomType(iRomms);
                                    }
                                }
                            }
                        }
                    }

                }
            }

            this.Response.Redirect("~/Page/UVPackage/PackageSearchResult2dForm.aspx");

        }
        else
        {
            if (Utility.DeleteHotel.Count > 0)
            {
                for (int i = Utility.Transaction.CurrentTransactionObject.Items.Count - 1; i >= 0; i--)
                {
                    HotelOrderItem hotelOrderItem = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                    if ((hotelOrderItem.CheckIn == Convert.ToDateTime(Utility.DeleteHotel[1])) && (hotelOrderItem.Room.Hotel.Name.Trim() == Utility.DeleteHotel[0].Trim()))
                        Utility.Transaction.CurrentTransactionObject.Items.Remove(hotelOrderItem);
                }
            }

            HotelMerchandise m_SaleMerchandise = (HotelMerchandise)this.OnSearch();
            MVHotel currentHotel = null;

            //查找当前修改的Hotel
            for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
            {
                MVHotel hotel = (MVHotel)m_SaleMerchandise.Items[i];

                if (!string.IsNullOrEmpty(hotelid)) //根据HotelID查找当前修改的Hotel
                {
                    if (hotel.HotelInformation.HotelCode.ToString().Trim() == hotelid.Trim())
                    {
                        if (hotel.HotelInformation.City.GTACode.ToString().Trim() == GTACITYCODE.Trim())
                        {
                            currentHotel = hotel;
                            break;
                        }

                        //break;
                    }
                }
                else if (!string.IsNullOrEmpty(hotelName) && !string.IsNullOrEmpty(strCheckin)) //根据HotelName和CheckIn查找当前修改的Hotel
                {
                    if ((hotel.HotelInformation.Name.Trim() == hotelName.Trim()) &&
                        (hotel.Profile.CheckInDate == Convert.ToDateTime(strCheckin)))
                    {
                        currentHotel = hotel;
                        break;
                    }
                }
            }

            if (currentHotel != null)
            {
                hotelid = currentHotel.HotelId.ToString();

                for (int roomIndex = 0; roomIndex < currentHotel.Items.Count; roomIndex++)
                {
                    MVRoom mvRoom = (MVRoom)currentHotel.Items[roomIndex];
                    DataList dlRooms = (DataList)dlHotel.Items[roomIndex].FindControl("dlRoom");

                    for (int indexroomscount = 0; indexroomscount < dlRooms.Items.Count; indexroomscount++)
                    {
                        RadioButton rb = (RadioButton)dlRooms.Items[indexroomscount].FindControl("rabRoomType");

                        if (rb.Checked)
                        {
                            Label lbltemp = (Label)dlRooms.Items[indexroomscount].FindControl("lblCode");
                            Label lblRoomId = (Label)dlRooms.Items[indexroomscount].FindControl("lblRoomID");

                            for (int iRomms = 0; iRomms < mvRoom.Items.Count; iRomms++)
                                if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                                {

                                    if (lblRoomId.Text.Trim().Length > 0)
                                    {
                                        if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                                        {
                                            if (mvRoom.Items[iRomms].Profile.GetParam("CATEGORYID") != null && mvRoom.Items[iRomms].Profile.GetParam("CATEGORYID").ToString().Trim() == lblRoomId.Text.Trim())
                                            {
                                                mvRoom.Items[iRomms].Selected = true;
                                                mvRoom.SetDefaultRoomType(iRomms);
                                                HotelOrderItem hotelOrderItem = new HotelOrderItem(mvRoom.Items[iRomms], mvRoom.Profile);

                                                if (mvRoom.Items[iRomms].Profile.GetParam("GTAORDERPOLICY") != null)
                                                {
                                                    OrderPolicyCollection orderPolicyCollection = (OrderPolicyCollection)mvRoom.Items[iRomms].Profile.GetParam("GTAORDERPOLICY");

                                                    hotelOrderItem.OrderPolicy = orderPolicyCollection;
                                                }
                                                
                                                Utility.Transaction.CurrentTransactionObject.Items.Add(hotelOrderItem);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                                        {
                                            mvRoom.Items[iRomms].Selected = true;
                                            mvRoom.SetDefaultRoomType(iRomms);
                                            HotelOrderItem hotelOrderItem = new HotelOrderItem(mvRoom.Items[iRomms], mvRoom.Profile);

                                            if (mvRoom.Items[iRomms].Profile.GetParam("GTAORDERPOLICY") != null)
                                            {
                                                OrderPolicyCollection orderPolicyCollection = (OrderPolicyCollection)mvRoom.Items[iRomms].Profile.GetParam("GTAORDERPOLICY");

                                                hotelOrderItem.OrderPolicy = orderPolicyCollection;
                                            }

                                            Utility.Transaction.CurrentTransactionObject.Items.Add(hotelOrderItem);
                                        }
                                    }
                                }
                        }
                    }
                }
            }
        }

        if (Utility.IsSubAgent && this.txtSubagentMarkup.Text.Trim().Length > 0)
        {
            decimal decMarkup = 0M;

            if (decimal.TryParse(this.txtSubagentMarkup.Text.Trim(), out decMarkup))
            {
                if (decMarkup > 0)
                {
                    Utility.Transaction.CurrentTransactionObject.SubagentMarkup.SetAmount(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(decMarkup));
                }
            }
        }

        this.Response.Redirect("~/Page/Hotel2/TravelForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
    }

    protected void dlHotel_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    }

    public static int CaculateWeekDay(int y, int m, int d)
    {
        if (m == 1) m = 13;
        if (m == 2) m = 14;
        int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7 + 1;
        return week;
    }

    protected void dlRoom_ItemDataBound(object sender, DataListItemEventArgs e)
    {

    }
}

public class HowWeek
{
    private string _weks;
    public string Weks
    {
        get
        {
            return _weks;
        }
        set
        {
            _weks = value;
        }
    }

    private List<WeekPrice> _weekPrices = new List<WeekPrice>();

    public List<WeekPrice> WeekPrices
    {
        get
        {
            return _weekPrices;
        }
        set
        {
            _weekPrices = value;
        }
    }
}

public class WeekPrice
{
    private string _wPrice;
    public string WPrice
    {
        get
        {
            return _wPrice;
        }
        set
        {
            _wPrice = value;
        }
    }
}
