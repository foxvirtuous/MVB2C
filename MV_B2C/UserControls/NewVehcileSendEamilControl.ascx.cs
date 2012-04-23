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
using Terms.Common.Service;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;

namespace Terms.Web.UserControls
{
    public partial class NewVehcileSendEamilControl : SalesBaseUserControl
    {
        private ICommonService _CommonService;

        public ICommonService CommonService
        {
            set
            {
                this._CommonService = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarInfo();
            }

            if (Utility.IsSubAgent)
            {
                string Handler;

                if (Utility.Transaction.Member.Handler == null || Utility.Transaction.Member.Handler.Trim().Length == 0)
                {
                    Handler = "DEFAULT";
                }
                else
                {
                    Handler = Utility.Transaction.Member.Handler;
                }

                List<Terms.Member.Utility.HandlerReceiver> Citys = Terms.Member.Utility.MemberUtility.GetHandlerReciever();

                for (int i = 0; i < Citys.Count; i++)
                {
                    if (Citys[i].Name.Trim().ToUpper() == Handler.Trim().ToUpper())
                    {
                        lblSalesName.Text = Citys[i].SalesName.Replace(",", " or ");
                        lblSalesEmail.Text = @"<a href='#' class='d07'>" + Citys[i].SalesEmail.Replace(",", @"</a> or <a href='#' class='d07'>") + @"</a>";
                    }
                }
            }
            else
            {
                lblSalesName.Text = "Garfield Zhang";
                lblSalesEmail.Text = @"<a href='#' class='d07'>gzhang@majestic-vacations.com</a>";
            }
        }

        public void AddItems()
        {
            if (Utility.Transaction.CurrentTransactionObject.GetPassengers() != null && Utility.Transaction.CurrentTransactionObject.GetPassengers().Count > 0)
            {
                TERMS.Business.Centers.SalesCenter.Passenger passenger = (TERMS.Business.Centers.SalesCenter.Passenger)Utility.Transaction.CurrentTransactionObject.GetPassengers()[0];

                switch (passenger.Salutationn)
                {
                    case TERMS.Common.Salutation.Dr:
                        lblTitle.Text = "Mr";
                        break;
                    case TERMS.Common.Salutation.Miss:
                        lblTitle.Text = "Miss";
                        break;
                    case TERMS.Common.Salutation.Mr:
                        lblTitle.Text = "Mr";
                        break;
                    case TERMS.Common.Salutation.Mrs:
                        lblTitle.Text = "Mrs";
                        break;
                    case TERMS.Common.Salutation.Ms:
                        lblTitle.Text = "Ms";
                        break;
                    case TERMS.Common.Salutation.None:
                        lblTitle.Text = @"&nbsp;";
                        break;
                    case TERMS.Common.Salutation.Rev:
                        lblTitle.Text = "Rev";
                        break;
                }

                lblFirstName.Text = passenger.FirstName;
                lblLastName.Text = passenger.LastName;
                lblMiddleName.Text = passenger.MiddleName + @"&nbsp;";
            }

            if (Utility.Transaction.CurrentTransactionObject.GetContacts() != null && Utility.Transaction.CurrentTransactionObject.GetContacts().Count > 0)
            {
                Contact contact = (Contact)Utility.Transaction.CurrentTransactionObject.GetContacts()[0];

                lblCity.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).City.Name;
                lblCountry.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).City.Country.Name;
                lblEmail.Text = contact.Person.Email;
                lblPhone.Text = contact.Person.GetPhone(TERMS.Common.ContactOptions.DayTime).Number;
                lblState.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).City.ProvinceName;
                lblAddress.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).AddressString;
                lblContactFristName.Text = contact.Person.FirstName;
                lblContactLastName.Text = contact.Person.LastName;
                lblContactMiddleName.Text = contact.Person.MiddleName + @"&nbsp;";
                lblZip.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).ZipCode;
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

        private void BindCarInfo()
        {
            VehcileSearchCondition vehcilesearchcondition = (VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions;

            VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

            for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
            {
                VehcileMaterial vehcilematerial = (VehcileMaterial)m_SaleMerchandise.Items[i];

                if (vehcilematerial.VendorCode == VendorCode && vehcilematerial.Vehciles.MakeModelCode == CarCode)
                {
                    lblCarName.Text = vehcilematerial.Vehciles.MakeModelName;

                    lblVendorName.Text = vehcilematerial.VendorName;

                    string PickupAirportCode = vehcilesearchcondition.PickupAirportCode;

                    Terms.Common.Domain.Airport pickAirport = _CommonService.FindAirportByAirportCode(PickupAirportCode.Trim());

                    lblPickCityCode.Text = ", " + vehcilesearchcondition.PickupAirportCode.Trim();
                    Terms.Common.Domain.Province provincePick = _CommonService.FindProvinceByName(pickAirport.City.ProvinceName);
                    if (provincePick != null)
                    {
                        lblPickPrCode.Text = ", " + provincePick.Code;
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

                    lblDropCityCode.Text = ", " + vehcilesearchcondition.DropoffAirportCode.Trim();
                    Terms.Common.Domain.Province provinceDrop = _CommonService.FindProvinceByName(dropAirport.City.ProvinceName);
                    if (provinceDrop != null)
                    {
                        lblDropPrCode.Text = ", " + provinceDrop.Code;
                    }
                    else
                    {
                        //lblDropPrCode.Text = ", " + dropAirport.City.ProvinceName;
                    }
                    lblDropContronCode.Text = ", " + vehcilesearchcondition.DropoffISOCountryCode.Trim();
                    lblDropZipCode.Text = ", " + vehcilematerial.DropoffLocationDetail.Telephone;
                    lblDropStree.Text = vehcilematerial.DropoffLocationDetail.AddressLine.Trim();

                    lblDropDateTime.Text = vehcilesearchcondition.DropoffTime.ToString("ddd MMM dd, yyyy hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                    lblDays.Text = ((TimeSpan)vehcilesearchcondition.DropoffTime.Subtract(vehcilesearchcondition.PickupTime)).Days.ToString();

                    string CarSize = vehcilematerial.Vehciles.VehicleType;

                    switch (CarSize)
                    {
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
                        case "32":
                            lblCarType.Text = "Specialty Car";
                            break;
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
    }
}