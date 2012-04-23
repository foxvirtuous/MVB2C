<%@ Page Language="C#" AutoEventWireup="true" Codebehind="EmailTourPDF.aspx.cs" Inherits="EmailTourPDF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Itinerary</title>
    <link href="../../../css/style_new1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="605" border="0" cellpadding="0" cellspacing="0" background="../../../images/tour_des_bg.gif">
                <tr>
                    <td width="605" height="28" align="left" background="../../../images/tour_des_bar.gif"
                        class="grp_title-w">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email Itinerary</td>
                </tr>
                <tr>
                    <td height="121" valign="top" style="border-right-style: solid; border-left-style: solid;
                        border-right-color: #FF4713; border-left-color: #FF4713; border-right-width: 2px;
                        border-left-width: 2px; padding: 10px 10px 10px 10px;">
                        <table cellspacing="0" cellpadding="5" width="580" align="center" border="0">
                            <tr>
                                <td width="15%" align="right">
                                    <asp:Label ID="Label1" runat="server" CssClass="head05" Text="To: "></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="280px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" CssClass="head05" Text="Subject: "></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" CssClass="t10" Text="Majestic Vacations China Tour"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" CssClass="head05" Text="Attachment: "></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Image ID="Image1" runat="server" CssClass="d13" ImageUrl="http://terms.majestic-vacations.com/images/attachment.jpg" /><asp:HyperLink
                                        ID="hlAttachment" runat="server" Target="_blank"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" CssClass="head05" Text="Message: "></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Width="90%" Style="width: 450px;"
                                        Rows="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnSendEmail" runat="server" CssClass="search_btn02" OnClick="btnSendEmail_Click"
                                        Text="Send" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="5">
                        <img src="../../../images/tour_des_down.gif" width="605" height="5" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
