<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GTypeProcessEntry.aspx.cs" Inherits="GTypeProcessEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="FldFream1">
         <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="20%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
             <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" Width="20%" BackColor="#ECF1FF"
                    NavigateUrl="~/page38.aspx"><i class="fa fa-home"></i> PLANNING</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="30%"
                    BackColor="#ECF1FF" NavigateUrl="~/GTypeProcessEntry.aspx"><i class ="fa fa-bars"></i>GARMENTS TYPE PROCESS ENTRY</asp:HyperLink>
             <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" width="30%"
                    BackColor="#ECF1FF" NavigateUrl="~/StyleInformationEntry.aspx"><i class="fa fa-bars"></i> STYLE INFORMATION ENTRY</asp:HyperLink>
                                 
           </div>

<div class="divbody">
    <fieldset class="fldProsess2">

        <h1>Garments Type Process Entry Form</h1>

        <div style="margin-left:50px;">
    <table>
        <tr>
            <td height="18px" width="100px">
                <span class="text-primary">Garments Type </span>
            </td>
            <td>
                <asp:DropDownList ID="GetGType" runat="server" CssClass="btn btn-default btn-sm" Width="200px">
                                        <asp:ListItem>-</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

       <tr>
            <td><br /></td>
            <td><br /></td>
        </tr>

       
        <tr>
            <td height="18px" width="100px">
                <span class="text-primary">Process Name </span>
            </td>
            <td>
                <asp:DropDownList ID="GetProcess" runat="server" CssClass="btn btn-default btn-sm" Width="200px">
                                        <asp:ListItem>-</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><br /></td>
            <td><br /></td>
        </tr>
        <tr>
             <td height="18px" width="100px">
                <span class="text-primary">SMV </span>
             </td>
             <td>
                <asp:TextBox ID="txtSmv" runat="server" CssClass="form-control input-sm" Width="200px">                                       
                </asp:TextBox>
             </td>
        </tr>
        <tr>
            <td><br /></td>
            <td><br /></td>
        </tr>
        <tr>
             <td height="18px" width="100px">
                <span class="text-primary">Machine Qty </span>
             </td>
             <td>
                <asp:TextBox ID="txtMachine" runat="server" CssClass="form-control input-sm" Width="200px">                                       
                </asp:TextBox>
             </td>
        </tr>
        <tr>
            <td><br /></td>
            <td><br /></td>
        </tr>
        <tr>
             <td height="18px" width="100px">
                <span class="text-primary">Man Qty </span>
             </td>
             <td>
                <asp:TextBox ID="txtMan" runat="server" CssClass="form-control input-sm" Width="200px">                                       
                </asp:TextBox>
             </td>
        </tr>
        <tr>
            <td><br /></td>
            <td><br /></td>
        </tr>
        <tr>
      
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary"  Text="SAVE" onclick="btnSave_Click"/>
            </td>
        </tr>
    </table>

    <asp:Label runat="server" ID="lblmsg"></asp:Label>
            </div>

        </fieldset>
    </div>
        </div>
</asp:Content>

