<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LineBooking2.aspx.cs" Inherits="LineBooking2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
            <link href="Styles/popupwindow.css" rel="stylesheet" type="text/css" />
			
            <%--Date changer calculation--%>

           <%-- <script type="text/javascript">
                function DateChanged() {
                    var currentdt = $find('txtentdt_CalendarExtender').get_selectedDate();
                    var currentTo = document.getElementById(txtentdt1).value;
           if (currentTo != "" && currentdt != "") {
               t1 = new Date(currentdt)
               t2 = new Date(currentTo)
               if (t1 != NaN && t2 != NaN) {
                   var date = t2.getTime() - t1.getTime();
                   var time = Math.floor(date / (1000 * 60 * 60 * 24));
                   $get('<%=TextBox1.ClientID %>').value = time
            }
        }
    }
    function DateChanged2() {
        var currentdt = $find('txtentdt1_CalendarExtender').get_selectedDate();
        var currentTo = document.getElementById(txtentdt).value;
           if (currentTo != "" && currentdt != "") {
               t1 = new Date(currentdt)
               t2 = new Date(currentTo)
               if (t1 != NaN && t2 != NaN) {
                   var date = t1.getTime() - t2.getTime();
                   var time = Math.floor(date / (1000 * 60 * 60 * 24));
                   $get('<%=TextBox1.ClientID %>').value = time
            }
        }
    }
            </script>--%>

            <%--Date changer calculation--%>

              <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="5%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="5%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page39.aspx"><i class="fa fa-bars"></i>ENTRY</asp:HyperLink>
             <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" width="10%"
                    BackColor="#ECF1FF" NavigateUrl="~/LineBooking2.aspx"><i class="fa fa-bars"></i> LINE BOOKING</asp:HyperLink>
                     <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="20%"
                    BackColor="#ECF1FF" NavigateUrl="~/HP5.aspx"><i class="fa fa-bars"></i> HOURLY PRODUCTION ENTRY</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="18%"
                    BackColor="#ECF1FF" NavigateUrl="~/HP4_Report.aspx"><i class="fa fa-bars"></i> HOURLY PRODUCTION REPORT</asp:HyperLink>

             <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/PlanningDashboard.aspx"><i class="fa fa-bars"></i> PRODUCTION DASHBOARD</asp:HyperLink>

                 <asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/LineBookingTool.aspx"><i class="fa fa-bars"></i> PLANNING DASHBOARD</asp:HyperLink> 
                  
                  <asp:HyperLink ID="HyperLink8" runat="server" CssClass="MhyperLnk" width="12%"
                    BackColor="#ECF1FF" NavigateUrl="~/FilterLineBooking.aspx"><i class="fa fa-bars"></i> LINE PLAN REPORT</asp:HyperLink>          
          
        </div>
            <div class="divbody">
                <fieldset class="fld1"> 
                     <table class="TblStyle">
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="sp1">LINE BOOKING INFO</span>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                          <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Buyer </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetByr" runat="server" CssClass="textbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="GetByr_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                             </tr>
                          <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Style/Order</span>
                                </td>
                                <td>
                                     <asp:DropDownList ID="GetStn" runat="server" CssClass="textbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="GetStn_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                              </tr>


                             <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Article</span>
                                </td>
                                <td>
                                     <asp:DropDownList ID="GetArticle" runat="server" CssClass="textbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="GetArticle_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                              </tr>      
                                <%--<td width="15px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="**"
                                        ControlToValidate="GetStn" ValidationGroup="btnsave" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>--%>
                        
                      <%--   <tr>
                              <td height="18px" width="100px">
                                    <span class="text-primary">PO </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetPo" runat="server" CssClass="textbox" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="GetPo_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                             </tr>--%>
                            <tr>
                              <td height="18px" width="100px">
                                    <span class="text-primary">Garments Type </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="GetGType" runat="server" CssClass="textbox" Width="200px">                                       
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Factory </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="GetFactory" runat="server" CssClass="textbox" Width="200px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Order Quantity </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="textbox" Width="200px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Sewing Start Date </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSd" runat="server" CssClass="textbox" Width="200px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">X-factory Date </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtXd" runat="server" CssClass="textbox" Width="200px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Sewing Lead Date </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSld" runat="server" CssClass="textbox" Width="200px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                         </table>
                </fieldset>

                 <fieldset class="fld1"> 
                     <table class="TblStyle">
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="sp1">LINE BOOKING INFO</span>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                         <tr>
                             <td></td>
                         </tr>
                         <tr>
                             <td></td>
                         </tr>
                         <tr>
                             <td></td>
                         </tr>

                          <tr>

        
        

        <td>
            <input type="button" class="btn-sm btn-primary" value="Select SMV By Process" onclick="SelectName()" />
        </td>
        <td>
            <input type="button" class="btn-sm btn-info" value="Select SMV By Image" onclick="SelectName2()" />
        </td>
    </tr>
                         <tr>
                             <td></td>
                         </tr>
                         <tr>
                             <td></td>
                         </tr>
                         <tr>
                             <td></td>
                         </tr>
                         <tr>
                             <td></td>
                         </tr>

                         <tr>                                
                               <td height="18px" width="100px">
                                    <span class="text-primary">Plan Efficiency</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPlanEff" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                </tr>
                         <tr>
                                 <td height="18px" width="100px">
                                    <span class="text-primary">SMV</span>
                                </td>
                                <td>
                                    <%--<input type="text" id="txtSmv" readonly="readonly" CssClass="textbox" Width="200px" />--%>
                                    <asp:TextBox ID="txtSmv" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static"></asp:TextBox>

                                    
                                       <%-- <input type="text" id="txtSmv" name="Smv" value="" />--%>
 

                                </td>
                             </tr>
                        
                         <tr>
                              <td height="18px" width="100px">
                                    <span class="text-primary">MO</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMo" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static">                                       
                                    </asp:TextBox>

                                    <%-- <input type="text" id="txtMo" name="Mo" value="" />--%>

                                </td>
                            </tr>
                            <tr>
                               <td height="18px" width="100px">
                                    <span class="text-primary">Helper</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHelper" runat="server" CssClass="textbox" Width="200px" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>

                                    <%--<input type="text" id="txtHelper" name="Helper" value=""/>--%>

                                </td>
                                </tr>

                        <%-- <tr>
                             <td>
                                 <asp:Button ID="Button3" runat="server" Text="Get Target" OnClick="Button3_Click" />
                             </td>
                         </tr>--%>
                         <tr>
                                 <td height="18px" width="100px">
                                    <span class="text-primary">Target/Hour</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTargetHr" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static"></asp:TextBox>
                                </td>
                             </tr> 
                         <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Plan Hour </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPlanHr" runat="server" CssClass="textbox" Width="200px" AutoPostBack="true" OnTextChanged="txtPlanHr_TextChanged">
                                    </asp:TextBox>
                                </td>
                            </tr>
                         <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Target/Day</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTargetDy" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                </td>
                            </tr>  
                         </table>

                   

                    <%-- test popup--%>
                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <%--<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
                            <link href="Styles/popupwindow.css" rel="stylesheet" type="text/css" />--%>
                     <%-- Popup window--%>
                            <%--  <script type="text/javascript">
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
                            </script>--%>
                     <%-- Popup window--%>
                       <%-- <asp:HyperLink ID="HyperLink9" runat="server" CssClass="MhyperLnk openModal1" 
                                            BackColor="#35b0e4" ForeColor="White" target="ifrm" Width="90%" >Operation Breakdown  <i class="fa fa-caret-right"></i> </asp:HyperLink>--%>




                           <%-- Testing POPUP Asp Snippets--%>


                            
