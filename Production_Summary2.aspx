<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Production_Summary2.aspx.cs" Inherits="Production_Summary2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <style type="text/css">
        .header {
	margin: 1em 0 0.5em 0;
	color: #0d98e8;
	font-weight: normal;
	font-family: 'Ultra', sans-serif;   
	font-size: 20px;
	line-height: 42px;
	text-transform: uppercase;
	text-shadow: 0 2px white, 0 3px #777;
}

        .castellar {
     color: #444444;
    text-shadow: -1px -1px 1px #000, 1px 1px 1px #ccc;
}

        .neon {
    color: #D0F8FF;
    text-shadow: 0 0 5px #A5F1FF, 0 0 10px #A5F1FF,
             0 0 20px #A5F1FF, 0 0 30px #A5F1FF,
             0 0 40px #A5F1FF;
}

        .threed {
    color: #CCCCCC;
    text-shadow: 0 1px 0 #999999, 0 2px 0 #888888,
             0 3px 0 #777777, 0 4px 0 #666666,
             0 5px 0 #555555, 0 6px 0 #444444,
             0 7px 0 #333333, 0 8px 7px rgba(0, 0, 0, 0.4),
             0 9px 10px rgba(0, 0, 0, 0.2);
}

        .masking{
    color: #FFFFFF;
    -webkit-mask-box-image: url(mask.png) 0 0 repeat;
}

        .custom-dropdown {
 -webkit-appearance: none;  /*REMOVES DEFAULT CHROME & SAFARI STYLE*/
 -moz-appearance: none;  /*REMOVES DEFAULT FIREFOX STYLE*/
 border: 0 !important;  /*REMOVES BORDER*/

 color: #fff;
 -webkit-border-radius: 5px;
 border-radius: 5px;
 font-size: 14px;
 padding: 3px;
 width: 35%;
 cursor: pointer;

 background: #0d98e8 url(../Images/arrowvb.png) no-repeat right center;
 background-size: 20px 37px; /*TO ACCOUNT FOR @2X IMAGE FOR RETINA */
}

        .custom {
 -webkit-appearance: none;  /*REMOVES DEFAULT CHROME & SAFARI STYLE*/
 -moz-appearance: none;  /*REMOVES DEFAULT FIREFOX STYLE*/
 border: 0 !important;  /*REMOVES BORDER*/

 color: #fff;
 -webkit-border-radius: 5px;
 border-radius: 5px;
 font-size: 14px;
 padding: 3px;
 width: 35%;
 cursor: pointer; 
 background: #0d98e8;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

             <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
             <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="10%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page24.aspx"><i class="fa fa-bars"></i> RMG HOME</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="25%"
                    BackColor="#ECF1FF" NavigateUrl="~/Production_Report.aspx"><i class="fa fa-bars"></i>DAILY SEWING REPORT</asp:HyperLink>
                     <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="25%"
                    BackColor="#ECF1FF" NavigateUrl="~/Production_Summary.aspx"><i class="fa fa-bars"></i> DAILY PRODUCTION SUMMARY</asp:HyperLink>
             <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" width="30%"
                    BackColor="#ECF1FF" NavigateUrl="~/Line_Wise_Achievement.aspx"><i class="fa fa-bars"></i>LINE WISE ACHIEVEMENT</asp:HyperLink>               
                         
            
        </div>



            <div style="min-height:500px;">
                <%--<div style="padding-top:10px;text-align:center">NZ Group Production Summary Report</div>--%>

                <h1 class="header">NZ Group Production Summary Report</h1>

                <div><hr class="hr" /></div>

                 <div style="text-align:center;">                               

                                &nbsp;&nbsp;&nbsp;&nbsp; <span class="masking">Date</span>
                               <asp:TextBox ID="txtDate" runat="server" Width="100px" Enabled="false" CssClass="custom"></asp:TextBox>
                               <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="true" Format="dd-MMM-yyyy" PopupButtonID="cal1" TargetControlID="txtDate" PopupPosition="TopLeft"></asp:CalendarExtender>
                               <asp:ImageButton ID="cal1" runat="server" Height="13px" 
                                                        ImageUrl="~/images/calendar.gif" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnsrcrmg" runat="server" Font-Size="11px" onclick="btnsrcrmg_Click"
                                                    Text="Search" Width="100px" ValidationGroup="v" CssClass="btn btn-primary" />
                           </div>

                <div style="height:10px;">

                </div>              

                <div style="align-content:center;margin-left:200px;">
                    <asp:GridView ID="GvIvn" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CssClass="gridcss4" AllowPaging="True" PagerSettings-PageButtonCount="5"
                            PagerSettings-Position="Bottom" PageSize="50"  ShowFooter="true" OnRowDataBound="GvIvn_RowDataBound"> 
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="true" />
                            <HeaderStyle Wrap="true" />
                            <%--<HeaderStyle CssClass="gridheade3" />--%>
                            <HeaderStyle Width="50px" />
                            <HeaderStyle Font-Size="25px" />
                            <HeaderStyle BackColor="Tomato" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <FooterStyle Width="30px" />
                            <FooterStyle Font-Size="25px" />
                            <FooterStyle BackColor="Tomato" />
                            <FooterStyle Font-Bold="true" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                            
                            <Columns>

                                 

                                <asp:templatefield headertext="Company Name"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">
                                   
                                    <ItemTemplate>
                                        <asp:Label ID="Label50" runat="server" Text="" CssClass="glbl" Font-Size="20px"><%# Eval("cCmpName")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <%--<asp:label id="OrderTotalLabel"
                                            runat="server"/>--%>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="Total Cutting"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="20px"><%# Eval("TotalCut")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelTotalCut"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="Total Input"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                         <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="20px"><%# Eval("TotalInput")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelTotalInput"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>

                                <asp:templatefield headertext="Total Sewing"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="20px"><%# Eval("TotalSewing")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelTotalSewing"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>


                                <asp:templatefield headertext="Total Poly"
                                    itemstyle-horizontalalign="Right"
                                    footerstyle-horizontalalign="Right"
                                    footerstyle-backcolor="Blue"
                                    footerstyle-forecolor="White">

                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text=""   CssClass="glbl" Font-Size="20px"><%# Eval("TotalPoly")%></asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                          <asp:label id="LabelTotalPoly"
                                            runat="server"/>
                                     </footertemplate>
                                </asp:TemplateField>

                                


                            </Columns>
                        </asp:GridView>
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

</asp:Content>


