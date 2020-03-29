<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Page18.aspx.cs" Inherits="Page5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
            <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
            <link href="Styles/popupwindow.css" rel="stylesheet" type="text/css" />
                        <%-- Popup window--%>
            <script type="text/javascript">
                $(function () {
                    modalPosition();
                    $(window).resize(function () {
                        modalPosition();
                    });
                    $('.openModal1').click(function (e) {
                        $('.modal1, .modal1-backdrop').fadeIn('fast');
                        e.preventDefault();

                    });
                    $('.close-modal1').click(function (e) {
                        $('.modal1, .modal1-backdrop').fadeOut('fast');
                    });
                });
                function modalPosition() {
                    var width = $('.modal1').width();
                    var pageWidth = $(window).width();
                    var x = (pageWidth / 2) - (width / 2);
                    $('.modal1').css({ left: x + "px" });
                }
            </script>
            <%-- Popup window--%>

               <%-- Popup window--%>
       <script type = "text/javascript">
           var popUpObj;
           function showModalPopUp() {
               popUpObj = window.open("Page6.aspx",
    "ModalPopUp",
    "toolbar=no," +
    "scrollbars=no," +
    "location=no," +
    "statusbar=no," +
    "menubar=no," +
    "resizable=0," +
    "width=510," +
    "height=400," +
    "left = 390," +
    "top=100"
    );
               popUpObj.focus();
               LoadModalDiv();
           }
</script>
<script type = "text/javascript">
    function LoadModalDiv() {
        var bcgDiv = document.getElementById("divBackground");
        bcgDiv.style.display = "block";
    }
</script>
<script type = "text/javascript">
    function HideModalDiv() {
        var bcgDiv = document.getElementById("divBackground");
        bcgDiv.style.display = "none";
    }
</script>
            <%-- Popup window--%>
   
    <div class="FldFream1">
        <div class="divnv">
            <div style="float: left">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME </asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnkD" Font-Underline="False"
                    BackColor="#ECF1FF"><i class="fa fa-th"></i> ORDER SCHEDULE <i class="fa fa-caret-right"></i></asp:HyperLink>
                      <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" 
                    BackColor="#ECF1FF" NavigateUrl="~/Page20.aspx"><i class="fa fa-caret-left"></i> TIME & ACTION PLAN</asp:HyperLink>
            
            </div>
           
        </div>
        <div class="divbody">
            <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                    font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                    <tr>
                        <td>
                            <span class="spanText" style="color: #FFFFFF">From</span>
                        </td>
                        <td>
                            <asp:TextBox ID="tx1" runat="server" CssClass="textbox" Width="100px" 
                                Enabled="False"></asp:TextBox>
                            <asp:CalendarExtender ID="tx1_CalendarExtender" runat="server" Enabled="True" TargetControlID="tx1"
                                PopupButtonID="imgPopup">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="imgPopup" ImageUrl="icons/date-picker.png" runat="server" Class="datepic1"
                                ImageAlign="TextTop" />
                        </td>
                         <td width="5px"></td>
                        <td>
                            <span class="spanText" style="color: #FFFFFF">To</span>
                        </td>
                        <td>
                            <asp:TextBox ID="tx2" runat="server" CssClass="textbox" Width="100px" 
                                Enabled="False"></asp:TextBox>
                            <asp:CalendarExtender ID="tx2_CalendarExtender" runat="server" Enabled="True" TargetControlID="tx2"
                                PopupButtonID="imgPopup1">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="imgPopup1" ImageUrl="icons/date-picker.png" runat="server" Class="datepic1"
                                ImageAlign="TextTop" />
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlbuyerFind" runat="server" CssClass="textbox" Width="150px">
                                <asp:ListItem Text = "ALL" Value = "ALL"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:Button ID="BtnOrdFind" runat="server" Text="Details" CssClass="Btn " 
                                BorderStyle="None" Width="80px" Height="20px"  OnClick="BtnOrdFind_Click" />
                        </td>
                        <td width="5px">
                        </td>
                         <td width="85px">
                          <input id="BtnNewWindo" type="button" value="Get Summary" Class="Btn " onclick="showModalPopUp()" 
                        style="border-style: none; width: 80px; height:20px;"  />
                        </td>
                        <td>
                        <asp:TextBox ID="txtSearch" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="Btn" Width="90px" Height="20px"/> 
                        </td>
                       
                    </tr>
                </table>
            </div>
            <div style="width: 100%; height: 482px; float: left; margin-top: 4px; ">
             <div style="width: 100%; height: 445px; float: left;  overflow: auto;">
                <asp:GridView ID="Gvorder" runat="server" AutoGenerateColumns="False" CssClass="gridcss2"
                    AllowPaging="True" PageSize="25" OnPageIndexChanging="Gvorder_PageIndexChanging"
                    OnRowDataBound="Gvorder_RowDataBound">
                    <AlternatingRowStyle BackColor="#F2F9FE" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                BUYER</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("byr_nm")%>'>></asp:Label>
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
                                ARTICLE</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("art_no")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                GARMENTS</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("gmtyp")%>'>></asp:Label>
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



                        <%--Garments Type--%>

                        <%-- <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                Garments Type</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("grment_typ")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>


                        <%--Garments Type--%>

                        <%--Entry date--%>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                ORDER ENTRY DT.</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("ord_entdt " ,"{0:dd/MMM/yyyy}")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--Entry date--%>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                ORDER RECV.DTLS. DT.</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("ord_cnfdate" ,"{0:dd/MMM/yyyy}")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                ORDER QUANTITY</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("po_quantity")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                PRICE</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("po_price")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                TTL. PRICE</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("Totalprice","$ {0:#,#}")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                EXFACTORY</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("po_xfactory","{0:dd/MMM/yyyy}")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                FACTORY</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("Fact_nm")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                REPORT</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text="Report"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                  <%--  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" CssClass="pagination"  />--%>
                  <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                </asp:GridView>
             </div>
                <div style="float: left; margin-top: 4px; margin-left: 4px;  font-family: Arial, Helvetica, sans-serif;font-size: 11px; width: 80%; height: 20px;">
                  
                    
                        <button type="submit" id="btnrefresh" runat="server" class="btnprnt" title="Refresh" >
                            <i class="fa fa-print fa-1x" 
                                style="margin: -2px 0px 0px 0px; padding-top: 0px; width: 20px;"></i>print
                        </button>
                        <button type="submit" id="Button1" runat="server" class="btnprnt" title="Refresh" >
                            <i class="fa fa-envelope-o fa-1x" style="margin: -2px 0px 0px 0px; padding-top: 0px;width: 20px;" ></i>Email
                        </button>
                  
                </div>
            </div>
        </div>
    </div>

  
    </ContentTemplate>
    </asp:UpdatePanel>
     <div class="modal1">
        <div class="modal1-header">
            <h3>
                OTS <a class="close-modal1" href="#">&times;</a></h3>
        </div>
        <div class="modal1-body">
            <iframe style="width: 100%; height: 410px;" id="ifrm" src="page6.aspx" runat="server">
            </iframe>
        </div>
        <div class="modal1-footer">
        </div>
    </div>
    <div class="modal1-backdrop">
    </div>

     <%-- Popup window--%>
    <div id = "divBackground" style="position: fixed; z-index: 999; height: 100%; width: 100%; top: 0; left:0; background-color: Black; filter: alpha(opacity=60); opacity: 0.6; -moz-opacity: 0.8;display:none">
     </div>
     <%-- Popup window--%>

</asp:Content>
