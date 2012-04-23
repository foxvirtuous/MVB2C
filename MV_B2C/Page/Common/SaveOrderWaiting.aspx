<%@ Page Language="C#" AutoEventWireup="true" Inherits="SaveOrderWaiting" Codebehind="SaveOrderWaiting.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare,
        Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>

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
		var obj = setTimeout("OnSearch('s')",1000);
    </script>

    <script language="JavaScript"> 
//禁止刷新，回退 
function onKeyDown() 
{ 
if ( (event.altKey) || ((event.keyCode == 8) && 
(event.srcElement.type != "text" && 
event.srcElement.type != "textarea" && 
event.srcElement.type != "password")) || 
((event.ctrlKey) && ((event.keyCode == 78) || (event.keyCode == 82)) ) || 
(event.keyCode == 116) ) { 
  event.keyCode = 0; 
  event.returnValue = false; 
  } 
 } 
 document.onkeydown = onKeyDown; 
 function stop(){   //这个是禁用鼠标右键 
return false; 
} 
document.oncontextmenu=stop; 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="IsOnSearch" type="hidden" name="OnSearch" runat="server" />
            <input id="FlashName" type="hidden" name="FlashName" runat="server" />
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
                        <embed src="<%=SecureUrlSuffix + ImagesPath + "Search_info.swf"%>" width="413" height="331"
                            type="application/x-shockwave-flash"></embed></object></div>
                <div align="center">
                    <strong>
                        <asp:Label ID="lalbel" runat="server" meta:resourcekey="lblDisplay">Please do not click the Back button on the browser.</asp:Label>
                    </strong>
                </div>
            </asp:Panel>
        </div>

        <script language="javascript" type="text/javascript">
        history.go(1);
        </script>

    </form>
</body>
</html>
