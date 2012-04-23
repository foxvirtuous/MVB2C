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
using System.Text.RegularExpressions;
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

namespace Terms.Web.Page.Package2
{
    public partial class CreditCardInformation : SalseBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
            if (this.IsSearchConditionNull)
            {
                this.Response.Redirect("~/Page/Common/ErrorMessage.aspx?ErrorMessage=The search condition has been removed from cache, please re-search.&&GoToPage=~/Page/Common/CreditCardInfoForm.aspx");
            }
            else
            {
                this.NavigationControl1.PageCode = 3;
                if (!IsPostBack)
                {
                    InitSet();
                    this.lblEmail.Text = Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email;
                    SetValidationGroup();
                    if (!string.IsNullOrEmpty(Request.QueryString["ErrMsg"]))
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + Request.QueryString["ErrMsg"] + "');</script>");
                }
            }
            //如果航空公司的CODE是UA，那么不能够订购这张机票
            string strAirlineCode = string.Empty;

            if (ConfigurationManager.AppSettings.Get("HiddenCreditCardAirline") != null)
                strAirlineCode = ConfigurationManager.AppSettings.Get("HiddenCreditCardAirline").ToString().ToUpper();

            bool isAirlineCode = false;

            if (!string.IsNullOrEmpty(strAirlineCode))
            {
                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is PackageOrderItem)
                    {
                        PackageOrderItem packageorderitem = (PackageOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i];

                        foreach (OrderItem orderitem in packageorderitem.Items)
                        {
                            if (orderitem is AirOrderItem)
                            {
                                foreach (SubAirTrip subTrip in ((AirOrderItem)orderitem).Merchandise.AirTrip.SubTrips)
                                {
                                    foreach (AirLeg airleg in subTrip.Flights)
                                    {
                                        if (strAirlineCode.Contains(airleg.AirLine.Code))
                                        {
                                            isAirlineCode = true;
                                            break;
                                        }
                                    }
                                    if (isAirlineCode)
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        if (isAirlineCode)
                        {
                            break;
                        }
                    }
                    else if (Utility.Transaction.CurrentTransactionObject.Items[i] is AirOrderItem)
                    {
                        foreach (SubAirTrip subTrip in ((AirOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).Merchandise.AirTrip.SubTrips)
                        {
                            foreach (AirLeg airleg in subTrip.Flights)
                            {
                                if (strAirlineCode.Contains(airleg.AirLine.Code))
                                {
                                    isAirlineCode = true;
                                    break;
                                }
                            }

                            if (isAirlineCode)
                            {
                                break;
                            }
                        }

                        if (isAirlineCode)
                        {
                            break;
                        }
                    }
                }

                //if (isAirlineCode)
                //{
                //    CreditCardInfoControl1.Visible = false;
                //    divCCInfo.Visible = false;
                //    divDisplay.Visible = true;
                //}
            }
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
                        this.lblRoomsAndPassengers.Text += "Room #" + (i + 1).ToString() + ": " + packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Adult].ToString() + " Adult(s)," + packageSearchCondition.HotelSearchCondition.RoomSearchConditions[i].Passengers[TERMS.Common.PassengerType.Child].ToString() + " Child(ren)" + "<br>";
                    }
                }
            }
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            if (hdFlag.Value == "YES")
            {
                if (this.txtEmail.Text == "")
                {

                }
                else
                {
                    string RegularExpressions = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

                    Match m = Regex.Match(this.txtEmail.Text, RegularExpressions);

                    if (!m.Success)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The mail address pattern is wrong');</script>");
                        return;
                    }

                    Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.Email = this.txtEmail.Text;
                    lbMessage.Visible = false;
                    lbMessage.Text = "";
                }
            }
            else
            {
                lbMessage.Visible = false;
                lbMessage.Text = "";
            }
            //if (!divDisplay.Visible)
            //{
                if (!CreditCardInfoControl1.PaddingPassengerInfo())
                {
                    return;
                }
            //}

            if (Utility.Transaction.CurrentTransactionObject == null)
            {
                return;
            }
            else
            {

                try
                {

                    SendEmailViewControl1.BindValueToControls();

                    System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo(UserCulture.ToString(), true);
                    System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
                    System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
                    this.SendEmailViewControl1.RenderControl(oHtmlTextWriter);

                    flagSearch.Value = oHtmlTextWriter.InnerWriter.ToString();

                    Utility.Transaction.EmailVersion = flagSearch.Value;

                    this.Response.Redirect("~/page/Common/SaveOrderWaiting.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
                    //this.Response.Redirect("~/page/Package2/SucceedFrom.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);

                }

                catch (Exception ex)
                {
                    string strError = ex.Message.Replace("\r", " ").Replace("\n", " ");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + strError + "');</script>");
                    return;
                }
            }
        }

        private void SetValidationGroup()
        {
            CreditCardInfoControl1.ValidationGroup = "PackageCreditForm";
            this.btnPurchase.ValidationGroup = "PackageCreditForm";
        }
    }
}
