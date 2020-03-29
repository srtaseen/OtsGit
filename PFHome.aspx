<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PFHome.aspx.cs" Inherits="PFHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
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
        
        <div class="divbody">
            <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                
            </div>
            <div style="width: 100%; height: 482px; float: left; margin-top: 4px; ">
             <div style="width: 100%; height: 445px; float: left;  overflow: auto;">
                
                 <div style="margin-top:20px;margin-left:100px;">
                    <table>
                        <tr>
                            <td>
                   <asp:HyperLink ID="HyperLink15" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/Problem_Followup.aspx" Width="700px">Problem Followup Entry </asp:HyperLink>
                     </td>
                           
                        </tr>
                        <tr>
                         <td>
                            <asp:HyperLink ID="HyperLink7" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/Problem_Followup_TNA.aspx" Width="700px">Problem Followup TNA </asp:HyperLink>
                    </td>
                            </tr>
                        <tr>
                         <td>
                            <asp:HyperLink ID="HyperLink1" class="btn btn-info" runat="server" Font-Underline="False" BackColor="#3a5795" ForeColor="White" Font-Size="Medium" NavigateUrl="~/Page2.aspx" Width="700px">OTS Home</asp:HyperLink>
                    </td>
                            </tr>
                             </table>
             </div>
                <div style="float: left; margin-top: 4px; margin-left: 4px;  font-family: Arial, Helvetica, sans-serif;font-size: 11px; width: 80%; height: 20px;">
                  
                    
                  
                </div>
            </div>
        </div>
    </div>
  
    <%--New popup Window--%>
    <script type="text/javascript">
        var popUpObj;
        function showModalPopUp() {
            popUpObj = window.open("Page6.aspx",
    "ModalPopUp",
    "toolbar=no," +
    "scrollbars=no," +
    "location=no," +
    "statusbar=no," +
    "menubar=no," +
    "resizable=0," +
    "width=520," +
    "height=400," +
    "left = 460," +
    "top=100"
    );
            popUpObj.focus();
            LoadModalDiv();
        }

    </script>
    <script type="text/javascript">
        function LoadModalDiv() {
            var bcgDiv = document.getElementById("divBackground");
            bcgDiv.style.display = "block";
        }
    </script>
    <script type="text/javascript">
        function HideModalDiv() {
            var bcgDiv = document.getElementById("divBackground");
            bcgDiv.style.display = "none";
        }
        function OnUnload() {
            if (false == popUpObj.closed) {
                popUpObj.close();
            }
        }
        window.onunload = OnUnload;
    </script>
    <%--New popup Window--%>
    <script type="text/javascript">

        function testHoldon(themeName) {
            HoldOn.open({
                theme: themeName,
                message: "<h4>" + themeName + " Demo. Closing in 2 seconds</h4>"
            });

            setTimeout(function () {
                HoldOn.close();
            }, 20);
        }
    </script>
     <%--Window Loading--%>
   <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script src="NECESSARY%20PLUGINS/js/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 20000);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>
    <div class="loading" align="center">
        Loading. Please wait.<br />
        <br />
        <img src="Images\loader.gif" alt="" />
    </div>
       <%--Window Loading--%>
       
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

