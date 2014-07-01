<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="UpdateVehicleAlert.aspx.cs" Inherits="SMS.SuperVisor.UpdateVehicleAlert"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
  <div class="divHeader">
    <span class="pageTitle">Update Person Alert</span></div>
      <div id="divErr" runat="server">
          <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
           ForeColor="Red"></asp:Label> </div>
          <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
          <asp:HiddenField ID="hdnBTName" runat="server" Value="" />    
        
            <br />          
            <div id="divAdvSearch" runat="server" visible="true">
                        <table width="100%">
                        
                                            <tr>
                                               <td>
                                                     <asp:Label ID="lblheading" Text="Vehicle Alert" CssClass="Labels" runat="server" 
                                                         Font-Bold="True" Font-Size="10pt"></asp:Label>                                                  
                                               </td>
                                            </tr>
                                               <tr>      
                                                     
                                                     <td>
                                                        <asp:Label ID="lbllocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="126px">
                                                        </asp:DropDownList>
                                                    </td> 
                                                    <td>
                                                           <asp:Label ID="lblalertid" Text="Alert ID" CssClass="Labels" 
                                                           runat="server" Visible="false"></asp:Label>
                                                     </td>
                                                      <td>
                                                          <asp:TextBox ID="txtAlertid" runat="server" CssClass="Input" ReadOnly="True" Visible="false"/>
                                                     </td>
                                             </tr>  
                        
                                          <tr>
                                                    <td>
                                                        <asp:Label ID="lblV_Type" CssClass="Labels" runat="server" Text="Vehicle Type"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlV_Type" runat="server" CssClass="Input" Width="126px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbladdnewtype" CssClass="Labels" runat="server" 
                                                            Text="Add New Type"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtaddType" Text="" CssClass="Input" />
                                                        &nbsp;
                                                        <asp:Button ID="btnaddnewVehicle" CssClass="Buttons" runat="server" 
                                                            Text="Add  Type"/>
                                                    </td>
                                            </tr>      
                        
                        
                          
                                            <tr>
                                            
                                                   <td>
                                                        <asp:Label ID="lblVehicleReg" Text="Vehicle Register No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtVehicleReg" runat="server" CssClass="Input"/>                                                     
                                                    </td>
                                            
                                            
                                                    <td>
                                                        <asp:Label ID="lblV_ONricNo" Text="Vehicle Owner NRIC No." CssClass="Labels" 
                                                            runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtV_ONricNo" runat="server" CssClass="Input" />                                                     
                                                        <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                    
                                                    
                                                    </td>
                                                     
                                           </tr>
                                            <tr>      
                                                     <td>
                                                           <asp:Label ID="lblVOwerName" Text="Vehicle Owner Name" CssClass="Labels" 
                                                           runat="server"></asp:Label>
                                                     </td>
                                                      <td>
                                                          <asp:TextBox ID="txtVOwerName" runat="server" CssClass="Input"/>
                                                     </td>
                                                   
                                                   <td>
                                                        <asp:Label ID="lblVColor" Text="Vehicle Color" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtVColor" runat="server" CssClass="Input" />
                                                        
                                                    </td>
                                            </tr>
                                            
                                           
                                           <tr>
                                                    <td>
                                                        <asp:Label ID="lblAlertReason" CssClass="Labels" runat="server" Text="Reason For Alert"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAlertreason" runat="server" CssClass="Input" Width="126px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbladdNewtreason" CssClass="Labels" runat="server" 
                                                            Text="Add Alert Reason"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtaddReason" Text="" CssClass="Input" />
                                                        &nbsp;
                                                        <asp:Button ID="cmdAddReason" CssClass="Buttons" runat="server" Text="Add Reason"/>
                                                    </td>
                                            </tr>                                        
                                            <tr>
                                                 <td valign="top" align="left">
                                                    <asp:Label ID="lblmessage" Text="Comments" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtmessage" runat="server" CssClass="Input" 
                                                        TextMode="Multiline" width="602px" Height="116px" />
                                                </td>
                                                
                                            </tr>
                      
                            <tr>
                                  <td height="45px" width="150px">
                                  </td>
                                  <td></td>
                            </tr>
                          
                                            <tr>
                                                    <td colspan="1">
                                                        <asp:Label ID="lblalertedby" runat="server" CssClass="Labels" Font-Bold="True" 
                                                            Text="Alert Raised By:"></asp:Label>
                                                    </td>
                                           </tr>
                                            <tr>
                                            
                                                     <td>
                                                        <asp:Label ID="lblbynric" runat="server" CssClass="Labels" Text="NRIC/FIN No."></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtbynric" runat="server" CssClass="Input" />
                                                        <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblname" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtname" runat="server" CssClass="Input" Width="220px" />
                                                    </td>
                                                    
                                           </tr>
                                            <tr>  
                                                   <td>
                                                        <asp:Label ID="lblphone" runat="server" CssClass="Labels" Text="Phone No."></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtphone" runat="server" CssClass="Input" />
                                                    </td>
                                                    
                                                    <td>
                                                        <asp:Label ID="lbldesignation" runat="server" CssClass="Labels" 
                                                            Text="Designation"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdesignation" runat="server" CssClass="Input" 
                                                            Width="218px" />
                                                    </td>
                                                    
                                              </tr>
                                              <tr>  
                                                    
                                                    <td>
                                                        <asp:Label ID="lbldepartment" runat="server" CssClass="Labels" 
                                                            Text="Department" Visible="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        
                                                        <asp:DropDownList ID="ddlRole0" runat="server" CssClass="Input" width="132px" Visible="False">                                                  
                                                        </asp:DropDownList>
                                                    </td>
                                                    
                                                    
                                            </tr>
                      
                            <tr>
                                <td height="50px">
                                </td>
                            
                            </tr>
                            <tr>
                            
                                    <td align="Center" colspan="4" >
                                         <asp:Button ID="btnsave" runat="server" CssClass="Buttons" 
                                           Text="Save" Width="85px" onclick="btnsave_Click"/>
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;              
                                          <asp:Button ID="btnClear" runat="server" CssClass="Buttons" 
                                           Text="View All" Width="85px" onclick="btnClear_Click"/>
                                     </td>
                           </tr>
                      </table>
                </div>
    <br/>     
        
          
     </div>



</asp:Content>
