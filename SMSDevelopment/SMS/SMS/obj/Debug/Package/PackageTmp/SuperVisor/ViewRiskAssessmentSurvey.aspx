<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ViewRiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.ViewRiskAssessmentSurvey"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer" >
        <div class="divHeader">
            <span class="pageTitle">Risk Assessement Survey</span></div>           
          
          <br/>
           <asp:UpdatePanel ID="uppan" runat="server" >
           <ContentTemplate>
          
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" > 
         
              <table width="100%" cellspacing="8" class="table" style=" background-color:White">
                                           
                 <tr>
                <td colspan="4" style=" height:90px;" align="center">
                <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
                </td>
                </tr>
                                          <tr>
                                                 <td>
                                                      <asp:Label ID="Label2" Text="Checklist Completed By:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>                                                
                                                <td>                                                   
                                                         <asp:Label runat="server" ID="txtCompletedBy" CssClass="Labels"></asp:Label>
                                                </td>
                                                
                                                 <td>
                                                        <asp:Label ID="lblEnterDate" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                            <asp:Label runat="server" ID="txtDate" CssClass="Labels"></asp:Label>
                                                    </td>
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4" valign="top">
                                                      <asp:Label ID="Label1" Text="
                                                        This survey is used to conduct risk assessment of specified client locations. Observe the physical and environmental
                                                        conditions and operational procedures at each location. Interview the appropriate client personnel to
                                                        complete the survey form. Comment on any high-risk situations as well as recommended actions.
                                                        " CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          
                                          </tr>
                                          
                                          <tr>
                                               <td>
                                                      <asp:Label ID="lblClientName" Text="Client Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     
                                                     <asp:Label runat="server" ID="txtClientName" CssClass="Labels"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="lblContactPerson" Text="Contact Person" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    
                                                      <asp:Label ID="txtContactPerson"  CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          
                                          <tr>
                                                 <td>
                                                      <asp:Label ID="lbllocationAddress" Text="Location Address" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                      <asp:Label ID="txtAddress" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="lblCity" Text="City" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                     <asp:Label ID="txtCity" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          
                                          <tr>
                                                 <td>
                                                      <asp:Label ID="lblState" Text="State" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                      <asp:Label ID="txtState" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="lblZip" Text="Zip" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                      <asp:Label ID="txtZip" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          <tr>      
                                                <td>
                                                      <asp:Label ID="lblPhoneNo" Text="Phone Number/s" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                      <asp:Label ID="txtPhone" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                          </tr>
                                          
                                          
                                           <tr>
                                               <td height="25px" colspan="2"></td>
                                          </tr>
                                          
                                          
                                          <tr>
                                              <td colspan="2" height="45">
                                                 <asp:Label ID="lblheadingTypeofFaculty" Text="Section A. TYPE OF FACULTY " 
                                                      CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                         
                                          
                                           <tr>
                                               <td colspan="4">
                                                   <asp:Panel ID="panTypeofFaculty" runat="server">
                                                      <table width="100%" style=" background-color:White">
                                                         <tr>
                                                              <td>                                                                 
                                                                   <asp:Label ID="ChkConstruction" CssClass="Labels" runat="server"></asp:Label>                                                                      
                                                              </td>
                                                              <td>
                                                                 
                                                                  <asp:Label ID="ChkOfficePark" CssClass="Labels" runat="server"></asp:Label> 
                                                                 
                                                              </td>
                                                              <td>
                                                                     <asp:Label ID="ChkHighRise" CssClass="Labels" runat="server"></asp:Label>                                                                      
                                                                 
                                                              </td>
                                                              <td>                                                              
                                                                     <asp:Label ID="ChkOfficeBldg" CssClass="Labels" runat="server"></asp:Label>                                                                                                                                      
                                                              </td>
                                                              <td>
                                                              
                                                                  <asp:Label ID="ChkHospital" CssClass="Labels" runat="server"></asp:Label>                                                                                                                                       
                                                                 
                                                              </td>
                                                        
                                                              <td>
                                                                   <asp:Label ID="ChkRetail" CssClass="Labels" runat="server"></asp:Label>                                                                                     
                                                                 
                                                              </td>
                                                        </tr>                                                         
                                                         <tr> 
                                                              <td>
                                                                   <asp:Label ID="ChkBank" CssClass="Labels" runat="server"></asp:Label> 
                                                              </td>                                                              
                                                              <td>
                                                                   <asp:Label ID="ChkGovernmentOwnedFacility" CssClass="Labels" runat="server"></asp:Label>                                                                  
                                                                   
                                                              </td>
                                                              <td>
                                                                    <asp:Label ID="ChkGovernementLeased" CssClass="Labels" runat="server"></asp:Label>                                                                   
                                                              </td>
                                                              <td>                                                              
                                                                   <asp:Label ID="ChkHotelMotel" CssClass="Labels" runat="server"></asp:Label>                                                              
                                                                   
                                                              </td>
                                                               <td>                                                               
                                                                    <asp:Label ID="ChkResidential" CssClass="Labels" runat="server"></asp:Label>                                                                    
                                                              </td>
                                                         </tr>
                                                         
                                                         <tr>
                                                                <td>
                                                                      <asp:Label ID="lblfacultyOther" Text="Other" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td colspan="5">
                                                                     <asp:Label ID="txtFacultyOther" CssClass="Labels" runat="server"></asp:Label>   
                                                                </td>
                                                                
                                                          </tr>
                                                          <tr>
                                                                <td>
                                                                      <asp:Label ID="lblManufacturing" Text="Manufacturing : Hi-Tech" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td>
                                                                    <asp:Label ID="txtManufacuturing" CssClass="Labels" runat="server"></asp:Label>   
                                                                </td>
                                                                <td>
                                                                      <asp:Label ID="lblManufacturProduct" Text="Product" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td colspan="3">
                                                                     <asp:Label ID="txtManufacturProduct" CssClass="Labels" runat="server"></asp:Label>   
                                                                </td>
                                                                
                                                          </tr>
                                                          <tr>
                                                                <td>
                                                                      <asp:Label ID="lblFacultyDistribution" Text="Distribution Center : Hi-Tech" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td>
                                                                     <asp:Label ID="txtFacultyDistribution" CssClass="Labels" runat="server"></asp:Label>   
                                                                </td>
                                                                <td>
                                                                      <asp:Label ID="lblDistributionProduct" Text="Product" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td colspan="3">
                                                                     <asp:Label ID="txtDistributionProduct" CssClass="Labels" runat="server"></asp:Label>   
                                                                </td>
                                                                
                                                          </tr>
                                                         
                                                         <tr>
                                                               <td>
                                                                      <asp:Label ID="lbloterDiscribe" Text="Other : Please Discribe" CssClass="Labels" runat="server"></asp:Label>
                                                                </td>
                                                                 <td colspan="5">
                                                                    <asp:Label ID="txtOtherDiscribe" CssClass="Labels" runat="server"></asp:Label>   
                                                                </td>
                                                                
                                                          </tr>
                                                         
                                                      
                                                      </table>
                                                   
                                                   
                                                   </asp:Panel>
                                                
                                              </td>
                                          </tr>
                                          <tr>
                                               <td height="45" colspan="2">
                                                 <asp:Label ID="Label7" Text="Section B. GENERAL ASSESSMENT" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label3" Text="1. Do you have a neighborhood crime statistics report from the local police?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="B1" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label4" Text="2. Any history of labor unrest in the area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="B2" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label5" Text="3. Have prior tenants, or owners of your facility ever reported a criminal incident?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="B3" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label6" Text="4. What types of crimes are the most prevalent in the area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>     
                                                <td colspan="4">                                                                                                         
                                                    <asp:Label ID="B4" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label8" Text="List by percentage and frequency." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>     
                                                <td colspan="4">                                                                                                         
                                                    <asp:Label ID="B4List" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label9" Text="5. Is the facility visible from the local roads?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="B5" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label10" Text="6. Is there easy access by emergency vehicles to the building from the local roads?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="B6" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label11" Text="7. What is the frequency of police patrols in the area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:Label ID="B7" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                       
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label12" Text="8. What is the response time of local fire and police departments?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:Label ID="B8" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                       
                                          </tr>
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label13" Text="9. What is the response time for an emergency or police vehicle to reach the facility?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:Label ID="B9" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                       
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label14" Text="10. Is the an evaluation of your building’s roof and doors which details the length of time it will
                                                       take for a break-in to be successful?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="B10" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label15" Text="11. Is there an evaluation of the safes, locks, and other devices to ascertain how long they can
                                                        delay being opened?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="B11" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label16" Text="12. If separate storage of high-risk or valuable items is required, are they placed in a high security
                                                          area which will discourage intrusion?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="B12" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label17" Text="13. Is personnel movement within the building controlled?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="B13" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label18" Text="14. Have the door and window hardware been evaluated for ease of entry?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="B14" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label19" Text="15. Have window openings been secured? (Check local fire and/or building codes.)" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="B15" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label20" Text="16. Are important files and computer operations secured in an area that prohibits unauthorized entry?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="B16" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label21" Text="17. Is the lighting sufficient throughout all work areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="B17" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label22" Text="18. Are vent and roof access panels and doors wired and latched to prevent intrusion?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="B18" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label23" Text="19. Have you prevented external access to locker rooms, vending and lounge areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="B19" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label24" Text="20. Are the financial handling areas separate and secure?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="B20" CssClass="Labels" runat="server"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                               <td height="65px"></td>
                                          </tr>
                                          
                            </table>    
       
           </asp:Panel>
           
      
        <table width="738px" style="margin-left:1.5em; height:2.2em; margin-bottom:-0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                    <td>
                   <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" style="margin-left:18em" 
                Width="110px" Height="25px" Font-Bold="True" onclick="btnprint_Click"/> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="bntnext" runat="server" CssClass="Buttons" Font-Bold="True" 
                                Height="25px" onclick="bntnext_Click" Text="Next" Width="110px" />
                            <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                            </td>
                       
                    </tr>
                </table>
            
                
                
       
        <br />   
           
     </div>
           </ContentTemplate>  
         </asp:UpdatePanel>
     
  </div>
  
 

</asp:Content>
