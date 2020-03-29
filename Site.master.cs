using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            //lb2.Text = " Session was created successfully by";
            lb4.Text = "" + Session["Username"].ToString();
            //lblid.Text = "" + Session["Username"].ToString();
        }
        else
        {
            //lb3.Text = "session was not created";

        }

    }
    //protected void FunctionD_ServerClick(object sender, EventArgs e)
    //{
    //    Session.Abandon();
    //    Session.Clear();
    //    Session.Contents.RemoveAll();
    //    Response.Redirect("~/LogIn.aspx");
    //}
}
