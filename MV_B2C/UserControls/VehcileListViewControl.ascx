<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VehcileListViewControl.ascx.cs"
    Inherits="Terms.Web.UserControls.VehcileListViewControl" %>
<%@ Register Src="~/Page/Flight/Module/PageNumber.ascx" TagName="PageNumberControl"
    TagPrefix="uc3" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="left" style="padding: 0px 0px 10px 0px;">
            Showing
            <asp:Label ID="lblPageRowNumber" runat="server" Text="" CssClass="t02"></asp:Label>
            Car(s) of
            <asp:Label ID="lblRowNumber" runat="server" Text="" CssClass="t02"></asp:Label>
            Total
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                <tr class="R_stepo">
                    <td valign="top" bgcolor="#F8F8F8">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr valign="top">
                                    <td height="30" align="left" valign="middle" style="font-size: 18px; color: #000000;">
                                        Pick up: <span id="Span1"><b>
                                            <asp:Label ID="lblPickupCode" runat="server" Text=""></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;Drop
                                            off: <b>
                                                <asp:Label ID="lblDropoffCode" runat="server" Text=""></asp:Label></b></span></td>
                                </tr>
                                <tr valign="top">
                                    <td align="left" valign="middle" style="font-size: 17px; color: #333333; height: 30px;">
                                        <asp:Label ID="lblCheckIn" runat="server" Text=""></asp:Label>
                                        -
                                        <asp:Label ID="lblCheckOut" runat="server" Text=""></asp:Label>.
                                        <asp:Label ID="lblDays" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="7">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="1" cellpadding="0" class="T_step0l">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="1" cellpadding="0">
                                                    <tr class="R_step03" align="center">
                                                        <td height="30" align="left">
                                                            <table id="Table1" style="display: block; border-collapse: collapse; visibility: visible;"
                                                                align="left" border="0" cellspacing="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;&nbsp;<span id="Span2" face="Arial" style="font-weight: 700; font-size: 9pt;">Sort
                                                                                By</span>&nbsp;</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlSort" runat="server" size="1" AutoPostBack="true">
                                                                                <asp:ListItem Value="0">Price</asp:ListItem>
                                                                                <asp:ListItem Value="1">Car Type</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr class="R_stepw">
                                            <td>
                                                <div id="divList" runat="server">
                                                    <asp:DataList ID="dlHotelInfo" runat="server" OnItemCommand="dlHotelInfo_ItemCommand"
                                                        Width="100%">
                                                        <ItemTemplate>
                                                            <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1">
                                                                <tr align="left" class="R_stepw">
                                                                    <td width="37%" align="center" style="padding-top: 10px; padding-bottom: 10px; border-bottom: solid #cccccc 1px;">
                                                                        <asp:Image ID="imgVonder" runat="server" Width="100" Height="47" vspace="5" border="0" /><br />
                                                                        <img src="../../images/v2/car_icon_air.gif" vspace="2" border="0" align="absmiddle" />
                                                                        <b>
                                                                            <asp:Label ID="lblPickup" runat="server" Text=""></asp:Label></b>
                                                                    </td>
                                                                    <td width="25%" align="center" style="padding-top: 10px; padding-bottom: 10px; border-bottom: solid #cccccc 1px;">
                                                                        <asp:Image ID="imgCar" runat="server" Width="150" vspace="5" border="0" onerror="this.src='../../images/v2/Car_Default.jpg';" /><br />
                                                                        <b>
                                                                            <asp:Label ID="lblCarSize" runat="server" Text=""></asp:Label></b><br />
                                                                        <span class="t04">(<asp:Label ID="lblCarName" runat="server" Text=""></asp:Label>)</span></td>
                                                                    <td width="16%" align="center" style="padding-top: 10px; padding-bottom: 10px; border-bottom: solid #cccccc 1px;">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td align="right" width=50%>
                                                                                    <asp:Label ID="lblCarCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Image ID="imgPassengerQuantity" runat="server" vspace="3" />
                                                                                </td>
                                                                                <td align="left">&nbsp;<asp:Label ID="lblX" runat="server" Text=" X "></asp:Label><asp:Label ID="lblPassengerQuantityImg"
                                                                                        runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="2">
                                                                                    <asp:Label ID="lblCarVonder" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Image ID="imgBaggageQuantity" runat="server" /></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td width="22%" align="center" style="padding-top: 10px; padding-bottom: 10px; border-bottom: solid #cccccc 1px;">
                                                                        <font color="#FF3300">
                                                                            <asp:Label ID="lblPrePrice" runat="server" Text="" Style="font-size: 26px; font-weight: bold;"></asp:Label>/Day</font><br />
                                                                        <br />
                                                                        <span class="t04">Total with Taxes:</span>
                                                                        <asp:Label ID="lblTotalPrice" runat="server" Text="" CssClass="t04"></asp:Label><br />
                                                                        <asp:ImageButton ID="btnSelect" runat="server" Text="Select Vehicle" CommandName="Select"
                                                                            ImageUrl="~/images/car_btn_select.gif" Width="120" Height="24" vspace="5" border="0" /></td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:DataList></div>
                                                <div id="divSorry" visible="false" runat="server">
                                                    <table class="ResultMessage" cellspacing="3" cellpadding="4" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td valign="top" width="90%" align="center">
                                                                    <span class="msgHead">
                                                                        <br>
                                                                        Sorry, your choices have hidden all of the cars!<br>
                                                                    </span>
                                                                    <br>
                                                                    <asp:LinkButton ID="lbtnCheckAll" runat="server" CssClass="linkLeftNavy">Click here show all cars</asp:LinkButton>
                                                                </td>
                                                                <td align="middle" width="10%">
                                                                    <img height="108" src="../../images/v2/ErrorReminder.gif" width="80" border="0">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="D_stepg">
                                    <div id="divPage" runat="server">
                                        <uc3:PageNumberControl ID="PageNumberControl1" runat="server" />
                                    </div>
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
        </td>
    </tr>
</table>
