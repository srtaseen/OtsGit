using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.IO.Compression;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindddl();

        }

    }
    private void bindddl()
    {
        ddl.AppendDataBoundItems = true;
        conn.Open();

        SqlCommand Syscmd = new SqlCommand("Select Username FROM Users where UsrApprove ='1' order by Username ASC", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddl.DataSource = ds;
        ddl.DataTextField = "Username";
        //ddl.DataValueField = "UserId";
        ddl.DataBind();

        conn.Close();
    }
    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSelectCmd = "select * from TblFormNameByUsr where FrmUsr ='" + ddl.SelectedItem.Text + "' ";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        lb1.Text = ds.Tables[0].Rows[0]["frmnam1"].ToString();
        lb2.Text = ds.Tables[0].Rows[0]["frmnam2"].ToString();
        lb3.Text = ds.Tables[0].Rows[0]["frmnam3"].ToString();
        lb4.Text = ds.Tables[0].Rows[0]["frmnam4"].ToString();
        lb5.Text = ds.Tables[0].Rows[0]["frmnam5"].ToString();
        lb6.Text = ds.Tables[0].Rows[0]["frmnam6"].ToString();
        lb7.Text = ds.Tables[0].Rows[0]["frmnam7"].ToString();
        lb8.Text = ds.Tables[0].Rows[0]["frmnam8"].ToString();
        lb9.Text = ds.Tables[0].Rows[0]["frmnam9"].ToString();
        lb10.Text = ds.Tables[0].Rows[0]["frmnam10"].ToString();
        lb11.Text = ds.Tables[0].Rows[0]["frmnam11"].ToString();
        lb12.Text = ds.Tables[0].Rows[0]["frmnam12"].ToString();
        lb13.Text = ds.Tables[0].Rows[0]["frmnam13"].ToString();
        lb14.Text = ds.Tables[0].Rows[0]["frmnam14"].ToString();
        lb15.Text = ds.Tables[0].Rows[0]["frmnam15"].ToString();
        lb16.Text = ds.Tables[0].Rows[0]["frmnam16"].ToString();
        lb17.Text = ds.Tables[0].Rows[0]["frmnam17"].ToString();
        

        if (!string.IsNullOrEmpty(lb1.Text.Trim()))
        {
            cb1.Checked = true;

        }
        if (!string.IsNullOrEmpty(lb2.Text.Trim()))
        {
            cb11.Checked = true;
        }
        if (!string.IsNullOrEmpty(lb3.Text.Trim()))
        {
            cb12.Checked = true;


        }
        if (!string.IsNullOrEmpty(lb4.Text.Trim()))
        {
            cb13.Checked = true;
        }
        if (!string.IsNullOrEmpty(lb5.Text.Trim()))
        {
            cb14.Checked = true;


        }
        if (!string.IsNullOrEmpty(lb6.Text.Trim()))
        {
            cb15.Checked = true;
        }
        if (!string.IsNullOrEmpty(lb7.Text.Trim()))
        {
            cb2.Checked = true;


        }
        if (!string.IsNullOrEmpty(lb8.Text.Trim()))
        {
            cb21.Checked = true;
        }
        if (!string.IsNullOrEmpty(lb9.Text.Trim()))
        {
            cb22.Checked = true;


        }
        if (!string.IsNullOrEmpty(lb10.Text.Trim()))
        {
            cb23.Checked = true;
        }
        if (!string.IsNullOrEmpty(lb11.Text.Trim()))
        {
            cb24.Checked = true;


        }
        if (!string.IsNullOrEmpty(lb12.Text.Trim()))
        {
            cb25.Checked = true;
        }
        if (!string.IsNullOrEmpty(lb13.Text.Trim()))
        {
            cb3.Checked = true;


        }
        if (!string.IsNullOrEmpty(lb14.Text.Trim()))
        {
            cb4.Checked = true;
        }
        if (!string.IsNullOrEmpty(lb15.Text.Trim()))
        {
            cb5.Checked = true;


        }
        if (!string.IsNullOrEmpty(lb16.Text.Trim()))
        {
            cb6.Checked = true;
        }
        if (!string.IsNullOrEmpty(lb17.Text.Trim()))
        {
            cb7.Checked = true;


        }
        

        //Button Condition
        lblb1.Text = ds.Tables[0].Rows[0]["Btn1"].ToString();
        lblb2.Text = ds.Tables[0].Rows[0]["Btn2"].ToString();
        lblb3.Text = ds.Tables[0].Rows[0]["Btn3"].ToString();
        lblb4.Text = ds.Tables[0].Rows[0]["Btn4"].ToString();
        lblb5.Text = ds.Tables[0].Rows[0]["Btn5"].ToString();
        lblb6.Text = ds.Tables[0].Rows[0]["Btn6"].ToString();
        lblb8.Text = ds.Tables[0].Rows[0]["Btn7"].ToString();
        lblb10.Text = ds.Tables[0].Rows[0]["Btn8"].ToString();
       
        if (!string.IsNullOrEmpty(lblb1.Text.Trim()))
        {
            cb111.Checked = true;
        }
        if (!string.IsNullOrEmpty(lblb2.Text.Trim()))
        {
            cb112.Checked = true;
        }
        if (!string.IsNullOrEmpty(lblb3.Text.Trim()))
        {
            cb113.Checked = true;
        }
        if (!string.IsNullOrEmpty(lblb4.Text.Trim()))
        {
            cb114.Checked = true;
        }
        if (!string.IsNullOrEmpty(lblb5.Text.Trim()))
        {
            cb115.Checked = true;
        }
        if (!string.IsNullOrEmpty(lblb6.Text.Trim()))
        {
            cb1111.Checked = true;
        }
        if (!string.IsNullOrEmpty(lblb8.Text.Trim()))
        {
            cb1113.Checked = true;
        }
        if (!string.IsNullOrEmpty(lblb10.Text.Trim()))
        {
            cb1115.Checked = true;
        }
       
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        string ck1 = cb1.Checked ? "Page5.aspx" : "";
        string ck2 = cb11.Checked ? "page3.aspx" : "";
        string ck3 = cb12.Checked ? "Page30.aspx" : "";
        string ck4 = cb13.Checked ? "Page7.aspx" : "";
        string ck5 = cb14.Checked ? "Page8.aspx" : "";
        string ck6 = cb15.Checked ? "Page31.aspx" : "";
        string ck7 = cb2.Checked ? "Page15.aspx" : "";
        string ck8 = cb21.Checked ? "Page16.aspx" : "";
        string ck9 = cb22.Checked ? "Page17.aspx" : "";
        string ck10 = cb23.Checked ? "Page21.aspx" : "";
        string ck11 = cb24.Checked ? "Page22.aspx" : "";
        string ck12 = cb25.Checked ? "Page23.aspx" : "";
        string ck13 = cb3.Checked ? "Page25.aspx" : "";
        string ck14 = cb4.Checked ? "Page26.aspx" : "";
        string ck15 = cb5.Checked ? "Page24.aspx" : "";
        string ck16 = cb6.Checked ? "Page18.aspx" : "";
        string ck17 = cb7.Checked ? "Page9.aspx" : "";


        //Button ID 
        string cbx1 = cb111.Checked ? "Btnsave" : "";  //Order Schedule Show
        string cbx2 = cb112.Checked ? "BtnNewWindo" : "";  //order master edit
        string cbx3 = cb113.Checked ? "TnALoad" : ""; //Order position Show
        string cbx4 = cb114.Checked ? "btnapprove" : "";  //T&A create Load
        string cbx5 = cb115.Checked ? "BtnTnARelod" : "";  //T&A Approved Load
        string cbx6 = cb1111.Checked ? "BtnNewWindo" : ""; //T&A Reload 
        string cbx7 = cb1113.Checked ? "BtnCustom" : ""; //T&A load customize
        string cbx8 = cb1115.Checked ? "btnmenual" : ""; //T&A Reload customize
  

        SqlCommand Syscmd = new SqlCommand();
        Syscmd.CommandType = CommandType.StoredProcedure;
        Syscmd.CommandText = "SpFormNameByUsr";

        Syscmd.Parameters.AddWithValue("@FrmUsr", ddl.SelectedValue);  //Page insrt
        Syscmd.Parameters.AddWithValue("@frmnam1", ck1);
        Syscmd.Parameters.AddWithValue("@frmnam2", ck2);
        Syscmd.Parameters.AddWithValue("@frmnam3", ck3);
        Syscmd.Parameters.AddWithValue("@frmnam4", ck4);
        Syscmd.Parameters.AddWithValue("@frmnam5", ck5);
        Syscmd.Parameters.AddWithValue("@frmnam6", ck6);
        Syscmd.Parameters.AddWithValue("@frmnam7", ck7);
        Syscmd.Parameters.AddWithValue("@frmnam8", ck8);
        Syscmd.Parameters.AddWithValue("@frmnam9", ck9);
        Syscmd.Parameters.AddWithValue("@frmnam10", ck10);
        Syscmd.Parameters.AddWithValue("@frmnam11", ck11);
        Syscmd.Parameters.AddWithValue("@frmnam12", ck12);
        Syscmd.Parameters.AddWithValue("@frmnam13", ck13);
        Syscmd.Parameters.AddWithValue("@frmnam14", ck14);
        Syscmd.Parameters.AddWithValue("@frmnam15", ck15);
        Syscmd.Parameters.AddWithValue("@frmnam16", ck16);
        Syscmd.Parameters.AddWithValue("@frmnam17", ck17);


        Syscmd.Parameters.AddWithValue("@Btn1", cbx1); //Button Inert
        Syscmd.Parameters.AddWithValue("@Btn2", cbx2);
        Syscmd.Parameters.AddWithValue("@Btn3", cbx3);
        Syscmd.Parameters.AddWithValue("@Btn4", cbx4);
        Syscmd.Parameters.AddWithValue("@Btn5", cbx5);
        Syscmd.Parameters.AddWithValue("@Btn6", cbx6);
        Syscmd.Parameters.AddWithValue("@Btn7", cbx7);
        Syscmd.Parameters.AddWithValue("@Btn8", cbx8);


        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();
        conn.Close();

        Response.Redirect(Request.RawUrl); //page refreash 

    }
    protected void BtnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}
