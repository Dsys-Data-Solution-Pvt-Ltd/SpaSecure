<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="RiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.RiskAssessmentSurvey"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Security/ Risk Assessment Survey</span></div>
            <div>            
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
            </div>  
            <br />
            <div id="divAdvSearch" runat="server" visible="true">   
                       <table width="80%" cellspacing="5" class="table" style=" background-color:White">
                                          <tr>
                                                 <td>
                                                      <asp:Label ID="Label2" Text="Checklist Completed By:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>                                                
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtChklistCompletedBy" CssClass="Input" runat="server" 
                                                        Width="220px"></asp:TextBox>
                                                </td>
                                                
                                                 <td>
                                                        <asp:Label ID="lblEnterDate" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                            <asp:TextBox runat="server" ID="calDate" Text="" CssClass="Input"/>
                                                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="calDate" PopupButtonID="imgBtnFromDate" />
                                                            <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp"/>
                                                    </td>
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="5" valign="top">
                                                      <asp:Label ID="Label1" Text="
                                                        This survey is used to conduct risk assessment of specified client locations. Observe the physical and environmental
                                                        conditions and operational procedures at each location. Interview the appropriate client personnel to
                                                        complete the survey form. Comment on any high-risk situations as well as recommended 
                                                        actions.
                                                        " CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          
                                          </tr>
                                          
                                          <tr>
                                               <td>
                                                      <asp:Label ID="lblClientName" Text="Client Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                     <asp:TextBox ID="txtClientName" CssClass="Input" runat="server" Width="220px"></asp:TextBox>
                                                </td>
                                                <td>
                                                      <asp:Label ID="lblContactPerson" Text="Contact Person" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                     <asp:TextBox ID="txtContactPerson" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                          </tr>
                                          
                                          <tr>
                                                 <td>
                                                      <asp:Label ID="lbllocationAddress" Text="Location Address" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td colspan="2">
                                                     <asp:TextBox ID="txtlocationAddress" CssClass="Input" runat="server" 
                                                         Width="220px"></asp:TextBox>
                                                </td>
                                                <td>
                                                      <asp:Label ID="lblCity" Text="City" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td colspan="2">
                                                     <asp:TextBox ID="txtCity" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                          </tr>
                                          
                                          <tr>
                                                 <td>
                                                      <asp:Label ID="lblState" Text="State" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td colspan="2">
                                                     <asp:TextBox ID="txtState" CssClass="Input" runat="server" Width="220px"></asp:TextBox>
                                                </td>
                                                <td>
                                                      <asp:Label ID="lblZip" Text="Zip" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                     <asp:TextBox ID="txtZip" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                          </tr>
                                          <tr>      
                                                <td>
                                                      <asp:Label ID="lblPhoneNo" Text="Phone Number/s" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                     <asp:TextBox ID="txtPhoneNo" CssClass="Input" runat="server" Width="220px"></asp:TextBox>
                                                </td>
                                                
                                          </tr>
                                          
                                          
                                           <tr>
                                               <td height="25px" colspan="3"></td>
                                          </tr>
                                          
                                          
                                          <tr>
                                              <td colspan="3" height="45">
                                                 <asp:Label ID="lblheadingTypeofFaculty" Text="Section A. TYPE OF FACILITY" 
                                                      CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                         
                                          
                                           <tr>
                                               <td colspan="7">
                                                   <asp:Panel ID="panTypeofFaculty" runat="server">
                                                      <table width="80%">
                                                         <tr>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkConstruction" runat="server" CssClass="Labels" 
                                                                      Text="Construction" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkOfficePark" runat="server" CssClass="Labels" 
                                                                      Text="Office Park" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkHighRise" runat="server" CssClass="Labels" 
                                                                      Text="High-Rise" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkOfficeBldg" runat="server" CssClass="Labels" 
                                                                      Text="Office Bldg" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkHospital" runat="server" CssClass="Labels" 
                                                                      Text="Hospital" />
                                                              </td>
                                                        
                                                              
                                                        </tr>                                                         
                                                         <tr>          
                                                              
                                                              <td>
                                                                 <asp:CheckBox ID="ChkBank" runat="server" CssClass="Labels" Text="Bank" />
                                                              </td>
                                                              
                                                              <td>
                                                                   <asp:CheckBox ID="ChkGovernmentOwnedFacility" runat="server" CssClass="Labels" Text="Government Owned Facility" />
                                                              </td>
                                                              <td>
                                                                   <asp:CheckBox ID="ChkGovernementLeased" runat="server" CssClass="Labels" Text="Governement Leased" />
                                                              </td>
                                                              <td>
                                                                   <asp:CheckBox ID="ChkHotelMotel" runat="server" CssClass="Labels" Text="Hotel/Motel" />
                                                              </td>
                                                               <td>
                                                                   <asp:CheckBox ID="ChkResidential" runat="server" CssClass="Labels" Text="Residential" />
                                                              </td>
                                                         </tr>
                                                         <tr>
                                                         <td>
                                                                  <asp:CheckBox ID="ChkRetail" runat="server" CssClass="Labels" Text="Retail" />
                                                              </td>
                                                         </tr>
                                                         <tr>
                                                                <td>
                                                                      <asp:Label ID="lblfacultyOther" Text="Other" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td colspan="5">
                                                                     <asp:TextBox ID="txtFacultyOther" CssClass="Input" runat="server" Width="600px"></asp:TextBox>
                                                                </td>
                                                                
                                                          </tr>
                                                          <tr>
                                                                <td>
                                                                      <asp:Label ID="lblManufacturing" Text="Manufacturing : Hi-Tech" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td>
                                                                     <asp:DropDownList ID="ddlManufacturing" CssClass="Input" runat="server" Width="50px">
                                                                       <asp:ListItem>Yes</asp:ListItem>
                                                                       <asp:ListItem>No</asp:ListItem>                                                                       
                                                                     </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                      <asp:Label ID="lblManufacturProduct" Text="Product" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td colspan="3">
                                                                     <asp:TextBox ID="txtManufacturProduct" CssClass="Input" runat="server" 
                                                                         Width="250px"></asp:TextBox>
                                                                </td>
                                                                
                                                          </tr>
                                                          <tr>
                                                                <td>
                                                                      <asp:Label ID="lblFacultyDistribution" Text="Distribution Center : Hi-Tech" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td>
                                                                     <asp:DropDownList ID="ddlfaultyDistribution" CssClass="Input" runat="server" Width="50px">
                                                                       <asp:ListItem>Yes</asp:ListItem>
                                                                       <asp:ListItem>No</asp:ListItem>                                                                       
                                                                     </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                      <asp:Label ID="lblDistributionProduct" Text="Product" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td colspan="3">
                                                                     <asp:TextBox ID="txtDistributionProduct" CssClass="Input" runat="server" 
                                                                         Height="16px" Width="250px"></asp:TextBox>
                                                                </td>
                                                                
                                                          </tr>
                                                         
                                                         <tr>
                                                               <td>
                                                                      <asp:Label ID="lbloterDiscribe" Text="Other : Please Describe" 
                                                                          CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td colspan="5">
                                                                     <asp:TextBox ID="txtotherDiscribe" CssClass="Input" runat="server" 
                                                                         Width="600px"></asp:TextBox>
                                                                </td>
                                                                
                                                          </tr>
                                                         
                                                      
                                                      </table>
                                                   
                                                   
                                                   </asp:Panel>
                                                
                                              </td>
                                          </tr>
                                          <tr>
                                               <td height="45" colspan="3">
                                                 <asp:Label ID="Label7" Text="Section B. GENERAL ASSESSMENT" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label3" 
                                                          Text="1. Do you have a neighborhood crime statistics report from the police?" 
                                                          CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B1" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="2. Any history of labor unrest in the area?" 
                                                          CssClass="Labels" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B2" CssClass="Input" runat="server" Width="50px" 
                                                         Visible="False">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="3. Have prior tenants, or owners of your facility ever reported a criminal incident?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B3" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="4. What types of crimes are the most prevalent in the area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>     
                                                <td colspan="5">                                                                                                         
                                                    <asp:TextBox ID="B4" runat="server" CssClass="Input" Width="80%"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label8" Text="List by percentage and frequency." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>     
                                                <td colspan="5">                                                                                                         
                                                    <asp:TextBox ID="txtSectionBpercentage" runat="server" CssClass="Input" 
                                                        Width="80%"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="5. Is the facility visible from the local roads?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B5" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="6. Is there easy access by emergency vehicles to the building from the local roads?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B6" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label11" Text="7. What is the frequency of police patrols in the area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="B7" runat="server" CssClass="Input" 
                                                         Width="250px"></asp:TextBox>
                                                </td>                                       
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label12" Text="8. What is the response time of local fire and police departments?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="B8" runat="server" CssClass="Input" 
                                                         Width="250px"></asp:TextBox>
                                                </td>                                       
                                          </tr>
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label13" Text="9. What is the response time for an emergency or police vehicle to reach the facility?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="B9" runat="server" CssClass="Input" 
                                                         Width="250px"></asp:TextBox>
                                                </td>                                       
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="10. Is the an evaluation of your building’s roof and doors which details the length of time it will
                                                       take for a break-in to be successful?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B10" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="11. Is there an evaluation of the safes, locks, and other devices to ascertain how long they can
                                                        delay being opened?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B11" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="12. If separate storage of high-risk or valuable items is required, are they placed in a high security
                                                          area which will discourage intrusion?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B12" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="13. Is personnel movement within the building controlled?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B13" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label18" Text="14. Have the door and window hardware been evaluated for ease of entry?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B14" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="15. Have window openings been secured? (Check local fire and/or building codes.)" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B15" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="16. Are important files and computer operations secured in an area that prohibits unauthorized entry?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B16" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="17. Is the lighting sufficient throughout all work areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B17" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="18. Are vent and roof access panels and doors wired and latched to prevent intrusion?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B18" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="19. Have you prevented external access to locker rooms, vending and lounge areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B19" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label24" Text="20. Are the financial handling areas separate and secure?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B20" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                               <td height="65px"></td>
                                          </tr>
                                          
                            </table>    
                                           
                       <br />
                       <br />
                                    
                               <table width="100%" class="table" style=" margin-top:-2.2em; background: url(../Images/1397d40aa687.jpg); height:2.2em">           
                                            
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="btnItemAdd" runat="server" CssClass="Buttons" 
                                                        Text="Next" Width="85px" onclick="btnItemAdd_Click"/>
                                                        
                                                    <asp:Label ID="lblid" runat="server" Text="" Visible="False"></asp:Label>
                                                   <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearItemAdd" 
                                                        runat="server" CssClass="Buttons" 
                                                        Text="Cancel" Width="85px"/>--%>
                                                </td>
                                            </tr>
                                 </table>
                           <br />
                    </div>
    </div>


</asp:Content>
