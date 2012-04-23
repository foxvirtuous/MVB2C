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

using Terms.Product.Domain;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Service;
using System.Text;

public partial class PriceingForm : SalseBasePage
{
    private OrderTermsConditionsService m_OrderTermsConditionsService;

    protected OrderTermsConditionsService OrderTermsConditionsService
    {
        get
        {
            return m_OrderTermsConditionsService;

        }
        set
        {
            m_OrderTermsConditionsService = value;
        }
    }

    public PriceingForm()
    {
        this.InitializeControls += new EventHandler(PriceingForm_InitializeControls);
    }

    void PriceingForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (Utility.IsLogin)
        {
            UserLogin1.Visible = false;
            divHead.Visible = false;
        }
        else
        {
            UserLogin1.Visible = true;
            UserLogin1.NextUrl = "~/Page/Hotel2/TravelForm.aspx";
            UserLogin1.ReturnUrl = "~/Page/Hotel2/PriceingForm.aspx?HotelID=" + this.Request["HotelID"];
            divHead.Visible = true;
        }
        if (!this.IsSearchConditionNull)
        {
            if (!this.IsPostBack)
            {
                ctlNavigationControl.PageCode = 2;

                InitSet();

                DeleteHotelById();

                SearchAndBind();
            }

        }
        else
        {
            //出错处理
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The search condition has been removed from cache, please re-search.&&GoToPage=~/Page/Hotel2/HotelViewForm.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Header1.Path = "../../";
    }

    private void SearchAndBind()
    {
        HotelMerchandise m_SaleMerchandise = (HotelMerchandise)this.OnSearch();

        if (m_SaleMerchandise.Items.Count > 0)
        {
            string hotelid = this.Request["HotelID"];
            string hotelName = this.Request["HotelName"];
            string strCheckin = this.Request["CheckIn"];
            string strGTACityCode = this.Request["GTACITYCODE"];

            if (this.Request["edit"] == "y")
                DeleteBeingChangedHotelOrderItem(hotelName, strCheckin);

            MVHotel currentHotel = GetBeingChangedHotel(m_SaleMerchandise, hotelid, hotelName, strCheckin, strGTACityCode);

            RoomTypeList cancel = new RoomTypeList();

            RoomTypeList canceldelete = new RoomTypeList();

            if (currentHotel != null && currentHotel.Profile.GetParam("DATASOURCE").ToString().Trim().ToUpper() == "GTA")
            {

                Terms.Sales.Business.CancellationPolicy Policy = new CancellationPolicy();

                cancel = Policy.GetIsNoHotelCancellation(currentHotel, true, out canceldelete);
                 
            }

            if (currentHotel.Items.Count > 0)
            {
                HTLSelectRoomTypeControl1.RoomCancel = cancel;
                HTLSelectRoomTypeControl1.RoomDelete = canceldelete;
                HTLSelectRoomTypeControl1.HotelMaterial = currentHotel;
            }
            else
            {
                this.Response.Redirect("SearchResultForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
            }

        }
        else
        {
            this.Response.Redirect("~/Index.aspx");
        }

    }

    private void DeleteBeingChangedHotelOrderItem(string hotelName, string strCheckin)
    {
        //删除Change的Room Type
        for (int i = Utility.Transaction.CurrentTransactionObject.Items.Count - 1; i >= 0; i--)
        {
            HotelOrderItem hotelOrderItem = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

            if ((hotelOrderItem.CheckIn == Convert.ToDateTime(strCheckin)) && (hotelOrderItem.Room.Hotel.Name.Trim() == hotelName.Trim()))
                Utility.Transaction.CurrentTransactionObject.Items.Remove(hotelOrderItem);
        }
    }

    private MVHotel GetBeingChangedHotel(HotelMerchandise m_SaleMerchandise, string hotelid, string hotelName, string strCheckin, string strGTACityCode)
    {
        MVHotel currentHotel = null;

        //查找当前修改的Hotel
        for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
        {
            MVHotel hotel = (MVHotel)m_SaleMerchandise.Items[i];

            if (!string.IsNullOrEmpty(hotelid)) //根据HotelID查找当前修改的Hotel
            {
                if (hotel.HotelInformation.HotelCode.ToString().Trim() == hotelid.Trim())
                {
                    if (hotel.HotelInformation.City.GTACode.ToString().Trim() == strGTACityCode.Trim())
                    {
                        currentHotel = hotel;
                        break;
                    }
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
        return currentHotel;
    }

    private void InitSet()
    {
        //获取Terms Conditions
        string ConditionsType = "";
        if (this.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            ConditionsType = "MVPackage";
        }
        if (this.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            ConditionsType = "MVHotel";
        }

        Terms.Sales.Domain.TermsConditionsMeta TermsCondtions = m_OrderTermsConditionsService.GetTermsConditions(ConditionsType);
        if (TermsCondtions != null)
        {
            lbConditons.Text = TermsCondtions.Conditions;
            this.Transaction.TermsConditions = TermsCondtions.Conditions;
        }
    }
    
    private void DeleteHotelById()
    {
        if (this.Request["Delete"] != null)
        {
            if (this.Request["Delete"].Trim().ToUpper() == "Y".Trim().ToUpper())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>return confirm('are you sure?');</script>");

                string strID = this.Request["HotelID"].Trim().ToUpper();

                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Room.Hotel.HotelCode == strID)
                    {
                        Utility.Transaction.CurrentTransactionObject.Items.Remove(Utility.Transaction.CurrentTransactionObject.Items[i]);
                    }
                }

                if (Utility.Transaction.CurrentTransactionObject.Items.Count == 0)
                {
                    this.Response.Redirect("~/Index.aspx");
                }
            }
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        if (this.chkConditions.Checked)
        {
            HTLSelectRoomTypeControl1.BookPrice();
        }
        else
        {
            //错误
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please read & confirm the Terms and Conditions to continue');</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alt", "if(document.getElementById('clickLink')!= null){document.getElementById('clickLink').click();}", true);
            return;
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        switch (FocusIndex.Value.Trim().ToUpper())
        {
            case "R":
                HotelOnlySearchControl1.imgbSearch_Click(new object(), new EventArgs());
                break;
            case "S":
                break;
            default:
                break;
        }
    }
}