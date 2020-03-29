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

public partial class showreport2 : System.Web.UI.Page
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
            DataTable table = get_InformationdataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where Display_AS_Header=1");
            //DataTable table = this.mybll.get_InformationdataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where Display_AS_Header=1");
            string str5 = table.Rows[0]["cCmpName"].ToString();
            string str6 = table.Rows[0]["cAdd1"].ToString();
            string str7 = table.Rows[0]["cAdd2"].ToString();
            switch (str4)
            {
                case "DailyCut":
                    {
                       // DateTime dt = (DateTime)Session["dt1"];
                        this.ReportViewer1.LocalReport.ReportPath = base.Server.MapPath("Dailycutsummery.rdlc");

                        SqlDataAdapter adapter = new SqlDataAdapter("Sp_Web_GetDailyCuttingProd '" + this.Session["dt1"].ToString() + "'," + this.Session["com"].ToString(), this.cn);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        ReportDataSource item = new ReportDataSource("DataSet1", dataSet.Tables[0]);
                        this.ReportViewer1.LocalReport.DataSources.Clear();
                        this.ReportViewer1.LocalReport.DataSources.Add(item);
                        ReportParameterCollection parameters = new ReportParameterCollection();
                        parameters.Add(new ReportParameter("Dailycut", "Daily Cut Summery For " + this.Session["dt1"].ToString()));
                        parameters.Add(new ReportParameter("comp", this.Session["comname"].ToString()));
                        parameters.Add(new ReportParameter("grp", str5));
                        parameters.Add(new ReportParameter("add", str6 + "," + str7));
                        this.ReportViewer1.LocalReport.SetParameters(parameters);
                        this.Session["dt"] = null;
                        this.Session["com"] = null;
                        this.Session["comname"] = null;
                        break;
                    }
                case "DailyCutD2D":
                    {
                        this.ReportViewer1.LocalReport.ReportPath = base.Server.MapPath("DailyCutD2D.rdlc");
                        SqlDataAdapter adapter2 = new SqlDataAdapter("Sp_Web_GetCuttSummaryXFty '" + this.Session["dt1"].ToString() + "','" + this.Session["dt2"].ToString() + "'", this.cn);
                        DataSet set2 = new DataSet();
                        adapter2.Fill(set2);
                        ReportDataSource source2 = new ReportDataSource("DataSet1", set2.Tables[0]);
                        this.ReportViewer1.LocalReport.DataSources.Clear();
                        this.ReportViewer1.LocalReport.DataSources.Add(source2);
                        ReportParameterCollection parameters2 = new ReportParameterCollection();
                        parameters2.Add(new ReportParameter("rptname", "Cutting to input Summery By Ex-Factory Date For " + this.Session["dt1"].ToString() + " To " + this.Session["dt2"].ToString()));
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

    //protected global_asax ApplicationInstance =>
    //    ((global_asax)this.Context.ApplicationInstance);

    //protected DefaultProfile Profile =>
    //    ((DefaultProfile)this.Context.Profile);


    public DataTable get_InformationdataTable(string sqlstatement)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = this.conn.CreateCommand();
        command.CommandText = sqlstatement;
        adapter.SelectCommand = command;
        command.CommandTimeout = 600;
        DataTable dataTable = new DataTable();
        if (this.conn.State == ConnectionState.Closed)
        {
            this.conn.Open();
        }
        adapter.Fill(dataTable);
        if (this.conn.State == ConnectionState.Open)
        {
            this.conn.Close();
        }
        return dataTable;
    }



}