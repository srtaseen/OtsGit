<%@ Page Title="OTS | PRINT EVENTS" Language="C#" MasterPageFile="~/Site2.master" AutoEventWireup="true"
    CodeFile="Page27.aspx.cs" Inherits="Page12" %>

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
                             <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" 
                            BackColor="#ECF1FF" NavigateUrl="~/Page24.aspx"><i class="fa fa-caret-left"></i> RMG</asp:HyperLink>
                              <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" 
                            BackColor="#ECF1FF" NavigateUrl="~/page27.aspx"><i class="fa fa-caret-left"></i> PRINTING</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" 
                            BackColor="#ECF1FF" NavigateUrl="~/CuttingToPrintTx.aspx"><i class="fa fa-caret-left"></i> CUTTING TO PRINT TRANSFER</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" 
                            BackColor="#ECF1FF" NavigateUrl="~/CuttingToPrintRx.aspx"><i class="fa fa-caret-left"></i> CUTTING TO PRINT RECEIVER</asp:HyperLink>
						<asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" 
                            BackColor="#ECF1FF" NavigateUrl="~/CutToPrint_Report.aspx"><i class="fa fa-caret-left"></i> CUTTING TO PRINT REPORT</asp:HyperLink>	
						<asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" 
                            BackColor="#ECF1FF" NavigateUrl="~/PrintToCut_Report.aspx"><i class="fa fa-caret-left"></i> PRINT TO CUTTING REPORT</asp:HyperLink>	
           
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
                                    <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                </td>
                                <td>
                                 <asp:DropDownList ID="ddlbuyerP" CssClass="textbox" runat="server" Width="152px" 
                                            Font-Size="11px" >
                                              <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                   
                                </td>
                                <td width="10px">
                                </td>
                                <td>
                                  <asp:Button ID="btnfindP" runat="server" CssClass="Btn" Text="Find" width="80px"
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="float: left; overflow: auto; width: 99.9%;">
              
                <asp:UpdatePanel ID="up3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GvP" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CssClass="gridcss4" OnRowDataBound="GvP_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5"
                            PagerSettings-Position="Bottom" PageSize="19" OnPageIndexChanging="GvP_PageIndexChanging">
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
                                  
                                            <th colspan="10" >
                                              PRINTING
                                            </th>
                                            <tr>
                                                <th>
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
                                               
                                               <th>
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
                                                </th>
                                                 
                                                
                                                
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
											<td width="120px">
                                            <asp:Label ID="Label3" runat="server" Text="" Width="103px" CssClass="glbl2" Font-Size="10px"><%# Eval("art_no")%></asp:Label>
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
                                                
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl38",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                            <td>
                                         
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                             <asp:Label ID="lblStlid" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln" Enabled="false" Text='<%# Eval("Tnaac38","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln_Click" Width="70px" Font-Size="10px" />
                                           
                                               
                                            </td>
                                             <td>
                                             <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl39",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                            <td>
                                         
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="lblStlid2" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln2" Enabled="false" Text='<%# Eval("Tnaac39","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln2_Click" Width="70px" Font-Size="10px" />
                                           
                                              
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
                        $('#<%=GvP.ClientID %>').Scrollable({
                            //                  ScrollHeight: 300,
                            ScrollWidth: 600,
                            IsInUpdatePanel: true
                        });
                    });
                </script>
            </div>
            <asp:UpdatePanel ID="up4" runat="server">
                <ContentTemplate>
                    <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;" id="dv1" runat="server">
                        <table >
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
                                <td width="50px">
                                    <asp:Label ID="lblprnt" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text="" Font-Bold="true"
                                        Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Red</span>
                                </td>
                                <td style=" width="50px">
                                    <asp:Label ID="lblprnt2" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td style=" width="30px">
                                    <asp:Label ID="lblprnt3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
   
    <%--    <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
        </Triggers>--%>
</asp:Content>
