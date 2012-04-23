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
using Terms.Material.Domain;
using Terms.Sales.Domain;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Common;
using TERMS.Core.Product;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;

public partial class ShowAllFlights : SalesBaseUserControl
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

    public ShowAllFlights()
    {
        this.InitializeControls += new EventHandler(ShowAllFlights_InitializeControls);
        this.PreRender+=new EventHandler(ShowAllFlights_PreRender);
    }

    private void ShowAllFlights_InitializeControls(object sender, EventArgs e)
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
                //List<HotelMaterial> hotelMaterialNew = new List<HotelMaterial>();

                //FilterHotel(_hotelDetails, ref hotelMaterialNew);

                BindDataList(0);
            }
        }
    }

    private void GetHotelPrice()
    {
        //SaleMerchandise PackageMerchandise = this.OnSearch();
        //if (PackageMerchandise.MaterialList != null)
        //{
        //    if (PackageMerchandise.MaterialList.Count > 0)
        //    {
        //        foreach (HotelMaterial hm in PackageMerchandise.MaterialList)
        //        {
        //            if (hm.Hotel.Id.Equals(HotelID))
        //            {
        //                HotelTotal += hm.Price.Total;
        //            }
        //        }

        //    }
        //}
        //if (PackageMerchandise.MaterialList2 != null)
        //{
        //    foreach (HotelMaterial hm in PackageMerchandise.MaterialList2)
        //    {
        //        if (hm.Hotel.Id.Equals(HotelID))
        //        {
        //            HotelTotal += hm.Price.Total;
        //        }
        //    }
        //}
    }

    protected void dlSubTrips_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbDeptOrRtn = (Label)e.Item.FindControl("lbDeptOrRtn");
            Label lbDepartureDate = (Label)e.Item.FindControl("lbDepartureDate");

            if (e.Item.ItemIndex == 0)
                lbDeptOrRtn.Text = "Departure";

            else
                lbDeptOrRtn.Text = "Return";

            lbDepartureDate.Text = ((SubAirTrip)e.Item.DataItem).Flights[0].DepartureTime.ToString("MMM dd,yyyy", DateTimeFormatInfo.InvariantInfo);


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

            //设置Cabin
            int airMaterialIndex = ((DataListItem)e.Item.Parent.Parent.Parent.Parent ).ItemIndex;
            Label lblCabin= (Label)e.Item.FindControl("lbCabin");

            if (lblCabin != null)
                lblCabin.Text = GetCabin(airMaterialIndex);
        }
    }
    protected void dlAirGroup_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "SELECT")
        {
            //List<MVHotel> hMaterial = new List<MVHotel>();

            //if (Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList != null)
            //{
            //    foreach (HotelMaterial hm in Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.MaterialList)
            //    {
            //        hMaterial.Add(hm);
            //    }
            //}
            //Utility.Transaction.CurrentTransactionObject.Items[0].Merchandise.ComponentGroup.Items.RemoveAt(0);

            //int parentIndex = ((DataListItem)((DataList)e.Item.Parent).Parent).ItemIndex;

            PackageMerchandise packageMerchandise = (PackageMerchandise)this.OnSearch();
            //ComponentGroup group = new ComponentGroup();
            //AirComponentGroup airGroup = (AirComponentGroup)((ComponentGroup)PackageMerchandise.ComponentGroup.Items[1].Component).Items[parentIndex].Component;
            //ComponentGroupItem componentGroupItem = new ComponentGroupItem(airGroup.Items[e.Item.ItemIndex].Component);
            //AirComponentGroup lastGroup = new AirComponentGroup((AirProfile)airGroup.Profile);
            //lastGroup = (AirComponentGroup)airGroup.Clone();
            //lastGroup.Items.Add(componentGroupItem);
            //group.Profile = PackageMerchandise.ComponentGroup.Profile;
            //group.Items.Clear();
            //group.Items.Add(new ComponentGroupItem(lastGroup));
            //group.Items.Insert(0, new ComponentGroupItem(lastGroup));

            packageMerchandise.DefaultIndex[0] = (PageNumberControl1.CurrentPageIndex * PAGE_SIZE) + e.Item.ItemIndex;
            //AirMaterial airMaterial = (AirMaterial)packageMerchandise.DefaultMerchandise[0];

            //AirOrderItem airOrderItem = new AirOrderItem(airMaterial);
            //int merchandiseNumber = packageMerchandise.DefaultMerchandise.Length;
            //List<OrderItem> orderItemList = new List<OrderItem>();

            //orderItemList.Add(airOrderItem);
            //for(int i=1 ;i<merchandiseNumber ;i++)
            //{
            //    foreach (object mVHotel in (List<object>)packageMerchandise.DefaultMerchandise[i])
            //    {
            //        HotelOrderItem hotelOrderItem = new HotelOrderItem((Hotel)mVHotel);
            //        orderItemList.Add(hotelOrderItem);
            //    }
            //}
            // Utility.Transaction.CurrentTransactionObject.
            //PackageOrderItem airOrderItem = new AirOrderItem(airMaterial);
            //saleMerchandise.ComponentGroup = group;
            //foreach (HotelMaterial hm in hMaterial)
            //{
            //    saleMerchandise.MaterialList.Add(hm);
            //}
            //Utility.Transaction.CurrentTransactionObject.InsertItem(0, saleMerchandise);
            //Utility.SelectAirGroup = group;

            if (URL.Contains("PackageSearchResult2dFrom"))
                Response.Redirect(URL + "?PostBack=false" + "&ConditionID=" + Request.Params["ConditionID"]);
            else
                Response.Redirect(URL + "?PostBack=false" + "&HotelIndex=" + packageMerchandise.CurrentHotelListNumber.ToString() + "&ConditionID=" + Request.Params["ConditionID"]);
        }
    }

    //********************************************
    //private void FilterHotel(IList<AirComponentGroup> hotelMaterials, ref List<AirComponentGroup> hotelMaterialsNew)
    //{
    //    if (this.ddlCountry.SelectedIndex > 0 && this.ddlCity.SelectedIndex > 0)
    //    {
    //        string strCityCode = this.ddlCity.SelectedValue;

    //        for (int i = 0; i < hotelMaterials.Count; i++)
    //        {
    //            if (hotelMaterials[i].Hotel.CityCode.Code.Trim() == strCityCode.Trim())
    //            {
    //                hotelMaterialsNew.Add(hotelMaterials[i]);
    //            }
    //        }
    //    }

    //    if (hotelMaterialsNew.Count > 0)
    //    {
    //        hotelMaterials = hotelMaterialsNew;
    //        hotelMaterialsNew = new List<HotelMaterial>();
    //    }
    //    if (this.ddlStar.SelectedIndex > 0)
    //    {
    //        string strStar = this.ddlStar.SelectedValue;

    //        for (int i = 0; i < hotelMaterials.Count; i++)
    //        {
    //            if (hotelMaterials[i].Hotel.Class.Value >= Convert.ToInt16(strStar))
    //            {
    //                hotelMaterialsNew.Add(hotelMaterials[i]);
    //            }
    //        }
    //    }

    //    if (hotelMaterialsNew.Count > 0)
    //    {
    //        hotelMaterials = hotelMaterialsNew;
    //        hotelMaterialsNew = new List<HotelMaterial>();
    //    }

    //    if (this.txtContains.Text.Trim().Length > 0)
    //    {
    //        string strContains = txtContains.Text.Trim();

    //        for (int i = 0; i < hotelMaterials.Count; i++)
    //        {
    //            if (hotelMaterials[i].Hotel.Name.Contains(strContains))
    //            {
    //                hotelMaterialsNew.Add(hotelMaterials[i]);
    //            }
    //        }
    //    }

    //    if (hotelMaterialsNew.Count == 0)
    //    {
    //        hotelMaterialsNew = (List<HotelMaterial>)hotelMaterials;
    //    }

    //    if (RadioButtonList1.SelectedIndex == 0)
    //    {
    //        hotelMaterialsNew.Sort(delegate(HotelMaterial r1, HotelMaterial r2) { return r1.RoomRates[r1.Hotel.Rooms[0].RoomTypes[0]].BaseFare.CompareTo(r2.RoomRates[r2.Hotel.Rooms[0].RoomTypes[0]].BaseFare); });
    //    }
    //    if (RadioButtonList1.SelectedIndex == 1)
    //    {
    //        hotelMaterialsNew.Sort(delegate(HotelMaterial r1, HotelMaterial r2) { return r1.RoomRates[r1.Hotel.Rooms[0].RoomTypes[0]].Total.CompareTo(r2.RoomRates[r2.Hotel.Rooms[0].RoomTypes[0]].Total); });
    //    }
    //    if (RadioButtonList1.SelectedIndex == 2)
    //    {
    //        hotelMaterialsNew.Sort(delegate(HotelMaterial r1, HotelMaterial r2) { return r1.Hotel.Name.CompareTo(r2.Hotel.Name); });
    //    }
    //    if (RadioButtonList1.SelectedIndex == 3)
    //    {
    //        hotelMaterialsNew.Sort(delegate(HotelMaterial r1, HotelMaterial r2) { return r1.Hotel.Class.Value.CompareTo(r2.Hotel.Class.Value); });
    //    }
    //}

    //private void BindDataList(IList<Component> dataSource)
    //{
    //    int iPageIndex;

    //    PagedDataSource objPds = new PagedDataSource();
    //    objPds.DataSource = dataSource;
    //    objPds.AllowPaging = true;
    //    objPds.PageSize = PAGE_SIZE;

    //    if (this.Request["PageIndex"] != null)
    //        iPageIndex = Convert.ToInt32(this.Request["PageIndex"]);
    //    else
    //        iPageIndex = 1;

    //    int iTemp = Convert.ToInt32(dataSource.Count / objPds.PageSize);

    //    if (Convert.ToInt32(iPageIndex / 5) == 0)
    //    {
    //        hlStar.Visible = false;
    //    }
    //    else
    //    {
    //        hlStar.Visible = true;
    //        hlStar.NavigateUrl = Request.CurrentExecutionFilePath + "?URL=" + URL + "&PageIndex=" + Convert.ToString(Convert.ToInt32(iPageIndex / 5) * 5);
    //    }

    //    int iMod = System.Data.SqlTypes.SqlInt32.Mod(new System.Data.SqlTypes.SqlInt32(dataSource.Count), new System.Data.SqlTypes.SqlInt32(objPds.PageSize)).Value;

    //    if (iTemp == 0 || ((Convert.ToInt32(iPageIndex / 5) * 5) + 6) > objPds.PageCount)
    //    {
    //        hlEnd.Visible = false;
    //    }
    //    else
    //    {
    //        if (Convert.ToInt32(iPageIndex / 5) == iTemp)
    //        {
    //            hlEnd.Visible = false;
    //        }
    //        else
    //        {
    //            hlEnd.Visible = true;
    //            hlEnd.NavigateUrl = Request.CurrentExecutionFilePath + "?URL=" + URL + "&PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 6);
    //        }
    //    }
    //    if ((1 < iMod || Convert.ToInt32(iPageIndex / 5) < iTemp) && ((Convert.ToInt32(iPageIndex / 5) * 5) + 1) <= objPds.PageCount)
    //    {
    //        hl1.NavigateUrl = Request.CurrentExecutionFilePath + "?URL=" + URL + "&PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 1);
    //        hl1.Text = Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 1);
    //        hl1.Visible = true;
    //    }
    //    else
    //    {
    //        hl1.Visible = false;
    //    }

    //    if ((11 < iMod || Convert.ToInt32(iPageIndex / 5) < iTemp) && ((Convert.ToInt32(iPageIndex / 5) * 5) + 2) <= objPds.PageCount)
    //    {
    //        hl2.NavigateUrl = Request.CurrentExecutionFilePath + "?URL=" + URL + "&PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 2);
    //        hl2.Text = Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 2);
    //        hl2.Visible = true;
    //    }
    //    else
    //    {
    //        hl2.Visible = false;
    //    }

    //    if ((21 < iMod || Convert.ToInt32(iPageIndex / 5) < iTemp) && ((Convert.ToInt32(iPageIndex / 5) * 5) + 3) <= objPds.PageCount)
    //    {
    //        hl3.NavigateUrl = Request.CurrentExecutionFilePath + "?URL=" + URL + "&PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 3);
    //        hl3.Text = Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 3);
    //        hl3.Visible = true;
    //    }
    //    else
    //    {
    //        hl3.Visible = false;
    //    }

    //    if ((31 < iMod || Convert.ToInt32(iPageIndex / 5) < iTemp) && ((Convert.ToInt32(iPageIndex / 5) * 5) + 4) <= objPds.PageCount)
    //    {
    //        hl4.NavigateUrl = Request.CurrentExecutionFilePath + "?URL=" + URL + "&PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 4);
    //        hl4.Text = Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 4);
    //        hl4.Visible = true;
    //    }
    //    else
    //    {
    //        hl4.Visible = false;
    //    }


    //    if ((41 < iMod || Convert.ToInt32(iPageIndex / 5) < iTemp) && ((Convert.ToInt32(iPageIndex / 5) * 5) + 5) <= objPds.PageCount)
    //    {
    //        hl5.NavigateUrl = Request.CurrentExecutionFilePath + "?URL=" + URL + "&PageIndex=" + Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 5);
    //        hl5.Text = Convert.ToString((Convert.ToInt32(iPageIndex / 5) * 5) + 5);
    //        hl5.Visible = true;
    //    }
    //    else
    //    {
    //        hl5.Visible = false;
    //    }

    //    objPds.CurrentPageIndex = iPageIndex - 1;

    //    if (!objPds.IsFirstPage)
    //        hlPrevious.NavigateUrl = Request.CurrentExecutionFilePath + "?URL=" + URL + "&PageIndex=" + Convert.ToString(iPageIndex - 1);

    //    if (!objPds.IsLastPage)
    //        hlNext.NavigateUrl = Request.CurrentExecutionFilePath + "?URL=" + URL + "&PageIndex=" + Convert.ToString(iPageIndex + 1);

    //    //把PagedDataSource 对象赋给Repeater控件 
    //    PreviousPageIndex = iPageIndex - 1;
    //    this.dlAirGroup.DataSource = objPds;
    //    this.dlAirGroup.DataBind();

    //}
    private void BindDataList(int index)
    {
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = PgMerchandise.GetPackageMaterials(0);
        pds.PageSize = PAGE_SIZE;
        PageNumberControl1.PageSize = PAGE_SIZE;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = index >= 0 ? index : 0;
        PageNumberControl1.CurrentPageIndex = pds.CurrentPageIndex;
        PageNumberControl1.PageAmount = pds.PageCount;
        PageNumberControl1.ItemAmount = pds.DataSourceCount;
        if (pds.DataSourceCount < PAGE_SIZE + 1)
            PageNumberControl1.Visible = false;
        else
            PageNumberControl1.Visible = true;


        this.dlAirGroup.DataSource = pds;
        this.dlAirGroup.DataBind();
    }

    /// <summary>
    /// PreRender Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ShowAllFlights_PreRender(object sender, EventArgs e)
    {
        if (!rePageNumber)
        {
            
            BindDataList(PageNumberControl1.CurrentPageIndex);
        }
        else
        {
            
            this.PageNumberControl1.DrawingNum();
            BindDataList(0);
        }

        //BODY.Attributes["onload"] = "toggleNLayer('" + ADVANCEDOPTION + "',1);ChangeFlightType('" + ONEWAYFLAG.ToLower() + "');";
    }

}
