<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="GenericErrorPage" Codebehind="GenericErrorPage.aspx.cs" %>

<%@ Register Src="../UserControls/Footer.ascx" TagName="Footer001" TagPrefix="uc7" %>
<%@ Register Src="../UserControls/Header.ascx" TagName="Header001" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc3:Header001 ID="Header001_1" runat="server"></uc3:Header001>
        <div align="center" style="padding:100px 0 100px 0">
            <asp:ImageButton ID="btnServerIsBusy" runat="server" ImageUrl="~/images/server-busy-pic.gif"
                PostBackUrl="~/Index.aspx" />
        </div>
        <uc7:Footer001 ID="Footer001_1" runat="server" />
    </form>
</body>
</html>
