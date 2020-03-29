using System.IO;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class TnaExportExcelF : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this.BindGrid();
            BindddlbuyerM();
        }
    }

    private void BindddlbuyerM()
    {
        ddbuyerM.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("select byr_id,byr_nm from Buyer_Tab", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddbuyerM.DataSource = ds;
        ddbuyerM.DataTextField = "byr_nm";
        ddbuyerM.DataValueField = "byr_id";
        ddbuyerM.DataBind();

        conn.Close();
    }

    protected void btnfindM_Click(object sender, EventArgs e)
    {
        BindGrid();
        btnExport.Visible = true;
    }

    private void BindGrid()
    {

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            using (SqlCommand cmd = new SqlCommand("select * from View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1'  AND TnaByrNm ='" + ddbuyerM.SelectedItem.Value + "'"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GridView1.AllowPaging = false;
            this.BindGrid();

            GridView1.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GridView1.RenderControl(hw);

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