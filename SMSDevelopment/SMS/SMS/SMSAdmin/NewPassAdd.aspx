<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="NewPassAdd.aspx.cs" Inherits="SMS.SMSAdmin.NewPassAdd" Title="TSP Secure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Pass</span></div>
        <table id="tblMain" width="100%">
            <tr>
                <td>
                    <div id="divAdvSearch" runat="server" visible="true">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlNewAddPass" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterPass" Text="Pass Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddPassType" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterPassNumber" Text="Pass Number" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEnterPassNumber" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblpassDescription" Text="Pass Descrption" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPassDecription" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Button ID="btnSearchPassAdd" Text="Enter" runat="server" 
                                                        CssClass="Buttons" onclick="Add_Pass" />
                                                 &nbsp;   <asp:Button ID="btnClearPassAdd" Text="Cancel" runat="server" 
                                                        CssClass="Buttons" onclick="btnClearPassAdd_Click" />
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
