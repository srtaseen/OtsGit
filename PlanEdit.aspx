<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PlanEdit.aspx.cs" Inherits="PlanEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
            <link href="Styles/popupwindow.css" rel="stylesheet" type="text/css" />	            

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
                                                             
                           </Columns>
                       </asp:GridView>
                                    
                       <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
                       </div>

                              <div style="float: left; width: 99%; margin-left: 1%; margin-top: 8px; height: 20px;">
                            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn-primary small"
                                BorderStyle="None" Width="50px" ValidationGroup="btnsave" OnClick="Btnsave_Click1" />
                            <asp:Button ID="BtnChkQty" runat="server" Text="Check Qty." CssClass="btn-primary small"
                                BorderStyle="None" Width="100px" OnClick="BtnChkQty_Click" />
                          <%--  <input id="BtnChkQty" type="button" value="Check Qty." class="btn-primary small openModal1"
                                style="border-style: none; width: 50px;" />--%>
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
                   

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script> 
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script> 
                <script src="Scripts/gridviewScroll.min.js"></script>
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
</asp:Content>

