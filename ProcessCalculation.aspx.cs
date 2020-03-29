using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProcessCalculation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindOperationGrid();
            //Bindddlgtype();            
        }
    }


    private void BindOperationGrid()
    {
        lblGType.Text = Session["GType"].ToString();
        int gType = int.Parse(Session["GTypeId"].ToString());
        SqlConnection conn = new SqlConnection(DbConnect.x);
        DataTable dt = new DataTable();
        try
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("select b.OperationName,a.SMV,a.MachineQty,a.ManQty  from tblGtypeProcess a join tblProcess b on a.Process = b.Id where GType = " + gType , conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt);
            //OperationGridView.DataMember = "tblOperation";
            OperationGridView.DataSource = dt;
            OperationGridView.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("Error Occured: " + ex.ToString());
        }
        finally
        {
            conn.Close();
            //dt.Clear();
            //ds.Dispose();
        }
    }


    //private void Bindddlgtype()
    //{
    //    GetGType.AppendDataBoundItems = true;
    //    SqlConnection conn = new SqlConnection(DbConnect.x);
    //    String strQuery = "select distinct gmtid,gmtyp from GarmentsType order by gmtyp ASC ";
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = strQuery;
    //    cmd.Connection = conn;
    //    try
    //    {
    //        conn.Open();
    //        GetGType.DataSource = cmd.ExecuteReader();
    //        GetGType.DataTextField = "gmtyp";
    //        GetGType.DataValueField = "gmtid";

    //        GetGType.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        conn.Close();
    //        conn.Dispose();
    //    }
    //}
    //protected void GetGType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection conn = new SqlConnection(DbConnect.x);
    //    conn.Open();
    //    SqlCommand cmd1 = new SqlCommand("select b.OperationName,a.SMV,a.MachineQty,a.ManQty  from tblGtypeProcess a join tblProcess b on a.Process = b.Id where GType = " + GetGType.SelectedItem.Value , conn);
    //    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
    //    DataSet ds = new DataSet();
    //    da1.Fill(ds);
    //    //OperationGridView.DataMember = "tblOperation";
    //    OperationGridView.DataSource = ds;
    //    OperationGridView.DataBind();
    //    conn.Close();
    //}


}