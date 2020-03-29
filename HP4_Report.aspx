<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HP4_Report.aspx.cs" Inherits="HP4_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                       <ContentTemplate>

                            <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="14%"
                    BackColor="#ECF1FF" NavigateUrl="~/LineBooking2.aspx"><i class="fa fa-bars"></i> LINE BOOKING</asp:HyperLink>
                     <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="26%"
                    BackColor="#ECF1FF" NavigateUrl="~/HP5.aspx"><i class="fa fa-bars"></i> HOURLY PRODUCTION ENTRY</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="26%"
                    BackColor="#ECF1FF" NavigateUrl="~/HP4_Report.aspx"><i class="fa fa-bars"></i> HOURLY PRODUCTION REPORT</asp:HyperLink>

             <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" width="24%"
                    BackColor="#ECF1FF" NavigateUrl="~/PlanningDashboard.aspx"><i class="fa fa-bars"></i> PLANNING DASHBOARD</asp:HyperLink>
               
           
          
        </div>


                       <div style="min-height:500px">
                      <div style="padding-top:6px;text-align:center;">Hourly Production Report</div>
    <div><hr class="hr" /></div>
  <%--  <div class="label" style="margin-top:10px">Company Name
        <asp:DropDownList ID="drpcompany" runat="server" 
            CssClass="textboxforgridview" Width="250px">
        </asp:DropDownList>

       


        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="drpcompany" Display="None" ErrorMessage="Select Company" 
            ValidationGroup="v">*</asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
        &nbsp;&nbsp;&nbsp;&nbsp; Date
        <asp:TextBox ID="txtDate" runat="server" CssClass="textboxforgridview" 
            Width="100px" Enabled="False"></asp:TextBox>
            <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                                                      Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="cal1" 
                                                                      TargetControlID="txtDate" PopupPosition="TopLeft">
                                                                  </asp:CalendarExtender>
        <asp:ImageButton ID="cal1" runat="server" Height="13px" 
            ImageUrl="~/images/calendar.gif" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnsrc" runat="server" Font-Size="11px" onclick="btnsrc_Click" 
            Text="Search" Width="100px" ValidationGroup="v" />
        <input id="Button1" type="button" style="font-size:11px; width:70px" class="print" rel="pntdv" value="Print" />
      

       
        </div>--%>
                           <%--<asp:Label ID="lbltotalinfo" runat="server" Text="Label"></asp:Label>--%>
                           <div style="text-align:center;">
                               Factory Name
                               <asp:DropDownList ID="drpFactory" runat="server" Width="250px">
                                   <asp:ListItem>-</asp:ListItem>
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Factory" ControlToValidate="drpFactory" Display="None" ValidationGroup="v"></asp:RequiredFieldValidator>
                               <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" Enabled="true" TargetControlID="RequiredFieldValidator1"></asp:ValidatorCalloutExtender>

                                &nbsp;&nbsp;&nbsp;&nbsp; Date
                               <asp:TextBox ID="txtDate" runat="server" Width="100px" Enabled="false"></asp:TextBox>
                               <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="true" Format="dd-MMM-yyyy" PopupButtonID="cal1" TargetControlID="txtDate" PopupPosition="TopLeft"></asp:CalendarExtender>
                               <asp:ImageButton ID="cal1" runat="server" Height="13px" 
                                                        ImageUrl="~/images/calendar.gif" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnsrc" runat="server" Font-Size="11px" onclick="btnsrc_Click" 
                                                    Text="Search" Width="100px" ValidationGroup="v" />
                           </div>
    <div>
        <hr class="hr" />
        </div>
    <div id="pntdv">
  
  
       <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" 
            CssClass="mGrid" 
            onrowdatabound="GridView1_RowDataBound" ShowFooter="True">
            
        <Columns>
        <asp:BoundField DataField="line_no" HeaderText="Line" />
        <asp:BoundField DataField="ord_no" HeaderText="Style" />
        <asp:BoundField DataField="po_no" HeaderText="PO" />        
        <asp:BoundField DataField="ord_buyer" HeaderText="Buyer" />
        
        
        
        <asp:BoundField DataField="H1" HeaderText="1" />
        <asp:BoundField DataField="H2" HeaderText="2" />
        <asp:BoundField DataField="H3" HeaderText="3" />
        <asp:BoundField DataField="H4" HeaderText="4" />
        <asp:BoundField DataField="H5" HeaderText="5" />
        <asp:BoundField DataField="H6" HeaderText="6" />
        <asp:BoundField DataField="H7" HeaderText="7" />
        <asp:BoundField DataField="H8" HeaderText="8" />
        <asp:BoundField DataField="H9" HeaderText="9" />
        <asp:BoundField DataField="H10" HeaderText="10" />
        <asp:BoundField DataField="H11" HeaderText="11" />
        <asp:BoundField DataField="H12" HeaderText="12" />
        <asp:BoundField DataField="target_hr" HeaderText="Target/Hour" />
        <asp:BoundField DataField="plan_hr" HeaderText="Plan/Hour" />
        <asp:BoundField DataField="target_dy" HeaderText="Target/Day" />
        <asp:BoundField DataField="totqty" HeaderText="Total Qty" />
        <asp:BoundField DataField="shortqty" HeaderText="Short Quantity" />
        <%--<asp:BoundField DataField="FobVal" HeaderText="Fob" />
        <asp:BoundField DataField="Rundays" HeaderText="Run Days" />
        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />--%>
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="lbllineid" runat="server" Text='<%# Eval("line_no") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>     
        
        
       
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
