<%@ Control Language="C#" AutoEventWireup="true" Inherits="TourPriceNewInfoControl"
    Codebehind="TourTravelerAndPriceInfoControl.ascx.cs" %>
<asp:UpdatePanel ID="upPriceInfo" runat="server">
    <ContentTemplate>
        <asp:DataList ID="dlRoomTypes" runat="server" Width="100%">
            <HeaderTemplate>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td width="30%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                <font class="t06">
                                    <asp:Label ID="lblRoomType" runat="server" meta:resourcekey="lblRoomType">Room Type</asp:Label></font>
                                <font color="#FF3300">*</font></td>
                            <td width="25%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                &nbsp;</td>
                            <td width="15%" align="center" style="border-bottom: solid #cccccc 1px">
                                <font class="t06">
                                    <asp:Label ID="lblPricePerPerson" runat="server" meta:resourcekey="lblPricePerPerson">Price(Per person)</asp:Label></font></td>
                            <td width="30%" align="center" style="border-bottom: solid #cccccc 1px">
                                <font class="t06">
                                    <asp:Label ID="lblNumberOfPassengers" runat="server" meta:resourcekey="lblNumberOfPassengers">Number of Passengers</asp:Label></font>
                                <font color="#FF3300">*</font></td>
                        </tr>
                    </tbody>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:DataList ID="dlRoomTypeNumber" runat="server" Width="100%">
                    <ItemTemplate>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" runat="server" id="tbQuat">
                            <tbody>
                                <tr>
                                    <td width="30%" rowspan="3" align="center" style="border-bottom: solid #cccccc 1px">
                                        <asp:Label ID="lblRoomTypeName" runat="server"></asp:Label>&nbsp;Room&nbsp;(<asp:Label
                                            ID="lblRoomNum" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>)</td>
                                    <td width="25%" height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAdult111" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label></td>
                                    <td width="15%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                        USD $<asp:Label runat="server" ID="lblAdultPrice"></asp:Label></td>
                                    <td width="30%" align="center" style="border-bottom: solid #cccccc 1px">
                                        <asp:DropDownList ID="ddlAdult" runat="server" CssClass="search_sle" Width="35px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlAdult_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">0</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:Label ID="lblAdult" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Adult") %>'
                                            Visible="false"></asp:Label>--%>
                                    </td>
                                </tr>
                                <tr runat="server" id="trChild" visible=false>
                                    <td height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" meta:resourcekey="lblChild">Child</asp:Label></td>
                                    <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                        USD $<asp:Label runat="server" ID="lblChildPrice"></asp:Label></td>
                                    <td height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                        <asp:DropDownList ID="ddlChild" runat="server" CssClass="search_sle" Width="35px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlChild_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:Label ID="lblChild" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Child") %>'
                                            Visible="false"></asp:Label>--%>
                                    </td>
                                </tr>
                                <tr runat="server" id="trChildWithOut"  visible=false>
                                    <td width="20%" height="25" align="left" style="border-bottom: solid #cccccc 1px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" meta:resourcekey="lblChildWithOut">Child (without bed)</asp:Label></td>
                                    <td width="15%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                        USD $<asp:Label runat="server" ID="lblChildWithOutPrice"></asp:Label></td>
                                    <td width="25%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                        <asp:DropDownList ID="ddlChildWithOut" runat="server" CssClass="search_sle" Width="35px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlChildWithOut_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:Label ID="lblChildWithOut" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ChildWithOut") %>'
                                            Visible="false"></asp:Label>--%>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </ItemTemplate>
        </asp:DataList>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="T_step03">
            <tr class="R_stepw">
                <td align="left">
                    <table align="right" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr valign="top">
                            <td>
                                <asp:PlaceHolder ID="phAgentFlightMarkup" runat="server" Visible="false">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr align="left" valign="top" bgcolor="#CCCCCC">
                                            <td colspan="4" height="1">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="65%" height="20" align="left">
                                                <asp:Label ID="lblAgentMarkup" runat="server" meta:resourcekey="lblAgentMarkup">Agent Markup</asp:Label></td>
                                            <td width="15%" height="20" align="left">
                                                &nbsp;</td>
                                            <td width="4%" height="20" align="left">
                                                &nbsp;</td>
                                            <td width="16%" align="right">
                                                $<asp:TextBox ID="txtAgentAdultUnitMarkup" Width="50px" MaxLength="6" AutoPostBack="True"
                                                    runat="server" Visible="false"></asp:TextBox>
                                                <asp:Label ID="lblAgentAdultUnitMarkup" runat="server" Text="" Visible="false"></asp:Label>
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
                                                <asp:Label ID="lblDeparturefrom" runat="server" meta:resourcekey="lblDeparturefrom">Departure from</asp:Label>
                                                <asp:Label ID="lblFromCity" runat="server">Dallas</asp:Label>
                                                To
                                                <asp:Label ID="lblToCity" runat="server">Shanghai</asp:Label>
                                                <asp:Label ID="lblMustOn" runat="server" meta:resourcekey="lblMustOn">(must add on)</asp:Label></td>
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
                                        <asp:PlaceHolder ID="phTourInsurance" runat="server" Visible="false">
                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="display:none" >
                                                <tr align="left" valign="top" bgcolor="#CCCCCC">
                                                    <td height="1" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr align="left" valign="top">
                                                    <td width="62%" height="20" align="left">
                                                        <asp:Label ID="lblTravelInsurance" runat="server" meta:resourcekey="lblTravelInsurance">Travel Insurance(Option)</asp:Label>
                                                        <div id="div_IsSelected" runat="server">
                                                            <asp:CheckBox ID="chkTourInsurance" Checked="false" runat="server" OnCheckedChanged="chkTourInsurance_CheckedChanged"
                                                                AutoPostBack="True" />
                                                            <font class="t05">
                                                                <asp:Label ID="lblBuyTrip" runat="server" meta:resourcekey="lblBuyTrip">Buy insurance for this trip</asp:Label>
                                                            </font>
                                                            <asp:HyperLink ID="hlInsuranceDetails" runat="server" meta:resourcekey="hlMore">
                                            more info</asp:HyperLink></div>
                                                    </td>
                                                    <%--<td width="15%" align="left">
                                                        &nbsp;</td>
                                                    <td width="4%" align="left">
                                                        &nbsp;</td>--%>
                                                    <td width="38%" align="left">
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
                                                    <span>
                                                        <asp:Label ID="lblAdults" runat="server">0</asp:Label>
                                                        <asp:Label ID="lblAdultDisp" runat="server" meta:resourcekey="lblAdultDisp">Adult(s)</asp:Label>
                                                        <asp:Label ID="lblChilds" runat="server">0</asp:Label>
                                                        <asp:Label ID="lblChildDisp" runat="server" meta:resourcekey="lblChildDisp">Child(ren)</asp:Label>
                                                        <asp:Label ID="lblChildWithOuts" runat="server">0</asp:Label>
                                                        <asp:Label ID="lblChildWithOutDisp" runat="server" meta:resourcekey="lblChildWithOut">Child(Without bed)</asp:Label>
                                                    </span><font class="head06">
                                                        <asp:Label ID="lblTotalPrice" runat="server" meta:resourcekey="lblTotalPrice">Total Price</asp:Label>:</font></td>
                                                <td width="10%" align="right" valign="middle">
                                                    <font class="head06">$<asp:Label ID="lbTotalPrice" runat="server"></asp:Label></font></td>
                                            </tr>
                                            <tr align="left" valign="top">
                                                <td colspan="2" align="right" valign="top" style="height: 19px">
                                                    <font class="t08">
                                                        <asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsg">excluding Taxes & Fees</asp:Label></font>
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
