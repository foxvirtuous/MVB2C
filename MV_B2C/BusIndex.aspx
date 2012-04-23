<%@ Page Language="C#" AutoEventWireup="true" Inherits="BusIndex" Codebehind="BusIndex.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations : We are the experts on traveling to ASIA : Bus</title>
    <link href="" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
    
    function ResetFrmHeight()
    {
        alert(document.body.clientHeight);
        var isIE = document.all?true:false;
        if(isIE){
          var Calendar = content;
        }else{
          var Calendar = document.getElementById('content');
        }
        alert(Calendar.document.body.clientHeight);

        document.getElementById('content').style.height = Calendar.document.body.clientHeight;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <table border="0" align="center" cellpadding="12" cellspacing="0">
            <tr>
                <td>
                    <iframe id="content" name="content" src="html/bus.html" width="900" height="700" scrolling="no" frameborder="0">
                    </iframe>
                    
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
