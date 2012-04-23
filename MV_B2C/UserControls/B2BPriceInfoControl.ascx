<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="UserControls_B2BPriceInfoControl" Codebehind="B2BPriceInfoControl.ascx.cs" %>
<table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
    <tr class="R_stepw">
        <td align="left">
            <table align="right" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr valign="top">
                    <td>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr align="left" valign="top">
                                <td width="65%" height="20" align="left">
                                    <font class="t06">Item</font></td>
                                <td width="12%" align="left">
                                    <font class="t06">Traveler</font></td>
                                <td width="7%" align="left">
                                    <font class="t06">Quantity</font></td>
                                <td width="16%" align="right">
                                    <font class="t06">Price</font><br />
                                    <font class="t08">includes Taxes & Fees</font></td>
                            </tr>
                        </table>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr align="left" valign="top" bgcolor="#CCCCCC">
                                <td colspan="4" height="1">
                                </td>
                            </tr>
                            <tr align="left" valign="top">
                                <td width="65%" height="20" align="left">
                                    <asp:Label ID="lbl_FlightTag" runat="server" Visible="false">Flight</asp:Label>
                                    <asp:Label ID="lbl_TourTag" runat="server" Visible="false">Tour</asp:Label>
                                </td>
                                <asp:PlaceHolder ID="phAdult" runat="server">
                                    <td width="15%" align="left">
                                        Adult(s)</td>
                                    <td width="4%" align="left">
                                        <asp:Label ID="lbAdults" runat="server"></asp:Label></td>
                                    <td width="16%" align="right">
                                        $<asp:Label ID="lbAdultPrice" runat="server"></asp:Label>
                                        <font class="t08">x
                                            <asp:Label ID="lbAdultNum" runat="server"></asp:Label></font></td>
                                </asp:PlaceHolder>
                            </tr>
                            <asp:PlaceHolder ID="phChild" runat="server">
                                <tr align="left" valign="top">
                                    <td height="20" align="left">
                                        &nbsp;</td>
                                    <td height="20" align="left">
                                        Child(ren)</td>
                                    <td height="20" align="left">
                                        <asp:Label ID="lbChilds" runat="server"></asp:Label></td>
                                    <td align="right">
                                        $<asp:Label ID="lbChildPrice" runat="server"></asp:Label>
                                        <font class="t08">x
                                            <asp:Label ID="lbChildNum" runat="server"></asp:Label></font></td>
                                </tr>
                            </asp:PlaceHolder>
                        </table>
                        <!-- Agent Flight Markup Begin -->
                        <!-- Visible is set true when current user is subagent.-->
                        <asp:PlaceHolder ID="phAgentFlightMarkup" runat="server">
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr align="left" valign="top" bgcolor="#CCCCCC">
                                    <td colspan="4" height="1">
                                    </td>
                                </tr>
                                <!-- Adult Markup Begin -->
                                <tr align="left" valign="top">
                                    <td height="20" align="left">
                                        &nbsp;</td>
                                    <td height="20" align="left">
                                        Adult(s)</td>
                                    <td height="20" align="left">
                                        <asp:Label ID="lblAgentAdultQuantity" runat="server"></asp:Label></td>
                                    <td align="right">
                                        $<asp:TextBox ID="lblAgentAdultUnitMarkup" Width="50px" MaxLength="6" runat="server"></asp:TextBox>
                                        <font class="t08">x
                                            <asp:Label ID="lblAgentAdultNumber" runat="server"></asp:Label></font></td>
                                </tr>
                                <!-- Adult Markup End -->
                                <!-- Child Markup Begin -->
                                <asp:PlaceHolder ID="phAgentChildFlightMarkup" runat="server">
                                    <tr align="left" valign="top">
                                        <td height="20" align="left">
                                            &nbsp;</td>
                                        <td height="20" align="left">
                                            Child(ren)</td>
                                        <td height="20" align="left">
                                            <asp:Label ID="lblAgentChildQuantity" runat="server"></asp:Label></td>
                                        <td align="right">
                                            $<asp:TextBox ID="lblAgentChildUnitMarkup" Width="50px" MaxLength="6" runat="server"></asp:TextBox>
                                            <font class="t08">x
                                                <asp:Label ID="lblAgentChildNumber" runat="server"></asp:Label></font></td>
                                    </tr>
                                </asp:PlaceHolder>
                                <!-- Child Markup End -->
                            </table>
                        </asp:PlaceHolder>
                        <!-- AgentFlight Markup End -->
                        <asp:PlaceHolder ID="phInsurance" runat="server" Visible="false">
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr align="left" valign="top" bgcolor="#CCCCCC">
                                    <td height="1" colspan="4">
                                    </td>
                                </tr>
                                <tr align="left" valign="top">
                                    <td width="65%" height="20" align="left">
                                        Travel Insurance</td>
                                    <td width="15%" align="left">
                                        &nbsp;</td>
                                    <td width="4%" align="left">
                                        &nbsp;</td>
                                    <td width="16%" align="right">
                                        $<asp:Label ID="lbInsurance" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:PlaceHolder>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr align="left" valign="top" bgcolor="#CCCCCC">
                                <td height="1" colspan="2">
                                </td>
                            </tr>
                            <tr align="left" valign="top">
                                <td width="90%" height="30" align="right" valign="middle">
                                    <font class="head06">Total Price:</font></td>
                                <td width="10%" align="right" valign="middle">
                                    <font class="head06">$<asp:Label ID="lbTotalPrice" runat="server"></asp:Label></font></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
