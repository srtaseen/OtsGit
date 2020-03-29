<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Spreading_Report2.aspx.cs" Inherits="Spreading_Report2" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container"> 
		<div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
                  
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="30%"
                            NavigateUrl="~/CADHome.aspx"><i class="fa fa-home"></i>CAD HOME </asp:HyperLink>
                        
                   
                    
                </div>
    <div style="width:500px;">
        <table class="TblStyle">
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="sp1">ORDER DETAILS</span>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr></tr>
                            <tr></tr>
                            <tr></tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Buyer </span>
                                </td>
                                <td>
                            <asp:DropDownList ID="ddlbuyer" runat="server" CssClass="textbox" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="ddlbuyer_SelectedIndexChanged">
                             <asp:ListItem Text="-" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                                <td>
                                </td>
                            </tr>
                            <tr></tr>
                            <tr></tr>
                            <tr></tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Style/Order</span>
                                </td>
                                <td>
                            <asp:DropDownList ID="ddlStyle" runat="server" CssClass="textbox" Width="95%" OnSelectedIndexChanged="ddlStyle_SelectedIndexChanged"
                                        AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                            </tr>
                            <tr></tr>
                            <tr></tr>
                            <tr></tr>

                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Article</span>
                                </td>
                                <td>
                            <asp:DropDownList ID="ddlarticle" runat="server" CssClass="textbox" Width="95%" AutoPostBack="true" OnSelectedIndexChanged="ddlarticle_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                            </tr>
                            <tr></tr>
                            <tr></tr>
                            <tr></tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">PO</span>
                                </td>
                                <td>
                            <asp:DropDownList ID="DropDownpo" runat="server" CssClass="textbox" Width="95%" AutoPostBack="True">
                                         <asp:ListItem Text="-" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                            </tr>
                            <tr></tr>
                            <tr></tr>
                            <tr></tr>
            </table>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Load" CssClass="btn btn-primary" />
       
        
       
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
            <LocalReport ReportPath="Spreading_Report2.rdlc"></LocalReport>
        </rsweb:ReportViewer>
       
        
       
    </div>
        </div>
</asp:Content>

