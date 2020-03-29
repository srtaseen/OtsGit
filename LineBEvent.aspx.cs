using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LineBEvent : System.Web.UI.Page
{

    WorkingDay woringDay = new WorkingDay();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = int.Parse(Request.QueryString["id"]); // "900072";   
            DataTable dt = (DataTable)Session["Event"];
            DataView dvEvent = dt.DefaultView;
            dvEvent.RowFilter = "id = " + id;
            string poNo = dvEvent[0][1].ToString();

            // populate the fields
            TextBoxEditName.Text = poNo;
            TextBoxEditStart.Text = Convert.ToDateTime(dvEvent[0][5]).ToString();
            TextBoxEditEnd.Text = Convert.ToDateTime(dvEvent[0][6]).ToString();        //("M/d/yyyy HH:mm");
            DropDownEditResource.DataSource = DbSelectResources();
            DropDownEditResource.DataTextField = "line";
            DropDownEditResource.DataValueField = "line";
            DropDownEditResource.SelectedValue = dvEvent[0][7].ToString();
            DropDownEditResource.DataBind();

            BindGvM(poNo);
        }
    }

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

    protected void ButtonOK_Click(object sender, EventArgs e)
    {
        DateTime start = Convert.ToDateTime(TextBoxEditStart.Text);
        DateTime end = Convert.ToDateTime(TextBoxEditEnd.Text);
        string name = TextBoxEditName.Text;
        string resource = DropDownEditResource.SelectedValue;

        DbUpdateEvent(Request.QueryString["id"], start, end, resource);

        Modal.Close(this, "OK");
    }

    private string DbUpdateEvent(string id, DateTime start, DateTime end, string resource)
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
        return id;
    }

    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        Modal.Close(this);
    }
    protected void BindGvM(string poNo)
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        conn.Open();
        string strSelectCmd = "SELECT  * FROM View_Tna_Plan WHERE Po_ShipDate is NULL AND ActiveOrder='1' AND TnAapproved IS NOT NULL AND art_no = '" + poNo + "'";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
            GvM.DataSource = dt;
            GvM.DataBind();
            int columncount = GvM.Rows[0].Cells.Count;
            GvM.Rows[0].Cells.Clear();
            GvM.Rows[0].Cells.Add(new TableCell());
            GvM.Rows[0].Cells[0].ColumnSpan = columncount;
            GvM.Rows[0].Cells[0].Text = "";
        }
        else
        {
            ViewState["dtOrder"] = dt;
            GvM.DataSource = dt;
            GvM.DataBind();
        }
    }

    protected void GvM_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["art_no"].ToString();

        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            Label lblHeader2 = (Label)e.Row.FindControl("lblHeader2");
            Label lblHeader3 = (Label)e.Row.FindControl("lblHeader3");
            Label lblHeader4 = (Label)e.Row.FindControl("lblHeader4");
            Label lblHeader5 = (Label)e.Row.FindControl("lblHeader5");
            Label lblHeader6 = (Label)e.Row.FindControl("lblHeader6");
            Label lblHeader7 = (Label)e.Row.FindControl("lblHeader7");
            Label lblHeader8 = (Label)e.Row.FindControl("lblHeader8");
            Label lblHeader9 = (Label)e.Row.FindControl("lblHeader9");
            Label lblHeader10 = (Label)e.Row.FindControl("lblHeader10");
            Label lblHeader11 = (Label)e.Row.FindControl("lblHeader11");
            Label lblHeader12 = (Label)e.Row.FindControl("lblHeader12");
            Label lblHeader13 = (Label)e.Row.FindControl("lblHeader13");
            Label lblHeader14 = (Label)e.Row.FindControl("lblHeader14");
            Label lblHeader15 = (Label)e.Row.FindControl("lblHeader15");
            Label lblHeader16 = (Label)e.Row.FindControl("lblHeader16");
            Label lblHeader17 = (Label)e.Row.FindControl("lblHeader17");
            Label lblHeader18 = (Label)e.Row.FindControl("lblHeader18");
            Label lblHeader19 = (Label)e.Row.FindControl("lblHeader19");
            Label lblHeader20 = (Label)e.Row.FindControl("lblHeader20");
            //Yarn
            Label lblHeader21 = (Label)e.Row.FindControl("lblHeader21");
            Label lblHeader22 = (Label)e.Row.FindControl("lblHeader22");
            Label lblHeader23 = (Label)e.Row.FindControl("lblHeader23");
            Label lblHeader24 = (Label)e.Row.FindControl("lblHeader24");
            Label lblyarnbook = (Label)e.Row.FindControl("lblyarnbook");
            //YarnD
            Label lblHeader25 = (Label)e.Row.FindControl("lblHeader25");
            Label lblHeader26 = (Label)e.Row.FindControl("lblHeader26");
            Label yrnInhouseStrt = (Label)e.Row.FindControl("yrnInhouseStrt");
            Label yrnInhouseEnd = (Label)e.Row.FindControl("yrnInhouseEnd");
            //Knitting
            Label lblHeader27 = (Label)e.Row.FindControl("lblHeader27");
            Label lblHeader28 = (Label)e.Row.FindControl("lblHeader28");
            //Dyeing
            Label lblHeader29 = (Label)e.Row.FindControl("lblHeader29");
            Label lblHeader30 = (Label)e.Row.FindControl("lblHeader30");
            //AOP
            Label lblHeader31 = (Label)e.Row.FindControl("lblHeader31");
            Label lblHeader32 = (Label)e.Row.FindControl("lblHeader32");
            //Acc
            Label lblHeader33 = (Label)e.Row.FindControl("lblHeader33");
            Label lblHeader34 = (Label)e.Row.FindControl("lblHeader34");
            Label lblacsbook = (Label)e.Row.FindControl("lblacsbook");
            //Inv
            Label lblHeader35 = (Label)e.Row.FindControl("lblHeader35");
            Label lblHeader36 = (Label)e.Row.FindControl("lblHeader36");
            Label lblHeader37 = (Label)e.Row.FindControl("lblHeader37");
            Label lblHeader38 = (Label)e.Row.FindControl("lblHeader38");
            //prnt
            Label lblHeader39 = (Label)e.Row.FindControl("lblHeader39");
            Label lblHeader40 = (Label)e.Row.FindControl("lblHeader40");
            //Emb
            Label lblHeader41 = (Label)e.Row.FindControl("lblHeader41");
            Label lblHeader42 = (Label)e.Row.FindControl("lblHeader42");
            //RMG
            Label lblHeader43 = (Label)e.Row.FindControl("lblHeader43");
            Label lblHeader44 = (Label)e.Row.FindControl("lblHeader44");
            Label lblHeader45 = (Label)e.Row.FindControl("lblHeader45");
            Label lblHeader46 = (Label)e.Row.FindControl("lblHeader46");
            Label lblHeader47 = (Label)e.Row.FindControl("lblHeader47");
            Label lblHeader48 = (Label)e.Row.FindControl("lblHeader48");
            Label lblHeader49 = (Label)e.Row.FindControl("lblHeader49");
            Label lblHeader50 = (Label)e.Row.FindControl("lblHeader50");
            Label lblHeader51 = (Label)e.Row.FindControl("lblHeader51");
            Label lblHeader52 = (Label)e.Row.FindControl("lblHeader52");
            Label lblHeader53 = (Label)e.Row.FindControl("lblHeader53");
            Label lblHeader54 = (Label)e.Row.FindControl("lblHeader54");
            Label lblHeader55 = (Label)e.Row.FindControl("lblHeader55");
            Label lblHeader56 = (Label)e.Row.FindControl("lblHeader56");
            Label lblHeader57 = (Label)e.Row.FindControl("lblHeader57");
            Label lblHeader58 = (Label)e.Row.FindControl("lblHeader58");
            Label lblHeader59 = (Label)e.Row.FindControl("lblHeader59");

            DataTable dt = (DataTable)ViewState["dtOrder"];
            lblHeader.Text = dt.Rows[0]["Tmplt_Evnt1"].ToString();
            lblHeader2.Text = dt.Rows[0]["Tmplt_Evnt2"].ToString();
            lblHeader3.Text = dt.Rows[0]["Tmplt_Evnt3"].ToString();
            lblHeader4.Text = dt.Rows[0]["Tmplt_Evnt4"].ToString();
            lblHeader5.Text = dt.Rows[0]["Tmplt_Evnt5"].ToString();
            lblHeader6.Text = dt.Rows[0]["Tmplt_Evnt6"].ToString();
            lblHeader7.Text = dt.Rows[0]["Tmplt_Evnt7"].ToString();
            lblHeader8.Text = dt.Rows[0]["Tmplt_Evnt8"].ToString();
            lblHeader9.Text = dt.Rows[0]["Tmplt_Evnt9"].ToString();
            lblHeader10.Text = dt.Rows[0]["Tmplt_Evnt10"].ToString();
            lblHeader11.Text = dt.Rows[0]["Tmplt_Evnt11"].ToString();
            lblHeader12.Text = dt.Rows[0]["Tmplt_Evnt12"].ToString();
            lblHeader13.Text = dt.Rows[0]["Tmplt_Evnt13"].ToString();
            lblHeader14.Text = dt.Rows[0]["Tmplt_Evnt14"].ToString();
            lblHeader15.Text = dt.Rows[0]["Tmplt_Evnt15"].ToString();
            lblHeader16.Text = dt.Rows[0]["Tmplt_Evnt16"].ToString();
            lblHeader17.Text = dt.Rows[0]["Tmplt_Evnt17"].ToString();
            lblHeader18.Text = dt.Rows[0]["Tmplt_Evnt18"].ToString();
            lblHeader19.Text = dt.Rows[0]["Tmplt_Evnt19"].ToString();
            lblHeader20.Text = dt.Rows[0]["Tmplt_Evnt20"].ToString();
            //Yarn
            lblyarnbook.Text = dt.Rows[0]["Tmplt_Evnt5"].ToString();
            lblHeader21.Text = dt.Rows[0]["Tmplt_Evnt21"].ToString();
            lblHeader22.Text = dt.Rows[0]["Tmplt_Evnt22"].ToString();
            lblHeader23.Text = dt.Rows[0]["Tmplt_Evnt23"].ToString();
            lblHeader24.Text = dt.Rows[0]["Tmplt_Evnt24"].ToString();
            //YarnD
            yrnInhouseStrt.Text = dt.Rows[0]["Tmplt_Evnt23"].ToString();
            yrnInhouseEnd.Text = dt.Rows[0]["Tmplt_Evnt24"].ToString();
            lblHeader25.Text = dt.Rows[0]["Tmplt_Evnt56"].ToString();
            lblHeader26.Text = dt.Rows[0]["Tmplt_Evnt57"].ToString();
            //Knitting
            lblHeader27.Text = dt.Rows[0]["Tmplt_Evnt25"].ToString();
            lblHeader28.Text = dt.Rows[0]["Tmplt_Evnt26"].ToString();
            //Dyeing
            lblHeader29.Text = dt.Rows[0]["Tmplt_Evnt27"].ToString();
            lblHeader30.Text = dt.Rows[0]["Tmplt_Evnt28"].ToString();
            //AOP
            lblHeader31.Text = dt.Rows[0]["Tmplt_Evnt58"].ToString();
            lblHeader32.Text = dt.Rows[0]["Tmplt_Evnt59"].ToString();
            //Acc
            lblacsbook.Text = dt.Rows[0]["Tmplt_Evnt3"].ToString();
            lblHeader33.Text = dt.Rows[0]["Tmplt_Evnt29"].ToString();
            lblHeader34.Text = dt.Rows[0]["Tmplt_Evnt30"].ToString();
            //Inv
            lblHeader35.Text = dt.Rows[0]["Tmplt_Evnt31"].ToString();
            lblHeader36.Text = dt.Rows[0]["Tmplt_Evnt32"].ToString();
            lblHeader37.Text = dt.Rows[0]["Tmplt_Evnt33"].ToString();
            lblHeader38.Text = dt.Rows[0]["Tmplt_Evnt34"].ToString();
            //prnt
            lblHeader39.Text = dt.Rows[0]["Tmplt_Evnt38"].ToString();
            lblHeader40.Text = dt.Rows[0]["Tmplt_Evnt39"].ToString();
            //Emb
            lblHeader41.Text = dt.Rows[0]["Tmplt_Evnt40"].ToString();
            lblHeader42.Text = dt.Rows[0]["Tmplt_Evnt41"].ToString();
            //RMG
            lblHeader43.Text = dt.Rows[0]["Tmplt_Evnt35"].ToString();
            lblHeader44.Text = dt.Rows[0]["Tmplt_Evnt36"].ToString();
            lblHeader45.Text = dt.Rows[0]["Tmplt_Evnt37"].ToString();
            lblHeader46.Text = dt.Rows[0]["Tmplt_Evnt42"].ToString();
            lblHeader47.Text = dt.Rows[0]["Tmplt_Evnt43"].ToString();
            lblHeader48.Text = dt.Rows[0]["Tmplt_Evnt44"].ToString();
            lblHeader49.Text = dt.Rows[0]["Tmplt_Evnt45"].ToString();
            lblHeader50.Text = dt.Rows[0]["Tmplt_Evnt46"].ToString();
            lblHeader51.Text = dt.Rows[0]["Tmplt_Evnt47"].ToString();
            lblHeader52.Text = dt.Rows[0]["Tmplt_Evnt48"].ToString();
            lblHeader53.Text = dt.Rows[0]["Tmplt_Evnt49"].ToString();
            lblHeader54.Text = dt.Rows[0]["Tmplt_Evnt50"].ToString();
            lblHeader55.Text = dt.Rows[0]["Tmplt_Evnt51"].ToString();
            lblHeader56.Text = dt.Rows[0]["Tmplt_Evnt52"].ToString();
            lblHeader57.Text = dt.Rows[0]["Tmplt_Evnt53"].ToString();
            lblHeader58.Text = dt.Rows[0]["Tmplt_Evnt54"].ToString();
            lblHeader59.Text = dt.Rows[0]["Tmplt_Evnt55"].ToString();
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblr1 = (Label)e.Row.FindControl("lblr1");
            Label lblr2 = (Label)e.Row.FindControl("lblr2");
            Label lblr3 = (Label)e.Row.FindControl("lblr3");
            Label lblr4 = (Label)e.Row.FindControl("lblr4");
            Label lblr5 = (Label)e.Row.FindControl("lblr5");
            Label lblr6 = (Label)e.Row.FindControl("lblr6");
            Label lblr7 = (Label)e.Row.FindControl("lblr7");
            Label lblr8 = (Label)e.Row.FindControl("lblr8");
            Label lblr9 = (Label)e.Row.FindControl("lblr9");
            Label lblr10 = (Label)e.Row.FindControl("lblr10");
            Label lblr11 = (Label)e.Row.FindControl("lblr11");
            Label lblr12 = (Label)e.Row.FindControl("lblr12");
            Label lblr13 = (Label)e.Row.FindControl("lblr13");
            Label lblr14 = (Label)e.Row.FindControl("lblr14");
            Label lblr15 = (Label)e.Row.FindControl("lblr15");
            Label lblr16 = (Label)e.Row.FindControl("lblr16");
            Label lblr17 = (Label)e.Row.FindControl("lblr17");
            Label lblr18 = (Label)e.Row.FindControl("lblr18");
            Label lblr19 = (Label)e.Row.FindControl("lblr19");
            Label lblr20 = (Label)e.Row.FindControl("lblr20");
            Label lblordconfirm = (Label)e.Row.FindControl("lblordconfirm");
            //Yarn
            Label lblryarnbok = (Label)e.Row.FindControl("lblryarnbok");
            Label lblr21 = (Label)e.Row.FindControl("lblr21");
            Label lblr22 = (Label)e.Row.FindControl("lblr22");
            Label lblr23 = (Label)e.Row.FindControl("lblr23");
            Label lblr24 = (Label)e.Row.FindControl("lblr24");
            //YarnD
            Label yrnInhouseStrt = (Label)e.Row.FindControl("yrnInhouseStrt");
            Label yrnInhouseEnd = (Label)e.Row.FindControl("yrnInhouseEnd");
            Label lblr25 = (Label)e.Row.FindControl("lblr25");
            Label lblr26 = (Label)e.Row.FindControl("lblr26");
            //Knitting
            Label lblr27 = (Label)e.Row.FindControl("lblr27");
            Label lblr28 = (Label)e.Row.FindControl("lblr28");
            //Dyeing
            Label lblr29 = (Label)e.Row.FindControl("lblr29");
            Label lblr30 = (Label)e.Row.FindControl("lblr30");
            //AOP
            Label lblr31 = (Label)e.Row.FindControl("lblr31");
            Label lblr32 = (Label)e.Row.FindControl("lblr32");
            //Acc
            Label lblracsbok = (Label)e.Row.FindControl("lblracsbok");
            Label lblr33 = (Label)e.Row.FindControl("lblr33");
            Label lblr34 = (Label)e.Row.FindControl("lblr34");
            //Inv
            Label lblr35 = (Label)e.Row.FindControl("lblr35");
            Label lblr36 = (Label)e.Row.FindControl("lblr36");
            Label lblr37 = (Label)e.Row.FindControl("lblr37");
            Label lblr38 = (Label)e.Row.FindControl("lblr38");
            //prnt
            Label lblr39 = (Label)e.Row.FindControl("lblr39");
            Label lblr40 = (Label)e.Row.FindControl("lblr40");
            //Emb
            Label lblr41 = (Label)e.Row.FindControl("lblr41");
            Label lblr42 = (Label)e.Row.FindControl("lblr42");
            //RMG
            Label lblr43 = (Label)e.Row.FindControl("lblr43");
            Label lblr44 = (Label)e.Row.FindControl("lblr44");
            Label lblr45 = (Label)e.Row.FindControl("lblr45");
            Label lblr46 = (Label)e.Row.FindControl("lblr46");
            Label lblr47 = (Label)e.Row.FindControl("lblr47");
            Label lblr48 = (Label)e.Row.FindControl("lblr48");
            Label lblr49 = (Label)e.Row.FindControl("lblr49");
            Label lblr50 = (Label)e.Row.FindControl("lblr50");
            Label lblr51 = (Label)e.Row.FindControl("lblr51");
            Label lblr52 = (Label)e.Row.FindControl("lblr52");
            Label lblr53 = (Label)e.Row.FindControl("lblr53");
            Label lblr54 = (Label)e.Row.FindControl("lblr54");
            Label lblr55 = (Label)e.Row.FindControl("lblr55");
            Label lblr56 = (Label)e.Row.FindControl("lblr56");
            Label lblr57 = (Label)e.Row.FindControl("lblr57");
            Label lblr58 = (Label)e.Row.FindControl("lblr58");
            Label lblr59 = (Label)e.Row.FindControl("lblr59");

            Label lbld1 = (Label)e.Row.FindControl("lbld1");
            Label lbld2 = (Label)e.Row.FindControl("lbld2");
            Label lbld3 = (Label)e.Row.FindControl("lbld3");
            Label lbld4 = (Label)e.Row.FindControl("lbld4");
            Label lbld5 = (Label)e.Row.FindControl("lbld5");
            Label lbld6 = (Label)e.Row.FindControl("lbld6");
            Label lbld7 = (Label)e.Row.FindControl("lbld7");
            Label lbld8 = (Label)e.Row.FindControl("lbld8");
            Label lbld9 = (Label)e.Row.FindControl("lbld9");
            Label lbld10 = (Label)e.Row.FindControl("lbld10");
            Label lbld11 = (Label)e.Row.FindControl("lbld11");
            Label lbld12 = (Label)e.Row.FindControl("lbld12");
            Label lbld13 = (Label)e.Row.FindControl("lbld13");
            Label lbld14 = (Label)e.Row.FindControl("lbld14");
            Label lbld15 = (Label)e.Row.FindControl("lbld15");
            Label lbld16 = (Label)e.Row.FindControl("lbld16");
            Label lbld17 = (Label)e.Row.FindControl("lbld17");
            Label lbld18 = (Label)e.Row.FindControl("lbld18");
            Label lbld19 = (Label)e.Row.FindControl("lbld19");
            Label lbld20 = (Label)e.Row.FindControl("lbld20");
            Label lbldays = (Label)e.Row.FindControl("lbldays");
            //Yarn
            Label lbld21 = (Label)e.Row.FindControl("lbld21");
            Label lbld22 = (Label)e.Row.FindControl("lbld22");
            Label lbld23 = (Label)e.Row.FindControl("lbld23");
            Label lbld24 = (Label)e.Row.FindControl("lbld24");
            //YarnD
            Label lbld25 = (Label)e.Row.FindControl("lbld25");
            Label lbld26 = (Label)e.Row.FindControl("lbld26");
            //Knitting
            Label lbld27 = (Label)e.Row.FindControl("lbld27");
            Label lbld28 = (Label)e.Row.FindControl("lbld28");
            //Dyeing
            Label lbld29 = (Label)e.Row.FindControl("lbld29");
            Label lbld30 = (Label)e.Row.FindControl("lbld30");
            //AOP
            Label lbld31 = (Label)e.Row.FindControl("lbld31");
            Label lbld32 = (Label)e.Row.FindControl("lbld32");
            //Acc
            Label lbld33 = (Label)e.Row.FindControl("lbld33");
            Label lbld34 = (Label)e.Row.FindControl("lbld34");
            //Inv
            Label lbld35 = (Label)e.Row.FindControl("lbld35");
            Label lbld36 = (Label)e.Row.FindControl("lbld36");
            Label lbld37 = (Label)e.Row.FindControl("lbld37");
            Label lbld38 = (Label)e.Row.FindControl("lbld38");
            //prnt
            Label lbld39 = (Label)e.Row.FindControl("lbld39");
            Label lbld40 = (Label)e.Row.FindControl("lbld40");
            //Emb
            Label lbld41 = (Label)e.Row.FindControl("lbld41");
            Label lbld42 = (Label)e.Row.FindControl("lbld42");
            //RMG
            Label lbld43 = (Label)e.Row.FindControl("lbld43");
            Label lbld44 = (Label)e.Row.FindControl("lbld44");
            Label lbld45 = (Label)e.Row.FindControl("lbld45");
            Label lbld46 = (Label)e.Row.FindControl("lbld46");
            Label lbld47 = (Label)e.Row.FindControl("lbld47");
            Label lbld48 = (Label)e.Row.FindControl("lbld48");
            Label lbld49 = (Label)e.Row.FindControl("lbld49");
            Label lbld50 = (Label)e.Row.FindControl("lbld50");
            Label lbld51 = (Label)e.Row.FindControl("lbld51");
            Label lbld52 = (Label)e.Row.FindControl("lbld52");
            Label lbld53 = (Label)e.Row.FindControl("lbld53");
            Label lbld54 = (Label)e.Row.FindControl("lbld54");
            Label lbld55 = (Label)e.Row.FindControl("lbld55");
            Label lbld56 = (Label)e.Row.FindControl("lbld56");
            Label lbld57 = (Label)e.Row.FindControl("lbld57");
            Label lbld58 = (Label)e.Row.FindControl("lbld58");
            Label lbld59 = (Label)e.Row.FindControl("lbld59");

            Label lbl1 = (Label)e.Row.FindControl("lbl1");
            Label lbl2 = (Label)e.Row.FindControl("lbl2");
            Label lbl3 = (Label)e.Row.FindControl("lbl3");
            Label lbl4 = (Label)e.Row.FindControl("lbl4");
            Label lbl5 = (Label)e.Row.FindControl("lbl5");
            Label lbl6 = (Label)e.Row.FindControl("lbl6");
            Label lbl7 = (Label)e.Row.FindControl("lbl7");
            Label lbl8 = (Label)e.Row.FindControl("lbl8");
            Label lbl9 = (Label)e.Row.FindControl("lbl9");
            Label lbl10 = (Label)e.Row.FindControl("lbl10");
            Label lbl11 = (Label)e.Row.FindControl("lbl11");
            Label lbl12 = (Label)e.Row.FindControl("lbl12");
            Label lbl13 = (Label)e.Row.FindControl("lbl13");
            Label lbl14 = (Label)e.Row.FindControl("lbl14");
            Label lbl15 = (Label)e.Row.FindControl("lbl15");
            Label lbl16 = (Label)e.Row.FindControl("lbl16");
            Label lbl17 = (Label)e.Row.FindControl("lbl17");
            Label lbl18 = (Label)e.Row.FindControl("lbl18");
            Label lbl19 = (Label)e.Row.FindControl("lbl19");
            Label lbl20 = (Label)e.Row.FindControl("lbl20");

            Label lblxfactory = (Label)e.Row.FindControl("lblxfactory");
            Label lblrexfactory = (Label)e.Row.FindControl("lblrexfactory");
            //Yarn
            Label lbl21 = (Label)e.Row.FindControl("lbl21");
            Label lbl22 = (Label)e.Row.FindControl("lbl22");
            Label lbl23 = (Label)e.Row.FindControl("lbl23");
            Label lbl24 = (Label)e.Row.FindControl("lbl24");
            //YarnD
            Label lbl25 = (Label)e.Row.FindControl("lbl25");
            Label lbl26 = (Label)e.Row.FindControl("lbl26");
            //Knitting
            Label lbl27 = (Label)e.Row.FindControl("lbl27");
            Label lbl28 = (Label)e.Row.FindControl("lbl28");
            //Dyeing
            Label lbl29 = (Label)e.Row.FindControl("lbl29");
            Label lbl30 = (Label)e.Row.FindControl("lbl30");
            //AOP
            Label lbl31 = (Label)e.Row.FindControl("lbl31");
            Label lbl32 = (Label)e.Row.FindControl("lbl32");
            //Acc
            Label lbl33 = (Label)e.Row.FindControl("lbl33");
            Label lbl34 = (Label)e.Row.FindControl("lbl34");
            //Inv
            Label lbl35 = (Label)e.Row.FindControl("lbl35");
            Label lbl36 = (Label)e.Row.FindControl("lbl36");
            Label lbl37 = (Label)e.Row.FindControl("lbl37");
            Label lbl38 = (Label)e.Row.FindControl("lbl38");
            //prnt
            Label lbl39 = (Label)e.Row.FindControl("lbl39");
            Label lbl40 = (Label)e.Row.FindControl("lbl40");
            //Emb
            Label lbl41 = (Label)e.Row.FindControl("lbl41");
            Label lbl42 = (Label)e.Row.FindControl("lbl42");
            //RMG
            Label lbl43 = (Label)e.Row.FindControl("lbl43");
            Label lbl44 = (Label)e.Row.FindControl("lbl44");
            Label lbl45 = (Label)e.Row.FindControl("lbl45");
            Label lbl46 = (Label)e.Row.FindControl("lbl46");
            Label lbl47 = (Label)e.Row.FindControl("lbl47");
            Label lbl48 = (Label)e.Row.FindControl("lbl48");
            Label lbl49 = (Label)e.Row.FindControl("lbl49");
            Label lbl50 = (Label)e.Row.FindControl("lbl50");
            Label lbl51 = (Label)e.Row.FindControl("lbl51");
            Label lbl52 = (Label)e.Row.FindControl("lbl52");
            Label lbl53 = (Label)e.Row.FindControl("lbl53");
            Label lbl54 = (Label)e.Row.FindControl("lbl54");
            Label lbl55 = (Label)e.Row.FindControl("lbl55");
            Label lbl56 = (Label)e.Row.FindControl("lbl56");
            Label lbl57 = (Label)e.Row.FindControl("lbl57");
            Label lbl58 = (Label)e.Row.FindControl("lbl58");
            Label lbl59 = (Label)e.Row.FindControl("lbl59");

            if (string.IsNullOrEmpty(lblrexfactory.Text.Trim()))
            {
                DateTime ad1 = DateTime.Now;
                DateTime ad2 = Convert.ToDateTime(lblxfactory.Text);
                int rexdays = (ad1 - ad2).Days;
                lbldays.Text = rexdays.ToString();
            }
            else
            {
                DateTime ad1 = DateTime.Now;
                DateTime ad2 = Convert.ToDateTime(lblrexfactory.Text);
                int rexdays = (ad1 - ad2).Days;
                lbldays.Text = rexdays.ToString();
            }

            //Delay Days Count 
            if (string.IsNullOrEmpty(lblr1.Text.Trim()))
            {
                lblr1.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl1.Text);
                int days = (d1 - d2).Days;
                lbld1.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr1.Text);
                DateTime d2 = Convert.ToDateTime(lbl1.Text);
                int days = (d1 - d2).Days;
                lbld1.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr2.Text.Trim()))
            {
                lblr2.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl2.Text);
                int days = (d1 - d2).Days;
                lbld2.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr2.Text);
                DateTime d2 = Convert.ToDateTime(lbl2.Text);
                int days = (d1 - d2).Days;
                lbld2.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr3.Text.Trim()))
            {
                lblr3.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl3.Text);
                int days = (d1 - d2).Days;
                lbld3.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr3.Text);
                DateTime d2 = Convert.ToDateTime(lbl3.Text);
                int days = (d1 - d2).Days;
                lbld3.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr4.Text.Trim()))
            {
                lblr4.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl4.Text);
                int days = (d1 - d2).Days;
                lbld4.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr4.Text);
                DateTime d2 = Convert.ToDateTime(lbl4.Text);
                int days = (d1 - d2).Days;
                lbld4.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr5.Text.Trim()))
            {
                lblr5.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl5.Text);
                int days = (d1 - d2).Days;
                lbld5.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr5.Text);
                DateTime d2 = Convert.ToDateTime(lbl5.Text);
                int days = (d1 - d2).Days;
                lbld5.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr6.Text.Trim()))
            {
                lblr6.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl6.Text);
                int days = (d1 - d2).Days;
                lbld6.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr6.Text);
                DateTime d2 = Convert.ToDateTime(lbl6.Text);
                int days = (d1 - d2).Days;
                lbld6.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr7.Text.Trim()))
            {
                lblr7.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl7.Text);
                int days = (d1 - d2).Days;
                lbld7.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr7.Text);
                DateTime d2 = Convert.ToDateTime(lbl7.Text);
                int days = (d1 - d2).Days;
                lbld7.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr8.Text.Trim()))
            {
                lblr8.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl8.Text);
                int days = (d1 - d2).Days;
                lbld8.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr8.Text);
                DateTime d2 = Convert.ToDateTime(lbl8.Text);
                int days = (d1 - d2).Days;
                lbld8.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr9.Text.Trim()))
            {
                lblr9.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl9.Text);
                int days = (d1 - d2).Days;
                lbld9.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr9.Text);
                DateTime d2 = Convert.ToDateTime(lbl9.Text);
                int days = (d1 - d2).Days;
                lbld9.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr10.Text.Trim()))
            {
                lblr10.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl10.Text);
                int days = (d1 - d2).Days;
                lbld10.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr10.Text);
                DateTime d2 = Convert.ToDateTime(lbl10.Text);
                int days = (d1 - d2).Days;
                lbld10.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr11.Text.Trim()))
            {
                lblr11.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl11.Text);
                int days = (d1 - d2).Days;
                lbld11.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr11.Text);
                DateTime d2 = Convert.ToDateTime(lbl11.Text);
                int days = (d1 - d2).Days;
                lbld11.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr12.Text.Trim()))
            {
                lblr12.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl12.Text);
                int days = (d1 - d2).Days;
                lbld12.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr12.Text);
                DateTime d2 = Convert.ToDateTime(lbl12.Text);
                int days = (d1 - d2).Days;
                lbld12.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr13.Text.Trim()))
            {
                lblr13.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl13.Text);
                int days = (d1 - d2).Days;
                lbld13.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr13.Text);
                DateTime d2 = Convert.ToDateTime(lbl13.Text);
                int days = (d1 - d2).Days;
                lbld13.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr14.Text.Trim()))
            {
                lblr14.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl14.Text);
                int days = (d1 - d2).Days;
                lbld14.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr14.Text);
                DateTime d2 = Convert.ToDateTime(lbl14.Text);
                int days = (d1 - d2).Days;
                lbld14.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr15.Text.Trim()))
            {
                lblr15.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl15.Text);
                int days = (d1 - d2).Days;
                lbld15.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr15.Text);
                DateTime d2 = Convert.ToDateTime(lbl15.Text);
                int days = (d1 - d2).Days;
                lbld15.Text = days.ToString();

            }
            if (string.IsNullOrEmpty(lblr16.Text.Trim()))
            {
                lblr16.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl16.Text);
                int days = (d1 - d2).Days;
                lbld16.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr16.Text);
                DateTime d2 = Convert.ToDateTime(lbl16.Text);
                int days = (d1 - d2).Days;
                lbld16.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr17.Text.Trim()))
            {
                lblr17.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl17.Text);
                int days = (d1 - d2).Days;
                lbld17.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr17.Text);
                DateTime d2 = Convert.ToDateTime(lbl17.Text);
                int days = (d1 - d2).Days;
                lbld17.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr18.Text.Trim()))
            {
                lblr18.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl18.Text);
                int days = (d1 - d2).Days;
                lbld18.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr18.Text);
                DateTime d2 = Convert.ToDateTime(lbl18.Text);
                int days = (d1 - d2).Days;
                lbld18.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr19.Text.Trim()))
            {
                lblr19.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl19.Text);
                int days = (d1 - d2).Days;
                lbld19.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr19.Text);
                DateTime d2 = Convert.ToDateTime(lbl19.Text);
                int days = (d1 - d2).Days;
                lbld19.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr20.Text.Trim()))
            {
                lblr20.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl20.Text);
                int days = (d1 - d2).Days;
                lbld20.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr20.Text);
                DateTime d2 = Convert.ToDateTime(lbl20.Text);
                int days = (d1 - d2).Days;
                lbld20.Text = days.ToString();
            }

            //Yarn
            if (string.IsNullOrEmpty(lblryarnbok.Text.Trim()))
            {
                lblryarnbok.Text = "Not Received";
                lblryarnbok.ForeColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrEmpty(lblr21.Text.Trim()))
            {
                lblr21.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl21.Text);
                int days = (d1 - d2).Days;
                lbld21.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr21.Text);
                DateTime d2 = Convert.ToDateTime(lbl21.Text);
                int days = (d1 - d2).Days;
                lbld21.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr22.Text.Trim()))
            {
                lblr22.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl22.Text);
                int days = (d1 - d2).Days;
                lbld22.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr22.Text);
                DateTime d2 = Convert.ToDateTime(lbl22.Text);
                int days = (d1 - d2).Days;
                lbld22.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr23.Text.Trim()))
            {
                lblr23.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl23.Text);
                int days = (d1 - d2).Days;
                lbld23.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr23.Text);
                DateTime d2 = Convert.ToDateTime(lbl23.Text);
                int days = (d1 - d2).Days;
                lbld23.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr24.Text.Trim()))
            {
                lblr24.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl24.Text);
                int days = (d1 - d2).Days;
                lbld24.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr24.Text);
                DateTime d2 = Convert.ToDateTime(lbl24.Text);
                int days = (d1 - d2).Days;
                lbld24.Text = days.ToString();
            }

            //YarnD
            if (string.IsNullOrEmpty(yrnInhouseStrt.Text.Trim()))
            {
                yrnInhouseStrt.Text = "Not Started";
                yrnInhouseStrt.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(yrnInhouseEnd.Text.Trim()))
            {
                yrnInhouseEnd.Text = "Not Finished";
                yrnInhouseEnd.ForeColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrEmpty(lblr25.Text.Trim()))
            {
                lblr25.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl25.Text);
                int days = (d1 - d2).Days;
                lbld25.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr25.Text);
                DateTime d2 = Convert.ToDateTime(lbl25.Text);
                int days = (d1 - d2).Days;
                lbld25.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr26.Text.Trim()))
            {
                lblr26.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl26.Text);
                int days = (d1 - d2).Days;
                lbld26.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr26.Text);
                DateTime d2 = Convert.ToDateTime(lbl26.Text);
                int days = (d1 - d2).Days;
                lbld26.Text = days.ToString();
            }

            //Knitting
            if (string.IsNullOrEmpty(lblr27.Text.Trim()))
            {
                lblr27.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl27.Text);
                int days = (d1 - d2).Days;
                lbld27.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr27.Text);
                DateTime d2 = Convert.ToDateTime(lbl27.Text);
                int days = (d1 - d2).Days;
                lbld27.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr28.Text.Trim()))
            {
                lblr28.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl28.Text);
                int days = (d1 - d2).Days;
                lbld28.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr28.Text);
                DateTime d2 = Convert.ToDateTime(lbl28.Text);
                int days = (d1 - d2).Days;
                lbld28.Text = days.ToString();
            }
            //Dyeing
            if (string.IsNullOrEmpty(lblr29.Text.Trim()))
            {
                lblr29.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl29.Text);
                int days = (d1 - d2).Days;
                lbld29.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr29.Text);
                DateTime d2 = Convert.ToDateTime(lbl29.Text);
                int days = (d1 - d2).Days;
                lbld29.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr30.Text.Trim()))
            {
                lblr30.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl30.Text);
                int days = (d1 - d2).Days;
                lbld30.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr30.Text);
                DateTime d2 = Convert.ToDateTime(lbl30.Text);
                int days = (d1 - d2).Days;
                lbld30.Text = days.ToString();
            }
            //AOP
            if (string.IsNullOrEmpty(lblr31.Text.Trim()))
            {
                lblr31.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl31.Text);
                int days = (d1 - d2).Days;
                lbld31.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr31.Text);
                DateTime d2 = Convert.ToDateTime(lbl31.Text);
                int days = (d1 - d2).Days;
                lbld31.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr32.Text.Trim()))
            {
                lblr32.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl32.Text);
                int days = (d1 - d2).Days;
                lbld32.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr32.Text);
                DateTime d2 = Convert.ToDateTime(lbl32.Text);
                int days = (d1 - d2).Days;
                lbld32.Text = days.ToString();
            }
            //Acc
            if (string.IsNullOrEmpty(lblracsbok.Text.Trim()))
            {
                lblracsbok.Text = "Not Received";
                lblracsbok.ForeColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrEmpty(lblr33.Text.Trim()))
            {
                lblr33.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl33.Text);
                int days = (d1 - d2).Days;
                lbld33.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr33.Text);
                DateTime d2 = Convert.ToDateTime(lbl33.Text);
                int days = (d1 - d2).Days;
                lbld33.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr34.Text.Trim()))
            {
                lblr34.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl34.Text);
                int days = (d1 - d2).Days;
                lbld34.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr34.Text);
                DateTime d2 = Convert.ToDateTime(lbl34.Text);
                int days = (d1 - d2).Days;
                lbld34.Text = days.ToString();
            }
            //Inv
            if (string.IsNullOrEmpty(lblr35.Text.Trim()))
            {
                lblr35.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl35.Text);
                int days = (d1 - d2).Days;
                lbld35.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr35.Text);
                DateTime d2 = Convert.ToDateTime(lbl35.Text);
                int days = (d1 - d2).Days;
                lbld35.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr36.Text.Trim()))
            {
                lblr36.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl36.Text);
                int days = (d1 - d2).Days;
                lbld36.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr36.Text);
                DateTime d2 = Convert.ToDateTime(lbl36.Text);
                int days = (d1 - d2).Days;
                lbld36.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr37.Text.Trim()))
            {
                lblr37.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl37.Text);
                int days = (d1 - d2).Days;
                lbld37.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr37.Text);
                DateTime d2 = Convert.ToDateTime(lbl37.Text);
                int days = (d1 - d2).Days;
                lbld37.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr38.Text.Trim()))
            {
                lblr38.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl38.Text);
                int days = (d1 - d2).Days;
                lbld38.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr38.Text);
                DateTime d2 = Convert.ToDateTime(lbl38.Text);
                int days = (d1 - d2).Days;
                lbld38.Text = days.ToString();
            }
            //prnt
            if (string.IsNullOrEmpty(lblr39.Text.Trim()))
            {
                lblr39.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl39.Text);
                int days = (d1 - d2).Days;
                lbld39.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr39.Text);
                DateTime d2 = Convert.ToDateTime(lbl39.Text);
                int days = (d1 - d2).Days;
                lbld39.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr40.Text.Trim()))
            {
                lblr40.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl40.Text);
                int days = (d1 - d2).Days;
                lbld40.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr40.Text);
                DateTime d2 = Convert.ToDateTime(lbl40.Text);
                int days = (d1 - d2).Days;
                lbld40.Text = days.ToString();
            }
            //Emb
            if (string.IsNullOrEmpty(lblr41.Text.Trim()))
            {
                lblr41.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl41.Text);
                int days = (d1 - d2).Days;
                lbld41.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr41.Text);
                DateTime d2 = Convert.ToDateTime(lbl41.Text);
                int days = (d1 - d2).Days;
                lbld41.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr42.Text.Trim()))
            {
                lblr42.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl42.Text);
                int days = (d1 - d2).Days;
                lbld42.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr42.Text);
                DateTime d2 = Convert.ToDateTime(lbl42.Text);
                int days = (d1 - d2).Days;
                lbld42.Text = days.ToString();
            }
            //RMG
            if (string.IsNullOrEmpty(lblr43.Text.Trim()))
            {
                lblr43.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl43.Text);
                int days = (d1 - d2).Days;
                lbld43.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr43.Text);
                DateTime d2 = Convert.ToDateTime(lbl43.Text);
                int days = (d1 - d2).Days;
                lbld43.Text = days.ToString();
            }


            if (string.IsNullOrEmpty(lblr44.Text.Trim()))
            {
                lblr44.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl44.Text);
                int days = (d1 - d2).Days;
                lbld44.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr44.Text);
                DateTime d2 = Convert.ToDateTime(lbl44.Text);
                int days = (d1 - d2).Days;
                lbld44.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr45.Text.Trim()))
            {
                lblr45.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl45.Text);
                int days = (d1 - d2).Days;
                lbld45.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr45.Text);
                DateTime d2 = Convert.ToDateTime(lbl45.Text);
                int days = (d1 - d2).Days;
                lbld45.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr46.Text.Trim()))
            {
                lblr46.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl46.Text);
                int days = (d1 - d2).Days;
                lbld46.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr46.Text);
                DateTime d2 = Convert.ToDateTime(lbl46.Text);
                int days = (d1 - d2).Days;
                lbld46.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr47.Text.Trim()))
            {
                lblr47.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl47.Text);
                int days = (d1 - d2).Days;
                lbld47.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr47.Text);
                DateTime d2 = Convert.ToDateTime(lbl47.Text);
                int days = (d1 - d2).Days;
                lbld47.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr48.Text.Trim()))
            {
                lblr48.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl48.Text);
                int days = (d1 - d2).Days;
                lbld48.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr48.Text);
                DateTime d2 = Convert.ToDateTime(lbl48.Text);
                int days = (d1 - d2).Days;
                lbld48.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr49.Text.Trim()))
            {
                lblr49.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl49.Text);
                int days = (d1 - d2).Days;
                lbld49.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr49.Text);
                DateTime d2 = Convert.ToDateTime(lbl49.Text);
                int days = (d1 - d2).Days;
                lbld49.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr50.Text.Trim()))
            {
                lblr50.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl50.Text);
                int days = (d1 - d2).Days;
                lbld50.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr50.Text);
                DateTime d2 = Convert.ToDateTime(lbl50.Text);
                int days = (d1 - d2).Days;
                lbld50.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr51.Text.Trim()))
            {
                lblr51.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl51.Text);
                int days = (d1 - d2).Days;
                lbld51.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr51.Text);
                DateTime d2 = Convert.ToDateTime(lbl51.Text);
                int days = (d1 - d2).Days;
                lbld51.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr52.Text.Trim()))
            {
                lblr52.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl52.Text);
                int days = (d1 - d2).Days;
                lbld52.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr52.Text);
                DateTime d2 = Convert.ToDateTime(lbl52.Text);
                int days = (d1 - d2).Days;
                lbld52.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr53.Text.Trim()))
            {
                lblr53.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl53.Text);
                int days = (d1 - d2).Days;
                lbld53.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr53.Text);
                DateTime d2 = Convert.ToDateTime(lbl53.Text);
                int days = (d1 - d2).Days;
                lbld53.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr54.Text.Trim()))
            {
                lblr54.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl54.Text);
                int days = (d1 - d2).Days;
                lbld54.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr54.Text);
                DateTime d2 = Convert.ToDateTime(lbl54.Text);
                int days = (d1 - d2).Days;
                lbld54.Text = days.ToString();
            }

            if (string.IsNullOrEmpty(lblr55.Text.Trim()))
            {
                lblr55.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl55.Text);
                int days = (d1 - d2).Days;
                lbld55.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr55.Text);
                DateTime d2 = Convert.ToDateTime(lbl55.Text);
                int days = (d1 - d2).Days;
                lbld55.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr56.Text.Trim()))
            {
                lblr56.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl56.Text);
                int days = (d1 - d2).Days;
                lbld56.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr56.Text);
                DateTime d2 = Convert.ToDateTime(lbl56.Text);
                int days = (d1 - d2).Days;
                lbld56.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr57.Text.Trim()))
            {
                lblr57.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl57.Text);
                int days = (d1 - d2).Days;
                lbld57.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr57.Text);
                DateTime d2 = Convert.ToDateTime(lbl57.Text);
                int days = (d1 - d2).Days;
                lbld57.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr58.Text.Trim()))
            {
                lblr58.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl58.Text);
                int days = (d1 - d2).Days;
                lbld58.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr58.Text);
                DateTime d2 = Convert.ToDateTime(lbl58.Text);
                int days = (d1 - d2).Days;
                lbld58.Text = days.ToString();
            }
            if (string.IsNullOrEmpty(lblr59.Text.Trim()))
            {
                lblr59.Text = "Not Ok";
                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(lbl59.Text);
                int days = (d1 - d2).Days;
                lbld59.Text = days.ToString();
            }
            else
            {
                DateTime d1 = DateTime.Parse(lblr59.Text);
                DateTime d2 = Convert.ToDateTime(lbl59.Text);
                int days = (d1 - d2).Days;
                lbld59.Text = days.ToString();
            }

            // gridview cell hover//
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";

            if (!string.IsNullOrEmpty(lbl1.Text))
            {
                DateTime dt = DateTime.Parse(lbl1.Text);

                if (lblr1.Text.ToString() != "Not Ok")
                {
                    lbl1.BackColor = System.Drawing.Color.Empty;
                    lbl1.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl1.BackColor = System.Drawing.Color.Yellow;
                        lbl1.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl1.BackColor = System.Drawing.Color.Red;
                        lbl1.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl2.Text))
            {
                DateTime dt = DateTime.Parse(lbl2.Text);
                if (lblr2.Text.ToString() != "Not Ok")
                {
                    lbl2.BackColor = System.Drawing.Color.Empty;
                    lbl2.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl2.BackColor = System.Drawing.Color.Yellow;
                        lbl2.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl2.BackColor = System.Drawing.Color.Red;
                        lbl2.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl3.Text))
            {
                DateTime dt = DateTime.Parse(lbl3.Text);
                if (lblr3.Text.ToString() != "Not Ok")
                {
                    lbl3.BackColor = System.Drawing.Color.Empty;
                    lbl3.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl3.BackColor = System.Drawing.Color.Yellow;
                        lbl3.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl3.BackColor = System.Drawing.Color.Red;
                        lbl3.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl4.Text))
            {
                DateTime dt = DateTime.Parse(lbl4.Text);
                if (lblr4.Text.ToString() != "Not Ok")
                {
                    lbl4.BackColor = System.Drawing.Color.Empty;
                    lbl4.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl4.BackColor = System.Drawing.Color.Yellow;
                        lbl4.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl4.BackColor = System.Drawing.Color.Red;
                        lbl4.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl5.Text))
            {
                DateTime dt = DateTime.Parse(lbl5.Text);
                if (lblr5.Text.ToString() != "Not Ok")
                {
                    lbl5.BackColor = System.Drawing.Color.Empty;
                    lbl5.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl5.BackColor = System.Drawing.Color.Yellow;
                        lbl5.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl5.BackColor = System.Drawing.Color.Red;
                        lbl5.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl4.Text))
            {
                DateTime dt = DateTime.Parse(lbl6.Text);
                if (lblr6.Text.ToString() != "Not Ok")
                {
                    lbl6.BackColor = System.Drawing.Color.Empty;
                    lbl6.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl6.BackColor = System.Drawing.Color.Yellow;
                        lbl6.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl6.BackColor = System.Drawing.Color.Red;
                        lbl6.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl7.Text))
            {
                DateTime dt = DateTime.Parse(lbl7.Text);
                if (lblr7.Text.ToString() != "Not Ok")
                {
                    lbl7.BackColor = System.Drawing.Color.Empty;
                    lbl7.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl7.BackColor = System.Drawing.Color.Yellow;
                        lbl7.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl7.BackColor = System.Drawing.Color.Red;
                        lbl7.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl8.Text))
            {
                DateTime dt = DateTime.Parse(lbl8.Text);
                if (lblr8.Text.ToString() != "Not Ok")
                {
                    lbl8.BackColor = System.Drawing.Color.Empty;
                    lbl8.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl8.BackColor = System.Drawing.Color.Yellow;
                        lbl8.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl8.BackColor = System.Drawing.Color.Red;
                        lbl8.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl9.Text))
            {
                DateTime dt = DateTime.Parse(lbl9.Text);
                if (lblr9.Text.ToString() != "Not Ok")
                {
                    lbl9.BackColor = System.Drawing.Color.Empty;
                    lbl9.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl9.BackColor = System.Drawing.Color.Yellow;
                        lbl9.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl9.BackColor = System.Drawing.Color.Red;
                        lbl9.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl10.Text))
            {
                DateTime dt = DateTime.Parse(lbl10.Text);
                if (lblr10.Text.ToString() != "Not Ok")
                {
                    lbl10.BackColor = System.Drawing.Color.Empty;
                    lbl10.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl10.BackColor = System.Drawing.Color.Yellow;
                        lbl10.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl10.BackColor = System.Drawing.Color.Red;
                        lbl10.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl11.Text))
            {
                DateTime dt = DateTime.Parse(lbl11.Text);
                if (lblr11.Text.ToString() != "Not Ok")
                {
                    lbl11.BackColor = System.Drawing.Color.Empty;
                    lbl11.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl11.BackColor = System.Drawing.Color.Yellow;
                        lbl11.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl11.BackColor = System.Drawing.Color.Red;
                        lbl11.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl12.Text))
            {
                DateTime dt = DateTime.Parse(lbl12.Text);
                if (lblr12.Text.ToString() != "Not Ok")
                {
                    lbl12.BackColor = System.Drawing.Color.Empty;
                    lbl12.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl12.BackColor = System.Drawing.Color.Yellow;
                        lbl12.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl12.BackColor = System.Drawing.Color.Red;
                        lbl12.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl13.Text))
            {
                DateTime dt = DateTime.Parse(lbl13.Text);
                if (lblr13.Text.ToString() != "Not Ok")
                {
                    lbl13.BackColor = System.Drawing.Color.Empty;
                    lbl13.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl13.BackColor = System.Drawing.Color.Yellow;
                        lbl13.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl13.BackColor = System.Drawing.Color.Red;
                        lbl13.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl14.Text))
            {
                DateTime dt = DateTime.Parse(lbl14.Text);
                if (lblr14.Text.ToString() != "Not Ok")
                {
                    lbl14.BackColor = System.Drawing.Color.Empty;
                    lbl14.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl14.BackColor = System.Drawing.Color.Yellow;
                        lbl14.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl14.BackColor = System.Drawing.Color.Red;
                        lbl14.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl15.Text))
            {
                DateTime dt = DateTime.Parse(lbl15.Text);
                if (lblr15.Text.ToString() != "Not Ok")
                {
                    lbl15.BackColor = System.Drawing.Color.Empty;
                    lbl15.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl15.BackColor = System.Drawing.Color.Yellow;
                        lbl15.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl15.BackColor = System.Drawing.Color.Red;
                        lbl15.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl16.Text))
            {
                DateTime dt = DateTime.Parse(lbl16.Text);
                if (lblr16.Text.ToString() != "Not Ok")
                {
                    lbl16.BackColor = System.Drawing.Color.Empty;
                    lbl16.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl16.BackColor = System.Drawing.Color.Yellow;
                        lbl16.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl16.BackColor = System.Drawing.Color.Red;
                        lbl16.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl17.Text))
            {
                DateTime dt = DateTime.Parse(lbl17.Text);
                if (lblr17.Text.ToString() != "Not Ok")
                {
                    lbl17.BackColor = System.Drawing.Color.Empty;
                    lbl17.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl17.BackColor = System.Drawing.Color.Yellow;
                        lbl17.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl17.BackColor = System.Drawing.Color.Red;
                        lbl17.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl18.Text))
            {
                DateTime dt = DateTime.Parse(lbl18.Text);
                if (lblr18.Text.ToString() != "Not Ok")
                {
                    lbl18.BackColor = System.Drawing.Color.Empty;
                    lbl18.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl18.BackColor = System.Drawing.Color.Yellow;
                        lbl18.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl18.BackColor = System.Drawing.Color.Red;
                        lbl18.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl19.Text))
            {
                DateTime dt = DateTime.Parse(lbl19.Text);
                if (lblr19.Text.ToString() != "Not Ok")
                {
                    lbl19.BackColor = System.Drawing.Color.Empty;
                    lbl19.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl19.BackColor = System.Drawing.Color.Yellow;
                        lbl19.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl19.BackColor = System.Drawing.Color.Red;
                        lbl19.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl20.Text))
            {
                DateTime dt = DateTime.Parse(lbl20.Text);
                if (lblr20.Text.ToString() != "Not Ok")
                {
                    lbl20.BackColor = System.Drawing.Color.Empty;
                    lbl20.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl20.BackColor = System.Drawing.Color.Yellow;
                        lbl20.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl20.BackColor = System.Drawing.Color.Red;
                        lbl20.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //Yarn
            if (!string.IsNullOrEmpty(lbl21.Text))
            {
                DateTime dt = DateTime.Parse(lbl21.Text);
                if (lblr21.Text.ToString() != "Not Ok")
                {
                    lbl21.BackColor = System.Drawing.Color.Empty;
                    lbl21.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl21.BackColor = System.Drawing.Color.Yellow;
                        lbl21.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl21.BackColor = System.Drawing.Color.Red;
                        lbl21.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl22.Text))
            {
                DateTime dt = DateTime.Parse(lbl22.Text);
                if (lblr22.Text.ToString() != "Not Ok")
                {
                    lbl22.BackColor = System.Drawing.Color.Empty;
                    lbl22.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl22.BackColor = System.Drawing.Color.Yellow;
                        lbl22.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl22.BackColor = System.Drawing.Color.Red;
                        lbl22.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl23.Text))
            {
                DateTime dt = DateTime.Parse(lbl23.Text);
                if (lblr23.Text.ToString() != "Not Ok")
                {
                    lbl23.BackColor = System.Drawing.Color.Empty;
                    lbl23.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl23.BackColor = System.Drawing.Color.Yellow;
                        lbl23.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl23.BackColor = System.Drawing.Color.Red;
                        lbl23.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl24.Text))
            {
                DateTime dt = DateTime.Parse(lbl24.Text);
                if (lblr24.Text.ToString() != "Not Ok")
                {
                    lbl24.BackColor = System.Drawing.Color.Empty;
                    lbl24.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl24.BackColor = System.Drawing.Color.Yellow;
                        lbl24.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl24.BackColor = System.Drawing.Color.Red;
                        lbl24.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //YarnD
            if (!string.IsNullOrEmpty(lbl25.Text))
            {
                DateTime dt = DateTime.Parse(lbl25.Text);
                if (lblr25.Text.ToString() != "Not Ok")
                {
                    lbl25.BackColor = System.Drawing.Color.Empty;
                    lbl25.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl25.BackColor = System.Drawing.Color.Yellow;
                        lbl25.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl25.BackColor = System.Drawing.Color.Red;
                        lbl25.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl26.Text))
            {
                DateTime dt = DateTime.Parse(lbl26.Text);
                if (lblr26.Text.ToString() != "Not Ok")
                {
                    lbl26.BackColor = System.Drawing.Color.Empty;
                    lbl26.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl26.BackColor = System.Drawing.Color.Yellow;
                        lbl26.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl26.BackColor = System.Drawing.Color.Red;
                        lbl26.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //Knitting
            if (!string.IsNullOrEmpty(lbl27.Text))
            {
                DateTime dt = DateTime.Parse(lbl27.Text);
                if (lblr27.Text.ToString() != "Not Ok")
                {
                    lbl27.BackColor = System.Drawing.Color.Empty;
                    lbl27.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl27.BackColor = System.Drawing.Color.Yellow;
                        lbl27.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl27.BackColor = System.Drawing.Color.Red;
                        lbl27.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl28.Text))
            {
                DateTime dt = DateTime.Parse(lbl28.Text);
                if (lblr28.Text.ToString() != "Not Ok")
                {
                    lbl28.BackColor = System.Drawing.Color.Empty;
                    lbl28.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl28.BackColor = System.Drawing.Color.Yellow;
                        lbl28.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl28.BackColor = System.Drawing.Color.Red;
                        lbl28.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //Dyeing
            if (!string.IsNullOrEmpty(lbl29.Text))
            {
                DateTime dt = DateTime.Parse(lbl29.Text);
                if (lblr29.Text.ToString() != "Not Ok")
                {
                    lbl29.BackColor = System.Drawing.Color.Empty;
                    lbl29.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl29.BackColor = System.Drawing.Color.Yellow;
                        lbl29.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl29.BackColor = System.Drawing.Color.Red;
                        lbl29.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl30.Text))
            {
                DateTime dt = DateTime.Parse(lbl30.Text);
                if (lblr30.Text.ToString() != "Not Ok")
                {
                    lbl30.BackColor = System.Drawing.Color.Empty;
                    lbl30.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl30.BackColor = System.Drawing.Color.Yellow;
                        lbl30.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl30.BackColor = System.Drawing.Color.Red;
                        lbl30.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //AOP
            if (!string.IsNullOrEmpty(lbl31.Text))
            {
                DateTime dt = DateTime.Parse(lbl31.Text);
                if (lblr31.Text.ToString() != "Not Ok")
                {
                    lbl31.BackColor = System.Drawing.Color.Empty;
                    lbl31.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl31.BackColor = System.Drawing.Color.Yellow;
                        lbl31.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl31.BackColor = System.Drawing.Color.Red;
                        lbl31.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl32.Text))
            {
                DateTime dt = DateTime.Parse(lbl32.Text);
                if (lblr32.Text.ToString() != "Not Ok")
                {
                    lbl32.BackColor = System.Drawing.Color.Empty;
                    lbl32.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl32.BackColor = System.Drawing.Color.Yellow;
                        lbl32.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl32.BackColor = System.Drawing.Color.Red;
                        lbl32.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //Acc
            if (!string.IsNullOrEmpty(lbl33.Text))
            {
                DateTime dt = DateTime.Parse(lbl33.Text);
                if (lblr33.Text.ToString() != "Not Ok")
                {
                    lbl33.BackColor = System.Drawing.Color.Empty;
                    lbl33.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl33.BackColor = System.Drawing.Color.Yellow;
                        lbl33.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl33.BackColor = System.Drawing.Color.Red;
                        lbl33.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl34.Text))
            {
                DateTime dt = DateTime.Parse(lbl34.Text);
                if (lblr34.Text.ToString() != "Not Ok")
                {
                    lbl34.BackColor = System.Drawing.Color.Empty;
                    lbl34.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl34.BackColor = System.Drawing.Color.Yellow;
                        lbl34.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl34.BackColor = System.Drawing.Color.Red;
                        lbl34.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //Inv
            if (!string.IsNullOrEmpty(lbl35.Text))
            {
                DateTime dt = DateTime.Parse(lbl35.Text);
                if (lblr35.Text.ToString() != "Not Ok")
                {
                    lbl35.BackColor = System.Drawing.Color.Empty;
                    lbl35.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl35.BackColor = System.Drawing.Color.Yellow;
                        lbl35.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl35.BackColor = System.Drawing.Color.Red;
                        lbl35.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl36.Text))
            {
                DateTime dt = DateTime.Parse(lbl36.Text);
                if (lblr36.Text.ToString() != "Not Ok")
                {
                    lbl36.BackColor = System.Drawing.Color.Empty;
                    lbl36.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl36.BackColor = System.Drawing.Color.Yellow;
                        lbl36.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl36.BackColor = System.Drawing.Color.Red;
                        lbl36.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl37.Text))
            {
                DateTime dt = DateTime.Parse(lbl37.Text);
                if (lblr37.Text.ToString() != "Not Ok")
                {
                    lbl37.BackColor = System.Drawing.Color.Empty;
                    lbl37.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl37.BackColor = System.Drawing.Color.Yellow;
                        lbl37.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl37.BackColor = System.Drawing.Color.Red;
                        lbl37.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl38.Text))
            {
                DateTime dt = DateTime.Parse(lbl38.Text);
                if (lblr38.Text.ToString() != "Not Ok")
                {
                    lbl38.BackColor = System.Drawing.Color.Empty;
                    lbl38.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl38.BackColor = System.Drawing.Color.Yellow;
                        lbl38.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl38.BackColor = System.Drawing.Color.Red;
                        lbl38.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //prnt
            if (!string.IsNullOrEmpty(lbl39.Text))
            {
                DateTime dt = DateTime.Parse(lbl39.Text);
                if (lblr39.Text.ToString() != "Not Ok")
                {
                    lbl39.BackColor = System.Drawing.Color.Empty;
                    lbl39.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl39.BackColor = System.Drawing.Color.Yellow;
                        lbl39.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl39.BackColor = System.Drawing.Color.Red;
                        lbl39.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl40.Text))
            {
                DateTime dt = DateTime.Parse(lbl40.Text);
                if (lblr40.Text.ToString() != "Not Ok")
                {
                    lbl40.BackColor = System.Drawing.Color.Empty;
                    lbl40.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl40.BackColor = System.Drawing.Color.Yellow;
                        lbl40.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl40.BackColor = System.Drawing.Color.Red;
                        lbl40.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //Emb
            if (!string.IsNullOrEmpty(lbl41.Text))
            {
                DateTime dt = DateTime.Parse(lbl41.Text);
                if (lblr41.Text.ToString() != "Not Ok")
                {
                    lbl41.BackColor = System.Drawing.Color.Empty;
                    lbl41.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl41.BackColor = System.Drawing.Color.Yellow;
                        lbl41.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl41.BackColor = System.Drawing.Color.Red;
                        lbl41.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl42.Text))
            {
                DateTime dt = DateTime.Parse(lbl42.Text);
                if (lblr42.Text.ToString() != "Not Ok")
                {
                    lbl42.BackColor = System.Drawing.Color.Empty;
                    lbl42.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl42.BackColor = System.Drawing.Color.Yellow;
                        lbl42.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl42.BackColor = System.Drawing.Color.Red;
                        lbl42.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            //RMG
            if (!string.IsNullOrEmpty(lbl43.Text))
            {
                DateTime dt = DateTime.Parse(lbl43.Text);
                if (lblr43.Text.ToString() != "Not Ok")
                {
                    lbl43.BackColor = System.Drawing.Color.Empty;
                    lbl43.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl43.BackColor = System.Drawing.Color.Yellow;
                        lbl43.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl43.BackColor = System.Drawing.Color.Red;
                        lbl43.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl44.Text))
            {
                DateTime dt = DateTime.Parse(lbl44.Text);
                if (lblr44.Text.ToString() != "Not Ok")
                {
                    lbl44.BackColor = System.Drawing.Color.Empty;
                    lbl44.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl44.BackColor = System.Drawing.Color.Yellow;
                        lbl44.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl44.BackColor = System.Drawing.Color.Red;
                        lbl44.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl45.Text))
            {
                DateTime dt = DateTime.Parse(lbl45.Text);
                if (lblr45.Text.ToString() != "Not Ok")
                {
                    lbl45.BackColor = System.Drawing.Color.Empty;
                    lbl45.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl45.BackColor = System.Drawing.Color.Yellow;
                        lbl45.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl45.BackColor = System.Drawing.Color.Red;
                        lbl45.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl46.Text))
            {
                DateTime dt = DateTime.Parse(lbl46.Text);
                if (lblr46.Text.ToString() != "Not Ok")
                {
                    lbl46.BackColor = System.Drawing.Color.Empty;
                    lbl46.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl46.BackColor = System.Drawing.Color.Yellow;
                        lbl46.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl46.BackColor = System.Drawing.Color.Red;
                        lbl46.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl47.Text))
            {
                DateTime dt = DateTime.Parse(lbl47.Text);
                if (lblr47.Text.ToString() != "Not Ok")
                {
                    lbl47.BackColor = System.Drawing.Color.Empty;
                    lbl47.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl47.BackColor = System.Drawing.Color.Yellow;
                        lbl47.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl47.BackColor = System.Drawing.Color.Red;
                        lbl47.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl48.Text))
            {
                DateTime dt = DateTime.Parse(lbl48.Text);
                if (lblr48.Text.ToString() != "Not Ok")
                {
                    lbl48.BackColor = System.Drawing.Color.Empty;
                    lbl48.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl48.BackColor = System.Drawing.Color.Yellow;
                        lbl48.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl48.BackColor = System.Drawing.Color.Red;
                        lbl8.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl49.Text))
            {
                DateTime dt = DateTime.Parse(lbl49.Text);
                if (lblr49.Text.ToString() != "Not Ok")
                {
                    lbl49.BackColor = System.Drawing.Color.Empty;
                    lbl49.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl49.BackColor = System.Drawing.Color.Yellow;
                        lbl49.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl49.BackColor = System.Drawing.Color.Red;
                        lbl49.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl50.Text))
            {
                DateTime dt = DateTime.Parse(lbl50.Text);
                if (lblr50.Text.ToString() != "Not Ok")
                {
                    lbl50.BackColor = System.Drawing.Color.Empty;
                    lbl50.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl50.BackColor = System.Drawing.Color.Yellow;
                        lbl50.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl50.BackColor = System.Drawing.Color.Red;
                        lbl50.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl51.Text))
            {
                DateTime dt = DateTime.Parse(lbl51.Text);
                if (lblr51.Text.ToString() != "Not Ok")
                {
                    lbl51.BackColor = System.Drawing.Color.Empty;
                    lbl51.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl51.BackColor = System.Drawing.Color.Yellow;
                        lbl51.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl51.BackColor = System.Drawing.Color.Red;
                        lbl51.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl52.Text))
            {
                DateTime dt = DateTime.Parse(lbl52.Text);
                if (lblr52.Text.ToString() != "Not Ok")
                {
                    lbl52.BackColor = System.Drawing.Color.Empty;
                    lbl52.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl52.BackColor = System.Drawing.Color.Yellow;
                        lbl52.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl52.BackColor = System.Drawing.Color.Red;
                        lbl52.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl53.Text))
            {
                DateTime dt = DateTime.Parse(lbl53.Text);
                if (lblr53.Text.ToString() != "Not Ok")
                {
                    lbl53.BackColor = System.Drawing.Color.Empty;
                    lbl53.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl53.BackColor = System.Drawing.Color.Yellow;
                        lbl53.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl53.BackColor = System.Drawing.Color.Red;
                        lbl53.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl54.Text))
            {
                DateTime dt = DateTime.Parse(lbl54.Text);
                if (lblr54.Text.ToString() != "Not Ok")
                {
                    lbl54.BackColor = System.Drawing.Color.Empty;
                    lbl54.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl54.BackColor = System.Drawing.Color.Yellow;
                        lbl54.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl54.BackColor = System.Drawing.Color.Red;
                        lbl54.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl55.Text))
            {
                DateTime dt = DateTime.Parse(lbl55.Text);
                if (lblr55.Text.ToString() != "Not Ok")
                {
                    lbl55.BackColor = System.Drawing.Color.Empty;
                    lbl55.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl55.BackColor = System.Drawing.Color.Yellow;
                        lbl55.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl55.BackColor = System.Drawing.Color.Red;
                        lbl55.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl56.Text))
            {
                DateTime dt = DateTime.Parse(lbl56.Text);
                if (lblr56.Text.ToString() != "Not Ok")
                {
                    lbl56.BackColor = System.Drawing.Color.Empty;
                    lbl56.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl56.BackColor = System.Drawing.Color.Yellow;
                        lbl56.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl56.BackColor = System.Drawing.Color.Red;
                        lbl56.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl57.Text))
            {
                DateTime dt = DateTime.Parse(lbl57.Text);
                if (lblr57.Text.ToString() != "Not Ok")
                {
                    lbl57.BackColor = System.Drawing.Color.Empty;
                    lbl57.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl57.BackColor = System.Drawing.Color.Yellow;
                        lbl57.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl57.BackColor = System.Drawing.Color.Red;
                        lbl57.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl58.Text))
            {
                DateTime dt = DateTime.Parse(lbl58.Text);
                if (lblr58.Text.ToString() != "Not Ok")
                {
                    lbl58.BackColor = System.Drawing.Color.Empty;
                    lbl58.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl58.BackColor = System.Drawing.Color.Yellow;
                        lbl58.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl58.BackColor = System.Drawing.Color.Red;
                        lbl58.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lbl59.Text))
            {
                DateTime dt = DateTime.Parse(lbl59.Text);
                if (lblr59.Text.ToString() != "Not Ok")
                {
                    lbl59.BackColor = System.Drawing.Color.Empty;
                    lbl59.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (dt.AddDays(-6) <= DateTime.Now)
                    {
                        lbl59.BackColor = System.Drawing.Color.Yellow;
                        lbl59.ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt <= DateTime.Now)
                    {
                        lbl59.BackColor = System.Drawing.Color.Red;
                        lbl59.ForeColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
        }
    }

}