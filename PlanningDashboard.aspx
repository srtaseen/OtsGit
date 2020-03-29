<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PlanningDashboard.aspx.cs" Inherits="PlanningDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script> 
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script> 
<script src="Scripts/gridviewScroll.min.js"></script>
<script type="text/javascript"> 
    $(document).ready(function () { 
        gridviewScroll(); 
    }); 
 
    function gridviewScroll() { 
        $('#<%=Grid1.ClientID%>').gridviewScroll({ 
            width: "99%", 
            height: 600, 
            freezesize: 4 
        }); 
    } 
</script>    
<style type="text/css">

    /*div#divgrid {
    width: 220px;
    height: 100px;
    overflow: auto;
    scrollbar-base-color:#ffeaff;
    }*/

    /* Locks the left column */
    /*td.locked, th.locked {*/
    /*font-size: 14px;
    font-weight: bold;
    text-align: center;
    background-color: navy;
    color: white;*/
    /*border-right: 1px solid silver;
    position:relative;
    cursor: default;*/
    /*IE5+ only*/
    /*left: expression(document.getElementById("Grid1").scrollLeft-2);*/
    /*}*/

    /* Locks table header */
    /*th {*/
    /*font-size: 14px;
    font-weight: bold;
    text-align: center;
    background-color: navy;
    color: white;*/
    /*border-right: 1px solid silver;
    position:relative;
    cursor: default;
    height: 10px;*/ 
    /*IE5+ only*/
    /*top: expression(document.getElementById("Grid1").scrollTop-2);
    z-index: 10;*/
    /*}*/

    /* Keeps the header as the top most item. Important for top left item*/
    /*th.locked {z-index: 99;}*/
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">  
    
     <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="14%"
                    BackColor="#ECF1FF" NavigateUrl="~/LineBooking2.aspx"><i class="fa fa-bars"></i> LINE BOOKING</asp:HyperLink>
                     <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="26%"
                    BackColor="#ECF1FF" NavigateUrl="~/HP5.aspx"><i class="fa fa-bars"></i> HOURLY PRODUCTION ENTRY</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="26%"
                    BackColor="#ECF1FF" NavigateUrl="~/HP4_Report.aspx"><i class="fa fa-bars"></i> HOURLY PRODUCTION REPORT</asp:HyperLink>

             <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" width="24%"
                    BackColor="#ECF1FF" NavigateUrl="~/PlanningDashboard.aspx"><i class="fa fa-bars"></i> PLANNING DASHBOARD</asp:HyperLink>
               
           
          
        </div>
      
 <table style='width: 99%;table-layout:fixed;'>
   <tr>
       <td>
         <table >
             <tr>                
                    <td>
                     PO No. : </td>
                    <td>
                        <asp:TextBox ID="txtProjectID" runat="server"></asp:TextBox>
                    </td>
                    <td>
                      <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/search.png" 
                            Height="32px"  Width="32px" onclick="btnSearch_Click" />
                    </td>
             </tr>
        </table>
    </td>
   </tr>

    <tr>
  `    <td>
           <%--<table style='width: 99%;table-layout:fixed;'>
               <tr>
                   <td >
                   <div align="left" style="width:100%; height:450px; overflow:auto" runat="server" id="divgrid" >
                    </div>
                   </td>
               </tr>
           </table>--%>
      <asp:GridView ID="Grid1" runat="server"></asp:GridView>
       </td>
    </tr>
</table>



</asp:Content>

