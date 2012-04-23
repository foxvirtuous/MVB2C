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

    /// <summary>
    /// BasePage 的摘要说明
    /// </summary>
    /// <version>
    /// 序号：1 作成人：童兰利 日期：2007/3/1 原因：初始作成
    /// </version>
    public abstract class GlobalSalesBasePage : Spring.Web.UI.Page
    {

        public GlobalSalesBasePage()
        {

            InitializeControls += new EventHandler(BasePage_InitializeControls);
        }

        //private void SetUserInfoToApplication(string webSite)
        //{
        //    switch 
        //}

        protected virtual string ClassName
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
                return this.GetGlobalResourceObject(ClassName, GlobalInfo.MainImagePath).ToString();
            }
        }

        public string TelephoneNumber
        {
            get
            {
                return this.GetGlobalResourceObject(ClassName, GlobalInfo.TelephoneNumber).ToString();
            }
        }

        public string CompanyName
        {
            get
            {
                return this.GetGlobalResourceObject(ClassName, GlobalInfo.CompanyName).ToString();
            }
        }

        public string EmailAddress
        {
            get
            {
                return this.GetGlobalResourceObject(ClassName, GlobalInfo.EmailAddress).ToString();
            }
        }

        private void BasePage_InitializeControls(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (isMainCssNeeded)
                //{

                //    //设置特殊页面信息
                //    SetSpecialDisplayInfo();
                //}

            }
        }

        protected virtual void SetSpecialDisplayInfo()
        {
            //设置页面样式
            ControlHelper.AddStyleSheet(this.Page, this.GetGlobalResourceObject(ClassName, "MainCSS").ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

    }