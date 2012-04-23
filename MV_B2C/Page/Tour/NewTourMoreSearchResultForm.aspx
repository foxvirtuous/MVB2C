<%@ Page Language="C#" MasterPageFile="TourBookingPage.master" AutoEventWireup="true"
    EnableEventValidation="false" Codebehind="NewTourMoreSearchResultForm.aspx.cs"
    Inherits="NewTourMoreSearchResultForm" %>

<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ MasterType VirtualPath="TourBookingPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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

    <div id="divECBuy2Get1Free" runat="server" visible="false">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <asp:Image ID="imgArea1" runat="server" onerror="this.src='http://www.majestic-vacations.com/images/default_pic_735x120.gif';" /></td>
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
    <table width="735" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="120">
                <asp:Image ID="imgArea" runat="server" onerror="this.src='http://www.majestic-vacations.com/images/default_pic_735x120.gif';"
                    Width="735" Height="120" />
            </td>
        </tr>
        <tr>
            <td height="10">
            </td>
        </tr>
    </table>
    <!--new -->
    <table width="735" border="0" cellpadding="8" cellspacing="1" bgcolor="#B3B3B3">
        <tr>
            <td height="238" align="left" valign="top" bgcolor="#F4F4F4" style="width: 734px">
                <div id="pagebar" style="border-bottom-style: solid; border-bottom-color: #B3B3B3;
                    border-bottom-width: 1px;">
                    <div id="pagetittle">
                        <asp:Label ID="lblArea" runat="server"></asp:Label></div>
                    <div id="page_sale">
                        <input type="hidden" value="1" id="hdPreference" runat="server" /><asp:ImageButton ID="ibtnPreference" runat="server" OnClick="lbtnPreference_Click" ImageUrl="http://www.majestic-vacations.com/images/Return-to-China-tours.gif" style="border-width:0px; margin-top:-9px;" />
                        <asp:LinkButton ID="lbtnPreference" runat="server" Visible="false" OnClick="lbtnPreference_Click">特惠中文团$49起</asp:LinkButton></div>
                </div>
                <asp:DataList ID="dlTourList" runat="server" OnItemCommand="dlTourList_ItemCommand"
                    OnItemDataBound="dlTourList_ItemDataBound">
                    <ItemTemplate>
                        <table width="715" border="0" cellspacing="0" cellpadding="8" style="border-bottom-style: solid;
                            border-bottom-color: #B3B3B3; border-bottom-width: 1px;">
                            <tr>
                                <td bgcolor="#FFFEE6">
                                    <table width="690" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="538" height="40" align="left">
                                                <asp:LinkButton ID="hlTourName" runat="server" CssClass="d13_tour-name" CommandName="Select">
                                                    <asp:Label ID="lblTourName" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Name.ToString() %>'></asp:Label></asp:LinkButton></td>
                                            <td width="162" align="right">
                                                <strong>
                                                    <asp:Label ID="keyTourCode" runat="server" Text="Tour Code: " meta:resourcekey="keyTourCode"></asp:Label></strong>
                                                <asp:LinkButton ID="hlTourCode" runat="server" CssClass="t13" CommandName="Select">
                                                    <asp:Label ID="lblTourCode" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Code.ToString() %>'></asp:Label></asp:LinkButton></td>
                                        </tr>
                                        <tr>
                                            <td height="5">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="690" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="160" align="left" valign="top">
                                                <asp:Image ID="imgTour" runat="server" Width="150" Height="100" border="0" onerror="this.src='http://www.majestic-vacations.com/images/default_pic.gif';" />
                                                <asp:Image ID="imgSale" ImageUrl="http://www.majestic-vacations.com/images/icon_sale.png"
                                                    runat="server" Width="72" Height="47" vspace="5" Style="position: absolute; margin: -5px 0px 0px -159px;
                                                    *margin: -10px 0px 0px -164px;" />
                                            </td>
                                            <td width="370" valign="top">
                                                <table width="377" height="80" border="0" cellpadding="0" cellspacing="0" class="t15">
                                                    <tr>
                                                        <td width="126" align="left" valign="top">
                                                            <b>
                                                                <asp:Label ID="Label1" meta:resourcekey="lblDeparturePlace" runat="server" Text="Departure Place"></asp:Label>:</b></td>
                                                        <td width="252" align="left" valign="top">
                                                            <asp:Label ID="lblDeparturePlace" runat="server" Text="New York"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="left">
                                                            <b>
                                                                <asp:Label ID="Label2" meta:resourcekey="lblDuration" runat="server" Text="Duration"></asp:Label>:</b></td>
                                                        <td valign="top" align="left">
                                                            <asp:Label ID="lblDuration" runat="server" Text='<%# ((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Days.ToString() %>'></asp:Label>
                                                            Days</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <b>
                                                                <asp:Label ID="Label3" meta:resourcekey="lblOperating" runat="server" Text="Operating"></asp:Label>:</b></td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOperating" runat="server" Text="Sep 17th 2011 - Oct 15th 2011: Daily"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <strong>
                                                                <asp:Label ID="Label4" meta:resourcekey="lblVisiting" runat="server" Text="Visiting"></asp:Label>:</strong></td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVisiting" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr style="display: none">
                                                        <td colspan="2" align="left" valign="top">
                                                            <span id="ctl00_MainContent_Label"><b>
                                                                <asp:Label ID="Label5" meta:resourcekey="lblHighlights" runat="server" Text="Highlights"></asp:Label>:</b></span><span
                                                                    id="ctl00_MainContent_lblHighlight"><strong><br />
                                                                    </strong><span id="ctl00_MainContent_lblHighlight4">
                                                                        <asp:Label ID="lblHighlight" runat="server" Text=""></asp:Label></span><br />
                                                                </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="150" valign="top">
                                                <table align="right" border="0" cellpadding="0" cellspacing="0" width="95">
                                                    <tbody>
                                                        <tr align="right" valign="top">
                                                            <td align="center" width="150" nowrap="nowrap">
                                                                <font class="t11">
                                                                    <asp:Label ID="Label6" meta:resourcekey="lblStartingFrom" runat="server" Text="Starting From"></asp:Label></font><font
                                                                        class="t11">
                                                                        <br />
                                                                        $<span class="tour-list_price"><asp:Label ID="lbl_PriceValue" runat="server" Text='000.00' /></span><asp:Label
                                                                            ID="Label7" meta:resourcekey="lblQi" runat="server" Text=""></asp:Label>
                                                                        <br />
                                                                    </font>
                                                            </td>
                                                        </tr>
                                                        <tr align="left" valign="top">
                                                            <td align="center">
                                                                <img runat="server" id="Icon21" src="../../images/Icon_21.gif" visible="false" width="128"
                                                                    height="22" vspace="5" /></td>
                                                        </tr>
                                                        <tr align="left" valign="top">
                                                            <td align="center">
                                                                <img runat="server" id="Icon22" src="../../images/Icon_22.gif" visible="false" width="128"
                                                                    height="22" vspace="5" /></td>
                                                        </tr>
                                                        <tr align="left" valign="top">
                                                            <td align="center">
                                                                <asp:ImageButton ID="imgbtnTour" ImageUrl="http://www.majestic-vacations.com/images/Icon_check-detail.gif"
                                                                    meta:resourcekey="imgTour" runat="server" Width="118" Height="32" vspace="5"
                                                                    border="0" CommandName="Select" /></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <%--<div id="pagebar">
                    <div id="pagenumber">
                        <p>
                            <a href="#" class="t13">Top </a>
                        </p>
                    </div>
                    <!-- Pages Begin -->
                    <div class="page">
                        <ul class="page_ul">
                            <li class="page_li"><a class="firstno toFirstPage ui-alink1"></a></li>
                            <li class="page_li"><a href="#p9" class="prevno toPrevPage ui-alink1"></a></li>
                            <li class="page_li"><a href="#p1" class="PageNum p1 ui-alink1 current">1</a></li>
                            <li class="page_li"><a href="#p2" class="PageNum p2 ui-alink1">2</a></li>
                            <li class="page_li"><a href="#p3" class="PageNum p3 ui-alink1">3</a></li>
                            <li class="page_li"><a href="#p4" class="PageNum p4 ui-alink1">4</a></li>
                            <li class="page_li"><a href="#p5" class="PageNum p5 ui-alink1">5</a></li>
                            <li class="page_li"><a href="#p2" class="next toNextPage ui-alink1"></a></li>
                            <li class="page_li"><a href="#p6" class="last toLastPage ui-alink1"></a></li>
                        </ul>
                    </div>
                    <!-- Pages End -->
                </div>--%>
            </td>
        </tr>
        <tr>
            <td height="7" bgcolor="#FFFFFF">
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF">
                <uc4:PageNumber ID="PageNumber1" runat="server"></uc4:PageNumber>
            </td>
        </tr>
        <tr>
            <td height="3" bgcolor="#FFFFFF">
            </td>
        </tr>
    </table>
</asp:Content>
