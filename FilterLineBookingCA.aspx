<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FilterLineBookingCA.aspx.cs" Inherits="FilterLineBookingCA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
            

    <script type = "text/javascript">
        function doPrint() {
            var prtContent = document.getElementById('<%= GvLineBooking.ClientID %>');
            prtContent.border = 0; //set no border here
            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
</script>


    <div class="divbody">
            <asp:UpdatePanel ID="upl1" runat="server">
            <ContentTemplate>
             <%-- <asp:Timer ID="Timer1" runat="server" OnTick="TimerTick" Interval="2000">
        </asp:Timer>--%>
            <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                    font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                    <tr>
                        <td>
                            <span class="spanText" style="color: #FFFFFF">From</span>
                        </td>
                        <td>
                            <asp:TextBox ID="tx1" runat="server" CssClass="textbox" Width="100px" placeholder="MM/DD/YYYY" 
                                Enabled="False"></asp:TextBox>
                            <asp:CalendarExtender ID="tx1_CalendarExtender" runat="server" Enabled="True" TargetControlID="tx1"
                                PopupButtonID="imgPopup">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="imgPopup" ImageUrl="icons/date-picker.png" runat="server" Class="datepic1"
                                ImageAlign="TextTop" />
                        </td>
                        <%-- <td></td>--%>
                        <td width="5px">
                        </td>
                        <td>
                            <span class="spanText" style="color: #FFFFFF">To</span>
                        </td>
                        <td>
                            <asp:TextBox ID="tx2" runat="server" CssClass="textbox" Width="100px" placeholder="MM/DD/YYYY" 
                                Enabled="False"></asp:TextBox>
                            <asp:CalendarExtender ID="tx2_CalendarExtender" runat="server" Enabled="True" TargetControlID="tx2"
                                PopupButtonID="imgPopup1">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="imgPopup1" ImageUrl="icons/date-picker.png" runat="server" Class="datepic1"
                                ImageAlign="TextTop" />
                        </td>
                        <td width="10px">
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlbuyerFind" runat="server" CssClass="textbox" Width="150px">
                            <asp:ListItem Text = "ALL" Value = "ALL"></asp:ListItem>
                              
                            </asp:DropDownList>
                        </td>
                        <td width="10px">
                        </td>
                        <td>
                            <asp:Button ID="BtnOrdFind" runat="server" Text="Details" CssClass="Btn " 
                                BorderStyle="None" Width="80px" Height="20px"  OnClick="BtnOrdFind_Click" />
                        </td>
                       <%-- <td width="85px">
                          <input id="BtnNewWindo" type="button" value="Get Summary" Class="Btn " onclick="showModalPopUp()" 
                        style="border-style: none; width: 80px; height:20px;"  />
                        </td>--%>
                        <td>
                        <asp:TextBox ID="txtSearch" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                       
                    </tr>
                </table>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>


        <div style="width: 100%; height: 482px; float: left; margin-top: 4px; ">
             <div style="width: 100%; height: 470px; float: left;  overflow: auto;">
                 <asp:UpdatePanel ID="upl2" runat="server">
                 <ContentTemplate>
                
                 <asp:GridView ID="GvLineBooking" runat="server" AutoGenerateColumns="False" CssClass="gridcss2"
                    AllowPaging="True" PageSize="25" OnPageIndexChanging="GvLineBooking_PageIndexChanging" ShowHeaderWhenEmpty="true"
                    OnRowDataBound="GvLineBooking_RowDataBound">
                    <AlternatingRowStyle BackColor="#F2F9FE" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                LINE NO</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("line_no")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                ORDER NO</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("ord_no")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
						
						<asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                ART NO</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("art_no")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                PO NO</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("po_no")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                BUYER</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("ord_buyer")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                GARMENTS TYPE</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("grment_typ")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                ORDER QUANTITY</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("ord_quantity")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                SMV</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("smv")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
						
						<asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                MO</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("mo")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                Helper</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("helper")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                TARGET/DAY</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("target_dy")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                START DATE</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("ent_date")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                END DATE</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("last_dt")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                LINE DURATION</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("SumDay")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                EX-FACTORY</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("ord_xfactory","{0:dd/MM/yyyy}")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        </Columns>
                  <%--  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" CssClass="pagination"  />--%>
                  <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                </asp:GridView>
                
                    

                 </ContentTemplate>
                 </asp:UpdatePanel>
        </div>

            <asp:UpdatePanel ID="upl3" runat="server">
                <ContentTemplate>
                  <div style="float: left; margin-top: 4px; margin-left: 4px;  font-family: Arial, Helvetica, sans-serif;font-size: 11px; width: 80%; height: 20px;">                  
                    <%-- <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="doPrint()" CssClass="Btn" Width="80px" Height="20px" /> 
                       <asp:Button ID="btnPrintAll" runat="server" Text="Print All Pages" OnClick = "PrintAllPages" CssClass="Btn" Width="80px" Height="20px" />  --%>
                      
                          
                      
                                   
                  
                </div>
                </ContentTemplate>

                </asp:UpdatePanel>
            <div style="margin-top:435px;padding-top:50px;">
                <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick = "ExportToExcel" CssClass="btn btn-primary" Width="150px" Height="40px" /> 
            </div>
</asp:Content>


