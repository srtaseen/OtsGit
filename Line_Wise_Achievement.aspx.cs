using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;


public partial class Line_Wise_Achievement : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(DbSmartCode.x);

    private decimal ttlP;
    private int m;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            BindGetFactory();
            //GetChartTypes();
        }
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
            SqlDataAdapter adapter = new SqlDataAdapter("Sp_LineWiseAchievement '" + this.txtFromDate.Text + "','" + this.txtToDate.Text + "','" + this.drpFactory.SelectedValue + "'", cn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            GetChartTypes(dt);
            Chart1.Visible = true;

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
        
    }


    //Chart Control
    private void GetChartTypes(DataTable dt)
    {
//        string sql = @"select pbl.aLine,
//            cast(round(cast(sum(pbl.aHrTotal) as decimal)/ cast((select SUM(LDayTgt) from Smt_LineDetail where LDate between '2016-12-03' and '2016-12-08' and LLineID=pbl.aLineID  and LMo is not null group by LLineID) as decimal) * 100,2) as numeric(36,2)) as Achievement 
//            from Hrs_ProductionByLine pbl left join
//            Smt_LineDetail sld on pbl.aDate=sld.LDate and pbl.aLineID=sld.LLineID left join
//            Smt_LcSupervisor slc on pbl.aLine=slc.aLine
//            where aStage='SEWING QC OUT' and aDate between '2016-12-03' and '2016-12-08' and aCompanyID=6
//            group by pbl.aLine,pbl.aLineID,slc.LCSV";
//        SqlCommand adapter = new SqlCommand(sql, cn);
//        cn.Open();
//        SqlDataReader rdr = adapter.ExecuteReader();
        //DataTable dt = new DataTable();
        //adapter.Fill(dt);
        //Chart1.DataBindTable(rdr, "aLine");
        //cn.Close();

        Chart1.Series["Series1"].XValueMember = "aLine";
        Chart1.Series["Series1"].YValueMembers = "Achievement";
        //Chart1.Series["Series1"].Label = "#PERCENT{P0}";
        Chart1.DataSource = dt;
        Chart1.DataBind();
       
    }

    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //this.Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(
    //    //    typeof(SeriesChartType), DropDownList1.SelectedValue);
    //}

    //Chart Control
}
