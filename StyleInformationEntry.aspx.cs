using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StyleInformationEntry : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["otsConn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        //BindOperationGrid();

        if (!IsPostBack)
        {
            Bindddlgtype();


        }
    }


    private void BindOperationGrid()
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand("GET_OPERATION_DATA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(dt);
            OperationGridView.DataSource = dt;
            OperationGridView.DataBind();

            //if (dt.Rows.Count > 0)
            //{
            //    OperationGridView.DataSource = null;
            //    OperationGridView.DataBind();

            //}

        }
        catch (Exception ex)
        {
            Response.Write("Error Occured: " + ex.ToString());
        }
        finally
        {
            //dt.Clear();
            //ds.Dispose();
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
    protected void GetGType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        conn.Open();
        SqlCommand cmd1 = new SqlCommand("select b.id, b.OperationName,a.SMV,a.MachineQty,a.ManQty  from tblGtypeProcess a join tblProcess b on a.Process = b.Id where GType = '" + GetGType.SelectedItem.Value + "'", conn);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        da1.Fill(ds);
        //OperationGridView.DataMember = "tblOperation";
        OperationGridView.DataSource = ds;
        OperationGridView.DataBind();
        conn.Close();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile != null)
        {
            try
            {
                string pId = txtPId.Text;
                string processes = pId.Substring(0, pId.Length - 1);
                string StyleImgName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                FileUpload1.SaveAs(Server.MapPath("StyleImages/" + StyleImgName));

                SqlConnection con = new SqlConnection(conString);

                SqlCommand cmd = new SqlCommand("sp_StyleRegistration", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StyleName", SqlDbType.VarChar).Value = txtStyle.Text.Trim();
                cmd.Parameters.AddWithValue("@PlnEfficiency", SqlDbType.Decimal).Value = txtPlanEff.Text.Trim();
                cmd.Parameters.AddWithValue("@Smv", SqlDbType.Decimal).Value = txtSmv.Text.Trim();
                cmd.Parameters.AddWithValue("@Mo", SqlDbType.Int).Value = txtMo.Text.Trim();
                cmd.Parameters.AddWithValue("@Helper", SqlDbType.Int).Value = txtHelper.Text.Trim();
                cmd.Parameters.AddWithValue("@StyleImgName", StyleImgName);
                cmd.Parameters.AddWithValue("@StyleImgPath", "StyleImages/" + StyleImgName);
                cmd.Parameters.AddWithValue("@GTypeId", SqlDbType.Int).Value = GetGType.SelectedValue;
                cmd.Parameters.AddWithValue("@Processes", processes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();

                txtStyle.Text = String.Empty;
                txtPlanEff.Text = String.Empty;
                txtSmv.Text = String.Empty;
                txtMo.Text = String.Empty;
                txtHelper.Text = String.Empty;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            lblmsg.Text = "Save Style Information";

        }
    }
}