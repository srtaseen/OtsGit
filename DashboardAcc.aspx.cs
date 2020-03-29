using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class DashboardAcc : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!Page.IsPostBack)
        //{
        //    Response.AddHeader("Refresh", "10");
        //}










    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //Red All
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_AccesDX", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedAccesDX"].ToString();
            lblRed.Text = Red;

        }

        conn.Close();



        //Red Merchandiser
        SqlCommand StoredProcedureCommandM = new SqlCommand("Sp_Red_OnlyAccDX", conn);
        StoredProcedureCommandM.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daM = StoredProcedureCommandM.ExecuteReader();
        //string orderlist = "";
        while (daM.Read())
        {
            string Red = daM["TtlRedAccOnly"].ToString();
            lblRedAp.Text = Red;

        }

        conn.Close();






        //Red Yarn
        SqlCommand StoredProcedureCmdYarn = new SqlCommand("Sp_Red_OnlyCommDX", conn);
        StoredProcedureCmdYarn.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daYarn = StoredProcedureCmdYarn.ExecuteReader();
        //string orderlist = "";
        while (daYarn.Read())
        {
            string Red = daYarn["TtlRedCommOnly"].ToString();
            lblRedAc.Text = Red;

        }
        //daYarn.Close();
        conn.Close();
        //// % of Red 
        ////lblRedY3.Text = ((int.Parse(lblRedY2.Text) * 100) / int.Parse(lblRedY1.Text)).ToString("0");
    }


      
}