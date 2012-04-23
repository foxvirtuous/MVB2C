<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HTLTotalPriceControl.ascx.cs"
    Inherits="HTLTotalPriceControl" %>
<table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
    <tr class="R_stepw">
        <td align="left">
            <table align="right" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr valign="top">
                    <td>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr align="left" valign="top">
                                <td height="30" align="left">
                                    <span class="t04"><span class="tour_day"><asp:Label ID="lblHotelInformation" runat="Server" meta:resourcekey="lblHotelInformation">Your Hotel Information</asp:Label></span></span></td>
                                <td width="15%" align="left">
                                    &nbsp;</td>
                                <td width="10%" align="left">
                                    &nbsp;</td>
                                <td width="16%" align="right">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <table align="center" border="0" cellpadding="5" cellspacing="0" width="100%">
                            <tr align="left" valign="top">
                                <td style="border-top: 1px solid #D8D8D8;" height="24" align="left">
                                    <strong><asp:Label ID="lblHotelname1" runat="Server" meta:resourcekey="lblHotelname">Hotel name</asp:Label>: </strong><asp:Label ID="lblHotelName" runat="server"></asp:Label><br />
                                    <strong><asp:Label ID="lblCheck_In" runat="Server" meta:resourcekey="lblCheck_In">Check In</asp:Label>:</strong>
                                    <asp:Label ID="lblCheckIn" runat="server"></asp:Label><br />
                                    <strong><asp:Label ID="lblCheck_Out" runat="Server" meta:resourcekey="lblCheck_Out">Check Out</asp:Label>:</strong>
                                    <asp:Label ID="lblCheckOut" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        <table align="center" border="0" cellpadding="5" cellspacing="0" width="100%">
                            <asp:Repeater ID="rptRooms" runat="server">
                                <ItemTemplate>
                                    <tr align="left" valign="top">
                                        <td align="left" style="border-top: 1px solid #D8D8D8;">
                                            <strong><asp:Label ID="lblRoom" runat="server" Text='<%# "Room " + (Container.ItemIndex + 1).ToString()%>'></asp:Label></strong> 
                                            <asp:Label ID="lblDrip" runat="server" Text='<%# " ( " + DataBinder.Eval(Container.DataItem, "Profile.AdultNumber") + " Adult " + DataBinder.Eval(Container.DataItem, "Profile.ChildNumber") + " Child" + ")"%>'></asp:Label>:
                                            <asp:Label ID="lblroomDel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Name")%>'></asp:Label>,
                                            <asp:Label ID="lblNights" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nights")%>'></asp:Label> Nights<br />
                                        </td>
                                        <td width="15%" align="left" style="border-top: 1px solid #D8D8D8;">
                                            &nbsp;</td>
                                        <td width="10%" style="border-top: 1px solid #D8D8D8;">
                                            &nbsp;</td>
                                        <td width="16%" align="right" style="border-top: 1px solid #D8D8D8;">
                                            $<asp:Label ID="lblRoomPrice" runat="server" Text='<%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "RoomPrice")).ToString("N2")%>'></asp:Label><br />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div style="text-align: right; border-top: 1px solid #D8D8D8;" id="divMarkup" visible=false runat=server>
                                   <asp:Label ID="Label1" runat="Server" meta:resourcekey="lblMArkup">Mark Up</asp:Label>: $ <asp:Label ID="lblMArkup" runat="server"></asp:Label> 
                       </div>
                        <div class="MV_hotel_step5_hotelInfo_price MV_head09">
                                   <asp:Label ID="lblTotalPrice1" runat="Server" meta:resourcekey="lblTotalPrice">Total Price</asp:Label>: $ <asp:Label ID="lblTotalPrice" runat="server"></asp:Label> 
                       </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
