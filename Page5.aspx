<%@ Page Title="OTS | Order Schedule" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Page5.aspx.cs" Inherits="Page5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

            <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
            <link href="Styles/popupwindow.css" rel="stylesheet" type="text/css" />

    <script>
        function doPrint()
        {
            var prtContent = document.getElementById('<%= Gvorder.ClientID %>');
            prtContent.border = 0; //set no border here
            var WinPrint = window.open('','','left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
</script>


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
    <%--Menu--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".accountM").click(function () {
                var X = $(this).attr('id');

                if (X == 1) {
                    $(".submenuM").hide();
                    $(this).attr('id', '0');
                }
                else {

                    $(".submenuM").show();
                    $(this).attr('id', '1');
                }

            });

            //Mouseup textarea false
            $(".submenuM").mouseup(function () {
                return false
            });
            $(".accountM").mouseup(function () {
                return false
            });


            //Textarea without editing.
            $(document).mouseup(function () {
                $(".submenuM").hide();
                $(".accountM").attr('id', '');
            });

        });
	
    </script>
    <%--Menu--%>
    <div class="FldFream1">
      <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
           
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" width="10%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME </asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnkD" Font-Underline="False" Width="16%"
                    BackColor="#ECF1FF"><i class="fa fa-th"></i> MERCHANDISING <i class="fa fa-caret-right"></i> </asp:HyperLink>
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnkD" Font-Underline="False" Width="18%" NavigateUrl="~/page5.aspx"
                    BackColor="#D9E4FF" ForeColor="#0033CC"><i class="fa fa-th-large"></i> ORDER SCHEDULE <i class="fa fa-caret-right"></i> </asp:HyperLink>
          <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnkD" Font-Underline="False" Width="20%" NavigateUrl="~/ShipmentDone.aspx"
                    BackColor="#D9E4FF" ForeColor="#0033CC"><i class="fa fa-plane"></i> SHIPMENT DONE ORDER <i class="fa fa-caret-right"></i> </asp:HyperLink>
           
            <div class="dropdownM">
                <%--   <asp:HyperLink ID="HyperLink3" runat="server" CssClass="account" 
            Font-Underline="False" BackColor="#ECF1FF">MERCHANDISING </asp:HyperLink>--%>
                <a class="accountM"><i class="fa fa-bars"></i> MENU<i class="fa fa-chevron-down fa-1x" style="margin-left: 20px"></i></a>
                <div class="submenuM">
                    <ul class="rootM">
                        <li style="background-color: #3a5795"><a href="Page5.aspx">Order Schedule</a></li>
                                <li><a href="ArticleMaster.aspx">Order Article Master</a></li>
                                <li><a href="Article_Po_Master.aspx">Article PO Master</a></li>
								<li><a href="Article_Create_TNA.aspx">Create T&A</a></li>
                                <li><a href="Page8.aspx">Approve T&A</a></li>
                                <li><a href="Page31.aspx">Reload T&A</a></li>
                                <li><a href="Page12.aspx">T&A Events</a></li>
                         
                                <li><a href="#feedback">Report</a></li>
                    </ul>
                </div>
            </div>
        </div>
      <div class="divbody">
            <asp:UpdatePanel ID="upl1" runat="server">
            <ContentTemplate>
             <%-- <asp:Timer ID="Timer1" runat="server" OnTick="TimerTick" Interval="2000">--%>
        </asp:Timer>
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
            </ContentTemplate>
            </asp:UpdatePanel>
            
            <div style="width: 100%; height: 482px; float: left; margin-top: 4px; ">
             <div style="width: 100%; height: 445px; float: left;  overflow: auto;">
                 <asp:UpdatePanel ID="upl2" runat="server">
                 <ContentTemplate>
                
                 <asp:GridView ID="Gvorder" runat="server" AutoGenerateColumns="False" CssClass="gridcss2"
                    AllowPaging="True" PageSize="25" OnPageIndexChanging="Gvorder_PageIndexChanging" ShowHeaderWhenEmpty="true"
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
                                SMV</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("art_smv")%>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="gridheade" />
                            <HeaderTemplate>
                                Total SMV Qty</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("TotalSmvQty")%>'>></asp:Label>
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
                                RE-EXFACTORY</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text='<%# Eval("ReExFactory","{0:dd/MMM/yyyy}")%>'>></asp:Label>
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
                <%-- <asp:Image ID="imgLoader" runat="server" ImageUrl="~/Images/loadingAnim.gif" 
                         CssClass="an" />--%>
                 </ContentTemplate>
                 </asp:UpdatePanel>
                
             </div>
                <asp:UpdatePanel ID="upl3" runat="server">
                <ContentTemplate>
                  <div style="float: left; margin-top: 4px; margin-left: 4px;  font-family: Arial, Helvetica, sans-serif;font-size: 11px; width: 80%; height: 20px;">
                  
                     <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="doPrint()" CssClass="Btn" Width="80px" Height="20px" />
                        <button type="submit" id="Button1" runat="server" class="btnprnt" title="Refresh" >
                            <i class="fa fa-envelope-o fa-1x" style="margin: -2px 0px 0px 0px; padding-top: 0px;width: 20px;" ></i>Email
                        </button>
                  
                </div>
                </ContentTemplate>
                </asp:UpdatePanel>
              
            </div>
        </div>
    </div>
    <%-- Popup window--%>
    <div id = "divBackground" style="position: fixed; z-index: 999; height: 100%; width: 100%; top: 0; left:0; background-color: Black; filter: alpha(opacity=60); opacity: 0.6; -moz-opacity: 0.8;display:none">
     </div>
     <%-- Popup window--%>

    
</asp:Content>
