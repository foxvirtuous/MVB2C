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
using TERMS.Business.Centers.ProductCenter.Profiles;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Core.Product;

/// <summary>
/// FlightInfoHider 的摘要说明

/// </summary>
public class FlightInfoHider
{
    public const string DISP_MESSAGE = "Airline names, flight numbers, and exact departure & arrival time will be displayed later after entering traveller's information.";

    public string DispMessage
    {
        get { return DISP_MESSAGE; }
    }

    private bool m_IsDisplay = false;
    public bool IsDisplay
    {
        set { m_IsDisplay = value; }
    }

    public FlightInfoHider()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public bool IsNeedToHide(Component merchandise)
    {
        bool result = false;

       string strAirLineCode = ((AirProfile)merchandise.Profile).Airlines[0].Code.Trim().ToString();

       result = IsNeedToHide(strAirLineCode, merchandise.Profile.GetParam("FARE_TYPE").ToString());
       
       return result;
    }

    public string ReplaceFlightCode(Component merchandise)
    {
        return ReplaceFlightName(merchandise);
    }

    public string ReplaceFlightName(Component merchandise)
    {
        string resultName = string.Empty;

        string strAirLineCode = ((AirProfile)merchandise.Profile).Airlines[0].Code.Trim().ToString();

        resultName = ReplaceFlightName(strAirLineCode, merchandise.Profile.GetParam("FARE_TYPE").ToString());

        return resultName;
    }

    public bool IsNeedToHide(string AirCode, string FareType)
    {
        bool result = false;

        if (!FareType.Equals(Terms.Product.Utility.FlightFareType.PUB.ToString()))
        {

            //获得配置文件并转换为DataSet
            System.Data.DataSet dsAirLineConfig = PageUtility.GetReciever();
            //判断配置数据是否存在
            if (dsAirLineConfig.Tables.Count > 0 && dsAirLineConfig.Tables[0] != null && dsAirLineConfig.Tables[0].Rows.Count == 1)
            {
                //判断当前Code是否存在于配置数据中
                if (dsAirLineConfig.Tables[0].Columns.Contains(AirCode.ToUpper().Trim()))
                    result = true;
            }

        }

        return result;
    }

    public string ReplaceFlightName(string AirLineCode,string FareType)
    {
        string resultName = string.Empty;

        if (!FareType.Equals(Terms.Product.Utility.FlightFareType.PUB.ToString()))
        {
            //获得配置文件并转换为DataSet
            System.Data.DataSet dsAirLineConfig = PageUtility.GetReciever();
            //判断配置数据是否存在
            if (dsAirLineConfig.Tables.Count > 0 && dsAirLineConfig.Tables[0] != null && dsAirLineConfig.Tables[0].Rows.Count == 1)
            {
                //判断当前Code是否存在于配置数据中
                if (dsAirLineConfig.Tables[0].Columns.Contains(AirLineCode.ToUpper().Trim()))
                {
                    resultName = dsAirLineConfig.Tables[0].Rows[0][AirLineCode.ToUpper().Trim()].ToString();
                }
            }
        }

        return resultName;
    }

    /// <summary>
    /// 对时间进行转换。转制成
    /// </summary>
    /// <param name="strTime"></param>
    /// <returns></returns>
    public string TimeToName(string strTime)
    {
        string result = string.Empty;
        try
        {
            DateTime time = Convert.ToDateTime(strTime);
            if (time >= Convert.ToDateTime("6:00") && time < Convert.ToDateTime("11:59"))
            {
                result = "Morning ";
            }
            if (time >= Convert.ToDateTime("12:00") && time < Convert.ToDateTime("12:59"))
            {
                result = "Noon  ";
            }
            if (time >= Convert.ToDateTime("13:00") && time < Convert.ToDateTime("18:59"))
            {
                result = "Afternoon  ";
            }
            if ((time >= Convert.ToDateTime("19:00") && time < Convert.ToDateTime("23:59")) || (time >= Convert.ToDateTime("00:00") && time < Convert.ToDateTime("5:59")))
            {
                result = "Night  ";
            }


        }
        catch
        { 
            
        }

        return result;

    }
}
