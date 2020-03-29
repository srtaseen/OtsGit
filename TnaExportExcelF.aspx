<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TnaExportExcelF.aspx.cs" Inherits="TnaExportExcelF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

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
                                <li><a href="TnaExportExcelF.aspx">TNA Export To Excel</a></li>
                    </ul>
                </div>
            </div>
        </div>
    <div>
         <table>
            <tr>
                <td>
                                    <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddbuyerM" runat="server" CssClass="textbox" Width="152px">
                                      <%--  <asp:ListItem Text="--"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                                <td width="10px">
                                </td>
                                <td>
                                    <asp:Button ID="btnfindM" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                        OnClick="btnfindM_Click" />
                                </td>
            </tr>
        </table>
    <asp:GridView ID="GridView1" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging">
    <Columns>
        <asp:BoundField DataField="ord_no" HeaderText="Order No" ItemStyle-Width="250px" />
        <asp:BoundField DataField="art_no" HeaderText="Article No" ItemStyle-Width="250px" />        
        <asp:BoundField DataField="po_no" HeaderText="PO No" ItemStyle-Width="250px" />
        <asp:BoundField DataField="po_quantity" HeaderText="PO Qty" ItemStyle-Width="150px" />
        <asp:BoundField DataField="ord_entdt" HeaderText="Order Entry Date" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="ord_cnfdate" HeaderText="Order Confirm Date" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="po_xfactory" HeaderText="Exfactory" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="ReExFactory" HeaderText="Rexfactory" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="TnaLedTm" HeaderText="Lead Time" ItemStyle-Width="100px" />
        <asp:BoundField DataField="Tna_Cr_Date" HeaderText="TNA Create Date" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="TnaApproved" HeaderText="TNA Approved Date" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="Username" HeaderText="Merchandiser" ItemStyle-Width="100px" />
        <asp:BoundField DataField="Tnapl1" HeaderText="Labdip Submit Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="Tnaac1" HeaderText="Labdip Submit Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="Tnapl2" HeaderText="Labdip Approval Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="Tnaac2" HeaderText="Labdip Approval Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}" />
        <asp:BoundField DataField="Tnapl3" HeaderText="Accessories Booking Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac3" HeaderText="Accessories Booking Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl4" HeaderText="Febric Booking Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac4" HeaderText="Febric Booking Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl5" HeaderText="Yarn Booking Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac5" HeaderText="Yarn Booking Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl6" HeaderText="Quality Fabric Submit Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac6" HeaderText="Quality Fabric Submit Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl7" HeaderText="Quality Fabric Apprv Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac7" HeaderText="Quality Fabric Apprv Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl8" HeaderText="Size Set Submit Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac8" HeaderText="Size Set Submit Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl9" HeaderText="Size Set Apprv Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac9" HeaderText="Size Set Apprv Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl10" HeaderText="Photo Sample Submit Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac10" HeaderText="Photo Sample Submit Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl11" HeaderText="Photo Sample Apprv Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac11" HeaderText="Photo Sample Apprv Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl12" HeaderText="CD Recv Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac12" HeaderText="CD Recv Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl13" HeaderText="Photo Inlay Submit Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac13" HeaderText="Photo Inlay Submit Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl14" HeaderText="Photo Inlay Apprv Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac14" HeaderText="Photo Inlay Apprv Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl15" HeaderText="PP Sample Submit Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac15" HeaderText="PP Sample Submit Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl16" HeaderText="PP Sample Apprv Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac16" HeaderText="PP Sample Apprv Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl17" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac17" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl18" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac18" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl19" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac19" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl20" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac20" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl21" HeaderText="PI Recv Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac21" HeaderText="PI Recv Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl22" HeaderText="BBLC Open Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac22" HeaderText="BBLC Open Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl23" HeaderText="Yarn Inhouse Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac23" HeaderText="Yarn Inhouse Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl24" HeaderText="Yarn Inhouse End Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac24" HeaderText="Yarn Inhouse End Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl25" HeaderText="Knit Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac25" HeaderText="Knit Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl26" HeaderText="Knit Finish Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac26" HeaderText="Knit Finish Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl27" HeaderText="Dye Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac27" HeaderText="Dye Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl28" HeaderText="Dye Finish Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac28" HeaderText="Dye Finish Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl29" HeaderText="Acc Prod Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac29" HeaderText="Acc Prod Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl30" HeaderText="Acc Prod End Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac30" HeaderText="Acc Prod End Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl31" HeaderText="Sewing Trims Inhouse Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac31" HeaderText="Sewing Trims Inhouse Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl32" HeaderText="Sewing Trims Inhouse End Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac32" HeaderText="Sewing Trims Inhouse End Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl33" HeaderText="Finishing Trims Inhouse Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac33" HeaderText="Finishing Trims Inhouse Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl34" HeaderText="Finishing Trims Inhouse End Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac34" HeaderText="Finishing Trims Inhouse End Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl35" HeaderText="PP Meeting/Trial Cut Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac35" HeaderText="PP Meeting/Trial Cut Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl36" HeaderText="Bulk Cutting Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac36" HeaderText="Bulk Cutting Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl37" HeaderText="Bulk Cutting Finish Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac37" HeaderText="Bulk Cutting Finish Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl38" HeaderText="Print Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac38" HeaderText="Print Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl39" HeaderText="Print Finish Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac39" HeaderText="Print Finish Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl40" HeaderText="EMB Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac40" HeaderText="EMB Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl41" HeaderText="EMB Finish Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac41" HeaderText="EMB Finish Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl42" HeaderText="Sewing Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac42" HeaderText="Sewing Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl43" HeaderText="Sewing Finish Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac43" HeaderText="Sewing Finish Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl44" HeaderText="Wash Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac44" HeaderText="Wash Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl45" HeaderText="Wash Finish Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac45" HeaderText="Wash Finish Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl46" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac46" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl47" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac47" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl48" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac48" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl49" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac49" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl50" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac50" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl51" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac51" HeaderText="None" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl52" HeaderText="Finish Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac52" HeaderText="Finish Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl53" HeaderText="Finish End Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac53" HeaderText="Finish End Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl54" HeaderText="Pre Final Ins Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac54" HeaderText="Pre Final Ins Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl55" HeaderText="Final Ins Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac55" HeaderText="Final Ins Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl56" HeaderText="YD Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac56" HeaderText="YD Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl57" HeaderText="YD Finish Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac57" HeaderText="YD Finish Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl58" HeaderText="AOP Start Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac58" HeaderText="AOP Start Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl59" HeaderText="AOP Finish Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac59" HeaderText="AOP Finish Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl60" HeaderText="Acc PI Recv Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac60" HeaderText="Acc PI Recv Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnapl61" HeaderText="Acc BBLC Recv Pln Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
        <asp:BoundField DataField="Tnaac61" HeaderText="Acc BBLC Recv Act Dt" ItemStyle-Width="100px" DataFormatString="{0:d}"/>
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick = "ExportToExcel" Visible="false" />
    </div>
</asp:Content>

