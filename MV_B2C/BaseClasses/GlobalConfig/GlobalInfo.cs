using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



/// <summary>
/// 域名
/// </summary>
//--------tonglanli 20081212 TurboTT Demo1
public struct WebSites
{
    public const string TurboTT = "demo1.turbott.com";
    public const string TurboTTDemo2 = "demo2.turbott.com";
    public const string ESoon = "www.esoon-travel.com";
    public const string ESoonShort = "esoon-travel.com";
    public const string Namei = "namei.turbott.com";
    public const string Urban = "urban.turbott.com";
    public const string Eco = "www.travelecotravel.com";
    public const string EAir = "eair.turbott.com";
    public const string Transpacific = "www.transpacific-travel.com";
    public const string Madison = "madison.turbott.com";
    public const string Excel = "www.excel-travel.com";
    public const string Vina = "vina.turbott.com";
    public const string Service = "service.turbott.com";
    public const string Atravel = "atravel.turbott.com";
    public const string Mjestic = "www.majestic-vacations.com";
}

public struct CustomerServiceEmails
{
    public const string GraceFang = "service@esoon-travel.com";
}

/// <summary>
/// 友情链接的参数
/// </summary>
public struct DirectFroms
{
    public const string GraceFang = "GraceFang";

}

/// <summary>
/// Sessions
/// </summary>
public struct SessionNames
{
    public const string CurrentWebSite = "CurrentWebSite";

}

/// <summary>
/// AppSettings
/// </summary>
//--------tonglanli 20081215 更改图片路径
public struct AppSettings
{
    public const string StoreFrontWebSiteURLForImage = "StoreFrontWebSiteURLForImage";
}

/// <summary>
/// CCEmails
/// </summary>
public struct CCEmails
{
    
    public const string Default = ""; //Default设置成cc，会导致发送Email时，用cc覆盖bcc，改成空字符串后就会保留bcc的内容了
    //public const string Default = "cc";
    public const string GraceFang = "ccGraceFang";

}

/// <summary>
/// 友情链接的Url
/// </summary>
public struct DirectFromURLs
{
    public const string GraceFang = "yourfriendgracetang.blogspot.com";
    //public const string GraceFang = "esoon.turbott.com/testeditresource.aspx";

}

/// <summary>
/// 资源文件名
/// </summary>
public struct ClassNames
{
    public const string TurboTT = "TurboTT";
    public const string ESoon = "ESoon";
    public const string Namei = "Namei";
    public const string Urban = "Urban";
    public const string Eco = "Eco";
    public const string EAir = "EAir";
    public const string Transpacific = "Transpacific";
    public const string Madison = "Madison";
    public const string Excel = "Excel";
    public const string Vina = "Vina";
    public const string Service = "Service";
    public const string Atravel = "Atravel";
    public const string Majestic = "MVB2C";
  
}

/// <summary>
/// 用户名
/// </summary>
public struct UserNames
{
    public const string TurboTT = "TURBOTT";
    public const string ESoon = "ESOON";
    public const string Namei = "NAMEI";
    public const string Urban = "URBAN";
    public const string Eco = "ECO";
    public const string EAir = "EAIR";
    public const string Transpacific = "TRANSPACIFIC";
    public const string Madison = "MADISON";
    public const string Excel = "EXCEL";
    public const string Vina = "VINA";
    public const string Service = "SERVICE";
    public const string Atravel = "ATRAVEL";
}

/// <summary>
/// 密码
/// </summary>
public struct Passwords
{
    public const string TurboTT = "TURBOTT";
    public const string ESoon = "ESOON";
    public const string Namei = "NAMEI";
    public const string Urban = "URBAN";
    public const string Eco = "ECO";
    public const string EAir = "EAIR";
    public const string Transpacific = "TRANSPACIFIC";
    public const string Madison = "MADISON";
    public const string Excel = "EXCEL";
    public const string Vina = "VINA";
    public const string Service = "SERVICE";
    public const string Atravel = "ATRAVEL";
}

/// <summary>
/// CaseNumberPrefix
/// </summary>
public struct CaseNumberPrefixInfo
{
    public const string TurboTT = "TU";
    public const string ESoon = "ES";
    public const string Namei = "NA";
    public const string Urban = "UR";
    public const string Eco = "EC";
    public const string EAir = "EA";
    public const string Transpacific = "TR";
    public const string Madison = "MA";
    public const string Excel = "EX";
    public const string Vina = "VI";
    public const string Service = "SE";
    public const string Atravel = "AT";
}

