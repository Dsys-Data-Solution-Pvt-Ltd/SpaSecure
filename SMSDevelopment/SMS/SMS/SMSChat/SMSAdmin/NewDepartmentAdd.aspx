<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="NewDepartmentAdd.aspx.cs" Inherits="SMS.SMSAdmin.NewDepartmentAdd" Title="TSP Secure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Department</span></div>
        <table id="tblMain" width="100%">
            <tr>
                <td>
                    <div id="divAdvSearch" runat="server" visible="true">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlNewAddDepartment" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterDepartmentCode" Text="Department Code" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddDepartmentCode" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterDepartmentName" Text="Department Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEnterDepartmentName" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterDepartmentdescription" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEnterDepartmentDescription" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Button ID="btnSearchDepartmentAdd" Text="Enter" runat="server" CssClass="Buttons" />
                                                     &nbsp;<asp:Button ID="btnClearDepartmentAdd" Text="Cancel" runat="server" 
                                                        CssClass="Buttons" onclick="btnClearDepartmentAdd_Click" />
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
