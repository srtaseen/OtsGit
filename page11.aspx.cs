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
            //BindGrid();
            BindGridView1();
           
        }

    }
    private void BindGridView1()
    {
      
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM View_UserStatus"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGridView1();
    }

    protected void OnRowCancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGridView1();
    }
    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Get the GridView Row.
        GridViewRow row = GridView1.Rows[e.RowIndex];

        //Get the HobbyId from the DataKey property.
        int UserId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

        //Get the checked value of the CheckBoxField column.
        bool UsrStatus = (row.Cells[0].Controls[0] as CheckBox).Checked;

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Users SET [UsrStatus] = @UsrStatus WHERE UserId=@UserId";
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@UsrStatus", UsrStatus);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        GridView1.EditIndex = -1;
        this.BindGridView1();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

        Label lbldeleteid = (Label)row.FindControl("lblID");
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete FROM Users where UserId='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        BindGridView1();
        Response.Redirect("~/Page11.aspx");

    }
}