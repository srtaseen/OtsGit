using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Page4_ : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Username"] == null)
        //{
        //    Response.Redirect("LogIn.aspx", false);
        //    return;
        //}
        if (!IsPostBack)
        {
            BindGvousr();
           
        }

    }
    protected void BindGvousr()
    {

        string strSelectCmd = " select * FROM Users WHERE UsrApprove IS NULL";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);


        //conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            Gvousr.DataSource = ds;
            Gvousr.DataBind();
            int columncount = Gvousr.Rows[0].Cells.Count;
            Gvousr.Rows[0].Cells.Clear();
            Gvousr.Rows[0].Cells.Add(new TableCell());
            Gvousr.Rows[0].Cells[0].ColumnSpan = columncount;
            Gvousr.Rows[0].Cells[0].Text = "No User has pending for approval";


        }
        else
        {

            Gvousr.DataSource = ds;
            Gvousr.DataBind();
        }


    }
    protected void Gvousr_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Button btnapprove = (Button)e.Row.FindControl("btnapprove");
            Button btncancle = (Button)e.Row.FindControl("btncancle");


            if (string.IsNullOrEmpty(btnapprove.Text.Trim()))
            {
                btnapprove.Text = "Approve";
                btnapprove.Enabled = true;


            }
            if (string.IsNullOrEmpty(btncancle.Text.Trim()))
            {
                btncancle.Text = "Cancle";
                btncancle.Enabled = true;


            }



            



        }
    }
    protected void btnapprove_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnapprove");
        Label lblapprove = (Label)row.FindControl("lblapprove");
        Label Label1 = (Label)row.FindControl("Label1");
        SqlCommand Syscmd = new SqlCommand("update Users set UsrApprove='1' where UserId= " + lblapprove.Text + " ", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();
        conn.Close();
        //btnact.Text = DateTime.Now.ToString();

        SqlCommand Syscmd2 = new SqlCommand("INSERT INTO TblFormNameByUsr (FrmUsr) VALUES(@FrmUsr) ");
        Syscmd2.CommandType = CommandType.Text;
        Syscmd2.Connection = conn;
        Syscmd2.Parameters.AddWithValue("@FrmUsr", Label1.Text.Trim());
        conn.Open();
        Syscmd2.ExecuteNonQuery();
        conn.Close();
        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btncancle_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btncan = (Button)row.FindControl("btncancle");

        Label lblapprove = (Label)row.FindControl("lblapprove");
        SqlCommand Syscmd = new SqlCommand("update Users set UsrApprove='2' where UserId= " + lblapprove.Text + " ", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();
        conn.Close();
        btncan.Text = DateTime.Now.ToString();
        btncan.Enabled = false;

        //btnact.Text = "OK";
    }
}