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
using TERMS.Common.Search;


    public class SearchingLogger
    {
        public void Log(DateTime searchingBeginningTime,
                        DateTime searchingEndingTime,
                        ISearchCondition searchCondition)
        {
            if (searchCondition is Terms.Sales.Business.AirSearchCondition) 
            {
                AirSearchingLogger.Log(searchingBeginningTime, searchingEndingTime, searchCondition);
            }
            else if (searchCondition is Terms.Sales.Business.HotelSearchCondition)
            {
                HotelSearchingLogger.Log(searchingBeginningTime, searchingEndingTime, searchCondition);
            }
            else if (searchCondition is Terms.Sales.Business.PackageSearchCondition)
            {
                PackageSearchingLogger.Log(searchingBeginningTime, searchingEndingTime, searchCondition);
            }
            else if (searchCondition is Terms.Sales.Business.TourSearchCondition)
            {
                if(searchCondition == null)
                    TourSearchingLogger.Log(searchingBeginningTime, searchingEndingTime);
                else
                    TourSearchingLogger.Log(searchingBeginningTime, searchingEndingTime, searchCondition);
            }

        }
    }

    public class AirSearchingLogger
    {
        private static readonly log4net.ILog logger =
         log4net.LogManager.GetLogger("AirSearching");

        public static void Log(DateTime searchingBeginningTime,
                        DateTime searchingEndingTime,
                        ISearchCondition searchCondition)
        {
            logger.Info(
                string.Format("[{0}] Air searching begin at {1} end at {2}, Searching Condition: {3}",
                ((TimeSpan)searchingEndingTime.Subtract(searchingBeginningTime)).ToString(),
                searchingBeginningTime.ToString(),
                searchingEndingTime.ToString(),
                searchCondition.ToString()));
        }
    }

    public class HotelSearchingLogger
    {
        private static readonly log4net.ILog logger =
         log4net.LogManager.GetLogger("HotelSearching");

        public static void Log(DateTime searchingBeginningTime,
                        DateTime searchingEndingTime,
                        ISearchCondition searchCondition)
        {
            logger.Info(
                string.Format("[{0}] Hotel searching begin at {1} end at {2}, Searching Condition: {3}",
                ((TimeSpan)searchingEndingTime.Subtract(searchingBeginningTime)).ToString(),
                searchingBeginningTime.ToString(),
                searchingEndingTime.ToString(),
                searchCondition.ToString()));
        }
    }

    public class PackageSearchingLogger
    {
        private static readonly log4net.ILog logger =
         log4net.LogManager.GetLogger("PackageSearching");

        public static void Log(DateTime searchingBeginningTime,
                        DateTime searchingEndingTime,
                        ISearchCondition searchCondition)
        {
            logger.Info(
                string.Format("[{0}] Package searching begin at {1} end at {2}, Searching Condition: {3}",
                ((TimeSpan)searchingEndingTime.Subtract(searchingBeginningTime)).ToString(),
                searchingBeginningTime.ToString(),
                searchingEndingTime.ToString(),
                searchCondition.ToString()));
        }
    }

    public class TourSearchingLogger
    {
        private static readonly log4net.ILog logger =
         log4net.LogManager.GetLogger("TourSearching");

        public static void Log(DateTime searchingBeginningTime,
                        DateTime searchingEndingTime,
                        ISearchCondition searchCondition)
        {
            logger.Info(
                string.Format("[{0}] Tour searching begin at {1} end at {2}, Searching Condition: {3}",
                ((TimeSpan)searchingEndingTime.Subtract(searchingBeginningTime)).ToString(),
                searchingBeginningTime.ToString(),
                searchingEndingTime.ToString(),
                searchCondition.ToString()));
        }

        public static void Log(DateTime searchingBeginningTime,
                        DateTime searchingEndingTime)
        {
            logger.Info(
                string.Format("[{0}] Tour searching begin at {1} end at {2}, Searching All Tours",
                ((TimeSpan)searchingEndingTime.Subtract(searchingBeginningTime)).ToString(),
                searchingBeginningTime.ToString(),
                searchingEndingTime.ToString()));
        }
    }
