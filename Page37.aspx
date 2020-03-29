<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Page37.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <div class="FldFream1">
    <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk"  Width="10%" BackColor="#FFFF95" NavigateUrl="~/page2.aspx"><i class="fa fa-home"  style="padding-right: 8px; padding-left: 4px; width: 20px; "></i>HOME</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnkD"  
            Width="15%" BackColor="#FFFF95" Font-Underline="False"><i class="fa fa-home"  style="padding-right: 8px; padding-left: 4px; width: 20px; "></i>PROFILE</asp:HyperLink>
    


        </div>
       <div style=" margin-top: 2px; float: left; background-color: #FFFFFF; height:250px; width: 49.5%;">
       
          <div class="idiv">

          
        <div style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333; padding-left: 8px">
           <h2 style="color: #333333; text-align: left; width:50% ;padding-left: 4px; font-family: 'Shonar Bangla';">Hi...</h2><i class="fa fa-user fa-4x"></i>
              <asp:Label ID="ln" runat="server" Text="" ForeColor="#333333" Visible="False">
              </asp:Label><asp:Label ID="ln2" runat="server" Text="" ForeColor="#333333"></asp:Label><br />
              <asp:Label ID="Label1" runat="server" Text="Your Information" 
                ForeColor="#0066FF" Font-Bold="True" Font-Italic="True" ></asp:Label>
              <br />Deparment :
              <asp:Label ID="ln3" runat="server" Text="" ForeColor="#333333"></asp:Label><br />Email : 
              <asp:Label ID="ln4" runat="server" Text="" ForeColor="#333333"></asp:Label><br />Company :
              <asp:Label ID="ln5" runat="server" Text="" ForeColor="#333333"></asp:Label><br />User Create Date :
              <asp:Label ID="ln6" runat="server" Text="" ForeColor="#333333"></asp:Label><br />Phone:
              <asp:Label ID="ln7" runat="server" Text="" ForeColor="#333333"></asp:Label><br />
              <asp:Label ID="Label2" runat="server" Text="Change Password" ForeColor="Gray"> </asp:Label><i class="fa fa-pencil-square-o"></i>
         </div>
          
          </div>
        </div>
        <div style=" margin-top: 2px; float: left; background-color: #FFFFFF; height:250px; width: 49.5%; margin-left: 1%;">
       
            <div class="idiv">
         
          
          </div>
           
        </div>
       
         <div style=" margin-top: 8px; float: left; background-color: #FFFFFF; height:280px;width: 49.5%;">
        <p style="padding: 2px 2px 2px 15px; margin: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3333FF;">Present Buyer Status</p>
           
        </div>
         <div style=" margin-top: 8px; float: left; background-color: #FFFFFF; height:280px; width: 49.5%; margin-left: 1%;">
        <p style="padding: 2px 2px 2px 4px; margin: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3333FF;">Graph Status by Week</p>
          
        </div>
    </div>
    
        </a></span>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
