<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footerPackage.ascx.cs" Inherits="Terms.Web.UserControls.footerPackage" %>
<div class="footer_package IBE_T_font_11">
    <div class="footer_l">
        <img src="<%=SecureUrlSuffix + "images/index/ci_asta.gif"%>" /><img src="<%=SecureUrlSuffix + "images/index/ci_usta.gif"%>" /><img
            src="<%=SecureUrlSuffix + "images/index/ci_pata.gif"%>" /><img src="<%=SecureUrlSuffix + "images/ci_aig.gif"%>" /><a href="http://www.cruising.org/" target="_blank"><img style="border-width: 0px;" src="<%=SecureUrlSuffix + "images/ci_clia.gif"%>" /></a><a
                href="https://seal.godaddy.com/verifySeal?sealID=64642988007e1672e610120b2198ed947f2e9424593492114326438452"
                target="_blank"><img style="border-width: 0px;margin-top:7px;" src="<%=SecureUrlSuffix + "images/index/ci_secured.gif"%>" /></a>
    </div>
    <div class="footer_r">
        <ul>
            <li><a href="<%=SaleWebSuffix + HtmlPath + "aboutus.htm"%>" target="_top">
                <asp:Label ID="lblAbout" runat="server" meta:resourcekey="lblAboutUs">About Us</asp:Label></a></li>
            <li><a href="<%=SaleWebSuffix + HtmlPath + "contactus.htm"%>" target="_top">
                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblContactUs">Contact Us</asp:Label></a></li>
            <li><a href="<%=SaleWebSuffix + HtmlPath + "contactus.htm"%>" target="_top">
                <asp:Label ID="Label10" runat="server" meta:resourcekey="lblOfficeLocation">Office Location</asp:Label></a></li>
            <li><a href="<%=SaleWebSuffix + HtmlPath + "terms.htm"%>" target="_top">
                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblTermsConditions">Terms &amp; Conditions</asp:Label></a></li>
            <li><a href="<%=SaleWebSuffix + HtmlPath + "feedback.htm"%>" target="_top">
                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblFeedback">Feedback</asp:Label></a></li>
            <li><a href="<%=SaleWebSuffix + HtmlPath + "privacy.htm"%>" target="_top">
                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblPrivacyPolicy">Privacy Policy</asp:Label></a></li>
            <li><a href="<%=SaleWebSuffix + HtmlPath + "guide.htm"%>" target="_top">
                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblTravelGuide">Travel Guide</asp:Label></a></li>
            <li><a href="<%=SaleWebSuffix + HtmlPath + "sitemap.htm"%>" target="_top">
                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblSiteMap">Site Map</asp:Label></a></li>
            <li class="lastitem"><a href="http://www.travelguard.com/majestic-vacations" target="_top">
                <asp:Label ID="Label7" runat="server" meta:resourcekey="lblTravelInsurance">Travel Insurance</asp:Label></a></li>
        </ul>
    </div>
    <div class="footer_r" style="padding-top:0px;">
        <span class="copyright">
            <asp:Label ID="lblCopyright" runat="server" meta:resourcekey="lblCopyright">Copyright </asp:Label>
            &copy; 2003-2009
            <asp:Label ID="Label8" runat="server" meta:resourcekey="lblLogName">Majestic Vacations</asp:Label>,
            <asp:Label ID="Label9" runat="server" meta:resourcekey="lblInc">Inc All rights reserved</asp:Label></span></div>
</div>