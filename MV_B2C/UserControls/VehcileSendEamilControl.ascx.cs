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
using System.Collections.Generic;

namespace Terms.Web.UserControls
{
    public partial class VehcileSendEamilControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VehcileInfoControl1.Flag = false;
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
                TERMS.Business.Centers.SalesCenter.Passenger passenger = (TERMS.Business.Centers.SalesCenter.Passenger)Utility.Transaction.CurrentTransactionObject.GetPassengers() [0];

                switch (passenger.Salutationn)
                { 
                    case TERMS.Common.Salutation.Dr:
                        lblSex.Text = "Mr";
                        break;
                    case TERMS.Common.Salutation.Miss:
                        lblSex.Text = "Miss";
                        break;
                    case TERMS.Common.Salutation.Mr:
                        lblSex.Text = "Mr";
                        break;
                    case TERMS.Common.Salutation.Mrs:
                        lblSex.Text = "Mrs";
                        break;
                    case TERMS.Common.Salutation.Ms:
                        lblSex.Text = "Ms";
                        break;
                    case TERMS.Common.Salutation.None:
                        lblSex.Text = "";
                        break;
                    case TERMS.Common.Salutation.Rev:
                        lblSex.Text = "Rev";
                        break;
                }

                lblFrist.Text = passenger.FirstName;
                lblLast.Text = passenger.LastName;
                lblMiddle.Text = passenger.MiddleName;
            }

            if (Utility.Transaction.CurrentTransactionObject.GetContacts() != null && Utility.Transaction.CurrentTransactionObject.GetContacts().Count > 0)
            {
                Contact contact = (Contact)Utility.Transaction.CurrentTransactionObject.GetContacts()[0];

                lblCity.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).City.Name;
                lblCountry.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).City.Country.Name;
                lblEmail.Text = contact.Person.Email;
                lblPhone.Text = contact.Person.GetPhone(TERMS.Common.ContactOptions.DayTime).Number;
                lblState.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).City.ProvinceName;
                lbltxtAddress1.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).AddressString;
                lbltxtContactFirst.Text = contact.Person.FirstName;
                lbltxtContactLast.Text = contact.Person.LastName;
                lbltxtContactMiddle.Text = contact.Person.MiddleName;
                lblZip.Text = contact.Person.GetAddress(TERMS.Common.ContactOptions.DayTime).ZipCode;
            }
        }
    }    
}