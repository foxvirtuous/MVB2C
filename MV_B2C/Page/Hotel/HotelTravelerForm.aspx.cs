using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using log4net;
using Spring.Web.UI;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

public partial class HotelTravelerForm : SalseBasePage
{
    public HotelTravelerForm()
    {
        this.InitializeControls += new EventHandler(HotelTravelerForm_InitializeControls);
    }

    void HotelTravelerForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (!this.IsSearchConditionNull)
        {
            if (!this.IsPostBack)
            {
                HotelListViewControl1.IsMoreLinkVisible = false;
                NavigationControl1.PageCode = 2;
                SetValidationGroup();
            }

            BindPrice();
        }
        else
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The search condition has been removed from cache, please re-search.&&GoToPage=~/Page/Hotel/HotelTravelerForm.aspx");
        }
    }
    protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (this.IsValid)
        {
                bool flag ;
                flag = HotelOrderPassengerInfoControl1.PaddingPassengerInfo();
                if (!flag)
                {
                    return;
                }
                flag = PHContactInfoControl1.PaddingPassengerInfo();
                if (!flag)
                {
                    return;
                }
                this.Response.Redirect(SecureUrlSuffix + "Page/Hotel/HotelCreditForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
            //}
        }
    }

    private void SetValidationGroup()
    {
        HotelOrderPassengerInfoControl1.ValidationGroup = "HotelTravelerForm";
        PHContactInfoControl1.ValidationGroup = "HotelTravelerForm";
        this.ibtnSubmit.ValidationGroup = "HotelTravelerForm";
    }

    private void BindPrice()
    {
        int iAdult = 0;
        int iChild = 0;

        if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            for (int i = 0; i < ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions.Count; i++)
            {
                iAdult += ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[i].Passengers[PassengerType.Adult];
                iChild += ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions[i].Passengers[PassengerType.Child];
            }

            int iCount = Utility.Transaction.CurrentTransactionObject.Items.Count;

            decimal decSum = 0M;

            for (int i = 0; i < iCount; i++)
            {
                //if (Utility.Transaction.CurrentTransactionObject.Items[i] is HotelOrderItem)
                //{
                //    HotelOrderItem tempHotelMaterial = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];
                //    decSum += tempHotelMaterial.RoomPrice;
                //}

                ////if (Utility.Transaction.CurrentTransactionObject.SubagentMarkup.GetTotalMarkup(PassengerType.Adult))
                ////{
                ////    SubagentMarkupOrderItem tempHotelMaterial = (SubagentMarkupOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];
                //decSum += Utility.Transaction.CurrentTransactionObject.SubagentMarkup.GetTotalMarkup(PassengerType.Adult);
                ////}
                HotelOrderItem tempHotelMaterial = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];
                decSum += tempHotelMaterial.TotalPrice;
            }

            lblTotal.Text = decSum.ToString("N2");
        }
    }
}

