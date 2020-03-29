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
    private static int PageSize = 5;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            BindddlbuyerM();
          
            
        }
 
        
    }
    private void BindddlbuyerM()
    {
        ddbuyerM.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddbuyerM.DataSource = ds;
        ddbuyerM.DataTextField = "byr_nm";
        ddbuyerM.DataValueField = "byr_id";
        ddbuyerM.DataBind();

        conn.Close();
    }
      //button
    protected void btnfindM_Click(object sender, EventArgs e)
    {
        
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl1)*21 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1'  AND TnaByrNm = '" + ddbuyerM.SelectedItem.Value + "' ", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lbltotal.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_Merchandisng", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRed"].ToString();
            lblRed.Text = Red;
           
        }
        conn.Close();
        //TheReader.Close();

        //Yellow
        SqlCommand cmdYellow = new SqlCommand("Sp_Red_MerchandisngMYlw", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedMerYlw"].ToString();
            lblYl.Text = Yellow;

        }

        conn.Close();
        // % of Red 
        lblredsub.Text = ((int.Parse(lblRed.Text) * 100) / int.Parse(lbltotal.Text)).ToString("0");
        lblYlSub.Text = ((int.Parse(lblYl.Text) * 100) / int.Parse(lbltotal.Text)).ToString("0");
        BindGvM();
     
   
    }
    //Grid
    protected void BindGvM()
    {
        conn.Open();
        string strSelectCmd = "SELECT  * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + ddbuyerM.SelectedItem.Value + "' order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvM.DataSource = ds;
            GvM.DataBind();
            int columncount = GvM.Rows[0].Cells.Count;
            GvM.Rows[0].Cells.Clear();
            GvM.Rows[0].Cells.Add(new TableCell());
            GvM.Rows[0].Cells[0].ColumnSpan = columncount;
            GvM.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrder"] = ds.Tables[0];
            //Search Option-RUS
            GvM.DataSource = ds;
            GvM.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = (DataTable)ViewState["dtOrder"];
        DataView dvOrder = dtOrder.DefaultView;
        dvOrder.RowFilter = "ord_no like '" + txtSearch.Text + "%'";

        GvM.DataSource = dvOrder;
        GvM.DataBind();
    }

    //Search Option-RUS






    //Rowdatabound
    protected void GvM_OnRowDataBound(object sender, GridViewRowEventArgs e)
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
            Label lblHeader5 = (Label)e.Row.FindControl("lblHeader5");
            Label lblHeader6 = (Label)e.Row.FindControl("lblHeader6");
            Label lblHeader7 = (Label)e.Row.FindControl("lblHeader7");
            Label lblHeader8 = (Label)e.Row.FindControl("lblHeader8");
            Label lblHeader9 = (Label)e.Row.FindControl("lblHeader9");
            Label lblHeader10 = (Label)e.Row.FindControl("lblHeader10");
            Label lblHeader11 = (Label)e.Row.FindControl("lblHeader11");
            Label lblHeader12 = (Label)e.Row.FindControl("lblHeader12");
            Label lblHeader13 = (Label)e.Row.FindControl("lblHeader13");
            Label lblHeader14 = (Label)e.Row.FindControl("lblHeader14");
            Label lblHeader15 = (Label)e.Row.FindControl("lblHeader15");
            Label lblHeader16 = (Label)e.Row.FindControl("lblHeader16");
            Label lblHeader17 = (Label)e.Row.FindControl("lblHeader17");
            Label lblHeader18 = (Label)e.Row.FindControl("lblHeader18");
            Label lblHeader19 = (Label)e.Row.FindControl("lblHeader19");
            //Label lblHeader20 = (Label)e.Row.FindControl("lblHeader20");
            Label lblHeader70 = (Label)e.Row.FindControl("lblHeader70");


            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddbuyerM.SelectedItem.Value + "'";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt1"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt2"].ToString();
            lblHeader3.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt3"].ToString();
            lblHeader4.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt4"].ToString();
            lblHeader5.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt5"].ToString();
            lblHeader6.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt6"].ToString();
            lblHeader7.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt7"].ToString();
            lblHeader8.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt8"].ToString();
            lblHeader9.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt9"].ToString();
            lblHeader10.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt10"].ToString();
            lblHeader11.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt11"].ToString();
            lblHeader12.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt12"].ToString();
            lblHeader13.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt13"].ToString();
            lblHeader14.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt14"].ToString();
            lblHeader15.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt15"].ToString();
            lblHeader16.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt16"].ToString();
            lblHeader17.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt17"].ToString();
            lblHeader18.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt18"].ToString();
            lblHeader19.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt19"].ToString();
            //lblHeader20.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt20"].ToString();
            lblHeader70.Text = ds.Tables[0].Rows[0]["Tmplt_Shipment"].ToString();

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblr1 = (Label)e.Row.FindControl("lblr1");
                Label lblr2 = (Label)e.Row.FindControl("lblr2");
                Label lblr3 = (Label)e.Row.FindControl("lblr3");
                Label lblr4 = (Label)e.Row.FindControl("lblr4");
                Label lblr5 = (Label)e.Row.FindControl("lblr5");
                Label lblr6 = (Label)e.Row.FindControl("lblr6");
                Label lblr7 = (Label)e.Row.FindControl("lblr7");
                Label lblr8 = (Label)e.Row.FindControl("lblr8");
                Label lblr9 = (Label)e.Row.FindControl("lblr9");
                Label lblr10 = (Label)e.Row.FindControl("lblr10");
                Label lblr11 = (Label)e.Row.FindControl("lblr11");
                Label lblr12 = (Label)e.Row.FindControl("lblr12");
                Label lblr13 = (Label)e.Row.FindControl("lblr13");
                Label lblr14 = (Label)e.Row.FindControl("lblr14");
                Label lblr15 = (Label)e.Row.FindControl("lblr15");
                Label lblr16 = (Label)e.Row.FindControl("lblr16");
                Label lblr17 = (Label)e.Row.FindControl("lblr17");
                Label lblr18 = (Label)e.Row.FindControl("lblr18");
                Label lblr19 = (Label)e.Row.FindControl("lblr19");
                //Label lblr20 = (Label)e.Row.FindControl("lblr20");
            //Label lblr70 = (Label)e.Row.FindControl("lblr70");
            Label lblordconfirm = (Label)e.Row.FindControl("lblordconfirm");

                Label lbld1 = (Label)e.Row.FindControl("lbld1");
                Label lbld2 = (Label)e.Row.FindControl("lbld2");
                Label lbld3 = (Label)e.Row.FindControl("lbld3");
                Label lbld4 = (Label)e.Row.FindControl("lbld4");
                Label lbld5 = (Label)e.Row.FindControl("lbld5");
                Label lbld6 = (Label)e.Row.FindControl("lbld6");
                Label lbld7 = (Label)e.Row.FindControl("lbld7");
                Label lbld8 = (Label)e.Row.FindControl("lbld8");
                Label lbld9 = (Label)e.Row.FindControl("lbld9");
                Label lbld10 = (Label)e.Row.FindControl("lbld10");
                Label lbld11 = (Label)e.Row.FindControl("lbld11");
                Label lbld12 = (Label)e.Row.FindControl("lbld12");
                Label lbld13 = (Label)e.Row.FindControl("lbld13");
                Label lbld14 = (Label)e.Row.FindControl("lbld14");
                Label lbld15 = (Label)e.Row.FindControl("lbld15");
                Label lbld16 = (Label)e.Row.FindControl("lbld16");
                Label lbld17 = (Label)e.Row.FindControl("lbld17");
                Label lbld18 = (Label)e.Row.FindControl("lbld18");
                Label lbld19 = (Label)e.Row.FindControl("lbld19");
                //Label lbld20 = (Label)e.Row.FindControl("lbld20");
            Label lbld70 = (Label)e.Row.FindControl("lbld70");
            Label lbldays = (Label)e.Row.FindControl("lbldays");


                Label lbl1 = (Label)e.Row.FindControl("lbl1");
                Label lbl2 = (Label)e.Row.FindControl("lbl2");
                Label lbl3 = (Label)e.Row.FindControl("lbl3");
                Label lbl4 = (Label)e.Row.FindControl("lbl4");
                Label lbl5 = (Label)e.Row.FindControl("lbl5");
                Label lbl6 = (Label)e.Row.FindControl("lbl6");
                Label lbl7 = (Label)e.Row.FindControl("lbl7");
                Label lbl8 = (Label)e.Row.FindControl("lbl8");
                Label lbl9 = (Label)e.Row.FindControl("lbl9");
                Label lbl10 = (Label)e.Row.FindControl("lbl10");
                Label lbl11 = (Label)e.Row.FindControl("lbl11");
                Label lbl12 = (Label)e.Row.FindControl("lbl12");
                Label lbl13 = (Label)e.Row.FindControl("lbl13");
                Label lbl14 = (Label)e.Row.FindControl("lbl14");
                Label lbl15 = (Label)e.Row.FindControl("lbl15");
                Label lbl16 = (Label)e.Row.FindControl("lbl16");
                Label lbl17 = (Label)e.Row.FindControl("lbl17");
                Label lbl18 = (Label)e.Row.FindControl("lbl18");
                Label lbl19 = (Label)e.Row.FindControl("lbl19");
                //Label lbl20 = (Label)e.Row.FindControl("lbl20");
            Label lbl70 = (Label)e.Row.FindControl("lbl70");

            Label lblxfactory = (Label)e.Row.FindControl("lblxfactory");
                Label lblrexfactory = (Label)e.Row.FindControl("lblrexfactory");

                Button btnActualpln = (Button)e.Row.FindControl("btnActualpln");
                Button btnActualpln2 = (Button)e.Row.FindControl("btnActualpln2");
                Button btnActualpln3 = (Button)e.Row.FindControl("btnActualpln3");
                Button btnActualpln4 = (Button)e.Row.FindControl("btnActualpln4");
                Button btnActualpln5 = (Button)e.Row.FindControl("btnActualpln5");
                Button btnActualpln6 = (Button)e.Row.FindControl("btnActualpln6");
                Button btnActualpln7 = (Button)e.Row.FindControl("btnActualpln7");
                Button btnActualpln8 = (Button)e.Row.FindControl("btnActualpln8");
                Button btnActualpln9 = (Button)e.Row.FindControl("btnActualpln9");
                Button btnActualpln10 = (Button)e.Row.FindControl("btnActualpln10");
                Button btnActualpln11 = (Button)e.Row.FindControl("btnActualpln11");
                Button btnActualpln12 = (Button)e.Row.FindControl("btnActualpln12");
                Button btnActualpln13 = (Button)e.Row.FindControl("btnActualpln13");
                Button btnActualpln14 = (Button)e.Row.FindControl("btnActualpln14");
                Button btnActualpln15 = (Button)e.Row.FindControl("btnActualpln15");
                Button btnActualpln16 = (Button)e.Row.FindControl("btnActualpln16");
                Button btnActualpln17 = (Button)e.Row.FindControl("btnActualpln17");
                Button btnActualpln18 = (Button)e.Row.FindControl("btnActualpln18");
                Button btnActualpln19 = (Button)e.Row.FindControl("btnActualpln19");
                //Button btnActualpln20 = (Button)e.Row.FindControl("btnActualpln20");
            Button btnActualpln70 = (Button)e.Row.FindControl("btnActualpln70");


            if (string.IsNullOrEmpty(lblrexfactory.Text.Trim()))
                {
                    DateTime ad1 = DateTime.Now;
                    DateTime ad2 = Convert.ToDateTime(lblxfactory.Text);
                    int rexdays = (ad1 - ad2).Days;
                    lbldays.Text = rexdays.ToString();
                }
                else
                {
                    DateTime ad1 = DateTime.Now;
                    DateTime ad2 = Convert.ToDateTime(lblrexfactory.Text);
                    int rexdays = (ad1 - ad2).Days;
                    lbldays.Text = rexdays.ToString();
                }



            //Rus Ship 



            if (string.IsNullOrEmpty(btnActualpln70.Text.Trim()))
            {
                //lblr1.Text = "Not Ok";
                btnActualpln70.Text = "Complete";
                btnActualpln70.Enabled = true;
                //Delay Days Count 
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl70.Text);
                int days = (d1 - d2).Days;
                lbld70.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                DateTime d1 = DateTime.Parse(btnActualpln70.Text);
                DateTime d2 = Convert.ToDateTime(lbl70.Text);
                int days = (d1 - d2).Days;
                lbld70.Text = days.ToString();
                //Delay Days Count

            }


            //Rus Ship 













            if (string.IsNullOrEmpty(btnActualpln.Text.Trim()))
                {
                    //lblr1.Text = "Not Ok";
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
                if (string.IsNullOrEmpty(btnActualpln5.Text.Trim()))
                {
                    btnActualpln5.Text = "Complete";
                    btnActualpln5.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl5.Text);
                    int days = (d1 - d2).Days;
                    lbld5.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln5.Text);
                    DateTime d2 = Convert.ToDateTime(lbl5.Text);
                    int days = (d1 - d2).Days;
                    lbld5.Text = days.ToString();
                    //Delay Days Count

                }

                if (string.IsNullOrEmpty(btnActualpln6.Text.Trim()))
                {
                    btnActualpln6.Text = "Complete";
                    btnActualpln6.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl6.Text);
                    int days = (d1 - d2).Days;
                    lbld6.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln6.Text);
                    DateTime d2 = Convert.ToDateTime(lbl6.Text);
                    int days = (d1 - d2).Days;
                    lbld6.Text = days.ToString();
                    //Delay Days Count

                }
                if (string.IsNullOrEmpty(btnActualpln7.Text.Trim()))
                {
                    btnActualpln7.Text = "Complete";
                    btnActualpln7.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl7.Text);
                    int days = (d1 - d2).Days;
                    lbld7.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln7.Text);
                    DateTime d2 = Convert.ToDateTime(lbl7.Text);
                    int days = (d1 - d2).Days;
                    lbld7.Text = days.ToString();
                    //Delay Days Count

                }

                if (string.IsNullOrEmpty(btnActualpln8.Text.Trim()))
                {
                    btnActualpln8.Text = "Complete";
                    btnActualpln8.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl8.Text);
                    int days = (d1 - d2).Days;
                    lbld8.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln8.Text);
                    DateTime d2 = Convert.ToDateTime(lbl8.Text);
                    int days = (d1 - d2).Days;
                    lbld8.Text = days.ToString();
                    //Delay Days Count

                }

                if (string.IsNullOrEmpty(btnActualpln9.Text.Trim()))
                {
                    btnActualpln9.Text = "Complete";
                    btnActualpln9.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl9.Text);
                    int days = (d1 - d2).Days;
                    lbld9.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln9.Text);
                    DateTime d2 = Convert.ToDateTime(lbl9.Text);
                    int days = (d1 - d2).Days;
                    lbld9.Text = days.ToString();
                    //Delay Days Count

                }

                if (string.IsNullOrEmpty(btnActualpln10.Text.Trim()))
                {
                    btnActualpln10.Text = "Complete";
                    btnActualpln10.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl10.Text);
                    int days = (d1 - d2).Days;
                    lbld10.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln10.Text);
                    DateTime d2 = Convert.ToDateTime(lbl10.Text);
                    int days = (d1 - d2).Days;
                    lbld10.Text = days.ToString();
                    //Delay Days Count

                }
                if (string.IsNullOrEmpty(btnActualpln11.Text.Trim()))
                {
                    btnActualpln11.Text = "Complete";
                    btnActualpln11.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl11.Text);
                    int days = (d1 - d2).Days;
                    lbld11.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln11.Text);
                    DateTime d2 = Convert.ToDateTime(lbl11.Text);
                    int days = (d1 - d2).Days;
                    lbld11.Text = days.ToString();
                    //Delay Days Count

                }

                if (string.IsNullOrEmpty(btnActualpln12.Text.Trim()))
                {
                    btnActualpln12.Text = "Complete";
                    btnActualpln12.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl12.Text);
                    int days = (d1 - d2).Days;
                    lbld12.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln12.Text);
                    DateTime d2 = Convert.ToDateTime(lbl12.Text);
                    int days = (d1 - d2).Days;
                    lbld12.Text = days.ToString();
                    //Delay Days Count

                }
                if (string.IsNullOrEmpty(btnActualpln13.Text.Trim()))
                {
                    btnActualpln13.Text = "Complete";
                    btnActualpln13.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl13.Text);
                    int days = (d1 - d2).Days;
                    lbld13.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln13.Text);
                    DateTime d2 = Convert.ToDateTime(lbl13.Text);
                    int days = (d1 - d2).Days;
                    lbld13.Text = days.ToString();
                    //Delay Days Count

                }

                if (string.IsNullOrEmpty(btnActualpln14.Text.Trim()))
                {
                    btnActualpln14.Text = "Complete";
                    btnActualpln14.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl14.Text);
                    int days = (d1 - d2).Days;
                    lbld14.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln14.Text);
                    DateTime d2 = Convert.ToDateTime(lbl14.Text);
                    int days = (d1 - d2).Days;
                    lbld14.Text = days.ToString();
                    //Delay Days Count

                }
                if (string.IsNullOrEmpty(btnActualpln15.Text.Trim()))
                {
                    btnActualpln15.Text = "Complete";
                    btnActualpln15.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl15.Text);
                    int days = (d1 - d2).Days;
                    lbld15.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln15.Text);
                    DateTime d2 = Convert.ToDateTime(lbl15.Text);
                    int days = (d1 - d2).Days;
                    lbld15.Text = days.ToString();
                    //Delay Days Count

                }
                if (string.IsNullOrEmpty(btnActualpln16.Text.Trim()))
                {
                    btnActualpln16.Text = "Complete";
                    btnActualpln16.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl16.Text);
                    int days = (d1 - d2).Days;
                    lbld16.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln16.Text);
                    DateTime d2 = Convert.ToDateTime(lbl16.Text);
                    int days = (d1 - d2).Days;
                    lbld16.Text = days.ToString();
                    //Delay Days Count

                }
                if (string.IsNullOrEmpty(btnActualpln17.Text.Trim()))
                {
                    btnActualpln17.Text = "Complete";
                    btnActualpln17.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl17.Text);
                    int days = (d1 - d2).Days;
                    lbld17.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln17.Text);
                    DateTime d2 = Convert.ToDateTime(lbl17.Text);
                    int days = (d1 - d2).Days;
                    lbld17.Text = days.ToString();
                    //Delay Days Count

                }
                if (string.IsNullOrEmpty(btnActualpln18.Text.Trim()))
                {
                    btnActualpln18.Text = "Complete";
                    btnActualpln18.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl18.Text);
                    int days = (d1 - d2).Days;
                    lbld18.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln18.Text);
                    DateTime d2 = Convert.ToDateTime(lbl18.Text);
                    int days = (d1 - d2).Days;
                    lbld18.Text = days.ToString();
                    //Delay Days Count

                }
                if (string.IsNullOrEmpty(btnActualpln19.Text.Trim()))
                {
                    btnActualpln19.Text = "Complete";
                    btnActualpln19.Enabled = true;

                    //Delay Days Count 
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(lbl19.Text);
                    int days = (d1 - d2).Days;
                    lbld19.Text = days.ToString();
                    //Delay Days Count
                }
                else
                {
                    //Delay Days Count 
                    DateTime d1 = DateTime.Parse(btnActualpln19.Text);
                    DateTime d2 = Convert.ToDateTime(lbl19.Text);
                    int days = (d1 - d2).Days;
                    lbld19.Text = days.ToString();
                    //Delay Days Count

                }
                //if (string.IsNullOrEmpty(btnActualpln20.Text.Trim()))
                //{
                //    btnActualpln20.Text = "Complete";
                //    btnActualpln20.Enabled = true;

                //    //Delay Days Count 
                //    DateTime d1 = DateTime.Now;
                //    DateTime d2 = Convert.ToDateTime(lbl20.Text);
                //    int days = (d1 - d2).Days;
                //    lbld20.Text = days.ToString();
                //    //Delay Days Count
                //}
                //else
                //{
                //    //Delay Days Count 
                //    DateTime d1 = DateTime.Parse(btnActualpln20.Text);
                //    DateTime d2 = Convert.ToDateTime(lbl20.Text);
                //    int days = (d1 - d2).Days;
                //    lbld20.Text = days.ToString();
                //    //Delay Days Count

                //}
                // gridview cell hover//
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";





            //Rus Ship



            if (!string.IsNullOrEmpty(lbl70.Text))
            {

                DateTime dt = DateTime.Parse(lbl70.Text);

                if (btnActualpln70.Text.ToString() != "Complete")
                {

                    lbl70.BackColor = System.Drawing.Color.Empty;
                    lbl70.ForeColor = System.Drawing.Color.Black;

                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl70.BackColor = System.Drawing.Color.Yellow;
                        lbl70.ForeColor = System.Drawing.Color.Black;


                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl70.BackColor = System.Drawing.Color.Red;
                        lbl70.ForeColor = System.Drawing.Color.Black;

                    }


                }

            }





            //Rus Ship









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
                            lbl1.ForeColor = System.Drawing.Color.Black;

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
                if (!string.IsNullOrEmpty(lbl5.Text))
                {

                    DateTime dt = DateTime.Parse(lbl5.Text);

                    if (btnActualpln5.Text.ToString() != "Complete")
                    {

                        lbl5.BackColor = System.Drawing.Color.Empty;
                        lbl5.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl5.BackColor = System.Drawing.Color.Yellow;
                            lbl5.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl5.BackColor = System.Drawing.Color.Red;
                            lbl5.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl4.Text))
                {

                    DateTime dt = DateTime.Parse(lbl6.Text);

                    if (btnActualpln6.Text.ToString() != "Complete")
                    {

                        lbl6.BackColor = System.Drawing.Color.Empty;
                        lbl6.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl6.BackColor = System.Drawing.Color.Yellow;
                            lbl6.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl6.BackColor = System.Drawing.Color.Red;
                            lbl6.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl7.Text))
                {

                    DateTime dt = DateTime.Parse(lbl7.Text);

                    if (btnActualpln7.Text.ToString() != "Complete")
                    {

                        lbl7.BackColor = System.Drawing.Color.Empty;
                        lbl7.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl7.BackColor = System.Drawing.Color.Yellow;
                            lbl7.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl7.BackColor = System.Drawing.Color.Red;
                            lbl7.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl8.Text))
                {

                    DateTime dt = DateTime.Parse(lbl8.Text);

                    if (btnActualpln8.Text.ToString() != "Complete")
                    {

                        lbl8.BackColor = System.Drawing.Color.Empty;
                        lbl8.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl8.BackColor = System.Drawing.Color.Yellow;
                            lbl8.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl8.BackColor = System.Drawing.Color.Red;
                            lbl8.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl9.Text))
                {

                    DateTime dt = DateTime.Parse(lbl9.Text);

                    if (btnActualpln9.Text.ToString() != "Complete")
                    {

                        lbl9.BackColor = System.Drawing.Color.Empty;
                        lbl9.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl9.BackColor = System.Drawing.Color.Yellow;
                            lbl9.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl9.BackColor = System.Drawing.Color.Red;
                            lbl9.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl10.Text))
                {

                    DateTime dt = DateTime.Parse(lbl10.Text);

                    if (btnActualpln10.Text.ToString() != "Complete")
                    {

                        lbl10.BackColor = System.Drawing.Color.Empty;
                        lbl10.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl10.BackColor = System.Drawing.Color.Yellow;
                            lbl10.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl10.BackColor = System.Drawing.Color.Red;
                            lbl10.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl11.Text))
                {

                    DateTime dt = DateTime.Parse(lbl11.Text);

                    if (btnActualpln11.Text.ToString() != "Complete")
                    {

                        lbl11.BackColor = System.Drawing.Color.Empty;
                        lbl11.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl11.BackColor = System.Drawing.Color.Yellow;
                            lbl11.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl11.BackColor = System.Drawing.Color.Red;
                            lbl11.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl12.Text))
                {

                    DateTime dt = DateTime.Parse(lbl12.Text);

                    if (btnActualpln12.Text.ToString() != "Complete")
                    {

                        lbl12.BackColor = System.Drawing.Color.Empty;
                        lbl12.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl12.BackColor = System.Drawing.Color.Yellow;
                            lbl12.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl12.BackColor = System.Drawing.Color.Red;
                            lbl12.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl13.Text))
                {

                    DateTime dt = DateTime.Parse(lbl13.Text);

                    if (btnActualpln13.Text.ToString() != "Complete")
                    {

                        lbl13.BackColor = System.Drawing.Color.Empty;
                        lbl13.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl13.BackColor = System.Drawing.Color.Yellow;
                            lbl13.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl13.BackColor = System.Drawing.Color.Red;
                            lbl13.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl14.Text))
                {

                    DateTime dt = DateTime.Parse(lbl14.Text);

                    if (btnActualpln14.Text.ToString() != "Complete")
                    {

                        lbl14.BackColor = System.Drawing.Color.Empty;
                        lbl14.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl14.BackColor = System.Drawing.Color.Yellow;
                            lbl14.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl14.BackColor = System.Drawing.Color.Red;
                            lbl14.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl15.Text))
                {

                    DateTime dt = DateTime.Parse(lbl15.Text);

                    if (btnActualpln15.Text.ToString() != "Complete")
                    {

                        lbl15.BackColor = System.Drawing.Color.Empty;
                        lbl15.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl15.BackColor = System.Drawing.Color.Yellow;
                            lbl15.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl15.BackColor = System.Drawing.Color.Red;
                            lbl15.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl16.Text))
                {

                    DateTime dt = DateTime.Parse(lbl16.Text);

                    if (btnActualpln16.Text.ToString() != "Complete")
                    {

                        lbl16.BackColor = System.Drawing.Color.Empty;
                        lbl16.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl16.BackColor = System.Drawing.Color.Yellow;
                            lbl16.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl16.BackColor = System.Drawing.Color.Red;
                            lbl16.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl17.Text))
                {

                    DateTime dt = DateTime.Parse(lbl17.Text);

                    if (btnActualpln17.Text.ToString() != "Complete")
                    {

                        lbl17.BackColor = System.Drawing.Color.Empty;
                        lbl17.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl17.BackColor = System.Drawing.Color.Yellow;
                            lbl17.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl17.BackColor = System.Drawing.Color.Red;
                            lbl17.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl18.Text))
                {

                    DateTime dt = DateTime.Parse(lbl18.Text);

                    if (btnActualpln18.Text.ToString() != "Complete")
                    {

                        lbl18.BackColor = System.Drawing.Color.Empty;
                        lbl18.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl18.BackColor = System.Drawing.Color.Yellow;
                            lbl18.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl18.BackColor = System.Drawing.Color.Red;
                            lbl18.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                if (!string.IsNullOrEmpty(lbl19.Text))
                {

                    DateTime dt = DateTime.Parse(lbl19.Text);

                    if (btnActualpln19.Text.ToString() != "Complete")
                    {

                        lbl19.BackColor = System.Drawing.Color.Empty;
                        lbl19.ForeColor = System.Drawing.Color.Black;


                    }
                    else
                    {
                        if (dt.AddDays(-6) <= DateTime.Now)
                        {
                            lbl19.BackColor = System.Drawing.Color.Yellow;
                            lbl19.ForeColor = System.Drawing.Color.Black;


                        }
                        if (dt <= DateTime.Now)
                        {
                            lbl19.BackColor = System.Drawing.Color.Red;
                            lbl19.ForeColor = System.Drawing.Color.WhiteSmoke;

                        }
                    }

                }
                //if (!string.IsNullOrEmpty(lbl20.Text))
                //{

                //    DateTime dt = DateTime.Parse(lbl20.Text);

                //    if (btnActualpln20.Text.ToString() != "Complete")
                //    {

                //        lbl20.BackColor = System.Drawing.Color.Empty;
                //        lbl20.ForeColor = System.Drawing.Color.Black;


                //    }
                //    else
                //    {
                //        if (dt.AddDays(-6) <= DateTime.Now)
                //        {
                //            lbl20.BackColor = System.Drawing.Color.Yellow;
                //            lbl20.ForeColor = System.Drawing.Color.Black;


                //        }
                //        if (dt <= DateTime.Now)
                //        {
                //            lbl20.BackColor = System.Drawing.Color.Red;
                //            lbl20.ForeColor = System.Drawing.Color.WhiteSmoke;

                //        }
                //    }

                //}
        }





    }



    















    protected void btnActualpln_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln");
        Label lblStlid = (Label)row.FindControl("lblStlid");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac1='" + DateTime.Now + "' where TnaPoNm=" + lblStlid.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac2='" + DateTime.Now + "' where TnaPoNm=" + lblStlid2.Text + "", conn);
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

        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac3='" + DateTime.Now + "' where TnaPoNm=" + lblStlid3.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac4='" + DateTime.Now + "' where TnaPoNm=" + lblStlid4.Text + "", conn);
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



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac5='" + DateTime.Now + "' where TnaPoNm=" + lblStlid5.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln6_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln6");
        Label lblStlid6 = (Label)row.FindControl("lblStlid6");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac6='" + DateTime.Now + "' where TnaPoNm=" + lblStlid6.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln7_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln7");
        Label lblStlid7 = (Label)row.FindControl("lblStlid7");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac7='" + DateTime.Now + "' where TnaPoNm=" + lblStlid7.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln8_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln8");
        Label lblStlid8 = (Label)row.FindControl("lblStlid8");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac8='" + DateTime.Now + "' where TnaPoNm=" + lblStlid8.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln9_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln9");
        Label lblStlid9 = (Label)row.FindControl("lblStlid9");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac9='" + DateTime.Now + "' where TnaPoNm=" + lblStlid9.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln10_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln10");
        Label lblStlid10 = (Label)row.FindControl("lblStlid10");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac10='" + DateTime.Now + "' where TnaPoNm=" + lblStlid10.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln11_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln11");
        Label lblStlid11 = (Label)row.FindControl("lblStlid11");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac11='" + DateTime.Now + "' where TnaPoNm=" + lblStlid11.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln12_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln12");
        Label lblStlid12 = (Label)row.FindControl("lblStlid12");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac12='" + DateTime.Now + "' where TnaPoNm=" + lblStlid12.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln13_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln13");
        Label lblStlid13 = (Label)row.FindControl("lblStlid13");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac13='" + DateTime.Now + "' where TnaPoNm=" + lblStlid13.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln14_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln14");
        Label lblStlid14 = (Label)row.FindControl("lblStlid14");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac14='" + DateTime.Now + "' where TnaPoNm=" + lblStlid14.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln15_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln15");
        Label lblStlid15 = (Label)row.FindControl("lblStlid15");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac15='" + DateTime.Now + "' where TnaPoNm=" + lblStlid15.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln16_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln16");
        Label lblStlid16 = (Label)row.FindControl("lblStlid16");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac16='" + DateTime.Now + "' where TnaPoNm=" + lblStlid16.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln17_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln17");
        Label lblStlid17 = (Label)row.FindControl("lblStlid17");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac17='" + DateTime.Now + "' where TnaPoNm=" + lblStlid17.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln18_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln18");
        Label lblStlid18 = (Label)row.FindControl("lblStlid18");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac18='" + DateTime.Now + "' where TnaPoNm=" + lblStlid18.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnActualpln19_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln19");
        Label lblStlid19 = (Label)row.FindControl("lblStlid19");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac19='" + DateTime.Now + "' where TnaPoNm=" + lblStlid19.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();

        btnact.Text = DateTime.Now.ToString();

        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    //protected void btnActualpln20_Click(object sender, EventArgs e)
    //{
    //    GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
    //    Button btnact = (Button)row.FindControl("btnActualpln20");
    //    Label lblStlid20 = (Label)row.FindControl("lblStlid20");
    //    //Label lbl1 = (Label)row.FindControl("lbl1");



    //    SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set Tnaac20='" + DateTime.Now + "' where TnaPoNm=" + lblStlid20.Text + "", conn);
    //    Syscmd.CommandType = CommandType.Text;
    //    Syscmd.Connection = conn;
    //    conn.Open();
    //    Syscmd.ExecuteNonQuery();

    //    conn.Close();

    //    btnact.Text = DateTime.Now.ToString();

    //    btnact.Enabled = false;

    //    //btnact.Text = "OK";
    //}




    //Rus Ship

    protected void btnActualpln70_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnActualpln70");
        Label lblStlid70 = (Label)row.FindControl("lblStlid70");
        //Label lbl1 = (Label)row.FindControl("lbl1");



        SqlCommand Syscmd = new SqlCommand("update Tbl_TnaPlan set PO_Ship_Date='" + DateTime.Now + "' where TnaPoNm=" + lblStlid70.Text + "", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();

        Syscmd.ExecuteNonQuery();
        conn.Close();


        btnact.Text = DateTime.Now.ToString();
       
        btnact.Enabled = false;

        //btnact.Text = "OK";

    }




    //Rus Ship














    protected void GvM_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvM.PageIndex = e.NewPageIndex;
        BindGvM();
    }

   
   

   
}
