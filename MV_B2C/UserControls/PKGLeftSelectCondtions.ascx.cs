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

public partial class PKGLeftSelectCondtions : SalesBaseUserControl
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

    public string ReturnURL
    {
        set
        {
            this.ChangeTravelersControl1.ReturnURL = value;
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

    public PKGLeftSelectCondtions()
    {
        this.InitializeControls += new EventHandler(PKGLeftSelectCondtions_InitializeControls);  
    }

    private void PKGLeftSelectCondtions_InitializeControls(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();

        if (!IsPostBack)
        {
            dateDeparture.IsCoercion = true;
            dateDeparture.CoercionID = "dateReturn";
            dateCheckIn.IsCoercion = true;
            dateCheckIn.CoercionID = "dateCheckOut";

            //设置查询条件
            dateDeparture.BeginDate = DateTime.Now.AddDays(7);
            dateReturn.BeginDate = DateTime.Now.AddDays(7);
            dateCheckIn.BeginDate = DateTime.Now.AddDays(7);
            dateCheckOut.BeginDate = DateTime.Now.AddDays(7);
        }

        SetCondition();
    }

    private void SetCondition()
    {
        this.dateDeparture.Path = this.dateReturn.Path = this.dateCheckIn.Path = this.dateCheckOut.Path= "../../";
    }

    protected void imgSearch_Click(object sender, EventArgs e)
    {
        //注意，在这里需要添加验证输入内容的代码！！！
        lblError.Visible = false;

        if (txtFrom.Text.Trim().Length == 0)
        {
            lblError.Visible = true;
            lblError.Text = "Please input From";
            return;
        }

        if (txtTo.Text.Trim().Length == 0)
        {
            lblError.Visible = true;
            lblError.Text = "Please input To";
            return;
        }

        txtFrom.Text = ConvertName(txtFrom.Text);
        txtTo.Text = ConvertName(txtTo.Text);

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

        Session["CurrentSession"] = new SessionClass();
        SessionClass scAH = (SessionClass)Session["CurrentSession"];

        scAH.FromCityName = txtFrom.Text;
        scAH.ToCityName = txtTo.Text;

        Session["CurrentSession"] = scAH;

        if (PacakgeSearch.DestinationAirPorts.Count > 0 && PacakgeSearch.DepatrueAirPorts.Count > 0)
        {
            PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateCheckIn.CDate);
            PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateCheckOut.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[0].Departure = (Airport)PacakgeSearch.DepatrueAirPorts[0];
            PacakgeSearch.AirSearchCondition.AirTripCondition[0].DepartureDate = Convert.ToDateTime(this.dateDeparture.CDate);            

            PacakgeSearch.AirSearchCondition.AirTripCondition[1].Destination = (Airport)PacakgeSearch.DepatrueAirPorts[0];

            PacakgeSearch.AirSearchCondition.AirTripCondition[1].Departure = (Airport)PacakgeSearch.DestinationAirPorts[0];
            PacakgeSearch.AirSearchCondition.AirTripCondition[1].DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[0].Destination = (Airport)PacakgeSearch.DestinationAirPorts[0];

            PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
            PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).CityCode; ;
            PacakgeSearch.HotelSearchCondition.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Country.Code; 

        }
        else if(PacakgeSearch.DestinationAirPorts.Count > 0 && PacakgeSearch.DepatrueAirPorts.Count <= 0)
        {
            PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateCheckIn.CDate);
            PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateCheckOut.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[0].Departure = new Airport();
            PacakgeSearch.AirSearchCondition.AirTripCondition[0].DepartureDate = Convert.ToDateTime(this.dateDeparture.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[1].Destination = new Airport();

            PacakgeSearch.AirSearchCondition.AirTripCondition[1].Departure = (Airport)PacakgeSearch.DestinationAirPorts[0];
            PacakgeSearch.AirSearchCondition.AirTripCondition[1].DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[0].Destination = (Airport)PacakgeSearch.DestinationAirPorts[0];

            PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
            PacakgeSearch.HotelSearchCondition.Location = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).CityCode; 
            PacakgeSearch.HotelSearchCondition.Country = ((Terms.Common.Domain.Airport)PacakgeSearch.DestinationAirPorts[0]).City.Country.Code; 
        }
        else if (PacakgeSearch.DestinationAirPorts.Count <= 0 && PacakgeSearch.DepatrueAirPorts.Count > 0)
        {
            PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateCheckIn.CDate);
            PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateCheckOut.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[0].Departure = (Airport)PacakgeSearch.DepatrueAirPorts[0];
            PacakgeSearch.AirSearchCondition.AirTripCondition[0].DepartureDate = Convert.ToDateTime(this.dateDeparture.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[1].Destination = (Airport)PacakgeSearch.DepatrueAirPorts[0];

            PacakgeSearch.AirSearchCondition.AirTripCondition[1].Departure = new Airport();
            PacakgeSearch.AirSearchCondition.AirTripCondition[1].DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[0].Destination = new Airport();

            PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
            PacakgeSearch.HotelSearchCondition.Location = "";
            PacakgeSearch.HotelSearchCondition.Country = ""; 
        }
        else
        { 
            PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateCheckIn.CDate);
            PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateCheckOut.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[0].Departure = new Airport();
            PacakgeSearch.AirSearchCondition.AirTripCondition[0].DepartureDate = Convert.ToDateTime(this.dateDeparture.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[1].Destination = new Airport();

            PacakgeSearch.AirSearchCondition.AirTripCondition[1].Departure = new Airport();
            PacakgeSearch.AirSearchCondition.AirTripCondition[1].DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);

            PacakgeSearch.AirSearchCondition.AirTripCondition[0].Destination = new Airport();

            PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
            PacakgeSearch.HotelSearchCondition.Location = "";
            PacakgeSearch.HotelSearchCondition.Country = ""; 
        }

        //记录Search Package事件
        if(Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchPackage, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchPackage, this);

        this.Page.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package2/ViewYourPackages" + "&ConditionID=" + Request.Params["ConditionID"]);

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

    private string ConvertName(string fullname)
    {
        int index = fullname.IndexOf("-");

        if (index > 0)
        {
            int end = fullname.Substring(index + 1).IndexOf(",");

            if (end > 0)
            {
                return fullname.Substring(index + 1, end).Trim();
            }
            else
            {
                return fullname.Substring(index + 1).Trim();
            }
        }
        else
        {
            return fullname.Trim();
        }
    }

}
