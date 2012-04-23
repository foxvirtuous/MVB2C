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
using Terms.Merchandise.Dao;
using Terms.Product.Domain;
using Terms.Sales.Domain;

using Terms.Base.Domain;
using Terms.Sales.Business;

public partial class HotelCommonInfo : SalesBaseUserControl
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

    private MVHotel m_HotelMaterial;

    public MVHotel HotelMaterial
    {
        set
        {
            int iPageIndex;

            if (this.Request["PictureIndex"] != null)
                iPageIndex = Convert.ToInt32(this.Request["PictureIndex"]);
            else
                iPageIndex = 1;

            lblNumber.Text = iPageIndex.ToString();
            lblSum.Text = value.HotelInformation.Images.Count.ToString();
            lblList.Text = BindPageList(value);
            if (iPageIndex > 1)
            {
                hlPre.NavigateUrl = Request.RawUrl  + "&&PictureIndex=" + (iPageIndex - 1).ToString();
            }

            if (iPageIndex < value.HotelInformation.Images.Count)
            {
                hlNext.NavigateUrl = Request.RawUrl + "&&PictureIndex=" + (iPageIndex + 1).ToString();
            }

            if (value.HotelInformation.Images.Count > 0)
            {
                imgRoom.ImageUrl = value.HotelInformation.Images[iPageIndex - 1].Filename;

                lblRoomName.Text = value.HotelInformation.Images[iPageIndex - 1].Name;
            }

            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                lblCheckin.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                lblCheckout.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                lblCheckin.Text = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                lblCheckout.Text = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }

            dlHotel.DataSource = value.Items;

            dlHotel.DataBind();

            for (int i = 0; i < dlHotel.Items.Count; i++)
            {
                DataList dl = (DataList)dlHotel.Items[i].FindControl("dlRoom");

                decimal decBasicOfPriceRoom = 0M;

                for (int j = 0; j < dl.Items.Count; j++)
                {
                    DataListItem item = dl.Items[j];

                    RadioButton rbtn = (RadioButton)item.FindControl("rabRoomType");

                    Label temp11 = (Label)item.FindControl("lblRoomType1");

                    if (temp11.Text.Trim().ToUpper() == value.Items[0].DefaultRoomType.Room.Name.Trim().ToUpper())
                    {
                        rbtn.Checked = true;
                    }

                    rbtn.Attributes["onclick"] = "javascript:CancelSelect(this,'HotelCommonInfo1$dlHotel$ctl0" + i.ToString() + "$dlRoom$ctl0" + j.ToString() + "');";
                    //rbtn.GroupName = "HotelRoomType" + i.ToString().Trim();

                    Label lbl = (Label)item.FindControl("lblCode");

                    if (lbl.Text.Trim().ToUpper() == "FreeBreakfast".Trim().ToUpper())
                    {
                        Label temp1 = (Label)item.FindControl("lblRoomType2");
                        temp1.Visible = true;
                        Label temp2 = (Label)item.FindControl("lblBreakfast2");
                        temp2.Visible = true;
                    }

                    if (lbl.Text.Trim().ToUpper() == "WithOutBreakfast".Trim().ToUpper())
                    {
                        Label temp1 = (Label)item.FindControl("lblRoomType3");
                        temp1.Visible = true;
                        Label temp2 = (Label)item.FindControl("lblBreakfast3");
                        temp2.Visible = true;
                    }

                    if (lbl.Text.Trim().ToUpper() == "NonFreeBreakfast".Trim().ToUpper())
                    {
                        Label temp1 = (Label)item.FindControl("lblRoomType1");
                        temp1.Visible = true;
                        CheckBox temp2 = (CheckBox)item.FindControl("chkBreakfast");
                        temp2.Visible = true;
                    }

                    lbl = (Label)item.FindControl("lblPireType");

                    Label lblTemp = (Label)item.FindControl("lblTempAdd");

                    if (j == 0)
                    {
                        lbl.Visible = false;
 
                        lblTemp.Text = "Includeds";

                        //decBasicOfPriceRoom = value.RoomRates[value.Hotel.Rooms[i].RoomTypes[j]].BaseFare;
                    }
                    else
                    {
                        decimal temp = 0.0m;// value.RoomRates[value.Hotel.Rooms[i].RoomTypes[j]].BaseFare;

                        temp = decBasicOfPriceRoom - temp;

                        if (temp >= 0)
                        {
                            lbl.Text = "+" + temp.ToString("N2");
                        }
                        else
                        {
                            lbl.Text = temp.ToString("N2") ;
                        }

                        lbl.Visible = true;

                        lblTemp.Text = " per room per night (avg.)";
                    }
                }
            }
        }
        get
        {
            if (m_HotelMaterial == null)
            {
                m_HotelMaterial = new MVHotel(new TERMS.Business.Centers.SalesCenter.Hotel(new TERMS.Business.Centers.SalesCenter.HotelProfile("HotelProfile")));
            }

            return m_HotelMaterial;
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

    public HotelCommonInfo()
    {
        this.InitializeControls += new EventHandler(HotelCommonInfo_InitializeControls);
    }

    void HotelCommonInfo_InitializeControls(object sender, EventArgs e)
    {
        if (this.Request["ReturnUrl"] != null)
        {
            ReturnURL = this.Request["ReturnUrl"];
        }
        if (!this.IsPostBack)
        {
            List<string> temp = new List<string>();
            temp.Add("天数");

            dlCheckDate.DataSource = temp;
            dlCheckDate.DataBind();
            string strCheckin;
            string strCheckout;
            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                strCheckin = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                strCheckout = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                strCheckin = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                strCheckout = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }

            //for (int i = 0; i < dlCheckDate.Items.Count; i++)
            //{
            //    TermsCalendar checkin = (TermsCalendar)dlCheckDate.Items[i].FindControl("txtCheckin");
            //    checkin.Text = strCheckin;
            //    TermsCalendar checkout = (TermsCalendar)dlCheckDate.Items[i].FindControl("txtCheckout");
            //    checkout.Text = strCheckout;
            //}
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ////if (ProductType == Terms.Base.Utility.ProductType.Package)
        ////    this.Response.Redirect("PackageSummaryFrom.aspx");
        ////else
        ////    this.Response.Redirect("HotelViewForm.aspx");

        //if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        //{
        //    if (this.Request["Condition"] != null)
        //    {
        //        int index = Utility.Transaction.CurrentTransactionObject.Items.Count;

        //        for (int i = 0; i < index; i++)
        //        {
        //            int count = Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList.Count;

        //            for (int j = 0; j < count; j++)
        //            {
        //                if (((HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList[j]).Hotel.Id.ToString().Trim() == this.Request["HotelID"].Trim())
        //                {
        //                    HotelMaterial temp = (HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList[j];

        //                    for (int indexRoom = 0; indexRoom < temp.Hotel.Rooms.Count; indexRoom++)
        //                    {
        //                        DataList dlRooms = (DataList)dlHotel.Items[indexRoom].FindControl("dlRoom");

        //                        for (int indexroomscount = 0; indexroomscount < dlRooms.Items.Count; indexroomscount++)
        //                        {
        //                            RadioButton rb = (RadioButton)dlRooms.Items[indexroomscount].FindControl("rabRoomType");

        //                            if (rb.Checked)
        //                            {
        //                                Label lbltemp = (Label)dlRooms.Items[indexroomscount].FindControl("lblCode");

        //                                temp.Hotel.Rooms[indexRoom].SetDefaultRoomType(indexroomscount);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            if (Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList2 != null)
        //            {
        //                int Mcount = Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList2.Count;

        //                for (int k = 0; k < Mcount; k++)
        //                {
        //                    if (((HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList2[k]).Hotel.Id.ToString().Trim() == this.Request["HotelID"].Trim())
        //                    {
        //                        HotelMaterial temp = (HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList2[k];

        //                        for (int indexRoom = 0; indexRoom < temp.Hotel.Rooms.Count; indexRoom++)
        //                        {
        //                            DataList dlRooms = (DataList)dlHotel.Items[indexRoom].FindControl("dlRoom");

        //                            for (int indexroomscount = 0; indexroomscount < dlRooms.Items.Count; indexroomscount++)
        //                            {
        //                                RadioButton rb = (RadioButton)dlRooms.Items[indexroomscount].FindControl("rabRoomType");

        //                                if (rb.Checked)
        //                                {
        //                                    Label lbltemp = (Label)dlRooms.Items[indexroomscount].FindControl("lblCode");

        //                                    temp.Hotel.Rooms[indexRoom].SetDefaultRoomType(indexroomscount);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }



        //        this.Response.Redirect(ReturnURL + "?PostBack=false");
        //    }
        //    else
        //    {
        //        this.Response.Redirect("PackageSummaryFrom.aspx");
        //    }
        //}
        //else
        //{
        //    if (this.Request["Condition"] != null)
        //    {
        //    }
        //    else
        //    {
        //        SaleMerchandise m_SaleMerchandise = this.OnSearch();

        //        List<HotelMaterial> hotelMaterial = new List<HotelMaterial>();

        //        for (int i = 0; i < m_SaleMerchandise.MaterialList.Count; i++)
        //        {
        //            if (((HotelMaterial)m_SaleMerchandise.MaterialList[i]).Hotel.Id.ToString().Trim() == this.Request["HotelID"].Trim())
        //            {

        //                if (Utility.Transaction.CurrentTransactionObject.Items != null)
        //                {
        //                    if (Utility.Transaction.CurrentTransactionObject.Items.Count == 0)
        //                    {
        //                        SaleMerchandise saleMerchandise = new SaleMerchandise();
        //                        saleMerchandise.MaterialList.Add(m_SaleMerchandise.MaterialList[i]);
        //                        OrderMerchandise newOrderMerchandise = new OrderMerchandise(saleMerchandise);
        //                        Utility.Transaction.CurrentTransactionObject.Items.Add(newOrderMerchandise);
        //                    }
        //                    else
        //                    {
        //                        Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Add(m_SaleMerchandise.MaterialList[i]);
        //                    }
        //                }
        //                else
        //                {
        //                    SaleMerchandise saleMerchandise = new SaleMerchandise();
        //                    saleMerchandise.MaterialList.Add(m_SaleMerchandise.MaterialList[i]);
        //                    OrderMerchandise newOrderMerchandise = new OrderMerchandise(saleMerchandise);
        //                    Utility.Transaction.CurrentTransactionObject.Items.Add(newOrderMerchandise);
        //                }
        //            }
        //        }
        //    }

        //    int index = Utility.Transaction.CurrentTransactionObject.Items.Count;

        //    for (int i = 0; i < index; i++)
        //    {
        //        int count = Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList.Count;

        //        for (int j = 0; j < count; j++)
        //        {
        //            if (((HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList[j]).Hotel.Id.ToString().Trim() == this.Request["HotelID"].Trim())
        //            {
        //                HotelMaterial temp = (HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[i].Merchandise.MaterialList[j];

        //                for (int indexRoom = 0; indexRoom < temp.Hotel.Rooms.Count; indexRoom++)
        //                {
        //                    DataList dlRooms = (DataList)dlHotel.Items[indexRoom].FindControl("dlRoom");

        //                    for (int indexroomscount = 0; indexroomscount < dlRooms.Items.Count; indexroomscount++)
        //                    {
        //                        RadioButton rb = (RadioButton)dlRooms.Items[indexroomscount].FindControl("rabRoomType");

        //                        if (rb.Checked)
        //                        {
        //                            Label lbltemp = (Label)dlRooms.Items[indexroomscount].FindControl("lblCode");

        //                            temp.Hotel.Rooms[indexRoom].SetDefaultRoomType(indexroomscount);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    this.Response.Redirect("HotelViewForm.aspx??HotelID=" + this.Request["HotelID"].Trim());
        //}
    }

    private string BindPageList(MVHotel pHotelMaterial)
    {
        string temp = string.Empty;

        lblHotelName.Text = pHotelMaterial.HotelInformation.Name;

        lblAddress.Text = pHotelMaterial.HotelInformation.Address;

        lblLocation.Text = pHotelMaterial.Location;

        imgMapUrl.ImageUrl = pHotelMaterial.HotelInformation.MapUrl;

        //List<SaleHotelAmenity> tempSaleHotelAmenity = pHotelMaterial.Hotel.Amenities;

        for (int i = 0; i < pHotelMaterial.Amenities.Count; i++)
        {
            temp += "<li>" + pHotelMaterial.Amenities[i].Name + "</li>";
        }

        return temp;
    }
}
