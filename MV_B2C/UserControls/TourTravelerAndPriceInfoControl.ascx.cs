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
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Sales.Business;
using TERMS.Common;
using Terms.Material.Service;
using TERMS.Business.Centers.ProductCenter.Profiles;
using Terms.Product.Utility;

public partial class TourPriceNewInfoControl : SalesBaseUserControl
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

    public bool SelectPriceType
    {
        get
        {
            if (Request["PriceType"] != null)
                return Convert.ToBoolean(Request["PriceType"].Trim());
            else
                return true;
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
    public bool isLandOnly
    {
        get
        {
            if (Request.Params["PriceType"] == null || Request.Params["PriceType"].Trim().ToUpper() == "L")
                return true;
            else
                return false;
        }
    }

    private bool m_IsInsurance = false;
    public bool IsInsurance
    {
        set { m_IsInsurance = value; }
        get
        {
            if (Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
            {
                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is InsuranceOrderItem)
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }
    }

    private bool m_IsTourInsurance = false;
    public bool IsTourInsurance
    {
        set { m_IsTourInsurance = value; }
        get
        {


            return m_IsTourInsurance;
        }
    }

    public bool ChkTourInsurance
    {

        get
        {
            if (chkTourInsurance.Checked)
                return true;
            else
                return false;
        }
    }

    private List<string> err_Rooms = new List<string>();
    public List<string> ErrRooms
    {
        get
        {
            return err_Rooms;
        }
        set
        {
            err_Rooms = value;
        }
    }

    private String[] _roomTypes;
    public String[] RoomTypes
    {
        get
        {
            return SetSelectedRoomTypeValue();
        }
    }

    private int[] _adults;
    public int[] Adults
    {
        get
        {
            return SetAdultValue();
        }
    }

    private int[] _childs;
    public int[] Childs
    {
        get
        {
            return SetChildValue();
        }
    }

    private int[] _childsWithOut;
    public int[] ChildsWithOut
    {
        get
        {
            return SetChildWithOutValue();
        }
    }

    public int Rooms
    {
        get
        {
            int m_Rooms = 0;

            for (int i = 0; i < dlRoomTypes.Items.Count; i++)
            {
                DataList dlRoomTypeNumber = (DataList)dlRoomTypes.Items[i].FindControl("dlRoomTypeNumber");

                if (dlRoomTypeNumber != null)
                {
                    for (int j = 0; j < dlRoomTypeNumber.Items.Count; j++)
                    {
                        m_Rooms++;
                    }
                }
            }

            return m_Rooms;
        }
    }

    public int AdultNumber
    {
        get
        {
            int m_AdultNumber = 0;
            foreach (int adult in Adults)
            {
                m_AdultNumber += adult;
            }
            return m_AdultNumber;
        }

    }

    public int ChildNumber
    {
        get
        {
            int m_ChildNumber = 0;
            foreach (int child in Childs)
            {
                m_ChildNumber += child;
            }
            return m_ChildNumber;
        }
       
    }

    public int ChildWithOutNumber
    {
        get
        {
            int m_ChildWithOutNumber = 0;
            foreach (int childWithOut in ChildsWithOut)
            {
                m_ChildWithOutNumber += childWithOut;
            }
            return m_ChildWithOutNumber;
        }

    }
    private int m_TotalPassengers = 0;
    public int TotalPassengers
    {
        get
        {
            return AdultNumber + ChildNumber + ChildWithOutNumber;
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitSetCondition();
            InitBinderInfo();
        }
    }

    private void InitSetCondition()
    {
        if (!Utility.IsSearchConditionNull)
        {
            TourOrderItem tourOrderItem = (TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];

            TourProfile tourProfile = (TourProfile)tourOrderItem.Profile;

            DateTime date = ((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).FlightDeptDate;

            List<TourRoom> tourSingleRoom = new List<TourRoom>();
            List<TourRoom> tourTwinRoom = new List<TourRoom>();
            List<TourRoom> tourTripleRoom = new List<TourRoom>();
            List<TourRoom> tourQuatRoom = new List<TourRoom>();

            List<string> roomtypes = new List<string>();

            foreach (TourOrderFareType tOrderFareType in tourOrderItem.FareTypeList)
            {
                if (tOrderFareType.Type == TourFareType.LAND)
                {
                    foreach (TourRoom tr in tOrderFareType.TourRooms)
                    {
                        if (!roomtypes.Contains(tr.RoomType))
                        {
                            roomtypes.Add(tr.RoomType);
                        }
                    }
                } 
            }

            dlRoomTypes.DataSource = roomtypes;
            dlRoomTypes.DataBind();

            for (int i = 0; i < dlRoomTypes.Items.Count; i++)
            {
                DataList dlRoomTypeNumber = (DataList)dlRoomTypes.Items[i].FindControl("dlRoomTypeNumber");

                if (dlRoomTypeNumber != null)
                {
                    List<TourRoom> tourrooms = new List<TourRoom>();

                    foreach (TourOrderFareType tOrderFareType in tourOrderItem.FareTypeList)
                    {
                        if (tOrderFareType.Type == TourFareType.LAND)
                        {
                            foreach (TourRoom tr in tOrderFareType.TourRooms)
                            {
                                if (roomtypes[i] == tr.RoomType)
                                {
                                    tourrooms.Add(tr);
                                }
                            }
                        }
                    }

                    if (tourrooms.Count > 0)
                    {
                        dlRoomTypeNumber.DataSource = tourrooms;
                        dlRoomTypeNumber.DataBind();
                    }

                    for (int j = 0; j < dlRoomTypeNumber.Items.Count; j++)
                    {
                        Label lblRoomTypeName = (Label)dlRoomTypeNumber.Items[j].FindControl("lblRoomTypeName");

                        lblRoomTypeName.Text = tourrooms[j].RoomType;

                        decimal adultPrice = (Decimal)tourProfile.GetPrice(date, lblRoomTypeName.Text, SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Adult)
                                                                    + (Decimal)tourProfile.GetPrice(date, lblRoomTypeName.Text, SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Adult);
                        decimal childPrice = (Decimal)tourProfile.GetPrice(date, lblRoomTypeName.Text, SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Child)
                                                                                + (Decimal)tourProfile.GetPrice(date, lblRoomTypeName.Text, SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Child);
                        decimal childWithOutPrice = (Decimal)tourProfile.GetPrice(date, lblRoomTypeName.Text, SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Infant)
                                                                                + (Decimal)tourProfile.GetPrice(date, lblRoomTypeName.Text, SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Infant);

                        Label lblAdultPrice = (Label)dlRoomTypeNumber.Items[j].FindControl("lblAdultPrice");
                        lblAdultPrice.Text = adultPrice.ToString("N2");

                        if (childPrice > 0)
                        {
                            Label lblChildPrice = (Label)dlRoomTypeNumber.Items[j].FindControl("lblChildPrice");
                            lblChildPrice.Text = childPrice.ToString("N2");
                            ((HtmlTableRow)dlRoomTypeNumber.Items[j].FindControl("trChild")).Visible = true;
                        }
                        else
                        {
                            ((HtmlTableRow)dlRoomTypeNumber.Items[j].FindControl("trChild")).Visible = false;
                        }

                        if (childWithOutPrice > 0)
                        {
                            Label lblChildWithOutPrice = (Label)dlRoomTypeNumber.Items[j].FindControl("lblChildWithOutPrice");
                            lblChildWithOutPrice.Text = childWithOutPrice.ToString("N2");
                            ((HtmlTableRow)dlRoomTypeNumber.Items[j].FindControl("trChildWithOut")).Visible = true;
                        }
                        else
                        {
                            ((HtmlTableRow)dlRoomTypeNumber.Items[j].FindControl("trChildWithOut")).Visible = false;
                        }
                    }
                }
            }
        }
    }
    private int[] SetAdultValue()
    {
        int[] Adults = new int[Rooms];
        int index = 0;
        
        for (int i = 0; i < dlRoomTypes.Items.Count; i++)
        {
            DataList dlRoomTypeNumber = (DataList)dlRoomTypes.Items[i].FindControl("dlRoomTypeNumber");

            if (dlRoomTypeNumber != null)
            {
                for (int j = 0; j < dlRoomTypeNumber.Items.Count; j++)
                {
                    DropDownList ddlAdult = (DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlAdult");

                    if (ddlAdult.SelectedIndex > 0)
                    {
                        Adults[index] = Convert.ToInt32(ddlAdult.SelectedValue);
                    }
                    else
                    {
                        Adults[index] = 0;
                    }

                    index++;
                }
            }
        }

        return Adults;
    }

    private int[] SetChildValue()
    {
        int[] Childs = new int[Rooms];
        int index = 0;
        
        for (int i = 0; i < dlRoomTypes.Items.Count; i++)
        {
            DataList dlRoomTypeNumber = (DataList)dlRoomTypes.Items[i].FindControl("dlRoomTypeNumber");

            if (dlRoomTypeNumber != null)
            {
                for (int j = 0; j < dlRoomTypeNumber.Items.Count; j++)
                {
                    DropDownList ddlChild = (DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlChild");

                    if (ddlChild.SelectedIndex > 0)
                    {
                        Childs[index] = Convert.ToInt32(ddlChild.SelectedValue);
                    }
                    else
                    {
                        Childs[index] = 0;
                    }

                    index++;
                }
            }
        }

        return Childs;
    }

    private int[] SetChildWithOutValue()
    {
        int[] WithOutChilds = new int[Rooms];
        int index = 0;
        
        for (int i = 0; i < dlRoomTypes.Items.Count; i++)
        {
            DataList dlRoomTypeNumber = (DataList)dlRoomTypes.Items[i].FindControl("dlRoomTypeNumber");

            if (dlRoomTypeNumber != null)
            {
                for (int j = 0; j < dlRoomTypeNumber.Items.Count; j++)
                {
                    DropDownList ddlChildWithOut = (DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlChildWithOut");

                    if (ddlChildWithOut.SelectedIndex > 0)
                    {
                        WithOutChilds[index] = Convert.ToInt32(ddlChildWithOut.SelectedValue);
                    }
                    else
                    {
                        WithOutChilds[index] = 0;
                    }

                    index++;
                }
            }
        }

        return WithOutChilds;
    }

    private decimal SumTotalPrice()
    {
        decimal totalPrice = 0M;

        for (int i = 0; i < dlRoomTypes.Items.Count; i++)
        {
            DataList dlRoomTypeNumber = (DataList)dlRoomTypes.Items[i].FindControl("dlRoomTypeNumber");

            if (dlRoomTypeNumber != null)
            {
                for (int j = 0; j < dlRoomTypeNumber.Items.Count; j++)
                {
                    DropDownList ddlAdult = (DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlAdult");

                    if (ddlAdult.SelectedIndex > 0)
                    {
                        Label lblAdultPrice = (Label)dlRoomTypeNumber.Items[j].FindControl("lblAdultPrice");
                        totalPrice += Convert.ToDecimal(lblAdultPrice.Text) * Convert.ToInt32(ddlAdult.SelectedValue);
                    }

                    DropDownList ddlChild = (DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlChild");

                    if (ddlChild.SelectedIndex > 0)
                    {
                        Label lblChildPrice = (Label)dlRoomTypeNumber.Items[j].FindControl("lblChildPrice");
                        totalPrice += Convert.ToDecimal(lblChildPrice.Text) * Convert.ToInt32(ddlChild.SelectedValue);
                    }

                    DropDownList ddlChildWithOut = (DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlChildWithOut");

                    if (ddlChildWithOut.SelectedIndex > 0)
                    {
                        Label lblChildWithOutPrice = (Label)dlRoomTypeNumber.Items[j].FindControl("lblChildWithOutPrice");
                        totalPrice += Convert.ToDecimal(lblChildWithOutPrice.Text) * Convert.ToInt32(ddlChildWithOut.SelectedValue);

                    }
                }
            }
        }

        return totalPrice;
    }

    public void InitBinderInfo()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {

            if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
            {
                TourMaterial tourMaterial = SelectTourMaterial;
                int childNumber = 0;
                int adultNumber = 0;
                int InfantNumber = 0;
                decimal totalPrice = 0.0m;

                decimal addOnPrice = 0.0m;
                decimal insurancePrice = 0.0m;
                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is TourOrderItem)
                    {
                        TourOrderItem tourOrderItem = (TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                        for (int j = 0; j < tourOrderItem.FareTypeList.Count; j++)
                        {
                            if (tourOrderItem.FareTypeList[j].Type == TourFareType.ADDON)
                            {
                                addOnPrice = tourOrderItem.FareTypeList[j].Price * tourOrderItem.FareTypeList[j].Quantity;
                            }
                        }

                        totalPrice = SumTotalPrice();

                        if (IsTourInsurance)
                        {
                            phTourInsurance.Visible = true;
                            insurancePrice = Convert.ToDecimal(tourOrderItem.InsuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount) * TotalPassengers;
                            lblTourInsurance.Text = insurancePrice.ToString("N0");
                            //if (!tourOrderItem.IsInsurance)
                            //{
                                div_IsSelected.Visible = true;
                                if (tourOrderItem.InsuranceMaterial.InsuranceUrl.IndexOf(@"http://") > -1)
                                {
                                    hlInsuranceDetails.NavigateUrl = tourOrderItem.InsuranceMaterial.InsuranceUrl;
                                }
                                else
                                {
                                    hlInsuranceDetails.NavigateUrl = @"http://" + tourOrderItem.InsuranceMaterial.InsuranceUrl;
                                }
                                hlInsuranceDetails.Target = "_blank";
                            //}
                            //else
                            //{
                            //    div_IsSelected.Visible = false;
                            //}
                                if (tourOrderItem.IsInsurance)
                                {
                                    this.chkTourInsurance.Checked = true;
                                }

                            
                        }


                    }

                }

                if (chkTourInsurance.Checked)
                {
                    totalPrice = totalPrice + insurancePrice;
                }

                //add pengzhaohui
                if (((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).DeptCity != null)
                {
                    Terms.Common.Domain.City city = AirService.CommCityDao.FindCityByCode(((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).DeptCity);
                    if (city != null)
                    {
                        lblFromCity.Text = city.Name;
                    }
                }
                lblToCity.Text = ((TourProfile)tourMaterial.Profile).StartCity.Name;
                //add end

                if (!((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).IsLandOnly && addOnPrice > 0)
                {
                    this.phTourAddOn.Visible = true;
                    lbl_TourAddOn.Text = addOnPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                }

                this.lbTotalPrice.Text = totalPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                this.lblAdults.Text = AdultNumber.ToString();
                this.lblChilds.Text = ChildNumber.ToString();
                this.lblChildWithOuts.Text = ChildWithOutNumber.ToString();
                if (((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).IsLandOnly == true)
                    this.lblMsg.Visible = false;

            }
        }
    }

    //public void InitCheck()
    //{
    //    TourProfile tourProfile = (TourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile;
    //    decimal ChildWithOutPrice = (Decimal)tourProfile.GetPrice(((TourSearchCondition)this.Transaction.CurrentSearchConditions).FlightDeptDate, "Single", isLandOnly, false).GetAmount(TERMS.Common.PassengerType.Infant);
    //    if (ChildWithOutPrice == null || ChildWithOutPrice == 0M)
    //    {
    //        this.ddlTwinChildWithOut.Enabled = false;
    //        this.ddlTripleChildWithOut.Enabled = false;
    //        this.ddlQuatChildWithOut.Enabled = false;
    //    }
    //}

    private String[] SetSelectedRoomTypeValue()
    {
        String[] SelectedRoomTypes = new string[Rooms];
        int index = 0;
        //if (dlSingle.Items != null && dlSingle.Items.Count > 0)
        //{
        //    index = dlSingle.Items.Count;
        //    for (int i = 0; i < index; i++)
        //    {
        //        SelectedRoomTypes[i] = Terms.Product.Utility.RoomType.Single.ToString();
        //    }        
        //}
        //if (dlTwin.Items != null && dlTwin.Items.Count > 0)
        //{
        //    int twinIndex = 0;
        //    if (index == 0)
        //    {
        //        index = dlTwin.Items.Count;
        //    }
        //    else
        //    {
        //        twinIndex = index;
        //        index += dlTwin.Items.Count;
        //    }
        //    for (int j = twinIndex; j < index; j++)
        //    {
        //        SelectedRoomTypes[j] = Terms.Product.Utility.RoomType.Twin.ToString();
        //    }
        //}
        //if (dlTriple.Items != null && dlTriple.Items.Count > 0)
        //{
        //    int tripIndex = 0;
        //    if (index == 0)
        //    {
        //        index = dlTriple.Items.Count;
        //    }
        //    else
        //    {
        //        tripIndex = index;
        //        index += dlTriple.Items.Count;
        //    }
        //    for (int k = tripIndex; k < index; k++)
        //    {
        //        SelectedRoomTypes[k] = Terms.Product.Utility.RoomType.Trip.ToString();
        //    }
        //}
        //if (dlQuat.Items != null && dlQuat.Items.Count > 0)
        //{
        //    int quatIndex = 0;
        //    if (index == 0)
        //    {
        //        index = dlQuat.Items.Count;
        //    }
        //    else
        //    {
        //        quatIndex = index;
        //        index += dlQuat.Items.Count;
        //    }
        //    for (int k = quatIndex; k < index; k++)
        //    {
        //        SelectedRoomTypes[k] = Terms.Product.Utility.RoomType.Quarter.ToString();
        //    }
        //}

        for (int i = 0; i < dlRoomTypes.Items.Count; i++)
        {
            DataList dlRoomTypeNumber = (DataList)dlRoomTypes.Items[i].FindControl("dlRoomTypeNumber");

            if (dlRoomTypeNumber != null)
            {
                for (int j = 0; j < dlRoomTypeNumber.Items.Count; j++)
                {
                    Label lblRoomTypeName = (Label)dlRoomTypeNumber.Items[j].FindControl("lblRoomTypeName");

                    SelectedRoomTypes[index] = lblRoomTypeName.Text;

                    index++;
                }
            }
        }

        return SelectedRoomTypes;
    }

    public Hashtable RoomTypeAndRoomNumber()
    {
        Hashtable hTRoomType = new Hashtable();

        //if (dlSingle.Items != null && dlSingle.Items.Count > 0)
        //{
        //    for (int i = 0; i < dlSingle.Items.Count;i++ )
        //    {
        //        if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Single.ToString()))
        //        {
        //            hTRoomType[Terms.Product.Utility.RoomType.Single.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Single.ToString()]) + 1;
        //        }
        //        else
        //        {
        //            hTRoomType.Add(Terms.Product.Utility.RoomType.Single.ToString(), 1);
        //        }
        //    }
        //}

        //if (dlTwin.Items != null && dlTwin.Items.Count > 0)
        //{
        //    for (int j = 0; j < dlTwin.Items.Count; j++)
        //    {
        //        if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Twin.ToString()))
        //        {
        //            hTRoomType[Terms.Product.Utility.RoomType.Twin.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Twin.ToString()]) + 1;
        //        }
        //        else
        //        {
        //            hTRoomType.Add(Terms.Product.Utility.RoomType.Twin.ToString(), 1);
        //        }
        //    }
        //}

        //if (dlTriple.Items != null && dlTriple.Items.Count > 0)
        //{
        //    for (int k = 0; k < dlTriple.Items.Count;k++ )
        //    {
        //        if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Trip.ToString()))
        //        {
        //            hTRoomType[Terms.Product.Utility.RoomType.Trip.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Trip.ToString()]) + 1;
        //        }
        //        else
        //        {
        //            hTRoomType.Add(Terms.Product.Utility.RoomType.Trip.ToString(), 1);
        //        }
        //    }
        //}

        //if (dlQuat.Items != null && dlQuat.Items.Count > 0)
        //{
        //    for (int x = 0; x < dlQuat.Items.Count;x++ )
        //    {
        //        if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Quarter.ToString()))
        //        {
        //            hTRoomType[Terms.Product.Utility.RoomType.Quarter.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Quarter.ToString()]) + 1;
        //        }
        //        else
        //        {
        //            hTRoomType.Add(Terms.Product.Utility.RoomType.Quarter.ToString(), 1);
        //        }
        //    }
        //}

        return hTRoomType;
    }

    public Hashtable RoomTypeAndPersonNumber(TERMS.Common.PassengerType type)
    {
        Hashtable hTRoomType = new Hashtable();

        switch (type.ToString().ToUpper())
        {
            #region Delete
            //case "ADULT":
            //    if (tbSingle.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlSingleAdult.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Single.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Single.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Single.ToString()]) + Convert.ToInt32(ddlSingleAdult.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Single.ToString(), Convert.ToInt32(ddlSingleAdult.SelectedValue));
            //            }
            //        }
            //    }

            //    if (tbTwin.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlTwinAdult.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Twin.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Twin.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Twin.ToString()]) + Convert.ToInt32(ddlTwinAdult.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Twin.ToString(), Convert.ToInt32(ddlTwinAdult.SelectedValue));
            //            }
            //        }
            //    }

            //    if (tbTriple.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlTripleAdult.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Trip.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Trip.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Trip.ToString()]) + Convert.ToInt32(ddlTripleAdult.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Trip.ToString(), Convert.ToInt32(ddlTripleAdult.SelectedValue));
            //            }
            //        }
            //    }

            //    if (tbQuat.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlQuatAdult.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Quarter.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Quarter.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Quarter.ToString()]) + Convert.ToInt32(ddlQuatAdult.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Quarter.ToString(), Convert.ToInt32(ddlQuatAdult.SelectedValue));
            //            }
            //        }
            //    }
            //    break;
            //case "CHILD":

            //    if (tbTwin.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlTwinChild.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Twin.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Twin.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Twin.ToString()]) + Convert.ToInt32(ddlTwinChild.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Twin.ToString(), Convert.ToInt32(ddlTwinChild.SelectedValue));
            //            }
            //        }
            //    }

            //    if (tbTriple.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlTripleChild.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Trip.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Trip.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Trip.ToString()]) + Convert.ToInt32(ddlTripleChild.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Trip.ToString(), Convert.ToInt32(ddlTripleChild.SelectedValue));
            //            }
            //        }
            //    }

            //    if (tbQuat.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlQuatChild.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Quarter.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Quarter.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Quarter.ToString()]) + Convert.ToInt32(ddlQuatChild.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Quarter.ToString(), Convert.ToInt32(ddlQuatChild.SelectedValue));
            //            }
            //        }
            //    }
            //    break;
            //case "INFANT":

            //    if (tbTwin.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlTwinChildWithOut.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Twin.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Twin.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Twin.ToString()]) + Convert.ToInt32(ddlTwinChildWithOut.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Twin.ToString(), Convert.ToInt32(ddlTwinChildWithOut.SelectedValue));
            //            }
            //        }
            //    }

            //    if (tbTriple.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlTripleChildWithOut.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Trip.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Trip.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Trip.ToString()]) + Convert.ToInt32(ddlTripleChildWithOut.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Trip.ToString(), Convert.ToInt32(ddlTripleChildWithOut.SelectedValue));
            //            }
            //        }
            //    }

            //    if (tbQuat.Visible == true)
            //    {
            //        if (Convert.ToInt32(ddlQuatChildWithOut.SelectedValue) > 0)
            //        {
            //            if (hTRoomType.ContainsKey(Terms.Product.Utility.RoomType.Quarter.ToString()))
            //            {
            //                hTRoomType[Terms.Product.Utility.RoomType.Quarter.ToString()] = Convert.ToInt32(hTRoomType[Terms.Product.Utility.RoomType.Quarter.ToString()]) + Convert.ToInt32(ddlQuatChildWithOut.SelectedValue);
            //            }
            //            else
            //            {
            //                hTRoomType.Add(Terms.Product.Utility.RoomType.Quarter.ToString(), Convert.ToInt32(ddlQuatChildWithOut.SelectedValue));
            //            }
            //        }
            //    }
            //    break;
            #endregion

            case "ADULT":
                for (int i = 0; i < Rooms; i++)
                {
                    if (hTRoomType.ContainsKey(RoomTypes[i]))
                        hTRoomType[RoomTypes[i]] = Convert.ToInt32(hTRoomType[RoomTypes[i]]) + Adults[i];
                    else
                    {
                        if (Adults[i] > 0)
                            hTRoomType.Add(RoomTypes[i], Adults[i]);
                    }
                }
                break;
            case "CHILD":

                for (int i = 0; i < Rooms; i++)
                {
                    if (hTRoomType.ContainsKey(RoomTypes[i]))
                        hTRoomType[RoomTypes[i]] = Convert.ToInt32(hTRoomType[RoomTypes[i]]) + Childs[i];
                    else
                    {

                        if (Childs[i] > 0)
                            hTRoomType.Add(RoomTypes[i], Childs[i]);
                    }

                }
                break;
            case "INFANT":
                for (int i = 0; i < Rooms; i++)
                {
                    if (hTRoomType.ContainsKey(RoomTypes[i]))
                        hTRoomType[RoomTypes[i]] = Convert.ToInt32(hTRoomType[RoomTypes[i]]) + ChildsWithOut[i];
                    else
                    {

                        if (Childs[i] > 0)
                            hTRoomType.Add(RoomTypes[i], ChildsWithOut[i]);
                    }

                }
                break;

        }

        return hTRoomType;
    }

    //private void InitBinderPrice()
    //{
    //    TourProfile tourProfile = (TourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile;
    //    DateTime date = ((TourSearchCondition)this.Transaction.CurrentSearchConditions).FlightDeptDate;
    //    decimal adultPrice = 0M;
    //    decimal childPrice = 0M;
    //    decimal childWithOutPrice = 0M;
    //    string RoomType = string.Empty;
    //    for (int i = 0; i < tourProfile.RoomTypes.Count; i++)
    //    {
    //        RoomType = tourProfile.RoomTypes[i];
    //        adultPrice = (Decimal)tourProfile.GetPrice(date, RoomType, isLandOnly, false).GetAmount(TERMS.Common.PassengerType.Adult)
    //                    + (Decimal)tourProfile.GetPrice(date, RoomType, isLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Adult);
    //        childPrice = (Decimal)tourProfile.GetPrice(date, RoomType, isLandOnly, false).GetAmount(TERMS.Common.PassengerType.Child)
    //                    + (Decimal)tourProfile.GetPrice(date, RoomType, isLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Child);
    //        childWithOutPrice = (Decimal)tourProfile.GetPrice(date, RoomType, isLandOnly, false).GetAmount(TERMS.Common.PassengerType.Infant)
    //                    + (Decimal)tourProfile.GetPrice(date, RoomType, isLandOnly, false).GetMarkup(TERMS.Common.PassengerType.Infant);
    //        if (RoomType.ToUpper() == "SINGLE")
    //        {
    //            this.lblSingleAdultPrice.Text = adultPrice.ToString("#,###");
    //        }
    //        else if (RoomType.ToUpper() == "TWIN")
    //        {
    //            this.lblTwinAdultPrice.Text = adultPrice.ToString("#,###");
    //            if(childPrice > 0M)
    //                this.lblTwinChildPrice.Text = childPrice.ToString("#,###");
    //            else
    //                this.lblTwinChildPrice.Text = adultPrice.ToString("#,###");
    //            if(childWithOutPrice > 0M)
    //                this.lblTwinChildWithOutPrice.Text = childWithOutPrice.ToString("#,###");
    //            else
    //                this.lblTwinChildWithOutPrice.Text = adultPrice.ToString("#,###");
    //        }
    //        else if (RoomType.ToUpper() == "TRIPLE")
    //        {
    //            this.lblTripleAdultPrice.Text = adultPrice.ToString("#,###");
    //            if(childPrice > 0M)
    //                this.lblTripleChildPrice.Text = childPrice.ToString("#,###");
    //            else
    //                this.lblTripleChildPrice.Text = adultPrice.ToString("#,###");
    //            if(childWithOutPrice > 0M)
    //                this.lblTripleChildWithOutPrice.Text = childWithOutPrice.ToString("#,###");
    //            else
    //                this.lblTripleChildWithOutPrice.Text = adultPrice.ToString("#,###");
    //        }
    //        else
    //        {
    //            this.lblQuatAdultPrice.Text = adultPrice.ToString("#,###");
    //            if(childPrice > 0M)
    //                this.lblQuatChildPrice.Text = childPrice.ToString("#,###");
    //            else
    //                this.lblQuatChildPrice.Text = adultPrice.ToString("#,###");
    //            if(childWithOutPrice > 0M)
    //                this.lblQuatChildWithOutPrice.Text = childWithOutPrice.ToString("#,###");
    //            else
    //                this.lblQuatChildWithOutPrice.Text = adultPrice.ToString("#,###");
    //        }

    //    }
    //}

    //public void SetRoomTypes()
    //{
    //    TourProfile tourProfile = (TourProfile)((TourMaterial)tourMerchandise.DefaultTourMaterial).Profile;
    //    for (int i = 0; i < tourProfile.RoomTypes.Count; i++)
    //    {
    //        if (tourProfile.RoomTypes[i].ToUpper() == "SINGLE")
    //        {
    //            this.tbSingle.Visible = true;
    //        }
    //        else if (tourProfile.RoomTypes[i].ToUpper() == "TWIN")
    //        {
    //            this.tbTwin.Visible = true;
    //        }
    //        else if (tourProfile.RoomTypes[i].ToUpper() == "TRIPLE")
    //        {
    //            this.tbTriple.Visible = true;
    //        }
    //        else
    //        {
    //            this.tbQuat.Visible = true;
    //        }

    //        if (((Terms.Product.Business.MVTourProfile)tourProfile).DefaultFareKey.Equals(tourProfile.RoomTypes[i]))
    //        {
    //            switch (((Terms.Product.Business.MVTourProfile)tourProfile).DefaultFareKey.ToUpper())
    //            { 
    //                case "SINGLE":
    //                    dllSingleRooms.SelectedIndex = dllSingleRooms.Items.IndexOf(dllSingleRooms.Items.FindByValue("1"));
    //                    ddlSingleAdult.SelectedIndex = ddlSingleAdult.Items.IndexOf(ddlSingleAdult.Items.FindByValue("1"));
    //                    break;
    //                case "TWIN":
    //                    dllTwinRooms.SelectedIndex = dllTwinRooms.Items.IndexOf(dllTwinRooms.Items.FindByValue("1"));
    //                    ddlTwinAdult.SelectedIndex = ddlTwinAdult.Items.IndexOf(ddlTwinAdult.Items.FindByValue("2"));
    //                    break;
    //                case "TRIPLE":
    //                    dllTripleRooms.SelectedIndex = dllTripleRooms.Items.IndexOf(dllTripleRooms.Items.FindByValue("1"));
    //                    ddlTripleAdult.SelectedIndex = ddlTripleAdult.Items.IndexOf(ddlTripleAdult.Items.FindByValue("3"));
    //                    break;
    //                case "QUARTER":
    //                    dllQuatRooms.SelectedIndex = dllQuatRooms.Items.IndexOf(dllQuatRooms.Items.FindByValue("1"));
    //                    ddlQuatAdult.SelectedIndex = ddlQuatAdult.Items.IndexOf(ddlQuatAdult.Items.FindByValue("4"));
    //                    break;
    //                default:
    //                    dllTwinRooms.SelectedIndex = dllTwinRooms.Items.IndexOf(dllTwinRooms.Items.FindByValue("1"));
    //                    ddlTwinAdult.SelectedIndex = ddlTwinAdult.Items.IndexOf(ddlTwinAdult.Items.FindByValue("2"));
    //                    break;

    //            }
                
    //        }
    //    }

    //}

    public List<TourRoom> GetTourRooms(TourProfile tourProfile, DateTime date)
    {
        List<TourRoom> tourRooms = new List<TourRoom>();
        for (int i = 0; i < Rooms; i++)
        {
            if (Adults[i] > 0)
            {
                TourRoom tourRoom = new TourRoom();
                tourRoom.RoomIndex = i + 1;
                tourRoom.PassengerType = TERMS.Common.PassengerType.Adult;
                tourRoom.Quantity = Adults[i];
                tourRoom.RoomType = RoomTypes[i];
                if (tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false) != null)
                {
                    tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Adult)
                        + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Adult);

                    tourRoom.NetPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetAmount(TERMS.Common.PassengerType.Adult);
                    //    + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetMarkup(TERMS.Common.PassengerType.Adult);
                    
                    tourRooms.Add(tourRoom);
                }
                else
                {
                    Response.Redirect("~/ErrorPages/GenericErrorPage.aspx", true);
                }
            }
            if (Childs[i] > 0)
            {
                TourRoom tourRoom = new TourRoom();
                tourRoom.RoomIndex = i + 1;
                tourRoom.PassengerType = TERMS.Common.PassengerType.Child;
                tourRoom.Quantity = Childs[i];
                tourRoom.RoomType = RoomTypes[i];
                if (tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false) != null)
                {
                    tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Child)
                       + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Child);

                    tourRoom.NetPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetAmount(TERMS.Common.PassengerType.Child);
                    //    + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetMarkup(TERMS.Common.PassengerType.Child);


                    if (tourRoom.UnitPrice == null || tourRoom.UnitPrice == 0M)
                    {
                        tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Child)
                        + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Child);

                        tourRoom.NetPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetAmount(TERMS.Common.PassengerType.Child);
                       // + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetMarkup(TERMS.Common.PassengerType.Child);
                    }
                    tourRooms.Add(tourRoom);
                }
                else
                {
                    Response.Redirect("~/ErrorPages/GenericErrorPage.aspx", true);
                }
            }
            if (ChildsWithOut[i] > 0)
            {
                TourRoom tourRoom = new TourRoom();
                tourRoom.RoomIndex = i + 1;
                tourRoom.PassengerType = TERMS.Common.PassengerType.Infant;
                tourRoom.Quantity = ChildsWithOut[i];
                tourRoom.RoomType = RoomTypes[i];
                if (tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false) != null)
                {
                    tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Infant)
                       + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Infant);

                    tourRoom.NetPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetAmount(TERMS.Common.PassengerType.Infant);
                     //  + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetMarkup(TERMS.Common.PassengerType.Infant);

                    if (tourRoom.UnitPrice == null || tourRoom.UnitPrice == 0M)
                    {
                        tourRoom.UnitPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Infant)
                        + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Infant);

                        tourRoom.NetPrice = (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetAmount(TERMS.Common.PassengerType.Infant);
                    //    + (Decimal)tourProfile.GetPrice(date, RoomTypes[i], SelectPriceType, true).GetMarkup(TERMS.Common.PassengerType.Infant);
                    }
                    tourRooms.Add(tourRoom);
                }
                else
                {
                    Response.Redirect("~/ErrorPages/GenericErrorPage.aspx", true);
                }
            }
        }
        return tourRooms;
    }

    protected void chkTourInsurance_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTourInsurance.Checked)
        {
            this.lbTotalPrice.Text = (Convert.ToDecimal(lbTotalPrice.Text) + Convert.ToDecimal(lblTourInsurance.Text)).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);

        }
        else
        {
            this.lbTotalPrice.Text = (Convert.ToDecimal(lbTotalPrice.Text) - Convert.ToDecimal(lblTourInsurance.Text)).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);

        }
    }

    public bool AddMarkup()
    {
        bool falg = true;

        if (Utility.IsSubAgent)
        {
            if (!string.IsNullOrEmpty(this.txtAgentAdultUnitMarkup.Text))
            {
                try
                {
                    decimal decmarkup = Convert.ToDecimal(txtAgentAdultUnitMarkup.Text);

                    if (decmarkup <= 0M)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Markup format input error');</script>");
                        return false;
                    }
                    else
                    {
                        Utility.Transaction.CurrentTransactionObject.SubagentMarkup.SetAmount(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(decmarkup));
                    }
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Markup format input error');</script>");
                    return false;
                }
            }
        }

        return falg;
    }

    public bool CheckConditions()
    {
        bool result = true;
        TourOrderItem tourOrderItem = (TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];

        TourProfile tourProfile = (TourProfile)tourOrderItem.Profile;

        //if (dlSingle.Items != null && dlSingle.Items.Count > 0)
        //{
        //    int i = 1;
        //    foreach (DataListItem item in dlSingle.Items)
        //    {
        //        if ((GetRoomPersonNumber(tourProfile, RoomType.Single.ToString()) < Convert.ToInt32(((DropDownList)item.FindControl("ddlSingleAdult")).SelectedValue)) ||
        //            Convert.ToInt32(((DropDownList)item.FindControl("ddlSingleAdult")).SelectedValue) == 0)
        //        {
        //            ErrRooms.Add("Single(" + i.ToString() + ")");
        //            result = false;
        //        }
        //        i++;
        //    }
        //}
        //if (dlTwin.Items != null && dlTwin.Items.Count > 0)
        //{
        //    int i = 1;
        //    foreach (DataListItem item in dlTwin.Items)
        //    {
        //        if (Convert.ToInt32(((DropDownList)item.FindControl("ddlTwinChild")).SelectedValue) != 0)
        //        {
        //            if (GetRoomPersonNumber(tourProfile, RoomType.Twin.ToString()) < Convert.ToInt32(((DropDownList)item.FindControl("ddlTwinAdult")).SelectedValue) + Convert.ToInt32(((DropDownList)item.FindControl("ddlTwinChild")).SelectedValue) ||
        //                Convert.ToInt32(((DropDownList)item.FindControl("ddlTwinAdult")).SelectedValue) == 0)
        //            {
        //                ErrRooms.Add(" Twin(" + i.ToString() + ")");
        //                result = false;
        //            }
        //        }
        //        else
        //        {
        //            if (GetRoomPersonNumber(tourProfile, RoomType.Twin.ToString()) != Convert.ToInt32(((DropDownList)item.FindControl("ddlTwinAdult")).SelectedValue))
        //            {
        //                ErrRooms.Add(" Twin(" + i.ToString() + ")");
        //                result = false;
        //            }
        //        }
        //        i++;
        //    }
        //}
        //if (dlTriple.Items != null && dlTriple.Items.Count > 0)
        //{
        //    int i = 1;
        //    foreach (DataListItem item in dlTriple.Items)
        //    {
        //        if (Convert.ToInt32(((DropDownList)item.FindControl("ddlTripleChild")).SelectedValue) != 0)
        //        {
        //            if (GetRoomPersonNumber(tourProfile, RoomType.Trip.ToString()) < Convert.ToInt32(((DropDownList)item.FindControl("ddlTripleAdult")).SelectedValue) + Convert.ToInt32(((DropDownList)item.FindControl("ddlTripleChild")).SelectedValue) ||
        //                Convert.ToInt32(((DropDownList)item.FindControl("ddlTripleAdult")).SelectedValue) == 0)
        //            {
        //                ErrRooms.Add(" Triple(" + i.ToString() + ")");
        //                result = false;
        //            }
        //        }
        //        else
        //        {
        //            if (GetRoomPersonNumber(tourProfile, RoomType.Trip.ToString()) != Convert.ToInt32(((DropDownList)item.FindControl("ddlTripleAdult")).SelectedValue))
        //            {
        //                ErrRooms.Add(" Triple(" + i.ToString() + ")");
        //                result = false;
        //            }
        //        }
        //        i++;
        //    }
        //}
        //if (dlQuat.Items != null && dlQuat.Items.Count > 0)
        //{
        //    int i = 1;
        //    foreach (DataListItem item in dlQuat.Items)
        //    {
        //        if (Convert.ToInt32(((DropDownList)item.FindControl("ddlQuatChild")).SelectedValue) != 0)
        //        {
        //            if (GetRoomPersonNumber(tourProfile, RoomType.Quarter.ToString()) < Convert.ToInt32(((DropDownList)item.FindControl("ddlQuatAdult")).SelectedValue) + Convert.ToInt32(((DropDownList)item.FindControl("ddlQuatChild")).SelectedValue) ||
        //                Convert.ToInt32(((DropDownList)item.FindControl("ddlQuatAdult")).SelectedValue) == 0)
        //            {
        //                ErrRooms.Add(" Quarter(" + i.ToString() + ")");
        //                result = false;
        //            }
        //        }
        //        else
        //        {
        //            if (GetRoomPersonNumber(tourProfile, RoomType.Quarter.ToString()) != Convert.ToInt32(((DropDownList)item.FindControl("ddlQuatAdult")).SelectedValue))
        //            {
        //                ErrRooms.Add(" Quarter(" + i.ToString() + ")");
        //                result = false;
        //            }
        //        }
        //        i++;
        //    }
        //}

        for (int i = 0; i < dlRoomTypes.Items.Count; i++)
        {
            DataList dlRoomTypeNumber = (DataList)dlRoomTypes.Items[i].FindControl("dlRoomTypeNumber");

            if (dlRoomTypeNumber != null)
            {
                for (int j = 0; j < dlRoomTypeNumber.Items.Count; j++)
                {
                    Label lblRoomTypeName = (Label)dlRoomTypeNumber.Items[j].FindControl("lblRoomTypeName");

                    if (Convert.ToInt32(((DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlChild")).SelectedValue) != 0)
                    {
                        if (GetRoomPersonNumber(tourProfile, lblRoomTypeName.Text) < Convert.ToInt32(((DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlAdult")).SelectedValue) + Convert.ToInt32(((DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlChild")).SelectedValue) ||
                            Convert.ToInt32(((DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlAdult")).SelectedValue) == 0)
                        {
                            ErrRooms.Add(lblRoomTypeName.Text + " (" + i.ToString() + ")");
                            result = false;
                        }
                    }
                    else
                    {
                        if (GetRoomPersonNumber(tourProfile, lblRoomTypeName.Text) != Convert.ToInt32(((DropDownList)dlRoomTypeNumber.Items[j].FindControl("ddlAdult")).SelectedValue))
                        {
                            ErrRooms.Add(lblRoomTypeName.Text + " (" + i.ToString() + ")");
                            result = false;
                        }
                    }
                }
            }
        }

        return result;
   }

    public int GetRoomPersonNumber(TourProfile tourProfile,string RoomType)
    {
        int MaxNumber = 0;
        MaxNumber = tourProfile.GetPaxNumberOfRoom(RoomType);
        return MaxNumber;
    }

    protected void ddlSingleAdult_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
    protected void ddlTwinAdult_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
    protected void ddlTwinChild_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
    protected void ddlTwinChildWithOut_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
    protected void ddlTripleAdult_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
    protected void ddlTripleChild_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
    protected void ddlTripleChildWithOut_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
    protected void ddlQuatAdult_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
    protected void ddlQuatChild_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
    protected void ddlQuatChildWithOut_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }

    protected void dlTwin_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;
            DateTime date = ((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).FlightDeptDate;
            decimal adultPrice = 0M;
            decimal childPrice = 0M;
            decimal childWithOutPrice = 0M;
            adultPrice = (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Twin.ToString(), SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Adult)
                                                                    + (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Twin.ToString(), SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Adult);
            childPrice = (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Twin.ToString(), SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Child)
                                                                    + (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Twin.ToString(), SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Child);
            childWithOutPrice = (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Twin.ToString(), SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Infant)
                                                                    + (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Twin.ToString(), SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Infant);
            if(childPrice > 0M)
                ((Label)e.Item.FindControl("lblTwinChildPrice")).Text = childPrice.ToString("#,###");
            else
                ((Label)e.Item.FindControl("lblTwinChildPrice")).Text = adultPrice.ToString("#,###");
            if (childWithOutPrice > 0M)
            {
                ((Label)e.Item.FindControl("lblTwinChildWithOutPrice")).Text = childWithOutPrice.ToString("#,###");
            }
            else
            {
                ((Label)e.Item.FindControl("lblTwinChildWithOutPrice")).Text = adultPrice.ToString("#,###");
                ((HtmlTableRow)e.Item.FindControl("trTwinChildWithOut")).Visible = false; //隐藏Child Without
            }
            ((Label)e.Item.FindControl("lblTwinAdultPrice")).Text = adultPrice.ToString("#,###");//Convert.ToDecimal(((Label)e.Item.FindControl("lblTwinAdultPrice")).Text).ToString("#,###");
            DropDownList ddlTwinAdult = (DropDownList)e.Item.FindControl("ddlTwinAdult");
            DropDownList ddlTwinChild = (DropDownList)e.Item.FindControl("ddlTwinChild");
            DropDownList ddlTwinChildWithOut = (DropDownList)e.Item.FindControl("ddlTwinChildWithOut");
            ddlTwinAdult.SelectedIndex = ddlTwinAdult.Items.IndexOf(ddlTwinAdult.Items.FindByValue(((Label)e.Item.FindControl("lblTwinAdult")).Text));
            ddlTwinChild.SelectedIndex = ddlTwinChild.Items.IndexOf(ddlTwinChild.Items.FindByValue(((Label)e.Item.FindControl("lblTwinChild")).Text));
            ddlTwinChildWithOut.SelectedIndex = ddlTwinChildWithOut.Items.IndexOf(ddlTwinChildWithOut.Items.FindByValue(((Label)e.Item.FindControl("lblTwinChildWithOut")).Text));
        }
    }
    protected void dlTriple_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;
            DateTime date = ((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).FlightDeptDate;
            decimal adultPrice = 0M;
            decimal childPrice = 0M;
            decimal childWithOutPrice = 0M;
            adultPrice = (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Triple.ToString(), SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Adult)
                                                                    + (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Triple.ToString(), SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Adult);
            childPrice = (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Triple.ToString(), SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Child)
                                                                    + (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Triple.ToString(), SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Child);
            childWithOutPrice = (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Triple.ToString(), SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Infant)
                                                                    + (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Triple.ToString(), SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Infant);
            if (childPrice > 0M)
                ((Label)e.Item.FindControl("lblTripleChildPrice")).Text = childPrice.ToString("#,###");
            else
                ((Label)e.Item.FindControl("lblTripleChildPrice")).Text = adultPrice.ToString("#,###");
            if (childWithOutPrice > 0M)
            {
                ((Label)e.Item.FindControl("lblTripleChildWithOutPrice")).Text = childWithOutPrice.ToString("#,###");
            }
            else
            {
                ((Label)e.Item.FindControl("lblTripleChildWithOutPrice")).Text = adultPrice.ToString("#,###");
                ((HtmlTableRow)e.Item.FindControl("trTripleChildWithOut")).Visible = false; //隐藏Child Without
            }
            ((Label)e.Item.FindControl("lblTripleAdultPrice")).Text = adultPrice.ToString("#,###");//Convert.ToDecimal(((Label)e.Item.FindControl("lblTripleAdultPrice")).Text).ToString("#,###");
            DropDownList ddlTripleAdult = (DropDownList)e.Item.FindControl("ddlTripleAdult");
            DropDownList ddlTripleChild = (DropDownList)e.Item.FindControl("ddlTripleChild");
            DropDownList ddlTripleChildWithOut = (DropDownList)e.Item.FindControl("ddlTripleChildWithOut");
            ddlTripleAdult.SelectedIndex = ddlTripleAdult.Items.IndexOf(ddlTripleAdult.Items.FindByValue(((Label)e.Item.FindControl("lblTripleAdult")).Text));
            ddlTripleChild.SelectedIndex = ddlTripleChild.Items.IndexOf(ddlTripleChild.Items.FindByValue(((Label)e.Item.FindControl("lblTripleChild")).Text));
            ddlTripleChildWithOut.SelectedIndex = ddlTripleChildWithOut.Items.IndexOf(ddlTripleChildWithOut.Items.FindByValue(((Label)e.Item.FindControl("lblTripleChildWithOut")).Text));
        }
    }
    protected void dlQuat_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;
            DateTime date = ((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).FlightDeptDate;
            decimal adultPrice = 0M;
            decimal childPrice = 0M;
            decimal childWithOutPrice = 0M;
            adultPrice = (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Quarter.ToString(), SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Adult)
                                                                    + (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Quarter.ToString(), SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Adult);
            childPrice = (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Quarter.ToString(), SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Child)
                                                                    + (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Quarter.ToString(), SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Child);
            childWithOutPrice = (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Quarter.ToString(), SelectPriceType, false).GetAmount(TERMS.Common.PassengerType.Infant)
                                                                    + (Decimal)tourProfile.GetPrice(date, Terms.Product.Utility.RoomType.Quarter.ToString(), SelectPriceType, false).GetMarkup(TERMS.Common.PassengerType.Infant);
            if (childPrice > 0M)
                ((Label)e.Item.FindControl("lblQuatChildPrice")).Text = childPrice.ToString("#,###");
            else
                ((Label)e.Item.FindControl("lblQuatChildPrice")).Text = adultPrice.ToString("#,###");
            if (childWithOutPrice > 0M)
            {
                ((Label)e.Item.FindControl("lblQuatChildWithOutPrice")).Text = childWithOutPrice.ToString("#,###");
            }
            else
            {
                ((Label)e.Item.FindControl("lblQuatChildWithOutPrice")).Text = adultPrice.ToString("#,###");
                ((HtmlTableRow)e.Item.FindControl("trQuatChildWithOut")).Visible = false; //隐藏Child Without
            }
            ((Label)e.Item.FindControl("lblQuatAdultPrice")).Text = adultPrice.ToString("#,###");//Convert.ToDecimal(((Label)e.Item.FindControl("lblQuatAdultPrice")).Text).ToString("#,###");
            DropDownList ddlQuatAdult = (DropDownList)e.Item.FindControl("ddlQuatAdult");
            DropDownList ddlQuatChild = (DropDownList)e.Item.FindControl("ddlQuatChild");
            DropDownList ddlQuatChildWithOut = (DropDownList)e.Item.FindControl("ddlQuatChildWithOut");
            ddlQuatAdult.SelectedIndex = ddlQuatAdult.Items.IndexOf(ddlQuatAdult.Items.FindByValue(((Label)e.Item.FindControl("lblQuatAdult")).Text));
            ddlQuatChild.SelectedIndex = ddlQuatChild.Items.IndexOf(ddlQuatChild.Items.FindByValue(((Label)e.Item.FindControl("lblQuatChild")).Text));
            ddlQuatChildWithOut.SelectedIndex = ddlQuatChildWithOut.Items.IndexOf(ddlQuatChildWithOut.Items.FindByValue(((Label)e.Item.FindControl("lblQuatChildWithOut")).Text));
        }
    }

    private List<ConvertTourRoom> ConvertToTempTourRoom(List<TourRoom> tourRooms)
    {
        List<ConvertTourRoom> tempTourRooms = new List<ConvertTourRoom>();
        ConvertTourRoom convertTourRoom = null;
        int roomIndex = 0;
        foreach (TourRoom tr in tourRooms)
        {
           
            if (roomIndex != tr.RoomIndex)
            {
                convertTourRoom = new ConvertTourRoom();
                roomIndex = tr.RoomIndex;
                convertTourRoom.RoomIndex = tr.RoomIndex;
                convertTourRoom.UnitPrice = tr.UnitPrice;
                if (tr.PassengerType == PassengerType.Adult)
                    convertTourRoom.Adult = tr.Quantity;
                if (tr.PassengerType == PassengerType.Child)
                    convertTourRoom.Child = tr.Quantity;
                if (tr.PassengerType == PassengerType.Infant)
                    convertTourRoom.ChildWithOut = tr.Quantity;
                tempTourRooms.Add(convertTourRoom);
            }
            else
            {
                //convertTourRoom.UnitPrice = tr.UnitPrice;
                if (tr.PassengerType == PassengerType.Adult)
                    convertTourRoom.Adult = tr.Quantity;
                if (tr.PassengerType == PassengerType.Child)
                    convertTourRoom.Child = tr.Quantity;
                if (tr.PassengerType == PassengerType.Infant)
                    convertTourRoom.ChildWithOut = tr.Quantity;
            }
        }
        return tempTourRooms;
    }
    protected void dlSingle_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((Label)e.Item.FindControl("lblSingleAdultPrice")).Text = Convert.ToDecimal(((Label)e.Item.FindControl("lblSingleAdultPrice")).Text).ToString("#,###");

            DropDownList ddlSingleAdult = (DropDownList)e.Item.FindControl("ddlSingleAdult");
            ddlSingleAdult.SelectedIndex = ddlSingleAdult.Items.IndexOf(ddlSingleAdult.Items.FindByValue(((Label)e.Item.FindControl("lblSingleAdult")).Text));
        }
    }

    protected void ddlAdult_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }

    protected void ddlChild_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }

    protected void ddlChildWithOut_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitBinderInfo();
    }
}

//临时转换类，便于页面显示
public class ConvertTourRoom
{
    private int m_Adult = 0;
    public int Adult
    {
        set
        {
            m_Adult = value;
        }
        get
        {
            return m_Adult;
        }
    }
    private int m_Child = 0;
    public int Child
    {
        set
        {
            m_Child = value;
        }
        get
        {
            return m_Child;
        }
    }
    private int m_ChildWithOut = 0;
    public int ChildWithOut
    {
        set
        {
            m_ChildWithOut = value;
        }
        get
        {
            return m_ChildWithOut;
        }
    }
    private decimal m_UnitPrice = 0M;
    public decimal UnitPrice
    {
        set
        {
            m_UnitPrice = value;
        }
        get
        {
            return m_UnitPrice;
        }
    }
    private int m_RoomIndex = 0;
    public int RoomIndex
    {
        set
        {
            m_RoomIndex = value;
        }
        get
        {
            return m_RoomIndex;
        }
    }
}
