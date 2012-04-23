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


public partial class VehcileAttachmentInfoControl : SalesBaseUserControl
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

    private void Bind()
    {
        VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

        VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

        for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
        {
            VehcileMaterial vehcilematerial = (TERMS.Business.Centers.ProductCenter.Components.VehcileMaterial)m_SaleMerchandise.Items[i];
                        
            if (vehcilematerial.VendorCode == VendorCode && vehcilematerial.Vehciles.MakeModelCode == CarCode)
            {
                List<string> ints = new List<string>();

                for (int z = 0; z < ((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments.Count; z++)
                {
                    if (((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[z].CalculationList != null && ((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[z].CalculationList.Count > 0)
                    {
                        ints.Add(((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[z].Type);
                    }
                }

                dlEquipments.DataSource = ints;
                dlEquipments.DataBind();

                int index = ((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments.Count;
                
                List<int> codes = new List<int>();

                for (int dindex = 0; dindex < ints.Count; dindex++)
                {
                    for (int z = 0; z < index; z++)
                    {
                        if (((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[z].Type == ints[dindex])
                        {

                            Label lblEquipmentsName = (Label)dlEquipments.Items[dindex].FindControl("lblEquipmentsName");
                            Label lblEquipmentsPrice = (Label)dlEquipments.Items[dindex].FindControl("lblEquipmentsPrice");
                            Label lblEquipmentsCode = (Label)dlEquipments.Items[dindex].FindControl("lblEquipmentsCode");
                            CheckBox cbEquipments = (CheckBox)dlEquipments.Items[dindex].FindControl("cbEquipments");

                            Label lblEquipmentsMaxPrice = (Label)dlEquipments.Items[dindex].FindControl("lblEquipmentsMaxPrice");
                            Label lblEquipmentsWeekPrice = (Label)dlEquipments.Items[dindex].FindControl("lblEquipmentsWeekPrice");
                            Label lblEquipmentsDayPrice = (Label)dlEquipments.Items[dindex].FindControl("lblEquipmentsDayPrice");
                            Label lblEquipmentsMonthPrice = (Label)dlEquipments.Items[dindex].FindControl("lblEquipmentsMonthPrice");

                            lblEquipmentsName.Text = ConvertSpecialEquipment(((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[z].Type);
                            lblEquipmentsCode.Text = ((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[z].Type;

                            List<string> EquipmentsPrices = new List<string>();


                            lblEquipmentsPrice.Text = "0.00";

                            ReturnPrice(((CarRentalVendor)vehcilematerial.Vendor).SpecialEquipments[z], lblEquipmentsPrice);

                            if (EquipmentsPrices.Count > 0)
                            {
                                lblEquipmentsName.Text += @" (" + string.Join("; ", EquipmentsPrices.ToArray()) + @")";
                            }

                            cbEquipments.Attributes.Add("onclick", "fillMarkup(" + cbEquipments.ClientID  + ")");
                        }
                    }
                }
            }
        }
    }

    public bool AddSpecial(out string error)
    {
        error = string.Empty;

        bool reslut = true;

        VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

        VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

        for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
        {
            VehcileMaterial vehcilematerial = (VehcileMaterial)m_SaleMerchandise.Items[i];

            if (vehcilematerial.VendorCode == VendorCode && vehcilematerial.Vehciles.MakeModelCode == CarCode)
            {
                vehcilematerial.SpecialCodes = new List<string>();

                for (int index = 0; index < dlEquipments.Items.Count; index++)
                {
                    CheckBox cbEquipments = (CheckBox)dlEquipments.Items[index].FindControl("cbEquipments");

                    if (cbEquipments.Checked)
                    {
                        Label lblEquipmentsCode = (Label)dlEquipments.Items[index].FindControl("lblEquipmentsCode");

                        vehcilematerial.SpecialCodes.Add(lblEquipmentsCode.Text);
                    }
                }
            }
        }

        return reslut;
    }

    private void ReturnPrice(SpecialEquipment equipment, Label equipmentsprice)
    {
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
                equipmentsprice.Text = "$" + decMax.ToString("N2");
            }
            else
            {
                equipmentsprice.Text = "$" + (decMax * (indexMonth + 1)).ToString("N2");
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
                        equipmentsprice.Text = "$" + decWeek.ToString("N2");
                    }
                    else
                    {
                        equipmentsprice.Text = "$" + (days * decDay).ToString("N2");
                    }
                }
                else
                {
                    if (days * decDay > decMax)
                    {
                        equipmentsprice.Text = "$" + decMax.ToString("N2");
                    }
                    else
                    {
                        equipmentsprice.Text = "$" + (days * decDay).ToString("N2");
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
                        equipmentsprice.Text = "$" + decMax.ToString("N2");
                    }
                    else
                    {
                        equipmentsprice.Text = "$" + (decWeek * indexWeek + decDay * modWeek).ToString("N2");
                    }
                }
                else
                {
                    if (days * decDay > decMax)
                    {
                        equipmentsprice.Text = "$" + decMax.ToString("N2");
                    }
                    else
                    {
                        equipmentsprice.Text = "$" + (days * decDay).ToString("N2");
                    }
                }
            }
            else
            {
                if (decMonth > 0)
                {
                    equipmentsprice.Text = "$" + decMax.ToString("N2");
                }
                else
                {
                    int indexMonth = days / 30;

                    int modMonth = days % 30;

                    int indexWeek = modMonth / 7;

                    int modWeek = modMonth % 7;

                    if (decDay * modMonth > decMax)
                    {
                        equipmentsprice.Text = "$" + (decMax * indexMonth + decMax).ToString("N2");
                    }
                    else
                    {
                        equipmentsprice.Text = "$" + (decMax * indexMonth + decDay * modMonth).ToString("N2");
                    }
                }
            }
        }
    }
}