<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Inherits="TourSelectAirForm"
    Codebehind="TourSelectAirForm.aspx.cs" %>

<%@ Register Src="../../UserControls/TourTravelerAndPriceInfoControl.ascx" TagName="TourPriceInfoControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/UserLoginControl.ascx" TagName="UserLoginControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/FlightDetailsControl.ascx" TagName="FlightDetailsControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="Content-Language" content="en-us" />
    <meta http-equiv="Content-type" content="text/html; charset=iso-8859-1" />
    <meta name="keywords" content="Majestic Vacations, Majestic, Vacations, Travel, Cheap Airfare, Hotels, Vacations, Airfare, Airline Tickets, Hotel, Vacation, Hotel Reservations, Vacation Packages, Travel Agency, Travel Deals, Discount Airfare" />
    <meta name="description" content="Purchase airline tickets, make hotel reservations, find vacation packages" />
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
         var isShow = false;
         function ShowOrHideItinerary()
         {
            if(!isShow)
            {
                isShow =true;
                document.getElementById("div_TourItinerary").style.display = "";
            }
            else
            { isShow =false;
                document.getElementById("div_TourItinerary").style.display = "none";}
         }
                 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:CheckBox ID="chkCheck" runat="server" Visible="false" />
        <asp:Button ID="btn_Check" runat="server" Text="Button" Visible="false" />
        <asp:TextBox ID="txtErr" runat="server" Visible="false"></asp:TextBox>
        <uc1:Header ID="Header1" runat="server" />
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <table width="920" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="15">
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="step">
                                    <tr>
                                        <td height="25" align="right" valign="top" style="width: 920px">
                                            <uc5:StatesControl ID="StatesControl1" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="0" class="T_table">
                        <tr>
                            <td align="right" valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="1" class="T_step02">
                                    <tr class="R_step02">
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr align="left">
                                                                            <td height="25" valign="top" class="D_stepr">
                                                                                <asp:Label ID="lblReview" runat="server" meta:resourcekey="lblReview">Review The Order You Selected</asp:Label></td>
                                                                            <td align="right">
                                                                                <%--<a href="#">Print</a>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                    <tr class="R_stepw">
                                                                                        <td>
                                                                                            <uc5:TourMainInfoControl ID="TourMainInfoControl1" runat="server"></uc5:TourMainInfoControl>
                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td height="10">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td height="10">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <%--*******************************************************--%>
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="height: 15px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                <tbody>
                                                                                                                    <tr>
                                                                                                                        <td width="20">
                                                                                                                            <table class="T_line01" cellspacing="0" cellpadding="0" width="20" border="0">
                                                                                                                                <tbody>
                                                                                                                                    <tr>
                                                                                                                                        <td align="center">
                                                                                                                                            ></td>
                                                                                                                                    </tr>
                                                                                                                                </tbody>
                                                                                                                            </table>
                                                                                                                        </td>
                                                                                                                        <td width="5">
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            <span class="head06">
                                                                                                                                <asp:Label ID="lblChoose" runat="server" meta:resourcekey="lblChoose">Choose Number of Passengers & Room Type</asp:Label></span></td>
                                                                                                                    </tr>
                                                                                                                </tbody>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <table class="T_step02" cellspacing="1" cellpadding="8" width="100%" border="0">
                                                                                                                <tbody>
                                                                                                                    <tr class="R_stepo">
                                                                                                                        <td valign="top">
                                                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                                <tbody>
                                                                                                                                    <tr>
                                                                                                                                        <td height="7">
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <input id="ctl00_MainContent_TourTravelerChangeControl1_hdControlName" type="hidden"
                                                                                                                                                value="TourTravelerChangeControl1" name="ctl00$MainContent$TourTravelerChangeControl1$hdControlName">
                                                                                                                                            <table class="T_step03" cellspacing="1" cellpadding="8" width="100%" border="0">
                                                                                                                                                <tbody>
                                                                                                                                                    <tr class="R_stepw">
                                                                                                                                                        <td>
                                                                                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            <font color="#FF3300">*</font>
                                                                                                                                                                            <asp:Label ID="lblReference" runat="server" meta:resourcekey="lblReference">Reference For Choice Passengers and Room Type</asp:Label></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#cccccc"
                                                                                                                                                                runat="server" id="tbAsia" visible="false">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr align="left" bgcolor="#F8F8F8">
                                                                                                                                                                        <td width="50%" height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label2" runat="server" meta:resourcekey="lblPassengersCombination">Passengers Combination</asp:Label></b></td>
                                                                                                                                                                        <td style="width: 410px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label3" runat="server" meta:resourcekey="lblRecommendRoomType">Recommend Room Type</asp:Label></b></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                        <td style="width: 410px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label104" runat="server" meta:resourcekey="lblSingleRoom">Single Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label31" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2</td>
                                                                                                                                                                        <td rowspan="4" style="width: 410px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label109" runat="server" meta:resourcekey="lblTwinRoom">Twin Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label32" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2 +
                                                                                                                                                                            <asp:Label ID="Label71" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label33" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label85" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label34" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label86" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label72" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label35" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label73" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label></td>
                                                                                                                                                                        <td style="width: 410px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label122" runat="server" meta:resourcekey="lblTwinRoomNeed">Twin Room (Child need bed)</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label36" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2 +
                                                                                                                                                                            <asp:Label ID="Label87" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 2</td>
                                                                                                                                                                        <td style="width: 410px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label110" runat="server" meta:resourcekey="lblTwinRoom">Twin Room</asp:Label>
                                                                                                                                                                                x 2</font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label37" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2+
                                                                                                                                                                            <asp:Label ID="Label88" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label74" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                        <td style="width: 410px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label116" runat="server" meta:resourcekey="lblTripleRoom">Triple Room</asp:Label></font>
                                                                                                                                                                            <asp:Label ID="Label143" runat="server" meta:resourcekey="lblOr">or</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label115" runat="server" meta:resourcekey="lblTwinRoom">Twin Room</asp:Label>
                                                                                                                                                                                x 2</font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b>&#8250;
                                                                                                                                                                                <asp:Label ID="Label127" runat="server" meta:resourcekey="lblRemarks">Remarks</asp:Label>:
                                                                                                                                                                            </b>
                                                                                                                                                                            <br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;1.
                                                                                                                                                                            <asp:Label ID="Label130" runat="server" meta:resourcekey="lblAgeLimit">Passenger Age Limit: Adult: ( Above 12 )、Child: ( 3-12 )、Child (without bed): ( 0-2 )</asp:Label>.</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#cccccc"
                                                                                                                                                                runat="server" id="tbEastCoast" visible="false">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr align="left" bgcolor="#F8F8F8">
                                                                                                                                                                        <td width="50%" height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label23" runat="server" meta:resourcekey="lblPassengersCombination">Passengers Combination</asp:Label></b></td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label27" runat="server" meta:resourcekey="lblRecommendRoomType">Recommend Room Type</asp:Label></b></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label38" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label105" runat="server" meta:resourcekey="lblSingleRoom">Single Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label39" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2</td>
                                                                                                                                                                        <td rowspan="4">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label11" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label111" runat="server" meta:resourcekey="lblTwinRoom">Twin Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label40" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2 +
                                                                                                                                                                            <asp:Label ID="Label70" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label41" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label89" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label42" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label90" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label75" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label43" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 3</td>
                                                                                                                                                                        <td rowspan="2">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label12" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label117" runat="server" meta:resourcekey="lblTripleRoom">Triple Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label44" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2+
                                                                                                                                                                            <asp:Label ID="Label91" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label76" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label45" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 4</td>
                                                                                                                                                                        <td rowspan="3">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label121" runat="server" meta:resourcekey="lblQuatRoom">Quat Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label46" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 3 +
                                                                                                                                                                            <asp:Label ID="Label92" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label47" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2 +
                                                                                                                                                                            <asp:Label ID="Label93" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 2</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b>&#8250;
                                                                                                                                                                                <asp:Label ID="Label128" runat="server" meta:resourcekey="lblRemarks">Remarks</asp:Label>:
                                                                                                                                                                            </b>
                                                                                                                                                                            <br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;1.
                                                                                                                                                                            <asp:Label ID="Label131" runat="server" meta:resourcekey="lblAgeLimit2">Passenger Age Limit: Adult: ( Above 9 )、Child: ( Above 9 )、Child (without bed): ( 2-9 )</asp:Label>.<br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;2.
                                                                                                                                                                            <asp:Label ID="Label135" runat="server" meta:resourcekey="lblNoExtra">Hotel accommodations based on Twin sharing. No extra bed for child or the 3rd, 4th person</asp:Label>.<br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;3.
                                                                                                                                                                            <asp:Label ID="Label136" runat="server" meta:resourcekey="lblExceed">Based on local fire safety regulation no rooms can exceed 2beds. triple or Quarter room based on two twin beds only</asp:Label>.</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#cccccc"
                                                                                                                                                                runat="server" id="tbWestCoast" visible="false">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr align="left" bgcolor="#F8F8F8">
                                                                                                                                                                        <td width="50%" height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label24" runat="server" meta:resourcekey="lblPassengersCombination">Passengers Combination</asp:Label></b></td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label28" runat="server" meta:resourcekey="lblRecommendRoomType">Recommend Room Type</asp:Label></b></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label48" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label14" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label106" runat="server" meta:resourcekey="lblSingleRoom">Single Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label49" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2</td>
                                                                                                                                                                        <td rowspan="4">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label15" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label112" runat="server" meta:resourcekey="lblTwinRoom">Twin Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label50" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2 +
                                                                                                                                                                            <asp:Label ID="Label77" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label51" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label94" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label52" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label95" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label78" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label53" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 3</td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label54" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2+
                                                                                                                                                                            <asp:Label ID="Label96" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label79" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label16" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label118" runat="server" meta:resourcekey="lblTripleRoom">Triple Room</asp:Label><br>
                                                                                                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label123" runat="server" meta:resourcekey="lblTwinRoom3rd">(3rd Person in Twin Room)</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b>&#8250;
                                                                                                                                                                                <asp:Label ID="Label129" runat="server" meta:resourcekey="lblRemarks">Remarks</asp:Label>:
                                                                                                                                                                            </b>
                                                                                                                                                                            <br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;1.
                                                                                                                                                                            <asp:Label ID="Label132" runat="server" meta:resourcekey="lblAgeLimit3">Passenger Age Limit: Adult: ( Above 11 )、Child: ( Above 11 )、Child (without bed): ( 2-11 )</asp:Label>.<br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;2.
                                                                                                                                                                            <asp:Label ID="Label139" runat="server" meta:resourcekey="lblAccommodationsWest">Hotel accommodations based on double occupancy, Child(Under 11 years old) rate is without bed</asp:Label>.<br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;3.
                                                                                                                                                                            <asp:Label ID="Label137" runat="server" meta:resourcekey="lblExceed">Based on local fire safety regulation no rooms can exceed 2beds. triple or Quarter room based on two twin beds only</asp:Label>.</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#cccccc"
                                                                                                                                                                runat="server" id="tbOrlando" visible="false">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr align="left" bgcolor="#F8F8F8">
                                                                                                                                                                        <td width="50%" height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label25" runat="server" meta:resourcekey="lblPassengersCombination">Passengers Combination</asp:Label></b></td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label29" runat="server" meta:resourcekey="lblRecommendRoomType">Recommend Room Type</asp:Label></b></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label55" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label17" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label107" runat="server" meta:resourcekey="lblSingleRoom">Single Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label56" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2</td>
                                                                                                                                                                        <td rowspan="4">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label18" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label113" runat="server" meta:resourcekey="lblTwinRoom">Twin Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label57" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2 +
                                                                                                                                                                            <asp:Label ID="Label80" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label58" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label97" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label59" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label98" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label81" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label60" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 3</td>
                                                                                                                                                                        <td rowspan="2">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label19" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label119" runat="server" meta:resourcekey="lblTripleRoom">Triple Room</asp:Label><br>
                                                                                                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label124" runat="server" meta:resourcekey="lblTwinRoom3rd">(3rd Person in Twin Room)</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label61" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2+
                                                                                                                                                                            <asp:Label ID="Label99" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label82" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label62" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 4</td>
                                                                                                                                                                        <td rowspan="3">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label20" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label120" runat="server" meta:resourcekey="lblQuatRoom">Quat Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label63" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 3 +
                                                                                                                                                                            <asp:Label ID="Label100" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label64" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2 +
                                                                                                                                                                            <asp:Label ID="Label101" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 2</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b>&#8250;
                                                                                                                                                                                <asp:Label ID="Label125" runat="server" meta:resourcekey="lblRemarks">Remarks</asp:Label>:
                                                                                                                                                                            </b>
                                                                                                                                                                            <br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;1.
                                                                                                                                                                            <asp:Label ID="Label133" runat="server" meta:resourcekey="lblAgeLimit4">Passenger Age Limit: Adult: ( Above 9 )、Child: ( Above 9 )、Child (without bed): ( 3-9 )</asp:Label>.<br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;2.
                                                                                                                                                                            <asp:Label ID="Label141" runat="server" meta:resourcekey="lblAccommodate">Hotel accommodate in Comfort Inn Universal Studio with Daily Continental Breakfast</asp:Label>.<br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label142" runat="server"
                                                                                                                                                                                meta:resourcekey="lblAddressOr">Address: 6101 Sand Lake Rd. Orlando FL 32819</asp:Label>.
                                                                                                                                                                            .</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#cccccc"
                                                                                                                                                                runat="server" id="tbHawaii" visible="false">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr align="left" bgcolor="#F8F8F8">
                                                                                                                                                                        <td width="50%" height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label26" runat="server" meta:resourcekey="lblPassengersCombination">Passengers Combination</asp:Label></b></td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="Label30" runat="server" meta:resourcekey="lblRecommendRoomType">Recommend Room Type</asp:Label></b></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label65" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label21" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label108" runat="server" meta:resourcekey="lblSingleRoom">Single Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label66" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2</td>
                                                                                                                                                                        <td rowspan="4">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label22" runat="server" meta:resourcekey="lblChoice">Please choice</asp:Label>
                                                                                                                                                                            <font class="t06">
                                                                                                                                                                                <asp:Label ID="Label114" runat="server" meta:resourcekey="lblTwinRoom">Twin Room</asp:Label></font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label67" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 2 +
                                                                                                                                                                            <asp:Label ID="Label83" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label68" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label102" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td height="25">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label69" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label103" runat="server" meta:resourcekey="lblChild">Child</asp:Label>
                                                                                                                                                                            x 1 +
                                                                                                                                                                            <asp:Label ID="Label84" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label>
                                                                                                                                                                            x 1</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr align="left" bgcolor="#FFFFFF">
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b>&#8250;
                                                                                                                                                                                <asp:Label ID="Label126" runat="server" meta:resourcekey="lblRemarks">Remarks</asp:Label>:
                                                                                                                                                                            </b>
                                                                                                                                                                            <br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;1.
                                                                                                                                                                            <asp:Label ID="Label134" runat="server" meta:resourcekey="lblAgeLimit5">Passenger Age Limit: Adult: ( Above 12 )、Child: ( Above 12 )、Child (without bed): ( 2-11 )</asp:Label>.<br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;2.
                                                                                                                                                                            <asp:Label ID="Label140" runat="server" meta:resourcekey="lblAccommodations">Hotel accommodations based on double occupancy, Child(Under 12 years old) rate is without bed</asp:Label>.<br>
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;3.
                                                                                                                                                                            <asp:Label ID="Label138" runat="server" meta:resourcekey="lblExceed">Based on local fire safety regulation no rooms can exceed 2beds. triple or Quarter room based on two twin beds only</asp:Label>.</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <%--                                                                                                       <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td height="10">
                                                                                                                                                                            <uc7:TourNewTravelerChangeControl ID="TourNewTravelerChangeControl1" runat="server" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>--%>
                                                                                                                                                            <%--<table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="25%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <font class="t06">Room Type</font> <font color="#FF3300">*</font></td>
                                                                                                                                                                        <td width="15%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <font class="t06">Number of Rooms</font></td>
                                                                                                                                                                        <td width="20%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;</td>
                                                                                                                                                                        <td width="15%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <font class="t06">Price</font></td>
                                                                                                                                                                        <td width="25%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <font class="t06">Number of Passengers</font> <font color="#FF3300">*</font></td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="25%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            Single Room</td>
                                                                                                                                                                        <td width="15%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select15" style="width: 35px" onchange="ShowHidePassengers()" name="ctl00$MainContent$TourTravelerChangeControl1$dllRooms">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                        <td width="20%" height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Adult</td>
                                                                                                                                                                        <td width="15%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td width="25%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select29" style="width: 35px" name="ctl00$MainContent$TourTravelerChangeControl1$ddlAdult1">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="25%" rowspan="3" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            Twin Room</td>
                                                                                                                                                                        <td width="15%" rowspan="3" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select17" style="width: 35px" onchange="ShowHidePassengers()" name="select">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                        <td height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Adult</td>
                                                                                                                                                                        <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select30" style="width: 35px" name="select2">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Child</td>
                                                                                                                                                                        <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select31" style="width: 35px" name="select3">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="20%" height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Child (without bed)</td>
                                                                                                                                                                        <td width="15%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td width="25%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select32" style="width: 35px" name="select4">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="25%" rowspan="3" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            Triple Room</td>
                                                                                                                                                                        <td width="15%" rowspan="3" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select21" style="width: 35px" onchange="ShowHidePassengers()" name="select5">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                        <td height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Adult</td>
                                                                                                                                                                        <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select33" style="width: 35px" name="select7">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Child</td>
                                                                                                                                                                        <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select34" style="width: 35px" name="select8">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="20%" height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Child (without bed)</td>
                                                                                                                                                                        <td width="15%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td width="25%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select35" style="width: 35px" name="select9">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="25%" rowspan="3" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            Quat Room</td>
                                                                                                                                                                        <td width="15%" rowspan="3" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select25" style="width: 35px" onchange="ShowHidePassengers()" name="select6">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                        <td height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Adult</td>
                                                                                                                                                                        <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select36" style="width: 35px" name="select10">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Child</td>
                                                                                                                                                                        <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select37" style="width: 35px" name="select11">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="20%" height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Child (without bed)</td>
                                                                                                                                                                        <td width="15%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            USD $308</td>
                                                                                                                                                                        <td width="25%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                                                                                                            <select id="select38" style="width: 35px" name="select12">
                                                                                                                                                                                <option value="1" selected>1</option>
                                                                                                                                                                                <option value="2">2</option>
                                                                                                                                                                                <option value="3">3</option>
                                                                                                                                                                                <option value="4">4</option>
                                                                                                                                                                                <option value="5">5</option>
                                                                                                                                                                                <option value="6">6</option>
                                                                                                                                                                            </select>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>--%>
                                                                                                                                                            <uc8:TourPriceInfoControl ID="PriceInfoControl1" runat="server" />
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </tbody>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td height="3">
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </tbody>
                                                                                                                            </table>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </tbody>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
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
                                                    </td>
                                                </tr>
                                                <tr class="R_step04">
                                                    <td height="20">
                                                        &nbsp;</td>
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
                                                    <td width="20">
                                                        <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                                            <tr>
                                                                <td align="center">
                                                                    &gt;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="5">
                                                    </td>
                                                    <td align="left">
                                                        <span class="head06">
                                                            <asp:Label ID="lblTermsConditions" runat="server" meta:resourcekey="lblTermsConditions">Terms and Conditions</asp:Label></span></td>
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
                                            <table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                                                <tr class="R_stepo">
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="7">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <label>
                                                                        <textarea name="textarea" id="textarea" style="width: 98%; padding: 10px" rows="10">1. Deposit: A deposit of $250 per person is required at the time of confirmation or the reservation. All reservations will automatically be cancelled if deposits are not received by Majestic Vacations within 7 days of confirmation of the reservation. A copy of the passport for each person should be provided to Majestic Vacations with the deposit check. All documents and tickets will be issued using the full legal name on each passport.

