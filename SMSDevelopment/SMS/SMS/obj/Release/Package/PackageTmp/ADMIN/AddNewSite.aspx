<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddNewSite.aspx.cs" Inherits="SMS.ADMIN.AddNewSite"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Location</span></div>
          

             <div>
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="lblerror"></asp:Label>
             </div>
             <br />    
             <div id="divAdvSearch" runat="server" visible="true">
             <asp:Panel id="Panel" runat="server" style="margin-left:1.5em; width:58em; height:85em">
                 <AJAX:TabContainer ID="TabContainer1" runat="server"  Font-Bold="True">
                 <AJAX:TabPanel ID="TabPanel1" HeaderText="Location" runat="server"  Font-Bold="True" Font-Size="20px" Font-Names="Arial">  
                 <ContentTemplate> 
                  <table width="100%" class="table">

                   <tr>
                            <td>
                                <asp:Label ID="lblEnterLocation" Text="Location Name" CssClass="Labels" 
                                    runat="server" ></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddLocation" runat="server" CssClass="newInput" 
                                    Width="425px" />
                                <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                 Font-Size="Smaller" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    <tr>
                             <td valign="top">
                                    <asp:Label ID="lblsiteAddress" Text="Address" CssClass="Labels" 
                                        runat="server"></asp:Label>
                             </td>
                             <td>
                                    <asp:TextBox ID="txtsiteaddres" runat="server" CssClass="newInput" 
                                        Height="72px" Width="425px" TextMode="MultiLine" />
                              </td>
                        </tr>
                        <tr>
            <td>
                 <asp:Label ID="lblClientUserID" runat="server" CssClass="Labels" Text="Client UserID"></asp:Label>
            </td>
             <td>
                 <asp:TextBox ID="txtClientUserID" runat="server" CssClass="newInput" Width="425px" />
            </td>
   </tr>
    <tr>
            <td>
                 <asp:Label ID="lblClientPassword" runat="server" CssClass="Labels" Text="Client Password"></asp:Label>
            </td>
             <td>
                 <asp:TextBox ID="txtClientPassword" runat="server" CssClass="newInput" 
                     Width="425px" TextMode="Password" />
            </td>
   </tr>
   <tr>
      <td>
        <asp:Label ID="lblContractStartDate" CssClass="Labels" runat="server" Text="Start Date:"></asp:Label>
    </td>                      
             <td colspan="26">
                                                    <asp:TextBox ID="txtdatefrom" CssClass="newInput" runat="server" ontextchanged="txtdatefrom_TextChanged" 
                                                     ></asp:TextBox>
                                                        
                                                     <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                     Format="MM/dd/yyyy" TargetControlID="txtdatefrom" 
                                                        PopupButtonID="imgBtnFromDate2" Enabled="True" />
                                                     <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                                                    ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                        onclick="imgBtnFromDate2_Click" class="calender" 
                                                    />
                                               </td>
                                                
   </tr>  
   <tr>
    <td>
        <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Expiry Date:"></asp:Label>
    </td>
    <td colspan="6">
   <asp:TextBox ID="txtdateto" CssClass="newInput" runat="server" ontextchanged="txtdateto_TextChanged"></asp:TextBox>
                                                                
    <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                         Format="MM/dd/yyyy" 
            TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" Enabled="True" />
                                                         <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                                          ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                          class="calender" onclick="imgBtnFromDate3_Click" />
   </td>
 </tr>
   <tr>
    <td>
        <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="Contract Value"></asp:Label>
    </td>
    <td colspan="7">
        <asp:TextBox ID="txtContractValue" runat="server" CssClass="newInput" 
            Width="400px"/>
    </td>
 </tr> 
 <tr style=" height:4em;"><td></td></tr>
 </table>
 <table  width="101.8%" style="margin-left:-0.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
 
        <tr>
            <td colspan="5">
  
            <asp:Button ID="btnSearchLocationAdd" Text="Save" runat="server" 
            CssClass="Buttons" Width="85px" onclick="btnSearchLocationAdd_Click" style=" margin-left:225px;"/>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNextLocationAdd" Text="Next" runat="server" 
            CssClass="Buttons"  Width="85px" onclick="btnNextLocationAdd_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnClearLocationAdd" Text="Finish" runat="server" 
            CssClass="Buttons"  Width="85px" onclick="btnClearLocationAdd_Click" />
            </td>
        </tr> 

  </table>
  </ContentTemplate>
  </AJAX:TabPanel>
 <AJAX:TabPanel ID="TabPanel2" HeaderText="Finance Contact" runat="server" Font-Bold="True" Font-Size="20px" Font-Names="Arial">  
 <ContentTemplate>  
 <table width="100%" class="table">
                        
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblFinanceName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                            </td>
                            <td>
                                    <asp:TextBox ID="txtFinaceName" runat="server" CssClass="newInput" 
                                      Width="425px" />
                                
                              </td>
                        </tr>
                        
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblfinanceContactTel" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                            </td>
                            <td>
                                    <asp:TextBox ID="txtFinanceContactTel" runat="server" CssClass="newInput" 
                                                        Width="425px" />
                                <asp:regularexpressionvalidator runat="server" 
                                        errormessage="Please Enter Numeric Value!..." 
                                        ControlToValidate="txtFinanceContactTel" Font-Bold="True" Font-Size="17px" 
                                        ValidationExpression="^\d+$"></asp:regularexpressionvalidator>
                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFinanceContactMob" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtFinanceContactMob" runat="server" CssClass="newInput" Width="425px" />
                              <asp:regularexpressionvalidator runat="server" 
                                        errormessage="Please Enter Numeric Value!..." 
                                        ControlToValidate="txtFinanceContactMob" Font-Bold="True" Font-Size="17px" 
                                        ValidationExpression="^\d+$"></asp:regularexpressionvalidator>
                             
                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFinanceContactEmail" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFinanceContactEmail" runat="server" CssClass="newInput" 
                                    Width="425px" />
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFinanceContactFax" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFinanceContactFax" runat="server" CssClass="newInput" 
                                    Width="425px" />
                             </td>
                        </tr>
