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
using System.Text;
using System.Data.SqlClient;

public partial class Index : IndexPageBase
{
    private IApplicationCacheFoundationDate _ApplicationCacheFoundationDate;
    public IApplicationCacheFoundationDate ApplicationCacheFoundationDate
    {
        set
        {
            this._ApplicationCacheFoundationDate = value;
        }
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

    #region Property
    private string path = string.Empty;
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

    public Index()
    {
        
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        if (Request.Params["Lan"] != null)
        {
            if (Request.Params["Lan"].ToString().ToUpper().Equals("CN"))
            {
                UserCulture = new CultureInfo("zh-CN");
                //�ض���ҳ��
                Response.Redirect(Request.Url.LocalPath);
            }
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


        if (!Page.IsPostBack)
        {
            //btn_SearchFare.Attributes.Add("onclick", "SeachOrder()");
            
            //��¼Index�������
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.DirectFrom, this);

            if (Request.QueryString["tab"] != null && Request.QueryString["tab"] != "")
            {
                this.CurrentTab.Value = Request.QueryString["tab"].ToString();
            }
            else
            {
            }
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Index));
    }
    private bool SearchA()
    {
        if (Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchAir, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchAir, this);

        Session["HasReminder"] = true;

        if (CheckSearch())
        {
            bool IsSelectAirport = false;
            bool IsRealCity = true;

            if (!IsRealCity)
            {
                if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                {
                    Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }

                Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
            }
            else
            {
                if (IsSelectAirport)
                {
                    Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                    {
                        Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }

                    Response.Redirect("~/Page/Flight/Searching.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Serarch", "<script>alert('Invaluable search condition.');</script>");
            return false;
        }

        return true;
    }

    private bool CheckSearch()
    {
        object obj = this.FindControl("SearchEngineA1_rdbRoundTrip");
        return true;
    }
}