2. Final Payment: Final payment of the tour fare is due at least 45 days prior to your departure date. If payment is not received by the due date listed on your confirmation, you reservation will be cancelled and your deposit will be forfeited completely.

3. Cancellation: All cancellations must be received in writing; either by fax or mail (e-mail and verbal cancellations are not acceptable). The following fees will be assessed per person accordingly when you cancel your reservation:

a. 45 or more days prior to departure: $150 per person.

b. 44 to 15 days prior to departure: $350 per person.

c. 14 to 3 days prior to departure: $1000 per person.

d. 100% of tour and airfare will be fined for no-show on the day of departure date or if less than 72 hours prior to departure time.

e. When travelers cannot complete their tour for any reason, the unused portion of the tour is not refundable, exchangeable or transferable.

f. In addition to the above stated cancellation charges, all penalties and service charges related to cancellation of the airline tickets and or cruise vessel passage will be charged to the traveler pursuant to the rules and regulations of the airline or cruise company.

Tour Fare Includes:
-------------------------------------------------------------------------------------------------------------------------------------------
1. Travel Protection Insurance Plan: Majestic Vacations provides full coverage of travel insurance to customers (US and Canadian residents only) at no additional charge when reservations and full final payment are made at least 45 days prior to departure. Optional Travel Protection Insurance is offered at an additional expense when the reservation is made or payment is received less than 45 days prior to departure.

