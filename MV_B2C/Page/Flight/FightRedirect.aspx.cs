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

using log4net;
using Spring.Web.UI;
using Terms.Sales.Business;
using TERMS.Common;
using System.Collections.Generic;
using Terms.Material.Service;
using Terms.Global.Utility;
using Terms.Sales.Service;
using Terms.Common.Service;
using System.Globalization;

public partial class FightRedirect : SalseBasePage
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

    private ICommonService _CommonService;

    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    public FightRedirect()
    {
        this.InitializeControls += new EventHandler(FightRedirect_InitializeControls);
    }

    void FightRedirect_InitializeControls(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateCondition();

        }
    }

    private void CreateCondition()
    {
        bool IsSelectAirport = false;
        bool IsRealCity = true;
        Session["CurrentSession"] = new SessionClass();
        SessionClass sc = (SessionClass)Session["CurrentSession"];

        AirSearchCondition airSearchCondition = new AirSearchCondition();

        airSearchCondition.SetPassengerNumber(PassengerType.Adult, Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Adults"]));

        CabinType cabin = new CabinType();
        cabin = CabinType.All;

        airSearchCondition.SetPassengerNumber(PassengerType.Child, Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Childs"]));

        airSearchCondition.FlightType = "roundtrip";

        airSearchCondition.FlexibleDays = 0;

        AirTripCondition deptCondition = new AirTripCondition();
        deptCondition.Cabin = cabin;

        string depCity = "";

        sc.FromCityName = depCity;

        if (depCity.Length > 3)
        {
            IList departureAirPorts = _CommonService.FindAirportByCityName(depCity);

            if (departureAirPorts.Count > 1)
            {
                IsSelectAirport = true;
                sc.FromAirports = departureAirPorts;
            }
            else if (departureAirPorts.Count == 1)
            {
                deptCondition.Departure = (Terms.Common.Domain.Airport)departureAirPorts[0];
            }
            else
            {

                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(depCity, airportList);
                if (airport != null)
                    deptCondition.Departure = airport;
                else
                    sc.IsRealFromCity = IsRealCity = false;
            }

        }
        else
        {
            deptCondition.Departure = AirService.CommAirportDao.FindByAirport(depCity.Trim());

            if (deptCondition.Departure == null)
            {
                deptCondition.Departure = new Terms.Common.Domain.Airport();
                deptCondition.Departure.Code = depCity;
            }
        }

        deptCondition.DepartureDate = GlobalUtility.GetDateTime(DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo));

        string toCity = this.Request["ToCity"];

        sc.ToCityName = toCity;
        if (toCity.Length > 3)
        {
            IList destinationAirPorts = _CommonService.FindAirportByCityName(toCity);

            if (destinationAirPorts.Count > 1)
            {
                IsSelectAirport = true;
                sc.ToAirports = destinationAirPorts;
            }
            else if (destinationAirPorts.Count == 1)
            {
                deptCondition.Destination = (Terms.Common.Domain.Airport)destinationAirPorts[0];
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(toCity, airportList);
                if (airport != null)
                    deptCondition.Destination = airport;
                else
                    sc.IsRealToCity = IsRealCity = false;
            }

        }
        else
        {
            deptCondition.Destination = AirService.CommAirportDao.FindByAirport(toCity);

            if (deptCondition.Destination == null)
            {
                deptCondition.Destination = new Terms.Common.Domain.Airport();
                deptCondition.Destination.Code = toCity;
            }
        }

        AirTripCondition rtnCondition = new AirTripCondition();
        rtnCondition.Cabin = cabin;

        rtnCondition.Departure = deptCondition.Destination;
        rtnCondition.Destination = deptCondition.Departure;
        rtnCondition.DepartureDate = GlobalUtility.GetDateTime(DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo));

        airSearchCondition.AddTripCondition(deptCondition);
        airSearchCondition.AddTripCondition(rtnCondition);

        sc.CurrentItinerary.SearchInfo = airSearchCondition;
        this.Transaction.CurrentSearchConditions = airSearchCondition;
        this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

        if (!IsRealCity)
        {
            Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?TYPE=Promos");
        }

        Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?TYPE=Promos");
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
