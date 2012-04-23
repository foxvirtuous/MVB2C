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
using Terms.Common.Service;
using Terms.Material.Service;
using Terms.Global.Utility;
using System.Globalization;
public partial class SearchEngineT : SalesBaseUserControl
{

    private AirService m_airService;

    protected AirService AirService
    {
        get
        {
            return m_airService;

        }
        set
        {
            m_airService = value;
        }
    }

    private ICommonService _CommonService;

    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        if (Utility.IsSubAgent)
        {
            this.tourDeptCalendar.Path = "../";
        }
        else
        {
            this.tourDeptCalendar.Path = "";
        }

        if (!IsPostBack)
        {
            //this.tourDeptCalendar.Path = ""; //this.PATH;


            SetPageValidationGroup();

            tourDeptCalendar.BeginDate = DateTime.Now.AddDays(7);

        }
    }
    protected void btn_Search_t_Click(object sender, EventArgs e)
    {
        if (Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchTour, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchTour, this);

        if (this.tourDeptCalendar.CDate == "__/__/____" || this.tourDeptCalendar.CDate == "")
        {
            this.lblMsg.Visible = true;
            return;
        }


        //log begin 20090312 Leon
        PageUtility.TourSearchingTimeLog.Info("\r\n");

        if (!Utility.IsLogin)
            PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >====================Not Login========================");
        else
            PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >==========================Login========================");

        PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >Tour Searching(1) Begin at: " + System.DateTime.Now);

        //log end 20090312 Leon


        TourSearchCondition tourSearchCondition = new TourSearchCondition();
        tourSearchCondition.Region = this.ddlArea_T.SelectedValue.ToString();
        tourSearchCondition.Counrty = this.ddlCountry_T.SelectedValue.ToString();
        tourSearchCondition.City = this.ddlCity_T.SelectedValue.ToString();
        if (rdbAirLand.Checked == true)
        {
            tourSearchCondition.IsLandOnly = false;
        }
        else
        {
            tourSearchCondition.IsLandOnly = true;
        }
        tourSearchCondition.TravelBeginDate = GlobalUtility.GetDateTime(tourDeptCalendar.CDate.Trim());

        switch (ddlTravelDate.SelectedIndex)
        {
            case 0: tourSearchCondition.TravelDaysFrom = 1;
                tourSearchCondition.TravelDaysTo = 10;
                break;
            case 1: tourSearchCondition.TravelDaysFrom = 11;
                tourSearchCondition.TravelDaysTo = 15;
                break;
            case 2: tourSearchCondition.TravelDaysFrom = 16;
                tourSearchCondition.TravelDaysTo = 800;
                break;
            default:
                tourSearchCondition.TravelDaysFrom = 1;
                tourSearchCondition.TravelDaysTo = 800;
                break;
        }
        this.Transaction.IntKey = tourSearchCondition.GetHashCode();
        this.Transaction.CurrentSearchConditions = tourSearchCondition;
        this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
        Utility.IsTourMain = false;//设置是否是Tour标志
        Utility.IsTourMore = false;//设置是否是Tour More

        //log
        PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >Redirect to Searching1.aspx at: " + System.DateTime.Now);

        this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlDecode(tourSearchCondition.Region) + "&target=~/Page/Tour/TourMoreSearchResultForm" + "&ConditionID=" + Utility.Transaction.IntKey.ToString());
    }

    private void SetPageValidationGroup()
    {
        this.btnSearch_t.ValidationGroup = "TourOnlySearch";

        ((TextBox)this.tourDeptCalendar.FindControl("calendarDate")).CssClass = "search_inp";


        if (!IsSearchConditionNull)
        {
            BindHotelSearchCondition();

        }
        else
        {
            ((TextBox)tourDeptCalendar.FindControl("calendarDate")).Text = DateTime.Now.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
        }
    }

    private void BindHotelSearchCondition()
    {
        if (this.Transaction == null) return;
        if (this.Transaction.CurrentSearchConditions == null) return;
        if ((this.Transaction.CurrentSearchConditions is HotelSearchCondition) == false) return;

        if (this.Transaction.CurrentSearchConditions is TourSearchCondition)
        {
            TourSearchCondition tourSearchCondition = (TourSearchCondition)this.Transaction.CurrentSearchConditions;
            TextBox tourDeptCalendar = (TextBox)this.tourDeptCalendar.FindControl("calendarDate");

            tourDeptCalendar.Text = tourSearchCondition.TravelBeginDate.ToString("d", DateTimeFormatInfo.InvariantInfo);

            cddArea.SelectedValue = tourSearchCondition.Region;
            cddCountry.SelectedValue = tourSearchCondition.Counrty;

            cddCity.SelectedValue = tourSearchCondition.City;
        }
    }
}
