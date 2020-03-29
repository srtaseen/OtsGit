using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class Spreading_Report2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindddlbuyer();
        }
    }

    private void Bindddlbuyer()
    {
        ddlbuyer.AppendDataBoundItems = true;
        //SqlConnection conn = new SqlConnection(dbcon.x);
        String strQuery = "select byr_id,byr_nm from Buyer_Tab order by byr_nm ASC ";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            ddlbuyer.DataSource = cmd.ExecuteReader();
            ddlbuyer.DataTextField = "byr_nm";
            ddlbuyer.DataValueField = "byr_id";

            ddlbuyer.DataBind();
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

    protected void ddlbuyer_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlStyle.Items.Clear();
        ddlStyle.Items.Add(new ListItem("-", ""));
        ddlStyle.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select  DISTINCT ord_no FROM Article_Master where ord_buyer='" + ddlbuyer.SelectedItem.Value + "' ";
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = strQuery1;
        cmd1.Connection = conn;
        try
        {
            conn.Open();
            ddlStyle.DataSource = cmd1.ExecuteReader();
            ddlStyle.DataTextField = "ord_no";
            //ddlStyle.DataValueField = "ord_id";
            ddlStyle.DataBind();
            if (ddlStyle.Items.Count > 1)
            {
                ddlStyle.Enabled = true;
            }
            else
            {


                ddlStyle.Enabled = false;
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

    protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlarticle.Items.Clear();
        ddlarticle.Items.Add(new ListItem("-", ""));
        ddlarticle.AppendDataBoundItems = true;

        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select  DISTINCT art_no FROM Article_Master where ord_no='" + ddlStyle.SelectedItem.Value + "' ";
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = strQuery1;
        cmd1.Connection = conn;
        try
        {
            conn.Open();
            ddlarticle.DataSource = cmd1.ExecuteReader();
            ddlarticle.DataTextField = "art_no";
            //ddlStyle.DataValueField = "ord_id";
            ddlarticle.DataBind();
            if (ddlarticle.Items.Count > 1)
            {
                ddlarticle.Enabled = true;
            }
            else
            {


                ddlarticle.Enabled = false;
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

    protected void ddlarticle_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownpo.Items.Clear();
        DropDownpo.Items.Add(new ListItem("-", ""));
        DropDownpo.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);

        String strQuery = "select DISTINCT po_id,po_no FROM PO_Master where art_no='" + ddlarticle.SelectedItem.Text + "'";
        SqlCommand cmd = new SqlCommand();


        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            DropDownpo.DataSource = cmd.ExecuteReader();
            DropDownpo.DataTextField = "po_no";
            DropDownpo.DataValueField = "po_id";
            DropDownpo.DataBind();
            if (DropDownpo.Items.Count > 1)
            {
                DropDownpo.Enabled = true;

            }
            else
            {


                DropDownpo.Enabled = false;
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        ShowReport();

    }
    private void ShowReport()
    {
        ReportViewer1.Reset();

        ReportDataSource dsOctober16 = new ReportDataSource("DataSet1", GetOctober16());
        ReportDataSource dsNovember16 = new ReportDataSource("DataSet2", GetNovember16());
        //ReportDataSource dsDecember16 = new ReportDataSource("DataSet3", GetDecember16());
        //ReportDataSource dsAugust4th = new ReportDataSource("DataSet4", GetAugust4th());

        ReportViewer1.LocalReport.DataSources.Add(dsOctober16);
        ReportViewer1.LocalReport.DataSources.Add(dsNovember16);
        //ReportViewer1.LocalReport.DataSources.Add(dsDecember16);
        //ReportViewer1.LocalReport.DataSources.Add(dsAugust4th);


        ReportViewer1.LocalReport.ReportPath = "Spreading_Report2.rdlc";

        //ReportViewer1.LocalReport.Refresh();


        //testing pdf

        var bytes = ReportViewer1.LocalReport.Render("PDF");
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "inline;attachment; filename=Sample.pdf");
        Response.BinaryWrite(bytes);
        Response.Flush(); // send it to the client to download
        Response.Clear();

    }

    private DataTable GetOctober16()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("select distinct buyer,ord_no,art_no,po_no,po_qty,input_qty,cons,laywght,gsm,cut_no,febwdth,merwdth,merlnth,mereff,cutwstg,sizeratio,supervisor from Cutting_Spreading_Master where po_no= '" + DropDownpo.SelectedItem.Text + "' ", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }

    private DataTable GetNovember16()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("select batch_no,shade_no,roll_no,kg,meter,plies,act_cut,reject,Req_cut,ent_dt,po_no,input_qty,sizeratio from Cutting_Spreading_Master where po_no= '" + DropDownpo.SelectedItem.Text + "' ", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }


    
}