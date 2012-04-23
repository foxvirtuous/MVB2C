<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="MemberMyAccountForm" Codebehind="MemberMyAccountForm.aspx.cs" %>

<%@ Register Src="~/UserControls/MemberLeftMenu.ascx" TagName="MemberLeftMenu"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="~/css/style_index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="45" colspan="2" align="left" valign="bottom" class="D_title">
                    &nbsp;&nbsp;<asp:Label ID="lblInfo" runat="server" meta:resourcekey="lblInfo" >Membership: My Account Info</asp:Label></td>
            </tr>
            <tr>
                <td>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" valign="top">
                                &nbsp;<uc3:MemberLeftMenu ID="MemberLeftMenu1" runat="server" />
                            </td>
                            <td width="80%" align="left" valign="top">
                                <table cellspacing="1" cellpadding="3" width="100%" border="0" class="T_table">
                                    <tr>
                                        <td width="70%" colspan="2">
                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="info">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="reg">
                                                            <tr>
                                                                <td colspan="2" class="name" style="height: 25px">
                                                                    <span class="head01"><asp:Label ID="Label1" runat="server" meta:resourcekey="lblMemberInfo" >Member Information</asp:Label></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="0" colspan="2" background="../../images/index/dot01.gif">
                                                                    <img src="../../images/index/dot01.gif"></td>
                                                            </tr>
                                                            <tr>
                                                                <td width="22%">
                                                                    <span class="redlab">*</span><asp:Label ID="Label2" runat="server" meta:resourcekey="lblGender" >Gender</asp:Label>:</td>
                                                                <td width="78%">
                                                                    <asp:Label ID="lblGender" runat="server">Mr</asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label3" runat="server" meta:resourcekey="lblFirstName" >First Name</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" meta:resourcekey="lblMiddleName" >Middle Name</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblMiddleName" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label5" runat="server" meta:resourcekey="lblLastName" >Last Name</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblLastName" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label6" runat="server" meta:resourcekey="lblPhoneDay" >Phone Number (daytime)</asp:Label>:</td>
                                                                <td>
                                                                    <asp:Label ID="lblDayPhoneNumber" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label7" runat="server" meta:resourcekey="lblPhoneNight" >Phone Number (nighttime)</asp:Label>:</td>
                                                                <td>
                                                                    <asp:Label ID="lblNightPhoneNumber" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label8" runat="server" meta:resourcekey="lblBirth" >Date of Birth</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblBirthday" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label9" runat="server" meta:resourcekey="lblPassportNumber" >Passport Number</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblPassportNumber" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label10" runat="server" meta:resourcekey="lblStreetAddress">Street Address</asp:Label>:</td>
                                                                <td>
                                                                    <asp:Label ID="lblStreetAddress" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label11" runat="server" meta:resourcekey="lblCity">City</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 19px">
                                                                    <span class="redlab">*</span><asp:Label ID="Label12" runat="server" meta:resourcekey="lblStateCountry">Country or Area</asp:Label>:</td>
                                                                <td style="height: 19px">
                                                                    <asp:Label ID="lblStateCountry" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label13" runat="server" meta:resourcekey="lblZip">Zip/Postal Code</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblZip" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                <asp:Label id="lblServer" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="reg">
                                                            <tr>
                                                                <td colspan="2" class="name">
                                                                    <span class="head01"><asp:Label ID="Label14" runat="server" meta:resourcekey="lblPreferences">Your Travel Preferences</asp:Label></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                                    <img src="../../images/index/dot01.gif" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:DataGrid ID="dgServer" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                                                        Width="100%" OnItemDataBound="dgServer_ItemDataBound">
                                                                        <HeaderStyle CssClass="newtt" />
                                                                        <Columns>
                                                                            <asp:BoundColumn DataField="Code" HeaderText="QuestionCode" Visible="False">
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="Name" HeaderText="QuestionName"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="IsRadio" HeaderText="SingleOrMultiterm" Visible="False">
                                                                            </asp:BoundColumn>
                                                                            <asp:TemplateColumn>
                                                                                <ItemTemplate>
                                                                                   <asp:Label ID="lblAnswer" runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                        </Columns>
                                                                    </asp:DataGrid></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lbnUpdate" runat="server" CssClass="d06" Text="Update your Account" OnClick="lbnUpdate_Click" meta:resourcekey="btnUpdate"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
