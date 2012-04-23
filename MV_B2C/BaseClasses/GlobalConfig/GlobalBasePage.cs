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
using Spring.Aspects.AirContact;
using Spring.Aspects.AirOperate;

/// <summary>
/// BasePage 的摘要说明
/// </summary>
/// <version>
/// 序号：1 作成人：童兰利 日期：2007/3/1 原因：初始作成
/// </version>
public abstract class GlobalBasePage : Spring.Web.UI.Page
{

    public GlobalBasePage()
    {

        InitializeControls += new EventHandler(BasePage_InitializeControls);
        //this.InitComplete += 
    }

    //private void SetUserInfoToApplication(string webSite)
    //{
    //    switch 
    //}

    public WebSiteMeta CurrentWebSite
    {
        get
        {
            return GlobalBaseUtility.CurrentWebSite;
        }
        set
        {
            GlobalBaseUtility.CurrentWebSite = value;
        }
    }

    protected virtual string ClassName
    {
        get
        {
            //SetPNR();
            return GlobalBaseUtility.GetClassName(GlobalBaseUtility.GetWebSite(Request.Url));
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

    protected virtual string SourceName
    {
        get
        {
            return ClassName;
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

    private string StoreFrontWebSiteURLForImage
    {
        get
        {
            return ConfigurationManager.AppSettings.Get(AppSettings.StoreFrontWebSiteURLForImage);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    //--------tonglanli 20081215 更改图片路径
    public string MainImagesPath
    {
        get
        {
            return StoreFrontWebSiteURLForImage + this.GetGlobalResourceObject(ClassName, GlobalInfo.MainImagePath).ToString() + ImageCulturePath;
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

    public string CultureName
    {
        get
        {
            if (System.Globalization.CultureInfo.CurrentCulture.Name.Equals("en-US"))
                return null;
            else
                return System.Globalization.CultureInfo.CurrentCulture.Name;
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
                return "/" + CultureName;
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

    protected string FormatUrl(string url)
    {
        string url_pre = string.Empty;

        if (url == null)
        {
            url = string.Empty;
        }

        if (url.StartsWith("http") == false)
        {
            url_pre = "http://";
        }


        if (url.Trim() == string.Empty)
        {
            return "#";
        }

        return url_pre + url;
    }

    public string TopDealHyperlink1
    {
        get
        {
            return FormatUrl(CurrentWebSite.TopDealHyperlink1);
        }
    }

    public string TopDealHyperlink2
    {
        get
        {
            return FormatUrl(CurrentWebSite.TopDealHyperlink2);
        }
    }

    public string TopDealHyperlink3
    {
        get
        {
            return FormatUrl(CurrentWebSite.TopDealHyperlink3);
        }
    }

    public string TopDealHyperlink4
    {
        get
        {
            return FormatUrl(CurrentWebSite.TopDealHyperlink4);
        }
    }

    public string TopDealHyperlink5
    {
        get
        {
            return FormatUrl(CurrentWebSite.TopDealHyperlink5);
        }
    }

    public string TopInformationTitle
    {
        get
        {

            return ControlHelper.GetNotNullString(this.GetGlobalResourceObject(ClassName, GlobalInfo.TopInformationTitle));
        }
    }

    // 2008-10-15 henry begin
    // 取消显示机票bookingclass，但是 TurboTT demo 网站保留
    public bool IsOpenBookingClass
    {
        get
        {
            if (WebsiteURL == WebSites.TurboTT)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    // 2008-10-15 henry end

    // 2009-01-02 henry begin
    public string TermConditionURL
    {
        get
        {
            return ControlHelper.GetNotNullString(this.GetGlobalResourceObject(ClassName, GlobalInfo.TermConditionURL));
        }
    }
    // 2009-01-02 henry end
    private void BasePage_InitializeControls(object sender, EventArgs e)
    {
        //设置WebSiteName信息
        GlobalBaseUtility.SetWebSite(Request.Url);

        //设置特殊页面信息
        SetSpecialDisplayInfo();

        if (!IsPostBack)
        {

        }

        //if(Re)
        SetPNR();

        //设置随即数 2008-10-27 tonglanli
        if (Session["LOG_RANDOM"] == null)
        {
            System.Random rd = new Random();
            Session["LOG_RANDOM"] = rd.Next(999999999);
        }

    }

    private void SetPNR()
    {
        ////设置WebSiteName信息
        //GlobalBaseUtility.SetWebSite(Request.Url);

        string webSiteName = GlobalBaseUtility.GetWebSite(HttpContext.Current.Request.Url);

        //设置PNR等配置文件的值
        SetOrderBaseInfo(webSiteName);

        //设置邮件路径
        SetEmailPath();
    }

    private void SetEmailPath()
    {
        string emailPath = string.Empty;

        emailPath = this.GetGlobalResourceObject(ClassName, GlobalInfo.EmailPath).ToString();

        ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.EmailPath, emailPath);
    }

    private static void SetOrderBaseInfo(string webSiteName)
    {

        OrderBaseInfo orderBaseInfo = new OrderBaseInfo(webSiteName);


        ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.CaseNumberPrefix, orderBaseInfo.CaseNumberPrefix);
        ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.PNRRefNumber, orderBaseInfo.PNRRefNumber);

        switch (GlobalBaseUtility.GetDirectFromName())
        {
            case DirectFroms.GraceFang:
                ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.QueueNo, QueueNoInfo.GraceFang);
                ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.PCC, PCCInfo.GraceFang);
                ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.CategoryNo, CategoryNoInfo.GraceFang);

                ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.CCEmails, CCEmails.GraceFang);
                break;

            default:
                ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.QueueNo, orderBaseInfo.QueueNo);
                ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.PCC, orderBaseInfo.PCC);
                ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.CategoryNo, orderBaseInfo.CategoryNo);

                ConfigurationSettings.AppSettings.Set(OrderBaseInfoProperties.CCEmails, CCEmails.Default);
                break;
        }


    }


    private const string DirectFrom = "DirectFrom";

    public string TEST_GROUP_CODE
    {
        get
        {
            return ControlHelper.GetNotNullString(ConfigurationManager.AppSettings.Get("TEST_GROUP_CODE"));
        }
    }
    protected virtual void SetSpecialDisplayInfo()
    {
        //设置页面样式
            ControlHelper.AddStyleSheet(this.Page, this.GetGlobalResourceObject(ClassName, "MainCSS").ToString().Replace(ClassName, ClassName + CulturePath));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //设置随即数 2008-10-27 tonglanli
        if (Session["LOG_RANDOM"] == null)
        {
            System.Random rd = new Random();
            Session["LOG_RANDOM"] = rd.Next(999999999);
        }
    }

    ////---------------20081006 tonglanli--------------------
    //protected void imgMsn_OnClick(object sender, EventArgs e)
    //{
    //    AnalyseContactAgt();
    //}

    //private void AnalyseContactAgt()
    //{
    //    AirContactAgentAdvice airContactAgentAdvice = new AirContactAgentAdvice();

    //    airContactAgentAdvice.CreateContactAgentLog(this);

        
    //}

    ////---------------20081006 tonglanli--------------------
}