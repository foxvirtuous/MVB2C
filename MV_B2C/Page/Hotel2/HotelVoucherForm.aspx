<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HotelVoucherForm.aspx.cs"
    Inherits="HotelVoucherForm" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Vorcher</title>
    <style>#lie { BORDER-RIGHT: #000000 2px solid }
	#lie2 { BORDER-RIGHT: #000000 2px solid; BORDER-BOTTOM: #000000 2px solid }
	#lie3 { BORDER-BOTTOM: #000000 2px solid }
	.Maj_title { FONT-WEIGHT: 900; FONT-SIZE: 30px; COLOR: #000000; FONT-FAMILY: Times New Roman }
	#lei { BORDER-BOTTOM: #000000 2px solid }
	.f_title { FONT-WEIGHT: 700; FONT-SIZE: 16px; FONT-FAMILY: Arial }
	.flittle { FONT-SIZE: 12px; FONT-FAMILY: Arial }
	.f { FONT-SIZE: 13px; FONT-FAMILY: Arial }
	.f_price { FONT-WEIGHT: 700; FONT-SIZE: 16px; COLOR: #ff0000; FONT-FAMILY: Arial }
	.f_name { FONT-WEIGHT: 700; FONT-SIZE: 16px; COLOR: #000000; FONT-FAMILY: Arial }
	.table { BORDER-RIGHT: #000000 2px solid; BORDER-TOP: #000000 2px solid; BORDER-LEFT: #000000 2px solid; BORDER-BOTTOM: #000000 2px solid }
	</style>
    <script language="javascript">
			function doPrint(){
				document.all.NotShow.style.visibility="hidden";
				window.print();
				document.all.NotShow.style.visibility="visible";
			}
    </script>
</head>
<body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
        <table id="NotShow" cellspacing="0" cellpadding="0" width="630" align="center" border="0"
            runat="server">
            <tr>
                <td class="f">
                    Email Address:
                    <asp:TextBox ID="txtEmail" runat="server" Width="280px"></asp:TextBox><asp:Button
                        ID="btnSendEmail" runat="server" Text="Send" OnClick="btnSendEmail_Click"></asp:Button>&nbsp;
                    <asp:Button ID="BtnPrint" runat="server" Text="Print" CausesValidation="False"></asp:Button>&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click"></asp:Button><asp:Label
                        ID="lbCIUID" runat="server" Visible="False"></asp:Label><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Required"></asp:RequiredFieldValidator><input
                                id="txtFormContent" type="hidden" name="Hidden1" runat="server"></td>
            </tr>
        </table>
        <br>
        <div id="MAIL_BODY" runat="server">
            <table cellspacing="0" cellpadding="0" width="630" align="center" border="0">
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="2" width="100%" border="0">
                            <tr>
                                <td class="Maj_title" valign="top" align="center" colspan="3" height="40">
                                    HOTEL VOUCHER
                                </td>
                            </tr>
                            <tr>
                                <td class="f" width="49%">
                                    <strong>VOUCHER NO.
                                        <asp:Label ID="lbInvoiceNo" runat="server"></asp:Label></strong></td>
                                <td class="f" align="right" width="38%">
                                    <strong>ISSUE DATE: </strong>
                                </td>
                                <td class="f" align="right" width="13%">
                                    <asp:Label ID="lbIssueDate" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        <table class="table" cellspacing="0" cellpadding="2" width="100%" border="0">
                            <tr class="f_title" align="center">
                                <td id="lie" colspan="2" height="35">
                                    Hotel Name:
                                </td>
                                <td id="lie" colspan="2">
                                    Guest Names:
                                </td>
                                <td id="lie" width="130">
                                    No.of Guests</td>
                                <td width="17%">
                                    No.of Rooms
                                </td>
                            </tr>
                            <tr align="center">
                                <td class="f" id="lie2" colspan="2" rowspan="2">
                                    <asp:Label ID="lbHotelName" runat="server"></asp:Label></td>
                                <td class="f" id="lie2" colspan="2" rowspan="2">
                                    <asp:Label ID="lbGuestName" runat="server"></asp:Label>&nbsp;
                                </td>
                                <td class="f" id="lie2" style="height: 22px">
                                    <asp:Label ID="LbNOGuest" runat="server"></asp:Label></td>
                                <td class="f" id="lie3" style="height: 22px">
                                    <asp:Label ID="lbNORoom" runat="server"></asp:Label></td>
                            </tr>
                            <tr align="center">
                                <td class="f_title" id="lie3" style="height: 39px">
                                    Type of Room:
                                </td>
                                <td class="f" id="lie3" style="height: 39px">
                                    <asp:Label ID="lbTypeRoom" runat="server"></asp:Label></td>
                            </tr>
                            <tr align="center">
                                <td class="f_title" id="lie" colspan="2" height="35">
                                    Address:</td>
                                <td class="f_title" id="lie" width="35%" colspan="2">
                                    Check In / Out Dates
                                </td>
                                <td class="f_title" id="lie3">
                                    Arrival Flight:</td>
                                <td class="f" id="lie3">
                                    <asp:Label ID="Label7" runat="server">N / L</asp:Label></td>
                            </tr>
                            <tr align="center">
                                <td class="f" id="lie2" align="center" colspan="2">
                                    &nbsp;
                                    <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
                                <td class="f" id="lie2" colspan="2" height="35">
                                    <asp:Label ID="lbCheckInOut" runat="server"></asp:Label></td>
                                <td class="f_title" id="lie3">
                                    Departure Flight:
                                </td>
                                <td class="f" id="lie3">
                                    <asp:Label ID="Label8" runat="server">N / L</asp:Label></td>
                            </tr>
                            <tr>
                                <td class="f_title" id="lie3" align="center" width="12%">
                                    Tel:</td>
                                <td class="f" id="lie2" align="center" width="16%">
                                    <asp:Label ID="lbHotelTel" runat="server"></asp:Label></td>
                                <td class="f_title" id="lie3" style="width: 101px" align="center" height="35">
                                    Total no. of Nights:</td>
                                <td class="f" id="lie2" align="center" height="35">
                                    <asp:Label ID="lbNights" runat="server"></asp:Label></td>
                                <td class="f_title" id="lie3" align="center">
                                    Transfer:</td>
                                <td class="f" id="lie3" align="center">
                                    <asp:Label ID="lbTANSFER" runat="server">N / L</asp:Label>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="f_title" id="lie3" align="center" style="height: 44px">
                                    Fax:</td>
                                <td class="f" id="lie2" align="center" style="height: 44px">
                                    <asp:Label ID="lbFAX" runat="server"></asp:Label>&nbsp;</td>
                                <td class="f_title" id="lie3" style="width: 101px; height: 44px;" align="center">
                                    Breakfast:</td>
                                <td class="f" id="lie2" align="center" style="height: 44px">
                                    <asp:Label ID="lbBreakfast" runat="server"></asp:Label></td>
                                <td class="f_title" id="lie3" align="center" style="height: 44px">
                                    Confirmation<br>
                                    Number:
                                </td>
                                <td class="f" id="lie3" align="center" style="height: 44px">
                                    &nbsp;
                                    <asp:Label ID="lbCommission" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="f_name" align="center">
                                    Remarks:</td>
                                <td class="f" style="width: 200px" align="center" colspan="2" height="35">
                                    URGENT CALL: &nbsp;</td>
                                <td class="f" id="lie" align="center" height="35">
                                    (888)-288-7528
                                </td>
                                <td class="f_title" style="width: 124px" align="center">
                                    Case Number:
                                </td>
                                <td class="f" align="center">
                                    <asp:Label ID="lbCaseNo" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        
                        <div id="pEmergencyTels" runat="server" visible="false">
	                            <table>
								    <tr>
									    <td class="f"><strong>GTA Emergency Contact</strong></td>
								    </tr>
						        </table>
								<table class="f" borderColor="#000000" cellSpacing="0" cellPadding="2" width="100%" align="center"
									border="1">
									<tr style="FONT-WEIGHT: bold">
										<td align="center">
											<span id="lbCountryCodeSM">Country Code</span></td>
										<td align="center">
											<span id="lbOfficeLocationSM">Office Location</span></td>
										<td align="center">
											<span id="lbInternationalNumberSM">National Number</span></td>
										<td align="center">
											<span id="lbOfficeHoursSM">Office Hours</span></td>
										<td noWrap align="center">
											<span id="lbOutOfOfficeSM">Non Office Hours</span></td>
										<td align="center">
											<span id="lbLanguageNameSM">Language Name</span></td>
									</tr>
									<tr>
										<td align="center">
											<span id="lbCountryCode"><asp:Label ID="lblCountryCode" runat="server"></asp:Label></span></td>
										<td align="center">
											<span id="lbOfficeLocation"><asp:Label ID="lblOfficeCity" runat="server"></asp:Label></span></td>
										<td align="center">
											<span id="lbInternationalNumber"><asp:Label ID="lblPhone" runat="server"></asp:Label></span></td>
										<td align="center">
											<span id="lbOfficeHours">09:00 - 18:00</span></td>
										<td align="center">
											<span id="lbOutOfOffice"></span></td>
										<td align="center">
											<span id="lbLanguageName">English</span></td>
									</tr>
								</table>
							
                        </div>
                        
                        <table class="f" cellspacing="0" cellpadding="2" width="100%" border="0">
                            <tr>
                                <td class="f" id="lei" valign="bottom">
                                    <strong>Issue By:
                                        <asp:Label ID="lbIssueBy" runat="server"></asp:Label></strong></td>
                                <td id="lei" align="right"></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <li>Hotel provides no refund to the guest for this voucher.</li></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <li>Any and all changes to this reservation&nbsp;must be made by Majestic Vacations.</li></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <li>All additional nights and incidentals should be recorded on a separated folio and
                                        paid by guest.</li></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 20px">
                                    <li>Other rules and conditions apply. </li>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" valign="top">
                                    <ul style="margin:0px; padding:0px; margin-left:17px;"><li>Please feel free to reconfirm your hotel reservation directly with the hotel, however
                                        you should be aware that some hotels will not show our reservation information until 2 days prior to&nbsp;your arrival.</li></ul>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                
                                    <ul style="margin:0px; padding:0px; margin-left:17px;"><li style=" line-height:150%;">If the guest does not check-in to the hotel on the first arrival date, the remaining
                                        nights of the reservation will be automatically cancelled and considered as a no-show
                                        (penalties will apply).</li></ul></td>
                            </tr>
                        </table>
                        <table cellspacing="0" cellpadding="2" width="100%" border="0">
                            <tr>
                                <td class="flittle">
                                    *** For more information, please contact with the travel agent or Majestic Vacations
                                    ***</td>
                            </tr>
                        </table>
                        <table cellspacing="0" cellpadding="2" width="100%" border="0">
                            <tr>
                                <td class="flittle">Hotel Cancellation Policy and Penalty<BR></td>
                            </tr>
                            <tr>
                                <td class="flittle" style="height: 34px">All cancellations must be received in writing; either by fax or e-mail (verbal cancellations are not acceptable).  The following fees will be assessed per booking accordingly when you cancel your reservation:<BR></td>
                            </tr>
                            <tr>
                                <td class="flittle">(a) 3 days or more prior to check-in, normally a minimum of 1 night’s hotel cost will be charged per room.  If assessed by hotel, additional charges or fees maybe set by each individual hotel which can be verified by Majestic Vacations at the time of cancellation.  A $50.00 service fee will be assessed by Majestic Vacations on all refunds of hotels cancelled 3 days or more prior to departure.<BR></td>
                            </tr>
                            <tr>
                                <td class="flittle">(b) Less than 3 days prior to departure hotel bookings are non-refundable.</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" width="630" align="center" border="0">
                <tr>
                    <td class="flittle" align="left">
                        www.majestic-vacations.com</td>
                    <td class="flittle" align="right">
                        GTT
                        <asp:Label ID="lbIssueDate1" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>

        <script language="javascript">					
					document.all.txtFormContent.value = document.all.MAIL_BODY.innerHTML;
        </script>

    </form>
</body>
</html>
