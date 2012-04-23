<%@ Control Language="C#" AutoEventWireup="true" Inherits="OrderPassengerInfoControl"
    Codebehind="OrderPassengerInfoControl.ascx.cs" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc3" %>
<asp:DataList ID="dlAdult" runat="server" Width="100%" OnItemDataBound="dlAdult_ItemDataBound">
    <ItemTemplate>
        <table class="T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
            width="100%">
            <tr class="R_stepw">
                <td>
                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr align="center" class="R_step03">
                            <td height="23" align="left">
                                <asp:Label ID="lblAdultTraveler" runat="server" meta:resourcekey="lblAdultTraveler">Adult Traveler</asp:Label>
                                #<asp:Label ID="lblAdultCount" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                        <tr align="left" class="R_stepw">
                            <td>
                                <span class="t01">*</span><asp:Label ID="lblGender" runat="server" meta:resourcekey="lblGender">Gender</asp:Label>:</td>
                            <td>
                                <asp:RadioButtonList ID="rbtnAdultGender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0" meta:resourcekey="item1">Mr</asp:ListItem>
                                    <asp:ListItem Value="1" meta:resourcekey="item2">Ms</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbGender" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Salutationn") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr align="left" class="R_stepw">
                            <td>
                                <span class="t01">*</span><asp:Label ID="lblLastName" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdultLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'></asp:TextBox>
                                <asp:Label ID="lblMiddleName" runat="server" meta:resourcekey="lblMiddleName">Middle Name</asp:Label>:
                                <asp:TextBox ID="txtAdultMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName") %>' />
                            </td>
                        </tr>
                        <tr align="left" class="R_stepw">
                            <td width="19%">
                                <span class="t01">*</span><asp:Label ID="lblFirstName" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
                            </td>
                            <td width="81%">
                                <asp:TextBox ID="txtAdultFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left" class="R_stepw">
                            <td>
                                <asp:Label ID="lblPassportNumber" runat="server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdultPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber") %>' />
                            </td>
                        </tr>
                        <asp:PlaceHolder ID="pMeal" runat="server">
                            <tr align="left" class="R_stepw">
                                <td>
                                    <asp:Label ID="lblMeal" runat="server" meta:resourcekey="lblMeal">Meal</asp:Label>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlAdultMeal" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </asp:PlaceHolder>
                        <tr align="left" class="R_stepw">
                            <td>
                                <span class="t01">
                                    <asp:Label ID="lblBir" runat="server">*</asp:Label></span><asp:Label ID="lblBirth"
                                        runat="server" meta:resourcekey="lblBirth">Date of Birth</asp:Label>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdultBirthday" runat="server"></asp:TextBox>
                                e.g. MM/DD/YYYY<asp:RequiredFieldValidator ID="rfvBirth" runat="server" ControlToValidate="txtAdultBirthday"
                                    Enabled="False" ErrorMessage="Please enter birthday"></asp:RequiredFieldValidator></td>
                        </tr>
                        <div id="InsuranceAdultNeed" runat="server" visible="false">
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblStreet" runat="server" meta:resourcekey="lblStreet">Street</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAdultStreet" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblCity" runat="server" meta:resourcekey="lblCity">City</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAdultCity" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblState" runat="server" meta:resourcekey="lblState">State</asp:Label>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAdultState" runat="server">
                                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="ddlAdultState" Display="Dynamic" ErrorMessage="Please select city."
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblCountry" runat="server" meta:resourcekey="lblCountry">Country or Area</asp:Label>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAdultCountry" runat="server" Width="180px" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlAdultCountry_SelectedIndexChanged">
                                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="ddlAdultCountry" Display="Dynamic" ErrorMessage="Please select country or area."
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAdultEmail" runat="server" Width="300px" />
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblZipCode" runat="server" meta:resourcekey="lblZipCode">ZipCode</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAdultZipCode" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                        </div>
                    </table>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
<asp:DataList ID="dlChild" runat="server" Width="100%" OnItemDataBound="dlChild_ItemDataBound">
    <ItemTemplate>
        <table class="T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
            width="100%">
            <tr class="R_stepw">
                <td>
                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr align="center" class="R_step03">
                            <td height="23" align="left">
                                <asp:Label ID="lblChildTraveler" runat="server" meta:resourcekey="lblChildTraveler">Child Traveler</asp:Label>
                                #<asp:Label ID="lblChildCount" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                        <tr align="left" class="R_stepw">
                            <td>
                                <span class="t01">*</span><asp:Label ID="lblGender2" runat="server" meta:resourcekey="lblGender">Gender</asp:Label>:</td>
                            <td>
                                <asp:RadioButtonList ID="rbtnChildGender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">Mr</asp:ListItem>
                                    <asp:ListItem Value="1">Ms</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr align="left" class="R_stepw">
                            <td>
                                <span class="t01">*</span><asp:Label ID="lblLastName2" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtChildLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'></asp:TextBox>
                                <asp:Label ID="lblMiddleName2" runat="server" meta:resourcekey="lblMiddleName">Middle Name</asp:Label>:
                                <asp:TextBox ID="txtChildMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName") %>' />
                            </td>
                        </tr>
                        <tr align="left" class="R_stepw">
                            <td width="19%">
                                <span class="t01">*</span><asp:Label ID="lblFirstName2" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
                            </td>
                            <td width="81%">
                                <asp:TextBox ID="txtChildFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left" class="R_stepw">
                            <td>
                                <span class="t01">*</span></span><asp:Label ID="lblBirth" runat="server" meta:resourcekey="lblBirth">Date of Birth</asp:Label>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtChildBirthday" runat="server" ></asp:TextBox>
                                e.g. MM/DD/YYYY</td>
                        </tr>
                        <tr align="left" class="R_stepw">
                            <td>
                                <asp:Label ID="lblPassportNumber2" runat="server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtChildPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber") %>' />
                            </td>
                        </tr>
                        <asp:PlaceHolder ID="pMeal" runat="server">
                            <tr align="left" class="R_stepw">
                                <td>
                                    <asp:Label ID="lblMeal2" runat="server" meta:resourcekey="lblMeal">Meal</asp:Label>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlChildMeal" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </asp:PlaceHolder>
                        <div id="InsuranceChildNeed" runat="server" visible="false">
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblStreet" runat="server" meta:resourcekey="lblStreet">Street</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildStreet" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblCity" runat="server" meta:resourcekey="lblCity">City</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildCity" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblState" runat="server" meta:resourcekey="lblState">State</asp:Label>:
                                </td>
                                <td>
                                    <%--<uc1:MustInputTextBox ID="txtChildState" runat="server" Width="300px" />--%>
                                    <asp:DropDownList ID="ddlChildState" runat="server">
                                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="ddlChildState" Display="Dynamic" ErrorMessage="Please select city."
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblCountry" runat="server" meta:resourcekey="lblCountry">Country</asp:Label>:
                                </td>
                                <td>
                                    <%--<uc1:MustInputTextBox ID="txtChildCountry" runat="server" Width="300px" />--%>
                                    <asp:DropDownList ID="ddlChildCountry" runat="server" Width="180px" AutoPostBack="True">
                                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="ddlChildCountry" Display="Dynamic" ErrorMessage="Please select country or area."
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildEmail" runat="server" Width="300px" />
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <span class="t01">*</span><asp:Label ID="lblZipCode" runat="server" meta:resourcekey="lblZipCode">ZipCode</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildZipCode" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                        </div>
                    </table>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>