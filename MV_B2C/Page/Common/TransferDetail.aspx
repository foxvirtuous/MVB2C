<%@ Page Language="C#" AutoEventWireup="true" Inherits="TransferDetailMain" Codebehind="TransferDetail.aspx.cs" %>

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
        <div id="content">
            <br>
            <table width="100%" cellspacing="0" cellpadding="0" align="center" border="0">
                <tr>
                    <td width="100%" align="left">
                        <span style="font-size: 18px;">Private Transfer Information</span></td>
                </tr>
            </table>
            <br>
            <table width="95%">
                <tr>
                    <td>
                        <b><span style="font-size: 12px;">
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label></span></b></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span style="font-size: 12px;">Approximate Time:<asp:Label ID="lblTime" runat="server"
                            Text=""></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span style="font-size: 12px;"><b>Description</b></span></td>
                </tr>
                <tr>
                    <td>
                        <span style="font-size: 12px;">
                            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label></span></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span style="font-size: 12px;"><b>Meeting Point</b></span></td>
                </tr>
                <tr>
                    <td>
                        <span style="font-size: 12px;">
                            <asp:Label ID="lblMeetingPoint" runat="server" Text=""></asp:Label></span></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="height: 17px">
                        <span style="font-size: 12px;"><b>Conditions:</b></span></td>
                </tr>
                <tr>
                    <td>
                        <span style="font-size: 12px;">
                            <asp:Label ID="lblConditions" runat="server" Text=""></asp:Label></span></td>
                </tr>
            </table>
            <div id="divCancellation" visible="false" runat="server">
                <br>
                <table width="100%" cellspacing="0" cellpadding="0" align="center" border="0">
                    <tr>
                        <td width="100%" align="left">
                            <span style="font-size: 18px;">Transfer Cancellation</span></td>
                    </tr>
                </table>
                <asp:GridView ID="gvCancellation" runat="server" AutoGenerateColumns="False" Width="95%">
                    <Columns>
                        <asp:BoundField DataField="TimeString" HeaderText="TimeString" >
                            <HeaderStyle Width="80%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Policy" HeaderText="Policy" />
                    </Columns>
                </asp:GridView>
                <br>
            </div>
            <div id="divAmendment" visible="false" runat="server">
                <br>
                <table width="100%" cellspacing="0" cellpadding="0" align="center" border="0">
                    <tr>
                        <td width="100%" align="left">
                            <span style="font-size: 18px;">Transfer Amendment</span></td>
                    </tr>
                </table>
                <br>
                <asp:GridView ID="gvAmendment" runat="server" AutoGenerateColumns="False" Width="95%">
                    <Columns>
                        <asp:BoundField DataField="TimeString" HeaderText="TimeString" >
                            <HeaderStyle Width="80%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Policy" HeaderText="Policy" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
