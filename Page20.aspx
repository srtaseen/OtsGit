<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.master" AutoEventWireup="true"
    CodeFile="Page20.aspx.cs" Inherits="Page12" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="Styles/ajaxTab.css" rel="stylesheet" type="text/css" />
    <div class="FldFream2">
        <div class="divnv">
            <div style="float: left">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME </asp:HyperLink>
                <%--<asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" BackColor="#ECF1FF"
                    NavigateUrl="~/Page18.aspx"><i class="fa fa-caret-left"></i> ORDER SCHEDULE </asp:HyperLink>--%>
                     <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnkD" 
                    BackColor="#ECF1FF" Font-Underline="False"><i class="fa fa-th"></i> TIME & ACTION PLAN</asp:HyperLink>
            </div>
        </div>
        <div class="divbody2">
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="Tab">
                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Merchandising">
                    <ContentTemplate>
                        <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddbuyerM" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindM" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindM_Click" />
                                    </td>
                                    <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchM" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchM" runat="server" Text="Search" OnClick="btnSearchM_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left; overflow: auto; width: 99.9%;">
                            <asp:GridView ID="GvM" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                CssClass="gridcss4" OnRowDataBound="GvM_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5"
                                PagerSettings-Position="Bottom" PageSize="16" OnPageIndexChanging="GvM_PageIndexChanging">
                                <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                    BorderWidth="1px" Height="18px" />
                                <RowStyle CssClass="RowStyle" />
                                <FooterStyle Wrap="False" />
                                <HeaderStyle Wrap="False" />
                                <HeaderStyle CssClass="gridheade" />
                                <PagerSettings PageButtonCount="5" />
                                <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <th colspan="71">
                                                <span style="padding-left: 10px; float: left">MERCHANDISING EVENTS</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    SL-No
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap" width="120px">
                                                    OrderNo
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap" width="120px">
                                                    ArticleNo
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap" width="200px">
                                                    PoNumber
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Quantity
                                                </th>

                                                <%--entry date--%>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Order Entry
                                                </th>
                                                <%--entry date--%>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Order Confirm
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Ex-Factory
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Re-Ex-Factory
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Lead
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Available
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Account
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Report
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader3"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader4"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader5"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader6"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader7"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader8"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader9"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader10"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader11"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader12"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader13"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader14"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader15"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader16"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader17"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader18"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader19"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader20"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                    Pcs
                                                </th>
                                                <th>
                                                    Date
                                                </th>
                                                <th>
                                                    Date
                                                </th>
                                                <th>
                                                    Date
                                                </th>
                                                <th>
                                                    Add Days
                                                </th>
                                                <th>
                                                    Days
                                                </th>
                                                <th>
                                                    Days
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
												<th>
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td width="100px" align="center">
                                                <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                    Font-Bold="True" Font-Size="8pt"></asp:Label>
                                            </td>
                                            <td width="112px">
                                                <asp:Label ID="Label7" runat="server" Text="" Width="103px" CssClass="glbl2" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                            <td width="112px">
                                                <asp:Label ID="Label1" runat="server" Text="" Width="103px" CssClass="glbl2" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="" CssClass="glbl2" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                            <%--entry date--%>
                                            <td>
                                                <asp:Label ID="lblordentry" runat="server" Text='<%# Eval("ord_entdt",  "{0:dd/MMM/yyyy}")%>'
                                                    CssClass="glbl" Font-Size="10px"></asp:Label>
                                            </td>

                                            <%--entry date--%>



                                            <td>
                                                <asp:Label ID="lblordconfirm" runat="server" Text='<%# Eval("ord_cnfdate",  "{0:dd/MMM/yyyy}")%>'
                                                    CssClass="glbl" Font-Size="10px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblxfactory" runat="server" Text='<%# Eval("po_xfactory",  "{0:dd/MMM/yyyy}")%>'
                                                    CssClass="glbl" Font-Size="10px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblrexfactory" runat="server" Text='<%# Eval("ReExFactory",  "{0:dd/MMM/yyyy}")%>'
                                                    CssClass="glbl" Font-Size="10px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TnaLedTm")%>' CssClass="glbl"
                                                    Font-Size="10px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldays" runat="server" Text="" CssClass="glbl" Font-Size="10px" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("Username")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="lnkView" Text="Print" CssClass="glbl" NavigateUrl='<%# Eval("po_id", "~/reportsaspx/ReportTnaOrderFromGrid.aspx?po_id={0}") %>'
                                                    Target="iframe_a" runat="server" />
                                            </td>
                                            <%--##---------------##--%>
                                            <td>
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl1",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <%-- <asp:Label ID="lblStlid" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>--%>
                                                <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac1",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                                <%-- <asp:Button ID="btnActualpln" Enabled="false" Text='<%# Eval("Tnaac1","{0:dd/MMM/yyyy}")%>'
                                                    runat="server" CssClass="gbtn" OnClick="btnActualpln_Click" Width="70px" Font-Size="10px" /--%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl2",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac2",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl3",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld3" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac3",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl4",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld4" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac4",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl5",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld5" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac5",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl6" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl6",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld6" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr6" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac6",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl7" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl7",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld7" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr7" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac7",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl8" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl8",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld8" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr8" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac8",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl9" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl9",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld9" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr9" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac9",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl10" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl10",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld10" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr10" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac10",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl11" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl11",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld11" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr11" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac11",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl12" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl12",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld12" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr12" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac12",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl13" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl13",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld13" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr13" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac13",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl14" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl14",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld14" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr14" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac14",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl15" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl15",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld15" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr15" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac15",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl16" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl16",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld16" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr16" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac16",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl17" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl17",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld17" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr17" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac17",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl18" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl18",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld18" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr18" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac18",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl19" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl19",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld19" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr19" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac19",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl20" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl20",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld20" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr20" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac20",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="dv1" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lbltotal" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblRed" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FF8A6C"
                                            Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblredsub" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                            Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                    </td>





                                     <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYl" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSub" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>




                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Yarn">
                    <ContentTemplate>
                        <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlbuyerY" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindY" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindY_Click" />
                                    </td>
                                    <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchY" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchY" runat="server" Text="Search" OnClick="btnSearchY_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left; overflow: auto; width: 99.9%;">
                            <asp:GridView ID="GvY" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                CssClass="gridcss4" OnRowDataBound="GvY_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5"
                                PagerSettings-Position="Bottom" PageSize="17" OnPageIndexChanging="GvY_PageIndexChanging">
                                <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                    BorderWidth="1px" Height="18px" />
                                <RowStyle CssClass="RowStyle" />
                                <FooterStyle Wrap="False" />
                                <HeaderStyle Wrap="False" />
                                <HeaderStyle CssClass="gridheade" />
                                <PagerSettings PageButtonCount="5" />
                                <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <th colspan="20">
                                                <span style="padding-left: 10px; float: left">YARN EVENTS</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    SL-No
                                                </th>
                                                <%--<th  class="gvmid" nowrap="nowrap">
                                                 Buyer
                                                </th>--%>
                                                <th class="gridheade2" nowrap="nowrap" width="120px">
                                                    OrderNo
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap" width="120px">
                                                    ArticleNo
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap" width="120px">
                                                    PoNumber
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Quantity
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Ex-Factory
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblyarnbook"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader3"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader4"></asp:Label>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Rcv: (Qty)
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Remarks
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                    Pending
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td width="100px" align="center">
                                                <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                    Font-Bold="True" Font-Size="8pt"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                            <td>
                                                <%--   <asp:Label ID="Label5" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblryarnbok" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac5",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <%--##---------------##--%>
                                            <td>
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl21",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld1" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac21",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl22",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac22",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl23",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld3" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac23",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl24",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld4" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac24",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label34" runat="server" Text="" CssClass="glbl" Font-Size="10px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("YrnComnt")%>'> </asp:Label>
                                            </td>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div1" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblTtlar" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblTtlar2" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblTtlar3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                            Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                    </td>




                                    <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlY" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSubY" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>





                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Yarn Dyeing">
                    <ContentTemplate>
                        <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlbuyerYD" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindYD" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindYD_Click" />
                                    </td>
                                     <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchYD" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchYD" runat="server" Text="Search" OnClick="btnSearchYD_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left; overflow: auto; width: 99.9%;">
                            <asp:GridView ID="GvYD" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                CssClass="gridcss4" OnRowDataBound="GvYD_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5"
                                PagerSettings-Position="Bottom" PageSize="17" OnPageIndexChanging="GvYD_PageIndexChanging">
                                <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                    BorderWidth="1px" Height="18px" />
                                <RowStyle CssClass="RowStyle" />
                                <FooterStyle Wrap="False" />
                                <HeaderStyle Wrap="False" />
                                <HeaderStyle CssClass="gridheade" />
                                <PagerSettings PageButtonCount="5" />
                                <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <th colspan="16">
                                                <span style="padding-left: 10px; float: left">YARN DYEING EVENTS</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    SL-No
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap" width="120px">
                                                    OrderNo
                                                </th>
                                                 <th class="gridheade2" nowrap="nowrap" width="120px">
                                                    ArticleNo
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap" width="200px">
                                                    PoNumber
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Quantity
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Ex-Factory
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="yrnInhouseStrt"></asp:Label>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="yrnInhouseEnd"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Rcv: (Qty)
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Remarks
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                    Pending
                                                </th>
                                                <th>
                                                    Pending
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td width="100px" align="center">
                                                <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                    Font-Bold="True" Font-Size="8pt"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                            <td>
                                                <%--  <asp:Label ID="Label5" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                            </td>
                                            <td>
                                                <asp:Label ID="yrnInhouseStrt" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac23",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="yrnInhouseEnd" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac24",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <%--##---------------##--%>
                                            <td>
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl56",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac56",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl57",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac57",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label34" runat="server" Text="" CssClass="glbl" Font-Size="10px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("YrnDyComnt")%>'> </asp:Label>
                                            </td>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div2" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblydr" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblydr2" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FF8A6C"
                                            Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblydr3" runat="server" CssClass="lbl1" Text="" Font-Bold="true" Font-Size="13px"
                                            BackColor="#FF8A6C"></asp:Label>
                                    </td>



                                      <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlYD" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSubYD" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>


                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Knitting">
                    <ContentTemplate>
                        <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlbuyerK" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindK" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindK_Click" />
                                    </td>
                                    <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchK" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchK" runat="server" Text="Search" OnClick="btnSearchK_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left; overflow: auto; width: 99.9%;">
                            <asp:GridView ID="GvK" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                CssClass="gridcss4" PageSize="17" OnRowDataBound="GvK_OnRowDataBound" AllowPaging="True"
                                OnPageIndexChanging="GvK_PageIndexChanging">
                                <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                    BorderWidth="1px" Height="18px" />
                                <RowStyle CssClass="RowStyle" />
                                <FooterStyle Wrap="False" />
                                <HeaderStyle Wrap="False" />
                                <HeaderStyle CssClass="gridheade" />
                                <PagerSettings PageButtonCount="5" />
                                <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <th colspan="15">
                                                <span style="padding-left: 10px; float: left">KNITTING EVENTS</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    SL-No
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap" width="120px">
                                                    OrderNo
                                                </th>
                                                 <th class="gridheade2" nowrap="nowrap" width="120px">
                                                    ArticleNo
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap" width="200px">
                                                    PoNumber
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Quantity
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Ex-Factory
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="yrnInhouseStrt"></asp:Label>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="yrnInhouseEnd"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Rcv: (Qty)
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                    Remarks
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                    Pending
                                                </th>
                                                <th>
                                                    Pending
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                    Plan
                                                </th>
                                                <th>
                                                    DD
                                                </th>
                                                <th>
                                                    Actual
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td width="100px" align="center">
                                                <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                    Font-Bold="True" Font-Size="8pt"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                            <td>
                                                <%--<asp:Label ID="Label5" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                            </td>
                                            <td>
                                                <asp:Label ID="yrnInhouseStrt" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac23",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="yrnInhouseEnd" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac24",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <%--##---------------##--%>
                                            <td>
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl25",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac25",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl26",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac26",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label34" runat="server" Text="" CssClass="glbl" Font-Size="10px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblr5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("KntComnt")%>'> </asp:Label>
                                            </td>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div3" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblrk" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblrk2" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FF8A6C"
                                            Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblrk3" runat="server" CssClass="lbl1" Text="" Font-Bold="true" Font-Size="13px"
                                            BackColor="#FF8A6C"></asp:Label>
                                    </td>



                                    <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlK" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSubK" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>

                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Dyeing">
                    <ContentTemplate>
                        <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlbuyerD" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindD" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindD_Click" />
                                    </td>
                                     <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchD" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchD" runat="server" Text="Search" OnClick="btnSearchD_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                        <asp:GridView ID="GvD" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CssClass="gridcss4" PageSize="17" OnRowDataBound="GvD_OnRowDataBound" AllowPaging="True"
                            OnPageIndexChanging="GvD_PageIndexChanging">
                            <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" Height="18px" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <th colspan="15">
                                            <span style="padding-left: 10px; float: left">DYEING EVENTS</span>
                                        </th>
                                        <tr>
                                            <th>
                                            </th>
                                            <th class="gridheade2" nowrap="nowrap">
                                                SL-No
                                            </th>
                                            <th class="gridheade2" nowrap="nowrap" width="120px">
                                                OrderNo
                                            </th>
                                            <th class="gridheade2" nowrap="nowrap" width="120px">
                                                ArticleNo
                                            </th>
                                            <th class="gridheade2" nowrap="nowrap" width="200px">
                                                PoNumber
                                            </th>
                                            <th class="gridheade2" nowrap="nowrap">
                                                Quantity
                                            </th>
                                            <th class="gridheade2" nowrap="nowrap">
                                                Ex-Factory
                                            </th>
                                            <th class="gridheade2" nowrap="nowrap">
                                                <asp:Label runat="server" ID="knitstart"></asp:Label>
                                            </th>
                                            <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                            </th>
                                            <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                            </th>
                                            <th class="gridheade2" nowrap="nowrap">
                                                Fin: (Qty)
                                            </th>
                                            <th class="gridheade2" nowrap="nowrap">
                                                Remarks
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                            </th>
                                            <th>
                                            </th>
                                            <th>
                                            </th>
                                            <th>
                                            </th>
                                            <th>
                                            </th>
                                            <th>
                                            </th>
                                            <th>
                                                Pending
                                            </th>
                                            <th>
                                                Plan
                                            </th>
                                            <th>
                                                DD
                                            </th>
                                            <th>
                                                Actual
                                            </th>
                                            <th>
                                                Plan
                                            </th>
                                            <th>
                                                DD
                                            </th>
                                            <th>
                                                Actual
                                            </th>
                                            <th>
                                            </th>
                                            <th>
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <td width="100px" align="center">
                                            <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                Font-Bold="True" Font-Size="8pt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                        </td>
                                        <td>
                                            <%--<asp:Label ID="Label5" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="knitstart" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac25",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                        </td>
                                        <%--##---------------##--%>
                                        <td>
                                            <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl27",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac27",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl28",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac28",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label34" runat="server" Text="" CssClass="glbl" Font-Size="10px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblr5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("DyeComnt")%>'> </asp:Label>
                                        </td>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField />
                            </Columns>
                        </asp:GridView>
                        <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div4" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblrdyed" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblrdyed2" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblrdyed3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                            Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                    </td>


                                     <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlD" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSubD" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>




                                </tr>
                            </table>
                        </div>
                        <div style="float: left; overflow: auto; width: 99.9%;">
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="AOP">
                    <ContentTemplate>
                        <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlbuyerAOP" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindAOP" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindAOP_Click" />
                                    </td>
                                   <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchA" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchA" runat="server" Text="Search" OnClick="btnSearchA_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                           <asp:GridView ID="GvAOP" runat="server" AutoGenerateColumns="False" CellPadding="2" CssClass="gridcss4"
                                OnRowDataBound="GvAOP_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5" PagerSettings-Position="Bottom" PageSize="17" OnPageIndexChanging="GvAOP_PageIndexChanging">
                                <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" Height="18px" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                    
                                            <th colspan="15" class="gvtop">
                                               <span style="padding-left: 10px; float: left">ALL OVER PRINT</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                     <th class="gridheade2" nowrap="nowrap">
                                                SL-No
                                            </th>
                                                 <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 OrderNo
                                                </th>
                                                 <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 ArticleNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="200px">
                                                PoNumber
                                                </th>
                                              
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                Quantity
                                                </th>
                                                    
                                                  <th  class="gridheade2" nowrap="nowrap">
                                                Ex-Factory
                                                </th>
                                                 
                                                    
                                                
                                               
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                    </th>
                                                     <th  class="gridheade2" nowrap="nowrap">
                                               Fin: (Qty)
                                                </th>
                                                  <th  class="gridheade2" nowrap="nowrap">
                                               Remarks
                                                </th>
                                              
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                               
                                               <th></th>
                                                
                                                 <th class="gvbtm">
                                                  
                                                </th>
                                                <th class="gvbtm">
                                                    
                                                </th>
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                                  
                                                 
                                               
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                <th class="gvbtm">
                                                   DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                  
                                                </th>
                                                <th class="gvbtm">
                                                  
                                                </th>
                                                
                                                
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                         <td width="100px" align="center">
                                            <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                Font-Bold="True" Font-Size="8pt"></asp:Label>
                                        </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label12" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                               <td>
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                          
                                            <td >
                                                <%--<asp:Label ID="Label5" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                            </td>
                                           
                                           
                                          
                                            
                                            <%--##---------------##--%>

                                            <td >
                                                
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl58",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                            <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac58",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td >
                                             <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl59",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                             <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac59",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                                            </td>
                                             <td >
                                                <asp:Label ID="Label34" runat="server" Text=""  CssClass="glbl" Font-Size="10px"></asp:Label>
                                            </td>
                                             <td >
                                            <asp:Label ID="lblr5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("YrnComnt")%>'> </asp:Label>
                                            
                                            </td>
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                            <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div5" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblraop" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblraop2" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblraop3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                            Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                    </td>


                                     <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlAop" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblSubYlAop" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>




                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                 <asp:TabPanel ID="TabPanel10" runat="server" HeaderText="Accessories">
                    <ContentTemplate>
                       <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlbuyerAcs" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindAcs" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindAcs_Click" />
                                    </td>
                                    <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchAC" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchAC" runat="server" Text="Search" OnClick="btnSearchAC_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                         <asp:GridView ID="GvAcs" runat="server" AutoGenerateColumns="False" CellPadding="2" CssClass="gridcss4"
                                OnRowDataBound="GvAcs_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5" PagerSettings-Position="Bottom" PageSize="17" OnPageIndexChanging="GvAcs_PageIndexChanging">
                              <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" Height="18px" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                    
                                            <th colspan="14" class="gvtop">
                                               <span style="padding-left: 10px; float: left">ACCESSORIES PRODUCTION</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                SL-No
                                            </th>
                                                
                                                 <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 OrderNo
                                                </th>
                                                 <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 ArticleNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="200px">
                                                PoNumber
                                                </th>
                                              
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                Quantity
                                                </th>
                                                    
                                                  <th  class="gridheade2" nowrap="nowrap">
                                                Ex-Factory
                                                </th>
                                                 
                                                    
                                                
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblacsbook"></asp:Label>
                                                </th>

                                                <%--acc pi and bblc--%>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader60"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader61"></asp:Label>
                                                </th>

                                                <%--acc pi and bblc--%>


                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                     <th  class="gridheade2" nowrap="nowrap">
                                               Approval Facts
                                                </th>
                                                  <th  class="gridheade2" nowrap="nowrap">
                                               Remarks
                                                </th>
                                              
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                               
                                               <th></th>
                                                
                                                 <th class="gvbtm">
                                                  
                                                </th>
                                                <th class="gvbtm">
                                                    
                                                </th>
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                                  
                                                  <th class="gvbtm">
                                                   
                                                </th>
                                               
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th><th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                  
                                                </th>
                                                <th class="gvbtm">
                                                  
                                                </th>
                                                
                                                
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                         <td width="100px" align="center">
                                            <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                Font-Bold="True" Font-Size="8pt"></asp:Label>
                                        </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                             <td >
                                                <asp:Label ID="Label13" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                          
                                            <td >
                                                <%--<asp:Label ID="Label5" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                            </td>
                                           
                                            <td >
                                                
                                                <asp:Label ID="lblracsbok" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac3",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                          
                                            
                                            <%--##---------------##--%>

                                            <%--acc pi and bblc--%>
                                            <td >
                                                
                                                <asp:Label ID="lbl60" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl60",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld60" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                            <asp:Label ID="lblr60" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac60",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                            <td >
                                                
                                                <asp:Label ID="lbl61" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl61",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld61" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                            <asp:Label ID="lblr61" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac61",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>

                                            <%--acc pi and bblc--%>

                                            <td >
                                                
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl29",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                            <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac29",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td>
                                             <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl30",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                             <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac30",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                                            </td>
                                             <td >
                                                <asp:Label ID="Label34" runat="server" Text="View "  CssClass="glbl" Font-Size="10px"></asp:Label>
                                            </td>
                                             <td >
                                            <asp:Label ID="lblr5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("AcsComnt")%>'> </asp:Label>
                                            
                                            </td>
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                        <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div6" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblacs" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblacs2" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblacs3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                            Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                    </td>



                                     <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlAc" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSubAc" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>




                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="Inventory">
                    <ContentTemplate>
                        <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlbuyerI" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindI" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindI_Click" />
                                    </td>
                                    <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchI" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchI" runat="server" Text="Search" OnClick="btnSearchI_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                          <asp:GridView ID="GvIvn" runat="server" AutoGenerateColumns="False" CellPadding="2" CssClass="gridcss4"
                                OnRowDataBound="GvIvn_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5" PagerSettings-Position="Bottom" PageSize="14" OnPageIndexChanging="GvIvn_PageIndexChanging">
                              <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" Height="18px" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                    
                                            <th colspan="20" class="gvtop">
                                               <span style="padding-left: 10px; float: left">ACCESSORIES IN-HOUSE/INVETORY</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                 <th class="gridheade2" nowrap="nowrap">
                                                SL-No
                                            </th>
                                                 <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 OrderNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 ArticleNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="200px">
                                                PoNumber
                                                </th>
                                              
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                Quantity
                                                </th>
                                                    
                                                  <th  class="gridheade2" nowrap="nowrap">
                                                Ex-Factory
                                                </th>
                                                 
                                                    
                                                
                                                
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                    </th>
                                                      <th  colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader3"></asp:Label>
                                                </th>
                                                   <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader4"></asp:Label>
                                                      </th>
                                              
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                               
                                               <th></th>
                                                
                                                 <th class="gvbtm">
                                                  
                                                </th>
                                                <th class="gvbtm">
                                                    
                                                </th>
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                               
                                               
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                
                                                
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        <td width="100px" align="center">
                                            <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                Font-Bold="True" Font-Size="8pt"></asp:Label>
                                        </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label14" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                          
                                            <td >
                                                <%--<asp:Label ID="Label5" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                            </td>
                                           
                                           
                                            
                                            <%--##---------------##--%>

                                            <td>
                                                
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl31",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                            <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac31",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td >
                                             <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl32",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                             <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac32",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                                            </td>
                                             <td>
                                                <asp:Label ID="lbl3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl33",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld3" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                             <td >
                                          <asp:Label ID="lblr3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac33",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            
                                            </td>
                                            <td >
                                                <asp:Label ID="lbl4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl34",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld4" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                             <td >
                                          <asp:Label ID="lblr4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac34",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            
                                            </td>
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                            <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div7" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblivn" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblivn2" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblivn3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                            Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                    </td>


                                     <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlIn" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSubIn" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>



                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                 <asp:TabPanel ID="TabPanel11" runat="server" HeaderText="Printing">
                    <ContentTemplate>
                    <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlbuyerP" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindP" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindP_Click" />
                                    </td>
                                     <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchP" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchP" runat="server" Text="Search" OnClick="btnSearchP_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                         <asp:GridView ID="GvP" runat="server" AutoGenerateColumns="False" CellPadding="2" CssClass="gridcss4"
                                OnRowDataBound="GvP_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5" PagerSettings-Position="Bottom" PageSize="17" OnPageIndexChanging="GvP_PageIndexChanging">
                              <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" Height="18px" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                  
                                            <th colspan="11" >
                                               <span style="padding-left: 10px; float: left">PRINTING</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                  <th class="gridheade2" nowrap="nowrap">
                                                SL-No
                                            </th>
                                                 <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 OrderNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 ArticleNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="200px">
                                                PoNumber
                                                </th>
                                              
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                Quantity
                                                </th>
                                                    
                                                  <th  class="gridheade2" nowrap="nowrap">
                                                Ex-Factory
                                                </th>
                                                 
                                                    
                                                
                                               
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                     </th>
                                              
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                               <th></th>
                                               
                                                
                                                 
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                                  
                                                  <th class="gvbtm">
                                                   
                                                </th>
                                                <th class="gvbtm">
                                                   
                                                </th>
                                               
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                <th class="gvbtm">
                                                   DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 
                                                
                                                
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                         <td width="100px" align="center">
                                            <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                Font-Bold="True" Font-Size="8pt"></asp:Label>
                                        </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label15" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                         <td>
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                          
                                            <td >
                                                <%--<asp:Label ID="Label5" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                            </td>
                                           
                                            
                                            
                                            <%--##---------------##--%>

                                            <td>
                                                
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl38",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td >
                                         
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                            <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac38",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td >
                                             <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl39",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                            <td >
                                         
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                             <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac39",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                                            </td>
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                        <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div8" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblprnt" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblprnt2" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblprnt3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                            Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                    </td>


                                      <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlPrnt" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSubPrnt" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>


                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel8" runat="server" HeaderText="Embroidery">
                    <ContentTemplate>
                        <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlbuyerE" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindE" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindE_Click" />
                                    </td>
                                     <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchE" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchE" runat="server" Text="Search" OnClick="btnSearchE_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                        <asp:GridView ID="GvE" runat="server" AutoGenerateColumns="False" CellPadding="2" CssClass="gridcss4"
                                OnRowDataBound="GvE_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5" PagerSettings-Position="Bottom" PageSize="17" OnPageIndexChanging="GvE_PageIndexChanging">
                               <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" Height="18px" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                    
                                            <th colspan="11" >
                                              <span style="padding-left: 10px; float: left">EMBROIDERY</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                  <th class="gridheade2" nowrap="nowrap">
                                                SL-No
                                            </th>
                                                 <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 OrderNo
                                                </th>
                                                 <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 ArticleNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="200px">
                                                PoNumber
                                                </th>
                                              
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                Quantity
                                                </th>
                                                    
                                                  <th  class="gridheade2" nowrap="nowrap">
                                                Ex-Factory
                                                </th>
                                                 
                                                    
                                                
                                               
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                     </th>
                                              
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                               
                                               <th></th>
                                                
                                                 
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                                 <th class="gvbtm">
                                                   
                                                </th>
                                                  
                                                  <th class="gvbtm">
                                                   
                                                </th>
                                                <th class="gvbtm">
                                                   
                                                </th>
                                               
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                <th class="gvbtm">
                                                   DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                <th class="gvbtm">
                                                    DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 
                                                
                                                
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                         <td width="100px" align="center">
                                            <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                Font-Bold="True" Font-Size="8pt"></asp:Label>
                                        </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                              <td >
                                                <asp:Label ID="Label16" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                          
                                            <td >
                                                <%--<asp:Label ID="Label5" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                            </td>
                                           
                                            
                                            
                                            <%--##---------------##--%>

                                            <td >
                                                
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl40",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                            <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac40",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td >
                                             <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl41",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                             <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac41",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                                            </td>
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                            <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div9" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblemb" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblemb2" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblemb3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                            Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                    </td>


                                     <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlEmb" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSubEmb" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>


                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel9" runat="server" HeaderText="RMG">
                    <ContentTemplate>
                       <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlbuyerR" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindR" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindR_Click" />
                                    </td>
                                     <td width="15%">
                                    </td>
                                    <td>
                        <asp:TextBox ID="txtSearchRMG" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearchRMG" runat="server" Text="Search" OnClick="btnSearchRMG_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left; overflow: auto; width: 99.9%;">
                        <asp:GridView ID="GvR" runat="server" AutoGenerateColumns="False" CellPadding="2" CssClass="gridcss4"
                                OnRowDataBound="GvR_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5" PagerSettings-Position="Bottom" PageSize="16" OnPageIndexChanging="GvR_PageIndexChanging">
                               <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" Height="18px" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                <Columns>
                              

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                    
                                            <th colspan="56" >
                                                 <span style="padding-left: 10px; float: left">RMG</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                <th class="gridheade2" nowrap="nowrap">
                                                SL-No
                                            </th>
                                                 <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 OrderNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="120px">
                                                 ArticleNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="200px">
                                                PoNumber
                                                </th>
                                              
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                Quantity
                                                </th>
                                                    
                                                  <th  class="gridheade2" nowrap="nowrap">
                                                Ex-Factory
                                                </th>
                                                  
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                </th>
                                                   <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader3"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader4"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader5"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader6"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader7"></asp:Label>
                                                </th>
                                                  <th colspan="3" class="gridheade2" nowrap="nowrap" bgcolor="#00FF00">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader8" BackColor="#00FF00"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader9"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader10"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader11"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader12"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader13"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader14"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader15"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader16"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader17"></asp:Label>
                                                </th>
                                               
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                         <th></th>
                                                <th class="gvbtm">
                                                   
                                                </th>
                                                 <th class="gvbtm">
                                                  
                                                </th>
                                                <th class="gvbtm">
                                                  
                                                </th>
                                                <th class="gvbtm">
                                                  
                                                </th>
												</th>
                                                <th class="gvbtm">
                                                  
                                                </th>
                                                
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                  <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                  <th class="gvbtm" bgcolor="#00FF00">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm" bgcolor="#00FF00">
                                                 DD
                                                </th>
                                                <th class="gvbtm" bgcolor="#00FF00">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                  <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                  <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                   DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                  DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                           
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                     <td width="100px" align="center">
                                            <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                Font-Bold="True" Font-Size="8pt"></asp:Label>
                                        </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" width="83px" CssClass="glbl2" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                             <td >
                                                <asp:Label ID="Label17" runat="server" Text="" width="83px" CssClass="glbl2" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl2" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                           
                                            <td >
                                                <asp:Label ID="Label5" runat="server" Text=""  CssClass="glbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>
                                            </td>
                                          
                                            <%--##---------------##--%>

                                            <td >
                                                
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl35",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                               <td >
                                            <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac35",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td >
                                             <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl36",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                             <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac36",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                                            </td>
                                             <td class="gvrow">
                                             <asp:Label ID="lbl3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl37",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld3" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                             <asp:Label ID="lblr3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac37",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                             
                                            </td>
                                            <td class="gvrow">
                                             <asp:Label ID="lbl4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl42",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld4" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                            <asp:Label ID="lblr4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac42",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            
                                            </td>
                                            <td class="gvrow">
                                             <asp:Label ID="lbl5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl43",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld5" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                               <asp:Label ID="lblr5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac43",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td class="gvrow">
                                              <asp:Label ID="lbl6" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl44",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld6" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                               <asp:Label ID="lblr6" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac44",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td class="gvrow">
                                               <asp:Label ID="lbl7" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl45",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld7" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                                <asp:Label ID="lblr7" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac45",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                              <td class="gvrow" bgcolor="#00FF00">
                                                <asp:Label ID="lbl8" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl46",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow" bgcolor="#00FF00">
                                         
                                                <asp:Label ID="lbld8" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow" bgcolor="#00FF00">
                                                <asp:Label ID="lblr8" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac46",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td class="gvrow">
                                               <asp:Label ID="lbl9" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl47",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld9" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                               <asp:Label ID="lblr9" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac47",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td class="gvrow">
                                              <asp:Label ID="lbl10" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl48",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld10" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                                 <asp:Label ID="lblr10" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac48",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td class="gvrow">
                                               <asp:Label ID="lbl11" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl49",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld11" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                                 <asp:Label ID="lblr11" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac49",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td class="gvrow">
                                              <asp:Label ID="lbl12" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl50",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld12" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                                <asp:Label ID="lblr12" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac50",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td class="gvrow">
                                              <asp:Label ID="lbl13" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl51",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld13" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                             <td class="gvrow">
                                               <asp:Label ID="lblr13" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac51",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                            <td class="gvrow">
                                              <asp:Label ID="lbl14" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl52",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld14" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                                            </td>
                                             <td class="gvrow">
                                                  <asp:Label ID="lblr14" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac52",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td class="gvrow">
                                              <asp:Label ID="lbl15" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl53",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld15" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                             <td class="gvrow">
                                                  <asp:Label ID="lblr15" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac53",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td class="gvrow">
                                              <asp:Label ID="lbl16" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl54",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld16" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                                  <asp:Label ID="lblr16" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac54",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td class="gvrow">
                                              <asp:Label ID="lbl17" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl55",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld17" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td class="gvrow">
                                                  <asp:Label ID="lblr17" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac55",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                            </div>
                             <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;"
                            id="Div10" runat="server">
                            <table>
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-left: 4px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                                EVENT SUMMARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="14px">
                                        <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                            font-size: 13px;">Total Job</span>
                                    </td>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblrr" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text=""
                                            Font-Bold="true" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style="" width="50px">
                                        <asp:Label ID="lblrr2" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                    </td>
                                    <td align="right" width="40px">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                            %</span>
                                    </td>
                                    <td style="" width="30px">
                                        <asp:Label ID="lblrr3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                            Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                    </td>



                                    <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Yellow</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblYlRmg" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FFFF66" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblYlSubRmg" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FFFF66"></asp:Label>
                                </td>


                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </div>
    </div>
</asp:Content>
