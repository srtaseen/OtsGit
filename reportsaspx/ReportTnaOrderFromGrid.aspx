<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportTnaOrderFromGrid.aspx.cs" Inherits="rp1t" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
                                  <%--  <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" 
                                        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="12pt"  
                                        Height="470px" Width="100%" >
                                             <LocalReport ReportPath="reports\OrderTnaReport.rdlc">
                                             </LocalReport>
                                    </rsweb:ReportViewer>--%>
                             
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"  Width="100%" Height="1200px">
            <LocalReport ReportPath="reports\OrderTnaReport.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
           </div>
    
    </div>
    </form>
</body>
</html>
