<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="PolicyStatement.aspx.cs" Inherits="SMS.SuperVisor.PolicyStatement"
    Title="Untitled Page" %>

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
   
     <div class="divHeader">
                <span class="pageTitle">POLICY STATEMENT</span></div>
            <br />
        <asp:Panel ID="printview" runat="server" BackColor="White" Style="margin-left: 1.5em"
            Font-Bold="True" Width="700px">
           
            <b>XYZ PROTECTION PTE LTD</b> is involved in the provision of security services
            in both the residential and commercial industries.
            <p>
                It is the policy of <b>XYZ Protection Pte Ltd</b> to provide efficient,prompt and
                courteous services through the use of qualified staff and effective work procedures.
                We recognise that consistent product and service quality will ensure a high degree
                of client satisfaction,repeat business and continued growth.
            </p>
            <p>
                We also recognise that quality is important to our clients so we ensure their requirement
                are suitably fulfilled. We provide customer satisfaction through our quality processes,co-ordination
                and quality service.
            </p>
            <br />
            Our main objectives are to :
            <li>meet with clients at least twice a month to obtain feedback</li>
            <li>provide bi-monthly OJT/refresher training for our personnel stationed at our premier
                assignments</li>
            <li>ensure an average of at least 70% of suppliers achieving a grading of satisfactory
                or better</li>
            <li>ensure minimum absenteeism at our client's sites</li>
            <p>
                To ensure that these objectives are met,our business has adopted a quality system
                that complies with the International Standard ISO 9001:2000. This Quality System
                should provide clients with the assurance that the projects completed by <b>XYZ Protection
                    Pte Ltd</b> will be of a consistent high standard.
            </p>
            <p>
                All employees of our company are aware of these quality objectives and strive to
                meet with them.
            </p>
            <p>
                The Management is committed to ensure :
                <li>that all statutory and regulatory requirements are complied with, and</li>
                <li>the implementation, and maintenance of this quality system</li>
                <li>that every employee to contributes and supports, within their sphere of influence,
                    our mission.</li>
            </p>
            <p>
                Evidence of our company's commitment to develop and continually improve the quality
                management system is through reviewing the quality objectives,changing them as required,regular
                review meetings,conducting internal quality audits,regular inspections of services,
                and implementing corrective and preventative actions.
            </p>
            <p>
                Customer satisfaction is monitored through regular customer feedback.
            </p>
        </asp:Panel>
        <br />
        <div style="background-color: #E4E4E4;">
            <center>
             <%--<a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>
--%>
                <asp:Button ID="btnprint" CssClass="Button" Height="30px" Width="100px" runat="server"
                    Text="Print" OnClientClick="javascript:PrintGridData();" />
            </center>
        </div>
    
</asp:Content>
