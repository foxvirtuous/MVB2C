using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common.Search;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Product.Business;
using TERMS.Business.Centers.ProductCenter.Search;
using TERMS.Business.Centers.ProductCenter.Profiles;
using Terms.Common.Dao;
using Terms.Common.Domain;
using Terms.Sales.Business;
using Spring.Context.Support;
using TERMS.Core.Product;
using TERMS.Core.Profiles;
using Terms.Global.Domain;
using TurboTT.Security;
using System.Threading;
using System.IO;

/// <summary>
/// Summary description for MVMerchandiseSearcher
/// </summary>
public class MVMerchandiseSearcher
{
    //记录Air Search时间的日志对象
    private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger("AirSearchTime");

    private static readonly log4net.ILog hotelLog =
         log4net.LogManager.GetLogger("HotelSearchTime");

    private static readonly log4net.ILog hotelSearchHotelByZyl =
         log4net.LogManager.GetLogger("HotelSearchPerformanceDebugging");

    private string m_LogRandomID = string.Empty;
    public string LogRandomID
    {
        get { return m_LogRandomID; }
        set { m_LogRandomID = value; }
    }

    private string m_Error;

    public string Errors
    {
        get { return m_Error; }
    }

    private ICityDao m_commcityDao = null;
    /// <summary>
    /// 对城市的数据访问对象
    /// </summary>
    public ICityDao CommCityDao
    {
        get
        {
            if (m_commcityDao == null)
                m_commcityDao = ContextRegistry.GetContext()["CityDao"] as ICityDao;

            return m_commcityDao;
        }

    }

    private UserInfo userInfo = null;
    private UserInfo UserInfo
    {
        get
        {

            if (Utility.IsSubAgent)
            {
                userInfo = new Terms.Security.Business.UserManager().GetUserInfo("MVSUBAGENT", "MVSUBAGENT");
            }
            else
            {
                userInfo = new Terms.Security.Business.UserManager().GetUserInfo("MVSALES", "MVSALES");
            }


            return userInfo;
        }
    }

    public ComponentGroup Search(ISearchCondition searchCondition)
    {
        ComponentGroup result = null;

        //UserInfo == null代表无法判断要取发布给哪个网站的产品。所以作为没有查到商品处理
        hotelSearchHotelByZyl.Debug("Flag UserInfo Start :" + DateTime.Now.ToLongTimeString());
        if (UserInfo == null) return null;
        hotelSearchHotelByZyl.Debug("Flag UserInfo End :" + DateTime.Now.ToLongTimeString());

        if (searchCondition is Terms.Sales.Business.AirSearchCondition)
            result = SearchAir((Terms.Sales.Business.AirSearchCondition)searchCondition);
        else if (searchCondition is Terms.Sales.Business.HotelSearchCondition)
            result = SearchHotel((Terms.Sales.Business.HotelSearchCondition)searchCondition);
        else if (searchCondition is Terms.Sales.Business.PackageSearchCondition)
            result = SearchPackage((Terms.Sales.Business.PackageSearchCondition)searchCondition);
        else if (searchCondition is Terms.Sales.Business.VehcileSearchCondition)
            return SearchVehcile((Terms.Sales.Business.VehcileSearchCondition)searchCondition);

        return result;
    }

    public ComponentGroup Search(ISearchCondition searchCondition, string Language)
    {
        //UserInfo == null代表无法判断要取发布给哪个网站的产品。所以作为没有查到商品处理
        hotelSearchHotelByZyl.Debug("Flag UserInfo Start :" + DateTime.Now.ToLongTimeString());
        if (UserInfo == null) return null;
        hotelSearchHotelByZyl.Debug("Flag UserInfo End :" + DateTime.Now.ToLongTimeString());

        return SearchTour((Terms.Sales.Business.TourSearchCondition)searchCondition, Language);

    }

    public ComponentGroup TourSearch(string Language)
    {
        return SearchTour(Language);
    }

    public ComponentGroup TourSearch(ISearchCondition searchCondition, List<string> citys, string Language)
    {
        return SearchTour((Terms.Sales.Business.TourSearchCondition)searchCondition, citys, Language);
    }
       
    #region "Search Air"

    private AirMerchandise SearchAir(Terms.Sales.Business.AirSearchCondition searchCondition)
    {
        searchCondition.UserInfo = UserInfo;
        //bool isOpenCommNetFareTicket = false;
        bool isOpenAllFareTypeAir = false;
        bool isOnlyShowPubFareTicket = true;
        bool hasMajorAirlinesForAvailable = false;
        bool hasMajorAirlinesForSelect = false;
        bool isAvailableOnly = false;

        if (ConfigurationManager.AppSettings.Get("IsOpenAllFareTypeAir") != null)
            isOpenAllFareTypeAir = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsOpenAllFareTypeAir").ToString());

        if (ConfigurationManager.AppSettings.Get("IsOnlyShowPubFareTicket") != null)
            isOnlyShowPubFareTicket = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsOnlyShowPubFareTicket").ToString());

        if (ConfigurationManager.AppSettings.Get("HasMajorAirlinesForAvailable") != null)
            hasMajorAirlinesForAvailable = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HasMajorAirlinesForAvailable").ToString());

        if (ConfigurationManager.AppSettings.Get("HasMajorAirlinesForSelect") != null)
            hasMajorAirlinesForSelect = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HasMajorAirlinesForSelect").ToString());

        if (ConfigurationManager.AppSettings.Get("IsAvailableOnly") != null)
            isAvailableOnly = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsAvailableOnly").ToString());

        //by cjc, 暂时显示所有的机票

        searchCondition.IsLogin = Utility.IsLogin;


        //从Cache中查找结果
        AirMerchandise airMerchandise = (AirMerchandise)MVMerchandisePool.Find(searchCondition);

        if (airMerchandise == null)
        {
            DateTime SearchingBeginningTime = DateTime.Now;

            AirProductSearcher searcher = new AirProductSearcher();

            DateTime depDate = searchCondition.GetAddTripCondition()[0].DepartureDate;
            DateTime rtnDate = new DateTime();
            string fromAirportCode = searchCondition.GetAddTripCondition()[0].Departure.Code;
            string toAirportCode = searchCondition.GetAddTripCondition()[0].Destination.Code;
            string rtnFromAirportCode = string.Empty;
            string rtnToAirportCode = string.Empty;
            int adultNumber = searchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult);
            int childNumber = searchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);
            IList<AirProduct> airs = new List<AirProduct>();
            DateTime dtBeginTime = new DateTime();

            //log begin 20090312 Leon
            try
            {
                dtBeginTime = System.DateTime.Now;
                log.Info(m_LogRandomID + " >Search  From Terms Product Begin Start time : " + dtBeginTime);

                if (searchCondition.FlightType.ToLower().Equals("oneway"))
                    log.Info(m_LogRandomID + " >===================== OneWay =====================");
                else if (searchCondition.FlightType.ToLower().Equals("roundtrip"))
                    log.Info(m_LogRandomID + " >===================== Roundtrip =====================");
                else
                    log.Info(m_LogRandomID + " >===================== OpenJW =====================");
            }
            catch
            { }


            //转换查询条件
            TERMS.Common.Search.AirSearchCondition termsSearchCondition;

            if (searchCondition.FlightType.ToLower().Equals("oneway"))
            {          
                termsSearchCondition = new TERMS.Common.Search.AirSearchCondition(fromAirportCode, true, toAirportCode, true, depDate, true, adultNumber, childNumber, 0);
            }
            else if (searchCondition.FlightType.ToLower().Equals("roundtrip"))
            {
                rtnDate = searchCondition.GetAddTripCondition()[1].DepartureDate;
                termsSearchCondition = new TERMS.Common.Search.AirSearchCondition(fromAirportCode, true, toAirportCode, true, depDate, true, rtnDate, true, adultNumber, childNumber, 0);
            }
            else  //Open Jaw
            {
                rtnDate = searchCondition.GetAddTripCondition()[1].DepartureDate;
                rtnFromAirportCode = searchCondition.GetAddTripCondition()[1].Departure.Code;
                rtnToAirportCode = searchCondition.GetAddTripCondition()[1].Destination.Code;
                termsSearchCondition = new TERMS.Common.Search.AirSearchCondition(fromAirportCode, true, toAirportCode, true, depDate, true, rtnFromAirportCode, true, rtnToAirportCode, true, rtnDate, true, adultNumber, childNumber, 0);
            }


