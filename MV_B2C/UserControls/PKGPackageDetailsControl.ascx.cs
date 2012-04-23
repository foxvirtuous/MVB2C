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
using Terms.Sales.Business;
using System.Collections.Generic;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Common;


namespace Terms.Web.UserControls
{
    public partial class PKGPackageDetailsControl : SalesBaseUserControl
    {
        private PackageMaterial _packageDetails;
        public PackageMaterial PackageDetails
        {
            set
            {
                if (value is PackageMaterial)
                {
                    if (!IsPostBack)
                    {
                        if (((PackageMaterial)value).Hotels != null && ((MVHotel)((System.Collections.Generic.List<TERMS.Business.Centers.SalesCenter.Hotel>)((PackageMaterial)value).Hotels[0])[0]).Profile.GetParam("DATASOURCE").ToString().Trim().ToUpper() == "GTA")
                        {
                            Terms.Sales.Business.CancellationPolicy Policy = new CancellationPolicy();

                            Policy.GetIsNoHotelCancellation((MVHotel)((System.Collections.Generic.List<TERMS.Business.Centers.SalesCenter.Hotel>)((PackageMaterial)value).Hotels[0])[0]);
                        }

                        dlHotelDetails.DataSource = ((PackageMaterial)value).Hotels;
                        dlHotelDetails.DataBind();
                    }

                }
            }
            get
            {
                if (_packageDetails == null)
                {
                    _packageDetails = new PackageMaterial(new TERMS.Business.Centers.ProductCenter.Profiles.PackageProfile("Package"));
                }

                return _packageDetails;
            }
        }

