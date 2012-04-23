using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
/// PageUtility 的摘要说明
/// </summary>
public class PageUtility
{
    public PageUtility()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static DataSet GetReciever()
    {
        DataSet ds = new DataSet();

        if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"/Config/AirLine.xml"))
        {
            ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + @"/Config/AirLine.xml");

        }

        return ds;
    }

    public static int HotelLogRandomNumber
    {
        get 
        {
            if (HttpContext.Current.Session["HOTEL_LOG_RANDOM"] == null)
                HttpContext.Current.Session["HOTEL_LOG_RANDOM"] = new Random().Next(999999999);

            return Convert.ToInt32(HttpContext.Current.Session["HOTEL_LOG_RANDOM"]);
        }
    }

    public static int TourLogRandomNumber
    {
        get
        {
            if (HttpContext.Current.Session["TOUR_LOG_RANDOM"] == null)
                HttpContext.Current.Session["TOUR_LOG_RANDOM"] = new Random().Next(999999999);

            return Convert.ToInt32(HttpContext.Current.Session["TOUR_LOG_RANDOM"]);
        }
    }

    public static TurboTT.Log.ILogExecutor TourSearchingTimeLog
    {
        get 
        {
            return TurboTT.Log.TermsLogManager.GetLogger("TourSearchTime");
        }
    }

    #region "Path"

    private static string path = string.Empty;

    /// <summary>
    /// The Path
    /// </summary>
    public static string Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }

    private static string AbsolutePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

    //端口号
    private static string UrlHost
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Request.Url.Host;
            else
                return string.Empty;
        }

    }

    //虚拟路径
    private static string VirtualPath
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Request.ApplicationPath;
            else
                return string.Empty;
        }

    }

    //普通URL网站名
    public static string UrlSuffix
    {
        get
        {
            //段口
            int port = HttpContext.Current.Request.Url.Port;
            int sslport = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SslPort"]);

            //虚拟目录
            string path = VirtualPath;
            if (path == "/") path = "";

            if (port == 80 || port == sslport)
                return @"http://" + UrlHost + path + "/";
            else
                return @"http://" + UrlHost + ":" + port.ToString() + path + "/";
        }
    }

    //SSL加密后的URL网站名
    public static string SecureUrlSuffix
    {
        get
        {
            //段口
            int port = HttpContext.Current.Request.Url.Port;
            int sslport = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SslPort"]);
            bool IsEnableSSL = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]);
            string head = @"http://";

            if (IsEnableSSL)
                head = @"https://";


            //虚拟目录
            string path = VirtualPath;

            if (path == "/") path = "";

            if (port == 80 || port == sslport)
                return head + UrlHost + path + "/";
            else
                return head + UrlHost + ":" + port.ToString() + path + "/";
        }
    }
    #endregion

    public static void AddHtmlMeta(System.Web.UI.Page page, string name, string context)
    {
        if (page.Header == null)
        {
            return;
        }

        if (page.Header.ClientID == "None")
        {
            return;
        }

        if (name == null || context == null)
        {
            return;
        }
        HtmlMeta meta = new HtmlMeta();
        meta.Name = name;

        meta.Content = context;
        page.Header.Controls.Add(meta);
    }

    public static void AddHtmlLink(System.Web.UI.Page page, string href)
    {
        if (page.Header == null)
        {
            return;
        }

        if (page.Header.ClientID == "None")
        {
            return;
        }

        if (href == null)
        {
            return;
        }

        HtmlLink link = new HtmlLink();
        link.Href = href;
        link.Attributes.Add("rel", "stylesheet");
        link.Attributes.Add("type", "text/css");
        page.Header.Controls.Add(link);
    }



}
