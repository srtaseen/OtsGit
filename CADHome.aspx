<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CADHome.aspx.cs" Inherits="CADHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="FldFream1">
         <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="15%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
             <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/BookingCAD.aspx"><i class="fa fa-bars"></i> BOOKING CAD</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/ProductionCAD.aspx"><i class="fa fa-bars"></i>PRODUCTION CAD</asp:HyperLink>
                     <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="15%"
                    BackColor="#ECF1FF" NavigateUrl="~/ConfirmCAD.aspx"><i class="fa fa-bars"></i> CONFIRM CAD</asp:HyperLink>
					<asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" width="20%"
                    BackColor="#ECF1FF" NavigateUrl="~/CuttingSpreadingSheet.aspx"><i class="fa fa-bars"></i> CUTTING LAY CHART</asp:HyperLink>
					<asp:HyperLink ID="HyperLink8" runat="server" CssClass="MhyperLnk" width="20%"
                    BackColor="#ECF1FF" NavigateUrl="~/Spreading_Report2.aspx"><i class="fa fa-bars"></i> CUTTING LAY REPORT</asp:HyperLink>
             
                        
               
           
            
        </div>
        <div class="divbody">
            <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                
            </div>
            <div style="width: 100%; height: 482px; float: left; margin-top: 4px; ">
             <div style="width: 100%; height: 445px; float: left;  overflow: auto;">
             
             </div>
                <div style="float: left; margin-top: 4px; margin-left: 4px;  font-family: Arial, Helvetica, sans-serif;font-size: 11px; width: 80%; height: 20px;">
                  
                    
                  
                </div>
            </div>
        </div>
    </div>
</asp:Content>

