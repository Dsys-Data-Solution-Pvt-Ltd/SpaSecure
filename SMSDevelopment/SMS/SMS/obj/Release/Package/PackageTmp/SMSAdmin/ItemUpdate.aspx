<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="ItemUpdate.aspx.cs" Inherits="SMS.SMSAdmin.ItemUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Item Update</span></div>
            <div id="divErr" runat="server">
                            <asp:label id="lblErrMsg" cssclass="ValSummary" runat="server" Font-Bold="True" 
                                ForeColor="Red"></asp:label>
             </div>
             <br />
        <table id="tblMain" width="100%">
            <tr>
                    <td>
                        
                        <asp:hiddenfield id="hdnBTID" runat="server" value="" />
                        <asp:hiddenfield id="hdnBTName" runat="server" value="" />
                    </td>
            </tr>
            
                 
                               <tr>
                                    <td>
                                        <asp:Label ID="lblItem" Text=" Add Item" CssClass="Labels" runat="server" Font-Bold="true" ></asp:Label>
                                    </td>
                               </tr>
                                <tr>
                                        <td>
                                             <asp:Label ID="lblItemNo" Text="Item No." CssClass="Labels" runat="server"></asp:Label>
                                       </td>
                                        <td>
                                            <asp:TextBox ID="txtItemNo" runat="server" CssClass="Input" BackColor="#E1E1E1" 
                                                        ReadOnly="True" />
                                         </td>
                                                
                                           <td>
                                             <asp:Label ID="lblItemDes" Text="Item Description" CssClass="Labels" runat="server"></asp:Label>
                                         </td>
                                           <td>
                                               <asp:TextBox ID="txtItemdescription" runat="server" CssClass="Input" />
                                          </td>
                                 </tr>
                                 <tr>
                                         <td>
                                             <asp:Label ID="lblitemquantity" Text="Item Quantity" CssClass="Labels" runat="server"></asp:Label>
                                        </td>
                                           <td>
                                               <asp:TextBox ID="txtitemquantity" runat="server" CssClass="Input" />
                                          </td> 
                                 </tr>
                                 
                                 
                                 
                                 <tr>
                                        <td height="35px">
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
                                                        BackColor="#E1E1E1" ReadOnly="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblItemname" Text="Name" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlogedname" runat="server" CssClass="Input" />
                                                         
                                                </td>
                                                
                                                
                                  </tr>
                                   <tr>
                                                <td>
                                                    <asp:Label ID="lblcname" Text="CompanyName" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlogedcompname" runat="server" CssClass="Input" />
                                                 </td>
                                                <td>
                                                    <asp:Label ID="lblTime" Text="Time" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                        <MKB:TimeSelector ID="TimeSelector1" runat="server" AllowSecondEditing="true" 
                                                            MinuteIncrement="1" SecondIncrement="1" SelectedTimeFormat="Twelve" />
                                                </td>
                                             
                                                
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
                                  </tr>
                                  <tr>
                                  
                                                 <td>
                                                    <asp:Label ID="lblPosition0" runat="server" CssClass="Labels" 
                                                        Text="NRIC/FIN No."></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsignednric" runat="server" CssClass="Input" 
                                                        BackColor="#E1E1E1" ReadOnly="True" />
                                                </td>
                                  
                                                <td>
                                                    <asp:Label ID="lblINo" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsignedname" runat="server" CssClass="Input" />
                                                </td>
                            
                                            
                                </tr>
                              
                                 <tr>
                                           <td>
                                               <asp:Label ID="lblcname0" runat="server" CssClass="Labels" Text="CompanyName"></asp:Label>
                                               </td>
                                               <td>
                                                   <asp:TextBox ID="txtsignedcompname" runat="server" CssClass="Input" />
                                               </td>
                                               <td>
                                                   <asp:Label ID="lblTime0" runat="server" CssClass="Labels" Text="Time"></asp:Label>
                                               </td>
                                               <td>
                                               
                                                   <MKB:TimeSelector ID="TimeSelector2" runat="server" AllowSecondEditing="true" 
                                                       MinuteIncrement="1" SecondIncrement="1" SelectedTimeFormat="Twelve" />
                                               
                                               </td>
                                  </tr>
                                    <tr>
                                                 <td>
                                                     <asp:Label ID="lblremarks" Text="Remarks" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtremarks" runat="server" CssClass="Input" />
                                               </td>
                                
                                </tr>  
                                   <tr>
                                               <td height="35px">
                                               </td>
                                  </tr>
                                  <tr>
                                                <td>
                                                    <asp:Label ID="lblLossfound" Text="Loss/Found Item" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                  </tr>
                                  <tr>
                                                <td>
                                                    <asp:Label ID="lblfoundby" Text="NRIC/FIN No." CssClass="Labels" 
                                                         runat="server"></asp:Label>
                                                 </td>
                                                <td>
                                                    <asp:TextBox ID="txtfoundnric" runat="server" CssClass="Input" 
                                                        BackColor="#E1E1E1" ReadOnly="True" />
                                                </td>
                                                 <td>
                                                        <asp:Label ID="lblstatus" Text="Status" CssClass="Labels" 
                                                            runat="server"></asp:Label>
                                                 </td>
                                                 <td>
                                                      <asp:DropDownList cssclass="Input" ID="cmbstatus" runat="server"  width="136px">
                                                       
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
                                                    <td>
                                                        <asp:TextBox ID="txtfoundremark" runat="server" CssClass="Input" />
                                                       
                                                    </td>
                                   </tr>                                  
                                  <tr>
                                               <td height="35px">
                                               </td>
                                  </tr>
            <tr>
                                
                 <td align="center" colspan="5">
                     
                        
                     <asp:button id="btnSave" runat="server" text="Save" cssclass="Buttons" 
                         onclick="btnSave_Click" Width="85px" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:button id="btnBack" runat="server" text="View All" cssclass="Buttons" 
                         onclick="btnBack_Click" Width="85px" />
                 </td>
                
              </tr>
        </table>
        <br />
    </div>
</asp:Content>
