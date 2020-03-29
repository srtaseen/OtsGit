using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Data;
using System.Web.Services;
using System.Configuration;

public partial class ProductionCAD : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGetStyle();
            
        }

    }


    protected void BindGvIvn()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(DbConnect.x))
            {

                conn.Open();

                //string strSelectCmd = "select (select SUM(cQty) from SmartCode.dbo.View_Web_StyleCutWiseCutOut where cStyleNo='" + ddlStyle.SelectedItem.Text + "') as TotalCutting,(SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + "' and BTDescription='INPUT') as TotalInput,(SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + "' and BTDescription='SEWING QC OUT') as TotalSewing ,(SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + "' and BTDescription='FINAL OUT'	) as TotalPoly ,(select SUM(sp.sp_SizeQty) from SmartCode.dbo.Smt_ShipmentInf sp join SpecFo.dbo.Smt_StyleMaster sm on sp.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + "') as ShipmentReady,sm.nTotOrdQty as ShipmentRequired,(select sum(ex.sp_SizeQty) from Smt_ExportInf ex join SpecFo.dbo.Smt_StyleMaster sm on ex.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + "') as ExportQty,(select sum(ex.sp_TotalValue) from Smt_ExportInf ex join SpecFo.dbo.Smt_StyleMaster sm on ex.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + "') as ExportValue,sb.cBuyer_Name from SmartCode.dbo.Smt_ShipmentInf sp join SpecFo.dbo.Smt_StyleMaster sm on sp.sp_StyleID=sm.nStyleID join SmartCode.dbo.Smt_ExportInf ex on sp.sp_StyleID=ex.sp_StyleID join SpecFo.dbo.Smt_BuyerName sb on sm.nAcct=sb.nBuyer_ID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + "' group by sm.nTotOrdQty,sb.cBuyer_Name";

                string strSelectCmd = "select art_no,art_qty,byr_nm,bCADCons,bCADDia,bCADGsm,bCADBookingDt,sp_User from tblBookCAD where ord_no='" + ddlStyle.SelectedItem.Text + "' and art_no='" + GetPo.SelectedItem.Text + "'";



                SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
                DataTable ds = new DataTable();
                da.Fill(ds);



                if (ds.Rows.Count == 0)
                {
                    DataRow dr = ds.NewRow();
                    foreach (DataColumn dc in ds.Columns)
                    {
                        dr[dc] = 0;
                    }
                    ds.Rows.Add(dr);
                    GvIvn.DataSource = ds;
                    GvIvn.DataBind();
                    int columncount = GvIvn.Rows[0].Cells.Count;
                    GvIvn.Rows[0].Cells.Clear();
                    GvIvn.Rows[0].Cells.Add(new TableCell());
                    GvIvn.Rows[0].Cells[0].ColumnSpan = columncount;
                    GvIvn.Rows[0].Cells[0].Text = "No data found.";

                }
                else
                {
                    GvIvn.DataSource = ds;
                    GvIvn.DataBind();


                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }



    private void BindGetStyle()
    {

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("select bCADId,ord_no from tblBookCAD ", conn);
            ddlStyle.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            ddlStyle.DataTextField = "ord_no";
            ddlStyle.DataValueField = "bCADId";
            ddlStyle.DataSource = rdr;
            ddlStyle.DataBind();
        }
    }

    protected void btnFindStyle_Click(object sender, EventArgs e)
    {
        BindGvIvn();
        //BindGvDetails();
        prodEntry.Visible = true;

    }

    protected void Btnsave_Click(object sender, System.EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(DbConnect.x);

            SqlCommand Syscmd = new SqlCommand();
            Syscmd.CommandType = CommandType.StoredProcedure;
            Syscmd.CommandText = "Sp_ProductionCAD_Data";

            //DateTime shipDate = DateTime.ParseExact(txtentdt.Text, "d", null);
            //Syscmd.Parameters.AddWithValue("@sp_Date", shipDate);
            Syscmd.Parameters.AddWithValue("@ord_no", ddlStyle.SelectedItem.ToString());
            Syscmd.Parameters.AddWithValue("@art_no", GetPo.SelectedItem.ToString());           
            Syscmd.Parameters.AddWithValue("@pCADCons", txtPCons.Text.Trim());
            Syscmd.Parameters.AddWithValue("@pCADDia", int.Parse(txtPDia.Text.Trim()));
            Syscmd.Parameters.AddWithValue("@pCADGsm", int.Parse(txtPGsm.Text.Trim()));
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

        ddlStyle.ClearSelection();
        GetPo.ClearSelection();        
        txtPCons.Text = string.Empty;
        txtPDia.Text = string.Empty;
        txtPGsm.Text = string.Empty;
        //GvIvn.SelectedIndex = -1;
        GvIvn.DataSource = null;
        GvIvn.DataBind();
        prodEntry.Visible = false;

    }



    protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPo.Items.Clear();
        GetPo.Items.Add(new ListItem("-", ""));
        GetPo.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select art_no from tblBookCAD where ord_no='" + ddlStyle.SelectedItem.Text + "' ";
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
}
