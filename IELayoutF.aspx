<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="IELayoutF.aspx.cs" Inherits="IELayoutF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    #leftPanel
    {
        width:700px;
        float:left;
        position:relative;
        margin:10px 20px 20px 20px;

    }
    #rightPanel
    {
        width:550px;
        float:left;
        position:relative;
        margin-left: 10px;
        margin-top:-92px;

    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
            <link href="Styles/popupwindow.css" rel="stylesheet" type="text/css" />


            <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795; width:50%; margin-left:300px">
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="30%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="30%"
                    BackColor="#ECF1FF" NavigateUrl="~/IEPlanningHome.aspx"><i class="fa fa-bars"></i>IE & PLANNING HOME</asp:HyperLink>
				<asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="30%"
                    BackColor="#ECF1FF" NavigateUrl="~/IELayoutEdit.aspx"><i class="fa fa-bars"></i>IE LAYOUT EDIT</asp:HyperLink>	
            
          
        </div>

            <div style="margin-top:10px;margin-left:200px;">
                <fieldset style="float:left;margin-right:100px;" > 
                     <table>
                            <tr>
                             
                                <td height="18px" width="100px">
                                    <span class="sp1">STYLE INFO</span>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        
                          <tr>
                                <td height="18px" width="180px">
                                    <span class="text-primary">Buyer </span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="GetByr" runat="server" CssClass="textbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="GetByr_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                             </tr>
                         
                          <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Style/Order</span>
                                </td>
                                <td>
                                     <asp:DropDownList ID="GetStn" runat="server" CssClass="textbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="GetStn_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                              </tr>
                        
                             <tr>
                                <td height="18px" width="100px">
                                    <span class="text-primary">Article</span>
                                </td>
                                <td>
                                     <asp:DropDownList ID="GetArticle" runat="server" CssClass="textbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="GetArticle_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                              </tr>      
                            
                         <tr>
                              <td height="18px" width="100px">
                                    <span class="text-primary">Garments Type </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="GetGType" runat="server" CssClass="textbox" Width="200px">                                       
                                    </asp:TextBox>
                                </td>
                            </tr>
                         <tr>
                             <td height="18px" width="180px"></td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Button ID="btnPrint" runat="server" CssClass="Btn btn-primary" Text="PRINT LAYOUT" Width="170px"
                                            OnClick="btnPrint_Click"/>
                             </td>
                             <td></td>
                             <td>
                                 <asp:Button ID="btnfindG" runat="server" CssClass="Btn btn-info" Text="SELECT SMV BY PROCESS" Width="200px"
                                            OnClick="btnfindG_Click" />
                             </td>
                         </tr>
                           

                         </table>
                     

                </fieldset>

                 <fieldset> 
                     <table>
                            <tr>
                                <td height="18px" width="100px">
                                    <span class="sp1">LAYOUT INFO</span>
                                </td>
                               
                            </tr>                        

                         <tr>                                
                               <td height="18px" width="100px">
                                    <span class="text-primary">Plan Efficiency</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPlanEff" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                                </td>
                                </tr>
                       

                         <tr>
                                 <td height="18px" width="100px">
                                    <span class="text-primary">SMV</span>
                                </td>
                                <td>
                                    
                                    <asp:TextBox ID="txtSmv" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static" Enabled="false"></asp:TextBox>

                                    
                                     
 

                                </td>
                             </tr>
                        
                         <tr>
                              <td height="18px" width="100px">
                                    <span class="text-primary">MO</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMo" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static" Enabled="false">                                       
                                    </asp:TextBox>

                                  

                                </td>
                            </tr>

                     

                            <tr>
                               <td height="18px" width="100px">
                                    <span class="text-primary">Helper</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHelper" runat="server" CssClass="textbox" Width="200px" AutoPostBack="true" ClientIDMode="Static" Enabled="false"></asp:TextBox>

                       

                                </td>
                                </tr>

                    
                         <tr>
                                 <td height="18px" width="100px">
                                    <span class="text-primary">Target/Hour</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTargetHr" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                                </td>
                             </tr> 

                        
                         </table>
                     </fieldset>


                </div>
      
            <hr style="color:aqua" />


              <div id="GvProcessHeader" style ="background-image:url(nav_03.gif);background-repeat:repeat-x;

height:30px;width:500px; margin:0;padding:0" runat="server">

<table cellspacing="0" cellpadding = "0" rules="all" border="1" id="tblHeader"

 style="font-family:Arial;font-size:10pt;width:700px;color:white; background-color:darkturquoise; 

 border-collapse:collapse;height:100%; margin-left:18px;">

    <tr>

        <td align="center" style ="width:40px; font-weight:bold; ">Chk</td>

       <td align="center" style ="width:205px; font-weight:bold;">Operation Name</td>

       <td align="center" style ="width:100px; font-weight:bold;">Machine Name</td>

       <td align="center" style ="width:100px; font-weight:bold;">SMV</td>

       <td align="center" style ="width:100px; font-weight:bold;">Machine Qty</td>

        <td align="center" style ="width:100px;font-weight:bold;">Man Qty</td>

    </tr>

</table>

</div>


            

            <div id="leftPanel" style ="height:500px; overflow:auto;">

              
            <asp:GridView ID="GvProcess" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" ShowHeader="false"
    AutoGenerateColumns="false" AlternatingRowStyle-BackColor="White">
    <Columns> 
        <asp:TemplateField ItemStyle-Width="50">
            <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server" AutoPostBack="true"  oncheckedchanged="chkRow_CheckedChanged" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Process Id" ItemStyle-Width="150" Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblProcessId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
     
        <asp:TemplateField HeaderText="Operation Name" ItemStyle-Width="300">
            <ItemTemplate>
                <asp:Label ID="lblOperation" runat="server" Text='<%# Eval("OperationName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Machine Name" ItemStyle-Width="150" itemstyle-horizontalalign="center">
            <ItemTemplate>
                <asp:Label ID="lblMachine" runat="server" Text='<%# Eval("MachineName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SMV" ItemStyle-Width="150" itemstyle-horizontalalign="center">
            <ItemTemplate>
                <asp:Label ID="lblSmv" runat="server" Text='<%# Eval("SMV") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Machine Qty" ItemStyle-Width="150" itemstyle-horizontalalign="center">
            <ItemTemplate>
                <asp:Label ID="lblMcQty" runat="server" Text='<%# Eval("MachineQty") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Man Qty" ItemStyle-Width="150" itemstyle-horizontalalign="center">
            <ItemTemplate>
                <asp:Label ID="lblMnQty" runat="server" Text='<%# Eval("ManQty") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

                <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>
 <br />
        
                <asp:HiddenField ID="hidSrlNo" runat="server" />
                </div>
 <div>         <br />
<asp:Button ID="btnGetSelected" runat="server" Text="GET SELECTED RECORDS" OnClick="GetSelectedRecords" CssClass="Btn btn-primary" Width="200px" />
</div>  
                                      
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script> 
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script> 
                <script src="Scripts/gridviewScroll.min.js"></script>
                

            <script type="text/javascript">
                $(document).ready(function () {
                    gridviewScroll();
                });

                function gridviewScroll() {
                    $('#<%=GvProcess.ClientID%>').gridviewScroll({
                        width: "99%",
                        height: 400,
                        //freezesize: 3 
                    });
                }
                </script>




<%--<hr />
<u>Selected Rows</u>
<br />--%>

            <div id="rightPanel">

                <div class="Free">      
            <asp:Label ID="lblGType" runat="server"></asp:Label>
        </div>

<asp:GridView ID="gvSelected" runat="server" 
    AutoGenerateColumns="false" ShowFooter="true" AlternatingRowStyle-BackColor="White" OnRowDataBound="gvSelected_RowDataBound">
    <Columns>
        <asp:BoundField DataField="SrlNo" HeaderText="Srl No." ItemStyle-Width="150" />

        <asp:TemplateField HeaderText="Process Id" Visible="false">
			 <ItemTemplate>
				<div style="text-align: right;">
				<asp:Label ID="lblPId" runat="server" Text='<%# Eval("Id") %>' Visible="false" />
				</div>
			 </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="OperationName" HeaderText="Operation Name" ItemStyle-Width="250" />
        <asp:BoundField DataField="MachineName" HeaderText="Machine Name" ItemStyle-Width="150" itemstyle-horizontalalign="center" />
        <%--<asp:BoundField DataField="SMV" HeaderText="SMV" ItemStyle-Width="150" />--%>

        <asp:TemplateField HeaderText="SMV" ItemStyle-Width="100" itemstyle-horizontalalign="center">
			 <ItemTemplate>
				<div style="text-align: center;">
				<asp:Label ID="lblqty" runat="server" Text='<%# Eval("SMV") %>' />
				</div>
			 </ItemTemplate>
			 <FooterTemplate>
				<div style="text-align: center;">
				<asp:Label ID="lblTotalqty" runat="server" />
				</div>
			 </FooterTemplate>
		  </asp:TemplateField>

        <%--<asp:BoundField DataField="MachineQty" HeaderText="Machine Qty" ItemStyle-Width="150" />--%>

        <asp:TemplateField HeaderText="Machine Qty" ItemStyle-Width="100" itemstyle-horizontalalign="center">
			 <ItemTemplate>
				<div style="text-align: center;">
				<asp:Label ID="lblmcqty" runat="server" Text='<%# Eval("MachineQty") %>' />
				</div>
			 </ItemTemplate>
			 <FooterTemplate>
				<div style="text-align: center;">
				<asp:Label ID="lblTotalmcqty" runat="server" />
				</div>
			 </FooterTemplate>
		  </asp:TemplateField>
        <%--<asp:BoundField DataField="ManQty" HeaderText="Man Qty" ItemStyle-Width="150" />--%>

        <asp:TemplateField HeaderText="Man Qty" ItemStyle-Width="100" itemstyle-horizontalalign="center">
			 <ItemTemplate>
				<div style="text-align: center;">
				<asp:Label ID="lblmnqty" runat="server" Text='<%# Eval("ManQty") %>' />
				</div>
			 </ItemTemplate>
			 <FooterTemplate>
				<div style="text-align: center;">
				<asp:Label ID="lblTotalmnqty" runat="server" />
				</div>
			 </FooterTemplate>
		  </asp:TemplateField>
       
    </Columns>

    <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="darkturquoise" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />

    <FooterStyle BackColor="#cccccc" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />

    

    </asp:GridView>
                <br />

                <asp:Button ID="saveProcess" runat="server" Text="SAVE THE PROCESS" OnClick="saveProcess_Click" CssClass="Btn btn-primary" Width="200px" />

                </div>

           

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

