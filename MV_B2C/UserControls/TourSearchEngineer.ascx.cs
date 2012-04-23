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
using Terms.Sales.Business;

public partial class TourSearchEngineer : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (txtTourSearch.Text.Trim().Length > 0)
        {
            TourSearchCondition tourSearchCondition = new TourSearchCondition();

            Utility.IsTourMore = false;
            Utility.IsTourMain = true;
            tourSearchCondition.IsLandOnly = true;
            tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
            tourSearchCondition.TravelDaysFrom = 1;
            tourSearchCondition.TravelDaysTo = 800;
            tourSearchCondition.PriceType = TERMS.Common.TourPriceType.All;
            Utility.Transaction.IntKey = tourSearchCondition.GetHashCode();
            Utility.Transaction.CurrentSearchConditions = tourSearchCondition;
            Utility.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

            Response.Redirect("~/page/Common/Searching1.aspx?TourSearchEngineer=" + txtTourSearch.Text.Trim() + "&ConditionID=" + this.Transaction.IntKey.ToString());
        }
    }
}