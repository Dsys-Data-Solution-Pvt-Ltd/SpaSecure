<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="View13RiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.View13RiskAssessmentSurvey"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer" >
        <div class="divHeader">
            <span class="pageTitle">Risk Assessment Survey</span></div>  
          <br/>
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
                                                <td colspan="4">
                                                      <asp:Label ID="Label3" Text="23. Are the weapons kept in arms racks and adequately secured when not in use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="T23" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           
                                           <tr>     
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="24. Are ammunition supplies properly secured and issued only for authorized purposes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                               <td>
                                                     <asp:Label ID="T24" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                  
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="25. Is each member of the guard force required to complete a course of basic training and take
                                                        periodic courses of in-service of advanced training?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                      <asp:Label ID="T25" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                 
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="26. Are the subjects included in the carious training courses adequate?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T26" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="Label25" Text="27.Does the training cover:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr> 
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="a. Hand-to-hand combat" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27a" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="b. Care and use of weapons" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27b" runat="server" CssClass="Labels"></asp:Label>
                                                 </td>   
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="c. Common forms of pilferage, theft, and sabotage activity" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T27c" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="d. Types of bombs and explosives" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27d" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="e. Location of hazardous materials and processes" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27e" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="f. Location and use of fire protective equipment, including sprinkler control valves" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T27f" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="g. Location and operation of all important steam and gas valves and main electrical switches" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27g" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="h. Conditions which may cause fire and explosions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27h" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="i. Location and use of first aid equipment" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27i" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="j. Duties in the event of fire, explosion, natural disaster and/or civil disturbance" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T27j" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label35" Text="k. Use of communication systems" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T27k" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label36" Text="l. Proper methods of search" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27l" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="m. Observation and description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T27m" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label38" Text="n. Patrol work" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27n" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label41" Text="o. Supervision of visitors" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27o" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label42" Text="p. Preparation of written reports" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T27p" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="q. General and special guard orders" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T27q" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="r. Authority to use force, conduct searches, and make arrests" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T27r" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="28. Are periodic examinations conducted to ensure maintenance of guard training standards?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T28" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="29. Are activities of the guard force in consonance with established policy?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T29" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="30. Is supervision of the guard force adequate?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T30" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label2" Text="31. Are general and special orders properly posted?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T31" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="32. Are guard orders reviewed at least semiannually to ensure applicability?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T32" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label8" Text="33. Are periodic inspections and examinations conducted to determine the degree of
                                                    understanding and compliance with all guard orders?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T33" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label26" Text="34. Do physical, functional, or other changes at the installation indicate the necessity for,
                                                        or feasibility of:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="a. Establishing additional guard posts" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T34a" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label13" Text="b. Discontinuing any exiting posts or patrols" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T34b" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label18" Text="35. Is two-way radio equipment installed on guard patrol cars?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T35" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label24" Text="36. Are duties other than those related to security performed by guard personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T36" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                         <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label27" Text="37. Are guard patrol cars equipped with spotlights?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T37" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label28" Text="38. Does each guard on patrol duty carry a flashlight?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T38" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label29" Text="39. Do guards record or report their presence at key points in the installation by means of:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          <tr>   
                                                <td colspan="4">
                                                      <asp:Label ID="Label39" Text="a. Portable watch clocks" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                             
                                                <td>
                                                     <asp:Label ID="T39a" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label30" Text="b. Central watch clocks" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T39b" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label31" Text="c. Telephones" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T39c" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label32" Text="d. Two-way radio equipment" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="T39d" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label33" Text="40. Are guard assignments and patrol routes varied at frequent intervals to obviate
                                                        an established routine?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="T40" runat="server" CssClass="Labels"></asp:Label>
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
                Width="110px" Height="35px" Font-Bold="True" onclick="btnprint_Click"/>                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                
               <asp:Button ID="bntnext" runat="server" CssClass="Buttons" Text="Next" 
                Width="110px" Height="35px" Font-Bold="True" onclick="bntnext_Click"/>   
                
           <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>   
      </td>
                       
    </tr>
     </table>   
        <br />   
           
     </div>
  </div>

</asp:Content>
