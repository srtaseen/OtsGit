using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Collections;

public partial class Problem_Followup_TNA : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
		BindGetDpt();
		}
    }

    private void BindGetDpt()
    {

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("Select dpt_id, dpt_nm FROM DeptTab", conn);
            GetDpt.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GetDpt.DataTextField = "dpt_nm";
            GetDpt.DataValueField = "dpt_id";
            GetDpt.DataSource = rdr;
            GetDpt.DataBind();
        }
    }

    protected void btnfinddpt_Click(object sender, EventArgs e)
    {
        BindGvY();
    }

    protected void BindGvY()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM tbl_problemfollow WHERE done is NULL AND dpt_nm = '" + GetDpt.SelectedItem.Text + "' order by pid ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvY.DataSource = ds;
            GvY.DataBind();
            int columncount = GvY.Rows[0].Cells.Count;
            GvY.Rows[0].Cells.Clear();
            GvY.Rows[0].Cells.Add(new TableCell());
            GvY.Rows[0].Cells[0].ColumnSpan = columncount;
            GvY.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrder"] = ds.Tables[0];
            //Search Option-RUS
            GvY.DataSource = ds;
            GvY.DataBind();


        }

    }

    protected void GvY_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["pid"].ToString();
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            //Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");
            //Label lblHeader3 = (Label)e.Row.FindControl("lblHeader3");
            //Label lblHeader4 = (Label)e.Row.FindControl("lblHeader4");
            //Label lblHeader5 = (Label)e.Row.FindControl("lblHeader5");


            string strSelectCmd = "select * from tbl_problemfollow WHERE dpt_nm = '" + GetDpt.SelectedItem.Text + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            lblHeader.Text = "Plan Date";
            //lblHeader2.Text = "Reminder1";
            //lblHeader3.Text = "Reminder2";
            //lblHeader4.Text = "Reminder3";
            //lblHeader5.Text = "Done";



        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblryarnbok = (Label)e.Row.FindControl("lblryarnbok");
            Label lblr1 = (Label)e.Row.FindControl("lblr1");
            Label lblr2 = (Label)e.Row.FindControl("lblr2");
            Label lblr3 = (Label)e.Row.FindControl("lblr3");
            Label lblr4 = (Label)e.Row.FindControl("lblr4");
            Label lblr5 = (Label)e.Row.FindControl("lblr5");

            Label lbld1 = (Label)e.Row.FindControl("lbld1");
            Label lbld2 = (Label)e.Row.FindControl("lbld2");
            Label lbld3 = (Label)e.Row.FindControl("lbld3");
            Label lbld4 = (Label)e.Row.FindControl("lbld4");

            Label lbl1 = (Label)e.Row.FindControl("lbl1");
            Label lbl2 = (Label)e.Row.FindControl("lbl2");
            Label lbl3 = (Label)e.Row.FindControl("lbl3");
            Label lbl4 = (Label)e.Row.FindControl("lbl4");

            Button btnActualpln = (Button)e.Row.FindControl("btnActualpln");
            Button btnActualpln2 = (Button)e.Row.FindControl("btnActualpln2");
            Button btnActualpln3 = (Button)e.Row.FindControl("btnActualpln3");
            Button btnActualpln4 = (Button)e.Row.FindControl("btnActualpln4");
            Button btnActualpln5 = (Button)e.Row.FindControl("btnActualpln5");




            if (string.IsNullOrEmpty(btnActualpln.Text.Trim()))
            {
                btnActualpln.Text = "Complete";
                btnActualpln.Enabled = true;
                //DateTime d1 = DateTime.Now;
                //DateTime d2 = Convert.ToDateTime(lbl1.Text);
                //int days = (d1 - d2).Days;
                //lbld1.Text = days.ToString();
                ////Delay Days Count
            }
            else
            {
                ////Delay Days Count 
                //DateTime d1 = DateTime.Parse(btnActualpln.Text);
                //DateTime d2 = Convert.ToDateTime(lbl1.Text);
                //int days = (d1 - d2).Days;
                //lbld1.Text = days.ToString();
                ////Delay Days Count

            }

            if (string.IsNullOrEmpty(btnActualpln2.Text.Trim()))
            {
                btnActualpln2.Text = "Complete";
                btnActualpln2.Enabled = true;
                ////Delay Days Count 
                //DateTime d1 = DateTime.Now;
                //DateTime d2 = Convert.ToDateTime(lbl2.Text);
                //int days = (d1 - d2).Days;
                //lbld2.Text = days.ToString();
                ////Delay Days Count
            }
            else
            {
                //Delay Days Count 
                //DateTime d1 = DateTime.Parse(btnActualpln2.Text);
                //DateTime d2 = Convert.ToDateTime(lbl2.Text);
                //int days = (d1 - d2).Days;
                //lbld2.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(btnActualpln3.Text.Trim()))
            {
                btnActualpln3.Text = "Complete";
                btnActualpln3.Enabled = true;
                ////Delay Days Count 
                //DateTime d1 = DateTime.Now;
                //DateTime d2 = Convert.ToDateTime(lbl3.Text);
                //int days = (d1 - d2).Days;
                //lbld3.Text = days.ToString();
                ////Delay Days Count
            }
            else
            {
                //Delay Days Count 
                //DateTime d1 = DateTime.Parse(btnActualpln3.Text);
                //DateTime d2 = Convert.ToDateTime(lbl3.Text);
                //int days = (d1 - d2).Days;
                //lbld3.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(btnActualpln4.Text.Trim()))
            {
                btnActualpln4.Text = "Complete";
                btnActualpln4.Enabled = true;
                //Delay Days Count 
                //DateTime d1 = DateTime.Now;
                //DateTime d2 = Convert.ToDateTime(lbl4.Text);
                //int days = (d1 - d2).Days;
                //lbld4.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                //DateTime d1 = DateTime.Parse(btnActualpln4.Text);
                //DateTime d2 = Convert.ToDateTime(lbl4.Text);
                //int days = (d1 - d2).Days;
                //lbld4.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(btnActualpln5.Text.Trim()))
            {
                btnActualpln5.Text = "Complete";
                btnActualpln5.Enabled = true;
                //Delay Days Count 
                //DateTime d1 = DateTime.Now;
                //DateTime d2 = Convert.ToDateTime(lbl4.Text);
                //int days = (d1 - d2).Days;
                //lbld4.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                //DateTime d1 = DateTime.Parse(btnActualpln4.Text);
                //DateTime d2 = Convert.ToDateTime(lbl4.Text);
                //int days = (d1 - d2).Days;
                //lbld4.Text = days.ToString();
                //Delay Days Count

            }



            // gridview cell hover//
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";



            if (!string.IsNullOrEmpty(lbl1.Text))
            {

                DateTime dt = DateTime.Parse(lbl1.Text);

                if (btnActualpln.Text.ToString() != "Complete")
                {

                    lbl1.BackColor = System.Drawing.Color.Empty;
                    lbl1.ForeColor = System.Drawing.Color.Black;


                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl1.BackColor = System.Drawing.Color.Yellow;
                        lbl1.ForeColor = System.Drawing.Color.Black;


                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl1.BackColor = System.Drawing.Color.Red;
                        lbl1.ForeColor = System.Drawing.Color.WhiteSmoke;

                    }


                }

            }
            


        }




    }

    protected void btnActualpln_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln");
        Label lblStlid = (Label)row.FindControl("lblStlid");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update tbl_problemfollow set actdt='" + DateTime.Now + "' where pid=" + lblStlid.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln2_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln2");
        Label lblStlid2 = (Label)row.FindControl("lblStlid2");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update tbl_problemfollow set reminder1='" + DateTime.Now + "' where pid=" + lblStlid2.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln3_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln3");
        Label lblStlid3 = (Label)row.FindControl("lblStlid3");
        //Label lbl1 = (Label)row.FindControl("lbl1");

        SqlCommand Syscmd = new SqlCommand("update tbl_problemfollow set reminder2='" + DateTime.Now + "' where pid=" + lblStlid3.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln4_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln4");
        Label lblStlid4 = (Label)row.FindControl("lblStlid4");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update tbl_problemfollow set reminder3='" + DateTime.Now + "' where pid=" + lblStlid4.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }

    protected void btnActualpln5_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln5");
        Label lblStlid5 = (Label)row.FindControl("lblStlid5");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update tbl_problemfollow set done='" + DateTime.Now + "' where pid=" + lblStlid5.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    //pageChange
    protected void GvY_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvY.PageIndex = e.NewPageIndex;
        BindGetDpt();
    }
}