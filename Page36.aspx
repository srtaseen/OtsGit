<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page36.aspx.cs" Inherits="Page4_" %>

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
        <span class="spanText" style="padding-top: 8px; color: #FFFFFF; padding-left: 4px">Add New </span>
       
    </div>
    <div  style=" margin: 6px 0% 10px 0%; padding: 1%; width: 99%; height: 400px; float: left; ">
        <asp:GridView ID="Gvousr" runat="server" AutoGenerateColumns="False" CssClass="gridcss"
                                         OnRowDataBound="Gvousr_RowDataBound" 
                                        BorderColor="White" BorderStyle="Solid" BorderWidth="1px">
                                        <RowStyle CssClass="RowStyle" />
                                        <AlternatingRowStyle BackColor="#F2F9FE" ForeColor="#284775" />
                                        <FooterStyle Wrap="False" />
                                        <HeaderStyle Wrap="False" />
                                        <PagerSettings PageButtonCount="5" />
                                      <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                     
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <th colspan="6" >
                                                        Pending User List 
                                                    </th>
                                                    <tr>
                                                        <th>
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" >
                                                            User ID
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap">
                                                            Email
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" >
                                                            Name
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" >
                                                            Department
                                                        </th>
                                                      
                                                        <th class="gridheade" nowrap="nowrap" >
                                                            APPROVED / CANCLE
                                                        </th>
                                                        <th></th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td nowrap="nowrap" align="center" width="100px">
                                                        <asp:Label ID="Label1" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("Username")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label8" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("Email")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label2" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("usrnm")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label3" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("UsrDpt" )%>'></asp:Label>
                                                    </td>
                                                   
                                                  
                                                    <td align="center" nowrap="nowrap">
                                                        <asp:Label ID="lblapprove" Visible="false" runat="server" Text='<%# Eval("UserId")%>'></asp:Label>
                                                        
                                                        <asp:Button ID="btnapprove" Enabled="False" Text='<%# Eval("UsrApprove")%>'
                                                            runat="server" OnClick="btnapprove_Click" Width="65px" CssClass="btn1" Font-Size="10px" />
                                                        <asp:Button ID="btncancle" Enabled="False" CssClass="btn2" Text='<%# Eval("UsrApprove")%>'
                                                            runat="server" OnClick="btncancle_Click" Width="65px" Font-Size="10px" />
                                                    </td>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField />
                                        </Columns>
                                    </asp:GridView>
    </div>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
