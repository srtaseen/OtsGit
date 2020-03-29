<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Export_Report.aspx.cs" Inherits="Export_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <style type="text/css">
        .header {
	margin: 1em 0 0.5em 0;
	color:blue;
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
               <%-- <div style="padding-top:10px;text-align:center;">Export Report</div>--%>
                <h1 class="header">Export Report</h1>

                <div><hr class="hr" /></div>

                 <div style="text-align:center;">
                              <span class="masking">Factory Name</span> 
                               <asp:DropDownList ID="drpFactory" runat="server" Width="250px" CssClass="custom-dropdown">
                                   <asp:ListItem>-</asp:ListItem>
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Factory" ControlToValidate="drpFactory" Display="None" ValidationGroup="v"></asp:RequiredFieldValidator>
                               <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" Enabled="true" TargetControlID="RequiredFieldValidator1"></asp:ValidatorCalloutExtender>

                                &nbsp;&nbsp;&nbsp;&nbsp;<span class="masking">Date</span> 
                               <asp:TextBox ID="txtDate" runat="server" Width="100px" Enabled="false" CssClass="custom"></asp:TextBox>
                               <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="true" Format="dd-MMM-yyyy" PopupButtonID="cal1" TargetControlID="txtDate" PopupPosition="TopLeft"></asp:CalendarExtender>
                               <asp:ImageButton ID="cal1" runat="server" Height="13px" 
                                                        ImageUrl="~/images/calendar.gif" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnsrc" runat="server" Font-Size="11px" onclick="btnsrc_Click" CssClass="btn btn-primary" 
                                                    Text="Search" Width="100px" ValidationGroup="v" />

									&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:TextBox ID="txtSearch" runat="server" placeholder="STYLE NO"  CssClass="textbox"></asp:TextBox>
								 &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnSearch" runat="server" Text="Style Wise Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" Width="120px" Font-Size="11px"/>
                           </div>
    <div>
        <hr class="hr" />
        </div>

                <div id="pntdv">
  
  
        <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" 
            CssClass="mGrid" ShowFooter="True">
            
        <Columns>
        <asp:BoundField DataField="cStyleNo" HeaderText="Style No" />
        <asp:BoundField DataField="sp_POLot" HeaderText="PO No" />
        <asp:BoundField DataField="cColour" HeaderText="Color Name" />
        <asp:BoundField DataField="sp_Size" HeaderText="Size Name" />
        <asp:BoundField DataField="sp_SizeQty" HeaderText="Export Qty" />
        <asp:BoundField DataField="sp_Fob" HeaderText="FOB" />
        <asp:BoundField DataField="sp_TotalValue" HeaderText="Total Value" />
       
        <%--<asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="lbllineid" runat="server" Text='<%# Eval("aLineID") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>  --%>   
        
        
       
        </Columns>
            <AlternatingRowStyle BackColor="#DDF7FF" Font-Size="11px" ForeColor="#333333" />
            <FooterStyle BackColor="#009BE6" Font-Size="11px" ForeColor="White" />
            <HeaderStyle BackColor="#0083C1" Font-Size="13px" ForeColor="White" />
            <RowStyle BackColor="#F7F7F7" Font-Size="11px" />
        </asp:GridView>
       
        </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



