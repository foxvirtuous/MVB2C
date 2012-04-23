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


public partial class HotelSelectForm : SalseBasePage
{
    //记录Air Search时间的日志对象
    private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger("HotelSearchTime");

    private static readonly log4net.ILog hotelSearchHotelByZyl =
         log4net.LogManager.GetLogger("HotelSearchPerformanceDebugging");

    public HotelSelectForm()
    {
        this.InitializeControls += new EventHandler(HotelSelectForm_InitializeControls);
    }

    void HotelSelectForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (!Utility.IsSearchConditionNull)
        {
            DateTime dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Info("MV_B2C Hotel Searching1 To HotelSelectForm Conclusion : " + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

            hotelSearchHotelByZyl.Debug("Hotel End :" + DateTime.Now.ToLongTimeString());

            DateTime dtTime = System.DateTime.Now;

            if (!this.IsPostBack)
            {
                //log
                log.Info( PageUtility.HotelLogRandomNumber.ToString() + " >Load HotelSelectForm.aspx Begin Start time : " + dtTime);

                NavigationControl1.PageCode = 1;
                ChangeTravelersControl1.ReturnURL = "~/Page/Hotel/HotelSelectForm.aspx";

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
                        Utility.Transaction.IntKey = hotelSearchCondition.GetHashCode();
                        Utility.Transaction.CurrentSearchConditions = hotelSearchCondition;

                        if (this.Request["edit"] == "y")
                            DeleteBeingChangedHotelOrderItem(hotelName, this.Request["CheckIn"]);

                        ////从TransactionObject中删除正在修改的HotelOrderItem
                        //for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                        //{
                        //    HotelOrderItem temp = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                        //    if (temp.Room.Hotel.HotelCode.ToString().Trim() == this.Request["HotelID"].Trim() && temp.CheckIn == Convert.ToDateTime(this.Request["CheckIn"]))
                        //    {
                        //        Utility.Transaction.CurrentTransactionObject.Items.Remove(Utility.Transaction.CurrentTransactionObject.Items[i]);
                        //    }
                        //}

                        this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Hotel/HotelSelectForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        this.Response.Redirect("~/Index.aspx");
                    }
                }
            }

            SearchAndBind();

            if (!this.IsPostBack)
            {
                log.Info( PageUtility.HotelLogRandomNumber.ToString() + " >Load HotelSelectForm.aspx End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtTime)).ToString());
            }
        }
        else
        { 
            //出错处理。
            Err("The search condition has been removed from cache, please re-search.", "", "HotelSelectForm.aspx");
        }
    }

    private void DeleteBeingChangedHotelOrderItem(string hotelName, string strCheckin)
    {
        //删除Change的Room Type
        //for (int i = Utility.Transaction.CurrentTransactionObject.Items.Count - 1; i >= 0; i--)
        //{
        //    HotelOrderItem hotelOrderItem = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

        //    if ((hotelOrderItem.CheckIn == Convert.ToDateTime(strCheckin)) && (hotelOrderItem.Room.Hotel.Name.Trim() == hotelName.Trim()))
        //        Utility.Transaction.CurrentTransactionObject.Items.Remove(hotelOrderItem);
        //}
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

            HotelDetailedInformationListControl1.HotelMaterial = hotelMaterialNew;
        }
        else
        {
            this.Response.Redirect("~/Index.aspx");
        }

        this.hotelSelect.NavigateUrl += "&ConditionID=" + Request.Params["ConditionID"];

        if (Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {
            divReturn.Visible = true;
        }
        else
        {
            divReturn.Visible = false;
        }
    }
}
