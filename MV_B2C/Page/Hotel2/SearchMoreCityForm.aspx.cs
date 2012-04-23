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
using Terms.Common.Service;
using Terms.Sales.Business;
using TERMS.Common;


public partial class SearchMoreCityForm : SalseBasePage
{
    private ICityService _cityService;
    public ICityService CityService
    {
        set
        {
            this._cityService = value;
        }
    }

    private IAirportService _airportService;
    public IAirportService AirportService
    {
        set
        {
            this._airportService = value;
        }
    }

    public SearchMoreCityForm()
    {
        this.InitializeControls += new EventHandler(SearchMoreCityForm_InitializeControls);
    }

    void SearchMoreCityForm_InitializeControls(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Header1.Path = "../../";
            BindData();
        }
    }

    protected void BindData()
    {
        if (this.Request["CityName"] != null)
        {
            lblCityName.Text = this.Request["CityName"].Trim();
            lblCityName1.Text = this.Request["CityName"].Trim();
        }
            
        List<Terms.Common.Domain.City> citylist = new List<Terms.Common.Domain.City>();

        if (Session["CityNameList"] != null)
        {
            IList list = (IList)Session["CityNameList"];

            for (int i = 0; i < list.Count; i++)
            {
                Terms.Common.Domain.City citytemp = new Terms.Common.Domain.City();
                citytemp.Name = ((Terms.Common.Domain.City)list[i]).Name + ", " + ((Terms.Common.Domain.City)list[i]).Country.Name;
                citytemp.Code = ((Terms.Common.Domain.City)list[i]).Code;
                citylist.Add(citytemp);
            }

            Terms.Common.Domain.City city = new Terms.Common.Domain.City();
            city.Name = "Or enter a new city name:";

            citylist.Add(city);
            plCityName.Visible = true;
            PLCiytName1.Visible = false;
            choosecity.Visible = true;
            PLCiytName2.Visible = false;
            PLCiytName3.Visible = false;

            rblCityName.DataTextField = "Name";
            rblCityName.DataValueField = "Code";

            rblCityName.DataSource = citylist;
            rblCityName.DataBind();
        }
        else if (this.Request["CityName"] != null && (this.Request["CityName"].ToString().Trim() == "" || this.Request["CityName"].ToString().Trim().Length < 3))
        {
            PLCiytName2.Visible = true;
            PLCiytName3.Visible = false;
            choosecity.Visible = false;
            List<City> list = new List<City>();
            City city = new City();
            city.Name = "Enter a new city name:";
            list.Add(city);
            plCityName.Visible = false;
            PLCiytName1.Visible = false;

            rblCityName.DataTextField = "Name";
            rblCityName.DataValueField = "Code";

            rblCityName.DataSource = list;
            rblCityName.DataBind();
        }
        else if (this.Request["ErrorMessage"] != null && this.Request["ErrorMessage"].ToString().Trim() != "")
        {
            txtCityName.Text = ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location;
            PLCiytName2.Visible = false;
            choosecity.Visible = false;
            List<City> list = new List<City>();
            City city = new City();
            city.Name = "Enter a new city name:";
            list.Add(city);
            plCityName.Visible = false;
            PLCiytName1.Visible = false;
            PLCiytName3.Visible = true;

            rblCityName.DataTextField = "Name";
            rblCityName.DataValueField = "Code";

            rblCityName.DataSource = list;
            rblCityName.DataBind();
        }
        else
        {
            PLCiytName3.Visible = false;
            PLCiytName2.Visible = false;
            choosecity.Visible = false;
            List<City> list = new List<City>();
            City city = new City();
            city.Name = "Enter a new city name:";
            list.Add(city);
            plCityName.Visible = false;
            PLCiytName1.Visible = true;

            rblCityName.DataTextField = "Name";
            rblCityName.DataValueField = "Code";

            rblCityName.DataSource = list;
            rblCityName.DataBind();
        }

        //默认选中第一项
        if (rblCityName.Items.Count > 0)
            rblCityName.SelectedIndex = 0;

    }

    protected void btn_Search_h_Click(object sender, EventArgs e)
    {
        Session["CityNameList"] = null;

        if (rblCityName.SelectedItem.Text.ToLower() == "or enter a new city name:" || rblCityName.SelectedItem.Text.ToLower() == "enter a new city name:")
        {
            if (this.txtCityName.Text.Trim() == "" || this.txtCityName.Text.Trim().Length < 3)
            {
                this.Response.Redirect(PageUtility.UrlSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtCityName.Text);
            }

            ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).UserInputInfo = this.txtCityName.Text;

            if (this.txtCityName.Text.Trim().Length == 3)
            {
                Terms.Common.Domain.City CityName = _cityService.Get(this.txtCityName.Text);

                if (CityName != null)
                {                    
                    ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = CityName.Code;
                    ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = CityName.CountryCode;
                    //Session["CityNameList"] = ilCityName;
                    //this.Response.Redirect("~/Page/Common/SearchMoreForm.aspx?CityName=" + this.txtCityName.Text);
                }
                else
                {
                    Terms.Common.Domain.Airport airport = _airportService.Get(this.txtCityName.Text);
                    if (airport != null)
                    {
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = airport.City.Code;
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = airport.City.CountryCode;
                    }
                    else
                    {
                        IList ilCityName = _cityService.FindSomeCityByName(this.txtCityName.Text);
                        if (ilCityName.Count > 1)
                        {
                            Session["CityNameList"] = ilCityName;
                            this.Response.Redirect(PageUtility.UrlSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtCityName.Text);
                        }
                        else if (ilCityName.Count == 1)
                        {
                            Terms.Common.Domain.City citylist = (Terms.Common.Domain.City)ilCityName[0];
                            ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = citylist.Code;
                            ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = citylist.CountryCode;
                        }
                        else if (ilCityName == null || ilCityName.Count == 0)
                        {
                            Session["CityNameList"] = null;
                            this.Response.Redirect(PageUtility.UrlSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtCityName.Text);
                        }
                    }
                }

            }
            else
            {
                //判断是否有多个.如果有相同则回到本页,如果没有则进入搜索页面
                IList ilCityName = _cityService.FindSomeCityByName(this.txtCityName.Text);

                if (ilCityName.Count > 1)
                {
                    Session["CityNameList"] = ilCityName;
                    this.Response.Redirect(PageUtility.UrlSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtCityName.Text);
                }
                else if (ilCityName.Count == 1)
                {
                    Terms.Common.Domain.City citylist = (Terms.Common.Domain.City)ilCityName[0];
                    ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = citylist.Code;
                    ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = citylist.CountryCode;
                }
                else if (ilCityName == null || ilCityName.Count == 0)
                {
                    Terms.Common.Domain.Airport airport = _airportService.Get(this.txtCityName.Text);
                    if (airport != null)
                    {
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = airport.City.Code;
                        ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = airport.City.CountryCode;
                    }
                    else
                    {
                        this.Response.Redirect(PageUtility.UrlSuffix + "Page/Hotel2/SearchMoreCityForm.aspx?CityName=" + this.txtCityName.Text);
                    }
                }
            }
            this.Response.Redirect(PageUtility.UrlSuffix + "Page/Common/Searching1.aspx?target=~/Page/Hotel2/SearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
        }
        else
        {
            //对HotelSearchCondition的Location和Country赋值
            ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Location = rblCityName.SelectedValue;
            Terms.Common.Domain.City citytemp = _cityService.Get(rblCityName.SelectedValue);
            if (citytemp != null)
            {
                ((HotelSearchCondition)this.Transaction.CurrentSearchConditions).Country = citytemp.CountryCode;
            }
            this.Response.Redirect(PageUtility.UrlSuffix + "Page/Common/Searching1.aspx?target=~/Page/Hotel2/SearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
        }
    }
}

