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

public partial class StyleWiseSummaryReport : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);

    protected void Page_Load(object sender, EventArgs e)
    {       
        if(!IsPostBack)
        {
            BindGetStyle();
        }

    }

   
    protected void BindGvIvn()
    {

        using (SqlConnection conn = new SqlConnection(DbSmartCode.x))
        {

            conn.Open();
            string strSelectCmd = "select (select SUM(cQty) from SmartCode.dbo.View_Web_StyleCutWiseCutOut where cStyleNo='" + ddlStyle.SelectedItem.Text + "') as TotalCutting,(SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + "' and BTDescription='INPUT') as TotalInput,(SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + "' and BTDescription='SEWING QC OUT') as TotalSewing ,(SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + "' and BTDescription='FINAL OUT'	) as TotalPoly , SUM(sp.sp_SizeQty) as ShipmentReady,sm.nTotOrdQty as ShipmentRequired from SmartCode.dbo.Smt_ShipmentInf sp join SpecFo.dbo.Smt_StyleMaster sm on sp.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + "' group by sm.nTotOrdQty";

            //string strSelectCmd = "SELECT * FROM View_Tna_Plan WHERE Po_ShipDate is NULL AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + ddlbuyerI.SelectedItem.Value + "'order by ord_no,po_xfactory ASC";

            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);



            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GvIvn.DataSource = ds;
                GvIvn.DataBind();
                int columncount = GvIvn.Rows[0].Cells.Count;
                GvIvn.Rows[0].Cells.Clear();
                GvIvn.Rows[0].Cells.Add(new TableCell());
                GvIvn.Rows[0].Cells[0].ColumnSpan = columncount;
                GvIvn.Rows[0].Cells[0].Text = "";

            }
            else
            {
                GvIvn.DataSource = ds;
                GvIvn.DataBind();


            }
        }

    }
    


    private void BindGetStyle()
    {

        using (SqlConnection conn = new SqlConnection(DbSpecFo.x))
        {
            SqlCommand cmd = new SqlCommand("select nStyleID,cStyleNo from SpecFo.dbo.Smt_StyleMaster ", conn);
            ddlStyle.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            ddlStyle.DataTextField = "cStyleNo";
            ddlStyle.DataValueField = "nStyleID";
            ddlStyle.DataSource = rdr;
            ddlStyle.DataBind();
        }
    }

    protected void btnFindStyle_Click(object sender, EventArgs e)
    {
        BindGvIvn();
    }
}
