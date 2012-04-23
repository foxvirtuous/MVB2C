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
using System.Globalization;

public partial class Index_New : IndexPageBase
{


    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    private void SearchT()
    {
        //if (Utility.IsSubAgent)
        //    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchTour, this);
        //else
        //    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchTour, this);

        //if (this.tourDeptCalendar.CDate == "__/__/____" || this.tourDeptCalendar.CDate == "")
        //{
        //    this.lblMsg.Visible = true;
        //    return;
        //}


        ////log begin 20090312 Leon
        //PageUtility.TourSearchingTimeLog.Info("\r\n");

        //if (!Utility.IsLogin)
        //    PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >====================Not Login========================");
        //else
        //    PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >==========================Login========================");

        //PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >Tour Searching(1) Begin at: " + System.DateTime.Now);

        ////log end 20090312 Leon


        //TourSearchCondition tourSearchCondition = new TourSearchCondition();
        //tourSearchCondition.Region = this.ddlArea_T.SelectedValue.ToString();
        //tourSearchCondition.Counrty = this.ddlCountry_T.SelectedValue.ToString();
        //tourSearchCondition.City = this.ddlCity_T.SelectedValue.ToString();
        //if (rdbAirLand.Checked == true)
        //{
        //    tourSearchCondition.IsLandOnly = false;
        //}
        //else
        //{
        //    tourSearchCondition.IsLandOnly = true;
        //}
        //tourSearchCondition.TravelBeginDate = GlobalUtility.GetDateTime(tourDeptCalendar.CDate.Trim());

        //switch (ddlTravelDate.SelectedIndex)
        //{
        //    case 0: tourSearchCondition.TravelDaysFrom = 1;
        //        tourSearchCondition.TravelDaysTo = 10;
        //        break;
        //    case 1: tourSearchCondition.TravelDaysFrom = 11;
        //        tourSearchCondition.TravelDaysTo = 15;
        //        break;
        //    case 2: tourSearchCondition.TravelDaysFrom = 16;
        //        tourSearchCondition.TravelDaysTo = 800;
        //        break;
        //    default:
        //        tourSearchCondition.TravelDaysFrom = 1;
        //        tourSearchCondition.TravelDaysTo = 800;
        //        break;
        //}
        //this.Transaction.IntKey = tourSearchCondition.GetHashCode();
        //this.Transaction.CurrentSearchConditions = tourSearchCondition;
        //this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
        //Utility.IsTourMain = false;//设置是否是Tour标志
        //Utility.IsTourMore = false;//设置是否是Tour More
    }
}
