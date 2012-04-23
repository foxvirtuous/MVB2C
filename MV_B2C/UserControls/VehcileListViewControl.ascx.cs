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
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;
using TERMS.Common;
using Terms.Sales.Business;
using Terms.Common.Service;

namespace Terms.Web.UserControls
{
    public partial class VehcileListViewControl : SalesBaseUserControl
    {
        private IAirportService _airportService;
        public IAirportService AirportService
        {
            set
            {
                this._airportService = value;
            }
        }

        private bool m_rePageNumber = false;

        public bool rePageNumber
        {
            get { return m_rePageNumber; }
            set { m_rePageNumber = value; }
        }

        private List<string> m_CarTypes = new List<string>();

        public List<string> CarTypes
        {
            get { return m_CarTypes; }
            set { m_CarTypes = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

            VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

            if (!IsPostBack)
            {
                if (m_SaleMerchandise.Items != null && m_SaleMerchandise.Items.Count > 0)
                {
                    foreach (TERMS.Core.Product.Component component in m_SaleMerchandise.Items)
                    {
                        VehcileMaterial vehcilematerial = (VehcileMaterial)component;

                        if (!CarTypes.Contains(vehcilematerial.Vehciles.VehicleType))
                        {
                            CarTypes.Add(vehcilematerial.Vehciles.VehicleType);
                        }
                    }
                }
                
                lbtnCheckAll.Attributes.Add("onclick", "SearchTypeAll()");
            }

            List<TERMS.Core.Product.Component> newdataSource = new List<TERMS.Core.Product.Component>();

            RemoveItem(m_SaleMerchandise.Items, ref newdataSource);

            FilterHotel(newdataSource);

            BindHeadAndFoot();

            BindDataList(newdataSource);
        }

        public VehcileListViewControl()
        {
            this.PreRender += new EventHandler(VehcileListViewControl_PreRender);
        }

        void VehcileListViewControl_PreRender(object sender, EventArgs e)
        {
            VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

            if (!rePageNumber)
            {
                if (Session["Flag"] != null)
                {
                    List<TERMS.Core.Product.Component> newdataSource = new List<TERMS.Core.Product.Component>();
                    RemoveItem(m_SaleMerchandise.Items, ref newdataSource);
                    FilterHotel(newdataSource);
                    PageNumberControl1.DrawingNum();
                    BindHeadAndFoot();
                    NewBindHeadAndFoot(newdataSource);
                }
                else
                {
                    List<TERMS.Core.Product.Component> newdataSource = new List<TERMS.Core.Product.Component>();
                    RemoveItem(m_SaleMerchandise.Items, ref newdataSource);
                    FilterHotel(newdataSource);
                    BindHeadAndFoot();
                    NewBindHeadAndFoot(newdataSource);
                }
            }
            else
            {
                List<TERMS.Core.Product.Component> newdataSource = new List<TERMS.Core.Product.Component>();
                RemoveItem(m_SaleMerchandise.Items, ref newdataSource);
                FilterHotel(newdataSource);
                PageNumberControl1.DrawingNum();
                BindHeadAndFoot();
                NewBindHeadAndFoot(newdataSource);
            }
        }

        public void BindHeadAndFoot()
        {
            VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

            if (m_SaleMerchandise.Items != null && m_SaleMerchandise.Items.Count > 0)
            {
                lblPickupCode.Text = ((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).PickupAirportCode;
                lblDropoffCode.Text = ((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).DropoffAirportCode;
                lblCheckIn.Text = ((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).PickupTime.ToString("ddd MMM dd, yyyy hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                if (lblCheckIn.Text.IndexOf("12:00 PM") > -1)
                {
                    lblCheckIn.Text = lblCheckIn.Text.Replace("12:00 PM", "12 Noon");
                }

                if (lblCheckIn.Text.IndexOf("12:00 AM") > -1)
                {
                    lblCheckIn.Text = lblCheckIn.Text.Replace("12:00 AM", "12 Midnt");
                }

                lblCheckOut.Text = ((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).DropoffTime.ToString("ddd MMM dd, yyyy hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                if (lblCheckOut.Text.IndexOf("12:00 PM") > -1)
                {
                    lblCheckOut.Text = lblCheckOut.Text.Replace("12:00 PM", "12 Noon");
                }

                if (lblCheckOut.Text.IndexOf("12:00 AM") > -1)
                {
                    lblCheckOut.Text = lblCheckOut.Text.Replace("12:00 AM", "12 Midnt");
                }

                lblDays.Text = ((TimeSpan)((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).DropoffTime.Subtract((((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).PickupTime))).Days.ToString() + " Days";
            }
        }

        public void NewBindHeadAndFoot(List<TERMS.Core.Product.Component> dataSource)
        {
            if (!rePageNumber)
            {
                if (Session["Flag"] != null)
                {
                    BindDataList(dataSource, 0);
                    Session["Flag"] = null;
                }
                else
                {
                    BindDataList(dataSource, PageNumberControl1.CurrentPageIndex);
                }
            }
            else
            {
                BindDataList(dataSource, 0);
            }
        }

        protected void dlHotelInfo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Trim().ToUpper() == "SELECT".Trim().ToUpper())
            {
                string carcode = ((Label)e.Item.FindControl("lblCarCode")).Text;
                string carvondercode = ((Label)e.Item.FindControl("lblCarVonder")).Text;

                this.Response.Redirect("VehcileInfoViewForm.aspx?VendorCode=" + carvondercode + "&CarCode=" + carcode + "&ConditionID=" + Request.Params["ConditionID"]);
            }
        }

        private string CounverCarSize(string CarSize)
        {
            string carSize = string.Empty;

            switch (CarSize)
            {
                //case "1":
                //    carSize = "Mini";
                //    break;
                //case "2":
                //    carSize = "Subcompact";
                //    break;
                case "3":
                    carSize = "Economy";
                    break;
                case "4":
                    carSize = "Compact";
                    break;
                //case "5":
                //    carSize = "Midsize";
                //    break;
                case "6":
                    carSize = "Intermediate";
                    break;
                case "7":
                    carSize = "Standard";
                    break;
                case "8":
                    carSize = "Full Size";
                    break;
                case "9":
                    carSize = "Luxury";
                    break;
                case "10":
                    carSize = "Premium";
                    break;
                //case "11":
                //    carSize = "Mini Van";
                //    break;
                //case "12":
                //    carSize = "12 passenger van";
                //    break;
                //case "13":
                //    carSize = "Moving van";
                //    break;
                //case "14":
                //    carSize = "15 passenger van";
                //    break;
                //case "15":
                //    carSize = "Cargo van";
                //    break;
                //case "16":
                //    carSize = "12 foot truck";
                //    break;
                //case "17":
                //    carSize = "20 foot truck";
                //    break;
                //case "18":
                //    carSize = "24 foot truck";
                //    break;
                //case "19":
                //    carSize = "26 foot truck";
                //    break;
                //case "20":
                //    carSize = "Moped";
                //    break;
                //case "21":
                //    carSize = "Stretch";
                //    break;
                //case "22":
                //    carSize = "Regular";
                //    break;
                //case "23":
                //    carSize = "Unique";
                //    break;
                //case "24":
                //    carSize = "Exotic";
                //    break;
                //case "25":
                //    carSize = "Small/medium truck";
                //    break;
                //case "26":
                //    carSize = "Large truck";
                //    break;
                //case "27":
                //    carSize = "Small SUV";
                //    break;
                //case "28":
                //    carSize = "Medium SUV";
                //    break;
                //case "29":
                //    carSize = "Large SUV";
                //    break;
                //case "30":
                //    carSize = "Exotic SUV";
                //    break;
                //case "31":
                //    carSize = "Four wheel drive";
                //    break;
                case "32":
                    carSize = "Specialty Car";
                    break;
                //case "33":
                //    carSize = "Mini elite";
                //    break;
                //case "34":
                //    carSize = "Economy elite";
                //    break;
                //case "35":
                //    carSize = "Compact elite";
                //    break;
                //case "36":
                //    carSize = "Intermediate elite";
                //    break;
                //case "37":
                //    carSize = "Standard elite";
                //    break;
                //case "38":
                //    carSize = "Fullsize elite";
                //    break;
                //case "39":
                //    carSize = "Premium elite";
                //    break;
                //case "40":
                //    carSize = "Luxury elite";
                //    break;
                //case "41":
                //    carSize = "Oversize";
                //    break;
                case "M2":
                    carSize = "Minivan";
                    break;
                case "M3":
                    carSize = "SUV";
                    break;
                case "M4":
                    carSize = "Convertible";
                    break;
            }

            return carSize;
        }

        private PagedDataSource BindDataList(List<TERMS.Core.Product.Component> dataSource)
        {
            int iPageIndex;

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = dataSource;
            objPds.AllowPaging = true;
            objPds.PageSize = 10;
            PageNumberControl1.PageSize = 10;
            objPds.CurrentPageIndex = 0;
            PageNumberControl1.PageAmount = objPds.PageCount;

            if (objPds.DataSourceCount < 10 + 1)
            {
                PageNumberControl1.Visible = false;
            }
            else
            {
                PageNumberControl1.Visible = true;
                PageNumberControl1.Update();
            }
            return objPds;
        }

        private void BindDataList(List<TERMS.Core.Product.Component> dataSource, int index)
        {
            List<TERMS.Core.Product.Component> newdataSource = new List<TERMS.Core.Product.Component>();

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = dataSource;
            objPds.AllowPaging = true;
            objPds.PageSize = 10;
            objPds.CurrentPageIndex = index >= 0 ? index : 0;
            PageNumberControl1.PageSize = 10;
            PageNumberControl1.PageAmount = objPds.PageCount;

            if (objPds.DataSourceCount < 10 + 1)
            {
                PageNumberControl1.Visible = false;
            }
            else
            {
                PageNumberControl1.Visible = true;
                PageNumberControl1.Update();
            }

            //把PagedDataSource 对象赋给Repeater控件 
            dlHotelInfo.DataSource = objPds;
            dlHotelInfo.DataBind();

            BindItems(dataSource, index);            
        }

        private void BindItems(List<TERMS.Core.Product.Component> dataSource, int index)
        {
            List<TERMS.Core.Product.Component> newdataSource = new List<TERMS.Core.Product.Component>();

            int count = dataSource.Count;

            lblRowNumber.Text = count.ToString();

            if (count <= 10)
            {
                lblPageRowNumber.Text = count.ToString();
            }
            else
            {
                int iIndex = (index + 1) * 10;

                if (count < iIndex)
                {
                    lblPageRowNumber.Text = (count - (iIndex - 10)).ToString();
                }
                else
                {
                    lblPageRowNumber.Text = "10";
                }
            }

            for (int i = 0; i < dlHotelInfo.Items.Count; i++)
            {
                VehcileMaterial vehcilematerial = (VehcileMaterial)dataSource[index * 10 + i];

                DataListItem item = (DataListItem)dlHotelInfo.Items[i];

                System.Web.UI.WebControls.Image imgVonder = (System.Web.UI.WebControls.Image)item.FindControl("imgVonder");
                Label lblPickup = (Label)item.FindControl("lblPickup");
                System.Web.UI.WebControls.Image imgCar = (System.Web.UI.WebControls.Image)item.FindControl("imgCar");
                Label lblCarSize = (Label)item.FindControl("lblCarSize");
                Label lblCarName = (Label)item.FindControl("lblCarName");
                System.Web.UI.WebControls.Image imgPassengerQuantity = (System.Web.UI.WebControls.Image)item.FindControl("imgPassengerQuantity");
                System.Web.UI.WebControls.Image imgBaggageQuantity = (System.Web.UI.WebControls.Image)item.FindControl("imgBaggageQuantity");
                Label lblPrePrice = (Label)item.FindControl("lblPrePrice");
                Label lblTotalPrice = (Label)item.FindControl("lblTotalPrice");

                Label lblX = (Label)item.FindControl("lblX");
                Label lblPassengerQuantityImg = (Label)item.FindControl("lblPassengerQuantityImg");

                Label lblPassengerQuantity = (Label)item.FindControl("lblPassengerQuantity");
                Label lblBaggageQuantity = (Label)item.FindControl("lblBaggageQuantity");
                
                imgVonder.ImageUrl = "~/images/V2/" + vehcilematerial.VendorCode + ".gif";

                if (((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).PickupAirportCode != null && ((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).PickupAirportCode.Trim().Length > 0)
                {
                    Terms.Common.Domain.Airport airport = _airportService.Get(((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).PickupAirportCode);

                    if (airport != null)
                    {
                        lblPickup.Text = airport.Name + " - " + airport.Code + ", " + airport.City.Name + ", " + airport.City.CountryCode;
                    }
                    else
                    {
                        lblPickup.Text = ((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).PickupLocation;
                    }
                }
                else
                {
                    lblPickup.Text = ((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).PickupLocation;
                }

                imgCar.ImageUrl = vehcilematerial.Vehciles.PictureURL;
                lblCarSize.Text = CounverCarSize(vehcilematerial.Vehciles.VehicleType);
                lblCarName.Text = vehcilematerial.Vehciles.MakeModelName;
                if (vehcilematerial.Vehciles.PassengerQuantity != null)
                {
                    imgPassengerQuantity.Visible = true;
                    imgPassengerQuantity.ImageUrl = "~/images/V2/car_icon_seat01.gif";
                    lblX.Visible = true;
                    lblPassengerQuantityImg.Visible = true;
                    lblPassengerQuantityImg.Text = vehcilematerial.Vehciles.PassengerQuantity;
                }
                else
                {
                    imgPassengerQuantity.Visible = false;
                    lblX.Visible = false;
                    lblPassengerQuantityImg.Visible = false;
                }
                if (vehcilematerial.Vehciles.BaggageQuantity != null)
                {
                    imgBaggageQuantity.Visible = true;
                    imgBaggageQuantity.ImageUrl = "~/images/V2/car_icon_case0" + vehcilematerial.Vehciles.BaggageQuantity.Trim() + ".gif";
                }
                else
                {
                    imgBaggageQuantity.Visible = false;
                }
                
                Price TotalPrice = vehcilematerial.GetTotalPrice(vehcilematerial.PickupDateTime, vehcilematerial.DropoffDateTime);

                int days = ((TimeSpan)vehcilematerial.DropoffDateTime.Subtract(vehcilematerial.PickupDateTime)).Days;

                lblTotalPrice.Text = "$" + TotalPrice.GetAmount(TERMS.Common.PassengerType.Adult).ToString("N2");
                lblPrePrice.Text = "$" + (TotalPrice.GetAmount(TERMS.Common.PassengerType.Adult) / days).ToString("N2");

                Label lblCarCode = (Label)item.FindControl("lblCarCode");
                Label lblCarVonder = (Label)item.FindControl("lblCarVonder");

                lblCarCode.Text = vehcilematerial.Vehciles.MakeModelCode;
                lblCarVonder.Text = vehcilematerial.VendorCode;
            }
        }

        private void FilterHotel(List<TERMS.Core.Product.Component> dataSource)
        {
            if (ddlSort.SelectedIndex == 0)
            {
                dataSource.Sort(delegate(TERMS.Core.Product.Component r1, TERMS.Core.Product.Component r2) { return ((VehcileMaterial)r1).GetTotalPrice(((VehcileMaterial)r1).PickupDateTime, ((VehcileMaterial)r1).DropoffDateTime).GetAmount(TERMS.Common.PassengerType.Adult).CompareTo(((VehcileMaterial)r2).GetTotalPrice(((VehcileMaterial)r1).PickupDateTime, ((VehcileMaterial)r1).DropoffDateTime).GetAmount(TERMS.Common.PassengerType.Adult)); });
            }
            else
            {
                dataSource.Sort(delegate(TERMS.Core.Product.Component r1, TERMS.Core.Product.Component r2) { return ((VehcileMaterial)r1).Vehciles.VehicleType.CompareTo(((VehcileMaterial)r2).Vehciles.VehicleType); });
            }
        }

        private void RemoveItem(List<TERMS.Core.Product.Component> dataSource, ref List<TERMS.Core.Product.Component> newdataSource)
        {
            TERMS.Core.Product.Component[] components = new TERMS.Core.Product.Component[dataSource.Count];

            dataSource.CopyTo(components);

            newdataSource.AddRange(components);

            VehcileTypeViewControl VehcileTypeViewControl1 = (VehcileTypeViewControl)this.Parent.FindControl("VehcileTypeViewControl1");

            if (VehcileTypeViewControl1 != null)
            {
                m_CarTypes = new List<string>();

                DataList repCarType = (DataList)VehcileTypeViewControl1.FindControl("repCarType");

                for (int i = 0; i < repCarType.Items.Count; i++)
                {
                    Label lblCarType = (Label)repCarType.Items[i].FindControl("lblCarType");
                    CheckBox cbCarType = (CheckBox)repCarType.Items[i].FindControl("cbCarType");

                    if (cbCarType.Checked)
                    {
                        m_CarTypes.Add(lblCarType.Text); 
                    }
                }
            }

            if (m_CarTypes != null)
            {
                for (int i = newdataSource.Count - 1; i >= 0; i--)
                {
                    VehcileMaterial vehcilematerial = (VehcileMaterial)newdataSource[i];

                    string size = vehcilematerial.Vehciles.VehicleType.Trim();

                    if (!m_CarTypes.Contains(size))
                    {
                        newdataSource.RemoveAt(i);
                    }
                }
            }

            if (newdataSource.Count == 0)
            {
                divList.Visible = false;
                divPage.Visible = false;
                divSorry.Visible = true;
            }
            else
            {
                divList.Visible = true;
                divPage.Visible = true;
                divSorry.Visible = false;
            }
        }
    }    
}