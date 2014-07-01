<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="IncidentUpdate.aspx.cs" Inherits="SMS.SMSAdmin.IncidentUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
 <div class="divHeader">
   <span class="pageTitle"> Incident Update</span></div>
    <div id="divErr" runat="server">
           <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
            ForeColor="Red"></asp:Label>
    </div>
    <br />
        <table id="tblMain" width="100%">
             <tr>
                <td>
                    
                    <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                    <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                </td>
            </tr>
            <tr>
                <td>
                  <div id="divAdvSearch" runat="server" visible="true">
                                    
                    <table width="100%">
                                            <tr>
                                               <td>
                                                    <asp:Label ID="lblReportedByName" runat="server" CssClass="Labels" 
                                                        Text="Name/Designation"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtReportedByName" runat="server" CssClass="Input" />
                                                </td>                                                
                                                
                                                <td width="20">
                                                </td>
                                                
                                                 <td>
                                                    <asp:Label ID="lblReport" Text="Report No." CssClass="Labels" runat="server" 
                                                         Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtReportNumber" runat="server" CssClass="Input" 
                                                        BackColor="#E1E1E1" ReadOnly="True" Visible="False" />
                                                </td>
                                           </tr> 
                                            <tr>
                                                 <td>
                                                    <asp:Label ID="lblVerifiedBy" Text="Verified By" CssClass="Labels" 
                                                        runat="server" ></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVerifiedBy" runat="server" CssClass="Input"/>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPlaceOfIncident" Text="Place of Incident" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEnterPlaceOfIncident" runat="server" CssClass="Input" />
                                                </td>
                                            </tr>
                                            <tr>
                                            
                                                <td>
                                                    <asp:Label ID="lblEnterDateOfIncident" Text="Date of Incident" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                        <asp:TextBox runat="server" ID="calDateOfIncident" Text="" CssClass="Input" 
                                                            ontextchanged="calDateOfIncident_TextChanged" />
                                                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                            Format="MM/dd/yyyy" TargetControlID="calDateOfIncident" PopupButtonID="imgBtnFromDate" />
                                                        <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 
                                                            ImageUrl="~/Images/calendar.bmp" onclick="imgBtnFromDate_Click" />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEnterTimeOfIncident" Text="Time of Incident" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <MKB:timeselector ID="TimeSelector1" runat="server" MinuteIncrement="1" SecondIncrement="1" SelectedTimeFormat="Twelve" AllowSecondEditing="true" width="126px"/>
                                                </td>
                                                
                                            </tr>                                            
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAssignment" Text="Assignment/Sites" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEnterAssignments" runat="server" CssClass="Input" />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblReportedBy" runat="server" CssClass="Labels" 
                                                        Text="Reported By"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtReportedBy" runat="server" CssClass="Input" />
                                                </td>
                                               
                                            </tr>
                                          
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTypeOfIncident" Text="Type " CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList2" runat="server" cssclass="Labels" 
                                                        onselectedindexchanged="DropDownList2_SelectedIndexChanged" width="136px" >
                                                        
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                     &nbsp;</td>
                                                <td>
                                                     &nbsp;</td>
                                               
                                                
                                               
                                            </tr>
                                             <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lblReportStatement" Text="Report/Statement" CssClass="Labels" runat="server" ></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtEnterReportstatement" runat="server" CssClass="Input" 
                                                        Height="80px" TextMode="multiline" width="90%"
                                                        ontextchanged="txtEnterReportstatement_TextChanged"  />
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td height="30px"></td>
                                            </tr>
                                            <tr>
                                                
                                                <td align="Center" colspan="5">
                                                    <br />
                                                    <asp:Button ID="btnsave" runat="server" CssClass="Buttons" 
                                                        onclick="btnsave_Click" Text="Save" Width="85px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnback" runat="server" CssClass="Buttons" 
                                                        onclick="btnback_Click" Text="View All" Width="85px" />
                                                </td>
                                                
                                            </tr>
                                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
