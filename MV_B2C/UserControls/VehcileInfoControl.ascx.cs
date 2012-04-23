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
using Terms.Common.Service;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;


public partial class VehcileInfoControl : SalesBaseUserControl
{
    private ICommonService _CommonService;

    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    private bool m_Flag = true;

    public bool Flag
    {
        get { return m_Flag; }
        set { m_Flag = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (!IsPostBack)
        {
            Bind();

            lbtnBack.Visible = Flag;
        }
    }


    private void Bind()
    {
        VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

        VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

        for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
        {
            VehcileMaterial vehcilematerial = (VehcileMaterial)m_SaleMerchandise.Items[i];

            if (vehcilematerial.VendorCode == VendorCode && vehcilematerial.Vehciles.MakeModelCode == CarCode)
            {
                imgVonder.ImageUrl =  SaleWebSuffix + "images/V2/" + vehcilematerial.VendorCode + ".gif";

                lblCarName.Text = vehcilematerial.Vehciles.MakeModelName;

                imgCar.ImageUrl = vehcilematerial.Vehciles.PictureURL;

                lblVendorCode.Text = vehcilematerial.VendorName;

                string PickupAirportCode = vehcilesearchcondition.PickupAirportCode;

                Terms.Common.Domain.Airport pickAirport = _CommonService.FindAirportByAirportCode(PickupAirportCode.Trim());

                lblPickCityName.Text = pickAirport.Name;
                lblPickCityCode.Text = vehcilesearchcondition.PickupAirportCode.Trim();

                Terms.Common.Domain.Province provincePick = _CommonService.FindProvinceByName(pickAirport.City.ProvinceName);
                if (provincePick != null)
                {
                    lblPickPrCode.Text = ", " + provincePick.Code.Trim();
                }
                else
                {
                    //lblPickPrCode.Text = "," + pickAirport.City.ProvinceName;
                }

                lblPickContronCode.Text = ", " + vehcilesearchcondition.PickupISOCountryCode.Trim();
                lblPickZipCode.Text = ", " + vehcilematerial.PickupLocationDetail.Telephone;

                lblPickStree.Text = vehcilematerial.PickupLocationDetail.AddressLine.Trim();

                lblPickDateTime.Text = vehcilesearchcondition.PickupTime.ToString("ddd MMM dd, yyyy hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                string DropoffAirportCode = vehcilesearchcondition.DropoffAirportCode;

                Terms.Common.Domain.Airport dropAirport = _CommonService.FindAirportByAirportCode(DropoffAirportCode.Trim());

                lblDropCityName.Text = dropAirport.Name;
                lblDropCityCode.Text = vehcilesearchcondition.DropoffAirportCode.Trim();

                Terms.Common.Domain.Province provinceDrop = _CommonService.FindProvinceByName(dropAirport.City.ProvinceName);
                if (provinceDrop != null)
                {
                    lblDropPrCode.Text = ", " + provinceDrop.Code.Trim();
                }
                else
                {
                    //lblDropPrCode.Text = "," + dropAirport.City.ProvinceName;
                }

                lblDropContronCode.Text = ", " + vehcilesearchcondition.DropoffISOCountryCode.Trim();
                lblDropZipCode.Text = ", " + vehcilematerial.DropoffLocationDetail.Telephone;

                lblDropStree.Text = vehcilematerial.DropoffLocationDetail.AddressLine.Trim();

                lblDropDateTime.Text = vehcilesearchcondition.DropoffTime.ToString("ddd MMM dd, yyyy hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                lblDays.Text = ((TimeSpan)vehcilesearchcondition.DropoffTime.Subtract(vehcilesearchcondition.PickupTime)).Days.ToString();

                string CarSize = vehcilematerial.Vehciles.VehicleType;

                switch (CarSize)
                {
                    //case "1":
                    //    lblCarType.Text = "Mini";
                    //    break;
                    //case "2":
                    //    lblCarType.Text = "Subcompact";
                    //    break;
                    case "3":
                        lblCarType.Text = "Economy";
                        break;
                    case "4":
                        lblCarType.Text = "Compact";
                        break;
                    case "5":
                        lblCarType.Text = "Midsize";
                        break;
                    case "6":
                        lblCarType.Text = "Intermediate";
                        break;
                    case "7":
                        lblCarType.Text = "Standard";
                        break;
                    case "8":
                        lblCarType.Text = "Full Size";
                        break;
                    case "9":
                        lblCarType.Text = "Luxury";
                        break;
                    case "10":
                        lblCarType.Text = "Premium";
                        break;
                    //case "11":
                    //    lblCarType.Text = "Mini Van";
                    //    break;
                    //case "12":
                    //    lblCarType.Text = "12 passenger van";
                    //    break;
                    //case "13":
                    //    lblCarType.Text = "Moving van";
                    //    break;
                    //case "14":
                    //    lblCarType.Text = "15 passenger van";
                    //    break;
                    //case "15":
                    //    lblCarType.Text = "Cargo van";
                    //    break;
                    //case "16":
                    //    lblCarType.Text = "12 foot truck";
                    //    break;
                    //case "17":
                    //    lblCarType.Text = "20 foot truck";
                    //    break;
                    //case "18":
                    //    lblCarType.Text = "24 foot truck";
                    //    break;
                    //case "19":
                    //    lblCarType.Text = "26 foot truck";
                    //    break;
                    //case "20":
                    //    lblCarType.Text = "Moped";
                    //    break;
                    //case "21":
                    //    lblCarType.Text = "Stretch";
                    //    break;
                    //case "22":
                    //    lblCarType.Text = "Regular";
                    //    break;
                    //case "23":
                    //    lblCarType.Text = "Unique";
                    //    break;
                    //case "24":
                    //    lblCarType.Text = "Exotic";
                    //    break;
                    //case "25":
                    //    lblCarType.Text = "Small/medium truck";
                    //    break;
                    //case "26":
                    //    lblCarType.Text = "Large truck";
                    //    break;
                    //case "27":
                    //    lblCarType.Text = "Small SUV";
                    //    break;
                    //case "28":
                    //    lblCarType.Text = "Medium SUV";
                    //    break;
                    //case "29":
                    //    lblCarType.Text = "Large SUV";
                    //    break;
                    //case "30":
                    //    lblCarType.Text = "Exotic SUV";
                    //    break;
                    //case "31":
                    //    lblCarType.Text = "Four wheel drive";
                    //    break;
                    case "32":
                        lblCarType.Text = "Specialty Car";
                        break;
                    //case "33":
                    //    lblCarType.Text = "Mini elite";
                    //    break;
                    //case "34":
                    //    lblCarType.Text = "Economy elite";
                    //    break;
                    //case "35":
                    //    lblCarType.Text = "Compact elite";
                    //    break;
                    //case "36":
                    //    lblCarType.Text = "Intermediate elite";
                    //    break;
                    //case "37":
                    //    lblCarType.Text = "Standard elite";
                    //    break;
                    //case "38":
                    //    lblCarType.Text = "Fullsize elite";
                    //    break;
                    //case "39":
                    //    lblCarType.Text = "Premium elite";
                    //    break;
                    //case "40":
                    //    lblCarType.Text = "Luxury elite";
                    //    break;
                    //case "41":
                    //    lblCarType.Text = "Oversize";
                    //    break;
                    case "M2":
                        lblCarType.Text = "Minivan";
                        break;
                    case "M3":
                        lblCarType.Text = "SUV";
                        break;
                    case "M4":
                        lblCarType.Text = "Convertible";
                        break;
                }
            }
        }
    }

    public string VendorCode
    {
        get
        {
            return Request.Params["VendorCode"];
        }
    }

    public string CarCode
    {
        get
        {
            return Request.Params["CarCode"];
        }
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("VehcileInfoViewForm.aspx?VendorCode=" + VendorCode + "&CarCode=" + CarCode + "&ConditionID=" + Request.Params["ConditionID"]);
    }
}