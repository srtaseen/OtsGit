<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function openWindow1() {
            var URL = "please specify your URL";
            window.open(URL, "RecoverPassword", "width=700,height=450");
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    

<a onclick="openWindow1()" href="#">forgot password </a>

    </form>
</body>
</html>
