<%@ Page Language="C#" AutoEventWireup="true" Inherits="Join" Codebehind="Join.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="../css/style_new.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Header ID="Header1" runat="server" />
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="45" colspan="2" align="left" valign="bottom" class="D_title1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblJoin1">Creat a New Account</asp:Label>
                        </td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr>
                                <td align="center" valign="top">
                                    <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center" valign="top">
                                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="4">
                                                                        <img src="../images/index/b_top_l.gif" /></td>
                                                                    <td height="4" background="../images/index/b_top_m.gif">
                                                                        <img src="../images/index/b_top_m.gif" /></td>
                                                                    <td>
                                                                        <img src="../images/index/b_top_r.gif" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td background="../images/index/b_mid_l.gif">
                                                                        <img src="../images/index/b_mid_l.gif" /></td>
                                                                    <td>
                                                                        <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" class="T_table">
                                                                            <tr>
                                                                                <td style="vertical-align: top; text-align: left">
                                                                                    <span class="t01" style="text-align: left">*</span><asp:Label ID="Label2" runat="server" meta:resourcekey="lblJoin2"> = required field</asp:Label>
                                                                                    <table width="100%" border="0" cellpadding="3" cellspacing="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                                                                    <tr>
                                                                                                        <td colspan="2" class="head03" style="text-align: left">
                                                                                                            <img src="../images/index/arrow.gif" hspace="2" align="absmiddle" /><asp:Label ID="Label3" runat="server" meta:resourcekey="lblJoin3">Please Enter Your Member Information</asp:Label>
                                                                                                            
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="25%">
                                                                                                            <span class="t01">*</span><asp:Label ID="Label4" runat="server" meta:resourcekey="lblJoin4">Company Name:</asp:Label></td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:TextBox ID="txtComName" runat="server" Width="202px"></asp:TextBox>
                                                                                                            <asp:Label ID="lblComName" runat="server" Text="" Visible="False"></asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2" class="head03" style="vertical-align: middle; text-align: left">
                                                                                                            <img src="../images/index/arrow.gif" hspace="2" align="absmiddle" /><asp:Label ID="Label5" runat="server" meta:resourcekey="lblJoin5">Contact Person</asp:Label>
                                                                                                            
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="25%">
                                                                                                            <span class="t01">*</span><asp:Label ID="Label6" runat="server" meta:resourcekey="lblJoin6">E-mail:</asp:Label></td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:TextBox ID="txtCPEmail" runat="server" Width="202px"></asp:TextBox>&nbsp;<asp:Label ID="Label7" runat="server" meta:resourcekey="lblJoin7">e.g.: Name@WebsiteName.com</asp:Label> </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 28px">
                                                                                                            <span class="t01">*</span><asp:Label ID="Label8" runat="server" meta:resourcekey="lblJoin8">Password:</asp:Label></td>
                                                                                                        <td style="vertical-align: middle; text-align: left; height: 28px;">
                                                                                                            <asp:TextBox ID="txtPwd" runat="server" Width="202px" TextMode="Password"></asp:TextBox>&nbsp;
                                                                                                            <asp:Label ID="Label9" runat="server" meta:resourcekey="lblJoin9">(6-30 characters)</asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 29px">
                                                                                                            <span class="t01">*</span><asp:Label ID="Label10" runat="server" meta:resourcekey="lblJoin10">Type Password again:</asp:Label>
                                                                                                        </td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:TextBox ID="txtPwdAgain" runat="server" Width="202px" TextMode="Password"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <span class="t01">*</span><asp:Label ID="Label11" runat="server" meta:resourcekey="lblJoin111">First Name:</asp:Label></td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:TextBox ID="txtCPFirstName" runat="server" Width="202px"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td><asp:Label ID="Label12" runat="server" meta:resourcekey="lblJoin12">Middle Name:</asp:Label>
                                                                                                            </td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:TextBox ID="txtCPMiddleName" runat="server" Width="202px"></asp:TextBox>&nbsp;<asp:Label ID="Label21" runat="server" meta:resourcekey="lblJoin13">(optional)</asp:Label>
                                                                                                            </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <span class="t01">*</span><asp:Label ID="Label13" runat="server" meta:resourcekey="lblJoin14">Last Name:</asp:Label></td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:TextBox ID="txtCPLastName" runat="server" Width="202px"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <span class="t01">*</span><asp:Label ID="Label14" runat="server" meta:resourcekey="lblJoin15">Telphone:</asp:Label></td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:TextBox ID="txtCPTel" runat="server" Width="202px"></asp:TextBox>&nbsp;<asp:Label ID="Label22" runat="server" meta:resourcekey="lblJoin16"> e.g.: 000-0000-0000</asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 34px"><asp:Label ID="Label15" runat="server" meta:resourcekey="lblJoin17">Fax:</asp:Label>
                                                                                                            </td>
                                                                                                        <td style="vertical-align: middle; text-align: left; height: 34px;">
                                                                                                            <asp:TextBox ID="txtCPFax" runat="server" Width="202px"></asp:TextBox>&nbsp;<asp:Label ID="Label16" runat="server" meta:resourcekey="lblJoin18"> e.g.: 000-0000-0000 (optional)</asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 29px">
                                                                                                            <span class="t01">*</span><asp:Label ID="Label17" runat="server" meta:resourcekey="lblJoin19">Address:</asp:Label></td>
                                                                                                        <td style="vertical-align: middle; text-align: left; height: 29px;">
                                                                                                            <asp:TextBox ID="txtCPAddress" runat="server" Width="202px"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <span class="t01">*</span><asp:Label ID="Label18" runat="server" meta:resourcekey="lblJoin20">City:</asp:Label></td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:TextBox ID="txtCPCity" runat="server" Width="202px"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <span class="t01">*</span><asp:Label ID="Label19" runat="server" meta:resourcekey="lblJoin21">State:</asp:Label></td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:DropDownList ID="dllCPState" runat="server" Width="208px">
                                                                                                            </asp:DropDownList>-<asp:DropDownList ID="dllCPCountry" runat="server" OnSelectedIndexChanged="dllCPCountry_SelectedIndexChanged"
                                                                                                                Width="146px" AutoPostBack="True">
                                                                                                            </asp:DropDownList></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <span class="t01">*</span><asp:Label ID="Label20" runat="server" meta:resourcekey="lblJoin22">Zip/Postal Code:</asp:Label>
                                                                                                        </td>
                                                                                                        <td style="vertical-align: middle; text-align: left">
                                                                                                            <asp:TextBox ID="txtCPZip" runat="server" Width="202px"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <div class="btn">
                                                                                        <asp:Button ID="btnCreat" runat="server" Text="Create" CssClass="search_btn" OnClick="btnCreat_Click" meta:resourcekey="lblJoin23"/>
                                                                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                                                                                        <asp:TextBox ID="TextBox1" runat="server" Width="556px"></asp:TextBox></div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td width="4" background="../images/index/b_mid_r.gif" style="height: 621px">
                                                                        <img src="../images/index/b_mid_r.gif" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="4" height="4">
                                                                        <img src="../images/index/b_bot_l.gif" /></td>
                                                                    <td height="4" background="../images/index/b_bot_m.gif">
                                                                        <img src="../images/index/b_bot_m.gif" /></td>
                                                                    <td width="4">
                                                                        <img src="../images/index/b_bot_r.gif" /></td>
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
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>
