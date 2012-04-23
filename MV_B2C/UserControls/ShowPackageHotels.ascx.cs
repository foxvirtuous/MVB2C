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
using Spring.Web.UI;
using log4net;
using Terms.Sales.Domain;
using Terms.Sales.Service;
using Terms.Base.Domain;
using Terms.Product.Domain;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;

public partial class ShowPackageHotels : Spring.Web.UI.UserControl
{
    private ISaleMerchandiseSearcherService _SaleMerchandiseSearcherService;
    public ISaleMerchandiseSearcherService SaleMerchandiseSearcherService
    {
        set { _SaleMerchandiseSearcherService = value; }
    }

    private PackageMaterial _PackageMaterial;
    public PackageMaterial pgMaterials
    {
        set
        {
            if (value is PackageMaterial)
            {
                dlHotelDetails.DataSource = ((PackageMaterial)value).Hotels;
                dlHotelDetails.DataBind();             
     
            }
        }
        get
        {
            if (_PackageMaterial == null)
            {
                _PackageMaterial = new PackageMaterial(new TERMS.Business.Centers.ProductCenter.Profiles.PackageProfile(""));
            }

            return _PackageMaterial;
        }
    }
    //private List<MVHotel> _hotelDetailsTwo;
    //public List<MVHotel> HotelDetailsTwo
    //{
    //    set
    //    {
    //        if (value is List<MVHotel>)
    //        {
    //            dlPackageMaterialTwo.DataSource = value;
    //            dlPackageMaterialTwo.DataBind();

    //        }
    //    }
    //    get
    //    {
    //        if (_hotelDetailsTwo == null)
    //        {
    //            _hotelDetailsTwo = new List<MVHotel>();
    //        }

    //        return _hotelDetailsTwo;
    //    }
    //}

    private int m_parentIndex = 0;

    public int ParentIndex
    {
        get
        {
            return m_parentIndex;
        }
        set
        {
            m_parentIndex = value;
        }
    }

    private int m_sonIndex = 0;

    public int SonIndex
    {
        get
        {
            return m_sonIndex;
        }
        set
        {
            m_sonIndex = value;
        }
    }
    private PackageMerchandise _pgMerchandise;
    public PackageMerchandise pgMerchandise
    {
        get
        {
            return _pgMerchandise;
        }
        set
        {
            _pgMerchandise = value;
        }
    }

    private IList<string> _cityCode;
    public IList<string> CityCode
    {
        get { return _cityCode; }
        set { _cityCode = value; }
    }

    public void BindHotels()
    {
       
        //List<HotelMaterial> tempOneHotels = new List<HotelMaterial>();
        //List<HotelMaterial> tempTwoHotels = new List<HotelMaterial>();
        //string OneHotelCity = "";
        //string TwoHotelCity = "";
        //if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        //{
        //    OneHotelCity = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.Location;
        //    if (((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition2 != null)
        //        TwoHotelCity = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition2.Location;
        //}
        //foreach (HotelMaterial hm in Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList)
        //{
        //    //if (OneHotelCity.Contains(hm.Hotel.CityCode.Code))
        //    //{
        //    tempOneHotels.Add(hm);
        //    //    break;
        //    //}
        //    //if (TwoHotelCity.Contains(hm.Hotel.CityCode.Code))
        //    //    tempTwoHotels.Add(hm);

        //}
        //if (Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList2 != null)
        //{
        //    foreach (HotelMaterial hm in Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList2)
        //    {
        //        //if (OneHotelCity.Contains(hm.Hotel.CityCode.Code))
        //        //    tempOneHotels.Add(hm);
        //        if (TwoHotelCity.Contains(hm.Hotel.CityCode.Code))
        //        {
        //            tempTwoHotels.Add(hm);
        //            break;
        //        }
        //    }
        //    HotelDetailsTwo = tempTwoHotels;
        //}

       

        pgMaterials = pgMerchandise.GetDefaultPackageMaterial();
        
    }

    public ShowPackageHotels()
    {
        this.InitializeControls += new EventHandler(ShowPackageHotels_InitializeControls);
    }

    void ShowPackageHotels_InitializeControls(object sender, EventArgs e)
    {
        
    }

    protected void dlHotelDetails_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //check item type

        //set nights

