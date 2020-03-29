<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    </asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="5000">
            </asp:Timer>

             <div class="FldFream1" style="margin-bottom:0px; padding-bottom:0px;">
        <h2 style="text-align:center;">ALL BUYER EVENT SUMMERY</h2>
         <div style="padding: 100px 100px 100px 120px; margin: 0px; border-bottom-style: solid; height:500px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #4ca9ff;" >
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
         <div style="width:1300px;margin-left:-220px; margin-top:2px;">
    <div style="margin-left:75px;">
             <table>
        <tr>
            <td style="width:250px; border:1px solid black; text-align:center; font-weight:bolder;">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Dashboard2.aspx" BackColor="#FFFF95"><i class="fa fa-home"></i>Buyerwise Red Summeay</asp:HyperLink>
    </td>
            <td style="width:300px; border:1px solid black; text-align:center; font-weight:bolder;">
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Dashboard5.aspx" BackColor="#FFFF95"><i class="fa fa-home"></i>Buyerwise Red Summary <= 7 Days</asp:HyperLink>
    </td>
            <td style="width:300px; border:1px solid black; text-align:center; font-weight:bolder;">
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Dashboard6.aspx" BackColor="#FFFF95"><i class="fa fa-home"></i>Buyerwise Red Summary 8-14 Days </asp:HyperLink>
    </td>
            <td style="width:300px; border:1px solid black; text-align:center; font-weight:bolder;">
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Dashboard7.aspx" BackColor="#FFFF95"><i class="fa fa-home"></i>Buyerwise Red Summary > 14 Days</asp:HyperLink>
    </td>
	
	</td>
            <td style="width:300px; border:1px solid black; text-align:center; font-weight:bolder;">
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/DashboardYlw.aspx" BackColor="#FFFF95"><i class="fa fa-home"></i>Yellow Summary</asp:HyperLink>
    </td>
	
    <td style="width:200px; border:1px solid black; height:30px; text-align:center; font-weight:bolder;">
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/page2.aspx" BackColor="#FFFF95"><i class="fa fa-home"></i> Home Page</asp:HyperLink>
    </td>
        </tr>
            </table>
        </div>
        </div>
        </div>

        </ContentTemplate>
       
    </asp:UpdatePanel>
     

   
    
    
   
</asp:Content>

