<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PromosSearching.aspx.cs"
    Inherits="PromosSearching" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cheap airfare, Cheap tickets, online ticket booking : Majestic Vacations </title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="keywords" content="明星假期旅遊網, 美國國內機票, 亞洲機票, 台灣,香港,北京,上海 特廉機票, 中國國內機票優惠, 最便宜酒店, 全球酒店線上訂購, 套裝行程,機票+酒店, 旅遊, 超值旅遊,台灣旅遊,中國旅遊,美國東岸,西岸,夏威夷,奧蘭多, 亞洲旅遊, 兩人成行, 郵輪旅遊, 皇家旅遊,公主郵輪, 旅遊同業中心, 機票代理中心" />
    <meta name="description" content="明星假期旅遊, 最豐富,最便宜, 最便宜機票, 美國到中國機票, 酒店, 兩人成行自由行, 旅遊, 郵輪假期" />

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
        <input id="ToSearch" type="hidden" runat="server" />
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
                    <embed src="<%=SaleWebSuffix + ImagesPath + "Searching.swf"%>" width="413" height="331"
                        type="application/x-shockwave-flash"></embed></object></div>
            <table width="100" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="15" align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <img src="images/ad_call_searching.jpg" /></td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
