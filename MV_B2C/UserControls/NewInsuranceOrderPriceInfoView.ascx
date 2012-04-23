<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewInsuranceOrderPriceInfoView.ascx.cs"
    Inherits="NewInsuranceOrderPriceInfoView" %>
<table class="IBE_package_SearchCondition_T_step04" align="right" border="0" cellpadding="0"
    cellspacing="0" width="100%">
    <tbody>
        <tr valign="top">
            <td>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="border-bottom: 1px solid #ccc;">
                    <tbody>
                        <tr align="left" valign="top">
                            <td align="left" height="20">
                                <font class="step3_price_price_t06">Item</font></td>
                            <td align="left" style="width: 10%">
                                <font class="step3_price_price_t06">Quantity</font></td>
                            <td width="16%" align="right">
                                <font class="step3_price_price_t06">Price</font>
                                <br />
                                <font class="IBE_t08">includes Taxes &
                                    <br />
                                    Fees</font>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:DataList runat="server" ID="dlPrice" Width="100%">
                    <ItemTemplate>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="border-bottom: 1px solid #ccc;">
                            <tbody>
                                <tr valign="top" align="left">
                                    <td align="left" height="20">
                                        <asp:Label ID="lblHotelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ItemName")%>'></asp:Label></td>
                                    <td style="width: 10%">
                                        <asp:Label ID="lblPassageNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"RoomCount")%>'></asp:Label></td>
                                    <td align="right" width="16%">
                                        $<asp:Label ID="lblItemTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Price")%>'></asp:Label><font
                                            class="t081">x&nbsp;<asp:Label ID="lblPassageNumber2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"RoomCount")%>'></asp:Label></font></td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="border-bottom: 1px solid #ccc;">
                    <tbody>
                        <tr valign="top" align="left">
                            <td align="left" height="20">
                                <asp:Label ID="Label1" runat="server" Text="Commission"></asp:Label></td>
                            <td style="width: 10%"></td>
                            <td align="right" width="16%">
                                $<asp:Label ID="lblCommission" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
                <table align="right" border="0" cellpadding="0" cellspacing="0" width="100%" style="border-bottom: 1px solid #ccc;">
                    <tr valign="top">
                        <td>
                            <font class="step3_price_price_t06">GTT Order NetPrice</font>
                        </td>
                        <td align="right">
                            <font class="step3_price_price_t06">GTT Selling Price</font>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td>
                            <asp:Label ID="lblNetPrice" runat="server" Text=""></asp:Label></td>
                        <td align="right">
                            <asp:Label ID="lblSellPrice" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </tbody>
</table>
