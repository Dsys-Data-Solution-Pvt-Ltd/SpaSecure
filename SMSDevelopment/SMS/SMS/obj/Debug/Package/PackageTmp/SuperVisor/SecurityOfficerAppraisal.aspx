<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="SecurityOfficerAppraisal.aspx.cs"
 Inherits="SMS.SuperVisor.SecurityOfficerAppraisal" Title="SecurityOfficerAppraisalForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Staff Feedback Form</span></div>           
           <div>
               <asp:Label id="lblerror" runat="server" Text="lblerror " ForeColor="Red" 
                   CssClass="ValSummary"></asp:Label>
              
          </div>  
          <br />
           <div id="divAdvSearch" runat="server" visible="true">
              <%--//<asp:UpdatePanel ID="UpdatePanel1" runat="server">
               //   <ContentTemplate>--%>
                         <table width="80%" cellspacing="5" class="table" style=" background-color:White">
                           
                                          <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                         &nbsp;
                                                         &nbsp;&nbsp;&nbsp;
                                                         <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px">
                                                         </asp:DropDownList> 
                                                        <asp:Label ID="searchid" runat="server" Text="" Visible="false"></asp:Label>
                                                     </td>                                                   
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    
                                                         <asp:TextBox ID="txtStaffName" runat="server" CssClass="Input" ReadOnly="True" 
                                                            Width="250px"></asp:TextBox>
                                                     </td>                                                   
                                            </tr>
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblNric" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                                          &nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtNric" runat="server" CssClass="Input" ReadOnly="True" 
                                                            Width="250px"/>
                                                   </td>
                                             </tr>  
                                           <%-- <tr>
                                                    <td>
                                                            <asp:Label ID="lblDate" Text="Date :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox runat="server" ID="calDate" Text="" CssClass="Input"/>
                                                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="calDate" PopupButtonID="imgBtnFromDate" />
                                                            <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp"/>
                                                    </td>
                                             </tr>  
                                             --%>
                                             
                                              <tr>  
                                                    <td colspan="2" height="35" valign="bottom">
                                                            <asp:Label ID="lblHeadStafftocomplete" Text="Staff to Complete :" 
                                                                CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    
                                              </tr>  
                                              
                                               <tr>  
                                                    <td height="50px" valign="bottom">
                                                            <asp:Label ID="lblSelfEvaluation" Text="1) SELF EVALUATION :" CssClass="Labels" 
                                                                runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                              </tr>  
                                              <tr>  
                                                    <td>
                                                            <asp:Label ID="lblAdequateTraining" Text="Do you feel you have adequate training/skills for your current position & job Description :" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAdequateTraining" runat="server" CssClass="Input">
                                                          <asp:ListItem>Yes</asp:ListItem>
                                                          <asp:ListItem>No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                              </tr> 
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlAdequateTraining" runat="server">
                                                       
                                                           <asp:Label ID="lblAdequateNo" Text="If No, what courses/training would be beneficial :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:TextBox ID="txtAdequateNo" runat="server" Width="560px"></asp:TextBox>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              
                                              
                                               <tr>  
                                                    <td>
                                                            <asp:Label ID="lbljobDescription" Text="Is your job Description up to date : If No, Please mark up the job Description." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddljobDescription" runat="server" CssClass="Input">
                                                          <asp:ListItem>Yes</asp:ListItem>
                                                          <asp:ListItem>No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                              </tr> 
                                              
                                              
                                               <tr>  
                                                    <td>
                                                         <asp:Label ID="lblSufficientMaterials" Text="Do you have sufficient materials & equipment to adequately perform your job :" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSufficientMaterial" runat="server" CssClass="Input" 
                                                            AutoPostBack="True" 
                                                            onselectedindexchanged="ddlSufficientMaterial_SelectedIndexChanged">
                                                          <asp:ListItem>Yes</asp:ListItem>
                                                          <asp:ListItem>No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                   
                                                     
                                                       <asp:Panel ID="pnlSufficientMaterial" runat="server" Visible="False">
                                                       
                                                           <asp:Label ID="lblNoSufficientMaterial" Text="If No, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:TextBox ID="txtNoSufficientMaterial" runat="server" Width="750px"></asp:TextBox>
                                                       </asp:Panel>
                                                      
                                                     
                                                       
                                                   </td>
                                              </tr>
                                              
                                              
                                               <tr>  
                                                    <td>
                                                         <asp:Label ID="lblotherArea" Text="Are there any other areas you would like to also do in your job :" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlotherArea" runat="server" CssClass="Input">
                                                          <asp:ListItem>No</asp:ListItem>
                                                          <asp:ListItem>Yes</asp:ListItem>                                                         
                                                        </asp:DropDownList>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlotherArea" runat="server">
                                                       
                                                           <asp:Label ID="lblyesotherArea" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:TextBox ID="txtyesotherArea" runat="server" Width="750px"></asp:TextBox>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              <tr>  
                                                    <td>
                                                         <asp:Label ID="lblotherposition" Text="Is there any other position in the company you feel would be better suited :" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlotherposition" runat="server" CssClass="Input">
                                                          <asp:ListItem>No</asp:ListItem>
                                                          <asp:ListItem>Yes</asp:ListItem>                                                         
                                                        </asp:DropDownList>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlotherposition" runat="server">
                                                       
                                                           <asp:Label ID="lblyesotherposition" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:TextBox ID="txtyesotherposition" runat="server" Width="750px"></asp:TextBox>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                               <tr>  
                                                    <td height="50px" valign="bottom">
                                                            <asp:Label ID="lblCompanyEvalution" Text="2) COMPANY EVALUATION :" 
                                                                CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                              </tr>   
                                              
                                               <tr>  
                                                    <td>
                                                         <asp:Label ID="lblcurrentCompany" Text="Are you happy with the current company direction (size, growth, etc) :" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddCompanyCurrent" runat="server" CssClass="Input">
                                                          <asp:ListItem>Yes</asp:ListItem>                                                         
                                                          <asp:ListItem>No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlcurrentCompany" runat="server">
                                                       
                                                           <asp:Label ID="lblNocurrentCompany" Text="If No, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:TextBox ID="txtNocurrentCompany" runat="server" Width="750px"></asp:TextBox>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                               <tr>  
                                                    <td>
                                                         <asp:Label ID="lblcompanyArea" Text="Are there any areas that the company could be addressing to better meet client's needs, or improve sales :" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCompanyArea" runat="server" CssClass="Input">
                                                           <asp:ListItem>No</asp:ListItem>
                                                            <asp:ListItem>Yes</asp:ListItem>                                                         
                                                        </asp:DropDownList>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlYescompanyArea" runat="server">
                                                       
                                                           <asp:Label ID="lblyescompanyArea" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:TextBox ID="txtyescompanyArea" runat="server" Width="750px"></asp:TextBox>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              
                                               <tr>  
                                                    <td>
                                                         <asp:Label ID="lblcompanyidentify" Text="Can you identify any ways to improve efficiency in your job or in the company :" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlcompanyidentify" runat="server" CssClass="Input">                                                                                                                      
                                                            <asp:ListItem>No</asp:ListItem>                                    
                                                             <asp:ListItem>Yes</asp:ListItem>                     
                                                        </asp:DropDownList>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlcompanyidentify" runat="server">
                                                       
                                                           <asp:Label ID="lblYescompanyidentify" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:TextBox ID="txtyescompanyidentify" runat="server" Width="750px"></asp:TextBox>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              <tr>  
                                                    <td height="50px" valign="bottom">
                                                            <asp:Label ID="lblManagementEvalution" Text="3) MANAGEMENT EVALUATION :" 
                                                                CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                              </tr>   
                                              
                                               <tr>  
                                                    <td>
                                                         <asp:Label ID="lblmanagementneeds" Text="Are their any areas you feel the management needs improving :" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlmanagementneed" runat="server" CssClass="Input">                                                                                                                      
                                                            <asp:ListItem>No</asp:ListItem>                                    
                                                             <asp:ListItem>Yes</asp:ListItem>                     
                                                        </asp:DropDownList>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlmanagementneed" runat="server">
                                                       
                                                           <asp:Label ID="lblyesmanagementneed" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:TextBox ID="txtyesmanagementneed" runat="server" Width="750px"></asp:TextBox>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              <tr>
                                                  <td height="25px">                                                                                                       
                                                  </td>                                              
                                              </tr>                                           
                                             <tr>                                                
                                                 <td colspan="3" align="center">                                                    
                                                     
                                                     &nbsp;&nbsp;&nbsp;                                                    
                                                 </td>                                                
                                            </tr>
                             </table>
                               <asp:Panel ID="btnpanel" runat="server"  style="width:60em; margin-top:-2.2em; margin-left:2em; background: url(../Images/1397d40aa687.jpg); height:2.2em">
                               <asp:Button ID="btnAdd" runat="server" CssClass="Buttons"  style="margin-left:18em;"
                                                         Text="Add" Width="85px" onclick="btnAdd_Click"/>
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button 
                                                         ID="btnClear" runat="server" CssClass="Buttons" 
                                                         Text="Cancel" Width="85px" onclick="btnClear_Click" />
                               </asp:Panel>
                             
                <%--       </ContentTemplate>  
                </asp:UpdatePanel>      --%>
                          
                        
              </div>
          <br/>      
    </div>


</asp:Content>
