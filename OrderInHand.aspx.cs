using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Text;
using System.Configuration;

public partial class OrderInHand : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["dt1"] = tx1.Text;
        Session["dt2"] = tx2.Text;
        Session["fact"] = ddlbuyerFind.SelectedValue;
        if (!IsPostBack)
        {
            BindddlbuyerFind();

        }

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "'and (UsrDpt='6' OR UsrGroup='1') and frmnam1 = 'Page5.aspx'  ", conn);
        command.Connection.Open();
        SqlDataReader rdr = command.ExecuteReader();

        if (rdr.HasRows)
        {

        }
        else
        {
            Response.Redirect("page2.aspx");
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This alert from code behind');", true);

        }

        conn.Close();
    }
    //protected void TimerTick(object sender, EventArgs e)
    //{
    //    this.BindGvorder();
    //    Timer1.Enabled = false;
    //    imgLoader.Visible = false;
    //}
    private void BindddlbuyerFind()
    {
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("select Fact_id, Fact_nm from Factory_Tab", conn);
            ddlbuyerFind.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            ddlbuyerFind.DataTextField = "Fact_nm";
            ddlbuyerFind.DataValueField = "Fact_id";
            ddlbuyerFind.DataSource = rdr;
            ddlbuyerFind.DataBind();
            //  ddlbuyerFind.Items.FindByValue(ViewState["Filter"].ToString())
            //.Selected = true;
        }


    }
    protected void BindGvorder()
    {

        conn.Open();
        //        string strSelectCmd = @"select distinct bt.byr_nm, om.ord_no,ft.Fact_nm,om.ord_cnfdate,pm.po_quantity,pm.po_price,pm.Totalprice,pm.po_xfactory,pm.ExportQty,pm.TnAapproved,pm.ActiveOrder,
        //								om.ord_factory,pm.po_no,om.ord_entdt,gt.gmtyp,tt.PO_Ship_Date,pm.art_no
        //								from Order_Master om --where ord_no='283190'
        //								INNER JOIN  Buyer_Tab bt ON om.ord_buyer = bt.byr_id
        //								inner join Factory_Tab ft on om.ord_factory=ft.Fact_id
        //								inner join PO_Master pm on om.ord_no=pm.ord_no and om.ord_buyer=pm.ord_buyer and om.ord_cnfdate=pm.ord_cnfdate and om.art_no=pm.art_no
        //								inner join Tbl_TnaPlan tt on om.ord_no=tt.TnaOrdNm
        //								inner join GarmentsType gt on om.grment_typ=gt.gmtid  
        //                                where ActiveOrder='1' AND TnAapproved IS NOT NULL AND PO_Ship_Date is NULL AND po_xfactory Between '" + tx1.Text + "' and '" + tx2.Text + "' AND byr_nm = '" + ddlbuyerFind.SelectedItem.Text + "' order by po_xfactory ASC";

        string strSelectCmd = @"select distinct bt.byr_nm, om.ord_no,ft.Fact_nm,om.ord_cnfdate,pm.po_quantity,pm.po_price,pm.Totalprice,tt.ReExFactory,pm.po_xfactory,pm.ExportQty,pm.TnAapproved,pm.ActiveOrder,
om.ord_factory,pm.po_no,om.ord_entdt,gt.gmtyp,tt.PO_Ship_Date,pm.art_no,am.art_smv,(pm.po_quantity*am.art_smv) as TotalSmvQty
from Order_Master om --where ord_no='283190'
INNER JOIN  Buyer_Tab bt ON om.ord_buyer = bt.byr_id
inner join Factory_Tab ft on om.ord_factory=ft.Fact_id
inner join PO_Master pm on om.ord_no=pm.ord_no and om.ord_buyer=pm.ord_buyer and om.ord_cnfdate=pm.ord_cnfdate and om.ord_entdt=pm.ord_entdt
inner join Tbl_TnaPlan tt on om.ord_no=tt.TnaOrdNm and om.ord_buyer=tt.TnaByrNm and pm.ord_buyer=tt.TnaByrNm and pm.ord_no=tt.TnaOrdNm and pm.po_id=tt.TnaPoNm and pm.TnaCreateDate=tt.Tna_Cr_Date 
inner join GarmentsType gt on om.grment_typ=gt.gmtid 
inner join Article_Master am on pm.art_no=am.art_no and pm.ord_no=am.ord_no and tt.art_no=am.art_no and tt.TnaOrdNm=am.ord_no and om.art_no=am.art_no 
where ActiveOrder='1' AND TnAapproved IS NOT NULL AND PO_Ship_Date is NULL 
AND isnull(tt.ReExFactory,po_xfactory) Between '" + tx1.Text + "' and '" + tx2.Text + "' AND Fact_id = '" + ddlbuyerFind.SelectedValue + "' order by po_xfactory ASC";

        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            Gvorder.DataSource = ds;
            Gvorder.DataBind();
            int columncount = Gvorder.Rows[0].Cells.Count;
            Gvorder.Rows[0].Cells.Clear();
            Gvorder.Rows[0].Cells.Add(new TableCell());
            Gvorder.Rows[0].Cells[0].ColumnSpan = columncount;
            Gvorder.Rows[0].Cells[0].Text = "Note:-Please Select Buyer, Form Date and To Date. Then Click Find";


        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrder"] = ds.Tables[0];
            //Search Option-RUS
            Gvorder.DataSource = ds;
            Gvorder.DataBind();
            Gvorder.Attributes["style"] = "border-collapse:separate";
        }



    }
    protected void BtnOrdFind_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tx1.Text.Trim()))
        {
            BindGvorder();


        }
        else
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Date & Buyer!');", true);


        }

    }
    protected void Gvorder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvorder.PageIndex = e.NewPageIndex;
        BindGvorder();
    }
    protected void Gvorder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();


        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.setAttribute('bgColor', this.style.backgroundColor); this.style.backgroundColor = '#CBFF97';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.getAttribute('bgColor');");
            e.Row.Attributes.Add("style", "cursor:pointer;");
        }

    }

    //Search Option-RUS
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = (DataTable)ViewState["dtOrder"];
        DataView dvOrder = dtOrder.DefaultView;
        dvOrder.RowFilter = "ord_no like '" + txtSearch.Text + "%'";

        Gvorder.DataSource = dvOrder;
        Gvorder.DataBind();
    }

    //Search Option-RUS

    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=OrderInHand.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            Gvorder.AllowPaging = false;
            this.BindGvorder();

            Gvorder.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in Gvorder.HeaderRow.Cells)
            {
                cell.BackColor = Gvorder.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in Gvorder.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = Gvorder.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = Gvorder.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            Gvorder.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        /* Verifies that the control is rendered */
    }

}