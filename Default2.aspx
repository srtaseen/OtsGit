<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script> 
   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script src="Scripts/gridviewScroll.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="gvMain" runat="server" Width="100%" 
    AutoGenerateColumns="False" GridLines="None" OnRowCreated="gvMain_RowCreated" BackColor="Red" BorderStyle="Solid" BorderWidth="1" BorderColor="Gray"> 
    <Columns> 
        <asp:BoundField HeaderText="ProductID" DataField="byr_nm" ItemStyle-BackColor="#EEEEEE" /> 
        <asp:BoundField HeaderText="Name" DataField="ord_no" ItemStyle-BackColor="#EEEEEE" /> 
        <asp:BoundField HeaderText="Number" DataField="po_no" ItemStyle-BackColor="#EEEEEE" /> 
        <asp:BoundField HeaderText="ReorderPoint" DataField="po_quantity" /> 
        <asp:BoundField HeaderText="Weight" DataField="po_price" /> 
        <asp:BoundField HeaderText="StandardCost" DataField="po_price" /> 
        <asp:BoundField HeaderText="ListPrice" DataField="po_price" /> 
        <asp:BoundField HeaderText="SafetyStockLevel" DataField="po_price" /> 
        <asp:BoundField HeaderText="SellStartDate" DataField="po_price" /> 
 
    </Columns> 
    <HeaderStyle CssClass="GridviewScrollC1Header" /> 
    <RowStyle CssClass="GridviewScrollC1Item" /> 
    <PagerStyle CssClass="GridviewScrollC1Pager" /> 
</asp:GridView> 
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            $('#<%=gvMain.ClientID%>').gridviewScroll({
                width: 600,
                height: 330,
                freezesize: 2,
                //            arrowsize: 30,
                //            varrowtopimg: "Images/arrowvt.png",
                //            varrowbottomimg: "Images/arrowvb.png",
                //            harrowleftimg: "Images/arrowhl.png",
                //            harrowrightimg: "Images/arrowhr.png",
//                headerrowcount: 2
            });
        } 
</script>


    </div>
    </form>
</body>
</html>
