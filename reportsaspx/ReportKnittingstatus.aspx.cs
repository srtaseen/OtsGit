using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class reportsaspx_ReportOrderInhand : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            ReportViewer1.Visible = true;

            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            DataSet ds = new DataSet();
            ds = GetData(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                var bytes = ReportViewer1.LocalReport.Render("PDF");
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline;attachment; filename=Sample.pdf");
                Response.BinaryWrite(bytes);
                Response.Flush(); // send it to the client to download
                Response.Clear();
            }
        }

    }

    private DataSet GetData(object id)
    {
        SqlCommand cmd = new SqlCommand("select * from View_Tna_Plan Where po_xfactory between '" + Session["dt1"].ToString() + "'  AND '" + Session["dt2"].ToString() + "'  ");
        using (conn)
        {
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return (ds);
            }
        }
    }

    public object id { get; set; }
}