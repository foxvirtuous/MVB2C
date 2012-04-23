<%@ Page Language="C#" AutoEventWireup="true" Inherits="Page_Common_HeaderPage" Codebehind="HeaderPage.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="~/css/style_index.css" rel="stylesheet" type="text/css" />
    
    <link href="" rel="stylesheet" type="text/css" />
</head>
<script>  

var FFextraHeight = 0;
 if(window.navigator.userAgent.indexOf("Firefox")>=1)
 {
  FFextraHeight = 16;
  }
 function ReSizeiFrame(iframe)
 {
   if(iframe && !window.opera)
   {
     iframe.style.display = "block";
      if(iframe.contentDocument && iframe.contentDocument.body.offsetHeight)
      {
        iframe.height = iframe.contentDocument.body.offsetHeight + FFextraHeight;
      }
      else if (iframe.Document && iframe.Document.body.scrollHeight)
      {
        iframe.height = iframe.Document.body.scrollHeight;
        //alert(iframe.Document.body.scrollHeight);
      }
   }
 }

</script>

<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Header ID="Header1" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <div runat="server" id="div7" style="width:920px;text-align:center;margin-left:auto;margin-right:auto;" visible="true">
            <iframe src='<%=PageName %>' id='footerpage' name='footerpage' width='920' onload="ReSizeiFrame(this)"  scrolling='no' frameborder='0' ></iframe>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </div>
    </form>
</body>
</html>

