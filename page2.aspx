<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="page2.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <div class="FldFream1">
     <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnkD"  Font-Underline="False" Width="10%" BackColor="#ECF1FF"><i class="fa fa-home" style="padding-right: 8px; padding-left: 4px; width: 20px; "></i>HOME</asp:HyperLink>
    
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk"  NavigateUrl="~/page5.aspx" Width="14%" BackColor="#FFFF95"><i class="fa fa-bars"></i> MERCHANDISING</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" Width="8%" BackColor="#FFFF95" NavigateUrl="~/Page15.aspx"><i class="fa fa-bars"></i> TEXTILE</asp:HyperLink>

        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" Width="12%"  BackColor="#FFFF95" NavigateUrl="~/Page25.aspx"><i class="fa fa-bars"></i> ACCESSORIES</asp:HyperLink>
         <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="10%" BackColor="#FFFF95" NavigateUrl="~/Page26.aspx"><i class="fa fa-bars"></i> INVENTORY</asp:HyperLink>
 
        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" Width="6%" BackColor="#FFFF95" NavigateUrl="~/Page24.aspx"><i class="fa fa-bars"></i> RMG</asp:HyperLink>
         <asp:HyperLink ID="HyperLink11" runat="server" CssClass="MhyperLnk" Width="14%" BackColor="#FFFF95" NavigateUrl="~/IEPlanningHome.aspx"><i class="fa fa-bars"></i> IE & PLANNING</asp:HyperLink>
         <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" width="10%" BackColor="#FFFF95" NavigateUrl="Page20.aspx"><i class="fa fa-bars"></i> REPORTS</asp:HyperLink>
         <asp:HyperLink ID="HyperLink12" runat="server" CssClass="MhyperLnk" width="8%" BackColor="#FFFF95" NavigateUrl="Problem_Followup.aspx"><i class="fa fa-bars"></i> PROBLEM ENTRY</asp:HyperLink>
  
  
        <asp:HyperLink ID="HyperLink8" runat="server" CssClass="MhyperLnk" width="8%"
            BackColor="#FFFF95" NavigateUrl="~/Page9.aspx"><i class="fa fa-cog"></i> SETUP</asp:HyperLink>

        </div>
       <div style=" margin-top: 2px; float: left; background-color: #FFFFFF; height:250px; width: 49.5%;">
       
          <div class="idiv">
         
           <p style="font-family: Arial, Helvetica, sans-serif; padding:6px;font-size: 11px; color: #333333; overflow: auto; float: left; line-height: 120%;"><span style="font-weight: bold; color: #259bdb">Welcome to the NZ GROUP ORDER TRACKING AND RESOURCE PLANNING (ORP).</span><br /><br />Create and track every order with an easy, efficient way. This solution will certainly increase bussiness by ensuring the managibility and security of all the orders. It will also provide the ease of task management.
                   
                    This System is developed and maintened by NZ Group ICT Department .
                    For system maintenence please email to: <br />systems_ots@nz-bd.com<br /><br />
                   
                    <span style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; font-weight: bold">Copyright & Legal Information</span><br />Realese Ver-: NZ-2015<br />
                    <span style="font-family: Arial, Helvetica, sans-serif; font-size: 11px">This software is a property of NZ Group.Copy or Publishing this software for bussiness or personal uses is prohibited.<br />© 2014 NZ GROUP 2015</span><br /><br />
                   <a CssClass="btn-link" href=""><i class="fa fa-gavel"></i> Legal act</a> | <a CssClass="btn-link" href=""><i class="fa fa-info-circle"></i> Help</a>
              </p>
          </div>
        </div>
        <div style=" margin-top: 2px; float: left; background-color: #FFFFFF; height:250px; width: 49.5%; margin-left: 1%;">
       
            <asp:PieChart ID="PieChart1" runat="server"  ChartType="Column" 
                ChartTitleColor="#0E426C" CssClass="idiv"
                ChartHeight="225px" ChartWidth="400px" >
                  
            </asp:PieChart>
           
        </div>
       
         <div style=" margin-top: 8px; float: left; background-color: #FFFFFF; height:280px;width: 49.5%;">
        <%--<p style="padding: 2px 2px 2px 15px; margin: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3333FF;">Present Buyer Status</p>
            <asp:GridView ID="GridView_p1" runat="server" AutoGenerateColumns="False" CssClass="gridcss">
             <AlternatingRowStyle BackColor="#F2F9FE" ForeColor="#284775" />
            <Columns>
            <asp:TemplateField>
             <HeaderStyle CssClass="gridheade" />
            <HeaderTemplate>BUYER</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Width="120px"  CssClass="gridlbl" Text='<%# Eval("byr_nm")%>'>></asp:Label>
            </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField>
             <HeaderStyle CssClass="gridheade" />
            <HeaderTemplate>ORDER QUANTITY</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Width="100px" CssClass="gridlbl" Text=""></asp:Label>
            </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField>
             <HeaderStyle CssClass="gridheade" />
            <HeaderTemplate>EXPORT QUANTITY</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text=""></asp:Label>
            </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField>
             <HeaderStyle CssClass="gridheade" />
            <HeaderTemplate>ON TIME EXPORT</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" CssClass="gridlbl" Text=""></asp:Label>
            </ItemTemplate>
            </asp:TemplateField> 
            </Columns>
            </asp:GridView>--%>
            <div>
                <h2 style="color:#3c9bdc; margin-left:20px;">Order In Hand Report</h2>
                 <div style="margin-left:30px; margin-top:50px;">
                    <asp:HyperLink ID="HyperLink9" runat="server" width="85%"
                        BackColor="#afccf7" NavigateUrl="~/OrderInHand.aspx"><i class="fa fa-stack-overflow fa-lg"></i> <b>ORDER IN HAND</b></asp:HyperLink>
                  </div>
                 
            </div>
        </div>
         <div style=" margin-top: 8px; float: left; background-color: #FFFFFF; height:280px; width: 49.5%; margin-left: 1%;">
        <p style="padding: 2px 2px 2px 4px; margin: 10px 0px 0px 5px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3333FF; text-decoration: underline;"><i class="fa fa-hand-o-right"></i> <a href="http://192.168.0.108/otsold/dashbd.aspx">GET PREVIUOS SYSTEM</a></p>
          
        </div>
    </div>
    
        </a></span>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
