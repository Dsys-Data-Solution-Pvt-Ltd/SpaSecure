<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="UpdateOffLeaveSetting.aspx.cs" Inherits="SMS.SuperVisor.UpdateOffLeaveSetting" Title="SPA Seuce"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="divContainer">
      <div class="divHeader">
         <span class="pageTitle">Update Off/ Leave Setting</span></div>
             <div>                        
               <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
             </div>
            <asp:Label ID="lblid" runat="server" Text="" Visible="false"></asp:Label>
            <br />          
           <div id="divAdvSearch" runat="server" visible="true"> <br /> 
                        <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750px">
            <table width="750px" class="table">
            <tr><td height="10"></td></tr>
                                            <tr>  
                                                    <td>
                                                        <asp:Label ID="lblStaffname" CssClass="Labels" runat="server" Text="Staff Name"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlStaffname" runat="server" CssClass="Input" 
                                                            Width="150px">
                                                        </asp:DropDownList> 
                                                    </td>
                                            </tr> <tr>
                    <td height="25px" style="width: 162px">
                    </td>
                </tr>  
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblTypeOfLeave" CssClass="Labels" runat="server" Text="Type of Leave"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTypeOfLeave" runat="server" CssClass="Input" 
                                                            Width="150px">
                                                        </asp:DropDownList> 
                                                    </td>
                                            </tr>   
                                                    <td height="25px" style="width: 162px">
                                                    </td>
                </tr>                   
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblNoOfday" CssClass="Labels" runat="server" Text="No. of days"></asp:Label>
                                                    </td>
                                                    <td>
                                                      <asp:TextBox ID="txtNoOfday" runat="server" CssClass="Input" /> 
                                                    </td>
                                            </tr>
                                                  <td height="25px" style="width: 162px">
                    </td>
                </tr>  
                                                        
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="Labels" Text="Superior Officer"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsuperiorOfficer" runat="server" CssClass="Input" />
                                </td>
                </tr>
                                                        
                            <tr>
                                 <td height="135" colspan="3">
                                 </td>
                            </tr>
                            </table>
                            </asp:panel>
                            </div>
                            <div >
                            <table  width="750px" style="margin-left:1.5em; margin-bottom:-0.4em; border:1px; border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                            <tr>
                              <td colspan="4" align="center" style="width: 750px">
                                         <asp:Button ID="btnNewItemAdd" runat="server" CssClass="Buttons" 
                                             Text="Save" onclick="btnNewItemAdd_Click" />
                                           &nbsp;&nbsp;&nbsp;              
                                          <asp:Button ID="btnClearNewItemAdd" runat="server" CssClass="Buttons" 
                                            Text="View All" onclick="btnClearNewItemAdd_Click"/>
                                     </td>
                           </tr>
                   </table></div>
           
    <br/>     
 </div>
</asp:Content>
