using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindGridView_p1();

            string query = string.Format("select Fact_nm, SUM(po_quantity) TotalOrders from View_OrderInhand group by Fact_nm");
            DataTable dt = GetData(query);

            //Loop and add each datatable row to the Pie Chart Values
            foreach (DataRow row in dt.Rows)
            {
                PieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                {
                    Category = row["Fact_nm"].ToString(),
                    Data = Convert.ToDecimal(row["TotalOrders"])
                });
            }
            //PieChart1.Visible = ddlCountries.SelectedItem.Value != "";


        }
    }

    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }



    //private void BindGridView_p1()
    //{
    //    conn.Open();
    //    string strSelectCmd = "SELECT DISTINCT byr_nm FROM View_Tna_Plan ";
    //    SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);



    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
    //        GridView_p1.DataSource = ds;
    //        GridView_p1.DataBind();
    //        int columncount = GridView_p1.Rows[0].Cells.Count;
    //        GridView_p1.Rows[0].Cells.Clear();
    //        GridView_p1.Rows[0].Cells.Add(new TableCell());
    //        GridView_p1.Rows[0].Cells[0].ColumnSpan = columncount;
    //        GridView_p1.Rows[0].Cells[0].Text = "";

    //    }
    //    else
    //    {
    //        GridView_p1.DataSource = ds;
    //        GridView_p1.DataBind();


    //    }
    //}
}
