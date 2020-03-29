using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;



public partial class OrderInHandSummary : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);

    decimal total = 0;
    int totalqty = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Username"] == null)
        //{
        //    Response.Redirect("LogIn.aspx", false);
        //    return;
        //}
        if (!IsPostBack)
        {
            BindGvorderSum();

        }
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

    }
    protected void GvorderSum_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.setAttribute('bgColor', this.style.backgroundColor); this.style.backgroundColor = '#CBFF97';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.getAttribute('bgColor');");
            e.Row.Attributes.Add("style", "cursor:pointer;");

            //Grand Total
            Label lblgt = (Label)e.Row.FindControl("lblprice");
            decimal qty = decimal.Parse(lblgt.Text);
            total = total + qty;

            //Grand Total
            Label lblgtpcs = (Label)e.Row.FindControl("lblqty");
            int qtypcs = int.Parse(lblgtpcs.Text);
            totalqty = totalqty + qtypcs;
        }

        //Grand Total Footer
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPrice");
            lblTotalPrice.Text = total.ToString();

            Label lblTotalQty = (Label)e.Row.FindControl("lblTotalQty");
            lblTotalQty.Text = totalqty.ToString();
        }

    }
    protected void BindGvorderSum()
    {

        conn.Open();
        string strSelectCmd = "Select DISTINCT byr_nm,SUM(Totalprice) as TPRC, SUM(po_quantity) as TQTY FROM View_OrderInhand  where po_xfactory Between '" + Session["dt1"].ToString() + "'  AND '" + Session["dt2"].ToString() + "' AND ord_factory= '" + Session["fact"] + "' AND TnAapproved IS NOT NULL GROUP BY byr_nm ";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        //SqlCommand Syscmd = new SqlCommand("Sp_PriceANDQuantityTotal", conn);
        //Syscmd.CommandType = CommandType.StoredProcedure;

        //SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);

        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
            GvorderSum.DataSource = dt;
            GvorderSum.DataBind();
            int columncount = GvorderSum.Rows[0].Cells.Count;
            GvorderSum.Rows[0].Cells.Clear();
            GvorderSum.Rows[0].Cells.Add(new TableCell());
            GvorderSum.Rows[0].Cells[0].ColumnSpan = columncount;
            GvorderSum.Rows[0].Cells[0].Text = "Note:-Please Select Buyer, Form Date and To Date. Then Click Find";


        }
        else
        {
            GvorderSum.DataSource = dt;
            GvorderSum.DataBind();
            GvorderSum.FooterRow.Cells[0].Text = "Grand Total";
            GvorderSum.Attributes["style"] = "border-collapse:separate";


        }



    }

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
            GvorderSum.AllowPaging = false;
            this.BindGvorderSum();

            GvorderSum.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GvorderSum.HeaderRow.Cells)
            {
                cell.BackColor = GvorderSum.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GvorderSum.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GvorderSum.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GvorderSum.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GvorderSum.RenderControl(hw);

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

