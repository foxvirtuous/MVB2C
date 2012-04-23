using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TERMS.Business.Centers.SalesCenter;
using System.Collections.Generic;

/// <summary>
/// Summary description for HotelOrderUtility
/// </summary>
public class HotelOrderUtility
{
    public HotelOrderUtility()
    {

    }

    public static List<cCity> GetCityDataSource(List<HotelOrderItem> HotelOrderItems)
    {
        //页面上显示选中的Hotel，其结构为3个DataList，层层嵌套：
        //第一层DataList为City，第二层为Hotel，第三层为Room，
        //例如，
        //Shanghai - 友谊宾馆 - Room #1 Double Room
        //                    - Room #2 Triple Room
        //         - Hilton   - Room #1 Twin Room
        //                    - Room #2 Triple Room 
        //第一层DataList数据源为List<cCity>
        //第二层DataList数据源为List<cHotel>
        //第二层DataList数据源为List<HotelOrderItem>

        //绑定City
        //得到所有订单项包含的City Name
        List<string> listCityName = new List<string>();

        for (int hotelOrderItemIndex = 0; hotelOrderItemIndex < HotelOrderItems.Count; hotelOrderItemIndex++)
        {
            //HotelOrderItem tempHotelMaterial = (HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[hotelOrderItemIndex];
            HotelOrderItem tempHotelMaterial = (HotelOrderItem)HotelOrderItems[hotelOrderItemIndex];

            if (!listCityName.Contains(tempHotelMaterial.Room.Hotel.City.Name))
                listCityName.Add(tempHotelMaterial.Room.Hotel.City.Name);
        }

        List<cCity> listDataSource = new List<cCity>();

        for (int cityIndex = 0; cityIndex < listCityName.Count; cityIndex++)
        {
            cCity cityDataSource = new cCity();
            cityDataSource.CityName = listCityName[cityIndex];
            cityDataSource.OrderItems = FilteHotelOrderItemsByCityName(HotelOrderItems, cityDataSource.CityName);
            cityDataSource.Hotels = GetHotelDataSource(cityDataSource);
            listDataSource.Add(cityDataSource);
        }
        return listDataSource;
    }

    public static List<cHotel> GetHotelDataSource(cCity cityDataSource)
    {
        List<cHotelNameCheckIn> hotelNameCheckIns = new List<cHotelNameCheckIn>();

        for (int j = 0; j < cityDataSource.OrderItems.Count; j++)
        {
            cHotelNameCheckIn hc = new cHotelNameCheckIn();
            hc.CheckIn = cityDataSource.OrderItems[j].Profile.CheckInDate;
            hc.HotelName = cityDataSource.OrderItems[j].Room.Hotel.Name;
            hc.Hotel = cityDataSource.OrderItems[j].Room.Hotel;

            if (!hotelNameCheckIns.Contains(hc))
                hotelNameCheckIns.Add(hc);
        }

        List<cHotel> hotelDataSources = new List<cHotel>();

        for (int hotelIndex = 0; hotelIndex < hotelNameCheckIns.Count; hotelIndex++)
        {
            cHotel hotelDataSource = new cHotel();
            cHotelNameCheckIn hc = hotelNameCheckIns[hotelIndex];
            hotelDataSource.Hotel = hc.Hotel;
            hotelDataSource.RoomTypes = FilteHotelOrderItemsByHotelName(cityDataSource.OrderItems, hc.HotelName);
            hotelDataSource.RoomTypes = FilteHotelOrderItemsByCheckIn(hotelDataSource.RoomTypes, hc.CheckIn);
            hotelDataSource.CheckIn = hotelDataSource.RoomTypes[0].Profile.CheckInDate;
            hotelDataSource.CheckOut = hotelDataSource.RoomTypes[0].Profile.CheckOutDate;

            foreach (HotelOrderItem roomType in hotelDataSource.RoomTypes)
                hotelDataSource.TotalPrice += roomType.TotalPrice;

            hotelDataSources.Add(hotelDataSource);
        }
        return hotelDataSources;
    }

