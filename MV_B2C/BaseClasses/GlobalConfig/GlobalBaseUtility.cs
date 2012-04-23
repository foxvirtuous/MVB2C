using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Spring.Context;
using Spring.Context.Support;

using Terms.Configuration.Domain;
using Terms.Configuration.Service;

/// <summary>
/// Summary description for GlobalUtility
/// </summary>
public class GlobalBaseUtility
{
    public GlobalBaseUtility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static WebSiteMeta CurrentWebSite
    {
        get
        {
            if (HttpContext.Current == null) return null;

            if (HttpContext.Current.Session[SessionNames.CurrentWebSite] == null)
            {
                HttpContext.Current.Session[SessionNames.CurrentWebSite] =
                    ((IWebSiteService)ContextRegistry.GetContext()["WebSiteService"]).Get(GetWebSite(HttpContext.Current.Request.Url));

                if (HttpContext.Current.Session[SessionNames.CurrentWebSite] == null)
                {
                    HttpContext.Current.Session[SessionNames.CurrentWebSite] = new WebSiteMeta();
                }
            }

            return (WebSiteMeta)HttpContext.Current.Session[SessionNames.CurrentWebSite];
        }
        set
        {
            HttpContext.Current.Session.Add(SessionNames.CurrentWebSite, value);
        }
    }

    public static string GetClassName(string webStie)
    {
        string className;

        className = string.Empty;

        switch (webStie)
        {
            case WebSites.TurboTT:
                className = ClassNames.TurboTT;
                break;

            case WebSites.ESoon:
                className = ClassNames.ESoon;
                break;

            case WebSites.Namei:
                className = ClassNames.Namei;
                break;

            case WebSites.Urban:
                className = ClassNames.Urban;
                break;

            case WebSites.Eco:
                className = ClassNames.Eco;
                break;

            case WebSites.EAir:
                className = ClassNames.EAir;
                break;

            case WebSites.Transpacific:
                className = ClassNames.Transpacific;
                break;

            case WebSites.Madison:
                className = ClassNames.Madison;
                break;

            case WebSites.Excel:
                className = ClassNames.Excel;
                break;

            case WebSites.Vina:
                className = ClassNames.Vina;
                break;

            case WebSites.Service:
                className = ClassNames.Service;
                break;

            case WebSites.Atravel:
                className = ClassNames.Atravel;
                break;

            default:
                className = ClassNames.Majestic;
                break;

        }

        return className;
    }

    public static string GetGroupCode()
    {
        string groupCode = null;

        if (Utility.Transaction.Member != null)
        {
            groupCode = Utility.Transaction.Member.GroupCode;
        }

        return groupCode;
    }

