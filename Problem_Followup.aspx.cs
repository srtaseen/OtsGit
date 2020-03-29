using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Collections;

public partial class Problem_Followup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindGetDpt();
            BindGetCat();
        }
            
    }

    private void BindGetDpt()
    {

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("Select dpt_id, dpt_nm FROM DeptTab", conn);
            GetDpt.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GetDpt.DataTextField = "dpt_nm";
            GetDpt.DataValueField = "dpt_id";
            GetDpt.DataSource = rdr;
            GetDpt.DataBind();
            conn.Close();
        }
    }

    private void BindGetCat()
    {

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("Select cid, cname FROM tbl_Category", conn);
            GetCat.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GetCat.DataTextField = "cname";
            GetCat.DataValueField = "cid";
            GetCat.DataSource = rdr;
            GetCat.DataBind();
            conn.Close();
        }
    }

    protected void Btnsave_Click1(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        SqlCommand Syscmd = new SqlCommand();
        Syscmd.CommandType = CommandType.StoredProcedure;
        Syscmd.CommandText = "Problem_Followup_Data";



        Syscmd.Parameters.AddWithValue("@dpt_nm", GetDpt.SelectedItem.Text.Trim());
        Syscmd.Parameters.AddWithValue("@cat_nm", GetCat.SelectedItem.Text.Trim());
        Syscmd.Parameters.AddWithValue("@problemdesc", txtDes.Text.Trim());
        Syscmd.Parameters.AddWithValue("@responsible", txtRes.Text.Trim());
        Syscmd.Parameters.AddWithValue("@plandt", entdt.Text.Trim());

        Syscmd.Connection = conn;
        conn.Open();

        Syscmd.ExecuteNonQuery();

        conn.Close();

        Response.Redirect(Request.RawUrl); //page refreash
    }
}