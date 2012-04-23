<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="InsuranceControl" Codebehind="InsuranceControl.ascx.cs" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="TermsCalender" TagPrefix="TermsCalender" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<asp:DataList ID="dlAdult" runat="server" Width="100%">
    <ItemTemplate>
        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="traveller">
            <tr class="name">
                <td colspan="2">
                    Adult Traveler #<asp:Label ID="lblAdultCount" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>
                </td>
            </tr>
            <%--<tr>
                <td>
                    <span class="redlab">*</span>Gender:</td>
                <td>
                    <asp:RadioButtonList ID="rbtnAdultGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">Mr</asp:ListItem>
                        <asp:ListItem Value="1">Ms</asp:ListItem>
                        <asp:ListItem Value="2">Mrs</asp:ListItem>
                        <asp:ListItem Value="3">Dr</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>--%>
            <tr>
                <td width="19%">
                    <span class="redlab">*</span>First Name:
                </td>
                <td width="81%">
                    <asp:Label ID="lblAdultFirstName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>Last Name:
                </td>
                <td>
                    <asp:Label ID="lblAdultLastName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>Date of Birth:
                </td>
                <td>
                    <%--<TermsCalender:TermsCalender ID="txtAdultBirthday" runat="server" />--%>
                    <asp:TextBox ID="txtAdultBirthday" runat="server"></asp:TextBox>
                    e.g. MM/DD/YYYY</td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>Street:
                </td>
                <td>
                    <uc1:MustInputTextBox ID="txtAdultStreet" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>City:
                </td>
                <td>
                    <uc1:MustInputTextBox ID="txtAdultCity" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>State::
                </td>
                <td>
                    <%--<uc1:MustInputTextBox ID="txtAdultState" runat="server" Width="300px" />--%>
                    <asp:DropDownList ID="ddlAdultState" runat="server">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="ddlAdultState" Display="Dynamic" ErrorMessage="Please select city."
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>Country or Area:
                </td>
                <td>
                    <%--<uc1:MustInputTextBox ID="txtAdultCountry" runat="server" Width="300px" />--%>
                    <asp:DropDownList ID="ddlAdultCountry" runat="server" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlAdultCountry_SelectedIndexChanged">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="ddlAdultCountry" Display="Dynamic" ErrorMessage="Please select country or area."
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Email:
                </td>
                <td>
                    <uc1:MustInputTextBox ID="txtAdultEmail" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>ZipCode:
                </td>
                <td>
                    <uc1:MustInputTextBox ID="txtAdultZipCode" runat="server" Width="300px" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
<asp:DataList ID="dlChild" runat="server" Width="100%">
    <ItemTemplate>
        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="traveller">
            <tr class="name">
                <td colspan="2">
                    Child Traveler #<asp:Label ID="lblChildCount" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>
                </td>
            </tr>
            <%--<tr>
                <td>
                    <span class="redlab">*</span>Gender:</td>
                <td>
                    <asp:RadioButtonList ID="rbtnChildGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">Mr</asp:ListItem>
                        <asp:ListItem Value="1">Mrs</asp:ListItem>
                        <asp:ListItem Value="2">Ms</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>--%>
            <tr>
                <td width="19%">
                    <span class="redlab">*</span>First Name:
                </td>
                <td width="81%">
                    <asp:Label ID="lblChildFirstName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>Last Name:
                </td>
                <td>
                    <asp:Label ID="lblChildLastName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>Date of Birth:
                </td>
                <td>
                    <asp:Label ID="lblChildBirthday" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Birthday") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>Street:
                </td>
                <td>
                    <uc1:MustInputTextBox ID="txtChildStreet" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>City:
                </td>
                <td>
                    <uc1:MustInputTextBox ID="txtChildCity" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>State::
                </td>
                <td>
                    <%--<uc1:MustInputTextBox ID="txtChildState" runat="server" Width="300px" />--%>
                    <asp:DropDownList ID="ddlChildState" runat="server">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="ddlChildState" Display="Dynamic" ErrorMessage="Please select city."
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>Country or Area:
                </td>
                <td>
                    <%--<uc1:MustInputTextBox ID="txtChildCountry" runat="server" Width="300px" />--%>
                    <asp:DropDownList ID="ddlChildCountry" runat="server" Width="180px" AutoPostBack="True">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="ddlChildCountry" Display="Dynamic" ErrorMessage="Please select country or area."
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Email:
                </td>
                <td>
                    <uc1:MustInputTextBox ID="txtChildEmail" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="redlab">*</span>ZipCode:
                </td>
                <td>
                    <uc1:MustInputTextBox ID="txtChildZipCode" runat="server" Width="300px" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
