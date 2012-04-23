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

    //����ʾ�����ķɻ��г���Ϣ
    private void BindFlight()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {
            AirOrderItem airOrderItem = null;

            //�ڶ�������Air������
            foreach (OrderItem item in Utility.Transaction.CurrentTransactionObject.Items)
            {
                airOrderItem = FindAirOrderItem(item);

                if (airOrderItem != null) break;
            }

            //�󶨷ɻ��г���Ϣ
            if (airOrderItem != null)
            {
                dlSubTrips.DataSource = ((AirMaterial)airOrderItem.Merchandise).AirTrip.SubTrips;
                dlSubTrips.DataBind();
            }
        }
    }

    private AirOrderItem FindAirOrderItem(Component orderItem)
    {
        if (orderItem is AirOrderItem) return (AirOrderItem)orderItem;  //�ҵ���
        if (orderItem is HotelOrderItem) return null;  //��HotelOrderItem
        if (orderItem is TourOrderItem)
        {
            for(int i=0;i<((TourOrderItem)orderItem).Items.Count;i++)
            {
                if (((TourOrderItem)orderItem).Items[i] is AirOrderItem)
                    return (AirOrderItem)((TourOrderItem)orderItem).Items[i];
            }
            return null;
        }
        if (!(orderItem is ComponentGroup)) return null;    //����ComonentGroup˵��û������,����û�ҵ�

        ComponentGroup cGroup = (ComponentGroup)orderItem;
      
        if (cGroup.Items.Count == 0) return null; //û�ҵ�

        foreach (Component item in cGroup.Items)
        {
            if (item is AirOrderItem)
            {
                return (AirOrderItem)item; //�ҵ���
            }
            else if (item is ComponentGroup)
            {
                AirOrderItem result = FindAirOrderItem(orderItem); //�ݹ����

                if (result != null) return result; //���ǿմ����ҵ���
            }
        }

        return null; //û�ҵ�
    }

    protected void dlFlights_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            

        }
    }
}
