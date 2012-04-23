using System;
using System.Collections.Generic;
using System.Text;

using TERMS.Common;
using Terms.Sales.Business;


public class Itinerary
{
    private AirSearchCondition searchInfo;
    private TERMS.Common.Price fareInfo = new TERMS.Common.Price();
    
    private AirTrip flightInfo = new AirTrip();
    public AirSearchCondition SearchInfo
    {
        get
        {
            return searchInfo;
        }
        set
        {
            searchInfo = value;
        }
    }

    public TERMS.Common.Price FareInfo
    {
        get
        {
            return fareInfo;
        }
        set
        {
            fareInfo = value;
        }
    }

    public AirTrip FlightInfo
    {
        get
        {
            return flightInfo;
        }
        set
        {
            flightInfo = value;
        }
    }
}

