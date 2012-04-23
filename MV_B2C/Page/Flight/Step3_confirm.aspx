<%@ Page Language="C#" MasterPageFile="BookingPage.Master" AutoEventWireup="true"
    Inherits="Step3_confirm" Title="Step3_confirm" Codebehind="Step3_confirm.aspx.cs" %>

<%@ Register Src="~/UserControls/UserLoginControl.ascx" TagName="UserLoginControl"
    TagPrefix="uc9" %>
<%@ Register Src="~/UserControls/PriceInfoControl.ascx" TagName="PriceInfoControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/FlightHeaderControl.ascx" TagName="FlightHeaderControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/FlightDetailsControl.ascx" TagName="FlightDetailsControl"
    TagPrefix="uc7" %>
<%@ MasterType VirtualPath="BookingPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <input id="OrderId" runat="server" name="OrderId" type="hidden" value="" />
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="0" class="T_table">
        <tr>
            <td align="right" valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" class="T_step02">
                    <tr class="R_step02">
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr align="left">
                                                            <td height="25" valign="top" class="D_stepr">
                                                                <asp:Label ID="lblReview" runat="server" meta:resourcekey="lblReviewOrder">Review The Order You Selected</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                    <tr class="R_stepw">
                                                                        <td height="120">
                                                                            <uc3:FlightHeaderControl ID="FlightHeaderControl1" runat="server" />
                                                                            <uc7:FlightDetailsControl ID="FlightDetailsControl1" runat="server" />
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td height="10">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <uc6:PriceInfoControl ID="PriceInfoControl1" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr class="R_content">
                                                            <td height="50" align="right">
                                                                <asp:PlaceHolder ID="P_table" runat="server">
                                                                    <asp:Label ID="Label1" runat="server" meta:resourcekey="lblMsg">Please click on <font id="P_red">"Continue"</font> to determine final price for
                                                                                            your itinerary.</asp:Label>&nbsp;
                                                                    <asp:Button ID="btn_button" runat="server" Text="Continue" OnClick="btn_button_Click"
                                                                        CssClass="search_btn02" Style="cursor: hand" meta:resourcekey="lblContinue" />&nbsp;&nbsp;</asp:PlaceHolder>
                                                                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="search_btn03"
                                                                    Style="cursor: hand" meta:resourcekey="lblBack" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr class="R_step04">
                                    <td height="20">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                </table>
                <div id="divSignIn" runat="server" visible="false">
                    <uc9:UserLoginControl ID="UserLoginControl1" runat="server" />
                </div>
            </td>
        </tr>
        <tr align="left">
            <td>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
    
        if (document.getElementById("ctl00_MainContent_UserLoginControl1_txtPassword") != null){
        document.getElementById("ctl00_MainContent_UserLoginControl1_txtPassword").onfocus=function document.onkeydown()
        {
             if   (event.keyCode   ==   13 && document.getElementById("ctl00_MainContent_UserLoginControl1_txtPassword").value != "")
             {
                document.body.focus();
                document.getElementById("ctl00_MainContent_UserLoginControl1_btnLogin").click();
             }
        }
        }
        if (document.getElementById("ctl00_MainContent_UserLoginControl1_txtUserName") != null){
        document.getElementById("ctl00_MainContent_UserLoginControl1_txtUserName").onfocus=function document.onkeydown()
        {
             if   (event.keyCode   ==   13 && document.getElementById("ctl00_MainContent_UserLoginControl1_txtUserName").value != "")
             {
                document.body.focus();
                document.getElementById("ctl00_MainContent_UserLoginControl1_btnLogin").click();
             }
        }
        }
    </script>

</asp:Content>
