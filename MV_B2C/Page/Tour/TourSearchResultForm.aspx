<%@ Page Language="C#" MasterPageFile="TourBookingPage.Master" AutoEventWireup="true" Inherits="TourSearchResultForm" EnableEventValidation="false" Codebehind="TourSearchResultForm.aspx.cs" %>
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
                                <span class="head06">Select a Tour</span></td>
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
                    <table width="100%" border="0" cellspacing="1" cellpadding="4" class="T_step03">
                        <tr class="R_stepw">
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
                                    <tr>
                                        <td align="left">
                                            <img src="images/btn_select.gif" hspace="2" vspace="5" border="0" align="absmiddle" />
                                            : Further seach required to check.</td>
                                    </tr>
                                </table>
                            </td>
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
                                            <asp:DataList ID="dlTourProduct" runat="server" Width="100%" HorizontalAlign="Center" OnItemCommand="dlTourProduct_ItemCommand" OnItemDataBound="dlTourProduct_ItemDataBound">
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="0" class="T_step0l">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                                                                    <tr class="R_step03" align="center">
                                                                        <td width="71%" height="30" align="left">
                                                                              <asp:Label ID="lblTourName" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Name.ToString() %>'>
                                                                                                        </asp:Label></td>
                                                                        <td width="29%" align="right">
                                                                            Tour Code :   <asp:Label ID="Label2" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Code.ToString() %>'>
                                                                                                        </asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr class="R_stepw">
                                                            <td>
                                                                <table border="0" cellpadding="10" cellspacing="1" width="100%" class="T_step03">
                                                                    <tr class="R_stepw" align="center">
                                                                        <td align="left">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="72%">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td width="14%" valign="top">
                                                                                                    <strong>Highlight :</strong><br />
                                                                                                    <asp:Label ID="Label3" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Description.ToString() %>'>
                                                                                                        </asp:Label>
                                                                                                    
                                                                                                   <br />
                                                                                                </td>
                                                                                            </tr>
                                                                                           <tr id="trIsShowAirline" runat="server">
                                                                                                <td valign="top">
                                                                                                
                                                                                                
                                                                                                    <strong>Airelines :</strong><img src='<%# ImageUrlHead +(((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Airlines.Count>0?((Airline)((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Airlines[0]).LogoUrl:"")%>' hspace="3" vspace="2"
                                                                                                        border="0" align="absmiddle" /><asp:Label ID="Label5" runat="server" Text='<%# ((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Airlines.Count>0?((Airline)((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Airlines[0]).Name :""%>'>
                                                                                                        </asp:Label></td>
                                                                                            </tr>
                                                                                            <%--<tr>
                                                                                                <td valign="top">
                                                                                                    <strong>Guide :</strong> <asp:Label ID="Label4" runat="server" Text='<%# ((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Guide!=null?((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Guide.ToString():"" %>'>
                                                                                                        </asp:Label></td>
                                                                                            </tr>--%>
                                                                                             <tr>
                                                                                                <td valign="top">
                                                                                                    <strong>Duration :</strong> <asp:Label ID="Label6" runat="server" Text='<%# ((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Days.ToString() %>'>
                                                                                                        </asp:Label>&nbsp;days</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top">
                                                                                                    <strong><asp:Label ID="lbl_HasAir" runat="server"> Air + </asp:Label>Land Price :</strong><font class="t11"> From $</strong> <asp:Label ID="lbl_PriceValue" runat="server" Text='000.00'/><asp:Label ID="lblDisp" runat="server">(Departure from&nbsp;</asp:Label><asp:Label ID="lbl_DeptFrom" runat="server"></asp:Label></font></td>
                                                                                            </tr>
                                                                                            <%--<tr>
                                                                                                <td valign="top">
                                                                                                    <strong>Travel Date :</strong> <asp:Label ID="Label6" runat="server" Text='<%# ((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Days.ToString() %>'>
                                                                                                        </asp:Label>days</td>
                                                                                            </tr>--%>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td width="20%" align="center" valign="top">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <%--<img src='<%#  ImageUrlHead +((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Logo.ToString() %>' width="150"
                                                                                                        height="100" vspace="10" />--%>
                                                                                                        <asp:Image ID="imgTour" runat="server" ImageUrl='<%# ImageUrlHead + ((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Logo.ToString() %>'
                                                                                                                     Width="150" Height="100" /></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                <asp:ImageButton  ImageUrl="images/btn_select.gif" runat="server" CommandName="Select"/>
                                                                                                    </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
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
    </div>
</asp:Content>
