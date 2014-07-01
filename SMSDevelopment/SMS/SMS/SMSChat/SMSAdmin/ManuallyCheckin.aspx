<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="ManuallyCheckin.aspx.cs" Inherits="SMS.SMSAdmin.ManuallyCheckin" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
     <div class="divHeader"><span class="pageTitle">Manually Checkin</span></div>
     <table id="tblMain" width="100%">
            <tr>
                <td>
                         <div id="divAdvSearch" runat="server" visible="true">
                            <table>
                            <tr>
                                    <td>
                                        <asp:Panel ID="pnlAddNewKeySearch" runat="server">
                                            <table>    
                            <tr>
                                                <td>
                                                    <asp:Label ID="lblnricno" Text="NRIC No" CssClass="Labels" runat="server"></asp:Label>                    
                                                </td>  
                                                <td>
                                                <asp:TextBox ID="txtnricno" runat="server" CssClass="Input"/>
                                                </td>  
                            
                            </tr>
                            
                            
                             <tr>
                             </tr>
                             <tr>
                             <td>
                             <asp:Button ID="btnCheckin" Text="Checkin" runat="server" CssClass="Buttons" 
                                                           />&nbsp;</td>
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


</asp:Content>
