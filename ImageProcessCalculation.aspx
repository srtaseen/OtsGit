<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ImageProcessCalculation.aspx.cs" Inherits="ImageProcessCalculation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <script type='text/javascript'
src='https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js'></script>
<script type="text/javascript">
    $(function () {
        $('input:checkbox').click(function (e) {
            calculateSmv(4); // sum of 4th column            
        });

        function calculateSmv(colidx) {
            total = 0.0;
            $("tr:has(:checkbox:checked) td:nth-child(" + colidx + ")").each(function () {
                total += parseFloat($(this).text());
            });
           
            $('#pln').text(total.toFixed(2));
            }
        });
</script>

<script type="text/javascript">
    $(function () {
        $('input:checkbox').click(function (e) {
            calculateSmv(5); // sum of 4th column            
        });

        function calculateSmv(colidx) {
            total = 0.0;
            $("tr:has(:checkbox:checked) td:nth-child(" + colidx + ")").each(function () {
                total += parseFloat($(this).text());
            });
           
            $('#smv').text(total.toFixed(2));
            }
        });
</script>
<script type="text/javascript">
    $(function () {
        $('input:checkbox').click(function (e) {
            calculateSmv(6); // sum of 4th column            
        });

        function calculateSmv(colidx) {
            total = 0.0;
            $("tr:has(:checkbox:checked) td:nth-child(" + colidx + ")").each(function () {
                total += parseFloat($(this).text());
            });
           
            $('#mo').text(total.toFixed(2));
            }
        });
</script>
<script type="text/javascript">
    $(function () {
        $('input:checkbox').click(function (e) {
            calculateSmv(7); // sum of 4th column            
        });

        function calculateSmv(colidx) {
            total = 0.0;
            $("tr:has(:checkbox:checked) td:nth-child(" + colidx + ")").each(function () {
                total += parseFloat($(this).text());
            });
           
            $('#helper').text(total.toFixed(2));
            }
        });
</script>

     <style type="text/css">
        .hiddencol { display: none; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset class="fldProsess">
        <h1>Select SMV By Image</h1>
     <div>

          <div class="Free">
            <%--<asp:DropDownList ID="GetGType" runat="server" CssClass="btn btn-default btn-sm" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="GetGType_SelectedIndexChanged">
                                        <asp:ListItem>-</asp:ListItem>
                                    </asp:DropDownList>--%>

              <asp:Label ID="lblGType" runat="server"></asp:Label>

              </div>
        <br />
        <br />
        <br />

         <div style="margin-left:80px;">
         <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="300px">
             <AlternatingRowStyle BackColor="White" />
                <Columns>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSel" runat="server" CssClass="chk" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    

                    <asp:TemplateField HeaderText="Image">                   

                        <ItemTemplate>

                            <asp:Image ID="imgPreview" ImageUrl='<%# Eval("StyleImgPath") %>' runat="server"

                                Height="100px" Width="100px" />

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField DataField="StyleName" ItemStyle-CssClass="hiddencol"/>
                    <asp:BoundField DataField="PlnEfficiency" ItemStyle-CssClass="hiddencol"/>
                    <asp:BoundField DataField="Smv" ItemStyle-CssClass="hiddencol"/>
                    <asp:BoundField DataField="Mo" ItemStyle-CssClass="hiddencol"/>
                    <asp:BoundField DataField="Helper" ItemStyle-CssClass="hiddencol"/>
                    <asp:BoundField DataField="StyleImgName" ItemStyle-CssClass="hiddencol"/>

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
        <br />
        <br />

         <div style="margin-left:80px;">

        <label for="smv">Plan Efficiency: </label><p id="pln"></p>
        <label for="smv">SMV: </label><p id="smv"></p>
        <label for="smv">MO: </label><p id="mo"></p>
        <label for="smv">Helper: </label><p id="helper"></p>

              <input style="margin-bottom:10px;" class="btn btn-primary" type="button" value="Done" onclick="SetName();" />


             </div>
    </div>

   
    
<script type="text/javascript">
    function SetName() {
        if (window.opener != null && !window.opener.closed) {
            var txtPlanEff = window.opener.document.getElementById("txtPlanEff")
            txtPlanEff.value = document.getElementById("pln").innerHTML;
            var txtSmv = window.opener.document.getElementById("txtSmv");
            txtSmv.value = document.getElementById("smv").innerHTML;
            var txtMo = window.opener.document.getElementById("txtMo");
            txtMo.value = document.getElementById("mo").innerHTML;
            var txtHelper = window.opener.document.getElementById("txtHelper");
            txtHelper.value = document.getElementById("helper").innerHTML;
            


            //var man = document.getElementById("man").innerHTML;
           // txtMo.value = man;
            //var txtHelper = window.opener.document.getElementById("txtHelper");
            //var machine = document.getElementById("machine").innerHTML;
            //txtHelper.value = man - machine;
            //txtMo.value = man - txtHelper.value;

            var txtTargetHr = window.opener.document.getElementById("txtTargetHr");
            //txtTargetHr.value = txtMo.value;

            //if(txtSmv.value <= 7)
            //{
            //    var txtPlanEff = window.opener.document.getElementById("txtPlanEff");
            //    txtPlanEff.value = 75;
            //}

            //else if (txtSmv.value > 7 <=13) {
            //    var txtPlanEff = window.opener.document.getElementById("txtPlanEff");
            //    txtPlanEff.value = 65;
            //}

            //else if (txtSmv.value > 13) {
            //    var txtPlanEff = window.opener.document.getElementById("txtPlanEff");
            //    txtPlanEff.value = 60;
            //}

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

        </fieldset>
</asp:Content>

