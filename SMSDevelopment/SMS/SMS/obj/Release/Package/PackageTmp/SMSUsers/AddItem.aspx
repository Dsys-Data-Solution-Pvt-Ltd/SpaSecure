<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="AddItem.aspx.cs" Inherits="SMS.SMSUsers.AddItem" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Lost /Found Item</span></div>
            <div>            
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
            </div>  
            <br />
            <div id="divAdvSearch" runat="server" visible="true">                                           
                       <table width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblItem" Text=" " CssClass="Labels" runat="server" 
                                                        Font-Bold="True" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblItemNo" Text="Item No." CssClass="Labels" runat="server"></asp:Label>
                                               
                                                </td>
                                               
                                                <td>
                                                    <asp:TextBox ID="txtItemNo" runat="server" CssClass="Input" 
                                                        ontextchanged="txtItemNo_TextChanged" AutoPostBack="true" ReadOnly="True"/>
                                                   <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                      
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblItemDes" Text="Item Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemdescription" runat="server" CssClass="Input" 
                                                        Width="143px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblItemquantity" Text="Item Quantity" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemquantity" runat="server" CssClass="Input" />
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                 <td height="35px" colspan="2">                                                 
                                                 </td> 
                                            </tr>
                                             <tr>
                                                <td>
                                                     <asp:Label ID="lblItemLogged" Text="Logged In By:" CssClass="Labels" 
                                                         runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPosition" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                    <asp:TextBox ID="txtlogednric" runat="server" CssClass="Input" 
                                                        ontextchanged="txtlogednric_TextChanged" />
                                                    <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                </td>                                            
                                                <td>
                                                    <asp:Label ID="lblItemname" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlogedname" runat="server" CssClass="Input" />
                                                     
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblcname" Text="Company Name" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtlogedcompname" runat="server" CssClass="Input"/>
                                                       
                                                     </td>
                                                    <td>
                                                        <asp:Label ID="lbllogedtime" CssClass="Labels" runat="server" Visible="False"></asp:Label></td>
                                                     <td>
                                                         &nbsp;</td>
                                             
                                                
                                            </tr>
                                            <tr>
                                                    <td height="35px">
                                                    </td>
                                            
                                            
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblItemsignout" Text="Signed Out By:" CssClass="Labels" 
                                                        runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:checkbox ID="chksingout" runat="server" CssClass="Labels" 
                                                        oncheckedchanged="chksingout_CheckedChanged" AutoPostBack ="true"></asp:checkbox>
                                                
                                                </td>
                                            </tr>
                                            <tr>    
                                                 <td>
                                                    <asp:Label ID="lblLossfound" Text="Found/Lost Item :" CssClass="Labels" 
                                                        runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:checkbox ID="chklost" runat="server" CssClass="Labels" 
                                                         AutoPostBack ="true" oncheckedchanged="chklost_CheckedChanged"></asp:checkbox>
                                                
                                                </td>
                                            </tr>
                                    </table>
                                    <br />
                                    <div> 
                                           
                                      <asp:Panel ID="pnlsingout" runat="server" Width="100%">
                                         
                                         <table width="100%">
                                            <tr>
                                            
                                               <td>
                                                   <asp:Label ID="lblPosition0" runat="server" CssClass="Labels" Text="NRIC/FIN No."></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsignednric" runat="server" CssClass="Input" />
                                                    <asp:Label ID="lblerr3" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                    <asp:Label ID="lblItemname0" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtsignedname" runat="server" CssClass="Input" Width="291px" />
                                                </td>                                            
                                           </tr>
                                           <tr>
                                                <td>
                                                    <asp:Label ID="lblcname0" Text="Company Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    
                                                    <asp:TextBox ID="txtsignedcompname" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblremark" runat="server" CssClass="Labels" Text="Remarks"></asp:Label>
                                                       
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtremark" runat="server" CssClass="Input" Height="16px" 
                                                        Width="293px" />
                                                </td>
                                           </tr>
                                           <tr>
                                                <td>
                                                    <asp:Label ID="lblsignedtime" CssClass="Labels" runat="server" Visible="False"></asp:Label></td>
                                                <td>
                                                    &nbsp;</td>
                                               
                                           
                                           
                                           </tr>
                                           
                                          
                                           <tr>
                                                <td height="35px" width="150px">
                                                </td>
                                                <td height="35px" width="220px">
                                                </td>
                                                <td width="150px">
                                                </td>
                                                <td height="35px">
                                                </td>
                                                
                                           </tr>
                                            
                                       </table>
                                </asp:Panel>
                              </div> 
                              <br />           
                                  <div>
                                      <asp:Panel ID="pnllost" runat="server" Width="100%">     
                                            <table Width="100%">           
                                            
                                            <tr>
                                                   
                                                    <td>
                                                        <asp:Label ID="lblfoundby" runat="server" CssClass="Labels" 
                                                            Text="NRIC/FIN No."></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtfoundnric" runat="server" CssClass="Input" />
                                                        <asp:Label ID="lblerr4" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                    </td>
                                                   
                                                  <td>
                                                        <asp:Label ID="lblstatus" Text="Status" CssClass="Labels" 
                                                            runat="server"></asp:Label>
                                                 </td>
                                                 <td>
                                                      <asp:DropDownList cssclass="Input" ID="cmbstatus" runat="server" 
                                                        width="136px">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Found</asp:ListItem>
                                                        <asp:ListItem>Lost</asp:ListItem>
                                                       
                                                    </asp:DropDownList>
                                                 </td>
                                            
                                            </tr>
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblfoundremark" runat="server" CssClass="Labels" 
                                                            Text="Remarks"></asp:Label>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtfoundremark" runat="server" CssClass="Input" 
                                                            Width="491px" />
                                                       
                                                    </td>
                                            </tr>                                            
                                              <tr>
                                                <td height="35px" width="180px">
                                                </td>
                                                <td height="35px" width="200px">
                                                </td>
                                                <td width="150px">
                                                </td>
                                                <td height="35px">
                                                </td>
                                                
                                           </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>                                               
                                            </tr>
                                      </table>      
                                 </asp:Panel>
                                </div> 
                                      
                               <br />
                                    
                               <table width="750px">           
                                            
                                            <tr>
                                                <td align="Center" colspan="3">
                                                    <asp:Button ID="btnItemAdd" runat="server" CssClass="Buttons" 
                                                        onclick="btnItemAdd_Click" Text="Save" Width="85px" />
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearItemAdd" runat="server" CssClass="Buttons" 
                                                        Text="Cancel" onclick="btnClearItemAdd_Click" Width="85px" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                    </div>
    </div>
  <br />  
</asp:Content>
