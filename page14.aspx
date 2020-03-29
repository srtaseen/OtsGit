<%@ Page Language="C#" AutoEventWireup="true" CodeFile="page14.aspx.cs" Inherits="Page4_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OTS | UserSettings</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/TnaGridView.css" rel="stylesheet" type="text/css" />
   

</head>
<body>



    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    
    <div style="background-color: #3a5795; width: 100%; height: 20px; float: left">
        <span class="spanText" style="padding-top: 8px; color: #FFFFFF; padding-left: 4px">
            Enable User</span>
          
      

    </div>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
