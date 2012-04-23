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

using Terms.Sales.Domain;
using Terms.Sales.Service;
using Terms.Sales.Dao;
using Terms.Sales.Utility;
using Terms.Common.Service;
using Terms.Common.Domain;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using Terms.Material.Service;
using System.Collections.Generic;

public partial class PackageLeftSelect : SalesBaseUserControl
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

    private IApplicationCacheFoundationDate _ApplicationCacheFoundationDate;
    public IApplicationCacheFoundationDate ApplicationCacheFoundationDate
    {
        set
        {
            this._ApplicationCacheFoundationDate = value;
        }
    }

  
    private ISaleMerchandiseSearcherService _SaleMerchandsiseSearcherService;
    public ISaleMerchandiseSearcherService SaleMerchandiseSearcherService
    {
        set { _SaleMerchandsiseSearcherService = value; }
    }
    private ICommonService _commonService;
    public ICommonService CommonService
    {
        set
        {
            _commonService = value;
        }
    }
    private PackageSearchCondition _packageSearchCondition;
    public PackageSearchCondition PackageSearchCondition
    {
        get
        {
            if (_packageSearchCondition == null)
            {
                _packageSearchCondition = new PackageSearchCondition();
            }
            return _packageSearchCondition;
        }
        set
        {
            _packageSearchCondition = value;
        }
    }


    public string From
    {
        get { return this.txtFrom.Text.Trim(); }
        set {// this.txtFrom.City = value; 
            this.txtFrom.Text = value;
        }
    }

    public string To
    {
        get { return this.txtTo.Text.Trim(); }
        set { //this.txtTo.City = value; 
            this.txtTo.Text = value;
        }
    }

    public DateTime DepartureDate
    {
        get { return Convert.ToDateTime(this.dateDeparture.CDate); }
        set { ((TextBox)this.dateDeparture.FindControl("calendarDate")).Text = value.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo); }
    }

    public DateTime ReturnDate
    {
        get { return Convert.ToDateTime(this.dateReturn.CDate); }
        set { ((TextBox)this.dateReturn.FindControl("calendarDate")).Text = value.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo); }
    }

    public DateTime CheckInDate
    {
        get { return Convert.ToDateTime(this.dateCheckIn.CDate); }
        set { ((TextBox)this.dateCheckIn.FindControl("calendarDate")).Text = value.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo); }
    }

    public DateTime CheckOutDate
    {
        get { return Convert.ToDateTime(this.dateCheckOut.CDate); }
        set { ((TextBox)this.dateCheckOut.FindControl("calendarDate")).Text = value.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo); }
    }

    public PackageLeftSelect()
    {
        this.InitializeControls += new EventHandler(PackageLeftSelect_InitializeControls);  
    }

    private void PackageLeftSelect_InitializeControls(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();

        if (!IsPostBack)
        {
            txtFrom.CssClass = "search_inp";
            txtTo.CssClass = "search_inp";

            dateDeparture.IsCoercion = true;
            dateDeparture.CoercionID = "dateReturn";
            dateCheckIn.IsCoercion = true;
            dateCheckIn.CoercionID = "dateCheckOut";

            //设置查询条件
            SetCondition();

            dateDeparture.BeginDate = DateTime.Now.AddDays(7);
            dateReturn.BeginDate = DateTime.Now.AddDays(7);
            dateCheckIn.BeginDate = DateTime.Now.AddDays(7);
            dateCheckOut.BeginDate = DateTime.Now.AddDays(7);
        }
    }

    private void SetCondition()
    {
        this.dateDeparture.Path = this.dateReturn.Path = this.dateCheckIn.Path = this.dateCheckOut.Path= "../../";
        //this.txtFrom.Text = PackageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.City.Name;
        //this.txtTo.Text = PackageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.City.Name;
        //this.dateDeparture.CDate = PackageSearchCondition.AirSearchCondition.AirTripCondition[0].DepartureDate.ToString();
        //this.dateReturn.CDate = PackageSearchCondition.AirSearchCondition.AirTripCondition[1].DepartureDate.ToString();
    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        //注意，在这里需要添加验证输入内容的代码！！！

        PackageSearchCondition PacakgeSearch = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;
        PacakgeSearch.OptionalHotelSearchConditions.Clear();
        PacakgeSearch.IsReset = true;

        PacakgeSearch.DepatrueAirPorts = new List<Terms.Common.Domain.Airport>();
        if (txtFrom.Text.Trim().Length > 3)
        {
            IList departureAirPorts = _commonService.FindAirportByCityName(txtFrom.Text.Trim());

            if (departureAirPorts.Count >= 1)
            {
                PacakgeSearch.DepatrueAirPorts = departureAirPorts;
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(txtFrom.Text.Trim(), airportList);
                if (airport != null)
                {
                    PacakgeSearch.DepatrueAirPorts.Add(airport);
                }
            }
        }
        else
        {
            //PacakgeSearch.DepatrueAirPorts.Add(AirService.CommAirportDao.FindByAirport(txtDepartureFrom.City.Trim()));
            Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(txtFrom.Text.Trim());

            if (airport != null)
            {
                PacakgeSearch.DepatrueAirPorts.Add(airport);
            }
            else
            {
                IList departureAirPorts = AirService.CommAirportDao.FindByCityCode(txtFrom.Text.Trim());

                if (departureAirPorts.Count >= 1)
                {
                    PacakgeSearch.DepatrueAirPorts = departureAirPorts;
                }
            }
        }

        PacakgeSearch.DestinationAirPorts = new List<Terms.Common.Domain.Airport>();
        if (txtTo.Text.Trim().Length > 3)
        {
            IList ReturnAirPorts = _commonService.FindAirportByCityName(txtTo.Text.Trim());

            if (ReturnAirPorts.Count >= 1)
            {
                PacakgeSearch.DestinationAirPorts = ReturnAirPorts;
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(txtTo.Text.Trim(), airportList);
                if (airport != null)
                {
                    PacakgeSearch.DestinationAirPorts.Add(airport);
                }
            }
        }
        else
        {
            Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(txtTo.Text.Trim());

            if (airport != null)
            {
                PacakgeSearch.DestinationAirPorts.Add(airport);
            }
            else
            {
                IList ReturnAirPorts = AirService.CommAirportDao.FindByCityCode(txtTo.Text.Trim());

                if (ReturnAirPorts.Count >= 1)
                {
                    PacakgeSearch.DestinationAirPorts = ReturnAirPorts;
                }
            }
        }

        Utility.IsTourMain = false;//设置是否是Tour标志

        //IList departureAirPorts = _commonService.FindAirportByCityName(this.txtFrom.Text);
        //PacakgeSearch.DepatrueAirPorts = departureAirPorts;
        //IList ReturnAirPorts = _commonService.FindAirportByCityName(this.txtTo.Text);
        //PacakgeSearch.DestinationAirPorts = ReturnAirPorts;
        if (PacakgeSearch.DestinationAirPorts.Count > 0 || PacakgeSearch.DepatrueAirPorts.Count > 0)
        {
            //每次Research后，时间应该按照页面输入的内容更新
            PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateCheckIn.CDate);
            PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateCheckOut.CDate);

            

            if (PacakgeSearch.DestinationAirPorts.Count > 1 || PacakgeSearch.DepatrueAirPorts.Count > 1)
            {
                PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
                PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).CityCode; ;
                PacakgeSearch.HotelSearchCondition.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Country.Code; 
                //this.Transaction.CurrentSearchConditions = PacakgeSearch;
                if(PacakgeSearch.HotelSearchCondition2 != null)
                    this.Page.Response.Redirect("~/Page/Package/PackageSearch2dForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
                else
                    this.Page.Response.Redirect("~/Page/Package/PackageSearchMoreForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
            }
            else
            {
                //以下的代码貌似无法处理owe way和Open Jaw的情况
                PacakgeSearch.AirSearchCondition.AirTripCondition[0].Departure = (Airport)PacakgeSearch.DepatrueAirPorts[0];
                PacakgeSearch.AirSearchCondition.AirTripCondition[0].DepartureDate = Convert.ToDateTime(this.dateDeparture.CDate);
                PacakgeSearch.AirSearchCondition.AirTripCondition[0].Destination = (Airport)PacakgeSearch.DestinationAirPorts[0];

                PacakgeSearch.AirSearchCondition.AirTripCondition[1].Departure = (Airport)PacakgeSearch.DestinationAirPorts[0];
                PacakgeSearch.AirSearchCondition.AirTripCondition[1].DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);
                PacakgeSearch.AirSearchCondition.AirTripCondition[1].Destination = (Airport)PacakgeSearch.DepatrueAirPorts[0];

                PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
                PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).CityCode; ;
                PacakgeSearch.HotelSearchCondition.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Country.Code; 

                //以下的代码每次都会添加两个AirTripCondition，但是Research时，真正起作用的是PacakgeSearch.AirSearchCondition中的第1、2个AirTripCondition
                //也就是说，每次修改Research中时间是不起任何作用的
                //AirTripCondition DPTairTripCondition = new AirTripCondition();
                //DPTairTripCondition.Departure = (Airport)PacakgeSearch.DepatrueAirPorts[0];
                //DPTairTripCondition.DepartureDate = Convert.ToDateTime(this.dateDeparture.CDate);
                //DPTairTripCondition.Destination = (Airport)PacakgeSearch.DestinationAirPorts[0];
                //PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);

                //AirTripCondition RTNairTripCondition = new AirTripCondition();
                //RTNairTripCondition.Departure = (Airport)PacakgeSearch.DestinationAirPorts[0];
                //RTNairTripCondition.DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);
                //RTNairTripCondition.Destination = (Airport)PacakgeSearch.DepatrueAirPorts[0];
                //PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);
                //this.Transaction.CurrentSearchConditions = PacakgeSearch;
            }
        }
        //记录Search Package事件
        if(Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchPackage, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchPackage, this);

        this.Page.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package/PackageSearchResultForm" + "&ConditionID=" + Request.Params["ConditionID"]);

    }

    private Terms.Common.Domain.Airport MatchAirport(string AirportName, List<Terms.Common.Domain.Airport> AirportList)
    {
        foreach (Terms.Common.Domain.Airport airport in AirportList)
        {
            if (airport.Name.Equals(AirportName))
                return airport;
        }
        return null;
    }
}
