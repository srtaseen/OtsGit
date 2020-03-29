<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DashboardAcc.aspx.cs" Inherits="DashboardAcc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    </asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="10000">
            </asp:Timer>

             <div class="FldFream1" style="margin-bottom:0px; padding-bottom:0px;">
        <h2 style="text-align:center;">ACCESSORIES EVENT SUMMERY</h2>
         <div style="padding: 100px 100px 100px 120px; margin: 0px; border-bottom-style: solid; height:500px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #4ca9ff;" >
    
             
             
             <div style="padding: 0px; margin-top: 20px; width:150px; height:80px; background-color: #3a5795; margin-left:300px;"
                            id="Div2" runat="server">
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
             
             
             
             
             <div style="padding: 0px; margin-top: 20px; width:350px; height:80px; background-color: #3a5795; margin-left:200px;"
                            id="Div12" runat="server">
                            <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                        <div style="height: 100%; padding-top:10px; padding-left:50px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                ACCESSORIES PRODUCTION PART</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding-top:10px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedAp" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="red" ForeColor="White"
                                            Font-Size="15px"></asp:Label>
                                    </td>
                                   
                                </tr>
                            </table>
                            </div>
                        <div style="float:left;padding:10px;"></div>




                                       <div style="padding: 0px; margin-top: 20px; width:350px; height:80px; background-color: #3a5795; margin-left:200px;"
                            id="Div1" runat="server">
                            <%--Red Yarn--%>
                  
                             <table style="float:left;">
                                <tr>
                                    <td colspan="6" height="14px">
                                         <div style="height: 100%; padding-top:10px; padding-left:50px;">
                                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 15px; color: #FFFFFF; font-weight: bolder;">
                                                ACCESSORIES COMMERCIAL PART</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                  
                                   <td align="right" width="40px" style="padding-left:40px; padding-top:10px;">
                                        <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 15px; font-family: Arial, Helvetica, sans-serif;">
                                            Red</span>
                                    </td>
                                    <td style=" width:50px; padding-top:10px; padding-left:10px;">
                                        <asp:Label ID="lblRedAc" runat="server" Text="" CssClass="lbl1" Font-Bold="true"
                                            BackColor="red" Font-Size="15px" ForeColor="White"></asp:Label>
                                    </td>
                                   
                                </tr>
                            </table>

                                       <%--Red Yarn--%>

                        </div>


                       
             </div>



                 <div style="width:1300px;margin-left:180px; margin-top:2px;">
    <div style="margin-left:75px;">
             <table>
        <tr>
            <td style="width:250px; border:1px solid black; text-align:center; font-weight:bolder;">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Page25.aspx" BackColor="#FFFF95"><i class="fa fa-home"></i>Accessories Home Page</asp:HyperLink>
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

