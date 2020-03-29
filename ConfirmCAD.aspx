<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ConfirmCAD.aspx.cs" Inherits="ConfirmCAD" %>

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
            <div class="FldFream2">
                 <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
                   
                       <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="30%"
                            NavigateUrl="~/CADHome.aspx"><i class="fa fa-home"></i>CAD HOME </asp:HyperLink>
                        
                   
                    
                </div>
                <div class="divbody">
                    <div style="width: 100%; height: 482px; float: left; margin-top: 4px; overflow: auto;">
                        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="380px"
                            Width="98%" BorderStyle="None" CssClass="Tab">
                            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="For Approval">
                                <ContentTemplate>

                                 <div style="background-color: #d6f0fd; width: 100%; height:30px; float: left">
                                    
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
                                                        Pending Order List For CAD Approval
                                                    </th>
                                                    <tr>
                                                        <th>
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="105px">
                                                            ORDER 
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="120px">
                                                            ARTICLE
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="30px">
                                                            ARTICLE QTY
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            BUYER
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="40px">
                                                            BOOKING CONS
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="40px">
                                                            PROD CONS
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="30px">
                                                            DIFF CONS
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="40px">
                                                            BOOKING DIA
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="40px">
                                                            PROD DIA
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="30px">
                                                            DIFF DIA
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="40px">
                                                            BOOKING GSM
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="40px" align="center">
                                                            PROD GSM
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="30px" align="center">
                                                            DIFF GSM
                                                        </th>
                                                   
                                                        <th class="gridheade" nowrap="nowrap" width="80px" align="center">
                                                            APPROVED / CANCEL
                                                        </th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label1" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ord_no")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label8" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("art_no")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label2" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("art_qty")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label10" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("byr_nm")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label11" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("bCADCons")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label12" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("pCADCons")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblTotalCM1" runat="server" Text='<%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "pCADCons")) - Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "bCADCons"))%>' Font-Size="10px" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label13" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("bCADDia")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label14" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("pCADDia")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "pCADDia")) - Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "bCADDia"))%>' Font-Size="10px" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label15" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("bCADGsm")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label16" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("pCADGsm")%>'></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "pCADGsm")) - Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "bCADGsm"))%>' Font-Size="10px" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    
                                                    <td width="140px" align="center" nowrap="nowrap">
                                                        <asp:Label ID="lblapprove" Visible="false" runat="server" Text='<%# Eval("pCADId")%>'></asp:Label>
                                                        <asp:Button ID="btnapprove" Enabled="False" Text='<%# Eval("cadApproved","{0:dd/MMM/yyyy}")%>'
                                                            runat="server" OnClick="btnapprove_Click" Width="65px" CssClass="btn1" Font-Size="10px" />
                                                        <asp:Button ID="btncancle" Enabled="False" CssClass="btn2" Text='<%# Eval("cadCanceled","{0:dd/MMM/yyyy}")%>'
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
                                                   <th class="gridheade" nowrap="nowrap" width="105px">
                                                            ORDER 
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="120px">
                                                            ARTICLE
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="60px">
                                                            ARTICLE QTY
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            BUYER
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="70px">
                                                            BOOKING CONS
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="30px">
                                                            PROD CONS
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            BOOKING DIA
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            PROD DIA
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            BOOKING GSM
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            PROD GSM
                                                        </th>
                                                   
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            APPROVED 
                                                        </th>
                                                    
                                                </tr>
                                             
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label1" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ord_no")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label8" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("art_no")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label2" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("art_qty")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label10" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("byr_nm")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label11" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("bCADCons")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label12" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("pCADCons")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label13" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("bCADDia")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label14" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("pCADDia")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label15" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("bCADGsm")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label16" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("pCADGsm")%>'></asp:Label>
                                                    </td>

                                                <td align="center">
                                                      <asp:Label ID="lblapprove" Visible="false" runat="server" Text='<%# Eval("pCADId")%>'></asp:Label>
                                                    <asp:Button ID="btnapprove" Enabled="false" Text='<%# Eval("cadApproved","{0:dd/MMM/yyyy}")%>' runat="server"
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
                                                            ORDER 
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="120px">
                                                            ARTICLE
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="60px">
                                                            ARTICLE QTY
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            BUYER
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="70px">
                                                            BOOKING CONS
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="30px">
                                                            PROD CONS
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            BOOKING DIA
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            PROD DIA
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            BOOKING GSM
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            PROD GSM
                                                        </th>
                                                   
                                                        <th class="gridheade" nowrap="nowrap" width="80px">
                                                            CANCEL 
                                                        </th>
                                                        <th class="gridheade" nowrap="nowrap">
                                                            REWORK
                                                        </th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label1" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("ord_no")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label8" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("art_no")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label2" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("art_qty")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label10" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("byr_nm")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label11" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("bCADCons")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label12" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("pCADCons")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label13" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("bCADDia")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label14" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("pCADDia")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label15" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("bCADGsm")%>'></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="center">
                                                        <asp:Label ID="Label16" runat="server" CssClass="click_lbl" Font-Size="10px" Text='<%# Eval("pCADGsm")%>'></asp:Label>
                                                    </td>
                                                    <%--     <td>
                                                    <asp:Label ID="lbl27" runat="server" Font-Size="10px" Text='<%# Eval("TnAapproved", "{0:dd/MMM/yyyy}")%>'></asp:Label>
                                                </td>--%>
                                                    <td align="center">
                                                        <asp:Button ID="btnapprove" Enabled="false" Text='<%# Eval("cadCanceled","{0:dd/MMM/yyyy}")%>'
                                                            runat="server" CssClass="btn2" Width="70px" Font-Size="10px" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblrework" Visible="false" runat="server" Text='<%# Eval("pCADId")%>'></asp:Label>
                                                        <asp:Button ID="btnrework" Enabled="false" runat="server" OnClick="btnrework_Click"
                                                            Text='<%# Eval("cadRework","{0:dd/MMM/yyyy}")%>' CssClass="btn1" Width="70px"
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
