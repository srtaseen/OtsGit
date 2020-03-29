<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CuttingSpreadingSheet.aspx.cs" Inherits="CuttingSpreadingSheet" %>

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
                  
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="30%"
                            NavigateUrl="~/CADHome.aspx"><i class="fa fa-home"></i>CAD HOME </asp:HyperLink>
                        
                   
                    
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

                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Article</span>
                                </td>
                                <td>
                            <asp:DropDownList ID="ddlarticle" runat="server" CssClass="textbox" Width="95%" AutoPostBack="true" OnSelectedIndexChanged="ddlarticle_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">PO</span>
                                </td>
                                <td>
                            <asp:DropDownList ID="DropDownpo" runat="server" CssClass="textbox" Width="95%" OnSelectedIndexChanged="DropDownpo_SelectedIndexChanged"
                                        AutoPostBack="True">
                                         <asp:ListItem Text="-" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">PO Qty</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtPQty" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Input Qty</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtInputQty" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Consumption</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtCons" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Lay Weight</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtLayWght" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Fabric GSM</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtGsm" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Cutiing No</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtCuttNo" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Fabric Width</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtFebWdth" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Marker Width</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtMerWdth" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Marker Length</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtMerLnth" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Marker Efficiency</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtMerEff" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <%--<tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Consumption</span>
                                </td>
                                <td>
                             <asp:TextBox ID="TextBox11" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>--%>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Cutting Wastage</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtCutWstg" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Size Ratio Total</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtSizeRatio" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            <tr>
                                <td height="18px" width="70px">
                                    <span class="text-primary">Supervisor Name</span>
                                </td>
                                <td>
                             <asp:TextBox ID="txtSupervisor" runat="server" Enabled="False" Width="80%" CssClass="textbox"
                                        Font-Size="11px"></asp:TextBox>
                        </td>
                            </tr>
                            
                           
                        </table>
                    </fieldset>
                    <fieldset class="fld222">
                        <div style="float: left; width: 99%; margin-left: 1%; margin-top: 8px;">
                            <span class="sp1">CUTTING LAY DETAILS</span>
                        </div>
                        <div style="border: 1px solid #006699; float: left; width: 98%; margin-left: 1%;
                            margin-top: 2px; height: 450px; overflow: auto;">
                            <asp:GridView ID="GridViewpo" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                                CellPadding="2" GridLines="None" OnRowDataBound="GridViewpo_RowDataBound" Width="99%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle CssClass="gridheade" />
                                <PagerSettings PageButtonCount="5" />
                                <Columns>
                                    <asp:TemplateField HeaderText="BATCH NO">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtBatch" runat="server" AutoPostBack="True" Width="98%" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SHADE">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtShade" runat="server" Width="98%" AutoPostBack="True" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ROLL">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtRoll" runat="server" Width="98%" AutoPostBack="True" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="KG">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtKg" runat="server" Width="98%" AutoPostBack="True" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="METER">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtMeter" runat="server" Width="98%" AutoPostBack="True" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PLIES">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtPlies" runat="server" Width="98%" AutoPostBack="True" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ACT. CUTTING">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtActCut" runat="server" Width="98%" AutoPostBack="True" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>                                
                                    



                                    <%--For SMV Value--%>

                                    <asp:TemplateField HeaderText="REJECTION ">
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
                                            <div style="float: left; width: 120px">
                                                <asp:TextBox ID="txtRej" runat="server" Width="98%" CssClass="Gridtextbox"></asp:TextBox>
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
            <iframe style="width: 100%; height: 410px;" id="ifrm" src="EditArticle.aspx" runat="server">
            </iframe>
        </div>
        <div class="modal1-footer">
        </div>
    </div>
    <div class="modal1-backdrop">
    </div>
</asp:Content>