        private PackageMerchandise _pgMerchandise;
        public PackageMerchandise pgMerchandise
        {
            get
            {
                return _pgMerchandise;
            }
            set
            {
                _pgMerchandise = value;
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

        private List<AirMaterial> _FlightDetails;

        public List<AirMaterial> FlightDetails
        {
            set
            {
                _FlightDetails = value;
                foreach (DataListItem item in this.dlHotelDetails.Items)
                {
                    DataList dlFlight = (DataList)item.FindControl("dlFlight");
                    dlFlight.DataSource = GetAirLegList(value[0]); ;
                    dlFlight.DataBind();
                }
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


        private MVHotel m_HotelMaterial;
        //public MVHotel HotelMaterial
        //{
        //    set
        //    {

        //        dlHotel.DataSource = value.Items;

        //        dlHotel.DataBind();



        //        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
        //        {
        //            lblCheckIn.Text = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        //            lblCheckOut.Text = ((Terms.Sales.Business.HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        //        }
        //        else
        //        {
        //            lblCheckIn.Text = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckIn.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        //            lblCheckOut.Text = ((Terms.Sales.Business.PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition.CheckOut.Date.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        //        }

        //        for (int i = 0; i < dlHotel.Items.Count; i++)
        //        {
        //            DataList dl = (DataList)dlHotel.Items[i].FindControl("dlRoom");

        //            decimal decBasicOfPriceRoom = 0M;

        //            decimal decRoomPrice = 0M;

        //            for (int j = 0; j < dl.Items.Count; j++)
        //            {
        //                //选中默认房型
        //                DataListItem item = dl.Items[j];
        //                RadioButton rbtn = (RadioButton)item.FindControl("rabRoomType");
        //                Label lbl = (Label)item.FindControl("lblCode");
        //                HtmlTable tab = (HtmlTable)item.FindControl("cell");


        //                if (lbl.Text.Trim().ToUpper() == value.Items[i].DefaultRoomType.Room.Code.Trim().ToUpper())
        //                {
        //                    rbtn.Checked = true;
        //                    tab.BgColor = "#fdf1c1";
        //                }
        //                else
        //                {
        //                    rbtn.Checked = false;
        //                    tab.BgColor = "";
        //                }

        //                //添加单选房型的事件
        //                rbtn.Attributes["onclick"] = "javascript:CancelSelect(this,'PKGPackageDetailsControl1$dlHotel$ctl0" + i.ToString() + "$dlRoom$ctl0" + j.ToString() + "','PKGPackageDetailsControl1_dlHotel_ctl0" + i.ToString() + "_dlRoom_ctl0" + j.ToString() + "_cell');";


        //                lbl = (Label)item.FindControl("lblPireType");

        //                if (j == 0)
        //                {
        //                    lbl.Visible = true;

        //                    decBasicOfPriceRoom = value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetAmount(TERMS.Common.PassengerType.Adult);

        //                    decRoomPrice = decBasicOfPriceRoom + value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetMarkup(TERMS.Common.PassengerType.Adult);

        //                    //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
        //                    //{
        //                    //Hotel产品显示每个房间的单价
        //                    lbl.Text = "$" + decRoomPrice.ToString("N2");
        //                    //}
        //                    //else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
        //                    //{
        //                    //    //Package产品不显示每个房间的单价
        //                    //    lbl.Text = "";
        //                    //}
        //                }
        //                else
        //                {
        //                    decimal temp = value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetAmount(TERMS.Common.PassengerType.Adult);

        //                    temp += value.Items[i].Items[j].GetAvgPerNightPrice(value.Profile.CheckInDate, value.Profile.CheckOutDate).GetMarkup(TERMS.Common.PassengerType.Adult);

        //                    //temp = temp - decRoomPrice;

        //                    if (temp >= 0)
        //                    {
        //                        lbl.Text = "$" + temp.ToString("N2");
        //                    }
        //                    else
        //                    {
        //                        lbl.Text = temp.ToString("N2");
        //                    }

        //                    lbl.Visible = true;

        //                }
        //            }
        //        }

        //        string temp1 = string.Empty;

        //        if (value.HotelInformation.GetImage("FRONT") != null && value.HotelInformation.GetImage("FRONT").Filename != null)
        //        {
        //            imgHotel.ImageUrl = value.HotelInformation.GetImage("FRONT").Filename.Trim();
        //            imgHotelIMG.ImageUrl = value.HotelInformation.GetImage("FRONT").Filename.Trim();
        //        }
        //        else
        //        {
        //            imgHotel.ImageUrl = "~/images/v1/defaulth.gif";
        //            imgHotelIMG.ImageUrl = "~/images/v1/defaulth.gif";
        //        }
        //        if (value.HotelInformation.Class != null && value.HotelInformation.Class.ToString() != "")
        //            imgClass.Src = "~/images/star" + value.HotelInformation.Class.ToString().Trim() + ".gif";
        //        lblHotelName.Text = value.HotelInformation.Name;
        //        lbHotelName.Text = value.HotelInformation.Name;
        //        lblHotelID.Text = value.HotelInformation.HotelCode;
        //        lblAdd.Text = value.HotelInformation.Address;
        //        lblAddress.Text = value.HotelInformation.Address;
        //        lblLocation.Text = value.HotelInformation.Description;
        //        if (string.IsNullOrEmpty(value.HotelInformation.MapUrl))
        //        {
        //            imgMapUrl.Visible = false;
        //        }
        //        else
        //        {
        //            imgMapUrl.Visible = true;
        //            imgMapUrl.ImageUrl = value.HotelInformation.MapUrl;
        //        }

        //        for (int i = 0; i < value.HotelInformation.Features.Count; i++)
        //        {
        //            temp1 += "<li>" + value.HotelInformation.Features[i] + "</li>";
        //        }


        //        lblList.Text = temp1;

        //        List<TERMS.Common.Image> images = (List<TERMS.Common.Image>)value.HotelInformation.Images;

        //        for (int i = images.Count - 1; i >= 0; i--)
        //        {
        //            if (images[i].Filename == null || images[i].Filename.Trim().Length <= 0)
        //            {
        //                images.Remove(images[i]);
        //            }
        //        }

        //        GridView1.DataSource = images;
        //        ViewState["ImageList"] = images;
        //        GridView1.DataBind();
        //    }
        //    get
        //    {
        //        return m_HotelMaterial;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
     
            }
   
        }

        public void BindHotels()
        {
            PackageDetails = pgMerchandise.GetDefaultPackageMaterial();
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

        protected void dlFlight_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Label)e.Item.FindControl("lblFlightDuration")).Text = GetFlightTime((AirLeg)(e.Item.DataItem));
                AirLeg airLeg = (AirLeg)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
                if (!string.IsNullOrEmpty(airLeg.OperatingAirlineInfo))
                {
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = true;
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Text = "Operated by: " + airLeg.OperatingAirlineInfo;

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


        public void SetRoomType()
        {
            string hotelid = this.Request["HotelID"];
            string hotelName = this.Request["HotelName"];
            string strCheckin = this.Request["CheckIn"];

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {

                PackageMerchandise m_SaleMerchandise = (PackageMerchandise)this.OnSearch();
                for (int k = 0; k < ((List<TERMS.Business.Centers.SalesCenter.Hotel>)m_SaleMerchandise.DefaultMerchandise[HotelListIndex + 1]).Count; k++)
                {
                    MVHotel mvHotel = (MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)m_SaleMerchandise.DefaultMerchandise[HotelListIndex + 1])[k];
                    for (int roomIndex = 0; roomIndex < mvHotel.Items.Count; roomIndex++)
                    {
                        MVRoom mvRoom = (MVRoom)mvHotel.Items[roomIndex];
                        DataList dlRooms = (DataList)((DataList)dlHotelDetails.Items[k].FindControl("dlHotel")).Items[roomIndex].FindControl("dlRoom");

                        for (int indexroomscount = 0; indexroomscount < dlRooms.Items.Count; indexroomscount++)
                        {
                            RadioButton rb = (RadioButton)dlRooms.Items[indexroomscount].FindControl("rabRoomType");

                            if (rb.Checked)
                            {
                                Label lbltemp = (Label)dlRooms.Items[indexroomscount].FindControl("lblCode");
                                Label lblRoomID = (Label)dlRooms.Items[indexroomscount].FindControl("lblRoomID");
                                
                                for (int iRomms = 0; iRomms < mvRoom.Items.Count; iRomms++)
                                {
                                    mvRoom.Items[iRomms].Selected = false;

                                    if (lblRoomID.Text.Trim().Length > 0)
                                    {
                                        if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                                        {
                                            if (mvRoom.Items[iRomms].Profile.GetParam("CATEGORYID") != null && mvRoom.Items[iRomms].Profile.GetParam("CATEGORYID").ToString().Trim() == lblRoomID.Text.Trim())
                                            {
                                                mvRoom.Items[iRomms].Selected = true;
                                                mvRoom.SetDefaultRoomType(iRomms);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                                        {
                                            mvRoom.Items[iRomms].Selected = true;
                                            mvRoom.SetDefaultRoomType(iRomms);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        protected void dlHotelDetails_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MVHotel Hotel = (MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)e.Item.DataItem)[0];
                DataList dlHotel = (DataList)e.Item.FindControl("dlHotel");
                dlHotel.DataSource = Hotel.Items;
                dlHotel.DataBind();
                //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                //{

                //    PackageMerchandise m_SaleMerchandise = (PackageMerchandise)this.OnSearch();
                //    for (int k = 0; k < ((List<TERMS.Business.Centers.SalesCenter.Hotel>)m_SaleMerchandise.DefaultMerchandise[HotelListIndex + 1]).Count; k++)
                //    {
                //        MVHotel mvHotel = (MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)m_SaleMerchandise.DefaultMerchandise[HotelListIndex + 1])[k];
                //        for (int roomIndex = 0; roomIndex < mvHotel.Items.Count; roomIndex++)
                //        {
                //            MVRoom mvRoom = (MVRoom)mvHotel.Items[roomIndex];
                //            DataList dlRooms = (DataList)dlHotel.Items[roomIndex].FindControl("dlRoom");

                //            for (int indexroomscount = 0; indexroomscount < dlRooms.Items.Count; indexroomscount++)
                //            {
                //                RadioButton rb = (RadioButton)dlRooms.Items[indexroomscount].FindControl("rabRoomType");

                //                if (rb.Checked)
                //                {
                //                    Label lbltemp = (Label)dlRooms.Items[indexroomscount].FindControl("lblCode");

                //                    for (int iRomms = 0; iRomms < mvRoom.Items.Count; iRomms++)
                //                    {
                //                        mvRoom.Items[iRomms].Selected = false;
                //                        if (mvRoom.Items[iRomms].Room.Code == lbltemp.Text.Trim())
                //                        {
                //                            mvRoom.Items[iRomms].Selected = true;
                //                            mvRoom.SetDefaultRoomType(iRomms);
                //                        }
                //                    }
                //                }
                //            }

                //        }
                //    }

                //}
                string temp1 = string.Empty;
                System.Web.UI.WebControls.Image imgHotel = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgHotel");
                System.Web.UI.WebControls.Image imgHotelIMG = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgHotelIMG");
                System.Web.UI.WebControls.Image imgMapUrl = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgMapUrl");
                HtmlImage imgClass = (HtmlImage)e.Item.FindControl("imgClass");
                Label lblHotelName = (Label)e.Item.FindControl("lblHotelName");
                Label lbHotelName = (Label)e.Item.FindControl("lbHotelName");
                Label lblHotelID = (Label)e.Item.FindControl("lblHotelID");
                Label lblAdd = (Label)e.Item.FindControl("lblAdd");
                Label lblAddress = (Label)e.Item.FindControl("lblAddress");
                Label lblLocation = (Label)e.Item.FindControl("lblLocation");
                Label lblList = (Label)e.Item.FindControl("lblList");
                Repeater GridView1 = (Repeater)e.Item.FindControl("GridView1");
                if (Hotel.HotelInformation.GetImage("FRONT") != null && Hotel.HotelInformation.GetImage("FRONT").Filename != null)
                {
                    imgHotel.ImageUrl = Hotel.HotelInformation.GetImage("FRONT").Filename.Trim();
                    imgHotelIMG.ImageUrl = Hotel.HotelInformation.GetImage("FRONT").Filename.Trim();
                }
                else
                {
                    imgHotel.ImageUrl = "~/images/v1/defaulth.gif";
                    imgHotelIMG.ImageUrl = "~/images/v1/defaulth.gif";
                }
                if (Hotel.HotelInformation.Class != null && Hotel.HotelInformation.Class.ToString() != "")
                    imgClass.Src = "~/images/star" + Hotel.HotelInformation.Class.ToString().Trim() + ".gif";
                lblHotelName.Text = Hotel.HotelInformation.Name;
                lbHotelName.Text = Hotel.HotelInformation.Name;
                lblHotelID.Text = Hotel.HotelInformation.HotelCode;
                lblAdd.Text = Hotel.HotelInformation.Address;
                lblAddress.Text = Hotel.HotelInformation.Address;
                lblLocation.Text = Hotel.HotelInformation.Description;
                if (string.IsNullOrEmpty(Hotel.HotelInformation.MapUrl))
                {
                    imgMapUrl.Visible = false;
                }
                else
                {
                    imgMapUrl.Visible = true;
                    imgMapUrl.ImageUrl = Hotel.HotelInformation.MapUrl;
                }

                for (int i = 0; i < Hotel.HotelInformation.Features.Count; i++)
                {
                    temp1 += "<li>" + Hotel.HotelInformation.Features[i] + "</li>";
                }


                lblList.Text = temp1;

                List<TERMS.Common.Image> images = (List<TERMS.Common.Image>)Hotel.HotelInformation.Images;

                for (int i = images.Count - 1; i >= 0; i--)
                {
                    if (images[i].Filename == null || images[i].Filename.Trim().Length <= 0)
                    {
                        images.Remove(images[i]);
                    }
                }

                GridView1.DataSource = images;
                ViewState["ImageList"] = images;
                GridView1.DataBind();

                HyperLink hlChange = (HyperLink)e.Item.FindControl("hlChange");
                hlChange.NavigateUrl = @"~/Page/Package2/ViewYourPackages.aspx?HotelIndex=" + e.Item.ItemIndex.ToString() + "&ConditionID=" + Request.Params["ConditionID"];

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

        protected void dlHotel_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataList dl = (DataList)e.Item.FindControl("dlRoom");

                decimal decBasicOfPriceRoom = 0M;

                decimal decRoomPrice = 0M;
                int i = ((DataListItem)e.Item.Parent.Parent).ItemIndex;
                int y = e.Item.ItemIndex;
                MVRoom room = (MVRoom)e.Item.DataItem;

                for (int j = 0; j < dl.Items.Count; j++)
                {
                    //选中默认房型
                    DataListItem item = dl.Items[j];
                    RadioButton rbtn = (RadioButton)item.FindControl("rabRoomType");
                    rbtn.GroupName = "radio" + y.ToString();
                    Label lbl = (Label)item.FindControl("lblCode");
                    HtmlTable tab = (HtmlTable)item.FindControl("cell");
                    Label lblRoomId = (Label)item.FindControl("lblRoomID");
                    Label lblHotelSTATUS = (Label)item.FindControl("lblHotelSTATUS");

                    if (room.Items[j].Profile.GetParam("CATEGORYID") != null)
                    {
                        lblRoomId.Text = room.Items[j].Profile.GetParam("CATEGORYID").ToString().Trim();
                    }

                    if (lbl.Text.Trim().ToUpper() == room.DefaultRoomType.Room.Code.Trim().ToUpper())
                    {
                        if (room.DefaultRoomType.Profile.GetParam("CATEGORYID") != null)
                        {
                            if (room.DefaultRoomType.Profile.GetParam("CATEGORYID").ToString().Trim() == lblRoomId.Text.Trim())
                            {
                                rbtn.Checked = true;
                                tab.BgColor = "#fdf1c1";
                            }
                            else
                            {
                                rbtn.Checked = false;
                                tab.BgColor = "";
                            }
                        }
                        else
                        {
                            rbtn.Checked = true;
                            tab.BgColor = "#fdf1c1";
                        }
                    }
                    else
                    {
                        rbtn.Checked = false;
                        tab.BgColor = "";
                    }

                    if (room.Items[j].Profile.GetParam("STATUS") != null)
                    {
                        //lblHotelSTATUS.Text = value.Items[i].Items[j].Profile.GetParam("STATUS").ToString();

                        if (room.Items[j].Profile.GetParam("STATUS").ToString() == "IM")
                        {
                            lblHotelSTATUS.Text = "AVAILABLE";
                            lblHotelSTATUS.Font.Bold = true;
                        }
                        else
                        {
                            lblHotelSTATUS.Text = "On Request";
                            lblHotelSTATUS.Font.Bold = false;
                        }
                    }
                    else
                    {
                        lblHotelSTATUS.Visible = false;
                    }

                    //添加单选房型的事件
                    if (j >= 10)
                    {
                        rbtn.Attributes["onclick"] = "javascript:CancelSelect(this,'PKGPackageDetailsControl1$dlHotelDetails$ctl0" + i.ToString() + "$dlHotel$ctl0" + y.ToString() + "$dlRoom$ctl" + j.ToString() + "','PKGPackageDetailsControl1_dlHotelDetails_ctl0" + i.ToString() + "_dlHotel_ctl0" + y.ToString() + "_dlRoom_ctl" + j.ToString() + "_cell');";
                    }
                    else
                    {
                        rbtn.Attributes["onclick"] = "javascript:CancelSelect(this,'PKGPackageDetailsControl1$dlHotelDetails$ctl0" + i.ToString() + "$dlHotel$ctl0" + y.ToString() + "$dlRoom$ctl0" + j.ToString() + "','PKGPackageDetailsControl1_dlHotelDetails_ctl0" + i.ToString() + "_dlHotel_ctl0" + y.ToString() + "_dlRoom_ctl0" + j.ToString() + "_cell');";
                    }

                    lbl = (Label)item.FindControl("lblPireType");

                    if (j == 0)
                    {
                        lbl.Visible = true;

                        decBasicOfPriceRoom = room.Items[j].GetAvgPerNightPrice(room.Profile.CheckInDate, room.Profile.CheckOutDate).GetAmount(TERMS.Common.PassengerType.Adult);

                        decRoomPrice = decBasicOfPriceRoom + room.Items[j].GetAvgPerNightPrice(room.Profile.CheckInDate, room.Profile.CheckOutDate).GetMarkup(TERMS.Common.PassengerType.Adult);

                        //if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
                        //{
                        //Hotel产品显示每个房间的单价
                        lbl.Text = Resources.Global.Included;
                        //}
                        //else if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
                        //{
                        //    //Package产品不显示每个房间的单价
                        //    lbl.Text = "";
                        //}
                    }
                    else
                    {
                        decimal temp = room.Items[j].GetAvgPerNightPrice(room.Profile.CheckInDate, room.Profile.CheckOutDate).GetAmount(TERMS.Common.PassengerType.Adult);

                        temp += room.Items[j].GetAvgPerNightPrice(room.Profile.CheckInDate, room.Profile.CheckOutDate).GetMarkup(TERMS.Common.PassengerType.Adult);

                        temp = temp - decRoomPrice;

                        if (temp >= 0)
                        {
                            lbl.Text = "+<span style=\"color:#FF6600\">$" + temp.ToString("N2") + "</span> " + Resources.Global.PerNight;
                        }
                        else
                        {
                            lbl.Text = "-$" + temp.ToString("N2") + " " + Resources.Global.PerNight;
                        }

                        lbl.Visible = true;

                    }
                }
            }
        }
    }
}