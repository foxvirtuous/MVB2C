<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuccessSubIncentiveTourForm.aspx.cs" Inherits="SuccessSubIncentiveTourForm" validateRequest="false" %>

<%@ Register Src="../../UserControls/SendEmailSubIncentiveTourControl.ascx" TagName="SendEmailSubIncentiveTourControl"
    TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
        <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare,
        Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/Style_intour.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
 var isShow = false;
  function GetFormContent()
    {
		if(document.getElementById("flagSearch") != null)
		    document.getElementById("flagSearch").value = document.getElementById("MAIL_BODY").innerHTML;
	}
				
	function OnSearch()
	{
		GetFormContent();
		document.getElementById("IsFinised").value ="yes";
	    document.getElementById("form1").submit();
	}
    </script>

    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Header ID="Header1" runat="server" />
        <input id="IsFinised" type="hidden" name="IsFinised" runat="server" />
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="920">
                    <img src="/images/v2/intour_01.jpg"><img src="/images/v2/intour_02.jpg"><img src="/images/v2/intour_03.jpg"><img
                        src="/images/v2/intour_04.jpg"></td>
            </tr>
        </table>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>                
                <td width="920" align="left" valign="top">
                    <div>
                        <table width="577" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="3">
                                    <img src="/images/v2/intour_06.gif" border="0" /></td>
                            </tr>
                            <tr>
                                <td width="15" background="/images/v2/intour_08.gif">
                                    <img src="/images/v2/intour_08.gif" border="0" /></td>
                                <td width="547" height="600" align="center" valign="top">
                                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="tour">
                                        <tr>
                                            <td height="40" align="center">
                                                <span class="head05">
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <font color="#000000">Thank you for choosing Majestic Vacations!</font></span><br />
                                                Our sales representative will contact in 2 business days.<asp:Button ID="Button1"
                                                    runat="server" Text="Button" Visible=false OnClick="Button1_Click" Width="0px" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="15" background="/images/v2/intour_10.gif">
                                    <img src="/images/v2/intour_10.gif" border="0" /></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="/images/v2/intour_16.gif" border="0" /></td>
                            </tr>
                            <tr>
                                <td height="20" colspan="3">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td width="14" align="right" valign="top">
                    <img src="/images/v2/intour_07.gif" border="0" /></td>
            </tr>
        </table>
        <div id="MAIL_BODY" style="display:none">
            <uc3:SendEmailSubIncentiveTourControl id="SendEmailSubIncentiveTourControl1" runat="server">
            </uc3:SendEmailSubIncentiveTourControl>
        </div>
        <asp:HiddenField ID="flagSearch" Value="" runat="server" />
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
