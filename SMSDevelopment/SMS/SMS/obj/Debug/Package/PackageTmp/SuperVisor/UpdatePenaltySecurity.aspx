<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="UpdatePenaltySecurity.aspx.cs" Inherits="SMS.SuperVisor.UpdatePenaltySecurity"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">

  <div class="divHeader">
  
    <span class="pageTitle">Update Penalty Security</span></div>
    <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="700px">
      <div id="divErr" runat="server">
          <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
           ForeColor="Red"></asp:Label> </div>
           
          <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
          <asp:HiddenField ID="hdnBTName" runat="server" Value="" />    
        
            <br />          
           <div id="divAdvSearch" runat="server" visible="true">
                    
                      <table width="700px" class="table">
                      
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblpenalty_ID" Text="ID" CssClass="Labels" runat="server" 
                                                        Visible="False"></asp:Label>
                                                </td>
                                                 <td>
                                                     <asp:TextBox ID="txtID" runat="server" CssClass="Input" ReadOnly="True" 
                                                         Visible="False" />                                                    
                                                 </td>
                                            </tr>
                      
                                             <tr>
                                                <td>
                                                    <asp:Label ID="lblHeading" Text="Heading" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                     <asp:TextBox ID="txtHeading" runat="server" CssClass="Input" Width="400px" />
                                                     <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" 
                                                     Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                     
                                                 </td>
                                             </tr>
                                             <tr>    
                                                 
                                                    <td valign="top">
                                                        <asp:Label ID="lblClause" Text="Clause" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtClause" runat="server" CssClass="Input" Height="55px" 
                                                            Width="400px" TextMode="MultiLine" />                      
                                                    </td>
                                            </tr>
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblFine" Text="Fine" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFine" runat="server" CssClass="Input" Width="400px" />                      
                                                    </td>
                                            </tr>                               
                                            <tr>  
                                                 <td height="45px" colspan="2">
                                                </td>
                                            </tr>
                                            <TABLE width="700px">
                                            
                                             <tr>
                            
                                       <td  colspan="5" style="margin-left:1.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)" >
                                         <asp:Button ID="btnsave" runat="server" CssClass="Buttons" 
                                           Text="Save" Width="85px" onclick="btnsave_Click" style=" margin-left:15em"/>
                                           &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;              
                                          <asp:Button ID="btnClear" runat="server" CssClass="Buttons" 
                                           Text="View All" Width="85px" onclick="btnClear_Click"/>
                                     </td>
                                </tr>
                               </table>
                    
                     
          </div>
          </asp:panel>
         <br/>     
        
        
                           
          
     </div>
    


</asp:Content>
