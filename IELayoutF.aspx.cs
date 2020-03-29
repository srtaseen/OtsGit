using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IELayoutF : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    WorkingDay wd = new WorkingDay();
    int index;
    string str;
    decimal total = 0;
    int totalmc = 0;
    int totalmn = 0;
    int srl = 0;
    ArrayList PrcsSrl = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Bindddlbuyer();
        btnGetSelected.Visible = false;
        saveProcess.Visible = false;
        GvProcessHeader.Visible = false;

        if (!IsPostBack)
        {
            Bindddlbuyer();
        }

    }

    private void Bindddlbuyer()
    {
        GetByr.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery = "select byr_id,byr_nm from Buyer_Tab order by byr_nm ASC ";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            GetByr.DataSource = cmd.ExecuteReader();
            GetByr.DataTextField = "byr_nm";
            GetByr.DataValueField = "byr_id";

            GetByr.DataBind();
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
    protected void GetByr_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetStn.Items.Clear();
        GetStn.Items.Add(new ListItem("-", ""));
        GetStn.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select  DISTINCT ord_no FROM Article_Master where ord_buyer='" + GetByr.SelectedItem.Value + "' ";
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = strQuery1;
        cmd1.Connection = conn;
        try
        {
            conn.Open();
            GetStn.DataSource = cmd1.ExecuteReader();
            GetStn.DataTextField = "ord_no";
            //ddlStyle.DataValueField = "ord_id";
            GetStn.DataBind();
            if (GetStn.Items.Count > 1)
            {
                GetStn.Enabled = true;
            }
            else
            {
                GetStn.Enabled = false;
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
    protected void GetStn_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetArticle.Items.Clear();
        GetArticle.Items.Add(new ListItem("-", ""));
        GetArticle.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select  DISTINCT art_id,art_no FROM Article_Master where ord_no='" + GetStn.SelectedItem.Value + "'";
        //"' and art_id not in (select art_id from IEMaster where Style='" + GetStn.SelectedItem.Value + "')";
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = strQuery1;
        cmd1.Connection = conn;
        try
        {
            conn.Open();
            GetArticle.DataSource = cmd1.ExecuteReader();
            GetArticle.DataTextField = "art_no";
            GetArticle.DataValueField = "art_id";
            GetArticle.DataBind();
            if (GetArticle.Items.Count > 1)
            {
                GetArticle.Enabled = true;
            }
            else
            {
                GetArticle.Enabled = false;
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

    protected void GetArticle_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetPo.Items.Clear();
        //GetPo.Items.Add(new ListItem("-", ""));
        //GetPo.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        try
        {
            DataTable dt = new DataTable();
            //String strQuery = "select distinct a.po_no,b.gmtyp as art_item,b.gmtid,a.Fact_nm from view_Article_Po a join GarmentsType b on a.art_item = b.gmtid where art_no='" + GetArticle.SelectedItem.Value + "' and a.po_no not in (select Po_no from Line_Booking) ";

            String strQuery = "select am.art_item,gm.gmtyp from Article_Master am join GarmentsType gm on am.art_item=gm.gmtid where am.art_no='" + GetArticle.SelectedItem.Text + "' ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = conn;

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //If you want to get mutiple data from the database then you need to write a simple looping 
                GetGType.Text = dt.Rows[0]["gmtyp"].ToString();
                //GetFactory.Text = dt.Rows[0]["Fact_nm"].ToString();
                Session["GType"] = GetGType.Text;
                Session["GTypeId"] = dt.Rows[0]["art_item"];
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

    protected void btnfindG_Click(object sender, EventArgs e)
    {
        BindGvM();
        btnGetSelected.Visible = false;
        GvProcessHeader.Visible = true;
    }

    protected void BindGvM()
    {
        conn.Open();

        //lblGType.Text = Session["GType"].ToString();
        int gType = int.Parse(Session["GTypeId"].ToString());
        //string strSelectCmd = "SELECT  * FROM View_Tna_Plan WHERE PO_Ship_Date is NULL AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND TnaByrNm = '" + ddbuyerM.SelectedItem.Value + "' order by ord_no,po_xfactory ASC";

        string strSelectCmd = @"select p.Id,p.OperationName,p.MachineName,gtp.SMV,gtp.MachineQty,gtp.ManQty from tblGtypeProcess gtp join tblProcess p on gtp.Process=p.Id
                                join GarmentsType g on gtp.GType = g.gmtid  where g.gmtid = " + gType;

        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Session["SelectedProcess"] = null;


        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GvProcess.DataSource = ds;
            GvProcess.DataBind();
            int columncount = GvProcess.Rows[0].Cells.Count;
            GvProcess.Rows[0].Cells.Clear();
            GvProcess.Rows[0].Cells.Add(new TableCell());
            GvProcess.Rows[0].Cells[0].ColumnSpan = columncount;
            GvProcess.Rows[0].Cells[0].Text = "";

        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrder"] = ds.Tables[0];
            //Search Option-RUS
            GvProcess.DataSource = ds;
            GvProcess.DataBind();
            //Session["GTypeId"] = dt.Rows[0]["art_item"];
            //Session["PId"] = GvProcess.Rows[0].Cells[0].
        }

    }


    protected void GetSelectedRecords(object sender, EventArgs e)
    {
        saveProcess.Visible = true;       
        
        gvSelected.DataSource = this.SelectedProcess;
        gvSelected.DataBind();

        GvProcessHeader.Visible = true;
    }

    protected void gvSelected_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqy = (Label)e.Row.FindControl("lblqty");
            decimal qty = decimal.Parse(lblqy.Text);
            total = total + qty;   ////SMV

            Label lblmcqty = (Label)e.Row.FindControl("lblmcqty");
            int mcqty = int.Parse(lblmcqty.Text);
            totalmc = totalmc + mcqty;

            Label lblmnqty = (Label)e.Row.FindControl("lblmnqty");
            int mnqty = int.Parse(lblmnqty.Text);
            totalmn = totalmn + mnqty;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalqty = (Label)e.Row.FindControl("lblTotalqty");
            lblTotalqty.Text = total.ToString();
            txtSmv.Text = lblTotalqty.Text;
            if (total > 1 && total <= 5)
            {
                txtPlanEff.Text = Convert.ToString(100);
            }

            if (total > 5 && total <= 8)
            {
                txtPlanEff.Text = Convert.ToString(90);
            }

            if (total > 8 && total <= 11)
            {
                txtPlanEff.Text = Convert.ToString(85);
            }

            if (total > 11 && total <= 14)
            {
                txtPlanEff.Text = Convert.ToString(80);
            }
			
			if (total > 14 && total <= 18)
            {
                txtPlanEff.Text = Convert.ToString(75);
            }

            if (total > 18)
            {
                txtPlanEff.Text = Convert.ToString(70);
            }

            Label lblTotalmcqty = (Label)e.Row.FindControl("lblTotalmcqty");
            lblTotalmcqty.Text = totalmc.ToString();

            Label lblTotalmnqty = (Label)e.Row.FindControl("lblTotalmnqty");
            lblTotalmnqty.Text = totalmn.ToString();

            txtHelper.Text = Convert.ToString(totalmn - totalmc);
            txtMo.Text = totalmc.ToString();

            int mo = Convert.ToInt32(txtMo.Text);
            int hr = Convert.ToInt32(txtHelper.Text);
            int plneff = (String.IsNullOrEmpty(txtPlanEff.Text)) ? 0: Convert.ToInt32(txtPlanEff.Text);
            decimal smv = Convert.ToDecimal(txtSmv.Text);
            int manpower = Convert.ToInt32(mo) + Convert.ToInt32(hr);
            txtTargetHr.Text = Convert.ToString(Math.Round(manpower * 60 * plneff / 100 / smv));
        }
    }


    protected void getLayout_Click(object sender, EventArgs e)
    {
        string txtautoid = ((TextBox)(gvSelected.FooterRow.Cells[2].Controls[0])).Text;
        txtSmv.Text = txtautoid;
        GvProcessHeader.Visible = true;
    }

    protected void saveProcess_Click(object sender, EventArgs e)
    {       

        SqlConnection con = new SqlConnection(DbConnect.x);    

        //Master Data Insert
        SqlCommand cmd = new SqlCommand("uspInsertIEMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Style", SqlDbType.NVarChar).Value = GetStn.SelectedValue;
        cmd.Parameters.AddWithValue("@art_id", SqlDbType.Int).Value = GetArticle.SelectedValue;
        cmd.Parameters.AddWithValue("@PEffeciency", SqlDbType.TinyInt).Value = txtPlanEff.Text.Trim();
        cmd.Parameters.AddWithValue("@TotSmv", SqlDbType.Decimal).Value = txtSmv.Text.Trim();
        cmd.Parameters.AddWithValue("@MOperator", SqlDbType.TinyInt).Value = txtMo.Text.Trim();
        cmd.Parameters.AddWithValue("@Helper", SqlDbType.TinyInt).Value = txtHelper.Text.Trim();
        cmd.Parameters.AddWithValue("@TargetPHr", SqlDbType.SmallInt).Value = txtTargetHr.Text.Trim();

        con.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        //con.Close();
        //con.Dispose();

        // Details Data Insert
        foreach (GridViewRow row in gvSelected.Rows)
        {
            //DataTable dt = this.SelectedProcess;
            SqlCommand cmdd = new SqlCommand("uspInsertIEDetails", con);
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@art_id", SqlDbType.Int).Value = GetArticle.SelectedValue;

            int pid = Convert.ToInt32(((Label)row.FindControl("lblPId")).Text);
            cmdd.Parameters.AddWithValue("@ProcessId", pid);
            //int srl = Convert.ToInt32((row.Cells[0]).Text);
            //cmdd.Parameters.AddWithValue("@SrlNo", srl);

            //con.Open();
            cmdd.ExecuteNonQuery();
            cmdd.Dispose();
            //con.Dispose();
        }


        con.Close();
        gvSelected.DataSource = null;
        gvSelected.DataBind();

        GvProcess.DataSource = null;
        GvProcess.DataBind();

        txtHelper.Text = "";
        txtMo.Text = "";
        txtPlanEff.Text = "";
        txtSmv.Text = "";
        txtTargetHr.Text = "";
        GetGType.Text = "";
        GetByr.Items.Clear();
        GetStn.Items.Clear();
        GetArticle.Items.Clear();
        saveProcess.Visible = false;

        Response.Redirect(Request.RawUrl);
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(DbConnect.x);

        //Master Data Insert
        SqlCommand cmd = new SqlCommand("GetIELayoutPlan", con);
        cmd.CommandType = CommandType.StoredProcedure;        

        cmd.Parameters.Add(new SqlParameter("@byr_nm", GetByr.SelectedItem.ToString()));
        cmd.Parameters.Add(new SqlParameter("@ord_no", GetStn.SelectedValue.ToString()));
        cmd.Parameters.Add(new SqlParameter("@art_id", int.Parse(GetArticle.SelectedValue.ToString())));
        cmd.Parameters.Add(new SqlParameter("@gmtyp", GetGType.Text.Trim()));

        con.Open();
        da.SelectCommand = cmd;
        da.Fill(ds);
        //cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();

        Session["IELayoutRpt"] = ds;

        this.runjQueryCode("window.open('IELayoutFReport.aspx','popup','location=1,status=1,left=0,top=0,scrollbars=1,width=970,height=600')");
    }

    private string getjQueryCode(string jsCodetoRun)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("$(document).ready(function() {");
        builder.AppendLine(jsCodetoRun);
        builder.AppendLine(" });");
        return builder.ToString();
    }
    
    private void runjQueryCode(string jsCodetoRun)
    {
        ScriptManager current = ScriptManager.GetCurrent(this);
        if ((current != null) && current.IsInAsyncPostBack)
        {
            ScriptManager.RegisterClientScriptBlock((Page)this, typeof(Page), Guid.NewGuid().ToString(), this.getjQueryCode(jsCodetoRun), true);
        }
        else
        {
            base.ClientScript.RegisterClientScriptBlock(typeof(Page), Guid.NewGuid().ToString(), this.getjQueryCode(jsCodetoRun), true);
        }
    }



    //2019-05-21 added code------------
    protected void chkRow_CheckedChanged(object sender, EventArgs e)
    {
        saveProcess.Visible = true;
        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox cb1 = (CheckBox)GvProcess.Rows[index].FindControl("chkRow");
        DataTable dt = this.SelectedProcess;
        DataRow dataRow = dt.NewRow();
        srl =  (String.IsNullOrEmpty(hidSrlNo.Value))? 0 : int.Parse(hidSrlNo.Value);
        if (cb1.Checked == true)
        {
            srl = srl + 1;
            //PrcsSrl.Add(srl);
            dataRow["SrlNo"] = srl;
            dataRow["Id"] = Convert.ToInt32((row.Cells[1].FindControl("lblProcessId") as Label).Text);
            dataRow["OperationName"] = (row.Cells[2].FindControl("lblOperation") as Label).Text;
            dataRow["MachineName"] = (row.Cells[3].FindControl("lblMachine") as Label).Text;
            dataRow["SMV"] = (row.Cells[4].FindControl("lblSmv") as Label).Text;
            dataRow["MachineQty"] = (row.Cells[5].FindControl("lblMcQty") as Label).Text;
            dataRow["ManQty"] = (row.Cells[6].FindControl("lblMnQty") as Label).Text;
            dt.Rows.Add(dataRow);
            this.SelectedProcess.AcceptChanges();
            Session.Add("SelectedProcess", SelectedProcess);
            hidSrlNo.Value = srl.ToString();

            gvSelected.DataSource = this.SelectedProcess;
            gvSelected.DataBind();
            GvProcessHeader.Visible = true;
        }
        else if (cb1.Checked == false)
        {
            int i = 0;
            int id = Convert.ToInt32((row.Cells[1].FindControl("lblProcessId") as Label).Text);
            DataRow[] drs = this.SelectedProcess.Select("Id=" + id);
            int sr = Convert.ToInt16(drs[0]["SrlNo"]);
            for (i=sr; i< SelectedProcess.Rows.Count; i++)
            {
                SelectedProcess.Rows[i]["SrlNo"] = i;
                this.SelectedProcess.AcceptChanges();
            }
            drs[0].Delete();
            this.SelectedProcess.AcceptChanges();
            hidSrlNo.Value = i.ToString();
            gvSelected.DataSource = this.SelectedProcess;
            gvSelected.DataBind();
        }

        //Here Write the code to connect to your database and update the status by 
        //sending the checkboxstatus as variable and update in the database.
    }

    public DataTable SelectedProcess
    {
        get
        {
            object obj = this.Session["SelectedProcess"];
            if (obj != null)
            {
                return (DataTable)obj;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("SrlNo", typeof(Int16));
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("OperationName", typeof(string));
            dt.Columns.Add("MachineName", typeof(string));
            dt.Columns.Add("SMV", typeof(string));
            dt.Columns.Add("MachineQty", typeof(string));
            dt.Columns.Add("ManQty", typeof(string));

            //AdjGridData.Tables.Add(dt1);
            this.Session["SelectedProcess"] = dt;
            return SelectedProcess;
        }
    }
}
    

    
    
