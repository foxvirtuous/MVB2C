<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SearchMoreForm.aspx.cs"
    Inherits="SearchMoreForm" EnableEventValidation="false" %>

<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Please help us with a little more information</title>
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <div id="content">
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <table width="920" border="0" align="center" cellpadding="0" cellspacing="1">
                        <tr>
                            <td align="center">
                                <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="T_table">
                                    <tr>
                                        <td colspan="2" align="left">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="20">
                                                        <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                                            <tr>
                                                                <td align="center">
                                                                    ></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="5">
                                                    </td>
                                                    <td>
                                                        <span class="head06">
                                                            <asp:Label ID="lblPlease" runat="server" meta:resourcekey="lblPlease">Please help us with a little more information</asp:Label></span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <table width="80%" border="0" cellspacing="1" cellpadding="3" class="T_line02">
                                                <tr>
                                                    <td align="left" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="18" valign="top">
                                                                    <table border="0" cellpadding="0" cellspacing="0" class="T_line03">
                                                                        <tr>
                                                                            <td width="13" align="center">
                                                                                !</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <span class="t05">
                                                                        <asp:Panel ID="plCityName" runat="server">
                                                                            <asp:Label ID="lblwefound" runat="server" meta:resourcekey="lblwefound">We found more than one location matching</asp:Label>
                                                                            '<asp:Label ID="lblCityName" runat="server"></asp:Label>'.
                                                                            <asp:Label ID="lblselect" runat="server" meta:resourcekey="lblselect">Please select a location from the list</asp:Label>.
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="PLCiytName1" runat="server">
                                                                            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblwefound1">We could not find any city or airports that match your search for</asp:Label>
                                                                            '<asp:Label ID="lblCityName1" runat="server"></asp:Label>'.
                                                                            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblselect1">Please enter a new city code, city name, or airport code</asp:Label>.
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="PLCiytName2" runat="server">
                                                                            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblwefound2">Please enter at least 3 characters of the location name</asp:Label>.
                                                                        </asp:Panel>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rblCityName" runat="server">
                                            </asp:RadioButtonList>
                                            &nbsp; &nbsp; &nbsp;
                                            <uc1:MustInputTextBox ID="txtCityName" runat="server" Style="margin-left: 20px; display: inline;"
                                                CssClass="dropDownRes" Width="150px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:Button ID="btnSearch_h" CssClass="search_btn" Text="Search" runat="server" OnClick="btn_Search_h_Click"
                                                Style="cursor: pointer" meta:resourcekey="btnSearch_h" />
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td colspan="2" height="10">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <p class="clear">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
