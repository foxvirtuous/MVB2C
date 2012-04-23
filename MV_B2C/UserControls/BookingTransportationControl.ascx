<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="BookingTransportationControl" Codebehind="BookingTransportationControl.ascx.cs" %>
<div visible="false" id="divThen" runat="server">
    <table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
        width="100%">
        <tr class="R_stepw">
            <td>
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr align="center" class="R_order">
                        <td height="23" align="left">
                            <h3>
                                Transportation Information(From Airport To Hotel)</h3>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                    <tr align="left" class="R_order">
                        <td colspan="2">
                            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                <tr align="center" class="R_order">
                                    <td height="23" align="left">
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
                    <tr align="left" class="R_stepw">
                        <td width="25%">
                            <span class="t01">*</span> Arriving From:</td>
                        <td>
                            <asp:TextBox ID="txtArrivingFrom_Then" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Flight Number and Airline code:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAirline_Then" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Estimated Time of Arrival:
                        </td>
                        <td>
                            <asp:TextBox ID="txtArrival_Then" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                    <tr align="left" class="R_order">
                        <td colspan="2">
                            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                <tr align="center" class="R_order">
                                    <td align="left" style="height: 23px">
                                        &nbsp;&nbsp;Drop Off Information</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td width="25%">
                            <span class="t01">*</span> Hotel Address:</td>
                        <td>
                            <asp:TextBox ID="txtHotelAddress_Then" runat="server" Width="450px" MaxLength="40"></asp:TextBox><br>
                            <asp:TextBox ID="txtHotelAddress1_Then" runat="server" Width="450px" Visible="false"
                                MaxLength="40"></asp:TextBox>
                            <asp:Label ID="lblHotelName_Then" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblHotelCode_Then" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblCityCode_Then" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td style="height: 30px">
                            <span class="t01">*</span> City:
                        </td>
                        <td style="height: 30px">
                            <asp:TextBox ID="txtCity_Then" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Country or Area:
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtState_Then" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="dllCountry_Then" runat="server">
                            </asp:DropDownList><%--
                        <asp:DropDownList ID="dllState_Then" runat="server">
                        </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Zip Code:
                        </td>
                        <td>
                            <asp:TextBox ID="txtZip_Then" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Phone Number:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTel_Then" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<div visible="false" id="divSend" runat="server">
    <table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
        width="100%">
        <tr class="R_stepw">
            <td>
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr align="center" class="R_order">
                        <td height="23" align="left">
                            <h3>
                                Transportation Information(From Hotel To Airport)</h3>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                    <tr align="left" class="R_order">
                        <td colspan="2">
                            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                <tr align="center" class="R_order">
                                    <td height="23" align="left">
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
                    <tr align="left" class="R_stepw">
                        <td width="25%">
                            <span class="t01">*</span> Hotel Address:</td>
                        <td>
                            <asp:TextBox ID="txtHotelAddress_Send" runat="server" Width="450px" MaxLength="40"></asp:TextBox><br>
                            <asp:TextBox ID="txtHotelAddress1_Send" runat="server" Width="450px" Visible="false"
                                MaxLength="40"></asp:TextBox>
                            <asp:Label ID="lblHotelName_Send" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblHotelCode_Send" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblCityCode_Send" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td style="height: 30px">
                            <span class="t01">*</span> City:
                        </td>
                        <td style="height: 30px">
                            <asp:TextBox ID="txtCity_Send" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Country or Area:
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtState_Send" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="dllCountry_Send" runat="server">
                            </asp:DropDownList>
                            <%--  
                        <asp:DropDownList ID="dllState_Send" runat="server">
                        </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Zip Code:
                        </td>
                        <td>
                            <asp:TextBox ID="txtZip_Send" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Phone Number:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTel_Send" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                    <tr align="left" class="R_order">
                        <td colspan="2">
                            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                <tr align="center" class="R_order">
                                    <td height="23" align="left">
                                        &nbsp;&nbsp;Pick Up Information</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td width="25%">
                            <span class="t01">*</span> Arriving From:</td>
                        <td>
                            <asp:TextBox ID="txtArrivingFrom_Send" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Flight Number and Airline code:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAirline_Send" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Estimated Time of Arrival:
                        </td>
                        <td>
                            <asp:TextBox ID="txtArrival_Send" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr align="left" class="R_stepw">
                        <td>
                            <span class="t01">*</span> Pickup Time:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPickupTime" runat="server"></asp:TextBox>
                            <asp:Label ID="lblMinTime" runat="server" ForeColor="Red" Text="Pickup Time must earlier than Estimated Time of Arrival 2 hours"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<asp:Label ID="lblwarning" runat="server" Visible="False" ForeColor="Red"></asp:Label>
<ajaxToolkit:CascadingDropDown ID="cddThen" runat="server" TargetControlID="dllCountry_Then"
    Category="Country" PromptText="Please select a country or area" LoadingText="[Loading hotels...]"
    ServiceMethod="GetDropDownContents" ParentControlID="" />
<ajaxToolkit:CascadingDropDown ID="cddSend" runat="server" TargetControlID="dllCountry_Send"
    Category="Country" PromptText="Please select a country or area" LoadingText="[Loading hotels...]"
    ServiceMethod="GetDropDownContents" ParentControlID="" />
