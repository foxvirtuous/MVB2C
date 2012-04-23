<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HTLInfoControl.ascx.cs" Inherits="HTLInfoControl" %>
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
                                                <asp:Label ID="lblSearchCondition" runat="Server" meta:resourcekey="lblSearchCondition">Search Condition</asp:Label></td>
                                                <td width="29%" align="right" valign="top"><div visible="false" runat="server" id="divReturn"><img src="../../images/v2/arrow.gif" hspace="2" align="absmiddle" /> 
                                                <a id="hotelSelect2" href="SearchResultForm.aspx" class="d09">
                                                    <asp:Label ID="lblReturnSelection" runat="server" Text="lblReturnSelection">Return to Hotel Selection</asp:Label></a></div></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                    <tr class="R_stepw">
                                                        <td>
                                                            <div>
                                                                <asp:Label ID="lblYour" runat="Server" meta:resourcekey="lblYour">Your</asp:Label>
                                                                <asp:Label ID="Label1" runat="Server" Text=" "></asp:Label>
                                                                <asp:Label ID="lblDayNumber" runat="server" Text="1"></asp:Label>
                                                                <asp:Label ID="Label2" runat="Server" Text=" "></asp:Label>
                                                                <asp:Label ID="lblNightStay" runat="Server" meta:resourcekey="lblNightStay">Night(s) Stay at</asp:Label>
                                                                
                                                                <font class="t06">
                                                                    <asp:Label ID="lblHotelName" runat="server"></asp:Label><asp:Label ID="lblCityName" runat="server" Text="shanghai" style="font-weight:bold;"></asp:Label></font>
                                                                <br />
                                                                <asp:Label ID="lblCheck_in" runat="Server" meta:resourcekey="lblCheck_in">Check in</asp:Label>:<font class="t06">
                                                                <asp:Label ID="lblCheckIn" runat="server" Visible="False" style="font-weight:bold;"></asp:Label></font>,
                                                                <asp:Label ID="lblCheck_out" runat="Server" meta:resourcekey="lblCheck_out">Check out</asp:Label>:<font class="t06">
                                                                <asp:Label ID="lblCheckOut" runat="server" Visible="False" style="font-weight:bold;"></asp:Label></font><br />
                                                                <asp:Label ID="lblRooms" runat="server" Text=""></asp:Label>
                                                            </div>
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