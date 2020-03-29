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

public partial class ArticleMaster : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGetByr();
            SetInitialRow();
        }
    }
    private void BindGetByr()
    {
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("Select byr_id, byr_nm FROM Buyer_Tab", conn);
            GetByr.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GetByr.DataTextField = "byr_nm";
            GetByr.DataValueField = "byr_id";
            GetByr.DataSource = rdr;
            GetByr.DataBind();
        }
    }
    //private void BindGetGType()
    //{
    //    using (SqlConnection conn = new SqlConnection(DbConnect.x))
    //    {
    //        SqlCommand cmd = new SqlCommand("Select gmtid,gmtyp FROM GarmentsType", conn);
    //        GetGType.AppendDataBoundItems = true;
    //        conn.Open();
    //        SqlDataReader rdr = cmd.ExecuteReader();
    //        GetGType.DataTextField = "gmtyp";
    //        GetGType.DataValueField = "gmtid";
    //        GetGType.DataSource = rdr;
    //        GetGType.DataBind();
    //    }
    //}
    //private void BindGetStType()
    //{
    //    using (SqlConnection conn = new SqlConnection(DbConnect.x))
    //    {
    //        SqlCommand cmd = new SqlCommand("Select styid,stytyp FROM StyleType", conn);
    //        GetStType.AppendDataBoundItems = true;
    //        conn.Open();
    //        SqlDataReader rdr = cmd.ExecuteReader();
    //        GetStType.DataTextField = "stytyp";
    //        GetStType.DataValueField = "styid";
    //        GetStType.DataSource = rdr;
    //        GetStType.DataBind();
    //    }
    //}
    //private void BindGetFactory()
    //{
    //    using (SqlConnection conn = new SqlConnection(DbConnect.x))
    //    {
    //        SqlCommand cmd = new SqlCommand("Select Fact_id,Fact_nm FROM Factory_Tab", conn);
    //        GetFactory.AppendDataBoundItems = true;
    //        conn.Open();
    //        SqlDataReader rdr = cmd.ExecuteReader();
    //        GetFactory.DataTextField = "Fact_nm";
    //        GetFactory.DataValueField = "Fact_id";
    //        GetFactory.DataSource = rdr;
    //        GetFactory.DataBind();
    //    }
    //}

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
        DropDownList ddlItem = (DropDownList)GridViewpo.Rows[0].Cells[2].FindControl("ddlItem");
        FillDropDownList(ddlItem);
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

                    TextBox txtArt = (TextBox)GridViewpo.Rows[i].Cells[0].FindControl("txtArt");
                    TextBox txtQty = (TextBox)GridViewpo.Rows[i].Cells[1].FindControl("txtQty");

                    //extract the DropDownList Selected Items
                    DropDownList ddlItem = (DropDownList)GridViewpo.Rows[i].Cells[2].FindControl("ddlItem");
                    //For Smv
                    TextBox txtSmv = (TextBox)GridViewpo.Rows[i].Cells[3].FindControl("txtSmv");

                    // Update the DataRow with the DDL Selected Items
                    dtCurrentTable.Rows[i]["Column0"] = txtArt.Text;
                    dtCurrentTable.Rows[i]["Column1"] = txtQty.Text;
                    //dtCurrentTable.Rows[i]["Column2"] = txtprc.Text;
                    //dtCurrentTable.Rows[i]["Column3"] = txtspdt.Text;
                    //dtCurrentTable.Rows[i]["Column4"] = txtexft.Text;
                    //dtCurrentTable.Rows[i]["Column5"] = txtld.Text;
                    //dtCurrentTable.Rows[i]["Column6"] = txtbss.Text;
                    dtCurrentTable.Rows[i]["Column2"] = ddlItem.SelectedItem.Text;
                    //For Smv
                    dtCurrentTable.Rows[i]["Column3"] = txtSmv.Text;
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
                    TextBox txtArt = (TextBox)GridViewpo.Rows[rowIndex].Cells[0].FindControl("txtArt");
                    TextBox txtQty = (TextBox)GridViewpo.Rows[rowIndex].Cells[1].FindControl("txtQty");
                    //TextBox txtprc = (TextBox)GridViewpo.Rows[rowIndex].Cells[2].FindControl("txtprc");
                    //TextBox txtspdt = (TextBox)GridViewpo.Rows[rowIndex].Cells[3].FindControl("txtspdt");
                    //TextBox txtexft = (TextBox)GridViewpo.Rows[rowIndex].Cells[4].FindControl("txtexft");
                    //TextBox txtld = (TextBox)GridViewpo.Rows[rowIndex].Cells[5].FindControl("txtld");
                    //TextBox txtbss = (TextBox)GridViewpo.Rows[rowIndex].Cells[6].FindControl("txtbss");
                    DropDownList ddlItem = (DropDownList)GridViewpo.Rows[rowIndex].Cells[2].FindControl("ddlItem");
                    //For Smv
                    TextBox txtSmv = (TextBox)GridViewpo.Rows[rowIndex].Cells[3].FindControl("txtSmv");                    
                    //Fill the DropDownList with Data
                   // FillDropDownList(ddl3);

                    if (i < dt.Rows.Count - 1)
                    {
                        txtArt.Text = dt.Rows[i]["Column0"].ToString();
                        txtQty.Text = dt.Rows[i]["Column1"].ToString();
                        //txtprc.Text = dt.Rows[i]["Column2"].ToString();
                        //txtspdt.Text = dt.Rows[i]["Column3"].ToString();
                        //txtexft.Text = dt.Rows[i]["Column4"].ToString();
                        //txtld.Text = dt.Rows[i]["Column5"].ToString();
                        //txtbss.Text = dt.Rows[i]["Column6"].ToString();
                        ddlItem.ClearSelection();
                        ddlItem.Items.FindByText(dt.Rows[i]["Column2"].ToString()).Selected = true;
                        //For Smv
                        txtSmv.Text = dt.Rows[i]["Column3"].ToString();
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
            DropDownList ddlItem = (e.Row.FindControl("ddlItem") as DropDownList);
            ddlItem.DataSource = GetData("select gmtid,gmtyp from GarmentsType");
            ddlItem.DataTextField = "gmtyp";
            ddlItem.DataValueField = "gmtid";
           

            //Add Default Item in the DropDownList
            ddlItem.Items.Insert(0, new ListItem("-"));
            ddlItem.DataBind();

            //Select the Country of Customer in DropDownList
            //string item = (e.Row.FindControl("lblItem") as Label).Text;
            //ddlItem.Items.FindByValue(item).Selected = true;
        }
    }
    //protected void txtspdt_TextChanged(object sender, EventArgs e)
    //{


    //    for (int i = 0; i < GridViewpo.Rows.Count; i++)
    //    {
    //        TextBox txtspdt = (TextBox)GridViewpo.Rows[i].FindControl("txtspdt");
    //        string shipdt = txtspdt.Text + GridViewpo.Rows[i].Cells[3].Text;
    //        TextBox txtexft = (TextBox)GridViewpo.Rows[i].FindControl("txtexft");
    //        string xfctdt = txtexft.Text + GridViewpo.Rows[i].Cells[4].Text;
    //        TextBox txtld = (TextBox)GridViewpo.Rows[i].FindControl("txtld");
    //        string lead = txtexft.Text + GridViewpo.Rows[i].Cells[5].Text;

    //        TextBox txtqun = (TextBox)GridViewpo.Rows[i].FindControl("txtqun");
    //        string quan = txtexft.Text + GridViewpo.Rows[i].Cells[1].Text;

    //        TextBox txtbss = (TextBox)GridViewpo.Rows[i].FindControl("txtbss");
    //        string bpcd = txtbss.Text + GridViewpo.Rows[i].Cells[6].Text;


    //        txtexft.Text = DateTime.Parse(txtspdt.Text).AddDays(-7).ToShortDateString();
    //        DateTime dt1 = DateTime.Parse(txtexft.Text);
    //       // DateTime dt2 = DateTime.Parse(rcvdt.Text);
    //       // TimeSpan ts = dt1 - dt2;
    //       // txtld.Text = ts.TotalDays.ToString();

    //        //short Term
    //        if (int.Parse(txtld.Text) <= 45) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-12).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 45) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-13).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 46) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-14).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 47) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-15).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 48) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-16).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 49) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-17).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 50) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-18).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 51) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-19).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 52) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-20).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 53) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-21).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 54) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-22).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 55) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-23).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 56) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-24).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 57) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-25).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 58) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-26).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 59) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-27).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 60) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-28).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 61) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-29).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 62) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-30).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 63) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-31).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 64) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-31).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 65) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-32).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 66) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-33).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 67) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-34).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 68) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-35).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 69) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-36).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 70) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-37).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 71) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-38).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 72) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-39).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 73) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-40).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 74) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-41).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 75) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-42).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 76) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-43).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 77) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-44).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 78) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-45).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 79) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-46).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 80) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-47).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 81) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-41).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 82) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-41).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 83) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-42).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 84) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-43).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 85) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-43).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 86) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-43).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 87) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-44).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 88) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-44).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 89) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-44).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 90) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-45).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 91) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-45).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 92) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-45).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 93) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-45).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 94) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-45).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 95) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-45).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 96) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-46).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 97) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-46).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 98) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-46).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 99) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-46).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 100) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-47).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 101) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-47).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 102) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-47).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 103) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-47).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 104) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-48).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 105) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-48).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 106) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-48).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 107) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-48).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 108) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-49).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 109) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-49).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 110) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-50).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 111) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-51).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 112) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-52).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 113) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-53).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 114) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-54).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 115) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-55).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 116) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-56).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 116) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-57).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 117) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-58).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 118) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-59).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 119) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-59).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 120) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-60).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 121) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-61).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 122) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-62).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 123) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-63).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 124) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-64).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) == 125) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-65).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) >= 125) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-66).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) >= 130) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-67).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) >= 135) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-68).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) >= 140) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-69).ToShortDateString();

    //        }
    //        if (int.Parse(txtld.Text) >= 145) //50 days order lead time//
    //        {
    //            txtbss.Text = DateTime.Parse(txtexft.Text).AddDays(-70).ToShortDateString();

    //        }



    //    }


    //}
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
                Syscmd.CommandText = "Order_Article_Data";



                Syscmd.Parameters.AddWithValue("@ord_no", stnm.Text.Trim());
                Syscmd.Parameters.AddWithValue("@ord_buyer", GetByr.SelectedValue);

                //Syscmd.Parameters.AddWithValue("@grment_typ", GetGType.SelectedValue);
                //Syscmd.Parameters.AddWithValue("@ord_typ", GetStType.SelectedValue);
                //Syscmd.Parameters.AddWithValue("@ord_factory", GetFactory.SelectedValue);
                //Syscmd.Parameters.AddWithValue("@ord_entdt", entdt.Text.Trim());
                //Syscmd.Parameters.AddWithValue("@ord_cnfdate", rcvdt.Text.Trim());
                //Syscmd.Parameters.AddWithValue("@Yd", c1);
                //Syscmd.Parameters.AddWithValue("@Prnt", c2);
                //Syscmd.Parameters.AddWithValue("@Aop", c3);
                //Syscmd.Parameters.AddWithValue("@Gmw", c4);
                //Syscmd.Parameters.AddWithValue("@Emb", c5);
                //Syscmd.Parameters.AddWithValue("@SolidFab", c6);
                //Syscmd.Parameters.AddWithValue("@YdSolid", c7);

                TextBox txtArt = (TextBox)GridViewpo.Rows[i].FindControl("txtArt");
                string art = txtArt.Text + GridViewpo.Rows[i].Cells[0].Text;
                Syscmd.Parameters.AddWithValue("@art_no", art);

                TextBox txtQty = (TextBox)GridViewpo.Rows[i].FindControl("txtQty");
                string qty = txtQty.Text + GridViewpo.Rows[i].Cells[1].Text;
                Syscmd.Parameters.AddWithValue("@art_quantity", qty);

                //TextBox txtprc = (TextBox)GridViewpo.Rows[i].FindControl("txtprc");
                //string price = txtprc.Text + GridViewpo.Rows[i].Cells[2].Text;
                //Syscmd.Parameters.AddWithValue("@po_price", price);

                //TextBox txtspdt = (TextBox)GridViewpo.Rows[i].FindControl("txtspdt");
                //string shipdt = txtspdt.Text + GridViewpo.Rows[i].Cells[3].Text;
                //Syscmd.Parameters.AddWithValue("@po_shipdt", shipdt);

                //TextBox txtexft = (TextBox)GridViewpo.Rows[i].FindControl("txtexft");
                //string xfctdt = txtexft.Text + GridViewpo.Rows[i].Cells[4].Text;
                //Syscmd.Parameters.AddWithValue("@po_xfactory ", xfctdt);


                //TextBox txtld = (TextBox)GridViewpo.Rows[i].FindControl("txtld");
                //string lead = txtld.Text + GridViewpo.Rows[i].Cells[5].Text;
                //Syscmd.Parameters.AddWithValue("@po_led", lead);

                //TextBox txtbss = (TextBox)GridViewpo.Rows[i].FindControl("txtbss");
                //string bpcd = txtbss.Text + GridViewpo.Rows[i].Cells[6].Text;
                //Syscmd.Parameters.AddWithValue("@po_bpsd", bpcd);


                DropDownList ddl = (DropDownList)GridViewpo.Rows[i].FindControl("ddlItem");
                string item = ddl.SelectedValue + GridViewpo.Rows[i].Cells[2].Text;
                Syscmd.Parameters.AddWithValue("@art_item", item);

                //For Smv
                TextBox txtSmv = (TextBox)GridViewpo.Rows[i].FindControl("txtSmv");
                string smv = txtSmv.Text + GridViewpo.Rows[i].Cells[3].Text;
                Syscmd.Parameters.AddWithValue("@art_smv", smv);


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
        using ( SqlConnection conn = new SqlConnection(DbConnect.x))
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
