<%@ Page Title="OTS | Assortment" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Page31.aspx.cs" Inherits="Page9" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

            <%--Menu--%>
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
            <%--Menu--%>
            <div class="FldFream1">
              <%--  <asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>--%>
                <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height: 25px;
                    border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95"
                        Width="10%" NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME </asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnkD" Font-Underline="False"
                        Width="18%" BackColor="#ECF1FF"><i class="fa fa-th"></i> MERCHANDISING <i class="fa fa-caret-right"></i> </asp:HyperLink>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnkD" Font-Underline="False"
                        Width="18%" BackColor="#D9E4FF" ForeColor="#0033CC"><i class="fa fa-th-large"></i> RE-LOAD T&A <i class="fa fa-caret-right"></i> </asp:HyperLink>
                    <div class="dropdownM">
                        <%--   <asp:HyperLink ID="HyperLink3" runat="server" CssClass="account" 
            Font-Underline="False" BackColor="#ECF1FF">MERCHANDISING </asp:HyperLink>--%>
                        <a class="accountM">MENU<i class="fa fa-chevron-down fa-1x" style="margin-left: 50px"></i></a>
                        <div class="submenuM">
                            <ul class="rootM">
                                <li><a href="Page5.aspx">Order Schedule</a></li>
                                <li><a href="Page3.aspx">Order Master</a></li>
                                <li><a href="Page30.aspx">Assortment</a></li>
                                <li><a href="Page7.aspx">Create T&A</a></li>
                                <li><a href="Page8.aspx">Approve T&A</a></li>
                                <li><a href="Page31.aspx">Reload T&A</a></li>
                                <li><a href="#feedback">Report</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <%--        </ContentTemplate>
                         </asp:UpdatePanel>--%>
                      <asp:UpdatePanel ID="up2" runat="server">
                    <ContentTemplate>
                <div class="divbody">
                    <div class="fld3">
                        <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 15px;
                            color: #FFFFFF; margin-top: 15px; font-family: Arial, Helvetica, sans-serif;"
                            width="94%">
                            <tr>
                                <td width="54%" height="18px">
                                    <span class="text-primary small">Buyer</span>
                                </td>
                                <td>
                                </td>
                                <td width="44%">
                                    <span class="text-primary small">Order Confirm Date</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlbuyer" runat="server" Width="100%" CssClass="textbox"
                                        Font-Size="11px" AutoPostBack="True" OnSelectedIndexChanged="ddlbuyer_SelectedIndexChanged">
                                        <asp:ListItem Text="-" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtocd" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="text-primary small">Style/Order</span>
                                </td>
                                <td width="20px">
                                </td>
                                <td>
                                    <span class="text-primary small">Exfactory Date</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlStyle" runat="server" Width="100%" CssClass="textbox"
                                        Font-Size="11px" OnSelectedIndexChanged="ddlStyle_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="--" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtxftd" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="text-primary small">PO/Delivery</span>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <span class="text-primary small">Re- Exfactory</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="DropDownpo" runat="server" Width="100%" OnSelectedIndexChanged="DropDownpo_SelectedIndexChanged"
                                        AutoPostBack="True" CssClass="textbox" Font-Size="11px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=""
                                        ControlToValidate="DropDownpo" ForeColor="#FF3300" ValidationGroup="tnaload"><i class="fa fa-asterisk"></i></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="newxfactory" runat="server" Enabled="false" Width="50%" CssClass="textbox"
                                        BackColor="#FFFFB0" Font-Size="11px" BorderColor="#999999" BorderStyle="Solid"
                                        BorderWidth="1px" OnTextChanged="newxfactory_TextChanged" AutoPostBack="True"></asp:TextBox>
                                    <asp:ImageButton ID="imgPopup" ImageUrl="~/icons/date-picker.png" runat="server" CssClass="datepic2"
                                        ImageAlign="TextTop" />
                                    <asp:CalendarExtender ID="newxfactory_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="newxfactory" PopupButtonID="imgPopup">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="text-primary small">Account Manager</span>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <span class="text-primary small">BPCD</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlusername" runat="server" Width="100%" CssClass="textbox"
                                        Font-Size="11px">
                                        <asp:ListItem Text="-" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbpsd" runat="server" Enabled="False" Width="67%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="text-primary small">T&A Category</span>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <span class="text-primary small">Lead Time</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddTnacategory" runat="server" Width="80%" BackColor="#FFFFB0"
                                        Font-Size="11px" AutoPostBack="True" CssClass="textbox">
                                        <asp:ListItem Text="--" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtled" runat="server" Enabled="False" Width="67%" CssClass="textbox"
                                        Font-Size="11px" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <span class="text-primary small">Pre Production Lead</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="lblpcd" runat="server" Enabled="False" Width="40%" CssClass="textbox"
                                        Font-Size="11px" BorderStyle="Solid" BorderColor="#CCCCCC" BackColor="#FFFFB0"
                                        BorderWidth="1px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <span class="text-primary small">Post Production Time</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="text-primary small">T&A Create Date</span>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="SewLed" runat="server" Enabled="False" Width="40%" CssClass="textbox"
                                        Font-Size="11px" BorderStyle="Solid" BorderColor="#CCCCCC" BackColor="#FFFFB0"
                                        BorderWidth="1px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                  <asp:TextBox ID="tsxtcrDate" runat="server" Enabled="False" Width="67%" CssClass="textbox"
                                        BackColor="#FFFFB0" Font-Size="11px" BorderStyle="None"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td height="70px">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="margin: 2px">
                                    <div style="padding: 4px 6px 4px 6px; float: left; background-color: #ECF1FF; width: 84%;">
                                        <asp:Button ID="btnGenarate" runat="server" Text="Genarate" Height="20px" Width="46%"
                                            CssClass="btn-primary small" BorderStyle="None" OnClick="btnGenarate_Click" />
                                        <asp:Button ID="btnmenual" runat="server" Text="Customize" Height="20px" Width="48%"
                                            ValidationGroup="tnaload" CssClass="btn-primary small" BorderStyle="None" OnClick="btnmenual_Click" />
                                    </div>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="padding: 0px 0px 0px 0px; width: 58%; height: 525px; float: left; margin-top: 0px;">
                        <div id="div1" runat='server' style="padding: 0px 0px 0px 0px; width: 100%; margin: 0px;
                            height: 25px">
                            <table style="padding: 0px; margin: 0px; float: left; width: 100%">
                                <tr>
                                    <td bgcolor="#35b0e4" style="border: 1px solid #FFFFFF">
                                        <span class="Text2">T & A EVENTS NAME</span>
                                    </td>
                                    <td bgcolor="#35b0e4" style="border: 1px solid #FFFFFF">
                                        <span class="Text2">GAP DAYS</span>
                                    </td>
                                    <td bgcolor="#35b0e4" style="border: 1px solid #FFFFFF">
                                        <span class="Text2">PLAN DATE</span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="padding: 0px 0px 0px 0px; height: 471px; overflow: auto; float: left;
                            width: 100%; border: 1px solid #FFFFFF; margin-left: 0px; background-color: #FFFFFF;">
                            <table id="Tab1" runat='server' width="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl1" runat="server" Font-Size="11px" CssClass="textbox1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg1" runat="server" Text="" Font-Size="11px" CssClass="textbox1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl1" runat="server" CssClass="textbox" ></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup1" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl1_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl1" PopupButtonID="imgPopup1">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl2" runat="server" Text="" Font-Size="11px" CssClass="textbox1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg2" runat="server" Text="" Font-Size="11px" CssClass="textbox1"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="lblpl2" runat="server" CssClass="textbox" ></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup2" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl2_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl2" PopupButtonID="imgPopup2">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl3" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg3" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="lblpl3" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup3" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl3_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl3" PopupButtonID="imgPopup3">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl4" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg4" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl4" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup4" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl4_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl4" PopupButtonID="imgPopup4">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl5" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg5" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl5" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup5" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl5_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl5" PopupButtonID="imgPopup5">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl6" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg6" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl6" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup6" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl6_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl6" PopupButtonID="imgPopup6">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl7" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg7" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl7" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup7" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl7_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl7" PopupButtonID="imgPopup7">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl8" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg8" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl8" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup8" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl8_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl8" PopupButtonID="imgPopup8">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl9" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg9" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl9" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup9" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl9_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl9" PopupButtonID="imgPopup9">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl10" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg10" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl10" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup10" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl10_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl10" PopupButtonID="imgPopup10">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl11" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td class="TnaCreateTabTdmr">
                                        <asp:Label ID="lblg11" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl11" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup11" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl11_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl11" PopupButtonID="imgPopup11">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl12" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg12" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl12" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup12" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl12_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl12" PopupButtonID="imgPopup12">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl13" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg13" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl13" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup13" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl13_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl13" PopupButtonID="imgPopup13">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl14" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg14" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl14" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup14" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl14_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl14" PopupButtonID="imgPopup14">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl15" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg15" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl15" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup15" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl15_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl15" PopupButtonID="imgPopup15">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl16" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg16" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl16" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup16" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl16_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl16" PopupButtonID="imgPopup16">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl17" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg17" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl17" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup17" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl17_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl17" PopupButtonID="imgPopup17">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl18" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg18" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl18" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup18" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl18_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl18" PopupButtonID="imgPopup18">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl19" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg19" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl19" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup19" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl19_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl19" PopupButtonID="imgPopup19">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl20" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td> 
                                        <asp:Label ID="lblg20" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl20" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="imgPopup20" ImageUrl="~/icons/date-picker.png" runat="server"
                                            ImageAlign="TextTop" />
                                        <asp:CalendarExtender ID="lblpl20_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="lblpl20" PopupButtonID="imgPopup20">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <%--YARN--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl21" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg21" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl21" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl22" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg22" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl22" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="18px">
                                        <asp:Label ID="lbl23" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg23" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl23" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl24" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg24" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl24" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--YARN DYED--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl56" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg56" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl56" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl57" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg57" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl57" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--KNITTING--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl25" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg25" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl25" runat="server" CssClass="textbox"> </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl26" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg26" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl26" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--DYEING--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl27" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg27" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl27" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td> 
                                        <asp:Label ID="lbl28" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg28" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl28" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--AOP--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl58" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg58" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl58" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl59" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg59" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl59" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--ACCESORIES PRODUCTION--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl29" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg29" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl29" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl30" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg30" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl30" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--INVENTORY--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl31" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg31" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl31" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl32" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg32" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl32" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl33" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg33" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl33" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl34" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg34" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl34" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--RMG--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl35" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg35" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl35" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl36" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg36" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl36" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl37" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg37" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl37" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl38" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg38" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td> 
                                        <asp:TextBox ID="lblpl38" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl39" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg39" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl39" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl40" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg40" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl40" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl41" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg41" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl41" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl42" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg42" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl42" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl43" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg43" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl43" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl44" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg44" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl44" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl45" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg45" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl45" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl46" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg46" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl46" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl47" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg47" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl47" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl48" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg48" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl48" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl49" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg49" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl49" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl50" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg50" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl50" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl51" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg51" runat="server" Text="" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl51" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl52" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg52" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl52" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl53" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg53" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl53" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl54" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg54" runat="server" Text="" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl54" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl55" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblg55" runat="server" Text="" CssClass="textbox1" Font-Size="11px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblpl55" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="border: 1px solid #FFFFFF; float: left; width: 100%; padding: 2px 0px 2px 4px;
                            margin-top: 0px; height: 27px; background-color: #ECF1FF;">
                            <asp:Button ID="BtnTnARelod" runat="server" CssClass="btn-primary small" BorderStyle="None"
                                Text="ReLoad" Width="80px" OnClick="BtnTnARelod_Click" Height="90%" ValidationGroup="tnaload" />
                            <asp:Button ID="cnlbtn" runat="server" CssClass="btn-primary small" BorderStyle="None"
                                Width="80px" Text="Cancel" OnClick="cnlbtn_Click" Height="90%" />
                        </div>
                    </div>
                </div>
                          </ContentTemplate>
                         </asp:UpdatePanel>
            </div>

</asp:Content>
