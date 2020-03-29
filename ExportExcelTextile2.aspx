<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportExcelTextile2.aspx.cs" Inherits="ExportExcelTextile2" %>

 <html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>EXPORT OTS TNA TO EXCEL</title>
</head>
<body>
<form id="form1" runat="server"> 
<div style="margin-left:50px;">
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95"
                            NavigateUrl="~/page15.aspx"><i class="fa fa-home"></i>BACK TO TEXTILE HOME</asp:HyperLink>
    </div>
    
    <div style="margin-top:20px;">
        <span class="spanText" style="color: black;">SELECT BUYER</span>
    </div>
    <div style="margin-top:5px;float:left;margin-right:20px;">
        
        <asp:DropDownList ID="ddlbuyerK" CssClass="textbox" runat="server" Width="152px" 
                                                Font-Size="11px" >
                                                  <asp:ListItem Text="--"></asp:ListItem>
                                            </asp:DropDownList>
    </div>
    

    <div>
    <asp:Button ID="btnExport" Text="Export Data" runat="server" onclick="btnExport_Click" />
    </div>
</div>
</form>
</body>
</html>