2. Air Transportation: A roundtrip international air ticket is included with the tour for passengers departing from the U.S. gateway city stated in the itinerary at the appropriate price point.

3. Hotel Accommodations: Based on 2 adults sharing one room, double occupancy (please specify single or double beds in your reservation). A customer who travels alone is required to pay a single supplement rate. When the hotel listed in the brochure is not available, the same category hotel will be substituted without prior notice.

4. Porter Service: The porter service in some hotels is limited to 1 baggage per person; all extra pieces must be paid by the traveler and arranged directly with the hotel personnel.

5. Meals: Most meals are provided daily as specified in your itinerary. Special diet requirements cannot be guaranteed prior to departure.

6. Sightseeing: All sightseeing listed in this brochure will be adhered to as accurately as possible. However, all final arrangements will be determined by the local tour guide based on circumstances which may be out of the control of Majestic Vacations.

7. Admission / Entrance Fees: All entrance fees and cruise tickets mentioned in the tour itinerary are included in the price of the tour.

Tour Fare Does Not Include:
-------------------------------------------------------------------------------------------------------------------------------------------
1. Any personal charges such as visa fees, passport fees, porterage, excess baggage charges, phone bills, postage, laundry, drinks, insurance premiums, or charges arising from deviations.

2. Meals and transportation not mentioned in this brochure.

