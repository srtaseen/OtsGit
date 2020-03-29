using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Production_Summary2 : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(DbSmartCode.x);
    SqlConnection conn = new SqlConnection(DbSpecFo.x);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsrcrmg_Click(object sender, EventArgs e)
    {

       BindGvIvn();
    }


    protected void BindGvIvn()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(DbSmartCode.x))
            {

                conn.Open();             

                SqlDataAdapter adapter = new SqlDataAdapter("Sp_reportGroupSummary '" + this.txtDate.Text + "'", cn);                                
                DataTable ds = new DataTable();
                adapter.Fill(ds);



                if (ds.Rows.Count == 0)
                {
                    DataRow dr = ds.NewRow();
                    foreach (DataColumn dc in ds.Columns)
                    {
                        dr[dc] = 0;
                    }
                    ds.Rows.Add(dr);
                    GvIvn.DataSource = ds;
                    GvIvn.DataBind();
                    int columncount = GvIvn.Rows[0].Cells.Count;
                    GvIvn.Rows[0].Cells.Clear();
                    GvIvn.Rows[0].Cells.Add(new TableCell());
                    GvIvn.Rows[0].Cells[0].ColumnSpan = columncount;
                    GvIvn.Rows[0].Cells[0].Text = "No data found.";

                }
                else
                {
                    GvIvn.DataSource = ds;
                    GvIvn.DataBind();


                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    int totalCut = 0;
    int totalInput = 0;
    int totalSewing = 0;
    int totalPoly = 0;
    

    protected void GvIvn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.setAttribute('bgColor', this.style.backgroundColor); this.style.backgroundColor = '#CBFF97';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.getAttribute('bgColor');");
            e.Row.Attributes.Add("style", "cursor:pointer;");

            //Grand Total
            totalCut += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalCut"));
            totalInput += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalInput"));
            totalSewing += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalSewing"));
            totalPoly += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalPoly"));
           
        }

        //Grand Total Footer
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label LabelTotalCut = (Label)e.Row.FindControl("LabelTotalCut");
            LabelTotalCut.Text = totalCut.ToString();

            Label LabelTotalInput = (Label)e.Row.FindControl("LabelTotalInput");
            LabelTotalInput.Text = totalInput.ToString();

            Label LabelTotalSewing = (Label)e.Row.FindControl("LabelTotalSewing");
            LabelTotalSewing.Text = totalSewing.ToString();

            Label LabelTotalPoly = (Label)e.Row.FindControl("LabelTotalPoly");
            LabelTotalPoly.Text = totalPoly.ToString();

          
        }

    }
}