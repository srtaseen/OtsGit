<%@ Page Title="OTS | RMG EVENTS" Language="C#" MasterPageFile="~/Site2.master" AutoEventWireup="true"
    CodeFile="Page29.aspx.cs" Inherits="Page12" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="FldFream2">
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <div class="divnv">
                    <div style="float: left">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95"
                            NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                              <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" 
                            BackColor="#ECF1FF" NavigateUrl="~/Page24.aspx"><i class="fa fa-caret-left"></i> RMG</asp:HyperLink>
           
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="divbody2">
            <asp:UpdatePanel ID="up2" runat="server">
                <ContentTemplate>
                    <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                        <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                            font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                            <tr>
                                <td>
                                    <span class="spanText" style="color: #FFFFFF">SELECT BUYER</span>
                                </td>
                                <td>
                                 <asp:DropDownList ID="ddlbuyerR" CssClass="textbox" runat="server" Width="152px" 
                                            Font-Size="11px" >
                                              <asp:ListItem Text="--"></asp:ListItem>
                                        </asp:DropDownList>
                                   
                                </td>
                                <td width="10px">
                                </td>
                                <td>
                                  <asp:Button ID="btnfindR" runat="server" CssClass="Btn" Text="Find" width="80px"
                                            OnClick="btnfindR_Click" />
                                  
                                </td>
                                <td width="25%"></td>
                                <td>
                               <%-- <asp:TextBox ID="txtSearch" runat="server" Width="100%" CssClass="txtsearch" placeholder="Search" ForeColor="#999999" />--%>

                                     <asp:TextBox ID="txtSearch" runat="server" placeholder="ORDER ID"  CssClass="textbox"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="Btn" Width="90px" Height="20px"/>

                                </td>
                              
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="float: left; overflow: auto; width: 99.9%;">
              
                <asp:UpdatePanel ID="up3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GvR" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CssClass="gridcss4" OnRowDataBound="GvR_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5"
                            PagerSettings-Position="Bottom" PageSize="18" OnPageIndexChanging="GvR_PageIndexChanging">
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
                                    
                                            <th colspan="55" >
                                                READYMADE GARMENT PRODUCTION
                                            </th>
                                            <tr>
                                                <th>
                                                </th>
                                               
                                                 <th  class="gridheade2" nowrap="nowrap" width="90px">
                                                 OrderNo
                                                </th>
                                                <th  class="gridheade2" nowrap="nowrap" width="200px">
                                                PoNumber
                                                </th>
                                              
                                                 <th  class="gridheade2" nowrap="nowrap">
                                                Quantity
                                                </th>
                                                    
                                                  <th  class="gridheade2" nowrap="nowrap">
                                                Ex-Factory
                                                </th>
                                                  
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader2"></asp:Label>
                                                </th>
                                                   <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                 
                                                    <asp:Label runat="server" ID="lblHeader3"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader4"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader5"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader6"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader7"></asp:Label>
                                                </th>
                                                  <th colspan="3" class="gridheade2" nowrap="nowrap" bgcolor="#00FF00">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader8" BackColor="#00FF00"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader9"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader10"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader11"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader12"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader13"></asp:Label>
                                                </th>
                                                 <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader14"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader15"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader16"></asp:Label>
                                                </th>
                                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                                    <asp:Label runat="server" ID="lblHeader17"></asp:Label>
                                                </th>
                                               
                                            </tr>
                                            <tr>
                                                <th>
                                                </th>
                                         
                                                <th class="gvbtm">
                                                   
                                                </th>
                                                 <th class="gvbtm">
                                                  
                                                </th>
                                                <th class="gvbtm">
                                                  
                                                </th>
                                                <th class="gvbtm">
                                                  
                                                </th>
                                                
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                 <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                  <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                  <th class="gvbtm" bgcolor="#00FF00">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm" bgcolor="#00FF00">
                                                 DD
                                                </th>
                                                <th class="gvbtm" bgcolor="#00FF00">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                  <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                  <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                   DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                  DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                                 <th class="gvbtm">
                                                    Plan
                                                </th>
                                                  <th class="gvbtm">
                                                 DD
                                                </th>
                                                <th class="gvbtm">
                                                    Actual
                                                </th>
                                           
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                     
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text="" Width="103px" CssClass="glbl2" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                                            </td>
                                         <td >
                                                <asp:Label ID="Label4" runat="server" Text="" Width="150px"  CssClass="glbl2" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                                            </td>
                                               <td >
                                                <asp:Label ID="Label11" runat="server" Text="" Width="103px"   CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                                            </td>
                                           
                                            <td >
                                                <%--<asp:Label ID="Label5" runat="server" Text=""  CssClass="glbl" Font-Size="10px"><%# Eval("po_xfactory", "{0:dd/MMM/yyyy}")%></asp:Label>--%>
                                            </td>
                                          
                                            <%--##---------------##--%>

                                            <td >
                                                
                                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl35",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                               <td >
                                               <asp:Label ID="lblStlid" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln" Enabled="false" Text='<%# Eval("Tnaac35","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln_Click" Width="70px" Font-Size="10px" />
                                          
                                               
                                            </td>
                                             <td >
                                             <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl36",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                                  <asp:Label ID="lblStlid2" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln2" Enabled="false" Text='<%# Eval("Tnaac36","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln2_Click" Width="70px" Font-Size="10px" />
                                            
                                              
                                            </td>
                                             <td >
                                             <asp:Label ID="lbl3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl37",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld3" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                        <asp:Label ID="lblStlid3" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln3" Enabled="false" Text='<%# Eval("Tnaac37","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln3_Click" Width="70px" Font-Size="10px" />
                                            
                                             
                                            </td>
                                            <td>
                                             <asp:Label ID="lbl4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl42",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld4" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                                 <asp:Label ID="lblStlid4" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln4" Enabled="false" Text='<%# Eval("Tnaac42","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln4_Click" Width="70px" Font-Size="10px" />
                                            
                                            </td>
                                            <td >
                                             <asp:Label ID="lbl5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl43",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld5" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                            <asp:Label ID="lblStlid5" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln5" Enabled="false" Text='<%# Eval("Tnaac43","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln5_Click" Width="70px" Font-Size="10px" />
                                            
                                            </td>
                                            <td>
                                              <asp:Label ID="lbl6" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl44",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld6" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                            <asp:Label ID="lblStlid6" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln6" Enabled="false" Text='<%# Eval("Tnaac44","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln6_Click" Width="70px" Font-Size="10px" />
                                              
                                            </td>
                                             <td>
                                               <asp:Label ID="lbl7" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl45",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld7" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                              <asp:Label ID="lblStlid7" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln7" Enabled="false" Text='<%# Eval("Tnaac45","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln7_Click" Width="70px" Font-Size="10px" />
                                              
                                            </td>
                                              <td bgcolor="#00FF00" >
                                                <asp:Label ID="lbl8" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl46",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td bgcolor="#00FF00">
                                         
                                                <asp:Label ID="lbld8" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td bgcolor="#00FF00">
                                             <asp:Label ID="lblStlid8" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln8" Enabled="false" Text='<%# Eval("Tnaac46","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln8_Click" Width="70px" Font-Size="10px" />
                                              
                                              
                                            </td>
                                             <td >
                                               <asp:Label ID="lbl9" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl47",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld9" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                             <asp:Label ID="lblStlid9" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln9" Enabled="false" Text='<%# Eval("Tnaac47","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln9_Click" Width="70px" Font-Size="10px" />
                                            
                                            </td>
                                            <td >
                                              <asp:Label ID="lbl10" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl48",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld10" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                             <asp:Label ID="lblStlid10" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln10" Enabled="false" Text='<%# Eval("Tnaac48","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln10_Click" Width="70px" Font-Size="10px" />
                                            
                                            </td>
                                             <td>
                                               <asp:Label ID="lbl11" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl49",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld11" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                             <asp:Label ID="lblStlid11" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln11" Enabled="false" Text='<%# Eval("Tnaac49","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln11_Click" Width="70px" Font-Size="10px" />
                                              
                                            </td>
                                            <td>
                                              <asp:Label ID="lbl12" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl50",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld12" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td>
                                             <asp:Label ID="lblStlid12" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln12" Enabled="false" Text='<%# Eval("Tnaac50","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln12_Click" Width="70px" Font-Size="10px" />
                                            
                                            </td>
                                             <td>
                                              <asp:Label ID="lbl13" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl51",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td>
                                         
                                                <asp:Label ID="lbld13" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                             <td >
                                               <asp:Label ID="lblStlid13" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln13" Enabled="false" Text='<%# Eval("Tnaac51","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln13_Click" Width="70px" Font-Size="10px" />
                                            
                                            </td>
                                            <td>
                                              <asp:Label ID="lbl14" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl52",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld14" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                             <td >
                                                  <asp:Label ID="lblStlid14" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln14" Enabled="false" Text='<%# Eval("Tnaac52","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln14_Click" Width="70px" Font-Size="10px" />
                                               
                                            </td>
                                             <td class="gvrow">
                                              <asp:Label ID="lbl15" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl53",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td class="gvrow">
                                         
                                                <asp:Label ID="lbld15" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                             <td class="gvrow">
                                                   <asp:Label ID="lblStlid15" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln15" Enabled="false" Text='<%# Eval("Tnaac53","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln15_Click" Width="70px" Font-Size="10px" />
                                                 </td>
                                             <td >
                                              <asp:Label ID="lbl16" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl54",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld16" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                               <asp:Label ID="lblStlid16" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln16" Enabled="false" Text='<%# Eval("Tnaac54","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln16_Click" Width="70px" Font-Size="10px" />
                                                 
                                            </td>
                                            <td >
                                              <asp:Label ID="lbl17" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl55",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                                            </td>
                                             <td >
                                         
                                                <asp:Label ID="lbld17" runat="server" CssClass="glbl" Text=""></asp:Label>
                                            </td>
                                            <td >
                                             <asp:Label ID="lblStlid17" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>
                                               <asp:Button ID="btnActualpln17" Enabled="false" Text='<%# Eval("Tnaac55","{0:dd/MMM/yyyy}")%>'
                                                runat="server" CssClass="gbtn" OnClick="btnActualpln17_Click" Width="70px" Font-Size="10px" />
                                                 
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
                        $('#<%=GvR.ClientID %>').Scrollable({
                            //                  ScrollHeight: 300,
                            ScrollWidth: 600,
                            IsInUpdatePanel: true
                        });
                    });
                </script>
            </div>
            <asp:UpdatePanel ID="up4" runat="server">
                <ContentTemplate>
                    <div style="padding: 4px; margin-top: 2px; float: left; background-color: #3a5795;" id="dv1" runat="server">
                        <table >
                            <tr>
                                <td colspan="6" height="14px">
                                    <div style="height: 100%; padding-left: 4px;">
                                        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #FFFFFF;">
                                            EVENT SUMMARY</span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height="14px">
                                    <span style="padding: 2px 10px 2px 2px; font-weight: bolder; font-family: Arial, Helvetica, sans-serif;
                                        font-size: 13px;">Total Job</span>
                                </td>
                                <td width="50px">
                                    <asp:Label ID="lblrr" runat="server" CssClass="lbl1" BackColor="#FFFF66" Text="" Font-Bold="true"
                                        Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        Red</span>
                                </td>
                                <td  width="50px">
                                    <asp:Label ID="lblrr2" runat="server" Text="" CssClass="lbl1" Font-Bold="true" BackColor="#FF8A6C" Font-Size="13px"></asp:Label>
                                </td>
                                <td align="right" width="40px">
                                    <span style="padding: 2px 2px 2px 0px; font-weight: bolder; font-size: 13px; font-family: Arial, Helvetica, sans-serif;">
                                        %</span>
                                </td>
                                <td width="30px">
                                    <asp:Label ID="lblrr3" runat="server" CssClass="lbl1" Text="" Font-Bold="true"
                                        Font-Size="13px" BackColor="#FF8A6C"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
   
    <%--    <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
        </Triggers>--%>
</asp:Content>
