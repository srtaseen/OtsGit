<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StyleWiseSummaryReport.aspx.cs" Inherits="StyleWiseSummaryReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="FldFream2">
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <div class="divnv">
                    <div style="float: left">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95"
                            NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                              <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" 
                            BackColor="#ECF1FF" Font-Underline="False"><i class="fa fa-caret-left"></i> INVENTORY</asp:HyperLink>
                        
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="divbody2">
            <asp:UpdatePanel ID="up2" runat="server">
                <ContentTemplate>
                    <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                        <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                            font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                            <tr>
                                <td>
                                    <span class="spanText" style="color: #FFFFFF">SELECT STYLE</span>
                                </td>
                                <td>
                                 <asp:DropDownList ID="ddlStyle" CssClass="textbox" runat="server" Width="152px" 
                                            Font-Size="11px" >
                                              <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                   
                                </td>
                                <td width="10px">
                                </td>
                                <td>
                                  <asp:Button ID="btnFindStyle" runat="server" CssClass="Btn" Text="Find" width="80px"
                                            OnClick="btnFindStyle_Click" />
                                  
                                </td>
                                <td width="55%"></td>
                                <td width="200px" align="right">
                               <%-- <asp:TextBox ID="txtSearch" runat="server" Width="100%" CssClass="txtsearch" placeholder="Search" ForeColor="#999999" />--%>
                                </td>
                              
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="float: left; overflow: auto; width: 99.9%;">
              
                <asp:UpdatePanel ID="up3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GvIvn" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CssClass="gridcss4" AllowPaging="True" PagerSettings-PageButtonCount="5"
                            PagerSettings-Position="Bottom" PageSize="19" >
                            <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Height="18px" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                            <Columns>
                                 <asp:TemplateField>
                                        <HeaderTemplate>
                                    
                                            <th colspan="20" >
                                              <span style="padding-left: 10px; float: left">STYLE WISE SUMMARY REPORT</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap">
                                                 Total Cutting
                                                </th>
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                 Total Input
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap">
                                                Total Sewing
                                                </th>
                                              
                                                 <th  class="gridheade2" nowrap="nowrap">
                                               Total Poly
                                                </th>
                                                    
                                                  <th  class="gridheade2" nowrap="nowrap">
                                                Total Ready For Shipment
                                                </th>
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                Total Order Qty
                                                </th> 
												<th class="gridheade2" nowrap="nowrap">
                                                    Remain Qty
                                                </th>          		
                                                
                                                
                                               
                                              
                                            </tr>
                                            
                                        </HeaderTemplate>
                                        <ItemTemplate>
											<td >
                                                <asp:Label ID="Label50" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("TotalCutting")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("TotalInput")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="10px"><%# Eval("TotalSewing")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("TotalPoly")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label1" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("ShipmentReady")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label2" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("ShipmentRequired")%></asp:Label>
                                            </td>
                                           <td>
                                                <asp:Label ID="lblTotalCM1" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "ShipmentRequired")) - Convert.ToDouble(DataBinder.Eval(Container.DataItem, "ShipmentReady"))%>'></asp:Label>
                                            </td>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:BoundField />
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <script src="Scripts/ScrollableGridPlugin_ASP.NetAJAX_3.0.js" type="text/javascript"></script>
                <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
                <script type="text/javascript">
                    var position = 0;
                    $(document).ready(function () {
                        $('#<%=GvIvn.ClientID %>').Scrollable({
                            //                  ScrollHeight: 300,
                            ScrollWidth: 600,
                            IsInUpdatePanel: true
                        });
                    });
                </script>
            </div>
          
</asp:Content>

