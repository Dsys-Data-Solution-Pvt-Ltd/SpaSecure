<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="UpdateLostFound.aspx.cs" Inherits="SMS.SuperVisor.UpdateLostFound"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
  <div class="divHeader">
    <span class="pageTitle">Follow-Up Lost/ Found</span></div>
      <div id="divErr" runat="server">
          <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
           ForeColor="Red"></asp:Label> </div>
          <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
          <asp:HiddenField ID="hdnBTName" runat="server" Value="" />    
        
            <br />          
            <div id="divAdvSearch" runat="server" visible="true">
                    <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750">   
            
                     <table class="table">
                                            <tr>
                                                <td colspan="5" height="25" valign="top" style="width: 9em">
                                                    <asp:Label ID="lblItem" Text="Details Of Lost" CssClass="Labels" runat="server" 
                                                        Font-Bold="True" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                    <td style="width: 9em">
                                                        <asp:Label ID="lblDateofLost" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                            <asp:TextBox runat="server" ID="calDate" Text="" CssClass="Input"/>
                                                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="calDate" PopupButtonID="imgBtnFromDate" />
                                                            <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp"/>
                                                    </td>
                                                     <td>
                                                            <asp:Label ID="lblLostID" Text="LostID" CssClass="Labels" runat="server" 
                                                                Visible="False"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtLostID" runat="server" CssClass="Input" ReadOnly="True" 
                                                                Visible="False" />
                                                    </td>
                                                    
                                                    
                                                    
                                             </tr>
                                             
                                            <tr>
                                                    <td style=" width:130px">
                                                            <asp:Label ID="lblTimeLost" Text="Time of Lost" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <MKB:timeselector ID="TimeSelector1" runat="server" MinuteIncrement="1" SecondIncrement="1" SelectedTimeFormat="Twelve" AllowSecondEditing="true"/>
                                                    </td>
                                            
                                            </tr>
                                            
                                            <tr>
                                            
                                                <td style="width: 9em">
                                                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLocation" runat="server" CssClass="Input"/>
                                                </td>
                                            
                                                    <td>
                                                            <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="Input" Width="250px"/>
                                                    </td>
                                                
                                          </tr>
                                          
                                            <tr>
                                                   
                                                     <td style="width: 9em">
                                                            <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtNRIC" runat="server" CssClass="Input"/>
                                                    </td>
                                                     <td>
                                                            <asp:Label ID="lblTelephone" Text="Contact No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtTelephone" runat="server" CssClass="Input" Width="250px"/>
                                                    </td>
                                                    
                                                    
                                            </tr>
                                            <tr>      
                                                
                                                <td valign="top" style="width: 9em">
                                                    <asp:Label ID="lblDescription" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtdescription" runat="server" CssClass="Input" 
                                                        Width="600px" Height="55px" TextMode="MultiLine" />
                                                </td>
                                         </tr>
                                            
                                            <tr>
                                                    <td style="width: 9em">
                                                            <asp:Label ID="lblStatus" Text="Status" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                         <asp:DropDownList ID="ddlStatus" runat="server" CssClass="Input" Width="123px">
                                                           <asp:ListItem>Lost</asp:ListItem>
                                                            <asp:ListItem>Found</asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>
                                            
                                            </tr>
                                            
                                           <tr>
                                                  <td height="35px" style="width: 9em">
                                                  </td>
                                           
                                           </tr>
                                           
                                           <tr>
                                                <td colspan="5" height="25" valign="top">
                                                    <asp:Label ID="Label1" Text="Details of Follow-Up" CssClass="Labels" runat="server" 
                                                        Font-Bold="True" ></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                    <td style="width: 9em">
                                                            <asp:Label ID="lblAckNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtAckNRIC" runat="server" CssClass="Input" />
                                                    </td>
                                                    
                                                    <td>
                                                        <asp:Label ID="lblAckClaimant" Text="Claimant" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAckClaimant" runat="server" CssClass="Input" Width="250px"/>
                                                    </td>
                                                
                                          </tr>
                                          
                                            <tr>
                                                   
                                                    
                                                     <td style="width: 9em">
                                                            <asp:Label ID="lblAckContact" Text="Contact No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtAckContact" runat="server" CssClass="Input"/>
                                                    </td>
                                                    
                                                     <td>
                                                            <asp:Label ID="lblAckAddress" Text="Address" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtAckAddress" runat="server" CssClass="Input"  Width="250px"/>
                                                    </td>
                                                    
                                                    
                                            </tr>
                                            <tr>      
                                                
                                                <td valign="top" style="width: 9em">
                                                    <asp:Label ID="lblAckAction" Text="Action" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtAckAction" runat="server" CssClass="Input" 
                                                        Width="600px" Height="55px" TextMode="MultiLine" />
                                                </td>
                                         </tr>
                                            
                                            
                                            
                                           <tr>
                                                  <td height="35px" style="width: 9em">
                                                  </td>
                                           
                                           </tr>
                                           
                                          
                                          <tr>      
                                                
                                               <td align="Center" colspan="4"style=" width:64.8em; height:36px; margin-left:19px; background:url(../Images/1397d40aa687.jpg)" >
                                             <asp:Button ID="btnsave" runat="server" CssClass="Buttons" 
                                               Text="Save" Width="85px" onclick="btnsave_Click"/>
                                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;              
                                              <asp:Button ID="Button2" runat="server" CssClass="Buttons" 
                                               Text="View All" Width="85px" onclick="Button2_Click"/>
                                     </td>
                                         </tr>
                                         
                                    </table>              
                       
                       </asp:panel>
           </div>
    <br/>   
          
     </div>


</asp:Content>
