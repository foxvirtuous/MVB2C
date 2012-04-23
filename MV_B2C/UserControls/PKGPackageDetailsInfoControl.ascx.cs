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
using System.Collections.Generic;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Common;
using TERMS.Business.Centers.ProductCenter.Profiles;
using Terms.Sales.Business;
using Terms.Sales.Service;
using Terms.Common.Service;

namespace Terms.Web.UserControls
{
    public partial class PKGPackageDetailsInfoControl : SalesBaseUserControl
    {
        private ICommonService _CommonService;
        public ICommonService CommonService
        {
            set
            {
                this._CommonService = value;
            }
        }
        private ISaleMerchandiseSearcherService _SaleMerchandiseSearcherService;
        public ISaleMerchandiseSearcherService SaleMerchandiseSearcherService
        {
            set { _SaleMerchandiseSearcherService = value; }
        }

        private bool rePageNumber = false;

        private PackageMerchandise _packageMerchandise;
        public PackageMerchandise PgMerchandise
        {
            set
            {
                _packageMerchandise = value;
            }
            get
            {
                return _packageMerchandise;
            }
        }

        private int _HotelListIndex = 0;
        public int HotelListIndex
        {
            get
            {
                return _HotelListIndex;
            }
            set
            {
                _HotelListIndex = value;
            }
        }

        private List<PackageMaterial> _packageDetails;
        public List<PackageMaterial> PackageDetails
        {


            set
            {
                if (value is List<PackageMaterial>)
                {
                    _packageDetails = value;
                   

                }
            }
            get
            {
                if (_packageDetails == null)
                {
                    _packageDetails = new List<PackageMaterial>();
                }

                return _packageDetails;
            }
        }

        private List<AirMaterial> _FlightDetails;

        public List<AirMaterial> FlightDetails
        {
            set
            {
                //if (value is List<AirMaterial>)
                //{
                //    this.dlPackages.DataSource = value[0];

                //    dlAirGroup.DataBind();                   
                //}
                _FlightDetails = value;
            }
            get
            {
                if (_FlightDetails == null)
                {
                    List<AirMaterial> newlist = new List<AirMaterial>();
                    newlist.Add(new AirMaterial(new TERMS.Core.Profiles.Profile("")));
                    _FlightDetails = newlist;
                }

                return _FlightDetails;
            }
        }

        private const int PAGE_SIZE = 10;

        private void BindDataList(int index)
        {
            PagedDataSource pds = new PagedDataSource();

            pds.DataSource = PgMerchandise.GetPackageMaterials(1 + HotelListIndex);
            pds.PageSize = PAGE_SIZE;
            PageNumber1.PageSize = PAGE_SIZE;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = index >= 0 ? index : 0;
            PageNumber1.CurrentPageIndex = pds.CurrentPageIndex;
            PageNumber1.PageAmount = pds.PageCount;
           // PageNumber1.ItemAmount = pds.DataSourceCount;
            if (pds.DataSourceCount < PAGE_SIZE + 1)
            {
                PageNumber1.Visible = false;
            }
            else
            {
                PageNumber1.Visible = true;
            }

            this.dlPackages.DataSource = pds;
            this.dlPackages.DataBind();
        }

        private void BindDataList(int index,List<PackageMaterial> packageDetails)
        {
            PagedDataSource pds = new PagedDataSource();

            pds.DataSource = packageDetails;
            pds.PageSize = PAGE_SIZE;
            PageNumber1.PageSize = PAGE_SIZE;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = index >= 0 ? index : 0;
            PageNumber1.CurrentPageIndex = pds.CurrentPageIndex;
            PageNumber1.PageAmount = pds.PageCount;
            // PageNumber1.ItemAmount = pds.DataSourceCount;
            if (pds.DataSourceCount < PAGE_SIZE + 1)
            {
                PageNumber1.Visible = false;
            }
            else
            {
                PageNumber1.Visible = true;
            }


            this.dlPackages.DataSource = pds;
            this.dlPackages.DataBind();
        }

        public PKGPackageDetailsInfoControl()
        {
            this.PreRender += new EventHandler(PKGPackageDetailsInfoControl_PreRender);     
        }

        void PKGPackageDetailsInfoControl_PreRender(object sender, EventArgs e)
        {
            if (!rePageNumber)
            {
                FilterHotel();
                BindDataList(PageNumber1.CurrentPageIndex);
                PageNumber1.DrawingNum(PageNumber1.CurrentPageIndex + 1);
            }
            else
            {
                FilterHotel();
                BindDataList(0);
                this.PageNumber1.RefreshDll();
                
            }
        }

