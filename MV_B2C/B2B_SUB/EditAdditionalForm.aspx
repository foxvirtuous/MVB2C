<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="EditAdditionalForm" Codebehind="EditAdditionalForm.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 24px">
                        <asp:Button ID="btnAddNew" runat="server" Text="InsertNew" OnClick="btnAddNew_Click" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" Visible="False" OnClick="btnSave_Click" />
                        Market: &nbsp;
                        <asp:DropDownList ID="dllMarketList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dllMarketList_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Product Type: &nbsp;<asp:DropDownList
                            ID="dllProductTypeList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dllProductTypeList_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" /></td>
                </tr>
                <tr>
                    <td>
                        <div id="divAddNew" runat="server">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Destination:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFlyerName" runat="server"></asp:TextBox></td>
                                    <td>
                                        Market:
                                    <td>
                                        <asp:DropDownList ID="dllMarket" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtNewRegion" runat="server" Visible="False"></asp:TextBox>
                                        <asp:Button ID="btnAddMarket" runat="server" Text="AddNew" OnClick="btnAddMarket_Click" /></td>
                                    <td>
                                        Product Type:</td>
                                    <td>
                                        <asp:DropDownList ID="dllProductType" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtNewType" runat="server" Visible="False"></asp:TextBox>
                                        <asp:Button ID="btnAddProductType" runat="server" Text="AddNew" OnClick="btnAddProductType_Click" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Validity From</td>
                                    <td>
                                        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox></td>
                                    <td>
                                        Validity To</td>
                                    <td>
                                        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox></td>
                                    <td>
                                        FlyerImgurl</td>
                                    <td>
                                        <asp:TextBox ID="txtImgUrl" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        FlyerAirline</td>
                                    <td>
                                        <asp:TextBox ID="txtAirline" runat="server"></asp:TextBox></td>
                                    <td>
                                        FlyerAirClass</td>
                                    <td>
                                        <asp:TextBox ID="txtAirClass" runat="server"></asp:TextBox></td>
                                    <td>
                                        FlyerURL</td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gridFlyer" runat="server" AutoGenerateColumns="False" OnRowDeleted="gridFlyer_RowDeleted" OnRowDeleting="gridFlyer_RowDeleting" OnSelectedIndexChanged="gridFlyer_SelectedIndexChanged" DataKeyNames="FlyerID">
                            <Columns>
                                <asp:BoundField DataField="FlyerID" HeaderText="ID" Visible="false" />
                                <asp:BoundField HeaderText="Destination" DataField="FlyerName" />
                                <asp:BoundField HeaderText="Market" DataField="FlyerType" />
                                <asp:BoundField HeaderText="Product Type" DataField="FlyerRegion" />
                                <asp:BoundField HeaderText="Validity From" DataField="FlyerFromDate" DataFormatString="{0:MM/dd/yyyy}" />
                                <asp:BoundField HeaderText="Validity To" DataField="FlyerToDate" DataFormatString="{0:MM/dd/yyyy}" />
                                <asp:BoundField HeaderText="FlyerImgUrl" DataField="FlyerImgurl" />
                                <asp:BoundField HeaderText="Airline" DataField="FlyerAirline" />
                                <asp:BoundField HeaderText="AirClass" DataField="FlyerAirClass" />
                                <asp:BoundField HeaderText="URL" DataField="FlyerURL" />
                                <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
