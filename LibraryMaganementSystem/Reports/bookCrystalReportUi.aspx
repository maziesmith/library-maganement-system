<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookCrystalReportUi.aspx.cs" Inherits="UniversityManagementSystem.Reports.bookReportUi" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Button" />
&nbsp;
        <br />
        <a href="bookCrystalReportUi.aspx">bookCrystalReportUi.aspx</a>
        <a href="bookCrystalReportUi.aspx">bookCrystalReportUi.aspx</a>
&nbsp;
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" Height="50px" ReportSourceID="CrystalReportSource1" ToolPanelWidth="200px" Width="350px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
             <Report FileName="..\Reports\bookCrystalReport.rpt"></Report>
             <%-- <Report FileName="~/Reports/bookCrystalReport.rpt">--%>
             </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
