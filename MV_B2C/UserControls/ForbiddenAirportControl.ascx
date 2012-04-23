<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ForbiddenAirportControl.ascx.cs"
    Inherits="ForbiddenAirportControl" %>
<asp:Panel ID="pnlComfirm" runat="server" class="tips_ConfirmAvailalbeContinue" Style="display: none;">
    <div class="message1">
        <asp:Label ID="lblCurrentMsg" runat="server" Text="Origin/Destination can not be booked online, please call our sales agent for booking."></asp:Label>&nbsp;
        <div class="message_btn">
            <input type="button" id="LinkButton2" onclick="hiddenPnlComfirm();$('maskDIVSearch').style.display='none'; return false;"
                class="search_btn" style="width: 70px; cursor: pointer" value="Close" />
        </div>
    </div>
    <div>
        &nbsp; &nbsp;&nbsp;</div>
</asp:Panel>

<script type="text/javascript">
                                     
                                       function hiddenPnlComfirm(event){
                                       
                                       document.getElementById(pnlComfirmClientID).style.display='none';
                                       if(ddl0!="")
                                            document.getElementById(ddl0).style.visibility="visible";
                                       if(ddl1!="")
                                       document.getElementById(ddl1).style.visibility="visible";
                                       
                                       }
                                      function positionUpdatePanelForSearch(event){
         

     document.getElementById("maskDIVSearch").style.height = document.body.clientHeight + "px";
     document.getElementById("maskDIVSearch").style.width = document.body.clientWidth + "px";
    document.getElementById("maskDIVSearch").style.display = "block";

}
</script>

<ajaxToolkit:AlwaysVisibleControlExtender ID="avceComfirm" runat="server" TargetControlID="pnlComfirm"
    VerticalSide="Middle" VerticalOffset="0" HorizontalSide="Center" HorizontalOffset="100"
    ScrollEffectDuration=".1" />
<div id="maskDIVSearch" style="width: 100%; height: 100%; position: absolute; left: 0px;
    top: 0px; display: none; border: 1px solid #ccc; z-index: 1000; background: #fff;
    filter: alpha(opacity=10); -moz-opacity: 0.1;">
</div>
