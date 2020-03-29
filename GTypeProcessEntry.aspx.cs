using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GTypeProcessEntry : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["otsConn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        //BindOperationGrid();

        if (!IsPostBack)
        {
            Bindddlgtype();
            Bindddlprocess();


        }
    }

    private void Bindddlgtype()
    {
        GetGType.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery = "select distinct gmtid,gmtyp from GarmentsType order by gmtyp ASC ";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            GetGType.DataSource = cmd.ExecuteReader();
            GetGType.DataTextField = "gmtyp";
            GetGType.DataValueField = "gmtid";

            GetGType.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }

    private void Bindddlprocess()
    {
        GetProcess.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery = "select distinct Id,OperationName from tblProcess order by OperationName ASC ";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            GetProcess.DataSource = cmd.ExecuteReader();
            GetProcess.DataTextField = "OperationName";
            GetProcess.DataValueField = "Id";

            GetProcess.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }






    protected void btnSave_Click(object sender, EventArgs e)
    {


        SqlConnection con = new SqlConnection(conString);

        SqlCommand cmd = new SqlCommand("sp_GTypeProcessRegistration", con);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@GType", SqlDbType.Int).Value = GetGType.SelectedValue;
        cmd.Parameters.AddWithValue("@Process", SqlDbType.Int).Value = GetProcess.SelectedValue;
        cmd.Parameters.AddWithValue("@SMV", SqlDbType.Decimal).Value = txtSmv.Text.Trim();
        cmd.Parameters.AddWithValue("@MachineQty", SqlDbType.Int).Value = txtMachine.Text.Trim();
        cmd.Parameters.AddWithValue("@ManQty", SqlDbType.Int).Value = txtMan.Text.Trim();


        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();


        txtSmv.Text = String.Empty;
        txtMachine.Text = String.Empty;
        txtMan.Text = String.Empty;

    
            
            lblmsg.Text = "Save Style Information";

        }
    
}