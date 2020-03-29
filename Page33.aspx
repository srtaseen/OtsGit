<%@ Page Title="OTS | YarnReport" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Page33.aspx.cs" Inherits="Page9" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
   
    <div class="FldFream1">
        <div class="divnv">
            <div style="float: left">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME </asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" 
                    BackColor="#ECF1FF" NavigateUrl="~/Page16.aspx"><i class="fa fa-caret-left"></i> YARN EVENTS</asp:HyperLink>
              
            </div>
           
        </div>
        <div class="divbody">
            <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                
            </div>
            <div style="width: 100%; height: 482px; float: left; margin-top: 4px; color: #000000; font-family: Arial, Helvetica, sans-serif; font-size: 12px;">
           <p style="padding: 4px; margin: 0px">Reports</p>
           <span style="padding: 4px 4px 4px 20px;">1.Time & Action Plan report by Delivery and exfactory date.</span><br />
                <p style="margin: 4px 4px 4px 20px; float: left">
                    <asp:Label ID="Label1" runat="server" Text="To Date"></asp:Label><br />
                <asp:TextBox ID="txt1" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>  
                    <asp:CalendarExtender ID="txt1_CalendarExtender" runat="server" Enabled="True" 
                        TargetControlID="txt1" PopupButtonID="imgPopup">
                    </asp:CalendarExtender>
                <asp:ImageButton ID="imgPopup" ImageUrl="icons/date-picker.png" runat="server" Class="datepic"
                                        ImageAlign="TextTop" /><br />
                    <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label><br />
                <asp:TextBox ID="txt2" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txt2_CalendarExtender" runat="server" Enabled="True" 
                        TargetControlID="txt2" PopupButtonID="im2">
                    </asp:CalendarExtender>
                  <asp:ImageButton ID="im2" ImageUrl="icons/date-picker.png" runat="server" Class="datepic"
                                        ImageAlign="TextTop" /> <br /><br />
                    <asp:Button ID="btnrpt" runat="server" Text="Report" 
                        CssClass="btn btn-primary" onclick="btnrpt_Click"/>
                </p>
            </div>
        </div>
    </div>
  
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
