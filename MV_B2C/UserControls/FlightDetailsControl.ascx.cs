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
using Terms.Base.Utility;
using System.Collections.Generic;

using TERMS.Common;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Core.Product;
using TERMS.Business.Centers.ProductCenter.Profiles;
using Resources;

public partial class FlightDetailsControl : SalesBaseUserControl
{
    //Add Peng zhao hui
    private string m_FareType;
    public string FareType
    {
        get { return m_FareType; }
        set { m_FareType = value; }
    }

    private bool m_IsSucceed = false;
    public bool IsSucceed
    {
        get { return m_IsSucceed; }
        set { m_IsSucceed = value; }
    }

    private bool m_IsWarnMessg = false;
    public bool IsWarnMessg
    {
        get { return m_IsWarnMessg; }
        set { m_IsWarnMessg = value; }
    }
    private bool _isLetDisplay = false;
    public bool IsLetDisplay
    {
        get { return _isLetDisplay; }
        set { _isLetDisplay = value; }
    }
    public FlightInfoHider flightInfohider = new FlightInfoHider();

    public FlightDetailsControl()
    {
        this.InitializeControls += new EventHandler(FlightDetailsControl_InitializeControls);
    }

    /// <summary>
    /// 隐藏飞机信息的标志，true代表隐藏，false代表不隐藏，默认false
    /// </summary>
    private bool HideFlightInfoFlag
    {
        get
        {
            if (ViewState["HideFlightInfoFlag"] == null)
                ViewState["HideFlightInfoFlag"] = false;

            return Convert.ToBoolean(ViewState["HideFlightInfoFlag"]);
        }
        set { ViewState["HideFlightInfoFlag"] = value; }
    }

    void FlightDetailsControl_InitializeControls(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Page.ToString() == "ASP.page_common_creditcardinfoform_aspx")
            {
                this.IsSucceed = true;
            }
            BindFlight();

