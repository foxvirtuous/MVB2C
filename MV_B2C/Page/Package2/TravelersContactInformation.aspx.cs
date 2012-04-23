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
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;
using Terms.Sales.Business;

namespace Terms.Web.Page.Package2
{
    public partial class TravelersContactInformation : SalseBasePage
    {
        public PackageMerchandise PgMerchandise
        {
            get
            {
                return (PackageMerchandise)this.OnSearch();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsSearchConditionNull)
            {
                this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
                this.NavigationControl1.PageCode = 3;
                if (!IsPostBack)
                {
                    SetValidationGroup();
                    InitSet();
                }
            }
        }

        private void SetValidationGroup()
        {
            this.HotelOrderPassengerInfoControl1.ValidationGroup = "TravelersContactInformation";
            this.ibtnSubmit.ValidationGroup = "TravelersContactInformation";
            this.PHContactInfoControl1.ValidationGroup = "TravelersContactInformation";
        }

        private void InitSet()
        {
            if (!IsSearchConditionNull)
            {
                if (this.Transaction.CurrentTransactionObject != null && this.Transaction.CurrentTransactionObject.Items.Count > 0)
                {
                    List<AirMaterial> FlightDetails = new List<AirMaterial>();
                    FlightDetails.Add(((AirOrderItem)((PackageOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).Items[0]).Merchandise);
                    this.PKGSelectedFlightControl1.FlightDetails = FlightDetails;
                }

                PackageSearchCondition packageSearchCondition = (PackageSearchCondition)this.Transaction.CurrentSearchConditions;
                lblFrom.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.City.Name + ", " + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.City.Country.Code + " (" + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Departure.Code + ")";
                lblTo.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.City.Name + ", " + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.City.Country.Code + " (" + packageSearchCondition.AirSearchCondition.AirTripCondition[0].Destination.Code + ")";
                lblDepartDate.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[0].DepartureDate.ToString("MM/dd/yy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                lblReturnDate.Text = packageSearchCondition.AirSearchCondition.AirTripCondition[1].DepartureDate.ToString("MM/dd/yy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                if (packageSearchCondition.HotelSearchCondition.RoomSearchConditions.Count > 0)
                {
                    for (int i = 0; i < packageSearchCondition.HotelSearchCondition.RoomSearchConditions.Count; i++)
                    {
                        this.lblRoomsAndPassengers.Text += Resources.Global.Room + " #" + (i + 1).ToString() + ": " + packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Adult].ToString() + " Adult(s)," + packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Child].ToString() + " Child(ren)" + "<br>";
                    }
                }
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

        protected void ibtnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                bool flag;
                Utility.Transaction.CurrentTransactionObject.Remark = this.txtRemark.Value;
                flag = this.PHContactInfoControl1.PaddingPassengerInfo();
                flag = this.HotelOrderPassengerInfoControl1.PaddingPassengerInfo();


                if (!flag)
                {
                    return;
                }

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
                    //OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.EnterTravels, this);
                    this.Response.Redirect("CreditCardInformation.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
                }
            }
        }
    }
}
