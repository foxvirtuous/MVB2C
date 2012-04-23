<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="SearchTransportationControl" Codebehind="SearchTransportationControl.ascx.cs" %>

<script type="text/javascript"> 
    function CancelSelect(obj,tempSpan)
 {
     elems = obj.form.elements;  
     var strTemp = tempSpan;
     var ttt = tempSpan.substr(0,46);
    
     for(i=0;i<elems.length;i++)
     {
        if (elems[i].type=="radio" && elems[i].name.substr(0,46) == ttt)
        {
          if (elems[i].type=="radio" && elems[i].id != obj.id && obj.name.substr(0,63) == strTemp)
          {
            if (elems[i].checked)
            {
                elems[i].checked = false;
                
                elems[i].alt = '';
            }
          } 
          
          if (elems[i].type=="radio" && elems[i].id == obj.id && obj.name.substr(0,63) == strTemp)
          {
            if (elems[i].alt == '001' && elems[i].checked)
            {
                elems[i].checked = false;
                
                elems[i].alt = '';
            }
            else
            {
                elems[i].alt = '001';
            }            
          }          
        }
     }
 }   
</script>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <asp:DataList ID="dlTransfers" runat="server">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="T_step02">
                        <tr class="R_stepo">
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="1" cellpadding="0" class="T_step0l">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                                                            <tr class="R_step03" align="center">
                                                                <td height="30" align="left">
                                                                    &#12288;<asp:Label ID="lblFromTo" runat="server" Text=""></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="R_stepw">
                                                    <td>
                                                        <asp:DataList ID="dlTransfer" runat="server" Width="100%">
                                                            <ItemTemplate>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr><%--
                                                                        <td width="13%" align="center">
                                                                            <img src="../images/080327_hotel_01.jpg" vspace="10" /></td>--%>
                                                                        <td width="75%" align="left">
                                                                            <b>
                                                                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label></b><br />
                                                                            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label><br />
                                                                            <asp:Label ID="lblTime" runat="server" Text=""></asp:Label><br />
                                                                            <font class="t06">Total Price:
                                                                                <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></font><br /></td>
                                                                                <td width="5%" align="center">
                                                                                <asp:HyperLink ID="hpDetail" runat="server" Target=_blank>Detail</asp:HyperLink>
                                                                                </td>
                                                                        <td width="5%" align="center">
                                                                            <asp:RadioButton ID="rbnSelect" runat="server" Checked=false />
                                                                            <asp:Label ID="lblItemCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblVehiclesCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblMaxPassengers" runat="server" Text="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblMaxLuggage" runat="server" Text="" Visible="false"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList></td>
    </tr>
</table>
