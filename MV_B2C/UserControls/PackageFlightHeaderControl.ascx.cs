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


using Terms.Sales.Dao;
using Terms.Product.Domain;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;

public partial class PackageFlightHeaderControl : Spring.Web.UI.UserControl
{
    private int flagCode;
    public int FlagCode
    {
        get
        {
            return flagCode;
        }
        set
        {
            flagCode = value;
        }
    }

   

    public void ReBind()
    {
        this.BindDate();
    }
    private int subindex;
    public int SubIndex
    {
        get 
        {
            return subindex;
        }
        set
        {
            switch (FlagCode)
            {
                case 1:
                    if (value == 0)
                    {
                        divLink.Visible = false;
                        divPrice.Visible = false;
                    }
                    else if (value == 1)
                    {
                        divLink.Visible = false;
                        divPrice.Visible = true;
                    }
                    else if (value == 2)
                    {
                        divLink.Visible = false;
                        divPrice.Visible = false;
                    }
                    break;
                case 2:
                    if (value == 0)
                    {
                        divLink.Visible = false;
                    }
                    break;

            }
        }
    }
    private decimal _TotalPrice = 0M;
    public decimal TotalPrice
    {
        set
        {
            _TotalPrice = value;
        }
        get
        {
            return _TotalPrice;
        }
    }
    public PackageFlightHeaderControl()
    {
        this.InitializeControls += new EventHandler(PackageFlightHeaderControl_InitializeControls);
    }

    public void PackageFlightHeaderControl_InitializeControls(object sender, EventArgs e)
    {
        try
        {
            
            if (!IsPostBack)
            {
                //BindDate();
            }
        }
        catch
        { 
        
        }
    }

    private void InitSetDisplay()
    {
        
    }

    public void BindDate()
    {
        PackageSearchCondition PackageSearch = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;
        this.lbAdults.Text = PackageSearch.AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult).ToString();
        this.lbChilds.Text = PackageSearch.AirSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child).ToString();
        this.lbRooms.Text = PackageSearch.HotelSearchCondition.RoomSearchConditions.Count.ToString();
        //this.lbDays.Text = ((TimeSpan)PackageSearch.AirSearchCondition.AirTripCondition[1].DepartureDate.Subtract(PackageSearch.AirSearchCondition.AirTripCondition[0].DepartureDate.AddDays(-1))).Days.ToString();
        //this.lbNights.Text = ((TimeSpan)PackageSearch.AirSearchCondition.AirTripCondition[1].DepartureDate.Subtract(PackageSearch.AirSearchCondition.AirTripCondition[0].DepartureDate)).Days.ToString();
        this.lbDepatrueCity.Text = ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[0]).Departure.City.Name;
        this.lbDestination.Text = ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[0]).Destination.City.Name;
        //this.lbl_CheckInDate.Text = PackageSearch.HotelSearchCondition.CheckIn.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        //this.lbl_CheckOutDate.Text = PackageSearch.HotelSearchCondition.CheckOut.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

        this.lbl_deptDate.Text = ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[0]).DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        this.lbl_rtnDate.Text = ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[1]).DepartureDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        

        if ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[1] != null)
        {
            //this.lbDestination2.Text = ",Form " + ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[1]).Departure.City.Name + " To " + ((AirTripCondition)PackageSearch.AirSearchCondition.GetAddTripCondition()[1]).Destination.City.Name;
        }

      
        this.lbTotalPrice.Text = Decimal.Round(TotalPrice, 0).ToString("n", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat);
       
    }


}
