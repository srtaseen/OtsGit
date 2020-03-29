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

public partial class StyleWiseMasterReport : System.Web.UI.Page
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
        using (SqlConnection conn = new SqlConnection(DbSmartCode.x))
        {

            conn.Open();

            //string strSelectCmd = "select (select SUM(cQty) from SmartCode.dbo.View_Web_StyleCutWiseCutOut where cStyleNo='" + ddlStyle.SelectedItem.Text + "') as TotalCutting,(SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + "' and BTDescription='INPUT') as TotalInput,(SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + "' and BTDescription='SEWING QC OUT') as TotalSewing ,(SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + "' and BTDescription='FINAL OUT'	) as TotalPoly ,(select SUM(sp.sp_SizeQty) from SmartCode.dbo.Smt_ShipmentInf sp join SpecFo.dbo.Smt_StyleMaster sm on sp.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + "') as ShipmentReady,sm.nTotOrdQty as ShipmentRequired,(select sum(ex.sp_SizeQty) from Smt_ExportInf ex join SpecFo.dbo.Smt_StyleMaster sm on ex.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + "') as ExportQty,(select sum(ex.sp_TotalValue) from Smt_ExportInf ex join SpecFo.dbo.Smt_StyleMaster sm on ex.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + "') as ExportValue,sb.cBuyer_Name from SmartCode.dbo.Smt_ShipmentInf sp join SpecFo.dbo.Smt_StyleMaster sm on sp.sp_StyleID=sm.nStyleID join SmartCode.dbo.Smt_ExportInf ex on sp.sp_StyleID=ex.sp_StyleID join SpecFo.dbo.Smt_BuyerName sb on sm.nAcct=sb.nBuyer_ID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + "' group by sm.nTotOrdQty,sb.cBuyer_Name";

            string strSelectCmd = @"select isnull((select SUM(cQty) from SmartCode.dbo.View_Web_StyleCutWiseCutOut where cStyleNo='" + ddlStyle.SelectedItem.Text + 
                "'),0) as TotalCutting, isnull((SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + 
                "' and BTDescription='INPUT'),0) as TotalInput, isnull((SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + 
                "' and BTDescription='SEWING QC OUT'),0) as TotalSewing , isnull((SELECT SUM(BQty) FROM [SmartCode].[dbo].[View_Web_ScanData_ColourSize] where BTStyle='" + ddlStyle.SelectedItem.Text + 
                "' and BTDescription='FINAL OUT'),0) as TotalPoly , isnull((select SUM(sp.sp_SizeQty) from SmartCode.dbo.Smt_ShipmentInf sp join SpecFo.dbo.Smt_StyleMaster sm on sp.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + 
                "'),0) as ShipmentReady,sm.nTotOrdQty as ShipmentRequired, isnull((select sum(ex.sp_SizeQty) from Smt_ExportInf ex join SpecFo.dbo.Smt_StyleMaster sm on ex.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + 
                "'),0) as ExportQty, isnull((select sum(ex.sp_TotalValue) from Smt_ExportInf ex join SpecFo.dbo.Smt_StyleMaster sm on ex.sp_StyleID=sm.nStyleID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text +
                "'),0) as ExportValue, sb.cBuyer_Name from SpecFo.dbo.Smt_StyleMaster sm left join SmartCode.dbo.Smt_ShipmentInf sp on sm.nStyleID= sp.sp_StyleID Left join SmartCode.dbo.Smt_ExportInf ex on sp.sp_StyleID=ex.sp_StyleID join SpecFo.dbo.Smt_BuyerName sb on sm.nAcct=sb.nBuyer_ID where sm.cStyleNo='" + ddlStyle.SelectedItem.Text + 
                "' group by sm.nTotOrdQty,sb.cBuyer_Name";

           

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
        catch(Exception ex){
            throw ex;
        }

    }



    private void BindGetStyle()
    {

        using (SqlConnection conn = new SqlConnection(DbSpecFo.x))
        {
            SqlCommand cmd = new SqlCommand("select nStyleID,cStyleNo from SpecFo.dbo.Smt_StyleMaster order by cStyleNo ", conn);
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
        BindGvDetails();
        
    }

    protected void BindGvDetails()
    {
        try
        { 
        using (SqlConnection conn = new SqlConnection(DbSmartCode.x))
        {
            conn.Open();
            string strSelectCmd = @"SELECT om.cPoNum as cPONo,isnull(vws.cColour,'Not Found') as cColour,vps.OrgSize,vpcs.OrgQty,isnull(vws.cQty,0) AS cQty,
            sum(CASE WHEN vwsc.BTDescription='INPUT' THEN isnull(vwsc.BQty,0) else 0 end) as INPUT, 
            sum(CASE WHEN vwsc.BTDescription='SEWING QC OUT' THEN isnull(vwsc.BQty,0) else 0 end) as SEWING,
            sum(CASE WHEN vwsc.BTDescription='FINAL OUT' THEN isnull(vwsc.BQty,0) else 0 end) as POLY,isnull(shp.shpqty,0) as shpqty,COALESCE(ex.sp_SizeQty,0) as sp_SizeQty,
            COALESCE(ex.sp_Fob,0) as sp_Fob,COALESCE(ex.sp_TotalValue,0) as sp_TotalValue,om.DXfty 
            from SpecFo.dbo.Smt_OrdersMaster om join  SpecFo.dbo.View_PivotSize vps on om.nOStyleId=vps.nStyleId and om.cOrderNu=vps.cLotNo
            join SpecFo.dbo.View_PivotColorQtyBySize vpcs on vps.nStyleID=vpcs.nstyCd and vps.cLotNo=vpcs.cLot and vps.SizeNo=vpcs.SizeNo
            left join SmartCode.dbo.View_Web_StyleCutWiseCutOut vws on vps.nStyleID=vws.nStyleID and vps.cLotNo=vws.PLot and vps.OrgSize=vws.cSize and vpcs.nCol=vws.nFabColNo and om.cOrderNu=vws.PLot
            left join SmartCode.dbo.View_Web_ScanData_ColourSize vwsc on vws.cPONo=vwsc.BPO and vws.PLot=vwsc.cOrderNu and vws.nStyleID=vwsc.BTStyleCode and vws.cColour=vwsc.BColor and vws.cSize=vwsc.BSize
            and vws.nFabColNo=vwsc.nColNo and vwsc.BTDescription in ('INPUT','FINAL OUT','SEWING QC OUT') and vwsc.BTStyle='" + ddlStyle.SelectedItem.Text + 
            "' left join (select sp_StyleID,sp_POLot,sp_ColorID,sp_Size,SUM(sp_SizeQty) shpqty from Smt_ShipmentInf group by sp_StyleID,sp_POLot,sp_ColorID,sp_Size) shp " +
            " on vws.nStyleID=shp.sp_StyleID and vws.cSize=shp.sp_Size and vws.cPONo=shp.sp_POLot and vwsc.nColNo=shp.sp_ColorID " + 
            " left join (select sp_StyleID,sp_POLot,sp_ColorID,sp_Size,SUM(sp_SizeQty) sp_SizeQty,sp_Fob,sum(sp_TotalValue) sp_TotalValue from Smt_ExportInf group by sp_StyleID,sp_POLot,sp_ColorID,sp_Size,sp_Fob) ex " +
            " on vws.nStyleID=ex.sp_StyleID and vws.cPONo=ex.sp_POLot and vwsc.nColNo=ex.sp_ColorID and vws.cSize=ex.sp_Size " + 
            " where om.nOStyleId='" + ddlStyle.SelectedValue + "' group by om.cPoNum,vws.cColour,vps.OrgSize,vpcs.OrgQty,vws.cQty,shp.shpqty,ex.sp_SizeQty,ex.sp_TotalValue,ex.sp_Fob,om.DXfty";

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
                ds.Rows.Add();
                GvDetails.DataSource = ds;
                GvDetails.DataBind();
                //int columncount = GvIvn.Rows[0].Cells.Count;
                //GvDetails.Rows[0].Cells.Clear();
                //GvDetails.Rows[0].Cells.Add(new TableCell());
                //GvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                //GvDetails.Rows[0].Cells[0].Text = "";

            }
            else
            {
                GvDetails.DataSource = ds;
                GvDetails.DataBind(); 
            }
        }
            }
        catch(Exception ex){
            throw ex;
        }
    }


    int total = 0;
    decimal exQty = 0;
    int rdShip = 0;
    int polyQty = 0;
    int sewQty = 0;
    int inpQty = 0;
    int cutQty = 0;
    int orgQty = 0;

    protected void GvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.setAttribute('bgColor', this.style.backgroundColor); this.style.backgroundColor = '#CBFF97';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.getAttribute('bgColor');");
            e.Row.Attributes.Add("style", "cursor:pointer;");

            //Grand Total
            total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "sp_TotalValue"));
            exQty += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "sp_SizeQty"));
            rdShip += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "shpqty"));
            polyQty += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "POLY"));
            sewQty += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SEWING"));
            inpQty += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "INPUT"));
            cutQty += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "cQty"));
            orgQty += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrgQty"));
        }

        //Grand Total Footer
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            lblTotal.Text = total.ToString("c");

            Label LabelExQty = (Label)e.Row.FindControl("LabelExQty");
            LabelExQty.Text = exQty.ToString();

            Label LabelRdSpQty = (Label)e.Row.FindControl("LabelRdSpQty");
            LabelRdSpQty.Text = rdShip.ToString();

            Label LabelPlQty = (Label)e.Row.FindControl("LabelPlQty");
            LabelPlQty.Text = polyQty.ToString();

            Label LabelSewQty = (Label)e.Row.FindControl("LabelSewQty");
            LabelSewQty.Text = sewQty.ToString();

            Label LabelInpQty = (Label)e.Row.FindControl("LabelInpQty");
            LabelInpQty.Text = inpQty.ToString();

            Label LabelCutQty = (Label)e.Row.FindControl("LabelCutQty");
            LabelCutQty.Text = cutQty.ToString();

            Label LabelOrgQty = (Label)e.Row.FindControl("LabelOrgQty");
            LabelOrgQty.Text = orgQty.ToString();
        }

    }
}
