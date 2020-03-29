using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HP4_Report : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);

    
    private decimal target_hr;
    private decimal plan_hr;
    private decimal target_dy;
    

    private decimal h1;
    private decimal h10;
    private decimal h11;
    private decimal h12;
    private decimal h2;
    private decimal h3;
    private decimal h4;
    private decimal h5;
    private decimal h6;
    private decimal h7;
    private decimal h8;
    private decimal h9;
    private string ord_no;
    private string po;
    protected void Page_Load(object sender, EventArgs e)
    {
         if(!IsPostBack)
            BindGetFactory();
    }

    private void BindGetFactory()
    {
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("Select Fact_id,Fact_nm from Factory_Tab", conn);
            drpFactory.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            drpFactory.DataTextField = "Fact_nm";
            drpFactory.DataValueField = "Fact_id";
            drpFactory.DataSource = rdr;
            drpFactory.DataBind();
        }
    }

    protected void btnsrc_Click(object sender, EventArgs e)
    {
        //Label label = (Label)base.Master.FindControl("lbltotalinfo");
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Sp_SrchHrlyProductionReport4 '" + this.txtDate.Text + "','" + this.drpFactory.SelectedItem.Text + "'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            //label.Text = "No Line Found";
            if (this.GridView1.Rows.Count > 0)
            {
                //label.Text = "";
            }
        }
        catch (Exception exception)
        {
            string s = exception.Message;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label label = (Label)e.Row.FindControl("lbllineid");
        //    SqlDataAdapter adapter = new SqlDataAdapter("Sp_SrchHrlyProductionReport4 '" + this.txtDate.Text + "'," + this.drpFactory.SelectedValue + "," + label.Text.Trim(), conn);
        //    DataTable dataTable = new DataTable();
        //    adapter.Fill(dataTable);
        //    string str = "0";
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        str = dataTable.Rows[0]["shortqty"].ToString();
        //        e.Row.Cells[21].Text = str;
        //    }
        //    string str2 = e.Row.Cells[3].Text.Trim();
        //    if (!string.IsNullOrEmpty(str2))
        //    {
        //        h1 += decimal.Parse(str2);
        //    }
        //    string str3 = e.Row.Cells[4].Text.Trim();
        //    if (!string.IsNullOrEmpty(str3))
        //    {
        //        h2 += decimal.Parse(str3);
        //    }
        //    string str4 = e.Row.Cells[5].Text.Trim();
        //    if (!string.IsNullOrEmpty(str4))
        //    {
        //        h3 += decimal.Parse(str4);
        //    }
        //    string str5 = e.Row.Cells[6].Text.Trim();
        //    if (!string.IsNullOrEmpty(str5))
        //    {
        //        h4 += decimal.Parse(str5);
        //    }
        //    string str6 = e.Row.Cells[7].Text.Trim();
        //    if (!string.IsNullOrEmpty(str6))
        //    {
        //        h5 += decimal.Parse(str6);
        //    }
        //    string str7 = e.Row.Cells[8].Text.Trim();
        //    if (!string.IsNullOrEmpty(str7))
        //    {
        //        h6 += decimal.Parse(str7);
        //    }
        //    string str8 = e.Row.Cells[9].Text.Trim();
        //    if (!string.IsNullOrEmpty(str8))
        //    {
        //        h7 += decimal.Parse(str8);
        //    }
        //    string str9 = e.Row.Cells[10].Text.Trim();
        //    if (!string.IsNullOrEmpty(str9))
        //    {
        //        h8 += decimal.Parse(str9);
        //    }
        //    string str10 = e.Row.Cells[11].Text.Trim();
        //    if (!string.IsNullOrEmpty(str10))
        //    {
        //        h9 += decimal.Parse(str10);
        //    }
        //    string str11 = e.Row.Cells[12].Text.Trim();
        //    if (!string.IsNullOrEmpty(str11))
        //    {
        //        h10 += decimal.Parse(str11);
        //    }
        //    string str12 = e.Row.Cells[13].Text.Trim();
        //    if (!string.IsNullOrEmpty(str12))
        //    {
        //        h11 += decimal.Parse(str12);
        //    }
        //    string str13 = e.Row.Cells[14].Text.Trim();
        //    if (!string.IsNullOrEmpty(str13))
        //    {
        //        h12 += decimal.Parse(str13);
        //    }
        //    string str14 = e.Row.Cells[1].Text.Trim();
        //    if (!string.IsNullOrEmpty(str14))
        //    {
        //        ord_no += decimal.Parse(str14);
        //    }
        //    string str15 = e.Row.Cells[2].Text.Trim();
        //    if (!string.IsNullOrEmpty(str15))
        //    {
        //        po += decimal.Parse(str15);
        //    }
        //    string str16 = e.Row.Cells[15].Text.Trim();
        //    if (!string.IsNullOrEmpty(str16))
        //    {
        //        target_hr += decimal.Parse(str15);
        //    }
        //    //string str17 = e.Row.Cells[21].Text.Trim();
        //    //if (!string.IsNullOrEmpty(str17))
        //    //{
        //    //    expn += decimal.Parse(str17);
        //    //}
        //    //string str18 = e.Row.Cells[0x15].Text.Trim();
        //    //if (!string.IsNullOrEmpty(str18))
        //    //{
        //    //    this.ttlfob += decimal.Parse(str18);
        //    //}
        //}
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    e.Row.Cells[3].Text = this.h1.ToString();
        //    e.Row.Cells[4].Text = this.h2.ToString();
        //    e.Row.Cells[5].Text = this.h3.ToString();
        //    e.Row.Cells[6].Text = this.h4.ToString();
        //    e.Row.Cells[7].Text = this.h5.ToString();
        //    e.Row.Cells[8].Text = this.h6.ToString();
        //    e.Row.Cells[9].Text = this.h7.ToString();
        //    e.Row.Cells[10].Text = this.h8.ToString();
        //    e.Row.Cells[11].Text = this.h9.ToString();
        //    e.Row.Cells[12].Text = this.h10.ToString();
        //    e.Row.Cells[13].Text = this.h11.ToString();
        //    e.Row.Cells[14].Text = this.h12.ToString();
        //    e.Row.Cells[15].Text = (((((((((((this.h1 + this.h2) + this.h3) + this.h4) + this.h5) + this.h6) + this.h7) + this.h8) + this.h9) + this.h10) + this.h11) + this.h12).ToString();
        //    //e.Row.Cells[20].Text = this.expn.ToString();
        //    //e.Row.Cells[0x15].Text = this.ttlfob.ToString();
        //    //SqlDataAdapter adapter2 = new SqlDataAdapter("Hourlyrpt_getftr '" + this.txtDate.Text + "'," + this.drpFactory.SelectedValue, conn);
        //    //DataTable table2 = new DataTable();
        //    //adapter2.Fill(table2);
        //    //if (table2.Rows.Count > 0)
        //    //{
        //    //    e.Row.Cells[1].Text = table2.Rows[0]["nMo"].ToString();
        //    //    e.Row.Cells[2].Text = table2.Rows[0]["nHP"].ToString();
        //    //    e.Row.Cells[6].Text = table2.Rows[0]["DTgt"].ToString();
        //    //}
        //}
		
		
		
		if (e.Row.RowType == DataControlRowType.DataRow)
        {


            int h1 = int.Parse(e.Row.Cells[4].Text);
            int h2 = int.Parse(e.Row.Cells[5].Text);
            int h3 = int.Parse(e.Row.Cells[6].Text);
            int h4 = int.Parse(e.Row.Cells[7].Text);
            int h5 = int.Parse(e.Row.Cells[8].Text);
            int h6 = int.Parse(e.Row.Cells[9].Text);
            int h7 = int.Parse(e.Row.Cells[10].Text);
            int h8 = int.Parse(e.Row.Cells[11].Text);
            int h9 = int.Parse(e.Row.Cells[12].Text);
            int h10 = int.Parse(e.Row.Cells[13].Text);
            int h11 = int.Parse(e.Row.Cells[14].Text);
            int h12 = int.Parse(e.Row.Cells[15].Text);

            int tgt = int.Parse(e.Row.Cells[16].Text);

            foreach (TableCell cell in e.Row.Cells)
            {
                if (h1 < tgt)
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
                }
                if (h2 < tgt)
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                }
                if (h3 < tgt)
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[6].ForeColor = System.Drawing.Color.White;
                }
                if (h4 < tgt)
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                }
                if (h5 < tgt)
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
                }
                if (h6 < tgt)
                {
                    e.Row.Cells[9].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[9].ForeColor = System.Drawing.Color.White;
                }
                if (h7 < tgt)
                {
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                }
                if (h8 < tgt)
                {
                    e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[11].ForeColor = System.Drawing.Color.White;
                }
                if (h9 < tgt)
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[12].ForeColor = System.Drawing.Color.White;
                }
                if (h10 < tgt)
                {
                    e.Row.Cells[13].BackColor = System.Drawing.Color.Red;
					e.Row.Cells[13].ForeColor = System.Drawing.Color.White;
                }
                
            }
        }
    }
}