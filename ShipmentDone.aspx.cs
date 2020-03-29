using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

public partial class ShipmentDone : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["dt1"] = tx1.Text;
        Session["dt2"] = tx2.Text;
        if (!IsPostBack)
        {
            BindddlbuyerFind();

        }
        SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "'and (UsrDpt='6' OR UsrGroup='1') and frmnam1 = 'Page5.aspx'  ", conn);
        command.Connection.Open();
        SqlDataReader rdr = command.ExecuteReader();

        if (rdr.HasRows)
        {

        }
        else
        {
            Response.Redirect("page2.aspx");
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This alert from code behind');", true);

        }

        conn.Close();
    }
    //protected void TimerTick(object sender, EventArgs e)
    //{
    //    this.BindGvorder();
    //    Timer1.Enabled = false;
    //    imgLoader.Visible = false;
    //}
    private void BindddlbuyerFind()
    {
        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand("Select byr_id, byr_nm FROM Buyer_Tab", conn);
            ddlbuyerFind.AppendDataBoundItems = true;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            ddlbuyerFind.DataTextField = "byr_nm";
            ddlbuyerFind.DataValueField = "byr_id";
            ddlbuyerFind.DataSource = rdr;
            ddlbuyerFind.DataBind();
            //  ddlbuyerFind.Items.FindByValue(ViewState["Filter"].ToString())
            //.Selected = true;
        }


    }
    protected void BindGvorder()
    {

        conn.Open();
        string strSelectCmd = "SELECT * FROM View_OrderInhand  where ActiveOrder='1' AND PO_Ship_Date is NOT NULL AND po_xfactory Between '" + tx1.Text + "' and '" + tx2.Text + "' AND byr_nm = '" + ddlbuyerFind.SelectedItem.Text + "' order by po_xfactory ASC";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);



        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            Gvorder.DataSource = ds;
            Gvorder.DataBind();
            int columncount = Gvorder.Rows[0].Cells.Count;
            Gvorder.Rows[0].Cells.Clear();
            Gvorder.Rows[0].Cells.Add(new TableCell());
            Gvorder.Rows[0].Cells[0].ColumnSpan = columncount;
            Gvorder.Rows[0].Cells[0].Text = "Note:-Please Select Buyer, Form Date and To Date. Then Click Find";


        }
        else
        {
            //Search Option-RUS
            ViewState["dtOrder"] = ds.Tables[0];
            //Search Option-RUS
            Gvorder.DataSource = ds;
            Gvorder.DataBind();
            Gvorder.Attributes["style"] = "border-collapse:separate";
        }



    }
    protected void BtnOrdFind_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tx1.Text.Trim()))
        {
            BindGvorder();


        }
        else
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Date & Buyer!');", true);


        }

    }
    protected void Gvorder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvorder.PageIndex = e.NewPageIndex;
        BindGvorder();
    }
    protected void Gvorder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["po_no"].ToString();


        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.setAttribute('bgColor', this.style.backgroundColor); this.style.backgroundColor = '#CBFF97';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.getAttribute('bgColor');");
            e.Row.Attributes.Add("style", "cursor:pointer;");
        }

    }

    //Search Option-RUS
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = (DataTable)ViewState["dtOrder"];
        DataView dvOrder = dtOrder.DefaultView;
        dvOrder.RowFilter = "ord_no like '" + txtSearch.Text + "%'";

        Gvorder.DataSource = dvOrder;
        Gvorder.DataBind();
    }

    //Search Option-RUS
}