<tr style=" height:4em;"><td></td></tr>
 </table>
 <table  width="101.8%" style="margin-left:-0.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
 
 
            <tr>
            <td colspan="5" >
            <asp:Button ID="btnSearch1LocationAdd" Text="Save" runat="server" 
            CssClass="Buttons" Width="85px" onclick="btnSearch1LocationAdd_Click" style=" margin-left:155px;" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNext1LocationAdd" Text="Next" runat="server" 
            CssClass="Buttons"  Width="85px" onclick="btnNext1LocationAdd_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnClear1LocationAdd" Text="Finish" runat="server" 
            CssClass="Buttons"  Width="85px" onclick="btnClear1LocationAdd_Click" />

            </td>
        </tr> 
</table>
 </ContentTemplate>
 </AJAX:TabPanel>
 <AJAX:TabPanel ID="TabPanel3" HeaderText="Operations Contact" runat="server" Font-Bold="True" Font-Size="20px" Font-Names="Arial">  
 <ContentTemplate>  
 <table width="100%" class="table">
 <tr>
                            <td>
                                <asp:Label ID="lblOperationName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtOperationName" runat="server" CssClass="newInput" 
                                  Width="425px" />
                                  

                              </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblOperationsContactTele" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtOperationsContactTelephone" runat="server" CssClass="newInput" 
                                  Width="425px" />

                                   <asp:regularexpressionvalidator runat="server" 
                                        errormessage="Please Enter Numeric Value!..." 
                                        ControlToValidate="txtOperationsContactTelephone" Font-Bold="True" Font-Size="17px" 
                                        ValidationExpression="^\d+$"></asp:regularexpressionvalidator>
                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOperationsContactMobile" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtOperationsContactMobile" runat="server" CssClass="newInput" 
                                  Width="425px" />
                                   <asp:regularexpressionvalidator runat="server" 
                                        errormessage="Please Enter Numeric Value!..." 
                                        ControlToValidate="txtOperationsContactMobile" Font-Bold="True" Font-Size="17px" 
                                        ValidationExpression="^\d+$"></asp:regularexpressionvalidator>
                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOperationsContactEmail" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtOperationsContactEmail" runat="server" CssClass="newInput" 
                                    Width="425px" />
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOperationsContactFax" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOperationsContactFax" runat="server" CssClass="newInput" 
                                    Width="425px" />
                             </td>
                        </tr>
