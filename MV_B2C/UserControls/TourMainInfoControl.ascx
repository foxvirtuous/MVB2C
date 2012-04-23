<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="TourMainInfoControl" Codebehind="TourMainInfoControl.ascx.cs" %>
    <%@ Import Namespace="TERMS.Common" %>
<table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr valign="top">
        <td>
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr align="left" valign="top">
                    <td width="15%" height="20">
                        <strong><asp:Label ID="Label1" runat="server" meta:resourcekey="lblTourName">Tour Name</asp:Label> :</strong></td>
                    <td>
                        <font class="t10"><asp:Label ID="lbl_TourName" runat="server"></asp:Label></font></td>
                </tr>
                <tr align="left" valign="top">
                    <td class="t06" colspan="2">
                        <asp:Label ID="lbl_FromTo" runat="server"></asp:Label></td>
                </tr>
            </table>
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr align="left" valign="top">
                    <td width="15%" height="20">
                        <strong><asp:Label ID="Label2" runat="server" meta:resourcekey="lblTourCode">Tour Code</asp:Label> :</strong></td>
                    <td width="591">
                         <asp:Label ID="lbl_TourCode" runat="server"></asp:Label></td>
                </tr>
               <%-- <tr align="left" valign="top">
                    <td height="20">
                        <strong>Airelines :</strong></td>
                    <td>
                        <img src="../../images/tkt/AA.gif" hspace="3" vspace="2" border="0" align="absmiddle" />American
                        Airline</td>
                </tr>--%>
               <%-- <tr align="left" valign="top" id="tr_Features" runat="server">
                    <td height="20">
                        <strong>Features :</strong>
                    </td>
                    <td>
                         <asp:DataList ID="dlFeatures" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <ItemTemplate>
                                                                                                        <tr>
                                                                                                            <td width="1%" valign="top">
                                                                                                                &#65294;</td>
                                                                                                            <td width="99%">
                                                                                                                <asp:Label ID="Label1" runat="server" Text='<%# ((Feature)DataBinder.Eval(Container,"DataItem")).Text.ToString() %>'>
                                                                                                                </asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </ItemTemplate>
                                                                                                </asp:DataList>
                    </td>
                </tr>--%>
                <tr align="left" valign="top">
                    <td height="20">
                        <strong><asp:Label ID="Label3" runat="server" meta:resourcekey="lblDepartureDate">Dept Date</asp:Label> : </strong>
                    </td>
                    <td>
                        <asp:Label ID="lbl_DeptDate" runat="server"></asp:Label>
                        &nbsp; &nbsp;
                        <asp:Label ID="lblDisPlay" runat="server" ForeColor="Black" Text="(Land tour begin on "
                            Visible="False"></asp:Label></td>
                </tr>
                <tr align="left" valign="top">
                    <td height="20">
                        <strong><asp:Label ID="Label4" runat="server" meta:resourcekey="lblReturnDate">Return Date</asp:Label> : </strong>
                    </td>
                    <td>
                        <asp:Label ID="lbl_RtnDate" runat="server"></asp:Label></td>
                </tr>
                <tr align="left" valign="top">
                    <td height="20">
                        <strong><asp:Label ID="Label5" runat="server" meta:resourcekey="lblRoomType">Room type</asp:Label> : </strong>
                    </td>
                    <td>
                       <asp:Label ID="lbl_RoomType" runat="server"></asp:Label></td>
                </tr>
                <tr align="left" valign="top" runat="server" id="trPassengers">
                    <td height="20">
                        <strong><asp:Label ID="Label6" runat="server" meta:resourcekey="lblNoOfPassgers">No. of Passenger</asp:Label> : </strong>
                    </td>
                    <td>
                        <asp:Label ID="lbl_AdultNumber" runat="server" Text="Adult(s)"  meta:resourcekey="lblAdult"></asp:Label> <asp:Label ID="lbl_ChildNumber" runat="server" Text="Child(ren)" meta:resourcekey="lblChild"></asp:Label> <asp:Label ID="lbl_ChildWithOutNumber" runat="server" Text="Child(Without bed)" meta:resourcekey="lblChildWithOut"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