        private void FilterHotel()
        {
            List<MVHotel> currentList = new List<MVHotel>();

            if (this.ddlCountry.SelectedIndex > 0 && this.ddlCity.SelectedIndex > 0)
            {
                string strCityCode = this.ddlCity.SelectedValue;

                for (int i = 0; i < ((HotelMerchandise)PgMerchandise.Items[1 + HotelListIndex]).Items.Count; i++)
                {
                    if (((MVHotel)((HotelMerchandise)PgMerchandise.Items[1 + HotelListIndex]).Items[i]).HotelInformation.City.Code.Trim() == strCityCode.Trim())
                    {
                        currentList.Add((MVHotel)((HotelMerchandise)PgMerchandise.Items[1 + HotelListIndex]).Items[i]);
                    }
                }
            }
            else
            {
                foreach (MVHotel mvHotel in ((HotelMerchandise)PgMerchandise.Items[1 + HotelListIndex]).Items)
                {
                    currentList.Add(mvHotel);
                }
            }

            if (currentList.Count > 0)
            {
                ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Clear();
                foreach (MVHotel mvHotel in currentList)
                {
                    ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Add(mvHotel);
                }
                currentList = new List<MVHotel>();
            }
            if (this.ddlStar.SelectedIndex > 0)
            {
                string strStar = this.ddlStar.SelectedValue;

                for (int i = 0; i < ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Count; i++)
                {
                    if (Convert.ToDouble(((MVHotel)((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items[i]).HotelInformation.Class) == Convert.ToDouble(strStar))
                    {
                        currentList.Add((MVHotel)((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items[i]);
                    }
                }
            }
            else
            {
                foreach (MVHotel mvHotel in ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items)
                {
                    currentList.Add(mvHotel);
                }
            }

            if (currentList.Count > 0)
            {
                ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Clear();
                foreach (MVHotel mvHotel in currentList)
                {
                    ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Add(mvHotel);
                }
                currentList = new List<MVHotel>();
            }

            if (this.txtContains.Text.Trim().Length > 0)
            {
                string strContains = txtContains.Text.Trim();

                for (int i = 0; i < ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Count; i++)
                {
                    if (((MVHotel)((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items[i]).HotelInformation.Name.ToLower().Contains(strContains.ToLower()))
                    {
                        currentList.Add((MVHotel)((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items[i]);
                    }
                }
            }
            else
            {
                foreach (MVHotel mvHotel in ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items)
                {
                    currentList.Add(mvHotel);
                }
            }

            if (currentList.Count == 0)
            {
                currentList = new List<MVHotel>();
            }
            ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Clear();
            foreach (MVHotel mvHotel in currentList)
            {
                ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items.Add(mvHotel);
            }

            if (RadioButtonList1.SelectedIndex == 0)
            {
                MagesticPicksSort(((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).Items);
            }
            if (RadioButtonList1.SelectedIndex == 1)
            {
                ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).SortByPrice();
            }
            if (RadioButtonList1.SelectedIndex == 2)
            {
                ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).SortByHotelName();
            }
            if (RadioButtonList1.SelectedIndex == 3)
            {
                ((HotelMerchandise)PgMerchandise.CurrentItems[1 + HotelListIndex]).SortByRating();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.Country));
                ddlCountry_SelectedIndexChanged(null, new EventArgs());
                this.ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByValue(((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.Location));
                BindDataList(0);
            }
        }

        protected void dlPackages_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PackageMaterial pm = (PackageMaterial)e.Item.DataItem;
                MVHotel pHotel = (MVHotel)pm.Hotels[HotelListIndex];
                System.Web.UI.WebControls.Image image1 = (System.Web.UI.WebControls.Image)e.Item.FindControl("AirImgRtn1");
                image1.ImageUrl = "~/images/airline/defult_air.jpg";
                string airImgName = ((AirProfile)FlightDetails[0].Profile).Airlines[0].Code.Trim().ToString() + ".gif";
                if (System.IO.File.Exists(Request.PhysicalApplicationPath + @"images\airline\" + airImgName))
                {
                    image1.ImageUrl = "~/images/airline/" + airImgName;
                }

                Label lblAirLine = (Label)e.Item.FindControl("lblAirLine");
                lblAirLine.Text = FlightDetails[0].Airline.Name;

                DataList dlFlights = (DataList)e.Item.FindControl("dlFlights");
                dlFlights.DataSource = FlightDetails;
                dlFlights.DataBind();
                DataList dlFlight = (DataList)e.Item.FindControl("dlFlight");
                dlFlight.DataSource = GetAirLegList(FlightDetails[0]);
                dlFlight.DataBind();
                //Label lblDisplayFlight = (Label)e.Item.FindControl("lblDisplayFlight");
                //List<AirLeg> AirLegs = (List<AirLeg>)GetAirLegList(FlightDetails[0]);
                //for (int i = 0; i < AirLegs.Count; i++)
                //{
                //    lblDisplayFlight.Text += "<table border='0' cellspacing='1' cellpadding='3' width='100%' class='IBE_T_step03'>";
                //    lblDisplayFlight.Text += "<tr align='left' class='IBE_R_stepw'>";
                //    lblDisplayFlight.Text += "<td width='25%'><b>";
                //    lblDisplayFlight.Text += AirLegs[i].AirLine.Code + "&nbsp;" ;
                //    lblDisplayFlight.Text += AirLegs[i].FlightNumber + "&nbsp; </b></td>";
                //    lblDisplayFlight.Text += "<td width='25%'>";
                //    lblDisplayFlight.Text += AirLegs[i].DepartureTime.ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "<br />";
                //    lblDisplayFlight.Text += AirLegs[i].DepartureAirport.City.Name ;
                //    lblDisplayFlight.Text += "(" + AirLegs[i].DepartureAirport.Code + ")<br /></td>";
                //    lblDisplayFlight.Text += "<td width='25%'>";
                //    lblDisplayFlight.Text += AirLegs[i].ArriveTime.ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "<br />";
                //    lblDisplayFlight.Text += AirLegs[i].DestinationAirport.City.Name;
                //    lblDisplayFlight.Text += "(" + AirLegs[i].DestinationAirport.Code + ")<br /></td>";
                //    lblDisplayFlight.Text += "<td width='10%' align='center'>";
                //    lblDisplayFlight.Text += AirLegs[i].NumberOfStops + "</td>";
                //    lblDisplayFlight.Text += "<td width='15%' align='center'>";
                //    lblDisplayFlight.Text += GetFlightTime(AirLegs[i]) + "</td>";
                //    lblDisplayFlight.Text += "</tr></table>";
                //}


                string List = string.Empty;
                Label lblHotelName = (Label)e.Item.FindControl("lblHotelName");
                System.Web.UI.WebControls.Image imgHotel = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgHotel");
                Label lblAddress = (Label)e.Item.FindControl("lblAddress");
                Label lblLocation = (Label)e.Item.FindControl("lblLocation");
                System.Web.UI.WebControls.Image imgMapUrl = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgMapUrl");
                Label lblList = (Label)e.Item.FindControl("lblList");
                Repeater GridView1 = (Repeater)e.Item.FindControl("GridView1");
                //add 2010-5-4
                Label lblHotelSTATUS = (Label)e.Item.FindControl("lblHotelSTATUS");
                Label lblsymbol = (Label)e.Item.FindControl("lblsymbol");

                lblHotelName.Text = pHotel.HotelInformation.Name;

                if (pHotel.Profile.GetParam("STATUS") != null)
                {
                    lblsymbol.Visible = true;
                    if (pHotel.Profile.GetParam("STATUS").ToString() == "IM")
                    {
                        lblHotelSTATUS.Text = "AVAILABLE";
                    }
                    else
                    {
                        lblHotelSTATUS.Text = "On Request";
                    }
                }
                else
                {
                    lblsymbol.Visible = false;
                    lblHotelSTATUS.Visible = false;
                }

                if (pHotel.HotelInformation.GetImage("FRONT") != null && pHotel.HotelInformation.GetImage("FRONT").Filename != null)
                    imgHotel.ImageUrl = pHotel.HotelInformation.GetImage("FRONT").Filename.Trim();
                else
                    imgHotel.ImageUrl = "~/images/v1/defaulth.gif";

                lblAddress.Text = pHotel.HotelInformation.Address;
                lblLocation.Text = pHotel.HotelInformation.Description;
                if (string.IsNullOrEmpty(pHotel.HotelInformation.MapUrl))
                {
                    imgMapUrl.Visible = false;
                }
                else
                {
                    imgMapUrl.Visible = true;
                    imgMapUrl.ImageUrl = pHotel.HotelInformation.MapUrl;
                }

                for (int i = 0; i < pHotel.HotelInformation.Features.Count; i++)
                {
                    List += "<li>" + pHotel.HotelInformation.Features[i] + "</li>";
                }

                lblList.Text = List;

                List<TERMS.Common.Image> images = (List<TERMS.Common.Image>)pHotel.HotelInformation.Images;

                for (int j = images.Count - 1; j >= 0; j--)
                {
                    if (images[j].Filename == null || images[j].Filename.Trim().Length <= 0)
                    {
                        images.Remove(images[j]);
                    }
                }

                GridView1.DataSource = images;
                GridView1.DataBind();

                SetTotalDurationAndDistance(FlightDetails[0], e.Item);
                AirMaterial flight = FlightDetails[0];
                if (flight.AirTrip.HasOverNightFlight)
                {
                    System.Web.UI.WebControls.Image imgOverNight = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgOverNight");
                    imgOverNight.Visible = true;
                }

                if (flight.AirTrip.CodeShared)
                {
                    System.Web.UI.WebControls.Image imgCodeShared = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgCodeShared");
                    imgCodeShared.Visible = true;
                }
            }
        }

        private void SetTotalDurationAndDistance(AirMaterial flight, DataListItem dataListItem)
        {
            System.Web.UI.WebControls.Label lblTotalDistance = (System.Web.UI.WebControls.Label)dataListItem.FindControl("lblTotalDistance");
            lblTotalDistance.Text = GetDistance(flight);

            System.Web.UI.WebControls.Label lblTotalDuration = (System.Web.UI.WebControls.Label)dataListItem.FindControl("lblTotalDuration");
            lblTotalDuration.Text = GetDuration(flight);

            System.Web.UI.WebControls.Label lblTotalDistanceMsg = (System.Web.UI.WebControls.Label)dataListItem.FindControl("lblTotalDistanceMsg");
            if (lblTotalDuration.Text.Trim() == string.Empty)
            {
                lblTotalDistanceMsg.Visible = false;
            }
        }

        private string GetDuration(AirMaterial flight)
        {
            string duration = string.Empty;
            TimeSpan flightTime = TimeSpan.Zero;
            TimeSpan connectionTime = TimeSpan.Zero;

            AirLineMatricsManager airManager = new AirLineMatricsManager();

            flightTime = airManager.GetFlightTime(flight);
            connectionTime = airManager.GetDuration(flight);

            return String.Format("{0} ({1}", airManager.FormatTimeSpan(flightTime), airManager.FormatTimeSpan(connectionTime));
        }

        private string GetDuration(AirLeg airLeg)
        {
            string duration;

            AirLineMatricsManager airManager = new AirLineMatricsManager();

            return airManager.FormatTimeSpan(airManager.GetDuration(airLeg));
        }

        private string GetFlightTime(AirLeg airLeg)
        {
            string duration;

            AirLineMatricsManager airManager = new AirLineMatricsManager();

            return airManager.FormatTimeSpan(airManager.GetFlightTime(airLeg));
        }

        private string GetDistance(AirMaterial flight)
        {
            int miles = 0;

            foreach (SubAirTrip subAirTrip in flight.AirTrip.SubTrips)
            {
                miles += subAirTrip.Miles;
            }

            if (miles == 0)
            {
                return string.Empty;
            }

            return String.Format("{0} miles ({1} km)", miles.ToString("#,###"), ConvertMilesToKilometers(miles).ToString("#,####"));
        }

        public int ConvertMilesToKilometers(int m)
        {
            return ((int)(m * 1.609344));
        }

        private object GetAirLegList(AirMaterial flight)
        {
            IList<AirLeg> airLegList = new List<AirLeg>();

            foreach (SubAirTrip subAirTrip in flight.AirTrip.SubTrips)
            {
                foreach (AirLeg airLeg in subAirTrip.Flights)
                {
                    airLegList.Add(airLeg);
                }
            }

            return airLegList;
        }

        protected void dlPackages_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "SELECT")
            {
                Session["HotelID"] = e.Item.FindControl("lblHotelID");
                ((List<int>)this.PgMerchandise.DefaultIndex[1 + HotelListIndex])[0] = (PageNumber1.CurrentPageIndex * PAGE_SIZE) + e.Item.ItemIndex;
                string TableName = "";
                if (e.CommandName.Trim().ToUpper() == "CHOOSE".Trim().ToUpper())
                    TableName = "&TableName=Features";
                ////记录选择了Package事件
                //if (Utility.IsSubAgent)
                //    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SelectPackage, this);
                //else
                //    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SelectPackage, this);

                this.Response.Redirect("SelectRoomRates.aspx?HotelIndex=" + HotelListIndex.ToString() + TableName + "&ConditionID=" + Request.Params["ConditionID"]);
            }
            if (e.CommandName.ToUpper() == "CHANGE")
            {
                ((List<int>)this.PgMerchandise.DefaultIndex[1 + HotelListIndex])[0] = (PageNumber1.CurrentPageIndex * PAGE_SIZE) + e.Item.ItemIndex;
                string hotelID = ((Label)e.Item.FindControl("lblHotelID")).Text;
                if (((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition2 != null)
                {
                    Response.Redirect("~/Page/Package2/ChangeFlightsInformation.aspx?URL=ViewYourPackages.aspx" + "&Condition=2" + "&ConditionID=" + Request.Params["ConditionID"]);
                }
                else
                {
                    Response.Redirect("~/Page/Package2/ChangeFlightsInformation.aspx?URL=ViewYourPackages.aspx" + "&ConditionID=" + Request.Params["ConditionID"]);
                }

            }
        }

        protected void dlSubTrips_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            System.Web.UI.WebControls.Label lblStops = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblStops");
            SubAirTrip subAirTrip = (SubAirTrip)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));

            AirLineMatricsManager airlineMatricsManager = new AirLineMatricsManager();
            lblStops.Text = airlineMatricsManager.GetStopsInsideFlight(subAirTrip).ToString();

            //Duration
            Label lblDuration = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblDuration");
            lblDuration.Text = airlineMatricsManager.FormatTimeSpan(airlineMatricsManager.GetDuration(subAirTrip));
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   FilterHotel();
            rePageNumber = true;
         //   BindDataList(0);
        }

        private void MagesticPicksSort(List<TERMS.Business.Centers.SalesCenter.Hotel> pMVHotel)
        {
            List<MVHotel> hotelOther = new List<MVHotel>();

            for (int i = 0; i < pMVHotel.Count; i++)
            {
                hotelOther.Add((MVHotel)pMVHotel[i]);
            }


            hotelOther.Sort(delegate(MVHotel r1, MVHotel r2) { return r1.RoomPricePerNight.CompareTo(r2.RoomPricePerNight); });

            pMVHotel.Clear();


            for (int i = 0; i < hotelOther.Count; i++)
            {
                if (hotelOther[i].IsRecommended)
                {
                    pMVHotel.Add(hotelOther[i]);
                }
            }

            for (int i = 0; i < hotelOther.Count; i++)
            {
                if (!hotelOther[i].IsRecommended)
                {
                    pMVHotel.Add(hotelOther[i]);
                }
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.Items.Clear();
            ddlCity.DataBind();

            if (ddlCountry.SelectedIndex > 0)
            {
                IList ilist = _CommonService.FindCitiesByCountryCode(ddlCountry.SelectedValue);

                ddlCity.DataSource = ilist;
                ddlCity.DataTextField = "Name";
                ddlCity.DataValueField = "Code";
                ddlCity.DataBind();
            }

            ListItem item = new ListItem("--Select--", string.Empty);

            ddlCity.Items.Insert(0, item);
        }

        private void BindCountry()
        {
            IList ilist = _CommonService.FindCountryAll();

            ddlCountry.DataSource = ilist;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "Code";
            ddlCountry.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);

            ddlCountry.Items.Insert(0, item);

            ddlCountry_SelectedIndexChanged(null, new EventArgs());
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //List<PackageMaterial> hotelMaterialNew = new List<PackageMaterial>();
            rePageNumber = true;
            FilterHotel();
            BindDataList(0);
        }

        protected void dlFlight_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Label)e.Item.FindControl("lblFlightDuration")).Text = GetFlightTime((AirLeg)(e.Item.DataItem));

                AirLeg airleg = (AirLeg)e.Item.DataItem;

                if (!string.IsNullOrEmpty(airleg.OperatingAirlineInfo))
                {
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = true;
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Text = "Operated by: " + airleg.OperatingAirlineInfo;

                    //if (flightInfohider.IsNeedToHide(airCode, fareType))
                    //{
                    //    ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = false;

                    //    System.Web.UI.WebControls.Image imgCodeShared = (System.Web.UI.WebControls.Image)e.Item.Parent.Parent.FindControl("imgCodeShared");

                    //    imgCodeShared.Visible = false;
                    //}
                }
                else
                {
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = false;
                }

            }
        }

    }
}