    public static string GetWebSite(Uri uri)
    {
        string webSite;

        webSite = string.Empty;

        string absoluteUri = uri.AbsoluteUri.ToLower();

        if (absoluteUri.Contains(WebSites.TurboTTDemo2.ToString()))
        {
            webSite = WebSites.TurboTT.ToString();  
        }
        else if (absoluteUri.Contains(WebSites.TurboTT.ToString()))
        {
            webSite = WebSites.TurboTT.ToString();
        }

        else if (absoluteUri.Contains(WebSites.ESoonShort.ToString()))
        {
            webSite = WebSites.ESoon.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Namei.ToString()))
        {
            webSite = WebSites.Namei.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Urban.ToString()))
        {
            webSite = WebSites.Urban.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Eco.ToString()))
        {
            webSite = WebSites.Eco.ToString();
        }

        else if (absoluteUri.Contains(WebSites.EAir.ToString()))
        {
            webSite = WebSites.EAir.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Transpacific.ToString()))
        {
            webSite = WebSites.Transpacific.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Madison.ToString()))
        {
            webSite = WebSites.Madison.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Excel.ToString()))
        {
            webSite = WebSites.Excel.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Vina.ToString()))
        {
            webSite = WebSites.Vina.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Service.ToString()))
        {
            webSite = WebSites.Service.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Atravel.ToString()))
        {
            webSite = WebSites.Atravel.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Mjestic.ToString()))
        {
            webSite = WebSites.Mjestic.ToString();
        }

        else
        {
            webSite = WebSites.Mjestic.ToString();
        }

        SetSiteName(webSite);

        return webSite;

    }

    public static string SetWebSite(Uri uri)
    {
        string webSite;

        webSite = string.Empty;

        string absoluteUri = uri.AbsoluteUri.ToLower();

        if (absoluteUri.Contains(WebSites.TurboTT.ToString()))
        {
            webSite = WebSites.TurboTT.ToString();
        }

        else if (absoluteUri.Contains(WebSites.ESoon.ToString()))
        {
            webSite = WebSites.ESoon.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Namei.ToString()))
        {
            webSite = WebSites.Namei.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Urban.ToString()))
        {
            webSite = WebSites.Urban.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Eco.ToString()))
        {
            webSite = WebSites.Eco.ToString();
        }

        else if (absoluteUri.Contains(WebSites.EAir.ToString()))
        {
            webSite = WebSites.EAir.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Transpacific.ToString()))
        {
            webSite = WebSites.Transpacific.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Madison.ToString()))
        {
            webSite = WebSites.Madison.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Excel.ToString()))
        {
            webSite = WebSites.Excel.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Vina.ToString()))
        {
            webSite = WebSites.Vina.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Service.ToString()))
        {
            webSite = WebSites.Service.ToString();
        }

        else if (absoluteUri.Contains(WebSites.Atravel.ToString()))
        {
            webSite = WebSites.Atravel.ToString();
        }
        else
        {
            webSite = "Default";
        }

        SetSiteName(webSite);

        //…Ë÷√WebInfo
        SetWebInfo(webSite);

        return webSite;

    }

    private static void SetWebInfo(string webSiteName)
    {
        if (CurrentWebSite.Id == Guid.Empty && CurrentWebSite.Name != webSiteName.Trim())
        {
            CurrentWebSite = ((IWebSiteService)ContextRegistry.GetContext()["WebSiteService"]).Get(webSiteName);
        }
    }

    private static void SetSiteName(string webSiteName)
    {
        ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.WebSiteName, webSiteName);

    }

    static public bool IsEsoonSite()
    {
        string webSiteName = GlobalBaseUtility.GetWebSite(HttpContext.Current.Request.Url);
        return webSiteName == WebSites.ESoon;
    }

    static public string GetWebSiteName()
    {
        string webSiteName = GlobalBaseUtility.GetWebSite(HttpContext.Current.Request.Url);
        return webSiteName;
    }

    public static string GetDirectFromName()
    {
        if (!IsEsoonSite())
        {
            return null;
        }

        if (HttpContext.Current == null)
        {
            return null;
        }
        else
        {
            if (HttpContext.Current.Session[OrderBaseInfoProperties.DirectFromName] == null)
            {
                if (Utility.Transaction != null && Utility.Transaction.Member != null)
                {
                    HttpContext.Current.Session[OrderBaseInfoProperties.DirectFromName] = Utility.Transaction.Member.DirectFrom;

                    if (HttpContext.Current.Session[OrderBaseInfoProperties.DirectFromName] != null)
                    {
                        return HttpContext.Current.Session[OrderBaseInfoProperties.DirectFromName].ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return HttpContext.Current.Session[OrderBaseInfoProperties.DirectFromName].ToString();
            }            
        }
    }

    public static void SetDirectFromName(string directFromName)
    {
        HttpContext.Current.Session.Add(OrderBaseInfoProperties.DirectFromName, directFromName);
        
    }
}

static public class ControlHelper
{
    static public void AddStyleSheet(System.Web.UI.Page page, string cssPath)
    {
        if (page.Header == null)
        {
            return;
        }

        if (page.Header.ClientID == "None")
        {
            return;
        }

        HtmlLink link = new HtmlLink();
        link.Href = cssPath;
        link.Attributes["rel"] = "stylesheet";
        link.Attributes["type"] = "text/css";


        page.Header.Controls.Add(link);
    }

    static public void AddHtmlMeta(System.Web.UI.Page page, string name,string context)
    {
        if (page.Header == null)
        {
            return;
        }

        if (page.Header.ClientID == "None")
        {
            return;
        }

        if (name == null || context ==null)
        {
            return;
        }
        HtmlMeta meta = new HtmlMeta();
        meta.Content = context;
        meta.Name = name;
        page.Header.Controls.Add(meta);
    }

    static public string GetNotNullString(object value)
    {
        if (value == null)
        {
            return string.Empty;
        }

        return value.ToString();
    }

    static public void AddIcon(System.Web.UI.Page page, string imagePath)
    {
        if (page.Header == null)
        {
            return;
        }

        if (page.Header.ClientID == "None")
        {
            return;
        }

        HtmlLink link = new HtmlLink();
        link.Href = imagePath;
        link.Attributes["rel"] = "shortcut icon";
        page.Header.Controls.Add(link);
    }
}


