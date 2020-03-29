using ASP;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Cut2FinishReport : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbSpecFo.x);
    SqlConnection cn = new SqlConnection(DbSmartCode.x);
    public DateTime dt(string dtime)
    {
        string[] strArray = dtime.Split(new char[] { '/' });
        string str = strArray[0];
        string str2 = strArray[1];
        string str3 = strArray[2];
        return DateTime.Parse(str2 + "/" + str + "/" + str3);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            Warning[] warningArray;
            string[] strArray;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string fileNameExtension = string.Empty;
            string str4 = this.Session["param"].ToString();

            switch (str4)
            {
                case "DailyCutD2D":
                    {
                        this.ReportViewer1.LocalReport.ReportPath = base.Server.MapPath("Cut2Finish.rdlc");
                        SqlDataAdapter adapter2 = new SqlDataAdapter("Sp_Web_GetCut2FinishSummaryXFty '" + this.Session["dt1"].ToString() + "','" + this.Session["dt2"].ToString() + "'", this.cn);
                        DataSet set2 = new DataSet();
                        adapter2.Fill(set2);
                        ReportDataSource source2 = new ReportDataSource("DataSet1", set2.Tables[0]);
                        this.ReportViewer1.LocalReport.DataSources.Clear();
                        this.ReportViewer1.LocalReport.DataSources.Add(source2);
                        ReportParameterCollection parameters2 = new ReportParameterCollection();
                        parameters2.Add(new ReportParameter("rptname", "Cutting to Finish Summery By Ex-Factory Date For " + this.Session["dt1"].ToString() + " To " + this.Session["dt2"].ToString()));
                        this.ReportViewer1.LocalReport.SetParameters(parameters2);
                        break;
                    }
            }

            byte[] buffer = this.ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out strArray, out warningArray);
            base.Response.Clear();
            base.Response.Buffer = true;
            base.Response.ContentType = "application/pdf";
            base.Response.BinaryWrite(buffer.ToArray<byte>());
            base.Response.End();
        }
    }
}