/// <summary>
/// PNRRefNumber
/// </summary>
public struct PNRRefNumberInfo
{
    public const string TurboTT = "TurboTT";
    public const string ESoon = "eSoon";
    public const string Namei = "Namei";
    public const string Urban = "Urban";
    public const string Eco = "Eco";
    public const string EAir = "EAir";
    public const string Transpacific = "Transpacific";
    public const string Madison = "Madison";
    public const string Excel = "Excel";
    public const string Vina = "Vina";
    public const string Service = "Service";
    public const string Atravel = "Atravel";
}

/// <summary>
/// QueueNo
/// </summary>
public struct QueueNoInfo
{
    public const string TurboTT = "88";
    public const string ESoon = "88";
    public const string Namei = "20";
    public const string Urban = "36";
    public const string Eco = "36";
    public const string EAir = "228";
    public const string Transpacific = "228";
    public const string GraceFang = "90";
    public const string Madison = "51";
    public const string Excel = "10";
    public const string Vina = "51";
    public const string Service = "51";
    public const string Atravel = "228";
}

/// <summary>
/// PCC
/// </summary>
public struct PCCInfo
{
    public const string TurboTT = "V83";
    public const string ESoon = "V83";
    public const string Namei = "A83";
    public const string Urban = "K84";
    public const string Eco = "K84";
    public const string EAir = "A81";
    public const string Transpacific = "A81";
    public const string GraceFang = "A86";
    public const string Madison = "G91";
    public const string Excel = "G87";
    public const string Vina = "G91";
    public const string Service = "G91";
    public const string Atravel = "A81";
}

/// <summary>
/// CategoryNo
/// </summary>
public struct CategoryNoInfo
{
    public const string TurboTT = "0";
    public const string ESoon = "0";
    public const string Namei = "0";
    public const string Urban = "0";
    public const string Eco = "1";
    public const string EAir = "0";
    public const string Transpacific = "1";
    public const string GraceFang = "0";
    public const string Madison = "1";
    public const string Excel = "1";
    public const string Vina = "2";
    public const string Service = "3";
    public const string Atravel = "2";
}

/// <summary>
/// OrderBaseInfo
/// </summary>
public struct OrderBaseInfoProperties
{
    public const string WebSiteName = "WebSiteName";
    public const string EmailPath = "EmailPath";

    public const string CCEmails = "CCEmails";

    public const string DirectFromName = "DirectFrom";

    public const string CaseNumberPrefix = "CaseNumberPrefix";
    public const string PNRRefNumber = "PNRRefNumber";
    public const string QueueNo = "QueueNo";
    public const string PCC = "PCC";
    public const string CategoryNo = "CategoryNo";
}

public struct GlobalInfo
{
    public const string MainImagePath = "MainImagePath";
    public const string TelephoneNumber = "TelephoneNumber";
    public const string CompanyName = "CompanyName";
    public const string EmailAddress = "EmailAddress";
    public const string MainCSS = "MainCSS";
    public const string IndexCSS = "IndexCSS";
    public const string CSSPath = "CSSPath";
    public const string Style2CSS = "Style2CSS";
    public const string HtmlPath = "HtmlPath";
    public const string MainCssPath = "MainCssPath";
    public const string ImagePath = "ImagePath";

    //
    public const string TopDeal1 = "TopDeal1";
    public const string TopDeal2 = "TopDeal2";
    public const string TopDeal3 = "TopDeal3";
    public const string TopDeal4 = "TopDeal4";
    public const string TopDeal5 = "TopDeal5";
    
    
    public const string CustomerServiceName = "CustomerServiceName";
    public const string WebsiteURL = "WebsiteURL";
    public const string CustomerServiceEmail = "CustomerServiceEmail";

    //20080828
    public const string Url_ad_sub = "Url_ad_sub";
    public const string Count_ad_main = "Count_ad_main";

    //20080903 tonglanli
    public const string EmailPath = "EmailPath";

    //20080905 tonglanli
    public const string CopyRightContent = "CopyRightContent";

    //20080905 tonglanli
    public const string LogoUrl = "LogoUrl";

    //20080909 tonglanli
    public const string HomeUrl = "HomeUrl";

    //20080910 tonglanli
    public const string Url_ad_head = "Url_ad_head";

    //20080916 henry
    public const string AdminFlashImageFlag = "AdminFlashImageFlag";

    //20080916 henry
    public const string GoogleAnalyticsCode = "GoogleAnalyticsCode";

