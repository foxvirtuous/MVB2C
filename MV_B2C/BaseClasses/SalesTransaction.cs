using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TERMS.Business.Centers.SalesCenter;
using Terms.Member.Business;
using Terms.Member.Service;
using Spring.Context.Support;

/// <summary>
/// SalesTransaction 的摘要说明
/// </summary>
public class Utility
{
    private static IMemberInformationService memberInformationService = null;

    public static IMemberInformationService MemberService
    {
        get
        {
            if (memberInformationService == null)
                memberInformationService = ContextRegistry.GetContext()["MemberInformationService"] as IMemberInformationService;

            return memberInformationService;
        }

    }

    public Utility()
    {
       
    }

    public static Terms.Sales.Business.Transaction Transaction
    {
        set
        {
            System.Web.HttpContext.Current.Session["Transaction"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["Transaction"] == null)
            {
                System.Web.HttpContext.Current.Session["Transaction"] = new Terms.Sales.Business.Transaction();
            }

            if (((Terms.Sales.Business.Transaction)System.Web.HttpContext.Current.Session["Transaction"]).Member == null)
            {
                Terms.Sales.Business.Transaction tr = (Terms.Sales.Business.Transaction)System.Web.HttpContext.Current.Session["Transaction"];
                MemberInformation Member = MemberService.FindMemberByID(ControlHelper.GetNotNullString(ConfigurationManager.AppSettings.Get("CommonChannel")));

                if (Member != null)
                {
                    Member.Source = SourceName;
                    tr.IsLogin = false;
                    tr.Member = Member;
                }
            }

            return (Terms.Sales.Business.Transaction)System.Web.HttpContext.Current.Session["Transaction"];
        }
    }

    protected static string SourceName
    {
        get
        {
            return GlobalBaseUtility.GetClassName(GlobalBaseUtility.GetWebSite(HttpContext.Current.Request.Url));
        }
    }

    public static List<string> HotelSortRule
    {
        set
        {
            System.Web.HttpContext.Current.Session["HotelSortRule"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["HotelSortRule"] == null)
            {
                System.Web.HttpContext.Current.Session["HotelSortRule"] = new List<string>();
            }

            return (List<string>)System.Web.HttpContext.Current.Session["HotelSortRule"];
        }
    }

    public static List<string> DeleteHotel
    {
        set
        {
            System.Web.HttpContext.Current.Session["DeleteHotel"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["DeleteHotel"] == null)
            {
                System.Web.HttpContext.Current.Session["DeleteHotel"] = new List<string>();
            }

            return (List<string>)System.Web.HttpContext.Current.Session["DeleteHotel"];
        }
    }

    public static string BackFlag
    {
        set
        {
            System.Web.HttpContext.Current.Session["BackFlag"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["BackFlag"] == null)
            {
                System.Web.HttpContext.Current.Session["BackFlag"] = "0";
            }

            return (string)System.Web.HttpContext.Current.Session["BackFlag"];
        }
    }

    public static string PackageBackFlag
    {
        set
        {
            System.Web.HttpContext.Current.Session["PackageBackFlag"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["PackageBackFlag"] == null)
            {
                System.Web.HttpContext.Current.Session["PackageBackFlag"] = "0";
            }

            return (string)System.Web.HttpContext.Current.Session["PackageBackFlag"];
        }
    }

    public static bool IsSearchConditionNull
    {
        get
        {
            if (System.Web.HttpContext.Current.Session["Transaction"] == null)
            {
                return true;
            }
            else
            {
                if (Transaction.CurrentSearchConditions == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    public static bool IsLogin
    {
        get
        {
            if (System.Web.HttpContext.Current.Session["Transaction"] == null)
            {
                return false;
            }
            else
            {
                return Transaction.IsLogin;
            }
        }
    }

    public static bool IsSubAgent
    {
        get
        {
            if (System.Web.HttpContext.Current.Session["Transaction"] == null)
            {
                return false;
            }
            else
            {
                return Transaction.IsSubAgent;
            }
        }
    }

    //public static ComponentGroup SelectAirGroup
    //{
    //    set
    //    {
    //        System.Web.HttpContext.Current.Session["SelectAirGroup"] = value;
    //    }
    //    get
    //    {
    //        if (System.Web.HttpContext.Current.Session["SelectAirGroup"] == null)
    //        {
    //            //System.Web.HttpContext.Current.Session["SelectAirGroup"] = new ComponentGroup();
    //            return null;
    //        }
    //        else
    //        {
    //            return (ComponentGroup)System.Web.HttpContext.Current.Session["SelectAirGroup"];
    //        }
    //    }
    //}

    public static bool IsTourMain
    {
        set
        {
            System.Web.HttpContext.Current.Session["TourMain"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["TourMain"] == null)
            {
                return false;
            }
            else
            {
                return (bool)System.Web.HttpContext.Current.Session["TourMain"];
            }
        }
    }

    public static bool IsTourMore
    {
        set
        {
            System.Web.HttpContext.Current.Session["TourMore"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["TourMore"] == null)
            {
                return false;
            }
            else
            {
                return (bool)System.Web.HttpContext.Current.Session["TourMore"];
            }
        }
    }

    public static List<string> TourCitys
    {
        set
        {
            System.Web.HttpContext.Current.Session["TourCitys"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["TourCitys"] == null)
            {
                return new List<string>();
            }
            else
            {
                return (List<string>)System.Web.HttpContext.Current.Session["TourCitys"];
            }
        }
    }

    public static List<string> SetTourLandOnlyCitys
    {
        set
        {
            System.Web.HttpContext.Current.Session["SetTourLandOnlyCitys"] = value;
        }
        get
        {
            if (System.Web.HttpContext.Current.Session["SetTourLandOnlyCitys"] == null)
            {
                return new List<string>();
            }
            else
            {
                return (List<string>)System.Web.HttpContext.Current.Session["SetTourLandOnlyCitys"];
            }
        }
    }
}