<tr style=" height:4em;"><td></td></tr>
 </table>
 <table  width="101.8%" style="margin-left:-0.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
 
 
        <tr>
            <td colspan="5">
            <asp:Button ID="btnSearch2LocationAdd" Text="Save" runat="server" 
            CssClass="Buttons" Width="85px" onclick="btnSearch2LocationAdd_Click" style=" margin-left:155px;" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNext2LocationAdd" Text="Next" runat="server" 
            CssClass="Buttons"  Width="85px" onclick="btnNext2LocationAdd_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnClear2LocationAdd" Text="Finish" runat="server" 
            CssClass="Buttons"  Width="85px" onclick="btnClear2LocationAdd_Click" />

            </td>
        </tr> 

</table>
 </ContentTemplate>
 </AJAX:TabPanel>
  <AJAX:TabPanel ID="TabPanel4" HeaderText="Management Contact " runat="server" Font-Bold="True" Font-Size="20px" Font-Names="Arial">  
 <ContentTemplate>  
 <table width="100%" class="table">
 <tr>
                            <td>
                                <asp:Label ID="lblManagementName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtManagementName" runat="server" CssClass="newInput" 
                                   Width="425px" />
                                


                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblManagementContactTelephone" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtlblManagementContactTelephone" runat="server" CssClass="newInput" 
                                   Width="425px" />

                                <asp:regularexpressionvalidator runat="server" 
                                        errormessage="Please Enter Numeric Value!..." 
                                        ControlToValidate="txtlblManagementContactTelephone" Font-Bold="True" Font-Size="13px" 
                                        ValidationExpression="^\d+$"></asp:regularexpressionvalidator>
   
                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblManagementContactMobile" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                            </td>
                            <td>
                                    <asp:TextBox ID="txtManagementContactMobile" runat="server" CssClass="newInput" 
                                     Width="425px" />
                                     <asp:regularexpressionvalidator runat="server" 
                                        errormessage="Please Enter Numeric Value!..." 
                                        ControlToValidate="txtManagementContactMobile" Font-Bold="True" Font-Size="13px" 
                                        ValidationExpression="^\d+$"></asp:regularexpressionvalidator>

                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblManagementContactEmail" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtManagementContactEmail" runat="server" CssClass="newInput" 
                                    Width="425px" />
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblManagementContactFax" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtManagementContactFax" runat="server" CssClass="newInput" 
                                    Width="425px" />
                             </td>
                        </tr>
                        <tr>
                            <td>
                              <asp:Label ID="lblEmergencyContactEmail" runat="server" CssClass="Labels" Text="Emergency Contact Email"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmergencyContactEmail" runat="server" CssClass="newInput" 
                                    Width="425px" />
                             </td>
                        </tr>
<tr style=" height:4em;"><td></td></tr>
 </table>
 <table  width="101.8%" style="margin-left:-0.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
 
 
            <tr>
            <td colspan="5">
            <asp:Button ID="btnSearch3LocationAdd" Text="Save" runat="server" 
            CssClass="Buttons" Width="85px" onclick="btnSearch3LocationAdd_Click" style=" margin-left:315px;" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnClear3LocationAdd" Text="Finish" runat="server" 
            CssClass="Buttons"  Width="85px" onclick="btnClear3LocationAdd_Click" />

            </td>
        </tr> 

