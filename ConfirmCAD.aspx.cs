using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ConfirmCAD : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindGvorder();
            BindGvorder2();
            Bindgvcancle();
            //this.ordid1.Visible = false;
            //this.Div3.Visible = true;
            //BindGvorder2();
            //Bindgvcancle();


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
   

    protected void FunctionA_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl); //page refreash
    }
    protected void BindGvorder()
    {

        string strSelectCmd = @" select p.pCADId,b.ord_no,b.art_no,b.art_qty,b.byr_nm,b.bCADCons,p.pCADCons,b.bCADDia,p.pCADDia,b.bCADGsm,p.pCADGsm,p.cadApproved,p.cadCanceled from tblBookCAD b 
				join tblProdCAD p on b.ord_no=p.ord_no and b.art_no=p.art_no
				where p.cadApproved is null and p.cadCanceled is null";
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
                btncancle.Text = "Cancel";
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
        SqlCommand Syscmd = new SqlCommand("update tblProdCAD set cadApproved='" + DateTime.Now + "' where pCADId=" + lblapprove.Text + " ", conn);
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
        SqlCommand Syscmd = new SqlCommand("update tblProdCAD set cadCanceled='" + DateTime.Now + "' where pCADId=" + lblapprove.Text + " ", conn);
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
        SqlCommand Syscmd = new SqlCommand("update tblProdCAD set cadRework='" + DateTime.Now + "' ,cadCanceled = NULL where pCADId=" + lblrework.Text + " ", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();
        conn.Close();
        btnact.Text = DateTime.Now.ToString();
        btnact.Enabled = false;


        //btnact.Text = "OK";
    }
   
    protected void Gvorder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvorder.PageIndex = e.NewPageIndex;
        BindGvorder();
    }

    protected void BindGvorder2()
    {

        string strSelectCmd = @" select p.pCADId,b.ord_no,b.art_no,b.art_qty,b.byr_nm,b.bCADCons,p.pCADCons,b.bCADDia,p.pCADDia,b.bCADGsm,p.pCADGsm,p.cadApproved,p.cadCanceled from tblBookCAD b 
                                join tblProdCAD p on b.ord_no = p.ord_no and b.art_no = p.art_no
                                where p.cadApproved is not null ";
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

    protected void Gvorder2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvorder2.PageIndex = e.NewPageIndex;
        BindGvorder2();
    }

    protected void Bindgvcancle()
    {

        string strSelectCmd = @" select p.pCADId,b.ord_no,b.art_no,b.art_qty,b.byr_nm,b.bCADCons,p.pCADCons,b.bCADDia,p.pCADDia,b.bCADGsm,p.pCADGsm,p.cadApproved,p.cadCanceled,p.cadRework from tblBookCAD b 
                                join tblProdCAD p on b.ord_no = p.ord_no and b.art_no = p.art_no
                                where p.cadCanceled is not null ";
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

    protected void gvcancle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvcancle.PageIndex = e.NewPageIndex;
        Bindgvcancle();
    }


}