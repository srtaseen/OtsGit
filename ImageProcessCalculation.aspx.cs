using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ImageProcessCalculation : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["otsConn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Bindddlgtype();
            //bindGrid();
            BindOperationGrid();


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
    //    DataSet ds = new DataSet();
    //    using (SqlConnection con = new SqlConnection(conString))
    //    {
    //        con.Open();
    //        string cmdstr = "Select StyleId,StyleName,PlnEfficiency,Smv,Mo,Helper,StyleImgName,StyleImgPath from StyleRegistration where GTypeId = '" + GetGType.SelectedValue + "'";
    //        SqlCommand cmd = new SqlCommand(cmdstr, con);
    //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
    //        adp.Fill(ds);
    //        gvDetails.DataSource = ds;
    //        gvDetails.DataBind();
    //    }
    //}


    private void BindOperationGrid()
    {
        lblGType.Text = Session["GType"].ToString();
        int gType = int.Parse(Session["GTypeId"].ToString());
        SqlConnection conn = new SqlConnection(DbConnect.x);
        DataTable dt = new DataTable();
        try
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("Select StyleId,StyleName,PlnEfficiency,Smv,Mo,Helper,StyleImgName,StyleImgPath from StyleRegistration where GTypeId = " + gType, conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt);
            //OperationGridView.DataMember = "tblOperation";
            gvDetails.DataSource = dt;
            gvDetails.DataBind();
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

    //protected void bindGrid()
    //{
    //    DataSet ds = new DataSet();
    //    using (SqlConnection con = new SqlConnection(conString))
    //    {
    //        con.Open();
    //        string cmdstr = "Select StyleId,StyleName,PlnEfficiency,Smv,Mo,Helper,StyleImgName,StyleImgPath from StyleRegistration where StyleName = '" + GetGType.SelectedItem.Text + "'";
    //        SqlCommand cmd = new SqlCommand(cmdstr, con);
    //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
    //        adp.Fill(ds);
    //        gvDetails.DataSource = ds;
    //        gvDetails.DataBind();
    //    }

    //}
}