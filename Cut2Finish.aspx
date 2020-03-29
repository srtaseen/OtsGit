<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cut2Finish.aspx.cs" Inherits="Cut2Finish" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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
     <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="15%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page27.aspx"><i class="fa fa-bars"></i> PRINT</asp:HyperLink>
                     <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page28.aspx"><i class="fa fa-bars"></i> EMBROIDERY</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page29.aspx"><i class="fa fa-bars"></i> RMG</asp:HyperLink>
             <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" width="10%"
                    BackColor="#ECF1FF" NavigateUrl="~/Cutting_Report2.aspx"><i class="fa fa-bars"></i> CUTTING</asp:HyperLink>
             <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/SewingHome.aspx"><i class="fa fa-bars"></i> SEWING</asp:HyperLink>
              <asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/Cut2Finish.aspx"><i class="fa fa-bars"></i> CUTTING TO FINISH</asp:HyperLink>
               
           
           
        </div>
     <h1 class="header">Cutting To Finish Reports</h1>
      <div style="margin-top:50px; padding-top:20px;margin-left:400px;border:1px solid white;width:500px;padding-bottom:10px;">   
           <table style="width:100%;">
               <tr>
                   <td style="width:500px;">
                       <div class="bx">
                           <table style="width: 100%;">
                               <tr>
                                   <td style="text-align: right; font-family: Arial; font-size: 20px;" 
                                       class="label">
                                       From Date</td>
                                   <td style="text-align: left;">
                                       <asp:TextBox ID="txtFormdate" runat="server" CssClass="textbox" Enabled="true" 
                                           Width="180px"></asp:TextBox>
                                       <asp:CalendarExtender ID="txtFormdate_CalendarExtender" runat="server" 
                                           Enabled="True" Format="dd/MM/yyyy" PopupButtonID="cal1" 
                                           TargetControlID="txtFormdate">
                                       </asp:CalendarExtender>
                                       <asp:CalendarExtender ID="txtFormdate_CalendarExtender2" runat="server" 
                                           Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="cal" 
                                           TargetControlID="txtFormdate">
                                       </asp:CalendarExtender>
                                       <asp:ImageButton ID="cal" runat="server" Enabled="true" Height="12px" 
                                           ImageUrl="~/images/calendar.gif" />
                                       <asp:RequiredFieldValidator ID="rqFormdt" runat="server" 
                                           ControlToValidate="txtFormdate" Display="None" ErrorMessage="Enter From Date" 
                                           ValidationGroup="a">*</asp:RequiredFieldValidator>
                                       <asp:ValidatorCalloutExtender ID="rqFormdt_ValidatorCalloutExtender" 
                                           runat="server" Enabled="True" TargetControlID="rqFormdt">
                                       </asp:ValidatorCalloutExtender>
                                   </td>
                                   <td>
                                       &nbsp;</td>
                               </tr>

                               <tr>
                                   <td>&nbsp;</td>
                                   
                               </tr>

                               <tr>
                                   <td class="label" 
                                       style="text-align: right; font-family: Arial; font-size: 20px;">
                                       To Date</td>
                                   <td style="text-align: left;">
                                       <asp:TextBox ID="txtTodate" runat="server" CssClass="textbox" Enabled="true" 
                                           Width="180px"></asp:TextBox>
                                       <asp:CalendarExtender ID="txtTodate_CalendarExtender" runat="server" 
                                           Enabled="True" Format="dd/MM/yyyy" PopupButtonID="cal2" 
                                           TargetControlID="txtTodate">
                                       </asp:CalendarExtender>
                                       <asp:CalendarExtender ID="txtTodate_CalendarExtender2" runat="server" 
                                           Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="cal2" 
                                           TargetControlID="txtTodate">
                                       </asp:CalendarExtender>
                                       <asp:ImageButton ID="cal2" runat="server" Enabled="true" Height="12px" 
                                           ImageUrl="~/images/calendar.gif" />
                                       <asp:RequiredFieldValidator ID="rqTodate" runat="server" 
                                           ControlToValidate="txtTodate" Display="None" ErrorMessage="Enter To Date" 
                                           ValidationGroup="a">*</asp:RequiredFieldValidator>
                                       <asp:ValidatorCalloutExtender ID="rqTodate_ValidatorCalloutExtender" 
                                           runat="server" Enabled="True" TargetControlID="rqTodate">
                                       </asp:ValidatorCalloutExtender>
                                       <asp:ValidatorCalloutExtender ID="rqTodate_ValidatorCalloutExtender2" 
                                           runat="server" Enabled="True" TargetControlID="rqTodate">
                                       </asp:ValidatorCalloutExtender>
                                   </td>
                                   <td>
                                       &nbsp;</td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                    
                               </tr>
                               
                              <%-- <tr>
                               <td></td>
                               <td></td>
                               </tr>--%>
                               <%--<tr>
                                   <td>
                                       &nbsp;</td>
                                   <td>
                                       &nbsp;</td>
                               </tr>--%>
                           </table>
                       </div>
                   </td>
                   <td style="text-align: center;">
                       &nbsp;</td>
                
               </tr>
               <tr>
               <td>&nbsp;</td>
               <td>&nbsp;</td>
               </tr>
               <tr>
                   <td style="text-align:center">
                       <asp:Button ID="btnGeneraterpt" runat="server" Enabled="true" Height="40px" CssClass="btn btn-primary" 
                           onclick="Button1_Click" Text="Generate Report" ValidationGroup="a" 
                           Width="250px" />
                   </td>
                   <td>
                   </td>
               </tr>
           </table>
      </div>

</asp:Content>

