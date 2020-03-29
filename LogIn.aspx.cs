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

public partial class _LogIn : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        // Stop Caching in Firefox
        Response.Cache.SetNoStore();
        // Stop Caching in IE
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

        if (!IsPostBack)
        {
           
          


        }

    }
    //protected void BtnLogin_Click(object sender, EventArgs e)
    //{
    //Session["Username"] = Txt1.Text.ToString();
    //Session["usrnm"] = lb3.Text.ToString();
    //int userId = 0;
    //using (SqlConnection conn = new SqlConnection(DbConnect.x))
    //{
    //    using (SqlCommand cmd = new SqlCommand("Validate_User"))
    //    {
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@Username", Txt1.Text.Trim());
    //        cmd.Parameters.AddWithValue("@Password", Txt2.Text.Trim());
    //        cmd.Connection = conn;
    //        conn.Open();
    //        userId = Convert.ToInt32(cmd.ExecuteScalar());
    //        conn.Close();
    //    }
   
    //    switch (userId)
    //    {
    //        case -1:
    //            lb1.Text = "Invalid User name or Password";
    //            break;

    //        default:
  
    //             Response.Redirect("page2.aspx");
    //            break;
    //    }
    //}


        
    //}


    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        Session["Username"] = Txt1.Text.ToString();
        Session["usrnm"] = lb3.Text.ToString();
        int userId = 0;
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            if (((this.Session["Username"].ToString() == "md") || (this.Session["Username"].ToString() == "MD")) || (this.Session["Username"].ToString() == "zulfia") || (this.Session["Username"].ToString() == "ZULFIA") || (this.Session["Username"].ToString() == "mursalin") || (this.Session["Username"].ToString() == "MURSALIN") || (this.Session["Username"].ToString() == "moon") || (this.Session["Username"].ToString() == "MOON") || (this.Session["Username"].ToString() == "rajiv") || (this.Session["Username"].ToString() == "RAJIV") || (this.Session["Username"].ToString() == "imam") || (this.Session["Username"].ToString() == "IMAM") || (this.Session["Username"].ToString() == "nasif") || (this.Session["Username"].ToString() == "NASIF") || (this.Session["Username"].ToString() == "rajiv-aldi") || (this.Session["Username"].ToString() == "Rajiv-Aldi") || (this.Session["Username"].ToString() == "shamim") || (this.Session["Username"].ToString() == "SHAMIM") || (this.Session["Username"].ToString() == "smiqbal") || (this.Session["Username"].ToString() == "SMIQBAL")) 
            {
                base.Response.Redirect("Dashboard.aspx");
            }
			else if ((this.Session["Username"].ToString() == "admin"))
            {
                base.Response.Redirect("PFHome.aspx");
            }
            else { 
            using (SqlCommand cmd = new SqlCommand("Validate_User"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Txt1.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", Txt2.Text.Trim());
                cmd.Connection = conn;
                conn.Open();
                userId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }

            switch (userId)
            {
                case -1:
                    lb1.Text = "Invalid User name or Password";
                    break;

                default:

                    Response.Redirect("page2.aspx");
                    break;
            }

           
        }



    }
}
}