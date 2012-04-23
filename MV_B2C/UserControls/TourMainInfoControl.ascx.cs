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
using TERMS.Core.Product;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Profiles;
using Terms.Sales.Business;
using Terms.Material.Service;
using System.Globalization;

public partial class TourMainInfoControl : SalesBaseUserControl
{
    private bool m_IsFeatures = false;
    public bool IsFeatures
    {
        set { m_IsFeatures = value; }
    }
    public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.TourOnSearch();
        }
    }

    public string SelectTourCode
    {
        get
        {
            if (Request["TourCode"] != null)
                return Request["TourCode"].Trim().ToLower();
            else
                return string.Empty;
        }
    }

    private TourMaterial _tourmaterial = null;
    public TourMaterial SelectTourMaterial
    {
        get
        {
            if (_tourmaterial == null || ((TourProfile)_tourmaterial.Profile).Code.Trim().ToLower() != SelectTourCode)
            {
                if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.Items.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.Items[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            _tourmaterial = (TourMaterial)tourMerchandise.Items[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return _tourmaterial;
        }
    }

    private TourProduct tourproduct = null;
    public TourProduct TourProduct
    {
        get
        {
            if (tourproduct == null || ((TourProfile)tourproduct.Profile).Code.Trim().ToLower() != SelectTourCode)
            {

                if (tourMerchandise != null && tourMerchandise.TourProductList != null && tourMerchandise.TourProductList.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.TourProductList.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.TourProductList[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            tourproduct = (TourProduct)tourMerchandise.TourProductList[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return tourproduct;
        }
    }

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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                if (this.Parent.Page.ToString() == "ASP.page_tour_tourselectairform_aspx")
                {
                    this.trPassengers.Visible = false;
                }
                InitPage();


            }

            //SearchToBinder();
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }
    public void InitPage()
    {
        if (SelectTourMaterial != null)
        {
            TourMaterial tourMaterial = (TourMaterial)SelectTourMaterial;
            TourSearchCondition tourSearchCondition = (TourSearchCondition)Transaction.CurrentSearchConditions;

            if (Transaction.CurrentTransactionObject != null && Transaction.CurrentTransactionObject.Items != null && Transaction.CurrentTransactionObject.Items.Count > 0)
            {
                string itemCode = ((Terms.Product.Business.MVTourProfile)((TourOrderItem)Transaction.CurrentTransactionObject.Items[0]).Profile).Code;

                for (int i = 0; i < tourMerchandise.Items.Count; i++)
                {
                    if (((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).Code.Trim().ToUpper() == itemCode.Trim().ToUpper())
                    {

                        lbl_TourName.Text = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).Name;
                        lbl_TourCode.Text = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).Code;

                        break;
                    }
                }
            }
            else
            {

                lbl_TourName.Text = tourMaterial.Profile.Name;
                lbl_TourCode.Text = tourMaterial.Profile.Code;
            }
            if ((TourOrderItem)this.Transaction.CurrentTransactionObject.Items[0] != null)
            {
                TourOrderItem TourOrderItem = (TourOrderItem)this.Transaction.CurrentTransactionObject.Items[0];
                lbl_AdultNumber.Text = TourOrderItem.AdultNumber.ToString() + " " + lbl_AdultNumber.Text;
                if (TourOrderItem.ChildWithOutNumber > 0)
                    lbl_ChildWithOutNumber.Text = TourOrderItem.ChildWithOutNumber.ToString() + " " + lbl_ChildWithOutNumber.Text;
                else
                    lbl_ChildWithOutNumber.Visible = false;
                if (TourOrderItem.ChildNumber > 0)
                    lbl_ChildNumber.Text = TourOrderItem.ChildNumber.ToString() + " " + lbl_ChildNumber.Text;
                else
                    lbl_ChildNumber.Visible = false;

                Hashtable roomType = new Hashtable();
                Hashtable roomIndex = new Hashtable();
                for (int i = 0; i < TourOrderItem.FareTypeList.Count; i++)
                {
                    TourOrderFareType toft = TourOrderItem.FareTypeList[i];
                    if (toft.Type == TourFareType.LAND)
                    {

                        for (int j = 0; j < toft.TourRooms.Count; j++)
                        {
                            //if (!roomIndex.ContainsKey(toft.TourRooms[j].RoomIndex))
                            //{
                            //    roomIndex.Add(toft.TourRooms[j].RoomIndex, toft.TourRooms[j].RoomType);
                            //}

                            if (roomType.ContainsKey(toft.TourRooms[j].RoomType))
                            {
                                if (toft.TourRooms[j].RoomIndex == toft.TourRooms[j - 1].RoomIndex)
                                    continue;
                                else
                                    roomType[toft.TourRooms[j].RoomType] = Convert.ToInt32(roomType[toft.TourRooms[j].RoomType]) + 1;
                            }
                            else
                            {
                                roomType.Add(toft.TourRooms[j].RoomType, 1);
                            }

                        }

                        //foreach (int key in roomIndex.Keys)
                        //{
                        //    if (!roomType.ContainsKey(roomIndex[key]))
                        //    {
                        //        roomType.Add(roomIndex[key], 1);
                        //    }
                        //    else
                        //    {
                        //        roomType[roomIndex[key]] = Convert.ToInt32(roomType[roomIndex[key]]) +1;
                        //    }
                        //}

                        foreach (string key in roomType.Keys)
                        {
                            lbl_RoomType.Text += roomType[key].ToString() + " " + key + " Room(s),";
                        }
                    }
                    
                }
                lbl_RoomType.Text = lbl_RoomType.Text.Substring(0, lbl_RoomType.Text.Length - 1);
                lbl_DeptDate.Text = TourOrderItem.BeginDate.ToString("d", DateTimeFormatInfo.InvariantInfo);
                lbl_RtnDate.Text = TourOrderItem.EndDate.ToString("d", DateTimeFormatInfo.InvariantInfo);
                if (tourSearchCondition.IsLandOnly == true)
                {
                    lblDisPlay.Text = lblDisPlay.Text + TourOrderItem.BeginDate.AddDays(1).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo) + ")";
                    lblDisPlay.Visible = IsDisPlay(tourSearchCondition.Counrty);
                }
                else
                {
                    lblDisPlay.Visible = false;
                }
                
            }
            if (tourSearchCondition.IsLandOnly == false)
            {
                Terms.Common.Domain.City city = AirService.CommCityDao.FindCityByCode(tourSearchCondition.DeptCity);
                if (city != null)
                {
                    lbl_FromTo.Text = "From " + city.Name + " To " + ((TourProfile)tourMaterial.Profile).StartCity.Name;
                }
            }
            else
                lbl_FromTo.Visible = false; 
            

            //if (m_IsFeatures)
            //{
            //    dlFeatures.DataSource = tourMaterial.Profile.Features;
            //    dlFeatures.DataBind();
            //}
        }
    }

    private bool IsDisPlay(string CountryCode)
    {
        foreach (string code in Utility.SetTourLandOnlyCitys)
        {
            if (CountryCode.Equals(code))
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        return false;
    }

}
