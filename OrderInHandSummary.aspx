<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderInHandSummary.aspx.cs" Inherits="OrderInHandSummary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OTS | OrderInHandSummary</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/TnaGridView.css" rel="stylesheet" type="text/css" />
    <link href="Styles/font-awesome.min.css" rel="stylesheet" />
<script>
        function doPrint()
        {
            var prtContent = document.getElementById('<%= GvorderSum.ClientID %>');
            
            prtContent.border = 0; //set no border here
            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write('<table border="1" cellspacing="0" cellpadding="4" style="font-size:10pt;border-collapse:collapse;border-bottom:1px solid;" align="center"&gt;');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
</script>

</head>
<body>
<script type = "text/javascript">
    function OnClose() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.HideModalDiv();
        }
    }
    window.onunload = OnClose;
</script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    
    <div style="background-color: #3a5795; width: 100%; height: 20px; float: left">
        <span class="spanText" style="padding-top: 8px; color: #FFFFFF; padding-left: 4px">ORDER
            INHAND SUMMARY</span>
    </div>
    <div style="width: 100%; height: 300px; float: left; margin-top: 4px; overflow: auto;">
    <p style="padding: 0px; margin: 0px 0px 0px 4px; float: left" class="spanText">From Date
        <asp:Label ID="lb1" runat="server" Text=""></asp:Label> To Date <asp:Label ID="lb2" runat="server" Text=""></asp:Label> </p>
        <asp:GridView ID="GvorderSum" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            PageSize="18" OnRowDataBound="GvorderSum_RowDataBound" CssClass="gridcss2" BorderColor="White"
            BorderStyle="Solid" BorderWidth="1" Width="99%" ShowFooter="true" PrintPageSize="23" AllowPrintPaging="true">
            <AlternatingRowStyle BackColor="#F2F9FE" ForeColor="#284775" />
            <Columns>
                
                <asp:BoundField DataField="byr_nm" HeaderText="BUYER">
                    <HeaderStyle CssClass="gridheade" />
                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                </asp:BoundField>
                <%--<asp:BoundField DataField="TQTY" HeaderText="TOTAL QUANTITY (PCS)">
                    <HeaderStyle CssClass="gridheade" />
                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                    
                </asp:BoundField>--%>
                <%--<asp:BoundField DataField="TPRC" HeaderText="TOTAL PRICE ($)" DataFormatString="{0:N2}" >
                    <HeaderStyle CssClass="gridheade" />
                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                    
                </asp:BoundField>--%>

                <asp:TemplateField HeaderText="TOTAL QUANTITY (PCS)">
			 <ItemTemplate>
				<div style="text-align: center;">
				<asp:Label ID="lblqty" runat="server" Text='<%# Eval("TQTY") %>' />
				</div>
                 
			 </ItemTemplate>
			 <FooterTemplate>              

				<div style="text-align: center;">
				<asp:Label ID="lblTotalQty" runat="server" />
				</div>
			 </FooterTemplate>
		  </asp:TemplateField>

                <asp:TemplateField HeaderText="TOTAL PRICE ($)">
			 <ItemTemplate>
				<div style="text-align: center;">
				<asp:Label ID="lblprice" runat="server" Text='<%# Eval("TPRC") %>' />
				</div>
                 
			 </ItemTemplate>
			 <FooterTemplate>              

				<div style="text-align: center;">
				<asp:Label ID="lblTotalPrice" runat="server" />
				</div>
			 </FooterTemplate>
		  </asp:TemplateField>
                
		</Columns>
		<FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />

             
               
            <%--</Columns>--%>
        </asp:GridView>
        <br>
        <br></br>
        <p style="padding: 0px; margin: 0px 0px 0px 4px; float: left">
            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="doPrint()" />

           <%-- <asp:Button ID="Button1" runat="server" 
    Text="<%# FontAwesome.Icons.Rocket %>" CssClass="fa" />--%>

        </p>
        </br>

         
       

    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
        <%--ExportToExcel--%>
    <div>
                <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick = "ExportToExcel" CssClass="btn btn-primary" Width="150px" Height="40px" /> 
            </div>
    <%--ExportToExcel--%>
    </form>

    

</body>
</html>
