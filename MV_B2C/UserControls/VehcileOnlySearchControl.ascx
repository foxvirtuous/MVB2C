<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VehcileOnlySearchControl.ascx.cs"
    Inherits="VehcileOnlySearchControl" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="TermsCalender" TagPrefix="TermsCalender" %>

<script type="text/javascript">
        var flagSearch=0;
      function checkSearch()
      {
          if(flagSearch == 0)
          {
              document.getElementById("VehcileOnlySearchControl1_imgdown").src="../../images/v2/arrow_down.gif";
              document.getElementById("divSearch").style.display = "";
              flagSearch='1';
          }
          else
          {
              document.getElementById("VehcileOnlySearchControl1_imgdown").src="../../images/v2/arrow_right.gif";
              document.getElementById("divSearch").style.display = "none";
              flagSearch='0';
          }     
          
          ChangeCarType();     
      }
      
      function ChangeCarType()
        {
            var flightType = document.forms[0].elements['VehcileOnlySearchControl1_rbS'];	
            if( flightType.checked )
            {
	            document.getElementById("VehcileOnlySearchControl1_trDrop1").style.display  = "none";
	            document.getElementById("VehcileOnlySearchControl1_trDrop2").style.display  = "none";
        	    
	            var txtCarFromFullName = document.forms[0].elements['VehcileOnlySearchControl1_txtCarFromFullName'];
	            document.getElementsByTagName("*").VehcileOnlySearchControl1_txtCarToFullName.value = txtCarFromFullName.value;	
            }
            else 
            {
	            document.getElementById("VehcileOnlySearchControl1_trDrop1").style.display  = "";
	            document.getElementById("VehcileOnlySearchControl1_trDrop2").style.display  = "";
            }
        }
</script>

