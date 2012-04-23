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
using System.Globalization;


public partial class CJ_Ads : IndexPageBase
{
    public string SaleWebSuffix
    {
        get
        {
            return PageUtility.UrlSuffix;
        }
    }

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

        Ajax.Utility.RegisterTypeForAjax(typeof(CJ_Ads));
    }
}