            //指定航空公司
            if (searchCondition.Airlines != null && searchCondition.Airlines.Length > 0)
                termsSearchCondition.AddAirlines(searchCondition.Airlines);

            //制定舱等
            for (int i = 0; i < termsSearchCondition.Trips.Count; i++)
                termsSearchCondition.Trips[i].Cabin = searchCondition.AirTripCondition[i].Cabin;


            //根据配置指定查询显示内容
            if (!isOpenAllFareTypeAir)
            {
                //if isOpenAllFareTypeAir is false ,  un-login condition come into effect.
                if (!Utility.IsLogin)
                {
                    termsSearchCondition.HasMajorAirlinesForAvailable = hasMajorAirlinesForAvailable;
                    termsSearchCondition.HasMajorAirlinesForSelect = hasMajorAirlinesForSelect;
                    termsSearchCondition.IsAvailableOnly = isAvailableOnly;

                    //if un-login and only show PUB fare
                    if (isOnlyShowPubFareTicket)
                    {
                        termsSearchCondition.HasMajorAirlinesForAvailable = true;
                        termsSearchCondition.HasMajorAirlinesForSelect = true;
                        termsSearchCondition.FareType = TERMS.Common.AirFareType.Published;
                        termsSearchCondition.IsAvailableOnly = true;
                    }
                    else
                    {
                        termsSearchCondition.FareType = TERMS.Common.AirFareType.All;
                    }
                }
                else
                {
                    //登录后显示所有机票内容
                    termsSearchCondition.HasMajorAirlinesForAvailable = true;
                    termsSearchCondition.HasMajorAirlinesForSelect = true;
                    termsSearchCondition.FareType = TERMS.Common.AirFareType.All;
                    termsSearchCondition.IsAvailableOnly = false;
                }
            }
            else
            {
                //显示所有机票内容
                termsSearchCondition.HasMajorAirlinesForAvailable = true;
                termsSearchCondition.HasMajorAirlinesForSelect = true;
                termsSearchCondition.FareType = TERMS.Common.AirFareType.All;
                termsSearchCondition.IsAvailableOnly = false;
            }


            //执行查询
            airs = searcher.Search(termsSearchCondition, UserInfo.Entity);


            log.Info(m_LogRandomID + " >Search From Terms Product End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtBeginTime)).ToString());
            dtBeginTime = System.DateTime.Now;

            if (airs.Count == 0 || airs[0].Items == null) return null;
            TERMS.Business.Centers.ProductCenter.Profiles.AirProfile oldProfile = (TERMS.Business.Centers.ProductCenter.Profiles.AirProfile)airs[0].Profile;
            oldProfile.SetParam("ADULT_NUMBER", adultNumber);
            oldProfile.SetParam("CHILD_NUMBER", childNumber);
            oldProfile.SetParam("IS_LOGIN", Utility.IsLogin);

            //log begin 20090312 Leon
            try
            {
                log.Info(m_LogRandomID + " >Become Merchandise Begin Begin Start time : " + dtBeginTime);

                if (airMerchandise != null && airMerchandise.Items != null)
                    log.Info(m_LogRandomID + " > " + airs[0].ItemGetter.Log.Text);
                else
                    log.Info(m_LogRandomID + " >No Result");

                log.Info(m_LogRandomID + " >Become Merchandise Begin End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtBeginTime)).ToString());
            }
            catch
            { }


            airMerchandise = new AirMerchandise(oldProfile, airs[0]);
            MVMerchandisePool.Cache(searchCondition.Clone(), airMerchandise); //Cache

            //记录Search时间
            DateTime SearchingEndingTime = DateTime.Now;
            SearchingLogger searchingLogger = new SearchingLogger();
            searchingLogger.Log(SearchingBeginningTime, SearchingEndingTime, searchCondition);
        }

        return airMerchandise;
    }

    #endregion

    #region "Search Hotel"

