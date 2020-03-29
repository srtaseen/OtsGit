<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dashboard6.aspx.cs" Inherits="Dashboard6" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <link href="Styles/ajaxTab.css" rel="stylesheet" type="text/css" />
     <div class="FldFream2">
        <div class="divnv">
            <div style="float: left">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME </asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" BackColor="#ECF1FF"
                    NavigateUrl="~/Dashboard.aspx"><i class="fa fa-caret-left"></i> BACK TO DASHBOARD </asp:HyperLink>
                    
            </div>
        </div>
        <div class="divbody2">
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="Tab">
                <asp:TabPanel ID="TabPanel1" runat="server">
                    <ContentTemplate>
                        <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                            <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                                font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                                <tr>
                                    <td>
                                        <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddbuyerM" runat="server" CssClass="textbox" Width="152px">
                                            <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnfindM" runat="server" CssClass="Btn" Text="Find" Width="80px"
                                            OnClick="btnfindM_Click" />
                                    </td>
                                    <td width="15%">
                                    </td>
                                   
                                </tr>
                            </table>
                        </div>
                             </div>

                                
                        
                        
                        
                        
                     <div style="padding: 100px 100px 100px 120px; margin: 0px; border-bottom-style: solid; height:500px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #4ca9ff;" >
    
                          <h2 style="text-align:center;">Buyerwise Red Summery 8 - 14  Days</h2>
                         
                         <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div12" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:50px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                TOTAL</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding-top:10px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRed" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                   
                                </tr>
                            </table>
                            </div>
                        <div style="float:left;padding:10px;"></div>




                                       <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div1" runat="server">
                            <%--Red Yarn--%>
                  
                             <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                         <div style="height: 100%; padding-top:10px; padding-left:10px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                MERCHANDISING</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                  
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedM" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="red" Font-Size="15px" ForeColor="White"></asp:Label>
                                    </td>
                                   
                                </tr>
                            </table>

                                       <%--Red Yarn--%>

                        </div>


                        <div style="float:left;padding:10px;"></div>

                        <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div2" runat="server">
                            <%--Red Yarn--%>
                  
                             <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:50px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                YARN</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                     <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedY2" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="red" Font-Size="15px" ForeColor="white"></asp:Label>
                                    </td>
                                   
                                </tr>
                            </table>

                                       <%--Red Yarn--%>

                        </div>
                        <div style="float:left;padding:10px;"></div>

                        <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div3" runat="server">
                            <%--Red Yarn--%>
                  
                             <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:20px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                YARN DYEING</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                  
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedYD" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="red" Font-Size="15px" ForeColor="White"></asp:Label>
                                    </td>
                                   
                                </tr>
                            </table>

                                       <%--Red Yarn--%>

                        </div>

                        <div style="float:left;padding:10px;"></div>
                        <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div4" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:30px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                KNITTING</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                   <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedK" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                    
                                </tr>
                            </table>
                            </div>
                        <div style="float:left;padding:10px;"></div>
                        <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div5" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:40px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                DYEING</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedD" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                    
                                </tr>
                            </table>
                            </div>

                        <div style="float:left;padding:10px;"></div>
                         <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div6" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:50px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF;font-weight: bolder;">
                                                AOP</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedA" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                    
                                </tr>
                            </table>
                            </div>

                        <div style="float:left;padding: 10px;"></div>
                         <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div7" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:20px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                ACCESSORIES</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedAC" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                    
                                </tr>
                            </table>
                            </div>
                        <div style="float:left;padding:10px;"></div>
                       <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div8" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:30px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                INVENTORY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedI" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                    
                                </tr>
                            </table>
                            </div>
                        <div style="float:left;padding:10px;"></div>
                         <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div9" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:40px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                PRINTING</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedP" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                   
                                </tr>
                            </table>
                            </div>
                         <div style="float:left;padding:10px;"></div>
                        <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div10" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:20px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight:bolder;">
                                                EMBROIDERY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                   <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedEM" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                    
                                </tr>
                            </table>
                            </div>

                        <div style="float:left;padding:10px;"></div>
                         <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div11" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:50px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                RMG</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedRMG" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                    
                                </tr>
                            </table>
                            </div>
             </div>


                                                 





                    </ContentTemplate>
                </asp:TabPanel>
                 </asp:TabContainer>
        </div>
    </div>
</asp:Content>