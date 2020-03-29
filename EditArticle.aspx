<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditArticle.aspx.cs" Inherits="EditArticle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OTS | OrderEdit</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/TnaGridView.css" rel="stylesheet" type="text/css" />
        <link href="NECESSARY%20PLUGINS/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="NECESSARY%20PLUGINS/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="NECESSARY%20PLUGINS/Font%20awsome/font-awesome-4.4.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
       <link href="Styles/TnaGridView.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <script type="text/javascript">
<!--
    function OnClose() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.HideModalDiv();
        }
    }
    window.onunload = OnClose;
    //-->
    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="background-color: #3a5795; width: 100%; height: 20px; float: left">
                <span class="spanText" style="padding-top: 8px; color: #FFFFFF; padding-left: 4px">EDIT
                    ORDER INFORMATION</span>
            </div>
            <div style="width: 100%; height: 300px; float: left; margin-top: 4px; overflow: auto;">
                <div style="float: left">
                    <table class="Ord_EditTab">
                        <tr>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; text-align: right;
                                color: #333333; font-weight: bold; width: 150px; padding-right: 4px;">
                                ORDER NUMBER
                            </td>
                            <td width="155px">
                                <asp:DropDownList ID="ddstyle" runat="server" CssClass="textbox" Width="152px">
                                    <asp:ListItem Text="-"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="70px">
                                <asp:Button ID="btnfindOrdEdit" runat="server" Text="Find" CssClass="btn-primary small" OnClick="btnfindOrdEdit_Click" BorderStyle="None"/>
                            </td>
                            <td width="70px">
                             <%--   <asp:Button ID="btnclear2" runat="server" Text="Clear" CssClass="Button_1" OnClick="btnclear2_Click" />--%>
                            </td>
                            <td>
                              <%--  <asp:Label ID="lbleditmsg" runat="server" CssClass="lblmsg" Text="You are not permitted for Edit Operation"></asp:Label>--%>
                            </td>
                        </tr>
                    </table>
                </div>
                </br>
                <asp:GridView ID="gvedit" runat="server" AutoGenerateColumns="False" CellPadding="2" PagerSettings-PageButtonCount="5" PagerSettings-Position="Bottom" OnPageIndexChanging="gvedit_PageIndexChanging"
                    GridLines="None" PageSize="16" AllowPaging="True" CssClass="gridcss2" DataKeyNames="art_id"
                    OnRowEditing="OnRowEditing" OnRowUpdating="gvedit_RowUpdating" OnRowCancelingEdit="gvedit_RowCancelingEdit"
                    EmptyDataText="No records has been added.">
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                   <HeaderStyle CssClass="gridheade" />
                    <PagerSettings PageButtonCount="5" />
                    <Columns>
                       <%-- <asp:TemplateField HeaderText="BUYER">
                            <ItemTemplate>
                                <asp:Label ID="lblbuyr" runat="server" Text='<%# Eval("byr_nm")%>' CssClass="Gridtextbox1"
                                    Font-Size="11px" Width="80px"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt" runat="server" Text='<%# Eval("byr_nm")%>' CssClass="Gridtextbox"
                                    Enabled="False" Width="80px"></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle CssClass="ord_hdr" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Article Name">
                            <ItemTemplate>
                                <asp:Label ID="lblart" runat="server" Text='<%# Eval("art_no")%>' CssClass="Gridtextbox1"
                                    Width="80px"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtartno" runat="server" Text='<%# Eval("art_no")%>' CssClass="Gridtextbox"
                                    Width="80px"></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle CssClass="ord_hdr" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("art_quantity")%>' CssClass="Gridtextbox1"
                                    Width="80px"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtquantity" runat="server" Text='<%# Eval("art_quantity")%>' CssClass="Gridtextbox"
                                    Width="80px"></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle CssClass="ord_hdr" />
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="Garments Type">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("art_item")%>' CssClass="Gridtextbox1"
                                    Font-Size="11px" Width="80px"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblgtype" runat="server" Text='<%# Eval("art_item")%>' Visible = "false"></asp:Label>
                                <asp:DropDownList ID = "ddlgtype" runat = "server">
                                 </asp:DropDownList>
                            </EditItemTemplate>
                            <HeaderStyle CssClass="ord_hdr" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="SMV">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("art_smv")%>' CssClass="Gridtextbox1"
                                    Font-Size="11px" Width="80px"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="textsmv" runat="server" Text='<%# Eval("art_smv")%>' CssClass="Gridtextbox"
                                    Width="80px" Font-Size="11px"></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle CssClass="ord_hdr" />
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="Smv">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Smv")%>' CssClass="Gridtextbox1"
                                    Font-Size="11px" Width="80px"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="textsmv" runat="server" Text='<%# Eval("Smv")%>' CssClass="Gridtextbox"
                                    Width="80px" Font-Size="11px"></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle CssClass="ord_hdr" />
                        </asp:TemplateField>--%>

                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ButtonType="Button">
                            <ControlStyle CssClass="btn-primary small" />
                         <%--   <ItemStyle Width="150px" Font-Size="11px" />--%>
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
                </br>
                <p style="padding: 0px; margin: 0px 0px 0px 4px; float: left">
                      <%--  <asp:Button ID="Button1" runat="server" Text="Clear" CssClass="Button_1"  onclick="btnclear2_Click" />--%>
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
