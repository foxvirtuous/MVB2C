<%@ Page Language="C#" AutoEventWireup="true" Codebehind="InputIncentiveTour.aspx.cs" EnableEventValidation="false" validateRequest="false"
    Inherits="InputIncentiveTour" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/Style_intour.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="920">
                    <img src="/images/v2/intour_01.jpg"><img src="/images/v2/intour_02.jpg"><img src="/images/v2/intour_03.jpg"><img
                        src="/images/v2/intour_04.jpg"></td>
            </tr>
        </table>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="329" align="right" valign="top">
                    <table width="329" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="/images/v2/intour_05.gif" border="0" /></td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/images/v2/intour_11.gif" border="0" /></td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/images/v2/intour_14.gif" border="0" /></td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/images/v2/intour_15.gif" border="0" /></td>
                        </tr>
                        <tr>
                            <td height="20">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td width="577" align="left" valign="top">
                    <div>
                        <table width="577" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="3">
                                    <img src="/images/v2/intour_06.gif" border="0" /></td>
                            </tr>
                            <tr>
                                <td width="15" background="/images/v2/intour_08.gif">
                                    <img src="/images/v2/intour_08.gif" border="0" /></td>
                                <td width="547" align="center" valign="top">
                                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="tour">
                                        <tr>
                                            <td width="50%" height="40" colspan="2" style="border-bottom: solid #cccccc 1px">
                                                <span class="head05"><font color="#000000">Incentive Tour Request Form</font></span></td>
                                            <td width="50%" colspan="2" align="right" style="border-bottom: solid #cccccc 1px">
                                                <font color="#FF3300">*</font> = required field</td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                <font color="#FF3300">*</font> Contact Person:
                                            </td>
                                            <td align="left" style="width: 146px">
                                                <asp:TextBox ID="txtContactPerson" runat="server" size="25" MaxLength=100></asp:TextBox></td>
                                            <td align="left">
                                                <font color="#FF3300">*</font>Company Name:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCompanyName" runat="server" size="25" MaxLength=100></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                <font color="#FF3300">*</font> Tel #:
                                            </td>
                                            <td height="30" align="left" style="width: 146px">
                                                <asp:TextBox ID="txtTel" runat="server" size="25" MaxLength=20></asp:TextBox></td>
                                            <td align="left">
                                                Cell #:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCell" runat="server" size="25" MaxLength=20></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                <font color="#FF3300">*</font> E-mail:
                                            </td>
                                            <td height="30" align="left" style="width: 146px">
                                                <asp:TextBox ID="txtEmail" runat="server" size="25" MaxLength=100></asp:TextBox></td>
                                            <td align="left">
                                                Fax:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtFax" runat="server" size="25" MaxLength=20></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                <font color="#FF3300">*</font> Contact By:
                                            </td>
                                            <td height="30" colspan="3" align="left">
                                                <asp:CheckBoxList ID="chkContactBy" runat="server" RepeatDirection="Horizontal" CssClass="radio_btn">
                                                    <asp:ListItem Value="0">Tel&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="1">E-mail&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="2">Fax</asp:ListItem>
                                                </asp:CheckBoxList></td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                <font color="#FF3300">*</font> Address:
                                            </td>
                                            <td height="30" colspan="3" align="left">
                                                <asp:TextBox ID="txtAddress" runat="server" size="70" MaxLength=200></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td height="30" colspan="4" align="left">
                                                <font color="#FF3300">*</font> City:
                                                <asp:TextBox ID="txtCity" runat="server" size="15" MaxLength=50></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;&nbsp;<font color="#FF3300">*</font> State:
                                                <asp:TextBox ID="txtState" runat="server" size="15" MaxLength=50></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;&nbsp;<font color="#FF3300">*</font> Zip Code:
                                                <asp:TextBox ID="txtZipCode" runat="server" size="15" MaxLength=20></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                Budget Amount:
                                            </td>
                                            <td height="30" colspan="3" align="left">
                                                <asp:TextBox ID="txtBudgetAmount" runat="server" size="25" MaxLength=20></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td height="30" colspan="2" align="left">
                                                <div style="float: left;">
                                                    <font color="#FF3300">*</font> Estimate Arrival China:</div>
                                                <TermsCalender:TermsCalendar ID="txtEstimateArrivalChina" runat="server" />
                                            </td>
                                            <td colspan="2" align="left">
                                                <div style="float: left;">
                                                    <font color="#FF3300">*</font> Estimate Dept. China:</div>
                                                <TermsCalender:TermsCalendar ID="txtEstimateDeptChina" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                <font color="#FF3300">*</font> Trip Plan:
                                            </td>
                                            <td height="30" align="left" style="width: 146px">
                                                <asp:TextBox ID="txtTripPlan" runat="server" size="5" MaxLength=4></asp:TextBox>
                                                days</td>
                                            <td height="30" align="left">
                                                <font color="#FF3300">*</font> Estimate Register:
                                            </td>
                                            <td height="30" align="left">
                                                <asp:TextBox ID="txtEstimateRegister" runat="server" size="5" MaxLength=10></asp:TextBox>
                                                Person</td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                <font color="#FF3300">*</font> Visit Cities:
                                            </td>
                                            <td height="30" colspan="3" align="left">
                                                <asp:CheckBoxList ID="chkVisitCities" runat="server" RepeatDirection="Horizontal"
                                                    Style="float: left;" CssClass="radio_btn">
                                                    <asp:ListItem Value="0">Beijing&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="1">Shanghai&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="2">Guangzhou</asp:ListItem>
                                                    <asp:ListItem Value="3">Others</asp:ListItem>
                                                </asp:CheckBoxList>
                                                <div style="float: left; margin-top: 2px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtVisitCities" runat="server" size="10" MaxLength=20></asp:TextBox></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                Hotel Choose:
                                            </td>
                                            <td height="30" colspan="3" align="left">
                                                <asp:RadioButtonList ID="rbtnHotelChoose" runat="server" RepeatDirection="Horizontal"
                                                    CssClass="radio_btn">
                                                    <asp:ListItem Value="0">First/Tourism Class&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="1">4 Stars&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="2">5 Stars&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="3">Others</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td height="30" align="left">
                                                Specific Hotel:
                                            </td>
                                            <td height="30" colspan="3" align="left">
                                                <asp:TextBox ID="txtSpecificHotel" runat="server" size="50" MaxLength=100></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td height="15" colspan="4" align="left">
                                                Meal Plan(Could Multiple Choose):</td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="4" align="left">
                                                <asp:CheckBoxList ID="chkMealPlan" runat="server" RepeatDirection="Horizontal" CssClass="radio_btn"
                                                    Style="float: left;">
                                                    <asp:ListItem Value="0">Chinese&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="1">Western&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="2">Local Cuisine&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="3">Buffet&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="4">Others</asp:ListItem>
                                                </asp:CheckBoxList><div style="float: left; margin-top: 2px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtMealPlan" runat="server" size="15" MaxLength=20></asp:TextBox></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" colspan="4" align="left">
                                                <div style="float: left; margin-top: 6px;">
                                                    <font color="#FF3300">*</font> Local Guide Request:</div>
                                                <asp:RadioButtonList ID="rbtnLocalGuideRequest" runat="server" RepeatDirection="Horizontal"
                                                    Style="float: left;" CssClass="radio_btn">
                                                    <asp:ListItem Value="0" Selected="True">Yes&#160;&#160;&#160;&#160;</asp:ListItem>
                                                    <asp:ListItem Value="1">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="15" colspan="4" align="left">
                                                <font color="#FF3300">*</font> Local Guide Language Speaking:</td>
                                        </tr>
                                        <tr>
                                            <td height="25" colspan="4" align="left">
                                                <asp:RadioButtonList ID="rbtnLocalGuideLanguageSpeaking" runat="server" RepeatDirection="Horizontal"
                                                    CssClass="radio_btn" Style="float: left;">
                                                    <asp:ListItem Value="0" Selected="True">English&#160;&#160;&#160;&#160;</asp:ListItem>
                                                    <asp:ListItem Value="1">Spanish&#160;&#160;&#160;&#160;</asp:ListItem>
                                                    <asp:ListItem Value="2">Chinese</asp:ListItem>
                                                    <asp:ListItem Value="3">Others</asp:ListItem>
                                                </asp:RadioButtonList><div style="float: left; margin-top: 1px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtLocalGuideLanguageSpeaking" runat="server" size="15" MaxLength=20></asp:TextBox></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                Special Request:<br />
                                                <center>
                                                    <asp:TextBox ID="txtSpecialRequest" runat="server" TextMode="MultiLine" Columns="60"
                                                        Rows="8"></asp:TextBox></center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <asp:Label ID="lblErrorMassage" runat="server" Text="" ForeColor="red" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td colspan="4" style="height: 30px">
                                                <asp:Button ID="btnSend" runat="server" Text="Send Out Your Request" OnClick="btnSend_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="15" background="/images/v2/intour_10.gif">
                                    <img src="/images/v2/intour_10.gif" border="0" /></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="/images/v2/intour_16.gif" border="0" /></td>
                            </tr>
                            <tr>
                                <td height="20" colspan="3">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td width="14" align="right" valign="top">
                    <img src="/images/v2/intour_07.gif" border="0" /></td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
