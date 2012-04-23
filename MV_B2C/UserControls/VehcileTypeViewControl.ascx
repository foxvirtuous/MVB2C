<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VehcileTypeViewControl.ascx.cs"
    Inherits="VehcileTypeViewControl" %>

<script type="text/javascript">
      var flag=1;
      function check()
      {
          if(flag == 0)
          {
              document.getElementById("VehcileTypeViewControl1_imgdown").src="../../images/v2/arrow_down.gif";
              document.getElementById("divType").style.display = "";
              document.getElementById("divSelect").style.display = "";
              document.getElementById("divSpace").style.display = "";
              flag='1';
          }
          else
          {
              document.getElementById("VehcileTypeViewControl1_imgdown").src="../../images/v2/arrow_right.gif";
              document.getElementById("divType").style.display = "none";
              document.getElementById("divSelect").style.display = "none";
              document.getElementById("divSpace").style.display = "none";
              flag='0';
          }   
          
          ChangeCarType();       
      }
      
      function SearchTypeOnly(a)
      {
          var elems =  document.getElementById("VehcileTypeViewControl1_repCarType");           
          var chkArr = elems.getElementsByTagName("input");    
          
          for(i=0;i<chkArr.length;i++)
          {
            if (chkArr[i].type == "checkbox"){
            if (chkArr[i].id == "VehcileTypeViewControl1_repCarType_ctl0" + a + "_cbCarType")
            {
                chkArr[i].checked="checked";
            }
            else
            {
                chkArr[i].checked="";
            }}
          }
          
          ChangeCarType();
      }
      
      function SearchTypeAll()
      {
          var elems =  document.getElementById("VehcileTypeViewControl1_repCarType");           
          var chkArr = elems.getElementsByTagName("input");    
          
          for(i=0;i<chkArr.length;i++)
          {
            if (chkArr[i].type == "checkbox"){
                chkArr[i].checked="checked";}
          }
          
          ChangeCarType();
      }
      function SearchTypeNone()
      {
          var elems =  document.getElementById("VehcileTypeViewControl1_repCarType");           
          var chkArr = elems.getElementsByTagName("input");    
          
          for(i=0;i<chkArr.length;i++)
          {
            if (chkArr[i].type == "checkbox"){
                chkArr[i].checked="";}
          }
          
          ChangeCarType();
      }
</script>

<div id="Div1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" border="0">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="1" width="100%" class="T_step0l">
                    <tr align="center" class="R_step06" onclick="check()">
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="cursor: pointer">
                                <tr>
                                    <td height="25px" align=center>
                                        <asp:Label ID="lblChangeYourSearch" runat="Server" meta:resourcekey="lblChangeYourSearch">Narrow Results</asp:Label></td>
                                    <td width="20" align="right">
                                        <asp:Image ID="imgdown" runat="server" ImageUrl="~/images/v2/arrow_down.gif" border="0" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="R_stepbox">
                        <td colspan="2">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" id="divSpace">
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                            </table>
                            <table align="center" border="0" cellpadding="3" cellspacing="0" id="divSelect" width="95%">
                                <tr>
                                    <td colspan="2" align="left">
                                        select :&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbtnAll" runat="server" OnClick="lbtnAll_Click">all</asp:LinkButton></td>
                                </tr>
                            </table>
                            <table align="center" border="0" cellpadding="3" cellspacing="0" width="100%" id="divType" >
                                <tr>
                                    <td align="left">
                                        <asp:DataList ID="repCarType" runat="server" Width=100% OnItemCommand="repCarType_ItemCommand" >
                                            <HeaderTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="left" valign=middle>
                                                        <asp:CheckBox ID="cbCarType" runat="server" AutoPostBack=true CommandName="SELECT" OnCheckedChanged="cbCarType_CheckedChanged" /><asp:Label ID="lblCarType"
                                                            runat="server" Text="" Visible="false"></asp:Label>&nbsp;<asp:LinkButton ID="lbtnCarType" CommandName="SELECT1" runat="server" >only</asp:LinkButton></td>
                                                    <td align="right">
                                                        $<asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:DataList>
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
