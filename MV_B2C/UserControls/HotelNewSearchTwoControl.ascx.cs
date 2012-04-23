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
using Terms.Sales.Business;
using TERMS.Common;
using TERMS.Business.Centers.SalesCenter;
using System.Collections.Generic;
using TERMS.Core.Product;

public partial class HotelNewSearchTwoControl : SalesBaseUserControl
{

    public HotelNewSearchTwoControl()
    {
        this.InitializeControls += new EventHandler(HotelNewSearchTwoControl_InitializeControls);
    }

    void HotelNewSearchTwoControl_InitializeControls(object sender, EventArgs e)
    {
        if (Utility.Transaction.CurrentTransactionObject != null)
        {
           
            txtCheckin.Path = txtCheckout.Path = "../../";

            txtCheckin.IsCoercion = true;
            txtCheckin.CoercionID = "txtCheckout";
            
            TextBox departureCalendarDate = (TextBox)this.txtCheckin.FindControl("calendarDate");
           
            departureCalendarDate.ValidationGroup = "HotelNewSearch";

            TextBox returnCalendarDate = (TextBox)this.txtCheckout.FindControl("calendarDate");
            
            returnCalendarDate.ValidationGroup = "HotelNewSearch";

            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                departureCalendarDate.Text = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                returnCalendarDate.Text = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                txtCheckin.AddDate(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn,((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.AddDays(-1));
                txtCheckin.IsAvailableDate = false;
                txtCheckin.BeginDate = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                txtCheckin.EndDate = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[1].DepartureDate;

                txtCheckout.AddDate(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn.AddDays(1), ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut);
                txtCheckout.IsAvailableDate = false;
                txtCheckout.BeginDate = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[0].DepartureDate;
                txtCheckout.EndDate = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.AirTripCondition[1].DepartureDate;
                
                
                for (int i = 0; i < ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).OptionalHotelSearchConditions.Count; i++)
                {
                    txtCheckin.AddDate(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).OptionalHotelSearchConditions[i].CheckIn, ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).OptionalHotelSearchConditions[i].CheckOut.AddDays(-1));
                    txtCheckout.AddDate(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).OptionalHotelSearchConditions[i].CheckIn.AddDays(1), ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).OptionalHotelSearchConditions[i].CheckOut);
                }

                cddHotel.SelectedValue = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.Country;
                cddCity.SelectedValue = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.Location;
            }
            else
            {
                departureCalendarDate.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                returnCalendarDate.Text = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                //txtCheckin.AddDate(((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn, ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.AddDays(-1));
                txtCheckin.IsAvailableDate = false;
                //txtCheckin.BeginDate = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut;
                //txtCheckin.EndDate = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn;

                //txtCheckout.AddDate(((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.AddDays(1), ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut);
                txtCheckout.IsAvailableDate = false;
                //txtCheckout.BeginDate = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn;
                //txtCheckout.EndDate = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn;

                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                {
                    txtCheckin.AddDate(((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).CheckIn, ((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).CheckOut.AddDays(-1));
                    txtCheckout.AddDate(((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).CheckIn.AddDays(1), ((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]).CheckOut);
                }

                cddHotel.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).Country;
                cddCity.SelectedValue = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).Location;
            }

            txtCheckin.BeginDate = DateTime.Now.AddDays(7);
            txtCheckout.BeginDate = DateTime.Now.AddDays(7);
        }
        else
        {
            //出错处理
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.ddlCountry.SelectedItem == null || this.ddlCity.SelectedItem == null)
            return;

        if (!IsDateValid())
            return;

        if (!Utility.IsSearchConditionNull)
        {
            this.ReturnUrlPath = this.Request.Url.OriginalString;

            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                HotelSearchCondition hotelSearchCondition = (HotelSearchCondition)Utility.Transaction.CurrentSearchConditions;

                hotelSearchCondition.Location = this.ddlCity.SelectedValue;
                hotelSearchCondition.LocationIndicator = LocationIndicator.City;
                hotelSearchCondition.CheckIn = Convert.ToDateTime(this.txtCheckin.CDate);
                hotelSearchCondition.CheckOut = Convert.ToDateTime(this.txtCheckout.CDate);
                hotelSearchCondition.Country = this.ddlCountry.SelectedValue;
                Utility.Transaction.IntKey = hotelSearchCondition.GetHashCode();
                Utility.Transaction.CurrentSearchConditions = hotelSearchCondition;

                this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Hotel/HotelSelectForm" + "&ConditionID=" + Utility.Transaction.IntKey.ToString());
            }
            else
            {
                PackageSearchCondition packageSearchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;

                HotelSearchCondition hotelSearchCondition = new HotelSearchCondition();
                hotelSearchCondition.RoomSearchConditions = packageSearchCondition.HotelSearchCondition.RoomSearchConditions;
                hotelSearchCondition.Location = this.ddlCity.SelectedValue;
                hotelSearchCondition.LocationIndicator = LocationIndicator.City;
                hotelSearchCondition.CheckIn = Convert.ToDateTime(this.txtCheckin.CDate);
                hotelSearchCondition.CheckOut = Convert.ToDateTime(this.txtCheckout.CDate);
                hotelSearchCondition.Country = this.ddlCountry.SelectedValue;
                packageSearchCondition.SetOptionalHotelSearchConditions(hotelSearchCondition);
                Utility.PackageBackFlag = "1";
                Utility.Transaction.IntKey = packageSearchCondition.GetHashCode();
                Utility.Transaction.CurrentSearchConditions = packageSearchCondition;
                if (packageSearchCondition.HotelSearchCondition2 != null)
                {
                    ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition2 = null;
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?Destination=2&target=~/Page/Package/PackageSearchResultForm" + "&ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?target=~/Page/Package/PackageSearchResultForm" + "&ConditionID=" + Utility.Transaction.IntKey.ToString());
            }

            
        }
        else
        {
            this.Response.Redirect("~/Index.aspx");
        }
    }

    private bool IsDateValid()
    {
        bool result = true;
        DateTime dateChinkIn_H = Convert.ToDateTime(this.txtCheckin.CDate);
        DateTime dateChinkOut_H = Convert.ToDateTime(this.txtCheckout.CDate);

        //if (dateChinkIn_H < DateTime.Today || dateChinkOut_H < DateTime.Today)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('We can only accept dates that occur after " + DateTime.Today.AddDays(1).ToString("MM/dd/yyyy") + " and 12/27/2008. Please enter a new date.');</script>");
        //    result = false;
        //}

        if (dateChinkIn_H < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Departure date is greater than the current date seven days.');</script>");
            result = false;
        }

        if (Convert.ToDateTime(dateChinkOut_H) < DateTime.Now.AddDays(7))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Return date is greater than the current date seven days.');</script>");
            result = false;
        }

        
        if (dateChinkIn_H <= DateTime.Today)    //用户输入的Check In不能小于今天
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The check-in date must occur after the today date. Please change the date.');</script>");
            result = false;
        }
        else if (dateChinkIn_H >= dateChinkOut_H)    //用户输入的Check In不能大于或等于Check out
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The check-out date must occur after the check-in date. Please change the date.');</script>");
            result = false;
        }

        //用户输入的Check In和Check out不能和已经订购的Hotel的日期冲突
        IList<HotelOrderItem> hotelOrderItems = new List<HotelOrderItem>();

        if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            IList<OrderItem> orderItems = Utility.Transaction.CurrentTransactionObject.Items;

            for (int i = 0; i < orderItems.Count; i++)
                if (orderItems[i] is HotelOrderItem)
                    hotelOrderItems.Add((HotelOrderItem)orderItems[i]);
        }
        else if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        {
            if (Utility.Transaction.CurrentTransactionObject.Items != null || Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
            {
                IList<Component> components = Utility.Transaction.CurrentTransactionObject.Items[0].Items;

                for (int i = 0; i < components.Count; i++)
                    if (components[i] is HotelOrderItem)
                        hotelOrderItems.Add((HotelOrderItem)components[i]);
            }
        }

        if (hotelOrderItems.Count > 0)
        {
            for (int orderItemIndex = 0; orderItemIndex < hotelOrderItems.Count; orderItemIndex++)
            {
                HotelOrderItem hotelOrderItem = hotelOrderItems[orderItemIndex];

                if ((hotelOrderItem.CheckIn <= dateChinkIn_H) && (dateChinkIn_H < hotelOrderItem.CheckOut))
                    result = false;
                else if ((hotelOrderItem.CheckIn < dateChinkOut_H) && (dateChinkOut_H <= hotelOrderItem.CheckOut))
                    result = false;
                else if ((hotelOrderItem.CheckIn > dateChinkIn_H) && (hotelOrderItem.CheckOut <= dateChinkOut_H))
                    result = false;

                if (!result)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('There is a conflict with the date your entered and the selected hotels. Please change the date.');</script>");
                    break;
                }
            }
        }

        //若订购Package产品，用户输入的Check In和Check out日期必须在Flight的Departure Date和Return Date之间
        if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        { 
            PackageSearchCondition currentSearchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;
            DateTime flightDepartDate = currentSearchCondition.AirSearchCondition.AirTripCondition[0].DepartureDate;
            DateTime flightReturnDate = currentSearchCondition.AirSearchCondition.AirTripCondition[currentSearchCondition.AirSearchCondition.AirTripCondition.Count -1].DepartureDate;

            if ((dateChinkIn_H < flightDepartDate || dateChinkIn_H >= flightReturnDate) || (dateChinkOut_H <= flightDepartDate || dateChinkOut_H > flightReturnDate))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", string.Format("<script language=javascript>alert('The check-date and check-out date need between {0} and {1}. Please change the date.');</script>",flightDepartDate.ToString("MM/dd/yyyy"),flightReturnDate.ToString("MM/dd/yyyy")));
                result = false;
            }
        }


        return result;
    }
}