    public static List<cHotel> GetHotelDataSource(List<HotelOrderItem> HotelOrderItems)
    {
        List<cHotelNameCheckIn> hotelNameCheckIns = new List<cHotelNameCheckIn>();

        for (int j = 0; j < HotelOrderItems.Count; j++)
        {
            cHotelNameCheckIn hc = new cHotelNameCheckIn();
            hc.CheckIn = HotelOrderItems[j].Profile.CheckInDate;
            hc.HotelName = HotelOrderItems[j].Room.Hotel.Name;
            hc.Hotel = HotelOrderItems[j].Room.Hotel;

            if (!hotelNameCheckIns.Contains(hc))
                hotelNameCheckIns.Add(hc);
        }

        List<cHotel> hotelDataSources = new List<cHotel>();

        for (int hotelIndex = 0; hotelIndex < hotelNameCheckIns.Count; hotelIndex++)
        {
            cHotel hotelDataSource = new cHotel();
            cHotelNameCheckIn hc = hotelNameCheckIns[hotelIndex];
            hotelDataSource.Hotel = hc.Hotel;
            hotelDataSource.RoomTypes = FilteHotelOrderItemsByHotelName(HotelOrderItems, hc.HotelName);
            hotelDataSource.RoomTypes = FilteHotelOrderItemsByCheckIn(HotelOrderItems, hc.CheckIn);
            hotelDataSource.CheckIn = hotelDataSource.RoomTypes[0].Profile.CheckInDate;
            hotelDataSource.CheckOut = hotelDataSource.RoomTypes[0].Profile.CheckOutDate;

            foreach (HotelOrderItem roomType in hotelDataSource.RoomTypes)
                hotelDataSource.TotalPrice += roomType.TotalPrice;

            hotelDataSources.Add(hotelDataSource);
        }
        return hotelDataSources;
    }

    public static void AssignPassengersToHotel(List<HotelOrderItem> hotelOrderItems, List<TERMS.Business.Centers.SalesCenter.Passenger> passengers)
    {
        //【将Passenger分配到OrderItem中】Begin

        //创建订单的成人和小孩列表
        List<TERMS.Business.Centers.SalesCenter.Passenger> adults = new List<TERMS.Business.Centers.SalesCenter.Passenger>();
        List<TERMS.Business.Centers.SalesCenter.Passenger> children = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

        for (int i = 0; i < passengers.Count; i++)
        {
            TERMS.Business.Centers.SalesCenter.Passenger pax = passengers[i];

            if (pax.PassengerType == TERMS.Common.PassengerType.Adult)
                adults.Add(pax);
            else if (pax.PassengerType == TERMS.Common.PassengerType.Child)
                children.Add(pax);
        }

        List<cHotel> hotels = HotelOrderUtility.GetHotelDataSource(hotelOrderItems);

        for (int hotelIndex = 0; hotelIndex < hotels.Count; hotelIndex++)
        {
            cHotel hotel = hotels[hotelIndex];
            int unAssignedAdultIndex = 0;   //所有Adult中未分配给hotelOrder的成人的起始序号
            int unAssignedChildIndex = 0;   //所有Child中未分配给hotelOrder的小孩的起始序号

            for (int roomIndex = 0; roomIndex < hotel.RoomTypes.Count; roomIndex++)
            {
                HotelOrderItem hotelOrderItem = hotel.RoomTypes[roomIndex];
                hotelOrderItem.Passengers.Clear();

                for (int j = 0; j < hotelOrderItem.Profile.AdultNumber; j++)
                    if (unAssignedAdultIndex + j < adults.Count)
                        hotelOrderItem.Passengers.Add(adults[unAssignedAdultIndex + j]);

                for (int j = 0; j < hotelOrderItem.Profile.ChildNumber; j++)
                    if (unAssignedChildIndex + j < children.Count)
                        hotelOrderItem.Passengers.Add(children[unAssignedChildIndex + j]);

                unAssignedAdultIndex += hotelOrderItem.AdultNumber;
                unAssignedChildIndex += hotelOrderItem.ChildNumber;
            }
        }
        //【将Passenger分配到OrderItem中】End
    }



    #region "过滤Hotel Order Item"

