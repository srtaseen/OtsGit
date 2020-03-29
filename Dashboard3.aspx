<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dashboard3.aspx.cs" Inherits="Dashboard3" %>

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

                                
                         <h2 style="text-align:center;">Buyerwise Monthly Order Quantity for Year 2016</h2>
                        
                        
                        
                     <div style="padding: 100px 100px 100px 120px; margin: 0px; border-bottom-style: solid; height:500px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #4ca9ff;" >
    <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; float: left; background-color: #3a5795;"
                            id="Div12" runat="server">
       
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:50px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                JANUARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding-top:10px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblJan" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
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
                                                FEBRUARY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                  
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblFeb" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#4ca9ff" Font-Size="15px" ForeColor="White"></asp:Label>
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
                                                MARCH</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                     <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblMar" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#4ca9ff" Font-Size="15px" ForeColor="white"></asp:Label>
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
                                                APRIL</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                  
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblApr" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="#4ca9ff" Font-Size="15px" ForeColor="White"></asp:Label>
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
                                                MAY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                   <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblMay" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
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
                                                JUNE</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblJun" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
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
                                                JULY</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblJul" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
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
                                                AUGUST</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblAug" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
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
                                                SEPTEMBER</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblSep" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
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
                                                OCTOBER</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblOct" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
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
                                                NOVEMBER</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                   <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblNov" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
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
                                                DECEMBER</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblDec" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                    
                                </tr>
                            </table>
                            </div>

                       


                         <div style="float:left;padding:200px;"></div>
                         <div style="padding: 0px; margin-top: 20px; width:250px; height:80px; float: left; background-color: #3a5795;"
                            id="Div13" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:50px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                GRAND TOTAL</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            </span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lbl16" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#4ca9ff" ForeColor="White"
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