<%--<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        
        

        <td>
            <input type="button" value="Select SMV" onclick="SelectName()" />
        </td>
        <td>
            <input type="button" value="Select SMV" onclick="SelectName2()" />
        </td>
    </tr>
</table>--%>
<script type="text/javascript">
    var popup;
    function SelectName() {
        popup = window.open("ProcessCalculation.aspx", "Popup", "width=600,height=600");
        popup.focus();
    }
    function SelectName2() {
        popup = window.open("ImageProcessCalculation.aspx", "Popup", "width=600,height=600");
        popup.focus();
    }
</script>

                              <%-- Testing POPUP Asp Snippets--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                <%--    <div class="modal1">
        <div class="modal1-header">
            <h3>
                Operation Breakdown <a class="close-modal1" href="#">&times;</a></h3>
        </div>
        <div class="modal1-body">
            <iframe style="width: 100%; height: 550px;" id="ifrm" name="iframe_a" src="ProcessCalculation.aspx" runat="server">
            </iframe>
        </div>
        <div class="modal1-footer">
        </div>
    </div>--%>
    <%-- <div class="modal1-backdrop">
    </div>--%>
            <%-- test popup--%>
    </fieldset>

               <fieldset class="fld2"> 
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                                <div style="float: left; width: 99%; margin-left: 1%; margin-top: 8px;">
                            <span class="sp1">LINE BOOKING DETAILS</span>
                        </div>
                   <div style="border: 1px solid #006699; float: left; width: 98%; margin-left: 1%;
                            margin-top: 2px; height: 250px; overflow: auto;">
                      

                       <asp:GridView ID="GridviewHp" runat="server" ShowFooter="True" AutoGenerateColumns="false" CellPadding="2" GridLines="None" OnRowDataBound="GridviewHp_RowDataBound" Width="99%" OnRowEditing="GridviewHp_RowEditing" OnRowUpdating="GridviewHp_RowUpdating" OnRowDeleting="GridviewHp_RowDeleting">
                           <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle CssClass="gridheade" />
                                <PagerSettings PageButtonCount="5" />
                           <Columns>
                                <asp:TemplateField HeaderText="Start Date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxentrydt" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div style="float: left; width: 95px;">
                                            <asp:TextBox ID="txtentdt" runat="server" AutoPostBack="True" Width="70%" CssClass="Gridtextbox"
                                                Enabled="False" OnTextChanged="txtentdt_TextChanged"></asp:TextBox>           
                                            <asp:ImageButton ID="imgPopup" ImageUrl="icons/date-picker.png" runat="server" CssClass="datepic2"
                                                ImageAlign="AbsBottom" />
                                            <asp:CalendarExtender ID="txtentdt_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtentdt" PopupButtonID="imgPopup">
                                            </asp:CalendarExtender>                                                
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridheade" />
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="End Date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="enddt" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div style="float: left; width: 95px;">
                                            <asp:TextBox ID="txtentdt1" runat="server" AutoPostBack="True" Width="70%" CssClass="Gridtextbox"
                                                Enabled="False" OnTextChanged="txtentdt1_TextChanged"></asp:TextBox>
                                            <asp:ImageButton ID="imgPopup1" ImageUrl="icons/date-picker.png" runat="server" CssClass="datepic2"
                                                ImageAlign="AbsBottom" />
                                            <asp:CalendarExtender ID="txtentdt1_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtentdt1" PopupButtonID="imgPopup1">
                                            </asp:CalendarExtender>                                                
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridheade" />
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Line No">
                                         <FooterTemplate>
                                            <button type="submit" id="btn" runat="server" onserverclick="FunctionB_ServerClick"
                                                title="Add New" class="btn-primary small" style="border-style: none;">
                                                <i class="fa fa-plus-square"></i>New
                                            </button>
                                       <%--<asp:Button ID="Btnsave" runat="server" Text="Save" CssClass="btn-primary small"
                                BorderStyle="None" Width="50px" ValidationGroup="btnsave" OnClick="Btnsave_Click1" />--%>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="drpLine" runat="server" AutoPostBack="true" onselectedindexchanged="drpLine_SelectedIndexChanged">
                                                <asp:ListItem>-</asp:ListItem>
                                                <asp:ListItem>Line 1</asp:ListItem>  
                                                <asp:ListItem>Line 2</asp:ListItem>  
                                                <asp:ListItem>Line 3</asp:ListItem>  
                                                <asp:ListItem>Line 4</asp:ListItem>  
                                                <asp:ListItem>Line 5</asp:ListItem> 
                                                <asp:ListItem>Line 6</asp:ListItem>
                                                <asp:ListItem>Line 7</asp:ListItem>
                                                <asp:ListItem>Line 8</asp:ListItem>
                                                <asp:ListItem>Line 9</asp:ListItem>
                                                <asp:ListItem>Line 10</asp:ListItem>
                                                <asp:ListItem>Line 11</asp:ListItem>
                                                <asp:ListItem>Line 12</asp:ListItem>
                                                <asp:ListItem>Line 13</asp:ListItem>
                                                <asp:ListItem>Line 14</asp:ListItem>
                                                <asp:ListItem>Line 15</asp:ListItem>
                                                <asp:ListItem>Line 16</asp:ListItem>
                                                <asp:ListItem>Line 17</asp:ListItem>
                                                <asp:ListItem>Line 18</asp:ListItem>
                                                <asp:ListItem>Line 19</asp:ListItem>
                                                <asp:ListItem>Line 20</asp:ListItem>
												<asp:ListItem>Line 21</asp:ListItem>
												<asp:ListItem>Line 22</asp:ListItem>
												<asp:ListItem>Line 23</asp:ListItem>
												<asp:ListItem>Line 24</asp:ListItem>
												<asp:ListItem>Line 25</asp:ListItem>
												<asp:ListItem>LINE 51</asp:ListItem>
												<asp:ListItem>LINE 52</asp:ListItem>
												<asp:ListItem>LINE 53</asp:ListItem>
												<asp:ListItem>LINE 54</asp:ListItem>
												<asp:ListItem>LINE 55</asp:ListItem>
												<asp:ListItem>LINE 56</asp:ListItem>
												<asp:ListItem>LINE 57</asp:ListItem>
												<asp:ListItem>LINE 58</asp:ListItem>
												<asp:ListItem>LINE 59</asp:ListItem>
												<asp:ListItem>LINE 60</asp:ListItem>
												<asp:ListItem>LINE 61</asp:ListItem>
												<asp:ListItem>LINE 62</asp:ListItem>
												<asp:ListItem>LINE 63</asp:ListItem>
												<asp:ListItem>LINE 64</asp:ListItem>
												<asp:ListItem>LINE 65</asp:ListItem>
												<asp:ListItem>LINE 66</asp:ListItem>
												<asp:ListItem>LINE 67</asp:ListItem>
												<asp:ListItem>LINE 68</asp:ListItem>
												<asp:ListItem>LINE 69</asp:ListItem>
												<asp:ListItem>LINE 70</asp:ListItem>
												<asp:ListItem>LINE 71</asp:ListItem>
												<asp:ListItem>LINE 72</asp:ListItem>
												<asp:ListItem>LINE 73</asp:ListItem>
												<asp:ListItem>LINE 74</asp:ListItem>
												<asp:ListItem>LINE 75</asp:ListItem>
												<asp:ListItem>LINE 76</asp:ListItem>
												<asp:ListItem>LINE 77</asp:ListItem>
												<asp:ListItem>LINE 78</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
									
									<asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Images/dltgrd.png" ItemStyle-Width="30px" />
                                    
                                <%--    <asp:TemplateField HeaderText="MO">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtMo" runat="server" AutoPostBack="True" Width="98%" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="HELPER">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtHelper" runat="server" AutoPostBack="True" Width="98%" CssClass="Gridtextbox" OnTextChanged="txtHelper_TextChanged"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                               <asp:TemplateField HeaderText="TARGET/HR">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtTargetHr" runat="server" AutoPostBack="True" Width="98%" CssClass="Gridtextbox"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                               <asp:TemplateField HeaderText="PLAN HOUR">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtPlanHr" runat="server" AutoPostBack="True" Width="98%" CssClass="Gridtextbox" OnTextChanged="txtPlanHr_TextChanged"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />
                                    </asp:TemplateField>
                               <asp:TemplateField HeaderText="TARGET/DY">
                                   <FooterTemplate>
                                            <button type="submit" id="btn" runat="server" onserverclick="FunctionB_ServerClick"
                                                title="Add New" class="btn-primary small" style="border-style: none;">
                                                <i class="fa fa-plus-square"></i>New
                                            </button>
                                       <%--<asp:Button ID="Btnsave" runat="server" Text="Save" CssClass="btn-primary small"
                                BorderStyle="None" Width="50px" ValidationGroup="btnsave" OnClick="Btnsave_Click1" />--%>
                                      <%--  </FooterTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 120px;">
                                                <asp:TextBox ID="txtTargetDy" runat="server" AutoPostBack="True" Width="98%" CssClass="Gridtextbox" OnTextChanged="txtTargetDy_TextChanged"></asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridheade" />--%>
                                 <%--</asp:TemplateField>--%>

                               
                     
                               
                              
                           </Columns>
                       </asp:GridView>
                                    
                       <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
                       </div>

                              <div style="float: left; width: 99%; margin-left: 1%; margin-top: 8px; height: 20px;">
                            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn-primary small"
                                BorderStyle="None" Width="50px" ValidationGroup="btnsave" OnClick="Btnsave_Click1" />
                            <input id="BtnNewWindo" type="button" value="Edit" class="btn-primary small openModal1"
                                style="border-style: none; width: 50px;" />
                            <asp:Button ID="Button2" runat="server" Text="Clear" CssClass="btn-primary small"
                                BorderStyle="None" Width="50px" />

                                   <div style="float:right;">
                                      <asp:Label ID="lblLineinfo" runat="server" Text=""></asp:Label> 
                                        <%--<span class="text-primary">Order Remaining </span>
                                        <asp:TextBox ID="txtOrdRem" runat="server" CssClass="textbox" Width="200px"  AutoPostBack="true">
                                    </asp:TextBox>--%>
                                  </div>

                            <div id="divBackground" style="position: fixed; z-index: 999; height: 100%; width: 100%;
                                top: 0; left: 0; background-color: Black; filter: alpha(opacity=60); opacity: 0.6;
                                -moz-opacity: 0.8; display: none">
                            </div>

                        </div>
                   


                   <script src="Scripts/ScrollableGridPlugin_ASP.NetAJAX_3.0.js" type="text/javascript"></script>
                <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
                <script type="text/javascript">
                    var position = 0;
                    $(document).ready(function () {
                        $('#<%=GridviewHp.ClientID %>').Scrollable({
                            //                  ScrollHeight: 300,
                            ScrollWidth: 600,
                            IsInUpdatePanel: true
                        });
                    });
                </script>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                  

               </fieldset>

              
            </div>
            

        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
        <div>

            


        <fieldset style="width:1300px;">
            <legend style="text-align:center">Line Free Summery</legend>

           
              

			  
			    <div style="border: 1px solid #006699; float: left; width: 15%; margin-left: 1%;margin-bottom:2px;
                            margin-top: 2px; height: 150px; overflow: auto;">

                 <asp:GridView ID="grdAug1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="200px">    
        <AlternatingRowStyle BackColor="White" />
        <Columns>  
            <asp:BoundField DataField="line_no"  HeaderText="-------1st Nov-10th Nov-------">
                <ItemStyle HorizontalAlign="Center" />
				
                </asp:BoundField>
            
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
		 <HeaderStyle CssClass="gridHeaderAlignCenter" />
		 <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
 </asp:GridView>

                 </div>
             <div style="border: 1px solid #006699; float: left; width: 15%; margin-left: 1%;margin-bottom:2px;
                            margin-top: 2px; height: 150px; overflow: auto;">

                  <asp:GridView ID="grdAug11" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="200px">    
        <AlternatingRowStyle BackColor="White" />
        <Columns>  
            <asp:BoundField DataField="line_no"  HeaderText="-------11th Nov-20th Nov-------">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
 </asp:GridView>

                 </div>
            <div style="border: 1px solid #006699; float: left; width: 15%; margin-left: 1%;margin-bottom:2px;
                            margin-top: 2px; height: 150px; overflow: auto;">

                <asp:GridView ID="grdAug21" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="200px">    
        <AlternatingRowStyle BackColor="White" />
        <Columns>  
            <asp:BoundField DataField="line_no"  HeaderText="-------21th Nov-30th Nov-------">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
 </asp:GridView>

                 </div>
             <div style="border: 1px solid #006699; float: left; width: 15%; margin-left: 1%;margin-bottom:2px;
                            margin-top: 2px; height: 150px; overflow: auto;">

                 <asp:GridView ID="grdSep1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="200px">    
        <AlternatingRowStyle BackColor="White" />
        <Columns>  
            <asp:BoundField DataField="line_no"  HeaderText="-------1st Dec-10th Dec-------">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
 </asp:GridView>

                 </div>
            <div style="border: 1px solid #006699; float: left; width: 15%; margin-left: 1%;margin-bottom:2px;
                            margin-top: 2px; height: 150px; overflow: auto;">

                <asp:GridView ID="grdSep11" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="200px">    
        <AlternatingRowStyle BackColor="White" />
        <Columns>  
            <asp:BoundField DataField="line_no"  HeaderText="-------11th Dec-20th Dec-------">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
 </asp:GridView>

                 </div>
             <div style="border: 1px solid #006699; float: left; width: 15%; margin-left: 1%;margin-bottom:2px;
                            margin-top: 2px; height: 150px; overflow: auto;">


                 <asp:GridView ID="grdSep21" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="200px">    
        <AlternatingRowStyle BackColor="White" />
        <Columns>  
            <asp:BoundField DataField="line_no"  HeaderText="-------21st Dec-31st Dec-------">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
 </asp:GridView>

                 </div>
	
				
				 <legend style="text-align:center">Pending Line Booking Details</legend>
			 

            <asp:GridView ID="LinePandingGridview" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1300px">    
         <AlternatingRowStyle BackColor="White"/>
       <Columns>  
        <asp:BoundField DataField="ord_no"  HeaderText="Order No" />
        <asp:BoundField DataField="po_no"  HeaderText="Po No" />
        <asp:BoundField DataField="art_no"  HeaderText="Article No" />  
        <asp:BoundField DataField="Tnapl42"  HeaderText="OTS Sewing Date" />
         
      </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
 </asp:GridView>

            <legend style="text-align:center">Line Booking Details</legend>

            

