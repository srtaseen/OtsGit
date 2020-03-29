<%@ Page Language="C#" AutoEventWireup="true" CodeFile="page10.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>User Permission </title>
    <link href="Styles/CSS.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/TnaGridView.css" rel="stylesheet" type="text/css" />
    <link href="NECESSARY%20PLUGINS/Font%20awsome/font-awesome-4.4.0/css/font-awesome.min.css"
        rel="stylesheet" type="text/css" />
    <link href="NECESSARY%20PLUGINS/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="NECESSARY%20PLUGINS/js/bootstrap.min.js" type="text/javascript"></script>
    
</head>
<body style="margin: 0; padding: 0">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
          <div style="margin-top: 5px; margin-left: 0px; width: 100%; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #FFFFFF; padding-bottom: 4px;">
            <span class="spanText" style="padding-left: 4px">User Name</span><asp:DropDownList 
                  ID="ddl" runat="server" Width="150px" CssClass="dropdown" AppendDataBoundItems="True"
                            AutoPostBack="True" Font-Size="11px" 
                  onselectedindexchanged="ddl_SelectedIndexChanged" >
                            <asp:ListItem Text="-"></asp:ListItem>
                        </asp:DropDownList>

          </div>
             <div style="margin-top: 2px; float: left; width: 100%; height: 16px; ">
                <span style="float: left; padding-left: 4px; font-weight: bold; font-family: Arial, Helvetica, sans-serif;
                    font-size: 12px;">Access Control List</span>
            </div>
            <div style="margin-top: 4px; float: left; width: 100%; height: 420px;  font-family: Arial, Helvetica, sans-serif; font-size: 11px;"
                id="div1" runat='server'>
                <table >
                    <tr>
                   
                        <td bgcolor="#00a4ef" style="border: 1px solid #00a4ef">
                            <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;
                                color: #FFFFFF;">Menu</span>
                        </td>
                         <td bgcolor="#00a4ef" style="border: 1px solid #00a4ef">
                            <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;
                                color: #FFFFFF;">Access</span>
                        </td>
                        <td bgcolor="#00a4ef" style="border: 1px solid #00a4ef">
                            <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;
                                color: #FFFFFF;">Form Allow</span>
                        </td>
                          <td bgcolor="#00a4ef" style="border: 1px solid #00a4ef">
                          <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;
                                color: #FFFFFF;">Button </span>
                        </td>
                        <td bgcolor="#00a4ef" style="border: 1px solid #00a4ef">
                           <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;
                                color: #FFFFFF;">Button </span>
                        </td>
                         <td bgcolor="#00a4ef" style="border: 1px solid #00a4ef">
                           <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;
                                color: #FFFFFF;">Button </span>
                        </td>
                       
                    </tr>
                    <tr>
                        <td width="100px" rowspan="5" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;">
                                MERCHANDISING</span>
                        </td>
                        <td width="80px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef" 
                            rowspan="5">
                            <asp:CheckBox ID="cb1" runat="server" /><asp:Label ID="lb1" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td width="100px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb11" runat="server" Text="Order Master" />  <asp:Label ID="lb2" runat="server" Visible="False"></asp:Label>
                        </td>
                     
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                             <asp:CheckBox ID="cb111" runat="server" Text="Save" /><asp:Label ID="lblb1" runat="server" Visible="False"></asp:Label>
                        </td>
                        
                        <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           <asp:CheckBox ID="cb1111" runat="server" Text="Edit" /><asp:Label ID="lblb6" runat="server" Visible="False"></asp:Label>
                        </td>
                       <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                        </td>
                       
                    </tr>
                    <tr>
                        <%-- <td bgcolor="#f2f9fe">
         <span class="span1">Order Master</span>
         </td>--%>
                         <td width="100px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb12" runat="server" Text="Assortment" /><asp:Label ID="lb3" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                           <asp:CheckBox ID="cb112" runat="server" Text="Save" /><asp:Label ID="lblb2" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                            
                        </td>
                        <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                        </td>
                    </tr>
                    <tr>
                        <%-- <td bgcolor="#f2f9fe">
         <span class="span1">Order Position</span>
         </td>--%>
                       <td width="100px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                       <asp:CheckBox ID="cb13" runat="server" Text="Create T&A" /><asp:Label ID="lb4" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb113" runat="server" Text="Load" /> <asp:Label ID="lblb3" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                             <asp:CheckBox ID="cb1113" runat="server" Text="Load" /> <asp:Label ID="lblb8" runat="server" Visible="False"></asp:Label> 
                        </td>
                        <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                        </td>
                    </tr>
                    <tr>
                        <%-- <td bgcolor="#e8f2ff">
         <span class="span1">T & A Create</span>
         </td>--%>
                        <td width="100px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                       <asp:CheckBox ID="cb14" runat="server" Text="Approve T&A" /><asp:Label ID="lb5" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                           <asp:CheckBox ID="cb114" runat="server" Text="Approved" />  <asp:Label ID="lblb4" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                          
                        </td>
                         <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                        </td>
                     
                    </tr>
                    <tr>
                        <%-- <td bgcolor="#e8f2ff">
         <span class="span1">T & A Approved</span>
         </td>--%>
                       <td width="100px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                       <asp:CheckBox ID="cb15" runat="server" Text="Reload T&A" /><asp:Label ID="lb6" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb115" runat="server" Text="Reload" /><asp:Label ID="lblb5" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb1115" runat="server" Text="Customize" /> <asp:Label ID="lblb10" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                           
                        </td>
                        
                    </tr>
                 
                    <tr>
                        <td width="100px" rowspan="5" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;">
                                TEXTILE</span>
                        </td>
                        <%--<td bgcolor="#f2f9fe">
         <span class="span1">Merchandising</span>
         </td>--%>
                        <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef" rowspan="5">
                         
                            <asp:CheckBox ID="cb2" runat="server" Text="" /><asp:Label ID="lb7" runat="server" Visible="False"></asp:Label>
                         
                        </td>
                       <td bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb21" runat="server" Text="Yarn" /> <asp:Label ID="lb8" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                           
                        </td>
                          <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                            
                        </td>
                          <td width="70px" bgcolor="#e8f2ff" style="border: 1px solid #00a4ef">
                            
                        </td>
                    </tr>
                    <tr>
                        <%--<td bgcolor="#f2f9fe">
         <span class="span1">Yarn Supply</span>
         </td>--%>
                       <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb22" runat="server" Text="Yarn Dye" /><asp:Label ID="lb9" runat="server" Visible="False"></asp:Label> 
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           
                        </td>
                          <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            
                        </td>
                          <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            
                        </td>
                    </tr>
                    <tr>
                        <%--         
         <td bgcolor="#f2f9fe">
         <span class="span1">Yarn Dyeing</span>
         </td>--%>
                       <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb23" runat="server" Text="Knitting" /><asp:Label ID="lb10" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           
                        </td>
                          <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            
                        </td>
                          <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            
                        </td>
                    </tr>
                    <tr>
                        <%--   <td bgcolor="#f2f9fe">
        <span class="span1">Knitting</span>
         </td>--%>
                       <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb24" runat="server" Text="Dyeing" /><asp:Label ID="lb11" runat="server" Visible="False"></asp:Label> 
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           
                        </td>
                          <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            
                        </td>
                          <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            
                        </td>
                    </tr>
                    <tr>
                        <%--    <td bgcolor="#f2f9fe">
         <span class="span1">Dyeing</span>
         </td>--%>
                       <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <asp:CheckBox ID="cb25" runat="server" Text="AOP" /><asp:Label ID="lb12" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           
                        </td>
                          <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            
                        </td>
                          <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            
                        </td>
                    </tr>
                    <tr>
                        <%--         <td bgcolor="#f2f9fe">
        <span class="span1">AOP</span>
         </td>--%>
                        <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;">
                                ACCESSORIES</span> 
                        </td>
                        <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                             <asp:CheckBox ID="cb3" runat="server" Text="" /><asp:Label ID="lb13" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           
                        </td>
                    </tr>
                    <tr>
                        <%--         <td bgcolor="#f2f9fe">
         <span class="span1">Accessories</span>
         </td>--%>
                        <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                            <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;">
                                INVENTORY</span> 
                        </td>
                        <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           <asp:CheckBox ID="cb4" runat="server" Text="" /><asp:Label ID="lb14" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           
                        </td>
                    </tr>
                    <tr>
                        <%--  
         <td bgcolor="#f2f9fe">
         <span class="span1">Inventory</span>
         </td>--%>
                        <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;">
                                RMG</span> 
                        </td>
                         <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                             <asp:CheckBox ID="cb5" runat="server" Text="" /><asp:Label ID="lb15" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           
                        </td>
                    </tr>
                    <tr>
                        <%-- <td bgcolor="#f2f9fe">
        <span class="span1">Embroidery</span>
         </td>--%>
                        <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;">
                                REPORTS</span>  
                        </td>
                         <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                             <asp:CheckBox ID="cb6" runat="server" Text="" /><asp:Label ID="lb16" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           
                        </td>
                    </tr>
                    <tr>
                        <%-- <td bgcolor="#f2f9fe">
        <span class="span1">Printing</span>
         </td>--%>
                        <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           <span style="padding-left: 4px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;">
                                SETUP</span>  
                        </td>
                         <td bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                             <asp:CheckBox ID="cb7" runat="server" Text="" /><asp:Label ID="lb17" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td width="70px" bgcolor="#f2f9fe" style="border: 1px solid #00a4ef">
                           
                        </td>
                    </tr>
       
                </table>
            </div>
            <div style="float: left; margin-top: 3px; margin-left: 4px; margin-bottom: 8px">
                <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-primary" 
                    Text="Update" onclick="BtnUpdate_Click" />
                     <asp:Button ID="BtnCancle" runat="server" CssClass="btn btn-primary" 
                    Text="Cancel" onclick="BtnCancle_Click"  />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