</table>
 </ContentTemplate>
 </AJAX:TabPanel>
 </AJAX:TabContainer>
 </asp:Panel>        
 <table width="100%" class="table"visible="false">
           <tr>
              <td colspan="4">
                  <asp:Panel ID="Panel2" runat="server">
                     <table width="70%">
                        <tr>
                            <td>
                                <asp:Label ID="lblChiefSecurityOfficer" runat="server" CssClass="Labels" Text="Chief Security Officer Required" visible="false" /></td>
                            <td>
                                <asp:Label ID="lblChiefSecurityRequiredDay" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChiefSecurityRequiredDay1" runat="server" CssClass="newInput" Width="75px" visible="false"/>
                            </td>
                            <td>
                                <asp:Label ID="lblChiefSecurityRequiredEvening" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChiefSecurityRequiredEvening" runat="server" CssClass="newInput" Width="67px" visible="false"/>
                             </td>
                         </tr>
                         <tr>
                                <td><asp:Label ID="lblSuperVisorRequired" runat="server" CssClass="Labels" Text="Supervisor Required" visible="false"/></td>
                                <td>
                                    <asp:Label ID="lblSuperVisorRequiredDay" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsupervisorrequiredDay" runat="server" CssClass="newInput" 
                                        Width="75px" visible="false"/>
                                 </td>
                                <td>
                                    <asp:Label ID="lblSupervisorRequireNight" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSupervisorRequireNight" runat="server" CssClass="newInput" 
                                        Width="66px" visible="false"/>
                                 </td>
                          </tr>  
                            <tr>
                                <td><asp:Label ID="lblSeniorSecurity" runat="server" CssClass="Labels" Text="Senior Security Officer Required" visible="false"/></td>
                                <td>
                                    <asp:Label ID="lblSSO" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtSSODay" runat="server" CssClass="newInput" Width="75px" visible="false"/>
                                 </td>
                                 <td>
                                    <asp:Label ID="lblSSONight" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSSONight" runat="server" CssClass="newInput" Width="66px" visible="false"/>
                                 </td>
                           </tr>
                           <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" CssClass="Labels" Text="Security Officer Required" visible="false"/></td>
                                <td>
                                    <asp:Label ID="lblSODay" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSODay" runat="server" CssClass="newInput" 
                                        Width="75px" visible="false"/>
                                 </td>
                                <td>
                                     <asp:Label ID="lblSONight" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSONight" runat="server" CssClass="newInput" Width="66px" visible="false"/>
                                 </td>
                             </tr>
                     </table>
                  </asp:Panel>
         </td>    
            </tr>                
            <tr>
                <td>
                   <asp:CheckBox ID="chkoter" runat="server" Text="Others" AutoPostBack="true" 
                       CssClass="Labels" oncheckedchanged="chkoter_CheckedChanged" visible="false"/>
               </td>
           </tr>
           <tr>
         <td colspan="6">
             <asp:Panel ID="PnlOther" runat="server">
              <table width="60%">
                   <tr>
                        <td>
                            <asp:TextBox ID="txtOther1" runat="server" CssClass="newInput" visible="false"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther1_day" runat="server" CssClass="newInput" 
                                Width="75px" visible="false"/>
                         </td>
                        <td>
                             <asp:Label ID="Label6" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther1_nig" runat="server" CssClass="newInput" Width="66px" visible="false"/>
                         </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:TextBox ID="txtOther2" runat="server" CssClass="newInput" visible="false"></asp:TextBox>
                         </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther2_day" runat="server" CssClass="newInput" 
                                Width="75px" visible="false"/>
                         </td>
                        <td>
                             <asp:Label ID="Label9" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther2_nig" runat="server" CssClass="newInput" Width="66px" visible="false"/>
                         </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtOther3" runat="server" CssClass="newInput" visible="false"></asp:TextBox>
                         </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" CssClass="Labels" Text="Day Shift"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther3_day" runat="server" CssClass="newInput" 
                                Width="75px" visible="false"/>
                         </td>
                        <td>
                             <asp:Label ID="Label12" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther3_nig" runat="server" CssClass="newInput" Width="66px" visible="false"/>
                         </td>
                    </tr>
                  </table>  
          </asp:Panel>
     </td>
      </tr>
</table>
 </div>    
     
  <br />      
</div>
</asp:Content>