    private static List<HotelOrderItem> FilteHotelOrderItemsByCityName(List<HotelOrderItem> hotelOrderItems, string cityName)
    {
        List<HotelOrderItem> result = new List<HotelOrderItem>();

        for (int index = 0; index < hotelOrderItems.Count; index++)
        {
            HotelOrderItem eachHotelOrderItem = hotelOrderItems[index];

            if (eachHotelOrderItem.Room.Hotel.City.Name.ToLower().Trim() == cityName.ToLower().Trim())
                result.Add(eachHotelOrderItem);
        }

        return result;
    }

    private static List<HotelOrderItem> FilteHotelOrderItemsByHotelName(List<HotelOrderItem> hotelOrderItems, string hotelName)
    {
        List<HotelOrderItem> result = new List<HotelOrderItem>();

        for (int index = 0; index < hotelOrderItems.Count; index++)
        {
            HotelOrderItem eachHotelOrderItem = hotelOrderItems[index];

            if (eachHotelOrderItem.Room.Hotel.Name.ToLower().Trim() == hotelName.ToLower().Trim())
                result.Add(eachHotelOrderItem);
        }

        return result;
    }

    private static List<HotelOrderItem> FilteHotelOrderItemsByCheckIn(List<HotelOrderItem> hotelOrderItems, DateTime checkIn)
    {
        List<HotelOrderItem> result = new List<HotelOrderItem>();

        for (int index = 0; index < hotelOrderItems.Count; index++)
        {
            HotelOrderItem eachHotelOrderItem = hotelOrderItems[index];

            if (eachHotelOrderItem.CheckIn == checkIn)
                result.Add(eachHotelOrderItem);
        }

        return result;
    }

    #endregion
    
}

public class cCity
{
    private string _CityName;

    public string CityName
    {
        get { return _CityName; }
        set { _CityName = value; }
    }
    private List<cHotel> _Hotels = new List<cHotel>();

    public List<cHotel> Hotels
    {
        get { return _Hotels; }
        set { _Hotels = value; }
    }
    private List<HotelOrderItem> _OrderItems = new List<HotelOrderItem>();

    public List<HotelOrderItem> OrderItems
    {
        get { return _OrderItems; }
        set { _OrderItems = value; }
    }
}

public class cHotel
{
    private TERMS.Common.Hotel _Hotel;

    public TERMS.Common.Hotel Hotel
    {
        get { return _Hotel; }
        set { _Hotel = value; }
    }
    private List<HotelOrderItem> _RoomTypes = new List<HotelOrderItem>();

    public List<HotelOrderItem> RoomTypes
    {
        get { return _RoomTypes; }
        set { _RoomTypes = value; }
    }
    private DateTime _CheckIn;

    public DateTime CheckIn
    {
        get { return _CheckIn; }
        set { _CheckIn = value; }
    }
    private DateTime _CheckOut;

    public DateTime CheckOut
    {
        get { return _CheckOut; }
        set { _CheckOut = value; }
    }

    public int Nights
    {
        get { return ((TimeSpan)CheckOut.Subtract(CheckIn)).Days; }
    }

    private decimal _TotalPrice;

    public decimal TotalPrice
    {
        get { return _TotalPrice; }
        set { _TotalPrice = value; }
    }
}

public class cHotelNameCheckIn
{
    private string _HotelName;

    public string HotelName
    {
        get { return _HotelName; }
        set { _HotelName = value; }
    }
    private DateTime _CheckIn;

    public DateTime CheckIn
    {
        get { return _CheckIn; }
        set { _CheckIn = value; }
    }

    private TERMS.Common.Hotel _Hotel;

    public TERMS.Common.Hotel Hotel
    {
        get { return _Hotel; }
        set { _Hotel = value; }
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        cHotelNameCheckIn hc = (cHotelNameCheckIn)obj;

        if (hc.CheckIn == this.CheckIn && hc.HotelName == this.HotelName)
            return true;
        else
            return false;
    }

    public override int GetHashCode()
    {
        return CheckIn.GetHashCode() ^ HotelName.GetHashCode();
    }

}
