<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LineBEvent.aspx.cs" Inherits="LineBEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellspacing="4" cellpadding="0">
            <tr>
                <td align="right"></td>
                <td>
                    <h4>Edit Line Booking</h4>
                </td>
            </tr>
            <tr>
                <td align="right">PO No:</td>
                <td><asp:TextBox ID="TextBoxEditName" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">Resource:</td>
                <td><asp:DropDownList ID="DropDownEditResource" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">Start:</td>
                <td><asp:TextBox ID="TextBoxEditStart" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">End:</td>
                <td><asp:TextBox ID="TextBoxEditEnd" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right"></td>
                <td>
                    <asp:Button ID="ButtonOK" runat="server" OnClick="ButtonOK_Click" Text="OK" />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
                </td>
            </tr>
        </table>
        </div>
        <br />
        <div style="float: left; overflow: auto; width: 99.9%;">
            <asp:GridView ID="GvM" runat="server" AutoGenerateColumns="False" CellPadding="2"
                CssClass="gridcss4" OnRowDataBound="GvM_OnRowDataBound" AllowPaging="True" PagerSettings-PageButtonCount="5"
                PagerSettings-Position="Bottom">
                <RowStyle Wrap="False" BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                    BorderWidth="1px" Height="18px" />
                <RowStyle CssClass="RowStyle" />
                <FooterStyle Wrap="False" />
                <HeaderStyle Wrap="False" />
                <HeaderStyle CssClass="gridheade" />
                <PagerSettings PageButtonCount="5" />
                <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <th colspan="71">
                                <span style="padding-left: 10px; float: left">MERCHANDISING EVENTS</span>
                            </th>
                            <tr>
                                <th>
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    SL-No
                                </th>
                                <th class="gridheade2" nowrap="nowrap" width="112px">
                                    OrderNo
                                </th>
                                <th class="gridheade2" nowrap="nowrap" width="70px">
                                    PoNumber
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    Quantity
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    Order Confirm
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    Ex-Factory
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    Re-Ex-Factory
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    Lead
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    Available
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    Account
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    Report
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
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader8"></asp:Label>
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
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader18"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader19"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader20"></asp:Label>
                                </th>
                                <%--Yarn--%>
                                    <th class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblyarnbook"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader21"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader22"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader23"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader24"></asp:Label>
                                </th>
                                <%--Yarn--%>
                                <%--YarnD--%>
                                <th class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="yrnInhouseStrt"></asp:Label>
                                </th>
                                <th class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="yrnInhouseEnd"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader25"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader26"></asp:Label>
                                </th>
                                <%--YarnD--%>
                                <%--Kniting--%>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader27"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblHeader28"></asp:Label>
                                </th>
                                <%--Kniting--%>
                                <%--Dyeing--%>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                <asp:Label runat="server" ID="lblHeader29"></asp:Label>
                            </th>
                            <th colspan="3" class="gridheade2" nowrap="nowrap">
                                <asp:Label runat="server" ID="lblHeader30"></asp:Label>
                            </th>
                                <%--Dyeing--%>
                                <%--AOP--%>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                 
                                    <asp:Label runat="server" ID="lblHeader31"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader32"></asp:Label>
                                    </th>
                                <%--AOP--%>
                                <%--Acc--%>
                                <th  class="gridheade2" nowrap="nowrap">                                                 
                                    <asp:Label runat="server" ID="lblacsbook"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                 
                                    <asp:Label runat="server" ID="lblHeader33"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader34"></asp:Label>
                                        </th>
                                <%--Acc--%>
                                <%--Inv--%>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                 
                                    <asp:Label runat="server" ID="lblHeader35"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader36"></asp:Label>
                                    </th>
                                        <th  colspan="3" class="gridheade2" nowrap="nowrap">                                                 
                                    <asp:Label runat="server" ID="lblHeader37"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader38"></asp:Label>
                                        </th>
                                <%--Inv--%>
                                <%--printing--%>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                 
                                    <asp:Label runat="server" ID="lblHeader39"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader40"></asp:Label>
                                        </th>
                                <%--printing--%>
                                <%--Emb--%>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                 
                                    <asp:Label runat="server" ID="lblHeader41"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader42"></asp:Label>
                                        </th>
                                <%--Emb--%>
                                <%--RMG--%>                                                
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader43"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                 
                                    <asp:Label runat="server" ID="lblHeader44"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader45"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader46"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader47"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader48"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader49"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader50"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader51"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">
                                                   
                                    <asp:Label runat="server" ID="lblHeader52"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader53"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader54"></asp:Label>
                                </th>
                                    <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader55"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader56"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader57"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                   
                                    <asp:Label runat="server" ID="lblHeader58"></asp:Label>
                                </th>
                                <th colspan="3" class="gridheade2" nowrap="nowrap">                                                 
                                    <asp:Label runat="server" ID="lblHeader59"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                                <th>
                                    Pcs
                                </th>
                                <th>
                                    Date
                                </th>
                                <th>
                                    Date
                                </th>
                                <th>
                                    Add Days
                                </th>
                                <th>
                                    Days
                                </th>
                                <th>
                                    Days
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                    <th>
                                    Pending
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Pending
                                </th>
                                <th>
                                    Pending
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
                                </th>
                                <th>
                                    Plan
                                </th>
                                <th>
                                    DD
                                </th>
                                <th>
                                    Actual
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
                            <td width="100px" align="center">
                                <asp:Label ID="lblSRNO" runat="server" CssClass="glbl" Width="20px" Text='<%#Container.DataItemIndex+1 %>'
                                    Font-Bold="True" Font-Size="8pt"></asp:Label>
                            </td>
                            <td width="112px">
                                <asp:Label ID="Label7" runat="server" Text="" Width="103px" CssClass="glbl2" Font-Size="10px"><%# Eval("ord_no")%></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="" CssClass="glbl2" Font-Size="10px"><%# Eval("po_no")%></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("po_quantity")%></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblordconfirm" runat="server" Text='<%# Eval("ord_cnfdate",  "{0:dd/MMM/yyyy}")%>'
                                    CssClass="glbl" Font-Size="10px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblxfactory" runat="server" Text='<%# Eval("po_xfactory",  "{0:dd/MMM/yyyy}")%>'
                                    CssClass="glbl" Font-Size="10px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrexfactory" runat="server" Text='<%# Eval("ReExFactory",  "{0:dd/MMM/yyyy}")%>'
                                    CssClass="glbl" Font-Size="10px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TnaLedTm")%>' CssClass="glbl"
                                    Font-Size="10px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbldays" runat="server" Text="" CssClass="glbl" Font-Size="10px" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="" CssClass="glbl" Font-Size="10px"><%# Eval("Username")%></asp:Label>
                            </td>
                            <td>
                                <asp:HyperLink ID="lnkView" Text="Print" CssClass="glbl" NavigateUrl='<%# Eval("po_id", "~/reportsaspx/ReportTnaOrderFromGrid.aspx?po_id={0}") %>'
                                    Target="iframe_a" runat="server" />
                            </td>
                            <%--##---------------##--%>
                            <td>
                                <asp:Label ID="lbl1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl1",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld1" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <%-- <asp:Label ID="lblStlid" Visible="false" runat="server" Text='<%# Eval("TnaPoNm")%>'></asp:Label>--%>
                                <asp:Label ID="lblr1" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac1",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                <%-- <asp:Button ID="btnActualpln" Enabled="false" Text='<%# Eval("Tnaac1","{0:dd/MMM/yyyy}")%>'
                                    runat="server" CssClass="gbtn" OnClick="btnActualpln_Click" Width="70px" Font-Size="10px" /--%>
                            </td>
                            <td>
                                <asp:Label ID="lbl2" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl2",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld2" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr2" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac2",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl3",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld3" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr3" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac3",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl4",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld4" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr4" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac4",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl5",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld5" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr5" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac5",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl6" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl6",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld6" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr6" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac6",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl7" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl7",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld7" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr7" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac7",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl8" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl8",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld8" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr8" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac8",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl9" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl9",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld9" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr9" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac9",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl10" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl10",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld10" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr10" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac10",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl11" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl11",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld11" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr11" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac11",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl12" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl12",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld12" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr12" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac12",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl13" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl13",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld13" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr13" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac13",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl14" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl14",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld14" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr14" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac14",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl15" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl15",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld15" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr15" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac15",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl16" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl16",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld16" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr16" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac16",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl17" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl17",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld17" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr17" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac17",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl18" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl18",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld18" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr18" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac18",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl19" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl19",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld19" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr19" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac19",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl20" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl20",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld20" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr20" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac20",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <%--Yarn--%>
                            <td>
                                <asp:Label ID="lblryarnbok" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac5",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <%--##---------------##--%>
                            <td>
                                <asp:Label ID="lbl21" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl21",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld21" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr21" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac21",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl22" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl22",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld22" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr22" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac22",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl23" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl23",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld23" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr23" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac23",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl24" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl24",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld24" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr24" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac24",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <%--Yarn--%>
                            <%--YarnD--%>
                            <td>
                                <asp:Label ID="yrnInhouseStrt" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac23",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="yrnInhouseEnd" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac24",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <%--##---------------##--%>
                            <td>
                                <asp:Label ID="lbl25" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl56",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld25" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr25" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac56",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl26" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl57",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld26" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr26" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac57",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <%--YarnD--%>
                            <%--Knitting--%>
                            <td>
                                <asp:Label ID="lbl27" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl25",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld27" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr27" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac25",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl28" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl26",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbld28" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr28" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac26",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <%--Knitting--%>
                            <%--Dyeing--%>
                                <td>
                            <asp:Label ID="lbl29" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl27",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbld29" runat="server" CssClass="glbl" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblr29" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac27",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl30" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl28",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbld30" runat="server" CssClass="glbl" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblr30" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac28",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                        </td>
                            <%--Dyeing--%>
                            <%--AOP--%>
                                <td >                                                
                                <asp:Label ID="lbl31" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl58",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td >
                                         
                                <asp:Label ID="lbld31" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td >
                            <asp:Label ID="lblr31" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac58",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td >
                                <asp:Label ID="lbl32" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl59",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td >
                                         
                                <asp:Label ID="lbld32" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lblr32" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac59",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                            </td>
                            <%--AOP--%>
                            <%--Acc--%>
                            <td >                                                
                                <asp:Label ID="lblracsbok" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac3",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>                                          
                            <td >                                                
                                <asp:Label ID="lbl33" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl29",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td >                                         
                                <asp:Label ID="lbld33" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td >
                            <asp:Label ID="lblr33" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac29",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td>
                                <asp:Label ID="lbl34" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl30",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td >                                         
                                <asp:Label ID="lbld34" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lblr34" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac30",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                            </td>
                            <%--Acc--%>
                            <%--Inv--%>
                            <td>
                                                
                                <asp:Label ID="lbl35" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl31",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td >
                                         
                                <asp:Label ID="lbld35" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td>
                            <asp:Label ID="lblr35" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac31",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td >
                                <asp:Label ID="lbl36" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl32",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td>
                                         
                                <asp:Label ID="lbld36" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lblr36" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac32",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                            </td>
                                <td>
                                <asp:Label ID="lbl37" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl33",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td>
                                         
                                <asp:Label ID="lbld37" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                                <td >
                            <asp:Label ID="lblr37" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac33",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            
                            </td>
                            <td >
                                <asp:Label ID="lbl38" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl34",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td>
                                         
                                <asp:Label ID="lbld38" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                                <td >
                            <asp:Label ID="lblr38" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac34",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            
                            </td>
                            <%--Inv--%>
                            <%--printing--%>
                            <td>
                                                
                                <asp:Label ID="lbl39" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl38",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td >
                                         
                                <asp:Label ID="lbld39" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td >
                            <asp:Label ID="lblr39" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac38",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td >
                                <asp:Label ID="lbl40" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl39",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                            <td >
                                         
                                <asp:Label ID="lbld40" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lblr40" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac39",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                            </td>
                            <%--printing--%>
                            <%--Emb--%>
                                <td >
                                                
                                <asp:Label ID="lbl41" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl40",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td >
                                         
                                <asp:Label ID="lbld41" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td >
                            <asp:Label ID="lblr41" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac40",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td >
                                <asp:Label ID="lbl42" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl41",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td>
                                         
                                <asp:Label ID="lbld42" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lblr42" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac41",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                            </td>
                            <%--Emb--%>
                            <%--RMG--%>
                            <td >
                                                
                                <asp:Label ID="lbl43" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl35",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td >
                                         
                                <asp:Label ID="lbld43" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                                <td >
                            <asp:Label ID="lblr43" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac35",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td >
                                <asp:Label ID="lbl44" runat="server" CssClass="glbl" Font-Size="10px" Text='<%# Eval("Tnapl36",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld44" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lblr44" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac36",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                            </td>
                                <td class="gvrow">
                                <asp:Label ID="lbl45" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl37",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                              
                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld45" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lblr45" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac37",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                             
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lbl46" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl42",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld46" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                            <asp:Label ID="lblr46" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac42",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                            
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lbl47" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl43",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld47" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lblr47" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac43",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lbl48" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl44",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                                               
                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld48" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lblr48" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac44",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td class="gvrow">
                                <asp:Label ID="lbl49" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl45",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld49" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lblr49" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac45",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td class="gvrow">
                                <asp:Label ID="lbl50" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl46",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld50" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lblr50" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac46",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td class="gvrow">
                                <asp:Label ID="lbl51" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl47",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld51" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lblr51" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac47",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lbl52" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl48",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld52" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                    <asp:Label ID="lblr52" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac48",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td class="gvrow">
                                <asp:Label ID="lbl53" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl49",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld53" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                    <asp:Label ID="lblr53" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac49",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lbl54" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl50",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld54" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lblr54" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac50",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td class="gvrow">
                                <asp:Label ID="lbl55" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl51",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld55" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                                <td class="gvrow">
                                <asp:Label ID="lblr55" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac51",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lbl56" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl52",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld56" runat="server" CssClass="click_lbl" Text=""></asp:Label>
                            </td>
                                <td class="gvrow">
                                    <asp:Label ID="lblr56" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac52",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td class="gvrow">
                                <asp:Label ID="lbl57" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl53",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld57" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                                <td class="gvrow">
                                    <asp:Label ID="lblr57" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac53",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                                <td class="gvrow">
                                <asp:Label ID="lbl58" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl54",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld58" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                    <asp:Label ID="lblr58" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac54",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <td class="gvrow">
                                <asp:Label ID="lbl59" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnapl55",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>

                            </td>
                                <td class="gvrow">
                                         
                                <asp:Label ID="lbld59" runat="server" CssClass="glbl" Text=""></asp:Label>
                            </td>
                            <td class="gvrow">
                                    <asp:Label ID="lblr59" runat="server" Font-Size="10px" CssClass="glbl" Text='<%# Eval("Tnaac55",  "{0:dd/MMM/yyyy}")%>'> </asp:Label>
                            </td>
                            <%--RMG--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <script type="text/javascript">
        document.getElementById("TextBoxEditStart").focus();
    </script>
</body>
</html>
