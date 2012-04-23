<%@ Control Language="C#" AutoEventWireup="true" Inherits="HotelOrderPassengerInfoControl"
    Codebehind="HotelOrderPassengerInfoControl.ascx.cs" %>
<%--<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc2" %>--%>
<asp:DataList ID="dlAdult" runat="server" Width="100%" OnItemDataBound="dlAdult_ItemDataBound">
    <ItemTemplate>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="IBE_package_step5_TravelInfo_T_step0l">
            <tr class="IBE_package_step5_TravelInfo_R_stepw">
                <td>
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tbody>
                            <tr class="IBE_package_step5_TravelInfo_R_step03" align="center">
                                <td align="left" height="25">
                                    <asp:Label ID="Label1" runat="server" meta:resourcekey="lblAdultTraveler">Adult Traveler</asp:Label>
                                    #<asp:Label ID="lblAdultCount" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                    <table class="IBE_T_step03 IBE_T_font_11" width="100%" border="0" cellpadding="3"
                        cellspacing="1">
                        <tbody>
                            <tr class="IBE_R_stepw" align="left">
                                <td>
                                    <span class="Required_t01">*</span><asp:Label ID="Label2" runat="server" meta:resourcekey="lblGender">Gender</asp:Label>:</td>
                                <td>
                                    <asp:RadioButtonList ID="rbtnAdultGender" runat="server" RepeatDirection="Horizontal"
                                        Style="margin: 0px; padding: 0px; margin-right: 3px; display: inline;">
                                        <asp:ListItem Selected="True" Value="0" meta:resourcekey="item1">Mr</asp:ListItem>
                                        <asp:ListItem Value="1" meta:resourcekey="item2">Ms</asp:ListItem>
                                        <asp:ListItem Value="2" meta:resourcekey="item3">Mrs</asp:ListItem>
                                        <asp:ListItem Value="3" meta:resourcekey="item4">Dr</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr class="IBE_R_stepw">
                                <td>
                                    <span class="Required_t01">*</span><asp:Label ID="Label5" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAdultLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'
                                        CausesValidation="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Must Input Last Name"
                                        ControlToValidate="txtAdultLast" Display="Dynamic"></asp:RequiredFieldValidator><asp:Label
                                            ID="Label4" runat="server" meta:resourcekey="lblMiddleName">Middle Name</asp:Label>:
                                    <asp:TextBox ID="txtAdultMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw">
                                <td width="19%">
                                    <span class="Required_t01">*</span><asp:Label ID="Label3" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
                                </td>
                                <td width="81%">
                                    <asp:TextBox ID="txtAdultFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'
                                        CausesValidation="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Must Input First Name"
                                        ControlToValidate="txtAdultFirst" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw">
                                <td>
                                    <asp:Label ID="Label6" runat="server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAdultPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <%--                            <asp:PlaceHolder ID="pMeal" runat="server">
                                <tr class="IBE_R_stepw">
                                    <td>
                                        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblMeal">Meal</asp:Label>:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAdultMeal" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </asp:PlaceHolder>--%>
                    </table>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
<asp:DataList ID="dlChild" runat="server" Width="100%" OnItemDataBound="dlChild_ItemDataBound">
    <ItemTemplate>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="IBE_package_step5_TravelInfo_T_step0l">
            <tr class="IBE_package_step5_TravelInfo_R_stepw">
                <td>
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tbody>
                            <tr class="IBE_package_step5_TravelInfo_R_step03" align="center">
                                <td align="left" height="25">
                                    <asp:Label ID="Label5" runat="server" meta:resourcekey="lblChildTraveler">Child Traveler</asp:Label>
                                    #<asp:Label ID="lblChildCount" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table class="IBE_T_step03 IBE_T_font_11" width="100%" border="0" cellpadding="3"
                        cellspacing="1">
                        <tbody>
                            <tr class="IBE_R_stepw" align="left">
                                <td>
                                    <span class="Required_t01">*</span><asp:Label ID="Label2" runat="server" meta:resourcekey="lblGender">Gender</asp:Label>:</td>
                                <td>
                                    <asp:RadioButtonList ID="rbtnChildGender" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0" meta:resourcekey="item1">Mr</asp:ListItem>
                                        <asp:ListItem Value="1" meta:resourcekey="item3">Mrs</asp:ListItem>
                                        <asp:ListItem Value="2" meta:resourcekey="item2">Ms</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr class="IBE_R_stepw">
                                <td>
                                    <span class="Required_t01">*</span><asp:Label ID="Label9" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'
                                        CausesValidation="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Must Input Last Name"
                                        ControlToValidate="txtChildLast" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:Label ID="Label8" runat="server" meta:resourcekey="lblMiddleName">Middle Name</asp:Label>:
                                    <asp:TextBox ID="txtChildMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw">
                                <td width="19%">
                                    <span class="Required_t01">*</span><asp:Label ID="Label3" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
                                </td>
                                <td width="81%">
                                    <asp:TextBox ID="txtChildFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'
                                        CausesValidation="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Must Input First Name"
                                        ControlToValidate="txtChildFirst" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw">
                                <td>
                                    <span class="Required_t01">*</span><asp:Label ID="Label10" runat="server" meta:resourcekey="lblDateOfBirth">Date of Birth</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildBirthday" runat="server"></asp:TextBox>
                                    e.g. MM/DD/YYYY</td>
                            </tr>
                            <tr class="IBE_R_stepw">
                                <td>
                                    <asp:Label ID="Label11" runat="server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <%--<asp:PlaceHolder ID="pMeal" runat="server">
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" meta:resourcekey="lblMeal">Meal</asp:Label>:</td>
                    <td>
                        <asp:DropDownList ID="ddlChildMeal" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </asp:PlaceHolder>--%>
                    </table>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>