<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="SecurityOfficerBriefing.aspx.cs" Inherits="SMS.SuperVisor.SecurityOfficerBriefing"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Briefing</span></div>
             <div>
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
             </div>
             <br />
            
             <table width="100%">
                          <tr>
                                <td>
                                    <asp:Label ID="lblLocatlion" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px"></asp:DropDownList>
                                     <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                                </td>
                        </tr> 
                        <tr>
                            <td>
                                <asp:Label ID="lbltypeofBriefing" Text="Type" CssClass="Labels" 
                                    runat="server"></asp:Label>
                            </td>
                            <td>                                
                                <asp:DropDownList ID="txttypeofBriefing" runat="server" CssClass="Input" 
                                    Width="130px">
                                </asp:DropDownList>
                                <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                 Font-Size="Smaller" ForeColor="Red"></asp:Label> &nbsp; &nbsp; &nbsp;
                           <%-- </td>
                            <td>--%>
                                 
                                <asp:Label ID="lbladdeventtype" CssClass="Labels" runat="server" 
                                    Text="Add New Type"></asp:Label>
                           <%-- </td>
                            <td>--%> &nbsp; &nbsp; &nbsp;
                                <asp:TextBox runat="server" ID="txtaddbrieortype" Text="" CssClass="Input" />
                                &nbsp;
                                <asp:Button ID="cmdadd2" CssClass="Buttons" runat="server" Text="Add" 
                                    Width="50px" onclick="cmdadd2_Click"/>
                            </td>
                            
                           
                        </tr>
                        
                        
                         <tr>        
                              <td>
                                     <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date"></asp:Label></td>
                              <td>
                                   <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                                                        
                              <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                               <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                              ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                             </td>
                       </tr>
                                              
                         <tr>
                                <td valign="top">
                                    <asp:Label ID="lblAttendees" Text="Attendees" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAttendees" runat="server" CssClass="Input" Width="700px" 
                                        Height="55px" TextMode="MultiLine" />
                                </td>
                        </tr>
                        
                        <tr>
                                <td>
                                    <asp:Label ID="lblConductedBy" Text="Conducted By" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtConductedBy" runat="server" CssClass="Input" 
                                     Width="200px"/>
                                </td>
                        </tr>
                        <tr>
                                <td valign="top">
                                    <asp:Label ID="lblDetail" Text="Details" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDetail" runat="server" CssClass="Input" Width="700px" 
                                        Height="85px" TextMode="MultiLine" />
                                </td>
                        </tr>       
                        
                        <tr>
                            <td height="25">                               
                            </td>                         
                         </tr>
                         
                         
                          <tr>
                                <td>
                                    <asp:Label ID="lblOutcomeHeading" Text="Outcome of Briefing" CssClass="Labels" 
                                        runat="server" Font-Bold="True"></asp:Label>
                                </td>
                          </tr>      
                         
                        <tr>
                                <td>
                                    <asp:Label ID="lblActionDate" Text="Action Date" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                  <asp:TextBox ID="txtActionDate" CssClass="Input" runat="server"></asp:TextBox>
                                                                
                                  <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                  Format="MM/dd/yyyy" TargetControlID="txtActionDate" PopupButtonID="imgBtnFromDate3" />
                                  <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                             </td>
                        </tr>
                        
                        <tr>
                                <td valign="top">
                                    <asp:Label ID="lblActionComment" Text="Comments" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActionComment" runat="server" CssClass="Input" Width="700px" 
                                        Height="85px" TextMode="MultiLine" />
                                </td>
                        </tr> 
                        
                         <tr>
                            <td height="25">                               
                            </td>                         
                         </tr>
                          <tr>
                                <td>
                                    <asp:Label ID="lblReportedTo" Text="Reported To" CssClass="Labels" 
                                        runat="server" Font-Bold="True"></asp:Label>
                                </td>
                          </tr>      
                         
                        
                        <tr>
                                <td>
                                    <asp:Label ID="lblReproedName" Text="Name" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReportedName" runat="server" CssClass="Input" 
                                     Width="200px"/>
                                </td>
                        </tr>
                        <tr>        
                                 <td>
                                    <asp:Label ID="lblPosition" Text="Position" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtposition" runat="server" CssClass="Input" Width="200px"/>
                                </td>
                        </tr>
                                         
                         <tr>
                            <td height="35">                               
                            </td>                         
                         </tr>
                         
                         <tr>
                                    <td colspan="4" align="center">
                                    <asp:Button ID="btnAddTraining" Text="Save" runat="server" 
                                    CssClass="Buttons" Width="85px" onclick="btnAddTraining_Click"/>
                                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearTraining" Text="Cancel" runat="server" 
                                    CssClass="Buttons"  Width="85px" onclick="btnClearTraining_Click"/> </td>
                         </tr>
                    </table>
              
        <br />      
</div>



</asp:Content>
