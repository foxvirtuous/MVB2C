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
using System.Collections.Generic;
using Terms.Sales.Service;
using Terms.Sales.Domain;
using Terms.Common.Service;
using Terms.Sales.Business;

public partial class TopDestinationsControl : SalesBaseUserControl
{
    private ITopDestinationsMasterConfigService _TopDestinationsMasterConfigService;

    public ITopDestinationsMasterConfigService TopDestinationsMasterConfigService
    {
        set
        {
            _TopDestinationsMasterConfigService = value;
        }
    }

    private ITopDestinationsDetailConfigService _TopDestinationsDetailConfigService;

    public ITopDestinationsDetailConfigService TopDestinationsDetailConfigService
    {
        set
        {
            _TopDestinationsDetailConfigService = value;
        }
    }

    private ICommonService m_CommonService;

    public ICommonService CommonService
    {
        set
        {
            m_CommonService = value;
        }
    } 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTop();
        }
    }

    private void BindTop()
    {
        IList metaMaster = _TopDestinationsMasterConfigService.FindAll();

        dlTopDestinations.DataSource = metaMaster;
        dlTopDestinations.DataBind();

        for (int i = 0; i < dlTopDestinations.Items.Count; i++)
        {
            Label lblContinent = (Label)dlTopDestinations.Items[i].FindControl("lblContinent");
            if (UserCulture.Name.Contains("zh-CN"))
                lblContinent.Text = ((TopDestinationsMasterConfigMeta)metaMaster[i]).TopCN;
            else
                lblContinent.Text = ((TopDestinationsMasterConfigMeta)metaMaster[i]).TopEN;

            DataList dlTourArea = (DataList)dlTopDestinations.Items[i].FindControl("dlTourArea");

            Guid masterid = ((TopDestinationsMasterConfigMeta)metaMaster[i]).Id;

            IList listDetail = _TopDestinationsDetailConfigService.FindByMasterId(masterid);

            if (i == dlTopDestinations.Items.Count - 1)
            {
                System.Web.UI.HtmlControls.HtmlTableCell tdTop = (System.Web.UI.HtmlControls.HtmlTableCell)dlTopDestinations.Items[i].FindControl("tdTop");
                tdTop.Attributes.Add("class", "d15");
            }

            dlTourArea.DataSource = listDetail;
            dlTourArea.DataBind();

            for (int j = 0; j < dlTourArea.Items.Count; j++)
            {
                LinkButton lbtnTourArea = (LinkButton)dlTourArea.Items[j].FindControl("lbtnTourArea");
                if (UserCulture.Name.Contains("zh-CN"))
                    lbtnTourArea.Text = ((TopDestinationsDetailConfigMeta)listDetail[j]).DetailCN;
                else
                    lbtnTourArea.Text = ((TopDestinationsDetailConfigMeta)listDetail[j]).DetailEN;

                Label lblLine = (Label)dlTourArea.Items[j].FindControl("lblLine");

                lblLine.Text = ((TopDestinationsDetailConfigMeta)listDetail[j]).DetailLine;

                Label lblID = (Label)dlTourArea.Items[j].FindControl("lblID");

                lblID.Text = ((TopDestinationsDetailConfigMeta)listDetail[j]).Id.ToString();
            }
        }
    }

    protected void dlTourArea_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Label lblLine = (Label)e.Item.FindControl("lblLine");

            if (!string.IsNullOrEmpty(lblLine.Text.Trim()))
            {
                string citys = lblLine.Text.Trim().Replace(@",", @";");

                string[] Citys = citys.Split(new char[] { ';' });

                List<string> listCity = new List<string>();

                for (int i = 0; i < Citys.Length; i++)
                {
                    listCity.Add(Citys[i]);
                }

                string city = listCity[0];

                Terms.Common.Domain.City City = m_CommonService.FindCityByCityCode(city);

                if (City != null)
                {
                    Label lblID = (Label)e.Item.FindControl("lblID");

                    Utility.TourCitys = listCity;
                    Utility.IsTourMain = true;
                    Utility.IsTourMore = true;

                    TourSearchCondition tourSearchCondition = new TourSearchCondition();

                    if (City.CountryCode == "US")
                    {
                        tourSearchCondition.Region = "U.S.";
                    }
                    else
                    {
                        tourSearchCondition.Region = City.CountryCode;
                    }
                    tourSearchCondition.Counrty = City.CountryCode ;
                    tourSearchCondition.CityList = listCity;
                    tourSearchCondition.City = city;
                    tourSearchCondition.DeptCity = city;
                    tourSearchCondition.IsLandOnly = true;
                    tourSearchCondition.PriceType = TERMS.Common.TourPriceType.All;
                    tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
                    tourSearchCondition.TravelDaysFrom = 1;
                    tourSearchCondition.TravelDaysTo = 800;
                    this.Transaction.IntKey = tourSearchCondition.GetHashCode();
                    this.Transaction.CurrentSearchConditions = tourSearchCondition;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                    //¼ÇÂ¼Search MoreÊÂ¼þ
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchMoreTour, this);
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode("U.S.") + "&ConditionID=" + Utility.Transaction.IntKey.ToString() + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm" + "&TopDestinations=" + lblID.Text);
                }
            }   
        }
    }
}