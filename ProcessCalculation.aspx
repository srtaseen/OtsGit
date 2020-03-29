<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProcessCalculation.aspx.cs" Inherits="ProcessCalculation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type='text/javascript'
src='https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js'></script>
<script type="text/javascript">
    $(function () {
        $('input:checkbox').click(function (e) {
            calculateSmv(3); // sum of 4th column   
            calculateMch(4);
            calculateMan(5);
        });

        function calculateSmv(colidx) {
            total = 0.0;
            $("tr:has(:checkbox:checked) td:nth-child(" + colidx + ")").each(function () {
                total += parseFloat($(this).text());
            });
           
            $('#smv').text(total.toFixed(2));
        }

        function calculateMch(colidx) {
            total2 = 0.0;
            $("tr:has(:checkbox:checked) td:nth-child(" + colidx + ")").each(function () {
                total2 += parseFloat($(this).text());
            });

            $('#machine').text(total2.toFixed(2));
        }
        
        function calculateMan(colidx) {
            total3 = 0.0;
            $("tr:has(:checkbox:checked) td:nth-child(" + colidx + ")").each(function () {
                total3 += parseFloat($(this).text());
            });

            $('#man').text(total3.toFixed(2));
        }


        });
</script>

   <%-- <script type="text/javascript">
    $(function () {
        $('input:checkbox').click(function (e) {
             // sum of 4th column
            
        });

        
        });
</script>

     <script type="text/javascript">
    $(function () {
        $('input:checkbox').click(function (e) {
             // sum of 4th column            
        });

             
        
        });
</script>--%>

     <style type="text/css">
        .hiddencol { display: none; }
    </style>  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset class="fldProsess">
         <h1>Select SMV By Process</h1>
        <div class="Free">
               <%--<asp:DropDownList ID="GetGType" runat="server" CssClass="btn btn-default btn-sm" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="GetGType_SelectedIndexChanged">
            <asp:ListItem>-</asp:ListItem>
            </asp:DropDownList>--%>
            <asp:Label ID="lblGType" runat="server"></asp:Label>
        </div>
            
   <div style="margin-left:80px;">
     <asp:GridView ID="OperationGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="300px">    
         <AlternatingRowStyle BackColor="White" />
       <Columns>  
           <asp:TemplateField>
               <ItemTemplate>
                   <asp:CheckBox ID="chkSel" runat="server" CssClass="chk" />
               </ItemTemplate>
           </asp:TemplateField>
        <%--<asp:BoundField DataField="ProcessID"  HeaderText="Process ID" />--%>
        <asp:BoundField DataField="OperationName"  HeaderText="Operation Name"/>
        <%--<asp:BoundField DataField="MachineName"  HeaderText="Machine Name" />  --%>
        <asp:BoundField DataField="Smv" ItemStyle-CssClass="hiddencol" />
        <asp:BoundField DataField="MachineQty" ItemStyle-CssClass="hiddencol" /> 
        <asp:BoundField DataField="ManQty" ItemStyle-CssClass="hiddencol" />     
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
        </div>
    <br />

   <%-- <table>
        <tr>
            <td>
                <span>SMV</span>
                <asp:TextBox ID="tot" runat="server"></asp:TextBox>
           </td>
            <td>
                <span>Machine Qty</span>
                <asp:TextBox ID="tot2" runat="server"></asp:TextBox>
           </td>
            <td>
                <span>Manpower</span>
                <asp:TextBox ID="tot3" runat="server"></asp:TextBox>
           </td>
        </tr>
    </table>--%>
        <div style="margin-left:80px;">
    <label for="smv">SMV: </label><p id="smv"></p>
    <label for="machine">Machine Qty: </label><p id="machine"></p>
    <label for="man">Man: </label><p id="man"></p> 

      <%-- Testing POPUP Asp Snippets--%>



<input style="margin-bottom:10px;" class="btn btn-primary" type="button" value="Done" onclick="SetName();" />

            

    </div>
<script type="text/javascript">
    function SetName() {
        if (window.opener != null && !window.opener.closed) {
            var txtSmv = window.opener.document.getElementById("txtSmv");
            txtSmv.value = document.getElementById("smv").innerHTML;
            var txtMo = window.opener.document.getElementById("txtMo");
            var man = document.getElementById("man").innerHTML;
           // txtMo.value = man;
            var txtHelper = window.opener.document.getElementById("txtHelper");
            var machine = document.getElementById("machine").innerHTML;
            txtHelper.value = man - machine;
            txtMo.value = man - txtHelper.value;

            var txtTargetHr = window.opener.document.getElementById("txtTargetHr");
            //txtTargetHr.value = txtMo.value;

            if(txtSmv.value <= 7)
            {
                var txtPlanEff = window.opener.document.getElementById("txtPlanEff");
                txtPlanEff.value = 75;
            }

            else if (txtSmv.value > 7 <=13) {
                var txtPlanEff = window.opener.document.getElementById("txtPlanEff");
                txtPlanEff.value = 65;
            }

            else if (txtSmv.value > 13) {
                var txtPlanEff = window.opener.document.getElementById("txtPlanEff");
                txtPlanEff.value = 60;
            }

            var mo = txtMo.value;
            var helper = txtHelper.value;
            var plneff = txtPlanEff.value;
            var smv = txtSmv.value;
            var manpower = parseInt(mo) + parseInt(helper)

            txtTargetHr.value = Math.round(manpower * 60 * plneff/100/smv);
        }
        window.close();
    }
</script>
          <script type="text/javascript">
        $(document).ready(function () {
            $(".chk :checkbox").live("click", function () {
                $(this).closest("tr").css("background-color", this.checked ? "#0000FF" : "");
            });
        });
    </script>

      <%-- Testing POPUP Asp Snippets--%>
        </fieldset>

</asp:Content>


