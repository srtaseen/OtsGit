﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IELayoutFReport.aspx.cs" Inherits="IELayoutFReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 632px">
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
            <LocalReport ReportPath="reports\IELayoutFRDLC.rdlc"></LocalReport>


        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>