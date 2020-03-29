<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HP5.aspx.cs" Inherits="HP5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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






             <div style="height:300px; margin-top:20px;">

                <fieldset style="border:1px solid white;"> 
                    <b style="text-align:center;margin-left:600px;">Hourly Production Details</b>
                <table class="TblStyle" style="margin-top:10px;">

                    <tr>
                        <td height="18px" width="100px">
                                    <span class="text-primary">PO No </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpPO" runat="server" CssClass="textbox" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drpPO_SelectedIndexChanged">
                                       
                                    </asp:DropDownList>
                                </td>

                         <td height="18px" width="100px">
                                    <span class="text-primary">Line No </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpLine" runat="server" CssClass="textbox" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drpLine_SelectedIndexChanged">
                                       
                                    </asp:DropDownList>
                                </td>

                         <td height="18px" width="100px">
                                    <span class="text-primary">Order </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOrder" runat="server" CssClass="textbox" Width="200px">                                       
                                    </asp:TextBox>
                                </td>

                        <td height="18px" width="100px">
                                    <span class="text-primary">Buyer </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBuyer" runat="server" CssClass="textbox" Width="200px">                                       
                                    </asp:TextBox>
                                </td>

                       <td height="18px" width="100px">
                                    <span class="text-primary">Target/Hr </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTargerHr" runat="server" CssClass="textbox" Width="200px">                                       
                                    </asp:TextBox>
                                </td>
                    </tr>
                    <tr>
                         <td height="18px" width="100px">
                                    <span class="text-primary">Plan/Hr </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPlanHr" runat="server" CssClass="textbox" Width="200px">                                       
                                    </asp:TextBox>
                                </td>
                        <td height="18px" width="100px">
                                    <span class="text-primary">Target/Day </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTargetDy" runat="server" CssClass="textbox" Width="200px">                                       
                                    </asp:TextBox>
                                </td>

                         <td height="18px" width="300px">
                                    <span class="text-primary">Order Factory </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOrdFactory" runat="server" CssClass="textbox" Width="200px">                                       
                                    </asp:TextBox>
                                </td>

                        <td height="18px" width="100px">
                            <span class="text-primary">Entry Date </span>
                        </td>
                        <td style="width:200px;">
                            <asp:TextBox ID="txtentdt" runat="server" AutoPostBack="True" Width="70%" CssClass="Gridtextbox"
                                    Enabled="False">
                            </asp:TextBox>
                            <asp:ImageButton ID="imgPopup" ImageUrl="icons/date-picker.png" runat="server" CssClass="datepic2"
                                    ImageAlign="AbsBottom" />
                             <asp:CalendarExtender ID="txtentdt_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtentdt" PopupButtonID="imgPopup">
                             </asp:CalendarExtender>
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
                           <span class="sp1">HOURLY PRODUCTION INPUTS</span>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="drpHour" runat="server" CssClass="textbox" Width="200px" AutoPostBack="True">
                                        <asp:ListItem>-</asp:ListItem>
                                        <asp:ListItem Text="H1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="H2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="H3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="H4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="H5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="H6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="H7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="H8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="H9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="H10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="H11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="H12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                        </td>
                         <td>
                                    <asp:TextBox ID="txtHour" runat="server" CssClass="textbox" Width="200px">                                       
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

