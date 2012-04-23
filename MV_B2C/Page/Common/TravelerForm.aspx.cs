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
using Terms.Material.Domain;
using Terms.Sales.Domain;
using Terms.Product.Domain;
using TERMS.Common.Search;
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;
using TERMS.Business.Centers.SalesCenter;
using Terms.Base.Utility;


public partial class TravelerForm : SalseBasePage
{
    public TravelerForm()
    {
        this.InitializeControls += new EventHandler(TravelerForm_InitializeControls);
    }

    void TravelerForm_InitializeControls(object sender, EventArgs e)
    {
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        this.SetWebSiteInfomation();
        this.StatesControl1.PageCode = 3;
        if (!this.IsSearchConditionNull)
        {
            if (!IsPostBack)
            {
                //InitSet();

                SetValidationGroup();

                SetInsurance();
                //this.FlightHeader1.BindDate();
            }
        }
        else
        {
            this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The search condition has been removed from cache, please re-search.&&GoToPage=~/Page/Common/TravelerForm.aspx");
        }
    }

    private void SetValidationGroup()
    {
        OrderPassengerInfoControl1.ValidationGroup = "PackageCreditForm";
        ContactInfoControl1.ValidationGroup = "PackageCreditForm";
        this.ibtnSubmit.ValidationGroup = "PackageCreditForm";
    }
    protected void ibtnSubmit_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            bool flag;
            Utility.Transaction.CurrentTransactionObject.Remark = this.txtRemark.Value;
            flag = OrderPassengerInfoControl1.PaddingPassengerInfo();
            if (!flag)
            {
                return;
            }
            flag = ContactInfoControl1.PaddingPassengerInfo();
            if (!flag)
            {
                return;
            }
            if (chkInsurance.Checked)
            {
                Terms.Sales.Business.InsuranceSearchCondition Condition = new Terms.Sales.Business.InsuranceSearchCondition();

                Condition.InsuranceType = TERMS.Common.InsuranceType.AirOnly;

                List<DateTime> listDateBegin = new List<DateTime>();
                List<DateTime> listDateEnd = new List<DateTime>();

                ///当有Air的时候 直接记录各个Air的CheckIn和CheckOut日期

                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is AirOrderItem)
                    {
                        for (int j = 0; j < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips.Count; j++)
                        {
                            for (int x = 0; x < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips[j].Flights.Count; x++)
                            {
                                listDateBegin.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips[j].Flights[x].DepartureTime);
                                listDateEnd.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips[j].Flights[x].ArriveTime);
                            }
                        }
                    }
                }
                //对时间进行排序
                listDateBegin.Sort();
                listDateEnd.Sort();


                Condition.DepartureDate = listDateBegin[0];
                Condition.ReturnDate = listDateEnd[listDateEnd.Count - 1];

                Condition.TotalTripCost = GetTotalPice();

                Condition.TravelerCount = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Adult) + ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Child);


                InsuranceMaterial insuranceMaterial = this.OnSearchInsurance(Condition);

                InsuranceOrderItem insuranceOrderItem = new InsuranceOrderItem(null);

                insuranceOrderItem.InsuranceOrderName = insuranceMaterial.InsuranceName;
                insuranceOrderItem.TotalPremiumAmount = Convert.ToDecimal(insuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount);

                Utility.Transaction.CurrentTransactionObject.AddItem(insuranceOrderItem);

                //记录输入顾客事件
                OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.EnterTravels, this);

                this.Response.Redirect("~/Page/Hotel/HotelTravelerInsuranceForm.aspx?ConditionID=" + Request.Params["ConditionID"]);
            }
            else
            {
                //记录输入顾客事件
                OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.EnterTravels, this);

                this.Response.Redirect(SecureUrlSuffix + "Page/Common/CreditCardInfoForm.aspx?ConditionID=" + Request.Params["ConditionID"]);
            }
        }
    }

    private void SetInsurance()
    {
        Terms.Sales.Business.InsuranceSearchCondition Condition = new Terms.Sales.Business.InsuranceSearchCondition();

        Condition.InsuranceType = TERMS.Common.InsuranceType.AirOnly;
        List<DateTime> listDateBegin = new List<DateTime>();
        List<DateTime> listDateEnd = new List<DateTime>();

        ///当有Air的时候 直接记录各个Air的CheckIn和CheckOut日期
        for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
        {
            if (Utility.Transaction.CurrentTransactionObject.Items[i] is AirOrderItem)
            {
                for (int j = 0; j < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips.Count; j++)
                {
                    for (int x = 0; x < ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips[j].Flights.Count; x++)
                    {
                        listDateBegin.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips[j].Flights[x].DepartureTime);
                        listDateEnd.Add(((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips[j].Flights[x].ArriveTime);
                    }
                }
            }
        }
        //对时间进行排序
        listDateBegin.Sort();
        listDateEnd.Sort();

        //记录最早日期与最晚日期

        Condition.DepartureDate = listDateBegin[0];
        Condition.ReturnDate = listDateEnd[listDateEnd.Count - 1];

        Condition.TotalTripCost = GetTotalPice();

        Condition.TravelerCount = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Adult) + ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Child);

        try
        {

            InsuranceMaterial insuranceMaterial = this.OnSearchInsurance(Condition);

            lblInsuranceName.Text = "Insurance Name : " + insuranceMaterial.InsuranceName;

            lblInsuranceTotal.Text = "Insurance Total : $" + insuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount.ToString("N0");

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

    private decimal GetTotalPice()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            {
                int adult = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Adult); //大人数
                int child = ((Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions).GetPassengerNumber(TERMS.Common.PassengerType.Child); //小孩数
                AirOrderItem airOrderItem = (AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0];
                decimal AirTotalPrice = 0.0m; //总价
                decimal adultTax = 0.0m; //大人单税
                decimal childTax = 0.0m; //小孩单税
                decimal adultPrice = 0.0m; //大人含税单价
                decimal childPrice = 0.0m; //小孩含税单价
                decimal adultMarkup = 0.0m;
                decimal childMarkup = 0.0m;

                decimal adultBasePrice = 0.0m; //大人不含税单价
                decimal childBasePrice = 0.0m; //小孩不含税单价
                decimal serviceFee = 5.0m; //PUB的服务费（包括webfare）

                if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "COMM" || airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "NET")
                {
                    adultTax = airOrderItem.Profile.GetParam("ADULT_TAX") == null ? adultTax : Convert.ToDecimal(airOrderItem.Profile.GetParam("ADULT_TAX"));
                    childTax = airOrderItem.Profile.GetParam("CHILD_TAX") == null ? childTax : Convert.ToDecimal(airOrderItem.Profile.GetParam("CHILD_TAX"));
                    airOrderItem.Merchandise.SetAdultTax(adultTax);
                    airOrderItem.Merchandise.SetChildTax(childTax);

                    childMarkup = airOrderItem.GetPrice().GetMarkup(TERMS.Common.PassengerType.Child);//Profile.GetParam("CHILD_MARKUP") == null ? childMarkup : Convert.ToDecimal(airOrderItem.Profile.GetParam("CHILD_MARKUP"));
                    adultMarkup = airOrderItem.GetPrice().GetMarkup(TERMS.Common.PassengerType.Adult);//Profile.GetParam("ADULT_MARKUP") == null ? adultMarkup : Convert.ToDecimal(airOrderItem.Profile.GetParam("ADULT_MARKUP"));

                    //TERMS.Common.Markup markup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(adultMarkup));
                    //markup.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(childMarkup));

                    //airOrderItem.Merchandise.Price.SetMarkup(markup);
                    //airOrderItem.Merchandise.Price.AddMarkup(new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(adultMarkup)));

                    adultBasePrice = airOrderItem.Profile.GetParam("PUBLISHED_ADULT_FARE") == null ? adultBasePrice : Convert.ToDecimal(airOrderItem.Profile.GetParam("PUBLISHED_ADULT_FARE"));
                    childBasePrice = airOrderItem.Profile.GetParam("PUBLISHED_CHILD_FARE") == null ? childBasePrice : Convert.ToDecimal(airOrderItem.Profile.GetParam("PUBLISHED_CHILD_FARE"));
                    int commision = airOrderItem.Profile.GetParam("COMMISION") == null ? 0 : Convert.ToInt32(airOrderItem.Profile.GetParam("COMMISION"));

                    if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "NET") commision = 0;
                    if (child > 0)
                    {
                        if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "NET")
                        {
                            childPrice = airOrderItem.Merchandise.ChildBaseFareWithCCSurcharge + airOrderItem.Merchandise.ChildMarkup + childTax;
                        }
                        else
                        {
                            if (Convert.ToBoolean(airOrderItem.Profile.GetParam("ISWEBFARE")))
                            {
                                childPrice = childBasePrice + serviceFee + childTax;
                                //airOrderItem.Merchandise.SetChildBaseFare(childBasePrice);
                                //airOrderItem.GetPrice().SetServiceFee(PassengerType.Child, new FareAmount(serviceFee, new Currency(), new Currency()));
                            }
                            else
                            {
                                childPrice = childBasePrice * (100 - commision) / 100 + airOrderItem.Merchandise.ChildMarkup + childTax;
                                //airOrderItem.Merchandise.SetChildBaseFare(childBasePrice * (100 - commision) / 100);
                            }
                        }
                    }

                    if (adult > 0)
                    {
                        if (airOrderItem.Profile.GetParam("FARE_TYPE").ToString() == "NET")
                        {
                            adultPrice = airOrderItem.Merchandise.AdultBaseFareWithCCSurcharge + airOrderItem.Merchandise.AdultMarkup + adultTax;
                        }
                        else
                        {
                            if (Convert.ToBoolean(airOrderItem.Profile.GetParam("ISWEBFARE")))
                            {
                                adultPrice = adultBasePrice + serviceFee + adultTax;
                                //airOrderItem.Merchandise.SetAdultBaseFare(adultBasePrice);
                                //airOrderItem.GetPrice().SetServiceFee(PassengerType.Adult, new FareAmount(serviceFee, new Currency(), new Currency()));
                            }
                            else
                            {
                                adultPrice = adultBasePrice * (100 - commision) / 100 + airOrderItem.Merchandise.AdultMarkup + adultTax;
                                //airOrderItem.Merchandise.SetAdultBaseFare(adultBasePrice * (100 - commision) / 100);
                            }
                        }
                    }

                }
                else
                {
                    adultTax = airOrderItem.GetPrice().GetTax(TERMS.Common.PassengerType.Adult);
                    childTax = airOrderItem.GetPrice().GetTax(TERMS.Common.PassengerType.Child);

                    if (child > 0)
                    {
                        //airOrderItem.GetPrice().SetServiceFee(PassengerType.Child, new FareAmount(serviceFee, new Currency(), new Currency()));
                        childPrice = airOrderItem.GetPrice().GetBase(TERMS.Common.PassengerType.Child) + airOrderItem.GetPrice().GetMarkup(TERMS.Common.PassengerType.Child) + airOrderItem.GetPrice().GetServiceFee(TERMS.Common.PassengerType.Adult) + childTax;
                    }

                    if (adult > 0)
                    {
                        //airOrderItem.GetPrice().SetServiceFee(PassengerType.Adult, new FareAmount(serviceFee, new Currency(), new Currency()));
                        adultPrice = airOrderItem.GetPrice().GetBase(TERMS.Common.PassengerType.Adult) + airOrderItem.GetPrice().GetMarkup(TERMS.Common.PassengerType.Adult) + airOrderItem.GetPrice().GetServiceFee(TERMS.Common.PassengerType.Adult) + adultTax;
                    }
                }

                AirTotalPrice = adultPrice * adult + childPrice * child;

                return AirTotalPrice;
            }
            else
            {
                return 0M;
            }
        }

        return 0M;
    }
}