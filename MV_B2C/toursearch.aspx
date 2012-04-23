<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Inherits="TourSearch" Codebehind="toursearch.aspx.cs" %>

<%@ Register Src="UserControls/SearchEngineT.ascx" TagName="SearchEngineT" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="MainScriptManager" runat="server" ScriptMode="release" LoadScriptsBeforeUI="false" />
        <div>
            <uc3:SearchEngineT ID="SearchEngineT1" runat="server" />
        </div>
    </form>
</body>
</html>
