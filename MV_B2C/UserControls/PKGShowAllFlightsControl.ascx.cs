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
using System.Collections.Generic;
using System.Globalization;
using Spring.Web.UI;
using log4net;
//using Terms.Material.Domain;
using Terms.Sales.Domain;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Common;
using TERMS.Core.Product;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;


public partial class PKGShowAllFlightsControl : SalesBaseUserControl
{
   public static int PAGE_SIZE = 10;
    private int m_previousPageIndex = 0;
    private bool rePageNumber = false;
    public int PreviousPageIndex
    {
        get
        {
                return m_previousPageIndex;
        }
        set
        {
            m_previousPageIndex = value;
        }
    }

    private decimal m_hotelTotal = 0M;
    public decimal HotelTotal
    {
        get
        {
            return m_hotelTotal;
        }
        set
        {
            m_hotelTotal = value;
        }
    }
    private Guid m_HotelID;
    public Guid HotelID
    {
        set { m_HotelID = value; }
        get { return m_HotelID; }
    }

    private string m_url;
    public string URL
    {
        get { return (string)ViewState["URL"]; }
        set { ViewState["URL"] = value; }
    }

    private List<PackageMaterial> _FlightDetails;
    public List<PackageMaterial> FlightDetails
    {
        set
        {
            if (value is List<PackageMaterial>)
            {
                
                BindDataList(0);
            }
            _FlightDetails = value;
        }
        get
        {
            if (_FlightDetails == null)
            {
                _FlightDetails = new List<PackageMaterial>();
            }

            return _FlightDetails;
        }
    }

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

    public string GetCabin(int airMaterialIndex)
    {
        string cabin = string.Empty;

        if( PgMerchandise != null)
            if( PgMerchandise.Items != null && PgMerchandise.Items.Count > 0)
                if (PgMerchandise.Items[0].Items != null && PgMerchandise.Items[0].Items.Count > 0 && airMaterialIndex < PgMerchandise.Items[0].Items.Count )
                {
                    AirMaterial airM = (AirMaterial)PgMerchandise.Items[0].Items[airMaterialIndex];
                    
                    if(airM.Profile.GetParam("CABIN") != null)
                        cabin = airM.Profile.GetParam("CABIN").ToString();
                }

        return cabin;
    }

    public PKGShowAllFlightsControl()
    {
        this.InitializeControls += new EventHandler(PKGShowAllFlightsControl_InitializeControls);
        this.PreRender += new EventHandler(PKGShowAllFlightsControl_PreRender);
    }

    private void PKGShowAllFlightsControl_InitializeControls(object sender, EventArgs e)
    {
        if (Request.QueryString["HotelID"] != null && Request.QueryString["HotelID"] != "")
        {
            HotelID = new Guid(Request.QueryString["HotelID"]);
            GetHotelPrice();
        }
        if (!IsPostBack)
        {
            if (FlightDetails == null || FlightDetails.Count == 0)
            {
            }
            else
            {
                BindDataList(0);
            }
        }
    }

    private void GetHotelPrice()
    {
     
    }

    protected void dlSubTrips_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //Label lbDeptOrRtn = (Label)e.Item.FindControl("lbDeptOrRtn");
            //Label lbDepartureDate = (Label)e.Item.FindControl("lbDepartureDate");
            PlaceHolder table = (PlaceHolder)e.Item.FindControl("phTable");
            if (e.Item.ItemIndex == 0)
                table.Visible = true;//lbDeptOrRtn.Text = "Departure";

            else
                table.Visible = false;//lbDeptOrRtn.Text = "Return";

            //lbDepartureDate.Text = ((SubAirTrip)e.Item.DataItem).Flights[0].DepartureTime.ToString("MMM dd,yyyy", DateTimeFormatInfo.InvariantInfo);


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

            ((Label)e.Item.FindControl("lblFlightDuration")).Text = GetFlightTime(airLeg);

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

            //ÉèÖÃCabin
            //int airMaterialIndex = ((DataListItem)e.Item.Parent.Parent.Parent.Parent ).ItemIndex;
            //Label lblCabin= (Label)e.Item.FindControl("lbCabin");

            //if (lblCabin != null)
            //    lblCabin.Text = GetCabin(airMaterialIndex);
        }
    }

    private string GetFlightTime(AirLeg airLeg)
    {
        string duration;

        AirLineMatricsManager airManager = new AirLineMatricsManager();

        return airManager.FormatTimeSpan(airManager.GetFlightTime(airLeg));
    }

    protected void dlAirGroup_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "SELECT")
        {

            PackageMerchandise packageMerchandise = (PackageMerchandise)this.OnSearch();

            packageMerchandise.DefaultIndex[0] = (PageNumber1.CurrentPageIndex * PAGE_SIZE) + e.Item.ItemIndex;

            if (URL.Contains("PackageSearchResult2dFrom"))
                Response.Redirect(URL + "?PostBack=false" + "&ConditionID=" + Request.Params["ConditionID"]);
            else
                Response.Redirect(URL + "?PostBack=false" + "&HotelIndex=" + packageMerchandise.CurrentHotelListNumber.ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
    }

   
    private void BindDataList(int index)
    {
        PagedDataSource pds = new PagedDataSource();
        List<PackageMaterial> packageDetails = PgMerchandise.GetPackageMaterials(0);
        //packageDetails.Sort(delegate(PackageMaterial p1, PackageMaterial p2) { return p1.Airs[0].AdultBaseFare.CompareTo(p2.Airs[0].AdultBaseFare); });

        //packageDetails.Sort(delegate(PackageMaterial p1, PackageMaterial p2) { return p1.TotalPrice.CompareTo(p2.TotalPrice); });
        pds.DataSource = packageDetails;// PgMerchandise.GetPackageMaterials(0);
        pds.PageSize = PAGE_SIZE;
        PageNumber1.PageSize = PAGE_SIZE;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = index >= 0 ? index : 0;
        PageNumber1.CurrentPageIndex = pds.CurrentPageIndex;
        PageNumber1.PageAmount = pds.PageCount;
       // PageNumber1.ItemAmount = pds.DataSourceCount;
        if (pds.DataSourceCount < PAGE_SIZE + 1)
            PageNumber1.Visible = false;
        else
            PageNumber1.Visible = true;
    
        this.dlAirGroup.DataSource = pds;
        this.dlAirGroup.DataBind();
    }

    /// <summary>
    /// PreRender Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PKGShowAllFlightsControl_PreRender(object sender, EventArgs e)
    {
        if (!rePageNumber)
        {
            BindDataList(PageNumber1.CurrentPageIndex);
        }
        else
        {
            this.PageNumber1.DrawingNum();
            BindDataList(0);
        }
    }

    protected void dlAirGroup_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (!IsSearchConditionNull)
            {
                Label lblAvgPrice = (Label)e.Item.FindControl("lblAvgPrice");
                Label lblTotal = (Label)e.Item.FindControl("lblTotal");
                int adult = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(PassengerType.Adult);
                int child = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition.GetPassengerNumber(PassengerType.Child);
                lblAvgPrice.Text = (Convert.ToDecimal(lblTotal.Text) / (adult + child)).ToString("#,###");
            }
        }
    }
}
