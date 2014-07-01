<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="TrainingEvaluation_Master.aspx.cs" Inherits="SMS.SuperVisor.TrainingEvaluation_Master" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
             <div class="divHeader">
                <span class="pageTitle">Training Evaluation Form</span></div>
             
           
           <div id="divAdvSearch" runat="server" visible="true">  
             <div><asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                    CssClass="ValSummary"></asp:Label></div> 
                                
        <br />                     
           <table width="900px" class="table">
                                            <tr>
                                            
                                                <td>
                                                    <asp:Label ID="lblAssignment" Text="Name Of Trainee" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTraineeName" runat="server" CssClass="Input" />
                                                </td>
                                                 
                                                <td>
                                                    <asp:Label ID="lblcompletedby" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNricNumber" runat="server" CssClass="Input" />
                                                </td>
                                        </tr>   
                                       <tr> 
                                                <td>
                                                    <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date:  From"></asp:Label>
                                                </td>
                                                   <td>
                                                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" 
                                                     ></asp:TextBox>
                                                        
                                                     <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                     Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                     <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                                                    ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender"
                                                    />
                                               </td>
                                                
                                               <td>
                                                        <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                                                </td>
                                                 <td>
                                                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                                                                
                                                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                         Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                                         <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                                          ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender"
                                                         />
                                                </td>
                                             
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" Text="Venue" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtvenue" runat="server" CssClass="Input" />
                                                </td>                                            
                                            </tr>
                                            <tr>
                                                    <td height="25px"></td>                                            
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="5">
                                                    <asp:Button ID="btnSearchPassAdd" Text="Search" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnSearchPassAdd_Click"/>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearTraining" 
                                                        Text="Clear" runat="server" 
                                                         CssClass="Buttons"  Width="85px" onclick="btnClearTraining_Click"/>
                                                </td>
                                            </tr>
                                        </table>                                    
         </div>
       <br />
           <div>
            <asp:gridview id="gvPassTable" runat="server" allowpaging="True" allowsorting="True"
                autogeneratecolumns="False" cellpadding="5" width="100%" onrowdatabound="gvPass_RowDataBound"
                onrowcommand="gvPass_RowCommand" 
                cssclass="GridMain2" PageSize="20">
            
            <HeaderStyle cssclass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle cssclass="NormalRow"/>
            <AlternatingRowStyle cssclass="AlternateRow"/>
            <PagerStyle cssclass="PagingRow" horizontalalign="Right" height="20px"/>
            <SelectedRowStyle cssclass="HighlightedRow"/>
            <EmptyDataRowStyle cssclass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" text="There is no Training Evaluation Yet in System.." runat="server">
                </asp:Label>
            </EmptyDataTemplate>
            <Columns>           
                    <%--<asp:BoundField datafield="intID" headertext="ID"><HeaderStyle Width="50px"/></asp:BoundField>--%>                   
                    <asp:BoundField datafield="strNameOfTrainee" headertext="Name of Trainee"></asp:BoundField>
                    <asp:BoundField datafield="dtmDateOfEvaluation" headertext="Date"></asp:BoundField> 
                    
                                      
                 <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.intID") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                     <HeaderStyle Width="50px" />
                   <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.intID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                   <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField> 
              
            </Columns>
       </asp:gridview>
  </div>
  <br />
           <div>
                <table width="100%" class="table">
                   <tr>
                       <td>
                          <asp:button id="btnNewPass" text="New Training Evaluation" runat="server" 
                            cssclass="Buttons" onclick="btnNewPass_Click" Width="229px"/>
                       </td>
                   </tr>
                </table>
          </div>
        <br />
    </div>
</asp:Content>