using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

public partial class Page9 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("LogIn.aspx", false);
            return;
        }

        SqlCommand command = new SqlCommand("SELECT Username FROM [View_FormNameByUser] WHERE Username = '" + Session["Username"] + "' and (UsrDpt='6' OR UsrGroup='1') and frmnam6 = 'Page31.aspx' ", conn);
        command.Connection.Open();
        SqlDataReader rdr = command.ExecuteReader();

        if (rdr.HasRows)
        {

        }
        else
        {

            Response.Redirect("~/page2.aspx");
        }

        conn.Close();

        if (!IsPostBack)
        {

            Bindddlusername();

            //this.div1.Visible = false;
            this.Tab1.Visible = false;
            BindddTnacategory();



            {

                ddlbuyer.AppendDataBoundItems = true;

                String strQuery = "Select DISTINCT byr_id, byr_nm FROM View_FormNameByUser WHERE Username = '" + Session["Username"] + "' and UsrTyp= byr_id ";
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

        }




    }

    private void BindddTnacategory()
    {
        ddTnacategory.Items.Clear();
        ddTnacategory.Items.Add(new ListItem("-", ""));
        ddTnacategory.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery = "select DISTINCT Tna_typ_ID, Tna_typ_Nm FROM Tbl_Tna_Category ";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            ddTnacategory.DataSource = cmd.ExecuteReader();
            ddTnacategory.DataTextField = "Tna_typ_Nm";
            ddTnacategory.DataValueField = "Tna_typ_ID";
            ddTnacategory.DataBind();
            if (ddTnacategory.Items.Count > 1)
            {
                ddTnacategory.Enabled = true;
            }
            else
            {


                ddTnacategory.Enabled = false;
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



    protected void ddlbuyer_SelectedIndexChanged(object sender, EventArgs e)
    {


        ddlStyle.Items.Clear();
        ddlStyle.Items.Add(new ListItem("-", ""));
        ddlStyle.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery1 = "select  DISTINCT ord_no FROM Order_Master where ord_buyer='" + ddlbuyer.SelectedItem.Value + "' ";
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



    //protected void ddTnacategory_SelectedIndexChanged(object sender, EventArgs e)
    //{


    //}


    private void Bindddlusername()
    {

        ddlusername.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select UserId,Username FROM Users order by Username ASC", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlusername.DataSource = ds;
        ddlusername.DataTextField = "Username";
        ddlusername.DataValueField = "UserId";
        ddlusername.DataBind();

        conn.Close();



    }

    //DrropDown Selection//


    private void Fdata()
    {

        string queryString = "SELECT ord_cnfdate,po_xfactory,po_led,po_bpsd,TnaCreateDate  FROM PO_Master where po_id=@po_id ";
        SqlCommand Syscmd = new SqlCommand(queryString, conn);
        Syscmd.Parameters.AddWithValue("po_id", DropDownpo.SelectedItem.Value);

        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet data = new DataSet();
        da.Fill(data);
        //To add code here that populates labels....
        txtocd.Text = Convert.ToDateTime(data.Tables[0].Rows[0]["ord_cnfdate"]).ToString("MM/dd/yyyy");
        txtxftd.Text = Convert.ToDateTime(data.Tables[0].Rows[0]["po_xfactory"]).ToString("MM/dd/yyyy");
        newxfactory.Text = Convert.ToDateTime(data.Tables[0].Rows[0]["po_xfactory"]).ToString("MM/dd/yyyy");
        txtled.Text = data.Tables[0].Rows[0]["po_led"].ToString();
        txtbpsd.Text = Convert.ToDateTime(data.Tables[0].Rows[0]["po_bpsd"]).ToString("MM/dd/yyyy");
        tsxtcrDate.Text = Convert.ToDateTime(data.Tables[0].Rows[0]["TnaCreateDate"]).ToString("MM/dd/yyyy");


    }

    //select change Style and Po
    protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownpo.Items.Clear();
        DropDownpo.Items.Add(new ListItem("-", ""));
        DropDownpo.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);

        String strQuery = "select DISTINCT po_id,po_no FROM PO_Master where ord_no='" + ddlStyle.SelectedItem.Text + "'AND ActiveOrder='1' AND(TnAapproved is NOT NULL OR TnaCancle is NOT NULL) ";
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

    //Call DropDown SelectedIndexChanged//

    protected void DropDownpo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FetchProductData();
        Fdata();

    }

    //Button for Genarete Date//
    protected void btnGenarate_Click(object sender, EventArgs e)
    {


        this.div1.Visible = true;
        this.Tab1.Visible = true;
        this.lblpl1.Enabled = false;
        this.lblpl2.Enabled = false;
        this.lblpl3.Enabled = false;
        this.lblpl4.Enabled = false;
        this.lblpl5.Enabled = false;
        this.lblpl6.Enabled = false;
        this.lblpl7.Enabled = false;
        this.lblpl8.Enabled = false;
        this.lblpl9.Enabled = false;
        this.lblpl10.Enabled = false;
        this.lblpl11.Enabled = false;
        this.lblpl12.Enabled = false;
        this.lblpl13.Enabled = false;
        this.lblpl14.Enabled = false;
        this.lblpl15.Enabled = false;
        this.lblpl16.Enabled = false;
        this.lblpl17.Enabled = false;
        this.lblpl18.Enabled = false;
        this.lblpl19.Enabled = false;
        this.lblpl20.Enabled = false;
        this.lblpl21.Enabled = false;

        this.lblpl22.Enabled = false;
        this.lblpl23.Enabled = false;
        this.lblpl24.Enabled = false;
        this.lblpl25.Enabled = false;
        this.lblpl26.Enabled = false;
        this.lblpl27.Enabled = false;
        this.lblpl28.Enabled = false;
        this.lblpl29.Enabled = false;
        this.lblpl30.Enabled = false;
        this.lblpl31.Enabled = false;

        this.lblpl32.Enabled = false;
        this.lblpl33.Enabled = false;
        this.lblpl34.Enabled = false;
        this.lblpl35.Enabled = false;
        this.lblpl36.Enabled = false;
        this.lblpl37.Enabled = false;
        this.lblpl38.Enabled = false;
        this.lblpl39.Enabled = false;
        this.lblpl40.Enabled = false;

        this.lblpl41.Enabled = false;
        this.lblpl42.Enabled = false;
        this.lblpl43.Enabled = false;
        this.lblpl44.Enabled = false;
        this.lblpl45.Enabled = false;
        this.lblpl46.Enabled = false;
        this.lblpl47.Enabled = false;
        this.lblpl48.Enabled = false;
        this.lblpl49.Enabled = false;
        this.lblpl50.Enabled = false;

        this.lblpl51.Enabled = false;
        this.lblpl52.Enabled = false;
        this.lblpl53.Enabled = false;
        this.lblpl54.Enabled = false;
        this.lblpl55.Enabled = false;
        this.lblpl56.Enabled = false;
        this.lblpl57.Enabled = false;
        this.lblpl58.Enabled = false;
        this.lblpl59.Enabled = false;

        this.imgPopup1.Visible = false;
        this.imgPopup1.Visible = false;
        this.imgPopup2.Visible = false;
        this.imgPopup3.Visible = false;
        this.imgPopup4.Visible = false;
        this.imgPopup5.Visible = false;
        this.imgPopup6.Visible = false;
        this.imgPopup7.Visible = false;
        this.imgPopup8.Visible = false;
        this.imgPopup9.Visible = false;
        this.imgPopup10.Visible = false;
        this.imgPopup11.Visible = false;
        this.imgPopup12.Visible = false;
        this.imgPopup13.Visible = false;
        this.imgPopup14.Visible = false;
        this.imgPopup15.Visible = false;
        this.imgPopup16.Visible = false;
        this.imgPopup17.Visible = false;
        this.imgPopup18.Visible = false;
        this.imgPopup19.Visible = false;
        this.imgPopup20.Visible = false;

        //if (ddTnacategory.SelectedItem.Value.ToString() == txtled.Text.ToString())

        string strSelectCmd = "select * from Buyer_Templt_View where Tmplt_Byr ='" + ddlbuyer.SelectedItem.Value + "' ";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        #region "Merchndising"

        DateTime x = DateTime.Parse(txtbpsd.Text);// best posible cut date
        DateTime s = DateTime.Parse(txtocd.Text);// order confirm date
        TimeSpan ts = x - s;

        lblpcd.Text = ts.TotalDays.ToString(); //merchant led time
        Double v1 = Double.Parse(lblpcd.Text);
        Double v2 = Double.Parse(txtled.Text);
        Double tm = v2 - v1;
        SewLed.Text = tm.ToString();

        // Labdip Submit 
        lbl1.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt1"].ToString();
        lblg1.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay1"].ToString();
        Double d1 = Double.Parse(lblg1.Text);
        Double dt1 = (v1 * d1) / 45;
        lblpl1.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt1).ToShortDateString(); //labdip submit

        //labdip Approval
        lbl2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt2"].ToString();
        lblg2.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay2"].ToString();
        Double d2 = Double.Parse(lblg2.Text);
        lblpl2.Text = DateTime.Parse(lblpl1.Text).AddDays(d2).ToShortDateString();//labdip app

        //Accessories Bokking
        lbl3.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt3"].ToString();
        lblg3.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay3"].ToString();
        Double d3 = Double.Parse(lblg3.Text);
        Double dt3 = (v1 * d3) / 45;
        lblpl3.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt3).ToShortDateString();//accessories booking

        //Fabric Booking 
        lbl4.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt4"].ToString();
        lblg4.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay4"].ToString();
        Double d4 = Double.Parse(lblg4.Text);
        Double dt4 = (v1 * d4) / 45;
        lblpl4.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt4).ToShortDateString();//fabric booking

        //yarn booking
        lbl5.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt5"].ToString();
        lblg5.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay5"].ToString();
        Double d5 = Double.Parse(lblg5.Text);
        Double dt5 = (v1 * d5) / 45;
        lblpl5.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt5).ToShortDateString();//yarn booking


        //Calculated From BPCD

        lbl6.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt6"].ToString();
        lblg6.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay6"].ToString();
        Double d6 = Double.Parse(lblg6.Text);
        Double dt6 = (v1 * d6) / 45;
        lblpl6.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt6).ToShortDateString();//1


        lbl7.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt7"].ToString();
        lblg7.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay7"].ToString();
        Double d7 = Double.Parse(lblg7.Text);
        Double dt7 = (v1 * d7) / 45;
        lblpl7.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt7).ToShortDateString();//2

        lbl8.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt8"].ToString();
        lblg8.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay8"].ToString();
        Double d8 = Double.Parse(lblg8.Text);
        Double dt8 = (v1 * d8) / 45;
        lblpl8.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt8).ToShortDateString();//3

        lbl9.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt9"].ToString();
        lblg9.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay9"].ToString();
        Double d9 = Double.Parse(lblg9.Text);
        Double dt9 = (v1 * d9) / 45;
        lblpl9.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d9).ToShortDateString();//4

        lbl10.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt10"].ToString();
        lblg10.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay10"].ToString();
        Double d10 = Double.Parse(lblg10.Text);
        Double dt10 = (v1 * d10) / 45;
        lblpl10.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt10).ToShortDateString();//5

        lbl11.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt11"].ToString();
        lblg11.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay11"].ToString();
        Double d11 = Double.Parse(lblg11.Text);
        Double dt11 = (v1 * d11) / 45;
        lblpl11.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt11).ToShortDateString();//6

        lbl12.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt12"].ToString();
        lblg12.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay12"].ToString();
        Double d12 = Double.Parse(lblg12.Text);
        Double dt12 = (v1 * d12) / 45;
        lblpl12.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt12).ToShortDateString();//7

        lbl13.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt13"].ToString();
        lblg13.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay13"].ToString();
        Double d13 = Double.Parse(lblg13.Text);
        Double dt13 = (v1 * d13) / 45;
        lblpl13.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt13).ToShortDateString();//8

        lbl14.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt14"].ToString();
        lblg14.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay14"].ToString();
        Double d14 = Double.Parse(lblg14.Text);
        Double dt14 = (v1 * d14) / 45;
        lblpl14.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt14).ToShortDateString();//9

        lbl15.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt15"].ToString();
        lblg15.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay15"].ToString();
        Double d15 = Double.Parse(lblg15.Text);
        Double dt15 = (v1 * d15) / 45;
        lblpl15.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt15).ToShortDateString();//10

        lbl16.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt16"].ToString();
        lblg16.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay16"].ToString();
        Double d16 = Double.Parse(lblg16.Text);
        Double dt16 = (v1 * d16) / 45;
        lblpl16.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt16).ToShortDateString();//11

        lbl17.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt17"].ToString();
        lblg17.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay17"].ToString();
        Double d17 = Double.Parse(lblg17.Text);
        Double dt17 = (v1 * d17) / 45;
        lblpl17.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt17).ToShortDateString();//12

        lbl18.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt18"].ToString();
        lblg18.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay18"].ToString();
        Double d18 = Double.Parse(lblg18.Text);
        Double dt18 = (v1 * d18) / 45;
        lblpl18.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt18).ToShortDateString();//13

        lbl19.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt19"].ToString();
        lblg19.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay19"].ToString();
        Double d19 = Double.Parse(lblg19.Text);
        Double dt19 = (v1 * d19) / 45;
        lblpl19.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt19).ToShortDateString();//14


        lbl20.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt20"].ToString();
        lblg20.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay20"].ToString();
        Double d20 = Double.Parse(lblg20.Text);
        Double dt20 = (v1 * d20) / 45;
        lblpl20.Text = DateTime.Parse(txtbpsd.Text).AddDays(-dt20).ToShortDateString();//15

        #endregion

        #region "Yarn"
        //after yarn booking
        lbl21.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt21"].ToString();
        lblg21.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay21"].ToString();
        Double d21 = Double.Parse(lblg21.Text);
        Double dt21 = (v1 * d21) / 45;
        lblpl21.Text = DateTime.Parse(lblpl5.Text).AddDays(dt21).ToShortDateString();//Pi recv

        //after PI receive
        lbl22.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt22"].ToString();
        lblg22.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay22"].ToString();
        Double d22 = Double.Parse(lblg22.Text);
        Double dt22 = (v1 * d22) / 45;
        lblpl22.Text = DateTime.Parse(lblpl21.Text).AddDays(dt22).ToShortDateString();//BBlc Open

        //after BBlc 
        lbl23.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt23"].ToString();
        lblg23.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay23"].ToString();
        Double d23 = Double.Parse(lblg23.Text);
        Double dt23 = (v1 * d23) / 45;
        lblpl23.Text = DateTime.Parse(lblpl22.Text).AddDays(dt23).ToShortDateString();//Yarn Inhouse Strt

        //Yarn Inhouse End
        lbl24.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt24"].ToString();
        lblg24.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay24"].ToString();
        Double d24 = Double.Parse(lblg24.Text);
        Double dt24 = (v1 * d24) / 45;
        lblpl24.Text = DateTime.Parse(lblpl23.Text).AddDays(dt24).ToShortDateString();//Yarn inhouse End
        #endregion

        #region "Yarn Dye"
        //YD
        lbl56.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt56"].ToString();
        lblg56.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay56"].ToString();
        Double d56 = Double.Parse(lblg56.Text);
        Double dt56 = (v1 * d56) / 45;
        lblpl56.Text = DateTime.Parse(lblpl23.Text).AddDays(dt56).ToShortDateString();//Yarn Dye Srat

        lbl57.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt57"].ToString();
        lblg57.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay57"].ToString();
        Double d57 = Double.Parse(lblg57.Text);
        Double dt57 = (v1 * d57) / 45;
        lblpl57.Text = DateTime.Parse(lblpl56.Text).AddDays(dt57).ToShortDateString();//Yarn Dye End
        #endregion

        #region "Knitting"
        lbl25.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt25"].ToString();
        lblg25.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay25"].ToString();
        Double d25 = Double.Parse(lblg25.Text);
        Double dt25 = (v1 * d25) / 45;
        lblpl25.Text = DateTime.Parse(lblpl23.Text).AddDays(dt25).ToShortDateString();//Knitting Start

        lbl26.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt26"].ToString();
        lblg26.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay26"].ToString();
        Double d26 = Double.Parse(lblg26.Text);
        Double dt26 = (v1 * d26) / 45;
        lblpl26.Text = DateTime.Parse(lblpl25.Text).AddDays(dt26).ToShortDateString();//Knitting End
        #endregion

        #region "Dyeing"
        lbl27.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt27"].ToString();
        lblg27.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay27"].ToString();
        Double d27 = Double.Parse(lblg27.Text);
        Double dt27 = (v1 * d27) / 45;
        lblpl27.Text = DateTime.Parse(lblpl25.Text).AddDays(dt27).ToShortDateString();//Dyeing  Strt
        //Calculated from BPCD

        //Calculated from After BPCD
        lbl28.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt28"].ToString();
        lblg28.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay28"].ToString();
        Double d28 = Double.Parse(lblg28.Text);
        Double dt28 = (v1 * d28) / 45;
        lblpl28.Text = DateTime.Parse(lblpl27.Text).AddDays(dt28).ToShortDateString();//Dyeing End
        #endregion

        #region "AOP"

        //AOP
        lbl58.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt58"].ToString();
        lblg58.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay58"].ToString();
        Double d58 = Double.Parse(lblg58.Text);
        Double dt58 = (v1 * d58) / 45;
        lblpl58.Text = DateTime.Parse(lblpl27.Text).AddDays(dt58).ToShortDateString();  //AOP Strat

        lbl59.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt59"].ToString();
        lblg59.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay59"].ToString();
        Double d59 = Double.Parse(lblg59.Text);
        Double dt59 = (v1 * d59) / 45;
        lblpl59.Text = DateTime.Parse(lblpl58.Text).AddDays(dt59).ToShortDateString();  //AOP End
        #endregion

        #region "Accessories prod"
        //after Accessories booking
        lbl29.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt29"].ToString();
        lblg29.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay29"].ToString();
        Double d29 = Double.Parse(lblg29.Text);
        Double dt29 = (v1 * d29) / 45;
        lblpl29.Text = DateTime.Parse(lblpl3.Text).AddDays(dt29).ToShortDateString();//Accessories Prod Start

        //after BPCD
        lbl30.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt30"].ToString();
        lblg30.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay30"].ToString();
        Double d30 = Double.Parse(lblg30.Text);
        Double dt30 = (v1 * d30) / 45;
        lblpl30.Text = DateTime.Parse(txtbpsd.Text).AddDays(dt30).ToShortDateString();//Accessories Prod End
        #endregion

        #region "Inventory"

        //before BPCD
        lbl31.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt31"].ToString();
        lblg31.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay31"].ToString();
        Double d31 = Double.Parse(lblg31.Text);
        Double dt31 = (v1 * d31) / 45;
        lblpl31.Text = DateTime.Parse(lblpl29.Text).AddDays(dt31).ToShortDateString();//Sewing Trim Inhouse Start

        //after BPCD
        lbl32.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt32"].ToString();
        lblg32.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay32"].ToString();
        Double d32 = Double.Parse(lblg32.Text);
        Double dt32 = (v1 * d32) / 45;
        lblpl32.Text = DateTime.Parse(lblpl30.Text).AddDays(dt32).ToShortDateString();//Sewing Trim inhouse End

        //before BPCD
        lbl33.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt33"].ToString();
        lblg33.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay33"].ToString();
        Double d33 = Double.Parse(lblg33.Text);
        Double dt33 = (v1 * d33) / 45;
        lblpl33.Text = DateTime.Parse(lblpl31.Text).AddDays(dt33).ToShortDateString();//Finishing Trim Inhouse Start 

        //after BPCD
        lbl34.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt34"].ToString();
        lblg34.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay34"].ToString();
        Double d34 = Double.Parse(lblg34.Text);
        Double dt34 = (v1 * d34) / 45;
        lblpl34.Text = DateTime.Parse(lblpl30.Text).AddDays(dt34).ToShortDateString();//Finishing Trim inhouse Emd
        #endregion

        #region "RMG"
        lbl35.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt35"].ToString();
        lblg35.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay35"].ToString();
        Double d35 = Double.Parse(lblg35.Text);
        lblpl35.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d35).ToShortDateString();//PP /Trial cut

        //After BPCD
        lbl36.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt36"].ToString();
        lblg36.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay36"].ToString();
        Double d36 = Double.Parse(lblg36.Text);
        lblpl36.Text = DateTime.Parse(txtbpsd.Text).AddDays(d36).ToShortDateString();//bulk Ctutting Strt

        //Before Exfactory
        lbl37.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt37"].ToString();
        lblg37.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay37"].ToString();
        Double d37 = Double.Parse(lblg37.Text);
        Double dt37 = (v1 * d37) / 45;
        lblpl37.Text = DateTime.Parse(lblpl36.Text).AddDays(dt37).ToShortDateString();//bulk Ctutting end

        //PRINT
        //After BPCD
        lbl38.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt38"].ToString();
        lblg38.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay38"].ToString();
        Double d38 = Double.Parse(lblg38.Text);
        lblpl38.Text = DateTime.Parse(lblpl36.Text).AddDays(d38).ToShortDateString();//Print start

        //before exfactory
        lbl39.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt39"].ToString();
        lblg39.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay39"].ToString();
        Double d39 = Double.Parse(lblg39.Text);
        Double dt39 = (v1 * d39) / 45;
        lblpl39.Text = DateTime.Parse(lblpl37.Text).AddDays(dt39).ToShortDateString();//Print end

        //EMB
        //After BPCD
        lbl40.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt40"].ToString();
        lblg40.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay40"].ToString();
        Double d40 = Double.Parse(lblg40.Text);
        lblpl40.Text = DateTime.Parse(lblpl36.Text).AddDays(d40).ToShortDateString();//Emb Start

        //before exfactory
        lbl41.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt41"].ToString();
        lblg41.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay41"].ToString();
        Double d41 = Double.Parse(lblg41.Text);
        Double dt41 = (v1 * d41) / 45;
        lblpl41.Text = DateTime.Parse(lblpl37.Text).AddDays(dt41).ToShortDateString();//Emb end

        //After BPCD
        lbl42.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt42"].ToString();
        lblg42.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay42"].ToString();
        Double d42 = Double.Parse(lblg42.Text);
        Double dt42 = (v1 * d42) / 45;
        lblpl42.Text = DateTime.Parse(lblpl36.Text).AddDays(dt42).ToShortDateString();//Sewing Start

        //Before Exfactory
        lbl43.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt43"].ToString();
        lblg43.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay43"].ToString();
        Double d43 = Double.Parse(lblg43.Text);
        lblpl43.Text = DateTime.Parse(txtxftd.Text).AddDays(-d43).ToShortDateString();//Sewing end

        //After Sewing Start
        lbl44.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt44"].ToString();
        lblg44.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay44"].ToString();
        Double d44 = Double.Parse(lblg44.Text);
        Double dt44 = (v1 * d44) / 45;
        lblpl44.Text = DateTime.Parse(lblpl42.Text).AddDays(dt44).ToShortDateString();//Wash Start

        //before exfactory
        lbl45.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt45"].ToString();
        lblg45.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay45"].ToString();
        Double d45 = Double.Parse(lblg45.Text);
        Double dt45 = (v1 * d45) / 45;
        lblpl45.Text = DateTime.Parse(lblpl43.Text).AddDays(dt45).ToShortDateString();//Wash end

        lbl46.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt46"].ToString();
        lblg46.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay46"].ToString();
        Double d46 = Double.Parse(lblg46.Text);
        Double dt46 = (v1 * d46) / 45;
        lblpl46.Text = DateTime.Parse(txtxftd.Text).AddDays(-dt46).ToShortDateString();//1

        lbl47.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt47"].ToString();
        lblg47.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay47"].ToString();
        Double d47 = Double.Parse(lblg47.Text);
        Double dt47 = (v1 * d47) / 45;
        lblpl47.Text = DateTime.Parse(txtxftd.Text).AddDays(-dt47).ToShortDateString();//2

        lbl48.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt48"].ToString();
        lblg48.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay48"].ToString();
        Double d48 = Double.Parse(lblg48.Text);
        Double dt48 = (v1 * d48) / 45;
        lblpl48.Text = DateTime.Parse(txtxftd.Text).AddDays(-dt48).ToShortDateString();//3

        lbl49.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt49"].ToString();
        lblg49.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay49"].ToString();
        Double d49 = Double.Parse(lblg49.Text);
        Double dt49 = (v1 * d49) / 45;
        lblpl49.Text = DateTime.Parse(txtxftd.Text).AddDays(-dt49).ToShortDateString();//4

        lbl50.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt50"].ToString();
        lblg50.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay50"].ToString();
        Double d50 = Double.Parse(lblg50.Text);
        Double dt50 = (v1 * d50) / 45;
        lblpl50.Text = DateTime.Parse(txtxftd.Text).AddDays(-dt50).ToShortDateString();//5

        lbl51.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt51"].ToString();
        lblg51.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay51"].ToString();
        Double d51 = Double.Parse(lblg51.Text);
        Double dt51 = (v1 * d51) / 45;
        lblpl51.Text = DateTime.Parse(txtxftd.Text).AddDays(-dt51).ToShortDateString();//6

        //After Sewing Start
        lbl52.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt52"].ToString();
        lblg52.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay52"].ToString();
        Double d52 = Double.Parse(lblg52.Text);
        lblpl52.Text = DateTime.Parse(lblpl42.Text).AddDays(d52).ToShortDateString();//Fin Start

        //before exfactory
        lbl53.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt53"].ToString();
        lblg53.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay53"].ToString();
        Double d53 = Double.Parse(lblg53.Text);
        lblpl53.Text = DateTime.Parse(txtxftd.Text).AddDays(-d53).ToShortDateString();//Fin End

        //before exfactory
        lbl54.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt54"].ToString();
        lblg54.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay54"].ToString();
        Double d54 = Double.Parse(lblg54.Text);
        lblpl54.Text = DateTime.Parse(txtxftd.Text).AddDays(-d54).ToShortDateString();//Pre final

        //before exfactory
        lbl55.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt55"].ToString();
        lblg55.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay55"].ToString();
        Double d55 = Double.Parse(lblg55.Text);
        lblpl55.Text = DateTime.Parse(txtxftd.Text).AddDays(-d55).ToShortDateString();//Final Inspection
        #endregion


        //Double d3 = Double.Parse(txt6.Text);Expr4
        //lblpl4.Text = DateTime.Now.AddDays(d3).ToShortDateString();




    }




    protected void BtnTnARelod_Click(object sender, EventArgs e)
    {


        {

            int TnaID = 0;

            SqlConnection conn = new SqlConnection(DbConnect.x);
            using  (SqlConnection con = new SqlConnection(DbConnect.x))
            {
                using (SqlCommand Syscmd = new SqlCommand("SpTnaPlanReload"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        Syscmd.CommandType = CommandType.StoredProcedure;
                        Syscmd.Parameters.AddWithValue("TnaByrNm", ddlbuyer.SelectedValue);
                        Syscmd.Parameters.AddWithValue("TnaOrdNm", ddlStyle.SelectedValue);
                        Syscmd.Parameters.AddWithValue("TnaPoNm", DropDownpo.SelectedValue);
                        Syscmd.Parameters.AddWithValue("TnaBpcd", txtbpsd.Text.Trim());
                        Syscmd.Parameters.AddWithValue("TnaLedTm", txtled.Text.Trim());
                        Syscmd.Parameters.AddWithValue("TnaAcMangr", ddlusername.SelectedValue);
                        Syscmd.Parameters.AddWithValue("TnaCetegory", ddTnacategory.SelectedValue);
                        Syscmd.Parameters.AddWithValue("Tnapl1", lblpl1.Text.Trim()); //lab dip
                        Syscmd.Parameters.AddWithValue("Tnapl2", lblpl2.Text.Trim()); //lab dip app
                        Syscmd.Parameters.AddWithValue("Tnapl3", lblpl3.Text.Trim()); //accessories booking
                        Syscmd.Parameters.AddWithValue("Tnapl4", lblpl4.Text.Trim());//fabric booking
                        Syscmd.Parameters.AddWithValue("Tnapl5", lblpl5.Text.Trim()); //yarn booking
                        Syscmd.Parameters.AddWithValue("Tnapl6", lblpl6.Text.Trim());//1
                        Syscmd.Parameters.AddWithValue("Tnapl7", lblpl7.Text.Trim());//2
                        Syscmd.Parameters.AddWithValue("Tnapl8", lblpl8.Text.Trim());//3
                        Syscmd.Parameters.AddWithValue("Tnapl9", lblpl9.Text.Trim());//4
                        Syscmd.Parameters.AddWithValue("Tnapl10", lblpl10.Text.Trim());//5
                        Syscmd.Parameters.AddWithValue("Tnapl11", lblpl11.Text.Trim());//6
                        Syscmd.Parameters.AddWithValue("Tnapl12", lblpl12.Text.Trim());//7
                        Syscmd.Parameters.AddWithValue("Tnapl13", lblpl13.Text.Trim());//8
                        Syscmd.Parameters.AddWithValue("Tnapl14", lblpl14.Text.Trim());//9
                        Syscmd.Parameters.AddWithValue("Tnapl15", lblpl15.Text.Trim());//10
                        Syscmd.Parameters.AddWithValue("Tnapl16", lblpl16.Text.Trim());//11
                        Syscmd.Parameters.AddWithValue("Tnapl17", lblpl17.Text.Trim());//12
                        Syscmd.Parameters.AddWithValue("Tnapl18", lblpl18.Text.Trim());//13
                        Syscmd.Parameters.AddWithValue("Tnapl19", lblpl19.Text.Trim());//14
                        Syscmd.Parameters.AddWithValue("Tnapl20", lblpl20.Text.Trim());//15
                        Syscmd.Parameters.AddWithValue("Tnapl21", lblpl21.Text.Trim());//Pi recv
                        Syscmd.Parameters.AddWithValue("Tnapl22", lblpl22.Text.Trim());//BBlc open
                        Syscmd.Parameters.AddWithValue("Tnapl23", lblpl23.Text.Trim());//Yarn inhose strt
                        Syscmd.Parameters.AddWithValue("Tnapl24", lblpl24.Text.Trim());//Yarn inhouse end
                        Syscmd.Parameters.AddWithValue("Tnapl25", lblpl25.Text.Trim());//Knit Strt
                        Syscmd.Parameters.AddWithValue("Tnapl26", lblpl26.Text.Trim());//Knit end
                        Syscmd.Parameters.AddWithValue("Tnapl27", lblpl27.Text.Trim());//Dye Start
                        Syscmd.Parameters.AddWithValue("Tnapl28", lblpl28.Text.Trim());//Dye end
                        Syscmd.Parameters.AddWithValue("Tnapl29", lblpl29.Text.Trim());//Accessories Production Start
                        Syscmd.Parameters.AddWithValue("Tnapl30", lblpl30.Text.Trim());//Accessories Production End
                        Syscmd.Parameters.AddWithValue("Tnapl31", lblpl31.Text.Trim());//Sewing Trims Inhouse Start
                        Syscmd.Parameters.AddWithValue("Tnapl32", lblpl32.Text.Trim());//Sewing Trims Inhouse end
                        Syscmd.Parameters.AddWithValue("Tnapl33", lblpl33.Text.Trim());//Finishing Trims Inhouse start
                        Syscmd.Parameters.AddWithValue("Tnapl34", lblpl34.Text.Trim());//Finishing Trims Inhouse end
                        Syscmd.Parameters.AddWithValue("Tnapl35", lblpl35.Text.Trim());//PP Meeting/Trial Cut
                        Syscmd.Parameters.AddWithValue("Tnapl36", lblpl36.Text.Trim());//Bulk Cutting Start
                        Syscmd.Parameters.AddWithValue("Tnapl37", lblpl37.Text.Trim());//Bulk Cutting Finished
                        Syscmd.Parameters.AddWithValue("Tnapl38", lblpl38.Text.Trim());//Print Start
                        Syscmd.Parameters.AddWithValue("Tnapl39", lblpl39.Text.Trim());//Print Finished
                        Syscmd.Parameters.AddWithValue("Tnapl40", lblpl30.Text.Trim());//EMB Start
                        Syscmd.Parameters.AddWithValue("Tnapl41", lblpl41.Text.Trim());//EMB Finished
                        Syscmd.Parameters.AddWithValue("Tnapl42", lblpl42.Text.Trim());//Sewing Start
                        Syscmd.Parameters.AddWithValue("Tnapl43", lblpl43.Text.Trim());//Sewing Finished
                        Syscmd.Parameters.AddWithValue("Tnapl44", lblpl44.Text.Trim());//Wash Start
                        Syscmd.Parameters.AddWithValue("Tnapl45", lblpl45.Text.Trim());//Wash Finished
                        Syscmd.Parameters.AddWithValue("Tnapl46", lblpl46.Text.Trim());//1
                        Syscmd.Parameters.AddWithValue("Tnapl47", lblpl47.Text.Trim());//2
                        Syscmd.Parameters.AddWithValue("Tnapl48", lblpl48.Text.Trim());//3
                        Syscmd.Parameters.AddWithValue("Tnapl49", lblpl49.Text.Trim());//4
                        Syscmd.Parameters.AddWithValue("Tnapl50", lblpl50.Text.Trim());//5
                        Syscmd.Parameters.AddWithValue("Tnapl51", lblpl51.Text.Trim());//6
                        Syscmd.Parameters.AddWithValue("Tnapl52", lblpl52.Text.Trim());//Finishing Start
                        Syscmd.Parameters.AddWithValue("Tnapl53", lblpl53.Text.Trim());//Finishing End
                        Syscmd.Parameters.AddWithValue("Tnapl54", lblpl54.Text.Trim());//Pre Final Ins
                        Syscmd.Parameters.AddWithValue("Tnapl55", lblpl55.Text.Trim());// Final Ins
                        Syscmd.Parameters.AddWithValue("Tnapl56", lblpl56.Text.Trim());//YD start
                        Syscmd.Parameters.AddWithValue("Tnapl57", lblpl57.Text.Trim());//YD end
                        Syscmd.Parameters.AddWithValue("Tnapl58", lblpl58.Text.Trim());//AOP start
                        Syscmd.Parameters.AddWithValue("Tnapl59", lblpl59.Text.Trim());//AOP end
                        Syscmd.Parameters.AddWithValue("ReExFactory", newxfactory.Text.Trim());//AOP end

                        Syscmd.Connection = con;
                        con.Open();
                        TnaID = Convert.ToInt32(Syscmd.ExecuteScalar());

                        con.Close();


                    }
                }

                string message = string.Empty;
                switch (TnaID)
                {
                    case -1:
                        message = "Username already exists.\\nPlease choose a different username.";
                        break;
                    case -2:
                        message = "Supplied email address has already been used.";
                        break;
                    default:
                        message = "Registration successful. Activation email has been sent to your email.";
                        //SendTNALoadEmail(UserId);
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

            }
            Response.Redirect(Request.RawUrl); //page refreash


        }


    }


    #region "TNA Load"
    //private void SendTNALoadEmail(int UserId)
    //{
    //    SqlConnection conn = new SqlConnection(dbcon.x);
    //    //string activationCode = Guid.NewGuid().ToString();
    //    //using (SqlConnection con = new SqlConnection(dbcon.x))
    //    //{
    //    //    //using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
    //    //    using (SqlCommand cmd = new SqlCommand("Sp_UserActivation"))
    //    //    {
    //    //        using (SqlDataAdapter sda = new SqlDataAdapter())
    //    //        {
    //    //            cmd.CommandType = CommandType.StoredProcedure;
    //    //            cmd.Parameters.AddWithValue("@UserId", UserId);
    //    //            cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
    //    //            cmd.Connection = con;
    //    //            con.Open();
    //    //            cmd.ExecuteNonQuery();
    //    //            con.Close();
    //    //        }
    //    //    }
    //    //}
    //    using (MailMessage mm = new MailMessage("info@nz-bd.com", eml.Text))
    //    {
    //        mm.Subject = "Account Activation";
    //        string body = "Hello " + uid.Text.Trim() + ",";
    //        body += "<br /><br />-------------------------------------------";
    //        body += "<br /><br />Your Request has accepted";
    //        body += "<br /><br />Please click the following link to activate your OTS account";
    //        body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Setup/CrtUserActivation.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
    //        body += "<br /><br />You will get second notification to access the system shortly";
    //        body += "<br /><br />Thanks";
    //        body += "<br /><br />Database Administrator";
    //        body += "<br />Order Tracking System";
    //        body += "<br />NZ GROUP";
    //        mm.Body = body;
    //        mm.IsBodyHtml = true;
    //        SmtpClient smtp = new SmtpClient();
    //        smtp.Host = "mail.nz-bd.com";
    //        smtp.EnableSsl = false;
    //        NetworkCredential NetworkCred = new NetworkCredential("info@nz-bd.com", "<info@123>");
    //        smtp.UseDefaultCredentials = true;
    //        smtp.Credentials = NetworkCred;
    //        smtp.Port = 25;
    //        smtp.Send(mm);
    //    }
    //}
    #endregion


    protected void cnlbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl); //page refreash
    }
    protected void bkbtn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProHome.aspx");
    }





    protected void btnmenual_Click(object sender, EventArgs e)
    {

        this.div1.Visible = true;
        this.Tab1.Visible = true;
        this.lblpl1.Enabled = false;
        this.lblpl2.Enabled = false;
        this.lblpl3.Enabled = false;
        this.lblpl4.Enabled = false;
        this.lblpl5.Enabled = false;
        this.lblpl6.Enabled = false;
        this.lblpl7.Enabled = false;
        this.lblpl8.Enabled = false;
        this.lblpl9.Enabled = false;
        this.lblpl10.Enabled = false;
        this.lblpl11.Enabled = false;
        this.lblpl12.Enabled = false;
        this.lblpl13.Enabled = false;
        this.lblpl14.Enabled = false;
        this.lblpl15.Enabled = false;
        this.lblpl16.Enabled = false;
        this.lblpl17.Enabled = false;
        this.lblpl18.Enabled = false;
        this.lblpl19.Enabled = false;
        this.lblpl20.Enabled = false;
        this.lblpl21.Enabled = false;

        this.lblpl22.Enabled = false;
        this.lblpl23.Enabled = false;
        this.lblpl24.Enabled = false;
        this.lblpl25.Enabled = false;
        this.lblpl26.Enabled = false;
        this.lblpl27.Enabled = false;
        this.lblpl28.Enabled = false;
        this.lblpl29.Enabled = false;
        this.lblpl30.Enabled = false;
        this.lblpl31.Enabled = false;

        this.lblpl32.Enabled = false;
        this.lblpl33.Enabled = false;
        this.lblpl34.Enabled = false;
        this.lblpl35.Enabled = false;
        this.lblpl36.Enabled = false;
        this.lblpl37.Enabled = false;
        this.lblpl38.Enabled = false;
        this.lblpl39.Enabled = false;
        this.lblpl40.Enabled = false;

        this.lblpl41.Enabled = false;
        this.lblpl42.Enabled = false;
        this.lblpl43.Enabled = false;
        this.lblpl44.Enabled = false;
        this.lblpl45.Enabled = false;
        this.lblpl46.Enabled = false;
        this.lblpl47.Enabled = false;
        this.lblpl48.Enabled = false;
        this.lblpl49.Enabled = false;
        this.lblpl50.Enabled = false;

        this.lblpl51.Enabled = false;
        this.lblpl52.Enabled = false;
        this.lblpl53.Enabled = false;
        this.lblpl54.Enabled = false;
        this.lblpl55.Enabled = false;
        this.lblpl56.Enabled = false;
        this.lblpl57.Enabled = false;
        this.lblpl58.Enabled = false;
        this.lblpl59.Enabled = false;

        this.lblg1.Visible = false;
        this.lblg2.Visible = false;
        this.lblg3.Visible = false;
        this.lblg4.Visible = false;
        this.lblg5.Visible = false;
        this.lblg6.Visible = false;
        this.lblg6.Visible = false;
        this.lblg7.Visible = false;
        this.lblg8.Visible = false;
        this.lblg9.Visible = false;
        this.lblg10.Visible = false;
        this.lblg11.Visible = false;
        this.lblg12.Visible = false;
        this.lblg13.Visible = false;
        this.lblg14.Visible = false;
        this.lblg15.Visible = false;
        this.lblg16.Visible = false;
        this.lblg17.Visible = false;
        this.lblg18.Visible = false;
        this.lblg19.Visible = false;
        this.lblg20.Visible = false;
        this.lblg21.Visible = false;
        this.lblg22.Visible = false;
        this.lblg23.Visible = false;
        this.lblg24.Visible = false;
        this.lblg25.Visible = false;
        this.lblg26.Visible = false;
        this.lblg27.Visible = false;
        this.lblg28.Visible = false;
        this.lblg29.Visible = false;
        this.lblg30.Visible = false;
        this.lblg31.Visible = false;
        this.lblg32.Visible = false;
        this.lblg33.Visible = false;
        this.lblg34.Visible = false;
        this.lblg35.Visible = false;
        this.lblg36.Visible = false;
        this.lblg37.Visible = false;
        this.lblg38.Visible = false;
        this.lblg39.Visible = false;
        this.lblg40.Visible = false;
        this.lblg41.Visible = false;
        this.lblg42.Visible = false;
        this.lblg43.Visible = false;
        this.lblg44.Visible = false;
        this.lblg45.Visible = false;
        this.lblg46.Visible = false;
        this.lblg47.Visible = false;
        this.lblg48.Visible = false;
        this.lblg49.Visible = false;
        this.lblg50.Visible = false;
        this.lblg51.Visible = false;
        this.lblg52.Visible = false;
        this.lblg53.Visible = false;
        this.lblg54.Visible = false;
        this.lblg55.Visible = false;

        this.imgPopup1.Visible = true;
        this.imgPopup2.Visible = true;
        this.imgPopup3.Visible = true;
        this.imgPopup4.Visible = true;
        this.imgPopup5.Visible = true;
        this.imgPopup6.Visible = true;
        this.imgPopup7.Visible = true;
        this.imgPopup8.Visible = true;
        this.imgPopup9.Visible = true;
        this.imgPopup10.Visible = true;
        this.imgPopup11.Visible = true;
        this.imgPopup12.Visible = true;
        this.imgPopup13.Visible = true;
        this.imgPopup14.Visible = true;
        this.imgPopup15.Visible = true;
        this.imgPopup16.Visible = true;
        this.imgPopup17.Visible = true;
        this.imgPopup18.Visible = true;
        this.imgPopup19.Visible = true;
        this.imgPopup20.Visible = true;

        //if (ddTnacategory.SelectedItem.Value.ToString() == txtled.Text.ToString())

        string strSelectCmd = "select * from Buyer_Templt_View where Tna_typ_ID ='" + ddTnacategory.SelectedItem.Value + "' ";
        SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        #region "Merchndising"
        // Calculated form Order Confirmation
        lbl1.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt1"].ToString();
        lblg1.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay1"].ToString();
        Double d1 = Double.Parse(lblg1.Text);
        lblpl1.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d1).ToShortDateString(); //labdip submit

        //after labdip submit
        lbl2.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt2"].ToString();
        lblg2.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay2"].ToString();
        Double d2 = Double.Parse(lblg2.Text);
        lblpl2.Text = DateTime.Parse(lblpl1.Text).AddDays(d2).ToShortDateString();//labdip app

        //after OC
        lbl3.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt3"].ToString();
        lblg3.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay3"].ToString();
        Double d3 = Double.Parse(lblg3.Text);
        lblpl3.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d3).ToShortDateString();//accessories booking

        //after OC
        lbl4.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt4"].ToString();
        lblg4.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay4"].ToString();
        Double d4 = Double.Parse(lblg4.Text);
        lblpl4.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d4).ToShortDateString();//fabric booking

        //after OC
        lbl5.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt5"].ToString();
        lblg5.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay5"].ToString();
        Double d5 = Double.Parse(lblg5.Text);
        lblpl5.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d5).ToShortDateString();//yarn booking


        //Calculated From BPCD

        lbl6.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt6"].ToString();
        lblg6.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay6"].ToString();
        Double d6 = Double.Parse(lblg6.Text);
        lblpl6.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d6).ToShortDateString();//1


        lbl7.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt7"].ToString();
        lblg7.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay7"].ToString();
        Double d7 = Double.Parse(lblg7.Text);
        lblpl7.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d7).ToShortDateString();//2

        lbl8.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt8"].ToString();
        lblg8.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay8"].ToString();
        Double d8 = Double.Parse(lblg8.Text);
        lblpl8.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d8).ToShortDateString();//3

        lbl9.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt9"].ToString();
        lblg9.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay9"].ToString();
        Double d9 = Double.Parse(lblg9.Text);
        lblpl9.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d9).ToShortDateString();//4

        lbl10.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt10"].ToString();
        lblg10.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay10"].ToString();
        Double d10 = Double.Parse(lblg10.Text);
        lblpl10.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d10).ToShortDateString();//5

        lbl11.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt11"].ToString();
        lblg11.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay11"].ToString();
        Double d11 = Double.Parse(lblg11.Text);
        lblpl11.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d11).ToShortDateString();//6

        lbl12.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt12"].ToString();
        lblg12.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay12"].ToString();
        Double d12 = Double.Parse(lblg12.Text);
        lblpl12.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d12).ToShortDateString();//7

        lbl13.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt13"].ToString();
        lblg13.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay13"].ToString();
        Double d13 = Double.Parse(lblg13.Text);
        lblpl13.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d13).ToShortDateString();//8

        lbl14.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt14"].ToString();
        lblg14.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay14"].ToString();
        Double d14 = Double.Parse(lblg14.Text);
        lblpl14.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d14).ToShortDateString();//9

        lbl15.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt15"].ToString();
        lblg15.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay15"].ToString();
        Double d15 = Double.Parse(lblg15.Text);
        lblpl15.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d15).ToShortDateString();//10

        lbl16.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt16"].ToString();
        lblg16.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay16"].ToString();
        Double d16 = Double.Parse(lblg16.Text);
        lblpl16.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d16).ToShortDateString();//11

        lbl17.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt17"].ToString();
        lblg17.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay17"].ToString();
        Double d17 = Double.Parse(lblg17.Text);
        lblpl17.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d17).ToShortDateString();//12

        lbl18.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt18"].ToString();
        lblg18.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay18"].ToString();
        Double d18 = Double.Parse(lblg18.Text);
        lblpl18.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d18).ToShortDateString();//13

        lbl19.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt19"].ToString();
        lblg19.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay19"].ToString();
        Double d19 = Double.Parse(lblg19.Text);
        lblpl19.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d19).ToShortDateString();//14


        lbl20.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt20"].ToString();
        lblg20.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay20"].ToString();
        Double d20 = Double.Parse(lblg20.Text);
        lblpl20.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d20).ToShortDateString();//15

        #endregion

        #region "Yarn"
        //after yarn booking
        lbl21.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt21"].ToString();
        lblg21.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay21"].ToString();
        Double d21 = Double.Parse(lblg21.Text);
        lblpl21.Text = DateTime.Parse(lblpl5.Text).AddDays(d21).ToShortDateString();//Pi recv

        //after PI receive
        lbl22.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt22"].ToString();
        lblg22.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay22"].ToString();
        Double d22 = Double.Parse(lblg22.Text);
        lblpl22.Text = DateTime.Parse(lblpl21.Text).AddDays(d22).ToShortDateString();//BBlc Open

        //after BBlc 
        lbl23.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt23"].ToString();
        lblg23.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay23"].ToString();
        Double d23 = Double.Parse(lblg23.Text);
        lblpl23.Text = DateTime.Parse(lblpl22.Text).AddDays(d23).ToShortDateString();//Yarn Inhouse Strt

        lbl24.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt24"].ToString();
        lblg24.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay24"].ToString();
        Double d24 = Double.Parse(lblg24.Text);
        lblpl24.Text = DateTime.Parse(txtxftd.Text).AddDays(-d24).ToShortDateString();//Yarn inhouse End
        #endregion

        #region "Yarn Dye"
        //YD
        lbl56.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt56"].ToString();
        lblg56.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay56"].ToString();
        Double d56 = Double.Parse(lblg56.Text);
        lblpl56.Text = DateTime.Parse(lblpl23.Text).AddDays(d56).ToShortDateString();//Yarn Dye Srat

        lbl57.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt57"].ToString();
        lblg57.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay57"].ToString();
        Double d57 = Double.Parse(lblg57.Text);
        lblpl57.Text = DateTime.Parse(txtxftd.Text).AddDays(-d57).ToShortDateString();//Yarn Dye End
        #endregion

        #region "Knitting"
        lbl25.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt25"].ToString();
        lblg25.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay25"].ToString();
        Double d25 = Double.Parse(lblg25.Text);
        lblpl25.Text = DateTime.Parse(lblpl23.Text).AddDays(d25).ToShortDateString();//Knitting Start

        lbl26.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt26"].ToString();
        lblg26.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay26"].ToString();
        Double d26 = Double.Parse(lblg26.Text);
        lblpl26.Text = DateTime.Parse(txtxftd.Text).AddDays(-d26).ToShortDateString();//Knitting End
        #endregion

        #region "Dyeing"
        lbl27.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt27"].ToString();
        lblg27.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay27"].ToString();
        Double d27 = Double.Parse(lblg27.Text);
        lblpl27.Text = DateTime.Parse(lblpl25.Text).AddDays(d27).ToShortDateString();//Dyeing  Strt
        //Calculated from BPCD

        //Calculated from After BPCD
        lbl28.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt28"].ToString();
        lblg28.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay28"].ToString();
        Double d28 = Double.Parse(lblg28.Text);
        lblpl28.Text = DateTime.Parse(txtxftd.Text).AddDays(-d28).ToShortDateString();//Dyeing End
        #endregion

        #region "AOP"

        //AOP
        lbl58.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt58"].ToString();
        lblg58.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay58"].ToString();
        Double d58 = Double.Parse(lblg58.Text);
        lblpl58.Text = DateTime.Parse(lblpl27.Text).AddDays(d58).ToShortDateString();  //AOP Strat

        lbl59.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt59"].ToString();
        lblg59.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay59"].ToString();
        Double d59 = Double.Parse(lblg59.Text);
        lblpl59.Text = DateTime.Parse(txtxftd.Text).AddDays(-d59).ToShortDateString();  //AOP End
        #endregion

        #region "Accessories prod"
        //after Accessories booking
        lbl29.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt29"].ToString();
        lblg29.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay29"].ToString();
        Double d29 = Double.Parse(lblg29.Text);
        lblpl29.Text = DateTime.Parse(lblpl3.Text).AddDays(d29).ToShortDateString();//Accessories Prod Start

        //after BPCD
        lbl30.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt30"].ToString();
        lblg30.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay30"].ToString();
        Double d30 = Double.Parse(lblg30.Text);
        lblpl30.Text = DateTime.Parse(txtxftd.Text).AddDays(-d30).ToShortDateString();//Accessories Prod End
        #endregion

        #region "Inventory"

        //before BPCD
        lbl31.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt31"].ToString();
        lblg31.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay31"].ToString();
        Double d31 = Double.Parse(lblg31.Text);
        lblpl31.Text = DateTime.Parse(lblpl29.Text).AddDays(d31).ToShortDateString();//Sewing Trim Inhouse Start

        //after BPCD
        lbl32.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt32"].ToString();
        lblg32.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay32"].ToString();
        Double d32 = Double.Parse(lblg32.Text);
        lblpl32.Text = DateTime.Parse(txtxftd.Text).AddDays(-d32).ToShortDateString();//Sewing Trim inhouse End

        //before BPCD
        lbl33.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt33"].ToString();
        lblg33.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay33"].ToString();
        Double d33 = Double.Parse(lblg33.Text);
        lblpl33.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d33).ToShortDateString();//Finishing Trim Inhouse Start 

        //after BPCD
        lbl34.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt34"].ToString();
        lblg34.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay34"].ToString();
        Double d34 = Double.Parse(lblg34.Text);
        lblpl34.Text = DateTime.Parse(txtxftd.Text).AddDays(-d34).ToShortDateString();//Finishing Trim inhouse Emd
        #endregion

        #region "RMG"
        lbl35.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt35"].ToString();
        lblg35.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay35"].ToString();
        Double d35 = Double.Parse(lblg35.Text);
        lblpl35.Text = DateTime.Parse(txtbpsd.Text).AddDays(-d35).ToShortDateString();//PP /Trial cut

        //After BPCD
        lbl36.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt36"].ToString();
        lblg36.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay36"].ToString();
        Double d36 = Double.Parse(lblg36.Text);
        lblpl36.Text = DateTime.Parse(txtbpsd.Text).AddDays(d36).ToShortDateString();//bulk Ctutting Strt

        //Before Exfactory
        lbl37.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt37"].ToString();
        lblg37.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay37"].ToString();
        Double d37 = Double.Parse(lblg37.Text);
        lblpl37.Text = DateTime.Parse(txtxftd.Text).AddDays(-d37).ToShortDateString();//bulk Ctutting end

        //PRINT
        //After BPCD
        lbl38.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt38"].ToString();
        lblg38.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay38"].ToString();
        Double d38 = Double.Parse(lblg38.Text);
        lblpl38.Text = DateTime.Parse(lblpl36.Text).AddDays(d38).ToShortDateString();//Print start

        //before exfactory
        lbl39.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt39"].ToString();
        lblg39.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay39"].ToString();
        Double d39 = Double.Parse(lblg39.Text);
        lblpl39.Text = DateTime.Parse(txtxftd.Text).AddDays(-d39).ToShortDateString();//Print end

        //EMB
        //After BPCD
        lbl40.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt40"].ToString();
        lblg40.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay40"].ToString();
        Double d40 = Double.Parse(lblg40.Text);
        lblpl40.Text = DateTime.Parse(lblpl36.Text).AddDays(d40).ToShortDateString();//Emb Start

        //before exfactory
        lbl41.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt41"].ToString();
        lblg41.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay41"].ToString();
        Double d41 = Double.Parse(lblg41.Text);
        lblpl41.Text = DateTime.Parse(txtxftd.Text).AddDays(-d41).ToShortDateString();//Emb end

        //After BPCD
        lbl42.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt42"].ToString();
        lblg42.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay42"].ToString();
        Double d42 = Double.Parse(lblg42.Text);
        lblpl42.Text = DateTime.Parse(txtbpsd.Text).AddDays(d42).ToShortDateString();//Sewing Start

        //Before Exfactory
        lbl43.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt43"].ToString();
        lblg43.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay43"].ToString();
        Double d43 = Double.Parse(lblg43.Text);
        lblpl43.Text = DateTime.Parse(txtxftd.Text).AddDays(-d43).ToShortDateString();//Sewing end

        //After Sewing Start
        lbl44.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt44"].ToString();
        lblg44.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay44"].ToString();
        Double d44 = Double.Parse(lblg44.Text);
        lblpl44.Text = DateTime.Parse(lblpl42.Text).AddDays(d44).ToShortDateString();//Wash Start

        //before exfactory
        lbl45.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt45"].ToString();
        lblg45.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay45"].ToString();
        Double d45 = Double.Parse(lblg45.Text);
        lblpl45.Text = DateTime.Parse(txtxftd.Text).AddDays(-d45).ToShortDateString();//Wash end

        lbl46.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt46"].ToString();
        lblg46.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay46"].ToString();
        Double d46 = Double.Parse(lblg46.Text);
        lblpl46.Text = DateTime.Parse(txtxftd.Text).AddDays(-d46).ToShortDateString();//1

        lbl47.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt47"].ToString();
        lblg47.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay47"].ToString();
        Double d47 = Double.Parse(lblg47.Text);
        lblpl47.Text = DateTime.Parse(txtxftd.Text).AddDays(-d47).ToShortDateString();//2

        lbl48.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt48"].ToString();
        lblg48.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay48"].ToString();
        Double d48 = Double.Parse(lblg48.Text);
        lblpl48.Text = DateTime.Parse(txtxftd.Text).AddDays(-d48).ToShortDateString();//3

        lbl49.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt49"].ToString();
        lblg49.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay49"].ToString();
        Double d49 = Double.Parse(lblg49.Text);
        lblpl49.Text = DateTime.Parse(txtxftd.Text).AddDays(-d49).ToShortDateString();//4

        lbl50.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt50"].ToString();
        lblg50.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay50"].ToString();
        Double d50 = Double.Parse(lblg50.Text);
        lblpl50.Text = DateTime.Parse(txtxftd.Text).AddDays(-d50).ToShortDateString();//5

        lbl51.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt51"].ToString();
        lblg51.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay51"].ToString();
        Double d51 = Double.Parse(lblg51.Text);
        lblpl51.Text = DateTime.Parse(txtxftd.Text).AddDays(-d51).ToShortDateString();//6

        //After Sewing Start
        lbl52.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt52"].ToString();
        lblg52.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay52"].ToString();
        Double d52 = Double.Parse(lblg52.Text);
        lblpl52.Text = DateTime.Parse(lblpl42.Text).AddDays(d52).ToShortDateString();//Fin Start

        //before exfactory
        lbl53.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt53"].ToString();
        lblg53.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay53"].ToString();
        Double d53 = Double.Parse(lblg53.Text);
        lblpl53.Text = DateTime.Parse(txtxftd.Text).AddDays(-d53).ToShortDateString();//Fin End

        //before exfactory
        lbl54.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt54"].ToString();
        lblg54.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay54"].ToString();
        Double d54 = Double.Parse(lblg54.Text);
        lblpl54.Text = DateTime.Parse(txtxftd.Text).AddDays(-d54).ToShortDateString();//Pre final

        //before exfactory
        lbl55.Text = ds.Tables[0].Rows[0]["Tmplt_Evnt55"].ToString();
        lblg55.Text = ds.Tables[0].Rows[0]["Tmplt_EvntDay55"].ToString();
        Double d55 = Double.Parse(lblg55.Text);
        lblpl55.Text = DateTime.Parse(txtxftd.Text).AddDays(-d55).ToShortDateString();//Final Inspection
        #endregion


        //Double d3 = Double.Parse(txt6.Text);Expr4
        //lblpl4.Text = DateTime.Now.AddDays(d3).ToShortDateString();

    }


    protected void newxfactory_TextChanged(object sender, EventArgs e)
    {

        DateTime dt1 = DateTime.Parse(newxfactory.Text);
        DateTime dt2 = DateTime.Parse(txtocd.Text);
        TimeSpan ts = dt1 - dt2;
        txtled.Text = ts.TotalDays.ToString();


        if (int.Parse(txtled.Text) >= 60) //60 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-12).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 65) //60 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-15).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 70) //60 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-18).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 75) //60 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-23).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 80) //60 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-35).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 90) //90 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-45).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 100) //90 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-50).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 110) //90 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-55).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 120) //120 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-65).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 130) //120 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-70).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 140) //120 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-75).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 150) //150 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-75).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 180) //180 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-75).ToShortDateString();

        }
        if (int.Parse(txtled.Text) >= 210) //210 days order lead time//
        {
            txtbpsd.Text = DateTime.Parse(newxfactory.Text).AddDays(-75).ToShortDateString();

        }
    }
    
}