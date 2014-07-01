<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true" CodeBehind="EventPlan.aspx.cs" Inherits="SMS.SMSAdmin.EventPlan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">

    function PrintGridData() {
        var prtGrid = document.getElementById('<%=printview.ClientID %>');

        //window.print();
        prtGrid.border = 0;
        //GridView1.Attributes(style) = "page-break-after:always"         
        var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        prtwin.document.write(prtGrid.outerHTML);
        prtwin.document.close();
        prtwin.focus();
        prtwin.print();
        prtwin.close();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="panelgrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="panelgrid" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>
      <div class="divHeader"><span class="pageTitle">Event Planner</span></div>
       <div class="btnbar" style="margin-top: 20px">

            <div class="btnbarBox">
                <ul>
                   <%-- <li>
                        <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="ImgAdd_Click">
                            <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                                <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false" OnClick="ImgUpdate_Click">
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="Update"></asp:Label></span>
                        </asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                Delete </span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgCopy" runat="server" CausesValidation="false" OnClick="ImageView">
                            <span id="spanCopy" runat="server" class="iconCopy" style="line-height: 120px;">View
                            </span>
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
        <div class="clear">
        </div>
    <div id="content" runat="server">
    <asp:Panel ID="panelgrid" runat="server">
      <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server" >
            <ContentTemplate>--%>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
            </telerik:RadAjaxLoadingPanel>

            <telerik:RadGrid ID="gvNewEventSearch" runat="server" CssClass="RadGrid" GridLines="None"
                HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                AllowFilteringByColumn="true">
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Event_ID">
                    <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                    
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                            AllowFiltering="false">
                           
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                    AutoPostBack="True" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="Date_From" DataField="Date_From" HeaderText="Start Date"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Date_To" DataField="Date_To" HeaderText="End Date"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="End_time" DataField="End_time" HeaderText="End Time"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Event_Type" DataField="Event_Type" HeaderText="Type" CurrentFilterFunction="Contains"
                            AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Incharg_Name" DataField="Incharg_Name" HeaderText="Person Incharge"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Special_Requirment" DataField="Special_Requirment" HeaderText="Special Requirment"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Guard_Requirment" DataField="Guard_Requirment" HeaderText="Guard Requirment"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        
                    </Columns>
                    <NoRecordsTemplate>
                    <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                    </NoRecordsTemplate>
                    
                </MasterTableView>
                
                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
            </telerik:RadGrid>

            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>
        <asp:HiddenField ID="hdnView" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupView" runat="server" TargetControlID="hdnView"
            CancelControlID="btnCancelView" BackgroundCssClass="modalBackground" PopupControlID="pnlView">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlView" runat="server" BackColor="White" Height="500px"
            Width="750px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait82" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait82" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                  
                    <center>
                        <asp:panel runat="server" ID="printview" BackColor="White" 
                            >
                          
            <table width="700px">
                <tr>
            <td colspan="4">
            <center>
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black; width: 690px;"></hr>
                   </center>
             </td>
            </tr>
                    <tr>
                        <td colspan="4">
                        <center>
                            <asp:Label ID="lblIncidentReport" Text="Event Report" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLocation" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Location"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtLocation" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbleventtype" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Event Type"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txteventtype" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblgaurdreq" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Number of Guards Required "></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtgaurdreq" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" Text="Event ID" CssClass="Reportcolor" runat="server"
                                Font-Bold="True" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventID1" CssClass="Reportcolor" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblspecialreq" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Special Requirement"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtspecialreq" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbldutyforgaurd" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Any Special Duty for Guard"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtdutygaurd" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEventDate" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Event Date :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventdate" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:Label ID="lblEventDateTo" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="To Date :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventDateTo" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEventstartTime" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Event Start Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventstartTime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEventEndTime" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="End Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventEndTime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="55">
                            <asp:Label ID="Label3" CssClass="Reportcolor" Font-Bold="True" runat="server" Text="Person In Charge: Contact Details"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblpersonNRIC" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="NRIC No."></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtpersonNRIC" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEnterName" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Name"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEnterName" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEnterContactno" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Contact No."></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtContactNo" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPosition" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Position"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtPosition" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCreatedBy" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Created By:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtCreatedBy" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                          <td colspan="2"></td>
                    </tr>
                 
                </table>
                        </asp:panel>
                        <br />
                        <div style="background-color:#E4E4E4; width:700px;">
                        <center>
                      <a id="print" href="~/Reports/printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                                       <%--  <asp:Button ID="Button2" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Print" OnClientClick="javascript:PrintGridData();"/>--%>

                                         <asp:Button ID="btnCancelView" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="btnCancelView_Click" />
                                        </center>
                        
                        
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>


        <asp:HiddenField ID="hdnDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="hdnDelete"
            CancelControlID="btnCancelDelete" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlDelete" runat="server" BackColor="White" Height="200px" Width="320px"
            BorderWidth="2px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress5" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel13">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait5" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait5" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                   
                    <center>
                        <br />
                        <div>
                            <table width="290px" style="height: 170px">
                                <tr>
                                    <td>
                                        Are you sure you want to delete the record!
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <center>
                                            <asp:Button ID="BtnDeleteYes" OnClick="Deletepopup_Yes_Click" CausesValidation="false"
                                                Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                            <asp:Button ID="btnCancelDelete" Text="No" runat="server" CausesValidation="false"
                                                OnClick="btnCancelDelete_Click" CssClass="Button" Style="margin-left: 10px" Height="30px"
                                                Width="100px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
     </div>





     <div id="divAdvSearch" runat="server" visible="false">
      <br /> 
       <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750px">
            <table width="750px" class="table">
            <tr><td height="10"></td></tr>
                 <tr>                   
                   <td>
                       <asp:Label ID="lblLocation1" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                   </td>
                   <td>
                       <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels"> 
                       </asp:DropDownList>
                       <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                   </td>
                   <td>
                        <asp:Label ID="lblEventType1" CssClass="Labels" runat="server" Text="Event Type"></asp:Label>
                   </td>
                   <td>
                       <asp:DropDownList ID="DropDownList2" runat="server" CssClass="Labels" 
                            >
                       </asp:DropDownList>
                   </td>
                    <td>
                            <asp:Label ID="lbleventid" CssClass="Labels" runat="server" Text="Event ID" Visible="false"></asp:Label>
                     </td>
                     <td>
                          <asp:TextBox runat="server" ID="txteventid" Text="" CssClass="Input" Visible="false"/>
                      </td>
             
              
            </tr>
                 <tr>
                    <td align="left">
                        <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date:  From"></asp:Label>
                    </td>
                       <td>
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" 
                         ontextchanged="txtdatefrom_TextChanged"></asp:TextBox>
                            
                         <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                         Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                         <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                        ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                        onclick="imgBtnFromDate2_Click" class="calender"/>
                   </td>
                    
                   <td align"right" align="left">
                            <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                    </td>
                     <td>
                            <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" 
                                ontextchanged="txtdateto_TextChanged"></asp:TextBox>
                                    
                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                             Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                             <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                              ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                              onclick="imgBtnFromDate3_Click" class="calender"/>
                    </td>
               </tr>  
                 
               <tr>
                    <td height="30px"></td>
               </tr> 
               </table>
            <table  width="750px" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                <tr>
                   <td colspan="4" align="center" width="750px">
                   <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" 
                       onclick="btnSearch1_Click" Width="85px" />
               &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="btnCanel" CssClass="Buttons" runat="server" Text="Clear" 
                        Width="85px" onclick="btnCanel_Click" />
               </td>  
            </tr>
            
          </table>
       </asp:panel>   
    </div>
          <div style=" margin-left:1.5em; width:750px">
    <%--<asp:GridView ID="gvNewEventSearch" 
            runat="server" 
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="5" Width="750px"
            OnRowDataBound="gvNewEvent_RowDataBound" 
            OnRowCommand="gvNewEvent_RowCommand" 
            OnPageIndexChanging="gvNewEvent_PageIndexChanging" CssClass="GridMain2" 
         onselectedindexchanged="gvNewEvent_SelectedIndexChanged" PageSize="100">
            
            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle CssClass="NormalRow"/>
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <SelectedRowStyle CssClass="HighlightedRow"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                
            </EmptyDataTemplate>
            

            <Columns>
            
                    <asp:BoundField DataField="Date_From" HeaderText="Start Date"></asp:BoundField>
                    <asp:BoundField DataField="Date_To" HeaderText="End Date"></asp:BoundField>
            
                    <asp:BoundField DataField="Start_time" HeaderText="Start Time"></asp:BoundField>
                    <asp:BoundField DataField="End_time" HeaderText="End Time"></asp:BoundField>
                    
                    
                    <asp:BoundField DataField="Event_Type" HeaderText="Type"></asp:BoundField>
                 
               
                    <asp:BoundField DataField="Incharg_Name" HeaderText="Person Incharge"></asp:BoundField>
                    <asp:BoundField DataField="Special_Requirment" HeaderText="Special Requirment"></asp:BoundField>
                    <asp:BoundField DataField="Guard_Requirment" HeaderText="Guard Requirment"></asp:BoundField>
              
               
                 <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>' CommandName="View" runat="server"/>
                    </ItemTemplate>

            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                
                   <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>

             <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField> 
            </Columns>
    </asp:GridView>--%>

      <%--<div class="table">
         <table>
         <tr><td>          
               <asp:Button ID="btnAddNewEvent" CssClass="Buttons" runat="server" Text="Add New Event" onclick="btnAddNewEvent_Click" Visible="False" />
        </td></tr>
        </table>
        </div>--%>
  </div>
</asp:Content>
