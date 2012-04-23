<%@ Page Language="C#" AutoEventWireup="true" Codebehind="VehcilePriceTravelForm.aspx.cs"
    Inherits="VehcilePriceTravelForm" %>

<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc10" %>

<%@ Register Src="../../UserControls/VehcileInfoALLControl.ascx" TagName="VehcileInfoALLControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/VehcileInfoControl.ascx" TagName="VehcileInfoControl"
    TagPrefix="uc9" %>
<%@ Register Src="../../UserControls/VehcileInfoViewControl.ascx" TagName="VehcileInfoViewControl"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/VehcilePriceInfoControl.ascx" TagName="VehcilePriceInfoControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Hotel.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Global.css"%>" rel="stylesheet" type="text/css" />

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>

    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="" name="DefaultTab" runat="server" /><input
            id="FocusIndex" type="hidden" value="" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="920" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="15">
                                </td>
                            </tr>
                            <tr>
                                <td height="10">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="25" align="right" valign="top">
                                                <uc10:NavigationControl ID="NavigationControl1" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
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
                                                                                <td height="25" valign="top" class="D_stepr" style="width: 898px">
                                                                                    Your Order Summary</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 898px">
                                                                                    <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                        <tr class="R_stepw">
                                                                                            <td height="120">
                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <uc8:VehcileInfoALLControl ID="VehcileInfoALLControl1" runat="server" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
                                                                                                    width="100%">
                                                                                                    <tr class="R_stepw">
                                                                                                        <td align="center">
                                                                                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                                                                <tr align="center" class="R_order03">
                                                                                                                    <td height="23" colspan="7" align="center">
                                                                                                                        <b>Car Information</b></td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <uc3:VehcileInfoViewControl ID="VehcileInfoViewControl1" runat="server" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                                    <tr class="R_stepw">
                                                                                                        <td align="left">
                                                                                                            <uc6:VehcilePriceInfoControl ID="VehcilePriceInfoControl1" runat="server" />
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                <tr>
                                                                                                                    <td align="right">
                                                                                                                        <font color="#FF3300">*</font> You will not be charged by Majestic Vacationa. You
                                                                                                                        will pay at the reservation desk.
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
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                                                        1</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="5">
                                                        </td>
                                                        <td align="left">
                                                            <span class="head06">Enter Travelers &amp; Contact Information</span></td>
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
                                                <table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                                                    <tr class="R_stepo">
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="7">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                            <tr class="R_stepw">
                                                                                <td>
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="20" align="left" valign="top">
                                                                                                Whose name should be used for car rental pick-up? <font color="#FF3300">Must be age
                                                                                                    25+ and have valid credit card.</font></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="20" align="right" valign="top">
                                                                                                <span class="t01">*</span> = Required</td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table class="T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
                                                                                        width="100%">
                                                                                        <tr class="R_stepw">
                                                                                            <td>
                                                                                                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                                                    <tr align="center" class="R_step03">
                                                                                                        <td height="23" align="left">
                                                                                                            Primary Driver</td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td width="20%">
                                                                                                            <span class="t01">*</span> Gender:</td>
                                                                                                        <td>
                                                                                                            <asp:RadioButtonList ID="rbtPassengerGender" runat="server" RepeatDirection="Horizontal">
                                                                                                                <asp:ListItem Value="0">Mr</asp:ListItem>
                                                                                                                <asp:ListItem Value="1">Ms</asp:ListItem>
                                                                                                            </asp:RadioButtonList></td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td width="20%">
                                                                                                            <span class="t01">*</span> First Name:
                                                                                                        </td>
                                                                                                        <td width="81%">
                                                                                                            <asp:TextBox ID="txtPassengerFirst" runat="server"></asp:TextBox>
                                                                                                            <span id="OrderPassengerInfo1_dlAdult_ctl00_txtAdultFirst_rfvMustInput" style="color: Red;
                                                                                                                display: none;"></span><span id="OrderPassengerInfo1_dlAdult_ctl00_txtAdultFirst_revMustInput"
                                                                                                                    style="color: Red; display: none;"></span>&nbsp;&nbsp;Middle Name:
                                                                                                            <asp:TextBox ID="txtPassengerMiddle" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            <span class="t01">*</span> Last Name:
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtPassengerLast" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="8">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
                                                                                        width="100%">
                                                                                        <tr class="R_stepw">
                                                                                            <td>
                                                                                                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                                                    <tr align="center" class="R_order">
                                                                                                        <td height="23" align="left">
                                                                                                            Contact Information</td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td width="20%">
                                                                                                            <span class="t01">*</span> Gender:</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:RadioButtonList ID="rbtContactGender" runat="server" RepeatDirection="Horizontal">
                                                                                                                <asp:ListItem Value="0">Mr</asp:ListItem>
                                                                                                                <asp:ListItem Value="1">Ms</asp:ListItem>
                                                                                                            </asp:RadioButtonList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            <span class="t01">*</span> First Name:
                                                                                                        </td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtFirst" runat="server" MaxLength=20></asp:TextBox>
                                                                                                            &nbsp;&nbsp;Middle Name:
                                                                                                            <asp:TextBox ID="txtMiddle" runat="server" MaxLength=20></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            <span class="t01">*</span> Last Name:
                                                                                                        </td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtLast" runat="server" MaxLength=20></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            <span class="t01">*</span> Email Address:</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtEmail" runat="server" MaxLength=50></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            <span class="t01">*</span> Phone Number (daytime):</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtPhoneDay" runat="server"></asp:TextBox>
                                                                                                            <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="20%">
                                                                                                            Phone Number (nighttime):</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtPhoneNight" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            <span class="t01">*</span> Street Address:</td>
                                                                                                        <td colspan="3">
                                                                                                            &nbsp;</td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            <span class="t01">*</span> City:
                                                                                                        </td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            <span class="t01">*</span> Country &amp; State:</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:DropDownList ID="ddlCountry" runat="server" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                                                                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                                                                ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Please select country or area."
                                                                                                                SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator>
                                                                                                            <asp:DropDownList ID="ddlState" runat="server">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            <span class="t01">*</span> Zip&nbsp;/&nbsp;Postal Code:
                                                                                                        </td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" class="R_stepw">
                                                                                                        <td>
                                                                                                            Fax:</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
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
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                                                        2</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="5">
                                                        </td>
                                                        <td align="left">
                                                            <span class="head06">Other Remark for Your Trip</span></td>
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
                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step02">
                                                    <tr class="R_stepw">
                                                        <td align="center">
                                                            <textarea class="remark" runat="server" name="textarea" id="txtRemark"></textarea></td>
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
                                        <tr>
                                            <td align="right">
                                                Please confirm all of the information is correct, then click &nbsp;
                                                <asp:Button ID="btnContinue" runat="server" Text="Continue" class="search_btn02"
                                                    OnClick="btnContinue_Click" />
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
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
