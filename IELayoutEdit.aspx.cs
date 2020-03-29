using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IELayoutEdit : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindddlbuyer();
        }

    }

    private void Bindddlbuyer()
    {
        GetByr.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery = "select byr_id,byr_nm from Buyer_Tab order by byr_nm ASC ";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            GetByr.DataSource = cmd.ExecuteReader();
            GetByr.DataTextField = "byr_nm";
            GetByr.DataValueField = "byr_id";

            GetByr.DataBind();
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
    protected void GetByr_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetStn.Items.Clear();
        GetStn.Items.Add(new ListItem("-", ""));
        GetStn.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select  DISTINCT ord_no FROM Article_Master where ord_buyer='" + GetByr.SelectedItem.Value + "' ";
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = strQuery1;
        cmd1.Connection = conn;
        try
        {
            conn.Open();
            GetStn.DataSource = cmd1.ExecuteReader();
            GetStn.DataTextField = "ord_no";
            //ddlStyle.DataValueField = "ord_id";
            GetStn.DataBind();
            if (GetStn.Items.Count > 1)
            {
                GetStn.Enabled = true;
            }
            else
            {
                GetStn.Enabled = false;
            }
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
    protected void GetStn_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetArticle.Items.Clear();
        GetArticle.Items.Add(new ListItem("-", ""));
        GetArticle.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select  DISTINCT art_id,art_no FROM Article_Master where ord_no='" + GetStn.SelectedItem.Value + "'";
        //"' and art_id not in (select art_id from IEMaster where Style='" + GetStn.SelectedItem.Value + "')";
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = strQuery1;
        cmd1.Connection = conn;
        try
        {
            conn.Open();
            GetArticle.DataSource = cmd1.ExecuteReader();
            GetArticle.DataTextField = "art_no";
            GetArticle.DataValueField = "art_id";
            GetArticle.DataBind();
            if (GetArticle.Items.Count > 1)
            {
                GetArticle.Enabled = true;
            }
            else
            {
                GetArticle.Enabled = false;
            }
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

    protected void GetArticle_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetPo.Items.Clear();
        //GetPo.Items.Add(new ListItem("-", ""));
        //GetPo.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        try
        {
            DataTable dt = new DataTable();
            //String strQuery = "select distinct a.po_no,b.gmtyp as art_item,b.gmtid,a.Fact_nm from view_Article_Po a join GarmentsType b on a.art_item = b.gmtid where art_no='" + GetArticle.SelectedItem.Value + "' and a.po_no not in (select Po_no from Line_Booking) ";

            String strQuery = "select am.art_item,gm.gmtyp from Article_Master am join GarmentsType gm on am.art_item=gm.gmtid where am.art_no='" + GetArticle.SelectedItem.Text + "' ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = conn;

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //If you want to get mutiple data from the database then you need to write a simple looping 
                GetGType.Text = dt.Rows[0]["gmtyp"].ToString();
                //GetFactory.Text = dt.Rows[0]["Fact_nm"].ToString();
                Session["GType"] = GetGType.Text;
                Session["GTypeId"] = dt.Rows[0]["art_item"];

            }

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

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        this.BindGrid();
    }

    private void BindGrid()
    {
        using (SqlCommand cmd = new SqlCommand(@"select ied.id,tp.OperationName, ied.SrlNo from IEDetails ied
        join Article_Master am on ied.art_id = am.art_id
        join tblProcess tp on ied.ProcessId = tp.Id
        where ied.art_id='" + GetArticle.SelectedItem.Value + "' order by SrlNo"))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = conn;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);        
        int srl = Convert.ToInt32((row.Cells[3].Controls[0] as TextBox).Text);
        //string name = (row.Cells[2].Controls[0] as TextBox).Text;
        //string country = (row.Cells[3].Controls[0] as TextBox).Text;
        //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            //using (SqlCommand cmd = new SqlCommand("uspUpdateIEDetails"))
            //{
                SqlCommand cmd = new SqlCommand("uspUpdateIEDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vId", id);
                cmd.Parameters.AddWithValue("@vSrl", srl);
                //cmd.Parameters.AddWithValue("@Country", country);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            //}
        }
        GridView1.EditIndex = -1;
        this.BindGrid();
    }

    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        //int srl = Convert.ToInt32((row.Cells[3].Controls[0] as TextBox).Text);
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {            
            SqlCommand cmd = new SqlCommand("uspDeleteIEDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vId", id);
            //cmd.Parameters.AddWithValue("@vSrl", srl);
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
}