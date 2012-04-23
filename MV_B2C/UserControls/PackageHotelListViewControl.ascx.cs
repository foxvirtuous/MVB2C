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

using Spring.Web.UI;
using log4net;

using Terms.Material.Domain;
using Terms.Product.Domain;
using TERMS.Business.Centers.SalesCenter;

public partial class PackageHotelListViewControl : Spring.Web.UI.UserControl
{

    public PackageHotelListViewControl()
    {
        this.InitializeControls += new EventHandler(PackageHotelListViewControl_InitializeControls);
    }

    void PackageHotelListViewControl_InitializeControls(object sender, EventArgs e)
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
                    HotelOrderItem tempHotelMaterial = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];
                    HotelOrderItems.Add(tempHotelMaterial);
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

            dlHotelByCity.DataSource = HotelOrderUtility.GetCityDataSource(HotelOrderItems);
            dlHotelByCity.DataBind();

        //    for (int i = 0; i < dlHotelByCity.Items.Count; i++)
        //    {
        //        DataListItem item = dlHotelByCity.Items[i];

        //        Label lbl = (Label)item.FindControl("lblCityName");

        //        lbl.Text = listCityName[i];

        //        List<HotelMaterial> NewHotelMaterials = new List<HotelMaterial>();

        //        for (int j = 0; j < HotelMaterials.Count; j++)
        //        {
        //            if (HotelMaterials[j].Hotel.CityCode.Name.Trim() == listCityName[i].Trim())
        //            {
        //                NewHotelMaterials.Add(HotelMaterials[j]);
        //            }
        //        }

        //        DataList dl = (DataList)item.FindControl("dlHotel");

        //        dl.DataSource = NewHotelMaterials;
        //        dl.DataBind();

        //        for (int x = 0; x < dl.Items.Count; x++)
        //        {
        //            DataListItem itemX = dl.Items[x];

        //            DataList dlX = (DataList)itemX.FindControl("dlRooMs");

        //            for (int ii = 0; ii < dlX.Items.Count; ii++)
        //            {
        //                Label lblX = (Label)dlX.Items[ii].FindControl("lblDayNumber");
        //                lblX.Text = strDayNumber;

        //                Label lblBreakfast = (Label)dlX.Items[ii].FindControl("Label2");

        //                if (lblBreakfast.Text.Trim().ToUpper() == "FreeBreakfast".Trim().ToUpper())
        //                {
        //                    lblBreakfast.Text = "Included Breakfast";
        //                }
        //                if (lblBreakfast.Text.Trim().ToUpper() == "NonFreeBreakfast".Trim().ToUpper())
        //                {
        //                    lblBreakfast.Text = "NonFreeBreakfast";
        //                }
        //                if (lblBreakfast.Text.Trim().ToUpper() == "WithOutBreakfast".Trim().ToUpper())
        //                {
        //                    lblBreakfast.Text = "Not Included Breakfast";
        //                }
        //            }

        //            HyperLink hl2 = (HyperLink)itemX.FindControl("hlRoomType");
        //            HyperLink hl3 = (HyperLink)itemX.FindControl("hotelSelect");

        //            Label lblHotelID = (Label)itemX.FindControl("lblHotelID");

        //            hl2.NavigateUrl = "~/Terms.Sales.Web/PackageSelectRoomsForm.aspx?HotelID=" + lblHotelID.Text + "&&Condition=A &&ReturnUrl=PackageSummaryFrom.aspx";


        //            Label lblCountryCode = (Label)itemX.FindControl("lblCountry");
        //            Label lblCityCode = (Label)itemX.FindControl("lblCityCode");
        //            Label lblCheckin = (Label)itemX.FindControl("lblCheckin");
        //            Label lblCheckOut = (Label)itemX.FindControl("lblCheckOut");


        //            hl3.NavigateUrl = "~/Terms.Sales.Web/PackageSearchForm.aspx?Country=" + lblCountryCode.Text + "&&CityCode=" + lblCityCode.Text +
        //                "&&CheckIn=" + lblCheckin.Text + "&&CheckOut=" + lblCheckOut.Text + "&&HotelID=" + lblHotelID.Text;

        //            hl3.Text = "Choose other hotel in " + ((Label)itemX.Parent.Parent.FindControl("lblCityName")).Text;

        //            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
        //            {
        //                itemX.FindControl("divDelete").Visible = false;
        //                hl2.Visible = false;
        //                hl3.Visible = false;
        //            }

        //            string strUrl = this.Request.Url.ToString();

        //            if (strUrl.Contains("PackageTravelerForm"))
        //            {
        //                itemX.FindControl("divDelete").Visible = false;
        //            }
        //        }
        //    }
        }
    }
}
