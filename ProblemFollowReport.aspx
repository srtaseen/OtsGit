<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProblemFollowReport.aspx.cs" Inherits="ProblemFollowReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

	<div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
		<div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
<asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                    NavigateUrl="~/Problem_Followup.aspx"><i class="fa fa-home"></i> ENTRY</asp:HyperLink>
<asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="10%"
                    NavigateUrl="~/ProblemFollowReport.aspx"><i class="fa fa-home"></i> REPORT</asp:HyperLink>					
</div>
            <div>
                <h1 class="header">Problem Events</h1>
                <table>
                    <tr>
                        <td>
                            <span>Select Department</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="GetDpt" CssClass="textbox" runat="server" Width="152px" 
                                            Font-Size="11px" >
                                              <asp:ListItem Text="--"></asp:ListItem>
                            </asp:DropDownList>
                                   
                        </td>
                        <td width="10px">
                        </td>
                        <td>
                            <asp:Button ID="btnfinddpt" runat="server" CssClass="Btn" Text="Find" width="80px"
                                            OnClick="btnfinddpt_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   </div>

    <div style="float: left; overflow: auto; width: 99.9%;">
              
                <asp:UpdatePanel ID="up3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GvY" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CssClass="gridcss4" OnRowDataBound="GvY_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5"
                            PagerSettings-Position="Bottom" PageSize="19" OnPageIndexChanging="GvY_PageIndexChanging">
                            <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Height="18px" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    
                                            <th colspan="20" >
                                             <span style="padding-left: 10px; float: left">PROBLEM EVENTS</span>
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                                 <th class="gridheade2" nowrap="nowrap">
                                                SL-No
                                            </th>
                                                 <%--<th  class="gvmid" nowrap="nowrap">
                                                 Buyer
                                                </th>--%>
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                 Department
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap">
                                                 Category
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap">
                                                Description
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap">
                                                Responsible Person
                                                </th>
                                                
                                              
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                
                                                <th style="background-color:#71aaff;">
                                                    Done
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                </th>
                                                  
                                              
                                            </tr>
                                            <tr>
                                            <th></th>
                                                <th></th>
                                                <th>
                                                </th>
                                                
                                                <th >
                                                   
                                                </th>
                                                 <th >
                                                  
                                                </th>
                                                <th >
                                                  
                                                </th>
                                                
                                               
                                                   
                                                <th >
                                                    Plan
                                                </th>
                                                 <th >
                                                    DD
                                                </th>
                                                <th >
                                                    Actual
                                                </th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                 
                                                
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                         <td width="100px" align="center">
                                            <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                                Font-Bold="True" Font-Size="8pt"></asp:Label>
                                        </td>
                                       <%--  <td class="gvrow" bgcolor="#EEEEEE">
                                                <asp:Label ID="Label6" runat="server" Text=""  CssClass="click_lbl" Font-Size="10px"><%# Eval("byr_nm")%></asp:Label>
                                            </td>--%>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("dpt_nm")%></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label1" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("cat_nm")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text=""  CssClass="glbl" Font-Size="10px"><%# Eval("problemdesc")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text=""   CssClass="glbl" Font-Size="10px"><%# Eval("responsible")%></asp:Label>
                                            </td>
                                            
                                           
                                            
                                          
                                             
                                            <%--##---------------##--%>

                                            <td >
                                                
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("plandt",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                              <td >
                                         
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                              <%--<asp:Label ID="lblStlid" Visible="false" runat="server" Text='<%# Eval("pid")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln" Enabled="false" Text='<%# Eval("actdt","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln_Click" Width="70px" Font-Size="10px" />--%>
                                               <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("actdt",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                          
                                            <%--<td >
                                              <asp:Label ID="lblStlid2" Visible="false" runat="server" Text='<%# Eval("pid")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln2" Enabled="false" Text='<%# Eval("reminder1","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln2_Click" Width="70px" Font-Size="10px" />
                                              
                                            </td>
                                            
                                            <td >
                                                <asp:Label ID="lblStlid3" Visible="false" runat="server" Text='<%# Eval("pid")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln3" Enabled="false" Text='<%# Eval("reminder2","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln3_Click" Width="70px" Font-Size="10px" />
                                            </td>
                                            
                                            <td >
                                           <asp:Label ID="lblStlid4" Visible="false" runat="server" Text='<%# Eval("pid")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln4" Enabled="false" Text='<%# Eval("reminder3","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln4_Click" Width="70px" Font-Size="10px" />
                                            </td>--%>

                                            <%--<td >
                                            <asp:Label ID="lblStlid5" Visible="false" runat="server" Text='<%# Eval("pid")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln5" Enabled="false" Text='<%# Eval("done","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln5_Click" Width="70px" Font-Size="10px" />
                                            </td>--%>
                                                <td>
                                                <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("done",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>

                                                
                                               
                                           
                                            
                                        </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField />
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <script src="Scripts/ScrollableGridPlugin_ASP.NetAJAX_3.0.js" type="text/javascript"></script>
                <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
                <script type="text/javascript">
                    var position = 0;
                    $(document).ready(function () {
                        $('#<%=GvY.ClientID %>').Scrollable({
                            //                  ScrollHeight: 300,
                            ScrollWidth: 600,
                            IsInUpdatePanel: true
                        });
                    });
                </script>
            </div>



</asp:Content>