    //20080919 henry
    public const string TopInformationTitle = "TopInformationTitle";

     //20080924 henry
    public const string MsnBar = "MsnBar";

    //20081006 henry
    public const string HasMultiLanguage = "HasMultiLanguage";
    //20081008 henry
    public const string HasAboutUs = "HasAboutUs";
    public const string HasContactUs = "HasContactUs";
    public const string HasAllianceMembers = "HasAllianceMembers";
    public const string HasPressRoom = "HasPressRoom";
    
    //20081021 henry
    public const string HomePageTitle = "HomePageTitle";
    public const string HomePageMetaVerifyTagName = "HomePageMetaVerifyTagName";
    public const string HomePageMetaVerifyTagContent = "HomePageMetaVerifyTagContent";
    public const string HomePageMetaKeywordsTagName = "HomePageMetaKeywordsTagName";
    public const string HomePageMetaKeywordsTagContent = "HomePageMetaKeywordsTagContent";
    public const string HomePageMetaDescriptionTagName = "HomePageMetaDescriptionTagName";
    public const string HomePageMetaDescriptionTagContent = "HomePageMetaDescriptionTagContent";

    //20090102 henry
    public const string TermConditionURL = "TermConditionURL";
}

public class OrderBaseInfo
{
    private string m_webSiteName;
    //private string m_caseNumberPrefix;

    public OrderBaseInfo(string webSiteName)
    {
        m_webSiteName = webSiteName;
    }

    public string CaseNumberPrefix
    {
        get
        {
            switch (m_webSiteName)
            {
                case WebSites.ESoon:
                    return CaseNumberPrefixInfo.ESoon;

                case WebSites.Namei:
                    return CaseNumberPrefixInfo.Namei;

                case WebSites.Urban:
                    return CaseNumberPrefixInfo.Urban;

                case WebSites.Eco:
                    return CaseNumberPrefixInfo.Eco;
                case WebSites.EAir:
                    return CaseNumberPrefixInfo.EAir;

                case WebSites.Transpacific:
                    return CaseNumberPrefixInfo.Transpacific;

                case WebSites.Madison:
                    return CaseNumberPrefixInfo.Madison;

                case WebSites.Excel:
                    return CaseNumberPrefixInfo.Excel;

                case WebSites.Vina:
                    return CaseNumberPrefixInfo.Vina;

                case WebSites.Service:
                    return CaseNumberPrefixInfo.Service;

                case WebSites.Atravel:
                    return CaseNumberPrefixInfo.Atravel;

                case WebSites.TurboTT:
                    return CaseNumberPrefixInfo.TurboTT;

               

            }

            return string.Empty;

        }
    }

    public string PNRRefNumber
    {
        get
        {

            switch (m_webSiteName)
            {
                case WebSites.ESoon:
                    return PNRRefNumberInfo.ESoon;

                case WebSites.Namei:
                    return PNRRefNumberInfo.Namei;

                case WebSites.Urban:
                    return PNRRefNumberInfo.Urban;

                case WebSites.Eco:
                    return PNRRefNumberInfo.Eco;
                case WebSites.EAir:
                    return PNRRefNumberInfo.EAir;

                case WebSites.Transpacific:
                    return PNRRefNumberInfo.Transpacific;

                case WebSites.Madison:
                    return PNRRefNumberInfo.Madison;

                case WebSites.Excel:
                    return PNRRefNumberInfo.Excel;

                case WebSites.Vina:
                    return PNRRefNumberInfo.Vina;

                case WebSites.Service:
                    return PNRRefNumberInfo.Service;

                case WebSites.Atravel:
                    return PNRRefNumberInfo.Atravel;

                case WebSites.TurboTT:
                    return PNRRefNumberInfo.TurboTT;


            }

            return string.Empty;

        }
    }

    public string QueueNo
    {
        get
        {

            switch (m_webSiteName)
            {
                case WebSites.ESoon:
                    return QueueNoInfo.ESoon;

                case WebSites.Namei:
                    return QueueNoInfo.Namei;

                case WebSites.Urban:
                    return QueueNoInfo.Urban;

                case WebSites.Eco:
                    return QueueNoInfo.Eco;

                case WebSites.EAir:
                    return QueueNoInfo.EAir;

                case WebSites.Transpacific:
                    return QueueNoInfo.Transpacific;

                case WebSites.Madison:
                    return QueueNoInfo.Madison;

                case WebSites.Excel:
                    return QueueNoInfo.Excel;

                case WebSites.Vina:
                    return QueueNoInfo.Vina;

                case WebSites.Service:
                    return QueueNoInfo.Service;

                case WebSites.Atravel:
                    return QueueNoInfo.Atravel;

                case WebSites.TurboTT:
                    return QueueNoInfo.TurboTT;
            }

            return string.Empty;

        }
    }

