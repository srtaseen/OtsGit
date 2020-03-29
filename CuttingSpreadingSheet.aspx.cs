using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Configuration;

public partial class CuttingSpreadingSheet : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindddlbuyer();
            SetInitialRow();
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

    protected void DropDownpo_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchProductData();

    }

    private void FetchProductData()
    {


        string queryString = "SELECT po_quantity FROM PO_Master where po_id=@po_id ";
        SqlCommand Syscmd = new SqlCommand(queryString, conn);
        Syscmd.Parameters.AddWithValue("po_id", DropDownpo.SelectedItem.Value);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt != null && dt.Rows.Count > 0)
        {
            //txtocd.Text = Convert.ToDateTime(dt.Rows[0]["ord_cnfdate"]).ToString("MM/dd/yyyy");
            //txtxftd.Text = Convert.ToDateTime(dt.Rows[0]["po_xfactory"]).ToString("MM/dd/yyyy");
            txtPQty.Text = dt.Rows[0]["po_quantity"].ToString();
            //txtled.Text = dt.Rows[0]["po_led"].ToString();
            //txtbpsd.Text = Convert.ToDateTime(dt.Rows[0]["po_bpsd"]).ToString("MM/dd/yyyy");
            //btntest1.Enabled = false;
            txtInputQty.Enabled = true;
            txtCons.Enabled = true;
            txtLayWght.Enabled = true;
            txtGsm.Enabled = true;
            txtCuttNo.Enabled = true;
            txtFebWdth.Enabled = true;
            txtMerWdth.Enabled = true;
            txtMerLnth.Enabled = true;
            txtMerEff.Enabled = true;
            txtCutWstg.Enabled = true;
            txtSizeRatio.Enabled = true;
            txtSupervisor.Enabled = true;
        }


    }


    private ArrayList GetDummyData()
    {
        ArrayList arr = new ArrayList();
        arr.Add(new ListItem("Long Pant", "1"));
        arr.Add(new ListItem("T-Shirt", "2"));
        arr.Add(new ListItem("Short Sleev", "3"));

        return arr;
    }

    //get shipmode
    private void FillDropDownList(DropDownList ddl)
    {
        ArrayList arr = GetDummyData();
        foreach (ListItem item in arr)
        {
            ddl.Items.Add(item);
        }
    }
    //add new row
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        //Define the Columns
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column0", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dt.Columns.Add(new DataColumn("Column6", typeof(string)));
        dt.Columns.Add(new DataColumn("Column7", typeof(string)));

        //Add a Dummy Data on Initial Load
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;
        //Bind the DataTable to the Grid
        GridViewpo.DataSource = dt;
        GridViewpo.DataBind();

        //Extract and Fill the DropDownList with Data
        //DropDownList ddlItem = (DropDownList)GridViewpo.Rows[0].Cells[2].FindControl("ddlItem");
        //FillDropDownList(ddlItem);
    }
    private void AddNewRowToGrid()
    {
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                //add new row to DataTable
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Store the current data to ViewState
                ViewState["CurrentTable"] = dtCurrentTable;

                for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                {

                    TextBox txtBatch = (TextBox)GridViewpo.Rows[i].Cells[0].FindControl("txtBatch");
                    TextBox txtShade = (TextBox)GridViewpo.Rows[i].Cells[1].FindControl("txtShade");
                    TextBox txtRoll = (TextBox)GridViewpo.Rows[i].Cells[2].FindControl("txtRoll");
                    TextBox txtKg = (TextBox)GridViewpo.Rows[i].Cells[3].FindControl("txtKg");
                    TextBox txtMeter = (TextBox)GridViewpo.Rows[i].Cells[4].FindControl("txtMeter");
                    TextBox txtPlies = (TextBox)GridViewpo.Rows[i].Cells[5].FindControl("txtPlies");
                    TextBox txtActCut = (TextBox)GridViewpo.Rows[i].Cells[6].FindControl("txtActCut");
                    TextBox txtRej = (TextBox)GridViewpo.Rows[i].Cells[6].FindControl("txtRej");


                    // Update the DataRow with the DDL Selected Items
                    dtCurrentTable.Rows[i]["Column0"] = txtBatch.Text;
                    dtCurrentTable.Rows[i]["Column1"] = txtShade.Text;
                    dtCurrentTable.Rows[i]["Column2"] = txtRoll.Text;
                    dtCurrentTable.Rows[i]["Column3"] = txtKg.Text;
                    dtCurrentTable.Rows[i]["Column4"] = txtMeter.Text;
                    dtCurrentTable.Rows[i]["Column5"] = txtPlies.Text;
                    dtCurrentTable.Rows[i]["Column6"] = txtActCut.Text;
                    dtCurrentTable.Rows[i]["Column7"] = txtRej.Text;
                    //dtCurrentTable.Rows[i]["Column2"] = ddlItem.SelectedItem.Text;
                    //For Smv

                }
                //Rebind the Grid with the current data
                GridViewpo.DataSource = dtCurrentTable;
                GridViewpo.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        //Set Previous Data on Postbacks
        SetPreviousData();
    }

    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Set the Previous Selected Items on Each DropDownList on Postbacks
                    TextBox txtBatch = (TextBox)GridViewpo.Rows[rowIndex].Cells[0].FindControl("txtBatch");
                    TextBox txtShade = (TextBox)GridViewpo.Rows[rowIndex].Cells[1].FindControl("txtShade");
                    TextBox txtRoll = (TextBox)GridViewpo.Rows[rowIndex].Cells[2].FindControl("txtRoll");
                    TextBox txtKg = (TextBox)GridViewpo.Rows[rowIndex].Cells[3].FindControl("txtKg");
                    TextBox txtMeter = (TextBox)GridViewpo.Rows[rowIndex].Cells[4].FindControl("txtMeter");
                    TextBox txtPlies = (TextBox)GridViewpo.Rows[rowIndex].Cells[5].FindControl("txtPlies");
                    TextBox txtActCut = (TextBox)GridViewpo.Rows[rowIndex].Cells[6].FindControl("txtActCut");
                    TextBox txtRej = (TextBox)GridViewpo.Rows[rowIndex].Cells[7].FindControl("txtRej");
                    

                    if (i < dt.Rows.Count - 1)
                    {
                        txtBatch.Text = dt.Rows[i]["Column0"].ToString();
                        txtShade.Text = dt.Rows[i]["Column1"].ToString();
                        txtRoll.Text = dt.Rows[i]["Column2"].ToString();
                        txtKg.Text = dt.Rows[i]["Column3"].ToString();
                        txtMeter.Text = dt.Rows[i]["Column4"].ToString();
                        txtPlies.Text = dt.Rows[i]["Column5"].ToString();
                        txtActCut.Text = dt.Rows[i]["Column6"].ToString();
                        txtRej.Text = dt.Rows[i]["Column7"].ToString();
                        
                        
                    }
                    rowIndex++;
                }
            }
        }
    }
    //protected void ButtonAdd_Click(object sender, EventArgs e)
    //{
    //    AddNewRowToGrid();
    //}
    protected void FunctionB_ServerClick(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void GridViewpo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //DropDownList ddlItem = (e.Row.FindControl("ddlItem") as DropDownList);
            //ddlItem.DataSource = GetData("select gmtid,gmtyp from GarmentsType");
            //ddlItem.DataTextField = "gmtyp";
            //ddlItem.DataValueField = "gmtid";


            //Add Default Item in the DropDownList
            //ddlItem.Items.Insert(0, new ListItem("-"));
            //ddlItem.DataBind();

            //Select the Country of Customer in DropDownList
            //string item = (e.Row.FindControl("lblItem") as Label).Text;
            //ddlItem.Items.FindByValue(item).Selected = true;
        }
    }

    protected void Btnclr_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl); //page refreash
    }
    protected void Btnsave_Click1(object sender, EventArgs e)
    {
        int ord_id = 0;

        SqlConnection conn = new SqlConnection(DbConnect.x);
        //string c1 = cb1.Checked ? "Y" : "N";
        //string c2 = cb2.Checked ? "Y" : "N";
        //string c3 = cb3.Checked ? "Y" : "N";
        //string c4 = cb4.Checked ? "Y" : "N";
        //string c5 = cb5.Checked ? "Y" : "N";
        //string c6 = cb6.Checked ? "Y" : "N";
        //string c7 = cb7.Checked ? "Y" : "N";



        for (int i = 0; i < GridViewpo.Rows.Count; i++)
        {
            if (GridViewpo.Rows[i].Cells[3].Text != null)
            {
                SqlCommand Syscmd = new SqlCommand();
                Syscmd.CommandType = CommandType.StoredProcedure;
                Syscmd.CommandText = "Cutting_Spreading_Data";



                Syscmd.Parameters.AddWithValue("@buyer", ddlbuyer.SelectedItem.Text);
                Syscmd.Parameters.AddWithValue("@ord_no", ddlStyle.SelectedValue);
                Syscmd.Parameters.AddWithValue("@art_no", ddlarticle.SelectedValue);
                Syscmd.Parameters.AddWithValue("@po_no", DropDownpo.SelectedItem.Text);
                Syscmd.Parameters.AddWithValue("@po_qty", txtPQty.Text.Trim());
                Syscmd.Parameters.AddWithValue("@input_qty", txtInputQty.Text.Trim());
                Syscmd.Parameters.AddWithValue("@cons", txtCons.Text.Trim());
                Syscmd.Parameters.AddWithValue("@laywght", txtLayWght.Text.Trim());
                Syscmd.Parameters.AddWithValue("@gsm", txtGsm.Text.Trim());
                Syscmd.Parameters.AddWithValue("@cut_no", txtCuttNo.Text.Trim());
                Syscmd.Parameters.AddWithValue("@febwdth", txtFebWdth.Text.Trim());
                Syscmd.Parameters.AddWithValue("@merwdth", txtMerWdth.Text.Trim());
                Syscmd.Parameters.AddWithValue("@merlnth", txtMerLnth.Text.Trim());
                Syscmd.Parameters.AddWithValue("@mereff", txtMerEff.Text.Trim());
                Syscmd.Parameters.AddWithValue("@cutwstg", txtCutWstg.Text.Trim());
                Syscmd.Parameters.AddWithValue("@sizeratio", txtSizeRatio.Text.Trim());
                Syscmd.Parameters.AddWithValue("@supervisor", txtSupervisor.Text.Trim());


                TextBox txtBatch = (TextBox)GridViewpo.Rows[i].FindControl("txtBatch");
                string batch = txtBatch.Text + GridViewpo.Rows[i].Cells[0].Text;
                Syscmd.Parameters.AddWithValue("@batch_no", batch);

                TextBox txtShade = (TextBox)GridViewpo.Rows[i].FindControl("txtShade");
                string shade = txtShade.Text + GridViewpo.Rows[i].Cells[1].Text;
                Syscmd.Parameters.AddWithValue("@shade_no", shade);

                TextBox txtRoll = (TextBox)GridViewpo.Rows[i].FindControl("txtRoll");
                string roll = txtRoll.Text + GridViewpo.Rows[i].Cells[2].Text;
                Syscmd.Parameters.AddWithValue("@roll_no", roll);

                TextBox txtKg = (TextBox)GridViewpo.Rows[i].FindControl("txtKg");
                string kg = txtKg.Text + GridViewpo.Rows[i].Cells[3].Text;
                Syscmd.Parameters.AddWithValue("@kg", kg);

                TextBox txtMeter = (TextBox)GridViewpo.Rows[i].FindControl("txtMeter");
                string meter = txtMeter.Text + GridViewpo.Rows[i].Cells[4].Text;
                Syscmd.Parameters.AddWithValue("@meter ", meter);


                TextBox txtPlies = (TextBox)GridViewpo.Rows[i].FindControl("txtPlies");
                string plies = txtPlies.Text + GridViewpo.Rows[i].Cells[5].Text;
                Syscmd.Parameters.AddWithValue("@plies", plies);

                TextBox txtActCut = (TextBox)GridViewpo.Rows[i].FindControl("txtActCut");
                string actcut = txtActCut.Text + GridViewpo.Rows[i].Cells[6].Text;
                Syscmd.Parameters.AddWithValue("@act_cut", actcut);

                TextBox txtRej = (TextBox)GridViewpo.Rows[i].FindControl("txtRej");
                string rej = txtRej.Text + GridViewpo.Rows[i].Cells[7].Text;
                Syscmd.Parameters.AddWithValue("@reject", rej);


                //DropDownList ddl = (DropDownList)GridViewpo.Rows[i].FindControl("ddlItem");
                //string item = ddl.SelectedValue + GridViewpo.Rows[i].Cells[2].Text;
                //Syscmd.Parameters.AddWithValue("@art_item", item);

                ////For Smv
                //TextBox txtSmv = (TextBox)GridViewpo.Rows[i].FindControl("txtSmv");
                //string smv = txtSmv.Text + GridViewpo.Rows[i].Cells[3].Text;
                //Syscmd.Parameters.AddWithValue("@art_smv", smv);


                Syscmd.Connection = conn;
                conn.Open();

                Syscmd.ExecuteNonQuery();

                conn.Close();

                string message = string.Empty;
                switch (ord_id)
                {
                    case -1:
                        message = "dhdghdfgdfg";
                        break;

                    default:

                        message = "Insert successful. Activation email has been sent to your email.";

                        break;
                }

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

            }

        }
        Response.Redirect(Request.RawUrl); //page refreash
    }



    private DataSet GetData(string query)
    {
        //string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = conn;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }
}