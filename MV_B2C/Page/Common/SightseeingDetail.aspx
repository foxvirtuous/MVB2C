<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="SightseeingDetail" Codebehind="SightseeingDetail.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare,
        Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 90%; height: 90%">
                <tr>
                    <td style="width: 70%; height: 100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                            <tr>
                                <td colspan="2">
                                    <strong>Sightseeing Information</strong></td>
                            </tr>
                            <tr>
                                <td width="5%">
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label><br />
                                    <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td><asp:Label ID="lblMore" runat="server" Text=""></asp:Label><br />
                                    <asp:Label ID="lblTime" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <strong>The Tour</strong></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblTour" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <strong>Includes</strong></td>
                            </tr> 
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblIncludes" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <strong>Please note</strong></td>
                            </tr> 
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblNote" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField HeaderText="Language" />
                                            <asp:BoundField HeaderText="Commentary" />
                                            <asp:BoundField HeaderText="From Date" />
                                            <asp:BoundField HeaderText="To Date" />
                                            <asp:BoundField HeaderText="Days of week" />
                                            <asp:BoundField HeaderText="Start Time" />
                                            <asp:BoundField HeaderText="Departure Point" />
                                        </Columns>
                                        <FooterStyle Width="100%" />
                                        <HeaderStyle Wrap="false" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 30%; height: 100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                            <tr>
                                <td>
                                    <asp:Image ID="imgTour" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Additional Information<br />
                                    <asp:Label ID="lblInformation" runat="server" Text=""></asp:Label>
                                    <asp:HyperLink ID="HyperLink1" runat="server" Target=_blank>Check Here</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Main Departure Points<br />
                                    <asp:Label ID="lblPoints" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
