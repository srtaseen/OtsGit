using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Page8 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            Bindddbuyer();
            BindGvorder2();
            //this.ordid1.Visible = false;
            //this.Div3.Visible = true;
            //BindGvorder2();
            Bindgvcancle();

            
        }
        //Page permission
        SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "' and (UsrDpt='6' OR UsrGroup='1') and frmnam5 = 'Page8.aspx'", conn);
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
    private void Bindddbuyer()
    {

        conn.Open();

        SqlCommand Syscmd = new SqlCommand("Select DISTINCT byr_id, byr_nm FROM View_User_ScreenPer  WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddbuyer.DataSource = ds;
        ddbuyer.DataTextField = "byr_nm";
        ddbuyer.DataValueField = "byr_id";
        ddbuyer.DataBind();

        conn.Close();

    }
    protected void btnchk_Click(object sender, EventArgs e)
    {
        BindGvorder();
        //this.ordid1.Visible = true;

    }
   
    protected void FunctionA_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl); //page refreash
    }
    protected void BindGvorder()
    {

        string strSelectCmd = " select * FROM View_PO_Buyer WHERE byr_nm = '" + ddbuyer.SelectedItem.Text + "' AND ActiveOrder='1' AND Po_ShipDate IS NULL AND TnAapproved IS NULL AND TnaCancle IS NULL AND TnaCreateDate IS NOT NULL order by TnaCreateDate DESC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);


        //conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            Gvorder.DataSource = ds;
            Gvorder.DataBind();
            int columncount = Gvorder.Rows[0].Cells.Count;
            Gvorder.Rows[0].Cells.Clear();
            Gvorder.Rows[0].Cells.Add(new TableCell());
            Gvorder.Rows[0].Cells[0].ColumnSpan = columncount;
            Gvorder.Rows[0].Cells[0].Text = "No Order has pending for approval";


        }
        else
        {

            Gvorder.DataSource = ds;
            Gvorder.DataBind();
        }


    }
    protected void Gvorder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Button btnapprove = (Button)e.Row.FindControl("btnapprove");
            Button btncancle = (Button)e.Row.FindControl("btncancle");


            if (string.IsNullOrEmpty(btnapprove.Text.Trim()))
            {
                btnapprove.Text = "Approve";
                btnapprove.Enabled = true;


            }
            if (string.IsNullOrEmpty(btncancle.Text.Trim()))
            {
                btncancle.Text = "Cancle";
                btncancle.Enabled = true;


            }



            //btn permission 
            SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "' and (UsrDpt='6' OR UsrGroup='1') AND btn5='btnapprove' ", conn);
            command.Connection.Open();
            SqlDataReader rdr = command.ExecuteReader();

            if (rdr.HasRows)
            {

                btnapprove.Enabled = true;
                btncancle.Enabled = true;

            }
            else
            {
                btnapprove.Enabled = false;
                btncancle.Enabled = false;


            }

            conn.Close();



        }
    }
    protected void btnapprove_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnapprove");


        Label lblapprove = (Label)row.FindControl("lblapprove");
        SqlCommand Syscmd = new SqlCommand("update PO_Master set TnAapproved='" + DateTime.Now + "' where po_id=" + lblapprove.Text + " ", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();
        conn.Close();
        btnact.Text = DateTime.Now.ToString();
        btnact.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btncancle_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btncan = (Button)row.FindControl("btncancle");

        Label lblapprove = (Label)row.FindControl("lblapprove");
        SqlCommand Syscmd = new SqlCommand("update PO_Master set TnaCancle='" + DateTime.Now + "' where po_id=" + lblapprove.Text + " ", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();
        conn.Close();
        btncan.Text = DateTime.Now.ToString();
        btncan.Enabled = false;

        //btnact.Text = "OK";
    }
    protected void btnrework_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
        Button btnact = (Button)row.FindControl("btnrework");


        Label lblrework = (Label)row.FindControl("lblrework");
        SqlCommand Syscmd = new SqlCommand("update PO_Master set TnaRework='" + DateTime.Now + "' ,TnaCreateDate = NULL where po_id=" + lblrework.Text + " ", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();
        conn.Close();
        btnact.Text = DateTime.Now.ToString();
        btnact.Enabled = false;


        //btnact.Text = "OK";
    }
    protected void BindGvorder2()
    {

        string strSelectCmd = " select * FROM View_PO_Buyer WHERE ActiveOrder='1' AND Po_ShipDate IS NULL AND TnAapproved IS NOT NULL order by TnAapproved DESC ";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);

        //conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            Gvorder2.DataSource = ds;
            Gvorder2.DataBind();
            int columncount = Gvorder2.Rows[0].Cells.Count;
            Gvorder2.Rows[0].Cells.Clear();
            Gvorder2.Rows[0].Cells.Add(new TableCell());
            Gvorder2.Rows[0].Cells[0].ColumnSpan = columncount;
            Gvorder2.Rows[0].Cells[0].Text = "";


        }
        else
        {

            Gvorder2.DataSource = ds;
            Gvorder2.DataBind();
        }


    }

    protected void Bindgvcancle()
    {

        string strSelectCmd = " select * FROM View_PO_Buyer WHERE  ActiveOrder='1' AND Po_ShipDate IS NULL AND TnaCancle IS NOT NULL order by TnaCancle DESC ";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);

        //conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gvcancle.DataSource = ds;
            gvcancle.DataBind();
            int columncount = gvcancle.Rows[0].Cells.Count;
            gvcancle.Rows[0].Cells.Clear();
            gvcancle.Rows[0].Cells.Add(new TableCell());
            gvcancle.Rows[0].Cells[0].ColumnSpan = columncount;
            gvcancle.Rows[0].Cells[0].Text = "";


        }
        else
        {

            gvcancle.DataSource = ds;
            gvcancle.DataBind();
        }


    }
    protected void gvcancle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            Button btnrework = (Button)e.Row.FindControl("btnrework");


            if (string.IsNullOrEmpty(btnrework.Text.Trim()))
            {
                btnrework.Text = "Permit";
                btnrework.Enabled = true;


            }



            //btn permission 
            SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "' and (UsrDpt='6' OR UsrGroup='1') AND btn5='btnapprove' ", conn);
            command.Connection.Open();
            SqlDataReader rdr = command.ExecuteReader();

            if (rdr.HasRows)
            {


                btnrework.Enabled = true;
            }
            else
            {

                btnrework.Enabled = false;

            }

            conn.Close();



        }
    }
    protected void Gvorder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvorder.PageIndex = e.NewPageIndex;
        BindGvorder();
    }
    protected void Gvorder2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvorder2.PageIndex = e.NewPageIndex;
        BindGvorder2();
    }
    protected void gvcancle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvcancle.PageIndex = e.NewPageIndex;
        Bindgvcancle();
    }

}