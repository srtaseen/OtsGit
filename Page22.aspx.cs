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

public partial class Page12 : System.Web.UI.Page
{ 
    SqlConnection conn = new SqlConnection(DbConnect.x);
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            BindddlbuyerD();
          
            
        }
        SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "'and (UsrDpt='10' OR UsrGroup='1') and frmnam11 = 'Page22.aspx'  ", conn);
        command.Connection.Open();
        SqlDataReader rdr = command.ExecuteReader();

        if (rdr.HasRows)
        {

        }
        else
        {

            Response.Redirect("page2.aspx");
        }

        conn.Close();
        
    }
    #region "Dyeing "
    //Dyeing-------------------------------------------------------------------------------------
    //dropdown
    private void BindddlbuyerD()
    {
        ddlbuyerD.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC  ", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbuyerD.DataSource = ds;
        ddlbuyerD.DataTextField = "byr_nm";
        ddlbuyerD.DataValueField = "byr_id";
        ddlbuyerD.DataBind();

        conn.Close();
    }
    protected void BindGvD()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + ddlbuyerD.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvD.DataSource = ds;
            GvD.DataBind();
            int columncount = GvD.Rows[0].Cells.Count;
            GvD.Rows[0].Cells.Clear();
            GvD.Rows[0].Cells.Add(new TableCell());
            GvD.Rows[0].Cells[0].ColumnSpan = columncount;
            GvD.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrder"] = ds.Tables[0];
            //Search Option-RUS
            GvD.DataSource = ds;
            GvD.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = (DataTable)ViewState["dtOrder"];
        DataView dvOrder = dtOrder.DefaultView;
        dvOrder.RowFilter = "ord_no like '" + txtSearch.Text + "%'";

        GvD.DataSource = dvOrder;
        GvD.DataBind();
    }

    //Search Option-RUS


    protected void btnfindD_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl27)*4 AS Total FROM View_Tna_Plan WHERE Po_ShipDate is NULL  AND ActiveOrder='1' AND TnaByrNm = '" + ddlbuyerD.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblrdyed.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_Dyeing", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddlbuyerD.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedDye"].ToString();
            lblrdyed2.Text = Red;

        }
        conn.Close();


        //Yellow
        SqlCommand cmdYellow = new SqlCommand("Sp_Red_DyeingYlw", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddlbuyerD.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedDyeYlw"].ToString();
            lblYl.Text = Yellow;

        }


        conn.Close();

        // % of Red 
        lblrdyed3.Text = ((int.Parse(lblrdyed2.Text) * 100) / int.Parse(lblrdyed.Text)).ToString("0");
        lblYlSub.Text = ((int.Parse(lblYl.Text) * 100) / int.Parse(lblrdyed.Text)).ToString("0");
        BindGvD();
    }
    protected void GvD_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");
            Label knitstart = (Label)e.Row.FindControl("knitstart");
            Label lblHeader3 = (Label)e.Row.FindControl("lblHeader3");
            Label lblHeader4 = (Label)e.Row.FindControl("lblHeader4");



            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddlbuyerD.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            knitstart.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt25"].ToString();

            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt27"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt28"].ToString();

            lblHeader3.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt10"].ToString();
            lblHeader4.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt11"].ToString();

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label knitstart = (Label)e.Row.FindControl("knitstart");

            Label lblr1 = (Label)e.Row.FindControl("lblr1");
            Label lblr2 = (Label)e.Row.FindControl("lblr2");
            Label lblr5 = (Label)e.Row.FindControl("lblr5");
            Label lblr3 = (Label)e.Row.FindControl("lblr3");
            Label lblr4 = (Label)e.Row.FindControl("lblr4");

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

            if (string.IsNullOrEmpty(knitstart.Text.Trim()))
            {
                knitstart.Text = "Not Started";
                knitstart.ForeColor = System.Drawing.Color.Red;
            }


            if (string.IsNullOrEmpty(btnActualpln.Text.Trim()))
            {
                btnActualpln.Text = "Complete";
                btnActualpln.Enabled = true;
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
                DateTime d1 = DateTime.Parse(btnActualpln.Text);
                DateTime d2 = Convert.ToDateTime(lbl1.Text);
                int days = (d1 - d2).Days;
                lbld1.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(btnActualpln2.Text.Trim()))
            {
                btnActualpln2.Text = "Complete";
                btnActualpln2.Enabled = true;
                //Delay Days Count 
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl2.Text);
                int days = (d1 - d2).Days;
                lbld2.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                DateTime d1 = DateTime.Parse(btnActualpln2.Text);
                DateTime d2 = Convert.ToDateTime(lbl2.Text);
                int days = (d1 - d2).Days;
                lbld2.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(btnActualpln3.Text.Trim()))
            {
                btnActualpln3.Text = "Complete";
                btnActualpln3.Enabled = true;
                //Delay Days Count 
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl3.Text);
                int days = (d1 - d2).Days;
                lbld3.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                DateTime d1 = DateTime.Parse(btnActualpln3.Text);
                DateTime d2 = Convert.ToDateTime(lbl3.Text);
                int days = (d1 - d2).Days;
                lbld3.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(btnActualpln4.Text.Trim()))
            {
                btnActualpln4.Text = "Complete";
                btnActualpln4.Enabled = true;
                //Delay Days Count 
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl4.Text);
                int days = (d1 - d2).Days;
                lbld4.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                DateTime d1 = DateTime.Parse(btnActualpln4.Text);
                DateTime d2 = Convert.ToDateTime(lbl4.Text);
                int days = (d1 - d2).Days;
                lbld4.Text = days.ToString();
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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (btnActualpln2.Text.ToString() != "Complete")
                {

                    lbl2.BackColor = System.Drawing.Color.Empty;
                    lbl2.ForeColor = System.Drawing.Color.Black;


                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl2.BackColor = System.Drawing.Color.Yellow;
                        lbl2.ForeColor = System.Drawing.Color.Black;


                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl2.BackColor = System.Drawing.Color.Red;
                        lbl2.ForeColor = System.Drawing.Color.WhiteSmoke;

                    }


                }

            }


            if (!string.IsNullOrEmpty(lbl3.Text))
            {

                DateTime dt = DateTime.Parse(lbl3.Text);

                if (btnActualpln3.Text.ToString() != "Complete")
                {

                    lbl3.BackColor = System.Drawing.Color.Empty;
                    lbl3.ForeColor = System.Drawing.Color.Black;


                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl3.BackColor = System.Drawing.Color.Yellow;
                        lbl3.ForeColor = System.Drawing.Color.Black;


                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl3.BackColor = System.Drawing.Color.Red;
                        lbl3.ForeColor = System.Drawing.Color.WhiteSmoke;

                    }


                }

            }


            if (!string.IsNullOrEmpty(lbl4.Text))
            {

                DateTime dt = DateTime.Parse(lbl4.Text);

                if (btnActualpln4.Text.ToString() != "Complete")
                {

                    lbl4.BackColor = System.Drawing.Color.Empty;
                    lbl4.ForeColor = System.Drawing.Color.Black;


                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl4.BackColor = System.Drawing.Color.Yellow;
                        lbl4.ForeColor = System.Drawing.Color.Black;


                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl4.BackColor = System.Drawing.Color.Red;
                        lbl4.ForeColor = System.Drawing.Color.WhiteSmoke;

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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac27='" + DateTime.Now + "' where TnaPoNm=" + lblStlid.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac28='" + DateTime.Now + "' where TnaPoNm=" + lblStlid2.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac10='" + DateTime.Now + "' where TnaPoNm=" + lblStlid3.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac11='" + DateTime.Now + "' where TnaPoNm=" + lblStlid4.Text + "", conn);
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
    protected void GvD_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvD.PageIndex = e.NewPageIndex;
        BindGvD();
    }
    #endregion

   
   

   
}
