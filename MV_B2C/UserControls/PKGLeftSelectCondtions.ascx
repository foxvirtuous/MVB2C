<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGLeftSelectCondtions.ascx.cs"
    Inherits="PKGLeftSelectCondtions" %>
<%@ Register Src="PKGChangeTravelersControl.ascx" TagName="ChangeTravelersControl"
    TagPrefix="uc7" %>
<%@ Register Src="Calendar.ascx" TagName="Calendar" TagPrefix="uc6" %>
<%@ Register Src="MustInputTextBox.ascx" TagName="MustInputTextBox" TagPrefix="uc1" %>
<link href="" rel="stylesheet" type="text/css" />
<link href="" rel="stylesheet" type="text/css" />
<link href="" rel="stylesheet" type="text/css" />
<div class="IBE_package_reSearch">
    <div class="IBE_package_R_step01 IBE_package_reSearch_title">
        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblRefineSearch">Change Your Search</asp:Label></div>
    <div class="IBE_package_reSearch_main">
        <ul class="IBE_package_reSearch_main_step1">
            <li class="IBE_package_D_stepb">
                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblFrom">From (city or airport code)</asp:Label>:</li>
            <li style="margin-top: 4px;">
                <%--<uc3:LocationTextBoxControl ID="txtFrom" runat="server" />--%>
                <asp:TextBox ID="txtFrom" runat="server" autocomplete="off" Width="120"></asp:TextBox>
            </li>
            <li class="IBE_package_D_stepb" style="margin-top: 2px;">
                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblTo">To (city or airport code)</asp:Label>:</li>
            <li style="margin-top: 4px;">
                <%--<uc3:LocationTextBoxControl ID="txtTo" runat="server" />--%>
                <asp:TextBox ID="txtTo" runat="server" autocomplete="off" Width="120"></asp:TextBox>
            </li>
            <li class="IBE_package_D_stepb" style="margin-top: 6px;">
                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblDepartDate">Depart date</asp:Label>:</li>
            <li style="margin-top: 2px;">
                <uc6:Calendar ID="dateDeparture" runat="server" />
            </li>
            <li class="IBE_package_D_stepb">
                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblReturnDate">Return date</asp:Label>:</li>
            <li style="margin-top: 2px;">
                <uc6:Calendar ID="dateReturn" runat="server" LowerLimitID="dateDeparture" />
            </li>
            <li class="IBE_package_D_stepb">
                <asp:Label ID="Label7" runat="server" meta:resourcekey="lblCheckInDate">CheckIn date</asp:Label>:</li>
            <li style="margin-top: 2px;">
                <uc6:Calendar ID="dateCheckIn" runat="server" LowerLimitID="dateDeparture" UpperLimitID="dateReturn" />
            </li>
            <li class="IBE_package_D_stepb">
                <asp:Label ID="Label8" runat="server" meta:resourcekey="lblCheckOutDate">CheckOut date</asp:Label>:</li>
            <li style="margin-top: 2px;">
                <uc6:Calendar ID="dateCheckOut" runat="server" LowerLimitID="dateCheckIn" UpperLimitID="dateReturn" />
            </li>
            <li style="margin-top: 2px;">
                <asp:Label ID="lblError" runat="server" Text="" Visible=false ForeColor=red ></asp:Label>
            </li>        
        </ul>
        <div style="width:100%; float:left; text-align:center; margin:10px 0px;">
            <asp:Button ID="imgSearch"  Width="58" Text="Search" CssClass="IBE_search_btn02L"
                    Height="18" runat="server" OnClick="imgSearch_Click" />
        </div>
        <uc7:ChangeTravelersControl ID="ChangeTravelersControl1" runat="server" />
    </div>
</div>
