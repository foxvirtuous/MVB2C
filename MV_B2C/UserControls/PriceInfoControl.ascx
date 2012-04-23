<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="PriceInfoControl" Codebehind="PriceInfoControl.ascx.cs" %>
<%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
<%--<asp:UpdatePanel ID="upPriceInfo" runat="server">
    <ContentTemplate>--%>
        
                    <table align="right" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr valign="top">
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" class="IBE_T_font_11">
                                    <tr align="left" valign="top" class="IBE_T_font_11">
                                        <td width="65%" height="20" align="left">
                                            <font class="t06"><asp:Label ID="lblItem" runat="server" meta:resourcekey="lblItem">Item</asp:Label></font></td>
                                        <td width="12%" align="left">
                                            <font class="t06"><asp:Label ID="lblTraveler" runat="server" meta:resourcekey="lblTraveler">Traveler</asp:Label></font></td>
                                        <td width="7%" align="left">
                                            <font class="t06"><asp:Label ID="lblQuantity" runat="server" meta:resourcekey="lblQuantity">Quantity</asp:Label></font></td>
                                        <td width="16%" align="right">
                                            <font class="t06"><asp:Label ID="lblPrice" runat="server" meta:resourcekey="lblPrice">Price</asp:Label></font><br />
                                            <font class="t08"><asp:Label ID="lblTaxes" runat="server" meta:resourcekey="lblTaxes">includes Taxes & Fees</asp:Label></font></td>
                                    </tr>
                                </table>
                                <!-- Flight or Tour price info begin -->
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr align="left" valign="top" bgcolor="#CCCCCC">
                                        <td colspan="4" height="1">
                                        </td>
                                    </tr>
                                    <!--Adult price info begin -->
                                    <tr align="left" valign="top">
                                        <td width="65%" height="20" align="left">
                                            <asp:Label ID="lbl_FlightTag" runat="server" Visible="false" meta:resourcekey="lblFlight">Flight</asp:Label>
                                            <asp:Label ID="lbl_TourTag" runat="server" Visible="false" meta:resourcekey="lblTour">Tour</asp:Label>
                                            <asp:Label ID="lbl_PackageTag" runat="server" Visible="false" meta:resourcekey="lblPackage">Flight + Hotel</asp:Label>
                                        </td>
                                        <asp:PlaceHolder ID="phAdult" runat="server">
                                            <td width="15%" align="left">
                                                <asp:Label ID="lblAdult" runat="server" meta:resourcekey="lblAdult">Adult(s)</asp:Label></td>
                                            <td width="4%" align="left">
                                                <asp:Label ID="lbAdults" runat="server"></asp:Label></td>
                                            <td width="16%" align="right">
                                                $<asp:Label ID="lbAdultPrice" runat="server"></asp:Label>
                                                <font class="t08">x
                                                    <asp:Label ID="lbAdultNum" runat="server"></asp:Label></font></td>
                                        </asp:PlaceHolder>
                                    </tr>
                                    <!--Adult price info end -->
                                    <!--Child price info begin -->
                                    <!-- Visible is set true when case includes child -->
                                    <asp:PlaceHolder ID="phChild" runat="server">
                                        <tr align="left" valign="top">
                                            <td height="20" align="left">
                                                &nbsp;</td>
                                            <td height="20" align="left">
                                                <asp:Label ID="lblChild" runat="server" meta:resourcekey="lblChild">Child(ren)</asp:Label></td>
                                            <td height="20" align="left">
                                                <asp:Label ID="lbChilds" runat="server"></asp:Label></td>
                                            <td align="right">
                                                $<asp:Label ID="lbChildPrice" runat="server"></asp:Label>
                                                <font class="t08">x
                                                    <asp:Label ID="lbChildNum" runat="server"></asp:Label></font></td>
                                        </tr>
                                    </asp:PlaceHolder>
                                    <!--Child price info end -->
                                </table>
                                <!-- Flight or Tour price info end -->
                                <!-- Agent Flight Markup Begin -->
                                <!-- Visible is set true when current user is subagent and flight type isn't PUB and WEB fare.-->
                                <asp:PlaceHolder ID="phAgentFlightMarkup" runat="server" Visible="false">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr align="left" valign="top" bgcolor="#CCCCCC">
                                            <td colspan="4" height="1">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="65%" height="20" align="left">
                                                Agent Markup</td>
                                            <td width="15%" height="20" align="left">
                                                &nbsp;</td>
                                            <td width="4%" height="20" align="left">
                                                &nbsp;</td>
                                            <td width="16%" align="right">
                                                $<asp:TextBox ID="txtAgentAdultUnitMarkup" Width="50px" MaxLength="6" AutoPostBack="True"
                                                    runat="server" OnTextChanged="txtAgentAdultUnitMarkup_TextChanged" Visible=false></asp:TextBox>
                                                <asp:Label ID="lblAgentAdultUnitMarkup" runat="server" Text="" Visible=false></asp:Label>
                                                <font class="t08"></font>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:RequiredFieldValidator ID="rfvAgentMarkup" runat="server" Display="None" ErrorMessage="Agent markup should be greater than equal $0."
                                        ControlToValidate="txtAgentAdultUnitMarkup">
                                    </asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvAgentMarkup" runat="server" Display="None" ErrorMessage="Agent markup should be greater than equal $0."
                                        ControlToValidate="txtAgentAdultUnitMarkup" Type="Double" Operator="GreaterThanEqual"
                                        ValueToCompare="0.00">
                                    </asp:CompareValidator>&nbsp; </asp:PlaceHolder>
                                <!-- AgentFlight Markup End -->
                                <!-- Agent Flight Service Fee Begin -->
                                <!-- Visible is set true when current user is subagent and flight type is PUB and WEB fare.-->
                                <asp:PlaceHolder ID="phAgentFlightServiceFee" runat="server" Visible="false">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr align="left" valign="top" bgcolor="#CCCCCC">
                                            <td colspan="4" height="1">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="65%" height="20" align="left">
                                                Majestic Service Fee (per ticket)</td>
                                            <td width="15%" height="20" align="left">
                                                &nbsp;</td>
                                            <td width="4%" height="20" align="left">
                                                <asp:Label ID="lblMVServiceFeeQuantity" runat="server"></asp:Label></td>
                                            <td width="16%" align="right">
                                                $<asp:Label ID="lblMVServiceFee" runat="server"></asp:Label>
                                                <font class="t08">x
                                                    <asp:Label ID="lblMVServiceFeeQuantity2" runat="server"></asp:Label></font></td>
                                        </tr>
                                      <%--  <div visible=false>--%>
                                        <tr align="left" valign="top">
                                            <td height="20" align="left">
                                                Agent Service Fee (per ticket)</td>
                                            <td height="20" align="left">
                                                &nbsp;</td>
                                            <td height="20" align="left">
                                                <asp:Label ID="lblAgentServiceFeeQuantity" runat="server"></asp:Label></td>
                                            <td align="right">
                                                $<asp:Label ID="lblAgentServiceFee" runat="server"></asp:Label>
                                                <font class="t08">x
                                                    <asp:Label ID="lblAgentServiceFeeQuantity2" runat="server"></asp:Label></font></td>
                                        </tr><%--</div>--%>
                                    </table>
                                </asp:PlaceHolder>
                                <!-- Agent Flight Service Fee end -->
                                <!-- Insurance info begin -->
                                <!-- Visible is set true when case includes insurance -->
                                <asp:PlaceHolder ID="phInsurance" runat="server" Visible="false">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr align="left" valign="top" bgcolor="#CCCCCC">
                                            <td height="1" colspan="4">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="65%" height="20" align="left">
                                                <asp:Label ID="lblInsurance" runat="server" meta:resourcekey="lblInsurance">Travel Insurance</asp:Label></td>
                                            <td width="15%" align="left">
                                                &nbsp;</td>
                                            <td width="4%" align="left">
                                                &nbsp;</td>
                                            <td width="16%" align="right">
                                                $<asp:Label ID="lbInsurance" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </asp:PlaceHolder>
                                <!-- Insurance info end -->
                                <!-- Total info begin -->
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr align="left" valign="top" bgcolor="#CCCCCC">
                                        <td height="1" colspan="2">
                                        </td>
                                    </tr>
                                    <tr align="left" valign="top">
                                        <td width="90%" height="30" align="right" valign="middle">
                                            <font class="head06"><asp:Label ID="lblTotal" runat="server" meta:resourcekey="lblTotal">Total Price</asp:Label>:</font></td>
                                        <td width="10%" align="right" valign="middle">
                                            <font class="head06">$<asp:Label ID="lbTotalPrice" runat="server"></asp:Label></font></td>
                                    </tr>
                                </table>
                                <!-- Total info end -->
                                <%--<asp:ValidationSummary ID="vsPrice" runat="server" />--%>
                            </td>
                        </tr>
                    </table>
             
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>
