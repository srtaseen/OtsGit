<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditOrder.aspx.cs" Inherits="EditOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
                    GridLines="None" PageSize="16" AllowPaging="True" CssClass="gridcss2" DataKeyNames="ord_id"
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
                        <%--<asp:TemplateField HeaderText="Order No">
                            <ItemTemplate>
                                <asp:Label ID="lblord" runat="server" Text='<%# Eval("ord_no")%>' CssClass="Gridtextbox1"
                                    Width="80px"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtordno" runat="server" Text='<%# Eval("ord_no")%>' CssClass="Gridtextbox"
                                    Width="80px"></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle CssClass="ord_hdr" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Factory">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ord_factory")%>' CssClass="Gridtextbox1"
                                    Width="80px"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtfactory" runat="server" Text='<%# Eval("ord_factory")%>' CssClass="Gridtextbox"
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
                        <%--<asp:TemplateField HeaderText="SMV">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("art_smv")%>' CssClass="Gridtextbox1"
                                    Font-Size="11px" Width="80px"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="textsmv" runat="server" Text='<%# Eval("art_smv")%>' CssClass="Gridtextbox"
                                    Width="80px" Font-Size="11px"></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle CssClass="ord_hdr" />
                        </asp:TemplateField>--%>
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
</asp:Content>

