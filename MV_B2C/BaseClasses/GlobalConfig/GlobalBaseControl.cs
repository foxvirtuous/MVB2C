using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Resources;

using Spring.Web.UI;
using Spring.Context.Support;

using Terms.Configuration.Domain;
using Terms.Configuration.Service;
using Spring.Aspects.AirOperate;


    /// <summary>
    /// BasePage 的摘要说明

    /// </summary>
    /// <version>
    /// 序号：1 作成人：童兰利 日期：2007/3/1 原因：初始作成

    /// </version>
    public abstract class GlobalBaseControl : Spring.Web.UI.UserControl
    {

        public GlobalBaseControl()
        {
            InitializeControls += new EventHandler(BasePage_InitializeControls);
        }

        public WebSiteMeta CurrentWebSite
        {
            get
            {
                return GlobalBaseUtility.CurrentWebSite;
            }
        }

        protected virtual AirStepConfirmLogAdvice OperaterAdvice
        {
            get
            {
                //SetPNR();
                return new AirStepConfirmLogAdvice();
            }
        }

        protected virtual string ClassName
        {
            get
            {
                return GlobalBaseUtility.GetClassName(GlobalBaseUtility.GetWebSite(Request.Url));
            }
        }

        protected virtual string SourceName
        {
            get
            {
                return GlobalBaseUtility.GetClassName(GlobalBaseUtility.GetWebSite(Request.Url));
            }
        }

        private string currentCSS;
        public string CurrentCSS
        {
            get
            {
                return currentCSS;
            }

            set
            {
                currentCSS = value;
            }
        }

        public string MainImagesPath
        {
            get
            {
               // return this.GetGlobalResourceObject(ClassName, GlobalInfo.MainImagePath).ToString() + ImageCulturePath;
                return this.GetGlobalResourceObject("Resource", GlobalInfo.MainImagePath).ToString() + ImageCulturePath;
            }
        }

        public string HtmlPath
        {
            get
            {
                return this.GetGlobalResourceObject("Resource", GlobalInfo.HtmlPath).ToString() + ImageCulturePath;
            }
        }

        public string TelephoneNumber
        {
            get
            {
                return CurrentWebSite.Phone;
            }
        }

        public string CompanyName
        {
            get
            {
                return CurrentWebSite.CompanyName;
            }
        }

        public string EmailAddress
        {
            get
            {
                return CurrentWebSite.ContractEmail;
            }
        }

        public string MainCSS
        {
            get
            {
                return this.GetGlobalResourceObject(ClassName, GlobalInfo.MainCSS).ToString();
            }
        }

        public string MainCssPath
        {
            get
            {
                return this.GetGlobalResourceObject("Resource", GlobalInfo.MainCssPath).ToString() + CulturePath;
            }
        }

        public string CultureName
        {
            get
            {
                if (UserCulture.Name.Equals("en-US"))
                    return null;
                else
                    return UserCulture.Name;
            }
        }

        //css Culture Path
        public string CulturePath
        {
            get
            {
                if (CultureName == null)
                    return string.Empty;
                else
                    return CultureName + "/";
            }
        }

        public string TopDeal1
        {
            get
            {
                return CurrentWebSite.TopDeal1;
            }
        }

        public string TopDeal2
        {
            get
            {
                return CurrentWebSite.TopDeal2;
            }
        }

        public string TopDeal3
        {
            get
            {
                return CurrentWebSite.TopDeal3;
            }
        }

        public string TopDeal4
        {
            get
            {
                return CurrentWebSite.TopDeal4;
            }
        }

        public string TopDeal5
        {
            get
            {
                return CurrentWebSite.TopDeal5;
            }
        }


        //image Culture Path
        public string ImageCulturePath
        {
            get
            {
                if (CultureName == null)
                    return string.Empty;
                else
                    return CultureName + "/";
            }
        }

        public string CustomerServiceName
        {
            get
            {
                return CurrentWebSite.CustomerServiceName;
            }
        }

        public string WebsiteURL
        {
            get
            {
                return this.GetGlobalResourceObject(ClassName, GlobalInfo.WebsiteURL).ToString();
            }
        }

        public string CustomerServiceEmail
        {
            get
            {
                //return this.GetGlobalResourceObject(ClassName, GlobalInfo.CustomerServiceEmail).ToString();
                switch (GlobalBaseUtility.GetDirectFromName())
                {
                    //service@esoon-travel.com
                    case DirectFroms.GraceFang:
                        return CustomerServiceEmails.GraceFang;

                    default:
                        return CurrentWebSite.CustomerServiceEmail;
                }
            }
        }

        public string GoogleAnalyticsCode
        {
            get
            {
                return ControlHelper.GetNotNullString(this.GetGlobalResourceObject(ClassName, GlobalInfo.GoogleAnalyticsCode));
            }
        }

        public string SaleWebSuffix
        {
            get
            {
                return PageUtility.UrlSuffix;
            }
        }

        public string SecureUrlSuffix
        {
            get
            {
                return PageUtility.SecureUrlSuffix;
            }
        }

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
        public bool HasAboutUs
        {
            get
            {
                string temp = ControlHelper.GetNotNullString(this.GetGlobalResourceObject(ClassName, GlobalInfo.HasAboutUs));

                if (temp.ToLower().Trim().Equals("true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool HasContactUs
        {
            get
            {
                string temp = ControlHelper.GetNotNullString(this.GetGlobalResourceObject(ClassName, GlobalInfo.HasContactUs));

                if (temp.ToLower().Trim().Equals("true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }


        public bool HasAllianceMembers
        {
            get
            {
                string temp = ControlHelper.GetNotNullString(this.GetGlobalResourceObject(ClassName, GlobalInfo.HasAllianceMembers));

                if (temp.ToLower().Trim().Equals("true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool HasPressRoom
        {
            get
            {
                string temp = ControlHelper.GetNotNullString(this.GetGlobalResourceObject(ClassName, GlobalInfo.HasPressRoom));

                if (temp.ToLower().Trim().Equals("true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

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

                //if (port == 80)
                    return "http://" + UrlHost + path + "/";
                //else
                //    return "http://" + UrlHost + ":" + port.ToString() + path + "/";
            }
        }

        public bool HasMultiLanguage
        {
            get
            {
                string temp = ControlHelper.GetNotNullString(this.GetGlobalResourceObject(ClassName, GlobalInfo.HasMultiLanguage));

                if (temp.ToLower().Trim().Equals("true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        private void BasePage_InitializeControls(object sender, EventArgs e)
        {
            //设置特殊页面信息
           // SetSpecialDisplayInfo();

            if (!IsPostBack)
            {
                

            }
        }

        //protected virtual void SetSpecialDisplayInfo()
        //{
        //    //设置页面样式
        //    ControlHelper.AddStyleSheet(this.Page, this.GetGlobalResourceObject(ClassName, "MainCSS").ToString().Replace(ClassName, ClassName + CulturePath));
        //}

        protected void SetCSSFromResource()
        {
            //设置页面样式
            ControlHelper.AddStyleSheet(this.Page, this.GetGlobalResourceObject(ClassName, "MainCSS").ToString().Replace(ClassName, ClassName + CulturePath));
        }

    }