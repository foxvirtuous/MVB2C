using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Terms.Product.Domain;
using TERMS.Business.Centers.ProductCenter.Components;
    public class SessionClass
    {
        private Hashtable secondSearchResults = new Hashtable();

        private Itinerary currentItinerary = new Itinerary();

        private BookingManage bookingManage = new BookingManage();

        private int originalIndex = 0;

        private IList fromAirports = null;

        private IList toAirports = null;

        private IList returnFromAirports = null;

        private IList returnToAirports = null;

        private string fromCityName = string.Empty;

        private string toCityName = string.Empty;

        private string returnFromCityName = string.Empty;

        private string returnToCityName = string.Empty;

        private bool isRealFromCity = true;

        private bool isRealToCity = true;

        private bool isRealReturnFromCity = true;

        private bool isRealReturnToCity = true;

       
       

        public Hashtable SecondSearchResults
        {
            get
            {
                return secondSearchResults;
            }
            set
            {
                secondSearchResults = value;
            }
        }

      

        public Itinerary CurrentItinerary
        {
            get
            {
                return currentItinerary;
            }
            set
            {
                currentItinerary = value;
            }
        }

        public int OriginalIndex
        {
            get
            {
                return originalIndex;
            }
            set
            {
                originalIndex = value;
            }
        }

        public BookingManage BookingManage
        {
            get
            {
                return bookingManage;
            }
            set
            {
                bookingManage = value;
            }
        }


        public IList FromAirports
        {
            get
            {
                return fromAirports;
            }
            set
            {
                fromAirports = value;
            }
        }

        public IList ToAirports
        {
            get
            {
                return toAirports;
            }
            set
            {
                toAirports = value;
            }
        }

        public IList ReturnFromAirports
        {
            get
            {
                return returnFromAirports;
            }
            set
            {
                returnFromAirports = value;
            }
        }

        public IList ReturnToAirports
        {
            get
            {
                return returnToAirports;
            }
            set
            {
                returnToAirports = value;
            }
        }

        public string FromCityName
        {
            get
            {
                return fromCityName;
            }
            set
            {
                fromCityName = value;
            }
        }

        public string ToCityName
        {
            get
            {
                return toCityName;
            }
            set
            {
                toCityName = value;
            }
        }

        public string ReturnFromCityName
        {
            get
            {
                return returnFromCityName;
            }
            set
            {
                returnFromCityName = value;
            }
        }

        public string ReturnToCityName
        {
            get
            {
                return returnToCityName;
            }
            set
            {
                returnToCityName = value;
            }
        }


        public bool IsRealFromCity
        {
            get
            {
                return isRealFromCity;
            }
            set
            {
                isRealFromCity = value;
            }
        }

        public bool IsRealToCity
        {
            get
            {
                return isRealToCity;
            }
            set
            {
                isRealToCity = value;
            }
        }

        public bool IsRealReturnFromCity
        {
            get
            {
                return isRealReturnFromCity;
            }
            set
            {
                isRealReturnFromCity = value;
            }
        }

        public bool IsRealReturnToCity
        {
            get
            {
                return isRealReturnToCity;
            }
            set
            {
                isRealReturnToCity = value;
            }
        }
    }
   

    
