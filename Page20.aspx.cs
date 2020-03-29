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
            BindddlbuyerY();
            BindddlbuyerYD();
            BindddlbuyerK();
            BindddlbuyerD();
            BindddlbuyerAOP();
            BindddlbuyerAcs();
            BindddlbuyerI();
            BindddlbuyerP();
            BindddlbuyerE();
            BindddlbuyerR();
          
            
        }
 
        
    }
    private void BindddlbuyerM()
    {
        ddbuyerM.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "Shahzahan") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "Rouf") || (Session["Username"].ToString() == "Hussain")|| (Session["Username"].ToString() == "Mukter")|| (Session["Username"].ToString() == "shams"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
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
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl1)*20 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1'  AND TnaByrNm = '" + ddbuyerM.SelectedItem.Value + "' ", conn);
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
    protected void btnSearchM_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = (DataTable)ViewState["dtOrder"];
        DataView dvOrder = dtOrder.DefaultView;
        dvOrder.RowFilter = "ord_no like '" + txtSearchM.Text + "%'";

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
            Label lblHeader20 = (Label)e.Row.FindControl("lblHeader20");


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
            lblHeader20.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt20"].ToString();

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
            Label lblr20 = (Label)e.Row.FindControl("lblr20");
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
            Label lbld20 = (Label)e.Row.FindControl("lbld20");
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
            Label lbl20 = (Label)e.Row.FindControl("lbl20");

            Label lblxfactory = (Label)e.Row.FindControl("lblxfactory");
            Label lblrexfactory = (Label)e.Row.FindControl("lblrexfactory");




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
                DateTime d1 = DateTime.Parse(lblr2.Text);
                DateTime d2 = Convert.ToDateTime(lbl2.Text);
                int days = (d1 - d2).Days;
                lbld2.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr3.Text.Trim()))
            {
                lblr3.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr3.Text);
                DateTime d2 = Convert.ToDateTime(lbl3.Text);
                int days = (d1 - d2).Days;
                lbld3.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr4.Text.Trim()))
            {
                lblr4.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr4.Text);
                DateTime d2 = Convert.ToDateTime(lbl4.Text);
                int days = (d1 - d2).Days;
                lbld4.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr5.Text.Trim()))
            {
                lblr5.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr5.Text);
                DateTime d2 = Convert.ToDateTime(lbl5.Text);
                int days = (d1 - d2).Days;
                lbld5.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr6.Text.Trim()))
            {
                lblr6.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr6.Text);
                DateTime d2 = Convert.ToDateTime(lbl6.Text);
                int days = (d1 - d2).Days;
                lbld6.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr7.Text.Trim()))
            {
                lblr7.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr7.Text);
                DateTime d2 = Convert.ToDateTime(lbl7.Text);
                int days = (d1 - d2).Days;
                lbld7.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr8.Text.Trim()))
            {
                lblr8.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr8.Text);
                DateTime d2 = Convert.ToDateTime(lbl8.Text);
                int days = (d1 - d2).Days;
                lbld8.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr9.Text.Trim()))
            {
                lblr9.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr9.Text);
                DateTime d2 = Convert.ToDateTime(lbl9.Text);
                int days = (d1 - d2).Days;
                lbld9.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr10.Text.Trim()))
            {
                lblr10.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr10.Text);
                DateTime d2 = Convert.ToDateTime(lbl10.Text);
                int days = (d1 - d2).Days;
                lbld10.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr11.Text.Trim()))
            {
                lblr11.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr11.Text);
                DateTime d2 = Convert.ToDateTime(lbl11.Text);
                int days = (d1 - d2).Days;
                lbld11.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr12.Text.Trim()))
            {
                lblr12.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr12.Text);
                DateTime d2 = Convert.ToDateTime(lbl12.Text);
                int days = (d1 - d2).Days;
                lbld12.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr13.Text.Trim()))
            {
                lblr13.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr13.Text);
                DateTime d2 = Convert.ToDateTime(lbl13.Text);
                int days = (d1 - d2).Days;
                lbld13.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr14.Text.Trim()))
            {
                lblr14.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr14.Text);
                DateTime d2 = Convert.ToDateTime(lbl14.Text);
                int days = (d1 - d2).Days;
                lbld14.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr15.Text.Trim()))
            {
                lblr15.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr15.Text);
                DateTime d2 = Convert.ToDateTime(lbl15.Text);
                int days = (d1 - d2).Days;
                lbld15.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr16.Text.Trim()))
            {
                lblr16.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr16.Text);
                DateTime d2 = Convert.ToDateTime(lbl16.Text);
                int days = (d1 - d2).Days;
                lbld16.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr17.Text.Trim()))
            {
                lblr17.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr17.Text);
                DateTime d2 = Convert.ToDateTime(lbl17.Text);
                int days = (d1 - d2).Days;
                lbld17.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr18.Text.Trim()))
            {
                lblr18.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr18.Text);
                DateTime d2 = Convert.ToDateTime(lbl18.Text);
                int days = (d1 - d2).Days;
                lbld18.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr19.Text.Trim()))
            {
                lblr19.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr19.Text);
                DateTime d2 = Convert.ToDateTime(lbl19.Text);
                int days = (d1 - d2).Days;
                lbld19.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr20.Text.Trim()))
            {
                lblr20.Text = "Not Ok";

                //Delay Days Count 
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl20.Text);
                int days = (d1 - d2).Days;
                lbld20.Text = days.ToString();
                //Delay Days Count
            }
            else
            {
                //Delay Days Count 
                DateTime d1 = DateTime.Parse(lblr20.Text);
                DateTime d2 = Convert.ToDateTime(lbl20.Text);
                int days = (d1 - d2).Days;
                lbld20.Text = days.ToString();
                //Delay Days Count

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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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

                if (lblr3.Text.ToString() != "Not Ok")
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

                if (lblr4.Text.ToString() != "Not Ok")
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

                if (lblr5.Text.ToString() != "Not Ok")
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

                if (lblr6.Text.ToString() != "Not Ok")
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

                if (lblr7.Text.ToString() != "Not Ok")
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

                if (lblr8.Text.ToString() != "Not Ok")
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

                if (lblr9.Text.ToString() != "Not Ok")
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

                if (lblr10.Text.ToString() != "Not Ok")
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

                if (lblr11.Text.ToString() != "Not Ok")
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

                if (lblr12.Text.ToString() != "Not Ok")
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

                if (lblr13.Text.ToString() != "Not Ok")
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

                if (lblr14.Text.ToString() != "Not Ok")
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

                if (lblr15.Text.ToString() != "Not Ok")
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

                if (lblr16.Text.ToString() != "Not Ok")
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

                if (lblr17.Text.ToString() != "Not Ok")
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

                if (lblr18.Text.ToString() != "Not Ok")
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

                if (lblr19.Text.ToString() != "Not Ok")
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
            if (!string.IsNullOrEmpty(lbl20.Text))
            {

                DateTime dt = DateTime.Parse(lbl20.Text);

                if (lblr20.Text.ToString() != "Not Ok")
                {

                    lbl20.BackColor = System.Drawing.Color.Empty;
                    lbl20.ForeColor = System.Drawing.Color.Black;


                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl20.BackColor = System.Drawing.Color.Yellow;
                        lbl20.ForeColor = System.Drawing.Color.Black;


                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl20.BackColor = System.Drawing.Color.Red;
                        lbl20.ForeColor = System.Drawing.Color.WhiteSmoke;

                    }
                }

            }
        }





    }

    
    protected void GvM_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvM.PageIndex = e.NewPageIndex;
        BindGvM();
    }


    #region "Yarn"
    // Yarn------------------------------------------------------------------------------------
    //dropdown
    private void BindddlbuyerY()
    {
        dlbuyerY.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul")|| (Session["Username"].ToString() == "Hussain")|| (Session["Username"].ToString() == "Mukter")|| (Session["Username"].ToString() == "shams"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        dlbuyerY.DataSource = ds;
        dlbuyerY.DataTextField = "byr_nm";
        dlbuyerY.DataValueField = "byr_id";
        dlbuyerY.DataBind();

        conn.Close();
    }
    //button
    protected void btnfindY_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl21)*4 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnaByrNm = '" + dlbuyerY.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblTtlar.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_Yarn", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", dlbuyerY.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedYarn"].ToString();
            lblTtlar2.Text = Red;

        }
        conn.Close();



        //Yellow
        SqlCommand cmdYellow = new SqlCommand("Sp_Red_YarnYlw", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedYarnYlw"].ToString();
            lblYlY.Text = Yellow;

        }

        conn.Close();







        // % of Red 
        lblTtlar3.Text = ((int.Parse(lblTtlar2.Text) * 100) / int.Parse(lblTtlar.Text)).ToString("0");
        lblYlSubY.Text = ((int.Parse(lblYlY.Text) * 100) / int.Parse(lblTtlar.Text)).ToString("0");
        BindGvY();
    }
    //Grid
    protected void BindGvY()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + dlbuyerY.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
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
            ViewState["dtOrderY"] = ds.Tables[0];
            //Search Option-RUS
            GvY.DataSource = ds;
            GvY.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearchY_Click(object sender, EventArgs e)
    {
        DataTable dtOrderY = (DataTable)ViewState["dtOrderY"];
        DataView dvOrderY = dtOrderY.DefaultView;
        dvOrderY.RowFilter = "ord_no like '" + txtSearchY.Text + "%'";

        GvY.DataSource = dvOrderY;
        GvY.DataBind();
    }

    //Search Option-RUS

    //Rowdatabound
    protected void GvY_OnRowDataBound(object sender, GridViewRowEventArgs e)
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
            Label lblyarnbook = (Label)e.Row.FindControl("lblyarnbook");


            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + dlbuyerY.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lblyarnbook.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt5"].ToString();
            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt21"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt22"].ToString();
            lblHeader3.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt23"].ToString();
            lblHeader4.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt24"].ToString();



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


            if (string.IsNullOrEmpty(lblryarnbok.Text.Trim()))
            {
                lblryarnbok.Text = "Not Received";
                lblryarnbok.ForeColor = System.Drawing.Color.Red;
            }

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
                DateTime d1 = DateTime.Parse(lblr2.Text);
                DateTime d2 = Convert.ToDateTime(lbl2.Text);
                int days = (d1 - d2).Days;
                lbld2.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr3.Text.Trim()))
            {
                lblr3.Text = "Not Ok";
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
                DateTime d1 = DateTime.Parse(lblr3.Text);
                DateTime d2 = Convert.ToDateTime(lbl3.Text);
                int days = (d1 - d2).Days;
                lbld3.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr4.Text.Trim()))
            {
                lblr4.Text = "Not Ok";
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
                DateTime d1 = DateTime.Parse(lblr4.Text);
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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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

                if (lblr3.Text.ToString() != "Not Ok")
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

                if (lblr4.Text.ToString() != "Not Ok")
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
    //pageChange
    protected void GvY_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvY.PageIndex = e.NewPageIndex;
        BindGvY();
    }

    #endregion
    #region "Yarn Dyed"
    //Yarn Dyed---------------------------------------------------------------------------------
    //dropdown
    private void BindddlbuyerYD()
    {
        dlbuyerYD.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Hussain") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "Rouf")|| (Session["Username"].ToString() == "Mukter")|| (Session["Username"].ToString() == "Prince"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        dlbuyerYD.DataSource = ds;
        dlbuyerYD.DataTextField = "byr_nm";
        dlbuyerYD.DataValueField = "byr_id";
        dlbuyerYD.DataBind();

        conn.Close();
    }
    //button
    protected void btnfindYD_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl56)*2 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1' AND TnaByrNm = '" + dlbuyerYD.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblydr.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_YarnDyed", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", dlbuyerYD.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedYd"].ToString();
            lblydr2.Text = Red;

        }
        conn.Close();



        //Yellow
        SqlCommand cmdYellow = new SqlCommand("Sp_Red_YarnDyedYlw", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedYdYlw"].ToString();
            lblYlYD.Text = Yellow;

        }

        conn.Close();


        // % of Red 
        lblydr3.Text = ((int.Parse(lblydr2.Text) * 100) / int.Parse(lblydr.Text)).ToString("0");
        lblYlSubYD.Text = ((int.Parse(lblYlYD.Text) * 100) / int.Parse(lblydr.Text)).ToString("0");
        BindGvYD();
    }
    //Grid
    protected void BindGvYD()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND Yd='Y' AND TnaByrNm = '" + dlbuyerYD.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvYD.DataSource = ds;
            GvYD.DataBind();
            int columncount = GvYD.Rows[0].Cells.Count;
            GvYD.Rows[0].Cells.Clear();
            GvYD.Rows[0].Cells.Add(new TableCell());
            GvYD.Rows[0].Cells[0].ColumnSpan = columncount;
            GvYD.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrderYD"] = ds.Tables[0];
            //Search Option-RUS
            GvYD.DataSource = ds;
            GvYD.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearchYD_Click(object sender, EventArgs e)
    {
        DataTable dtOrderYD = (DataTable)ViewState["dtOrderYD"];
        DataView dvOrderYD = dtOrderYD.DefaultView;
        dvOrderYD.RowFilter = "ord_no like '" + txtSearchYD.Text + "%'";

        GvYD.DataSource = dvOrderYD;
        GvYD.DataBind();
    }

    //Search Option-RUS


    //Rowdatabound
    protected void GvYD_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");
            Label yrnInhouseStrt = (Label)e.Row.FindControl("yrnInhouseStrt");
            Label yrnInhouseEnd = (Label)e.Row.FindControl("yrnInhouseEnd");


            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + dlbuyerYD.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            yrnInhouseStrt.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt23"].ToString();
            yrnInhouseEnd.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt24"].ToString();
            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt56"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt57"].ToString();

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label yrnInhouseStrt = (Label)e.Row.FindControl("yrnInhouseStrt");
            Label yrnInhouseEnd = (Label)e.Row.FindControl("yrnInhouseEnd");
            Label lblr1 = (Label)e.Row.FindControl("lblr1");
            Label lblr2 = (Label)e.Row.FindControl("lblr2");
            Label lblr5 = (Label)e.Row.FindControl("lblr5");

            Label lbld1 = (Label)e.Row.FindControl("lbld1");
            Label lbld2 = (Label)e.Row.FindControl("lbld2");


            Label lbl1 = (Label)e.Row.FindControl("lbl1");
            Label lbl2 = (Label)e.Row.FindControl("lbl2");



            if (string.IsNullOrEmpty(yrnInhouseStrt.Text.Trim()))
            {
                yrnInhouseStrt.Text = "Not Started";
                yrnInhouseStrt.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(yrnInhouseEnd.Text.Trim()))
            {
                yrnInhouseEnd.Text = "Not Finished";
                yrnInhouseEnd.ForeColor = System.Drawing.Color.Red;
            }

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
                DateTime d1 = DateTime.Parse(lblr2.Text);
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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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
    //pageChange
    protected void GvYD_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvYD.PageIndex = e.NewPageIndex;
        BindGvYD();
    }

    #endregion
    #region "knitting"
    //Knitting----------------------------------------------------------------------------------

    //dropdown
    private void BindddlbuyerK()
    {
        ddlbuyerK.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "Rouf")|| (Session["Username"].ToString() == "Hussain")|| (Session["Username"].ToString() == "Mukter"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        ddlbuyerK.DataSource = ds;
        ddlbuyerK.DataTextField = "byr_nm";
        ddlbuyerK.DataValueField = "byr_id";
        ddlbuyerK.DataBind();

        conn.Close();
    }
    protected void btnfindK_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl25)*2 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1' AND TnaByrNm = '" + ddlbuyerK.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblrk.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_Knitting", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddlbuyerK.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedKnit"].ToString();
            lblrk2.Text = Red;

        }
        conn.Close();


        //Yellow
        SqlCommand cmdYellow = new SqlCommand("Sp_Red_KnittingYlw", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedKnitYlw"].ToString();
            lblYlK.Text = Yellow;

        }

        conn.Close();


        // % of Red 
        lblrk3.Text = ((int.Parse(lblrk2.Text) * 100) / int.Parse(lblrk.Text)).ToString("0");
        lblYlSubK.Text = ((int.Parse(lblYlK.Text) * 100) / int.Parse(lblrk.Text)).ToString("0");
        BindGvK();
    }
    //Grid
    protected void BindGvK()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + ddlbuyerK.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvK.DataSource = ds;
            GvK.DataBind();
            int columncount = GvK.Rows[0].Cells.Count;
            GvK.Rows[0].Cells.Clear();
            GvK.Rows[0].Cells.Add(new TableCell());
            GvK.Rows[0].Cells[0].ColumnSpan = columncount;
            GvK.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrderK"] = ds.Tables[0];
            //Search Option-RUS
            GvK.DataSource = ds;
            GvK.DataBind();


        }

    }


    //Search Option-RUS
    protected void btnSearchK_Click(object sender, EventArgs e)
    {
        DataTable dtOrderK = (DataTable)ViewState["dtOrderK"];
        DataView dvOrderK = dtOrderK.DefaultView;
        dvOrderK.RowFilter = "ord_no like '" + txtSearchK.Text + "%'";

        GvK.DataSource = dvOrderK;
        GvK.DataBind();
    }

    //Search Option-RUS


    protected void GvK_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");
            Label yrnInhouseStrt = (Label)e.Row.FindControl("yrnInhouseStrt");
            Label yrnInhouseEnd = (Label)e.Row.FindControl("yrnInhouseEnd");


            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddlbuyerK.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            yrnInhouseStrt.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt23"].ToString();
            yrnInhouseEnd.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt24"].ToString();
            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt25"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt26"].ToString();

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label yrnInhouseStrt = (Label)e.Row.FindControl("yrnInhouseStrt");
            Label yrnInhouseEnd = (Label)e.Row.FindControl("yrnInhouseEnd");
            Label lblr1 = (Label)e.Row.FindControl("lblr1");
            Label lblr2 = (Label)e.Row.FindControl("lblr2");
            Label lblr5 = (Label)e.Row.FindControl("lblr5");

            Label lbld1 = (Label)e.Row.FindControl("lbld1");
            Label lbld2 = (Label)e.Row.FindControl("lbld2");

            Label lbl1 = (Label)e.Row.FindControl("lbl1");
            Label lbl2 = (Label)e.Row.FindControl("lbl2");



            if (string.IsNullOrEmpty(yrnInhouseStrt.Text.Trim()))
            {
                yrnInhouseStrt.Text = "Not Started";
                yrnInhouseStrt.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(yrnInhouseEnd.Text.Trim()))
            {
                yrnInhouseEnd.Text = "Not Finished";
                yrnInhouseEnd.ForeColor = System.Drawing.Color.Red;
            }

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
                DateTime d1 = DateTime.Parse(lblr2.Text);
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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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
    //pageChange
    protected void GvK_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvK.PageIndex = e.NewPageIndex;
        BindGvK();
    }

   
    
    #endregion 
    #region "Dyeing "
    //Dyeing-------------------------------------------------------------------------------------
    //dropdown
    private void BindddlbuyerD()
    {
        ddlbuyerD.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "Rouf")|| (Session["Username"].ToString() == "Hussain")|| (Session["Username"].ToString() == "Mukter"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
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
            ViewState["dtOrderD"] = ds.Tables[0];
            //Search Option-RUS
            GvD.DataSource = ds;
            GvD.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearchD_Click(object sender, EventArgs e)
    {
        DataTable dtOrderD = (DataTable)ViewState["dtOrderD"];
        DataView dvOrderD = dtOrderD.DefaultView;
        dvOrderD.RowFilter = "ord_no like '" + txtSearchD.Text + "%'";

        GvD.DataSource = dvOrderD;
        GvD.DataBind();
    }

    //Search Option-RUS


    protected void btnfindD_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl27)*2 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnaByrNm = '" + ddlbuyerD.SelectedItem.Value + "'", conn);
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
        SqlCommand cmdYellow = new SqlCommand("[Sp_Red_DyeingYlw]", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedDyeYlw"].ToString();
            lblYlD.Text = Yellow;

        }

        conn.Close();



        // % of Red 
        lblrdyed3.Text = ((int.Parse(lblrdyed2.Text) * 100) / int.Parse(lblrdyed.Text)).ToString("0");
        lblYlSubD.Text = ((int.Parse(lblYlD.Text) * 100) / int.Parse(lblrdyed.Text)).ToString("0");
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



            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddlbuyerD.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            knitstart.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt25"].ToString();

            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt27"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt28"].ToString();

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label knitstart = (Label)e.Row.FindControl("knitstart");

            Label lblr1 = (Label)e.Row.FindControl("lblr1");
            Label lblr2 = (Label)e.Row.FindControl("lblr2");
            Label lblr5 = (Label)e.Row.FindControl("lblr5");

            Label lbld1 = (Label)e.Row.FindControl("lbld1");
            Label lbld2 = (Label)e.Row.FindControl("lbld2");

            Label lbl1 = (Label)e.Row.FindControl("lbl1");
            Label lbl2 = (Label)e.Row.FindControl("lbl2");

            if (string.IsNullOrEmpty(knitstart.Text.Trim()))
            {
                knitstart.Text = "Not Started";
                knitstart.ForeColor = System.Drawing.Color.Red;
            }


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
                DateTime d1 = DateTime.Parse(lblr2.Text);
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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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
    //pageChange
    protected void GvD_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvD.PageIndex = e.NewPageIndex;
        BindGvD();
    }
    #endregion
    #region "AOP"
    //AOP------------------------------------------------------------------------------------------------
    //doropdown
    private void BindddlbuyerAOP()
    {
        ddlbuyerAOP.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "Rouf")|| (Session["Username"].ToString() == "Hussain")|| (Session["Username"].ToString() == "Mukter"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        ddlbuyerAOP.DataSource = ds;
        ddlbuyerAOP.DataTextField = "byr_nm";
        ddlbuyerAOP.DataValueField = "byr_id";
        ddlbuyerAOP.DataBind();

        conn.Close();
    }
    protected void BindGvAOP()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND Aop='Y' AND TnaByrNm = '" + ddlbuyerAOP.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvAOP.DataSource = ds;
            GvAOP.DataBind();
            int columncount = GvAOP.Rows[0].Cells.Count;
            GvAOP.Rows[0].Cells.Clear();
            GvAOP.Rows[0].Cells.Add(new TableCell());
            GvAOP.Rows[0].Cells[0].ColumnSpan = columncount;
            GvAOP.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrderA"] = ds.Tables[0];
            //Search Option-RUS
            GvAOP.DataSource = ds;
            GvAOP.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearchA_Click(object sender, EventArgs e)
    {
        DataTable dtOrderA = (DataTable)ViewState["dtOrderA"];
        DataView dvOrderA = dtOrderA.DefaultView;
        dvOrderA.RowFilter = "ord_no like '" + txtSearchA.Text + "%'";

        GvAOP.DataSource = dvOrderA;
        GvAOP.DataBind();
    }

    //Search Option-RUS
    protected void btnfindAOP_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl58)*2 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnaByrNm = '" + ddlbuyerAOP.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblraop.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_Aop", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddlbuyerAOP.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedAop"].ToString();
            lblraop2.Text = Red;

        }
        conn.Close();

        //Yellow
        SqlCommand cmdYellow = new SqlCommand("[Sp_Red_AopYlw]", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedAopYlw"].ToString();
            lblYlAop.Text = Yellow;

        }

        conn.Close();



        // % of Red 
        lblraop3.Text = ((int.Parse(lblraop2.Text) * 100) / int.Parse(lblraop.Text)).ToString("0");
        lblSubYlAop.Text = ((int.Parse(lblYlAop.Text) * 100) / int.Parse(lblraop.Text)).ToString("0");
        BindGvAOP();
    }
    protected void GvAOP_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");




            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddlbuyerAOP.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt58"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt59"].ToString();

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
                DateTime d1 = DateTime.Parse(lblr2.Text);
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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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
    //pageChange
    protected void GvAOP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvAOP.PageIndex = e.NewPageIndex;
        BindGvAOP();
    }
    #endregion 
    #region "Accessories"
    //Accessories---------------------------------------------------------------------------------------
    //doropdown
    private void BindddlbuyerAcs()
    {
        ddlbuyerAcs.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "Rouf")|| (Session["Username"].ToString() == "Hussain")|| (Session["Username"].ToString() == "Mukter"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
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
            ViewState["dtOrderAC"] = ds.Tables[0];
            //Search Option-RUS
            GvAcs.DataSource = ds;
            GvAcs.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearchAC_Click(object sender, EventArgs e)
    {
        DataTable dtOrderAC = (DataTable)ViewState["dtOrderAC"];
        DataView dvOrderAC = dtOrderAC.DefaultView;
        dvOrderAC.RowFilter = "ord_no like '" + txtSearchAC.Text + "%'";

        GvAcs.DataSource = dvOrderAC;
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


        //Yellow
        SqlCommand cmdYellow = new SqlCommand("[Sp_Red_AccesYlw]", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedAccesYlw"].ToString();
            lblYlAc.Text = Yellow;

        }

        conn.Close();





        // % of Red 
        lblacs3.Text = ((int.Parse(lblacs2.Text) * 100) / int.Parse(lblacs.Text)).ToString("0");
        lblYlSubAc.Text = ((int.Parse(lblYlAc.Text) * 100) / int.Parse(lblacs.Text)).ToString("0");
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

            if (string.IsNullOrEmpty(lblracsbok.Text.Trim()))
            {
                lblracsbok.Text = "Not Received";
                lblracsbok.ForeColor = System.Drawing.Color.Red;
            }



            //Acc pi and bblc

            if (string.IsNullOrEmpty(lblr60.Text.Trim()))
            {
                lblr60.Text = "Not Ok";
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
                DateTime d1 = DateTime.Parse(lblr60.Text);
                DateTime d2 = Convert.ToDateTime(lbl60.Text);
                int days = (d1 - d2).Days;
                lbld60.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr61.Text.Trim()))
            {
                lblr61.Text = "Not Ok";
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
                DateTime d1 = DateTime.Parse(lblr61.Text);
                DateTime d2 = Convert.ToDateTime(lbl61.Text);
                int days = (d1 - d2).Days;
                lbld61.Text = days.ToString();
                //Delay Days Count

            }

            //Acc pi and bblc


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
                DateTime d1 = DateTime.Parse(lblr2.Text);
                DateTime d2 = Convert.ToDateTime(lbl2.Text);
                int days = (d1 - d2).Days;
                lbld2.Text = days.ToString();
                //Delay Days Count

            }


            // gridview cell hover//
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";

            //Acc pi and bblc

            if (!string.IsNullOrEmpty(lbl60.Text))
            {

                DateTime dt = DateTime.Parse(lbl60.Text);

                if (lblr60.Text.ToString() != "Not Ok")
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


            if (!string.IsNullOrEmpty(lbl61.Text))
            {

                DateTime dt = DateTime.Parse(lbl61.Text);

                if (lblr60.Text.ToString() != "Not Ok")
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

            //Acc pi and bblc

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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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
    //pageChange
    protected void GvAcs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvAcs.PageIndex = e.NewPageIndex;
        BindGvAcs();
    }

    #endregion 
    #region "Inventroy"

    //Inventory---------------------------------------------------------------------------------------
    //doropdown
    private void BindddlbuyerI()
    {
        ddlbuyerI.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "Rouf")|| (Session["Username"].ToString() == "Hussain")|| (Session["Username"].ToString() == "Mukter"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
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
            ViewState["dtOrderI"] = ds.Tables[0];
            //Search Option-RUS
            GvIvn.DataSource = ds;
            GvIvn.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearchI_Click(object sender, EventArgs e)
    {
        DataTable dtOrderI = (DataTable)ViewState["dtOrderI"];
        DataView dvOrderI = dtOrderI.DefaultView;
        dvOrderI.RowFilter = "ord_no like '" + txtSearchI.Text + "%'";

        GvIvn.DataSource = dvOrderI;
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

        //Yellow
        SqlCommand cmdYellow = new SqlCommand("[Sp_Red_InventoryYlw]", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedInventYlw"].ToString();
            lblYlIn.Text = Yellow;

        }

        conn.Close();



        // % of Red 
        lblivn3.Text = ((int.Parse(lblivn2.Text) * 100) / int.Parse(lblivn.Text)).ToString("0");
        lblYlSubIn.Text = ((int.Parse(lblYlIn.Text) * 100) / int.Parse(lblivn.Text)).ToString("0");
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
                DateTime d1 = DateTime.Parse(lblr2.Text);
                DateTime d2 = Convert.ToDateTime(lbl2.Text);
                int days = (d1 - d2).Days;
                lbld2.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr3.Text.Trim()))
            {
                lblr3.Text = "Not Ok";
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
                DateTime d1 = DateTime.Parse(lblr3.Text);
                DateTime d2 = Convert.ToDateTime(lbl3.Text);
                int days = (d1 - d2).Days;
                lbld3.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr4.Text.Trim()))
            {
                lblr4.Text = "Not Ok";
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
                DateTime d1 = DateTime.Parse(lblr4.Text);
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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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

                if (lblr3.Text.ToString() != "Not Ok")
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

                if (lblr4.Text.ToString() != "Not Ok")
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
    //pageChange
    protected void GvIvn_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvIvn.PageIndex = e.NewPageIndex;
        BindGvIvn();
    }
    #endregion 
    #region "print"
    //Print---------------------------------------------------------------------------------------
    //doropdown
    private void BindddlbuyerP()
    {
        ddlbuyerP.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "Rouf")|| (Session["Username"].ToString() == "Shams")|| (Session["Username"].ToString() == "Hussain")|| (Session["Username"].ToString() == "Mukter"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
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
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND Prnt='Y' AND TnaByrNm = '" + ddlbuyerP.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
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
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl38)*2 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnaByrNm = '" + ddlbuyerP.SelectedItem.Value + "'", conn);
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


        //Yellow
        SqlCommand cmdYellow = new SqlCommand("[Sp_Red_PrntYlw]", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedPrntYlw"].ToString();
            lblYlPrnt.Text = Yellow;

        }

        conn.Close();


        // % of Red 
        lblprnt3.Text = ((int.Parse(lblprnt2.Text) * 100) / int.Parse(lblprnt.Text)).ToString("0");
        lblYlSubPrnt.Text = ((int.Parse(lblYlPrnt.Text) * 100) / int.Parse(lblprnt.Text)).ToString("0");
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
                DateTime d1 = DateTime.Parse(lblr2.Text);
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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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
    //pageChange
    protected void GvP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvP.PageIndex = e.NewPageIndex;
        BindGvP();
    }
    #endregion 
    #region "Embroidery"
    //Ebroidery---------------------------------------------------------------------------------------
    //doropdown
    private void BindddlbuyerE()
    {
        ddlbuyerE.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "rouf")|| (Session["Username"].ToString() == "Shams")|| (Session["Username"].ToString() == "Mukter")|| (Session["Username"].ToString() == "Hussain"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        ddlbuyerE.DataSource = ds;
        ddlbuyerE.DataTextField = "byr_nm";
        ddlbuyerE.DataValueField = "byr_id";
        ddlbuyerE.DataBind();

        conn.Close();
    }
    protected void BindGvE()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND Emb='Y' AND TnaByrNm = '" + ddlbuyerE.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvE.DataSource = ds;
            GvE.DataBind();
            int columncount = GvE.Rows[0].Cells.Count;
            GvE.Rows[0].Cells.Clear();
            GvE.Rows[0].Cells.Add(new TableCell());
            GvE.Rows[0].Cells[0].ColumnSpan = columncount;
            GvE.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrderE"] = ds.Tables[0];
            //Search Option-RUS
            GvE.DataSource = ds;
            GvE.DataBind();


        }

    }


    //Search Option-RUS
    protected void btnSearchE_Click(object sender, EventArgs e)
    {
        DataTable dtOrderE = (DataTable)ViewState["dtOrderE"];
        DataView dvOrderE = dtOrderE.DefaultView;
        dvOrderE.RowFilter = "ord_no like '" + txtSearchE.Text + "%'";

        GvE.DataSource = dvOrderE;
        GvE.DataBind();
    }

    //Search Option-RUS




    protected void btnfindE_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl40)*2 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnaByrNm = '" + ddlbuyerE.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblemb.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_Emb", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddlbuyerE.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedEmb"].ToString();
            lblemb2.Text = Red;

        }
        conn.Close();


        //Yellow
        SqlCommand cmdYellow = new SqlCommand("[Sp_Red_EmbYlw]", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedEmbYlw"].ToString();
            lblYlEmb.Text = Yellow;

        }

        conn.Close();


        // % of Red 
        lblemb3.Text = ((int.Parse(lblemb2.Text) * 100) / int.Parse(lblemb.Text)).ToString("0");
        lblYlSubEmb.Text = ((int.Parse(lblYlEmb.Text) * 100) / int.Parse(lblemb.Text)).ToString("0");
        BindGvE();
    }
    protected void GvE_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");





            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddlbuyerE.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt40"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt41"].ToString();

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
                DateTime d1 = DateTime.Parse(lblr2.Text);
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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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
    //pageChange
    protected void GvE_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvE.PageIndex = e.NewPageIndex;
        BindGvE();
    }
    #endregion 
    #region "RMg"

    //RMG---------------------------------------------------------------------------------------
    //doropdown
    private void BindddlbuyerR()
    {
        ddlbuyerR.AppendDataBoundItems = true;
        string sqltext = String.Empty;
        if ((Session["Username"].ToString() == "admin") || (Session["Username"].ToString() == "Uttam") || (Session["Username"].ToString() == "zulfia") || (Session["Username"].ToString() == "rouf") || (Session["Username"].ToString() == "Prince") || (Session["Username"].ToString() == "Shams") || (Session["Username"].ToString() == "Jayanta") || (Session["Username"].ToString() == "Anwar") || (Session["Username"].ToString() == "tajul") || (Session["Username"].ToString() == "Rouf")|| (Session["Username"].ToString() == "Hussain")|| (Session["Username"].ToString() == "Mukter"))
            sqltext = "Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC";
        else
            sqltext = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id";

        SqlCommand Syscmd = new SqlCommand(sqltext, conn);
        Syscmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        ddlbuyerR.DataSource = ds;
        ddlbuyerR.DataTextField = "byr_nm";
        ddlbuyerR.DataValueField = "byr_id";
        ddlbuyerR.DataBind();

        conn.Close();
    }
    protected void BindGvR()
    {
        conn.Open();
        string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + ddlbuyerR.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvR.DataSource = ds;
            GvR.DataBind();
            int columncount = GvR.Rows[0].Cells.Count;
            GvR.Rows[0].Cells.Clear();
            GvR.Rows[0].Cells.Add(new TableCell());
            GvR.Rows[0].Cells[0].ColumnSpan = columncount;
            GvR.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrderRMG"] = ds.Tables[0];
            //Search Option-RUS
            GvR.DataSource = ds;
            GvR.DataBind();


        }

    }

    //Search Option-RUS
    protected void btnSearchRMG_Click(object sender, EventArgs e)
    {
        DataTable dtOrderRMG = (DataTable)ViewState["dtOrderRMG"];
        DataView dvOrderRMG = dtOrderRMG.DefaultView;
        dvOrderRMG.RowFilter = "ord_no like '" + txtSearchRMG.Text + "%'";

        GvR.DataSource = dvOrderRMG;
        GvR.DataBind();
    }

    //Search Option-RUS


    protected void btnfindR_Click(object sender, EventArgs e)
    {
        //Total Job
        conn.Open();
        SqlCommand cmd3 = new SqlCommand("SELECT COUNT (Tnapl38)*17 AS Total FROM View_Tna_Plan WHERE PO_Ship_Date is NULL  AND ActiveOrder='1' AND TnaByrNm = '" + ddlbuyerR.SelectedItem.Value + "'", conn);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        lblrr.Text = ds3.Tables[0].Rows[0]["Total"].ToString();
        cmd3.ExecuteNonQuery();
        conn.Close();

        //Red
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_rmg", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddlbuyerR.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedrmg"].ToString();
            lblrr2.Text = Red;

        }
        conn.Close();


        //Yellow
        SqlCommand cmdYellow = new SqlCommand("[Sp_Red_rmgYlw]", conn);
        cmdYellow.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm2 = cmdYellow.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader rd = cmdYellow.ExecuteReader();
        //string orderlist = "";
        while (rd.Read())
        {
            string Yellow = rd["TtlRedrmgYlw"].ToString();
            lblYlRmg.Text = Yellow;

        }

        conn.Close();



        // % of Red 
        lblrr3.Text = ((int.Parse(lblrr2.Text) * 100) / int.Parse(lblrr.Text)).ToString("0");
        lblYlSubRmg.Text = ((int.Parse(lblYlRmg.Text) * 100) / int.Parse(lblrr.Text)).ToString("0");
        BindGvR();
    }
    protected void GvR_OnRowDataBound(object sender, GridViewRowEventArgs e)
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





            string strSelectCmd = "select * from View_Tna_Plan WHERE TnaByrNm = '" + ddlbuyerR.SelectedItem.Value + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            lblHeader.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt35"].ToString();
            lblHeader2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt36"].ToString();
            lblHeader3.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt37"].ToString();
            lblHeader4.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt42"].ToString();
            lblHeader5.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt43"].ToString();
            lblHeader6.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt44"].ToString();
            lblHeader7.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt45"].ToString();
            lblHeader8.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt46"].ToString();
            lblHeader9.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt47"].ToString();
            lblHeader10.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt48"].ToString();
            lblHeader11.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt49"].ToString();
            lblHeader12.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt50"].ToString();
            lblHeader13.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt51"].ToString();
            lblHeader14.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt52"].ToString();
            lblHeader15.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt53"].ToString();
            lblHeader16.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt54"].ToString();
            lblHeader17.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt55"].ToString();

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
                DateTime d1 = DateTime.Parse(lblr2.Text);
                DateTime d2 = Convert.ToDateTime(lbl2.Text);
                int days = (d1 - d2).Days;
                lbld2.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr3.Text.Trim()))
            {
                lblr3.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr3.Text);
                DateTime d2 = Convert.ToDateTime(lbl3.Text);
                int days = (d1 - d2).Days;
                lbld3.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr4.Text.Trim()))
            {
                lblr4.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr4.Text);
                DateTime d2 = Convert.ToDateTime(lbl4.Text);
                int days = (d1 - d2).Days;
                lbld4.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr5.Text.Trim()))
            {
                lblr5.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr5.Text);
                DateTime d2 = Convert.ToDateTime(lbl5.Text);
                int days = (d1 - d2).Days;
                lbld5.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr6.Text.Trim()))
            {
                lblr6.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr6.Text);
                DateTime d2 = Convert.ToDateTime(lbl6.Text);
                int days = (d1 - d2).Days;
                lbld6.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr7.Text.Trim()))
            {
                lblr7.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr7.Text);
                DateTime d2 = Convert.ToDateTime(lbl7.Text);
                int days = (d1 - d2).Days;
                lbld7.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr8.Text.Trim()))
            {
                lblr8.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr8.Text);
                DateTime d2 = Convert.ToDateTime(lbl8.Text);
                int days = (d1 - d2).Days;
                lbld8.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr9.Text.Trim()))
            {
                lblr9.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr9.Text);
                DateTime d2 = Convert.ToDateTime(lbl9.Text);
                int days = (d1 - d2).Days;
                lbld9.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr10.Text.Trim()))
            {
                lblr10.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr10.Text);
                DateTime d2 = Convert.ToDateTime(lbl10.Text);
                int days = (d1 - d2).Days;
                lbld10.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr11.Text.Trim()))
            {
                lblr11.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr11.Text);
                DateTime d2 = Convert.ToDateTime(lbl11.Text);
                int days = (d1 - d2).Days;
                lbld11.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr12.Text.Trim()))
            {
                lblr12.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr12.Text);
                DateTime d2 = Convert.ToDateTime(lbl12.Text);
                int days = (d1 - d2).Days;
                lbld12.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr13.Text.Trim()))
            {
                lblr13.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr13.Text);
                DateTime d2 = Convert.ToDateTime(lbl13.Text);
                int days = (d1 - d2).Days;
                lbld13.Text = days.ToString();
                //Delay Days Count

            }

            if (string.IsNullOrEmpty(lblr14.Text.Trim()))
            {
                lblr14.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr14.Text);
                DateTime d2 = Convert.ToDateTime(lbl14.Text);
                int days = (d1 - d2).Days;
                lbld14.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr15.Text.Trim()))
            {
                lblr15.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr15.Text);
                DateTime d2 = Convert.ToDateTime(lbl15.Text);
                int days = (d1 - d2).Days;
                lbld15.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr16.Text.Trim()))
            {
                lblr16.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr16.Text);
                DateTime d2 = Convert.ToDateTime(lbl16.Text);
                int days = (d1 - d2).Days;
                lbld16.Text = days.ToString();
                //Delay Days Count

            }
            if (string.IsNullOrEmpty(lblr17.Text.Trim()))
            {
                lblr17.Text = "Not Ok";

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
                DateTime d1 = DateTime.Parse(lblr17.Text);
                DateTime d2 = Convert.ToDateTime(lbl17.Text);
                int days = (d1 - d2).Days;
                lbld17.Text = days.ToString();
                //Delay Days Count

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
            if (!string.IsNullOrEmpty(lbl2.Text))
            {

                DateTime dt = DateTime.Parse(lbl2.Text);

                if (lblr2.Text.ToString() != "Not Ok")
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

                if (lblr3.Text.ToString() != "Not Ok")
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

                if (lblr4.Text.ToString() != "Not Ok")
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

                if (lblr5.Text.ToString() != "Not Ok")
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

                if (lblr6.Text.ToString() != "Not Ok")
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

                if (lblr7.Text.ToString() != "Not Ok")
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

                if (lblr8.Text.ToString() != "Not Ok")
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

                if (lblr9.Text.ToString() != "Not Ok")
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

                if (lblr10.Text.ToString() != "Not Ok")
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

                if (lblr11.Text.ToString() != "Not Ok")
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

                if (lblr12.Text.ToString() != "Not Ok")
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

                if (lblr13.Text.ToString() != "Not Ok")
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

                if (lblr14.Text.ToString() != "Not Ok")
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

                if (lblr15.Text.ToString() != "Not Ok")
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

                if (lblr16.Text.ToString() != "Not Ok")
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

                if (lblr17.Text.ToString() != "Not Ok")
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


        }


    }
    //pageChange
    protected void GvR_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvR.PageIndex = e.NewPageIndex;
        BindGvR();
    }

    #endregion 

    

}
