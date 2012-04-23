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
using Terms.Sales.Service;
using TERMS.Business.Centers.SalesCenter;
using System.Net.Mail;
using TurboTT.Security;
using Spring.Context.Support;
using System.IO;
using System.Collections.Generic;


public partial class HotelVoucherForm : SalseBasePage
{
    private IOPSaleOrderService _OPSaleOrderService;
    public IOPSaleOrderService OPSaleOrderService
    {
        set { this._OPSaleOrderService = value; }
    }

    private string _returnUrl = string.Empty;
    public string ReturnURL
    {
        get
        {
            return _returnUrl;
        }
        set
        {
            _returnUrl = value;
        }
    }

    private string _OrderID = string.Empty;

    public string OrderID
    {
        get
        {
            if (string.IsNullOrEmpty(_OrderID))
            {
                string strTemp = System.Web.HttpContext.Current.Request["OrderId"];

                if (string.IsNullOrEmpty(strTemp))
                {
                    strTemp = string.Empty;
                }
                else
                {
                    _OrderID = strTemp;
                }
            }

            return _OrderID;
        }
        set
        {
            _OrderID = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        BtnPrint.Attributes["onClick"] = "javascript:doPrint();return true;";
        if (Request.QueryString["ReturnURL"] != null)
        {
            ReturnURL = Request.QueryString["ReturnURL"];

        }
        if (Request.QueryString["OrderId"] != null)
        {
            OrderID = this.Request["OrderId"].ToString();

        }
        if (!IsPostBack)
        {
            BinderInfo();
        }
    }

    private void BinderInfo()
    {
        IOPSaleOrderService opSaleOrderService = ContextRegistry.GetContext()["OPSaleOrderService"] as IOPSaleOrderService;

        Utility.Transaction.CurrentTransactionObject = opSaleOrderService.GetTransactionObject(OrderID);

        if (Utility.Transaction.CurrentTransactionObject != null)
        {
            int Rooms = 0;

            List<string> roomType = new List<string>();

            List<int> roomNumber = new List<int>();

            foreach (OrderItem item in Utility.Transaction.CurrentTransactionObject.Items)
            {
                if (item is PackageOrderItem)
                {
                    foreach (OrderItem orderitem in item.Items)
                    {
                        if (orderitem is HotelOrderItem)
                        {
                            if (((HotelOrderItem)orderitem).Room.Hotel.HotelCode == Request.QueryString["HotelCode"])
                            {
                                this.lbHotelName.Text = ((HotelOrderItem)orderitem).Room.Hotel.Name;
                                this.lbHotelTel.Text = ((HotelOrderItem)orderitem).Room.Hotel.Telephone;
                                this.lbInvoiceNo.Text = Utility.Transaction.CurrentTransactionObject.InvoiceNumber;
                                this.lbNights.Text = ((HotelOrderItem)orderitem).Nights.ToString() + " Nights";
                                this.lbTypeRoom.Text = ((HotelOrderItem)orderitem).Room.Name;
                                this.lbNORoom.Text = ((HotelOrderItem)orderitem).Room.RoomAmount.ToString();
                                this.lbCaseNo.Text = Utility.Transaction.CurrentTransactionObject.CaseNumber;
                                this.lbAddress.Text = ((HotelOrderItem)orderitem).Room.Hotel.Address;
                                this.lbCheckInOut.Text = ((HotelOrderItem)orderitem).CheckIn.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " / " + ((HotelOrderItem)orderitem).CheckOut.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                                this.lbBreakfast.Text = "include";
                                this.lbIssueDate.Text = DateTime.Now.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                                this.lbIssueDate1.Text = DateTime.Now.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                                if (((HotelOrderItem)orderitem).Profile.GetParam("Token") != null)
                                {
                                    lbCommission.Text = orderitem.Profile.GetParam("Token").ToString();
                                }
                                else if (orderitem.Profile.GetParam("RoomRefNumber") != null)
                                {
                                    lbCommission.Text = orderitem.Profile.GetParam("RoomRefNumber").ToString();
                                }


                                int i = 0;
                                foreach (Passenger pass in Utility.Transaction.CurrentTransactionObject.GetPassengers())
                                {
                                    string middleName = "";
                                    if (pass.MiddleName != "")
                                    {
                                        middleName = "." + pass.MiddleName;
                                    }
                                    if (i == 0)
                                    {
                                        this.lbGuestName.Text += pass.LastName + "/" + pass.FirstName + middleName;
                                    }
                                    else
                                    {
                                        this.lbGuestName.Text += "<br> " + pass.LastName + "/" + pass.FirstName + middleName;
                                    }
                                    i++;
                                }

                                LbNOGuest.Text = Convert.ToString(i);

                                if (((HotelOrderItem)orderitem).Profile.GetParam("DATASOURCE") == "GTA")
                                {
                                    this.pEmergencyTels.Visible = true;
                                    this.lblCountryCode.Text = ((HotelOrderItem)orderitem).Room.Hotel.City.CountryCode;
                                    this.lblOfficeCity.Text = ((HotelOrderItem)orderitem).Room.Hotel.City.Name;
                                    this.lblPhone.Text = ((HotelOrderItem)orderitem).Room.Hotel.Telephone;
                                }
                                else
                                {
                                    this.pEmergencyTels.Visible = false;
                                }
                            }

                        }
                    }
                }
                if (item is HotelOrderItem)
                {
                    if (((HotelOrderItem)item).Room.Hotel.HotelCode == Request.QueryString["HotelCode"] && ((HotelOrderItem)item).CheckIn.ToString("MM/dd/yyyy") == Request.QueryString["Checkin"])
                    {
                    //if (((HotelOrderItem)item).Room.Hotel.HotelCode == Request.QueryString["HotelCode"])
                    //{
                        this.lbHotelName.Text = ((HotelOrderItem)item).Room.Hotel.Name;
                        if (((HotelOrderItem)item).Room.Hotel.Telephone != null)
                        {
                            this.lbHotelTel.Text = ((HotelOrderItem)item).Room.Hotel.Telephone;
                        }
                        else
                        {
                            this.lbHotelTel.Text = "N/A";
                        }
                        //this.lbHotelTel.Text = ((HotelOrderItem)item).Room.Hotel.Telephone;

                        this.lbInvoiceNo.Text = Utility.Transaction.CurrentTransactionObject.InvoiceNumber;
                        this.lbNights.Text = ((HotelOrderItem)item).Nights.ToString() + " Nights";

                        roomType.Add(((HotelOrderItem)item).Room.Name);

                        //this.lbTypeRoom.Text = ((HotelOrderItem)item).Room.Name;
                        this.lbNORoom.Text = (Convert.ToInt32(this.lbNORoom.Text) + (int)((HotelOrderItem)item).Room.RoomAmount).ToString();
                        //this.lbNORoom.Text = ((HotelOrderItem)item).Room.RoomAmount.ToString();
                        this.lbCaseNo.Text = Utility.Transaction.CurrentTransactionObject.CaseNumber;
                        this.lbAddress.Text = ((HotelOrderItem)item).Room.Hotel.Address;
                        this.lbCheckInOut.Text = ((HotelOrderItem)item).CheckIn.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " / " + ((HotelOrderItem)item).CheckOut.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                        if (((HotelOrderItem)item).IsBuyBreakfast)
                        {
                            if (string.IsNullOrEmpty(this.lbBreakfast.Text))
                            {
                                this.lbBreakfast.Text += "Include";
                            }
                            else
                            {
                                this.lbBreakfast.Text += "<br>" + "Include";
                            }
                        }
                        else
                        {
                            if (((HotelOrderItem)item).IncluedBreakfastQuantity == 0 && ((HotelOrderItem)item).BreakfastPricePerPersonPerDay == 0)
                            {
                                if (string.IsNullOrEmpty(this.lbBreakfast.Text))
                                {
                                    this.lbBreakfast.Text += "No include";
                                }
                                else
                                {
                                    this.lbBreakfast.Text += "<br>" + "No include";
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(this.lbBreakfast.Text))
                                {
                                    this.lbBreakfast.Text += "Include";
                                }
                                else
                                {
                                    this.lbBreakfast.Text += "<br>" + "Include";
                                }
                            }
                        }
                        
                        
                        //this.lbBreakfast.Text = "include";
                        this.lbIssueDate.Text = DateTime.Now.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        this.lbIssueDate1.Text = DateTime.Now.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        //int i = 0;

                        if (((HotelOrderItem)item).Profile.GetParam("Token") != null)
                        {
                            lbCommission.Text = item.Profile.GetParam("Token").ToString();
                        }
                        else if (item.Profile.GetParam("RoomRefNumber") != null)
                        {
                            lbCommission.Text = item.Profile.GetParam("RoomRefNumber").ToString();
                        }

                        //foreach (Passenger pass in Utility.Transaction.CurrentTransactionObject.GetPassengers())
                        //{
                        //    string middleName = "";
                        //    if (pass.MiddleName != "")
                        //    {
                        //        middleName = "." + pass.MiddleName;
                        //    }
                        //    if (i == 0)
                        //    {
                        //        this.lbGuestName.Text += pass.LastName + "/" + pass.FirstName + middleName;
                        //    }
                        //    else
                        //    {
                        //        this.lbGuestName.Text += "<br> " + pass.LastName + "/" + pass.FirstName + middleName;
                        //    }
                        //    i++;
                        //}

                        //LbNOGuest.Text = Convert.ToString(i);

                        if (((HotelOrderItem)item).Profile.GetParam("DATASOURCE").ToString() == "GTA")
                        {
                            this.pEmergencyTels.Visible = true;
                            this.lblCountryCode.Text = ((HotelOrderItem)item).Room.Hotel.City.CountryCode;
                            this.lblOfficeCity.Text = ((HotelOrderItem)item).Room.Hotel.City.Name;
                            this.lblPhone.Text = ((HotelOrderItem)item).Room.Hotel.Telephone;
                        }
                        else
                        {
                            this.pEmergencyTels.Visible = false;
                        }
                    }
                }
            }

            List<string> roomname = new List<string>();

            if (roomType.Count > 0)
            {
                for (int i = 0; i < roomType.Count; i++)
                {
                    for (int j = 0; j < roomname.Count; j++)
                    {
                        if (!roomname.Contains(roomType[i]))
                        {
                            roomname.Add(roomType[i]);
                            roomNumber.Add(1);
                            break;
                        }
                        else
                        {
                            roomNumber[j] = roomNumber[j] + 1;
                            break;
                        }
                    }

                    if (roomname.Count == 0)
                    {
                        roomname.Add(roomType[i]);
                        roomNumber.Add(1);
                    }
                }
            }

            for (int i = 0; i < roomname.Count; i++)
            {
                if (string.IsNullOrEmpty(this.lbTypeRoom.Text))
                {
                    this.lbTypeRoom.Text += roomname[i] + " x " + roomNumber[i].ToString();
                }
                else
                {
                    this.lbTypeRoom.Text += "<br>" + roomname[i] + " x " + roomNumber[i].ToString();
                }
            }

            foreach (Passenger pass in Utility.Transaction.CurrentTransactionObject.GetPassengers())
            {
                string middleName = "";
                if (pass.MiddleName != "")
                {
                    middleName = "." + pass.MiddleName;
                }
                if (this.lbGuestName.Text.Trim().Length == 0)
                {
                    this.lbGuestName.Text += pass.LastName + "/" + pass.FirstName + middleName;
                }
                else
                {
                    this.lbGuestName.Text += "<br> " + pass.LastName + "/" + pass.FirstName + middleName;
                }
            }

            LbNOGuest.Text = Utility.Transaction.CurrentTransactionObject.GetPassengers().Count.ToString();
        }
    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
        mailMessage.To.Add(new MailAddress(this.txtEmail.Text.Trim()));
        mailMessage.IsBodyHtml = true;
        mailMessage.Subject = "Hotel Voucher - " + lbCaseNo.Text.Trim();

        string mailContent = txtFormContent.Value;

        String note = @"<TABLE cellSpacing='0' cellPadding='2' width='630' align='center' border='0' ID='Table1'><TR><TD class='flittle' align='left'><strong>Please Note: <br>1. The date format on this form is mm/dd/yyyy.<br>2. This is an automatically generated e-mail, please do not reply to this email address.</strong></TD></TR></TABLE>";
        String style = "<STYLE> #lie { BORDER-RIGHT: #000000 2px solid } #lie2 { BORDER-RIGHT: #000000 2px solid; BORDER-BOTTOM: #000000 2px solid }";
        style += " #lie3 { BORDER-BOTTOM: #000000 2px solid } .Maj_title { FONT-WEIGHT: 900; FONT-SIZE: 30px; COLOR: #000000; FONT-FAMILY: Pristina }";
        style += " #lei { BORDER-BOTTOM: #000000 2px solid } .f_title { FONT-WEIGHT: 700; FONT-SIZE: 16px; FONT-FAMILY: Arial }";
        style += " .flittle { FONT-SIZE: 12px; FONT-FAMILY: Arial } .f { FONT-SIZE: 13px; FONT-FAMILY: Arial }";
        style += " .f_price { FONT-WEIGHT: 700; FONT-SIZE: 16px; COLOR: #ff0000; FONT-FAMILY: Arial } .f_name { FONT-WEIGHT: 700; FONT-SIZE: 16px; COLOR: #000000; FONT-FAMILY: Arial }";
        style += " .table { BORDER-RIGHT: #000000 2px solid; BORDER-TOP: #000000 2px solid; BORDER-LEFT: #000000 2px solid; BORDER-BOTTOM: #000000 2px solid } </STYLE>";
        mailMessage.Body = style + mailContent + note;

#if DEBUG
        try
        {
            using (StreamWriter sw = File.CreateText("C:\\OrderEmail\\HotelVouch.html"))
            {
                sw.Write(mailMessage.Body);
            }
        }
        catch
        {
            //·ÀÖ¹Î´×¢ÊÍ±»XXX±©Í·
        }
#endif

        Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Package");

        _OPSaleOrderService.UpdateOperationalRecords(Utility.Transaction.CurrentTransactionObject.PaymentStatus.ToString(), Utility.Transaction.CurrentTransactionObject.PaymentStatus.ToString(),
            Utility.Transaction.CurrentTransactionObject.OPStatus.ToString(), Utility.Transaction.CurrentTransactionObject.OPStatus.ToString(), Utility.Transaction.Member.FirstName + " " + Utility.Transaction.Member.LastName, OrderID, "Send Voucher");

        Response.Redirect(ReturnURL + "?OrderID=" + OrderID);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(ReturnURL + "?OrderID=" + OrderID);
    }
}
