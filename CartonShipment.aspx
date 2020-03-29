<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CartonShipment.aspx.cs" Inherits="CartonShipment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

	<div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="8%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="8%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page27.aspx"><i class="fa fa-bars"></i> PRINT</asp:HyperLink>
                     <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="12.5%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page28.aspx"><i class="fa fa-bars"></i> EMBROIDERY</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="6%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page29.aspx"><i class="fa fa-bars"></i> RMG</asp:HyperLink>
             <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" width="9%"
                    BackColor="#ECF1FF" NavigateUrl="~/Cutting_Report2.aspx"><i class="fa fa-bars"></i> CUTTING</asp:HyperLink>
             <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" width="9%"
                    BackColor="#ECF1FF" NavigateUrl="~/SewingHome.aspx"><i class="fa fa-bars"></i> SEWING</asp:HyperLink>
              <asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/Cut2Finish.aspx"><i class="fa fa-bars"></i> CUTTING TO FINISH</asp:HyperLink>
             <asp:HyperLink ID="HyperLink8" runat="server" CssClass="MhyperLnk" width="8%"
                    BackColor="#ECF1FF" NavigateUrl="~/CartonShipment.aspx"><i class="fa fa-bars"></i> PACKING</asp:HyperLink>
             <asp:HyperLink ID="HyperLink9" runat="server" CssClass="MhyperLnk" width="8%"
                    BackColor="#ECF1FF" NavigateUrl="~/Export.aspx"><i class="fa fa-bars"></i> EXPORT</asp:HyperLink>
             <asp:HyperLink ID="HyperLink10" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/StyleWiseMasterReport.aspx"><i class="fa fa-bars"></i> MASTER REPORT</asp:HyperLink>
               
           
           
        </div>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



                  <div style="height:300px; margin-top:20px;">

                <fieldset style="border:1px solid white;"> 
                    <b style="text-align:center;margin-left:600px;">Packing Style Information</b>
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
                                    <span class="text-primary"> Lot/Po </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetPo" runat="server" CssClass="textbox" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="GetPo_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                             
                                     
                                <td height="18px" width="100px">
                                    <span class="text-primary"> Color </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetColor" runat="server" CssClass="textbox" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="GetColor_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>


                           
                               
                            </tr>

                            <tr>

                                 <td height="18px" width="100px">
                                    <span class="text-primary">Packing Date </span>
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
                                </td>

                                <td height="18px" width="100px">
                                    <span class="text-primary">Factory </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetFactory" runat="server" CssClass="textbox" Width="98%">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
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
                           <span class="sp1">Size Wise Packing Qty</span>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="GetSize" runat="server" CssClass="textbox" Width="200px">
                            </asp:DropDownList>
                        </td>
                         <td>
                            <asp:TextBox ID="txtShipQty" runat="server" CssClass="textbox" Width="200px">                                       
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

