using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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
          Bindddl();
          Binddl();
          Bindd2();
          Bindd3();
          this.l2.Enabled = false;
          this.l3.Enabled = false;
          this.l4.Visible = true;
          this.d1.Visible = false;
          this.d2.Visible = false;
          this.d3.Visible = false;
          this.btnedit.Enabled = false;
          this.btnup.Enabled = false;
          //this.btnedit.Visible = false;
        
           
        }

    }
    private void Bindddl()
    {
        ddl.AppendDataBoundItems = true;
        conn.Open();

        SqlCommand Syscmd = new SqlCommand("Select Username,UserId FROM Users where UsrApprove is NOT NULL order by Username ASC", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddl.DataSource = ds;
        ddl.DataTextField = "Username";
        ddl.DataValueField = "UserId";
        ddl.DataBind();

        conn.Close();
    }
    private void Binddl()
    {
        d1.AppendDataBoundItems = true;
        conn.Open();

        SqlCommand Syscmd = new SqlCommand("select * FROM DeptTab", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        d1.DataSource = ds;
        d1.DataTextField = "dpt_nm";
        d1.DataValueField = "dpt_id";
        d1.DataBind();

        conn.Close();
    }
    private void Bindd2()
    {
        d2.AppendDataBoundItems = true;
        conn.Open();

        SqlCommand Syscmd = new SqlCommand("select * FROM Buyer_Tab", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        d2.DataSource = ds;
        d2.DataTextField = "byr_nm";
        d2.DataValueField = "byr_id";
        d2.DataBind();

        conn.Close();
    }
    private void Bindd3()
    {
        d3.AppendDataBoundItems = true;
        conn.Open();

        SqlCommand Syscmd = new SqlCommand("select * FROM Tbl_UsrGroup", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        d3.DataSource = ds;
        d3.DataTextField = "UsrGName";
        d3.DataValueField = "UsrGID";
        d3.DataBind();

        conn.Close();
    }
    
    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.btnedit.Enabled = true;
        this.btnup.Enabled = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        conn.Open();
        string str = "select * FROM View_UserStatus WHERE Username= '" + ddl.SelectedItem + "'";
        SqlCommand com = new SqlCommand(str, conn);
        SqlDataReader reader = com.ExecuteReader();
        if (reader.Read())
        {
            l1.Text = reader["Username"].ToString();
            l2.Text = reader["usrnm"].ToString();
            l3.Text = reader["Password"].ToString();
            //d1.Items.Add(reader["dpt_nm"].ToString());
            l4.Text = reader["dpt_nm"].ToString();
            l7.Text = reader["Email"].ToString();
            l6.Text = reader["Fact_nm"].ToString();
            l12.Text = reader["UsrGName"].ToString();
            l8.Text = reader["CreateDate"].ToString();
            l9.Text = reader["UsrStatus"].ToString();
            l5.Text = reader["LastLoginDate"].ToString();
            l11.Text = reader["byr_nm"].ToString();
            
            //this.btnedit.Visible = true;
            //if (l9.Text == ("false"))
            //{
            //    l10.Text = "ACTIVE";
            //}
            //else
            //{
            //    //l10.Visible = false;
            //}
            reader.Close();

            
            conn.Close();
           

        }
        
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
       
            this.l2.Enabled = true;
            this.l3.Enabled = true;
            this.l4.Visible = false;
            this.l11.Visible = false;
            this.l12.Visible = false;
            this.d1.Visible = true;
            this.d2.Visible = true;
            this.d3.Visible = true;
       
    }
    protected void btnup_Click(object sender, EventArgs e)
    {

        SqlCommand Syscmd = new SqlCommand("update View_UserStatus set Password='" + l3.Text.ToString() + "', UsrDpt='" + d1.SelectedValue + "',UsrGroup='" + d3.SelectedValue + "',UsrTyp='" + d2.SelectedValue+ "' WHERE Username='" + l1.Text + "'", conn);
        Syscmd.CommandType = CommandType.Text;
        Syscmd.Connection = conn;
        conn.Open();
        Syscmd.ExecuteNonQuery();

        conn.Close();
        Response.Redirect(Request.RawUrl);
    }
    protected void btncncl_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}