3. Tips for your tour guide, driver or bellmen.

4. Air fares from your hometown to the gateway city, airport taxes, air ticket taxes, fuel surcharges, or any other charges levied by local, state, or federal government agency.

5. Fees for delivery of tour documentation to international destinations.

General Conditions:
-------------------------------------------------------------------------------------------------------------------------------------------
1. All fares are quoted in U.S. Dollars and are based on tariffs and rates of currency exchange [in] effect [as] of January 2006. These rates are subject to change as deemed necessary by Majestic Vacations. Should flight schedule changes require Majestic Vacations to extend the trip by adding 1 night to the package, the additional cost will be assessed to each customer.

2. Majestic Vacations reserves the right to cancel the tour when the total number of participants falls below 10.

3. Tour Programs will be narrated only in the language specified for that departure. Please make sure that speakers of English only or Spanish only are booked on the appropriate tours.

4. Passport / Visas: All tour members?passports must be valid for at least 6 months validity AFTER the return date of the tour. Majestic Vacations is not responsible when you are denied entrance for any reason at a foreign country, even if you have a valid passport and visa. A single-entry visa to China costs $80 if arranged by Majestic Vacations for U.S. Citizens. Please inquire directly at Majestic Vacations about visa requirements to other countries.

5. Baggage: Baggage is the sole responsibility of the traveler. Check-in luggage allowance for the transoceanic flights is generally 2 pieces that weigh no more than 50lbs. Most airlines limit carry-on baggage to 1 piece per person that must be small enough to fit under the seat. Please check directly with your airline for their latest baggage requirements and related excess charges. Baggage allowances on domestic China flights are limited to 44 lbs.

