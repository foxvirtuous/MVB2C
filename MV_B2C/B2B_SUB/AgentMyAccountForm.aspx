<%@ Page Language="C#" AutoEventWireup="true" Inherits="AgentMyAccountForm" Codebehind="AgentMyAccountForm.aspx.cs" %>

<%@ Register Src="../UserControls/AgentLeftMenu.ascx" TagName="AgentLeftMenu" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="45" colspan="2" align="left" valign="bottom" class="D_title"><asp:Label ID="lblInfo" runat="server" meta:resourcekey="lblInfo" ></asp:Label>
                    &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" meta:resourcekey="lblAgentMyAccountForm1" >Membership: My Account Info</asp:Label></td>
            </tr>
            <tr>
            <td  width="20%" align="center" valign="top"><uc3:AgentLeftMenu ID="AgentLeftMenu1" runat="server" />
            </td>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
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
                                                                    <span class="head01"><asp:Label ID="Label2" runat="server" meta:resourcekey="lblAgentMyAccountForm2" >Member Information</asp:Label></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="0" colspan="2" background="../images/index/dot01.gif">
                                                                    <img src="../images/index/dot01.gif"></td>
                                                            </tr>
                                                            <tr>
                                                                <td width="22%">
                                                                    <span class="redlab">*</span><asp:Label ID="Label3" runat="server" meta:resourcekey="lblAgentMyAccountForm3" >Gender:</asp:Label></td>
                                                                <td width="78%">
                                                                    <asp:Label ID="lblGender" runat="server">Mr</asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label4" runat="server" meta:resourcekey="lblAgentMyAccountForm4" >First Name:</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td><asp:Label ID="Label5" runat="server" meta:resourcekey="lblAgentMyAccountForm5" >Middle Name:</asp:Label>
                                                                    
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblMiddleName" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label6" runat="server" meta:resourcekey="lblAgentMyAccountForm6" >Last Name:</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblLastName" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label7" runat="server" meta:resourcekey="lblAgentMyAccountForm7" >Phone Number (daytime):</asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblDayPhoneNumber" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label8" runat="server" meta:resourcekey="lblAgentMyAccountForm8" >Street Address:</asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblStreetAddress" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label9" runat="server" meta:resourcekey="lblAgentMyAccountForm9" >City:</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label10" runat="server" meta:resourcekey="lblAgentMyAccountForm10" >Country or Area</asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblStateCountry" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label11" runat="server" meta:resourcekey="lblAgentMyAccountForm11" >Zip/Postal Code:</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblZip" runat="server"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:LinkButton ID="lbnUpdate" runat="server" CssClass="d06" Text="" OnClick="lbnUpdate_Click" meta:resourcekey="lblAgentMyAccountForm12"></asp:LinkButton>
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
