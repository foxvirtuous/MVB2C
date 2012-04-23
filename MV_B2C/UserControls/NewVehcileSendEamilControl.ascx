<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewVehcileSendEamilControl.ascx.cs"
    Inherits="Terms.Web.UserControls.NewVehcileSendEamilControl" %>
<%@ Register Src="VehcileEmailPriceInfoControl.ascx" TagName="VehcilePriceInfoControl"
    TagPrefix="uc3" %>
<table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center">
            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="0" style="font-size: 14px;
                line-height: 19px; color: #000000; font-family: Verdana;">
                <tr>
                    <td align="right" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left">
                                    Thank you for your purchase.
                                    <br />
                                    Your car rental(s) have been reserved. Please print this page for your records.
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr align="left">
                                <td height="25" valign="top" style="color: #000000; font-size: 16px; line-height: 20px;
                                    font-family: Verdana; font-weight: bold;">
                                    Your Order Summary</td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                                        <tr>
                                            <td height="120">
                                                <table width="100%" border="0" cellpadding="8" cellspacing="0" style="border-top: solid #999999 1px;
                                                    border-bottom: solid #999999 1px; border-left: solid #999999 1px; border-right: solid #999999 1px;
                                                    border: 1;">
                                                    <tr style="background: #FDF1C1;">
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="7">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="8" style="border-top: solid #CCCCCC 1px;
                                                                            border-bottom: solid #CCCCCC 1px; border-left: solid #CCCCCC 1px; border-right: solid #CCCCCC 1px;
                                                                            border: 1;">
                                                                            <tr style="background: #FFFFFF;">
                                                                                <td align="left">
                                                                                    <font style="color: #000000; font-size: 16px; line-height: 20px; font-family: Verdana;
                                                                                        font-weight: bold;">Order Number:</font> <font style="color: #005599; font-size: 16px;
                                                                                            line-height: 20px; font-family: Verdana; font-weight: bold;">$OrderNumber </font>
                                                                                    <br />
                                                                                    <font style="color: #000000; font-size: 16px; line-height: 20px; font-family: Verdana;
                                                                                        font-weight: bold;">Confirmation number:</font> <font style="color: #005599; font-size: 16px;
                                                                                            line-height: 20px; font-family: Verdana; font-weight: bold;">$Confirmationnumber</font></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="3">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table style="border-top: solid #999999 1px; border-bottom: solid #999999 1px; border-left: solid #999999 1px;
                                                    border-right: solid #999999 1px; border: 1;" align="center" border="0" cellpadding="0"
                                                    cellspacing="0" width="100%">
                                                    <tr style="background: #FFFFFF;">
                                                        <td align="center">
                                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                <tr align="center" style="background: #FF3300; height: 25; color: #FFFFFF; font-family: Verdana;
                                                                    font-weight: bold;">
                                                                    <td height="23" colspan="7" align="center">
                                                                        <b>Car Details</b></td>
                                                                </tr>
                                                            </table>
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <table border="0" cellpadding="3" cellspacing="0" width="100%" style="border-top: solid #999999 1px;
                                                                            border-bottom: solid #999999 1px; border-left: solid #999999 1px; border-right: solid #999999 1px;
                                                                            border: 1;">
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;">
                                                                                    &nbsp;</td>
                                                                                <td width="75%" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;">
                                                                                    <b>
                                                                                        <asp:Label ID="lblVendorName" runat="server" Text=""></asp:Label>
                                                                                        Car Rental</b></td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <b>Car Type</b></td>
                                                                                <td style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px; font-size: 11px;">
                                                                                    <asp:Label ID="lblCarType" runat="server" Text=""></asp:Label><br />
                                                                                    <asp:Label ID="lblCarName" runat="server" Text=""></asp:Label><br />
                                                                                    Automatic, Air Conditioned</td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <b>Pick-up Location</b></td>
                                                                                <td style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px; font-size: 11px;">
                                                                                    <asp:Label ID="lblPickStree" runat="server" Text=""></asp:Label><asp:Label ID="lblPickCityCode"
                                                                                        runat="server" Text=""></asp:Label><asp:Label ID="lblPickPrCode" runat="server" Text=""></asp:Label><asp:Label
                                                                                            ID="lblPickContronCode" runat="server" Text=""></asp:Label><asp:Label ID="lblPickZipCode"
                                                                                                runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <b>Pick-up Date/Time</b></td>
                                                                                <td style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px; font-size: 11px;">
                                                                                    <asp:Label ID="lblPickDateTime" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <b>Drop-off Location</b></td>
                                                                                <td style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px; font-size: 11px;">
                                                                                    <asp:Label ID="lblDropStree" runat="server" Text=""></asp:Label><asp:Label ID="lblDropCityCode"
                                                                                        runat="server" Text=""></asp:Label><asp:Label ID="lblDropPrCode" runat="server" Text=""></asp:Label><asp:Label
                                                                                            ID="lblDropContronCode" runat="server" Text=""></asp:Label><asp:Label ID="lblDropZipCode"
                                                                                                runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <b>Drop-off Date/Time</b></td>
                                                                                <td style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px; font-size: 11px;">
                                                                                    <asp:Label ID="lblDropDateTime" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <b>Total Rental Period</b></td>
                                                                                <td style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px; font-size: 11px;">
                                                                                    <asp:Label ID="lblDays" runat="server" Text=""></asp:Label>
                                                                                    Days</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table style="border-top: solid #999999 1px; border-bottom: solid #999999 1px; border-left: solid #999999 1px;
                                                    border-right: solid #999999 1px; border: 1;" align="center" border="0" cellpadding="0"
                                                    cellspacing="0" width="100%">
                                                    <tr style="background: #FFFFFF;">
                                                        <td align="center">
                                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                <tr align="center" style="background: #FF3300; height: 25; color: #FFFFFF; font-family: Verdana;
                                                                    font-weight: bold;">
                                                                    <td height="23" colspan="7" align="center">
                                                                        <b>Driver Details </b>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border="0" cellpadding="2" cellspacing="0" width="100%" style="border-top: solid #999999 1px;
                                                                border-bottom: solid #999999 1px; border-left: solid #999999 1px; border-right: solid #999999 1px;
                                                                border: 1;">
                                                                <tr align="center" style="background: #EEEEEE; height: 25; color: #000000; font-family: Verdana;
                                                                    font-weight: bold;">
                                                                    <td height="23" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                        font-size: 11px;">
                                                                        Title</td>
                                                                    <td width="28%" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                        font-size: 11px;">
                                                                        First Name</td>
                                                                    <td width="28%" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                        font-size: 11px;">
                                                                        Middle Name
                                                                    </td>
                                                                    <td width="28%" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                        font-size: 11px;">
                                                                        Last Name
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <table border="0" cellpadding="3" cellspacing="0" width="100%" style="border-top: solid #999999 1px;
                                                                                        border-bottom: solid #999999 1px; border-left: solid #999999 1px; border-right: solid #999999 1px;
                                                                                        border: 1;">
                                                                                        <tr align="left" style="background: #FFFFFF;">
                                                                                            <td style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px; font-size: 11px;">
                                                                                                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></td>
                                                                                            <td width="28%" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                                font-size: 11px;">
                                                                                                <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label></td>
                                                                                            <td width="28%" align="left" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                                font-size: 11px;">
                                                                                                <asp:Label ID="lblMiddleName" runat="server" Text=""></asp:Label></td>
                                                                                            <td width="28%" align="left" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                                font-size: 11px;">
                                                                                                <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table style="border-top: solid #999999 1px; border-bottom: solid #999999 1px; border-left: solid #999999 1px;
                                                    border-right: solid #999999 1px; border: 1;" align="center" border="0" cellpadding="0"
                                                    cellspacing="0" width="100%">
                                                    <tr style="background: #FFFFFF;">
                                                        <td align="center">
                                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                <tr align="center" style="background: #FF3300; height: 25; color: #FFFFFF; font-family: Verdana;
                                                                    font-weight: bold;">
                                                                    <td height="23" colspan="7" align="center">
                                                                        <b>Contact Information</b></td>
                                                                </tr>
                                                            </table>
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <table border="0" cellpadding="3" cellspacing="0" width="100%" style="border-top: solid #999999 1px;
                                                                            border-bottom: solid #999999 1px; border-left: solid #999999 1px; border-right: solid #999999 1px;
                                                                            border: 1;">
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td width="20%" align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    First Name</td>
                                                                                <td width="30%" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblContactFristName" runat="server" Text=""></asp:Label></td>
                                                                                <td width="20%" align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    Middle Name:</td>
                                                                                <td width="30%" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblContactMiddleName" runat="server" Text=""></asp:Label></td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    Last Name</td>
                                                                                <td colspan="3" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblContactLastName" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    Address</td>
                                                                                <td colspan="3" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    City</td>
                                                                                <td colspan="3" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblCity" runat="server" Text=""></asp:Label></td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    State</td>
                                                                                <td colspan="3" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblState" runat="server" Text=""></asp:Label></td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    Zip</td>
                                                                                <td colspan="3" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblZip" runat="server" Text=""></asp:Label></td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    Country</td>
                                                                                <td colspan="3" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblCountry" runat="server" Text=""></asp:Label></td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    Contact Phone</td>
                                                                                <td colspan="3" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label></td>
                                                                            </tr>
                                                                            <tr align="left" style="background: #FFFFFF;">
                                                                                <td align="right" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    Email</td>
                                                                                <td colspan="3" style="border-bottom: solid #cccccc 1px; border-right: solid #cccccc 1px;
                                                                                    font-size: 11px;">
                                                                                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="8" style="border-top: solid #999999 1px;
                                                    border-bottom: solid #999999 1px; border-left: solid #999999 1px; border-right: solid #999999 1px;
                                                    border: 1;">
                                                    <tr style="background: #FFFFFF; font-size: 11px;">
                                                        <td align="left">
                                                            <uc3:VehcilePriceInfoControl ID="VehcilePriceInfoControl1" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="15">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="left" style="color: #000000; font-size: 16px; line-height: 20px; font-family: Verdana;
                                                font-weight: bold;">
                                                Service Contact</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="8" style="border-top: solid #999999 1px;
                                        border-bottom: solid #999999 1px; border-left: solid #999999 1px; border-right: solid #999999 1px;
                                        border: 1;">
                                        <tr style="background: #FFFFFF; font-size: 11px;">
                                            <td align="left">
                                                &#8226; &nbsp;<asp:Label ID="lblCustomerStaff" runat="server">Customer Service Staff</asp:Label>:
                                                <asp:Label runat="server" ID="lblSalesName"></asp:Label>
                                                <br>
                                                &#8226; &nbsp;<asp:Label ID="Label1" runat="server">Phone</asp:Label>: 1-(888)-288-7528<br>
                                                &#8226; &nbsp;<asp:Label ID="Label2" runat="server">Email</asp:Label>:
                                                <asp:Label runat="server" ID="lblSalesEmail"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                            <tr>
                                <td height="50" align="left" valign="top">
                                    Thanks again for your purchase. We're looking forward to going places with you!<br>
                                    Always visit <a href="http://www.majestic-vacations.com/" class="d07">www.majestic-vacations.com</a>
                                    for the greatest travel deals!</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Enjoy your trip,
                                    <br>
                                    The Majestic Vacation Team</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