6. Charges for Children: For children 11 or under, if they share a room with 2 adults and do not request an extra bed, they will be charged the listed child rate. If an extra bed is required in the room, they must pay 90% of the adult rate. Children 12 and over will be charged the full adult price.

7. Deviation Charge: In addition to the hotel or airline charge, there will be a $75 charge for any deviation from the tour.

8. Change Fee: One change is allowed free of charge after your reservation is confirmed if made more than 45 days prior to departure. A $75 fee will be charged for any subsequent changes. Once documents or air tickets have been issued, no changes are permitted.

9. Majestic Vacations reserves the right to exclude any person as a tour member when such person抯 health, mental condition, physical infirmity, or general condition impede the operation of the tour or the rights, welfare, or enjoyment of other tour members. Any unused tour features, either cruise/land arrangements or air transportation, is not refundable, transferable or exchangeable.

10. Shopping: Our Majestic Vacations tour guides are happy to assist you with any shopping requirements, however Majestic Vacations is not responsible for any items purchased at shops on this tour. Any after sales correspondence must be between the shop and the customer.

11. Health: To ensure the smooth operation of the tour, Majestic Vacations recommends that travelers be in good health. Please consult your doctor regarding your wellness and any physical limitations to traveling long distances or high altitudes in Tibet. Any physical or mental disability which requires special treatment, access, or assistance, must be noted at the time of reservation.

