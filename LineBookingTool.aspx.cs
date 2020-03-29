using DayPilot.Utils;
using DayPilot.Web.Ui.Enums;
using DayPilot.Web.Ui.Events;
using DayPilot.Web.Ui.Events.Bubble;
using DayPilot.Web.Ui.Events.Scheduler;
using DayPilot.Web.Ui.Events.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LineBookingTool : System.Web.UI.Page
{
	SqlConnection conn = new SqlConnection(DbConnect.x);
    WorkingDay woringDay = new WorkingDay();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadResources();

            DayPilotScheduler1.StartDate = new DateTime(DateTime.Today.Year, 1, 12);
            DayPilotScheduler1.Days = Year.Days(DateTime.Today.Year);
            DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);
            DayPilotScheduler1.DataBind();

            DayPilotScheduler1.SetScrollX(DateTime.Today);
			
			Bindddlorder();
        }
		
        conn.Close();
    }

    private void LoadResources()
    {
        DayPilotScheduler1.Resources.Clear();

        SqlConnection conn = new SqlConnection(DbConnect.x);
        SqlDataAdapter da = new SqlDataAdapter("select distinct line_no as line from Line_Booking where ord_factory like 'NAZ%' order by line_no", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        foreach (DataRow r in dt.Rows)
        {
            string name = (string)r["line"];

            DayPilotScheduler1.Resources.Add(name, name);
        }
    }

    private DataTable DbGetEvents(DateTime start, int days)
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        //SqlDataAdapter da = new SqlDataAdapter("SELECT [id], [name], [eventstart], [eventend], [resource_id] FROM [event] WHERE NOT (([eventend] <= @start) OR ([eventstart] >= @end))", conn);
        //da.SelectCommand.Parameters.AddWithValue("start", start);
        //da.SelectCommand.Parameters.AddWithValue("end", start.AddDays(days));
        //SqlDataAdapter da = new SqlDataAdapter("select line_booking_id as id,po_no as name,ord_no as StyleNo,art_no as ArticleNo,grment_typ as GarmentsType,ent_date as eventstart,(case when (DATEDIFF(dd,ent_date, last_dt))=0 then (DATEADD(dd,1,last_dt)) else (DATEADD(dd,2,last_dt)) end) as eventend, line_no as resource_id, ord_sewing as sewDate,ord_xfactory as xfactDate from Line_Booking order by line_no", conn);
        SqlDataAdapter da = new SqlDataAdapter("select line_booking_id as id,art_no as name,ord_no as StyleNo,art_no as ArticleNo,grment_typ as GarmentsType,ent_date as eventstart,last_dt as eventend, line_no as resource_id, ord_sewing as sewDate,ord_xfactory as xfactDate,lineQty as lineQty,ord_no from Line_Booking where ord_factory like 'NAZ%' order by line_no", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        Session["Event"] = dt;

        //----- for tooltip-------
   //     string qry = @"select distinct l.line_no as Line,l.art_no as PoNo,l.ord_quantity as ordQty,isnull(l.targetQty*l.planDay,0) as lineQty,isnull(p.ProdQty,0) as ProdQty,l.targetQty,l.planDay-isnull(p.prodDay,0) as remDay
			//from (select l.line_no,l.ord_no,l.art_no,sum(SumDay) as planDay,ord_quantity,isnull(target_dy,0) as targetQty 
			//	from sanpro.dbo.Line_Booking l where l.ord_factory like 'NAZ%' group by l.line_no,l.ord_no,l.art_no,ord_quantity,target_dy) l left join
			//	sanpro.dbo.po_Master po on l.art_no=po.art_no left join
			//(select p.aline,p.astyle,p.aPO, sum(isnull(p.aHrTotal,0)) as prodqty,count(p.aDate) as prodDay
			//	from SmartCode.dbo.Hrs_ProductionByLine p where RTRIM(p.aStage)='SEWING QC OUT' group by p.aline,p.astyle,p.aPO) p 
			//on l.ord_no=p.aStyle and po.po_no=p.aPO and l.line_no=p.aLine
			//order by l.line_no";

        string qry = @"select l.line_no as Line,l.art_no as PoNo,l.ord_quantity as ordQty,isnull(l.targetQty*l.planDay,0) as lineQty,isnull(p.ProdQty,0) as ProdQty,l.targetQty,l.planDay-isnull(p.prodDay,0) as remDay
			from (select l.line_no,l.ord_no,l.art_no,sum(SumDay) as planDay,ord_quantity,isnull(target_dy,0) as targetQty 
				from sanpro.dbo.Line_Booking l where l.ord_factory like 'NAZ%' group by l.line_no,l.ord_no,l.art_no,ord_quantity,target_dy) l left join
			(select p.aline,p.astyle, p.aPO,sum(isnull(p.aHrTotal,0)) as prodqty,count(p.aDate) as prodDay
				from [ERP\ERP].SmartCode.dbo.Hrs_ProductionByLine p where RTRIM(p.aStage)='SEWING QC OUT' group by p.aline,p.astyle, p.aPO ) p 
				on l.line_no=p.aLine and l.ord_no=p.aStyle
				join sanpro.dbo.PO_Master po on l.ord_no=po.ord_no and l.art_no=po.art_no and p.aPO=po.po_no  
			order by l.line_no";

        SqlDataAdapter daTool = new SqlDataAdapter(qry, conn);
        DataTable dtTool = new DataTable();
        daTool.Fill(dtTool);
        Session["ToolInfo"] = dtTool;
        /////____________________

        return dt;
    }
    private void setDataSourceAndBind()
    {
        // ensure that filter is loaded
        string filter = (string)DayPilotScheduler1.ClientState["filter"];
        DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);
        DayPilotScheduler1.DataBind();
    }
    private void DbUpdateEvent(string id, DateTime start, DateTime end, string resource)
    {
        using (SqlConnection con = new SqlConnection(DbConnect.x))
        {
            int noDay = woringDay.GetNoDay(start, end);
            con.Open();
            SqlCommand cmd = new SqlCommand("uspUpdateLineBooking", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", int.Parse(id));
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@lineNo", resource);
            cmd.Parameters.AddWithValue("@sumDay", noDay);
            cmd.ExecuteNonQuery();
        }
    }

    protected void DayPilotScheduler1_EventMove(object sender, DayPilot.Web.Ui.Events.EventMoveEventArgs e)
    {
         if (Session["Username"].ToString() == "shakil" || Session["Username"].ToString() == "prince" || Session["Username"].ToString() == "Jayanta")
        { 
        string id = e.Value;
        DateTime start = e.NewStart;
        DateTime end = e.NewEnd;
        string resource = e.NewResource;

        DbUpdateEvent(id, start, end, resource);

        DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);
        DayPilotScheduler1.DataBind();
        DayPilotScheduler1.Update();
        }
    }

    //protected void DayPilotScheduler1_EventClick(object sender, EventClickEventArgs e)
    //{
    //    //// populate the fields
    //    //TextBoxEditName.Text = e.Text;
    //    //TextBoxEditStart.Text = e.Start.ToString("M/d/yyyy HH:mm");
    //    //TextBoxEditEnd.Text = e.End.ToString("M/d/yyyy HH:mm");
    //    //HiddenEditId.Value = e.Value;
    //    //DropDownEditResource.DataSource = DbSelectResources();
    //    //DropDownEditResource.DataTextField = "line";
    //    //DropDownEditResource.DataValueField = "line";
    //    //DropDownEditResource.SelectedValue = e.ResourceId;
    //    //DropDownEditResource.DataBind();

    //    //UpdatePanelEdit.Update();
    //    //ModalPopupEdit.Show();
    //}
    protected void DayPilotScheduler1_Command(object sender, DayPilot.Web.Ui.Events.CommandEventArgs e)
    {
        switch (e.Command)
        {
            case "next":
                DayPilotScheduler1.StartDate = DayPilotScheduler1.StartDate.AddYears(1);
                DayPilotScheduler1.Days = Year.Days(DayPilotScheduler1.StartDate.Year);
                DayPilotScheduler1.ScrollY = 20;
                break;
            case "previous":
                DayPilotScheduler1.StartDate = DayPilotScheduler1.StartDate.AddYears(-1);
                DayPilotScheduler1.Days = Year.Days(DayPilotScheduler1.StartDate.Year);
                break;
            case "this":
                DayPilotScheduler1.StartDate = new DateTime(DateTime.Today.Year, 1, 1);
                DayPilotScheduler1.Days = Year.Days(DayPilotScheduler1.StartDate.Year);
                break;
            //case "test":
            //    JsonData d = e.Data;
            //    break;
            case "refresh":
            case "filter":
                // refresh is always done, see setDataSourceAndBind()
                break;
            default:
                throw new Exception("Unknown command.");
        }

        setDataSourceAndBind();
        DayPilotScheduler1.Update();
    }
    protected void DayPilotScheduler1_Refresh(object sender, DayPilot.Web.Ui.Events.RefreshEventArgs e)
    {
        LoadResources();
        DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);           //DbSelectEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.EndDate.AddDays(1));
        DayPilotScheduler1.DataBind();

        UpdatePanelScheduler.Update();
        //DayPilotScheduler1.Update(CallBackUpdateType.Full);
    }
    protected void DayPilotScheduler1_EventUpdate(object sender, EventUpdateEventArgs e)
    {
        LoadResources();
        DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);           //DbSelectEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.EndDate.AddDays(1));
        DayPilotScheduler1.DataBind();

        UpdatePanelScheduler.Update();
    }
    protected void DayPilotScheduler1_EventClick(object sender, DayPilot.Web.Ui.Events.EventClickEventArgs e)
    {
        LoadResources();
        DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);           //DbSelectEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.EndDate.AddDays(1));
        DayPilotScheduler1.DataBind();

        UpdatePanelScheduler.Update();
    }

    //protected void DayPilotScheduler1_EventEdit(object sender, DayPilot.Web.Ui.Events.EventEditEventArgs e)
    //{
    //    setDataSourceAndBind();
    //    DayPilotScheduler1.Update();
    //}
    private DataTable DbSelectResources()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(DbConnect.x))
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select distinct line_no as line from Line_Booking order by line_no", con);
            da.Fill(dt);
        }
        return dt;
    }

    protected void ButtonEditSave_Click(object sender, EventArgs e)
    {
        //DateTime start = DateTime.ParseExact(TextBoxEditStart.Text, "M/d/yyyy HH:mm", Thread.CurrentThread.CurrentCulture);
        //DateTime end = DateTime.ParseExact(TextBoxEditEnd.Text, "M/d/yyyy HH:mm", Thread.CurrentThread.CurrentCulture);
        //string name = TextBoxEditName.Text;
        //string id = HiddenEditId.Value;
        //string resource = DropDownEditResource.SelectedValue.ToString();

        //DbUpdateEvent(id, start, end, resource);

        //ModalPopupEdit.Hide();

        //LoadResources();
        //DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);           //DbSelectEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.EndDate.AddDays(1));
        //DayPilotScheduler1.DataBind();

        //UpdatePanelScheduler.Update();

    }
    protected void ButtonEditCancel_Click(object sender, EventArgs e)
    {
        //ModalPopupEdit.Hide();
    }

    //private DataTable DbSelectEvents(DateTime start, DateTime end)
    //{
    //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [event] WHERE NOT (([eventend] <= @start) OR ([eventstart] >= @end))", ConfigurationManager.ConnectionStrings["DayPilot"].ConnectionString);
    //    da.SelectCommand.Parameters.AddWithValue("start", start);
    //    da.SelectCommand.Parameters.AddWithValue("end", end);

    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    return dt;
    //}

    #region Tooltip
    //protected void DayPilotBubble1_RenderContent(object sender, RenderEventArgs e)
    //{
    //    if (e is RenderResourceBubbleEventArgs)
    //    {
    //        RenderResourceBubbleEventArgs re = e as RenderResourceBubbleEventArgs;
    //        e.InnerHTML = "<b>Resource header details</b><br />Value: " + re.ResourceId;
    //    }
    //    else if (e is RenderCellBubbleEventArgs)
    //    {
    //        RenderCellBubbleEventArgs re = e as RenderCellBubbleEventArgs;
    //        e.InnerHTML = "<b>Cell details</b><br />Resource:" + re.ResourceId + "<br />From:" + re.Start + "<br />To: " + re.End;
    //    }
    //}
    protected void DayPilotBubble1_RenderEventBubble(object sender, RenderEventBubbleEventArgs e)
    {
        DataTable dt = (DataTable)Session["Event"];
        DataView dvEvent = dt.DefaultView;
        dvEvent.RowFilter = "id = " + e.Value;
        string poNo = dvEvent[0][1].ToString();
        string ordNo = dvEvent[0][2].ToString();
        string artNo = dvEvent[0][3].ToString();
        string gType = dvEvent[0][4].ToString();
        string lineno = dvEvent[0][7].ToString();
        //DateTime sewDt = DateTime.Parse(dvEvent[0][5].ToString());
        DateTime xDt = DateTime.Parse(dvEvent[0][9].ToString());
        //int lineQty = int.Parse(dvEvent[0][10].ToString());

        DataTable dtTool = (DataTable)Session["ToolInfo"];
        DataView dvTool = dtTool.DefaultView;
        dvTool.RowFilter = "PoNo = '" + poNo + "' and Line = '" + lineno + "'";
        if (dvTool.Count > 0)
        {
            string ordQty = dvTool[0][2].ToString();
            string lineQty = dvTool[0][3].ToString();
            string ProdQty = dvTool[0][4].ToString();
            string targetQty = dvTool[0][5].ToString();
            int remDay = int.Parse(dvTool[0][6].ToString());
            int remQty = int.Parse(lineQty) - int.Parse(ProdQty);
            int reqTarget = remQty / remDay;
            e.InnerHTML = "<b>Line: " + e.ResourceId + "</b><br />Style No: " + ordNo + "</b><br />Article No: " + artNo + "</b><br />Garments Type: " + gType + "</b><br />X-Factory Date: " + xDt + "<br />Order Qty: " + ordQty + "<br />Line Total Qty: " + lineQty + "<br />Production Qty: " + ProdQty + "<br />Remain Qty: " + remQty.ToString() + "<br />Target Qty: " + targetQty + "<br />Req. Target Qty: " + reqTarget.ToString();
        }
    }

    #endregion
	
	 private void Bindddlorder()
    {
        ddlOrder.Items.Clear();
        ddlOrder.Items.Add(new ListItem("-", "abc"));
        ddlOrder.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("select distinct ord_no from Line_Booking", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlOrder.DataSource = ds;
        ddlOrder.DataTextField = "ord_no";
        ddlOrder.DataValueField = "ord_no";
        ddlOrder.DataBind();

        conn.Close();
    }
    protected void ddlOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtEvent = (DataTable)Session["Event"];
        DataView dvEvent = dtEvent.DefaultView;
        string ord = ddlOrder.SelectedValue;
        if (ord == "abc")
        {
            //DayPilotScheduler1.DataSource = dtEvent;
            //DayPilotScheduler1.DataBind();
            DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);
            DayPilotScheduler1.DataBind();
        }
        else
        { 
            dvEvent.RowFilter = "ord_no = '" + ord + "'";
            DataTable dt = dvEvent.ToTable();
            DayPilotScheduler1.DataSource = dt;
            DayPilotScheduler1.DataBind();
        }
    }
}