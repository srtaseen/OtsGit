<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Production_Summary.aspx.cs" Inherits="Production_Summary" %>

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

                            <div >
                       <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server" 
            CssClass="mGrid"  
            ShowFooter="True" onrowdatabound="GridView2_RowDataBound">
            
        <Columns>
       
       <asp:TemplateField>
       <ItemTemplate>
           <asp:Label ID="lblcompname" runat="server" Text=""></asp:Label>
           <asp:Label ID="lblCompid" Visible="false" runat="server" Text='<%# Eval("nCompanyID") %>'></asp:Label>
       </ItemTemplate>
       </asp:TemplateField>
        <asp:BoundField DataField="" HeaderText="Target" />
        <asp:BoundField DataField="CutTtl" HeaderText="Achive" />

        <asp:BoundField DataField="" HeaderText="Target" />
        <asp:BoundField DataField="Input" HeaderText="Achive" />

        <asp:BoundField DataField="SewTgt" HeaderText="Target" />
        <asp:BoundField DataField="QcOut" HeaderText="Achive" />


        <%--<asp:BoundField DataField="" HeaderText="Target" />
        <asp:BoundField DataField="SMV" HeaderText="SMV" />--%>

        <asp:BoundField DataField="" HeaderText="Target" />
        <asp:BoundField DataField="FinAchvQty" HeaderText="Achive" />       
        <%--<asp:BoundField DataField="FOB" HeaderText="FOB" />--%>
        <asp:BoundField DataField="Mo" HeaderText="Mo" />
        <asp:BoundField DataField="Hlp" HeaderText="Helper" />
         <%--<asp:BoundField DataField="QcOut" HeaderText="QcOut" />--%>
        </Columns>
            <AlternatingRowStyle BackColor="#DDF7FF" Font-Size="11px" ForeColor="#333333" />
            <FooterStyle BackColor="#009BE6" Font-Size="11px" ForeColor="White" />
            <HeaderStyle BackColor="#0083C1" Font-Size="14px" ForeColor="White" />
            <RowStyle BackColor="#F7F7F7" Font-Size="13px" />
        </asp:GridView>
                      </div> 



                </div>
                </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

