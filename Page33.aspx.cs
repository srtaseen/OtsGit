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
       
        if (!IsPostBack)
        {
        
        }
    }



    protected void btnrpt_Click(object sender, EventArgs e)
    {
        Session["dt1"] = txt1.Text;
        Session["dt2"] = txt2.Text;

        string url = "reportsaspx/ReportYarnstatus.aspx";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

    }
}