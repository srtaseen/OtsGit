<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductionCAD.aspx.cs" Inherits="ProductionCAD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

        
                     <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="30%"
                            NavigateUrl="~/CADHome.aspx"><i class="fa fa-home"></i>CAD HOME </asp:HyperLink>
               
           
           
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
                                 <asp:DropDownList ID="ddlStyle" CssClass="textbox" runat="server" Width="152px" AutoPostBack="true" 
                                            Font-Size="11px" OnSelectedIndexChanged="ddlStyle_SelectedIndexChanged" >
                                              <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                   
                                </td>

                                <td height="18px" width="100px" >
                                    <span class="text-primary"> Article No </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetPo" runat="server" CssClass="textbox" Width="300px" AutoPostBack="true" >
                                        <asp:ListItem>-</asp:ListItem>
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
            <div style="height:50px;">
                             </div>
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
                                                 Article No
                                                </th>
                                                 <th  class="gridheade3" nowrap="nowrap">
                                                 Article Qty
                                                </th>
                                                <th  class="gridheade3" nowrap="nowrap">
                                                Buyer Name
                                                </th>
                                              
                                                 <th  class="gridheade3" nowrap="nowrap">
                                               Booking CAD Consumtion
                                                </th>
                                                    
                                                  <th  class="gridheade3" nowrap="nowrap">
                                                Booking CAD DIA
                                                </th>
                                                 <th  class="gridheade3" nowrap="nowrap">
                                                Booking CAD GSM
                                                </th> 
												<th class="gridheade3" nowrap="nowrap">
                                                    Booking Date
                                                </th> 
                                                <th class="gridheade3" nowrap="nowrap">
                                                    Booking User
                                                </th> 
                                                
                                                         		
                                                
                                                
                                               
                                              
                                            </tr>
                                            
                                        </HeaderTemplate>
                                        <ItemTemplate>
											<td >
                                                <asp:Label ID="Label50" runat="server" Text="" CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("art_no")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("art_qty")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("byr_nm")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("bCADCons")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label1" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("bCADDia")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label2" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("bCADGsm")%></asp:Label>
                                            </td>
                                           
                                            <td >
                                                <asp:Label ID="Label8" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("bCADBookingDt")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label9" runat="server" Text=""   CssClass="glbl" Font-Size="15px" Font-Bold="true"><%# Eval("sp_User")%></asp:Label>
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

                        <div id="prodEntry" runat="server" visible="false">
                            <div style="height:500px;" >
                 <fieldset style="border:1px solid white;"> 
                   
                <table class="TblStyle">
                    <tr>
                        <td height="18px" width="100px">
                           <span class="sp1">Production CAD Details</span>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="text-primary">Production Consumtion </span>
                        </td>
                         <td>
                            <asp:TextBox ID="txtPCons" runat="server" CssClass="textbox" Width="200px">                                       
                            </asp:TextBox>
                        </td>
                        <td>
                            <span class="text-primary">Production DIA </span>
                        </td>
                         <td>
                            <asp:TextBox ID="txtPDia" runat="server" CssClass="textbox" Width="200px">                                       
                            </asp:TextBox>
                        </td>
                        <td>
                            <span class="text-primary">Production GSM </span>
                        </td>
                         <td>
                            <asp:TextBox ID="txtPGsm" runat="server" CssClass="textbox" Width="200px">                                       
                            </asp:TextBox>
                        </td>
                    </tr>

                    
                </table>

                     <div style="margin-left:27px;margin-top:10px;margin-bottom:10px;">
                         <asp:Button ID="Btnsave" runat="server" Text="Save" CssClass="btn-primary large" 
                                BorderStyle="None" Width="50px" ValidationGroup="btnsave" OnClick="Btnsave_Click" />
                     </div>
                
</fieldset>
            </div>
                        </div>
                       

                        
                        
                     



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
                <script type="text/javascript">
                    $(document).ready(function(){
                      $("btnFindStyle").click(function(){
                        $("div").toggle();
                      });
                    });
                </script>
            </div>
          
</asp:Content>


