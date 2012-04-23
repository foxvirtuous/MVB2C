<%@ Page Language="C#" MasterPageFile="BookingPage.Master" AutoEventWireup="true" Inherits="Error" Codebehind="Error.aspx.cs" %>

<%@ MasterType virtualPath="BookingPage.Master"%>
 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table width="98%" align="center" cellpadding="0" cellspacing="1" class="T_select">
        <tr align="left">
            <td>
                <strong>
                    &nbsp;<asp:Label ID="lblMessage" runat="server"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr class="R_content"  align="center">
            <td>
                <table width="100%" border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td height="51">
                            <font class="P_Blue"><asp:Label ID="LblErrorInfo" runat="server" Width="100%" Height="100%"></asp:Label></font>
                        </td>
                    </tr>
                    <!--<tr>
                        <td><a href="step1.aspx">back to search</a></td>
                    </tr>-->
                </table>
            </td>
        </tr>
    </table>
</asp:Content>