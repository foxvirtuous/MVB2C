<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HotelPrintInvoice.aspx.cs"
    Inherits="Terms.Web.Page.Hotel2.HotelPrintInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
.frame_border{width:920px; margin:0 auto;}
.top{ background:url(../../images/v2/GatewayTravel_Logo.gif) no-repeat; text-align:right; width:100%; float:left;}
.content{ width:100%; float:left; font-size:16px; font-family:Verdana, Arial, Helvetica, sans-serif;}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="frame_border">
            <div class="top">
                <img src="../../images/v2/MJV_Logo.jpg" />
            </div>
            <div class="content">
                <table cellpadding="0" cellspacing="0" border="0" width="91%" style="margin-top: 120px;">
                    <tr>
                        <td width="600">
                        </td>
                        <td align="center">
                            <asp:Label ID="lblInvoice" runat="server" Text="Label"></asp:Label> ITINERARY INVOICE<br />
                            PAGE NO.</td>
                    </tr>
                    <tr>
                        <td width="600">
                        </td>
                        <td align="left" style="padding-top: 15px;">
                            PNR:<asp:Label ID="lblPNR" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: 120px;">
                    <tr>
                        <td colspan="2">
                            <asp:DataList ID="dlPassenger" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                                Width="100%">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirst" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FirstName") %>'></asp:Label>&nbsp;
                                    <asp:Label ID="lblMiddle" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MiddleName") %>'></asp:Label>&nbsp;
                                    <asp:Label ID="lblLast" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LastName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                        <td width="24%">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="30">
                        </td>
                    </tr>
                    <tr>
                        <td width="43%" align="center">
                        </td>
                        <td align="center" width="33%">
                            ACCT CODE</td>
                        <td align="center" width="24%">
                            <asp:Label ID="lblAcountCode" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <asp:DataList ID="dlInfo" runat="server" Width="100%">
                    <ItemTemplate>
                        <table cellpadding="3" cellspacing="0" border="0" width="100%" style="margin-top: 60px;">
                            <tr>
                                <td width="5%">
                                    T TU</td>
                                <td>
                                    <asp:Label ID="lblMonthAndDay" runat="server" Text=""></asp:Label></td>
                                <td width="78%">
                                    <asp:Label ID="lblVenderCode" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblState" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblYear" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblHotelName" runat="server" Text=""></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblRoomInfo" runat="server" Text=""></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblHotelNo" runat="server" Text=""></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblCaseNumber" runat="server" Text=""></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <table cellpadding="3" cellspacing="0" border="0" width="100%" style="margin-top: 20px;">
                    <tr>
                        <td width="5%">
                        </td>
                        <td width="35%">
                            LAND</td>
                        <td align="center">
                            <asp:Label ID="lblNetPrice" runat="server" Text=""></asp:Label></td>
                        <td width="35%">
                            TAX</td>
                        <td align="center">
                            <asp:Label ID="lblTax" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            SUBTOTAL</td>
                        <td align="center">
                            <asp:Label ID="lblSubPrice" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            TOTAL INVOICE AMOUNT</td>
                        <td align="center">
                            <asp:Label ID="lblSubPrice2" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            AMOUNT DUE</td>
                        <td align="center">
                            <asp:Label ID="lblSubPrice3" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center" style="padding-top: 30px;">
                            THANK YOU FOR YOUR BUSINESS</td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
