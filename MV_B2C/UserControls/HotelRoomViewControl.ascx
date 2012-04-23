<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="HotelRoomViewControl" Codebehind="HotelRoomViewControl.ascx.cs" %>
<div>
    <!-- Button used to launch the animation -->
    <img src="../../images/btn_01.gif" width="20" height="18" align="absmiddle" />
    <asp:LinkButton ID="ImageButton1" runat="server" OnClientClick="return false;">Room Details </asp:LinkButton>
    <!-- "Wire frame" div used to transition from the button to the info panel -->
    <div id="flyout" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF;
        border: solid 1px #D0D0D0;">
    </div>
    <!-- Info panel to be displayed as a flyout when the button is clicked -->
    <div id="info" style="display: none; width: 290px; z-index: 2; opacity: 0; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0);
        font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
        <div id="btnCloseParent" style="float: right; opacity: 0; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0);">
            <asp:LinkButton ID="btnClose" runat="server" OnClientClick="return false;" Text="X"
                ToolTip="Close" Style="background-color: #666666; color: #FFFFFF; text-align: center;
                font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 2px;" />
        </div>
        <div class="RoomDetail">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="2" class="DeptRet">
                        Room #1: Standard Double Room | Guest: 1 Adult
                    </td>
                </tr>
                <tr>
                    <td style="width: 151px; height: 38px;">
                        Room Rate: 12/31 - 01/03
                    </td>
                    <td width="46%" style="height: 38px">
                        $85.00 per night
                    </td>
                </tr>
                <tr>
                    <td style="width: 151px">
                        Room Rate: 01/04 - 01/07
                    </td>
                    <td>
                        $65.00 per night
                    </td>
                </tr>
                <tr>
                    <td style="width: 151px">
                        Taxes &amp; service fees:</td>
                    <td>
                        Included</td>
                </tr>
                <tr>
                    <td style="width: 151px">
                        Breakfast (2 persons):
                    </td>
                    <td>
                        Included</td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="2" class="DeptRet">
                        Room #2: Standard Double Room + 1 Extra Bed | Guest: 2 Adults 2 Children (Age: 13,
                        4)
                    </td>
                </tr>
                <tr>
                    <td width="53%">
                        Room Rate: 12/31 - 01/03
                    </td>
                    <td width="47%">
                        $85.00 per night
                    </td>
                </tr>
                <tr>
                    <td>
                        Room Rate: 01/04 - 01/07
                    </td>
                    <td>
                        $65.00 per night
                    </td>
                </tr>
                <tr>
                    <td>
                        1 Extra Bed charge:
                    </td>
                    <td>
                        $30.00 per night
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px">
                        Taxes &amp; service fees:</td>
                    <td style="height: 23px">
                        Included</td>
                </tr>
                <tr>
                    <td>
                        Breakfast (2 persons):
                    </td>
                    <td>
                        Included</td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript" language="javascript">
            function Cover(bottom, top, ignoreSize) {
                var location = Sys.UI.DomElement.getLocation(bottom);
                top.style.position = 'absolute';
                top.style.top = location.y + 'px';
                top.style.left = location.x + 'px';
                if (!ignoreSize) {
                    top.style.height = bottom.offsetHeight + 'px';
                    top.style.width = bottom.offsetWidth + 'px';
                }
            }
    </script>

    <ajaxToolkit:AnimationExtender ID="OpenAnimation" runat="server" TargetControlID="ImageButton1">
        <Animations>
                <OnClick>
                    <Sequence>
                        <EnableAction Enabled="false" />
                        
                        <ScriptAction Script="Cover($get('ctl00_SampleContent_btnInfo'), $get('flyout'));" />
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="block"/>
                       
                        <Parallel AnimationTarget="flyout" Duration="0.0" Fps="50">
                            <Move Horizontal="150" Vertical="-50" />
                            <Resize Width="290" Height="280" />
                            <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                        </Parallel>
                       
                        <ScriptAction Script="Cover($get('flyout'), $get('info'), true);" />
                        <StyleAction AnimationTarget="info" Attribute="display" Value="block"/>
                        <FadeIn AnimationTarget="info" Duration="0.0"/>
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="none"/>
                      
                        <Parallel AnimationTarget="info" Duration="0.0">
                            <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                            <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                        </Parallel>
                        <Parallel AnimationTarget="info" Duration="0.0">
                            <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                            <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                            <FadeIn AnimationTarget="btnCloseParent" MaximumOpacity=".9" />
                        </Parallel>
                    </Sequence>
                </OnClick>
        </Animations>
    </ajaxToolkit:AnimationExtender>
    <ajaxToolkit:AnimationExtender ID="CloseAnimation" runat="server" TargetControlID="btnClose">
        <Animations>
                <OnClick>
                    <Sequence AnimationTarget="info">
                      
                        <StyleAction Attribute="overflow" Value="hidden"/>
                        <Parallel Duration=".0" Fps="50">
                            <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                            <FadeOut />
                        </Parallel>                        
                       
                        <StyleAction Attribute="display" Value="none"/>
                        <StyleAction Attribute="width" Value="290"/>
                        <StyleAction Attribute="height" Value=""/>
                        <StyleAction Attribute="fontSize" Value="12px"/>
                        <OpacityAction AnimationTarget="btnCloseParent" Opacity="0" />
                        
                        
                        <EnableAction AnimationTarget="ImageButton1" Enabled="true" />
                    </Sequence>
                </OnClick>              
        </Animations>
    </ajaxToolkit:AnimationExtender>
    <br />
</div>