<div id="Div1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" border="0">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="1" width="100%" class="T_step0l">
                    <tr align="center" class="R_step06" onclick="checkSearch()">
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="cursor: pointer">
                                <tr>
                                    <td height="25px" align=center>
                                        <asp:Label ID="lblChangeYourSearch" runat="Server" meta:resourcekey="lblChangeYourSearch">Change Your Search</asp:Label></td>
                                    <td width="20" align="right">
                                        <asp:Image ID="imgdown" runat="server" ImageUrl="~/images/v2/arrow_right.gif" border="0" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="R_stepbox" id="divSearch" style="display: none">
                        <td>
                            <table align="center" border="0" cellpadding="3" cellspacing="0" width="95%">
                                <tr>
                                    <td align="left" class="D_stepb">
                                        <asp:Label ID="Label2" runat="Server">Drop Off:</asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:RadioButton ID="rbS" runat="server" GroupName="CarSelectType" Text=""
                                            onclick="ChangeCarType()" />&nbsp;<asp:Label ID="Label4" runat="server" Text="Same Location"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:RadioButton ID="rbD" runat="server" GroupName="CarSelectType" Text=""
                                            onclick="ChangeCarType()" />&nbsp;<asp:Label ID="Label3" runat="server" Text="Different Location"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="D_stepb">
                                        <asp:Label ID="lblCountry" runat="Server">Pick Up Airport:</asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:TextBox ID="txtCarFromFullName" runat="server" autocomplete="off" onfocus="if(document.getElementById('FocusIndex')!=null){document.getElementById('FocusIndex').value='R';}">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtFromName" runat="server" Visible="false">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="trDrop1" style="display: none" runat=server>
                                    <td align="left" class="D_stepb">
                                        <asp:Label ID="Label1" runat="Server">Drop Off Airport:</asp:Label></td>
                                </tr>
                                <tr id="trDrop2" style="display: none" runat=server>
                                    <td align="left" style="height: 30px">
                                        <asp:TextBox ID="txtCarToFullName" runat="server" autocomplete="off" onfocus="if(document.getElementById('FocusIndex')!=null){document.getElementById('FocusIndex').value='R';}">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtToName" runat="server" Visible="false">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="D_stepb">
                                        <asp:Label ID="lblPickup" runat="Server">Pick Up:</asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <TermsCalender:TermsCalender ID="txtPickupDate" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlPickupTime" runat="server">
                                            <asp:ListItem Value="0030A">12:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0100A">01:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0130A">01:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0200A">02:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0230A">02:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0300A">03:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0330A">03:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0400A">04:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0430A">04:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0500A">05:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0530A">05:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0600A">06:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0630A">06:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0700A">07:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0730A">07:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0800A">08:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0830A">08:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0900A">09:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0930A">09:30 AM</asp:ListItem>
                                            <asp:ListItem Value="1000A">10:00 AM</asp:ListItem>
                                            <asp:ListItem Value="1030A">10:30 AM</asp:ListItem>
                                            <asp:ListItem Value="1100A">11:00 AM</asp:ListItem>
                                            <asp:ListItem Value="1130A">11:30 AM</asp:ListItem>
                                            <asp:ListItem Value="1200A" Selected=True>12 Noon</asp:ListItem>
                                            <asp:ListItem Value="0030P">12:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0100P">01:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0130P">01:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0200P">02:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0230P">02:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0300P">03:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0330P">03:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0400P">04:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0430P">04:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0500P">05:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0530P">05:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0600P">06:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0630P">06:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0700P">07:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0730P">07:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0800P">08:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0830P">08:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0900P">09:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0930P">09:30 PM</asp:ListItem>
                                            <asp:ListItem Value="1000P">10:00 PM</asp:ListItem>
                                            <asp:ListItem Value="1030P">10:30 PM</asp:ListItem>
                                            <asp:ListItem Value="1100P">11:00 PM</asp:ListItem>
                                            <asp:ListItem Value="1130P">11:30 PM</asp:ListItem>
                                            <asp:ListItem Value="1200P">12 Midnt</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:DropDownList ID="ddlPickupTimeType" runat="server">
                                            <asp:ListItem Value="A">AM</asp:ListItem>
                                            <asp:ListItem Value="P" Selected=True>PM</asp:ListItem>
                                        </asp:DropDownList>--%>
                                        
                                        </td>
                                </tr>
                                <tr>
                                    <td align="left" class="D_stepb">
                                        <asp:Label ID="lblCheckout" runat="Server">Drop Off:</asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <TermsCalender:TermsCalender ID="txtDropoffDate" runat="server" LowerLimitID="txtPickupDate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 28px">
                                        <asp:DropDownList ID="ddlDropoffTime" runat="server">
                                            <asp:ListItem Value="0030A">12:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0100A">01:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0130A">01:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0200A">02:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0230A">02:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0300A">03:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0330A">03:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0400A">04:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0430A">04:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0500A">05:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0530A">05:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0600A">06:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0630A">06:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0700A">07:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0730A">07:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0800A">08:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0830A">08:30 AM</asp:ListItem>
                                            <asp:ListItem Value="0900A">09:00 AM</asp:ListItem>
                                            <asp:ListItem Value="0930A">09:30 AM</asp:ListItem>
                                            <asp:ListItem Value="1000A">10:00 AM</asp:ListItem>
                                            <asp:ListItem Value="1030A">10:30 AM</asp:ListItem>
                                            <asp:ListItem Value="1100A">11:00 AM</asp:ListItem>
                                            <asp:ListItem Value="1130A">11:30 AM</asp:ListItem>
                                            <asp:ListItem Value="1200A" Selected=True>12 Noon</asp:ListItem>
                                            <asp:ListItem Value="0030P">12:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0100P">01:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0130P">01:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0200P">02:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0230P">02:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0300P">03:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0330P">03:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0400P">04:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0430P">04:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0500P">05:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0530P">05:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0600P">06:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0630P">06:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0700P">07:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0730P">07:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0800P">08:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0830P">08:30 PM</asp:ListItem>
                                            <asp:ListItem Value="0900P">09:00 PM</asp:ListItem>
                                            <asp:ListItem Value="0930P">09:30 PM</asp:ListItem>
                                            <asp:ListItem Value="1000P">10:00 PM</asp:ListItem>
                                            <asp:ListItem Value="1030P">10:30 PM</asp:ListItem>
                                            <asp:ListItem Value="1100P">11:00 PM</asp:ListItem>
                                            <asp:ListItem Value="1130P">11:30 PM</asp:ListItem>
                                            <asp:ListItem Value="1200P">12 Midnt</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:DropDownList ID="ddlDropoffTimeType" runat="server">
                                            <asp:ListItem Value="A">AM</asp:ListItem>
                                            <asp:ListItem Value="P" Selected=True>PM</asp:ListItem>
                                        </asp:DropDownList>--%></td>
                                </tr>
                                <tr>
                                    <td align="left" class="D_stepb">
                                        <asp:Label ID="lblCarType" runat="Server">Car Type:</asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlCarType" runat="server">
                                            <asp:ListItem Value="0" Selected="True">No Preference</asp:ListItem>
                                            <asp:ListItem Value="3">Economy</asp:ListItem>
                                            <asp:ListItem Value="4">Compact</asp:ListItem>
                                            <asp:ListItem Value="5">Midsize</asp:ListItem>
                                            <asp:ListItem Value="7">Standard</asp:ListItem>
                                            <asp:ListItem Value="8">Full Size</asp:ListItem>
                                            <asp:ListItem Value="10">Premium</asp:ListItem>
                                            <asp:ListItem Value="9">Luxury</asp:ListItem>
                                            <asp:ListItem Value="97">Convertible</asp:ListItem>
                                            <asp:ListItem Value="98">Minivan</asp:ListItem>
                                            <asp:ListItem Value="99">SUV</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                <tr valign="top">
                                    <td colspan="2" align="center">
                                        <asp:Button ID="imgbSearch" runat="server" Text="Search" OnClick="imgbSearch_Click"
                                            CssClass="search_btn01" Style="cursor: pointer" meta:resourcekey="imgbSearch" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TdWidth">
            </td>
        </tr>
    </table>
</div>