12. Late Booking: Last minute booking (inside 30 days prior to departure) will be assessed a $50 per person surcharge and will be taken only with full payment and subject to availability.

13. The airlines, airports, bus company, hotels, cruise lines, or local travel agency have their own regulations and insurance policies protecting it抯 clients regarding to safety and other issues related to the trip. Customers should contact related operator directly since Majestic Vacations is not responsible for what the insurance of the third-party operator is providing.

14. By making a reservation and sending payment to Majestic Vacations, the tour member agrees to and consents to all terms and conditions presented in this brochure.

Responsibility:
-------------------------------------------------------------------------------------------------------------------------------------------
Majestic Vacations, as a tour operator, acts only as agent. All travel arrangements included in this trip are made on the participants behalf upon the express condition that, neither Majestic Vacations, nor its agents, shall be liable or responsible in the absence of its (or their) negligence for any direct, indirect, consequential, irregularity of any kind which may be accessioned by reason of any act or omission of any person or entity, including without limitation, any act of negligence or breach of contract of any third-party such as airline, cruise vessel, boat, train, private car, bus, motor coach, or of any other mode of conveyance, of hotels, of sightseeing, and local ground handler, etc., which is to supply or does supply any goods or services for this trip. Participant understands that Majestic Vacations neither owns nor operates such third-party suppliers and accordingly agrees to seek remedies directly and only with those suppliers and not hold Majestic Vacations responsible for their acts, omissions, or commission. Without limiting the foregoing, Majestic Vacations and its agents are furthermore not responsible for any losses or expenses incurred due to any of the following: delay or changes of schedule, overbooking of accommodations, default of any third parties, sickness, weather, strike, acts of God, acts of terrorism, force majeure, acts of government抯 civil disturbances, war, quarantine, customs regulations, epidemics, criminal activity, or any other cause beyond the control of Majestic Vacations. All such losses or expenses have to be borne and be paid for by the participant.

