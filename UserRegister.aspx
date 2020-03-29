<%@ Page Title="OTS LogIn Page" Language="C#" MasterPageFile="~/LogInSite.master"
    AutoEventWireup="true" CodeFile="UserRegister.aspx.cs" Inherits="_LogIn" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
      
            <%--    scripts for disable back button--%>
            <script type="text/javascript">
                history.pushState(null, null, 'UserRegister.aspx');
                window.addEventListener('popstate', function (event) {
                    history.pushState(null, null, 'UserRegister.aspx');
                });
            </script>
            <%--    scripts for disable back button--%>
            <div style="float: left; width: 100%;">
                <h2 style="font-family: Arial, Helvetica, sans-serif; color: #FFFFFF" align="center">
                    USER REGISTRATION FORM
                </h2>
                
            </div>
            <div class="divUsrRegistration">
                <p style="padding: 0px; margin: 10px 0px 0px 8px; font-family: Verdana; font-size: 24px;
                    color: #FFFFFF; font-weight: bold;">
                    Sign Up
                </p>
                
                <table class="TblUserregistration" >
                    <tr>
                        <td width="28%">
                            <span class="spanText">Name Of Employee</span>
                        </td>
                        <td width="54%">
                       
                               <asp:TextBox ID="unm" runat="server" placeholder="Name" class="form-control input-sm"></asp:TextBox>
                          
                        </td>
                        <td width="18%">
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=""  ControlToValidate="unm" ValidationGroup="btnsave" CssClass="validText"><i class="fa fa-asterisk"></i></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="spanText">Prefared OTS Login ID</span>
                        </td>
                        <td>
                            <asp:TextBox ID="uid" runat="server" class="form-control input-sm" placeholder="Someone"></asp:TextBox>
                        </td>
                        <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=""  ControlToValidate="uid" ValidationGroup="btnsave" CssClass="validText"><i class="fa fa-asterisk"></i></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <span class="spanText"> Password</span>
                        </td>
                        <td>
                            <asp:TextBox ID="pwd" runat="server" class="form-control input-sm" 
                                placeholder="Password" TextMode="Password" ></asp:TextBox>
                                                     
                        </td>
                        <td>

                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=""
                                        ControlToValidate="pwd" CssClass="validText" 
                                ValidationGroup="btnsave"><i class="fa fa-asterisk"></i></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="spanText">Confirm Password</span>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" class="form-control input-sm" 
                                placeholder="" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                          <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Not match"
                                        ControlToCompare="pwd" ControlToValidate="TextBox3" CssClass="validText" ></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="spanText">Mobile No</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtmobile" runat="server" class="form-control input-sm" 
                                MaxLength="14"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="spanText">Email</span>
                        </td>
                        <td>
                            <asp:TextBox ID="eml" runat="server" class="form-control input-sm" placeholder="Someone@nz-bd.com" TextMode="SingleLine"></asp:TextBox>
                        </td>
                        <td>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=""
                                        ControlToValidate="eml" CssClass="validText"  ValidationGroup="btnsave"><i class="fa fa-asterisk"></i></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                        ValidationExpression="^\w+([-+.']\w+)*@nz-bd.com$" ControlToValidate="eml"
                                         CssClass="validText"  ErrorMessage="Invalid"></asp:RegularExpressionValidator>
                                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="spanText">Department</span>
                        </td>
                        <td>
                          <asp:DropDownList ID="dd_crusr_dpt" runat="server" class="form-control input-sm">
                            <asp:ListItem>-</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="spanText">Company</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_crusr_com" runat="server" class="form-control input-sm">
                            <asp:ListItem>-</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="spanText">Select User Group</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_crusr_group" runat="server" class="form-control input-sm">
                            <asp:ListItem>-</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="spanText">Select Account Type</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_buyer" runat="server" class="form-control input-sm">
                            <asp:ListItem>-</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                        <tr>
                        <td height="10px">
                         
                        </td>
                        <td>
                           
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <i class="fa fa-arrow-circle-left "></i> <asp:Button ID="btnbak" runat="server" 
                                Text="Back to LogIn" class="btn-link" OnClick="btnbak_Click" Font-Bold="True" 
                               ForeColor="#CC3300"  />
                        </td>
                        <td colspan="2">
                          <asp:Button ID="btn_crusr_sv" runat="server" Text="Submit" class="btn btn-primary" OnClick="btn_crusr_sv_Click" validationgroup="btnsave"/>
                           <%-- <button type="submit"  class="btn btn-primary" validationgroup="btnsave" runat="server" OnClick="btn_crusr_sv_Click">
                                Submit</button>--%>
                            <asp:Label ID="lbltext" runat="server" Text="" CssClass="ErrorText"></asp:Label>
                            <asp:Label ID="lbltext2" runat="server" Text="" CssClass="ErrorText2"></asp:Label>
                               <asp:Label ID="lbltext3" runat="server" Text="" CssClass="ErrorText"></asp:Label>
                          
                        </td>
                    </tr>
                </table>
              
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