        if (IsAlternatingItemOrItem(e.Item.ItemType))
        {
            //HyperLink hl1 = (HyperLink)e.Item.FindControl("hlCheck");
            HyperLink hl2 = (HyperLink)e.Item.FindControl("hlRoomType");
            HyperLink hl3 = (HyperLink)e.Item.FindControl("hotelSelect");

            Label lblHotelID = (Label)e.Item.FindControl("lblHotelID");

            //hl1.NavigateUrl = "~/Page/Package/PackageSelectRoomsForm.aspx?HotelIndex=" + e.Item.ItemIndex + "&&Condition=A &&ReturnUrl=PackageSearchResult2dFrom.aspx";
            hl2.NavigateUrl = "~/Page/Package/PackageSelectRoomsForm.aspx?HotelIndex=" + e.Item.ItemIndex + "&&ReturnUrl=PackageSearchResult2dForm.aspx" + "&ConditionID=" + Request.Params["ConditionID"];

            Label lblCountryCode = (Label)e.Item.FindControl("lblCountry");
            Label lblCityCode = (Label)e.Item.FindControl("lblCityCode");
            Label lblCheckin = (Label)e.Item.FindControl("lbCheckin");
            Label lblCheckOut = (Label)e.Item.FindControl("lbCheckOut");
            lblCheckin.Text = Convert.ToDateTime(lblCheckin.Text).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            lblCheckOut.Text = Convert.ToDateTime(lblCheckOut.Text).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            hl3.NavigateUrl = @"~/Page/Package/PackageSearchResultForm.aspx?HotelIndex=" + e.Item.ItemIndex.ToString() + "&ConditionID=" + Request.Params["ConditionID"];

            hl3.Text = Resources.Global.ChooseHotel  + ((Label)e.Item.FindControl("lbHotelCity")).Text + Resources.Global.OtherHotel;
            SetNightsByCondition(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition, e);
        }
    }

    private void SetNightsByCondition(HotelSearchCondition searchCondition, DataListItemEventArgs e)
    {
        //((Label)e.Item.FindControl("lbNights")).Text = ((TimeSpan)searchCondition.CheckOut.Subtract(searchCondition.CheckIn)).Days.ToString();
    }

    private bool IsAlternatingItemOrItem(ListItemType listItemType)
    {
        return listItemType == ListItemType.AlternatingItem || listItemType == ListItemType.Item;
    }
    //protected void dlHotelDetailsTwo_ItemDataBound(object sender, DataListItemEventArgs e)
    //{
    //    if (IsAlternatingItemOrItem(e.Item.ItemType))
    //    {
    //        HyperLink hl1 = (HyperLink)e.Item.FindControl("hlCheck");
    //        HyperLink hl2 = (HyperLink)e.Item.FindControl("hlRoomType");
    //        HyperLink hl3 = (HyperLink)e.Item.FindControl("hotelSelect");

    //        Label lblHotelID = (Label)e.Item.FindControl("lblHotelID");

    //        hl1.NavigateUrl = "~/Terms.Sales.Web/PackageSelectRoomsForm.aspx?HotelID=" + lblHotelID.Text + "&&Condition=A &&ReturnUrl=PackageSearchResult2dFrom.aspx";
    //        hl2.NavigateUrl = "~/Terms.Sales.Web/PackageSelectRoomsForm.aspx?HotelID=" + lblHotelID.Text + "&&Condition=A &&ReturnUrl=PackageSearchResult2dFrom.aspx";

    //        Label lblCountryCode = (Label)e.Item.FindControl("lblCountry");
    //        Label lblCityCode = (Label)e.Item.FindControl("lblCityCode");
    //        Label lblCheckin = (Label)e.Item.FindControl("lbTwoCheckin");
    //        Label lblCheckOut = (Label)e.Item.FindControl("lbTwoCheckOut");
    //        lblCheckin.Text = Convert.ToDateTime(lblCheckin.Text).ToString("MM/dd/yyyy");
    //        lblCheckOut.Text = Convert.ToDateTime(lblCheckOut.Text).ToString("MM/dd/yyyy");

    //        hl3.NavigateUrl = @"~/Terms.Sales.Web/PackageSearch2dForm.aspx?Country=" + lblCountryCode.Text +
    //            "&CheckIn=" + lblCheckin.Text + "&CheckOut=" + lblCheckOut.Text + "&HotelID=" + lblHotelID.Text;

    //        hl3.Text = "Choose other hotel in " + ((Label)e.Item.FindControl("lbHotelCity")).Text;
    //        SetNightsByCondition(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition2, e);
    //    }
    //}
}