    public string PCC
    {
        get
        {

            switch (m_webSiteName)
            {
                case WebSites.ESoon:
                    return PCCInfo.ESoon;

                case WebSites.Namei:
                    return PCCInfo.Namei;

                case WebSites.Urban:
                    return PCCInfo.Urban;

                case WebSites.Eco:
                    return PCCInfo.Eco;

                case WebSites.EAir:
                    return PCCInfo.EAir;

                case WebSites.Transpacific:
                    return PCCInfo.Transpacific;

                case WebSites.Madison:
                    return PCCInfo.Madison;

                case WebSites.Excel:
                    return PCCInfo.Excel;

                case WebSites.Vina:
                    return PCCInfo.Vina;

                case WebSites.Service:
                    return PCCInfo.Service;

                case WebSites.Atravel:
                    return PCCInfo.Atravel;

                case WebSites.TurboTT:
                    return PCCInfo.TurboTT;

            }

            return string.Empty;

        }
    }

    public string CategoryNo
    {
        get
        {

            switch (m_webSiteName)
            {
                case WebSites.ESoon:
                    return CategoryNoInfo.ESoon;

                case WebSites.Namei:
                    return CategoryNoInfo.Namei;

                case WebSites.Urban:
                    return CategoryNoInfo.Urban;

                case WebSites.Eco:
                    return CategoryNoInfo.Eco;

                case WebSites.EAir:
                    return CategoryNoInfo.EAir;

                case WebSites.Transpacific:
                    return CategoryNoInfo.Transpacific;

                case WebSites.Madison:
                    return CategoryNoInfo.Madison;

                case WebSites.Excel:
                    return CategoryNoInfo.Excel;

                case WebSites.Vina:
                    return CategoryNoInfo.Vina;

                case WebSites.Service:
                    return CategoryNoInfo.Service;

                case WebSites.Atravel:
                    return CategoryNoInfo.Atravel;

                case WebSites.TurboTT:
                    return CategoryNoInfo.TurboTT;

            }

            return string.Empty;

        }
    }
}

public class UserBaseInfo
{
    private string m_webSiteName;
    //private string m_caseNumberPrefix;

    public UserBaseInfo(string webSiteName)
    {
        m_webSiteName = webSiteName;
    }

    public string UserName
    {
        get
        {
            switch (m_webSiteName)
            {
                case WebSites.ESoon:
                    return UserNames.ESoon;

                case WebSites.Namei:
                    return UserNames.Namei;

                case WebSites.Urban:
                    return UserNames.Urban;

                case WebSites.Eco:
                    return UserNames.Eco;

                case WebSites.EAir:
                    return UserNames.EAir;

                case WebSites.Transpacific:
                    return UserNames.Transpacific;

                case WebSites.Madison:
                    return UserNames.Madison;

                case WebSites.Excel:
                    return UserNames.Excel;

                case WebSites.Vina:
                    return UserNames.Vina;

                case WebSites.Service:
                    return UserNames.Service;

                case WebSites.Atravel:
                    return UserNames.Atravel;

                case WebSites.TurboTT:
                    return UserNames.TurboTT;


            }

            return string.Empty;

        }
    }

    public string Password
    {
        get
        {

            switch (m_webSiteName)
            {
                case WebSites.ESoon:
                    return Passwords.ESoon;

                case WebSites.Namei:
                    return Passwords.Namei;

                case WebSites.Urban:
                    return Passwords.Urban;

                case WebSites.Eco:
                    return Passwords.Eco;

                case WebSites.EAir:
                    return Passwords.EAir;


                case WebSites.Transpacific:
                    return Passwords.Transpacific;

                case WebSites.Madison:
                    return Passwords.Madison;

                case WebSites.Excel:
                    return Passwords.Excel;

                case WebSites.Vina:
                    return Passwords.Vina;

                case WebSites.Service:
                    return Passwords.Service;

                case WebSites.Atravel:
                    return Passwords.Atravel;

                case WebSites.TurboTT:
                    return Passwords.TurboTT;

            }

            return string.Empty;

        }
    }
}
