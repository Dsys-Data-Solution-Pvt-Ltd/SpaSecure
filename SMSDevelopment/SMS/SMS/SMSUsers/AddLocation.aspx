<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="AddLocation.aspx.cs" Inherits="SMS.AddLocation" Title="TSP Secure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Location</span></div>
             <div>
                  
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
             </div>
             <br />
             <div id="divAdvSearch" runat="server" visible="true">
                        <table width="500px">
                                        <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterLocationCode" Text="Location Code" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddLocationName" runat="server" CssClass="Input" 
                                                        ReadOnly="True" />
                                                    <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                                     Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                </td>
                                                
                                           
                                                <td>
                                                    <asp:Label ID="lblEnterLocation" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddLocationName1" runat="server" CssClass="Input" />
                                                    <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" 
                                                     Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                    
                                                    
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                 <td height="40px" width="105px">
                                                   
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    
                                                   
                                             
                                                    <asp:Button ID="btnSearchLocationAdd" Text="Add" runat="server" 
                                                        CssClass="Buttons" onclick="Add_Location" Width="85px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearLocationAdd" Text="Cancel" runat="server" 
                                                        CssClass="Buttons" onclick="btnClearLocationAdd_Click" Width="85px" />
                                                  
                                                </td>
                                                
                                            </tr>
                                        </table>
                    </div>
        <br />      
    </div>
</asp:Content>
