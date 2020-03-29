<%@ Page Language="C#" AutoEventWireup="true" CodeFile="page11.aspx.cs" Inherits="Page4_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OTS | UserSettings</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/TnaGridView.css" rel="stylesheet" type="text/css" />
  
</head>
<body>



    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
    
    <div style="background-color: #3a5795; width: 100%; height: 20px; float: left">
        <span class="spanText" style="padding-top: 8px; color: #FFFFFF; padding-left: 4px">User Edit</span>
       
    </div>
     <div style=" width: 100%; height: 420px; float: left; overflow: auto;" >
         <asp:UpdatePanel ID="up1" runat="server">
    <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="UserId" OnRowDeleting="GridView1_RowDeleting"
OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelEdit" OnRowUpdating="OnRowUpdating" CssClass="gridcss" BorderColor="White" 
             BorderStyle="Solid" BorderWidth="1px">
              <RowStyle Wrap="False"  BorderColor="White" BorderStyle="Solid" BorderWidth="1px" Height="18px" />
               <AlternatingRowStyle BackColor="#F2F9FE" ForeColor="#284775" />
                            <RowStyle CssClass="RowStyle" />
                            <FooterStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            <HeaderStyle CssClass="gridheade" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
<Columns>

    <asp:CheckBoxField DataField="UsrStatus" HeaderText="STATUS" />

    <asp:BoundField DataField="Username" HeaderText="USER ID" ItemStyle-Width="120px" ReadOnly="true" />
    <asp:BoundField DataField="usrnm" HeaderText="NAME" ItemStyle-Width="180px" ReadOnly="true" />
    <asp:BoundField DataField="dpt_nm" HeaderText="DEPARTMENT" ItemStyle-Width="100px" ReadOnly="true" />
  
    <asp:CommandField ShowEditButton="true" HeaderText="EDIT/DEL" ItemStyle-Width="80px" ShowDeleteButton="True" />
</Columns>
</asp:GridView>
</ContentTemplate>
    </asp:UpdatePanel>
     <script src="Scripts/ScrollableGridPlugin_ASP.NetAJAX_3.0.js" type="text/javascript"></script>
                <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
                <script type="text/javascript">
                    var position = 0;
                    $(document).ready(function () {
                        $('#<%=GridView1.ClientID %>').Scrollable({
                            ScrollHeight: 400,
                            //                            ScrollWidth: 600,
                            IsInUpdatePanel: true
                        });
                    });
                </script>
</div>
    
    
    </form>
</body>
</html>
