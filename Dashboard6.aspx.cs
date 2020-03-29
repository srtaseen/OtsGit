using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Dashboard6 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindddlbuyerM();
        }
    }

    private void BindddlbuyerM()
    {
        ddbuyerM.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddbuyerM.DataSource = ds;
        ddbuyerM.DataTextField = "byr_nm";
        ddbuyerM.DataValueField = "byr_id";
        ddbuyerM.DataBind();

        conn.Close();
    }
    //button
    protected void btnfindM_Click(object sender, EventArgs e)
    {
        //Red All
        SqlCommand StoredProcedureCommand = new SqlCommand("Sp_Red_All814", conn);
        StoredProcedureCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm1 = StoredProcedureCommand.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommand.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TtlRed814"].ToString();
            lblRed.Text = Red;

        }
        //TheReader.Close();
        conn.Close();
        // % of Red 
        //lblredsub.Text = ((int.Parse(lblRed.Text) * 100) / int.Parse(lbltotal.Text)).ToString("0");

        //Yarn Total
        //Total Job
        //conn.Open();
        //SqlCommand cmdy = new SqlCommand("SELECT COUNT (Tnapl21)*4 AS Total FROM View_Tna_Plan WHERE Po_ShipDate is NULL  AND ActiveOrder='1' AND TnaByrNm = '" + dlbuyerY.SelectedItem.Value + "'", conn);
        //SqlDataAdapter day = new SqlDataAdapter(cmdy);
        //DataSet dsy = new DataSet();
        //day.Fill(dsy);
        //lblRedY1.Text = dsy.Tables[0].Rows[0]["Total"].ToString();
        //cmdy.ExecuteNonQuery();
        //conn.Close();


        //Red Merchandiser
        SqlCommand StoredProcedureCommandM = new SqlCommand("Sp_Red_MerchandisngM814", conn);
        StoredProcedureCommandM.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmM = StoredProcedureCommandM.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daM = StoredProcedureCommandM.ExecuteReader();
        //string orderlist = "";
        while (daM.Read())
        {
            string Red = daM["TtlRedMer814"].ToString();
            lblRedM.Text = Red;

        }

        conn.Close();






        //Red Yarn
        SqlCommand StoredProcedureCmdYarn = new SqlCommand("Sp_Red_Yarn814", conn);
        StoredProcedureCmdYarn.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmy = StoredProcedureCmdYarn.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daYarn = StoredProcedureCmdYarn.ExecuteReader();
        //string orderlist = "";
        while (daYarn.Read())
        {
            string Red = daYarn["TtlRedYarn814"].ToString();
            lblRedY2.Text = Red;

        }
        daYarn.Close();
        conn.Close();
        // % of Red 
        //lblRedY3.Text = ((int.Parse(lblRedY2.Text) * 100) / int.Parse(lblRedY1.Text)).ToString("0");



        //Red Yarn Dyeing
        SqlCommand StoredProcedureCommandYD = new SqlCommand("Sp_Red_YarnDyed814", conn);
        StoredProcedureCommandYD.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmYD = StoredProcedureCommandYD.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daYD = StoredProcedureCommandYD.ExecuteReader();
        //string orderlist = "";
        while (daYD.Read())
        {
            string Red = daYD["TtlRedYd814"].ToString();
            lblRedYD.Text = Red;

        }

        conn.Close();


        //Red knitting
        SqlCommand StoredProcedureCommandK = new SqlCommand("Sp_Red_Knitting814", conn);
        StoredProcedureCommandK.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmK = StoredProcedureCommandK.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daK = StoredProcedureCommandK.ExecuteReader();
        //string orderlist = "";
        while (daK.Read())
        {
            string Red = daK["TtlRedKnit814"].ToString();
            lblRedK.Text = Red;

        }

        conn.Close();


        //Red Dyeing
        SqlCommand StoredProcedureCommandD = new SqlCommand("Sp_Red_Dyeing814", conn);
        StoredProcedureCommandD.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmD = StoredProcedureCommandD.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daD = StoredProcedureCommandD.ExecuteReader();
        //string orderlist = "";
        while (daD.Read())
        {
            string Red = daD["TtlRedDye814"].ToString();
            lblRedD.Text = Red;

        }

        conn.Close();


        //Red AOP
        SqlCommand StoredProcedureCommandA = new SqlCommand("Sp_Red_Aop814", conn);
        StoredProcedureCommandA.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmA = StoredProcedureCommandA.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daA = StoredProcedureCommandA.ExecuteReader();
        //string orderlist = "";
        while (daA.Read())
        {
            string Red = daA["TtlRedAop814"].ToString();
            lblRedA.Text = Red;

        }

        conn.Close();

        //Red Accessories
        SqlCommand StoredProcedureCommandAC = new SqlCommand("Sp_Red_Acces814", conn);
        StoredProcedureCommandAC.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmAC = StoredProcedureCommandAC.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daAC = StoredProcedureCommandAC.ExecuteReader();
        //string orderlist = "";
        while (daAC.Read())
        {
            string Red = daAC["TtlRedAcces814"].ToString();
            lblRedAC.Text = Red;

        }

        conn.Close();

        //Red Inventory
        SqlCommand StoredProcedureCommandI = new SqlCommand("Sp_Red_Inventory814", conn);
        StoredProcedureCommandI.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmI = StoredProcedureCommandI.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daI = StoredProcedureCommandI.ExecuteReader();
        //string orderlist = "";
        while (daI.Read())
        {
            string Red = daI["TtlRedInvent814"].ToString();
            lblRedI.Text = Red;

        }

        conn.Close();

        //Red Printing
        SqlCommand StoredProcedureCommandP = new SqlCommand("Sp_Red_Prnt814", conn);
        StoredProcedureCommandP.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmP = StoredProcedureCommandP.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daP = StoredProcedureCommandP.ExecuteReader();
        //string orderlist = "";
        while (daP.Read())
        {
            string Red = daP["TtlRedPrnt814"].ToString();
            lblRedP.Text = Red;

        }

        conn.Close();

        //Red Printing
        SqlCommand StoredProcedureCommandEM = new SqlCommand("Sp_Red_Emb814", conn);
        StoredProcedureCommandEM.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmEM = StoredProcedureCommandEM.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daEM = StoredProcedureCommandEM.ExecuteReader();
        //string orderlist = "";
        while (daEM.Read())
        {
            string Red = daEM["TtlRedEmb814"].ToString();
            lblRedEM.Text = Red;

        }

        conn.Close();

        //Red Printing
        SqlCommand StoredProcedureCommandRMG = new SqlCommand("Sp_Red_rmg814", conn);
        StoredProcedureCommandRMG.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmRMG = StoredProcedureCommandRMG.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daRMG = StoredProcedureCommandRMG.ExecuteReader();
        //string orderlist = "";
        while (daRMG.Read())
        {
            string Red = daRMG["TtlRedrmg814"].ToString();
            lblRedRMG.Text = Red;

        }

        conn.Close();

    }
}