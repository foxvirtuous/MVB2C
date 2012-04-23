<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="CurrentItineraryControl" Codebehind="CurrentItineraryControl.ascx.cs" %>
<%@ Import Namespace="TERMS.Common" %>
<div class="P_table">
    <!--new -->
    <table width="735" border="0" cellpadding="0" cellspacing="1" class="T_step02">
        <tr class="R_step02">
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr align="left">
                                                <td height="25" valign="top" class="D_stepr" width="75%">
                                                    <asp:Label ID="Label1" runat="server" meta:resourcekey="lblReview">Review Current Itinerary</asp:Label></td>
                                                <td align="right" width="8%">
                                                    <a href="javascript:doPrint();" id="printLink" runat="server" visible="false"><asp:Label ID="Label6" runat="server" meta:resourcekey="lblPrint">Print</asp:Label></a></td>
                                                <td  align="right" style="height: 48px">
                                                    <table border="0" cellspacing="0" cellpadding="0">
                                                        <tr valign="bottom">
                                                            <td>
                                                                <asp:HyperLink ID="hlItinerary" runat="server" ImageUrl="~/images/v2/it_cn.gif"></asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                        <tr class="R_stepw">
                                                            <td>
                                                                <!-- part one begin-->
                                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr valign="top">
                                                                        <td width="80%">
                                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                                                                                <tr align="left" valign="top">
                                                                                    <td width="35%" height="20">
                                                                                        <strong><asp:Label ID="Label2" runat="server" meta:resourcekey="lblTourName">Tour Name</asp:Label> :</strong></td>
                                                                                    <td>
                                                                                        <strong><font class="t10">
                                                                                            <asp:Label ID="lbl_TourName" runat="server">
                                                                                            </asp:Label></font></strong></td>
                                                                                </tr>
                                                                                <%-- <tr align="left" valign="top">
                                                                                    <td width="88" height="20">
                                                                                        <strong>Date :</strong></td>
                                                                                    <td width="244"><asp:Label ID="lbl_DeptDate" runat="server"></asp:Label>
                                                                                       </td>
                                                                                </tr>--%>
                                                                                <tr align="left" valign="top">
                                                                                    <td width="35%" height="20">
                                                                                        <strong><strong><asp:Label ID="Label3" runat="server" meta:resourcekey="lblTourCode">Tour Code</asp:Label> :</strong></td>
                                                                                    <td width="244">
                                                                                        <asp:Label ID="lbl_TourCode" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr align="left" valign="top" id="trDeptPlace" runat="server">
                                                                                    <td height="20">
                                                                                        <strong><asp:Label ID="Label4" runat="server" meta:resourcekey="lblDeparturePlace">Departure Place</asp:Label> :</strong></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lbl_DeptCity" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr align="left" valign="top">
                                                                                    <td height="20">
                                                                                        <strong><asp:Label ID="Label5" runat="server" meta:resourcekey="lblDuration">Duration</asp:Label> :</strong></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lbl_travelDate" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr align="left" valign="top">
                                                                                    <td height="20">
                                                                                        <strong><asp:Label ID="Label9" runat="server" meta:resourcekey="lblProductLink">Product Link</asp:Label> :</strong></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lbl_Link" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td bgcolor="#CCCCCC" width="1">
                                                                        </td>
                                                                        <td width="20%">
                                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                                                                                <tr align="right" valign="top">
                                                                                    <td colspan="2">
                                                                                        <font class="t11"><asp:Label ID="Label7" runat="server" meta:resourcekey="lblFrom">From</asp:Label> $<asp:Label ID="lbl_Price" runat="server">000.00</asp:Label>&nbsp;<asp:Label ID="Label8" runat="server" meta:resourcekey="lblFromCN"></asp:Label> <%--(Departure from&nbsp;<asp:Label ID="lbl_DeptFrom" runat="server"></asp:Label>)--%></font></td>
                                                                                </tr>
                                                                                <tr align="right" valign="top">
                                                                                    <td colspan="2">Lowest Price
                                                                                    </td>
                                                                                </tr>
                                                                                <tr align="left" valign="top">
                                                                                    <td height="20">
                                                                                    </td>
                                                                                    <td>
                                                                                        <%--<asp:Label ID="lbl_FromCountry" runat="server"></asp:Label>--%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr align="left" valign="top">
                                                                                    <td height="20">
                                                                                    </td>
                                                                                    <td>
                                                                                        <%--<asp:Label ID="lbl_FromCity" runat="server"></asp:Label>&nbsp;--%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <!-- part one end-->
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="R_step04">
                        <td height="20">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!-- new -->
</div>
