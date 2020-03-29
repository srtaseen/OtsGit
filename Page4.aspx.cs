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
    private static int PageSize = 5;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindddstyle();
        }

    }
    private void Bindddstyle()
    {
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("Select DISTINCT ord_no FROM PO_Master", conn);
            ddstyle.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            ddstyle.DataTextField = "ord_no";
            //ddstyle.DataValueField = "byr_id";
            ddstyle.DataSource = rdr;
            ddstyle.DataBind();
        }
        
    }
    protected void btnfindOrdEdit_Click(object sender, EventArgs e)
    {
        Bindgvedit();
        //this.div8.Visible = true;

    }

    protected void Bindgvedit()
    {


        conn.Open();
        SqlCommand cmd = new SqlCommand("select * FROM View_PO_Buyer WHERE ord_no = '" + ddstyle.SelectedItem.Text + "' ", conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvedit.DataSource = ds;
            gvedit.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gvedit.DataSource = ds;
            gvedit.DataBind();
            int columncount = gvedit.Rows[0].Cells.Count;
            gvedit.Rows[0].Cells.Clear();
            gvedit.Rows[0].Cells.Add(new TableCell());
            gvedit.Rows[0].Cells[0].ColumnSpan = columncount;
            gvedit.Rows[0].Cells[0].Text = "No Records Found";
        }



    }
    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvedit.EditIndex = e.NewEditIndex;
        this.Bindgvedit();
    }

    protected void gvedit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int po = Convert.ToInt32(gvedit.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)gvedit.Rows[e.RowIndex];
        //Label lblID = (Label)row.FindControl("lblID");

        TextBox txtpono = (TextBox)row.FindControl("txtpono");
        TextBox txtquantity = (TextBox)row.FindControl("txtquantity");
        TextBox textprice = (TextBox)row.FindControl("textprice");
        TextBox texttprice = (TextBox)row.FindControl("texttprice");
        //TextBox textsmv = (TextBox)row.FindControl("textsmv");
        gvedit.EditIndex = -1;
        conn.Open();
        //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);
        SqlCommand cmd = new SqlCommand("update PO_Master set po_no='" + txtpono.Text + "',po_quantity='" + txtquantity.Text + "',po_price='" + textprice.Text + "',Totalprice='" + texttprice.Text + "' where po_id='" + po + "'", conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        Bindgvedit();
    }

    protected void gvedit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvedit.EditIndex = -1;
        Bindgvedit();
    }


    protected void gvedit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvedit.PageIndex = e.NewPageIndex;
        Bindgvedit();
    }
}