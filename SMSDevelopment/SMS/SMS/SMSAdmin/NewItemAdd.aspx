<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="NewItemAdd.aspx.cs" Inherits="SMS.SMSAdmin.NewItemAdd" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Item</span></div>
        <table id="tblMain" width="100%">
            <tr>
                <td>
                    <div id="divAdvSearch" runat="server" visible="true">
                        <table>
                            <tr>
                                <td>
                                    <asp:panel id="pnlAddNewItemSearch" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                <asp:Label ID="lblItem" Text=" Add Item" CssClass="Labels" runat="server" Font-Bold="true" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblItemNo" Text="Item No" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemNo" runat="server" CssClass="Input" />
                                                </td>
                                                
                                                <td>
                                                    <asp:Label ID="lblItemDes" Text="Item Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemName" runat="server" CssClass="Input" />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                     <asp:Label ID="lblItemLogged" Text="Item Logged By" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblItemname" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="Input" />
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                    <asp:TextBox ID="txtPosition" runat="server" CssClass="Input" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcname" Text="CompanyName" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtcname" runat="server" CssClass="Input" />
                                                 </td>
                                                <td>
                                                    <asp:Label ID="lblTime" Text="Time" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTime" runat="server" CssClass="Input" />
                                                 </td>
                                                
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblItemsignout" Text="Item Signed Out By" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblINo" Text="Item No" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNo" runat="server" CssClass="Input" />
                                                </td>
                            
                                            
                                           </tr>
                                           <tr>
                                                <td>
                                                    <asp:Label ID="lblLossfound" Text="Loss/Found Item" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>
                                                <td>
                                                    <asp:Label ID="lbladddescr" Text="Add Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtadddes" runat="server" CssClass="Input" />
                                                 </td>
                                                 <td>
                                                    <asp:Label ID="lblfoundby" Text="Found By" CssClass="Labels" runat="server"></asp:Label>
                                                 </td>
                                                <td>
                                                    <asp:TextBox ID="txtfoundby" runat="server" CssClass="Input" />
                                                </td>
                                            
                                            
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbloundby" Text="Found ON" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbldate" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtdate" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblime" Text="Time" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlime" runat="server" CssClass="Input" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Button ID="btnItemAdd" Text="Enter" runat="server" 
                                                        CssClass="Buttons" onclick="btnItemAdd_Click" />
                                                    &nbsp;<asp:Button ID="btnClearItemAdd" Text="Clear" runat="server" 
                                                        CssClass="Buttons" onclick="btnClearItemAdd_Click" 
                                                         />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
