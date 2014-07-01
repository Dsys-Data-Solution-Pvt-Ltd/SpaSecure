<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="Update_Contingency.aspx.cs" Inherits="SMS.SuperVisor.Update_Contingency" Title="SPA Secure"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Update Contingency Exercise</span></div>
            <div>            
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
                   <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                   <asp:HiddenField ID="hdnBTName" runat="server" Value="" />    
            
            </div>  
            <br />
            <div id="divAdvSearch" runat="server" visible="true">   
                                                    
                       <table width="100%" cellspacing="15">
                                            <tr>
                                                <td colspan="5" height="25" valign="top">
                                                    <asp:Label ID="lblItem" Text="Contingency Exercise" CssClass="Labels" runat="server" 
                                                        Font-Bold="True" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                            
                                                 <td>
                                                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" 
                                                          Width="130px" 
                                                       ></asp:DropDownList>
                                                </td>
                                                 <td>
                                                      <asp:Label ID="lblExerciseType" Text="Exercise Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:TextBox ID="txtExerciseType" runat="server" CssClass="Input" 
                                                          Width="152px"/>
                                                 </td>
                                            </tr>
                                            
                                            <tr>
                                                 <td valign="top">
                                                      <asp:Label ID="lblManagementStaff" Text="Management Staff" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                       <asp:TextBox ID="txtManagementStaff" runat="server" CssClass="Input" 
                                                           Width="655px" Height="65px" TextMode="MultiLine"/>
                                                 </td>
                                            
                                            </tr>
                                            
                                            <tr>
                                                 <td valign="top">
                                                         <asp:Label ID="lblAttendees" Text="Attendees" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                          <asp:TextBox ID="txtAttendees" runat="server" CssClass="Input" Width="655px" 
                                                              Height="82px" TextMode="MultiLine"/>
                                                 </td>
                                            
                                            </tr>
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblEmergencyType" Text="Emergency Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                          <asp:TextBox ID="txtEmergencyType" runat="server" CssClass="Input" 
                                                              Width="655px"/>
                                                 </td>
                                            
                                            </tr>
                                              <tr>
                                                    <td>
                                                        <asp:Label ID="lblDate" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                            <asp:TextBox runat="server" ID="calDate" Text="" CssClass="Input"/>
                                                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="calDate" PopupButtonID="imgBtnFromDate" />
                                                            <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp"/>
                                                    </td>
                                                    
                                                    <td>
                                                        <asp:Label ID="lblReviewDate" Text="Review Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                            <asp:TextBox runat="server" ID="txtReviewDate" Text="" CssClass="Input"/>
                                                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="txtReviewDate" PopupButtonID="ImageButton1" />
                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp"/>
                                                    </td>
                                                    
                                                    
                                             </tr>
                                             
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblObjective" Text="Objective & Scope" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:TextBox ID="txtObjective" runat="server" CssClass="Input" Width="655px" 
                                                               Height="112px" TextMode="MultiLine"/>
                                                    </td>
                                            
                                            </tr>
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblContigencyTigger" Text="Contigency Tiggers" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:TextBox ID="txtConigencyTigger" runat="server" CssClass="Input" 
                                                               Width="655px" Height="116px" TextMode="MultiLine"/>
                                                    </td>
                                            
                                            </tr>
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblMethodology" Text="Methodology (Schedule for preparation and deployment)" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:TextBox ID="txtMethodology" runat="server" CssClass="Input" Width="655px" 
                                                               Height="84px" TextMode="MultiLine"/>
                                                    </td>
                                            
                                            </tr>
                                             <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblRoles" Text="Roles & Responsibilities" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:TextBox ID="txtRoles" runat="server" CssClass="Input" Width="655px" 
                                                               Height="106px" TextMode="MultiLine"/>
                                                    </td>
                                            
                                            </tr>
                                            
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblStatusReporting" Text="Status Reporting Processes and Protocols" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:TextBox ID="txtStatusReporting" runat="server" CssClass="Input" 
                                                               Width="655px" Height="89px" TextMode="MultiLine"/>
                                                    </td>
                                            
                                            </tr>
                                             <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblCommunication" Text="Communications Strategy" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:TextBox ID="txtCommunication" runat="server" CssClass="Input" 
                                                               Width="655px" Height="110px" TextMode="MultiLine"/>
                                                    </td>
                                            
                                            </tr>
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblResource" Text="Resources Available" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:TextBox ID="txtResource" runat="server" CssClass="Input" Width="655px" 
                                                               Height="97px" TextMode="MultiLine"/>
                                                    </td>
                                            
                                            </tr>
                                             <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblFinding" Text="Findings" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:TextBox ID="txtFinding" runat="server" CssClass="Input" Width="655px" 
                                                               Height="115px" TextMode="MultiLine"/>
                                                    </td>
                                            
                                            </tr>
                                            
                                             <tr>
                                                    <td colspan="4">
                                                            <asp:Label ID="lblheading" Text="Please mark appropriate number (1 = very low, 5 = very high) and Risk Priority Rating" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                             </tr>
                                             <tr>
                                                    <td>
                                                            <asp:Label ID="lblFrequency" Text="Frequency" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                         <asp:DropDownList ID="ddlFrequency" CssClass="Input" runat="server" 
                                                             Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>
                                                    
                                                    <td>
                                                         <asp:Label ID="lblSeverity" Text="Severity" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                         <asp:DropDownList ID="ddlServerity" CssClass="Input" runat="server" 
                                                             Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>
                                            </tr>
                                            
                                            
                                            <tr>
                                            
                                                <td>
                                                    <asp:Label ID="lblRiskFrequecy" Text="Risk (Frequency x Severity)" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtRiskFrequecy" runat="server" CssClass="Input" 
                                                        Width="655px"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                    <td>
                                                          <asp:Label ID="lblRiskPriority" Text="Risk Priority Rating" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                           <asp:DropDownList ID="ddlRiskPriority" CssClass="Input" runat="server">
                                                               <asp:ListItem>High (16 – 25)</asp:ListItem>
                                                               <asp:ListItem>Medium (9 – 15)</asp:ListItem>
                                                               <asp:ListItem>)Low (1 – 8)</asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>
                                            </tr>
                                          
                                          <tr>
                                                   
                                                     <td>
                                                            <asp:Label ID="lblRecommended" Text="Recommended Control Measures" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                            <asp:TextBox ID="txtRecommended" runat="server" CssClass="Input" Width="655px"/>
                                                    </td>                                                    
                                                    
                                            </tr>
                                           <tr>
                                                    <td>
                                                          <asp:Label ID="lblRevisedRisk" Text="Revised Risk Priority Rating (F)x (S)=" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                           <asp:DropDownList ID="ddlRevisedRisk" CssClass="Input" runat="server">
                                                               <asp:ListItem>High (16 – 25)</asp:ListItem>
                                                               <asp:ListItem>Medium (9 – 15)</asp:ListItem>
                                                               <asp:ListItem>)Low (1 – 8)</asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>
                                            </tr>
                                          
                                    </table>
             
                       <br />
                       <br />
                       <br />
                                    
                               <table width="100%">           
                                            
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="Buttons" 
                                                        Text="Save" Width="85px" onclick="btnsave_Click"/>
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnviewAll" 
                                                        runat="server" CssClass="Buttons" 
                                                        Text="View All" Width="85px" onclick="btnviewAll_Click"/>
                                                </td>
                                            </tr>
                                 </table>
                           <br />
                    </div>
    </div>

</asp:Content>
