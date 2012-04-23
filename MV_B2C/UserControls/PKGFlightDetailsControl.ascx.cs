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
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;
using TERMS.Common;
using System.Globalization;
using Terms.Sales.Business;

namespace Terms.Web.UserControls
{
    public partial class PKGFlightDetailsControl : Spring.Web.UI.UserControl
    {
           //设置标志位
        private int flagCode;
        public int FlagCode
        {
            set 
            {
                flagCode = value;
            }
            get
            {
                return flagCode;
            }
        }

        private int m_index;
        public int Index
        {
            set { m_index = value; }
            get { return m_index; }
        }

        //设置返回路径属性
        private string m_url;
        public string URL
        {
            get { return ViewState["URL"].ToString(); }
            set { ViewState["URL"] = value; }
        }

        //设置Hotel是否选择
        private bool m_isSelectHotel = false;
        public bool IsSelectHotel
        {
            set { m_isSelectHotel = value; }
            get { return m_isSelectHotel; }
        }


        //接收飞机信息集合
        private List<AirMaterial> _FlightDetails;

        public List<AirMaterial> FlightDetails
        {
            set
            {
                if (value is List<AirMaterial>)
                {
                    this.dlAirGroup.DataSource = value;

                    dlAirGroup.DataBind();

                    for (int i = 0; i < dlAirGroup.Items.Count; i++)
                    {
                        if (FlagCode == 0)
                        {
                            ((LinkButton)dlAirGroup.Items[i].FindControl("lkbChange")).Visible = true;
                        }
                        else
                        {
                            ((LinkButton)dlAirGroup.Items[i].FindControl("lkbChange")).Visible = false;
                        }
                    }
                }
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

        public PKGFlightDetailsControl()
        {
            this.InitializeControls += new EventHandler(PKGFlightDetailsControl_InitializeControls);
        }

        private void PKGFlightDetailsControl_InitializeControls(object sender, EventArgs e)
        {
            URL = "ChangeFlightsInformation.aspx";
            try
            {
                if (!IsPostBack)
                {
                    
                    BinderHotelDetails();
                }
            }
            catch
            {

            }
        }

        private void BinderHotelDetails()
        {
            this.dlAirGroup.DataSource = FlightDetails;
            this.dlAirGroup.DataBind();
        }

        protected void dlSubTrips_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Label lbDeptOrRtn = (Label)e.Item.FindControl("lbDeptOrRtn");
                //Label lbDepartureDate = (Label)e.Item.FindControl("lbDepartureDate");
                
                //if (e.Item.ItemIndex == 0)
                //    lbDeptOrRtn.Text = Resources.Global.Departure;
                   
                //else
                //    lbDeptOrRtn.Text = Resources.Global.Return;

                //lbDepartureDate.Text = ((SubAirTrip)e.Item.DataItem).Flights[0].DepartureTime.ToString("MMM dd,yyyy", DateTimeFormatInfo.InvariantInfo);

                if (e.Item.ItemIndex == Index)
                    e.Item.Visible = true;
                else
                    e.Item.Visible = false;
            }
        }
        protected void lkbChange_Click(object sender, EventArgs e)
        {
            
        }
        protected void dlAirGroup_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "SELECT")
            {
 
                if (((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).HotelSearchCondition2 != null)
                {
                    Response.Redirect("~/Page/Package2/ChangeFlightsInformation.aspx?URL=" + URL + "&Condition=2" + "&ConditionID=" + Request.Params["ConditionID"]);
                }

                else
                {
                    Response.Redirect("~/Page/Package2/ChangeFlightsInformation.aspx?URL=" + URL + "&ConditionID=" + Request.Params["ConditionID"]);
                }

            }
        }
        protected void dlFlights_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                AirLeg airLeg = (AirLeg)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
                System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("AirImgRtn");
                image.ImageUrl = "~/images/airline/defult_air.jpg";
                string airImgName = airLeg.AirLine.Code.Trim().ToString() + ".gif";

                if (System.IO.File.Exists(Request.PhysicalApplicationPath + @"images\airline\" + airImgName))
                {
                    image.ImageUrl = "~/images/airline/" + airImgName;
                }

                ((Label)e.Item.FindControl("lblFlightDuration")).Text = GetFlightTime((AirLeg)(e.Item.DataItem));

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
        private string GetFlightTime(AirLeg airLeg)
        {
            string duration;

            AirLineMatricsManager airManager = new AirLineMatricsManager();

            return airManager.FormatTimeSpan(airManager.GetFlightTime(airLeg));
        }

       
    }

}