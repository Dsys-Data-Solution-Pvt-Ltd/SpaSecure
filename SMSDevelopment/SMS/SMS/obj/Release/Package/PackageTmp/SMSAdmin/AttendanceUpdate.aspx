<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="AttendanceUpdate.aspx.cs" Inherits="SMS.SMSAdmin.AttendanceUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
<div class="divHeader">
        <span class="pageTitle">Attendance Update</span></div>
         <div id="divErr" runat="server">
                <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label> 
         </div>
          <asp:HiddenField ID="hdnBTID" runat="server" Value="" onvaluechanged="hdnBTID_ValueChanged" />
          <asp:HiddenField ID="hdnBTName" runat="server" Value="" onvaluechanged="hdnBTName_ValueChanged" />
        
        <br /> 
         <table width="100%">                                        
                                        
                                        <tr>
                                            <td>
                                               <asp:Label ID="lblstaffnric" cssclass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtnric" cssclass="Input" runat="server" 
                                                    BackColor="#E7E7E7" ReadOnly="True"></asp:TextBox>
                                                 
                                            </td> 
                                            <td>
                                                <asp:Label ID="lblname" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtname" runat="server" CssClass="Input"></asp:TextBox>                                               
                                            </td>
                                      </tr>
                                      <tr>  
                                                                                   
                                            <td>
                                                <asp:Label ID="lblPassNo" CssClass="Labels" runat="server" Text="Pass No."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPassNo" CssClass="Input" runat="server" ></asp:TextBox>                                               
                                            </td>
                                             <td>
                                                <asp:Label ID="lblPassType" CssClass="Labels" runat="server" Text="Pass Type"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList cssclass="Input" ID="cmbContractorPass" runat="server" 
                                                    width="136px" 
                                                    onselectedindexchanged="cmbContractorPass_SelectedIndexChanged1">
                                               
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblKeyNo" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKeyNo" CssClass="Input" runat="server"></asp:TextBox>
                                                 
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                             <td>
                                                         <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="In Time"></asp:Label>
                                             </td>
                                             <td>
                                                            <asp:TextBox runat="server" ID="calDateOfIncident" Text="" CssClass="Input" ontextchanged="calDateOfIncident_TextChanged" 
                                                                 />
                                                        
                                                          <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="calDateOfIncident" PopupButtonID="imgBtnFromDate" />
                                                            <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp" style="width: 16px" 
                                                                onclick="imgBtnFromDate_Click" />
                                             </td>
                                             <td>
                                                       <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="Out Time"></asp:Label>
                                             </td>
                                             <td>
                                                            <asp:TextBox runat="server" ID="calDateOfIncident1" Text="" CssClass="Input" ontextchanged="calDateOfIncident1_TextChanged" 
                                                                 />
                                             
                                                    
                                                            <AJAX:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="calDateOfIncident" PopupButtonID="imgBtnFromDate1" />
                                                            <asp:ImageButton ID="imgBtnFromDate1" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp" style="height: 13px"  />
                                             </td>
                                             
                                        </tr>
                                       
                                        
                                        <tr>
                                             <td height="40px">
                                             
                                                  <asp:Label  ID=out_no runat="server" Font-Size="Smaller" Visible="False"></asp:Label>
                                             </td>
                                             <td height="40px">
                                             
                                                  <asp:Label  ID=role runat="server" Font-Size="Smaller" Visible="False"></asp:Label>
                                             </td>
                                        
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="Center">
                                                <asp:Button ID="btnsave" runat="server" CssClass="Buttons" Text="Save" 
                                                     Width="85px" onclick="btnsave_Click" />
                                          
                                             &nbsp;&nbsp;&nbsp; &nbsp;
                                            <asp:Button ID="btnback" CssClass="Buttons" runat="server" Text="View All" 
                                                     Width="85px" onclick="btnback_Click" />
                                                
                                            </td>
                                           
                                                             
                                        </tr>
                                        <tr>
                                             <td height="25px">
                                             </td>
                                        </tr>
                                        
                                        
                          </table> 
     <br />   
</div>
<br />
</asp:Content>
