<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StyleInformationEntry.aspx.cs" Inherits="StyleInformationEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type='text/javascript'
src='https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js'></script>

<script type="text/javascript">
    $(function () {
        $('input:checkbox').click(function (e) {
            calculateSmv(4); // sum of 4th column 
            calculateMch(5); // sum of 5th column
            calculateMan(6); // sum of 4th column  
            addPId(3);
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

        function addPId(colidx) {
            pId = "";
            $("tr:has(:checkbox:checked) td:nth-child(" + colidx + ")").each(function () {
                pId += $(this).text() + ",";
            });

            $('#txtPId').val(pId);
        }

        });
</script>

    <style type="text/css">
        .hiddencol { display: none; }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

     <div class="FldFream1">
         <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="20%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
             <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" Width="20%" BackColor="#ECF1FF"
                    NavigateUrl="~/page38.aspx"><i class="fa fa-home"></i> PLANNING</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="30%"
                    BackColor="#ECF1FF" NavigateUrl="~/GTypeProcessEntry.aspx"><i class ="fa fa-bars"></i>GARMENTS TYPE PROCESS ENTRY</asp:HyperLink>
             <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" width="30%"
                    BackColor="#ECF1FF" NavigateUrl="~/StyleInformationEntry.aspx"><i class="fa fa-bars"></i> STYLE INFORMATION ENTRY</asp:HyperLink>
                                 
           </div>

         <div class="divbody">

    <fieldset class="fldProsess2">
        <h1>Style Information Entry</h1>
<div class="Free">
    <asp:DropDownList ID="GetGType" runat="server" CssClass="btn btn-default btn-sm" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="GetGType_SelectedIndexChanged">
        <asp:ListItem>-</asp:ListItem>
    </asp:DropDownList>
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
        <asp:BoundField DataField="OperationName"  HeaderText="Operation Name" />
        <asp:BoundField DataField="Id" ItemStyle-CssClass="hiddencol" />
        <%--<asp:BoundField DataField="MachineName"  HeaderText="Machine Name" />  --%>
        <asp:BoundField DataField="Smv" ItemStyle-CssClass="hiddencol" />
        <asp:BoundField DataField="MachineQty" ItemStyle-CssClass="hiddencol"  /> 
        <asp:BoundField DataField="ManQty" ItemStyle-CssClass="hiddencol"  />     
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

         <div style="margin-left:80px;">
    <label for="smv">SMV: </label><p id="smv"></p>
    <label for="machine">Machine Qty: </label><p id="machine"></p>
    <label for="man">Man: </label><p id="man"></p> 

<input style="margin-bottom:10px;" class="btn btn-primary"  type="button" value="GET DATA" onclick="SetName();" />
    </div>
<script type="text/javascript">
    function SetName() {
            var txtSmv = document.getElementById("txtSmv");
            txtSmv.value = document.getElementById("smv").innerHTML;
            var txtMo = document.getElementById("txtMo");
            var man = document.getElementById("man").innerHTML;
            var txtHelper = document.getElementById("txtHelper");
            var machine = document.getElementById("machine").innerHTML;
            txtHelper.value = man - machine;
            txtMo.value = man - txtHelper.value;
        
            if(txtSmv.value <= 7)
            {
                var txtPlanEff = document.getElementById("txtPlanEff");
                txtPlanEff.value = 75;
            }
            else if (txtSmv.value > 7 <=13) {
                var txtPlanEff = document.getElementById("txtPlanEff");
                txtPlanEff.value = 65;
            }
            else if (txtSmv.value > 13) {
                var txtPlanEff = document.getElementById("txtPlanEff");
                txtPlanEff.value = 60;
            }
        }
</script>

        <script type="text/javascript">
        $(document).ready(function () {
            $(".chk :checkbox").live("click", function () {
                $(this).closest("tr").css("background-color", this.checked ? "#0000FF" : "");
            });
        });
    </script>

<div>   
    <div style="margin-left:70px;">
    <asp:Table runat="server" >  
         
         <asp:TableRow>  
            <asp:TableCell>Plan Efficiency </asp:TableCell><asp:TableCell><asp:TextBox runat="server" ID="txtPlanEff" CssClass="form-control input-sm" ClientIDMode="Static"></asp:TextBox></asp:TableCell>  
        </asp:TableRow>  
        <asp:TableRow>  
            <asp:TableCell><br /></asp:TableCell><asp:TableCell><br /></asp:TableCell>  
        </asp:TableRow> 
         <asp:TableRow>  
            <asp:TableCell>SMV </asp:TableCell><asp:TableCell><asp:TextBox runat="server" ID="txtSmv" CssClass="form-control input-sm" ClientIDMode="Static"></asp:TextBox></asp:TableCell>  
        </asp:TableRow> 
        <asp:TableRow>  
            <asp:TableCell><br /></asp:TableCell><asp:TableCell><br /></asp:TableCell>  
        </asp:TableRow>  
         <asp:TableRow>  
            <asp:TableCell>MO </asp:TableCell><asp:TableCell><asp:TextBox runat="server" ID="txtMo" CssClass="form-control input-sm" ClientIDMode="Static"></asp:TextBox></asp:TableCell>  
        </asp:TableRow> 
        <asp:TableRow>  
            <asp:TableCell><br /></asp:TableCell><asp:TableCell><br /></asp:TableCell>  
        </asp:TableRow> 
        <asp:TableRow>  
            <asp:TableCell>Helper </asp:TableCell><asp:TableCell><asp:TextBox runat="server" ID="txtHelper" CssClass="form-control input-sm" ClientIDMode="Static"></asp:TextBox></asp:TableCell>  
        </asp:TableRow>
        <asp:TableRow>  
            <asp:TableCell><br /></asp:TableCell><asp:TableCell><br /></asp:TableCell>  
        </asp:TableRow>  
         <asp:TableRow>  
            <asp:TableCell>Style Name </asp:TableCell><asp:TableCell><asp:TextBox runat="server" ID="txtStyle" CssClass="form-control input-sm"></asp:TextBox></asp:TableCell>  
        </asp:TableRow> 
        <asp:TableRow>  
            <asp:TableCell><br /></asp:TableCell><asp:TableCell><br /></asp:TableCell>  
        </asp:TableRow>  
             <asp:TableRow>  
            <asp:TableCell>Style Image Upload </asp:TableCell><asp:TableCell><asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-primary"/></asp:TableCell>  
        </asp:TableRow>
        <asp:TableRow>  
            <asp:TableCell><br /></asp:TableCell><asp:TableCell><br /></asp:TableCell>  
        </asp:TableRow>   
        <asp:TableRow>  
            <asp:TableCell></asp:TableCell><asp:TableCell><asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary"  Text="SAVE" onclick="btnSave_Click"/></asp:TableCell>  
        </asp:TableRow> 
        <asp:TableRow>  
            <asp:TableCell><br /></asp:TableCell><asp:TableCell><br /></asp:TableCell>  
        </asp:TableRow> 
        
    </asp:Table>  

        </div>
    <asp:TextBox runat="server" ID="txtPId" ClientIDMode="Static" CssClass="hiddencol"></asp:TextBox>
</div>  
<asp:Label runat="server" ID="lblmsg"></asp:Label>
    </fieldset>
             </div>
         </div>
</asp:Content>


