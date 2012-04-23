<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GTAEssentialInformation.aspx.cs" Inherits="GTAEssentialInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Essential Information</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellSpacing="0" cellPadding="0" width="500" align="left" border="0">
				<tr>
					<td width="100%"><font size="5">Essential Information</font></td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
				<tr>
					<td><asp:Label ID="lbInformation" Runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<tr><td>
                    <asp:Label ID="lbDATE" runat="server" Text="Label"></asp:Label></td></tr>
			</table>
    </div>
    </form>
</body>
</html>
