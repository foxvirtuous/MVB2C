<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GTAStayOffer.aspx.cs" Inherits="GTAStayOffer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Stay Offer</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <table cellSpacing="3" cellPadding="0" width="500" align="left" border="0">
				<tr>
					<td width="100%" style=" background:#c4c4c4; padding:2px;"><b>
								<asp:Label id="lbhotelname" runat="server" style=" font-size:15px;"></asp:Label></b></td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
				
						<tr>
							<td style=" background:#eee;">
							
									<asp:Label ID="lbroomcode" Runat="server" style=" font-size:16px;"></asp:Label></td>
						</tr>
						<tr>
							<td>
									<asp:Label ID="lbremark" Runat="server" style=" font-size:16px; color:#00cc00; font-weight:bold;"></asp:Label></td>
						</tr>
						<tr>
						<td>
							<asp:Label ID="lbremark1" Runat="server" style="font-size:11px;"></asp:Label>
						</td>
						</tr>
						<tr>
						<td>
							<asp:Label ID="Label1" Runat="server" style=" font-size:16px; color:#00cc00; font-weight:bold;">Validity</asp:Label>
						</td>
						</tr>
						<tr>
						<td>
							<asp:Label ID="lbValidity" Runat="server" style="font-size:11px;"></asp:Label>
						</td>
						</tr>
						<tr><td height=15></td></tr>
					
			</table>
    </div>
    </form>
</body>
</html>
