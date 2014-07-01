<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="updateviewclient.aspx.cs" Inherits="GaurdPatroSystem.updateviewclient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
      <table width="100%" cellspacing="5">
         <tr>
           <td align="left" colspan="2" height="30" valign="top"> 
               <asp:Label ID="lblmsg" runat="server" Visible="False" Font-Bold="True" 
                   ForeColor="#FF3300"></asp:Label>
           </td>
        </tr>
       <tr>
          <td align="center">
              <asp:Label ID="lblclientName" runat="server" Text="User ID"></asp:Label>
          </td>
          <td>
              <asp:TextBox ID="txtclientName" runat="server"></asp:TextBox>
              <asp:Label ID="staffid" runat="server" Text="" Visible="false"></asp:Label>
          </td> 
        </tr>
        <tr>  
           <td align="center">
              <asp:Label ID="lblpassword" runat="server" Text="Password"></asp:Label>
          </td>
          <td>
              <asp:TextBox ID="txtpassword" runat="server" ></asp:TextBox>
          </td> 
       </tr>
      <tr>  
           <td align="center">
              <asp:Label ID="lbllocation" runat="server" Text="Location"></asp:Label>
          </td>
          <td>
             <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="150px" 
         class="Label2"  style=" width:167px" >
        </asp:DropDownList>
              <asp:Label ID="lbllocationid" runat="server" Text="" Visible="false"></asp:Label>
          </td> 
       </tr>
       <tr>
          <td height="20px">             
          </td>
       </tr>
       <tr>
          <td colspan="2">
              <asp:Button ID="btnAdd" runat="server" Text="Update" onclick="btnAdd_Click" Width="80px" style=" margin-left:195px"
               />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btncancel" runat="server" Text="Cancel" Width="80px" 
                Visible="false" />
          </td>
       </tr>
       <tr><td><asp:Label ID="SearchLocID" runat="server" Visible="False" Width="20px"></asp:Label></td></tr>
   </table>
   </div>

</asp:Content>
