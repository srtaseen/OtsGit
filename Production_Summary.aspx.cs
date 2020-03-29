using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Summary : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(DbSmartCode.x);
    SqlConnection conn = new SqlConnection(DbSpecFo.x);


    private decimal cutacv;
    private decimal cuttrgt;
    //protected DropDownList drpcompany;
    private decimal expn;
    private int FinishAchv;
    private decimal Finishtrgt;
    private decimal fob;
    //protected GridView GridView1;
    //protected GridView GridView2;
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
    //protected Label Label5;
    private int mo;
    private decimal Mo;
    private decimal smvarc;
    private decimal smvtrg;
    private decimal stchacv;
    private decimal stchtrgt;
    //protected Timer Timer1;
    private decimal trgt;
    private decimal ttlfob;


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsrcrmg_Click(object sender, EventArgs e)
    {
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Sp_rsWebGroupSummary '" + this.txtDate.Text + "'", cn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.GridView2.DataSource = dt;
            this.GridView2.DataBind();
            //label.Text = "No Line Found";
            if (this.GridView2.Rows.Count > 0)
            {
                //label.Text = "";
            }
        }
        catch (Exception exception)
        {
            string s = exception.Message;
        }
    }


    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label label = (Label)e.Row.FindControl("lblCompid");
            //DataTable table = this._bl.get_InformationdataTable("select cCmpName from Smt_Company where nCompanyID=" + label.Text.Trim());

            SqlDataAdapter adapter = new SqlDataAdapter("select cCmpName from Smt_Company where nCompanyID=" + label.Text.Trim(), this.conn);
            DataTable table = new DataTable();
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                Label label2 = (Label)e.Row.FindControl("lblcompname");
                label2.Text = table.Rows[0]["cCmpName"].ToString();
            }
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView view1 = (GridView)sender;
            GridViewRow child = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell = new TableCell
            {
                Text = "Company",
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 1
            };
            child.Cells.Add(cell);
            cell = new TableCell
            {
                Text = "CUTTING",
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };
            child.Cells.Add(cell);
            cell = new TableCell
            {
                Text = "INPUT",
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };
            child.Cells.Add(cell);
            cell = new TableCell
            {
                Text = "STITCHING",
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };
            child.Cells.Add(cell);
            //cell = new TableCell
            //{
            //    Text = "SMV",
            //    HorizontalAlign = HorizontalAlign.Center,
            //    ColumnSpan = 2
            //};
            //child.Cells.Add(cell);
            cell = new TableCell
            {
                Text = "FINISH GOODS",
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };
            child.Cells.Add(cell);
            cell = new TableCell
            {
                Text = "OTHERS",
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 3
            };
            child.Cells.Add(cell);
            this.GridView2.Controls[0].Controls.AddAt(0, child);
        }

    }




    //test for Auto sum

    //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label label = (Label)e.Row.FindControl("lblCompid");
    //        //DataTable table = this._bl.get_InformationdataTable("select cCmpName from Smt_Company where nCompanyID=" + label.Text.Trim());

    //        SqlDataAdapter adapter = new SqlDataAdapter("select cCmpName from Smt_Company where nCompanyID=" + label.Text.Trim(), this.conn);
    //        DataTable table = new DataTable();
    //        adapter.Fill(table);
    //        if (table.Rows.Count > 0)
    //        {
    //            Label label2 = (Label)e.Row.FindControl("lblcompname");
    //            label2.Text = table.Rows[0]["cCmpName"].ToString();

    //            string str = e.Row.Cells[2].Text.Trim();
    //            if (!string.IsNullOrEmpty(str))
    //            {
    //                this.cuttrgt += decimal.Parse(str);
    //            }
    //            string str2 = e.Row.Cells[1].Text.Trim();
    //            if (!string.IsNullOrEmpty(str2))
    //            {
    //                this.cutacv += decimal.Parse(str2);
    //            }
    //            string str3 = e.Row.Cells[4].Text.Trim();
    //            if (!string.IsNullOrEmpty(str3))
    //            {
    //                this.inptacv += decimal.Parse(str3);
    //            }
    //            string str4 = e.Row.Cells[3].Text.Trim();
    //            if (!string.IsNullOrEmpty(str4))
    //            {
    //                this.inpttrg += decimal.Parse(str4);
    //            }
    //            string str5 = e.Row.Cells[5].Text.Trim();
    //            if (!string.IsNullOrEmpty(str5))
    //            {
    //                this.stchtrgt += decimal.Parse(str5);
    //            }
    //            string str6 = e.Row.Cells[6].Text.Trim();
    //            if (!string.IsNullOrEmpty(str6))
    //            {
    //                this.stchacv += decimal.Parse(str6);
    //            }
    //            string str7 = e.Row.Cells[7].Text.Trim();
    //            if (!string.IsNullOrEmpty(str7))
    //            {
    //                this.smvtrg += decimal.Parse(str7);
    //            }
    //            string str8 = e.Row.Cells[8].Text.Trim();
    //            if (!string.IsNullOrEmpty(str8))
    //            {
    //                this.smvarc += decimal.Parse(str8);
    //            }
    //            string str9 = e.Row.Cells[9].Text.Trim();
    //            if (!string.IsNullOrEmpty(str9))
    //            {
    //                this.Finishtrgt += decimal.Parse(str9);
    //            }
    //            string str10 = e.Row.Cells[10].Text.Trim();
    //            if (!string.IsNullOrEmpty(str10))
    //            {
    //                this.FinishAchv += int.Parse(str10);
    //            }
    //            string str11 = e.Row.Cells[13].Text.Trim();
    //            if (!string.IsNullOrEmpty(str11))
    //            {
    //                this.hlper += int.Parse(str11);
    //            }
    //            string str12 = e.Row.Cells[12].Text.Trim();
    //            if (!string.IsNullOrEmpty(str12))
    //            {
    //                this.mo += int.Parse(str12);
    //            }
    //            string str13 = e.Row.Cells[11].Text.Trim();
    //            if (!string.IsNullOrEmpty(str13))
    //            {
    //                this.fob += int.Parse(str13);
    //            }
    //        }
    //    }
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        e.Row.Cells[2].Text = this.cuttrgt.ToString();
    //        e.Row.Cells[1].Text = this.cutacv.ToString();
    //        e.Row.Cells[4].Text = this.inptacv.ToString();
    //        e.Row.Cells[3].Text = this.inpttrg.ToString();
    //        e.Row.Cells[5].Text = this.stchtrgt.ToString();
    //        e.Row.Cells[6].Text = this.stchacv.ToString();
    //        e.Row.Cells[7].Text = this.smvtrg.ToString();
    //        e.Row.Cells[8].Text = this.smvarc.ToString();
    //        e.Row.Cells[9].Text = this.Finishtrgt.ToString();
    //        e.Row.Cells[10].Text = this.FinishAchv.ToString();
    //        e.Row.Cells[11].Text = this.fob.ToString();
    //        e.Row.Cells[12].Text = this.mo.ToString();
    //        e.Row.Cells[13].Text = this.hlper.ToString();
    //    }
    //    if (e.Row.RowType == DataControlRowType.Header)
    //    {
    //        GridView view1 = (GridView)sender;
    //        GridViewRow child = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
    //        TableCell cell = new TableCell
    //        {
    //            Text = "Company",
    //            HorizontalAlign = HorizontalAlign.Center,
    //            ColumnSpan = 1
    //        };
    //        child.Cells.Add(cell);
    //        cell = new TableCell
    //        {
    //            Text = "CUTTING",
    //            HorizontalAlign = HorizontalAlign.Center,
    //            ColumnSpan = 2
    //        };
    //        child.Cells.Add(cell);
    //        cell = new TableCell
    //        {
    //            Text = "INPUT",
    //            HorizontalAlign = HorizontalAlign.Center,
    //            ColumnSpan = 2
    //        };
    //        child.Cells.Add(cell);
    //        cell = new TableCell
    //        {
    //            Text = "STITCHING",
    //            HorizontalAlign = HorizontalAlign.Center,
    //            ColumnSpan = 2
    //        };
    //        child.Cells.Add(cell);
    //        cell = new TableCell
    //        {
    //            Text = "SMV",
    //            HorizontalAlign = HorizontalAlign.Center,
    //            ColumnSpan = 2
    //        };
    //        child.Cells.Add(cell);
    //        cell = new TableCell
    //        {
    //            Text = "FINISH GOODS",
    //            HorizontalAlign = HorizontalAlign.Center,
    //            ColumnSpan = 2
    //        };
    //        child.Cells.Add(cell);
    //        cell = new TableCell
    //        {
    //            Text = "OTHERS",
    //            HorizontalAlign = HorizontalAlign.Center,
    //            ColumnSpan = 3
    //        };
    //        child.Cells.Add(cell);
    //        this.GridView2.Controls[0].Controls.AddAt(0, child);
    //    }
    //}

    //public static void margePORaise(GridView gridView)
    //{
    //    for (int i = gridView.Rows.Count - 2; i >= 0; i--)
    //    {
    //        GridViewRow row = gridView.Rows[i];
    //        GridViewRow row2 = gridView.Rows[i + 1];
    //        if (row.Cells[0].Text == row2.Cells[0].Text)
    //        {
    //            row.Cells[0].RowSpan = (row2.Cells[0].RowSpan < 2) ? 2 : (row2.Cells[0].RowSpan + 1);
    //            row2.Cells[0].Visible = false;
    //            row.Cells[1].RowSpan = (row2.Cells[1].RowSpan < 2) ? 2 : (row2.Cells[1].RowSpan + 1);
    //            row2.Cells[1].Visible = false;
    //            row.Cells[2].RowSpan = (row2.Cells[2].RowSpan < 2) ? 2 : (row2.Cells[2].RowSpan + 1);
    //            row2.Cells[2].Visible = false;
    //            row.Cells[6].RowSpan = (row2.Cells[6].RowSpan < 2) ? 2 : (row2.Cells[6].RowSpan + 1);
    //            row2.Cells[6].Visible = false;
    //            row.Cells[20].RowSpan = (row2.Cells[20].RowSpan < 2) ? 2 : (row2.Cells[20].RowSpan + 1);
    //            row2.Cells[20].Visible = false;
    //        }
    //    }
    //}


}