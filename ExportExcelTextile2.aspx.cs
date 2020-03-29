using System;
using System.Data;
using System.Data.SqlClient;

public partial class ExportExcelTextile2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindddlbuyerK();

    }

    private void BindddlbuyerK()
    {
        ddlbuyerK.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select byr_id, byr_nm FROM Buyer_Tab order by byr_nm ASC ", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbuyerK.DataSource = ds;
        ddlbuyerK.DataTextField = "byr_nm";
        ddlbuyerK.DataValueField = "byr_id";
        ddlbuyerK.DataBind();

        conn.Close();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TextileTNA.xls"));
        Response.ContentType = "application/ms-excel";
        DataTable dt = GetDatafromDatabase();
        string str = string.Empty;
        foreach (DataColumn dtcol in dt.Columns)
        {
            Response.Write(str + dtcol.ColumnName);
            str = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            str = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                Response.Write(str + Convert.ToString(dr[j]));
                str = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    }

    protected DataTable GetDatafromDatabase()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(DbConnect.x))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select ord_no,art_no,po_no,po_quantity,tnapl23 as YarnInhouseStartPlnDt,isnull(convert(varchar(50),tnaac23),'Not Done') as YarnInhouseStartActDt,tnapl24 as YarnInhouseEndPlnDt,isnull(convert(varchar(50),tnaac24),'Not Done') as YarnInhouseEndActDt,tnapl25 as KnittingStartPlnDt,isnull(convert(varchar(50),tnaac25),'Not Done') as KnittingStartActDt,tnapl26 as KnittingFinishPlnDt,isnull(convert(varchar(50),tnaac26),'Not Done') as KnittingFinishActDt,tnapl27 as DeyingStartPlnDt,isnull(convert(varchar(50),tnaac27),'Not Done') as DeyingStartActDt,tnapl28 as DeyingFinishPlnDt,isnull(convert(varchar(50),tnaac28),'Not Done') as DeyingFinishActDt from View_Tna_Plan where Po_ShipDate is NULL AND ActiveOrder='1' and TnAapproved is not null and TnaByrNm = '" + ddlbuyerK.SelectedItem.Value + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
        }
        return dt;
    }


}