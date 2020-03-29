<%@ Page Title="OTS | T&A Approved" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="Page8.aspx.cs" Inherits="Page8" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <link href="Styles/liquid-slider.css" rel="stylesheet" type="text/css" />
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
                   
                       <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                            NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME </asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnkD" Font-Underline="False" Width="16%"
                            BackColor="#ECF1FF"><i class="fa fa-th"></i> MERCHANDISING <i class="fa fa-caret-right"></i> </asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnkD" Font-Underline="False" Width="18%"
                            BackColor="#D9E4FF" ForeColor="#0033CC"><i class="fa fa-th-large"></i> APPROVE T&A <i class="fa fa-caret-right"></i> </asp:HyperLink>
                   
                    <div class="dropdownM">
                        <%--   <asp:HyperLink ID="HyperLink3" runat="server" CssClass="account" 
            Font-Underline="False" BackColor="#ECF1FF">MERCHANDISING </asp:HyperLink>--%>
                        <a class="accountM">MENU<i class="fa fa-chevron-down fa-1x" style="margin-left: 50px"></i></a>
                        <div class="submenuM">
                            <ul class="rootM">
                                <li><a href="Page5.aspx">Order Schedule</a></li>
                                <li><a href="Page3.aspx">Order Master</a></li>
                                <li><a href="Page30.aspx">Assortment</a></li>
                                <li><a href="Page7.aspx">Create T&A</a></li>
                                <li><a href="Page8.aspx">Approve T&A</a></li>
                                <li><a href="Page31.aspx">Reload T&A</a></li>
                                 <li><a href="Page12.aspx">T&A Events</a></li>
                                <li><a href="#feedback">Report</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="divbody">
                    <div style="width: 100%; height: 482px; float: left; margin-top: 4px; overflow: auto;">
                        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="380px"
                            Width="98%" BorderStyle="None" CssClass="Tab">
                            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="For Approval">
                                <ContentTemplate>

                                 <div style="background-color: #d6f0fd; width: 100%; height:30px; float: left">
                                    <table style="padding: 2px; margin-top: 2px;">
                                        <tr>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; text-align: right;
                                                color: #333333; padding-right: 4px; font-weight: bold;" width="150px" height="18px">
                                                BUYER
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddbuyer" CssClass="textbox" runat="server" Font-Size="11px"
                                                    Width="152px">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="10px">
                                            </td>
                                            <td>
                                                <asp:Button ID="btnchk" runat="server" Text="Get" CssClass="btn-primary small" OnClick="btnchk_Click"
                                                    BorderStyle="None" width="70px"/>
                                            </td>
                                            <td width="10px">
                                            </td>
                                            <td>
                                                <%--<asp:Button ID="btnGreport" runat="server" Text="Grid Report" CssClass="btn-primary small"
                                                    OnClick="btnGreport_Click" BorderStyle="None" width="80px"/>
                                                </button>--%>
                                            </td>
                                        </tr>
                                    </table>
                                    </div>
                                    <div style="padding: 0px; margin: 0px; float: left; overflow: auto">
                                    <asp:GridView ID="Gvorder" runat="server" AutoGenerateColumns="False" CssClass="gridcss3"
                                        AllowPaging="True" PageSize="10" OnRowDataBound="Gvorder_RowDataBound" OnPageIndexChanging="Gvorder_PageIndexChanging" Width="98%"
                                        BorderColor="White" BorderStyle="Solid" BorderWidth="1px">
                                        <RowStyle CssClass="RowStyle" />
                                        <AlternatingRowStyle BackColor="#F2F9FE" ForeColor="#284775" />
                                        <FooterStyle Wrap="False" />
                                        <HeaderStyle Wrap="False" />
                                        <PagerSettings PageButtonCount="5" />
                                      <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <th colspan="12" >
                                                        Pending Order List For T & A Approval
                                                    </th>
                                                    <tr>
                                                        <th>
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="105px">
                                                            ORDER
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="120px">
                                                            PO
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="60px">
                                                            QUANTITY
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            ORDER DATE
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="70px">
                                                            EXFACTORY
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="30px">
                                                            LEAD
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            CREATE DATE
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            CREATE By
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            ORDER STATE
                                                        </th>
                                                   
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            APPROVED / CANCLE
                                                        </th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label1" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ord_no")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label8" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_no")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label2" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_quantity")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label3" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ord_cnfdate" ,"{0:dd/MMM/yyyy}")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label4" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_xfactory" ,"{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label5" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_led")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label6" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("TnaCreateDate" ,"{0:dd/MMM/yyyy}")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label9" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("TnaCreateDate" ,"{0:dd/MMM/yyyy}")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label7" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ActStatus")%>'></asp:Label>
                                                    </td>
                                                    <%--           <td nowrap="nowrap">
                                                   <asp:Button ID="Button1" Enabled="False" Text="Report" runat="server"
                                                        Width="60px" CssClass="ClickRpt" Font-Size="10px" />
                                                </td>--%>
                                                    <td width="140px" align="center" nowrap="nowrap">
                                                        <asp:Label ID="lblapprove" Visible="false" runat="server" Text='<%# Eval("po_id")%>'></asp:Label>
                                                        <asp:Button ID="btnapprove" Enabled="False" Text='<%# Eval("TnAapproved","{0:dd/MMM/yyyy}")%>'
                                                            runat="server" OnClick="btnapprove_Click" Width="65px" CssClass="btn1" Font-Size="10px" />
                                                        <asp:Button ID="btncancle" Enabled="False" CssClass="btn2" Text='<%# Eval("TnaCancle","{0:dd/MMM/yyyy}")%>'
                                                            runat="server" OnClick="btncancle_Click" Width="65px" Font-Size="10px" />
                                                    </td>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField />
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Approved">
                                <ContentTemplate>
                                     <asp:GridView ID="Gvorder2" runat="server" AutoGenerateColumns="False" CssClass="gridcss3"
                                            AllowPaging="True" PageSize="15" OnPageIndexChanging="Gvorder2_PageIndexChanging"
                                            BorderColor="White" BorderStyle="Solid" BorderWidth="1px" >
                                        <RowStyle CssClass="RowStyle"/>
                                    <AlternatingRowStyle BackColor="#f2f9fe" ForeColor="#284775" />
                                    <FooterStyle Wrap="False" />
                                    <HeaderStyle Wrap="False" />
                                         <PagerSettings PageButtonCount="5" />
                                      <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" /> 
                                            <Columns>
                                          <asp:TemplateField>
                                            <HeaderTemplate>
                                            <th colspan="9" >
                                            T & A Approved Order List
                                            </th>
                                                <tr >
                                                    <th>
                                                    </th>
                                                   <th  class="gridheade" nowrap="nowrap" width="105px">
                                                        ORDER
                                                    </th>
                                                   <th  class="gridheade" nowrap="nowrap" width="120px">
                                                        PO
                                                    </th>
                                                  
                                                    <th  class="gridheade" nowrap="nowrap" width="60px">
                                                       QUANTITY
                                                    </th>
                                                    <th  class="gridheade" nowrap="nowrap" width="80px">
                                                        ORDER DATE
                                                    </th>
                                                    <th  class="gridheade" nowrap="nowrap" width="70px">
                                                        EXFACTORY
                                                    </th>
                                                    <th  class="gridheade" nowrap="nowrap" width="40px">
                                                        LEAD 
                                                    </th>
                                                    <th  class="gridheade" nowrap="nowrap" width="80px">
                                                      CREATE DATE
                                                    </th>

                                                   <th  class="gridheade" nowrap="nowrap" >
                                                       APPROVED DATE
                                                    </th>
                                                    
                                                </tr>
                                             
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <td nowrap="nowrap" align="center">
                                                    <asp:Label ID="Label1" runat="server"  CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ord_no")%>'></asp:Label>
                                                </td>
                                                <td nowrap="nowrap" align="center">
                                                    <asp:Label ID="Label8" runat="server"  CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_no")%>'></asp:Label>
                                                </td>
                                                <td nowrap="nowrap" align="center">
                                                    <asp:Label ID="Label2" runat="server"  CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_quantity")%>'></asp:Label>
                                                </td>
                                                <td nowrap="nowrap" align="center">
                                                    <asp:Label ID="Label3" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ord_cnfdate" ,"{0:dd/MMM/yyyy}")%>'></asp:Label>
                                                </td>
                                                <td nowrap="nowrap" align="center">
                                                    <asp:Label ID="Label4" runat="server"  CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_xfactory" ,"{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                                </td>
                                                <td nowrap="nowrap" align="center">
                                                    <asp:Label ID="Label5" runat="server"  CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_led")%>'></asp:Label>
                                                </td>
                                                <td nowrap="nowrap" align="center">
                                                    <asp:Label ID="Label6" runat="server"  CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("TnaCreateDate" ,"{0:dd/MMM/yyyy}")%>'></asp:Label>
                                                </td>

                                                <td align="center">
                                                      <asp:Label ID="lblapprove" Visible="false" runat="server" Text='<%# Eval("po_id")%>'></asp:Label>
                                                    <asp:Button ID="btnapprove" Enabled="false" Text='<%# Eval("TnAapproved","{0:dd/MMM/yyyy}")%>' runat="server"
                                                        OnClick="btnapprove_Click" CssClass="btn1" Width="70px" Font-Size="10px" />
                                                </td>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField />
                                    </Columns>
                                   
                                        </asp:GridView>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Canclled">
                                <ContentTemplate>
                                 <div style="padding: 0px; margin: 0px; float: left; overflow: auto">
                                    <asp:GridView ID="gvcancle" runat="server" AutoGenerateColumns="False" CssClass="gridcss3"
                                        OnRowDataBound="gvcancle_RowDataBound" AllowPaging="True" PageSize="15" OnPageIndexChanging="gvcancle_PageIndexChanging"
                                        BorderColor="White" BorderStyle="Solid" BorderWidth="1px" >
                                        <RowStyle CssClass="RowStyle" />
                                        <AlternatingRowStyle BackColor="#F2F9FE" ForeColor="#284775" />
                                        <FooterStyle Wrap="False" />
                                        <HeaderStyle Wrap="False" />
                                      <PagerSettings PageButtonCount="5" />
                                      <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <th colspan="11" >
                                                        For Rework Order List
                                                    </th>
                                                    <tr>
                                                        <th>
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="105px">
                                                            ORDERNUMBER
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="120px">
                                                            PO
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            QUANTITY
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            ORDER DATE
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            EXFACTORY
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="40px">
                                                            LEAD
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            T&A CREATE
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            ORDER STATE
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap">
                                                            CANCLE DATE
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap">
                                                            REWORK
                                                        </th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td align="center">
                                                        <asp:Label ID="Label1" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ord_no")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label8" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_no")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label2" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_quantity")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label3" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ord_cnfdate" ,"{0:dd/MMM/yyyy}")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label4" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_xfactory" ,"{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label5" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("po_led")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label6" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("TnaCreateDate" ,"{0:dd/MMM/yyyy}")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label7" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ActStatus")%>'></asp:Label>
                                                    </td>
                                                    <%--     <td>
                                                    <asp:Label ID="lbl27" runat="server" Font-Size="10px" Text='<%# Eval("TnAapproved", "{0:dd/MMM/yyyy}")%>'></asp:Label>
                                                </td>--%>
                                                    <td align="center">
                                                        <asp:Button ID="btnapprove" Enabled="false" Text='<%# Eval("TnaCancle","{0:dd/MMM/yyyy}")%>'
                                                            runat="server" CssClass="btn2" Width="70px" Font-Size="10px" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblrework" Visible="false" runat="server" Text='<%# Eval("po_id")%>'></asp:Label>
                                                        <asp:Button ID="btnrework" Enabled="false" runat="server" OnClick="btnrework_Click"
                                                            Text='<%# Eval("TnaRework","{0:dd/MMM/yyyy}")%>' CssClass="btn1" Width="70px"
                                                            Font-Size="10px" />
                                                    </td>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField />
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </div>
                </div>
            </div>
            <%--Window Loading--%>
            <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
            <script src="NECESSARY%20PLUGINS/js/jquery-1.11.3.min.js" type="text/javascript"></script>
            <script type="text/javascript">
                function ShowProgress() {
                    setTimeout(function () {
                        var modal = $('<div />');
                        modal.addClass("modal");
                        $('body').append(modal);
                        var loading = $(".loading");
                        loading.show();
                        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                        loading.css({ top: top, left: left });
                    }, 20000);
                }
                $('form').live("submit", function () {
                    ShowProgress();
                });
            </script>
            <div class="loading" align="center">
                Loading. Please wait.<br />
                <br />
                <img src="Images\loader.gif" alt="" />
            </div>
            <%--Window Loading--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
