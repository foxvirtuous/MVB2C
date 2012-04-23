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

public partial class HotelCommonInfoControl : SalesBaseUserControl
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
            //int iPageIndex;
            //string url = Request.RawUrl;

            //if (this.Request["PictureIndex"] != null)
            //{
            //    iPageIndex = Convert.ToInt32(this.Request["PictureIndex"]);
            //    url = Request.RawUrl.Replace("&&PictureIndex=" + Request["PictureIndex"], "");
            //}
            //else
            //    iPageIndex = 1;

            //lblNumber.Text = iPageIndex.ToString();
            //lblSum.Text = value.HotelInformation.Images.Count.ToString();
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

            //url = url.Replace("&TableName=Photo", "");

            //if (iPageIndex > 1)
            //{
            //    hlPre.NavigateUrl = url + "&TableName=Photo" + "&&PictureIndex=" + (iPageIndex - 1).ToString();
            //}

            //if (iPageIndex < value.HotelInformation.Images.Count)
            //{
            //    hlNext.NavigateUrl = url + "&TableName=Photo" + "&&PictureIndex=" + (iPageIndex + 1).ToString();
            //}

            //if (value.HotelInformation.Images.Count > 0)
            //{
            //    if (value.HotelInformation.Images[iPageIndex - 1].Name.Trim().ToLower() != "map")
            //    {
            //        imgRoom.ImageUrl = value.HotelInformation.Images[iPageIndex - 1].Filename.Trim();
            //        lblRoomName.Text = value.HotelInformation.Images[iPageIndex - 1].Name.Trim();
            //    }
            //}

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                lblCheckin.Text = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                lblCheckout.Text = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                lblCheckin.Text = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                lblCheckout.Text = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }


            dlHotel.DataSource = value.Items;

            dlHotel.DataBind();

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

                    if (lbl.Text.Trim().ToUpper() == value.Items[i].DefaultRoomType.Room.Code.Trim().ToUpper())
                    {
                        rbtn.Checked = true;
                    }
                    else
                    {
                        rbtn.Checked = false;
                    }

                    CheckBox ckIsBuy = (CheckBox)item.FindControl("IsBuy");

                    if (value.Items[i].IsBuyBreakfast && value.Items[i].Items[j].Room.Code.Trim().ToUpper() == value.Items[i].DefaultRoomType.Room.Code.Trim().ToUpper())
                    {
                        ckIsBuy.Checked = true;
                    }
                    else
                    {
                        ckIsBuy.Checked = false;
                    }
                
                    //添加单选房型的事件
                    rbtn.Attributes["onclick"] = "javascript:CancelSelect(this,'HotelCommonInfoControl1$dlHotel$ctl0" + i.ToString() + "$dlRoom$ctl0" + j.ToString() + "');";


                    lbl = (Label)item.FindControl("lblPireType");

                    Label lblTemp = (Label)item.FindControl("lblTempAdd");

                    if (j == 0)
                    {
                        lbl.Visible = true;

                        //decBasicOfPriceRoom = value.Items[i].PerNightTotalPrice(value.Items[i].Items[j]);

                        decRoomPrice = value.Items[i].PerNightTotalPrice(value.Items[i].Items[j]);

                        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                        {
                            //Hotel产品显示每个房间的单价
                            lbl.Text = "$" + decRoomPrice.ToString("N2");
                            lblTemp.Text = " per room per night (avg.)";
                        }
                        else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                        {
                            //Package产品不显示每个房间的单价
                            lbl.Text = "";
                            lblTemp.Text = "Includes";
                        }
                    }
                    else
                    {
                        decimal temp = value.Items[i].PerNightTotalPrice(value.Items[i].Items[j]);

                        //temp += value.Items[i].PerNightTotalPrice(value.Items[i].Items[j]);

                        temp = temp - decRoomPrice;

                        if (temp >= 0)
                        {
                            lbl.Text = "+$" + temp.ToString("N2");
                        }
                        else
                        {
                            lbl.Text = "-$" + (-temp).ToString("N2");
                        }

                        lbl.Visible = true;

                        lblTemp.Text = " per room per night (avg.)";
                    }


                    Label lblBreakfast = (Label)item.FindControl("lblBreakfast2");
                    CheckBox chIsbuy = (CheckBox)item.FindControl("IsBuy");

                    if (value.Items[i].Items[j].IncluedBreakfastQuantity == 0 && value.Items[i].RoomBreakfastPrice == decimal.Zero)
                    {
                        lblBreakfast.Text = "Not included breakfast";
                        chIsbuy.Visible = false;
                    }

                    if (value.Items[i].Items[j].IncluedBreakfastQuantity > 0)
                    {
                        if (string.IsNullOrEmpty(value.Items[i].Items[j].Breakfast))
                        {
                            lblBreakfast.Text = "Includes breakfast for " + value.Items[i].Items[j].IncluedBreakfastQuantity.ToString();
                            chIsbuy.Visible = false;
                        }
                        else
                        {
                            lblBreakfast.Text = "Includes " + value.Items[i].Items[j].Breakfast + " for " + value.Items[i].Items[j].IncluedBreakfastQuantity.ToString();
                            chIsbuy.Visible = false;
                        }
                    }

                    if (value.Items[i].Items[j].IncluedBreakfastQuantity == 0 && value.Items[i].RoomBreakfastPrice > decimal.Zero)
                    {
                        if (string.IsNullOrEmpty(value.Items[i].Items[j].Breakfast))
                        {
                            lblBreakfast.Text = "Breakfast $" + value.Items[i].RoomBreakfastPrice.ToString("N2");
                            chIsbuy.Visible = true;
                        }
                        else
                        {
                            lblBreakfast.Text = value.Items[i].Items[j].Breakfast + " $" + value.Items[i].RoomBreakfastPrice.ToString("N2");
                            chIsbuy.Visible = true;
                        }
                    }
                }
            }
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

    public HotelCommonInfoControl()
    {
        this.InitializeControls += new EventHandler(HotelCommonInfoControl_InitializeControls);
    }

    void HotelCommonInfoControl_InitializeControls(object sender, EventArgs e)
    {
        if (this.Request["ReturnUrl"] != null)
        {
            ReturnURL = this.Request["ReturnUrl"];
        }
        if (!IsSearchConditionNull)
        {
            if (!this.IsPostBack)
            {
                List<string> temp = new List<string>();
                temp.Add("天数");

                dlCheckDate.DataSource = temp;
                dlCheckDate.DataBind();
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

                for (int i = 0; i < dlCheckDate.Items.Count; i++)
                {
                    TermsCalendar checkin = (TermsCalendar)dlCheckDate.Items[i].FindControl("txtCheckin");
                    checkin.CDate = strCheckin;
                    TermsCalendar checkout = (TermsCalendar)dlCheckDate.Items[i].FindControl("txtCheckout");
                    checkout.CDate = strCheckout;
                }

                if (Request.QueryString["PictureIndex"] == null)
                    CurrentTab.Value = "Room Types";

                if (Request.QueryString["TableName"] != null)
                    CurrentTab.Value = Request.QueryString["TableName"];
                else
                    CurrentTab.Value = "Room Types";
            }
        }
    }

    private string BindPageList(MVHotel pHotelMaterial)
    {
        string temp = string.Empty;

        lblHotelName.Text = pHotelMaterial.HotelInformation.Name;

        if (pHotelMaterial.HotelInformation.GetImage("FRONT") != null && pHotelMaterial.HotelInformation.GetImage("FRONT").Filename != null)
            imgHotel.ImageUrl = pHotelMaterial.HotelInformation.GetImage("FRONT").Filename.Trim();
        else
            imgHotel.ImageUrl = "~/images/v1/defaulth.gif";

        lblAddress.Text = pHotelMaterial.HotelInformation.Address;
        lblLocation.Text = pHotelMaterial.HotelInformation.Description;
        if (string.IsNullOrEmpty(pHotelMaterial.HotelInformation.MapUrl))
        {
            imgMapUrl.Visible = false;
        }
        else
        {
            imgMapUrl.Visible = true;
            imgMapUrl.ImageUrl = pHotelMaterial.HotelInformation.MapUrl;
        }

        for (int i = 0; i < pHotelMaterial.HotelInformation.Features.Count; i++)
        {
            temp += "<li>" + pHotelMaterial.HotelInformation.Features[i] + "</li>";
        }

        return temp;
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string hotelid = this.Request["HotelID"];
        string hotelName = this.Request["HotelName"];
        string strCheckin = this.Request["CheckIn"];

        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {

            PackageMerchandise m_SaleMerchandise = (PackageMerchandise)this.OnSearch();

            //int index = m_SaleMerchandise.DefaultMerchandise.Length - 1;
            //PackageOrderItem packageOrderItem = null;
            //if (Utility.Transaction.CurrentTransactionObject.Items == null &&Utility.Transaction.CurrentTransactionObject.Items.Count >0)
            //     packageOrderItem =(PackageOrderItem) Utility.Transaction.CurrentTransactionObject.Items[0];
            //else
            //     packageOrderItem = new PackageOrderItem(new PackageProfile("PackageProfile"));

            //int hotelIndex = Convert.ToInt32(((List<int>)PgMerchandise.DefaultIndex[1 + HotelListIndex])[0]);
            //List<PackageMaterial> MVHotelList = PgMerchandise.GetPackageMaterials(1 + HotelListIndex);
            //packageOrderItem.RoomPrice = ((PackageMaterial)MVHotelList[hotelIndex]).RoomPrice;
            //packageOrderItem.Nights = ((PackageMaterial)MVHotelList[hotelIndex]).Nights;
            //packageOrderItem.RoomPricePerNight = ((PackageMaterial)MVHotelList[hotelIndex]).RoomPricePerNight;
            //packageOrderItem.AirPrice = ((PackageMaterial)MVHotelList[hotelIndex]).AirPrice;
            //packageOrderItem.TotalPrice = ((PackageMaterial)MVHotelList[hotelIndex]).TotalPrice;

            //AirOrderItem airOrderItem = new AirOrderItem((AirMaterial)m_SaleMerchandise.DefaultMerchandise[0]);

            //if (packageOrderItem.Items.Count == 0)
            //    packageOrderItem.Add(airOrderItem);
            //else
            //    packageOrderItem.Items[0] = airOrderItem;

            //for (int i = 0; i < index; i++)
            //{

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

                            mvRoom.IsBuyBreakfast = false;

                            for (int iRomms = 0; iRomms < mvRoom.Items.Count; iRomms++)
                            {
                                CheckBox chIsbuy = (CheckBox)dlRooms.Items[indexroomscount].FindControl("IsBuy");

                                if (chIsbuy.Visible)
                                {
                                    if (chIsbuy.Checked)
                                    {
                                        mvRoom.IsBuyBreakfast = true;
                                    }
                                }

                                mvRoom.Items[iRomms].Selected = false;
                                if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                                {
                                    mvRoom.Items[iRomms].Selected = true;
                                    mvRoom.SetDefaultRoomType(iRomms);
                                    //HotelOrderItem hotelOrderItem = new HotelOrderItem(mvRoom.Items[iRomms], mvRoom.Profile);

                                    //packageOrderItem.Add(hotelOrderItem);
                                }
                            }
                        }
                    }

                }
            }


            //Utility.Transaction.CurrentTransactionObject.Items.Clear();
            //Utility.Transaction.CurrentTransactionObject.Items.Add(packageOrderItem);
            //}

            this.Response.Redirect("~/Page/Package/PackageSearchResult2dForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);

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
                        currentHotel = hotel;
                        break;
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
                            CheckBox chIsbuy = (CheckBox)dlRooms.Items[indexroomscount].FindControl("IsBuy");

                            mvRoom.IsBuyBreakfast = false;

                            if (chIsbuy.Visible)
                            {
                                if (chIsbuy.Checked)
                                {
                                    mvRoom.IsBuyBreakfast = true;
                                }
                            }

                            Label lbltemp = (Label)dlRooms.Items[indexroomscount].FindControl("lblCode");

                            for (int iRomms = 0; iRomms < mvRoom.Items.Count; iRomms++)
                            {
                                if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                                {
                                    mvRoom.Items[iRomms].Selected = true;
                                    mvRoom.SetDefaultRoomType(iRomms);
                                    HotelOrderItem hotelOrderItem = new HotelOrderItem(mvRoom.Items[iRomms], mvRoom.Profile);
                                    hotelOrderItem.Aduit = mvRoom.Aduit;
                                    hotelOrderItem.Child = mvRoom.Child;
                                    if (mvRoom.IsBuyBreakfast)
                                    {
                                        hotelOrderItem.SearchPassengersNumber = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[roomIndex].AdultNumber +
                                        ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[roomIndex].ChildNumber;
                                    }
                                    hotelOrderItem.IsBuyBreakfast = mvRoom.IsBuyBreakfast;

                                    Utility.Transaction.CurrentTransactionObject.Items.Add(hotelOrderItem);
                                }
                            }
                        }
                    }
                }
            }
        }

        this.Response.Redirect("~/Page/Hotel/HotelViewForm.aspx?HotelID=" + hotelid + "&ConditionID=" + Request.Params["ConditionID"]);

    }
    protected void imgBackFeature_Click(object sender, ImageClickEventArgs e)
    {
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {
            this.Response.Redirect("PackageSearchResultForm.aspx?HotelIndex=" + HotelListIndex.ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            Utility.BackFlag = "1";
            this.Response.Redirect("HotelSelectForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }
    protected void imgBackLocation_Click(object sender, ImageClickEventArgs e)
    {
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {
            this.Response.Redirect("PackageSearchResultForm.aspx?HotelIndex=" + HotelListIndex.ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            Utility.BackFlag = "1";
            this.Response.Redirect("HotelSelectForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }
    protected void imgBackPhoto_Click(object sender, ImageClickEventArgs e)
    {
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {
            this.Response.Redirect("PackageSearchResultForm.aspx?HotelIndex=" + HotelListIndex.ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            Utility.BackFlag = "1";
            this.Response.Redirect("HotelSelectForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }
    protected void imgBackRoom_Click(object sender, ImageClickEventArgs e)
    {
        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        {
            this.Response.Redirect("PackageSearchResultForm.aspx?HotelIndex=" + HotelListIndex.ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
        else
        {
            Utility.BackFlag = "1";
            this.Response.Redirect("HotelSelectForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
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
}
