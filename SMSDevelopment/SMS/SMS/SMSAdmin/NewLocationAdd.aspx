<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="NewLocationAdd.aspx.cs" Inherits="SMS.SMSAdmin.NewLocationAdd" Title="TSP Secure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Location</span></div>
        <table id="tblMain" width="100%">
            <tr>
                <td>
                    <div id="divAdvSearch" runat="server" visible="true">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlNewAddLocation" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterLocation" Text="Location Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddLocationName" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Button ID="btnLocationAdd" Text="Enter" runat="server" 
                                                        CssClass="Buttons" onclick="Add_AdminLocation"  />
                                                  &nbsp;  <asp:Button ID="btnClearLocationAdd" Text="Cancel" runat="server" 
                                                        CssClass="Buttons" onclick="btnClearLocationAdd_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
