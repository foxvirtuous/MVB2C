<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="PackageTravelerInsurance" Codebehind="PackageTravelerInsurance.aspx.cs" %>

<%@ Register Src="~/UserControls/InsuranceControl.ascx" TagName="TravelerInfoOfInsurance"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/PackageLeftSelect.ascx" TagName="PackageLeftSelect"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/Header.ascx" TagName="Header"
    TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/footer.ascx" TagName="footer"
    TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel package,Cheap Tours,Cheap Cruises</title>
    <link href='~/css/style2.css' rel="stylesheet" type="text/css" />
    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
</head>
<body><input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc4:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div id="content">
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc6:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <h1>
                        Complement the Information of Insurance
                    </h1>
                    You choosed &quot;buy insurance for this trip&quot;, and now we need more information
                    of travelers.
                    <div>
                        <h3>
                            Enter More Traveler Information
                        </h3>
                        <uc3:TravelerInfoOfInsurance ID="TravelerInfoOfInsurance1" runat="server"></uc3:TravelerInfoOfInsurance>
                    </div>
                    <div class="btn">
                        Please confirm all of the information is correct, then click
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/v1/btn_submit.gif"
                            DescriptionUrl="~/images/v1/btn_submit.gif" Width="143" Height="33" BorderStyle="None" OnClick="btnSubmit_Click1" />
                    </div>
                </div>
            </div>
            <p class="clear">
            </p>
        </div>
        <uc5:Footer ID="Footer1" runat="server" />
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