            if (HideFlightInfoFlag)
            {

                lbDispMessage.Text = HintInfo.DISP_MESSAGE;
               // lbDispMessage.Text = Resources.HintInfo.DISP_MESSAGE;
                lbDispMessage.Visible = true;

            }
            else
            {
                lbDispMessage.Visible = false;
            }
        }

       
        
    }
    //绑定显示订购的飞机行程信息

    private void BindFlight()
    {
        if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
        {
            AirOrderItem airOrderItem = null;

            //在订单中找Air订单项

            foreach (OrderItem item in Utility.Transaction.CurrentTransactionObject.Items)
            {
                airOrderItem = FindAirOrderItem(item);

                if (airOrderItem != null) break;
            }

            AirMaterial airMaterial = null;
            //绑定飞机行程信息
            if (airOrderItem != null)
            {
                FareType = airOrderItem.Profile.GetParam("FARE_TYPE").ToString();
                IList<AirLeg> flights = new List<AirLeg>();
                airMaterial = (AirMaterial)airOrderItem.Merchandise;
                if (airMaterial.Profile.GetParam("SHOW_WARN_MSG")!=null)
                    m_IsWarnMessg = Convert.ToBoolean(airMaterial.Profile.GetParam("SHOW_WARN_MSG"));
                foreach (SubAirTrip subAirTrip in airMaterial.AirTrip.SubTrips)
                    foreach (AirLeg airLeg in subAirTrip.Flights)
                        flights.Add(airLeg);

                dlFlights.DataSource = flights;
                dlFlights.DataBind();
            }

            //显示Duration
            SetTotalDurationAndDistance(airMaterial);
        }
    }

    private void SetTotalDurationAndDistance(AirMaterial flight)
    {
        lblTotalDistance.Text = GetDistance(flight);
        lblTotalDuration.Text = GetDuration(flight);

        if (lblTotalDistance.Text.Trim() == string.Empty)
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

    public string GetDistance(AirMaterial flight)
    {
        return new AirLineMatricsManager().GetDistance(flight);
    }

    private AirOrderItem FindAirOrderItem(Component orderItem)
    {
        if (orderItem is AirOrderItem) return (AirOrderItem)orderItem;  //找到了

        if (orderItem is HotelOrderItem) return null;  //是HotelOrderItem
        if (!(orderItem is ComponentGroup)) return null;    //不是ComonentGroup说明没有子项,所以没找到

        ComponentGroup cGroup = (ComponentGroup)orderItem;
      
        if (cGroup.Items.Count == 0) return null; //没找到


        foreach (Component item in cGroup.Items)
        {
            if (item is AirOrderItem)
            {
                return (AirOrderItem)item; //找到了

            }
            else if (item is ComponentGroup)
            {
                AirOrderItem result = FindAirOrderItem(orderItem); //递归查找

                if (result != null) return result; //不是空代表找到了
            }
        }

        return null; //没找到

    }

    protected void dlFlights_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //if (!IsSucceed)
            //{
                string AirCode = ((Label)e.Item.FindControl("lbl_AirCode")).Text;

                if (IsLetDisplay || !flightInfohider.IsNeedToHide(AirCode, FareType))
                {
                    //((Label)e.Item.FindControl("lblAirName")).Visible = false;
                    ((Label)e.Item.FindControl("Label3")).Visible = false;
                    ((Label)e.Item.FindControl("Label6")).Visible = false;
                    //((Label)e.Item.FindControl("lblBookClass")).Visible = true;
                    ((Label)e.Item.FindControl("lblFlightNo")).Visible = true;
                    //((Label)e.Item.FindControl("lbl_AirCode")).Visible = true;
                    ((Label)e.Item.FindControl("lblDepDate")).Visible = true;
                    ((Label)e.Item.FindControl("lblArrDate")).Visible = true;
                }
                else
                {
                    //((Label)e.Item.FindControl("lblAirName")).Visible = true;
                    //((Label)e.Item.FindControl("lbl_AirCode")).Text = flightInfohider.ReplaceFlightName(AirCode,FareType);
                    //((Label)e.Item.FindControl("Label3")).Visible = true;
                    //((Label)e.Item.FindControl("Label6")).Visible = true;
                    ((Label)e.Item.FindControl("lbl_AirCode")).Text = flightInfohider.ReplaceFlightName(AirCode, FareType);
                    ((Label)e.Item.FindControl("Label3")).Text = flightInfohider.TimeToName(((Label)e.Item.FindControl("lblDepDate")).Text.Substring(0, 8)) + ((Label)e.Item.FindControl("Label3")).Text;
                    ((Label)e.Item.FindControl("Label6")).Text = flightInfohider.TimeToName(((Label)e.Item.FindControl("lblArrDate")).Text.Substring(0, 8)) + ((Label)e.Item.FindControl("Label6")).Text;
                    //((Label)e.Item.FindControl("lblBookClass")).Visible = false;
                    ((Label)e.Item.FindControl("lblFlightNo")).Visible = false;
                    ((Label)e.Item.FindControl("lblDepDate")).Visible = false;
                    ((Label)e.Item.FindControl("lblArrDate")).Visible = false;
                    HideFlightInfoFlag = true;
                }

                AirLeg airleg = (AirLeg)e.Item.DataItem;

                if (!string.IsNullOrEmpty(airleg.OperatingAirlineInfo))
                {
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = true;
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Text = "Operated by: " + airleg.OperatingAirlineInfo;

                    if (IsLetDisplay || !flightInfohider.IsNeedToHide(AirCode, FareType))
                    {
                    }
                    else
                    {
                        ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = false;
                    }
                }
                else
                {
                    ((Label)e.Item.FindControl("lblOperatingAirline")).Visible = false;
                }

            //}
            //else
            //{
            //    ((Label)e.Item.FindControl("Label3")).Visible = true;
            //    ((Label)e.Item.FindControl("Label6")).Visible = true;
            //    //((Label)e.Item.FindControl("lblBookClass")).Visible = true;
            //    ((Label)e.Item.FindControl("lblFlightNo")).Visible = true;
            //    ((Label)e.Item.FindControl("lbl_AirCode")).Visible = true;
            //    ((Label)e.Item.FindControl("lblDepDate")).Visible = false;
            //    ((Label)e.Item.FindControl("lblArrDate")).Visible = false;
            //    //((Label)e.Item.FindControl("lblAirName")).Visible = false;
            //}

                ((Label)e.Item.FindControl("lblFlightDuration")).Text = GetFlightTime((AirLeg)(e.Item.DataItem));
            
        }
    }

    private string GetFlightTime(AirLeg airLeg)
    {
        string duration;

        AirLineMatricsManager airManager = new AirLineMatricsManager();

        return airManager.FormatTimeSpan(airManager.GetFlightTime(airLeg));
    }

}
