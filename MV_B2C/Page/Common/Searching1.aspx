<%@ Page Language="C#" AutoEventWireup="true" Inherits="Searching1" Codebehind="Searching1.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>

    <script language="javascript" type="text/javascript">
	
		/// <summary>
		/// On Search Fare
		/// </summary>
		var temp = 1;
		function OnSearch(objs)
		{
    		var count;
			count = temp;
			temp -= 1;
			if(count == 0 )
			{
				document.getElementById("IsOnSearch").value ="searching";
			    document.getElementById("form1").submit();
			}
		}

		// set the 10S, then do this function, It is for Firfox
		var obj = setTimeout("OnSearch('s')",50);
    </script>
<meta http-equiv="cache-control" content="no-cache"/>
</head>
<body>
    <form id="form1" runat="server">
        <input id="IsOnSearch" type="hidden" name="OnSearch" runat="server" />
        <input id="FlashName"  type="hidden" name="FlashName" runat="server" />
        <asp:Panel ID="pnFlash" runat="server">
            <div>
                <table>
                    <tr>
                        <td height="60">
                        </td>
                    </tr>
                </table>
            </div>
            <div id="loadHotel" align="center" runat="server">
                <object>
                    <embed src="<%=SaleWebSuffix + ImagesPath + "Searching.swf"%>" width="413" height="331" type="application/x-shockwave-flash"></embed></object></div>
            <div id="loadPackage" align="center" runat="server">
                <object>
                    <embed src="<%=SaleWebSuffix + ImagesPath + "Searching.swf"%>" width="413" height="331" type="application/x-shockwave-flash"></embed></object></div>
            <div id="loadTour" align="center" runat="server">
                <object>
                    <embed src="<%=SaleWebSuffix + ImagesPath + "Searching.swf"%>" width="413" height="331" type="application/x-shockwave-flash"></embed></object></div>
        </asp:Panel>
    </form>
</body>
</html>
