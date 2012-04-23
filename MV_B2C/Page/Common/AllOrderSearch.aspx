<%@ Page Language="C#" AutoEventWireup="true" Inherits="AllOrderSearch" Codebehind="AllOrderSearch.aspx.cs" %>

<%@ Register Src="~/UserControls/MemberLeftMenu.ascx" TagName="MemberLeftMenu" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <uc1:Header ID="Header1" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="45" align="left" valign="bottom" class="D_title">
                        &nbsp;&nbsp;Membership: My Orders</td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="920" align="center" border="0">
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>

                    <td>
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tr>
                                            <td width="80%" align="left" valign="top">
                                                <table cellspacing="1" cellpadding="3" width="100%" border="0" class="T_table">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="50%">
                                                                        <span class="head01">Search Orders</span></td>
                                                                    <td width="50%" align="right">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                                        <img src="../../images/index/dot01.gif"></td>
                                                                </tr>
                                                            </table>
                                                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                <tr>
                                                                    <td width="15%">
                                                                        Departure Date:
                                                                    </td>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td width="10%">
                                                                                    from
                                                                                </td>
                                                                                <td style="width: 15%">
                                                                                    <TermsCalender:TermsCalendar ID="txtFromDate" runat="server" />
                                                                                </td>
                                                                                <td width="10%" align="center">
                                                                                    to
                                                                                </td>
                                                                                <td width="15%">
                                                                                    <TermsCalender:TermsCalendar ID="txtToDate" runat="server" />
                                                                                </td>
                                                                                <td width="50%">
                                                                                
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 47px">
                                                                        Booking Date:</td>
                                                                    <td style="height: 47px">
                                                                         <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td width="10%">
                                                                                    from
                                                                                </td>
                                                                                <td width="15%">
                                                                                    <TermsCalender:TermsCalendar ID="txtFromBookingDate" runat="server" />
                                                                                </td>
                                                                                <td width="10%"  align="center">
                                                                                    to
                                                                                </td>
                                                                                <td width="15%">
                                                                                    <TermsCalender:TermsCalendar ID="txtToBookingDate" runat="server" />
                                                                                </td>
                                                                                <td  width="50%">
                                                                                
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Contact Person's Name:</td>
                                                                    <td>
                                                                        <uc3:MustInputTextBox ID="txtContactName" runat="server" IsValidEmpty="true" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Passenger's Name:</td>
                                                                    <td>
                                                                        <uc3:MustInputTextBox ID="txtPassengersName" runat="server" IsValidEmpty="true" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Case Number:</td>
                                                                    <td>
                                                                        <uc3:MustInputTextBox ID="txtCaseNumber" runat="server" IsValidEmpty="true" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="search_btn" OnClick="btnSearch_Click" /></td>
                                                                </tr>
                                                            </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                            <td align="right" style="height: 15px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <span class="head01">Order List </span>
                                            </td>
                                            <td width="50%" align="right">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                <img src="../../images/index/dot01.gif" /></td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="T_order"
                                        Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
                                        <HeaderStyle CssClass="R_order" />
                                        <RowStyle CssClass="R_order01" />
                                        <AlternatingRowStyle CssClass="R_order02" />
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="False" />
                                            <asp:BoundField HeaderText="Case Number" DataField="CaseNumber" />
                                            <asp:BoundField HeaderText="Dep. Date" DataField="BeginDate" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:BoundField HeaderText="Record Locator" DataField="RcordLocator" />
                                            <asp:BoundField HeaderText="Booking Time" DataField="BookingDate" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:BoundField HeaderText="Adult" DataField="AdultNumber" />
                                            <asp:BoundField HeaderText="Child" DataField="ChildNumber" />
                                            <asp:BoundField DataField="CFM" HeaderText="Hotel CFM#" Visible="True" />
                                            <asp:BoundField HeaderText="OP Status" DataField="OPStatus" />
                                            <asp:BoundField HeaderText="Payment Status" DataField="PayStatus" />
                                            <asp:CommandField SelectText="Cancel" ShowSelectButton="True" HeaderText="Cancel" />
                                        </Columns>
                                    </asp:GridView>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="T_order">
                                        <tr class="R_order01">
                                            <td align="center" style="height: 30px">
                                                <asp:Label ID="lblPageNumber" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    </tr> </table> </td>
                </tr>
            </table>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
