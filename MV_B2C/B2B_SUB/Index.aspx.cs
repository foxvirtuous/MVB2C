using Spring.Context;
using Spring.Context.Support;

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

using Terms.Global.Utility;
using Terms.Material.Service;
using Terms.Product.Utility;
using Terms.Common.Domain;
using Terms.Common.Dao;
using Terms.Common.Service;
using Terms.Sales.Dao;
using Terms.Sales.Domain;
using Terms.Sales.Utility;
using Terms.Sales.Service;
using Terms.Sales.Business;
using Terms.Base.Service;
using TERMS.Common;
using Terms.Additional.Service;

namespace Terms.B2B_SUB
{
    public partial class Index : IndexPageBase
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

        private IEditFlyerService m_EditFlyerService;

        public IEditFlyerService EditFlyerService
        {
            set { m_EditFlyerService = value; }
            get { return m_EditFlyerService; }
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
                //段口
                int port = HttpContext.Current.Request.Url.Port;

                //虚拟目录
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
                    this.CurrentTab.Value = Request.QueryString["tab"].ToString();
                }

                BindMarket();
            }

            Ajax.Utility.RegisterTypeForAjax(typeof(Index));
        }


        private void BindMarket()
        {
            IList ilist = m_EditFlyerService.GetFlyerRegion("Air + Hotel", @"0', '2");

            dlPackage.DataSource = ilist;
            dlPackage.DataBind();

            for (int i = 0; i < dlPackage.Items.Count; i++)
            {
                Label lbl = (Label)dlPackage.Items[i].FindControl("lblPackage");

                if (System.IO.File.Exists(Server.MapPath("~/images/b2b/") + ilist[i].ToString() + ".gif"))
                {
                    lbl.Text = @"<a href='Flyer_pkg.aspx?Type=" + HttpUtility.UrlEncode("Air + Hotel") + "&Region=" + ilist[i].ToString() + "' class='d01'><img src='../images/b2b/" + ilist[i].ToString() + ".gif' hspace='3' border='0' align='absmiddle' /><br /><u>" + ilist[i].ToString() + "</u></a>";
                }
                else
                {
                    lbl.Text = @"<a href='Flyer_pkg.aspx?Type=" + HttpUtility.UrlEncode("Air + Hotel") + "&Region=" + ilist[i].ToString() + "' class='d01'><img src='../images/b2b/defualeflyer.gif' hspace='3' border='0' align='absmiddle' /><br /><u>" + ilist[i].ToString() + "</u></a>";
                }
            }

            ilist = m_EditFlyerService.GetFlyerRegion("Tour", @"0','2");

            dlTour.DataSource = ilist;
            dlTour.DataBind();

            for (int i = 0; i < dlTour.Items.Count; i++)
            {
                Label lbl = (Label)dlTour.Items[i].FindControl("lblTour");

                if (System.IO.File.Exists(Server.MapPath("~/images/b2b/") + ilist[i].ToString() + ".gif"))
                {
                    lbl.Text = @"<a href='Flyer_grp.aspx?Type=" + HttpUtility.UrlEncode("Tour") + "&Region=" + ilist[i].ToString() + "' class='d01'><img src='../images/b2b/" + ilist[i].ToString() + ".gif' hspace='3' border='0' align='absmiddle' /><br /><u>" + ilist[i].ToString() + "</u></a>";
                }
                else
                {
                    lbl.Text = @"<a href='Flyer_grp.aspx?Type=" + HttpUtility.UrlEncode("Tour") + "&Region=" + ilist[i].ToString() + "' class='d01'><img src='../images/b2b/defualeflyer.gif' hspace='3' border='0' align='absmiddle' /><br /><u>" + ilist[i].ToString() + "</u></a>";
                }
            }
        }
    }
}
