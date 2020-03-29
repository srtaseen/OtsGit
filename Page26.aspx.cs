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
            BindddlbuyerI();
            
        }
        SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "'and (UsrDpt='16' OR UsrGroup='1') and frmnam14 = 'Page26.aspx'  ", conn);
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
    #region "Inventroy"

    //Inventory---------------------------------------------------------------------------------------
    //doropdown
    private void BindddlbuyerI()
    {
        ddlbuyerI.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC ", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbuyerI.DataSource = ds;
        ddlbuyerI.DataTextField = "byr_nm";
        ddlbuyerI.DataValueField = "byr_id";
        ddlbuyerI.DataBind();

        conn.Close();
    }
    protected void BindGvIvn()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + ddlbuyerI.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvIvn.DataSource = ds;
            GvIvn.DataBind();
            int columncount = GvIvn.Rows[0].Cells.Count;
            GvIvn.Rows[0].Cells.Clear();
            GvIvn.Rows[0].Cells.Add(new TableCell());
            GvIvn.Rows[0].Cells[0].ColumnSpan = columncount;
            GvIvn.Rows[0].Cells[0].Text = "";

        }
        else
        {
			 //Search Option-RUS
            ViewState["dtOrder"] = ds.Tables[0];
            //Search Option-RUS
            GvIvn.DataSource = ds;
            GvIvn.DataBind();


        }

    }
	
	//Search Option-RUS
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = (DataTable)ViewState["dtOrder"];
        DataView dvOrder = dtOrder.DefaultView;
        dvOrder.RowFilter = "ord_no like '" + txtSearch.Text + "%'";

        GvIvn.DataSource = dvOrder;
        GvIvn.DataBind();
    }

    //Search Option-RUS
    protected void btnfindI_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl31)*4 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND TnaByrNm = '" + ddlbuyerI.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblivn.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_Inventory", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddlbuyerI.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedInvent"].ToString();
            lblivn2.Text = Red;

        }
        conn.Close();
        // % of Red 
        lblivn3.Text = ((int.Parse(lblivn2.Text) * 100) / int.Parse(lblivn.Text)).ToString("0");
        BindGvIvn();
    }
    protected void GvIvn_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");
            Label lblHeader3 = (Label)e.Row.FindControl("lblHeader3");
            Label lblHeader4 = (Label)e.Row.FindControl("lblHeader4");




            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddlbuyerI.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt31"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt32"].ToString();
            lblHeader3.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt33"].ToString();
            lblHeader4.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt34"].ToString();

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblr1 = (Label)e.Row.FindControl("lblr1");
            Label lblr2 = (Label)e.Row.FindControl("lblr2");
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac31='" + DateTime.Now + "' where TnaPoNm=" + lblStlid.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac32='" + DateTime.Now + "' where TnaPoNm=" + lblStlid2.Text + "", conn);
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

        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac33='" + DateTime.Now + "' where TnaPoNm=" + lblStlid3.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac34='" + DateTime.Now + "' where TnaPoNm=" + lblStlid4.Text + "", conn);
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
    protected void GvIvn_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvIvn.PageIndex = e.NewPageIndex;
        BindGvIvn();
    }
    #endregion 

   
   

   
}
