using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CutToEmb_Report : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(DbSmartCode.x);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindGetFactory();
    }

    private void BindGetFactory()
    {
        using (SqlConnection conn = new SqlConnection(DbSpecFo.x))
        {
            SqlCommand cmd = new SqlCommand("select nCompanyID,cCmpName from Smt_Company", conn);
            drpFactory.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            drpFactory.DataTextField = "cCmpName";
            drpFactory.DataValueField = "nCompanyID";
            drpFactory.DataSource = rdr;
            drpFactory.DataBind();
        }
    }

    protected void btnsrc_Click(object sender, EventArgs e)
    {

        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Sp_CutToEmbTxReport '" + this.txtDate.Text + "','" + this.drpFactory.SelectedValue + "'", cn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "";

            }
            else
            {
                //Search Option-RUS
                ViewState["dtOrder"] = ds.Tables[0];
                //Search Option-RUS

                int sum = 0;
                //decimal tfob = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sum += Convert.ToInt32(dr["sp_SizeQty"]);
                    //tfob += Convert.ToDecimal(dr["sp_TotalValue"]);
                }

                //--- Here 3 is the number of column where you want to show the total.  

                GridView1.Columns[4].FooterText = sum.ToString();
                //GridView1.Columns[6].FooterText = tfob.ToString();
                GridView1.Columns[3].FooterText = "Total Transfer Qty";
                //GridView1.Columns[5].FooterText = "Total Export Value in $";
                GridView1.DataSource = ds;
                GridView1.DataBind();


                //Calculate Sum and display in Footer Row



                //decimal total = GridView1(row => row.Field<decimal>("Price"));
                //GridView1.FooterRow.Cells[1].Text = "Total";
                //GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                //GridView1.FooterRow.Cells[4].Text = sum.ToString("N2");


            }



            ////label.Text = "No Line Found";
            //if (this.GridView1.Rows.Count > 0)
            //{
            //    //label.Text = "";
            //}
        }
        catch (Exception exception)
        {
            string s = exception.Message;
        }


    }

    //Search Option-RUS
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = (DataTable)ViewState["dtOrder"];
        DataView dvOrder = dtOrder.DefaultView;
        dvOrder.RowFilter = "cStyleNo like '" + txtSearch.Text + "%'";

        DataTable dt = dvOrder.ToTable();

        int sum = 0;
        //decimal tfob = 0;
        foreach (DataRow dr in dt.Rows)
        {
            sum += Convert.ToInt32(dr["sp_SizeQty"]);
            //tfob += Convert.ToDecimal(dr["sp_TotalValue"]);
        }

        GridView1.Columns[4].FooterText = sum.ToString();
        //GridView1.Columns[6].FooterText = tfob.ToString();
        GridView1.Columns[3].FooterText = "Total Transfer Qty";
        //GridView1.Columns[5].FooterText = "Total Export Value";
        GridView1.DataSource = dvOrder;
        GridView1.DataBind();
    }

    //Search Option-RUS
}