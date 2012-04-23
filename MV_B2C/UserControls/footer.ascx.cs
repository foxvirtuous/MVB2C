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

public partial class Footer : GlobalBaseControl
{
    private string path = string.Empty;

    #region Property
    /// <summary>
    /// The Path
    /// </summary>
    public string Path
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

    public string SaleWebSuffix
    {
        get
        {
            return PageUtility.UrlSuffix;
        }
    }

    private string AbsolutePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
    private string UrlHost
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Request.Url.Host;
            else
                return string.Empty;
        }

    }

    private string VirtualPath
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Request.ApplicationPath;
            else
                return string.Empty;
        }

    }

    private string UrlSuffix
    {
        get
        {
            //¶Î¿Ú
            int port = HttpContext.Current.Request.Url.Port;

            //ÐéÄâÄ¿Â¼
            string path = VirtualPath;
            if (path == "/") path = "";

            //if (port == 80)
                return "http://" + UrlHost + path + "/";
            //else
            //    return "http://" + UrlHost + ":" + port.ToString() + path + "/";
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
