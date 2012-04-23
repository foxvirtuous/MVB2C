<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"
    Inherits="HotelDetailedInformationForm" Codebehind="HotelDetailedInformationForm.aspx.cs" %>

<%@ Register Src="~/UserControls/HotelCommonInfoControl.ascx" TagName="HotelCommonInfoControl"
    TagPrefix="uc6" %>

<%@ Register Src="~/UserControls/HotelInfoControl.ascx" TagName="HotelInfo" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/RemarkAndCall.ascx" TagName="RemarkAndCall" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/HotelOnlySearchControl.ascx" TagName="HotelOnlySearch" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/NavigationControl.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers" TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        
        
        function ShowHideChangeDate()
        {
            if(document.getElementById("changeIO").style.display == "")
                document.getElementById("changeIO").style.display = "none";
            else
                document.getElementById("changeIO").style.display = "";
        }
        
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <div id="content">
            <div id="subcontent_r">
                <uc2:HotelOnlySearch ID="HotelOnlySearch1" runat="server" />
                <uc5:ChangeTravelers ID="ChangeTravelers1" runat="server" />
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc3:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <h1>
                        <asp:Label ID="lblHotelName" runat="server" Text=""></asp:Label>
                    </h1>
                        Select your room type. 
                    <div>
                        <div class="base">
                            <div class="newprice">
                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                    <tr>
                                        <td colspan="2" align=center>
                                            <strong>Total: </strong><strong>$<asp:Label ID="lblLowestTotal" runat="server" Font-Bold="True"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Label ID="lblBreakfast" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </div>
                            <uc7:HotelInfo ID="HotelInfo1" runat="server" />
                            <br />
                        </div>
                    </div>
                    <div id="hotel">
                        <uc6:HotelCommonInfoControl id="HotelCommonInfoControl1" runat="server">
                        </uc6:HotelCommonInfoControl></div>
                </div>
                <div id="subcontent_l_r">
                    <uc1:RemarkAndCall ID="RemarkAndCall1" runat="server" />
                </div>
            </div>
            <p class="clear">
            </p>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>
</body>
</html>
