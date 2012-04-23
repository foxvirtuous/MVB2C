<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="TourPriceInfoControl" Codebehind="TourPriceInfoControl.ascx.cs" %>
<asp:UpdatePanel ID="upPriceInfo" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
            <tr class="R_stepw">
                <td align="left">
                    <table align="right" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr valign="top">
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr align="left" valign="top">
                                        <td width="40%" height="20" align="left">
                                            <font class="t06"><asp:Label ID="lblItem" runat="server" meta:resourcekey="lblItem">Item</asp:Label></font></td>
                                       <%-- <td width="8%" height="20">
                                            <font class="t06">Room NO.</font></td>--%>
                                        <td height="20" style="width: 12%">
                                            <font class="t06"><asp:Label ID="lblRoomType" runat="server" meta:resourcekey="lblRoomType">Room Type</asp:Label></font></td>
                                        <td width="20%" align="left">
                                            <font class="t06"><asp:Label ID="lblTraveler" runat="server" meta:resourcekey="lblTraveler">Traveler</asp:Label></font></td>
                                        <td align="left" style="width: 8%">
                                            <font class="t06"><asp:Label ID="lblQuantity" runat="server" meta:resourcekey="lblQuantity">Quantity</asp:Label></font></td>
                                        <td width="160%" align="right">
                                            <font class="t06"><asp:Label ID="lblPrice" runat="server" meta:resourcekey="lblPrice">Price</asp:Label></font></td>
                                    </tr>
                                </table>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr align="left" valign="top" bgcolor="#CCCCCC">
                                        <td colspan="6" height="1">
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rpTourRooms" runat="server" OnItemDataBound="rpTourRooms_ItemDataBound">
                                        <ItemTemplate>
                                            <tr align="left" valign="top">
                                                <td width="40%" align="left" style="height: 7px">
                                                    <asp:Label ID="lbl_TourTag" runat="server" meta:resourcekey="lblTour">Tour</asp:Label>
                                                </td>
                                                <%--<td width="8%" align="left" style="height: 7px">
                                                    <asp:Label ID="lbl_RoomNO" runat="server">1</asp:Label>
                                                </td>--%>
                                                <td align="left" style="width: 12%; height: 7px">
                                                    <asp:Label ID="lbl_RoomType" runat="server">Twin</asp:Label>
                                                </td>
                                                <td width="20%" align="left" style="height: 7px">
                                                    <asp:Label ID="lbl_PersonType" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 8%; height: 7px" align="left">
                                                    <asp:Label ID="lbl_PersonNumber" runat="server"></asp:Label>
                                                </td>
                                                <td width="16%" style="height: 7px" align="right">
                                                    <asp:Label ID="lbl_Price" runat="server"></asp:Label>
                                                    <font class="t08">x</font>
                                                    <asp:Label ID="lbl_PriceNumber" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
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
                                <asp:PlaceHolder ID="phTourAddOn" runat="server" Visible="false">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr align="left" valign="top" bgcolor="#CCCCCC">
                                            <td height="1" colspan="4">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="65%" height="20" align="left">
                                                Departure from
                                                <asp:Label ID="lblFromCity" runat="server">Dallas</asp:Label>
                                                To
                                                <asp:Label ID="lblToCity" runat="server">Shanghai</asp:Label>
                                                (must add on)</td>
                                            <td width="15%" align="left">
                                                &nbsp;</td>
                                            <td width="4%" align="left">
                                                &nbsp;</td>
                                            <td width="16%" align="right">
                                                $<asp:Label ID="lbl_TourAddOn" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </asp:PlaceHolder>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="phTourInsurance" runat="server" Visible="false" >
                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" >
                                                <tr align="left" valign="top" bgcolor="#CCCCCC">
                                                    <td height="1" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr align="left" valign="top">
                                                    <td width="65%" height="20" align="left">
                                                        <asp:Label ID="lblTravelInsurance" runat="server" meta:resourcekey="lblTravelInsurance">Travel Insurance</asp:Label> 
                                                        <div id="div_IsSelected" runat="server">
                                                            <asp:CheckBox ID="chkTourInsurance" Checked="true" runat="server" OnCheckedChanged="chkTourInsurance_CheckedChanged"
                                                                AutoPostBack="True" />
                                                            <font class="t05"><asp:Label ID="lblBuyInsurance" runat="server" meta:resourcekey="lblBuyInsurance">Buy insurance for this trip</asp:Label> </font>
                                                            <asp:HyperLink ID="hlInsuranceDetails" runat="server">
                                            <asp:Label ID="lblMoreInfo" runat="server" meta:resourcekey="lblMoreInfo">more info</asp:Label></asp:HyperLink></div>
                                                    </td>
                                                    <td width="15%" align="left">
                                                        &nbsp;</td>
                                                    <td width="4%" align="left">
                                                        &nbsp;</td>
                                                    <td width="16%" align="right">
                                                        $<asp:Label ID="lblTourInsurance" runat="server"></asp:Label></td>
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
                                                    <font class="head06"><asp:Label ID="lblTotalPrice" runat="server" meta:resourcekey="lblTotalPrice">Total Price</asp:Label>:</font></td>
                                                <td width="10%" align="right" valign="middle">
                                                    <font class="head06">$<asp:Label ID="lbTotalPrice" runat="server"></asp:Label></font></td>
                                            </tr>
                                            <tr align="left" valign="top">
                                                <td colspan="2" align="right" valign="top" style="height: 19px">
                                                    <font class="t08"><asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsg">excluding Taxes & Fees</asp:Label></font>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
