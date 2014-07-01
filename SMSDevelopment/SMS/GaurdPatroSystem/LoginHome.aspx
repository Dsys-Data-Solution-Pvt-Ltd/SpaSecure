<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="LoginHome.aspx.cs" Inherits="GaurdPatroSystem.LoginHome"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
   <table>
        <tr>
           <td align="left" colspan="2" height="30" valign="top"> 
               <asp:Label ID="lblmsg" runat="server" Visible="False" Font-Bold="True" 
                   ForeColor="#FF3300"></asp:Label>
           </td>
        </tr>
        <tr>
           <td align="left"> 
               <asp:Label ID="lblusername" runat="server" Text="User ID" Font-Names="Tahoma" 
                   Font-Size="9pt"></asp:Label>
           </td>
           <td>
              <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
           </td>
        </tr>
         <tr>
           <td>
              <asp:Label ID="lblpassword" runat="server" Text="Password" Font-Names="Tahoma" 
                   Font-Size="9pt"></asp:Label>
           </td>
           <td>
             <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
           </td>
        </tr> 
        
        <tr>
          <td colspan="2">
              <asp:Button ID="btnlogin" runat="server" Text="Login" 
                  onclick="btnlogin_Click" />
          </td>
        </tr>
          
   </table> 
 </div>
</asp:Content>
