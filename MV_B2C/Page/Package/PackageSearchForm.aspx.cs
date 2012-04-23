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

using Terms.Sales.Dao;
using Terms.Sales.Service;
using Terms.Sales.Domain;
using Terms.Sales.Utility;
using Terms.Common.Service;
using Terms.Common.Domain;
using Terms.Base.Domain;
using Terms.Base.Service;

using Terms.Material.Service;

using System.Collections.Generic;
using Terms.Sales.Business;
public partial class PackageSearchForm:SalseBasePage
{
    private ICommonService _commonService;
    public ICommonService CommonService
    {
        set
        {
            _commonService = value;
        }
    }

    private IBaseService _baseService;
    public IBaseService BaseService
    {
        set { _baseService = value; }
    }
    private AirService m_airService;

    public  AirService AirService
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

    public PackageSearchForm()
    {
        this.InitializeControls += new EventHandler(PackageSearchForm_InitializeControls);
    }

    void PackageSearchForm_InitializeControls(object sender, EventArgs e)
    {
        //this.dateDeparture.ArrDate = "'3/4/2008|3/6/2008', '3/14/2008|3/26/2008', '4/4/2008|4/6/2008', '4/14/2008|4/26/2008','6/14/2008|12/26/2008'".Split(',');
        //this.dateReturn.ArrDate = "'4/5/2008|4/7/2008', '4/15/2008|4/27/2008', '5/5/2008|5/7/2008', '6/15/2008|6/27/2008','7/14/2008|11/26/2008'".Split(',');
        try
        {
            if (!IsPostBack)
            {
                dateDeparture.IsCoercion = true;
                dateDeparture.CoercionID = "dateReturn";

                ClaendarUC3.IsCoercion = true;
                ClaendarUC3.CoercionID = "ClaendarUC4";


                if (this.Request["Country"] != null)
                {
                    if (!Utility.IsSearchConditionNull)
                    {
                        PackageSearchCondition PacakgeSearch = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;
                        //HotelSearchCondition hotelSearchCondition = new HotelSearchCondition();
                        PacakgeSearch.HotelSearchCondition.Location = this.Request["CityCode"];
                        PacakgeSearch.HotelSearchCondition.LocationIndicator = TERMS.Common.LocationIndicator.City;
                        PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.Request["CheckIn"]);
                        PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.Request["CheckOut"]);
                        PacakgeSearch.HotelSearchCondition.Country = this.Request["Country"];
                        Utility.Transaction.CurrentSearchConditions = PacakgeSearch;


                        //for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Count; i++)
                        //{
                        //    HotelMaterial temp = (HotelMaterial)Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList[i];

                        //    if (temp.Hotel.Id.ToString().Trim() == this.Request["HotelID"].Trim())
                        //    {
                        //        Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList.Remove(Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList[i]);
                        //    }
                        //}

                        this.Response.Redirect("~/Page/Common/Searching1.aspx?ChooseHotelID=" + this.Request["HotelID"] + "&target=PackageSearchResultForm");
                    }
                    else
                    {
                        this.Response.Redirect("PackageSearchForm.aspx");
                    }
                }
            }
        }
        catch
        {

        }
    }

    private void PackageSearchar()
    {
       

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       // Utility.SelectAirGroup = null;
       // PackageSearchCondition PacakgeSearch = new PackageSearchCondition();
       // IList departureAirPorts = _commonService.FindAirportByCityName(this.txtFrom.Text);
       // PacakgeSearch.DepatrueAirPorts = departureAirPorts;
       // IList ReturnAirPorts = _commonService.FindAirportByCityName(this.txtTo.Text);
       // PacakgeSearch.DestinationAirPorts = ReturnAirPorts;
       // PacakgeSearch.AirSearchCondition.SetPassengerNumber(Terms.Base.Utility.PassengerType.Adult, TravelerChange1.TotalAdults);
       // PacakgeSearch.AirSearchCondition.SetPassengerNumber(Terms.Base.Utility.PassengerType.Child, TravelerChange1.TotalChilds);

       // for (int i = 0; i < TravelerChange1.Rooms; i++)
       // {
       //     RoomSearchCondition roomSearchCondition = new RoomSearchCondition();

       //     roomSearchCondition.Passengers.Add(Terms.Base.Utility.PassengerType.Adult, TravelerChange1.Adults[i]);
       //     roomSearchCondition.Passengers.Add(Terms.Base.Utility.PassengerType.Child, TravelerChange1.Childs[i]);

       //     PacakgeSearch.HotelSearchCondition.RoomSearchConditions.Add(roomSearchCondition);
       // }
       ////判断城市机场
       // if (PacakgeSearch.DestinationAirPorts.Count > 0 || PacakgeSearch.DepatrueAirPorts.Count > 0)
       // {
       //     //如果城市机场多于一个跳转页面
       //     if (PacakgeSearch.DestinationAirPorts.Count > 1 || PacakgeSearch.DepatrueAirPorts.Count > 1)
       //     {
       //         PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateDeparture.CDate).AddDays(1);
       //         PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateReturn.CDate);
       //         PacakgeSearch.HotelSearchCondition.LocationIndicator = Terms.Base.Utility.LocationIndicator.City;
       //         PacakgeSearch.HotelSearchCondition.Country = this.txtTo.Text;

       //         this.Transaction.CurrentSearchConditions = PacakgeSearch;
       //         this.Page.Response.Redirect("PackageSearchMoreForm.aspx");
       //     }
       //     //如果城市只有一个
       //     else
       //     {
       //         PacakgeSearch.HotelSearchCondition.CheckIn = Convert.ToDateTime(this.dateDeparture.CDate).AddDays(1);
       //         PacakgeSearch.HotelSearchCondition.CheckOut = Convert.ToDateTime(this.dateReturn.CDate);
       //         PacakgeSearch.HotelSearchCondition.Location = ((CommCityMeta)_commonService.FindCitiesByName(this.txtTo.Text)[0]).Code;// "PVG";
       //         PacakgeSearch.HotelSearchCondition.LocationIndicator = Terms.Base.Utility.LocationIndicator.City;
       //         PacakgeSearch.HotelSearchCondition.Country = this.txtTo.Text;

       //         AirTripCondition DPTairTripCondition = new AirTripCondition();
       //         DPTairTripCondition.Departure = (CommAirportMeta)PacakgeSearch.DepatrueAirPorts[0];
       //         DPTairTripCondition.DepartureDate = Convert.ToDateTime(this.dateDeparture.CDate);
       //         DPTairTripCondition.Destination = (CommAirportMeta)PacakgeSearch.DestinationAirPorts[0];
       //         DPTairTripCondition.IsDepartureTimeSpecified = this.chbFlexible.Checked;
       //         PacakgeSearch.AirSearchCondition.AddTripCondition(DPTairTripCondition);
       //         //if (this.ddlAirline.SelectedIndex == -1)
       //         //{
       //         //    PacakgeSearch.AirSearchCondition.Airlines = new string[3] { "UA", "NW", "AA" };
       //         //}
       //         //else
       //         //{
       //             PacakgeSearch.AirSearchCondition.Airlines = new string[1] { "" };
       //         //}
       //         AirTripCondition RTNairTripCondition = new AirTripCondition();
       //         RTNairTripCondition.Departure = (CommAirportMeta)PacakgeSearch.DestinationAirPorts[0];
       //         RTNairTripCondition.DepartureDate = Convert.ToDateTime(this.dateReturn.CDate);
       //         RTNairTripCondition.Destination = (CommAirportMeta)PacakgeSearch.DepatrueAirPorts[0];
       //         RTNairTripCondition.IsDepartureTimeSpecified = this.chbFlexible.Checked;
       //         PacakgeSearch.AirSearchCondition.AddTripCondition(RTNairTripCondition);
       //         PacakgeSearch.AirSearchCondition.FlightType = "roundtrip";
       //         PacakgeSearch.AirSearchCondition.ProductType = Terms.Base.Utility.ProductType.Package;
       //         this.Transaction.CurrentSearchConditions = PacakgeSearch;

        //         this.Page.Response.Redirect("~/Page/Common/Searching1.aspx?target=PackageSearchResultForm");
       //     }
       // }
       // else
       // { 
            
       // }
        
    }
}
