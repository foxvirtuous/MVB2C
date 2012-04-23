<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="ViewTransportationControl" Codebehind="ViewTransportationControl.ascx.cs" %>
<div visible="false" id="divThen" runat="server">
    <table class="order" align="center" border="0" cellpadding="0" cellspacing="0"
        width="100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr align="center">
                        <td height="23" align="left" class="name">
                            <h3>
                                Transportation Information(From Airport To Hotel)</h3>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr align="left">
                        <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                <tr align="center" >
                                    <td height="23" align="left" class="name">
                                        &nbsp;&nbsp;Pick Up Information</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td colspan="2">
                                <asp:Label ID="lblName_Then" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td width="25%">
                            <span class="t01">*</span> Arriving From:</td>
                        <td>
                            <asp:Label ID="lblArrivingFrom_Then" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Flight Number and Airline code:
                        </td>
                        <td>
                            <asp:Label ID="lblAirline_Then" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Estimated Time of Arrival:
                        </td>
                        <td>
                            <asp:Label ID="lblArrival_Then" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr align="left">
                        <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr align="center" >
                                    <td align="left" style="height: 23px" class="name">
                                        &nbsp;&nbsp;Drop Off Information</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td width="25%">
                            <span class="t01">*</span> Hotel Address:</td>
                        <td>
                            <asp:Label ID="lblHotelAddress_Then" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td style="height: 30px">
                            <span class="t01">*</span> City:
                        </td>
                        <td style="height: 30px">
                            <asp:Label ID="lblCity_Then" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Country or Area:
                        </td>
                        <td>
                            <asp:Label ID="lblState_Then" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Zip Code:
                        </td>
                        <td>
                            <asp:Label ID="lblZip_Then" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Phone Number:
                        </td>
                        <td>
                            <asp:Label ID="lblTel_Then" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            <asp:HyperLink ID="hpDetailAndCancel_Then" runat="server" Target="_blank">detail</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<div visible="false" id="divSend" runat="server">
    <table class="order" align="center" border="0" cellpadding="0" cellspacing="0"
        width="100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr align="center">
                        <td height="23" align="left" class="name">
                            <h3>
                                Transportation Information(From Hotel To Airport)</h3>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr align="left">
                        <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr align="center">
                                    <td height="23" align="left" class="name">
                                        &nbsp;&nbsp;Drop Off Information</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td colspan="2">
                                <asp:Label ID="lblName_Send" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td width="25%" style="height: 25px">
                            <span class="t01">*</span> Hotel Address:</td>
                        <td style="height: 25px">
                            <asp:Label ID="lblHotelAddress_Send" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td style="height: 30px">
                            <span class="t01">*</span> City:
                        </td>
                        <td style="height: 30px">
                            <asp:Label ID="lblCity_Send" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Country or Area:
                        </td>
                        <td>
                            <asp:Label ID="lblState_Send" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Zip Code:
                        </td>
                        <td>
                            <asp:Label ID="lblZip_Send" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Phone Number:
                        </td>
                        <td>
                            <asp:Label ID="lblTel_Send" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr align="left">
                        <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr align="center">
                                    <td height="23" align="left" class="name">
                                        &nbsp;&nbsp;Pick Up Information</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td width="25%">
                            <span class="t01">*</span> Arriving From:</td>
                        <td>
                            <asp:Label ID="lblArrivingFrom_Send" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Flight Number and Airline code:
                        </td>
                        <td>
                            <asp:Label ID="lblAirline_Send" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Estimated Time of Arrival:
                        </td>
                        <td>
                            <asp:Label ID="lblArrival_Send" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <span class="t01">*</span> Pickup Time:
                        </td>
                        <td>
                            <asp:Label ID="lblPickupTime" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            <asp:HyperLink ID="hpDetailAndCancel_Send" runat="server" Target="_blank">detail</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
