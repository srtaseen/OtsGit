<%@ Page Title="OTS LogIn Page" Language="C#" MasterPageFile="~/LogInSite.master"
    AutoEventWireup="true" CodeFile="LogIn.aspx.cs" EnableEventValidation="false" Inherits="_LogIn" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            float: left;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
      
            <%--    scripts for disable back button--%>
            <script type="text/javascript">
                history.pushState(null, null, 'LogIn.aspx');
                window.addEventListener('popstate', function (event) {
                    history.pushState(null, null, 'LogIn.aspx');
                });
            </script>
            <%--    scripts for disable back button--%>
            <div style="float: left; width: 100%;">
                <h2 style="font-family: Arial, Helvetica, sans-serif; color: #FFFFFF" 
                    align="center">
                   NZ GROUP
                </h2>
              
            </div>
          
            <div class="divUsrRegistration1">
                <p 
                    style="padding: 0px; margin: 0px 0px 0px 0px; font-family: Verdana; font-size: 20px;
                    color: #FFFFFF; font-weight: bold; background-color: #359ace; text-align: center;">
                   Login Form
                </p>
                <form>
                <div class="form-group"  style="margin-left: 15%; width: 70%; margin-top: 40px;"><i class="fa fa-user"></i>
                    <label for="exampleInputEmail1">
                        ID</label>
                    <asp:TextBox ID="Txt1" runat="server" class="form-control input-sm" placeholder="Login User"></asp:TextBox>
                </div>
                <div class="form-group"  style="margin-left: 15%; width: 70%; margin-top: 10px;"><i class="fa fa-key"></i>
                    <label for="exampleInputPassword1">
                        Password</label>
                    <asp:TextBox ID="Txt2" runat="server" class="form-control input-sm" placeholder="Password"
                        TextMode="Password"></asp:TextBox>
                </div>
               
                <div class="checkbox" style="margin-left: 50px; width: 200px;">
                    <label>
                        <input type="checkbox">
                        Remember me
                    </label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div  style="margin-left: 15%; width: 70%; margin-top: 20px;">
                 
                    <asp:Label ID="lb1" runat="server" ForeColor="Red"></asp:Label><br />
                    <asp:Label ID="lb3" runat="server" ForeColor="Red" Visible="False"></asp:Label><br />
                </div>
                 <div   style="margin-left: 15%; width: 70%; margin-top: 10px;">
                  
                    <asp:Button ID="BtnLogin" runat="server" Text="LogIn" Width="100%" class="btn btn-primary" OnClick="BtnLogin_Click" />
                  
                 
                </div>
               <div   style="margin-left: 15%; width: 70%; margin-top: 20px; font-family: Arial, Helvetica, sans-serif; font-size: 12px;">
                <span>Dont have account ?</span> <span style="padding: 2px 2px 2px 6px"><a href="UserRegister.aspx">REGISTER</a></span>
                </div>
                   
                 
                </form>
               
            </div>
             <p style="padding: 0px; margin: 0px; font-family: Verdana; font-size: 11px; " 
                align="center" class="auto-style1">
                    To learn more about NZ Group visit <a href="http://www.nz-bd.com" title="ASP.NET Website">
                        www.nz-bd.com</a>.
                </p>
				
				 <%--<img src="Images/Happy-New-year-2017.jpg" width="300" height="100" style="align-items:center;float:right;margin-right:512px;" />--%>
        </ContentTemplate>
    </asp:UpdatePanel>
      <div>

                        <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                    </div>
</asp:Content>
