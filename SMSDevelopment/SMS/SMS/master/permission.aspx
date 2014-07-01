<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="permission.aspx.cs" Inherits="Web.permission" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style=" margin-top:-5em;background-color:#D0E2F0;height:2em;width:60.2em; margin-left:-0.5em">
            <asp:Label ID="dllshift" runat="server" Text="Label" Visible="false"></asp:Label>
              <asp:Label ID="staffcount" runat="server" Text="" Visible="false"></asp:Label>
            <span class="pageTitle">Permission</span>
</div>
    <html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>

 </head>
<script>

    var rptcont = 0; var Eventyemgmtcont = 0; var shiftmgmtcont = 0; var Shiftdepcont = 0; var asslocationcont = 0; var locationmgmtcont = 0; var inventrycont = 0; var tranningcont = 0; var previsitorcont = 0; var chkinoutcont = 0; var feedbackcont = 0;
    var ditdiarycont = 0; var viewreportcont = 0; var alertcont = 0; var followupcont = 0; var dashcont = 0; var maintenancecont = 0; var emergencycont = 0; var sopcont = 0; var staffmgmtcont = 0; var creportcont = 0; var permissioncount = 0; var ipcameracount = 0; var asscount = 0;
    var pddcount = 0; var mppdcount = 0; var logsettingcount = 0; var accsettingcount = 0; var logoutcount = 0; var gpsystemcount = 0; var facilitycount = 0; var feedcount = 0;

    var array = new Array("mpddDiv2", "logsettingDiv2", "accsettingDiv2", "logoutDiv2", "facilityDiv2", "permissionDiv2", "creportDiv2", "staffmgmtDiv2", "sopDiv2", "emergencyDiv2", "maintenanceDiv2", "dashDiv2", "followupDiv2", "alertrptDiv2", "viewreportDiv2", "ditdiaryDiv2", "chkinoutDiv2", "eveDiv2", "shfDiv2", "ShiftdepDiv2", "asslocationDiv2", "locationmgmtDiv2", "inventryDiv2", "child");
    //-----------------report function start-----------------------/
    function report() {

        if (rptcont == 0) {
            rptcont = 1; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++) {
                if (array[i] == "child") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (rptcont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++)
            { document.getElementById(array[i]).style.display = "none"; }
        }
    }
    function Eventyemgmt() {

        if (Eventyemgmtcont == 0) {
            //----------------------------------------------------
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 1; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;

            //-----------------------------------------------------   
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "eveDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
            //----------------------------------------------------------
        }
        else if (Eventyemgmtcont == 1) {
            //----------------------------------------------
            rptcont = 1; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;

            //----------------------------------------
            for (var i = 0; i < array.length; i++)
            { document.getElementById(array[i]).style.display = "none"; }
        }
    }
    //-----------------end event function-----------------------/
    //-----------------shift function start-----------------------/
    function Shift() {

        if (shiftmgmtcont == 0) {
            shiftmgmtcont = 1; Shiftdepcont = 0; rptcont = 0; asslocationcont = 0; Eventyemgmtcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "shfDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (shiftmgmtcont == 1) {
            shiftmgmtcont = 0; Shiftdepcont = 0; rptcont = 0; asslocationcont = 0; Eventyemgmtcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end shift function-----------------------/
    //-----------------shiftdep function start-----------------------/
    function Shiftdep() {

        if (Shiftdepcont == 0) {
            Shiftdepcont = 1; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "ShiftdepDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (Shiftdepcont == 1) {
            Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
            emergencycont = 0;
            sopcont = 0; staffmgmtcont = 0; creportcont = 0;
            permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
            logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++)
            { document.getElementById(array[i]).style.display = "none"; }

        }
    }
    //-----------------end shiftdep function-----------------------/
    //-----------------asslocation function start-----------------------/
    function asslocation() {

        if (asslocationcont == 0) {
            Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 1; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
            emergencycont = 0;
            sopcont = 0; staffmgmtcont = 0; creportcont = 0;
            permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
            logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++) {
                if (array[i] == "asslocationDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (asslocationcont == 1) {
            Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
            emergencycont = 0;
            sopcont = 0; staffmgmtcont = 0; creportcont = 0;
            permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
            logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++)
            { document.getElementById(array[i]).style.display = "none"; }
        }
    }
    //-----------------end assloc function-----------------------/
    //-----------------location function start-----------------------/
    function locationmgmt() {

        if (locationmgmtcont == 0) {

            Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 1; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
            emergencycont = 0;
            sopcont = 0; staffmgmtcont = 0; creportcont = 0;
            permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
            logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++) {
                if (array[i] == "locationmgmtDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }


        }
        else if (locationmgmtcont == 1) {
            Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
            emergencycont = 0;
            sopcont = 0; staffmgmtcont = 0; creportcont = 0;
            permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
            logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++)
            { document.getElementById(array[i]).style.display = "none"; }
        }
    }
    //-----------------end location function-----------------------/
    //-----------------inventry function start-----------------------/
    function inventry() {

        if (inventrycont == 0) {
            Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 1; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
            emergencycont = 0;
            sopcont = 0; staffmgmtcont = 0; creportcont = 0;
            permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
            logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++) {
                if (array[i] == "inventryDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (inventrycont == 1) {
            Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
            emergencycont = 0;
            sopcont = 0; staffmgmtcont = 0; creportcont = 0;
            permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
            logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++)
            { document.getElementById(array[i]).style.display = "none"; }
        }
    }
    //-----------------end inventry function-----------------------/
    //-----------------tranning function start-----------------------/
    /*function tranning() {

    if (tranningcont == 0) {
    Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 1;
    previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
    emergencycont = 0;
    sopcont = 0; staffmgmtcont = 0; creportcont = 0;
    permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
    logoutcount = 0; facilitycount = 0; feedcount = 0;
    for (var i = 0; i < array.length; i++) {
    if (array[i] == "tranningDiv2") { document.getElementById(array[i]).style.display = "block"; }
    else { document.getElementById(array[i]).style.display = "none"; }
    }

    }
    else if (tranningcont == 1) {
    Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
    previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
    emergencycont = 0;
    sopcont = 0; staffmgmtcont = 0; creportcont = 0;
    permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
    logoutcount = 0; facilitycount = 0; feedcount = 0;
    for (var i = 0; i < array.length; i++) {
    document.getElementById(array[i]).style.display = "none";
    }
    }
    }*/
    //-----------------end tranning function-----------------------/
    //-----------------previsitor function start-----------------------/
    /*function previsitor() {

    if (previsitorcont == 0) {
    Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
    previsitorcont = 1; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
    emergencycont = 0;
    sopcont = 0; staffmgmtcont = 0; creportcont = 0;
    permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
    logoutcount = 0; facilitycount = 0; feedcount = 0;
    for (var i = 0; i < array.length; i++) {
    if (array[i] == "previsitorDiv2") { document.getElementById(array[i]).style.display = "block"; }
    else { document.getElementById(array[i]).style.display = "none"; }
    }
    }
    else if (previsitorcont == 1) {
    Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
    previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
    emergencycont = 0;
    sopcont = 0; staffmgmtcont = 0; creportcont = 0;
    permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
    logoutcount = 0; facilitycount = 0; feedcount = 0;
    for (var i = 0; i < array.length; i++) {
    document.getElementById(array[i]).style.display = "none";
    }
    }
    }*/
    //-----------------end previsit function-----------------------/
    //-----------------checkinout function start-----------------------/
    function chkinout() {

        if (chkinoutcont == 0) {
            Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 1; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
            emergencycont = 0;
            sopcont = 0; staffmgmtcont = 0; creportcont = 0;
            permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
            logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++) {
                if (array[i] == "chkinoutDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (chkinoutcont == 1) {
            Shiftdepcont = 0; rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0; maintenancecont = 0;
            emergencycont = 0;
            sopcont = 0; staffmgmtcont = 0; creportcont = 0;
            permissioncount = 0; ipcameracount = 0; asscount = 0; pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0;
            logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end checkinout function-----------------------/
    //-----------------feedback function start-----------------------/
    /*function feedback() {

    if (feedbackcont == 0) {
    rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
    previsitorcont = 0; chkinoutcont = 0; feedbackcont = 1; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
    maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
    pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
    for (var i = 0; i < array.length; i++) {
    if (array[i] == "feedbackDiv2") { document.getElementById(array[i]).style.display = "block"; }
    else { document.getElementById(array[i]).style.display = "none"; }
    }

    }
    else if (feedbackcont == 1) {
    rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
    previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
    maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
    pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
    for (var i = 0; i < array.length; i++) {
    document.getElementById(array[i]).style.display = "none";
    }
    }
    }*/
    //-----------------end feedback function-----------------------/
    //-----------------ditdiary function start-----------------------/
    function ditdiary() {

        if (ditdiarycont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 1; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "ditdiaryDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (ditdiarycont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end ditdiay function-----------------------/
    //-----------------viewreport function start-----------------------/
    function viewreport() {

        if (viewreportcont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 1; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "viewreportDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }


        else if (viewreportcont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end viewreport function-----------------------/
    //-----------------alertrpt function start-----------------------/
    function alertrpt() {

        if (alertcont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 1; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "alertrptDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (alertcont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end alert function-----------------------/
    //-----------------folowup function start-----------------------/
    function followup() {

        if (followupcont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 1; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "followupDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (followupcont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end followup function-----------------------/
    //-----------------dash function start-----------------------/
    function dash() {

        if (dashcont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 1;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "dashDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (dashcont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end dash board function-----------------------/
    //-----------------maintenance function start-----------------------/
    function maintenance() {

        if (maintenancecont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 1; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "maintenanceDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (maintenancecont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end maintenance function-----------------------/
    //-----------------sop function start-----------------------/
    function sop() {

        if (sopcont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 1; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "sopDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (sopcont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end sop function-----------------------/
    //-----------------emergency function start-----------------------/
    function emergency() {

        if (emergencycont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 1; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "emergencyDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (emergencycont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end emergency function-----------------------/
    //-----------------shaffmgmt function start-----------------------/
    function staffmgmt() {

        if (staffmgmtcont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 1; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "staffmgmtDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (staffmgmtcont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end staffmgmt function-----------------------/
    //-----------------creatrpt function start-----------------------/
    function creport() {

        if (creportcont == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 1; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "creportDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (creportcont == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    //-----------------end createrpt function-----------------------/
    //-----------------permission function start-----------------------/
    function permission() {
        if (permissioncount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 1; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "permissionDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (permissioncount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    function ipcamera() {
        if (ipcameracount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 1; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "ipcameraDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (ipcameracount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    function ass() {
        if (asscount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 1;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "assDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (asscount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }

        }
    }
    function pdd() {
        if (pddcount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 1; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "pddDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (pddcount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    function mppd() {
        if (mppdcount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 1; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "mpddDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (mppdcount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    function logsetting() {
        if (logsettingcount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 1; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "logsettingDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (logsettingcount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    function accsetting() {
        if (accsettingcount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 1; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "accsettingDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (accsettingcount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;

            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    function gpsystem() {
        if (gpsystemcount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 1; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "gpsystemDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (gpsystemcount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    function logout() {
        if (logoutcount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 1; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "logoutDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }

        }
        else if (logoutcount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }
        }
    }
    function facility() {
        if (facilitycount == 0) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 1; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] == "facilityDiv2") { document.getElementById(array[i]).style.display = "block"; }
                else { document.getElementById(array[i]).style.display = "none"; }
            }
        }
        else if (facilitycount == 1) {
            rptcont = 0; shiftmgmtcont = 0; Eventyemgmtcont = 0; Shiftdepcont = 0; asslocationcont = 0; locationmgmtcont = 0; inventrycont = 0; tranningcont = 0;
            previsitorcont = 0; chkinoutcont = 0; feedbackcont = 0; ditdiarycont = 0; viewreportcont = 0; alertcont = 0; followupcont = 0; dashcont = 0;
            maintenancecont = 0; emergencycont = 0; sopcont = 0; staffmgmtcont = 0; creportcont = 0; permissioncount = 0; ipcameracount = 0; asscount = 0;
            pddcount = 0; mppdcount = 0; logsettingcount = 0; accsettingcount = 0; gpsystemcount = 0; logoutcount = 0; facilitycount = 0; feedcount = 0;
            for (var i = 0; i < array.length; i++) {
                document.getElementById(array[i]).style.display = "none";
            }


        }
    }
    



</script>    
    
 <asp:Panel ID="masterpanel"  runat="server" BackColor="white" Width="720" Height="32em" style="margin-left:2em; margin-top:0em">
 
 <asp:Label ID="Label12" runat="server" BackColor="white"
   Forecolor="Blue"   style="left: -6px;"
 Text="Set User Role Permission" Visible="false"></asp:Label>
 
<asp:Panel ID="Panel1" runat="server" BackColor="White" ScrollBars="Auto" 
style="top:1.3em;left:400px; position: absolute;height:400px; width: 320px">
<!---------------report start-------------------------------->
<div id="report" class="report" onclick="report()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="report1" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"></asp:Label></div>
<div id="child"  style=" width:440px; height:505px;display:none;border:1px solid #CCC">
<asp:Label ID="Label4" runat="server" Text="" ForeColor="Black"  Width="440px" Height="20px" BackColor="#FFCCFF" style="font-family:Arial Verdana; font-weight:500; letter-spacing:0em; font-size:18px"></asp:Label>
<asp:UpdatePanel ID="upanel2" runat="server">
<ContentTemplate>
<asp:CheckBox ID="inReadOnly" runat="server" ForeColor="Black" 
        style="top: 42px; left: 191px; position: absolute; height: 21px; width: 186px" 
        Text="ReadOnly" />
<asp:CheckBox ID="lostWriteOnly" runat="server" ForeColor="Black" style="top: 225px; left: 277px; position: absolute; height: 20px; width: 121px; bottom: 308px" Text="WriteOnly" />
<asp:CheckBox ID="CheckBox4" runat="server" ForeColor="Black" style="top: 45px; left: 277px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="incidentReadOnly" runat="server" ForeColor="Black" style="top: 87px; left: 191px; position: absolute; height: 21px; width: 80px" Text="ReadOnly" />
<asp:CheckBox ID="CheckBox14" runat="server" ForeColor="Black" style="top: 66px; left: 277px; position: absolute; height: 21px; width: 121px" Text="WriteOnly" />
<asp:CheckBox ID="Contractor" runat="server" ForeColor="Black"  AutoPostBack="true"
        style="top: 179px; left: -2px; position: absolute; height: 21px; width: 121px" 
        Text="" oncheckedchanged="Contractor_CheckedChanged" />
<asp:CheckBox ID="check_in_report" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 43px; left: -2px; position: absolute; height: 21px; width: 176px" 
        Text="" oncheckedchanged="check_in_report_CheckedChanged" />
<asp:CheckBox ID="incidWriteOnly" runat="server" ForeColor="Black" style="top: 89px; left: 277px; position: absolute; height: 21px; width: 121px" Text="WriteOnly" />
<asp:CheckBox ID="Check_out_report" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 65px; left: -2px; position: absolute; height: 24px; width: 178px" 
        Text="" oncheckedchanged="Check_out_report_CheckedChanged" />
<!-----------------update panel start----------------------------------------->
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>--%>
<asp:Button ID="past_in_Button" runat="server" style="top: 279px; left: 360px; position: absolute; height: 21px; width: 76px" Text="save" onclick="past_in_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="past_out_Button" runat="server" style="top: 301px; left: 360px; position: absolute; height: 21px; width: 76px" Text="save" onclick="past_out_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="past_inced_Button" runat="server" style="top: 324px; left: 360px; position: absolute; height: 21px; width: 76px" Text="save" onclick="past_inced_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="past_alert_Button" runat="server" style="top: 346px; left: 360px; position: absolute; height: 21px; width: 76px" Text="save" onclick="past_alert_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="past_occure_Button" runat="server" style="top: 368px; left: 360px; position: absolute; height: 21px; width: 76px" Text="save" onclick="past_occure_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="past_visit_Button" runat="server" style="top: 390px; left: 360px; position: absolute; height: 21px; width: 76px" Text="save" onclick="past_visit_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="past_contract_Button" runat="server" style="top: 412px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="past_contract_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="past_event_Button" runat="server" style="top: 435px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="past_event_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="past_lost_Button" runat="server" style="top: 458px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="past_lost_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="activerev5" runat="server" style="top: 481px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="activerev5_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="activerev6" runat="server" style="top: 505px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="activerev6_Click"   OnClientClick="JavaScript:alert('save')"/>
<%--</ContentTemplate></asp:UpdatePanel>--%>
<!-------------------------end of update panel-------------------------------------->
<asp:CheckBox ID="outReadOnly" runat="server" ForeColor="Black" style="top: 64px; left: 191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="Incident_Report" runat="server" ForeColor="Black"  AutoPostBack="true"
        style="top: 88px; left: -1px; position: absolute; height: 21px; width: 179px" 
        Text="" oncheckedchanged="Incident_Report_CheckedChanged" />
<asp:CheckBox ID="Alert_Report" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 111px; left: -1px; position: absolute; height: 21px; width: 141px" 
        Text="" oncheckedchanged="Alert_Report_CheckedChanged" />
<asp:CheckBox ID="Occurence" runat="server" ForeColor="Black"  AutoPostBack="true"
        style="top: 134px; left: -2px; position: absolute; height: 20px; width: 148px" 
        Text="" oncheckedchanged="Occurence_CheckedChanged" />
<asp:CheckBox ID="alertReadOnly" runat="server" ForeColor="Black" style="top: 108px; left: 191px; position: absolute; height: 21px; width: 111px; bottom: 424px" Text="ReadOnly" />
<asp:CheckBox ID="alertWriteOnly" runat="server" ForeColor="Black" style="top: 111px; left: 277px; position: absolute; height: 21px; width: 121px" Text="WriteOnly" />
<asp:CheckBox ID="CheckBox18" runat="server" ForeColor="Black"  AutoPostBack="true"
        style="top: 156px; left: -2px; position: absolute; height: 21px; width: 141px" 
        Text="" oncheckedchanged="CheckBox18_CheckedChanged" />
<asp:CheckBox ID="vivitWriteOnly" runat="server" ForeColor="Black" style="top: 157px; left: 277px; position: absolute; height: 21px; width: 111px" Text="WriteOnly" />

<asp:CheckBox ID="contractWriteOnly" runat="server" ForeColor="Black" style="top: 178px; left: 277px; position: absolute; height: 21px; width: 111px; bottom: 354px;" Text="WriteOnly" />
<asp:CheckBox ID="eventReadOnly" runat="server" ForeColor="Black" style="top: 203px; left: 191px; position: absolute; height: 21px; width: 111px" Text="ReadOnly" />
<asp:CheckBox ID="occureReadOnly" runat="server" ForeColor="Black" style="top: 131px; left: 191px; position: absolute; height: 21px; width: 111px"  Text="ReadOnly" />
<asp:CheckBox ID="occurWriteOnly" runat="server" ForeColor="Black" oncheckedchanged="CheckBox20_CheckedChanged" style="top: 133px; left: 277px; position: absolute; height: 21px; width: 111px" Text="WriteOnly" />
<asp:CheckBox ID="visitReadOnly" runat="server" ForeColor="Black" style="top: 155px; left: 191px; position: absolute; height: 21px; width: 91px" Text="ReadOnly" />
<asp:CheckBox ID="Event" runat="server" ForeColor="Black"  AutoPostBack="true"
        style="top: 201px; left: -1px; position: absolute; height: 21px; width: 111px; bottom: 331px" 
        Text="" oncheckedchanged="Event_CheckedChanged" />
<asp:CheckBox ID="contractReadOnly" runat="server" ForeColor="Black" style="top: 179px; left: 191px; position: absolute; height: 20px; width: 90px" Text="ReadOnly" />
<asp:CheckBox ID="Lost_Found" runat="server" ForeColor="Black"  AutoPostBack="true"
        style="top: 226px; left: -1px; position: absolute; height: 21px; width: 131px" 
        Text="" oncheckedchanged="Lost_Found_CheckedChanged" />
<asp:CheckBox ID="eventWriteOnly" runat="server" ForeColor="Black" style="top: 200px; left: 277px; position: absolute; height: 21px; width: 111px" Text="WriteOnly" />
<asp:Label ID="Label5" runat="server" Text="" ForeColor="Black" style="top: 257px; left: 1px; position: absolute; height: 20px; width: 440px;font-family:Arial Verdana; font-weight:500;letter-spacing:0em; font-size:18px" BackColor="#FFCCFF"></asp:Label>
<asp:CheckBox ID="pCheck_in_report" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 278px; left: -2px; position: absolute; height: 21px; width: 147px; right: 315px;" 
        Text="" oncheckedchanged="pCheck_in_report_CheckedChanged" />
<asp:CheckBox ID="p_in_WriteOnly" runat="server" ForeColor="Black" style="top: 279px; left: 277px; position: absolute; height: 21px; width: 103px; bottom: 253px;" Text="WriteOnly" />
<asp:CheckBox ID="p_in_ReadOnly" runat="server" ForeColor="Black" style="top: 279px; left: 191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="pCheck_out_report" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 299px; left: -2px; position: absolute; height: 21px; width: 164px" 
        Text="" oncheckedchanged="pCheck_out_report_CheckedChanged" />
<asp:CheckBox ID="p_out_WriteOnly" runat="server" ForeColor="Black" style="top: 461px; left: 277px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="activerev3" runat="server" ForeColor="Black" style="top: 485px; left: 277px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="activerev4" runat="server" ForeColor="Black" style="top: 510px; left: 277px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="p_out_ReadOnly" runat="server" ForeColor="Black" style="top: 298px; left: 191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" /> 
<asp:CheckBox ID="p_incident" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 322px; left: -2px; position: absolute; height: 21px; width: 133px" 
        Text="" oncheckedchanged="p_incident_CheckedChanged" />
<asp:CheckBox ID="p_inc_WriteOnly" runat="server" ForeColor="Black" style="top: 300px; left: 277px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="p_inc_ReadOnly" runat="server" ForeColor="Black" style="top: 320px; left: 191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="p_alert" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 346px; left: -2px; position: absolute; height: 17px; width: 133px" 
        Text="" oncheckedchanged="p_alert_CheckedChanged" />
<asp:CheckBox ID="p_alert_WriteOnly" runat="server" ForeColor="Black" style="top: 321px; left: 276px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="p_alert_ReadOnly" runat="server" ForeColor="Black" style="top: 343px; left: 191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="p_occurence" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 367px; left: -2px; position: absolute; height: 21px; width: 133px"  
        Text="" oncheckedchanged="p_occurence_CheckedChanged" />
<asp:CheckBox ID="pocr_WriteOnly" runat="server" ForeColor="Black" style="top: 344px; left: 277px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="p_occure_ReadOnly" runat="server" ForeColor="Black" style="top: 368px; left: 191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="p_visit" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 390px; left: -1px; position: absolute; height: 19px; width: 133px" 
        Text="" oncheckedchanged="p_visit_CheckedChanged" />
<asp:CheckBox ID="p_visit_WriteOnly" runat="server" ForeColor="Black" style="top: 368px; left: 277px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="p_visit_ReadOnly" runat="server" ForeColor="Black" style="top: 391px; left:191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="p_contract" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 413px; left: -1px; position: absolute; height: 21px; width: 133px" 
        Text="" oncheckedchanged="p_contract_CheckedChanged" />
<asp:CheckBox ID="p_cont_WriteOnly" runat="server" ForeColor="Black" style="top: 391px; left: 276px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="p_contract_ReadOnly" runat="server" ForeColor="Black" style="top: 416px; left: 190px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="p_event" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 437px; left: -1px; position: absolute; height: 21px; width: 133px" 
        Text="" oncheckedchanged="p_event_CheckedChanged" />
<asp:CheckBox ID="p_event_WriteOnly" runat="server" ForeColor="Black" style="top: 414px; left: 277px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="p_event_ReadOnly" runat="server" ForeColor="Black" style="top: 438px; left: 191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="p_lost" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 460px; left: -2px; position: absolute; height: 21px; width: 133px" 
        Text="" oncheckedchanged="p_lost_CheckedChanged" />
<asp:CheckBox ID="activereview1" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 485px; left: -2px; position: absolute; height: 21px; width: 124px" 
        Text="" oncheckedchanged="activereview1_CheckedChanged" />
<asp:CheckBox ID="activereview2" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 510px; left: -2px; position: absolute; height: 21px; width: 124px" 
        Text="" oncheckedchanged="activereview2_CheckedChanged" />
<asp:CheckBox ID="p_lost_WriteOnly" runat="server" ForeColor="Black" style="top: 438px; left: 278px; position: absolute; height: 21px; width: 103px" Text="WriteOnly" />
<asp:CheckBox ID="p_lost_ReadOnly" runat="server" ForeColor="Black" style="top: 463px; left: 191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="activerev1" runat="server" ForeColor="Black" style="top: 485px; left:191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="activerev2" runat="server" ForeColor="Black" style="top: 510px; left: 191px; position: absolute; height: 21px; width: 81px" Text="ReadOnly" />
<asp:CheckBox ID="lostReadOnly" runat="server" ForeColor="Black" style="top: 227px; left:191px; position: absolute; height: 20px; width: 88px" Text="ReadOnly" />
<!--------------------start update panel--------------------------------------->
<%--<asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>--%>
<asp:Button ID="cur_checkin_Button" runat="server" style="top: 44px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="cur_checkin_Button_Click"  OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="cur_checkout_Button" runat="server" style="top: 66px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="cur_checkout_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="cur_ince_Button" runat="server" style="top: 90px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="cur_ince_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="cur_alert_Button" runat="server" style="top: 113px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="cur_alert_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="cur_occur_Button" runat="server" style="top: 136px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="cur_occur_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="cur_visit_Button" runat="server" style="top: 159px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="cur_visit_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="cur_conctract_Button" runat="server" style="top: 180px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="cur_conctract_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="cur_event_Button" runat="server" style="top: 202px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="cur_event_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="cur_lost_Button" runat="server" style="top: 227px; left: 360px; position: absolute; height:21px; width: 76px" Text="save" onclick="cur_lost_Button_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel>
<!-----------------------end of update panel----------------------------------------->
</div>

<!---------------------end code---------------------------------->
<!--------------------eventmanagement start---------------------->
<div id="Eventyemgmt" class="report" onclick="Eventyemgmt()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="eventmgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="eveDiv2"  style=" width:440px; height:45px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="eveUpdate1" runat="server"><ContentTemplate>
<asp:CheckBox ID="eveviewCheckBox" runat="server" ForeColor="Black" AutoPostBack="true" 
        style="top: 44px; left: -2px; position: absolute; height: 21px; width: 149px" 
        Text="" oncheckedchanged="eveviewCheckBox_CheckedChanged" />
<asp:CheckBox ID="eveviewReadOnly" runat="server" ForeColor="Black" style="top: 45px; left: 191px; position: absolute; height: 21px; width: 99px; bottom: 567px;" Text="ReadOnly" />
<asp:CheckBox ID="eveviewWriteOnly" runat="server" ForeColor="Black" style="top: 42px; left: 277px; position: absolute; height: 21px; width: 111px"  Text="WriteOnly" />
</ContentTemplate></asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
<asp:Button ID="eveviewButton" runat="server" Text="save" style="top: 46px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="eveviewButton_Click"    OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="eveaddButton" runat="server" Text="save" style="top: 69px; left: 360px; position: absolute; height: 21px; width: 76px"  onclick="eveaddButton_Click"    OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel>
<asp:UpdatePanel ID="eveupdate2" runat="server"><ContentTemplate>
<asp:CheckBox ID="eveaddCheckBox" runat="server" ForeColor="Black"  AutoPostBack="true" 
        style="top: 67px; left: -2px; position: absolute; height: 21px; width: 154px" 
        Text="" oncheckedchanged="eveaddCheckBox_CheckedChanged" />
<asp:CheckBox ID="eveaddReadOnly" runat="server" ForeColor="Black" style="top: 65px; position: absolute; height: 21px; width: 101px; left: 191px" Text="ReadOnly" />
 <asp:CheckBox ID="eveaddWriteOnly" runat="server" ForeColor="Black" style="top: 65px; left: 277px; position: absolute; height: 21px; width: 111px" Text="WriteOnly" />
 </ContentTemplate></asp:UpdatePanel>
 
 </div>
<!------------------------end code---------------------------------------------->
<!---------------------shift start---------------------------------------------->
<div id="Shift" class="report" onclick="Shift()" style=" width:440px; height:20px; background-color:#EEEEEE; cursor:pointer;border:1px solid #CCC;font-size:0.87em; font-family:Arial">
 <asp:Label ID="shift" runat="server" Text="" style="font-size:16px;letter-spacing:-1px; padding-bottom: 5px;font-weight:300"> </asp:Label></div>
<div id="shfDiv2"  style=" width:440px; height:100px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="shiftupdate1" runat="server"><ContentTemplate>
<asp:CheckBox ID="shiftCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 71px; left: -2px; position: absolute; height: 21px; width: 164px" 
        oncheckedchanged="shiftCheckBox1_CheckedChanged" />
<asp:CheckBox ID="shiftCheckBox2" runat="server" AutoPostBack="true" 
        style="top: 97px; left: -1px; position: absolute; height: 21px; width: 164px" 
        oncheckedchanged="shiftCheckBox2_CheckedChanged" />
<asp:CheckBox ID="shiftCheckBox3" runat="server" AutoPostBack="true" 
        style="top: 124px; left: -1px; position: absolute; height: 18px; width: 164px" 
        oncheckedchanged="shiftCheckBox3_CheckedChanged" />
<asp:CheckBox ID="shiftCheckBox4" runat="server" AutoPostBack="true" 
        style="top: 144px; left: -1px; position: absolute; height: 18px; width: 164px" 
        oncheckedchanged="shiftCheckBox4_CheckedChanged" />
<asp:CheckBox ID="shiftreadCheckBox1" runat="server" style="top: 71px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="shiftreadCheckBox2" runat="server" style="top: 95px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="shiftreadCheckBox3" runat="server" style="top: 120px; left: -1px; position: absolute; height: 21px; width: 126px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="shiftreadCheckBox4" runat="server" style="top: 144px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="shiftwriteCheckBox1" runat="server" style="top: 71px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="shiftwriteCheckBox2" runat="server" style="top: 93px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="shiftwriteCheckBox3" runat="server" style="top: 119px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="shiftwriteCheckBox4" runat="server" style="top: 144px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
<asp:Button ID="shiftButton1" runat="server" Text="save" style="top: 70px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="shiftButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="shiftButton2" runat="server" Text="save" style="top: 93px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="shiftButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="shiftButton3" runat="server" Text="save" style="top: 116px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="shiftButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="shiftButton4" runat="server" Text="save" style="top: 140px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="shiftButton4_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel>  </div>
<!----------------------------end code------------------------------------------------->
<!--------------------------shift deploywment start------------------------------------------->
<div id="Shiftdep" class="report" onclick="Shiftdep()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
 <asp:Label ID="shiftdep" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="ShiftdepDiv2"  style=" width:440px; height:75px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="shiftUpdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="shiftdepCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 88px; left: -2px; position: absolute; height: 21px; width: 164px" 
        oncheckedchanged="shiftdepCheckBox1_CheckedChanged" />
<asp:CheckBox ID="shiftdepCheckBox2" runat="server" AutoPostBack="true" 
        style="top: 110px; left: -2px; position: absolute; height: 21px; width: 229px" 
        oncheckedchanged="shiftdepCheckBox2_CheckedChanged" />
<asp:CheckBox ID="shiftdepCheckBox3" runat="server" AutoPostBack="true" 
        style="top: 135px; left: -2px; position: absolute; height: 21px; width: 230px" 
        oncheckedchanged="shiftdepCheckBox3_CheckedChanged" />
<asp:CheckBox ID="shiftdepredCheckBox1" runat="server" style="top: 88px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="shiftdepredCheckBox2" runat="server" style="top: 110px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="shiftdepredCheckBox3" runat="server" style="top: 135px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="shiftdepwrCheckBox1" runat="server" style="top: 88px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="shiftdepwrCheckBox2" runat="server" style="top: 110px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="shiftdepwrCheckBox3" runat="server" style="top: 135px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
<asp:Button ID="shiftdepButton1" runat="server" Text="save" style="top: 88px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="shiftdepButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="shiftdepButton2" runat="server" Text="save" style="top: 110px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="shiftdepButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="shiftdepButton3" runat="server" Text="save" style="top: 135px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="shiftdepButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div> 
<!------------------end code------------------------------------------------------------>
<!----------------------assign location start------------------------------------------------->
<div id="asslocation" class="report" onclick="asslocation()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="asslocationmgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="asslocationDiv2"  style=" width:440px; height:25px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="assignupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="asslocCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 112px; left: -2px; position: absolute; height: 21px; width: 164px" 
        oncheckedchanged="asslocCheckBox1_CheckedChanged" />
<asp:CheckBox ID="asslocredchkbox1" runat="server" style="top: 112px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="asslocwrchkbox" runat="server" style="top: 112px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
<asp:Button ID="asslocButton1" runat="server" Text="save" style="top: 112px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="asslocButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel>  </div>   
<!---------------------end code--------------------------------------------------------------->
<!--------------------location management----------------------------------------------------->
<div id="locationmgmt" class="report" onclick="locationmgmt()" style=" width:440px; height:20px; background-color:#EEEEEE; cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="locationmanagement" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="locationmgmtDiv2"  style=" width:440px; height:75px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="locationupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="locCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 135px; left: -1px; position:absolute; height: 21px; width: 164px" 
        oncheckedchanged="locCheckBox1_CheckedChanged" />
<asp:CheckBox ID="locCheckBox2" runat="server" AutoPostBack="true" 
        style="top: 160px; left: -1px; position:absolute; height: 21px; width: 164px" 
        oncheckedchanged="locCheckBox2_CheckedChanged" />
<asp:CheckBox ID="locCheckBox3" runat="server" AutoPostBack="true" 
        style="top: 184px; left: -1px; position:absolute; height: 21px; width: 164px" 
        oncheckedchanged="locCheckBox3_CheckedChanged" />
<asp:CheckBox ID="locredCheckBox1" runat="server" style="top:135px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="locredCheckBox2" runat="server" style="top: 160px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="locredCheckBox3" runat="server" style="top: 184px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="locwrCheckBox1" runat="server" style="top: 135px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="locwrCheckBox2" runat="server" style="top: 160px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="locwrCheckBox3" runat="server" style="top: 184px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate>
<asp:Button ID="locButton1" runat="server" Text="save" style="top: 135px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="locButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="locButton2" runat="server" Text="save" style="top: 160px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="locButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="locButton3" runat="server" Text="save" style="top: 185px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="locButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel> </ContentTemplate></asp:UpdatePanel></div> 
<!-------------------end code---------------------------------------------->
<!------------------------inventry management start--------------------------------> 
<div id="inventry" class="report" onclick="inventry()" style=" width:440px; height:20px; background-color:#EEEEEE; cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="inventrymgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="inventryDiv2"  style=" width:440px; height:75px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="inventory" runat="server"><ContentTemplate>
<asp:CheckBox ID="invetCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 155px; left: -2px; position:absolute; height: 21px; width: 164px" 
        oncheckedchanged="invetCheckBox1_CheckedChanged" />
<asp:CheckBox ID="invetCheckBox2" runat="server" AutoPostBack="true" 
        style="top: 177px; left: -1px; position:absolute; height: 21px; width: 164px" 
        oncheckedchanged="invetCheckBox2_CheckedChanged" />
<asp:CheckBox ID="invetCheckBox3" runat="server" AutoPostBack="true" 
        style="top: 200px; left: -1px; position:absolute; height: 21px; width: 164px" 
        oncheckedchanged="invetCheckBox3_CheckedChanged" />
<asp:CheckBox ID="invetredchkbox1" runat="server" style="top:155px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="invetredchkbox12" runat="server" style="top: 177px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="invetredchkbox13" runat="server" style="top: 200px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="invetwrchkbox1" runat="server" style="top: 155px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="invetwrchkbox2" runat="server" style="top: 177px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="invetwrchkbox3" runat="server" style="top: 200px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate>
<asp:Button ID="invetButton1" runat="server" Text="save" style="top: 155px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="invetButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="invetButton2" runat="server" Text="save" style="top: 177px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="invetButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="invetButton3" runat="server" Text="save" style="top: 200px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="invetButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel>  </div>
<!-------------end code------------------------------------------------------------->
<!------------------tranning mgmt---------------------------------------------------->

<!------------------end code--------------------------------------------------------->
<!-------------------previsitor mgmt------------------------------------------------->

<!-------------------------end code--------------------------------------------------->
<!-----------------------checkin\out mgmt--------------------------------------------->
<div id="chkinout" class="report" onclick="chkinout()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="chkinoutmgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="chkinoutDiv2"  style=" width:440px; height:190px;display:none;border:1px solid #CCC">
<asp:Label ID="chkinLabel" runat="server" Text="" style="top: 175px; left: 1px; position: absolute; height: 20px; width: 440px; font-size:18px; font-weight:500; color:Black; letter-spacing:0em; font-family:Verdana Arial" BackColor="#FFCCFF"></asp:Label>
<asp:UpdatePanel ID="checkinupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="chkinCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 200px; left: -1px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="chkinCheckBox1_CheckedChanged" />
<asp:CheckBox ID="chkinCheckBox2" runat="server" AutoPostBack="true" 
        style="top: 225px; left: -1px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="chkinCheckBox2_CheckedChanged" />
<asp:CheckBox ID="chkinCheckBox3" runat="server" AutoPostBack="true" 
        style="top: 250px; left: -1px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="chkinCheckBox3_CheckedChanged" />
<asp:CheckBox ID="chkinredCB1" runat="server" style="top:200px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="chkinredCB2" runat="server" style="top: 225px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="chkinredCB3" runat="server" style="top: 250px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="chkinwrCB1" runat="server" style="top: 200px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="chkinwrCB2" runat="server" style="top: 225px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="chkinwrCB3" runat="server" style="top: 250px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel11" runat="server"><ContentTemplate>
<asp:Button ID="chkinButton1" runat="server" Text="save" style="top: 200px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="chkinButton1_Click" OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="chkinButton2" runat="server" Text="save" style="top: 225px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="chkinButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="chkinButton3" runat="server" Text="save" style="top: 250px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="chkinButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel> 
<asp:Label ID="chkoutLabel" runat="server" Text="" 
style="top:275px; height: 20px; width: 440px; left:2px; font-weight:500; font-size:18px; letter-spacing:0em; font-family:Arial Verdana;color:Black; position: absolute;" 
        BackColor="#FFCCFF"></asp:Label>
<asp:CheckBox ID="chkoutCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 296px; left: -1px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="chkoutCheckBox1_CheckedChanged" />
<asp:CheckBox ID="chkoutCheckBox2" runat="server" AutoPostBack="true" 
        style="top: 321px; left: -1px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="chkoutCheckBox2_CheckedChanged" />
<asp:CheckBox ID="chkoutCheckBox3" runat="server" AutoPostBack="true" 
        style="top: 346px; left: -1px; position:absolute; height: 21px; width: 200px" 
        oncheckedchanged="chkoutCheckBox3_CheckedChanged" />
<asp:CheckBox ID="chkoutredCB1" runat="server" style="top:296px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="chkoutredCB2" runat="server" style="top: 321px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="chkoutredCB3" runat="server" style="top: 346px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="chkoutwrCB1" runat="server" style="top: 296px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="chkoutwrCB2" runat="server" style="top: 321px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="chkoutwrCB3" runat="server" style="top: 346px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
<asp:Button ID="chkoutButton1" runat="server" Text="save" style="top: 296px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="chkoutButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="chkoutButton2" runat="server" Text="save" style="top: 321px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="chkoutButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="chkoutButton3" runat="server" Text="save" style="top: 346px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="chkoutButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>  
<!---------------------end code---------------------------------------------------->
<!---------------------feedbacck mgmt---------------------------------------------->
<!--------------------end code---------------------------------------------------->
<!-----------------digital diary-------------------------------------------------->
<div id="ditdiary" class="report" onclick="ditdiary()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
 <asp:Label ID="ldigitaldiary" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="ditdiaryDiv2"  style=" width:440px; height:25px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="dtupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="dtCheckBox1" runat="server"  AutoPostBack="true"
        style="top: 200px; left: -3px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="dtCheckBox1_CheckedChanged" />
<asp:CheckBox ID="dtredCheckBox1" runat="server" style="top: 200px; left: -3px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="CheckBox1" runat="server" style="top: 200px; left: -3px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:UpdatePanel ID="UpdatePanel14" runat="server"><ContentTemplate>
<asp:Button ID="dtButton1" runat="server" Text="save" style="top: 200px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="dtButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>  
<!--------------------end code----------------------------------------------------->
<!--------------------view management---------------------------------------------->
<div id="viewreport" class="report" onclick="viewreport()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="viewreportmgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="viewreportDiv2"  style=" width:440px; height:195px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="viewupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="viewCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 225px; left: -3px; position:absolute; height: 21px; width:200px" 
        oncheckedchanged="viewCheckBox1_CheckedChanged"/>
<asp:CheckBox ID="viewCheckBox2" runat="server" AutoPostBack="true" 
        style="top: 250px; left: -3px; position:absolute; height: 21px; width: 220px" 
        oncheckedchanged="viewCheckBox2_CheckedChanged" />
<asp:CheckBox ID="viewCheckBox3" runat="server" AutoPostBack="true" 
        style="top: 275px; left: -3px; position:absolute; height: 21px; width: 217px" 
        oncheckedchanged="viewCheckBox3_CheckedChanged" />
<asp:CheckBox ID="viewCheckBox4" runat="server" AutoPostBack="true" 
        style="top: 300px; left: -3px; position:absolute; height: 21px; width: 200px" 
        oncheckedchanged="viewCheckBox4_CheckedChanged" />
<asp:CheckBox ID="viewCheckBox5" runat="server" AutoPostBack="true" 
        style="top: 325px; left: -3px; position:absolute; height: 21px; width: 200px" 
        oncheckedchanged="viewCheckBox5_CheckedChanged" />
<asp:CheckBox ID="viewCheckBox6" runat="server" AutoPostBack="true" 
        style="top: 350px; left: -3px; position:absolute; height: 21px; width: 200px" 
        oncheckedchanged="viewCheckBox6_CheckedChanged" />
<asp:CheckBox ID="viewCheckBox7" runat="server" AutoPostBack="true" 
        style="top: 375px; left: -3px; position:absolute; height: 21px; width: 200px" 
        oncheckedchanged="viewCheckBox7_CheckedChanged" />
<asp:CheckBox ID="viewredCB1" runat="server" style="top: 225px; left: -3px; position:absolute; height: 21px; width: 91px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="viewredCB2" runat="server" style="top: 250px; left: -3px; position:absolute; height: 21px; width: 91px;left:191px" Text="ReadOnly" />
<asp:CheckBox ID="viewredCB3" runat="server" style="top: 275px; left: -3px; position:absolute; height: 21px; width: 91px;left:191px" Text="ReadOnly" />
<asp:CheckBox ID="viewredCB4" runat="server" style="top: 300px; left: -3px; position:absolute; height: 21px; width:91px;left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="viewredCB5" runat="server" style="top: 325px; left: -3px; position:absolute; height: 21px; width: 91px;left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="viewredCB6" runat="server" style="top: 350px; left: -3px; position:absolute; height: 21px; width: 91px;left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="viewredCB7" runat="server" style="top: 375px; left: -3px; position:absolute; height: 21px; width:91px;left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="viewwrCB1" runat="server" style="top: 225px; left: -3px; position:absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="viewwrCB2" runat="server" style="top: 250px; left: -3px; position:absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="viewwrCB3" runat="server" style="top: 275px; left: -3px; position:absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="viewwrCB4" runat="server" style="top: 300px; left: -3px; position:absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="viewwrCB5" runat="server" style="top: 325px; left: -3px; position:absolute; height: 21px; width: 86px; left:277px" Text="ReadOnly"/>
<asp:CheckBox ID="viewwrCB6" runat="server" style="top: 350px; left: -3px; position:absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="viewwrCB7" runat="server" style="top: 375px; left: -3px; position:absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly"/>
<asp:UpdatePanel ID="UpdatePanel15" runat="server"><ContentTemplate>
<asp:Button ID="viewButton1" runat="server" Text="save" style="top: 225px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="viewButton1_Click"   OnClientClick="JavaScript:alert('save')" />
<asp:Button ID="viewButton2" runat="server" Text="save" style="top: 250px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="viewButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="viewButton3" runat="server" Text="save" style="top: 275px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="viewButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="viewButton4" runat="server" Text="save" style="top: 300px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="viewButton4_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="viewButton5" runat="server" Text="save" style="top: 325px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="viewButton5_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="viewButton6" runat="server" Text="save" style="top: 350px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="viewButton6_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="viewButton7" runat="server" Text="save" style="top: 375px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="viewButton7_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>  
<!-------------------------end code----------------------------------------------->
<!--------------------alert report------------------------------------------------>
<div id="alertrpt" class="report" onclick="alertrpt()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
  <asp:Label ID="alertreport" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="alertrptDiv2"  style=" width:440px; height:130px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="alertupdate" runat="server"><ContentTemplate>
<asp:Label ID="addalertLabel" runat="server" Text="" style="top: 240px; left: 2px; position: absolute; height: 20px; width:440px; font-weight:500px; font-family:Arial Verdana; font-size:18px; letter-spacing:0em" BackColor="#FFCCFF"></asp:Label>
<asp:CheckBox ID="addaltCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 265px; left: -2px; position:absolute; height: 24px; width: 208px" 
        oncheckedchanged="addaltCheckBox1_CheckedChanged" />
<asp:CheckBox ID="addaltCheckBox2" runat="server" AutoPostBack="true" 
        style="top: 290px; left: -2px; position:absolute; height: 21px; width: 164px" 
        oncheckedchanged="addaltCheckBox2_CheckedChanged" />
<asp:CheckBox ID="altredCB1" runat="server" style="top: 265px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="altredCB2" runat="server" style="top: 290px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="altwrCB1" runat="server" style="top: 265px; left: -2px; position: absolute; height: 21px; width: 85px; left:275px" Text="WriteOnly"/>
<asp:CheckBox ID="altwrCB2" runat="server" style="top: 290px; left: -1px; position: absolute; height: 21px; width: 87px; left:278px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel16" runat="server"><ContentTemplate>
<asp:Button ID="addaltButton1" runat="server" Text="save" style="top: 265px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="addaltButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="addaltButton2" runat="server" Text="save" style="top: 290px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="addaltButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel>
 <asp:Label ID="viewaltLabel" runat="server" Text="Label" style="top: 315px; left: -1px; position: absolute; height: 20px; width: 440px; font-weight:500px; font-family:Arial Verdana; font-size:18px; letter-spacing:0em" BackColor="#FFCCFF"></asp:Label>
<asp:CheckBox ID="viewaltCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 340px; left: -2px; position:absolute; height: 21px; width: 164px" 
        oncheckedchanged="viewaltCheckBox1_CheckedChanged" />
 <asp:CheckBox ID="viewaltredCB1" runat="server" style="top: 340px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="viewaltwrCB1" runat="server" style="top: 340px; left: -1px; position: absolute; height: 21px; width: 87px; left:278px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel17" runat="server"><ContentTemplate>
<asp:Button ID="viewaltButton1" runat="server" Text="save" style="top: 340px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="viewaltButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div> 
<!------------------end code------------------------------------------------------->
<!-----------------follow up------------------------------------------------------->
<div id="followup" class="report" onclick="followup()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
  <asp:Label ID="followupmgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="followupDiv2"  style=" width:440px; height:50px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="followupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="followCheckBox1" runat="server" AutoPostBack="true" 
        style="top: 265px; left: -2px; position:absolute; height: 24px; width: 208px" 
        oncheckedchanged="followCheckBox1_CheckedChanged" />
<asp:CheckBox ID="followCheckBox2" runat="server" AutoPostBack="true" 
        style="top: 290px; left: -2px; position:absolute; height: 21px; width: 164px" 
        oncheckedchanged="followCheckBox2_CheckedChanged" />
<asp:CheckBox ID="folllowredCB1" runat="server" style="top: 265px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="folllowredCB2" runat="server" style="top: 290px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="folllowwrCB1" runat="server" style="top: 265px; left: -2px; position: absolute; height: 21px; width: 85px; left:275px" Text="WriteOnly"/>
<asp:CheckBox ID="folllowwrCB2" runat="server" style="top: 290px; left: -1px; position: absolute; height: 21px; width: 87px; left:278px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel18" runat="server"><ContentTemplate>
<asp:Button ID="followButton1" runat="server" Text="save" style="top:265px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="followButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="followButton2" runat="server" Text="save" style="top: 290px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="followButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div> 
<!-----------------------------end code--------------------------------------------->
<!------------------------dash board------------------------------------------------>
<div id="dash" class="report" onclick="dash()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="dashboard" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="dashDiv2"  style=" width:440px; height:25px; display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="dashupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="dashbordCheckBox1" runat="server"  AutoPostBack="true"
        style="top: 290px; left: -2px; position: absolute; height: 21px; width: 164px" 
        oncheckedchanged="dashbordCheckBox1_CheckedChanged" />
 <asp:CheckBox ID="dashredCB1" runat="server" style="top: 290px; left: -1px; position: absolute; height: 21px; width: 88px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="dashwrCB1" runat="server" style="top: 290px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:UpdatePanel ID="UpdatePanel19" runat="server"><ContentTemplate>
<asp:Button ID="dashButton1" runat="server" Text="save" style="top: 290px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="dashButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div> 
<!------------------------end code-------------------------------------------------->
<!------------------maintenance mgmt------------------------------------------------>
<div id="maintenance" class="report" onclick="maintenance()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
  <asp:Label ID="maintenancemgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="maintenanceDiv2"  style=" width:440px; height:500px; display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="maintenanceupdate" runat="server"><ContentTemplate>
<asp:Label ID="keymanagerLabel" runat="server" Text="" style="left: 1px; position: absolute; height: 20px; width: 440px; font-weight:500px; font-family:Arial Verdana; font-size:18px; letter-spacing:0em" BackColor="#FFCCFF"></asp:Label>
<asp:CheckBox ID="keymanagerCB1" runat="server"  AutoPostBack="true"
        style="top:330px; left: -3px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="keymanagerCB1_CheckedChanged" />
 <asp:CheckBox ID="keymanagerCB2" runat="server"  AutoPostBack="true"
        style="top: 355px; left: -2px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="keymanagerCB2_CheckedChanged" />
<asp:CheckBox ID="keymanagerCB3" runat="server"  AutoPostBack="true"
        style="top: 380px; left: -1px; position:absolute; height: 21px; width: 200px" 
        oncheckedchanged="keymanagerCB3_CheckedChanged" />
<asp:CheckBox ID="keymanagerredCB1" runat="server" style="top:330px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="keymanagerredCB2" runat="server" style="top: 355px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="keymanagerredCB3" runat="server" style="top: 380px; left: -1px; position: absolute; height: 21px; width: 164px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="keymanagerwrCB1" runat="server" style="top: 330px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="keymanagerwrCB2" runat="server" style="top: 355px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="keymanagerwrCB3" runat="server" style="top: 380px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel20" runat="server"><ContentTemplate>
<asp:Button ID="keymanagerButton1" runat="server" Text="save" style="top: 330px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="keymanagerButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="keymanagerButton2" runat="server" Text="save" style="top: 355px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="keymanagerButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="keymanagerButton3" runat="server" Text="save" style="top: 380px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="keymanagerButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel>
<asp:Label ID="passmanagerLabel" runat="server" Text="" style="top: 410px; left: 1px; position: absolute; height:20px; width: 440px; font-weight:500px; font-family:Arial Verdana; font-size:18px; letter-spacing:0em" BackColor="#FFCCFF"></asp:Label>
<asp:CheckBox ID="passmanagerCB1" runat="server"  AutoPostBack="true"
        style="top:435px; left: -3px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="passmanagerCB1_CheckedChanged" />
<asp:CheckBox ID="passmanagerCB2" runat="server"  AutoPostBack="true"
        style="top: 460px; left: -2px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="passmanagerCB2_CheckedChanged" />
<asp:CheckBox ID="passmanagerredCB1" runat="server" style="top:435px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="passmanagerredCB2" runat="server" style="top: 460px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="passmanagerwrCB1" runat="server" style="top:435px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="passmanagerwrCB2" runat="server" style="top:460px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel21" runat="server"><ContentTemplate>
<asp:Button ID="passmanagerButton1" runat="server" Text="save" style="top: 435px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="passmanagerButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="passmanagerButton2" runat="server" Text="save" style="top: 460px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="passmanagerButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel>
<asp:Label ID="itemanagerLabel" runat="server" BackColor="#FFCCFF" style="z-index: 1; left: 1px; top:490px; position: absolute; width:440px; height: 20px; font-weight:500px; font-family:Arial Verdana; font-size:18px; letter-spacing:0em"></asp:Label>
<asp:CheckBox ID="itemanagerCB1" runat="server"  AutoPostBack="true"
        style="top:515px; left: -3px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="itemanagerCB1_CheckedChanged" />
 <asp:CheckBox ID="itemanagerCB2" runat="server"  AutoPostBack="true"
        style="top: 540px; left: -2px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="itemanagerCB2_CheckedChanged" />
<asp:CheckBox ID="itemanageredCB1" runat="server" style="top:515px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="itemanageredCB2" runat="server" style="top: 540px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="itemanagerwrCB1" runat="server" style="top: 515px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="itemanagerwrCB2" runat="server" style="top: 540px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel22" runat="server"><ContentTemplate>
<asp:Button ID="itemanagerButton1" runat="server" Text="save" style="top: 515px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="itemanagerButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="itemanagerButton2" runat="server" Text="save" style="top: 540px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="itemanagerButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel>
<asp:Label ID="sopmanagerLabel" runat="server" Text="" BackColor="#FFCCFF" style="z-index: 1; left: 3px; top: 570px; position: absolute; width: 440px; height: 20px; font-weight:500px; font-family:Arial Verdana; font-size:18px; letter-spacing:0em"></asp:Label>
<asp:CheckBox ID="sopmanagerCB1" runat="server"  AutoPostBack="true"
        style="top:595px; left: -3px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="sopmanagerCB1_CheckedChanged" />
 <asp:CheckBox ID="sopmanagerCB2" runat="server"  AutoPostBack="true"
        style="top: 620px; left: -2px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="sopmanagerCB2_CheckedChanged" />
<asp:CheckBox ID="sopmanageredCB1" runat="server" style="top:595px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="sopmanageredCB2" runat="server" style="top: 620px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="sopmanagerwrCB1" runat="server" style="top: 595px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="sopmanagerwrCB2" runat="server" style="top: 620px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate>
<asp:Button ID="sopmanagerButton1" runat="server" Text="save" style="top: 595px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="sopmanagerButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="sopmanagerButton2" runat="server" Text="save" style="top: 620px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="sopmanagerButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel>
<asp:Label ID="alertmanagerLabel" runat="server" Text="" style="z-index: 1; left: -1px; top: 650px; position: absolute; width: 440px; height: 20px; font-weight:500px; font-family:Arial Verdana; font-size:18px; letter-spacing:0em"  BackColor="#FFCCFF"></asp:Label>
<asp:Label ID="viewalertmanagerLabel" runat="server" 
        style="z-index: 1; left: -1px; top: 675px; position: absolute; width: 440px; height: 20px; font-weight:500px; font-family:Arial Verdana; font-size:18px; letter-spacing:0em" 
        BackColor="#CCFFFF"></asp:Label>
<asp:CheckBox ID="viewalertmanagerCB1" runat="server"  AutoPostBack="true"
        style="top:700px; left: -3px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="viewalertmanagerCB1_CheckedChanged" />
<asp:CheckBox ID="viewalertmanagerredCB1" runat="server"  style="top: 700px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="viewalertmanagerwrCB1" runat="server" style="top:700px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:UpdatePanel ID="UpdatePanel24" runat="server"><ContentTemplate>
<asp:Button ID="viewalertmanagerButton1" runat="server" Text="save" style="top: 700px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="viewalertmanagerButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel>
<asp:Label ID="addalertmanagerLabel" runat="server"  AutoPostBack="true"
        style="z-index: 1; left: -1px; top: 730px; position: absolute; width: 440px; height: 20px; font-weight:500px; font-family:Arial Verdana; font-size:18px; letter-spacing:0em" 
        BackColor="#CCFFFF"></asp:Label>
 <asp:CheckBox ID="addalertmanagerCB1" runat="server"  AutoPostBack="true"
        style="top:755px; left: -3px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="addalertmanagerCB1_CheckedChanged" />
 <asp:CheckBox ID="addalertmanagerCB2" runat="server"  AutoPostBack="true"
        style="top: 780px; left: -1px; position:absolute; height: 21px; width: 184px" 
        oncheckedchanged="addalertmanagerCB2_CheckedChanged" />
<asp:CheckBox ID="addalertmanageredCB1" runat="server" style="top:755px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="addalertmanageredCB2" runat="server"  style="top: 780px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="addalertmanagerwrCB1" runat="server" style="top: 755px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:CheckBox ID="addalertmanagerwrCB2" runat="server" style="top: 780px; left: -1px; position: absolute; height: 21px; width: 87px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel25" runat="server"><ContentTemplate>
<asp:Button ID="addalertmanagerButton1" runat="server" Text="save" style="top: 755px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="addalertmanagerButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="addalertmanagerButton2" runat="server" Text="save" style="top: 780px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="addalertmanagerButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
             </ContentTemplate>
</asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!----------------------------emergenc mgmt--------------------------------->
<div id="emergency" class="report" onclick="emergency()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
  <asp:Label ID="emergencymgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="emergencyDiv2"  style=" width:440px; height:25px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="emergencyupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="emergencyCB1" runat="server" AutoPostBack="true"
        style="top: 335px; left: -1px; position: absolute; height: 21px; width: 158px" 
        oncheckedchanged="emergencyCB1_CheckedChanged" />
<asp:CheckBox ID="emergencyredCB1" runat="server" style="top:335px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="emergencywrCB1" runat="server" style="top:335px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>]
<asp:UpdatePanel ID="UpdatePanel26" runat="server"><ContentTemplate>
<asp:Button ID="emergencyButton1" runat="server" Text="save" style="top: 335px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="emergencyButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!---------------------------end code----------------------------------------------->
<!------------------sop mgmt-------------------------------------------------------->
<div id="sop" class="report" onclick="sop()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
  <asp:Label ID="sopmgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="sopDiv2"  style=" width:440px; height:50px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="sopupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="sopCheckBox1" runat="server"  AutoPostBack="true"
        style="top: 355px; left: -2px; position: absolute; height: 21px; width: 143px" 
        oncheckedchanged="sopCheckBox1_CheckedChanged" />
<asp:CheckBox ID="sopCheckBox2" runat="server" AutoPostBack="true"
        style="top: 380px; left: -2px; position: absolute; height: 21px; width: 145px" 
        oncheckedchanged="sopCheckBox2_CheckedChanged" />
<asp:CheckBox ID="sopredCB1" runat="server" style="top:355px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="sopredCB2" runat="server" style="top: 380px; left: -2px; position: absolute; height: 21px; width: 85px; left:191px" Text="ReadOnly"/>
<asp:CheckBox ID="sopwrCB1" runat="server" style="top:355px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="sopwrCB2" runat="server" style="top: 380px; left: -2px; position: absolute; height: 21px; width: 85px; left:277px" Text="WriteOnly"/>
<asp:UpdatePanel ID="UpdatePanel27" runat="server"><ContentTemplate>
<asp:Button ID="sopButton1" runat="server" Text="save" style="top:355px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="sopButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="sopButton2" runat="server" Text="save" style="top: 380px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="sopButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!--------------------------end code-------------------------------------------------->
<!---------------------------staff management----------------------------------------->
 <div id="staffmgmt" class="report" onclick="staffmgmt()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer; border:1px solid #CCC;font-size:0.87em">
  <asp:Label ID="staffmanagement" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="staffmgmtDiv2"  style=" width:440px; height:125px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="staffupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="staffmgmtCB1" runat="server" AutoPostBack="true"
        style="top: 380px; left: -3px; position: absolute; height: 21px; width: 168px" 
        oncheckedchanged="staffmgmtCB1_CheckedChanged" />
<asp:CheckBox ID="staffmgmtCB2" runat="server" AutoPostBack="true"
        style="top: 405px; left: -3px; position: absolute; height: 21px; width: 173px" 
        oncheckedchanged="staffmgmtCB2_CheckedChanged" />
<asp:CheckBox ID="staffmgmtCB3" runat="server" AutoPostBack="true"
        style="top: 430px; left: -3px; position: absolute; height: 21px; width: 172px" 
        oncheckedchanged="staffmgmtCB3_CheckedChanged" />
<asp:CheckBox ID="staffmgmtCB4" runat="server" AutoPostBack="true"
        style="top: 455px; left: -3px; position: absolute; height: 21px; width: 171px" 
        oncheckedchanged="staffmgmtCB4_CheckedChanged" />
<asp:CheckBox ID="staffmgmtCB5" runat="server" AutoPostBack="true"
        style="top: 480px; left: -3px; position: absolute; height: 21px; width: 173px" 
        oncheckedchanged="staffmgmtCB5_CheckedChanged" />
<asp:CheckBox ID="staffmgmtredCB1" runat="server" style="top:380px; left: -5px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
 <asp:CheckBox ID="staffmgmtredCB2" runat="server" style="top:405px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="staffmgmtredCB3" runat="server" style="top:430px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="staffmgmtredCB4" runat="server" style="top:455px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="staffmgmtredCB5" runat="server" style="top:480px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="staffmgmtwrCB1" runat="server" style="top:380px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="staffmgmtwrCB2" runat="server" style="top:405px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="staffmgmtwrCB3" runat="server" style="top:430px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="staffmgmtwrCB4" runat="server" style="top:455px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="staffmgmtwrCB5" runat="server" style="top:480px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel28" runat="server">  <ContentTemplate>
<asp:Button ID="staffmgmtButton1" runat="server" Text="save" style="top:380px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="staffmgmtButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="staffmgmtButton2" runat="server" Text="save" style="top: 405px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="staffmgmtButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
 <asp:Button ID="staffmgmtButton3" runat="server" Text="save" style="top:430px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="staffmgmtButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="staffmgmtButton4" runat="server" Text="save" style="top: 455px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="staffmgmtButton4_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="staffmgmtButton5" runat="server" Text="save" style="top: 480px; left: 360px; position: absolute; height: 21px; width: 76px" 
 onclick="staffmgmtButton5_Click"   OnClientClick="JavaScript:alert('save')"/>

</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!---------------------------end code--------------------------------------------------->
<!-------------------create report------------------------------------------------------>
<div id="creport" class="report" onclick="creport()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
  <asp:Label ID="createreport" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="creportDiv2"  style=" width:440px; height:80px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="createupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="creportCB1" runat="server"  AutoPostBack="true"
        style="top: 400px; left: -2px; position: absolute; height: 21px; width: 168px" 
        oncheckedchanged="creportCB1_CheckedChanged" />
<asp:CheckBox ID="creportCB2" runat="server" AutoPostBack="true"
        style="top: 425px; left: -2px; position: absolute; height: 21px; width: 173px" 
        oncheckedchanged="creportCB2_CheckedChanged" />
<asp:CheckBox ID="creportCB3" runat="server" AutoPostBack="true"
        style="top: 450px; left: -2px; position: absolute; height: 21px; width: 172px" 
        oncheckedchanged="creportCB3_CheckedChanged" />
<asp:CheckBox ID="creportredCB1" runat="server" style="top:400px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
 <asp:CheckBox ID="creportredCB2" runat="server" style="top:425px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="creportredCB3" runat="server" style="top:450px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="creportwrCB1" runat="server" style="top:400px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="creportwrCB2" runat="server" style="top:425px; left: -2px; position: absolute; height: 21px; width: 86px; left:278px"  Text="WriteOnly" />
<asp:CheckBox ID="creportwrCB3" runat="server" style="top:450px; left: -2px; position: absolute; height: 21px; width: 86px; left:278px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel29" runat="server"><ContentTemplate>
<asp:Button ID="creportButton1" runat="server" Text="save" style="top:400px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="creportButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="creportButton2" runat="server" Text="save" style="top: 425px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="creportButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="creportButton3" runat="server" Text="save" style="top:450px; left: 360px; position: absolute; height: 21px; width: 76px" 
             onclick="creportButton3_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!---------------------------------end code-------------------------------------------->
<!------------------------------permission--------------------------------------------->
<div id="permission" class="report" onclick="permission()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
 <asp:Label ID="permissionmgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="permissionDiv2"  style=" width:440px; height:25px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="permissionupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="permissionCB1" runat="server"  AutoPostBack="true"
        style="top: 420px; left: 1px; position: absolute; height: 21px; width: 160px" 
        oncheckedchanged="permissionCB1_CheckedChanged" />
<asp:CheckBox ID="permissionredCB1" runat="server" style="top:420px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="permissionwrCB1" runat="server" style="top:420px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel30" runat="server"><ContentTemplate>
<asp:Button ID="permissionButton1" runat="server" Text="save" style="top: 420px; left: 360px; position: absolute; height: 21px; width: 76px" 
         onclick="permissionButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!--------------------------end permission code----------------------------------------->
<!------------ipcamera start------------------------------------------------------------>    

<!------------------------------end ipcamera code-------------------------------------------->
<!----------------------------ass start----------------------------------------------------->
<!-------------------end ass code--------------------------------------------------------->
<!---------------personal digital diary start---------------------------------------------->
<!------------------end ppd code------------------------------------------------------------>
<!-------------------------master ppd start------------------------------------------------->
<div id="mpdd" class="report" onclick="mppd()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="mpddiary" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="mpddDiv2"  style=" width:440px; height:50px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="mpddupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="mpddCB1" runat="server" AutoPostBack="true" 
        style="top: 445px; left: -2px; position: absolute; height: 21px; width: 103px" 
        oncheckedchanged="mpddCB1_CheckedChanged" />
<asp:CheckBox ID="mpddCB2" runat="server"  AutoPostBack="true"
        style="top: 470px; left: -2px; position: absolute; height: 21px; width: 143px" 
        oncheckedchanged="mpddCB2_CheckedChanged" />
<asp:CheckBox ID="mpddCB3" runat="server" style="top: 625px; left: -2px; position: absolute; height: 21px; width: 163px" visible="false"/>
<asp:CheckBox ID="mpddCB4" runat="server" style="top: 650px; left: -2px; position: absolute; height: 21px; width: 163px" visible="false"/>
<asp:CheckBox ID="mpddCB5" runat="server" style="top: 675px; left: -2px; position: absolute; height: 21px; width: 143px"  visible="false"/>
<asp:CheckBox ID="mpddredCB1" runat="server" style="top:445px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="mpddredCB2" runat="server" style="top:470px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="mpddredCB3" runat="server" style="top:625px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" visible="false"/>
<asp:CheckBox ID="mpddredCB4" runat="server" style="top:650px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" visible="false"/>
<asp:CheckBox ID="mpddredCB5" runat="server" style="top:675px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" visible="false"/>
<asp:CheckBox ID="mpddwrCB1" runat="server" style="top:445px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="mpddwrCB2" runat="server" style="top:470px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:CheckBox ID="mpddwrCB3" runat="server" style="top:625px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" visible="false"/>
<asp:CheckBox ID="mpddwrCB4" runat="server" style="top:650px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" visible="false"/>
<asp:CheckBox ID="mpddwrCB5" runat="server" style="top:675px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" visible="false"/>
<asp:UpdatePanel ID="UpdatePanel40" runat="server"><ContentTemplate>
<asp:Button ID="mpddButton1" runat="server" Text="save" style="top: 445px; left: 360px; position: absolute; height: 21px; width: 76px" 
         onclick="mpddButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="mpddButton2" runat="server" Text="save" style="top: 470px; left: 360px; position: absolute; height: 21px; width: 76px" 
         onclick="mpddButton2_Click"   OnClientClick="JavaScript:alert('save')"/>
<asp:Button ID="mpddButton3" runat="server" Text="save" style="top: 625px; left: 360px; position: absolute; height: 21px; width: 76px" 
         onclick="mpddButton3_Click"   OnClientClick="JavaScript:alert('save')" visible="false"/>
<asp:Button ID="mpddButton4" runat="server" Text="save" style="top: 650px; left: 360px; position: absolute; height: 21px; width: 76px" 
         onclick="mpddButton4_Click"   OnClientClick="JavaScript:alert('save')" visible="false"/>
<asp:Button ID="mpddButton5" runat="server" Text="save" style="top: 675px; left: 360px; position: absolute; height: 21px; width: 76px" 
         onclick="mpddButton5_Click"   OnClientClick="JavaScript:alert('save')" visible="false"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!-----------------------end mppd code----------------------------------------------------->
<!--------------------------lossetting start----------------------------------------------->
<div id="logsetting" class="report" onclick="logsetting()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="logmgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="logsettingDiv2"  style=" width:440px; height:25px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="logupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="logsettingCB1" runat="server"  AutoPostBack="true"
        style="top: 465px; left: -2px; position: absolute; height: 21px; width: 168px" 
        oncheckedchanged="logsettingCB1_CheckedChanged" />
<asp:CheckBox ID="logsettingredCB1" runat="server" style="top:465px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="logsettingwrCB1" runat="server" style="top:465px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel38" runat="server">
 <ContentTemplate>
<asp:Button ID="logsettingButton1" runat="server" Text="save" style="top: 465px; left: 360px; position: absolute; height: 21px; width: 76px" 
onclick="logsettingButton1_Click"  OnClientClick="JavaScript:alert('save')" />
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!---------------end log code-------------------------------------------------------------------->
<!------account setting start------------------------------------------------------------------->
<div id="accsetting" class="report" onclick="accsetting()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="accountsetting" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="accsettingDiv2"  style=" width:440px; height:25px;display:none;border:1px solid #CCC">
<asp:updatePanel ID="accountupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="accsettingCB1" runat="server"  AutoPostBack="true"
        style="top:485px; left: -1px; position: absolute; height: 21px; width: 163px" 
        oncheckedchanged="accsettingCB1_CheckedChanged" />
<asp:CheckBox ID="accsettingredCB1" runat="server" style="top:485px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="accsettingwrCB1" runat="server" style="top:485px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel37" runat="server"><ContentTemplate>
<asp:Button ID="accsettingButton1" runat="server" Text="save" style="top: 485px; left: 360px; position: absolute; height: 21px; width: 76px" 
onclick="accsettingButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!-----------------------------end asssetting code------------------------------------------------>
<!--------------------guard petroling start------------------------------------------------------->
<!----------------------end code-------------------------------------------------------------------->
<!---------------------logout start---------------------------------------------------------->
<div id="logout" class="report" onclick="logout()"  style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em">
<asp:Label ID="logoutmgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="logoutDiv2"  style=" width:440px; height:25px;display:none;border:1px solid #CCC">
<asp:UpdatePanel ID="logoutupdate" runat="server"><ContentTemplate>
<asp:CheckBox ID="logoutCB1" runat="server"  AutoPostBack="true"
        style="top: 510px; left: -3px; position: absolute; height: 21px; width: 169px" 
        oncheckedchanged="logoutCB1_CheckedChanged" />
<asp:CheckBox ID="logoutredCB1" runat="server"  style="top:510px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" Text="ReadOnly" />
<asp:CheckBox ID="logoutwrCB1" runat="server" style="top:510px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel35" runat="server"><ContentTemplate>
<asp:Button ID="logoutButton1" runat="server" Text="save" style="top: 510px; left: 360px; position: absolute; height: 21px; width: 76px" onclick="logoutButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></ContentTemplate></asp:UpdatePanel></div>
<!-----------------------------end code------------------------------------------------->
<!--------------------------facility mgmt start----------------------------------------->
<div id="facility" class="report" onclick="facility()" style=" width:440px; height:20px; background-color:#EEEEEE;cursor:pointer;border:1px solid #CCC;font-size:0.87em; display:none">
<asp:Label ID="facilitymgmt" runat="server" Text="" style="font-size:18px;letter-spacing:-1px; padding-bottom: 5px;font-weight:500"> </asp:Label></div>
<div id="facilityDiv2"  style=" width:440px; height:25px;display:none;border:1px solid #CCC">
<asp:CheckBox ID="facilityCB1" runat="server" style="top: 683px; left: 0px; position: absolute; height: 21px; width: 186px" />
<asp:CheckBox ID="facilityredCB1" runat="server" style="top:683px; left: -2px; position: absolute; height: 21px; width: 86px; left:191px" 
 Text="ReadOnly" />
<asp:CheckBox ID="facilitywrCB1" runat="server" style="top:683px; left: -2px; position: absolute; height: 21px; width: 86px; left:277px" 
Text="WriteOnly" />
<asp:UpdatePanel ID="UpdatePanel34" runat="server"><ContentTemplate>
<asp:Button ID="facilityButton1" runat="server" Text="save" style="top: 683px; left: 360px; position: absolute; height: 21px; width: 76px" 
onclick="facilityButton1_Click"   OnClientClick="JavaScript:alert('save')"/>
</ContentTemplate></asp:UpdatePanel></div>
<!------------------end facility code-------------------------------------------------->
<!----------------------feedback start------------------------------------------------>
<!--------------end feedback code-------------------------------------------------------->
    </asp:Panel>

            <div style=" margin-top:4.3em; margin-left:.5em">
            <telerik:RadMenu ID="rdDBMenu" runat="server" Flow="Vertical" BackColor="White"  
                EnableRoundedCorners="true" Font-Bold="True" EnableShadows="true"  
                ExpandDelay="500" ForeColor="#66CCFF" Height="50px" Style="z-index:2;font-size:xx-large" 
                Width="255px" EnableAutoScroll="true" EnableEmbeddedScripts="True" 
                GroupSettings-ExpandDirection="Down" OnItemClick="rdDBMenu_ItemClick" >
                <ExpandAnimation Type="InOutQuad"/>
                <DefaultGroupSettings ExpandDirection="Down" />
            </telerik:RadMenu>
            </div>
<asp:Panel ID="progress" runat="server" style=" margin-top:0px">
        <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="upanel2" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="eveUpdate1" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="eveupdate2" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress3" AssociatedUpdatePanelID="shiftupdate1" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress4" AssociatedUpdatePanelID="shiftUpdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress5" AssociatedUpdatePanelID="assignupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress6" AssociatedUpdatePanelID="locationupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
         <asp:UpdateProgress ID="UpdateProgress7" AssociatedUpdatePanelID="inventory" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress8" AssociatedUpdatePanelID="checkinupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress9" AssociatedUpdatePanelID="dtupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress10" AssociatedUpdatePanelID="viewupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress11" AssociatedUpdatePanelID="alertupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress13" AssociatedUpdatePanelID="followupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress12" AssociatedUpdatePanelID="dashupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress14" AssociatedUpdatePanelID="maintenanceupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress15" AssociatedUpdatePanelID="emergencyupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress16" AssociatedUpdatePanelID="sopupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress17" AssociatedUpdatePanelID="staffupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress18" AssociatedUpdatePanelID="createupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress19" AssociatedUpdatePanelID="permissionupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress20" AssociatedUpdatePanelID="mpddupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress21" AssociatedUpdatePanelID="accountupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress22" AssociatedUpdatePanelID="logupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress23" AssociatedUpdatePanelID="logoutupdate" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/process.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
</asp:Panel>

    <!-------------------------------------------------->

<!----------------------end tree view--------------------------------------------->    
<asp:Panel ID="lblpanel" runat="server" Font-Bold="True" 
       ForeColor="Blue" style="top:-0.3em; left:1.23em; position: absolute; height: 26px; width:720px;font-family:Arial Verdana; font-weight:500; letter-spacing:0em; font-size:21px" 
 BackColor="White" >
<asp:Label ID="Label1" runat="server" BackColor="White"
   Forecolor="Blue"   style="margin-left:0.5em;"
 Text="Select user" Width="17em"></asp:Label>
<asp:Label ID="Label3" runat="server" 
       ForeColor="Blue" style="margin-left:.5em" 
 Text="Set Permission"></asp:Label>
 </asp:Panel>
    </asp:Panel>
</html>

</asp:Content>
