using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;





/// <summary>
/// Summary description for HotelInfomationService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService()]
public class HotelInfomationService : System.Web.Services.WebService
{
    public HotelInfomationService()
    { 
    }

    [WebMethod]
    public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownContents(string knownCategoryValues, string category)
    {
        return null;
        
        


        #region 注销的方法, 暂时不使用
        //AjaxControlToolkit.CascadingDropDownNameValue[] dvs = null;
        //System.Collections.ArrayList List = new ArrayList();
        //if (category == "Country")
        //{
        //    IList CountryList = this._CommonService.FindCountryAll();

        //    for (int index = 0; index < CountryList.Count; index++)
        //    {
        //        CommCountry Country = (CommCountry)CountryList[index];
        //        if (Country != null)
        //        {
        //            AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(Country.Name, Country.Code);
        //            List.Add(dv);
        //        }
        //    }
        //}

        //else if (category == "City")
        //{
        //    string CountryCode = knownCategoryValues.Replace("Country:", "").Trim();
        //    IList CityList = this._CommonService.FindCitiesByCountryCode(CountryCode);

        //    for (int index = 0; index < CityList.Count; index++)
        //    {
        //        CommCity City = (CommCity)CityList[index];
        //        if (City != null)
        //        {
        //            AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(City.Name, City.Code);
        //            List.Add(dv);
        //        }
        //    }
        //}

        //else if (category == "Hotel")
        //{
        //    string CityCode = knownCategoryValues.Replace("City:", "").Trim();
        //    IList HotelList = this._BaseService.GetHotels(CityCode);

        //    for (int index = 0; index < HotelList.Count; index++)
        //    {
        //        THotel Hotel = (THotel)HotelList[index];

        //        if (Hotel != null)
        //        {

        //            AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(Hotel.Name, Hotel.Id.ToString());
        //            List.Add(dv);
        //        }
        //    }
        //}

        //else if (category == "Room")
        //{
        //    string HotelID = knownCategoryValues.Replace("Hotel:", "").Trim();

        //    IList RoomList = this._BaseService.GetRooms(new Guid(HotelID));

        //    for (int index = 0; index < 3; index++)
        //    {
        //        THotelRoom room = (THotelRoom)RoomList[index];
        //        if (room != null)
        //        {
        //            AjaxControlToolkit.CascadingDropDownNameValue dv = new AjaxControlToolkit.CascadingDropDownNameValue(room.Name, room.Id.ToString());
        //            List.Add(dv);
        //        }
        //    }
        //}

        //if (List.Count > 0)
        //{
        //    dvs = (AjaxControlToolkit.CascadingDropDownNameValue[])List.ToArray(typeof(AjaxControlToolkit.CascadingDropDownNameValue));
        //}

        //return dvs;

        #endregion
    }

}

