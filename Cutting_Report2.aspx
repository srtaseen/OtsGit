<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cutting_Report2.aspx.cs" Inherits="Cutting_Report2" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
             <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="10%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page24.aspx"><i class="fa fa-bars"></i> RMG HOME</asp:HyperLink>
                              
                       
        </div>
            <%--<div style="height:10px;"></div>--%>
             <h1 class="header">Cutting Reports</h1>
            <div style="margin-left:200px;">

            <div style="padding:10px; text-align:center; color:#1EA7EE;">
    
     </div>
     <div>
         <table style="width:100%;">
             <tr>
                 <td style="vertical-align:top; width:500px;">
                     <div ID="lst">
                         <table style="width: 100%;">
                             <tr>
                                 <td align="left">
                                     &nbsp;</td>
                             </tr>
                             <tr>
                                 <td align="left">
                                     <asp:RadioButton ID="rdDailycutsummery" runat="server" AutoPostBack="True" CssClass="custom" 
                                         Font-Names="Arial" Font-Size="20px" GroupName="a" 
                                         oncheckedchanged="rdDailycutsummery_CheckedChanged" Text="Daily Cut Summery" />
                                 </td>
                             </tr>
                             <tr>
                                 <td align="left">
                                     <asp:RadioButton ID="rdCuttingd2d" runat="server" AutoPostBack="True" CssClass="custom"
                                         Font-Names="Arial" Font-Size="20px" GroupName="a" 
                                         oncheckedchanged="rdCuttingd2d_CheckedChanged" 
                                         Text="Cutting Summery Date To Date" />
                                 </td>
                             </tr>
                             <tr>
                                 <td align="left">
                                     &nbsp;</td>
                             </tr>
                             <tr>
                                 <td align="left">
                                     &nbsp;</td>
                             </tr>
                             <tr>
                                 <td align="left">
                                     &nbsp;</td>
                             </tr>
                         </table>
                     </div>
                     </td>
                <%-- <td style="vertical-align:center">
                 <div id="talkbubble">
                
                     <asp:Label ID="lblinfo" runat="server" 
                         Text="Information : </br></br>1.Select Report List.</br>2.Set parameter's Value.</br></br>-Click Generate Report Button" 
                         ForeColor="#E06DE1"></asp:Label>
                             </div>
                     </td>--%>
             </tr>
         </table>
        </div>
    
      
       <div style="margin-top:7px; padding-top:5px">   
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
                                       <asp:TextBox ID="txtFormdate" runat="server" CssClass="textbox" Enabled="False" 
                                           Width="180px"></asp:TextBox>
                                       <asp:CalendarExtender ID="txtFormdate_CalendarExtender" runat="server" 
                                           Enabled="True" Format="dd/MM/yyyy" PopupButtonID="cal1" 
                                           TargetControlID="txtFormdate">
                                       </asp:CalendarExtender>
                                       <asp:CalendarExtender ID="txtFormdate_CalendarExtender2" runat="server" 
                                           Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="cal" 
                                           TargetControlID="txtFormdate">
                                       </asp:CalendarExtender>
                                       <asp:ImageButton ID="cal" runat="server" Enabled="False" Height="12px" 
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
                                       <asp:TextBox ID="txtTodate" runat="server" CssClass="textbox" Enabled="False" 
                                           Width="180px"></asp:TextBox>
                                       <asp:CalendarExtender ID="txtTodate_CalendarExtender" runat="server" 
                                           Enabled="True" Format="dd/MM/yyyy" PopupButtonID="cal2" 
                                           TargetControlID="txtTodate">
                                       </asp:CalendarExtender>
                                       <asp:CalendarExtender ID="txtTodate_CalendarExtender2" runat="server" 
                                           Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="cal2" 
                                           TargetControlID="txtTodate">
                                       </asp:CalendarExtender>
                                       <asp:ImageButton ID="cal2" runat="server" Enabled="False" Height="12px" 
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
                               <tr>
                                   <td class="label" 
                                       style="text-align: right; font-family: Arial; font-size: 20px;">
                                       Company</td>
                                   <td style="text-align: left;">
                                       <asp:DropDownList ID="drpcompany" runat="server" CssClass="custom-dropdown" 
                                           Width="200px">
                                       </asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="rdcompany" runat="server" 
                                           ControlToValidate="drpcompany" Display="None" ErrorMessage="Select Company." 
                                           ValidationGroup="a">*</asp:RequiredFieldValidator>
                                       <asp:ValidatorCalloutExtender ID="rdcompany_ValidatorCalloutExtender" 
                                           runat="server" Enabled="True" TargetControlID="rdcompany">
                                       </asp:ValidatorCalloutExtender>
                                       <asp:ValidatorCalloutExtender ID="rdcompany_ValidatorCalloutExtender2" 
                                           runat="server" Enabled="True" TargetControlID="rdcompany">
                                       </asp:ValidatorCalloutExtender>
                                   </td>
                                   <td>
                                       &nbsp;</td>
                               </tr>
                               <tr>
                               <td></td>
                               <td></td>
                               </tr>
                               <tr>
                                   <td>
                                       &nbsp;</td>
                                   <td>
                                       &nbsp;</td>
                               </tr>
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
                       <asp:Button ID="btnGeneraterpt" runat="server" Enabled="False" Height="40px" CssClass="btn btn-primary" 
                           onclick="Button1_Click" Text="Generate Report" ValidationGroup="a" 
                           Width="250px" />
                   </td>
                   <td>
                   </td>
               </tr>
           </table>
      </div>

                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

