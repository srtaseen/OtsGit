<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StyleWiseMasterReport.aspx.cs" Inherits="StyleWiseMasterReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

        
                     <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="8%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="8%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page27.aspx"><i class="fa fa-bars"></i> PRINT</asp:HyperLink>
                     <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="12.5%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page28.aspx"><i class="fa fa-bars"></i> EMBROIDERY</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="6%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page29.aspx"><i class="fa fa-bars"></i> RMG</asp:HyperLink>
             <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" width="9%"
                    BackColor="#ECF1FF" NavigateUrl="~/Cutting_Report2.aspx"><i class="fa fa-bars"></i> CUTTING</asp:HyperLink>
             <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" width="9%"
                    BackColor="#ECF1FF" NavigateUrl="~/SewingHome.aspx"><i class="fa fa-bars"></i> SEWING</asp:HyperLink>
              <asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/Cut2Finish.aspx"><i class="fa fa-bars"></i> CUTTING TO FINISH</asp:HyperLink>
             <asp:HyperLink ID="HyperLink8" runat="server" CssClass="MhyperLnk" width="8%"
                    BackColor="#ECF1FF" NavigateUrl="~/CartonShipment.aspx"><i class="fa fa-bars"></i> PACKING</asp:HyperLink>
             <asp:HyperLink ID="HyperLink9" runat="server" CssClass="MhyperLnk" width="8%"
                    BackColor="#ECF1FF" NavigateUrl="~/Export.aspx"><i class="fa fa-bars"></i> EXPORT</asp:HyperLink>
             <asp:HyperLink ID="HyperLink10" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/StyleWiseMasterReport.aspx"><i class="fa fa-bars"></i> MASTER REPORT</asp:HyperLink>
               
           
           
        </div>

        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                
               
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
                            <HeaderStyle Wrap="true" />
                            <%--<HeaderStyle CssClass="gridheade3" />--%>
                            <HeaderStyle Width="30px" />
                            <HeaderStyle Font-Size="15px" />
                            <HeaderStyle BackColor="Tomato" />
                            <HeaderStyle HorizontalAlign="Center" />
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
                                                <th  class="gridheade3" nowrap="nowrap">
                                                 Total Cutting
                                                </th>
                                                 <th  class="gridheade3" nowrap="nowrap">
                                                 Total Input
                                                </th>
                                                <th  class="gridheade3" nowrap="nowrap">
                                                Total Sewing
                                                </th>
                                              
                                                 <th  class="gridheade3" nowrap="nowrap">
                                               Total Poly
                                                </th>
                                                    
                                                  <th  class="gridheade3" nowrap="nowrap">
                                                Total Ready For Shipment
                                                </th>
                                                 <th  class="gridheade3" nowrap="nowrap">
                                                Total Order Qty
                                                </th> 
												<th class="gridheade3" nowrap="nowrap">
                                                    Remain Qty
                                                </th> 
                                                <th class="gridheade3" nowrap="nowrap">
                                                    Export Qty
                                                </th> 
                                                <th class="gridheade3" nowrap="nowrap">
                                                    Export Value
                                                </th> 
                                                <th class="gridheade3" nowrap="nowrap">
                                                    Buyer Name
                                                </th> 
                                                         		
                                                
                                                
                                               
                                              
                                            </tr>
                                            
                                        </HeaderTemplate>
                                        <ItemTemplate>
											<td >
                                                <asp:Label ID="Label50" runat="server" Text="" CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("TotalCutting")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("TotalInput")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("TotalSewing")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("TotalPoly")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label1" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("ShipmentReady")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label2" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("ShipmentRequired")%></asp:Label>
                                            </td>
                                           <td>
                                                <asp:Label ID="lblTotalCM1" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "ShipmentRequired")) - Convert.ToDouble(DataBinder.Eval(Container.DataItem, "ShipmentReady"))%>' Font-Size="15px" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label8" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("ExportQty")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label9" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("ExportValue","{0:c}")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label10" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("cBuyer_Name")%></asp:Label>
                                            </td>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:BoundField />
                            </Columns>
                        </asp:GridView>

                         <div style="height:50px;">
                             </div>

<%--                        <div style="height:50px;">
                            <span class="ab" style="padding-top:5px; background-color:tomato;margin-left:400px; margin-top:100px; font: bold 20px arial; visibility:hidden;">STYLE WISE DETAILS REPORT</span>
                        </div>--%>

                       

                        
                        
                        <asp:GridView ID="GvDetails" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CssClass="gridcss4" AllowPaging="True" PagerSettings-PageButtonCount="5"
                            PagerSettings-Position="Bottom" PageSize="50"  ShowFooter="true"  OnRowDataBound="GvDetails_RowDataBound">
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="true" />
                            <HeaderStyle Wrap="true" />
                            <%--<HeaderStyle CssClass="gridheade3" />--%>
                            <HeaderStyle Width="30px" />
                            <HeaderStyle Font-Size="15px" />
                            <HeaderStyle BackColor="Tomato" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <FooterStyle Width="30px" />
                            <FooterStyle Font-Size="15px" />
                            <FooterStyle BackColor="Tomato" />
                            <FooterStyle Font-Bold="true" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                            
                            <Columns>

                                 

                                <asp:templatefield headertext="PO NO"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">
                                   
                                    <ItemTemplate>
                                        <asp:Label ID="Label50" runat="server" Text="" CssClass="glbl" Font-Size="15px"><%# Eval("cPONo")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <%--<asp:label id="OrderTotalLabel"
                                            runat="server"/>--%>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="COLOR"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="15px"><%# Eval("cColour")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <%--<asp:label id="OrderTotalLabel"
                                            runat="server"/>--%>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="SIZE"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                         <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="15px"><%# Eval("OrgSize")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <%--<asp:label id="OrderTotalLabel"
                                            runat="server"/>--%>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="ORDER QTY"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="15px"><%# Eval("OrgQty")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelOrgQty"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>


                                <asp:templatefield headertext="CUTTING QTY"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text=""   CssClass="glbl" Font-Size="15px"><%# Eval("cQty")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelCutQty"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="INPUT QTY"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text=""   CssClass="glbl" Font-Size="15px"><%# Eval("INPUT")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelInpQty"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="SEWING QTY"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text=""   CssClass="glbl" Font-Size="15px"><%# Eval("SEWING")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelSewQty"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="POLY QTY"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text=""   CssClass="glbl" Font-Size="15px"><%# Eval("POLY")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelPlQty"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="READY FOR SHIPMENT"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text=""   CssClass="glbl" Font-Size="15px"><%# Eval("shpqty")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelRdSpQty"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>


                                <asp:templatefield headertext="EXPORT QTY"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text=""   CssClass="glbl" Font-Size="15px"><%# Eval("sp_SizeQty")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelExQty"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="FOB"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text=""   CssClass="glbl" Font-Size="15px"><%# Eval("sp_Fob","{0:c}")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <%--<asp:label id="OrderTotalLabel"
                                            runat="server"/>--%>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="EXPORT VALUE"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text=""   CssClass="glbl"  Font-Size="15px"><%# Eval("sp_TotalValue","{0:c}")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="lblTotal" 
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="ORIGINAL SHIPMENT DATE"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label16" runat="server" Text=""   CssClass="glbl" Font-Size="15px"><%# Eval("DXfty","{0:d}")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="OrderTotalLabel"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>


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