    private HotelMerchandise SearchHotel(Terms.Sales.Business.HotelSearchCondition searchCondition)
    {
        hotelSearchHotelByZyl.Debug("Hotel UserInfo Start :" + DateTime.Now.ToLongTimeString());
        searchCondition.UserInfo = UserInfo;
        hotelSearchHotelByZyl.Debug("Hotel UserInfo End :" + DateTime.Now.ToLongTimeString());

        //从Cache中查找结果
        HotelMerchandise hotelMerchandise = (HotelMerchandise)MVMerchandisePool.Find(searchCondition);

        if (hotelMerchandise == null)
        {
            DateTime SearchingBeginningTime = DateTime.Now;

            //log zyl
            hotelSearchHotelByZyl.Debug("Search Hotel Start :" + DateTime.Now.ToLongTimeString());

            TERMS.Common.Search.HotelSearchCondition termsHotelSC = ConvertHotelSearchCondition(searchCondition);

            DateTime dtBeginTime = new DateTime();

            //log begin 20090312 Leon
            dtBeginTime = System.DateTime.Now;
            hotelLog.Info(m_LogRandomID + " >Search From Terms Product Begin Start time : " + dtBeginTime);

            IList<HotelProduct> products = new List<HotelProduct>();

            //查询得到Hotel Product
            DateTime dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Debug("MV_B2C Hotel GetProductFrame Start :" + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);
            products = new TERMS.Business.Centers.ProductCenter.Search.HotelProductSearcher().Search(termsHotelSC, UserInfo.Entity);
            dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Debug("MV_B2C Hotel GetProductFrame Conclusion :" + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);

            //log
            hotelLog.Info(m_LogRandomID + " >Search From Terms Product End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtBeginTime)).ToString());
            dtBeginTime = System.DateTime.Now;
            hotelLog.Info(m_LogRandomID + " >TERMS Search hotel Begin time : " + dtBeginTime);

            HotelProduct hotelProduct = products[0];

            dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Debug("MV_B2C Hotel GetProductItems Start :" + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);
            IList<TERMS.Core.Product.Component> hotels = hotelProduct.Items;
            dtNow = DateTime.Now;
            hotelSearchHotelByZyl.Debug("MV_B2C Hotel GetProductItems Conclusion :" + dtNow.ToString("HH:mm:ss") + ":" + dtNow.Millisecond);
            if (hotels.Count == 0)
            {
                m_Error = "Searching is not available in Web Searching now. Please choose another travel date or destination.(h1)";
                return null;
            }


            //log begin 20090312 Leon
            try
            {
                if (hotelProduct.ItemGetter != null && hotelProduct.ItemGetter.Log != null)
                    hotelLog.Info(m_LogRandomID + " > " + hotelProduct.ItemGetter.Log.Text);

                hotelLog.Info(m_LogRandomID + " >TERMS Search hotel End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtBeginTime)).ToString());
                dtBeginTime = System.DateTime.Now;
                hotelLog.Info(m_LogRandomID + " >Create Hotel Merchandise Begin time : " + dtBeginTime);
            }
            catch
            { }

            //生成Hotel Merchandise
            TERMS.Business.Centers.SalesCenter.HotelProfile hotelProfile = new TERMS.Business.Centers.SalesCenter.HotelProfile("mv");
            hotelProfile.CheckInDate = searchCondition.CheckIn;
            hotelProfile.CheckOutDate = searchCondition.CheckOut;
            hotelProfile.Location = searchCondition.Location;

            hotelMerchandise = new HotelMerchandise(hotelProfile, hotelProduct);

            //log
            hotelLog.Info(m_LogRandomID + " >Create Hotel Merchandise End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtBeginTime)).ToString());

            if (hotelMerchandise == null || hotelMerchandise.Items == null || hotelMerchandise.Items.Count == 0)
            {
                m_Error = "Searching is not available in Web Searching now. Please choose another travel date or destination.(h1)";
                return null;
            }

            //log
            dtBeginTime = System.DateTime.Now;
            hotelLog.Info(m_LogRandomID + " >Convert Hotel to MV Hotel Begin time : " + dtBeginTime);

            hotelMerchandise = ConvertHotelToMVHotel(searchCondition, hotelMerchandise);

            //log
            hotelLog.Info(m_LogRandomID + " >Convert Hotel to MV Hotel End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtBeginTime)).ToString());

            if (hotelMerchandise == null || hotelMerchandise.Items == null || hotelMerchandise.Items.Count == 0)
            {
                m_Error = "Searching is not available in Web Searching now. Please choose another travel date or destination.(h1)";
                return null;
            }

            hotelSearchHotelByZyl.Info("MV_B2C Hotel Count :" + hotelMerchandise.Items.Count);

            MVMerchandisePool.Cache(searchCondition.Clone(), hotelMerchandise); //Cache

            hotelSearchHotelByZyl.Debug("Search Hotel End :" + DateTime.Now.ToLongTimeString());

            //记录Search时间
            DateTime SearchingEndingTime = DateTime.Now;
            SearchingLogger searchingLogger = new SearchingLogger();
            searchingLogger.Log(SearchingBeginningTime, SearchingEndingTime, searchCondition);
        }

        return hotelMerchandise;
        //return null;
    }

    private TERMS.Common.Search.HotelSearchCondition ConvertHotelSearchCondition(Terms.Sales.Business.HotelSearchCondition searchCondition)
    {
        hotelSearchHotelByZyl.Debug("UserInfo Start :" + DateTime.Now.ToLongTimeString());
        searchCondition.UserInfo = UserInfo;
        hotelSearchHotelByZyl.Debug("UserInfo End :" + DateTime.Now.ToLongTimeString());
        //转换Search条件
        List<TERMS.Common.Search.RoomCondition> termsRoomSCs = new List<TERMS.Common.Search.RoomCondition>();

        for (int i = 0; i < searchCondition.RoomSearchConditions.Count; i++)
        {
            Terms.Sales.Business.RoomSearchCondition mvRoomSC = searchCondition.RoomSearchConditions[i];
            TERMS.Common.Search.RoomCondition termsRoomSC;

            if (mvRoomSC.ChildNumber > 0)
            {
                List<DateTime> childrenBirthday = new List<DateTime>();

                for (int childIndex = 0; childIndex < mvRoomSC.ChildNumber; childIndex++)
                    childrenBirthday.Add(DateTime.Now.AddYears(-3));    //小孩默认为2岁

                termsRoomSC = new TERMS.Common.Search.RoomCondition(mvRoomSC.AdultNumber, mvRoomSC.ChildNumber, childrenBirthday.ToArray());
            }
            else
            {
                termsRoomSC = new TERMS.Common.Search.RoomCondition(mvRoomSC.AdultNumber, mvRoomSC.ChildNumber);
            }

            termsRoomSCs.Add(termsRoomSC);
        }

        TERMS.Common.Search.HotelSearchCondition termsHotelSC = new TERMS.Common.Search.HotelSearchCondition(
            searchCondition.Location, searchCondition.CheckIn, searchCondition.CheckOut, string.Empty, searchCondition.RoomSearchConditions.Count,
            termsRoomSCs.ToArray());

        City city = CommCityDao.FindCityByCode(searchCondition.Location);

        if (city != null)
        {
            termsHotelSC.Destination.CityCode_Travco = city.CityCode_Travco;
            termsHotelSC.Destination.Name = city.Name;
            termsHotelSC.Destination.ProvinceName = city.ProvinceName;
            termsHotelSC.Destination.Country = new TERMS.Common.Country();
            termsHotelSC.Destination.Country.Code = city.Country.Code;
            termsHotelSC.Destination.Country.Code3 = city.Country.Code3;
            termsHotelSC.Destination.Country.CallingCode = city.Country.CallingCode;
            termsHotelSC.Destination.Country.FullName = city.Country.FullName;
            termsHotelSC.Destination.Country.Name = city.Country.Name;
        }

        return termsHotelSC;
    }

    private HotelMerchandise ConvertHotelToMVHotel(Terms.Sales.Business.HotelSearchCondition searchCondition, HotelMerchandise hotelMerchandise)
    {
        if (hotelMerchandise.Items == null) return null;
        if (hotelMerchandise.Items.Count == 0) return null;

        //将Hotel Merchandise的结构换成：HotelMerchandise -> MVHotel -> MVRoom -> HotelMaterial
        for (int i = hotelMerchandise.Items.Count - 1; i >= 0; i--)
        {
            TERMS.Business.Centers.SalesCenter.Hotel hotel = ConvertRooms(hotelMerchandise.Items[i], searchCondition);

            if (hotel == null)
                hotelMerchandise.Items.RemoveAt(i);
            else
            {
                hotelMerchandise.Items[i] = new MVHotel(hotelMerchandise.Items[i]);

                hotelMerchandise.Items[i].Profile.CheckInDate = hotelMerchandise.Profile.CheckInDate;
                hotelMerchandise.Items[i].Profile.CheckOutDate = hotelMerchandise.Profile.CheckOutDate;

                if (((MVHotel)hotelMerchandise.Items[i]).Items != null)
                {
                    foreach (MVRoom room in ((MVHotel)hotelMerchandise.Items[i]).Items)
                    {
                        room.Profile.CheckInDate = hotelMerchandise.Profile.CheckInDate;
                        room.Profile.CheckOutDate = hotelMerchandise.Profile.CheckOutDate;
                    }
                }

                try
                {
                    decimal dec = hotelMerchandise.Items[i].RoomPrice;
                }
                catch
                {
                    hotelMerchandise.Items.RemoveAt(i);
                    continue;
                }

                //把Map的地址赋值
                if (hotelMerchandise.Items[i].HotelInformation.Images.Count > 0)
                {
                    if (hotelMerchandise.Items[i].Source == "GTA")
                    {
                        for (int index = 0; index < hotelMerchandise.Items[i].HotelInformation.Images.Count; index++)
                        {
                            if (string.IsNullOrEmpty(hotelMerchandise.Items[i].HotelInformation.Images[index].Name))
                            {
                                hotelMerchandise.Items[i].HotelInformation.MapUrl = hotelMerchandise.Items[i].HotelInformation.Images[index].Filename;

                                hotelMerchandise.Items[i].HotelInformation.Images.RemoveAt(index);

                                continue;
                            }
                        }
                    }
                    if (hotelMerchandise.Items[i].Source == "TRAVCO")
                    {
                        for (int index = 0; index < hotelMerchandise.Items[i].HotelInformation.Images.Count; index++)
                        {
                            if (hotelMerchandise.Items[i].HotelInformation.Images[index].Name.Trim().ToUpper() == "MAP".Trim().ToUpper())
                            {
                                hotelMerchandise.Items[i].HotelInformation.MapUrl = hotelMerchandise.Items[i].HotelInformation.Images[index].Filename;

                                hotelMerchandise.Items[i].HotelInformation.Images.RemoveAt(index);

                                continue;
                            }
                        }
                    }

                    //add zyl 2009-8-19 当hotel是 local时 用 webconfig中的配置的路径替换图片路径中的 "~/" 因为图片上传时是上传到TERMS的 
                    if (hotelMerchandise.Items[i].Source == "LOCAL")
                    {
                        string imgHand = string.Empty;

                        if (System.Configuration.ConfigurationManager.AppSettings["URL.Head"] != null)
                            imgHand = System.Configuration.ConfigurationManager.AppSettings["URL.Head"];


                        for (int index = 0; index < hotelMerchandise.Items[i].HotelInformation.Images.Count; index++)
                        {
                            if (!string.IsNullOrEmpty(imgHand))
                            {
                                hotelMerchandise.Items[i].HotelInformation.Images[index].Filename =
                                    hotelMerchandise.Items[i].HotelInformation.Images[index].Filename.Trim().Replace("~/", imgHand);
                            }
                        }
                    }
                }
                else
                {
                    //add zyl 2009-9-2 当hotel是 local时 如果没有图片信息就不要显示给前台
                    if (hotelMerchandise.Items[i].Source == "LOCAL")
                    {
                        hotelMerchandise.Items.RemoveAt(i);
                        continue;
                    }
                }
            }
        }

        return hotelMerchandise;
    }


    private TERMS.Business.Centers.SalesCenter.Hotel ConvertRooms(TERMS.Business.Centers.SalesCenter.Hotel hotel, Terms.Sales.Business.HotelSearchCondition searchCondtion)
    {
        List<MVRoom> rooms = new List<MVRoom>();

        for (int index = 0; index < searchCondtion.RoomSearchConditions.Count; index++)
        {
            //大人数
            int iAdult = searchCondtion.RoomSearchConditions[index].Passengers[TERMS.Common.PassengerType.Adult];
            //小孩数
            int iChild = searchCondtion.RoomSearchConditions[index].Passengers[TERMS.Common.PassengerType.Child];

            int MaxNumber = 0;

            MVRoom mvroom = new MVRoom((TERMS.Business.Centers.SalesCenter.HotelProfile)((TERMS.Business.Centers.SalesCenter.HotelProfile)hotel.Profile).Clone());
            mvroom.Profile.AdultNumber = iAdult;
            mvroom.Profile.ChildNumber = iChild;

            for (int j = 0; j < hotel.Items.Count; j++)
            {
                //判断房间类型是否合适
                HotelMaterial room = (HotelMaterial)hotel.Items[j];

                if (string.IsNullOrEmpty(room.Room.Name))
                    room.Room.Name = room.Room.Description;

                MaxNumber = room.Room.Capacity + room.Room.MaxExtraBed + room.Room.MaxShareBed;


                if ((iAdult + iChild) > MaxNumber)
                {
                    continue;
                }
                else
                {
                    if (iChild > 0)
                    {
                        if ((iAdult + iChild) == room.Room.Capacity)
                        {
                            if (iAdult == 2 && iChild == 1)
                            {
                                if (room.Room.Code == "TR")
                                {
                                    continue;
                                }
                            }

                            AddRoomSort(mvroom, room);
                            continue;
                        }

                        if ((room.Room.MaxExtraBed + room.Room.MaxShareBed) >= iChild && iAdult == room.Room.Capacity)
                        {
                            if (iAdult == 2 && iChild == 1)
                            {
                                if (room.Room.Code == "TR")
                                {
                                    continue;
                                }
                            }

                            AddRoomSort(mvroom, room);
                            continue;
                        }

                        if (iAdult == 1 && iChild == 2)
                        {
                            if (room.Room.Code == "DB" || room.Room.Code == "TB")
                            {
                                if (room.Room.MaxExtraBed == 1)
                                {
                                    AddRoomSort(mvroom, room);
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (iAdult == room.Room.Capacity && (room.Room.MaxExtraBed + room.Room.MaxShareBed) == iChild)
                        {
                            if (iAdult == 2 && iChild == 1)
                            {
                                if (room.Room.Code == "TR")
                                {
                                    continue;
                                }
                            }

                            AddRoomSort(mvroom, room);
                            continue;
                        }
                    }


                    //mvroom.Items.Add(room);

                }
            }

            if (mvroom.Items.Count > 0)
                rooms.Add(mvroom);
        }

        if (rooms.Count == searchCondtion.RoomSearchConditions.Count)
        {
            hotel.Items.Clear();

            for (int j = 0; j < rooms.Count; j++)
            {
                hotel.Items.Add(rooms[j]);
            }

            return hotel;
        }
        else
        {
            return null;
        }
    }

    private void AddRoomSort(MVRoom mvroom, HotelMaterial room)
    {
        if (mvroom != null)
        {
            if (mvroom.Items.Count == 0)
            {
                //如果mvroom中没有房间 直接把房价加到 mvroom中
                mvroom.Items.Add(room);
            }
            else
            {
                for (int i = 0; i < mvroom.Items.Count; i++)
                {
                    //计算 新加入的房价的价格
                    decimal roomExtraBedPrice = decimal.Zero;

                    TERMS.Common.Price price = null;

                    if (room.IsNeedExtraBed(mvroom.Aduit, mvroom.Child))
                    {
                        price = room.GetAvgPerNightExtraBedPrice(mvroom.Profile.CheckInDate, mvroom.Profile.CheckOutDate);

                        if (price == null)
                        {
                            roomExtraBedPrice = decimal.Zero;
                        }
                        else
                        {
                            roomExtraBedPrice = price.GetAmount(TERMS.Common.PassengerType.Adult);
                        }
                    }
                    else
                    {
                        roomExtraBedPrice = decimal.Zero;
                    }

                    decimal roomSubtotalPerNightPrice = decimal.Zero;

                    price = room.GetAvgPerNightPrice(mvroom.Profile.CheckInDate, mvroom.Profile.CheckOutDate);

                    roomSubtotalPerNightPrice = price.GetAmount(TERMS.Common.PassengerType.Adult) + price.GetMarkup(TERMS.Common.PassengerType.Adult);

                    //计算需要对比的房价的价格
                    decimal mvroomExtraBedPrice = decimal.Zero;

                    if (mvroom.Items[i].IsNeedExtraBed(mvroom.Aduit, mvroom.Child))
                    {
                        price = mvroom.Items[i].GetAvgPerNightExtraBedPrice(mvroom.Profile.CheckInDate, mvroom.Profile.CheckOutDate);

                        if (price == null)
                        {
                            mvroomExtraBedPrice = decimal.Zero;
                        }
                        else
                        {
                            mvroomExtraBedPrice = price.GetAmount(TERMS.Common.PassengerType.Adult);
                        }
                    }
                    else
                    {
                        mvroomExtraBedPrice = decimal.Zero;
                    }

                    decimal mvroomSubtotalPerNightPrice = decimal.Zero;

                    price = mvroom.Items[i].GetAvgPerNightPrice(mvroom.Profile.CheckInDate, mvroom.Profile.CheckOutDate);

                    mvroomSubtotalPerNightPrice = price.GetAmount(TERMS.Common.PassengerType.Adult) + price.GetMarkup(TERMS.Common.PassengerType.Adult);

                    //如果 新加入的房间的价格 比 当前用于比较的房间的价格 少， 那么 把新加入的房价 添加到集合的当前房间的前面
                    if (roomExtraBedPrice + roomSubtotalPerNightPrice < mvroomExtraBedPrice + mvroomSubtotalPerNightPrice)
                    {
                        mvroom.Items.Insert(i, room);

                        return;
                    }
                }

                //如果 新加入的房间的价格最大 那么加到集合的末尾
                mvroom.Items.Add(room);
            }
        }
    }

    #endregion

    #region "Search Package"
    private PackageMerchandise SearchPackage(Terms.Sales.Business.PackageSearchCondition searchCondition)
    {
        searchCondition.UserInfo = UserInfo;
        searchCondition.AirSearchCondition.UserInfo = UserInfo;
        searchCondition.HotelSearchCondition.UserInfo = UserInfo;

        if (searchCondition.HotelSearchCondition2 != null)
            searchCondition.HotelSearchCondition2.UserInfo = UserInfo;

        //从Cache中查找结
        PackageMerchandise packageMerchandise = (PackageMerchandise)MVMerchandisePool.Find(searchCondition);

        if (packageMerchandise == null)
        {
            DateTime SearchingBeginningTime = DateTime.Now;

            Utility.Transaction.Difference.To = "OnSearch1 End";
            Utility.Transaction.Difference.EndTime = DateTime.Now;
            Utility.Transaction.Difference.From = "Search Package By Find";
            Utility.Transaction.Difference.StarTime = DateTime.Now;

            PackageProductSearcher searcher = new PackageProductSearcher();
            TERMS.Common.Search.PackageSearchCondition pkgCondition = new TERMS.Common.Search.PackageSearchCondition();
            DateTime depDate = searchCondition.AirSearchCondition.GetAddTripCondition()[0].DepartureDate;
            DateTime rtnDate = new DateTime();
            string fromAirportCode = searchCondition.AirSearchCondition.GetAddTripCondition()[0].Departure.Code;
            string toAirportCode = searchCondition.AirSearchCondition.GetAddTripCondition()[0].Destination.Code;
            string rtnFromAirportCode = string.Empty;
            string rtnToAirportCode = string.Empty;
            int adultNumber = searchCondition.AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult);

            int childNumber = searchCondition.AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);
            IList<PackageProduct> pkgs = new List<PackageProduct>();
            if (searchCondition.AirSearchCondition.FlightType.ToLower().Equals("oneway"))
            {
                //没有
            }
            else if (searchCondition.AirSearchCondition.FlightType.ToLower().Equals("roundtrip"))
            {
                rtnDate = searchCondition.AirSearchCondition.GetAddTripCondition()[1].DepartureDate;
                pkgCondition.AirCondition = new TERMS.Common.Search.AirSearchCondition(fromAirportCode, true, toAirportCode, true, depDate, true, rtnDate, true, adultNumber, childNumber, 0);
            }
            else
            {
                rtnDate = searchCondition.AirSearchCondition.GetAddTripCondition()[1].DepartureDate;
                rtnFromAirportCode = searchCondition.AirSearchCondition.GetAddTripCondition()[1].Departure.Code;
                rtnToAirportCode = searchCondition.AirSearchCondition.GetAddTripCondition()[1].Destination.Code;
                pkgCondition.AirCondition = new TERMS.Common.Search.AirSearchCondition(fromAirportCode, true, toAirportCode, true, depDate, true, rtnFromAirportCode, true, rtnToAirportCode, true, rtnDate, true, adultNumber, childNumber, 0);
            }

            if (ConfigurationManager.AppSettings.Get("IsOpenCommNetFareTicket") != null)
                pkgCondition.AirCondition.IsAvailableOnly = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsOpenCommNetFareTicket").ToString());

            //设置Airlines
            if (searchCondition.AirSearchCondition.Airlines != null && searchCondition.AirSearchCondition.Airlines.Length > 0)
                pkgCondition.AirCondition.AddAirlines(searchCondition.AirSearchCondition.Airlines);

            //设置Cabin
            for (int i = 0; i < pkgCondition.AirCondition.Trips.Count; i++)
                pkgCondition.AirCondition.Trips[i].Cabin = searchCondition.AirSearchCondition.AirTripCondition[i].Cabin;

            //转换Hotel Search Condition
            pkgCondition.HotelCondition = ConvertHotelSearchCondition(searchCondition.HotelSearchCondition);

            

            pkgs = searcher.Search(pkgCondition);

            //为线程方法添加参数 package
            PackageProduct pkg = package = pkgs[0];
            Utility.Transaction.Difference.To = "Intel Search Over";
            Utility.Transaction.Difference.EndTime = DateTime.Now;
            Utility.Transaction.Difference.From = "Return AIRItem Start";
            Utility.Transaction.Difference.StarTime = DateTime.Now;

            //启用线程 同时查询 Air 与 Hotel
            PackageThreadStar();

            //IList<TERMS.Core.Product.Component> aa = pkg.AirGroup.Items;

            if (packageair == null || packageair.Count == 0)
            {
                m_Error = "Searching is not available in Web Searching now. Please choose another travel date or destination.(pa1)";
                return null;
            }

            Utility.Transaction.Difference.To = "Return AIRItem End";
            Utility.Transaction.Difference.EndTime = DateTime.Now;
            Utility.Transaction.Difference.From = "Return HotelItem Start";
            Utility.Transaction.Difference.StarTime = DateTime.Now;

            //IList<TERMS.Core.Product.Component> BB = pkg.HotelGroup.Items;

            if (packagehotel == null || packagehotel.Count == 0)
            {
                m_Error = "Searching is not available in Web Searching now. Please choose another travel date or destination.(ph1)";
                return null;
            }

            Utility.Transaction.Difference.To = "Return HotelItem End";
            Utility.Transaction.Difference.EndTime = DateTime.Now;
            Utility.Transaction.Difference.From = "Convert Start";
            Utility.Transaction.Difference.StarTime = DateTime.Now;

            TERMS.Business.Centers.ProductCenter.Profiles.PackageProfile packageProfile = (TERMS.Business.Centers.ProductCenter.Profiles.PackageProfile)pkg.Profile;

            packageProfile.SetParam("ADULT_NUMBER", adultNumber);
            packageProfile.SetParam("CHILD_NUMBER", childNumber);
            packageProfile.SetParam("CheckIn", searchCondition.HotelSearchCondition.CheckIn);
            packageProfile.SetParam("CheckOut", searchCondition.HotelSearchCondition.CheckOut);
            packageProfile.SetParam("Location", searchCondition.HotelSearchCondition.Location);
            try
            {
                packageMerchandise = new PackageMerchandise(packageProfile, pkg);

                if (packageMerchandise.Items[1] == null || ((HotelMerchandise)packageMerchandise.Items[1]).Items == null || ((HotelMerchandise)packageMerchandise.Items[1]).Items.Count == 0)
                {
                    m_Error = "Searching is not available in Web Searching now. Please choose another travel date or destination.";
                    return null;
                }

                for (int i = 1; i < packageMerchandise.Items.Count; i++)
                {
                    HotelMerchandise hotelMerchandise = (HotelMerchandise)packageMerchandise.Items[i];
                    hotelMerchandise.Profile.CheckInDate = searchCondition.HotelSearchCondition.CheckIn;
                    hotelMerchandise.Profile.CheckOutDate = searchCondition.HotelSearchCondition.CheckOut;//
                    hotelMerchandise = ConvertHotelToMVHotel(searchCondition.HotelSearchCondition, hotelMerchandise);
                }
                //判断
                if (packageMerchandise.Items[1] == null || ((HotelMerchandise)packageMerchandise.Items[1]).Items == null || ((HotelMerchandise)packageMerchandise.Items[1]).Items.Count == 0)
                {
                    m_Error = "Searching is not available in Web Searching now. Please choose another travel date or destination.";
                    return null;
                }

                MVMerchandisePool.Cache(searchCondition.Clone(), packageMerchandise); //Cache

                if (searchCondition.OptionalHotelSearchConditions.Count > 0)
                {
                    for (int j = 0; j < searchCondition.OptionalHotelSearchConditions.Count; j++)
                    {
                        packageMerchandise.Items.Add(SearchHotel(searchCondition.OptionalHotelSearchConditions[j]));
                    }
                    packageMerchandise.ReSetPMItems();    // 设定各默认项索引号
                }
                packageMerchandise.Reset();//此为初始化packageMerchandise 中的 CurrentItem
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

            //记录Search时间
            DateTime SearchingEndingTime = DateTime.Now;
            SearchingLogger searchingLogger = new SearchingLogger();
            searchingLogger.Log(SearchingBeginningTime, SearchingEndingTime, searchCondition);
        }
        else
        {
            if (searchCondition.OptionalHotelSearchConditions.Count == packageMerchandise.CurrentItems.Count - 3)
            {
                packageMerchandise.Items.RemoveAt(packageMerchandise.Items.Count - 1);
                packageMerchandise.CurrentItems.RemoveAt(packageMerchandise.CurrentItems.Count - 1);

                packageMerchandise.CurrentHotelListNumber = 0;
                packageMerchandise.Reset();
                packageMerchandise.ReSetPMItems();
            }

            if (searchCondition.IsReset) //重置packageMerchandise 中的 CurrentItem
            {
                for (int i = 2; i < packageMerchandise.Items.Count; i++)
                {
                    packageMerchandise.Items.Remove(packageMerchandise.Items[i]);
                }
                packageMerchandise.CurrentHotelListNumber = 0;
                packageMerchandise.Reset();
                packageMerchandise.ReSetPMItems();
            }
        }


        List<int> searchFaildHotelIndexs = new List<int>();

        for (int i = 0; i < searchCondition.OptionalHotelSearchConditions.Count; i++)
        {
            HotelMerchandise hotelMerchandise = (HotelMerchandise)MVMerchandisePool.Find(searchCondition.OptionalHotelSearchConditions[i]);
            if (hotelMerchandise == null)
            {
                hotelMerchandise = SearchHotel(searchCondition.OptionalHotelSearchConditions[i]);

                if (hotelMerchandise == null) //Search Hotel失败
                    searchFaildHotelIndexs.Add(i);

                packageMerchandise.Items.Add(hotelMerchandise);
                packageMerchandise.Reset(i + 2);
                packageMerchandise.ReSetPMItems();
            }
            else
            {
                if ((packageMerchandise.Items.Count - 1) >= (i + 2))//判断下标(i+2),在Items 里面是否存在
                    packageMerchandise.Items[i + 2] = hotelMerchandise;
                else
                {
                    packageMerchandise.Items.Add(hotelMerchandise);
                    packageMerchandise.Reset(i + 2);
                    packageMerchandise.ReSetPMItems();
                }
                if (searchCondition.IsReset) //重置packageMerchandise 中的 CurrentItem[i+2]
                    packageMerchandise.Reset(i + 2);
            }

        }

        if (searchFaildHotelIndexs.Count > 0) //Search Hotel失败
        {
            for (int i = 0; i < searchFaildHotelIndexs.Count; i++)
            {
                //清除Search失败的Hotel Search Condition
                searchCondition.OptionalHotelSearchConditions.RemoveAt(searchFaildHotelIndexs[i] - i);
                packageMerchandise.Items.RemoveAt(searchFaildHotelIndexs[i] + 2 - i);
                packageMerchandise.CurrentItems.RemoveAt(searchFaildHotelIndexs[i] + 2 - i);
            }

            packageMerchandise.ReSetPMItems();

            return null;
        }

        searchCondition.IsReset = false;

        Utility.Transaction.Difference.To = "Convert End";
        Utility.Transaction.Difference.EndTime = DateTime.Now;

        Utility.Transaction.Difference.From = "Search End";
        Utility.Transaction.Difference.StarTime = DateTime.Now;

        packageMerchandise.UserInfo = UserInfo.User.UserName;

        return packageMerchandise;
    }

    // 产品结构
    PackageProduct package = null;
    // package Air Items
    IList<TERMS.Core.Product.Component> packageair = null;
    // package Hotel Items
    IList<TERMS.Core.Product.Component> packagehotel = null;


    //private ManualResetEvent[] doEvent = new ManualResetEvent[2];

    //当 AirGroup.Items 为空时 填充 被线程A 调用  查机票
    private void FillAirItemForPackage()
    {
        packageair = package.AirGroup.Items;

        //doEvent[0].Reset();
    }
    //当 HotelGroup.Items 为空时 填充 被线程B 调用 查酒店
    private void FillHotelItemForPackage()
    {
        packagehotel = package.HotelGroup.Items;
        //doEvent[1].Reset();
    }

    private void PackageThreadStar()
    {
        //声明线程数组 
        Thread[] thread = new Thread[2];

        //for (int i = 0; i < 2; i++)
        //{
        //    doEvent[i] = new ManualResetEvent(false);
        //}
        // 线程 A  
        thread[0] = new Thread(new ThreadStart(FillAirItemForPackage));
        // 线程 B
        thread[1] = new Thread(new ThreadStart(FillHotelItemForPackage));

        // 线程A 启动
        thread[0].Start();
        // 线程B 启动
        thread[1].Start();

        //等待 线程 A 与 B 完成
        thread[0].Join();
        thread[1].Join();

        //WaitHandle.WaitAll(doEvent);
    }



    #endregion

    #region "Search Insurance"
    public InsuranceMaterial SearchInsurance(Terms.Sales.Business.InsuranceSearchCondition insuranceCondition)
    {
        TERMS.Common.Search.InsuranceSearchCondition Condition = new TERMS.Common.Search.InsuranceSearchCondition();

        Condition.InsuranceType = insuranceCondition.InsuranceType;

        Condition.Trip = new TERMS.Common.Trip();

        Condition.Trip.DepartureDate = insuranceCondition.DepartureDate;
        Condition.Trip.ReturnDate = insuranceCondition.ReturnDate;
        Condition.Trip.InitialTripDepositDate = DateTime.Now;

        List<TERMS.Common.Traveler> list = new List<TERMS.Common.Traveler>();

        for (int i = 0; i < insuranceCondition.TravelerCount; i++)
        {
            TERMS.Common.Traveler t = new TERMS.Common.Traveler();

            t.BirthDate = DateTime.Now.AddYears(-10);

            t.TripCost = Convert.ToDouble(insuranceCondition.TotalTripCost / insuranceCondition.TravelerCount);

            list.Add(t);
        }

        Condition.Travelers = list.ToArray();

        InsuranceProductSearcher INs = new InsuranceProductSearcher();
        IList<InsuranceProduct> products = null;
        try
        {
            products = INs.Search(Condition);
        }
        catch
        {
            return null;
        }

        if (products != null && products.Count > 0)
        {
            return ((TERMS.Business.Centers.ProductCenter.Components.InsuranceMaterial)((TERMS.Core.Product.ComponentGroup)products[0].Items[0]).Items[0]);
        }
        else
        {
            return null;
        }
    }

    public InsuranceMaterial SearchInsuranceByB2B(Terms.Sales.Business.InsuranceSearchCondition insuranceCondition)
    {
        TERMS.Common.Search.InsuranceSearchCondition Condition = new TERMS.Common.Search.InsuranceSearchCondition();

        Condition.InsuranceType = insuranceCondition.InsuranceType;

        Condition.Trip = new TERMS.Common.Trip();

        Condition.Trip.DepartureDate = insuranceCondition.DepartureDate;
        Condition.Trip.ReturnDate = insuranceCondition.ReturnDate;
        Condition.Trip.InitialTripDepositDate = DateTime.Now;

        List<TERMS.Common.Traveler> list = new List<TERMS.Common.Traveler>();

        for (int i = 0; i < insuranceCondition.TravelerCount; i++)
        {
            TERMS.Common.Traveler t = new TERMS.Common.Traveler();

            t.BirthDate = DateTime.Now.AddYears(-10);

            t.TripCost = Convert.ToDouble(insuranceCondition.TotalTripCost / insuranceCondition.TravelerCount);

            list.Add(t);
        }

        Condition.Travelers = list.ToArray();

        InsuranceProductSearcher INs = new InsuranceProductSearcher();

        try
        {
            IList<InsuranceProduct> products = INs.Search(Condition);

            if (products != null && products.Count > 0)
            {
                return ((TERMS.Business.Centers.ProductCenter.Components.InsuranceMaterial)((TERMS.Core.Product.ComponentGroup)products[0].Items[0]).Items[0]);
            }
            else
            {
                InsuranceMaterial insurance = new InsuranceMaterial(new TERMS.Core.Profiles.Profile("insurance"));

                insurance.PolicyQuote = new TERMS.Common.PolicyQuote();

                insurance.PolicyQuote.Status = new TERMS.Common.Status();

                insurance.PolicyQuote.Status.IsSuccess = false;

                insurance.PolicyQuote.Status.ErrorDescription = "None Insurance products";

                return insurance;
            }
        }
        catch (Exception ex)
        {
            InsuranceMaterial insurance = new InsuranceMaterial(new TERMS.Core.Profiles.Profile("insurance"));

            insurance.PolicyQuote = new TERMS.Common.PolicyQuote();

            insurance.PolicyQuote.Status = new TERMS.Common.Status();

            insurance.PolicyQuote.Status.IsSuccess = false;

            insurance.PolicyQuote.Status.ErrorDescription = ex.Message;

            return insurance;
        }
    }
    #endregion

    #region "Search Tour"
    public TourMerchandise SearchTour(Terms.Sales.Business.TourSearchCondition searchCondition, string Language)
    {
        //searchCondition.UserInfo = UserInfo;
        ////从Cache中查找结
        //TourMerchandise tourMerchandise = null;
        //if (Utility.IsSubAgent)
        //    tourMerchandise = (TourMerchandise)MVMerchandisePool.FindB2BTour(searchCondition);
        //else
        //    tourMerchandise = (TourMerchandise)MVMerchandisePool.Find(searchCondition);

        //if (tourMerchandise == null)
        //{
        TourProductSearcher searcher = new TourProductSearcher();

        TERMS.Common.Search.TourSearchCondition tourSearchCondition = new TERMS.Common.Search.TourSearchCondition();
        tourSearchCondition.SetCity(searchCondition.City);
        tourSearchCondition.SetRegion(searchCondition.Region);
        tourSearchCondition.SetCountry(searchCondition.Counrty);
        tourSearchCondition.IsLandOnly = searchCondition.IsLandOnly;
        tourSearchCondition.TravelDaysFrom = searchCondition.TravelDaysFrom;
        tourSearchCondition.TravelDaysTo = searchCondition.TravelDaysTo;
        tourSearchCondition.PriceType = searchCondition.PriceType;
        tourSearchCondition.SetDepartureRange(searchCondition.TravelBeginDate.AddDays(-7), searchCondition.TravelBeginDate.AddDays(7));

        List<string> citys = new List<string>();

        citys.Add(searchCondition.City);
               
        return SearchTour(searchCondition, citys, Language);

        //    IList<TourProduct> tps = new List<TourProduct>();

        //    tps = searcher.Search(tourSearchCondition, UserInfo.Entity);


        //    if (tps != null && tps.Count > 0)
        //    {
        //        tourMerchandise = new TourMerchandise((List<TourProduct>)tps);

        //        if (Utility.IsSubAgent)
        //        {
        //            GetSpecialTourPrice(tourMerchandise, searchCondition.IsLandOnly);
        //        }

        //        MVMerchandisePool.Cache(searchCondition.Clone(), tourMerchandise); //Cache
        //    }
        //    else
        //        return null;
        //}

        //tourMerchandise.LanguageFlag = Language;

        //return tourMerchandise;        
    }

    public TourMerchandise SearchTour(string Language)
    {
        //从Cache中查找结
        TourMerchandise tourMerchandise = null;
        if (Utility.IsSubAgent)
            tourMerchandise = (TourMerchandise)MVMerchandisePool.Find("SUBTour");
        else
            tourMerchandise = (TourMerchandise)MVMerchandisePool.Find("Tour");

        if (tourMerchandise == null)
        {
            TourProductSearcher searcher = new TourProductSearcher();
            IList<TourProduct> tps = new List<TourProduct>();

            tps = searcher.Search(UserInfo.Entity);

            if (tps != null && tps.Count > 0)
            {
                tourMerchandise = new TourMerchandise((List<TourProduct>)tps);

                if (Utility.IsSubAgent)
                {
                    GetSpecialTourPrice(tourMerchandise, true);
                }                

                if (Utility.IsSubAgent)
                {
                    MVMerchandisePool.Cache("SUBTour", tourMerchandise);
                }
                else
                {
                    
                    MVMerchandisePool.Cache("Tour", tourMerchandise); //Cache
                }
            }
            else
                return null;
        }

        tourMerchandise.LanguageFlag = Language;

        return tourMerchandise;
    }
    //public TourMerchandise SearchTour(Terms.Sales.Business.TourSearchCondition searchCondition, List<string> citys, string Language)
    //{
    //    searchCondition.UserInfo = UserInfo;
    //    //从Cache中查找结
    //    TourMerchandise tourMerchandise = (TourMerchandise)MVMerchandisePool.Find(citys);

    //    if (tourMerchandise == null)
    //    {
    //        TourProductSearcher searcher = new TourProductSearcher();
    //        TERMS.Common.Search.TourSearchCondition tourSearchCondition = new TERMS.Common.Search.TourSearchCondition();
    //        tourSearchCondition.SetCity(searchCondition.City);
    //        tourSearchCondition.SetRegion(searchCondition.Region);
    //        tourSearchCondition.SetCountry(searchCondition.Counrty);
    //        tourSearchCondition.IsLandOnly = searchCondition.IsLandOnly;
    //        tourSearchCondition.TravelDaysFrom = searchCondition.TravelDaysFrom;
    //        tourSearchCondition.TravelDaysTo = searchCondition.TravelDaysTo;
    //        tourSearchCondition.PriceType = searchCondition.PriceType;
    //        tourSearchCondition.SetDepartureRange(searchCondition.TravelBeginDate.AddDays(-7), searchCondition.TravelBeginDate.AddDays(300));
    //        IList<TourProduct> tps = new List<TourProduct>();

    //        tps = searcher.Search(tourSearchCondition, citys, userInfo.Entity);

    //        if (tps != null && tps.Count > 0)
    //        {
    //            TourMerchandise tourMerchandiseNew = new TourMerchandise((List<TourProduct>)tps);

    //            if (Utility.IsSubAgent)
    //            {
    //                GetSpecialTourPrice(tourMerchandise, searchCondition.IsLandOnly);
    //            }

    //            MVMerchandisePool.Cache(citys, tourMerchandiseNew); //Cache

    //            tourMerchandise = tourMerchandiseNew;
    //        }
    //        else
    //            return null;
    //    }
    //    tourMerchandise.LanguageFlag = Language;

    //    return tourMerchandise;
    //}

    public TourMerchandise SearchTour(Terms.Sales.Business.TourSearchCondition searchCondition, List<string> citys, string Language)
    {
        //searchCondition.UserInfo = UserInfo;

        TourMerchandise tourMerchandise = null;

        TourMerchandise tourMerchandiseAll = null;

        if (Utility.IsSubAgent)
            tourMerchandiseAll = (TourMerchandise)MVMerchandisePool.Find("SUBTour");
        else
            tourMerchandiseAll = (TourMerchandise)MVMerchandisePool.Find("Tour");

        if (tourMerchandiseAll == null)
        {
            tourMerchandiseAll = SearchTour(Language);
        }

        if (tourMerchandiseAll != null)
        {
            tourMerchandise = new TourMerchandise();

            tourMerchandise.TourProductList = tourMerchandiseAll.TourProductList;

            for (int i = 0; i < tourMerchandiseAll.Items.Count; i++)
            {
                TourMaterial tourMaterial = (TourMaterial)tourMerchandiseAll.Items[i];
                TourMaterial tourMaterialCN = (TourMaterial)tourMerchandiseAll.TourMCN[i];

                TourProfile tourprofile = (TourProfile)tourMaterial.Profile;

                TERMS.Common.City StartCity = tourprofile.StartCity;
                TERMS.Common.City EndCity = tourprofile.EndCity;
                List<TERMS.Common.City> PassCities = (List<TERMS.Common.City>)tourprofile.PassCities;

                if (searchCondition.TravelDaysFrom != 0 && searchCondition.TravelDaysTo != 0 &&
                (tourprofile.Days < searchCondition.TravelDaysFrom || tourprofile.Days > searchCondition.TravelDaysTo))
                {
                    continue;
                }

                if (citys.Contains(StartCity.Code))
                {
                    tourMerchandise.Add(tourMaterial);
                    tourMerchandise.TourMCN.Add(tourMaterialCN);
                    continue;
                }
                if (citys.Contains(EndCity.Code))
                {
                    tourMerchandise.Add(tourMaterial);
                    tourMerchandise.TourMCN.Add(tourMaterialCN);
                    continue;
                }
                for (int index = 0; index < PassCities.Count; index++)
                {
                    if (citys.Contains(PassCities[index].Code))
                    {
                        tourMerchandise.Add(tourMaterial);
                        tourMerchandise.TourMCN.Add(tourMaterialCN);

                        break;
                    }
                }
            }            
        }
        else
            return null;

        //tourMerchandise.Items.Sort(CompareByStartFromLandOnlyFareAndTourCode);

        tourMerchandise.LanguageFlag = Language;

        return tourMerchandise;
    }

    public TourMerchandise SearchTourByTourCode(string tourCode, string Language)
    {
        TourMerchandise tourMerchandise = null;

        TourMerchandise tourMerchandiseAll = null;

        if (Utility.IsSubAgent)
            tourMerchandiseAll = (TourMerchandise)MVMerchandisePool.Find("SUBTour");
        else
            tourMerchandiseAll = (TourMerchandise)MVMerchandisePool.Find("Tour");

        if (tourMerchandiseAll == null)
        {
            tourMerchandiseAll = SearchTour(Language);
        }

        if (tourMerchandiseAll != null)
        {
            tourMerchandise = new TourMerchandise();

            tourMerchandise.TourProductList = tourMerchandiseAll.TourProductList;

            for (int i = 0; i < tourMerchandiseAll.Items.Count; i++)
            {
                TourMaterial tourMaterial = (TourMaterial)tourMerchandiseAll.Items[i];
                TourMaterial tourMaterialCN = (TourMaterial)tourMerchandiseAll.TourMCN[i];

                TourProfile tourprofile = (TourProfile)tourMaterial.Profile;

                if (tourprofile.Code.Trim().ToUpper() == tourCode.Trim().ToUpper())
                {
                    tourMerchandise.Add(tourMaterial);
                    tourMerchandise.TourMCN.Add(tourMaterialCN);
                    break; ;
                }
            }
        }

        else
            return null;

        tourMerchandise.LanguageFlag = Language;

        return tourMerchandise;
    }

    #region 查询特别Tour的价格
    public void GetSpecialTourPrice(TourMerchandise tourmerchandise, bool islandOnly)
    {
        string emailPath = string.Empty;

        emailPath = @"/Config/SpecialTourPrice.xml";

        if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + emailPath))
        {
            DataSet ds = new DataSet();

            ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + emailPath);

            if (ds != null)
            {
                DataTable dt = ds.Tables[0];

                string tourcode = string.Empty;

                string strSql = string.Empty;

                decimal decPrice = decimal.Zero;

                string roomType = string.Empty;

                decimal decSelling = decimal.Zero;

                for (int i = 0; i < tourmerchandise.Items.Count ; i++)
                {
                    TourProfile tourProfile = (TourProfile)((TourMaterial)tourmerchandise.Items[i] ).Profile;

                    List<DateTime> dates = new List<DateTime>();

                    for (int ii = 0; ii < tourProfile.Seasons.Count; ii++)
                    {
                        if (tourProfile.Seasons[ii].Periods.Count > 0)
                        {
                                dates.Add(tourProfile.Seasons[ii].Periods[0].PeriodFrom);
                        }
                    }

                    tourcode = tourProfile.Code;

                    strSql = " TourCode = '" + tourcode + "'";

                    DataRow[] drs = dt.Select(strSql);

                    if (drs != null && drs.Length > 0)
                    {
                        for (int j = 0; j < drs.Length; j++)
                        {
                            decPrice = Convert.ToDecimal(drs[j]["Price"].ToString().Trim());

                            roomType = drs[j]["RoomType"].ToString().Trim();

                            for (int dataCount = 0; dataCount < dates.Count; dataCount++)
                            {
                                decSelling = tourProfile.GetPrice(dates[dataCount], roomType, islandOnly, false).GetAmount(TERMS.Common.PassengerType.Adult);

                                if (decSelling > decimal.Zero)
                                {
                                    tourProfile.GetPrice(dates[dataCount], roomType, islandOnly,
                                        false).SetAmount(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(decSelling + decPrice));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    #endregion
    #endregion

    #region Search Transfer
    public TERMS.Business.Centers.ProductCenter.Components.TransferProduct SearchTransfer(Terms.Sales.Business.TransferSearchCondition transferSearchCondition)
    {
        TERMS.Common.Search.TransferSearchCondition searchCondition = new TERMS.Common.Search.TransferSearchCondition();

        searchCondition.CurrencyCode = transferSearchCondition.CurrencyCode;
        searchCondition.CountryCode = transferSearchCondition.Country;
        searchCondition.PreferredLanguage = transferSearchCondition.PreferredLanguage;

        searchCondition.PickupCityCode = transferSearchCondition.PickupCityCode;
        searchCondition.PickupCode = transferSearchCondition.PickupCode;
        searchCondition.PickupPointCode = transferSearchCondition.PickupPoint;


        searchCondition.DropOffCityCode = transferSearchCondition.DropOffCityCode;
        searchCondition.DropOffCode = transferSearchCondition.DropOffCode;

        searchCondition.TransferDate = transferSearchCondition.TransferDate;
        searchCondition.AlternateLanguage = transferSearchCondition.AlternateLanguage;
        searchCondition.Passengers = transferSearchCondition.Passengers;

        TransferProductSearcher searcher = new TransferProductSearcher();
        IList<TransferProduct> Products = searcher.Search(searchCondition);

        if (Products != null && Products.Count > 0)
        {
            return (TERMS.Business.Centers.ProductCenter.Components.TransferProduct)Products[0];
        }
        else
        {
            return null;
        }
    }
    #endregion

    #region Search SightSeeing
    public SightSeeingMaterial SearchInsurance(Terms.Sales.Business.SightSeeingSearchCondition sightSeeingSearchCondition)
    {
        TERMS.Common.Search.SightSeeingSearchCondition searchCondition = new TERMS.Common.Search.SightSeeingSearchCondition();

        searchCondition.Adults = sightSeeingSearchCondition.Adults;

        searchCondition.ChildrenAges = sightSeeingSearchCondition.ChildrenAges.ToArray();

        searchCondition.DestinationCode = sightSeeingSearchCondition.City;
        searchCondition.DestinationType = sightSeeingSearchCondition.SearchType;
        searchCondition.TourDate = sightSeeingSearchCondition.ServiceDate;

        searchCondition.TypeCodes = sightSeeingSearchCondition.Types.ToArray();

        SightSeeingProductSearcher searcher = new SightSeeingProductSearcher();

        IList<SightSeeingProduct> Products = searcher.Search(searchCondition);


        if (Products != null)
        {
            return ((TERMS.Business.Centers.ProductCenter.Components.SightSeeingMaterial)((TERMS.Core.Product.ComponentGroup)Products[0].Items[0]).Items[0]);
        }
        else
        {
            return null;
        }
    }
    #endregion

    private VehcileMerchandise SearchVehcile(Terms.Sales.Business.VehcileSearchCondition searchCondition)
    {

        //searchCondition.UserInfo = UserInfo;

        //从Cache中查找结果
        VehcileMerchandise hotelMerchandise = (VehcileMerchandise)MVMerchandisePool.Find(searchCondition);

        if (hotelMerchandise == null)
        {
            //log zyl
            try
            {
                TERMS.Common.Search.VehcileSearchCondition termsHotelSC = searchCondition.CarSearchCondition ;
                
                IList<VehcileProduct> products = new List<VehcileProduct>();

                hotelLog.Info(" Search Car : " + UserInfo.Entity.Name);
                //查询得到Hotel Product
                products = new TERMS.Business.Centers.ProductCenter.Search.VehcileProductSearcher().Search(termsHotelSC, UserInfo.Entity);

                hotelLog.Info(" Search Car 1: " + products.Count.ToString());

                VehcileProduct hotelProduct = products[0];

                //IList<TERMS.Core.Product.Component> hotels = hotelProduct.Items;
                if (products[0].Items.Count == 0)
                {
                    m_Error = "Searching is not available in Web Searching now. Please choose another travel date or destination.(h1)";
                    return null;
                }


                //生成Hotel Merchandise
                VehcileProfile hotelProfile = new VehcileProfile("car");

                hotelMerchandise = new VehcileMerchandise(hotelProfile, hotelProduct);

                //log
                
                MVMerchandisePool.Cache(searchCondition, hotelMerchandise); //Cache
            }
            catch(Exception ex)
            {
                hotelLog.Info(" Search Car 1: " + ex.Message );

                if (ex.InnerException != null)
                {
                    hotelLog.Info(" Search Car 2: " + ex.InnerException.Message);
                }

                m_Error = "Searching is not available in Web Searching now. Please choose another travel date or destination.";
                return null;
            }
        }

        return hotelMerchandise;
    }
}

