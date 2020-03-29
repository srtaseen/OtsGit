<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Problem_Followup.aspx.cs" Inherits="Problem_Followup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
		
             <div class="container">
			 <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
<asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                    NavigateUrl="~/Problem_Followup.aspx"><i class="fa fa-home"></i> ENTRY</asp:HyperLink>
<asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                    NavigateUrl="~/ProblemFollowReport.aspx"><i class="fa fa-home"></i> REPORT</asp:HyperLink>					
</div>
                 <h1 class="header">Problem Details</h1>
        <table style="margin:auto; margin-top:50px;">
            <tr>
                <td>
                    <span>Department</span>
                </td>
                <td>
                    <asp:DropDownList ID="GetDpt" runat="server" CssClass="textbox" Width="98%" AutoPostBack="true">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                </td>
                <td style="padding-left:50px;">
                    <span>Problem Description</span>
                </td>
                <td style="padding-left:50px;">
                     <asp:TextBox ID="txtDes" runat="server" TextMode="MultiLine" Height="70"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td>
                    <span>Responsible Person</span>
                </td>
                <td>
                     <asp:TextBox ID="txtRes" runat="server"></asp:TextBox>
                </td>

                <td style="padding-left:50px;">
                    <span>Category</span>
                </td>
                <td>
                    <asp:DropDownList ID="GetCat" runat="server" CssClass="textbox" Width="98%" AutoPostBack="true">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                </td>

                </tr>
            <tr style="height:20px;">
                <td></td>
                <td></td>
            </tr>
            <tr>
                
                <td>
                     <span>Plan Date</span>
                </td>
                <td>
                     <asp:TextBox ID="entdt" runat="server" CssClass="textbox" Width="70%" Enabled="False"></asp:TextBox>
                     <asp:ImageButton ID="imgPopup2" ImageUrl="icons/date-picker.png" runat="server" Class="datepic"
                                        ImageAlign="TextTop" />
                     <asp:CalendarExtender ID="entdt_CalendarExtender" runat="server" Enabled="True" TargetControlID="entdt"
                                        PopupButtonID="imgPopup2">
                     </asp:CalendarExtender>
                </td>
                                
            </tr>
        </table>

        <div style="margin-left:265px; margin-top:20px;">            
        <asp:Button ID="Btnsave" runat="server" Text="Save" CssClass="btn-primary small"
                                BorderStyle="None" Width="50px" ValidationGroup="btnsave" OnClick="Btnsave_Click1" />
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>

