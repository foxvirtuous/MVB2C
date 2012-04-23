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

using Spring.Web.UI;
using log4net;

using Terms.Sales.Domain;

using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Common.Search;

public partial class PackageTravelerForm : SalseBasePage
{
   
    public PackageMerchandise PgMerchandise
    {
        get{
        return (PackageMerchandise)this.OnSearch();}
    }
    public PackageTravelerForm()
    {
        this.InitializeControls += new EventHandler(PackageTravelerForm_InitializeControls);

        this.PreRender += new EventHandler(PackageTravelerForm_PreRender);
    }

    void PackageTravelerForm_PreRender(object sender, EventArgs e)
    {
        if (this.AAA.Value == "001")
        {
            Do();
        }
    }

    void PackageTravelerForm_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        this.SetWebSiteInfomation();
        Navigation1.PageCode = 2;
        FlightHeader1.FlagCode = 2;
        FlightHeader1.SubIndex = 0;
        DefaultFlightDetails1.FlagCode = 2;
        if (!IsPostBack)
        {
            HotelListView1.IsMoreLinkVisible = false;
            InitSet();
            SetValidationGroup();
            List<PackageMaterial> MVHotelList = PgMerchandise.GetPackageMaterials(1);

            if (Utility.IsSubAgent)
            {
                decimal dectemp = 0M;

                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    //if (Utility.Transaction.CurrentTransactionObject.Items[i] is SubagentMarkupOrderItem)
                    //{
                    //    dectemp += ((SubagentMarkupOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Markup;
                    //}

                    dectemp += Utility.Transaction.CurrentTransactionObject.SubagentMarkup.GetTotalMarkup(TERMS.Common.PassengerType.Adult);

                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is TransferOrderItem)
                    {
                        dectemp += ((TransferOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Price;
                    }
                }

                this.FlightHeader1.TotalPrice = ((PackageMaterial)MVHotelList[((List<int>)PgMerchandise.DefaultIndex[1])[0]]).TotalPrice + dectemp;
            }
            else
            {
                decimal dectemp = 0M;

                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is TransferOrderItem)
                    {
                        dectemp += ((TransferOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Price;
                    }
                }

                this.FlightHeader1.TotalPrice = ((PackageMaterial)MVHotelList[((List<int>)PgMerchandise.DefaultIndex[1])[0]]).TotalPrice + dectemp;
            }
            this.FlightHeader1.BindDate();

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                SetInsurance();
            }
        }
        else
        {

        }
    }

    private void InitSet()
    {
        Terms.Sales.Business.PackageSearchCondition pakcageSearch = (Terms.Sales.Business.PackageSearchCondition)this.Transaction.CurrentSearchConditions;
        List<AirMaterial> airMertialList = new  List<AirMaterial>();
        airMertialList.Add((AirMaterial)PgMerchandise.DefaultMerchandise[0]);
        this.DefaultFlightDetails1.FlightDetails =airMertialList;
    }


    protected void btnCountinue_Click(object sender, ImageClickEventArgs e)
    {

        if (this.IsValid)
        {
            bool flag;
            flag = OrderPassengerInfo1.PaddingPassengerInfo();
            this.Response.Redirect("PackageCreditForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
        }
    }

    private void SetValidationGroup()
    {
        OrderPassengerInfo1.ValidationGroup = "PackageCreditForm";
        ContactInfo1.ValidationGroup = "PackageCreditForm";
        this.ibtnSubmit.ValidationGroup = "PackageCreditForm";
    }
    protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (this.IsValid)
        {
            bool flag;
            Utility.Transaction.CurrentTransactionObject.Remark = this.txtRemark.Value;
            flag = OrderPassengerInfo1.PaddingPassengerInfo();
            flag = ContactInfo1.PaddingPassengerInfo();
            //flag = BookingTransportationControl1.UpdateTransfer();

            if (!flag)
            {
                return;
            }

            //if (!string.IsNullOrEmpty(BookingTransportationControl1.Warning))
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>confirmerror('" + BookingTransportationControl1.Warning + "');</script>");
            //    return;
            //}

            //BookingTransportationControl1.DoUpdateTransfer();
           
            if (this.chkInsurance.Checked && this.divInsurance.Visible == true)
            {
                Terms.Sales.Business.InsuranceSearchCondition Condition = new Terms.Sales.Business.InsuranceSearchCondition();

                Condition.InsuranceType = TERMS.Common.InsuranceType.Package;

                List<DateTime> listDateBegin = new List<DateTime>();
                List<DateTime> listDateEnd = new List<DateTime>();

                ///当有Air的时候 直接记录各个Air的CheckIn和CheckOut日期

                if (Utility.Transaction.CurrentTransactionObject.Items[0] is PackageOrderItem)
                {
                    for (int j = 0; j < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips.Count; j++)
                    {
                        for (int x = 0; x < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips[j].Flights.Count; x++)
                        {
                            listDateBegin.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips[j].Flights[x].DepartureTime);
                            listDateEnd.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips[j].Flights[x].ArriveTime);
                        }
                    }
                }
                //对时间进行排序
                listDateBegin.Sort();
                listDateEnd.Sort();


                Condition.DepartureDate = listDateBegin[0];
                Condition.ReturnDate = listDateEnd[listDateEnd.Count - 1];

                List<PackageMaterial> MVHotelList = PgMerchandise.GetPackageMaterials(1);
                Condition.TotalTripCost = ((PackageMaterial)MVHotelList[((List<int>)PgMerchandise.DefaultIndex[1])[0]]).TotalPrice;

                Condition.TravelerCount = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult) + ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);

                InsuranceMaterial insuranceMaterial = this.OnSearchInsurance(Condition);

                InsuranceOrderItem insuranceOrderItem = new InsuranceOrderItem(null);

                insuranceOrderItem.InsuranceOrderName = insuranceMaterial.InsuranceName;
                insuranceOrderItem.TotalPremiumAmount = Convert.ToDecimal(insuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount);

                Utility.Transaction.CurrentTransactionObject.AddItem(insuranceOrderItem);

                this.Response.Redirect("PackageTravelerInsurance.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
            }
            else
            {
                //记录输入顾客信息
                OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.EnterTravels, this);
                this.Response.Redirect(SecureUrlSuffix + "Page/Hotel/HotelCreditForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
            }
        }
    }

    private void Do()
    {
        BookingTransportationControl1.DoUpdateTransfer();

        if (this.chkInsurance.Checked && this.divInsurance.Visible == true)
        {
            Terms.Sales.Business.InsuranceSearchCondition Condition = new Terms.Sales.Business.InsuranceSearchCondition();

            Condition.InsuranceType = TERMS.Common.InsuranceType.Package;

            List<DateTime> listDateBegin = new List<DateTime>();
            List<DateTime> listDateEnd = new List<DateTime>();

            ///当有Air的时候 直接记录各个Air的CheckIn和CheckOut日期

            if (Utility.Transaction.CurrentTransactionObject.Items[0] is PackageOrderItem)
            {
                for (int j = 0; j < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips.Count; j++)
                {
                    for (int x = 0; x < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips[j].Flights.Count; x++)
                    {
                        listDateBegin.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips[j].Flights[x].DepartureTime);
                        listDateEnd.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips[j].Flights[x].ArriveTime);
                    }
                }
            }
            //对时间进行排序
            listDateBegin.Sort();
            listDateEnd.Sort();


            Condition.DepartureDate = listDateBegin[0];
            Condition.ReturnDate = listDateEnd[listDateEnd.Count - 1];

            List<PackageMaterial> MVHotelList = PgMerchandise.GetPackageMaterials(1);
            Condition.TotalTripCost = ((PackageMaterial)MVHotelList[((List<int>)PgMerchandise.DefaultIndex[1])[0]]).TotalPrice;

            Condition.TravelerCount = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult) + ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);

            InsuranceMaterial insuranceMaterial = this.OnSearchInsurance(Condition);

            InsuranceOrderItem insuranceOrderItem = new InsuranceOrderItem(null);

            insuranceOrderItem.InsuranceOrderName = insuranceMaterial.InsuranceName;
            insuranceOrderItem.TotalPremiumAmount = Convert.ToDecimal(insuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount);

            Utility.Transaction.CurrentTransactionObject.AddItem(insuranceOrderItem);

            this.Response.Redirect("PackageTravelerInsurance.aspx");
        }
        else
        {
            this.Response.Redirect(SecureUrlSuffix + "Page/Hotel/HotelCreditForm.aspx");
        }
    }

    private void SetInsurance()
    {
        Terms.Sales.Business.InsuranceSearchCondition Condition = new Terms.Sales.Business.InsuranceSearchCondition();

        Condition.InsuranceType = TERMS.Common.InsuranceType.Package;

        List<DateTime> listDateBegin = new List<DateTime>();
        List<DateTime> listDateEnd = new List<DateTime>();

        ///当有Air的时候 直接记录各个Air的CheckIn和CheckOut日期

            if (Utility.Transaction.CurrentTransactionObject.Items[0] is PackageOrderItem)
            {
                for (int j = 0; j < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips.Count; j++)
                {
                    for (int x = 0; x < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips[j].Flights.Count; x++)
                    {
                        listDateBegin.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips[j].Flights[x].DepartureTime);
                        listDateEnd.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Merchandise.AirTrip.SubTrips[j].Flights[x].ArriveTime);
                    }
                }
            }
        //对时间进行排序
        listDateBegin.Sort();
        listDateEnd.Sort();


        Condition.DepartureDate = listDateBegin[0];
        Condition.ReturnDate = listDateEnd[listDateEnd.Count - 1];

        List<PackageMaterial> MVHotelList = PgMerchandise.GetPackageMaterials(1);
        Condition.TotalTripCost = ((PackageMaterial)MVHotelList[((List<int>)PgMerchandise.DefaultIndex[1])[0]]).TotalPrice;
        Condition.TravelerCount = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult) + ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);

        try
        {
            InsuranceMaterial insuranceMaterial = this.OnSearchInsurance(Condition);

            lblInsuranceName.Text = insuranceMaterial.InsuranceName;

            lblInsuranceTotal.Text = "$" + insuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount.ToString("N0");


            if (insuranceMaterial.InsuranceUrl.IndexOf(@"http://") > -1)
            {
                hlInsuranceDetails.NavigateUrl = insuranceMaterial.InsuranceUrl;
            }
            else
            {
                hlInsuranceDetails.NavigateUrl = @"http://" + insuranceMaterial.InsuranceUrl;
            }
        }
        catch
        {
            return;
        }
    }
}
