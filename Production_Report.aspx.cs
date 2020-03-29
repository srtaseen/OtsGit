using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Report : System.Web.UI.Page
{    
    private decimal cutacv;
    private decimal cuttrgt;    
    private decimal expn;
    private int FinishAchv;
    private decimal Finishtrgt;
    private decimal fob;    
    private int hlper;
    private decimal hlpr;
    private decimal hr1;
    private decimal hr10;
    private decimal hr11;
    private decimal hr12;
    private decimal hr2;
    private decimal hr3;
    private decimal hr4;
    private decimal hr5;
    private decimal hr6;
    private decimal hr7;
    private decimal hr8;
    private decimal hr9;
    private decimal hrgr;
    private decimal inptacv;
    private decimal inpttrg;   
    private int mo;
    private decimal Mo;   
    private decimal smvarc;
    private decimal smvtrg;
    private decimal stchacv;
    private decimal stchtrgt;   
    private decimal trgt;
    private decimal ttlfob;

    SqlConnection cn = new SqlConnection(DbSmartCode.x);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindGetFactory();
    }

    private void BindGetFactory()
    {
        using (SqlConnection conn = new SqlConnection(DbSpecFo.x))
        {
            SqlCommand cmd = new SqlCommand("select nCompanyID,cCmpName from Smt_Company", conn);
            drpFactory.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            drpFactory.DataTextField = "cCmpName";
            drpFactory.DataValueField = "nCompanyID";
            drpFactory.DataSource = rdr;
            drpFactory.DataBind();
        }
    }

    protected void btnsrc_Click(object sender, EventArgs e)
    {
        
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Sp_rsHrsProdcutionReport '" + this.txtDate.Text + "','" + this.drpFactory.SelectedValue + "'", cn);
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

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        margePORaise(this.GridView1);
    }

     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label label = (Label)e.Row.FindControl("lbllineid");
            SqlDataAdapter adapter = new SqlDataAdapter("Sp_rsHrsProdcutionReport1 '" + this.txtDate.Text + "'," + this.drpFactory.SelectedValue + "," + label.Text.Trim(), this.cn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            string str = "0";
            if (dataTable.Rows.Count > 0)
            {
                str = dataTable.Rows[0]["shortqty"].ToString();
                e.Row.Cells[21].Text = str;
            }
            string str2 = e.Row.Cells[8].Text.Trim();
            if (!string.IsNullOrEmpty(str2))
            {
                this.hr1 += decimal.Parse(str2);
            }
            string str3 = e.Row.Cells[9].Text.Trim();
            if (!string.IsNullOrEmpty(str3))
            {
                this.hr2 += decimal.Parse(str3);
            }
            string str4 = e.Row.Cells[10].Text.Trim();
            if (!string.IsNullOrEmpty(str4))
            {
                this.hr3 += decimal.Parse(str4);
            }
            string str5 = e.Row.Cells[11].Text.Trim();
            if (!string.IsNullOrEmpty(str5))
            {
                this.hr4 += decimal.Parse(str5);
            }
            string str6 = e.Row.Cells[12].Text.Trim();
            if (!string.IsNullOrEmpty(str6))
            {
                this.hr5 += decimal.Parse(str6);
            }
            string str7 = e.Row.Cells[13].Text.Trim();
            if (!string.IsNullOrEmpty(str7))
            {
                this.hr6 += decimal.Parse(str7);
            }
            string str8 = e.Row.Cells[14].Text.Trim();
            if (!string.IsNullOrEmpty(str8))
            {
                this.hr7 += decimal.Parse(str8);
            }
            string str9 = e.Row.Cells[15].Text.Trim();
            if (!string.IsNullOrEmpty(str9))
            {
                this.hr8 += decimal.Parse(str9);
            }
            string str10 = e.Row.Cells[16].Text.Trim();
            if (!string.IsNullOrEmpty(str10))
            {
                this.hr9 += decimal.Parse(str10);
            }
            string str11 = e.Row.Cells[0x11].Text.Trim();
            if (!string.IsNullOrEmpty(str11))
            {
                this.hr10 += decimal.Parse(str11);
            }
            string str12 = e.Row.Cells[0x12].Text.Trim();
            if (!string.IsNullOrEmpty(str12))
            {
                this.hr11 += decimal.Parse(str12);
            }
            string str13 = e.Row.Cells[0x13].Text.Trim();
            if (!string.IsNullOrEmpty(str13))
            {
                this.hr12 += decimal.Parse(str13);
            }
            string str14 = e.Row.Cells[1].Text.Trim();
            if (!string.IsNullOrEmpty(str14))
            {
                this.Mo += decimal.Parse(str14);
            }
            string str15 = e.Row.Cells[2].Text.Trim();
            if (!string.IsNullOrEmpty(str15))
            {
                this.hlpr += decimal.Parse(str15);
            }
            string str16 = e.Row.Cells[7].Text.Trim();
            if (!string.IsNullOrEmpty(str16))
            {
                this.trgt += decimal.Parse(str16);
            }
            string str17 = e.Row.Cells[21].Text.Trim();
            if (!string.IsNullOrEmpty(str17))
            {
                this.expn += decimal.Parse(str17);
            }
            string str18 = e.Row.Cells[0x16].Text.Trim();
            if (!string.IsNullOrEmpty(str18))
            {
                this.ttlfob += decimal.Parse(str18);
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[8].Text = this.hr1.ToString();
            e.Row.Cells[9].Text = this.hr2.ToString();
            e.Row.Cells[10].Text = this.hr3.ToString();
            e.Row.Cells[11].Text = this.hr4.ToString();
            e.Row.Cells[12].Text = this.hr5.ToString();
            e.Row.Cells[13].Text = this.hr6.ToString();
            e.Row.Cells[14].Text = this.hr7.ToString();
            e.Row.Cells[15].Text = this.hr8.ToString();
            e.Row.Cells[16].Text = this.hr9.ToString();
            e.Row.Cells[0x11].Text = this.hr10.ToString();
            e.Row.Cells[0x12].Text = this.hr11.ToString();
            e.Row.Cells[0x13].Text = this.hr12.ToString();
            e.Row.Cells[0x14].Text = (((((((((((this.hr1 + this.hr2) + this.hr3) + this.hr4) + this.hr5) + this.hr6) + this.hr7) + this.hr8) + this.hr9) + this.hr10) + this.hr11) + this.hr12).ToString();
            e.Row.Cells[21].Text = this.expn.ToString();
            e.Row.Cells[0x16].Text = this.ttlfob.ToString();
            SqlDataAdapter adapter2 = new SqlDataAdapter("Hourlyrpt_getftr '" + this.txtDate.Text + "'," + this.drpFactory.SelectedValue, this.cn);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            if (table2.Rows.Count > 0)
            {
                e.Row.Cells[1].Text = table2.Rows[0]["nMo"].ToString();
                e.Row.Cells[2].Text = table2.Rows[0]["nHP"].ToString();
                e.Row.Cells[7].Text = table2.Rows[0]["DTgt"].ToString();
            }
        }
    }

     public static void margePORaise(GridView gridView)
     {
         for (int i = gridView.Rows.Count - 2; i >= 0; i--)
         {
             GridViewRow row = gridView.Rows[i];
             GridViewRow row2 = gridView.Rows[i + 1];
             if (row.Cells[0].Text == row2.Cells[0].Text)
             {
                 row.Cells[0].RowSpan = (row2.Cells[0].RowSpan < 2) ? 2 : (row2.Cells[0].RowSpan + 1);
                 row2.Cells[0].Visible = false;
                 row.Cells[1].RowSpan = (row2.Cells[1].RowSpan < 2) ? 2 : (row2.Cells[1].RowSpan + 1);
                 row2.Cells[1].Visible = false;
                 row.Cells[2].RowSpan = (row2.Cells[2].RowSpan < 2) ? 2 : (row2.Cells[2].RowSpan + 1);
                 row2.Cells[2].Visible = false;
                 row.Cells[6].RowSpan = (row2.Cells[6].RowSpan < 2) ? 2 : (row2.Cells[6].RowSpan + 1);
                 row2.Cells[6].Visible = false;
                 row.Cells[20].RowSpan = (row2.Cells[20].RowSpan < 2) ? 2 : (row2.Cells[20].RowSpan + 1);
                 row2.Cells[20].Visible = false;
             }
         }
     }

}