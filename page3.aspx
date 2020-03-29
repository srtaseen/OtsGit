<%@ Page Title="OTS|OrderMaster" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="page3.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
            <link href="Styles/popupwindow.css" rel="stylesheet" type="text/css" />
            <%-- Popup window--%>
            <script type="text/javascript">
                $(function () {
                    modalPosition();
                    $(window).resize(function () {
                        modalPosition();
                    });
                    $('.openModal1').click(function (e) {
                        $('.modal1, .modal1-backdrop').fadeIn('fast');
                        e.preventDefault();

                    });
                    $('.close-modal1').click(function (e) {
                        $('.modal1, .modal1-backdrop').fadeOut('fast');
                    });
                });
                function modalPosition() {
                    var width = $('.modal1').width();
                    var pageWidth = $(window).width();
                    var x = (pageWidth / 2) - (width / 2);
                    $('.modal1').css({ left: x + "px" });
                }
            </script>
            <%-- Popup window--%>
            <%-- Menu--%>
            <script type="text/javascript">
                $(document).ready(function () {
                    $(".accountM").click(function () {
                        var X = $(this).attr('id');

                        if (X == 1) {
                            $(".submenuM").hide();
                            $(this).attr('id', '0');
                        }
                        else {

                            $(".submenuM").show();
                            $(this).attr('id', '1');
                        }

                    });

                    //Mouseup textarea false
                    $(".submenuM").mouseup(function () {
                        return false
                    });
                    $(".accountM").mouseup(function () {
                        return false
                    });


                    //Textarea without editing.
                    $(document).mouseup(function () {
                        $(".submenuM").hide();
                        $(".accountM").attr('id', '');
                    });

                });
	
            </script>
            <%-- Menu--%>
            <div class="FldFream1">
                <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
                  
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                            NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME </asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnkD" Font-Underline="False" Width="16%"
                            BackColor="#ECF1FF"><i class="fa fa-th"></i> MERCHANDISING <i class="fa fa-caret-right"></i> </asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnkD" Font-Underline="False" Width="18%"
                            BackColor="#D9E4FF" ForeColor="#0033CC"><i class="fa fa-th-large"></i> ORDER MASTER <i class="fa fa-caret-right"></i> </asp:HyperLink>
                   
                    <div class="dropdownM">
                        <%--   <asp:HyperLink ID="HyperLink3" runat="server" CssClass="account" 
            Font-Underline="False" BackColor="#ECF1FF">MERCHANDISING </asp:HyperLink>--%>
                        <a class="accountM"><i class="fa fa-bars"></i> MENU<i class="fa fa-chevron-down fa-1x" style="margin-left: 20px"></i></a>
                        <div class="submenuM">
                            <ul class="rootM">
                                <li><a href="Page5.aspx">Order Schedule</a></li>
                                <li style="background-color: #FFFF95"><a href="Page3.aspx">Order Master</a></li>
                                <li><a href="Page30.aspx">Assortment</a></li>
                                <li><a href="Page7.aspx">Create T&A</a></li>
                                <li><a href="Page8.aspx">Approve T&A</a></li>
                                <li><a href="Page31.aspx">Reload T&A</a></li>
                                <li><a href="Page12.aspx">T&A Events</a></li>
                         
                                <li><a href="#feedback">Report</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="divbody111">
                    <fieldset class="fld111">
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
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Style/Order</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="stnm" runat="server" CssClass="textbox" Width="98%"></asp:TextBox>
                                </td>
                                <td width="15px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="**"
                                        ControlToValidate="stnm" ValidationGroup="btnsave" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Buyer </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetByr" runat="server" CssClass="textbox" Width="98%">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Garments Type </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetGType" runat="server" CssClass="textbox" Width="98%">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Style Type </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetStType" runat="server" CssClass="textbox" Width="98%">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
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

                            <%--entry date area--%>

                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Order Entry Date</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="entdt" runat="server" CssClass="textbox" Width="70%" Enabled="False"></asp:TextBox>
                                    <asp:ImageButton ID="imgPopup2" ImageUrl="icons/date-picker.png" runat="server" Class="datepic"
                                        ImageAlign="TextTop" />
                                    <asp:CalendarExtender ID="entdt_CalendarExtender" runat="server" Enabled="True" TargetControlID="entdt"
                                        PopupButtonID="imgPopup2">
                                    </asp:CalendarExtender>
                                </td>
                                <td width="15px">
                                </td>
                            </tr>
                            

                            <%--entry date area--%>

                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Order Receive Details Date</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="rcvdt" runat="server" CssClass="textbox" Width="70%" Enabled="False"></asp:TextBox>
                                    <asp:ImageButton ID="imgPopup" ImageUrl="icons/date-picker.png" runat="server" Class="datepic"
                                        ImageAlign="TextTop" />
                                    <asp:CalendarExtender ID="rcvdt_CalendarExtender" runat="server" Enabled="True" TargetControlID="rcvdt"
                                        PopupButtonID="imgPopup">
                                    </asp:CalendarExtender>
                                </td>
                                <td width="15px">
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px" colspan="3">
                                    <span class="sp1">SPECIAL OPERATION</span>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">AOP </span>
                                </td>
                                <td>
                                    <div class="squaredFour">
                                        <input type="checkbox" runat="server" value="None" id="cb1" name="check" />
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Embroidery </span>
                                </td>
                                <td>
                                    <div class="squaredFour">
                                        <input type="checkbox" runat="server" value="None" id="cb2" name="check" />
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Garment Wash </span>
                                </td>
                                <td>
                                    <div class="squaredFour">
                                        <input type="checkbox" runat="server" value="None" id="cb3" name="check" />
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Printing </span>
                                </td>
                                <td>
                                    <div class="squaredFour">
                                        <input type="checkbox" runat="server" value="None" id="cb4" name="check" />
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="sp1">FABRICATION</span>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Solid Fab. </span>
                                </td>
                                <td>
                                    <div class="squaredFour">
                                        <input type="checkbox" runat="server" value="None" id="cb5" name="check" />
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Y/D Fab. </span>
                                </td>
                                <td>
                                    <div class="squaredFour">
                                        <input type="checkbox" runat="server" value="None" id="cb6" name="check" />
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Y/D+Solid Fab. </span>
                                </td>
                                <td>
                                    <div class="squaredFour">
                                        <input type="checkbox" runat="server" value="None" id="cb7" name="check" />
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="fld222">
                        <div style="float: left; width: 99%; margin-left: 1%; margin-top: 8px;">
                            <span class="sp1">DELIVERY DETAILS</span>
                        </div>
                        <div style="border: 1px solid #006699; float: left; width: 98%; margin-left: 1%;
                            margin-top: 2px; height: 450px; overflow: auto;">
                            <asp:GridView ID="GridViewpo" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                                CellPadding="2" GridLines="None" OnRowDataBound="GridViewpo_RowDataBound" Width="99%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle CssClass="gridheade" />
                                <PagerSettings PageButtonCount="5" />
                                <Columns>
                                    <asp:TemplateField HeaderText="PO NUMBER">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtpo" runat="server" AutoPostBack="True" Width="98%" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QUANTITY">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 80px;">
                                                <asp:TextBox ID="txtqun" runat="server" Width="98%" AutoPostBack="True" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PRICE">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 50px;">
                                                <asp:TextBox ID="txtprc" runat="server" Width="98%" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SHIP DT.">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxshipdt" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 95px;">
                                                <asp:TextBox ID="txtspdt" runat="server" AutoPostBack="True" Width="70%" CssClass="Gridtextbox"
                                                    OnTextChanged="txtspdt_TextChanged" Enabled="False"></asp:TextBox>
                                                <asp:ImageButton ID="imgPopup" ImageUrl="icons/date-picker.png" runat="server" CssClass="datepic2"
                                                    ImageAlign="AbsBottom" />
                                                <asp:CalendarExtender ID="txtspdt_CalendarExtender" runat="server" Enabled="True"
                                                    TargetControlID="txtspdt" PopupButtonID="imgPopup">
                                                </asp:CalendarExtender>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ex-FACTORY">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 80px;">
                                                <asp:TextBox ID="txtexft" runat="server" Width="98%" CssClass="Gridtextbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LEAD ">
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 35px">
                                                <asp:TextBox ID="txtld" runat="server" Width="98%" CssClass="Gridtextbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BPCD ">
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 70px">
                                                <asp:TextBox ID="txtbss" runat="server" Width="98%" CssClass="Gridtextbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SHIPMODE">
                                        <FooterTemplate>
                                            <button type="submit" id="btn" runat="server" onserverclick="FunctionB_ServerClick"
                                                title="Add New" class="btn-primary small" style="border-style: none;">
                                                <i class="fa fa-plus-square"></i>New
                                            </button>
                                        </FooterTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 70px">
                                                <asp:DropDownList ID="shipmod" runat="server" Width="98%" CssClass="Gridtextbox"
                                                    AppendDataBoundItems="True" AutoPostBack="True">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--For SMV Value--%>

                                    <asp:TemplateField HeaderText="SMV ">
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 70px">
                                                <asp:TextBox ID="txtSmv" runat="server" Width="98%" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>

                                    <%--For SMV Value--%>

                                </Columns>
                            </asp:GridView>
                        </div>
                        <div style="float: left; width: 99%; margin-left: 1%; margin-top: 8px; height: 20px;">
                            <asp:Button ID="Btnsave" runat="server" Text="Save" CssClass="btn-primary small"
                                BorderStyle="None" Width="50px" ValidationGroup="btnsave" OnClick="Btnsave_Click1" />
                            <input id="BtnNewWindo" type="button" value="Edit" class="btn-primary small openModal1"
                                style="border-style: none; width: 50px;" />
                            <asp:Button ID="Btnclr" runat="server" Text="Clear" CssClass="btn-primary small"
                                BorderStyle="None" Width="50px" />
                            <div id="divBackground" style="position: fixed; z-index: 999; height: 100%; width: 100%;
                                top: 0; left: 0; background-color: Black; filter: alpha(opacity=60); opacity: 0.6;
                                -moz-opacity: 0.8; display: none">
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal1">
        <div class="modal1-header">
            <h3>
                OTS <a class="close-modal1" href="#">&times;</a></h3>
        </div>
        <div class="modal1-body">
            <iframe style="width: 100%; height: 410px;" id="ifrm" src="page4.aspx" runat="server">
            </iframe>
        </div>
        <div class="modal1-footer">
        </div>
    </div>
    <div class="modal1-backdrop">
    </div>
</asp:Content>
