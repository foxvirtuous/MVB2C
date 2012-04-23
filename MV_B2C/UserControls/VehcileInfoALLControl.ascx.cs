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
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;


public partial class VehcileInfoALLControl : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (!IsPostBack)
        {
            VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

            if (vehcilesearchcondition.PickupLocation != null && vehcilesearchcondition.PickupLocation.Trim().Length > 0)
            {
                lblDayNumber.Text = vehcilesearchcondition.PickupLocation;
            }
            else
            {
                lblDayNumber.Text = vehcilesearchcondition.PickupAirportCode;
            }

            lblPackup.Text = vehcilesearchcondition.PickupTime.ToString("MM/dd/yyyy HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            lblDropoff.Text = vehcilesearchcondition.DropoffTime.ToString("MM/dd/yyyy HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            lblDays.Text = ((TimeSpan)vehcilesearchcondition.DropoffTime.Subtract(vehcilesearchcondition.PickupTime)).Days.ToString() + " Days";

            VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

            for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
            {
                VehcileMaterial vehcilematerial = (VehcileMaterial)m_SaleMerchandise.Items[i];

                if (vehcilematerial.VendorCode == VendorCode && vehcilematerial.Vehciles.MakeModelCode == CarCode)
                {
                    if (vehcilematerial.SpecialCodes != null && vehcilematerial.SpecialCodes.Count > 0)
                    {
                        divSpecialEquipment.Visible = true;

                        List<string> SpecialEquipments = new List<string>();

                        for (int count = 0; count < vehcilematerial.SpecialCodes.Count; count++)
                        {
                            SpecialEquipments.Add(ConvertSpecialEquipment(vehcilematerial.SpecialCodes[count]));
                        }

                        lblSpecialEquipment.Text = string.Join(", ", SpecialEquipments.ToArray());
                    }

                    lblCarType.Text = vehcilematerial.VendorName;
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

    private string ConvertSpecialEquipment(string type)
    {
        string SpecialEquipment = string.Empty;

        switch (type)
        {
            case "1":
                SpecialEquipment = "Mobile phone";
                break;
            case "2":
                SpecialEquipment = "Bike rack";
                break;
            case "3":
                SpecialEquipment = "Luggage rack";
                break;
            case "4":
                SpecialEquipment = "Ski rack";
                break;
            case "5":
                SpecialEquipment = "Trailer hitch";
                break;
            case "6":
                SpecialEquipment = "Automatic locks";
                break;
            case "7":
                SpecialEquipment = "Infant child seat";
                break;
            case "8":
                SpecialEquipment = "Child toddler seat";
                break;
            case "9":
                SpecialEquipment = "Booster seat";
                break;
            case "10":
                SpecialEquipment = "Snow chains";
                break;
            case "11":
                SpecialEquipment = "Hand control right";
                break;
            case "12":
                SpecialEquipment = "Hand control left";
                break;
            case "13":
                SpecialEquipment = "Navigational system";
                break;
            case "14":
                SpecialEquipment = "Snow tires";
                break;
            case "15":
                SpecialEquipment = "Baby stroller";
                break;
            case "16":
                SpecialEquipment = "1DVD player monitor";
                break;
            case "17":
                SpecialEquipment = "VCR player monitor";
                break;
            case "18":
                SpecialEquipment = "Spinner knob";
                break;
            case "19":
                SpecialEquipment = "Furniture pads";
                break;
            case "20":
                SpecialEquipment = "Car dolly";
                break;
            case "21":
                SpecialEquipment = "Auto transport";
                break;
            case "22":
                SpecialEquipment = "Hand truck";
                break;
            case "23":
                SpecialEquipment = "Cargo barrier front";
                break;
            case "24":
                SpecialEquipment = "Cargo barrier rear";
                break;
            case "25":
                SpecialEquipment = "Luggage trailer";
                break;
            case "26":
                SpecialEquipment = "Camping equipment";
                break;
            case "27":
                SpecialEquipment = "Satellite radio";
                break;
            case "28":
                SpecialEquipment = "Wheelchair accessible van";
                break;
            case "29":
                SpecialEquipment = "Seat belt extensions";
                break;
            case "30":
                SpecialEquipment = "Winter package";
                break;
            case "31":
                SpecialEquipment = "Citizen band radio";
                break;
            case "32":
                SpecialEquipment = "Computerized directions";
                break;
            case "33":
                SpecialEquipment = "FM radio";
                break;
            case "34":
                SpecialEquipment = "Navigational phone";
                break;
            case "35":
                SpecialEquipment = "Ski rental";
                break;
            case "36":
                SpecialEquipment = "Ski equipped";
                break;
            case "37":
                SpecialEquipment = "Cassette player";
                break;
            case "38":
                SpecialEquipment = "Television";
                break;
            case "39":
                SpecialEquipment = "Other";
                break;
            case "40":
                SpecialEquipment = "Portable DVD/CD/picture player";
                break;
            case "52":
                SpecialEquipment = "Toll Pass Device";
                break;
            case "59":
                SpecialEquipment = "Carbon Offset";
                break;
        }

        return SpecialEquipment;
    }
}