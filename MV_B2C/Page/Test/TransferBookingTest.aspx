<%@ Page Language="C#" AutoEventWireup="true" Inherits="Page_Test_TransferBookingTest" Codebehind="TransferBookingTest.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Œﬁ±ÍÃ‚“≥</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div
            style="text-align: left">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <strong>Country or Area</strong></td>
                    <td><asp:DropDownList ID="dllCountry" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Select a City</strong></td>
                    <td >
                        <asp:DropDownList ID="dllCityCode" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><strong>Pick Up</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="dllPickType" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="dllAirLineCode" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><strong>Drop Off</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="dllDropCode" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><strong>Date</strong>
                    </td>
                    <td >
                        <TermsCalender:TermsCalendar ID="TermsCalendar1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><strong>Number of Passengers</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="dllPassengers" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><strong>Language</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="dllLanguage1" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td >
                    </td>
                    <td>
                        <asp:DropDownList ID="dllLanguage2" runat="server">
                        </asp:DropDownList>
                        <a href=TransferBookingTest.aspx target=_blank><img src="../../images/080327_hotel_01.jpg" /></a>
                        </td>
                </tr>
                <tr>
                    <td colspan="2" >
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" /></td>
                </tr>
            </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </div>
    </form>
</body>
</html>
