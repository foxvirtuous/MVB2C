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
using System.Collections.Generic;
using Terms.Common.Service;
using Terms.Common.Domain;
using System.Globalization;
using Terms.Material.Service;

public partial class PackageRedirect : SalseBasePage
{
    private ICommonService _CommonService;

    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

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

    public PackageRedirect()
    {
        this.InitializeControls += new EventHandler(PackageRedirect_InitializeControls);
    }

    void PackageRedirect_InitializeControls(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateCondition();
        }
    }

    private void CreateCondition()
    {
        if (Utility.Transaction.CurrentTransactionObject != null)
        {
            Utility.Transaction.CurrentTransactionObject = null;
        }
        if (this.Transaction.CurrentSearchConditions != null)
        {
            this.Transaction.CurrentSearchConditions = null;
        }
        if (Session["CurrentSession"] != null)
        {
            Session["CurrentSession"] = null;
        }

        string FromCity = "";
        string ToCity = this.Request["ToCity"];
        PackageSearchCondition PacakgeSearch = new PackageSearchCondition();
        PacakgeSearch.IsReset = true;
        IList departureAirPorts = _CommonService.FindAirportByCityName(FromCity);
        PacakgeSearch.DepatrueAirPorts = departureAirPorts;

        Terms.Common.Domain.Airport airport = AirService.CommAirportDao.FindByAirport(ToCity);

        if (airport != null)
        {
            PacakgeSearch.DestinationAirPorts = new List<Terms.Common.Domain.Airport>();
            PacakgeSearch.DestinationAirPorts.Add(airport);
        }
        else
        {

        }
        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Adult, Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Adults"]));
        PacakgeSearch.AirSearchCondition.SetPassengerNumber(TERMS.Common.PassengerType.Child, Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Childs"]));

        RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

        roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Adult, Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Adults"]));
        roomSearchCondition.Passengers.Add(TERMS.Common.PassengerType.Child, Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Childs"]));

        PacakgeSearch.HotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);

        if (PacakgeSearch.DestinationAirPorts != null && PacakgeSearch.DestinationAirPorts.Count > 0 || PacakgeSearch.DepatrueAirPorts.Count > 0)
        {
            PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo)).AddDays(1);
            PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo));
            PacakgeSearch.HotelSearchCondition.Location = ((Airport)PacakgeSearch.DestinationAirPorts[0]).CityCode; // "PVG";
            PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
            PacakgeSearch.HotelSearchCondition.Country = ((Airport)PacakgeSearch.DestinationAirPorts[0]).City.CountryCode;

            AirTripCondition DPTairTripCondition = new AirTripCondition();
            DPTairTripCondition.Departure = new Airport();
            DPTairTripCondition.DepartureDate = Convert.ToDateTime(DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo));
            DPTairTripCondition.Destination = (Airport)PacakgeSearch.DestinationAirPorts[0];
            DPTairTripCondition.IsDepartureTimeSpecified = false;
            PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
            PacakgeSearch.AirSearchCondition.Airlines = null;
            AirTripCondition RTNairTripCondition = new AirTripCondition();
            RTNairTripCondition.Departure = (Airport)PacakgeSearch.DestinationAirPorts[0];
            RTNairTripCondition.DepartureDate = Convert.ToDateTime(DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo));
            RTNairTripCondition.Destination = new Airport();
            RTNairTripCondition.IsDepartureTimeSpecified = false;
            PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);
            PacakgeSearch.AirSearchCondition.FlightType = "roundtrip";
            this.Transaction.CurrentSearchConditions = PacakgeSearch;
            this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

            this.Page.Response.Redirect("~/Page/Package2/SearchConditionsMeassageAHForm.aspx?TYPE=Promos");

        }
        else
        {
            PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo)).AddDays(1);
            PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo));

            AirTripCondition DPTairTripCondition = new AirTripCondition();
            DPTairTripCondition.Departure = new Airport();
            DPTairTripCondition.DepartureDate = Convert.ToDateTime(DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo));
            DPTairTripCondition.IsDepartureTimeSpecified = false;
            PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
            PacakgeSearch.AirSearchCondition.Airlines = null;
            AirTripCondition RTNairTripCondition = new AirTripCondition();
            RTNairTripCondition.DepartureDate = Convert.ToDateTime(DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo));
            RTNairTripCondition.Destination = new Airport();
            RTNairTripCondition.IsDepartureTimeSpecified = false;
            PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);
            PacakgeSearch.AirSearchCondition.FlightType = "roundtrip";
            this.Transaction.CurrentSearchConditions = PacakgeSearch;
            this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

            this.Page.Response.Redirect("~/Page/Package2/SearchConditionsMeassageAHForm.aspx?TYPE=Promos");


        }
    }

    private List<int> UnConvert(string p)
    {
        List<int> list = new List<int>();

        string[] temps = p.Split(new char[] { ',' } , StringSplitOptions.RemoveEmptyEntries);

        if (temps != null && temps.Length > 0)
        {
            for (int i = 0; i < temps.Length; i++)
            {
                list.Add(Convert.ToInt32(temps[i]));
            }
        }

        return list;
    }
}
