<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportDyeingstatus.aspx.cs" Inherits="reportsaspx_ReportDyeingstatus" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">

        </asp:ScriptManager>
        <div style="float: left; width:810px; margin-top: 5px; background-color: #FFFFFF; margin-left: 2px">
            
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"  Width="100%" Height="1200px">
            <LocalReport ReportPath="reports\DyeingStatus.rdlc">
            </LocalReport>
             </rsweb:ReportViewer>

        </div>
    
    </div>
    </form>
</body>
</html>
