<%@ Page Language="C#" AutoEventWireup="true" Codebehind="DetailForm.aspx.cs" Inherits="DetailForm" %>

<%@ Register Src="~/UserControls/HTLCommonInfoControl.ascx" TagName="HotelCommonInfoControl"
    TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/HTLInfoControl.ascx" TagName="HotelInfo" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/HotelOnlySearchControl.ascx" TagName="HotelOnlySearch"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/NavigationControl.ascx" TagName="Navigation" TagPrefix="uc8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
     <link href="<%=SaleWebSuffix + MainCssPath + "Hotel.css"%>" rel="stylesheet" type="text/css" />
     <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet" type="text/css" />
     <link href="<%=SaleWebSuffix + MainCssPath + "Global.css"%>" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        
        
        function ShowHideChangeDate()
        {
            if(document.getElementById("changeIO").style.display == "")
                document.getElementById("changeIO").style.display = "none";
            else
                document.getElementById("changeIO").style.display = "";
        }
        
        
    </script>

<script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
<script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

</head>
<body onload="SetRepeatHotel();"><input id="cityandairport" type="hidden" value="A" runat="server" />
<input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
        <form id="form1" runat="server">
       
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="hpContainer" class="TableWidth1" align="center">
            <%--<table cellpadding="0" cellspacing="0" id="Table1" class="TableWidth1">
                <col class="ColWidth1" />
                <col class="ColWidth2" />
                <col class="ColWidth1" />
                <tr>
                    <td id="containerLeft">
                    </td>
                    <td id="containerCenter" valign="top">--%>
                        <!-- localhead.jsp | begin -->
                        <!-- localhead.jsp | end -->
                        <div id="ualbody" style="float:left;">
                            <table border="0" cellpadding="0" cellspacing="0" id="ualbodyTable" class="TableWidth2">
                                <tr>
                                    <td colspan="3" align="right">
                                        <uc8:Navigation ID="Navigation1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td valign="top" width="20%">
                                        <!-- leftcol.jsp | begin -->
                                        <uc2:HotelOnlySearch ID="HotelOnlySearchControl1" runat="server" />
                                        <%--<uc5:PackageLeftSelect ID="PackageLeftSelect1" runat="server"></uc5:PackageLeftSelect>--%>
                                        <!-- leftcol.jsp | end -->
                                    </td>
                                    <td align="left" valign="top" id="bodyCol3">
                                        <!-- main begin-->
                                        <uc7:HotelInfo ID="HotelInfo1" runat="server" />
                                        <div id="hotel">
                                            <uc5:HotelCommonInfoControl ID="HotelCommonInfoControl1" runat="server" />
                                        </div>
                                        <!-- mian end-->
                                    </td>
                                    <td id="bodyCol4" class="bodyColSpace">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td height="1">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    <%--</td>
                    <td id="containerRight">
                    </td>
                </tr>
            </table>--%>
        </div>
        <!-- footer.jsp | begin -->
       
        <uc2:Footer ID="Footer1" runat="server" />
        <!-- footer.jsp | end -->

        <script language="javascript" type="text/javascript">
        history.go(1);
        </script>

    </form>
</body>
</html>
