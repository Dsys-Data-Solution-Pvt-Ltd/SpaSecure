<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddPenaltySecurity.aspx.cs" Inherits="SMS.SuperVisor.AddPenaltySecurity"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Penalty</span></div>
              
        <div>
            <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                CssClass="ValSummary"></asp:Label>
        </div>
        <br /> 
        <div id="divAdvSearch" runat="server" visible="true">
               <table width="750" class="table" style=" background:white">
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
                                            
                                            <tr>
                                                  <td colspan="5">
                                                     </td>
                                            </tr>
                               </table>
                               <asp:Panel ID="btnpanel" width="750" style=" height:36px; margin-left:22px; background:url(../Images/1397d40aa687.jpg)" runat="server">
                               <asp:Button ID="Button1" Text="Add" runat="server" 
                                 CssClass="Buttons" Width="85px" onclick="btnSearchPassAdd_Click"  style=" margin-left:20em; height:30px"/>
                                 &nbsp;&nbsp;&nbsp; &nbsp;
                              <asp:Button ID="Button2" Text="Cancel" runat="server" 
                               CssClass="Buttons" Width="85px" onclick="btnClearPassAdd_Click" style="height:30px"/>

                               </asp:Panel>
        </div>
       <br />
    </div>

</asp:Content>
