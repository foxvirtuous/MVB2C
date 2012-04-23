<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="SearchEngineT" Codebehind="SearchEngineT.ascx.cs" %>
<%@ Register Src="LocationTextBoxControl.ascx" TagName="LocationTextBoxControl" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>
<link href="" rel="stylesheet" type="text/css" />
<!-- Tour Search Body Begin -->

<script type="text/javascript" language="javascript">
	             
//		            function ChangeTourType(type)
//		            {
//			            if( type == "LandOnly")
//			            {
//				            
//				            document.getElementsByTagName("*").div_DeptCity.style.display = "";
//				          
//			            }
//			            else if(type == "AirLand")
//			            {
//				           
//				            document.getElementsByTagName("*").div_DeptCity.style.display = "none";
//				           
//			            }
//		            }
//            		
		           
		            function UpperCase(obj)
		            {
			            obj.value = obj.value.toUpperCase();
		            }
</script>

<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr align="left">
        <td width="2%" height="25">
            <input id="rdbLandOnly" name="radiobutton" type="radio" value="1" checked runat="server" /></td>
        <td width="46%">
            <asp:Label ID="lblLand" runat="server" meta:resourcekey="lblLandOnly">Land Only</asp:Label></td>
        <td width="2%">
            <input id="rdbAirLand" name="radiobutton" type="radio" value="0"  runat="server"  visible="false"/></td>
        <td width="50%" visible="false">
            </td>
    </tr>
</table>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr align="left">
        <td colspan="2">
            <asp:Label ID="lblRegion" runat="server" meta:resourcekey="lblRegion">Region</asp:Label>:<br />
            <asp:DropDownList ID="ddlArea_T" runat="server" CssClass="search_sle" ValidationGroup="TourOnlySearch"
                Width="280px">
            </asp:DropDownList><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="ddlArea_T" Display="Dynamic"  meta:resourcekey="lblAreaMsg" ErrorMessage="Please select area."
                SetFocusOnError="True" ValidationGroup="TourOnlySearch"></asp:RequiredFieldValidator></td>
    </tr>
    <tr align="left">
        <td colspan="2">
            <asp:Label ID="lblCountry" runat="server" meta:resourcekey="lblCountry">Country or Area</asp:Label>:<br />
            <asp:DropDownList ID="ddlCountry_T" runat="server" CssClass="search_sle" ValidationGroup="TourOnlySearch"
                Width="280px">
            </asp:DropDownList><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="ddlCountry_T" Display="Dynamic"  meta:resourcekey="lblCountryMsg" ErrorMessage="Please select country or area."
                SetFocusOnError="True" ValidationGroup="TourOnlySearch"></asp:RequiredFieldValidator></td>
    </tr>
    <tr align="left">
        <td colspan="2">
            <asp:Label ID="lblCity" runat="server" meta:resourcekey="lblCity">City</asp:Label>:<br />
            <asp:DropDownList ID="ddlCity_T" runat="server" Width="280px" CssClass="search_sle"
                ValidationGroup="TourOnlySearch">
            </asp:DropDownList><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="ddlCity_T" Display="Dynamic" meta:resourcekey="lblCityMsg" ErrorMessage="Please select city."
                SetFocusOnError="True" ValidationGroup="TourOnlySearch"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td colspan="2" height="5px">
        </td>
    </tr>
    <tr align="left">
        <td>
            <asp:Label ID="lblDepartureDate" runat="server" meta:resourcekey="lblDepartureDate">Departure Date</asp:Label>:</td>
        <td>
            <uc1:Calendar ID="tourDeptCalendar" runat="server" />&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" meta:resourcekey="lblDataMsg" Text="Please enter date" Visible="False"></asp:Label></td>
    </tr>
    <tr align="left">
        <td>
            <asp:Label ID="lblDuration" runat="server" meta:resourcekey="lblDuration">Duration</asp:Label>:
        </td>
        <td>
            <asp:DropDownList ID="ddlTravelDate" runat="server" Width="90px" CssClass="search_sle"
                ValidationGroup="TourOnlySearch">
                <asp:ListItem Value="5" meta:resourcekey="lbl5to10">less than 10 days</asp:ListItem>
                <asp:ListItem Value="11" meta:resourcekey="lbl11to15">11 - 15 days</asp:ListItem>
                <asp:ListItem Value="15" meta:resourcekey="lbl15">over 15 days</asp:ListItem>
                <asp:ListItem Value="16" Selected="true" meta:resourcekey="lblAll">All</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Button ID="btnSearch_t" CssClass="search_btn" Text="Search" runat="server" OnClick="btn_Search_t_Click"
                Style="cursor: hand" meta:resourcekey="btn_SearchFare" /></td>
    </tr>
</table>
<!-- Tour Search Body End -->
<ajaxToolkit:CascadingDropDown ID="cddArea" runat="server" TargetControlID="ddlArea_T"
    Category="TourArea" PromptText="Please select a area" LoadingText="[Loading areas...]"
    ServiceMethod="GetDropDownContents" ParentControlID=""   meta:resourcekey="CddArea" />
<ajaxToolkit:CascadingDropDown ID="cddCountry" runat="server" TargetControlID="ddlCountry_T"
    Category="TourCountry" meta:resourcekey="CddCountry"  PromptText="Please select a country or area" LoadingText="[Loading countries...]"
    ServiceMethod="GetDropDownContents" ParentControlID="ddlArea_T" />
<ajaxToolkit:CascadingDropDown ID="cddCity" runat="server" TargetControlID="ddlCity_T"
    Category="TourCity" meta:resourcekey="CddCity"  PromptText="Please select a city" LoadingText="[Loading cities...]"
    ServiceMethod="GetDropDownContents" ParentControlID="ddlCountry_T" />
<!-- Tour Search Body End -->
