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

using Terms.Sales.Service;
using Terms.Sales.Dao;
using Terms.Sales.Domain;

using Terms.Product.Domain;
using Terms.Material.Domain;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;



public partial class DetailForm : SalseBasePage
{
    public DetailForm()
    {
        this.InitializeControls += new EventHandler(DetailForm_InitializeControls);
    }

    void DetailForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (!this.IsPostBack)
        {
            Navigation1.PageCode = 2;

            SearchAndBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Header1.Path = "../../";
    }

    private void SearchAndBind()
    {
        //查询其他城市，重置查询条件

        if (this.Request["Condition"] != null)
        {
            string strCityCode = string.Empty;
            string strLocationIndicator = string.Empty;
            DateTime dateCheckOut = DateTime.MaxValue;

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                HotelOrderItem temp = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                if (temp.Room.Hotel.Name.ToString().Trim() == this.Request["HotelName"].Trim() && temp.CheckIn == Convert.ToDateTime(this.Request["CheckIn"].Trim()))
                {
                    strCityCode = temp.Room.Hotel.City.Code;
                    strLocationIndicator = temp.Room.Hotel.City.Country.Code;
                    dateCheckOut = temp.CheckOut;
                    Utility.Transaction.CurrentTransactionObject.Items.Remove(Utility.Transaction.CurrentTransactionObject.Items[i]);
                }
            }

            Terms.Sales.Business.HotelSearchCondition hotelSearchCondition = (Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions;

            hotelSearchCondition.CheckIn = Convert.ToDateTime(this.Request["CheckIn"].Trim());
            hotelSearchCondition.CheckOut = dateCheckOut;
            hotelSearchCondition.Location = strCityCode;
            hotelSearchCondition.Country = strLocationIndicator;
            hotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;

            Utility.Transaction.CurrentSearchConditions = hotelSearchCondition;
        }

        HotelMerchandise m_SaleMerchandise = (HotelMerchandise)this.OnSearch();

        if (m_SaleMerchandise.Items.Count > 0)
        {
            string hotelid = this.Request["HotelID"];
            string hotelName = this.Request["HotelName"];
            string strCheckin = this.Request["CheckIn"];

            if (this.Request["edit"] == "y")
                DeleteBeingChangedHotelOrderItem(hotelName, strCheckin);

            MVHotel currentHotel = GetBeingChangedHotel(m_SaleMerchandise, hotelid, hotelName, strCheckin);

            if (currentHotel != null)
            {
                HotelCommonInfoControl1.HotelMaterial = currentHotel;
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

    private MVHotel GetBeingChangedHotel(HotelMerchandise m_SaleMerchandise, string hotelid, string hotelName, string strCheckin)
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
        return currentHotel;
    }
}

