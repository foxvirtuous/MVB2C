<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="TourBookingPage.Master"
    EnableEventValidation="false" Inherits="TourMoreSearchResultForm" Codebehind="TourMoreSearchResultForm.aspx.cs" %>

<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ MasterType VirtualPath="TourBookingPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ItineraryInfo -->

    <script language="javascript" type="text/javascript">
        function DoSelect(obj){
            
            if(document.getElementById("ctl00_MainContent_runFlag").value == "1"){
                return false;
            }    
            obj.style.visibility="hidden";           
            obj.parentElement.className="loading";
            document.getElementById("ctl00_MainContent_runFlag").value = "1";
            
        }
    </script>

    <br />
    <div id="divECBuy2Get1Free" runat="server" visible="false">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <img src="/images/banner_090123.jpg"></td>
            </tr>
        </table>
    </div>
    <div id="divWCBuy2Get1Free" runat="server" visible="false">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <img src="/images/banner_090402.jpg"></td>
            </tr>
        </table>
    </div>
    <div id="divHCBuy2Get1Free" runat="server" visible="false">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <img src="/images/banner_090617.jpg"></td>
            </tr>
        </table>
    </div>

    <div id="Div1">
        <!-- new -->
        <table width="735" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="15">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="20">
                                <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                    <tr>
                                        <td align="center">
                                            ></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="5">
                            </td>
                            <td align="left">
                                <span class="head06"><asp:Label ID="Label1" runat="server" meta:resourcekey="lblSelect">Select a Tour in</asp:Label>
                                    <asp:Label ID="lblArea" runat="server"></asp:Label></span></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="735" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                        <tr class="R_stepo">
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="T_step0l" cellspacing="1" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="1" cellpadding="0">
                                                                <tr class="R_step03" align="center">
                                                                    <td width="52%" height="40">
                                                                        <asp:Label ID="Label2" runat="server" meta:resourcekey="lblTourName">Tour Name</asp:Label></td>
                                                                    <td width="12%">
                                                                        <asp:Label ID="Label3" runat="server" meta:resourcekey="lblTourCode">Tour Code</asp:Label></td>
                                                                    <td width="12%">
                                                                        <asp:Label ID="Label4" runat="server" meta:resourcekey="lblDuration">Duration</asp:Label></td>
                                                                    <td width="12%">
                                                                        <asp:Label ID="Label5" runat="server" meta:resourcekey="lblLandPrice">Land Price<br>
                                                                        From</asp:Label></td>
                                                                    <td width="12%">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                            </table>
                                            <asp:DataList ID="dlTourList" runat="server" Width="100%" HorizontalAlign="Center"
                                                OnItemCommand="dlTourList_ItemCommand" OnItemDataBound="dlTourList_ItemDataBound">
                                                <ItemTemplate>
                                                    <%--<table class="T_step0l" cellspacing="1" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr class="R_stepw">
                                                                <td>
                                                                    <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">--%>
                                                    <tr class="R_stepw" align="center">
                                                        <td width="52%" align="left">
                                                            <asp:LinkButton ID="hlTourName" runat="server" CssClass="d06" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Name.ToString() %>'
                                                                CommandName="SelectName"></asp:LinkButton>
                                                        </td>
                                                        <td width="12%" align="left">
                                                            <asp:Label ID="lblTourCode" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Code.ToString() %>'></asp:Label>
                                                        </td>
                                                        <td width="12%">
                                                            <asp:Label ID="lblDays" runat="server" Text='<%# ((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Days.ToString() %>'>
                                                            </asp:Label>&nbsp;<asp:Label ID="Label5" runat="server" meta:resourcekey="lblDays">days</asp:Label></td>
                                                        <td width="12%">
                                                            <font class="t07">$<asp:Label ID="lbl_PriceValue" runat="server" Text='000.00' /></font></td>
                                                        <td width="12%">
                                                            <asp:ImageButton ID="ImageButton1" ImageUrl="../../images/v2/btn_01.gif" runat="server"
                                                                CommandName="Select" /></td>
                                                    </tr>
                                                    <%--    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>--%>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <tr class="R_stepg" align="center">
                                                        <td width="52%" align="left">
                                                            <asp:LinkButton ID="hlTourName" runat="server" CssClass="d06" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Name.ToString() %>'
                                                                CommandName="SelectName"></asp:LinkButton>
                                                        </td>
                                                        <td width="12%" align="left">
                                                            <asp:Label ID="lblTourCode" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Code.ToString() %>'></asp:Label>
                                                        </td>
                                                        <td width="12%">
                                                            <asp:Label ID="lblDays" runat="server" Text='<%# ((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Days.ToString() %>'>
                                                            </asp:Label>&nbsp;<asp:Label ID="Label5" runat="server" meta:resourcekey="lblDays">days</asp:Label></td>
                                                        <td width="12%">
                                                            <font class="t07">$<asp:Label ID="lbl_PriceValue" runat="server" Text='000.00' /></font></td>
                                                        <td width="12%">
                                                            <asp:ImageButton ID="ImageButton1" ImageUrl="../../images/v2/btn_01.gif" runat="server"
                                                                CommandName="Select" /></td>
                                                    </tr>
                                                </AlternatingItemTemplate>
                                                <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                    Font-Strikeout="False" Font-Underline="False" />
                                            </asp:DataList></td>
                                    </tr>
                                    <tr>
                                        <td height="7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <uc4:PageNumber ID="PageNumber1" runat="server"></uc4:PageNumber>
                                    </tr>
                                    <tr>
                                        <td height="3">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button ID="btn_back" runat="server" Text="Back" CssClass="search_btn03" Style="cursor: hand"
            OnClick="btn_back_Click" meta:resourcekey="btnBack" />
    </div>
</asp:Content>
