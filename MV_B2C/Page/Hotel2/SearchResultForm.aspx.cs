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

using log4net;
using Spring.Web.UI;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;


public partial class SearchResultForm : SalseBasePage
{
    public SearchResultForm()
    {
        this.InitializeControls += new EventHandler(SearchResultForm_InitializeControls);
    }

    void SearchResultForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (!Utility.IsSearchConditionNull)
        {
            if (!this.IsPostBack)
            {
                Navigation1.PageCode = 2;
                //HotelInfoControl1.ReturnURL = "~/Page/UVHotel/HotelSelectForm.aspx";

                if (this.Request["Country"] != null)
                {
                    if (!this.IsSearchConditionNull)
                    {
                        HotelSearchCondition hotelSearchCondition = (HotelSearchCondition)Utility.Transaction.CurrentSearchConditions;

                        string hotelName = this.Request["HotelName"];
                        hotelSearchCondition.Location = this.Request["CityCode"];
                        hotelSearchCondition.LocationIndicator = LocationIndicator.City;
                        hotelSearchCondition.CheckIn = Convert.ToDateTime(this.Request["CheckIn"]);
                        hotelSearchCondition.CheckOut = Convert.ToDateTime(this.Request["CheckOut"]);
                        hotelSearchCondition.Country = this.Request["Country"];
                        Utility.Transaction.IntKey = hotelSearchCondition.GetHashCode();
                        Utility.Transaction.CurrentSearchConditions = hotelSearchCondition;

                        if (this.Request["edit"] == "y")
                            DeleteBeingChangedHotelOrderItem(hotelName, this.Request["CheckIn"]);

                        this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Hotel2/SearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        this.Response.Redirect("../../Index.aspx");
                    }
                }

            }
            SearchAndBind();
        }
        else
        {
            //出错处理。

            Err("The search condition has been removed from cache, please re-search.", "", "SearchResultForm.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Header1.Path = "../../";
    }

    private void DeleteBeingChangedHotelOrderItem(string hotelName, string strCheckin)
    {
        //把需要删除的HotelOrderItem缓存在Session中

        List<string> deleteList = new List<string>();
        deleteList.Add(hotelName);
        deleteList.Add(strCheckin);
        Utility.DeleteHotel = deleteList;
    }

    private void SearchAndBind()
    {
        HotelMerchandise m_SaleMerchandise = (HotelMerchandise)this.OnSearch();

        if (m_SaleMerchandise.Items.Count > 0)
        {
            List<MVHotel> hotelMaterialNew = new List<MVHotel>();

            for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
            {
                hotelMaterialNew.Add((MVHotel)m_SaleMerchandise.Items[i]); 
            }

            HotelDetailedInformationListControl1.HotelMaterial = hotelMaterialNew;
        }
        else
        {
            this.Response.Redirect("../../Index.aspx");
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        switch (FocusIndex.Value.Trim().ToUpper())
        {
            case "R":
                HotelOnlySearchControl1.imgbSearch_Click(new object(), new EventArgs());
                break;
            case "S":
                HotelDetailedInformationListControl1.btnShow_Click(new object(), new EventArgs());
                break;
            default:
                break;
        }
    }
}
