using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TERMS.Common;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Core.Product;
public partial class TourFlightDetailInMailControl : Spring.Web.UI.UserControl
{
    public TourFlightDetailInMailControl()
    {
        this.InitializeControls += new EventHandler(TourFlightDetailInMailControl_InitializeControls);
    }

    void TourFlightDetailInMailControl_InitializeControls(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFlight();
        }
    }

    //绑定显示订购的飞机行程信息
    private void BindFlight()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {
            AirOrderItem airOrderItem = null;

            //在订单中找Air订单项
            foreach (OrderItem item in Utility.Transaction.CurrentTransactionObject.Items)
            {
                airOrderItem = FindAirOrderItem(item);

                if (airOrderItem != null) break;
            }

            //绑定飞机行程信息
            if (airOrderItem != null)
            {
                dlSubTrips.DataSource = ((AirMaterial)airOrderItem.Merchandise).AirTrip.SubTrips;
                dlSubTrips.DataBind();
            }
        }
    }

    private AirOrderItem FindAirOrderItem(Component orderItem)
    {
        if (orderItem is AirOrderItem) return (AirOrderItem)orderItem;  //找到了
        if (orderItem is HotelOrderItem) return null;  //是HotelOrderItem
        if (orderItem is TourOrderItem)
        {
            for(int i=0;i<((TourOrderItem)orderItem).Items.Count;i++)
            {
                if (((TourOrderItem)orderItem).Items[i] is AirOrderItem)
                    return (AirOrderItem)((TourOrderItem)orderItem).Items[i];
            }
            return null;
        }
        if (!(orderItem is ComponentGroup)) return null;    //不是ComonentGroup说明没有子项,所以没找到

        ComponentGroup cGroup = (ComponentGroup)orderItem;
      
        if (cGroup.Items.Count == 0) return null; //没找到

        foreach (Component item in cGroup.Items)
        {
            if (item is AirOrderItem)
            {
                return (AirOrderItem)item; //找到了
            }
            else if (item is ComponentGroup)
            {
                AirOrderItem result = FindAirOrderItem(orderItem); //递归查找

                if (result != null) return result; //不是空代表找到了
            }
        }

        return null; //没找到
    }

    protected void dlFlights_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            

        }
    }
}
