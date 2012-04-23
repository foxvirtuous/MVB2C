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
using Spring.Web.UI;
using Terms.Material.Service;
using Terms.Common.Service;
using Terms.Sales.Service;
using Terms.Base.Service;

namespace Terms.Web.B2B_SUB
{
    public partial class TourIndex : IndexPageBase
    {
        private AirService m_airService;

        protected AirService AirService
        {
            get
            {
                return m_airService;

            }
            set
            {
                m_airService = value;
            }
        }

        private ICommonService _CommonService;

        public ICommonService CommonService
        {
            set
            {
                this._CommonService = value;
            }
        }

        private IApplicationCacheFoundationDate _ApplicationCacheFoundationDate;
        public IApplicationCacheFoundationDate ApplicationCacheFoundationDate
        {
            set
            {
                this._ApplicationCacheFoundationDate = value;
            }
        }
        private IBaseService _baseService;
        public IBaseService BaseService
        {
            set { _baseService = value; }
        }

        public Terms.Sales.Business.Transaction Transaction
        {
            set
            {
                Utility.Transaction = value;
            }
            get
            {
                return Utility.Transaction;
            }
        }

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

                if (port == 80)
                    return "http://" + UrlHost + path + "/";
                else
                    return "http://" + UrlHost + ":" + port.ToString() + path + "/";
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utility.IsLogin)
            {
                if (!Utility.IsSubAgent)
                {
                    this.Response.Redirect("Login.aspx");
                }
            }
            else
            {
                this.Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["tab"] != null && Request.QueryString["tab"] != "")
                {
                    this.CurrentTab.Value = Request.QueryString["tab"].ToString().ToUpper();
                }
                else
                {
                }

                Header1.CurrentTabName = "t";
            }

            Ajax.Utility.RegisterTypeForAjax(typeof(Index));
        }
    }
}
