<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BookingCAD.aspx.cs" Inherits="BookingCAD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

             <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="30%"
                            NavigateUrl="~/CADHome.aspx"><i class="fa fa-home"></i>CAD HOME </asp:HyperLink>
               
           
           
        </div>

                  <div style="height:300px; margin-top:20px;">

                <fieldset style="border:1px solid white;"> 
                    <b style="text-align:center;margin-left:600px;">Booking CAD Information</b>
       <table class="TblStyle" style="margin-top:10px; width:70%">
            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Style/Order </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetStyle" runat="server" CssClass="textbox" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="GetStyle_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                          
                           
                           
                                <td height="18px" width="100px" >
                                    <span class="text-primary"> Article No </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetPo" runat="server" CssClass="textbox" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="GetPo_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                             
                                 
                                <td height="18px" width="100px">
                                    <span class="text-primary"> Article Qty </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty" runat="server" CssClass="textbox" Width="200px">                                       
                            </asp:TextBox>
                                </td>
                                
                            </tr>

                            
                            <tr>
                                
                                
                                <td height="18px" width="100px">
                                    <span class="text-primary">Buyer </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBuyer" runat="server" CssClass="textbox" Width="200px">                                       
                            </asp:TextBox>
                                </td> 
                                
                                 <%--<td height="18px" width="100px">
                                    <span class="text-primary">Booking Date </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtentdt" runat="server" AutoPostBack="True" Width="200px" CssClass="Gridtextbox"
                                            Enabled="False">
                                    </asp:TextBox>
                                    <asp:ImageButton ID="imgPopup" ImageUrl="icons/date-picker.png" runat="server" CssClass="datepic2"
                                            ImageAlign="AbsBottom" />
                                     <asp:CalendarExtender ID="txtentdt_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="txtentdt" PopupButtonID="imgPopup">
                                     </asp:CalendarExtender>
                                </td>--%>
                                
                                
                            </tr>
                            
                            <tr>

                                

                                
                                <td>
                                </td>                                

                            </tr>
                           


        </table>
                     </fieldset>
    </div>

                     <div style="height:500px; margin-top:-150px;">
                 <fieldset style="border:1px solid white;"> 
                   
                <table class="TblStyle">
                    <tr>
                        <td height="18px" width="100px">
                           <span class="sp1">Booking CAD Details</span>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="text-primary">Booking Consumtion </span>
                        </td>
                         <td>
                            <asp:TextBox ID="txtBCons" runat="server" CssClass="textbox" Width="200px">                                       
                            </asp:TextBox>
                        </td>
                        <td>
                            <span class="text-primary">Booking DIA </span>
                        </td>
                         <td>
                            <asp:TextBox ID="txtBDia" runat="server" CssClass="textbox" Width="200px">                                       
                            </asp:TextBox>
                        </td>
                        <td>
                            <span class="text-primary">Booking GSM </span>
                        </td>
                         <td>
                            <asp:TextBox ID="txtBGsm" runat="server" CssClass="textbox" Width="200px">                                       
                            </asp:TextBox>
                        </td>
                    </tr>

                    
                </table>

                     <div style="margin-left:27px;margin-top:10px;margin-bottom:10px;">
                         <asp:Button ID="Btnsave" runat="server" Text="Save" CssClass="btn-primary large" 
                                BorderStyle="None" Width="50px" ValidationGroup="btnsave" OnClick="Btnsave_Click" />
                     </div>
                
</fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

