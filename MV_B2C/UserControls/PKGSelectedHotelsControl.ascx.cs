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
using Spring.Web.UI;
using log4net;

using Terms.Material.Domain;
using Terms.Product.Domain;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using System.Collections.Generic;

namespace Terms.Web.UserControls
{
    public partial class PKGSelectedHotelsControl : Spring.Web.UI.UserControl
    {
        public bool IsMoreLinkVisible
        {
            get
            {
                if (ViewState["IsMoreLinkVisible"] == null)
                    ViewState["IsMoreLinkVisible"] = true;

                return Convert.ToBoolean(ViewState["IsMoreLinkVisible"]);
            }
            set { ViewState["IsMoreLinkVisible"] = value; }
        }

        public bool IsShowPrice
        { 
            get
            {
                bool result = false;

                if (Utility.Transaction.CurrentSearchConditions != null)
                {
                    if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                        result = true;
                    else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                        result = false;
                }

                return result;
            }
        }

        public PKGSelectedHotelsControl()
        {
            this.InitializeControls += new EventHandler(PKGSelectedHotelsControl_InitializeControls);
            this.Load += new EventHandler(PKGSelectedHotelsControl_Load);
        }

        void PKGSelectedHotelsControl_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                if (!Utility.IsSearchConditionNull)
                {
                    DateTime checkin;
                    DateTime checkout;
                    int nights = 0;
                    List<HotelOrderItem> HotelOrderItems = new List<HotelOrderItem>();

                    if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                    {
                        checkin = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn;
                        checkout = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut;
                        nights = ((TimeSpan)checkout.Subtract(checkin)).Days;

                        for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                        {
                            if (Utility.Transaction.CurrentTransactionObject.Items[i] is HotelOrderItem)
                            {
                                HotelOrderItem tempHotelMaterial = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];
                                HotelOrderItems.Add(tempHotelMaterial);
                            }
                        }
                    }

                    if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                    {
                        checkin = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn;
                        checkout = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut;
                        nights = ((TimeSpan)checkout.Subtract(checkin)).Days;
                        for (int i = 1; i < ((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items.Count; i++)
                        {
                            HotelOrderItem tempHotelMaterial = (HotelOrderItem)((PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).Items[i];
                            HotelOrderItems.Add(tempHotelMaterial);
                        }
                        
                    }
                    List<cCity> cCitys = HotelOrderUtility.GetCityDataSource(HotelOrderItems);
                    dlHotelByCity.DataSource = cCitys;
                    dlHotelByCity.DataBind();

                    for (int i = 0; i < dlHotelByCity.Items.Count; i++)
                    {
                        DataList dlHotel = (DataList)dlHotelByCity.Items[i].FindControl("dlHotel");

                        for (int ii = 0; ii < dlHotel.Items.Count; ii++)
                        {
                            Repeater repeater = (Repeater)dlHotel.Items[ii].FindControl("rptRoom");

                            for (int iii = 0; iii < repeater.Items.Count; iii++)
                            {
                                Label lbl = (Label)repeater.Items[iii].FindControl("Label2");

                                if (cCitys[i].Hotels[ii].RoomTypes[iii].IsBuyBreakfast)
                                {
                                    if (string.IsNullOrEmpty(cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastName))
                                    {
                                        lbl.Text = "Breakfast $" + cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastPricePerPersonPerDay.ToString("N2");
                                    }
                                    else
                                    {
                                        lbl.Text = cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastName + " $ " + cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastPricePerPersonPerDay.ToString("N2");
                                    }
                                }
                                else
                                {
                                    if (cCitys[i].Hotels[ii].RoomTypes[iii].IncluedBreakfastQuantity == 0 && cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastPricePerPersonPerDay == 0)
                                    {
                                        lbl.Text = "Not included breakfast";
                                    }

                                    if (cCitys[i].Hotels[ii].RoomTypes[iii].IncluedBreakfastQuantity > 0)
                                    {
                                        if (string.IsNullOrEmpty(cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastName))
                                        {
                                            lbl.Text = "Includes breakfast for  for " + cCitys[i].Hotels[ii].RoomTypes[iii].IncluedBreakfastQuantity.ToString();
                                        }
                                        else
                                        {
                                            lbl.Text = cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastName + " for " + cCitys[i].Hotels[ii].RoomTypes[iii].IncluedBreakfastQuantity.ToString();
                                        }
                                    }

                                    if (cCitys[i].Hotels[ii].RoomTypes[iii].IncluedBreakfastQuantity == 0 && cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastPricePerPersonPerDay > 0)
                                    {
                                        if (string.IsNullOrEmpty(cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastName))
                                        {
                                            lbl.Text = "Breakfast $" + cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastPricePerPersonPerDay.ToString("N2");
                                        }
                                        else
                                        {
                                            lbl.Text = cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastName + " $ " + cCitys[i].Hotels[ii].RoomTypes[iii].BreakfastPricePerPersonPerDay.ToString("N2");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        void PKGSelectedHotelsControl_InitializeControls(object sender, EventArgs e)
        {
            
        }

        protected void dlHotel_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //HyperLink hotelSelect = (HyperLink)e.Item.FindControl("hotelSelect");
                //hotelSelect.NavigateUrl += "&ConditionID=" + Request.Params["ConditionID"];
            }
        }   
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}