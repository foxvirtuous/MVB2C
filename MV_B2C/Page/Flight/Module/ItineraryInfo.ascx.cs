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
using Terms.Product.Utility;
using Terms.Product.Domain;
using Terms.Base.Utility;
public partial class ItineraryInfo : System.Web.UI.UserControl
{

    private Itinerary m_itinerary = null;
    public Itinerary Itinerary
    {
        set
        {
            m_itinerary = value;
        }
    }

    private bool m_isShowFareDetail = false;
    private bool m_isShowFlightInfo = false;
    public bool IsShowFareDetail
    {
        set
        {
            m_isShowFareDetail = value;
        }
    }

    public bool IsShowFlightInfo
    {
        set
        {
            m_isShowFlightInfo = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            phFareDetail.Visible = m_isShowFareDetail;
            phFlightInfo.Visible = m_isShowFlightInfo;
            InitPage();
        }
    }

    protected void InitPage()
    {
        if (m_itinerary != null)
        {
            if (m_itinerary.SearchInfo != null)
            {
                lbl_DepartureCity.Text = m_itinerary.SearchInfo.AirTripCondition[0].Departure.City.Name + "&nbsp;(" + m_itinerary.SearchInfo.AirTripCondition[0].Departure.Name + ")";
                lbl_DestinationCity.Text = m_itinerary.SearchInfo.AirTripCondition[0].Destination.City.Name + "&nbsp;(" + m_itinerary.SearchInfo.AirTripCondition[0].Destination.Name + ")";
                lbl_DepartureDate.Text = m_itinerary.SearchInfo.AirTripCondition[0].DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                if (m_itinerary.SearchInfo.FlightType != "oneway")
                {

                    lbl_ArrivalDate.Text = m_itinerary.SearchInfo.AirTripCondition[1].DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    lbl_ReturnFromCity.Text = m_itinerary.SearchInfo.AirTripCondition[1].Departure.City.Name + "&nbsp;(" + m_itinerary.SearchInfo.AirTripCondition[1].Departure.Name + ")";
                    lbl_ReturnToCity.Text = m_itinerary.SearchInfo.AirTripCondition[1].Destination.City.Name + "&nbsp;(" + m_itinerary.SearchInfo.AirTripCondition[1].Destination.Name + ")";
                    phRtnInfo.Visible = true;
                }
                else
                {
                    phRtnInfo.Visible = false;
                }

            }

            if (m_isShowFareDetail && m_itinerary.FareInfo != null)
            {
                lbl_AdultFare.Text = (m_itinerary.FareInfo.GetBase(TERMS.Common.PassengerType.Adult) + m_itinerary.FareInfo.GetMarkup(TERMS.Common.PassengerType.Adult)).ToString("N"); ;
                if (m_itinerary.FareInfo.GetBase(TERMS.Common.PassengerType.Child) > 0)
                    lbl_ChildFare.Text = (m_itinerary.FareInfo.GetBase(TERMS.Common.PassengerType.Child) + m_itinerary.FareInfo.GetMarkup(TERMS.Common.PassengerType.Child)).ToString("N");
                //lbl_InfantFare.Text = m_itinerary.FareInfo.InfantFare.ToString("N");
                //lbl_AdultNum.Text = m_itinerary.SearchInfo.GetPassengerNumber(PassengerType.Adult).ToString();
                //lbl_ChildNum.Text = m_itinerary.SearchInfo.GetPassengerNumber(PassengerType.Child).ToString();
                //lbl_InfantNum.Text = m_itinerary.SearchInfo.GetPassengerNumber(PassengerType.Infant).ToString();
                lbl_AdultNum.Text = "Tax not include";
                lbl_ChildNum.Text = "Tax not include";
                //lbl_InfantNum.Text = "Tax not include";

            }

            //if (m_isShowFlightInfo && m_itinerary.FlightInfo != null)
            //{
            //    IList<AirLeg> flights = new List<AirLeg>();
            //    foreach (SubAirTrip subAirTrip in m_itinerary.FlightInfo.SubTrips)
            //    {
            //        foreach (AirLeg airLeg in subAirTrip.Flights)
            //        {
            //            flights.Add(airLeg);
            //        }
            //    }
            //    dlFlights.DataSource = flights;
            //    dlFlights.DataBind();
            //}

        }

    }
}