Majestic Vacations accepts no responsibility for value, reliability, quality or authenticity of any goods purchased on a tour or for any mailing, freight or shipping arrangements.

Majestic Vacations reserves the right to decline, to accept, or to retain any person as a tour participant should that person抯 health, mental condition, physical infirmity or general condition impede the operation of the tour or the rights, welfare, or enjoyment of other tour participants.

Majestic Vacations reserves the right to substitute hotels, and alter the itinerary, withdraw any tour and make any desirable alteration for the convenience of the operation of the tours. Majestic Vacations reserves the right to cancel the tour prior to departure for any reason. Liability for such cancellations limited to full refund of the money received by Majestic Vacations and this will constitute full settlement with the tour member. All tour fares shown, except in China, are based on the present value of the foreign currencies in relation to the U.S. Dollar on January 2, 2006 and current tariffs on the same date. All tour fares therefore are subject to change. In China, costs are quoted by the Chinese handling travel agency. Increases in cost of any service within China, tour fares and hotels are subject to adjustment. The right is reserved to cancel the tour prior to departure for any reason. In such case, a full refund of all payments will constitute a full settlement with the participant. The Chinese handling travel agency has sole and exclusive control over the operation of all tours in China. The Chinese handling travel agency reserves the right to make alterations or adjustments in the itinerary as to destinations, transportation, accommodations and all other services. Neither Majestic Vacations nor any subsidiary or affiliate of Majestic Vacations shall be responsible for any such alterations made by the Chinese handling travel agency.

