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
using TERMS.Common;


public partial class VehcilePriceInfoControl : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (!IsPostBack)
        {
            Bind();
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

    private void Bind()
    {
        VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

        VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

        for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
        {
            VehcileMaterial vehcilematerial = (TERMS.Business.Centers.ProductCenter.Components.VehcileMaterial)m_SaleMerchandise.Items[i];

            if (vehcilematerial.VendorCode == VendorCode && vehcilematerial.Vehciles.MakeModelCode == CarCode)
            {
                decimal decSpecial = decimal.Zero;

                if (vehcilematerial.SpecialCodes != null && vehcilematerial.SpecialCodes.Count > 0)
                {
                    int index = ((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments.Count;

                    string teble = string.Empty;

                    for (int count = 0; count < index; count++)
                    {
                        string SpecialCode = ((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[count].Type;

                        if (vehcilematerial.SpecialCodes.Contains(SpecialCode))
                        {
                            teble = teble + "<table width='100%' align='center' border='0' cellpadding='0' cellspacing='0'>";
                            teble = teble + "<tbody><tr valign='top' align='left'><td width='50%' height='20' align='left' style='border-bottom: solid #cccccc 1px;'>";
                            teble = teble + "<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td width='50%' height='30' align='left'>";
                            teble = teble + ConvertSpecialEquipment(((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[count].Type) + "</td><td align='right'>";

                            if (((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[count].CalculationList != null && ((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[count].CalculationList.Count > 0)
                            {
                                teble = teble + "$" + ReturnPrice(((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[count]).ToString("N2");

                                decSpecial += ReturnPrice(((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[count]);
                            }
                            else
                            {
                                teble = teble + "free";
                            }

                            teble = teble + "</td></tr></table></td></tr></tbody></table>";
                        }
                    }

                    lblEquipments.Text = teble;
                }



                int days = ((TimeSpan)vehcilesearchcondition.DropoffTime.Subtract(vehcilesearchcondition.PickupTime)).Days;
                lblDays.Text = days.ToString();
                lblDailyRate.Text = (vehcilematerial.GetTotalPrice(vehcilesearchcondition.PickupTime, vehcilesearchcondition.DropoffTime).GetAmount(PassengerType.Adult) / days).ToString("N2");
                lblEstamatedTotal.Text = (vehcilematerial.GetTotalPrice(vehcilesearchcondition.PickupTime, vehcilesearchcondition.DropoffTime).GetAmount(PassengerType.Adult)).ToString("N2");
                lblTotalPrice.Text = (vehcilematerial.GetTotalPrice(vehcilesearchcondition.PickupTime, vehcilesearchcondition.DropoffTime).GetAmount(PassengerType.Adult) + decSpecial).ToString("N2");
            }
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

    private decimal ReturnPrice(SpecialEquipment equipment)
    {
        decimal reslut = decimal.Zero;

        VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

        int days = ((TimeSpan)vehcilesearchcondition.DropoffTime.Subtract(vehcilesearchcondition.PickupTime)).Days;

        decimal decDay = decimal.Zero;
        decimal decWeek = decimal.Zero;
        decimal decMonth = decimal.Zero;
        decimal decMax = decimal.Zero;

        for (int count = 0; count < equipment.CalculationList.Count; count++)
        {
            if (equipment.CalculationList[count].UnitName == "RentalPeriod")
            {
                decMax = Convert.ToDecimal(equipment.CalculationList[count].UnitCharge);
            }
            else if (equipment.CalculationList[count].UnitName == "Week")
            {
                decWeek = Convert.ToDecimal(equipment.CalculationList[count].UnitCharge);
            }
            else if (equipment.CalculationList[count].UnitName == "Day")
            {
                decDay = Convert.ToDecimal(equipment.CalculationList[count].UnitCharge);
            }
            else if (equipment.CalculationList[count].UnitName == "Month")
            {
                decMonth = Convert.ToDecimal(equipment.CalculationList[count].UnitCharge);
            }
        }

        if (decDay == decimal.Zero && decWeek == decimal.Zero && decMonth == decimal.Zero && decMax != decimal.Zero)
        {
            int indexMonth = days / 30;

            int modMonth = days % 30;

            if (indexMonth <= 1 && modMonth == 0)
            {
                reslut = decMax;
            }
            else
            {
                reslut = (decMax * (indexMonth + 1));
            }
        }
        else
        {
            if (days < 7)
            {
                if (decWeek > 0)
                {
                    if (days * decDay > decWeek)
                    {
                        reslut = decWeek;
                    }
                    else
                    {
                        reslut = (days * decDay);
                    }
                }
                else
                {
                    if (days * decDay > decMax)
                    {
                        reslut = decMax;
                    }
                    else
                    {
                        reslut = (days * decDay);
                    }
                }
            }
            else if (days < 30)
            {
                if (decWeek > 0)
                {
                    int indexWeek = days / 7;

                    int modWeek = days % 7;

                    if ((decWeek * indexWeek + days * modWeek) > decMax)
                    {
                        reslut = decMax;
                    }
                    else
                    {
                        reslut = (decWeek * indexWeek + decDay * modWeek);
                    }
                }
                else
                {
                    if (days * decDay > decMax)
                    {
                        reslut = decMax;
                    }
                    else
                    {
                        reslut = (days * decDay);
                    }
                }
            }
            else
            {
                if (decMonth > 0)
                {
                    reslut = decMax;
                }
                else
                {
                    int indexMonth = days / 30;

                    int modMonth = days % 30;

                    int indexWeek = modMonth / 7;

                    int modWeek = modMonth % 7;

                    if (decDay * modMonth > decMax)
                    {
                        reslut= (decMax * indexMonth + decMax);
                    }
                    else
                    {
                        reslut= (decMax * indexMonth + decDay * modMonth);
                    }
                }
            }
        }

        return reslut;
    }
}