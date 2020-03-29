using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Collections;

public partial class BookingCAD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGetStyle();
            //BindGetFactory();
            //GetPo.Enabled = false;
        }
    }

    private void BindGetStyle()
    {

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("select ord_id,ord_no from Order_Master ", conn);
            GetStyle.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GetStyle.DataTextField = "ord_no";
            GetStyle.DataValueField = "ord_id";
            GetStyle.DataSource = rdr;
            GetStyle.DataBind();
        }
    }

   

    protected void GetStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPo.Items.Clear();
        GetPo.Items.Add(new ListItem("-", ""));
        GetPo.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select art_id,art_no from Article_Master where ord_no='" + GetStyle.SelectedItem.Text + "' ";
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = strQuery1;
        cmd1.Connection = conn;
        try
        {
            conn.Open();
            GetPo.DataSource = cmd1.ExecuteReader();
            GetPo.DataTextField = "art_no";
            GetPo.DataBind();
            if (GetPo.Items.Count > 1)
            {
                GetPo.Enabled = true;
            }
            else
            {
                GetPo.Enabled = false;
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

    protected void GetPo_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //GetColor.Items.Clear();
        //GetColor.Items.Add(new ListItem("-", ""));
        //GetColor.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select am.art_quantity,bt.byr_nm from Article_Master am join Buyer_Tab bt on am.ord_buyer=bt.byr_id where art_no='" + GetPo.SelectedItem.Text + "' ";
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = strQuery1;
        cmd1.Connection = conn;
        try
        {
            conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtQty.Text = dt.Rows[0]["art_quantity"].ToString();
                txtBuyer.Text = dt.Rows[0]["byr_nm"].ToString();

            }

            //GetColor.DataSource = dt;
            //GetColor.DataTextField = "cColour";
            //GetColor.DataValueField = "nFabColNo";
            //GetColor.DataBind();
            //if (GetColor.Items.Count > 1)
            //{
            //    GetColor.Enabled = true;
            //}
            //else
            //{
            //    GetColor.Enabled = false;
            //}
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
    protected void GetColor_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindGetSize();
    }


    


    protected void Btnsave_Click(object sender, System.EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(DbConnect.x);

            SqlCommand Syscmd = new SqlCommand();
            Syscmd.CommandType = CommandType.StoredProcedure;
            Syscmd.CommandText = "Sp_BookingCAD_Data";

            //DateTime shipDate = DateTime.ParseExact(txtentdt.Text, "d", null);
            //Syscmd.Parameters.AddWithValue("@sp_Date", shipDate);
            Syscmd.Parameters.AddWithValue("@ord_no", GetStyle.SelectedItem.ToString());
            Syscmd.Parameters.AddWithValue("@art_no", GetPo.SelectedItem.ToString());
            Syscmd.Parameters.AddWithValue("@art_qty", int.Parse(txtQty.Text.Trim()));
            Syscmd.Parameters.AddWithValue("@byr_nm", txtBuyer.Text.Trim());
            Syscmd.Parameters.AddWithValue("@bCADCons", txtBCons.Text.Trim());
            Syscmd.Parameters.AddWithValue("@bCADDia", int.Parse(txtBDia.Text.Trim()));            
            Syscmd.Parameters.AddWithValue("@bCADGsm", int.Parse(txtBGsm.Text.Trim()));
            Syscmd.Parameters.AddWithValue("@sp_User", this.Session["Username"].ToString());

            Syscmd.Connection = conn;
            conn.Open();

            Syscmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        GetStyle.ClearSelection();
        GetPo.ClearSelection();
        txtQty.Text = string.Empty;
        txtBuyer.Text = string.Empty;
        txtBCons.Text = string.Empty;
        txtBDia.Text = string.Empty;
        txtBGsm.Text = string.Empty;

    }

}