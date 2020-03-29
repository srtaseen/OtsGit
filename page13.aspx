<%@ Page Language="C#" AutoEventWireup="true" CodeFile="page13.aspx.cs" Inherits="Page4_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OTS | UserSettings</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/TnaGridView.css" rel="stylesheet" type="text/css" />
    <link href="Styles/popupwindow.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="NECESSARY%20PLUGINS/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="NECESSARY%20PLUGINS/Font%20awsome/font-awesome-4.4.0/css/font-awesome.min.css"
        rel="stylesheet" type="text/css" />
    <script src="NECESSARY%20PLUGINS/js/bootstrap.min.js" type="text/javascript"></script>
 

</head>
<body>



    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    
   <%-- <div style="background-color: #3a5795; width: 100%; height: 20px; float: left">
        <span class="spanText" style="padding-top: 8px; color: #FFFFFF; padding-left: 4px">
            User Profile</span>

    </div>--%>
    <div style=" width: 98%; height: 400px; float: left; margin-top: 8px; margin-right: 1%; margin-left: 1%; padding-left: 8px;">
        <div style="float: left; padding: 10px">
        <span class="text-primary" style="width: 150px" >Search</span>
        <asp:DropDownList ID="ddl" runat="server" CssClass="dropdown" AutoPostBack="True" 
                onselectedindexchanged="ddl_SelectedIndexChanged">
                <asp:ListItem>-</asp:ListItem>
        </asp:DropDownList>
         
        <br /><br />
        <table style="border-collapse: separate; border-spacing: 2px; font-size: 12px;">
        <tr>
        <td width="150px">
          <span class="text-primary">User ID</span>
        </td>
        <td width="300px">
            <asp:TextBox ID="l1" runat="server" CssClass="textbox" width="40%" Enabled="False" 
               ></asp:TextBox>
            <asp:Label ID="l9" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="l10" runat="server" ></asp:Label>
        </td>
        </tr>
        <tr>
        <td>
         <span class="text-primary">Email</span>
        </td>
        <td >
         <asp:TextBox ID="l7" runat="server" CssClass="textbox" width="95%" 
                Enabled="False" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
         <span class="text-primary">Full Name</span> 
        </td>
        <td>
            <asp:TextBox ID="l2" runat="server" CssClass="textbox" width="95%" Enabled="False"
            ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        <span class="text-primary">Password</span>
        </td>
        <td>
         <asp:TextBox ID="l3" runat="server" CssClass="textbox" width="60%" 
                Enabled="False" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
         <span class="text-primary">Department</span>
        </td>
        <td>
          <asp:TextBox ID="l4" runat="server" CssClass="textbox" width="60%" 
                Enabled="False" ></asp:TextBox>
            <asp:DropDownList ID="d1" runat="server" CssClass="textbox" width="60%">
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
         <span class="text-primary">Company</span>
        </td>
        <td >
         <asp:TextBox ID="l6" runat="server" CssClass="textbox" width="60%" 
                Enabled="False" ></asp:TextBox>
        </td>
        </tr>
         <tr>
        <td>
         <span class="text-primary">User Group</span>
        </td>
        <td >
         <asp:TextBox ID="l12" runat="server" CssClass="textbox" width="60%" 
                Enabled="False" ></asp:TextBox>
         <asp:DropDownList ID="d3" runat="server" CssClass="textbox" width="60%">
            </asp:DropDownList>
        </td>
        </tr>
         <tr>
        <td>
         <span class="text-primary">Buyer Type</span>
        </td>
        <td >
         <asp:TextBox ID="l11" runat="server" CssClass="textbox" width="60%" 
                Enabled="False" ></asp:TextBox>
      <asp:DropDownList ID="d2" runat="server" CssClass="textbox" width="60%">
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
         <span class="text-primary">Create Date</span>
        </td>
        <td >
         <asp:TextBox ID="l8" runat="server" CssClass="textbox" width="60%" 
                Enabled="False" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
         <span class="text-primary">Last Login Time</span>
        </td>
        <td >
         <asp:TextBox ID="l5" runat="server" CssClass="textbox" width="60%" 
                Enabled="False" ></asp:TextBox>
        </td>
        </tr>
         <tr>
        <td height="10px">
         
        </td>
        <td >
          
        </td>
        </tr>
         <tr>
        <td>
         
        </td>
        <td >
            <asp:Button ID="btnedit" runat="server" Text="Edit" Width="70px" CssClass="btn btn-primary" 
                onclick="btnedit_Click" />
                 <asp:Button ID="btnup" runat="server" Text="Update" Width="70px" 
                CssClass="btn btn-primary" onclick="btnup_Click" 
               />
                 <asp:Button ID="btncncl" runat="server" Text="Cancle" Width="70px" 
                CssClass="btn btn-primary" onclick="btncncl_Click" />
        </td>
        </tr>
        </table>
      
        </div>
    </div>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
