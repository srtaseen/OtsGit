using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
           
            ln.Text = "" + Session["Username"].ToString();
           
            conn.Open();
            string str = "select * FROM View_UserStatus WHERE Username= '" + ln.Text.ToString() + "'";
            SqlCommand com = new SqlCommand(str, conn);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                ln2.Text = reader["usrnm"].ToString();

                ln3.Text = reader["dpt_nm"].ToString();
                ln4.Text = reader["Email"].ToString();
                ln5.Text = reader["Fact_nm"].ToString();
                ln6.Text = reader["CreateDate"].ToString();
                //l9.Text = reader["UsrStatus"].ToString();
                //l5.Text = reader["LastLoginDate"].ToString();
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
        if (!IsPostBack)
        {
           
            
        }
    }

}
