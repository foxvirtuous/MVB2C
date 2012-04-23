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

public partial class Index2 : IndexPageBase
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

    public string PageName
    {
        get
        {
            if (this.Request["pagename"] == null)
            {
                return @"area_cn_main.htm";
            }
            else
            {
                return this.Request["pagename"];
            }
        }
    }

    public string TopImageName
    {
        get
        {
            if (this.Request["areacode"] == null)
            {
                return @"area_cn01.jpg";
            }
            else
            {
                switch (this.Request["areacode"])
                {
                    case "af":
                        return @"area_af01.jpg";
                        break;
                    case "cn":
                        return @"area_cn01.jpg";
                        break;
                    case "ca":
                        return @"area_ca01.jpg";
                        break;
                    case "eu":
                        return @"area_eu01.jpg";
                        break;
                    case "ne":
                        return @"area_ne01.jpg";
                        break;
                    case "sa":
                        return @"area_sa01.jpg";
                        break;
                    case "se":
                        return @"area_se01.jpg";
                        break;
                    case "us":
                        return @"area_us01.jpg";
                        break;
                    default:
                        return @"area_cn01.jpg";
                        break;
                }
            }
        }
    }

    public string MainImageName
    {
        get
        {
            if (this.Request["areacode"] == null)
            {
                return @"area_cn02.jpg";
            }
            else
            {
                switch (this.Request["areacode"])
                {
                    case "af":
                        return @"area_af02.jpg";
                        break;
                    case "cn":
                        return @"area_cn02.jpg";
                        break;
                    case "ca":
                        return @"area_ca02.jpg";
                        break;
                    case "eu":
                        return @"area_eu02.jpg";
                        break;
                    case "ne":
                        return @"area_ne02.jpg";
                        break;
                    case "sa":
                        return @"area_sa02.jpg";
                        break;
                    case "se":
                        return @"area_se02.jpg";
                        break;
                    case "us":
                        return @"area_us02.jpg";
                        break;
                    default:
                        return @"area_cn02.jpg";
                        break;
                }
            }
        }
    }

    public string CountryName
    {
        get
        {
            if (this.Request["areacode"] == null)
            {
                return "China";
            }
            else
            {
                switch (this.Request["areacode"])
                {
                    case "af":
                        return "Africa & MidEast";
                        break;
                    case "cn":
                        return "China";
                        break;
                    case "ca":
                        return "Central America";
                        break;
                    case "eu":
                        return "Europe";
                        break;
                    case "ne":
                        return "Japan & Korea";
                        break;
                    case "sa":
                        return "South America";
                        break;
                    case "se":
                        return "Southeast Asia";
                        break;
                    case "us":
                        return "United States";
                        break;
                    default:
                        return "China";
                        break;
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["tab"] != null && Request.QueryString["tab"] != "")
            {
                this.CurrentTab.Value = Request.QueryString["tab"].ToString();
                this.divSearchTab.Visible = false;
                divSearchNonTab.Visible = true;
            }
            else
            {
                this.divSearchTab.Visible = true;
                divSearchNonTab.Visible = false;
            }
        }
    }
}
