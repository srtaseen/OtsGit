using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PlanEdit : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    WorkingDay wd = new WorkingDay();
    int index;
    string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetInitialRow();
            Bindddlbuyer();
            lblLineinfo.Visible = false;
           
        }
    }
    #region Left Pane
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
        String strQuery1 = "select  DISTINCT art_id,art_no FROM Article_Master where ord_no='" + GetStn.SelectedItem.Value + "' ";
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
        SqlConnection conn = new SqlConnection(DbConnect.x);
        try
        {
            DataTable dt = new DataTable();
            //String strQuery = "select distinct a.po_no,b.gmtyp as art_item,b.gmtid,a.Fact_nm from view_Article_Po a join GarmentsType b on a.art_item = b.gmtid where art_no='" + GetArticle.SelectedItem.Value + "' and a.po_no not in (select Po_no from Line_Booking) ";
            String strQuery = @"select a.art_no,a.art_item,a.gmtid,a.Fact_nm, sum(po_quantity) as po_quantity, min(Tnapl42) as Tnapl42,min(po_xfactory) as po_xfactory 
                        FROM (select distinct a.art_no, b.gmtyp as art_item,b.gmtid,a.Fact_nm 
                        from view_Article_Po a join GarmentsType b on a.art_item = b.gmtid where art_no='" + GetArticle.SelectedItem.Text +
                        "') a join View_Tna_Plan v on a.art_no=v.art_no where a.art_no= '" + GetArticle.SelectedItem.Text + "' group by a.art_no, a.art_item,a.gmtid,a.Fact_nm";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = conn;

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GetGType.Text = dt.Rows[0]["art_item"].ToString();
                GetFactory.Text = dt.Rows[0]["Fact_nm"].ToString();
                Session["GType"] = GetGType.Text;
                Session["GTypeId"] = dt.Rows[0]["gmtid"];

                txtQuantity.Text = dt.Rows[0]["po_quantity"].ToString();
                txtSd.Text = dt.Rows[0]["Tnapl42"].ToString();
                txtXd.Text = dt.Rows[0]["po_xfactory"].ToString();

                DateTime date1 = new DateTime();
                DateTime date2 = new DateTime();
                int days;

                bool isDate1Valid = DateTime.TryParse(txtSd.Text, out date1);
                bool isDate2Valid = DateTime.TryParse(txtXd.Text, out date2);

                if (isDate1Valid && isDate2Valid)
                {
                    ///Friday need to calculate
                    days = wd.GetNoDay(date1, date2);
                    txtSld.Text = (days).ToString();
                }
            }

            ////-----Line grid-----
            SqlCommand cmd1 = new SqlCommand("select ent_date as StartDate, last_dt as EndDate,line_no, lineQty,line_booking_id as id, target_dy as targetDay,SMV, SumDay from Line_booking where art_no= '" + GetArticle.SelectedItem.Text + "'", conn);
            cmd1.CommandType = CommandType.Text;
            DataTable dtt = new DataTable();
            da = new SqlDataAdapter(cmd1);
            da.Fill(dtt);
            if (dtt.Rows.Count > 0)
            {
                ViewState["SMV"] = dtt.Rows[0]["SMV"];
                ViewState["TargetDay"] = dtt.Rows[0]["targetDay"];
                ViewState["CurrentTable"] = dtt;
                GridviewHp.DataSource = dtt;
                GridviewHp.DataBind();
                SetPreviousData();
                //AddNewRowToGrid();
            }

            GetUsedQty();
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

    #endregion



    #region Right Pane
    //public void BindDropLine(DropDownList drpLine, DateTime entDate)
    //{
    //    SqlConnection con = new SqlConnection("Data Source = SHOWKAT; Initial Catalog = Sanpro; Persist Security Info = True; User ID = sa; Password = sql");
    //    string strQuery = "select Code, Name from LineMaster where code not in "
    //                    + "(select Code from LineMaster b where CONVERT(date, '" + entDate
    //                    + "') in (select ent_date from line_booking c where b.Name = c.line_no)) order by code ";
    //    SqlCommand cmd = new SqlCommand();

    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = strQuery;
    //    cmd.Connection = con;
    //    try
    //    {
    //        con.Open();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);
    //        drpLine.DataSource = dt;
    //        drpLine.DataTextField = "Name";
    //        drpLine.DataValueField = "Name";
    //        drpLine.DataBind();

    //        drpLine.Items.Insert(0, new ListItem(string.Empty, string.Empty));
    //        drpLine.SelectedIndex = 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.Close();
    //        //conn.Dispose();
    //    }
    //}
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        //DataRow dr = null;

        ////Define the Columns
        //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("StartDate", typeof(string)));
        dt.Columns.Add(new DataColumn("EndDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Line", typeof(string)));

        ////Add a Dummy Data on Initial Load
        //dr = dt.NewRow();
        ////dr["RowNumber"] = 1;
        //dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;
        ////Bind the DataTable to the Grid
        GridviewHp.DataSource = dt;
        GridviewHp.DataBind();
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
                drCurrentRow["id"] = 0;
                //drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                dtCurrentTable.Rows.Add(drCurrentRow);

                ViewState["CurrentTable"] = dtCurrentTable;
                GridviewHp.DataSource = dtCurrentTable;
                GridviewHp.DataBind();
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
        try
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Set the Previous Selected Items on Each DropDownList on Postbacks
                        TextBox txtentdt = (TextBox)GridviewHp.Rows[i].FindControl("txtentdt");
                        TextBox txtentdt1 = (TextBox)GridviewHp.Rows[i].FindControl("txtentdt1");
                        DropDownList drpLine = (DropDownList)GridviewHp.Rows[i].FindControl("drpLine");

                        txtentdt.Text = dt.Rows[i][0].ToString();
                        txtentdt1.Text = dt.Rows[i][1].ToString();
                        drpLine.ClearSelection();
                        drpLine.Items.FindByText(dt.Rows[i][2].ToString()).Selected = true;
                    }
                }
            }
        }
        catch (Exception e)
        { }
    }

    protected void GridviewHp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    
    protected void GridviewHp_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridviewHp_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void GridviewHp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //DataTable dt = (DataTable)ViewState["CurrentTable"];
        //dt.Rows.RemoveAt(e.RowIndex);
        //dt.AcceptChanges();
        //ViewState["CurrentTable"] = dt;
        //GridviewHp.DataSource = dt;
        //GridviewHp.DataBind();
        //SetPreviousData();
    }

    protected void txtentdt_TextChanged(object sender, EventArgs e)
    {
        TextBox txtentdt = (TextBox)sender;
        GridViewRow gvr = (GridViewRow)txtentdt.Parent.Parent;
        int index = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["CurrentTable"];
        //int lineQty = int.Parse(dt.Rows[index]["lineQty"].ToString());

        TextBox txtentdt1 = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt1");
        DropDownList drpLine = (DropDownList)GridviewHp.Rows[index].FindControl("drpLine");
        if (!String.IsNullOrWhiteSpace(txtentdt1.Text))
        {
            int noDay = 0;
            DateTime fstDate = DateTime.Parse(txtentdt.Text.ToString());
            DateTime lstDate = DateTime.Parse(txtentdt1.Text.ToString());
            noDay += wd.GetNoDay(fstDate, lstDate);

            int targetDay = (int)ViewState["TargetDay"];
            //int rBookQty = (int)ViewState["RemainBookQty"];
            //int orderQty = Convert.ToInt32(txtQuantity.Text);

            dt.Rows[index][0] = txtentdt.Text.ToString();
            dt.Rows[index][1] = txtentdt1.Text.ToString();
            dt.Rows[index][2] = drpLine.SelectedValue;
            dt.Rows[index][3] = (noDay * targetDay);
            dt.Rows[index]["SumDay"] = noDay;
            dt.AcceptChanges();
            ViewState["CurrentTable"] = dt;

            //int remQy = orderQty - (noDay * targetDay);
            //lblLineinfo.Text = "No more line to book. RQ: " + remQy.ToString();
        }
    }
    protected void txtentdt1_TextChanged(object sender, EventArgs e)
    {
        TextBox txtentdt1 = (TextBox)sender;
        GridViewRow gvr = (GridViewRow)txtentdt1.Parent.Parent;
        int index = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["CurrentTable"];
        //int lineQty = int.Parse(dt.Rows[index]["lineQty"].ToString());

        TextBox txtentdt = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt");
        DropDownList drpLine = (DropDownList)GridviewHp.Rows[index].FindControl("drpLine");
        
        int noDay = 0;
        DateTime fstDate = DateTime.Parse(txtentdt.Text.ToString());
        DateTime lstDate = DateTime.Parse(txtentdt1.Text.ToString());
        noDay += wd.GetNoDay(fstDate, lstDate);        

        int targetDay = (int)ViewState["TargetDay"];

        dt.Rows[index][0] = txtentdt.Text.ToString();
        dt.Rows[index][1] = txtentdt1.Text.ToString();
        dt.Rows[index][2] = drpLine.SelectedValue;
        dt.Rows[index]["lineQty"] = (noDay * targetDay);
        dt.Rows[index]["SumDay"] = noDay;
        dt.AcceptChanges();
        ViewState["CurrentTable"] = dt;
    }
    protected void drpLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drpLine = (DropDownList)sender;
        GridViewRow gvr = (GridViewRow)drpLine.Parent.Parent;
        int index = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["CurrentTable"];
        TextBox txtentdt = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt");
        TextBox txtentdt1 = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt1");

        int noDay = 0;
        DateTime fstDate = DateTime.Parse(txtentdt.Text.ToString());
        DateTime lstDate = DateTime.Parse(txtentdt1.Text.ToString());
        noDay += wd.GetNoDay(fstDate, lstDate);

        int targetDay = (int)ViewState["TargetDay"];
        
        dt.Rows[index][0] = txtentdt.Text.ToString();
        dt.Rows[index][1] = txtentdt1.Text.ToString();
        dt.Rows[index][2] = drpLine.SelectedValue;
        dt.Rows[index]["lineQty"] = (noDay * targetDay);
        dt.Rows[index]["SumDay"] = noDay;
        dt.AcceptChanges();
        ViewState["CurrentTable"] = dt;
    }
    protected void FunctionB_ServerClick(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void Btnsave_Click1(object sender, EventArgs e)
    {
        //int ord_id = 0;
        DataTable dt = (DataTable)ViewState["CurrentTable"];

        SqlConnection conn = new SqlConnection(DbConnect.x);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            SqlCommand Syscmd = new SqlCommand();
            Syscmd.CommandType = CommandType.StoredProcedure;
            Syscmd.CommandText = "Sp_Line_BookingModify";

            Syscmd.Parameters.AddWithValue("@ord_no", GetStn.SelectedValue);
            Syscmd.Parameters.AddWithValue("@ord_buyer", GetByr.SelectedItem.Text.Trim());
            Syscmd.Parameters.AddWithValue("@art_no", GetArticle.SelectedItem.Text.Trim());
           // Syscmd.Parameters.AddWithValue("@po_no", "");
            Syscmd.Parameters.AddWithValue("@grment_typ", GetGType.Text.Trim());
            Syscmd.Parameters.AddWithValue("@ord_factory", GetFactory.Text.Trim());
            Syscmd.Parameters.AddWithValue("@ord_quantity", txtQuantity.Text.Trim());
            Syscmd.Parameters.AddWithValue("@ord_sewing", txtSd.Text.Trim());
            Syscmd.Parameters.AddWithValue("@ord_xfactory", txtXd.Text.Trim());

            //Syscmd.Parameters.AddWithValue("@pln_efficiency", txtPlanEff.Text.Trim());
            //Syscmd.Parameters.AddWithValue("@smv", txtSmv.Text.Trim());
            //Syscmd.Parameters.AddWithValue("@mo", txtMo.Text.Trim());            
            string targetDay = ViewState["TargetDay"].ToString();
            string date = dt.Rows[i][0].ToString();
            string endDate = dt.Rows[i][1].ToString();
            string line = dt.Rows[i][2].ToString();

            Syscmd.Parameters.AddWithValue("@lineBId", dt.Rows[i]["id"].ToString());
            Syscmd.Parameters.AddWithValue("@ent_date", dt.Rows[i][0].ToString());
            Syscmd.Parameters.AddWithValue("@last_dt", dt.Rows[i][1].ToString());
            Syscmd.Parameters.AddWithValue("@line_no", dt.Rows[i][2].ToString());
            Syscmd.Parameters.AddWithValue("@sumDay", dt.Rows[i]["SumDay"].ToString());
            Syscmd.Parameters.AddWithValue("@lineQty", dt.Rows[i]["lineQty"].ToString());
            Syscmd.Parameters.AddWithValue("@target_dy", ViewState["TargetDay"].ToString());

            //DropDownList drpLine = (DropDownList)GridviewHp.Rows[i].FindControl("drpLine");

            Syscmd.Connection = conn;
            conn.Open();
            Syscmd.ExecuteNonQuery();

            conn.Close();
        }

        Response.Redirect(Request.RawUrl); //page refreash
    }

    protected void BtnChkQty_Click(object sender, EventArgs e)
    {
        lblLineinfo.Visible = true;
        int totLineQty = 0;
        DataTable dt = (DataTable)ViewState["CurrentTable"];
        foreach (DataRow dr in dt.Rows)
        {
            totLineQty += (int)dr["lineQty"];
        }

        int orderQty = Convert.ToInt32(txtQuantity.Text);
        int prodQty = (int)ViewState["ProdQty"];

        int remQy = orderQty - prodQty - totLineQty;
        lblLineinfo.Text = "No more line to book. RQ: " + remQy.ToString();
    }
    #endregion



    #region Line Booking
    private void GetLearningCurve(Int16 code, int targetPDay)
    {
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery = "select day,Percentage from LearningCurve where Percentage < 100 and code= " + code.ToString();
        SqlCommand cmd = new SqlCommand(strQuery, conn);
        cmd.CommandType = CommandType.Text;
        //cmd.CommandText = strQuery;
        //cmd.Connection = conn;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        DataTable dtLc = new DataTable();
        dtLc.Columns.Add("Day", typeof(System.Int16));
        dtLc.Columns.Add("Percen", typeof(System.Int16));
        dtLc.Columns.Add("Target", typeof(System.Int32));

        foreach (DataRow dr in dt.Rows)
        {
            DataRow drN = dtLc.NewRow();
            drN[0] = dr[0];
            drN[1] = dr[1];
            decimal qty = Math.Ceiling(decimal.Parse((targetPDay * int.Parse(dr[1].ToString()) / 100).ToString()));
            drN[2] = int.Parse(qty.ToString());
            dtLc.Rows.Add(drN);
        }

        ViewState["dtLearningCrv"] = dtLc;
    }

    private void BookingLine(int orderQty, int targetDay, out int remainQty, int pQtyDay = 0)
    {
        int bQTY = 0;
        int bookDay = 0; int noDay = 0;
        int bookQty = 0; int midQty = 0;
        int oQty = orderQty;

        int[] lc = new int[2];
        lc = LCCalculate(orderQty);

        DataTable dt = (DataTable)ViewState["CurrentTable"];
        DataTable lineTab = (DataTable)Session["LineTable"];

        DateTime sewingDate = DateTime.Parse(txtSd.Text);
        DateTime xDate = DateTime.Parse(txtXd.Text);
        DateTime startDate; DateTime endDate;

        bool book = false;
        foreach (DataRow dr in lineTab.Rows)
        {
            string line = dr[0].ToString();             // check - is line already booked
            foreach (DataRow row in dt.Rows)
            {
                if (row[2].ToString() == line)
                    goto nextLine;
            }

            //---------Calculate Learning Curve-----------------------------------------------------
            bookDay = lc[0];
            bookQty = lc[1];
            oQty = orderQty - lc[1];
            //----------------- ------------------------ --------------------------

            DateTime lastDt = DateTime.Parse(dr[2].ToString());
            if (lastDt == sewingDate)
            {
                startDate = sewingDate.AddDays(1);
                if (startDate.DayOfWeek == DayOfWeek.Friday)
                    startDate = startDate.AddDays(1);
            }
            else
            {
                startDate = sewingDate;
                if (startDate.DayOfWeek == DayOfWeek.Friday)
                    startDate = startDate.AddDays(1);
            }

            if (oQty > targetDay)
            {
                decimal daybook = Math.Ceiling(decimal.Parse(oQty.ToString()) / targetDay);
                noDay = int.Parse(daybook.ToString());
                bookDay += noDay;
                bookQty += oQty;
            }
            else if (oQty <= targetDay)
            {
                if (oQty > targetDay * .5)
                {
                    bookDay += 1;
                    bookQty += oQty;
                }
            }
            //else if (oQty <= 0)
            //    BookLine(bookDay, startDate, line);

            endDate = wd.GetEndDate(startDate, startDate.AddDays(bookDay - 1));
            if (lastDt < startDate) //&& (endDate <= xDate))
            {
                //BookLine(startDate, endDate, line);
                //book = true;
                //goto lineBookDone;

                if (endDate <= xDate)
                {
                    BookLine(startDate, endDate, line);
                    bQTY = bookQty;
                    goto lineBookDone;
                }
                else
                {
                    bookDay = wd.GetNoDay(startDate, xDate);
                    midQty = (bookDay - lc[0]) * targetDay;
                    bookQty = lc[1] + midQty;
                    //bookDay += lc[0];

                    if (bookDay > 0)
                        endDate = wd.GetEndDate(startDate, startDate.AddDays(bookDay - 1));
                    else
                    {
                        bookDay = lc[0] + 1;
                        endDate = startDate;
                    }

                    BookLine(startDate, endDate, line);
                    bQTY += bookQty;
                    orderQty = orderQty - bookQty;

                    if (orderQty <= targetDay * .5)
                        goto lineBookDone;
                }

            } //...................... if possible then book the whole order into one line - 1st priority

            nextLine:;
        }

        if (!book)
        {
            bQTY = BookMultipleLine(lc, orderQty);
        }

        lineBookDone:;
        remainQty = orderQty - bQTY;
        int bd = bookDay;
        //if (bd > 0)
        //    BookLine(bd, remQty, out remQty,pQtyDay,0);
    }

    private int BookMultipleLine(int[] lc, int orderQty)
    {
        int bQTY = 0;
        return bQTY;
    }

    private int[] LCCalculate(int orderQty)
    {
        int[] lc = new int[2];
        DataTable dtSmv = (DataTable)ViewState["dtLearningCrv"];
        int lcDay = 0; int totLcQty = 0;

        foreach (DataRow row in dtSmv.Rows)
        {
            decimal qty = Math.Ceiling(decimal.Parse(row[2].ToString()));
            int lcQty = int.Parse(qty.ToString());
            totLcQty = totLcQty + lcQty;
            lcDay = Convert.ToInt16(row[0].ToString());
            if (orderQty < lcQty)
            {
                totLcQty = totLcQty - (lcQty - orderQty);
                break;
            }
            orderQty = orderQty - lcQty;
        }

        lc[0] = lcDay; lc[1] = totLcQty;

        return lc;
    }
    private void BookLine(DateTime startDt, DateTime endDate, string line)
    {
        //DateTime endDate;
        //endDate = wd.GetEndDate(bookDt, bookDt.AddDays(noDay - 1));
        DataTable dt = (DataTable)ViewState["CurrentTable"];
        DataRow newRow = dt.NewRow();
        newRow[0] = startDt.ToString();
        newRow[1] = endDate.ToString();
        newRow[2] = line;
        dt.Rows.Add(newRow);
        ViewState["CurrentTable"] = dt;
    }

    private void GetUsedQty()
    {
        int totProd = 0;
        //int bookQty = 0;
        DataTable dt = new DataTable();  //,count(p.aDate) as prodDay
        string strQuery = @"select sum(isnull(p.aHrTotal,0)) as prodqty from [ERP\ERP].SmartCode.dbo.Hrs_ProductionByLine p 
                            where RTRIM(p.aStage)='SEWING QC OUT'  and
                            aPO in (select po_no from sanpro.dbo.PO_Master where art_no='" + GetArticle.SelectedItem.Text + "')  and p.aLine='Line 2' " +
                            " group by p.astyle";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = conn;
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        conn.Close();
        conn.Dispose();

        if (dt.Rows.Count > 0)
            totProd = (int)dt.Rows[0]["prodqty"];

        ViewState["ProdQty"] = totProd;

        //string strQry = @"select sum(lineQty) from Line_booking where art_no=' " + GetArticle.SelectedItem.Text + "')  ";
        //SqlCommand cmd1 = new SqlCommand();
        //cmd1.CommandType = CommandType.Text;
        //cmd1.CommandText = strQry;
        //cmd1.Connection = conn;

        //var bQty = cmd1.ExecuteScalar();

        //if (!String.IsNullOrWhiteSpace(bQty.ToString()))
        //    bookQty = (int)bQty;
        
        //ViewState["BookingQty"] = bookQty;  
    }

    //private int CountRemainQty(int noDay, int lineQty)
    //{
    //    int targetDy = (int)ViewState["TargetDay"];
    //    int orderQty = int.Parse(txtQuantity.Text);
    //    int booking = (int)ViewState["BookingQty"];
    //    //int prodQty = (int)ViewState["ProdQty"];

    //    int newBookQty = noDay * targetDy;

    //    return 
    //}

    #endregion

    
}



