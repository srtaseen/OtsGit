using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

public partial class Page9 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("LogIn.aspx", false);
            return;
        }
       
        if (!IsPostBack)
        {
        
        }
        SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "'and (UsrDpt='9' OR UsrDpt='5' OR UsrDpt='10' OR UsrDpt='14' OR UsrGroup='1') and frmnam7 = 'Page15.aspx'  ", conn);
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

  
    
}