<div style ="background-image:url(nav_03.gif);background-repeat:repeat-x;

height:30px;width:600px; margin:0;padding:0">

<table cellspacing="0" cellpadding = "0" rules="all" border="1" id="tblHeader"

 style="font-family:Arial;font-size:10pt;width:1300px;color:white;

 border-collapse:collapse;height:100%;">

    <tr>

       <td style ="width:50px;">Line No</td>

       <td style ="width:450px;">Start Date</td>

       <td style ="width:450px;">End Date</td>

       <td style ="width:50px;">Running Days</td>

        <td style ="width:50px;">Remain Days</td>

    </tr>

</table>

</div>


            <div style ="height:200px; width:1300px; overflow:auto;">	
            <asp:GridView ID="LineGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1300px" ShowHeader="false">    
         <AlternatingRowStyle BackColor="White"/>
       <Columns>  
        <asp:BoundField DataField="line_no"  HeaderText="Line No" />
        <asp:BoundField DataField="SchStart"  HeaderText="Start Date" />
        <asp:BoundField DataField="SchEnd"  HeaderText="End Date" />  
        <asp:BoundField DataField="Running"  HeaderText="Running Days" />
        <asp:BoundField DataField="Remain"  HeaderText="Remain Days" />  
      </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
 </asp:GridView>
                 </div>
 
 
 
				 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script> 
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script> 
                <script src="Scripts/gridviewScroll.min.js"></script>
                

            <script type="text/javascript">
                $(document).ready(function () {
                    gridviewScroll();
                });

                function gridviewScroll() {
                    $('#<%=LinePandingGridview.ClientID%>').gridviewScroll({
                        width: "99%",
                        height: 400,
                        //freezesize: 3 
                    });
                }
                </script> 
				
				 
				
				
        </fieldset>
            </div>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


