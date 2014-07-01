<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddNewTraining.aspx.cs" Inherits="SMS.ADMIN.AddNewTraining" Title="Add New Training" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Training</span></div>
             <div>
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
             </div>
             <br />
            
             <table width="100%" class="table">
                        <tr>
                            <td style="width: 107px">
                                <asp:Label ID="lbltraingType" Text="Training Topic" CssClass="Labels" 
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttraingType" runat="server" CssClass="Input" 
                                    Width="200px" />
                                <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                 Font-Size="Smaller" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        
                        
                         <tr>        
                              <td align="left" style="width: 87px">
                                     <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Start Date"></asp:Label></td>
                              <td>
                                   <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                                                        
                              <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                               <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                              ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                             </td>
                     </tr>
                     <tr>                           
                             <td style="width: 87px">
                                   <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="End Date"></asp:Label></td>
                            <td>
                                  <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                                                                
                                  <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                  Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                  <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                             </td>
                    </tr>
                        
                        
                        
                        <tr>
                                <td style="width: 87px">
                                    <asp:Label ID="lblVenue" Text="Venue" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVenue" runat="server" CssClass="Input" Width="200px" />
                                </td>
                        </tr>
                        
                         <tr>
                                <td style="width: 87px">
                                    <asp:Label ID="lblfacilitation" Text="Facilitator" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfacilitation" runat="server" CssClass="Input" Width="200px" />
                                </td>
                        </tr>
                        
                        <tr>
                                <td valign="top" style="width: 87px">
                                    <asp:Label ID="lblTrainees" Text="Trainees" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTrainees" runat="server" CssClass="Input" Width="700px" 
                                        Height="32px" TextMode="MultiLine" />
                                    <asp:DropDownList ID="ddltrainees" runat="server" CssClass="Input" 
                                        onselectedindexchanged="ddltrainees_SelectedIndexChanged"                                         
                                        style="top: 122px; left: 128px; position: absolute; height: 22px; width: 77px; bottom: 74px; right: 302px;" 
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                        </tr>
                        
                        <tr>
                            <td style="width: 87px; height: 126px">
                                <asp:Panel ID="pnltrainees" runat="server" CssClass="Input" 
                                    
                                    
                                    style="top: 144px; left: 90px; position: absolute; height: 95px; width: 703px" 
                                    ScrollBars="Auto">
                                    <asp:GridView ID="GridViewTrainee" runat="server" 
                                        CssClass="Input" ondatabound="GridViewTrainee_DataBound" 
                                        onrowcreated="GridViewTrainee_RowCreated" Height="16px">
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                         </tr>
                        <tr>
                                <td valign="top" style="width: 87px; height: 81px">
                                    <asp:Label ID="lblTraineeDetail" Text="Details" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td style="height: 81px">
                                    <asp:TextBox ID="txtTraineeDetail" runat="server" CssClass="Input" Width="700px" 
                                        Height="85px" TextMode="MultiLine" />
                                </td>
                        </tr>
                        
                        
                        
                        

                         <tr>
                            <td height="35" style="width: 87px">
                               
                            </td>
                         
                         </tr>
                         
                         <tr>
                                    <td colspan="4" align="center">
                                    <asp:Button ID="btnAddTraining" Text="Save" runat="server" 
                                    CssClass="Buttons" Width="85px" onclick="btnAddTraining_Click"/>
                                    &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearTraining" Text="Cancel" runat="server" 
                                    CssClass="Buttons"  Width="85px" onclick="btnClearTraining_Click" /> </td>
                         </tr>
                    </table>
              
        <br />      
</div>


</asp:Content>
