<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="EventAlert.aspx.cs" Inherits="SMS.SMSUsers.EventAlert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="divContainer">
  <div class="divHeader"><span class="pageTitle">Event Scheduling</span></div>
       
 <br /><br /><br />
 <div>
        <asp:gridview id="gvItemTable" runat="server"
            allowpaging="True" allowsorting="True"
            autogeneratecolumns="False" cellpadding="5" width="100%" HeaderStyle-HorizontalAlign="Center"
            onrowdatabound="gvItem_RowDataBound"
            onrowcommand="gvItem_RowCommand" 
            onpageindexchanging="gvItem_PageIndexChanging"
            cssclass="GridMain" 
            onselectedindexchanged="gvItemTable_SelectedIndexChanged">
            
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
                <li>To add Billing Table click the Add New Item Code.</li>
            </EmptyDataTemplate>
            <Columns>
                    
                    <asp:BoundField DataField="Date_From" HeaderText="Start Date"></asp:BoundField>
                    <asp:BoundField DataField="Date_To" HeaderText="End Date"></asp:BoundField>
            
                    <asp:BoundField DataField="Start_time" HeaderText="Start Time"></asp:BoundField>
                    <asp:BoundField DataField="End_time" HeaderText="End Time"></asp:BoundField>
            
                  <%--  <asp:BoundField DataField="Event_ID" HeaderText="Event ID"></asp:BoundField>--%>
                    <asp:BoundField DataField="Event_Type" HeaderText="Event Type"></asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Location"></asp:BoundField>
                  
                    <asp:BoundField DataField="Incharg_Name" HeaderText="Person Incharge"></asp:BoundField>
                    <asp:BoundField DataField="Superior_Name" HeaderText="Supervisor Name"></asp:BoundField>
                   
                  
                   
                   
               
                
                <%-- <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>

                <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField> --%>
                
            </Columns>
    </asp:gridview>
 
  </div>
  <br/>
  <br/>
  <div>
        <asp:Button ID="btnSearch" CssClass="Buttons" runat="server" Text="Back To Home" 
            onclick="btnSearch_Click"  />       
  </div>
 <br/>
</div>

</asp:Content>
