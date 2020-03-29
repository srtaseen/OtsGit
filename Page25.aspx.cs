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
            BindddlbuyerAcs();
            
        }
        SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "'and (UsrDpt='15' OR UsrGroup='1') and frmnam13 = 'Page25.aspx'  ", conn);
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
    #region "Accessories"
    //Accessories---------------------------------------------------------------------------------------
    //doropdown
    private void BindddlbuyerAcs()
    {
        ddlbuyerAcs.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC  ", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbuyerAcs.DataSource = ds;
        ddlbuyerAcs.DataTextField = "byr_nm";
        ddlbuyerAcs.DataValueField = "byr_id";
        ddlbuyerAcs.DataBind();

        conn.Close();
    }
    protected void BindGvAcs()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + ddlbuyerAcs.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvAcs.DataSource = ds;
            GvAcs.DataBind();
            int columncount = GvAcs.Rows[0].Cells.Count;
            GvAcs.Rows[0].Cells.Clear();
            GvAcs.Rows[0].Cells.Add(new TableCell());
            GvAcs.Rows[0].Cells[0].ColumnSpan = columncount;
            GvAcs.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrder"] = ds.Tables[0];
            //Search Option-RUS
            GvAcs.DataSource = ds;
            GvAcs.DataBind();


        }

    }


    //Search Option-RUS
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = (DataTable)ViewState["dtOrder"];
        DataView dvOrder = dtOrder.DefaultView;
        dvOrder.RowFilter = "ord_no like '" + txtSearch.Text + "%'";

        GvAcs.DataSource = dvOrder;
        GvAcs.DataBind();
    }

    //Search Option-RUS


    protected void btnfindAcs_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl29)*4 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnaByrNm = '" + ddlbuyerAcs.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblacs.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_Acces", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddlbuyerAcs.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedAcces"].ToString();
            lblacs2.Text = Red;

        }
        conn.Close();
        // % of Red 
        lblacs3.Text = ((int.Parse(lblacs2.Text) * 100) / int.Parse(lblacs.Text)).ToString("0");
        BindGvAcs();
    }
    protected void GvAcs_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();
        }


        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");
            Label lblHeader60 = (Label)e.Row.FindControl("lblHeader60");
            Label lblHeader61 = (Label)e.Row.FindControl("lblHeader61");
            Label lblacsbook = (Label)e.Row.FindControl("lblacsbook");




            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddlbuyerAcs.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            lblacsbook.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt3"].ToString();
            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt29"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt30"].ToString();
            lblHeader60.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt60"].ToString();
            lblHeader61.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt61"].ToString();

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblracsbok = (Label)e.Row.FindControl("lblracsbok");
            Label lblr1 = (Label)e.Row.FindControl("lblr1");
            Label lblr2 = (Label)e.Row.FindControl("lblr2");
            Label lblr60 = (Label)e.Row.FindControl("lblr60");
            Label lblr61 = (Label)e.Row.FindControl("lblr61");

            Label lbld1 = (Label)e.Row.FindControl("lbld1");
            Label lbld2 = (Label)e.Row.FindControl("lbld2");
            Label lbld60 = (Label)e.Row.FindControl("lbld60");
            Label lbld61 = (Label)e.Row.FindControl("lbld61");


            Label lbl1 = (Label)e.Row.FindControl("lbl1");
            Label lbl2 = (Label)e.Row.FindControl("lbl2");
            Label lbl60 = (Label)e.Row.FindControl("lbl60");
            Label lbl61 = (Label)e.Row.FindControl("lbl61");

            Button btnActualpln = (Button)e.Row.FindControl("btnActualpln");
            Button btnActualpln2 = (Button)e.Row.FindControl("btnActualpln2");
            Button btnActualpln60 = (Button)e.Row.FindControl("btnActualpln60");
            Button btnActualpln61 = (Button)e.Row.FindControl("btnActualpln61");

            if (string.IsNullOrEmpty(lblracsbok.Text.Trim()))
            {
                lblracsbok.Text = "Not Received";
                lblracsbok.ForeColor = System.Drawing.Color.Red;
            }

            //acc pi
            if (string.IsNullOrEmpty(btnActualpln60.Text.Trim()))
            {
                btnActualpln60.Text = "Complete";
                btnActualpln60.Enabled = true;
                //Delay Days Count 
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl60.Text);
                int days = (d1 - d2).Days;
                lbld60.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                DateTime d1 = DateTime.Parse(btnActualpln60.Text);
                DateTime d2 = Convert.ToDateTime(lbl60.Text);
                int days = (d1 - d2).Days;
                lbld60.Text = days.ToString();
                //Delay Days Count

            }

            //acc pi

            //Acc bblc open
            if (string.IsNullOrEmpty(btnActualpln61.Text.Trim()))
            {
                btnActualpln61.Text = "Complete";
                btnActualpln61.Enabled = true;
                //Delay Days Count 
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl61.Text);
                int days = (d1 - d2).Days;
                lbld61.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                DateTime d1 = DateTime.Parse(btnActualpln61.Text);
                DateTime d2 = Convert.ToDateTime(lbl61.Text);
                int days = (d1 - d2).Days;
                lbld61.Text = days.ToString();
                //Delay Days Count

            }

            //Acc bblc open


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


            // gridview cell hover//
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";

            //acc pi rcv
            if (!string.IsNullOrEmpty(lbl60.Text))
            {

                DateTime dt = DateTime.Parse(lbl60.Text);

                if (btnActualpln60.Text.ToString() != "Complete")
                {

                    lbl60.BackColor = System.Drawing.Color.Empty;
                    lbl60.ForeColor = System.Drawing.Color.Black;


                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl60.BackColor = System.Drawing.Color.Yellow;
                        lbl60.ForeColor = System.Drawing.Color.Black;


                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl60.BackColor = System.Drawing.Color.Red;
                        lbl60.ForeColor = System.Drawing.Color.WhiteSmoke;

                    }


                }

            }
            //acc pi rcv
            //acc bblc open
            if (!string.IsNullOrEmpty(lbl61.Text))
            {

                DateTime dt = DateTime.Parse(lbl61.Text);

                if (btnActualpln61.Text.ToString() != "Complete")
                {

                    lbl61.BackColor = System.Drawing.Color.Empty;
                    lbl61.ForeColor = System.Drawing.Color.Black;


                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl61.BackColor = System.Drawing.Color.Yellow;
                        lbl61.ForeColor = System.Drawing.Color.Black;


                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl61.BackColor = System.Drawing.Color.Red;
                        lbl61.ForeColor = System.Drawing.Color.WhiteSmoke;

                    }


                }

            }



            //acc bblc open

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



        }


    }

    //acc pi rcv 
    protected void btnActualpln60_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact60 = (Button)row.FindControl("btnActualpln60");
        Label lblStlid60 = (Label)row.FindControl("lblStlid60");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac60='" + DateTime.Now + "' where TnaPoNm=" + lblStlid60.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact60.Text = DateTime.Now.ToString();

        btnact60.Enabled = false;

        //btnact.Text = "OK";
    }

    //acc pi rcv

    //acc bblc rcv 
    protected void btnActualpln61_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact61 = (Button)row.FindControl("btnActualpln61");
        Label lblStlid61 = (Label)row.FindControl("lblStlid61");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac61='" + DateTime.Now + "' where TnaPoNm=" + lblStlid61.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact61.Text = DateTime.Now.ToString();

        btnact61.Enabled = false;

        //btnact.Text = "OK";
    }

    //acc bblc rcv

    protected void btnActualpln_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln");
        Label lblStlid = (Label)row.FindControl("lblStlid");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac29='" + DateTime.Now + "' where TnaPoNm=" + lblStlid.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac30='" + DateTime.Now + "' where TnaPoNm=" + lblStlid2.Text + "", conn);
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
    protected void GvAcs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvAcs.PageIndex = e.NewPageIndex;
        BindGvAcs();
    }

    #endregion 

   
   

   
}
