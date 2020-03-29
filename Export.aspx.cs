using System;
using System.Collections.Generic;
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

public partial class Export : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGetStyle();
            BindGetFactory();
        }
    }

    private void BindGetStyle()
    {

        using (SqlConnection conn = new SqlConnection(DbSpecFo.x))
        {
            SqlCommand cmd = new SqlCommand("select nStyleID,cStyleNo from SpecFo.dbo.Smt_StyleMaster ", conn);
            GetStyle.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GetStyle.DataTextField = "cStyleNo";
            GetStyle.DataValueField = "nStyleID";
            GetStyle.DataSource = rdr;
            GetStyle.DataBind();
        }
    }

    private void BindGetSize()
    {
        GetSize.Items.Clear();        
        SqlConnection conn = new SqlConnection(DbSpecFo.x);
        String strQuery1 = @"select distinct sm.cStyleNo,om.cPoNum,so.Size1,so.Size2,so.Size3,so.Size4,so.Size5,so.Size6,so.Size7,so.Size8,so.Size9,so.Size10,so.Size11,so.Size12,so.Size13,so.Size14,so.Size15 
                from Smt_OrdersMaster om join Smt_StyleMaster sm on om.nOStyleId=sm.nStyleID 
                join Smt_OrderSize so on om.nOStyleId=so.nStyleID 
                where sm.cStyleNo='" + GetStyle.SelectedItem.Text + "' and om.cPoNum='" + GetPo.SelectedItem.Text + "' ";
        
        try
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(strQuery1, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> size = new List<string>();
            if (dt.Rows.Count > 0)
            {
                int i;
                for (i = 2; i <= dt.Columns.Count - 1; i++)
                {
                    string sz = dt.Rows[0][i].ToString();
                    if (!String.IsNullOrWhiteSpace(sz))
                        size.Add(sz);
                }
            }
            GetSize.DataSource = size;           
            GetSize.DataBind();
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

    protected void GetStyle_SelectedIndexChanged(object sender, EventArgs e)
    {

        GetPo.Items.Clear();
        GetPo.Items.Add(new ListItem("-", ""));
        GetPo.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbSpecFo.x);
        String strQuery1 = "select sm.cStyleNo,om.cPoNum from Smt_OrdersMaster om join Smt_StyleMaster sm on om.nOStyleId=sm.nStyleID where cStyleNo='" + GetStyle.SelectedItem.Text + "' ";
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = strQuery1;
        cmd1.Connection = conn;
        try
        {
            conn.Open();
            GetPo.DataSource = cmd1.ExecuteReader();
            GetPo.DataTextField = "cPoNum";
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
        GetColor.Items.Clear();
        GetColor.Items.Add(new ListItem("-", ""));
        GetColor.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbSpecFo.x);
        String strQuery1 = @"select distinct sm.cStyleNo,om.cPoNum,sof.nFabColNo,sc.cColour,om.nfob,om.DXfty from Smt_OrdersMaster om join Smt_StyleMaster sm on om.nOStyleId=sm.nStyleID 
																	join Smt_OrdFabColor sof on om.nOStyleId=sof.nStyleID
																	join Smt_Colours sc on sof.nFabColNo=sc.nColNo where cStyleNo='" + GetStyle.SelectedItem.Text + "' and cPoNum='" + GetPo.SelectedItem.Text + "' ";
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
                txtFob.Text = dt.Rows[0]["nfob"].ToString();
               
            }

            GetColor.DataSource = dt;
            GetColor.DataTextField = "cColour";
            GetColor.DataValueField = "nFabColNo";
            GetColor.DataBind();
            if (GetColor.Items.Count > 1)
            {
                GetColor.Enabled = true;
            }
            else
            {
                GetColor.Enabled = false;
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
    protected void GetColor_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindGetSize();
    }


    private void BindGetFactory()
    {
        using (SqlConnection conn = new SqlConnection(DbSpecFo.x))
        {
            SqlCommand cmd = new SqlCommand("Select nCompanyID,cCmpName FROM Smt_Company", conn);
            GetFactory.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GetFactory.DataTextField = "cCmpName";
            GetFactory.DataValueField = "nCompanyID";
            GetFactory.DataSource = rdr;
            GetFactory.DataBind();
        }
    }


    protected void Btnsave_Click(object sender, System.EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(DbSmartCode.x);

            SqlCommand Syscmd = new SqlCommand();
            Syscmd.CommandType = CommandType.StoredProcedure;
            Syscmd.CommandText = "Sp_Export_Data";

            DateTime shipDate = DateTime.ParseExact(txtentdt.Text, "d", null);
            Syscmd.Parameters.AddWithValue("@sp_Date", shipDate);            
            Syscmd.Parameters.AddWithValue("@sp_StyleID", GetStyle.SelectedValue.ToString());
            Syscmd.Parameters.AddWithValue("@sp_POLot", GetPo.SelectedItem.ToString());
            Syscmd.Parameters.AddWithValue("@sp_ColorID", GetColor.SelectedValue.ToString());
            Syscmd.Parameters.AddWithValue("@sp_CompanyID", GetFactory.SelectedValue.ToString());
            Syscmd.Parameters.AddWithValue("@sp_Size", GetSize.SelectedItem.ToString());
            Syscmd.Parameters.AddWithValue("@sp_SizeQty", int.Parse(txtShipQty.Text.Trim()));
            Syscmd.Parameters.AddWithValue("@sp_User", this.Session["Username"].ToString());
            Syscmd.Parameters.AddWithValue("@sp_Fob", decimal.Parse(txtFob.Text.Trim()));           

            Syscmd.Connection = conn;
            conn.Open();

            Syscmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
        }

        GetSize.ClearSelection();
        txtShipQty.Text = string.Empty;
       
    }

}