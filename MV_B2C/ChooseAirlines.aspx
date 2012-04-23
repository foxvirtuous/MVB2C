<%@ Page Language="C#" AutoEventWireup="true" Inherits="ChooseAirlines" Codebehind="ChooseAirlines.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    
    <script language="javascript" type="text/javascript">
        function IntxtAirline(code)
        {
            if(window.opener != null)
            {
                var txtAirline = window.opener.document.getElementById('SearchEngineA1_txtAirline');
        		
    		    if(txtAirline != null)
    		    {
                    if (Trim(txtAirline.value).length - Trim(txtAirline.value.replace(/(,)/g, "")).length < 4)
                    {
                        if (Trim(txtAirline.value) != "")
                        {
                            if (txtAirline.value.indexOf(code) < 0)
                            {
                                txtAirline.value = txtAirline.value + "," + code;
                            }
                        }
                        else
                        {
                            txtAirline.value = code;
                        }
                    }
                }
            }
            
            window.opener = null;
			window.close();
        }
        
        function LTrim(str)
        {
            var i;
            for(i=0;i<str.length;i++)
            {
                if(str.charAt(i)!=" "&&str.charAt(i)!=" ")
                    break;
            }
            str=str.substring(i,str.length);
            return str;
        }
        
        function RTrim(str)
        {
            var i;
            for(i=str.length-1;i>=0;i--)
            {
                if(str.charAt(i)!=" "&&str.charAt(i)!=" ")
                    break;
            }
            str=str.substring(0,i+1);
            return str;
        }
        
        function Trim(str)
        {
            return LTrim(RTrim(str));
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="MainScriptManager" runat="server" ScriptMode="release" LoadScriptsBeforeUI="false" />
        <div style="font-size:11px;">
            <span style="font-weight:bold;">Airlines:</span>
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%">
                <asp:BulletedList ID="BulletedList1" runat="server" DisplayMode="HyperLink">
                </asp:BulletedList>
                <ajaxToolkit:PagingBulletedListExtender ID="PagingBulletedListExtender1" runat="server"
                    BehaviorID="PagingBulletedListBehavior1" TargetControlID="BulletedList1" ClientSort="true"
                    IndexSize="1" Separator=" - " SelectIndexCssClass="selectIndex" UnselectIndexCssClass="unselectIndex" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
