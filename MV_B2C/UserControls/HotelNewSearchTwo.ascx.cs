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

using Terms.Sales.Service;
using Terms.Sales.Dao;
using Terms.Sales.Domain;

using Terms.Material.Domain;

public partial class HotelNewSearchTwo : Spring.Web.UI.UserControl
{
    //private ICommonService _CommonService;
    //public ICommonService CommonService
    //{
    //    set
    //    {
    //        this._CommonService = value;
    //    }
    //}

    public HotelNewSearchTwo()
    {
        this.InitializeControls += new EventHandler(HotelNewSearchTwo_InitializeControls);
    }

    void HotelNewSearchTwo_InitializeControls(object sender, EventArgs e)
    {
        //IList ilist = _CommonService.FindCountryAll();

        //ddlCountry.DataSource = ilist;
        //ddlCountry.DataTextField = "Name";
        //ddlCountry.DataValueField = "Code";
        //ddlCountry.DataBind();

        //ListItem item = new ListItem("--Select--", string.Empty);

        //ddlCountry.Items.Insert(0, item);

        //ddlCountry_SelectedIndexChanged(null, new EventArgs());
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlCity.Items.Clear();
        //ddlCity.DataBind();

        //if (ddlCountry.SelectedIndex > 0)
        //{
        //    IList ilist = _CommonService.FindCitiesByCountryCode(ddlCountry.SelectedValue);

        //    ddlCity.DataSource = ilist;
        //    ddlCity.DataTextField = "Name";
        //    ddlCity.DataValueField = "Code";
        //    ddlCity.DataBind();
        //}

        //ListItem item = new ListItem("--Select--", string.Empty);

        //ddlCity.Items.Insert(0, item);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if (this.ddlCountry.SelectedIndex <= 0 || this.ddlCity.SelectedIndex <= 0)
        //{
        //    return;
        //}

        //DateTime dateChinkIn_H = Convert.ToDateTime(this.txtCheckin.CDate);
        //DateTime dateChinkOut_H = Convert.ToDateTime(this.txtCheckout.CDate);

        //if (dateChinkIn_H < DateTime.Today && dateChinkOut_H < DateTime.Today)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('We can only accept dates that occur between " + DateTime.Today.AddDays(1).ToString("MM/dd/yyyy") + " and 12/27/2008. Please enter a new date.');</script>");
        //    return;
        //}

        //if (dateChinkIn_H <= DateTime.Today)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The check-in date must occur after the today date. Please change the date.');</script>");
        //    return;
        //}

        //if (dateChinkIn_H > dateChinkOut_H)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The check-out date must occur after the check-in date. Please change the date.');</script>");
        //    return;
        //}

        //if (!Utility.IsSearchConditionNull)
        //{
        //    if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
        //    {
        //        HotelSearchCondition hotelSearchCondition = (HotelSearchCondition)Utility.Transaction.CurrentSearchConditions;

        //        hotelSearchCondition.Location = this.ddlCity.SelectedValue;
        //        hotelSearchCondition.LocationIndicator = Terms.Base.Utility.LocationIndicator.City;
        //        hotelSearchCondition.CheckIn = Convert.ToDateTime(this.txtCheckin.CDate);
        //        hotelSearchCondition.CheckOut = Convert.ToDateTime(this.txtCheckout.CDate);
        //        hotelSearchCondition.Country = this.ddlCountry.SelectedValue;
        //        Utility.Transaction.CurrentSearchConditions = hotelSearchCondition;
        //        //this.Response.Redirect("HotelSelectForm.aspx");
        //        this.Response.Redirect("~/Page/Common/Searching1.aspx?target=HotelSelectForm");
        //    }
        //    else
        //    {
        //        PackageSearchCondition packageSearchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;

        //        //HotelSearchCondition hotelSearchCondition = packageSearchCondition.HotelSearchCondition;

        //        packageSearchCondition.HotelSearchCondition.Location = this.ddlCity.SelectedValue;
        //        packageSearchCondition.HotelSearchCondition.LocationIndicator = Terms.Base.Utility.LocationIndicator.City;
        //        packageSearchCondition.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.txtCheckin.CDate);
        //        packageSearchCondition.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.txtCheckout.CDate);
        //        packageSearchCondition.HotelSearchCondition.Country = this.ddlCountry.SelectedValue;
        //        Utility.Transaction.CurrentSearchConditions = packageSearchCondition;
        //        if (packageSearchCondition.HotelSearchCondition2 != null)
        //        {
        //            ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition2 = null;
        //            this.Response.Redirect("~/Page/Common/Searching1.aspx?Destination=2&target=PackageSearchResultForm");
        //        }
        //        else
        //            this.Response.Redirect("~/Page/Common/Searching1.aspx?target=PackageSearchResultForm");
        //    }
        //}
        //else
        //{
        //    this.Response.Redirect("~/Index.aspx");
        //}
    }
}
