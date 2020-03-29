using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Page4_ : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Username"] == null)
        //{
        //    Response.Redirect("LogIn.aspx", false);
        //    return;
        //}
        if (!IsPostBack)
        {
           //BindGvorderSum();
           
        }

    }
    //protected void GvorderSum_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    //if (e.Row.RowType == DataControlRowType.DataRow)
    //    //{
    //    //    e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();


    //    //}
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes.Add("onmouseover", "this.setAttribute('bgColor', this.style.backgroundColor); this.style.backgroundColor = '#CBFF97';");
    //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.getAttribute('bgColor');");
    //        e.Row.Attributes.Add("style", "cursor:pointer;");
    //    }


    //}
    //protected void BindGvorderSum()
    //{

    //    conn.Open();
    //    string strSelectCmd = "Select DISTINCT byr_nm,SUM(Totalprice) as TPRC, SUM(po_quantity) as TQTY FROM View_OrderInhand  where po_xfactory Between '" + Session["dt1"].ToString() + "'  AND '" + Session["dt2"].ToString() + "' GROUP BY byr_nm ";
    //    SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);

    //    //SqlCommand Syscmd = new SqlCommand("Sp_PriceANDQuantityTotal", conn);
    //    //Syscmd.CommandType = CommandType.StoredProcedure;

    //    //SqlDataAdapter da = new SqlDataAdapter(Syscmd);
    //    //DataSet ds = new DataSet();
    //    //da.Fill(ds);



    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
    //        GvorderSum.DataSource = ds;
    //        GvorderSum.DataBind();
    //        int columncount = GvorderSum.Rows[0].Cells.Count;
    //        GvorderSum.Rows[0].Cells.Clear();
    //        GvorderSum.Rows[0].Cells.Add(new TableCell());
    //        GvorderSum.Rows[0].Cells[0].ColumnSpan = columncount;
    //        GvorderSum.Rows[0].Cells[0].Text = "Note:-Please Select Buyer, Form Date and To Date. Then Click Find";


    //    }
    //    else
    //    {
    //        GvorderSum.DataSource = ds;
    //        GvorderSum.DataBind();
    //    }



    //}
}