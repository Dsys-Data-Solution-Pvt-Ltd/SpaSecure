<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ItemIssued.aspx.cs" Inherits="SMS.ADMIN.ItemIssued" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle"></span></div>
          
          <div>
          <br />
            <asp:Label ID="lblerror1" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
         <div>
              <table style="height: 100px; width: 524px;">
                <tr>
                    <td>
                       <asp:Button ID="cmdIssueItem" CssClass="Buttons" runat="server" Text="Issue New Items" 
                                 onclick="cmdIssueItem_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="cmdViewIssueItem" CssClass="Buttons" runat="server" Text="View Issued Items" 
                               onclick="cmdViewIssueItem_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="cmdbuttonCancelItem" CssClass="Buttons" runat="server" Text="Finish"
                          Width="85px" onclick="cmdbuttonCancelItem_Click" />
                     </td>
                </tr>               
              
              </table>            
         </div>
       
</div>    

</asp:Content>