Baggage is carried at the owner risk and baggage insurance is recommended. Majestic Vacations is not responsible for typographical or printing errors or omissions in the brochure. Majestic Vacations accepts no responsibility for cost, which may occur as results of a participant failing to secure adequate insurance coverage, which coverage is highly recommended. Generally, your health insurance does not cover expense outside the USA. Majestic Vacations is not responsible for participant抯 visa or passport requirements, nor will a refund of unused services be made, nor reimbursement of any additional expenditure if the participant is denied entry to a country for this or any other reason.

General conditions, to which you have agreed when you had decided to utilize the services of Majestic Vacations, may not be amended in any way, except in writing, by an authorized officer of Majestic Vacations. By utilizing the services of Majestic Vacations, you agree that the exclusive venue for claims shall be the County of Dallas, State of Texas and such claims shall be determined according to the laws and jurisdiction of the State of Texas.

The issuance of tickets and vouchers shall be deemed to be consent to the above conditions and to these terms and conditions.

Omissions:
-------------------------------------------------------------------------------------------------------------------------------------------
The company is not responsible for omissions or errors of printing or presentation in brochures, on the internet, or through any other media where such information maybe presented. The company reserves the right to make corrections as required. 

Travel Protection Insurance:
-------------------------------------------------------------------------------------------------------------------------------------------
Majestic Vacations highly recommends purchasing additional travel insurance that allows you extra freedom and flexibility to make changes to your plans without incurring costly revision and cancellation fees. Travelers receive reassurances that they will be protected from unexpected circumstances prior to departure or during travel for a reasonable price. Please inquire with our sales agent for the cost of the policy which best suits your individual needs.

Depending on the optional plan you purchase, you will have protection for trip cancellation, trip interruption, trip delay, emergency evacuation, accident medical protection, sickness and medical expenses, baggage delay, travel accident protection and access to 24-hour emergency assistance. Please inquire for a complete list of benefits and coverage.

Please call our reservations office at               1-(888)-288-7528        and we will assist in processing your additional insurance.  


                        </textarea>
                                                                    </label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10">
                                                                    <asp:CheckBox ID="chkConditions" runat="server" CssClass='orglab' /><a name="bottom"></a><a href="#bottom" id="clickLink"></a>
                                                                    <span class="t02">
                                                                        <asp:Label ID="lblAgree" runat="server" meta:resourcekey="lblAgree">Yes, I agree to the Terms and Conditions above.</asp:Label></span></td>
                                                            </tr>
                                                        </table>
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
                                        <td align="right">
                                            <asp:PlaceHolder ID="P_table" runat="server">
                                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblConfirm">Please confirm all of the information is correct, then click</asp:Label>
                                                &nbsp;
                                                <asp:Button CssClass="search_btn02" ID="btn_button" runat="server" Text="Continue"
                                                    OnClick="btn_button_Click" Style="cursor: hand" meta:resourcekey="btnContinue" />&nbsp;&nbsp;</asp:PlaceHolder>
                                            <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="search_btn03"
                                                Style="cursor: hand" meta:resourcekey="btnBack" />
                                        </td>
                                    </tr>
                                </table>
                                <div id="divSignIn" runat="server" visible="false">
                                    <uc6:UserLoginControl ID="UserLoginControl1" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
        <script type="text/javascript">
        var txtPassword = document.getElementById("UserLoginControl1_txtPassword");
        if(txtPassword != null)
        {
            document.getElementById("UserLoginControl1_txtPassword").onfocus=function document.onkeydown()
            {
                 if   (event.keyCode   ==   13 && document.getElementById("UserLoginControl1_txtPassword").value != "")
                 {
                    document.body.focus();
                    document.getElementById("UserLoginControl1_btnLogin").click();
                 }
            }
        }        
        var txtUserName = document.getElementById("UserLoginControl1_txtUserName");
        
        if(txtUserName != null)
        {
            document.getElementById("UserLoginControl1_txtUserName").onfocus=function document.onkeydown()
            {
                 if   (event.keyCode   ==   13 && document.getElementById("UserLoginControl1_txtUserName").value != "")
                 {
                    document.body.focus();
                    document.getElementById("UserLoginControl1_btnLogin").click();   
                 }
            }
        }        
        txtPassword = null;
        txtUserName = null; 
        </script>
    </form>
</body>
</html>
