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
using System.Globalization;


public partial class PromosIndex : IndexPageBase
{
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
            //�ο�
            int port = HttpContext.Current.Request.Url.Port;

            //����Ŀ¼
            string path = VirtualPath;
            if (path == "/") path = "";

            if (port == 80)
                return "http://" + UrlHost + path + "/";
            else
                return "http://" + UrlHost + ":" + port.ToString() + path + "/";
        }
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Header1.SetLanguageAndPhone();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["tab"] != null && Request.QueryString["tab"] != "")
            {
                this.CurrentTab.Value = Request.QueryString["tab"].ToString();
            }
            else
            {
            }

            Header1.CurrentTabName = "P";
        }

        //�ض���KeyWords
        if (UserCulture.Name.Contains("zh-CN"))
        {
            PageUtility.AddHtmlMeta(this.Page, "keywords", "���Ǽ������[�W, �������șCƱ, ���ޙCƱ, ̨��,���,����,�Ϻ� �����CƱ, �Ї����șCƱ����, ����˾Ƶ�, ȫ��Ƶ꾀��ӆُ, ���b�г�,�CƱ+�Ƶ�, ���[, ��ֵ���[,̨�����[,�Ї����[,�����|��,����,������,�W�m��, �������[, ���˳���, �]݆���[, �ʼ����[,�����]݆, ���[ͬ�I����, �CƱ��������");
            PageUtility.AddHtmlMeta(this.Page, "description", "���Ǽ������[, ���S��,�����, ����˙CƱ, �������Ї��CƱ, �Ƶ�, ���˳���������, ���[, �]݆����");
        }
        else
        {
            PageUtility.AddHtmlMeta(this.Page, "keywords", "Majestic Vacations, Cheap air tickets, Cheap flights to china, Cheap hotels, hotel rooms, vacation packages, group tours, cruises, cruise deals, depart from american, online ticket booking, China travel, US travel agency");
            PageUtility.AddHtmlMeta(this.Page, "description", "airline tickets, hotel reservations, find vacation packages, find tours , cruise deals and purchase, China Tours, China Tour Packages, Beijing tour, Shanghai tour, Yangtze River Cruise tours, China Hotel, China Travel Packages");
        }

        //��CSS
        PageUtility.AddHtmlLink(this.Page, SaleWebSuffix + MainCssPath + "style_index.css");

        
        Ajax.Utility.RegisterTypeForAjax(typeof(Index));
    }
}
