<%@ Page Language="C#" AutoEventWireup="true" Codebehind="GttGlobalSkipIndex.aspx.cs"
    Inherits="Terms.Web.B2B_SUB.GttGlobalSkipIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
		BODY { FONT-SIZE: 11px; FONT-FAMILY: Verdana }
		.tr_bg { BACKGROUND: #fff }
		.input_size { FONT-SIZE: 11px }
		</style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Welcome to Majestic Vacations/GTT Online Hotel, Tour, and Travel Insurance B2B Booking
            System. Please review your e-mail and phone number and make CORRECTION if needed.</p>
        <p>
            If you have regiestered in Majestic-vacations.com/b2b previously, pls use the SAME
            E-MAIL ADDRESS.</p>
        <table border="0" cellpadding="1" cellspacing="3" style="font-size: 11px; background: #ccc">
            <tr class="tr_bg">
                <td style="width: 95px">
                    Name</td>
                <td>
                    <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label><asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    E-mail
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input_size"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    Phone</td>
                <td>
                    <asp:TextBox ID="txtPhoneDay" runat="server" CssClass="input_size"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    Company Name</td>
                <td>
                    <asp:TextBox ID="txtCompanyname" runat="server" CssClass="input_size"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    Account Code</td>
                <td>
                    <asp:Label ID="lblAccountCode" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    Branch</td>
                <td>
                    <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <!--add zyl 2009-9-14-->
            <tr class="tr_bg">
                <td style="width: 95px">
                    ARC Number</td>
                <td>
                    <asp:Label ID="lblARCNumber" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    Address</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="input_size"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    City</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="input_size"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    State</td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" CssClass="input_size"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    ZipCode</td>
                <td>
                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="input_size"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    Country</td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server" CssClass="input_size"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr_bg">
                <td style="width: 95px">
                    Fax</td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server" CssClass="input_size"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr_bg">
                <td visible="false" runat="server" style="width: 95px" colspan="2">
                    <asp:Label ID="lblUserId" runat="server" Text="Label"></asp:Label><asp:Label ID="lblRool" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_bg">
                <td colspan="2" align="center">
                    <asp:Button ID="btnCreate" runat="server" Text="Login" OnClick="btnCreate_Click"
                        CssClass="input_size" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblErrorMeassage" runat="server" Text="" ForeColor="red"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
