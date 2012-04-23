<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewInsuranceContactInformationControl.ascx.cs" Inherits="NewInsuranceContactInformationControl" %>
<asp:UpdatePanel runat="server" ID="upContact">
    <ContentTemplate>
        <table class="IBE_package_step5_TravelInfo_T_step0l" width="100%" align="center"
            border="0" style="margin-bottom: 0px;" cellpadding="0" cellspacing="1">
            <tbody>
                <tr class="IBE_package_step5_TravelInfo_R_stepw">
                    <td>
                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                            <tbody>
                                <tr class="IBE_package_step5_TravelInfo_R_step03" align="center">
                                    <td align="left" height="23" style="color:Blue">
                                        Contact Information</td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="IBE_T_step03" width="100%" border="0" cellpadding="3" cellspacing="1">
                            <tbody>
                                <tr class="IBE_R_stepw" align="left">
                                    <td width="20%">
                                        <span class="Required_t01">*</span> Gender:</td>
                                    <td colspan="3">
                                        <table id="Table4" border="0" cellpadding="0" cellspacing="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 44px" colspan="2">
                                                        <asp:RadioButtonList ID="rbtnGender" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="0">Mr</asp:ListItem>
                                                            <asp:ListItem Value="1">Mrs</asp:ListItem>
                                                            <asp:ListItem Value="2">Ms</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Last Name:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtLast" runat="server"></asp:TextBox>
                                        &nbsp;&nbsp;Middle Name:<asp:TextBox ID="txtMiddle" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> First Name:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Email Address:</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="415px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Phone Number
                                        <br>
                                        &nbsp;&nbsp;&nbsp;(daytime):</td>
                                    <td>
                                        <asp:TextBox ID="txtPhoneDay" runat="server" onblur="copytext(this)"></asp:TextBox>
                                    </td>
                                    <td width="20%">
                                        Phone Number (nighttime):</td>
                                    <td>
                                        <asp:TextBox ID="txtPhoneNight" runat="server" onblur="copytext(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Street Address:</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtStreet" runat="server" Width="415px" onblur="copytext(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> City:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtCity" runat="server" onblur="copytext(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Country &amp; State:</td>
                                    <td colspan="3">
                                        <asp:UpdatePanel runat="server" ID="CountryAndState">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCountry" runat="server" Width="180px" AutoPostBack="true"
                                                    onblur="copytext('aa')" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Please select country."
                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlState" runat="server" onblur="copytext('aa')">
                                                </asp:DropDownList></ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Zip&nbsp;/&nbsp;Postal Code:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtZip" runat="server" onblur="copytext(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        Fax:</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>