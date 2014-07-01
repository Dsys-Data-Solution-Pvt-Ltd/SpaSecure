<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="UpdateEmergencyContact.aspx.cs" Inherits="SMS.SuperVisor.UpdateEmergencyContact"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
       <div>
            <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                CssClass="ValSummary"></asp:Label>
        </div>
        <br /> 
  <div id="divAdvSearch" runat="server" visible="true">
                       <table width="100%">
                                             <tr>                                             
                                                 <td>
                                                    <asp:Label ID="lblAssignmentid" Text="Location" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>                                                
                                                <td>
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" 
                                                        Width="175px"></asp:DropDownList>
                                                     <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr>
                                                <td>
                                                    <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                 <td>
                                                     <asp:TextBox ID="txtName" runat="server" CssClass="Input" Width="175px" />
                                                     
                                                 </td>
                                            </tr>
                                             <tr>    
                                                 <td>
                                                        <asp:Label ID="lblPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                                  </td>
                                                  <td>
                                                         <asp:TextBox ID="txtPosition" runat="server" CssClass="Input" Width="175px" />                      
                                                  </td>
                                            </tr>
                                             <tr>    
                                                 <td>
                                                        <asp:Label ID="lblmobileno" Text="Mobile No." CssClass="Labels" runat="server"></asp:Label>
                                                  </td>
                                                  <td>
                                                         <asp:TextBox ID="txtmobileno" runat="server" CssClass="Input" Width="175px" />                      
                                                  </td>
                                            </tr>
                                             <tr>    
                                                 <td>
                                                        <asp:Label ID="lblofficeno" Text="Office No." CssClass="Labels" runat="server"></asp:Label>
                                                  </td>
                                                  <td>
                                                         <asp:TextBox ID="txtofficeno" runat="server" CssClass="Input" Width="175px" />                      
                                                  </td>
                                            </tr>
                                             <tr>    
                                                 <td>
                                                        <asp:Label ID="lblhomeno" Text="Home No." CssClass="Labels" runat="server"></asp:Label>
                                                  </td>
                                                  <td>
                                                         <asp:TextBox ID="txthomeno" runat="server" CssClass="Input" Width="175px" />                      
                                                  </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <asp:Label ID="lblgrade" Text="Extension" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtGrade" runat="server" CssClass="Input" Width="175px" />
                                                </td>                                                
                                            </tr>                                             
                                            <tr>  
                                                 <td height="45px">
                                                </td>
                                            </tr>                                                      
                                            <tr>
                                                  <td align="center" colspan="5">
                                                    <asp:Button ID="btnSave" Text="Save" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnSave_Click"/>
                                                     &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="btnClear" Text="View All" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnClear_Click"/>
                                                   </td>
                                            </tr>
                               </table>
          </div>
</div>
</asp:Content>
