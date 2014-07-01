<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="NewKeyAdd.aspx.cs" Inherits="SMS.SMSAdmin.NewKeyAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 53px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Key</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <div>
                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
            </div>
            <br />
            <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="880">
            <table width="800" class="table">
            <tr><td></td></tr>
               <tr>
                   <td>
                        <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels"></asp:DropDownList>
                            <asp:Label ID="SearchLocID" Text="" CssClass="Labels" runat="server" Visible="False"></asp:Label>                       
                    </td>
               </tr>
               <tr><td></td></tr>
                <tr>
                     <td>
                        <asp:Label ID="lblbunchNo" Text="Bunch No." CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbunchNo" runat="server" CssClass="Input"/>
                          <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                            ForeColor="Red"></asp:Label>
                    </td>               
                
                    <td>
                        <asp:Label ID="lblKeyNo" Text="No. of Key" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyNo" runat="server" CssClass="Input" />
                      
                    </td>
                   
                </tr>
                <tr><td></td></tr>
                <tr>
                    
                     
                <%--</tr>
                <tr>--%>
                      <td class="style1" valign="top">
                        <asp:Label ID="lblKeyDesc" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td colspan="4" class="style1">
                        <asp:TextBox ID="txtKeyDesc" runat="server" CssClass="Input" Width="636px" 
                            Height="50px" TextMode="MultiLine" />
                    </td>
                </tr>
                <tr><td></td></tr>
                <tr>
                     <td>
                        <asp:Label ID="lblKeyStatus" Text="Status" CssClass="Labels" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyStatus" runat="server" CssClass="Input" Visible="False">Free</asp:TextBox>
                    </td>                
                </tr>              
                <tr>
                    <td height="50px" colspan="1">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblKeySign" runat="server" CssClass="Labels" Text="Key Added By:"
                            Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                   <tr><td></td></tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblStaffid" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStaffiD" runat="server" CssClass="Input" 
                                                AutoPostBack="True" ontextchanged="txtStaffiD_TextChanged" />
                                            <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                                ForeColor="Red"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblKeyName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeyName" runat="server" CssClass="Input" Width="300px" />
                                        </td>
                                    </tr>
                                    <tr><td></td></tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblKeyPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeyPosition" runat="server" CssClass="Input" ></asp:TextBox>
                                        </td>               
                </tr>
                <tr>
                    <td height="175">
                    </td>
                    
                </tr>
                <table  width="100%" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td colspan="4" align="center" style="width: 897px">
                        <asp:Button ID="btnSearchKeyAdd" Text="Add" runat="server" CssClass="Buttons" OnClick="btnSearchKeyAdd_Click"
                            Width="85px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnClearKeyAdd" Text="Cancel" runat="server" CssClass="Buttons" OnClick="btnClearKeyAdd_Click"
                            Width="85px" />
                    </td>
                </tr>
                </table>
            </table>
            </asp:panel>
            <br />
        </div>
    </div>

</asp:Content>
