using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Default2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack) 
        {
            conn.Open();
            string strSelectCmd = "SELECT TOP 20 * FROM View_OrderInhand  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);



            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvMain.DataSource = ds;
                gvMain.DataBind();
                int columncount = gvMain.Rows[0].Cells.Count;
                gvMain.Rows[0].Cells.Clear();
                gvMain.Rows[0].Cells.Add(new TableCell());
                gvMain.Rows[0].Cells[0].ColumnSpan = columncount;
                gvMain.Rows[0].Cells[0].Text = "Note:-Please Select Buyer, Form Date and To Date. Then Click Find";


            }
            else
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
            }
        }

    }


    protected void gvMain_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.gvMain.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergeCost = new TableCell();
            tcMergeCost.Text = "Product";
            tcMergeCost.ColumnSpan = 2;
            tcMergeCost.BackColor = System.Drawing.ColorTranslator.FromHtml("#666666");

            gvHeaderRowCopy.Cells.AddAt(0, tcMergeCost);

            TableCell tcMergeOther = new TableCell();
            tcMergeOther.Text = "Package";
            tcMergeOther.ColumnSpan = 2;
            tcMergeOther.BackColor = System.Drawing.ColorTranslator.FromHtml("#666666");

            gvHeaderRowCopy.Cells.AddAt(3, tcMergeOther);
        }
    }
}