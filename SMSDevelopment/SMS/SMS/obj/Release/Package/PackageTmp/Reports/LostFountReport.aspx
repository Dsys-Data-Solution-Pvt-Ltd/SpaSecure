<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true" CodeBehind="LostFountReport.aspx.cs" Inherits="SMS.SMSUsers.Reports.LostFountReport" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        <div class="divHeader">
        <span class="pageTitle">Lost Found Report</span>
        </div> 
        <div class="btnbar" style="margin-top: 20px">
            <div class="btnbarBox">
                <ul>
                   <%-- <li>
                        <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false" OnClick="ImgView_Click">
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="View"></asp:Label></span>
                        </asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                Delete </span>
                        </asp:LinkButton>
                    </li>
                    <li>
                    <asp:LinkButton ID="imgCopy" runat="server" CausesValidation="false" OnClick="ImgView_Click">
                        <span id="spanCopy" runat="server" class="iconCopy" style="line-height: 120px;">View
                        </span>
                    </asp:LinkButton>
                </li>
                </ul>
            </div>
        </div>
               
           <div id="divAdvSearch" runat="server" visible="false">
            <br />
                                 <asp:panel runat="server" ID="Pnl" BackColor="White" 
                            style=" margin-left:1.5em; margin-top: 0px;" Font-Bold="True"  Width="750px">
            <table width="750px" class="table">                                          
                                        <tr>                                        
                                                 <td>
                                                        <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                  </td>
                                                  <td>
                                                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="130px" 
                            ForeColor="Black" onselectedindexchanged="ddllocation_SelectedIndexChanged"> 
                                                         </asp:DropDownList>
                                                         <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                                                   </td>  
                                                     <td height="20px"> 
                                                   
                                                        <asp:Label ID="lblStatus" Text="Status" CssClass="Labels" runat="server" visible=false></asp:Label>
                                                  </td>
                                                  <td>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="Labels" 
                                                            ForeColor="Black" Height="20px" Width="90px" visible=false>
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem>Lost</asp:ListItem>
                                                            <asp:ListItem>Found</asp:ListItem>
                                                           
                                                         </asp:DropDownList>
                                                         
                                                   </td>  
                                            
                                    </tr>
                                        
                                        <tr>
                                        <td>                                             
                                                    <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date:  From"></asp:Label>
                                              </td>
                                              <td>
                                                     <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                                                  
                                                       <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                  
                                                       <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender"/>
                                              </td>
                                              <td>
                                                        <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                                              </td>
                                              <td>
                                                     <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                                                  
                                                       <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                      Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                                      <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender" />
                                              </td> 
                                               
                                        </tr>
                                        <tr>
                                        <td height="50px"></td>
                                        </tr>
                                         </table>  </asp:panel>

                                        <table  width="750px" style="margin-left:1.5em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black; background-color:Gray">

                                            <tr>
                                                <td colspan="4" align="center" style="width: 750px">
                                                <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" 
                                                    onclick="btnSearch1_Click" Width="85px" />
                                           &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" 
                                                     Width="85px" onclick="btnclear_Click"  />
                                            </td>

                                        </tr>
                                        </table>
                                      
           </div>
           <div class="clear">
        </div>
        <div id="content" runat="server">
        </div>
           <br />
         <%--  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
                <%--<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
                </telerik:RadAjaxLoadingPanel>--%>
                 <asp:Panel ID="panelgrid" runat="server">
                <telerik:RadGrid ID="gvItemTable1" runat="server" CssClass="RadGrid" GridLines="None"
                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                    AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Lost_ID">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="Name" HeaderText="Name" DataField="Name" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Location" DataField="Location"
                                HeaderText="Location" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Description" DataField="Description" HeaderText="Description"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="LostStatus" DataField="LostStatus" HeaderText="Status"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="NameOfReporting" DataField="NameOfReporting" HeaderText="NameOfReporting"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>                            
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
          <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>

        <asp:HiddenField ID="hdnUpdate" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="hdnUpdate"
            CancelControlID="BtnCancelUpdate" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdate">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlUpdate" ScrollBars="Vertical" runat="server" BackColor="White"
            Height="600px" Width="750px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait83" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait83" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                    <asp:panel runat="server" ID="printview" BackColor="White" style=" margin-left:1.5em" Font-Bold="True" width="750">
            <table width="750px" class="table">            
            
            <tr>
            <td  colspan="4">
            <center>
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black; width: 702px;"></hr>
                   </center>
             </td>
            </tr>
                                            <tr>
                                                <td colspan="4" >
                                                <center>
                                                     <asp:Label ID="lblIncidentReport" Text="Lost/Found Report" CssClass="Labels" 
                                                       runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black">
                                                     </asp:Label>
                                                     </center>
                                                </td>
                                           </tr>
                                            <tr>
                                            
                                                <td>
                                                    <asp:Label ID="lblName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                <asp:Label ID="txtName1" runat="server" CssClass="Labels" runat="server" ></asp:Label>
                                                   
                                                </td>
                                            
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                    <asp:Label ID="txtLocation" runat="server" CssClass="Labels"></asp:Label>
                                                </td>
                                                </tr>
                                          </tr>
                                          <tr>  
                                                <td>
                                                    <asp:Label ID="lblDescription" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                     <asp:Label ID="txtIdescription" runat="server"  Width="570px" CssClass="Labels"></asp:Label>   
                                                </td>
                                         </tr>
                                         
                                         
                                         
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblConNo" Text="Contect No." CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtConNo" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>
                                            </tr>
                                                <tr>
                                                <td>
                                                    <asp:Label ID="lblNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                    <asp:Label ID="txtNRIC" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>  
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblDate" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="txtDate" runat="server" CssClass="Labels"></asp:Label>   
                                                     </td>
                                                                                                    
                                            </tr>
                                            <tr>                                          
                                                <td>
                                                    <asp:Label ID="lblTime" Text="Time" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:Label ID="txtTime" runat="server" CssClass="Labels"></asp:Label>   
                                                     
                                                </td>
                                                </tr>
                                            
                                             
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNameOfReporting" runat="server" CssClass="Labels" 
                                                        Text="Name Of Reporting "></asp:Label>
                                                </td>                                                
                                                <td>
                                                    <asp:Label ID="txtNameOfReporting" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                            
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" CssClass="Labels" Text="Status"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="txtStatus" runat="server" CssClass="Labels"></asp:Label>
                                                     </td>
                                                                                                    
                                            </tr>
                                             
                                            
                                           
                                    </table>
                 </asp:panel>
                    <br />
                    <div style="background-color: #E4E4E4;">
                            <center>
                            
                           <a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                                <asp:Button ID="BtnCancelUpdate" CssClass="Button" Height="30px" Width="100px" runat="server"
                                    Text="Cancel" OnClick="BtnCancelPrint_Click" />
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
                                        Are you sure to delete the record!
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



      <div>
        <asp:panel  ID="panel1" Visible="false" runat="server" Width="750px" style="margin-left:1.2em">
        <asp:GridView runat="server" ID="gvItemTable" allowpaging="True" allowsorting="True"
            autogeneratecolumns="False" cellpadding="5" width="750px"  
             PageSize="5" onpageindexchanging="gvItemTable_PageIndexChanging" 
                onrowcommand="gvItemTable_RowCommand" 
                onrowdatabound="gvItemTable_RowDataBound" 
                onselectedindexchanged="gvItemTable_SelectedIndexChanged">
             <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle CssClass="NormalRow"/>
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <SelectedRowStyle CssClass="HighlightedRow"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" Text="No record(s) in the system." runat="server">
                </asp:Label>               
            </EmptyDataTemplate>
            <Columns>           
                            <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                            <asp:BoundField DataField="Location" HeaderText="Location"></asp:BoundField>                       
                            <asp:BoundField DataField="Description" HeaderText="Description"></asp:BoundField>
                            <asp:BoundField DataField="LostStatus" HeaderText="Status"></asp:BoundField>
                            <asp:BoundField DataField="NameOfReporting" HeaderText="NameOfReporting"></asp:BoundField>                  
                            
                            <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnView" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Lost_ID") %>' runat="server"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandName="DeleteRow" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Lost_ID") %>' runat="server"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                

                       </Columns>
 


        </asp:GridView>
   </asp:panel>
     </div>
   <br/> 
     <div style=" background-color: #E4E4E4; width:100%">
      <center>
        <table style=" background-color: #E4E4E4; width:50%;" >
                <tr>
                    <td style="width: 111px">
                        <asp:Label ID="exportto" CssClass="Labels" runat="server" Text="Export To" ForeColor="#000099"
                            Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099"
                            Height="30px" Width="75px">
                            <asp:ListItem>Pdf</asp:ListItem>
                            <asp:ListItem>Word</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                    
                        <asp:Button ID="btnGo" CssClass="Button" Height="30px" Width="100px" runat="server" Text="Go" OnClick="btnGo_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnEmail" CssClass="Buttons" runat="server" Text="E-Mail" Width="85px"
                            Visible="False" />
                    </td>
                    <td>
                        <asp:Button ID="btnPrint" CssClass="Buttons" runat="server" Text="Print" Width="85px"
                             Visible="False" />
                    </td>
                </tr>
            </table></center>
     </div>
   <br/>


</asp:Content>
