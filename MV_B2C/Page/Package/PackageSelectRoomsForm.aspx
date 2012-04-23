<%@ Page Language="C#" AutoEventWireup="true" Inherits="PackageSelectRoomsForm" Codebehind="PackageSelectRoomsForm.aspx.cs" %>

<%@ Register Src="~/UserControls/HotelCommonInfoControl.ascx" TagName="HotelCommonInfoControl" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc7" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/PackageLeftSelect.ascx" TagName="PackageLeftSelect" TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/ShowPackageHotelDetails.ascx" TagName="ShowPackageHotelDetails" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/PackageFlightHeaderControl.ascx" TagName="PackageFlightHeaderControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/DefaultFlightDetails.ascx" TagName="DefaultFlightDetails" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/RemarkAndCall.ascx" TagName="RemarkAndCall" TagPrefix="uc8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel package,Cheap Tours,Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        function tabChange(tabName)
        {
            if(tabName == "Features")
            {
                 document.getElementById("HotelFeature").style.display = "";
                 document.getElementById("photo").style.display = "none";
                 document.getElementById("Location").style.display = "none";
                 document.getElementById("roomopt").style.display = "none";
                 
                 document.getElementById("liFeatures").className = "chosed";
                 document.getElementById("liLocation").className = "";
                 document.getElementById("liPhoto").className = "";
                 document.getElementById("liRoomTypes").className = "";
            }
            else if(tabName == "Location")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "none";
                 document.getElementById("Location").style.display = "";
                 document.getElementById("roomopt").style.display = "none";
                 
                 document.getElementById("liFeatures").className = "";
                 document.getElementById("liLocation").className = "chosed";
                 document.getElementById("liPhoto").className = "";
                 document.getElementById("liRoomTypes").className = "";
            }
            else if(tabName == "Photo")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "";
                 document.getElementById("Location").style.display = "none";
                 document.getElementById("roomopt").style.display = "none";
                 
                 document.getElementById("liFeatures").className = "";
                 document.getElementById("liLocation").className = "";
                 document.getElementById("liPhoto").className = "chosed";
                 document.getElementById("liRoomTypes").className = "";
            }
            else if(tabName == "Room Types")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "none";
                 document.getElementById("Location").style.display = "none";
                 document.getElementById("roomopt").style.display = "";
                 
                 document.getElementById("liFeatures").className = "";
                 document.getElementById("liLocation").className = "";
                 document.getElementById("liPhoto").className = "";
                 document.getElementById("liRoomTypes").className = "chosed";
            }
        }
        
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
<body><input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <input id="CurrentTab" type="hidden" value="Room Types" name="DefaultTab" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
    <uc1:Header ID="Header1" runat="server" />
        <div id="content">
            
            <div id="subcontent_r">
                <div class="refine">
                    <uc5:PackageLeftSelect ID="PackageLeftSelect1" runat="server"></uc5:PackageLeftSelect>
                    <uc6:ChangeTravelers ID="ChangeTravelers1" runat="server" />
                </div>
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                       <uc7:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <h1>
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblSelectRoomType">Select your room type</asp:Label></h1>
                    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblViewHotel">View the hotel options below. Use the Select button to make your choice.</asp:Label>
                    <div>
                        <div class="base">
                            <div>
                                <uc1:PackageFlightHeaderControl ID="FlightHeader1" runat="server" />
                                &nbsp;</div>
                        </div>
                        <uc2:DefaultFlightDetails ID="DefaultFlightDetails1" runat="server" />
                    </div>                
                                            
                    <div id="hotel">
                         <h3><asp:Label ID="lbHotelName" runat="server" ></asp:Label></h3> 
                        <uc3:HotelCommonInfoControl ID="HotelCommonInfoControl1" runat="server" />
                    </div>
                </div>
                <div id="subcontent_l_r">
                    <uc8:RemarkAndCall ID="RemarkAndCall1" runat="server" />
                </div>
            </div>
        </div>
        
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>
</body>
</html>
