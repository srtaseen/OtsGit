using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class DashboardYlw : System.Web.UI.Page
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
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_AllYlwDX", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRedAllYlwDX"].ToString();
            lblRed.Text = Red;

        }

        conn.Close();



        //Red Merchandiser
        SqlCommand StoredProcedureCommandM = new SqlCommand("Sp_Red_MerchandisngMYlwDX", conn);
        StoredProcedureCommandM.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daM = StoredProcedureCommandM.ExecuteReader();
        //string orderlist = "";
        while (daM.Read())
        {
            string Red = daM["TtlRedMerYlwDX"].ToString();
            lblRedM.Text = Red;

        }

        conn.Close();






        //Red Yarn
        SqlCommand StoredProcedureCmdYarn = new SqlCommand("Sp_Red_YarnYlwDX", conn);
        StoredProcedureCmdYarn.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daYarn = StoredProcedureCmdYarn.ExecuteReader();
        //string orderlist = "";
        while (daYarn.Read())
        {
            string Red = daYarn["TtlRedYarnYlwDX"].ToString();
            lblRedY2.Text = Red;

        }
        //daYarn.Close();
        conn.Close();
        //// % of Red 
        ////lblRedY3.Text = ((int.Parse(lblRedY2.Text) * 100) / int.Parse(lblRedY1.Text)).ToString("0");



        //Red Yarn Dyeing
        SqlCommand StoredProcedureCommandYD = new SqlCommand("Sp_Red_YarnDyedYlwDX", conn);
        StoredProcedureCommandYD.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daYD = StoredProcedureCommandYD.ExecuteReader();
        //string orderlist = "";
        while (daYD.Read())
        {
            string Red = daYD["TtlRedYdYlwDX"].ToString();
            lblRedYD.Text = Red;

        }

        conn.Close();


        //Red knitting
        SqlCommand StoredProcedureCommandK = new SqlCommand("Sp_Red_KnittingYlwDX", conn);
        StoredProcedureCommandK.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daK = StoredProcedureCommandK.ExecuteReader();
        //string orderlist = "";
        while (daK.Read())
        {
            string Red = daK["TtlRedKnitYlwDX"].ToString();
            lblRedK.Text = Red;

        }

        conn.Close();


        //Red Dyeing
        SqlCommand StoredProcedureCommandD = new SqlCommand("Sp_Red_DyeingYlwDX", conn);
        StoredProcedureCommandD.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daD = StoredProcedureCommandD.ExecuteReader();
        //string orderlist = "";
        while (daD.Read())
        {
            string Red = daD["TtlRedDyeYlwDX"].ToString();
            lblRedD.Text = Red;

        }

        conn.Close();


        //Red AOP
        SqlCommand StoredProcedureCommandA = new SqlCommand("Sp_Red_AopYlwDX", conn);
        StoredProcedureCommandA.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daA = StoredProcedureCommandA.ExecuteReader();
        //string orderlist = "";
        while (daA.Read())
        {
            string Red = daA["TtlRedAopYlwDX"].ToString();
            lblRedA.Text = Red;

        }

        conn.Close();

        //Red Accessories
        SqlCommand StoredProcedureCommandAC = new SqlCommand("Sp_Red_AccesYlwDX", conn);
        StoredProcedureCommandAC.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daAC = StoredProcedureCommandAC.ExecuteReader();
        //string orderlist = "";
        while (daAC.Read())
        {
            string Red = daAC["TtlRedAccesYlwDX"].ToString();
            lblRedAC.Text = Red;

        }

        conn.Close();

        //Red Inventory
        SqlCommand StoredProcedureCommandI = new SqlCommand("Sp_Red_InventoryYlwDX", conn);
        StoredProcedureCommandI.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daI = StoredProcedureCommandI.ExecuteReader();
        //string orderlist = "";
        while (daI.Read())
        {
            string Red = daI["TtlRedInventYlwDX"].ToString();
            lblRedI.Text = Red;

        }

        conn.Close();

        //Red Printing
        SqlCommand StoredProcedureCommandP = new SqlCommand("Sp_Red_PrntYlwDX", conn);
        StoredProcedureCommandP.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daP = StoredProcedureCommandP.ExecuteReader();
        //string orderlist = "";
        while (daP.Read())
        {
            string Red = daP["TtlRedPrntYlwDX"].ToString();
            lblRedP.Text = Red;

        }

        conn.Close();

        //Red Printing
        SqlCommand StoredProcedureCommandEM = new SqlCommand("Sp_Red_EmbYlwDX", conn);
        StoredProcedureCommandEM.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daEM = StoredProcedureCommandEM.ExecuteReader();
        //string orderlist = "";
        while (daEM.Read())
        {
            string Red = daEM["TtlRedEmbYlwDX"].ToString();
            lblRedEM.Text = Red;

        }

        conn.Close();

        //Red Printing
        SqlCommand StoredProcedureCommandRMG = new SqlCommand("Sp_Red_rmgYlwDX", conn);
        StoredProcedureCommandRMG.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader daRMG = StoredProcedureCommandRMG.ExecuteReader();
        //string orderlist = "";
        while (daRMG.Read())
        {
            string Red = daRMG["TtlRedrmgYlwDX"].ToString();
            lblRedRMG.Text = Red;

        }

        conn.Close();
    }
}