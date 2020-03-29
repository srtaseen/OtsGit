using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LineBooking2 : System.Web.UI.Page
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
            BindLineGrid();
            BindPendingLineGrid();
           
			 bindGridAug1();
            bindGridAug11();
            bindGridAug21();
            bindGridSep1();
            bindGridSep11();
            bindGridSep21();
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
        String strQuery1 = "select  DISTINCT art_id,art_no FROM Article_Master where ord_no='" + GetStn.SelectedItem.Value + "' and art_no not in (select distinct isnull(art_no,'') from Line_Booking) ";
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
    //protected void GetPo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection conn = new SqlConnection(DbConnect.x);
    //    try
    //    {
    //        DataTable dt = new DataTable();
    //        String strQuery = "select DISTINCT po_quantity,Tnapl42,po_xfactory FROM View_Tna_Plan where po_no='" + GetPo.SelectedItem.Text + "' ";
    //        SqlCommand cmd = new SqlCommand();
    //        cmd.CommandType = CommandType.Text;
    //        cmd.CommandText = strQuery;
    //        cmd.Connection = conn;

    //        conn.Open();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        da.Fill(dt);
    //        if (dt.Rows.Count > 0)
    //        {
    //            //If you want to get mutiple data from the database then you need to write a simple looping 
    //            txtQuantity.Text = dt.Rows[0]["po_quantity"].ToString();
    //            txtSd.Text = dt.Rows[0]["Tnapl42"].ToString();
    //            txtXd.Text = dt.Rows[0]["po_xfactory"].ToString();

    //            DateTime date1 = new DateTime();
    //            DateTime date2 = new DateTime();
    //            int days;

    //            bool isDate1Valid = DateTime.TryParse(txtSd.Text, out date1);
    //            bool isDate2Valid = DateTime.TryParse(txtXd.Text, out date2);

    //            if (isDate1Valid && isDate2Valid)
    //            {
    //                ///Friday need to calculate
    //                days = wd.GetNoDay(date1,date2);

    //                txtSld.Text = (days).ToString();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        conn.Close();
    //        conn.Dispose();
    //    }
    //}
    #endregion

    #region Middle Pane
    //protected void txtHelper_TextChanged(object sender, EventArgs e)
    //{
    //    txtTargetHr.Text = Convert.ToString(Convert.ToInt32((Convert.ToInt32(txtMo.Text) + Convert.ToInt32(txtHelper.Text)) * 60 * Convert.ToInt32(txtPlanEff.Text) / 100 / Convert.ToDecimal(txtSmv.Text)));
    //}

    private void GetLearningCurve(Int16 code, int targetPDay)
    {
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery = "select day,Percentage from LearningCurve where Percentage < 100 and code= " + code.ToString();
        SqlCommand cmd = new SqlCommand(strQuery,conn);
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
    protected void txtPlanHr_TextChanged(object sender, EventArgs e)  
    {
        try
        {
            int targetDay = (Convert.ToInt32(txtTargetHr.Text) * Convert.ToInt32(txtPlanHr.Text));
            int orderQty = Convert.ToInt32(txtQuantity.Text);
            decimal smv = Convert.ToDecimal(txtSmv.Text);
            //int prodQty = Convert.ToInt32(txtSld.Text) * targetDay;
            string msg = "";
            //CalculateQty(orderQty, targetDay, out msg);
            int remainQty = 0;
            
            ////-----Learning Curve   -----
            if (smv <= 7)
                GetLearningCurve(1, targetDay);
            else if (smv > 7 && smv<=10 )
                GetLearningCurve(2, targetDay);
            else
                GetLearningCurve(3, targetDay);

            BookingLine(orderQty, targetDay, out remainQty, 0);

            if (remainQty <= 0)
                msg = "Booking Qty: " + (orderQty-remainQty).ToString();
            else if (remainQty < targetDay)
                msg = "Need to rearrange. RQ: " + remainQty.ToString();
            else
                msg = "No more line to book. RQ: " + remainQty.ToString();

            lblLineinfo.Visible = true;
            lblLineinfo.Text = msg;
            txtTargetDy.Text = Convert.ToString(targetDay);
            DataTable dt = (DataTable)ViewState["CurrentTable"];        
            GridviewHp.DataSource = dt;
            GridviewHp.DataBind();                
            SetPreviousData(); 
        }
        catch (Exception ex)
        { }
    }

    //private void CalculateQty(decimal orderQty, int targetDay, out string remMsg)
    //{
    //    //int targetDay = (Convert.ToInt32(txtTargetHr.Text) * Convert.ToInt32(txtPlanHr.Text));
    //   // decimal remQty = 0, bQty =0; string msg = "";
    //   // decimal daybook = Math.Ceiling(orderQty / targetDay);
    //   // int noDay = int.Parse(daybook.ToString());
    //   // int prodQty = targetDay*noDay;

    //   // if (prodQty == orderQty)
    //   // {
    //   //     bQty = BookingLine(0, targetDay);
    //   //     remQty = orderQty-bQty;
    //   // }
    //   // else if (prodQty > orderQty)
    //   // {
    //   //     bQty = BookingLine(int.Parse(noDay.ToString()), targetDay);
    //   //     remQty = orderQty - bQty;
    //   // }
    //   // else if (prodQty < orderQty)
    //   // {
    //   //     bQty = BookingLine(0, targetDay);
    //   //     remQty = orderQty - bQty;
    //   // }

    //   // //if (msg == "")
    //   // //{
    //   //     if (remQty > 900)
    //   //         CalculateQty(remQty, prodQty,out remMsg);
    //   //// }
    //   // else
    //   // {
    //   //     remMsg = remQty.ToString();
    //   // }
    //}
    private void BookingLine(int orderQty,int targetDay, out int remainQty, int pQtyDay = 0)
    {
        int bQTY = 0;
        int bookDay = 0; int noDay=0;
        int bookQty = 0; int midQty = 0;
        int oQty = orderQty;

        int[] lc = new int[2];
        lc = LCCalculate(orderQty);

        DataTable dt = (DataTable)ViewState["CurrentTable"];
        DataTable lineTab = (DataTable)Session["LineTable"];

        DateTime sewingDate = DateTime.Parse(txtSd.Text);
        DateTime xDate = DateTime.Parse(txtXd.Text);
        DateTime startDate;  DateTime endDate;

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

    private int BookMultipleLine(int[] lc,int orderQty)
    {
        int bQTY = 0;
        int bookDay = 0; int noDay = 0;
        int bookQty = 0; int midQty = 0;
        int oQty = orderQty; string line = String.Empty;

        int targetDay = (Convert.ToInt32(txtTargetHr.Text) * Convert.ToInt32(txtPlanHr.Text));
        DataTable dt = (DataTable)ViewState["CurrentTable"];
        DataTable lineTab = (DataTable)Session["LineTable"];

        DateTime sewingDate = DateTime.Parse(txtSd.Text);
        DateTime xDate = DateTime.Parse(txtXd.Text);
        DateTime startDate; DateTime endDate;

        bool book = false;

        foreach (DataRow dr in lineTab.Rows)  
        {
            line = dr[0].ToString(); 
            foreach (DataRow row in dt.Rows)
            {
                if (row[2].ToString() == line)
                    goto nextLine1;
            }

            // LC Calcilation..................
            bookDay = lc[0];
            bookQty = lc[1];
            oQty = orderQty - bookQty;
            //---------------------------------------

            DateTime lastDt = DateTime.Parse(dr[2].ToString());

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

            if ((lastDt > sewingDate) && (lastDt < xDate))
            {
                startDate = lastDt.AddDays(1);
                if (startDate.DayOfWeek == DayOfWeek.Friday)
                    startDate = startDate.AddDays(1);
                endDate = wd.GetEndDate(startDate, startDate.AddDays(bookDay - 1));
                if (endDate <= xDate)
                {
                    BookLine(startDate, endDate, line);
                    bQTY = bookQty;
                    break;
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
                        bookDay = lc[0]+1;
                        endDate = startDate;
                    }

                    BookLine(startDate, endDate, line);
                    bQTY += bookQty;
                    orderQty = orderQty - bookQty;

                    if (orderQty <= targetDay * .5)
                        break;
                }
            }

            nextLine1:;
        }  


        return bQTY;
    }

    //private DateTime GetStartDate(DateTime lastDt, DateTime sewingDate)
    //{
    //    DateTime startDate;
    //    if (lastDt == sewingDate)
    //    {
    //        startDate = sewingDate.AddDays(1);
    //        if (startDate.DayOfWeek == DayOfWeek.Friday)
    //            startDate = sewingDate.AddDays(2);
    //    }
    //    else
    //        startDate = sewingDate;

    //    return startDate;
    //}

    private int[] LCCalculate(int orderQty)
    {
        int[] lc = new int[2];
        DataTable dtSmv = (DataTable)ViewState["dtLearningCrv"];
        int lcDay = 0;        int totLcQty = 0;

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

        lc[0] = lcDay; lc[1]= totLcQty;
        
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

    
    
    #endregion
    #region Right Pane
    protected void drpLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drpLine = (DropDownList)sender;
        GridViewRow gvr = (GridViewRow)drpLine.Parent.Parent;
        int index = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["CurrentTable"];
        TextBox txtentdt = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt");
        TextBox txtentdt1 = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt1");
        
        dt.Rows[index][0] = txtentdt.Text.ToString();
        dt.Rows[index][1] = txtentdt1.Text.ToString();
        dt.Rows[index][2] = drpLine.SelectedValue;
        dt.AcceptChanges();
        ViewState["CurrentTable"] = dt;

        int targetDay = (Convert.ToInt32(txtTargetHr.Text) * Convert.ToInt32(txtPlanHr.Text));
        int orderQty = Convert.ToInt32(txtQuantity.Text);
        int noDay = 0;
        foreach(DataRow dr in dt.Rows)
        {
            DateTime fstDate = DateTime.Parse(dr[0].ToString());
            DateTime lstDate = DateTime.Parse(dr[1].ToString());
            noDay += wd.GetNoDay(fstDate, lstDate);
        }

        int remQy = orderQty - (noDay * targetDay);
        lblLineinfo.Text = "No more line to book. RQ: " + remQy.ToString();
    }
    protected void FunctionB_ServerClick(object sender, EventArgs e)
    {        
        AddNewRowToGrid();
    }
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
     
    protected void txtOrdRem_TextChanged(object sender, EventArgs e)
    {

    }
    //protected void txtentdt1_TextChanged(object sender, EventArgs e)
    //{
    //    index = GridviewHp.Rows.Count - 1;
    //    TextBox entDt = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt");
    //    DateTime entDate = DateTime.Parse("2000-01-01");
    //    if (entDt.Text != "")
    //    { entDate = DateTime.Parse(entDt.Text); }
    //    DropDownList drpLine = (DropDownList)GridviewHp.Rows[index].FindControl("drpLine");
    //    BindDropLine(drpLine, entDate);
    //}
    protected void GridviewHp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    public void BindDropLine(DropDownList drpLine, DateTime entDate)
    {
        SqlConnection con = new SqlConnection("Data Source = WEB; Initial Catalog = Sanpro; Persist Security Info = True; User ID = sa; Password = bangladesh#100");
        string strQuery = "select Code, Name from LineMaster where code not in "
                        + "(select Code from LineMaster b where CONVERT(date, '" + entDate
                        + "') in (select ent_date from line_booking c where b.Name = c.line_no)) order by code ";
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            drpLine.DataSource = dt;
            drpLine.DataTextField = "Name";
            drpLine.DataValueField = "Name";
            drpLine.DataBind();

            drpLine.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            drpLine.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            //conn.Dispose();
        }
    }
    #endregion
    
    protected void Btnsave_Click1(object sender, EventArgs e)
    {
        //int ord_id = 0;
        DataTable dt = (DataTable)ViewState["CurrentTable"];

        SqlConnection conn = new SqlConnection(DbConnect.x);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            SqlCommand Syscmd = new SqlCommand();
            Syscmd.CommandType = CommandType.StoredProcedure;
            Syscmd.CommandText = "Sp_Line_Booking";

            Syscmd.Parameters.AddWithValue("@ord_no", GetStn.SelectedValue);
            Syscmd.Parameters.AddWithValue("@ord_buyer", GetByr.SelectedItem.Text.Trim());
            Syscmd.Parameters.AddWithValue("@art_no", GetArticle.SelectedItem.Text.Trim());
            Syscmd.Parameters.AddWithValue("@po_no", "");
            Syscmd.Parameters.AddWithValue("@grment_typ", GetGType.Text.Trim());
            Syscmd.Parameters.AddWithValue("@pln_efficiency", txtPlanEff.Text.Trim());
            Syscmd.Parameters.AddWithValue("@smv", txtSmv.Text.Trim());
            Syscmd.Parameters.AddWithValue("@ord_factory", GetFactory.Text.Trim());
            Syscmd.Parameters.AddWithValue("@ord_quantity", txtQuantity.Text.Trim());
            Syscmd.Parameters.AddWithValue("@ord_sewing", txtSd.Text.Trim());
            Syscmd.Parameters.AddWithValue("@ord_xfactory", txtXd.Text.Trim());
            Syscmd.Parameters.AddWithValue("@mo", txtMo.Text.Trim());
            Syscmd.Parameters.AddWithValue("@helper", txtHelper.Text.Trim());
            Syscmd.Parameters.AddWithValue("@target_hr", txtTargetHr.Text.Trim());
            Syscmd.Parameters.AddWithValue("@plan_hr", txtPlanHr.Text.Trim());
            Syscmd.Parameters.AddWithValue("@target_dy", txtTargetDy.Text.Trim());

            string date = dt.Rows[i][0].ToString();
            Syscmd.Parameters.AddWithValue("@ent_date", date);

            string endDate = dt.Rows[i][1].ToString();
            Syscmd.Parameters.AddWithValue("@last_dt", endDate);

            DropDownList drpLine = (DropDownList)GridviewHp.Rows[i].FindControl("drpLine");
            string line = dt.Rows[i][2].ToString();
            Syscmd.Parameters.AddWithValue("@line_no", line);
            
            Syscmd.Connection = conn;
            conn.Open();
            Syscmd.ExecuteNonQuery();

            conn.Close();
        }
        //string message = string.Empty;
        //switch (ord_id)
        //{
        //    case -1:
        //        message = "dhdghdfgdfg";
        //        break;

        //    default:
        //        message = "Insert successful. Activation email has been sent to your email.";
        //        //SendOrderEmail(ord_id);
        //        break;
        //}
        //Page.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);        
        ////********** Save to Line Master ********//
        //var result = from row in dt.AsEnumerable()
        //             group row by row.Field<string>("Column1") into grp
        //             select new
        //             {
        //                 line = grp.Key,
        //                 fromDate = grp.Min(row => row.Field<DateTime>("Column0")),
        //                 toDate = grp.Max(row => row.Field<DateTime>("Column0"))
        //             };

        //foreach (var v in result)
        //{
        //    string l = v.line;
        //    DateTime f = v.fromDate;
        //    DateTime t = v.toDate;
        //}
        //   // DataTable dtt = (DataTable)result;
        ////DataView dv = dt.DefaultView;
        ////dv.RowFilter

        Response.Redirect(Request.RawUrl); //page refreash
    }

    protected void GridviewHp_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void GridviewHp_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }


    //lower grid************
    private void BindLineGrid()
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand("GET_LINE_DATA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                LineGridView.DataSource = dt;
                LineGridView.DataBind();
                dt.Columns.Add(new DataColumn("Selected", typeof(Int16)));
                Session["LineTable"] = dt;
            }
            else
            {
                LineGridView.DataSource = null;
                LineGridView.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error Occured: " + ex.ToString());
        }
        finally
        {
            //dt.Clear();
            //ds.Dispose();
        }
    }


    private void BindPendingLineGrid()
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand("select ord_no,po_no,art_no,Tnapl42 from View_Tna_Plan where tnapl42 <= DATEADD(day,15,getdate()) and po_no not in (select po_no from Line_Booking) and art_no is not null and PO_Ship_Date is null and ActiveOrder='1' and TnAapproved is not null", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                LinePandingGridview.DataSource = dt;
                LinePandingGridview.DataBind();
                dt.Columns.Add(new DataColumn("Selected", typeof(Int16)));
                Session["PendingLineTable"] = dt;
            }
            else
            {
                LinePandingGridview.DataSource = null;
                LinePandingGridview.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error Occured: " + ex.ToString());
        }
        finally
        {
            //dt.Clear();
            //ds.Dispose();
        }
    }
   
	 public void bindGridAug1()
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        conn.Open();
        SqlCommand cmd1 = new SqlCommand("select line_no from Line_Booking group by line_no having max(last_dt) between '2017/11/01' and '2017/11/10'", conn);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        da1.Fill(ds, "Line_Booking");
        grdAug1.DataMember = "Line_Booking";
        grdAug1.DataSource = ds;
        grdAug1.DataBind();
        conn.Close();
    }

    public void bindGridAug11()
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        conn.Open();
        SqlCommand cmd1 = new SqlCommand("select line_no from Line_Booking group by line_no having max(last_dt) between '2017/11/11' and '2017/11/20'", conn);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        da1.Fill(ds, "Line_Booking");
        grdAug11.DataMember = "Line_Booking";
        grdAug11.DataSource = ds;
        grdAug11.DataBind();
        conn.Close();
    }

    public void bindGridAug21()
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        conn.Open();
        SqlCommand cmd1 = new SqlCommand("select line_no from Line_Booking group by line_no having max(last_dt) between '2017/11/21' and '2017/11/30'", conn);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        da1.Fill(ds, "Line_Booking");
        grdAug21.DataMember = "Line_Booking";
        grdAug21.DataSource = ds;
        grdAug21.DataBind();
        conn.Close();
    }


    public void bindGridSep1()
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        conn.Open();
        SqlCommand cmd1 = new SqlCommand("select line_no from Line_Booking group by line_no having max(last_dt) between '2017/12/01' and '2017/12/10'", conn);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        da1.Fill(ds, "Line_Booking");
        grdSep1.DataMember = "Line_Booking";
        grdSep1.DataSource = ds;
        grdSep1.DataBind();
        conn.Close();
    }

    public void bindGridSep11()
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        conn.Open();
        SqlCommand cmd1 = new SqlCommand("select line_no from Line_Booking group by line_no having max(last_dt) between '2017/12/11' and '2017/12/20'", conn);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        da1.Fill(ds, "Line_Booking");
        grdSep11.DataMember = "Line_Booking";
        grdSep11.DataSource = ds;
        grdSep11.DataBind();
        conn.Close();
    }

    public void bindGridSep21()
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        conn.Open();
        SqlCommand cmd1 = new SqlCommand("select line_no from Line_Booking group by line_no having max(last_dt) between '2017/12/21' and '2017/12/31'", conn);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        da1.Fill(ds, "Line_Booking");
        grdSep21.DataMember = "Line_Booking";
        grdSep21.DataSource = ds;
        grdSep21.DataBind();
        conn.Close();
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
                //If you want to get mutiple data from the database then you need to write a simple looping 
                GetGType.Text = dt.Rows[0]["art_item"].ToString();
                GetFactory.Text = dt.Rows[0]["Fact_nm"].ToString();
                Session["GType"] = GetGType.Text;
                Session["GTypeId"] = dt.Rows[0]["gmtid"];
                //GetPo.ClearSelection();
                //GetPo.DataTextField = "po_no";
                //GetPo.DataValueField = "po_no";
                //GetPo.DataSource = dt;
                //GetPo.DataBind();

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

            ////-----IE-----
            SqlCommand cmd1 = new SqlCommand("select PEffeciency,TotSmv,MOperator,Helper,TargetPHr from IEMaster where art_id= " + GetArticle.SelectedItem.Value,conn);
            cmd1.CommandType = CommandType.Text;
            DataTable dtt = new DataTable();
            da = new SqlDataAdapter(cmd1);
            da.Fill(dtt);
            if (dtt.Rows.Count > 0)
            {
                txtPlanEff.Text = dtt.Rows[0]["PEffeciency"].ToString();
                txtSmv.Text = dtt.Rows[0]["TotSmv"].ToString();
                txtMo.Text = dtt.Rows[0]["MOperator"].ToString();
                txtHelper.Text = dtt.Rows[0]["Helper"].ToString();
                txtTargetHr.Text = dtt.Rows[0]["TargetPHr"].ToString();
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
    protected void txtentdt_TextChanged(object sender, EventArgs e)
    {
        TextBox txtentdt = (TextBox)sender;
        GridViewRow gvr = (GridViewRow)txtentdt.Parent.Parent;
        int index = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["CurrentTable"];
        //txtentdt = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt");
        TextBox txtentdt1 = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt1");
        DropDownList drpLine = (DropDownList)GridviewHp.Rows[index].FindControl("drpLine");
        if (!String.IsNullOrWhiteSpace(txtentdt1.Text))
        {
            dt.Rows[index][0] = txtentdt.Text.ToString();
            dt.Rows[index][1] = txtentdt1.Text.ToString();
            dt.Rows[index][2] = drpLine.SelectedValue;
            dt.AcceptChanges();
            ViewState["CurrentTable"] = dt;

            int targetDay = (Convert.ToInt32(txtTargetHr.Text) * Convert.ToInt32(txtPlanHr.Text));
            int orderQty = Convert.ToInt32(txtQuantity.Text);
            int noDay = 0;
            foreach (DataRow dr in dt.Rows)
            {
                DateTime fstDate = DateTime.Parse(dr[0].ToString());
                DateTime lstDate = DateTime.Parse(dr[1].ToString());
                noDay += wd.GetNoDay(fstDate, lstDate);
            }

            int remQy = orderQty - (noDay * targetDay);
            lblLineinfo.Text = "No more line to book. RQ: " + remQy.ToString();
        }
    }
    protected void txtentdt1_TextChanged(object sender, EventArgs e)
    {
        TextBox txtentdt1 = (TextBox)sender;
        GridViewRow gvr = (GridViewRow)txtentdt1.Parent.Parent;
        int index = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["CurrentTable"];
        TextBox txtentdt = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt");
       // TextBox txtentdt1 = (TextBox)GridviewHp.Rows[index].FindControl("txtentdt1");
        DropDownList drpLine = (DropDownList)GridviewHp.Rows[index].FindControl("drpLine");
        //if (!String.IsNullOrWhiteSpace(drpLine.SelectedItem.Text))
        //{
            dt.Rows[index][0] = txtentdt.Text.ToString();
            dt.Rows[index][1] = txtentdt1.Text.ToString();
            dt.Rows[index][2] = drpLine.SelectedValue;
            dt.AcceptChanges();
            ViewState["CurrentTable"] = dt;

            int targetDay = (Convert.ToInt32(txtTargetHr.Text) * Convert.ToInt32(txtPlanHr.Text));
            int orderQty = Convert.ToInt32(txtQuantity.Text);
            int noDay = 0;
            foreach (DataRow dr in dt.Rows)
            {
                DateTime fstDate = DateTime.Parse(dr[0].ToString());
                DateTime lstDate = DateTime.Parse(dr[1].ToString());
                noDay += wd.GetNoDay(fstDate, lstDate);
            }

            int remQy = orderQty - (noDay * targetDay);
            lblLineinfo.Text = "No more line to book. RQ: " + remQy.ToString();
        //}
    }
	
	protected void GridviewHp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["CurrentTable"];
        dt.Rows.RemoveAt(e.RowIndex);
        dt.AcceptChanges();
        ViewState["CurrentTable"] = dt;
        GridviewHp.DataSource = dt;
        GridviewHp.DataBind();
        SetPreviousData();
    }
}




