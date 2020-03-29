<%@ Page Title="OTS | SETUP" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Page9.aspx.cs" Inherits="Page9" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
   
            <div class="FldFream1">
                <div class="divnv">
                    <div style="float: left">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" width="80px" BackColor="#FFFF95"
                            NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" width="80px" CssClass="MhyperLnk" Font-Underline="False"
                            BackColor="#D9E4FF" ForeColor="#0033CC"><i class="fa fa-caret-left"></i> SETUP</asp:HyperLink>
                    </div>
                 
                </div>
                <div class="divbody2">
                 
                    <div style="width: 100%; height: 100%; float: left; ">
                        <div style="border-style: solid none solid solid; border-width: 1px; border-color: #FFFFFF; padding: 0px 0px 4px 0px; width: 19%; height: 100%;
                            float: left; ">
                            <p style="padding: 0px 0px 0px 2px; margin: 0px; background-color: #D9E4FF; ">
                                <i class="fa fa-user"></i><span class="text-primary"> User Settings</span></p>

                            <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" 
                                BackColor="#35B0E4" ForeColor="White" Width="90%" target="iframe_a" 
                                NavigateUrl="~/Page36.aspx">NEW USER  <i class="fa fa-user-plus"></i> </asp:HyperLink><br />
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk " 
                                BackColor="#35B0E4" ForeColor="White" Width="90%" target="iframe_a" NavigateUrl="~/page11.aspx">USER LIST  <i class="fa fa-pencil-square-o"></i> </asp:HyperLink><br />
                            <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk " 
                                BackColor="#35b0e4" ForeColor="White" Width="90%" target="iframe_a" NavigateUrl="~/page13.aspx">USER PROFILE  <i class="fa fa-caret-right"></i> </asp:HyperLink><br />
                            <asp:HyperLink ID="HyperLink9" runat="server" CssClass="MhyperLnk openModal1" 
                                BackColor="#35b0e4" ForeColor="White" target="ifrm" Width="90%" >PERMISSION LEVEL  <i class="fa fa-caret-right"></i> </asp:HyperLink>
                             
                         
                        </div>
                        <div style="padding: 0px 0px 4px 0px; border: 1px solid #FFFFFF; width: 18%; height: 100%;
                            float: left; ">
                            <p style="padding: 0px 0px 0px 2px; margin: 0px; background-color: #D9E4FF; ">
                                <i class="fa fa-database"></i><span class="text-primary"> Data Library</span></p>
                            <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" Font-Underline="False"
                                BackColor="#35B0E4" ForeColor="White" Width="90%"> COMAPNY  <i class="fa fa-building-o"></i> </asp:HyperLink><br />
                            <asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" Font-Underline="False"
                                BackColor="#35b0e4" ForeColor="White" Width="90%"> DEPARTMENT  <i class="fa fa-pencil-square-o"></i> </asp:HyperLink><br />
                            <asp:HyperLink ID="HyperLink8" runat="server" CssClass="MhyperLnk" Font-Underline="False"
                                BackColor="#35b0e4" ForeColor="White" Width="90%"> T&A CATEGORY  <i class="fa fa-caret-right"></i> </asp:HyperLink>
                            <asp:HyperLink ID="HyperLink10" runat="server" CssClass="MhyperLnk" Font-Underline="False"
                                BackColor="#35b0e4" ForeColor="White" Width="90%">T&A EVENTS  <i class="fa fa-caret-right"></i> </asp:HyperLink>
                            <asp:HyperLink ID="HyperLink11" runat="server" CssClass="MhyperLnk" Font-Underline="False"
                                BackColor="#35b0e4" ForeColor="White" Width="90%">T&A TEMPLATE  <i class="fa fa-caret-right"></i> </asp:HyperLink>
                            <asp:HyperLink ID="HyperLink12" runat="server" CssClass="MhyperLnk" Font-Underline="False"
                                BackColor="#35b0e4" ForeColor="White" Width="90%">INACTIVE T&A PLAN  <i class="fa fa-caret-right"></i> </asp:HyperLink>
                            <asp:HyperLink ID="HyperLink13" runat="server" CssClass="MhyperLnk" Font-Underline="False"
                                BackColor="#35b0e4" ForeColor="White" Width="90%">REMOVE ORDER <i class="fa fa-caret-right"></i> </asp:HyperLink>
                        </div>
                        <div style="border-style: solid solid solid none; border-width: 1px; border-color: #FFFFFF; padding: 2px 0px 2px 2px; width: 63%; height: 100%; float: left; margin-right: 0px;">
                         <iframe src="" width="100%" height="100%" name="iframe_a" frameborder="0" scrolling="no"></iframe>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
  
    <div class="modal1">
        <div class="modal1-header">
            <h3>
               User Level Permission <a class="close-modal1" href="#">&times;</a></h3>
        </div>
        <div class="modal1-body">
            <iframe style="width: 100%; height: 550px;" id="ifrm" name="iframe_a" src="page10.aspx" runat="server">
            </iframe>
        </div>
                
        <div class="modal1-footer">
         
        </div>
    </div>
    <div class="modal1-backdrop">
    </div>
</asp:Content>
