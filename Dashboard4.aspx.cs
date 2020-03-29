using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Dashboard4 : System.Web.UI.Page
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
        SqlCommand StoredProcedureCommandJan = new SqlCommand("Sp_tqty_Jan15", conn);
        StoredProcedureCommandJan.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmJan = StoredProcedureCommandJan.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader TheReader = StoredProcedureCommandJan.ExecuteReader();
        //string orderlist = "";
        while (TheReader.Read())
        {
            string Red = TheReader["TQTYJan15"].ToString();
            lblJan.Text = Red;

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
        SqlCommand StoredProcedureCommandFeb = new SqlCommand("[Sp_tqty_Feb15]", conn);
        StoredProcedureCommandFeb.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmF = StoredProcedureCommandFeb.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daFeb = StoredProcedureCommandFeb.ExecuteReader();
        //string orderlist = "";
        while (daFeb.Read())
        {
            string Red = daFeb["TQTYFeb15"].ToString();
            lblFeb.Text = Red;

        }

        conn.Close();






        //Red Yarn
        SqlCommand StoredProcedureCmdMar = new SqlCommand("Sp_tqty_Mer15", conn);
        StoredProcedureCmdMar.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmmar = StoredProcedureCmdMar.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daMar = StoredProcedureCmdMar.ExecuteReader();
        //string orderlist = "";
        while (daMar.Read())
        {
            string Red = daMar["TQTYMer15"].ToString();
            lblMar.Text = Red;

        }
        daMar.Close();
        conn.Close();
        // % of Red 
        //lblRedY3.Text = ((int.Parse(lblRedY2.Text) * 100) / int.Parse(lblRedY1.Text)).ToString("0");



        //Red Yarn Dyeing
        SqlCommand StoredProcedureCommandApr = new SqlCommand("Sp_tqty_Apr15", conn);
        StoredProcedureCommandApr.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmApr = StoredProcedureCommandApr.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daApr = StoredProcedureCommandApr.ExecuteReader();
        //string orderlist = "";
        while (daApr.Read())
        {
            string Red = daApr["TQTYApr15"].ToString();
            lblApr.Text = Red;

        }

        conn.Close();


        //Red knitting
        SqlCommand StoredProcedureCommandMay = new SqlCommand("Sp_tqty_May15", conn);
        StoredProcedureCommandMay.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmmay = StoredProcedureCommandMay.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader damay = StoredProcedureCommandMay.ExecuteReader();
        //string orderlist = "";
        while (damay.Read())
        {
            string Red = damay["TQTYMay15"].ToString();
            lblMay.Text = Red;

        }

        conn.Close();


        //Red Dyeing
        SqlCommand StoredProcedureCommandJun = new SqlCommand("Sp_tqty_Jun15", conn);
        StoredProcedureCommandJun.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmJun = StoredProcedureCommandJun.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daJun = StoredProcedureCommandJun.ExecuteReader();
        //string orderlist = "";
        while (daJun.Read())
        {
            string Red = daJun["TQTYJun15"].ToString();
            lblJun.Text = Red;

        }

        conn.Close();


        //Red AOP
        SqlCommand StoredProcedureCommandJul = new SqlCommand("Sp_tqty_Jul15", conn);
        StoredProcedureCommandJul.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmJul = StoredProcedureCommandJul.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daJul = StoredProcedureCommandJul.ExecuteReader();
        //string orderlist = "";
        while (daJul.Read())
        {
            string Red = daJul["TQTYJul15"].ToString();
            lblJul.Text = Red;

        }

        conn.Close();

        //Red Accessories
        SqlCommand StoredProcedureCommandAug = new SqlCommand("Sp_tqty_Aug15", conn);
        StoredProcedureCommandAug.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmAug = StoredProcedureCommandAug.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daAug = StoredProcedureCommandAug.ExecuteReader();
        //string orderlist = "";
        while (daAug.Read())
        {
            string Red = daAug["TQTYAug15"].ToString();
            lblAug.Text = Red;

        }

        conn.Close();

        //Red Inventory
        SqlCommand StoredProcedureCommandSep = new SqlCommand("Sp_tqty_Sep15", conn);
        StoredProcedureCommandSep.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmSep = StoredProcedureCommandSep.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daSep = StoredProcedureCommandSep.ExecuteReader();
        //string orderlist = "";
        while (daSep.Read())
        {
            string Red = daSep["TQTYSep15"].ToString();
            lblSep.Text = Red;

        }

        conn.Close();

        //Red Printing
        SqlCommand StoredProcedureCommandOct = new SqlCommand("Sp_tqty_Oct15", conn);
        StoredProcedureCommandOct.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmOct = StoredProcedureCommandOct.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daOct = StoredProcedureCommandOct.ExecuteReader();
        //string orderlist = "";
        while (daOct.Read())
        {
            string Red = daOct["TQTYOct15"].ToString();
            lblOct.Text = Red;

        }

        conn.Close();

        //Red Printing
        SqlCommand StoredProcedureCommandNov = new SqlCommand("Sp_tqty_Nov15", conn);
        StoredProcedureCommandNov.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmNov = StoredProcedureCommandNov.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daNov = StoredProcedureCommandNov.ExecuteReader();
        //string orderlist = "";
        while (daNov.Read())
        {
            string Red = daNov["TQTYNov15"].ToString();
            lblNov.Text = Red;

        }

        conn.Close();

        //Red Printing
        SqlCommand StoredProcedureCommandDec = new SqlCommand("Sp_tqty_Dec15", conn);
        StoredProcedureCommandDec.CommandType = CommandType.StoredProcedure;
        SqlParameter myParmDec = StoredProcedureCommandDec.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader daDec = StoredProcedureCommandDec.ExecuteReader();
        //string orderlist = "";
        while (daDec.Read())
        {
            string Red = daDec["TQTYDec15"].ToString();
            lblDec.Text = Red;

        }

        conn.Close();




        //Red Printing
        SqlCommand StoredProcedureCommand15 = new SqlCommand("Sp_tqty_15", conn);
        StoredProcedureCommand15.CommandType = CommandType.StoredProcedure;
        SqlParameter myParm15 = StoredProcedureCommand15.Parameters.Add("@TnaByrNm", ddbuyerM.SelectedValue);
        conn.Open();
        SqlDataReader da15 = StoredProcedureCommand15.ExecuteReader();
        //string orderlist = "";
        while (da15.Read())
        {
            string Red = da15["TQTY15"].ToString();
            lbl15.Text = Red;

        }

        conn.Close();



    }
}