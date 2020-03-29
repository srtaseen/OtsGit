using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class FilterLineBookingCA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindddlbuyerFind();
        }
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    }

    private void BindddlbuyerFind()
    {
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("Select byr_id, byr_nm FROM Buyer_Tab", conn);
            ddlbuyerFind.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            ddlbuyerFind.DataTextField = "byr_nm";
            ddlbuyerFind.DataValueField = "byr_id";
            ddlbuyerFind.DataSource = rdr;
            ddlbuyerFind.DataBind();
            //  ddlbuyerFind.Items.FindByValue(ViewState["Filter"].ToString())
            //.Selected = true;
        }


    }
    protected void GvLineBooking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvLineBooking.PageIndex = e.NewPageIndex;
        BindGvorder();
    }
    protected void GvLineBooking_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void BtnOrdFind_Click(object sender, EventArgs e)
    {
        BindGvorder();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = (DataTable)ViewState["dtOrder"];
        DataView dvOrder = dtOrder.DefaultView;
        dvOrder.RowFilter = "ord_no like '" + txtSearch.Text + "%'";

        GvLineBooking.DataSource = dvOrder;
        GvLineBooking.DataBind();
    }

    protected void BindGvorder()
    {
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand command = new SqlCommand("Sp_FilterLineBookingCA", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Stdt", SqlDbType.Date));
            command.Parameters["@Stdt"].Value = tx1.Text;
            command.Parameters.Add(new SqlParameter("@Enddt", SqlDbType.Date));
            command.Parameters["@Enddt"].Value = tx2.Text;
            command.Parameters.Add(new SqlParameter("@ord_buyer", SqlDbType.NVarChar));
            command.Parameters["@ord_buyer"].Value = ddlbuyerFind.SelectedItem.Text;
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GvLineBooking.DataSource = ds;
                GvLineBooking.DataBind();
                int columncount = GvLineBooking.Rows[0].Cells.Count;
                GvLineBooking.Rows[0].Cells.Clear();
                GvLineBooking.Rows[0].Cells.Add(new TableCell());
                GvLineBooking.Rows[0].Cells[0].ColumnSpan = columncount;
                GvLineBooking.Rows[0].Cells[0].Text = "Note:-Please Select Buyer, Form Date and To Date. Then Click Find";


            }
            else
            {
                //Search Option-RUS
                ViewState["dtOrder"] = ds.Tables[0];
                //Search Option-RUS
                GvLineBooking.DataSource = ds;
                GvLineBooking.DataBind();
                GvLineBooking.Attributes["style"] = "border-collapse:separate";
            }
        }
    }




    protected void PrintAllPages(object sender, EventArgs e)
    {

        GvLineBooking.AllowPaging = false;

        GvLineBooking.DataBind();

        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);

        GvLineBooking.RenderControl(hw);

        string gridHTML = sw.ToString().Replace("\"", "'")

            .Replace(System.Environment.NewLine, "");

        StringBuilder sb = new StringBuilder();

        sb.Append("<script type = 'text/javascript'>");

        sb.Append("window.onload = new function(){");

        sb.Append("var printWin = window.open('', '', 'left=0");

        sb.Append(",top=0,width=1000,height=600,status=0');");

        sb.Append("printWin.document.write(\"");

        sb.Append(gridHTML);

        sb.Append("\");");

        sb.Append("printWin.document.close();");

        sb.Append("printWin.focus();");

        sb.Append("printWin.print();");

        sb.Append("printWin.close();};");

        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

        GvLineBooking.AllowPaging = true;

        GvLineBooking.DataBind();

    }


    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=LinePlan.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GvLineBooking.AllowPaging = false;
            this.BindGvorder();

            GvLineBooking.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GvLineBooking.HeaderRow.Cells)
            {
                cell.BackColor = GvLineBooking.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GvLineBooking.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GvLineBooking.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GvLineBooking.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GvLineBooking.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


}