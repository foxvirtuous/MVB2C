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

public partial class TourPriceInfoControl : SalesBaseUserControl
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
    private Hashtable m_Rooms = new Hashtable();
    public Hashtable Rooms
    {
        get
        {

            return m_Rooms;
        }
        set
        {
            m_Rooms = value;
        }
    }

    public TourPriceInfoControl()
    {
        this.InitializeControls += new EventHandler(TourPriceInfoControl_InitializeControls);
    }

    void TourPriceInfoControl_InitializeControls(object sender, EventArgs e)
    {

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitBinderInfo();

            //InitAgentFlightMarkup();
        }
    }
    public void InitBinderInfo()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {

            if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
            {
                TourMaterial tourMaterial = (TourMaterial)SelectTourMaterial;
                int childNumber = 0;
                int adultNumber = 0;
                int InfantNumber = 0;
                decimal tourPrice = 0.0m;

                decimal addOnPrice = 0.0m;
                decimal insurancePrice = 0.0m;
                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is TourOrderItem)
                    {
                        TourOrderItem tourOrderItem = (TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                        rpTourRooms.DataSource = tourOrderItem.TourRooms;
                        rpTourRooms.DataBind();


                        childNumber = tourOrderItem.ChildNumber;
                        adultNumber = tourOrderItem.AdultNumber + tourOrderItem.ChildWithOutNumber;
                      //  InfantNumber = tourOrderItem.in


                        for (int j = 0; j < tourOrderItem.FareTypeList.Count; j++)
                        {

                            tourPrice += tourOrderItem.FareTypeList[j].Price * tourOrderItem.FareTypeList[j].Quantity;
                            if (tourOrderItem.FareTypeList[j].Type == TourFareType.ADDON)
                            {
                                addOnPrice = tourOrderItem.FareTypeList[j].Price * tourOrderItem.FareTypeList[j].Quantity;
                            }
                        }



                        //if (IsTourInsurance)
                        //{
                        //    phTourInsurance.Visible = true;
                        //    insurancePrice = Convert.ToDecimal(tourOrderItem.InsuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount * (adultNumber + childNumber));
                        //    lblTourInsurance.Text = insurancePrice.ToString("N0");
                        //    if (!tourOrderItem.IsInsurance)
                        //    {
                        //        div_IsSelected.Visible = true;
                        //        if (tourOrderItem.InsuranceMaterial.InsuranceUrl.IndexOf(@"http://") > -1)
                        //        {
                        //            hlInsuranceDetails.NavigateUrl = tourOrderItem.InsuranceMaterial.InsuranceUrl;
                        //        }
                        //        else
                        //        {
                        //            hlInsuranceDetails.NavigateUrl = @"http://" + tourOrderItem.InsuranceMaterial.InsuranceUrl;
                        //        }
                        //        hlInsuranceDetails.Target = "_blank";
                        //    }
                        //    else
                        //    {
                        //        div_IsSelected.Visible = false;
                        //    }
                        //}


                    }

                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is InsuranceOrderItem)
                    {
                        InsuranceOrderItem insuranceorderitem = (InsuranceOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                        phTourInsurance.Visible = true;

                        insurancePrice = Convert.ToDecimal(insuranceorderitem.Item.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount);

                        lblTourInsurance.Text = insurancePrice.ToString("N0");

                        div_IsSelected.Visible = false;
                    }

                }
                decimal TotalPrice = tourPrice  + insurancePrice;
                
                //add pengzhaohui
                if (((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).DeptCity != null)
                {
                    Terms.Common.Domain.City city = AirService.CommCityDao.FindCityByCode(((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).DeptCity);
                    if (city != null)
                    {
                        lblFromCity.Text = city.Name;
                    }
                }
                lblToCity.Text =  ((TourProfile)tourMaterial.Profile).StartCity.Name;
                //add end

                if (!((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).IsLandOnly && addOnPrice > 0)
                {
                    this.phTourAddOn.Visible = true;
                    lbl_TourAddOn.Text = addOnPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                }


                //lbAdults.Text = lbAdultNum.Text = adultNumber.ToString();
                //lbChilds.Text = lbChildNum.Text = childNumber.ToString();

                //this.lbAdultPrice.Text = adultPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                //this.lbChildPrice.Text = childPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                this.lbTotalPrice.Text = TotalPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                if (((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).IsLandOnly == true)
                    this.lblMsg.Visible = false;

            }
        }
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


    protected void rpTourRooms_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl_TourTag = (Label)e.Item.FindControl("lbl_TourTag");
           // Label lbl_RoomNO = (Label)e.Item.FindControl("lbl_RoomNO");
            Label lbl_RoomType = (Label)e.Item.FindControl("lbl_RoomType");

            Label lbl_PersonType = (Label)e.Item.FindControl("lbl_PersonType");

            Label lbl_PersonNumber = (Label)e.Item.FindControl("lbl_PersonNumber");
            Label lbl_Price = (Label)e.Item.FindControl("lbl_Price");
            Label lbl_PriceNumber = (Label)e.Item.FindControl("lbl_PriceNumber");
            


            TourRoom tourRoom = (TourRoom)(((System.Object)(((System.Web.UI.WebControls.RepeaterItem)(e.Item)).DataItem)));
            if (e.Item.ItemIndex > 0)
                lbl_TourTag.Visible = false;

           
            //lbl_RoomNO.Text = tourRoom.RoomIndex.ToString();
            string roomType = string.Empty;
            if (tourRoom.RoomType.ToLower().Contains("single"))
                roomType = Resources.Global.SINGLE;
            else if (tourRoom.RoomType.ToLower().Contains("twin"))
                roomType = Resources.Global.TWIN;
            else if (tourRoom.RoomType.ToLower().Contains("triple"))
                roomType = Resources.Global.TRIPLE;
            else if (tourRoom.RoomType.ToLower().Contains("quat"))
                roomType = Resources.Global.QUAT;

            if (UserCulture.Name.Contains("zh-CN"))
                lbl_RoomType.Text = tourRoom.RoomType + " ( " + roomType + " ) ";
            else
                lbl_RoomType.Text = tourRoom.RoomType;

            string passengerType = string.Empty;
            if (tourRoom.PassengerType.ToString().ToLower().Contains("adult"))
                passengerType = Resources.Global.ADULT;
            else if (tourRoom.PassengerType.ToString().ToLower().Contains("child"))
                passengerType = Resources.Global.CHILD;
            if (tourRoom.PassengerType == PassengerType.Infant)
                lbl_PersonType.Text = Resources.Global.CHILDOUT;
            else
                lbl_PersonType.Text = passengerType;

            lbl_PersonNumber.Text = tourRoom.Quantity.ToString();
            lbl_Price.Text = tourRoom.UnitPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
            lbl_PriceNumber.Text = tourRoom.Quantity.ToString();

            if (Rooms.ContainsKey(tourRoom.RoomIndex))
            {
                //lbl_RoomNO.Visible = false;
                lbl_RoomType.Visible = false;
            }
            else
            {
                Rooms.Add(tourRoom.RoomIndex, tourRoom.RoomType);
            }
            //string strPersonTypeTable = string.Empty;
            //string strPersonNumberTable = string.Empty;
            //string strPriceTable = string.Empty;

            //strPersonTypeTable += "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
            //strPersonNumberTable += "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
            //strPriceTable += "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
            //foreach (string key in tourRoom.PersonNumber.Keys)
            //{
            //    switch (key.ToUpper())
            //    {
            //        case "ADULT":
            //            if (Convert.ToInt32(tourRoom.PersonNumber[key]) > 0)
            //            {
            //                strPersonTypeTable += "<tr><td>Adult(s)</td></tr>";
            //                strPersonNumberTable += "<tr><td>" + tourRoom.PersonNumber[key].ToString() + "</td></tr>";
            //                strPriceTable += "<tr><td>" + GetUnitPprice(tourRoom, PassengerType.Adult) + "<font class=\"t08\">x" + tourRoom.PersonNumber[key].ToString() + "</font></td></tr>";
            //            }
            //            break;
            //        case "CHILD":
            //            if (Convert.ToInt32(tourRoom.PersonNumber[key]) > 0)
            //            {
            //                strPersonTypeTable += "<tr><td>Child(ren)</td></tr>";
            //                strPersonNumberTable += "<tr><td>" + tourRoom.PersonNumber[key].ToString() + "</td></tr>";
            //                strPriceTable += "<tr><td>" + GetUnitPprice(tourRoom, PassengerType.Child) + "<font class=\"t08\">x" + tourRoom.PersonNumber[key].ToString() + "</font></td></tr>";
            //            }
            //            break;
            //    }
            //}
            //strPersonTypeTable += " </table>";
            //lbl_PersonTypeTable.Text = strPersonTypeTable;
            //strPersonNumberTable += " </table>";
            //lbl_PersonNumberTable.Text = strPersonNumberTable;
            //strPriceTable += " </table>";
            //lbl_PriceTable.Text = strPriceTable;
        }
    }
    public string GetUnitPprice(TourRoom tourRoom, TERMS.Common.PassengerType passenger)
    {
        decimal unitPprice = 0.0m;
        //for (int i = 0; i < tourRoom.FareType.Count; i++)
        //{
        //    if (tourRoom.FareType[i].PassengerType.ToString().Equals(passenger.ToString()))
        //    {
        //        unitPprice = tourRoom.FareType[i].LandUnitNetPrice + tourRoom.FareType[i].UnitMarkup;

        //    }

        //}
        return unitPprice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
    }


    private void InitAgentFlightMarkup()
    {
        //if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        //    if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
        //        if (Utility.IsSubAgent)
        //        {
        //            phAgentFlightMarkup.Visible = true;
        //        }


        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
            if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
                if (Utility.IsSubAgent)
                {
                    //int temp = 0;
                    decimal decTemp = 0M;

                    //for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                    //{
                    //    if (Utility.Transaction.CurrentTransactionObject.Items[i] is SubagentMarkupOrderItem)
                    //    {
                    //        temp++;
                    //        decTemp += ((SubagentMarkupOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Markup;
                    //    }
                    //}

                    decTemp += Utility.Transaction.CurrentTransactionObject.SubagentMarkup.GetTotalMarkup(PassengerType.Adult);

                    if (decTemp > 0)
                    {
                        this.phAgentFlightMarkup.Visible = true;
                        lblAgentAdultUnitMarkup.Visible = true;
                        lblAgentAdultUnitMarkup.Text = decTemp.ToString("N2");
                        lbTotalPrice.Text = (Convert.ToDecimal(this.lbTotalPrice.Text) + decTemp).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat); ;
                    }
                    else
                    {
                        this.phAgentFlightMarkup.Visible = true;
                        txtAgentAdultUnitMarkup.Visible = true;
                    }
                }
    }

    protected void txtAgentAdultUnitMarkup_TextChanged(object sender, EventArgs e)
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {

            if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
            {
                int childNumber = 0;
                int adultNumber = 0;
                decimal tourPrice = 0.0m;

                decimal addOnPrice = 0.0m;
                decimal insurancePrice = 0.0m;
                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is TourOrderItem)
                    {
                        TourOrderItem tourOrderItem = (TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                        rpTourRooms.DataSource = tourOrderItem.TourRooms;
                        rpTourRooms.DataBind();



                        childNumber = tourOrderItem.ChildNumber;
                        adultNumber = tourOrderItem.AdultNumber;


                        for (int j = 0; j < tourOrderItem.FareTypeList.Count; j++)
                        {

                            tourPrice += tourOrderItem.FareTypeList[j].Price * tourOrderItem.FareTypeList[j].Quantity;
                            if (tourOrderItem.FareTypeList[j].Type == TourFareType.ADDON)
                            {
                                addOnPrice = tourOrderItem.FareTypeList[j].Price * tourOrderItem.FareTypeList[j].Quantity;
                            }
                        }



                        //if (IsTourInsurance)
                        //{
                        //    phTourInsurance.Visible = true;
                        //    insurancePrice = Convert.ToDecimal(tourOrderItem.InsuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount);
                        //    lblTourInsurance.Text = insurancePrice.ToString("N0");
                        //    if (!tourOrderItem.IsInsurance)
                        //    {
                        //        div_IsSelected.Visible = true;
                        //        if (tourOrderItem.InsuranceMaterial.InsuranceUrl.IndexOf(@"http://") > -1)
                        //        {
                        //            hlInsuranceDetails.NavigateUrl = tourOrderItem.InsuranceMaterial.InsuranceUrl;
                        //        }
                        //        else
                        //        {
                        //            hlInsuranceDetails.NavigateUrl = @"http://" + tourOrderItem.InsuranceMaterial.InsuranceUrl;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        div_IsSelected.Visible = false;
                        //    }
                        //}


                    }

                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is InsuranceOrderItem)
                    {
                        InsuranceOrderItem insuranceorderitem = (InsuranceOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                        phTourInsurance.Visible = true;

                        insurancePrice = Convert.ToDecimal(insuranceorderitem.Item.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount);

                        lblTourInsurance.Text = insurancePrice.ToString("N0");

                        div_IsSelected.Visible = false;
                    }

                }
                decimal TotalPrice = tourPrice + addOnPrice + insurancePrice;


                if (!((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).IsLandOnly && addOnPrice > 0)
                {
                    this.phTourAddOn.Visible = true;
                    lbl_TourAddOn.Text = addOnPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                }


                //lbAdults.Text = lbAdultNum.Text = adultNumber.ToString();
                //lbChilds.Text = lbChildNum.Text = childNumber.ToString();

                //this.lbAdultPrice.Text = adultPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                //this.lbChildPrice.Text = childPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
                this.lbTotalPrice.Text = TotalPrice.ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
            }
        }

        lbTotalPrice.Text = (Convert.ToDecimal(this.lbTotalPrice.Text) + Convert.ToDecimal(this.txtAgentAdultUnitMarkup.Text)).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
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
                        //SubagentMarkupOrderItem markup = new SubagentMarkupOrderItem(new TERMS.Business.Centers.ProductCenter.Profiles.SubagentMarkupProfile(""));

                        //markup.Markup = decmarkup;

                        //Utility.Transaction.CurrentTransactionObject.AddItem(markup);

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
}
