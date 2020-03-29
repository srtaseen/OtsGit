using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class IELayoutFReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.ReportViewer1.LocalReport.ReportPath = base.Server.MapPath("LayoutPlan.rdlc");

        ReportViewer1.LocalReport.ReportPath = "reports/IELayoutFRDLC.rdlc";

        DataSet set2 = (DataSet)Session["IELayoutRpt"];
        ReportDataSource source2 = new ReportDataSource("DataSet1", set2.Tables[0]);
        this.ReportViewer1.LocalReport.DataSources.Clear();
        this.ReportViewer1.LocalReport.DataSources.Add(source2);
        //ReportParameterCollection parameters2 = new ReportParameterCollection();
        //parameters2.Add(new ReportParameter("rptname", "Cutting to Finish Summery By Ex-Factory Date For " + this.Session["dt1"].ToString() + " To " + this.Session["dt2"].ToString()));
        //this.ReportViewer1.LocalReport.SetParameters(parameters2);
        //break;

        var bytes = ReportViewer1.LocalReport.Render("PDF");
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "inline;attachment; filename=Sample.pdf");
        Response.BinaryWrite(bytes);
        Response.Flush(); // send it to the client to download
        Response.Clear();

    }

    
}