using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Data;
using System.Web.Services;
using System.Configuration;

public partial class ProblemFollowReport : System.Web.UI.Page
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


            string strSelectCmd = "select * from tbl_problemfollow WHERE dpt_nm = '" + GetDpt.SelectedItem.Text + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            lblHeader.Text = "Plan Date";


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
            
            Button btnActualpln5 = (Button)e.Row.FindControl("btnActualpln5");

            if (string.IsNullOrEmpty(lblr1.Text.Trim()))
            {
                lblr1.Text = "Not Ok";
                //Delay Days Count 
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl1.Text);
                int days = (d1 - d2).Days;
                lbld1.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                DateTime d1 = DateTime.Parse(lblr1.Text);
                DateTime d2 = Convert.ToDateTime(lbl1.Text);
                int days = (d1 - d2).Days;
                lbld1.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr2.Text.Trim()))
            {
                lblr2.Text = "Not Ok";

                
            }
            else
            {
               

            }
            // gridview cell hover//
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";

            if (!string.IsNullOrEmpty(lbl1.Text))
            {

                DateTime dt = DateTime.Parse(lbl1.Text);

                if (lblr1.Text.ToString() != "Not Ok")
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

   

    
    //pageChange
    protected void GvY_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvY.PageIndex = e.NewPageIndex;
        BindGetDpt();
    }
}