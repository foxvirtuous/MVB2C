<%@ Page Language="C#" AutoEventWireup="true" Inherits="Searching" Codebehind="Searching.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html  xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Searching</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
    <meta name="CODE_LANGUAGE" content="C#"/>
    <meta name="vs_defaultClientScript" content="JavaScript"/>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>

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
				document.getElementById("ToSearch").value ="searching";
			    document.getElementById("Form1").submit();
			}
		}
		// set the 10S, then do this function, It is for Firfox
		var obj = setTimeout("OnSearch('s')",500);
    </script>

</head>
<body id="BODY" runat="server">
    <form id="Form1" method="post" runat="server">
        &nbsp;
        <input id="ToSearch" type="hidden" name="ToSearch" runat="server" />
        <asp:Panel ID="pnFlash" runat="server">
            <div>
                <table>
                    <tr>
                        <td height="60">
                        </td>
                    </tr>
                </table>
            </div>
            <div id="load" align="center">
                <object>
                    <embed src="<%=SaleWebSuffix + ImagesPath + "Searching.swf"%>" width="413" height="331" type="application/x-shockwave-flash"></embed></object></div>
        </asp:Panel>
    </form>
</body>
</html>
