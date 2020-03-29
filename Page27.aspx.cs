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
            BindddlbuyerP();
            
        }
 
        
    }
    #region "print"
    //Print---------------------------------------------------------------------------------------
    //doropdown
    private void BindddlbuyerP()
    {
        ddlbuyerP.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC ", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbuyerP.DataSource = ds;
        ddlbuyerP.DataTextField = "byr_nm";
        ddlbuyerP.DataValueField = "byr_id";
        ddlbuyerP.DataBind();

        conn.Close();
    }
    protected void BindGvP()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND (Prnt='Y') AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + ddlbuyerP.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvP.DataSource = ds;
            GvP.DataBind();
            int columncount = GvP.Rows[0].Cells.Count;
            GvP.Rows[0].Cells.Clear();
            GvP.Rows[0].Cells.Add(new TableCell());
            GvP.Rows[0].Cells[0].ColumnSpan = columncount;
            GvP.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrderP"] = ds.Tables[0];
            //Search Option-RUS
            GvP.DataSource = ds;
            GvP.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearchP_Click(object sender, EventArgs e)
    {
        DataTable dtOrderP = (DataTable)ViewState["dtOrderP"];
        DataView dvOrderP = dtOrderP.DefaultView;
        dvOrderP.RowFilter = "ord_no like '" + txtSearchP.Text + "%'";

        GvP.DataSource = dvOrderP;
        GvP.DataBind();
    }

    //Search Option-RUS


    protected void btnfindP_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl38)*2 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND (Prnt='Y') AND ActiveOrder='1' AND TnaByrNm = '" + ddlbuyerP.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblprnt.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_Prnt", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddlbuyerP.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedPrnt"].ToString();
            lblprnt2.Text = Red;

        }
        conn.Close();
        // % of Red 
        lblprnt3.Text = ((int.Parse(lblprnt2.Text) * 100) / int.Parse(lblprnt.Text)).ToString("0");
        BindGvP();
    }
    protected void GvP_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");

            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddlbuyerP.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt38"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt39"].ToString();

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblr1 = (Label)e.Row.FindControl("lblr1");
            Label lblr2 = (Label)e.Row.FindControl("lblr2");



            Label lbld1 = (Label)e.Row.FindControl("lbld1");
            Label lbld2 = (Label)e.Row.FindControl("lbld2");

            Label lbl1 = (Label)e.Row.FindControl("lbl1");
            Label lbl2 = (Label)e.Row.FindControl("lbl2");


            Button btnActualpln = (Button)e.Row.FindControl("btnActualpln");
            Button btnActualpln2 = (Button)e.Row.FindControl("btnActualpln2");



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

    protected void btnActualpln_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln");
        Label lblStlid = (Label)row.FindControl("lblStlid");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac38='" + DateTime.Now + "' where TnaPoNm=" + lblStlid.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac39='" + DateTime.Now + "' where TnaPoNm=" + lblStlid2.Text + "", conn);
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
    protected void GvP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvP.PageIndex = e.NewPageIndex;
        BindGvP();
    }
    #endregion 

   
   

   
}
