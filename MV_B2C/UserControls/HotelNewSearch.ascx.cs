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
using log4net;

using Terms.Common.Service;
using Terms.Common.Dao;
using Terms.Common.Domain;

public partial class HotelNewSearch : Spring.Web.UI.UserControl
{
    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    public HotelNewSearch()
    {
        this.InitializeControls += new EventHandler(HotelNewSearch_InitializeControls);
    }

    void HotelNewSearch_InitializeControls(object sender, EventArgs e)
    {
        IList ilist = _CommonService.FindCountryAll();

        ddlCountry.DataSource = ilist;
        ddlCountry.DataTextField = "Name";
        ddlCountry.DataValueField = "Code";
        ddlCountry.DataBind();

        ListItem item = new ListItem("--Select--", string.Empty);

        ddlCountry.Items.Insert(0, item);

        ddlCountry_SelectedIndexChanged(null, new EventArgs());
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCity.Items.Clear();
        ddlCity.DataBind();

        if (ddlCountry.SelectedIndex > 0)
        {
            IList ilist = _CommonService.FindCitiesByCountryCode(ddlCountry.SelectedValue);

            ddlCity.DataSource = ilist;
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Code";
            ddlCity.DataBind();
        }

        ListItem item = new ListItem("--Select--", string.Empty);

        ddlCity.Items.Insert(0, item);
    }
}
