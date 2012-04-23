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

public partial class HotelRedirect : SalseBasePage
{
    public HotelRedirect()
    {
        this.InitializeControls += new EventHandler(HotelRedirect_InitializeControls);
    }

    void HotelRedirect_InitializeControls(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Request["CountryCode"] != null && this.Request["CityCode"] != null)
            {
                int iRoomNumber = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RoomNumber"]);

                List<int> listAdults = UnConvert(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Adults"]));

                List<int> listChilds = UnConvert(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Childs"]));

                string strCountryCode = this.Request["CountryCode"];
                string strCityCode = this.Request["CityCode"];

                DateTime dateChechkIn = DateTime.Now.AddDays(Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["DateCheckIn"])).Date;
                DateTime dateChechkOut = DateTime.Now.AddDays(Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["DateCheckOut"])).Date;

                HotelSearchCondition hotelSearchCondition = new HotelSearchCondition();

                for (int i = 0; i < iRoomNumber; i++)
                {
                    RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

                    roomSearchCondition.Passengers.Add(PassengerType.Adult, listAdults[i]);
                    roomSearchCondition.Passengers.Add(PassengerType.Child, listChilds[i]);

                    hotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
                }
                hotelSearchCondition.Country = strCountryCode;
                hotelSearchCondition.Location = strCityCode;
                hotelSearchCondition.LocationIndicator = LocationIndicator.City;
                hotelSearchCondition.CheckIn = Convert.ToDateTime(dateChechkIn);
                hotelSearchCondition.CheckOut = Convert.ToDateTime(dateChechkOut);
                this.Transaction.CurrentSearchConditions = hotelSearchCondition;
                this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();

                this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Hotel/HotelSelectForm");
            }
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
