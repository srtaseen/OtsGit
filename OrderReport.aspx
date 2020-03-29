<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OrderReport.aspx.cs" Inherits="OrderReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


       <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnkD"  Font-Underline="False" Width="10%" BackColor="#ECF1FF"><i class="fa fa-home" style="padding-right: 8px; padding-left: 4px; width: 20px; "></i>HOME</asp:HyperLink>
    
        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk"  NavigateUrl="~/page5.aspx" Width="14%" BackColor="#FFFF95"><i class="fa fa-bars"></i> MERCHANDISING</asp:HyperLink>
        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" Width="8%" BackColor="#FFFF95" NavigateUrl="~/Page15.aspx"><i class="fa fa-bars"></i> TEXTILE</asp:HyperLink>

        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" Width="14%"  BackColor="#FFFF95" NavigateUrl="~/Page25.aspx"><i class="fa fa-bars"></i> ACCESSORIES</asp:HyperLink>
         <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="12%" BackColor="#FFFF95" NavigateUrl="~/Page26.aspx"><i class="fa fa-bars"></i> INVENTORY</asp:HyperLink>
 
        <asp:HyperLink ID="HyperLink8" runat="server" CssClass="MhyperLnk" Width="6%" BackColor="#FFFF95" NavigateUrl="~/Page24.aspx"><i class="fa fa-bars"></i> RMG</asp:HyperLink>
         <asp:HyperLink ID="HyperLink11" runat="server" CssClass="MhyperLnk" Width="10%" BackColor="#FFFF95" NavigateUrl="~/Page38.aspx"><i class="fa fa-bars"></i> PLANNING</asp:HyperLink>
         <asp:HyperLink ID="HyperLink9" runat="server" CssClass="MhyperLnk" width="10%" BackColor="#FFFF95" NavigateUrl="Page18.aspx"><i class="fa fa-bars"></i> REPORTS</asp:HyperLink>
         <asp:HyperLink ID="HyperLink12" runat="server" CssClass="MhyperLnk" width="8%" BackColor="#FFFF95" NavigateUrl="OrderReport.aspx"><i class="fa fa-bars"></i> Order</asp:HyperLink>
  
  
        <asp:HyperLink ID="HyperLink10" runat="server" CssClass="MhyperLnk" width="8%"
            BackColor="#FFFF95" NavigateUrl="~/Page9.aspx"><i class="fa fa-cog"></i> SETUP</asp:HyperLink>

        </div>

    <div style="border:1px solid white; width:1100px;height:150px;margin-left:100px;margin-top:20px; padding:10px;">
        <h3 style="margin-left:280px;">Weekly Order In Hand For The Year Of 2016</h3>
        <div style="text-align:center;margin-top:20px;">

            <table>
                <tr>
                    <td>
                       <asp:HyperLink ID="HyperLink15" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderOctober16.aspx">Weekly Report For The Month Of October'16 </asp:HyperLink>
                    </td>
                    <td>
                       <asp:HyperLink ID="HyperLink16" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderNovember16.aspx">Weekly Report For The Month Of November'16 </asp:HyperLink> 
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink17" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderDecember16.aspx">Weekly Report For The Month Of December'16 </asp:HyperLink>
                    </td>
                </tr>
                
            </table>

            </div>
        <div></div>

         <div style="border:1px solid white; width:1100px;height:250px;margin-left:-10px;margin-top:50px; padding:10px;">
        <h3 style="margin-left:280px;">Weekly Order In Hand For The Year Of 2017</h3>
        <div style="text-align:center;margin-top:20px;">

            <table>
                <tr>
                    <td>
                      <asp:HyperLink ID="HyperLink1" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderJanuary17.aspx">Weekly Report For The Month Of January'17 </asp:HyperLink>
                    </td>
                    <td>
                       <asp:HyperLink ID="HyperLink13" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderFebruary17.aspx">Weekly Report For The Month Of February'17 </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink14" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderMarch17.aspx">Weekly Report For The Month Of March'17 </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                      <asp:HyperLink ID="HyperLink2" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderApril17.aspx">Weekly Report For The Month Of April'17 </asp:HyperLink>
                    </td>
                    <td>
                       <asp:HyperLink ID="HyperLink20" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderMay17.aspx">Weekly Report For The Month Of May'17 </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink21" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderJune17.aspx">Weekly Report For The Month Of June'17 </asp:HyperLink>
                    </td>
                </tr>
                 <tr>
                    <td>
                      <asp:HyperLink ID="HyperLink18" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderJuly17.aspx">Weekly Report For The Month Of July'17 </asp:HyperLink>
                    </td>
                    <td>
                       <asp:HyperLink ID="HyperLink23" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderAugust17.aspx">Weekly Report For The Month Of August'17 </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink24" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderSeptember17.aspx">Weekly Report For The Month Of September'17 </asp:HyperLink>
                    </td>
                </tr>

                 <tr>
                    <td>
                      <asp:HyperLink ID="HyperLink19" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderOctober17.aspx">Weekly Report For The Month Of October'17 </asp:HyperLink>
                    </td>
                    <td>
                       <asp:HyperLink ID="HyperLink26" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderNovember17.aspx">Weekly Report For The Month Of November'17 </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink27" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderDecember17.aspx">Weekly Report For The Month Of December'17 </asp:HyperLink>
                    </td>
                </tr>
                
            </table>

            </div>
             </div>


        <div style="border:1px solid white; width:1100px;height:150px;margin-left:-10px;margin-top:20px; padding:10px;">
        <h3 style="margin-left:280px;">Monthly Order In Hand </h3>
        <div style="text-align:center;margin-top:20px;">

            <table>
                <tr>
                    <td>
                       <asp:HyperLink ID="HyperLink22" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderMonthYear16.aspx">Monthly Report For The Year Of 2016 </asp:HyperLink>
                    </td>
                    <td>
                       <asp:HyperLink ID="HyperLink25" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderMonthJanuary17.aspx">Monthly Report For The Year Of 2017 </asp:HyperLink>
                    </td>
                  
                </tr>
                
            </table>

            </div>
            </div>
            
           <%-- <br />
            <br />
            
            <br />
            <br />
            
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderJanuary17.aspx">Weekly Report For The Month Of January'17 </asp:HyperLink>
            <br/>
            <br />
            <asp:HyperLink ID="HyperLink13" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderFebruary17.aspx">Weekly Report For The Month Of February'17 </asp:HyperLink>
            <br />  
            <br />      
            <asp:HyperLink ID="HyperLink14" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderMarch17.aspx">Weekly Report For The Month Of March'17 </asp:HyperLink>
            <br />  
            <br />      
            <asp:HyperLink ID="HyperLink19" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderApril17.aspx">Weekly Report For The Month Of April'17 </asp:HyperLink>
            <br />  
            <br />      
            <asp:HyperLink ID="HyperLink20" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderMay17.aspx">Weekly Report For The Month Of May'17 </asp:HyperLink>
               <br />  
            <br />      
            <asp:HyperLink ID="HyperLink21" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderJune17.aspx">Weekly Report For The Month Of June'17 </asp:HyperLink>
               <br />  
            <br />      
            <asp:HyperLink ID="HyperLink22" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderJuly17.aspx">Weekly Report For The Month Of July'17 </asp:HyperLink>
               <br />  
            <br />      
            <asp:HyperLink ID="HyperLink23" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderAugust17.aspx">Weekly Report For The Month Of August'17 </asp:HyperLink>
               <br />  
            <br />      
            <asp:HyperLink ID="HyperLink24" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderSeptember17.aspx">Weekly Report For The Month Of September'17 </asp:HyperLink>
               <br />  
            <br />      
            <asp:HyperLink ID="HyperLink25" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderOctober17.aspx">Weekly Report For The Month Of October'17 </asp:HyperLink>
               <br />  
            <br />      
            <asp:HyperLink ID="HyperLink26" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderNovember17.aspx">Weekly Report For The Month Of November'17 </asp:HyperLink>
               <br />  
            <br />      
            <asp:HyperLink ID="HyperLink27" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderDecember17.aspx">Weekly Report For The Month Of December'17 </asp:HyperLink>

        </div>

        
    </div>
    <div style="border:1px solid white; width:500px;height:200px;margin-left:400px;margin-top:20px;">
        <div style="text-align:center;margin-top:20px;">
            <asp:HyperLink ID="HyperLink18" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderMonthYear16.aspx">Monthly Report For The Year Of 2016 </asp:HyperLink>
			<br />  
            <br /> 
    <asp:HyperLink ID="HyperLink2" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/OrderMonthJanuary17.aspx">Monthly Report For The Year Of 2017 </asp:HyperLink>

            </div>
    </div>--%>


</asp:Content>

