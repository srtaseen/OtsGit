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

public partial class _LogIn : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(DbConnect.x);
    protected void Page_Load(object sender, EventArgs e)
    {
        // Stop Caching in Firefox
        Response.Cache.SetNoStore();
        // Stop Caching in IE
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

        if (!IsPostBack)
        {
            Binddd_crusr_dpt();
            Binddd_crusr_com();
            Binddd_crusr_group();
            Binddd_buyer();
            this.lbltext.Visible = false;
            this.lbltext2.Visible = false;
            this.lbltext3.Visible = false;


        }

    }

    private void Binddd_buyer()
    {
        dd_buyer.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select byr_id,byr_nm FROM Buyer_Tab order by byr_nm ASC", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dd_buyer.DataSource = ds;
        dd_buyer.DataTextField = "byr_nm";
        dd_buyer.DataValueField = "byr_id";
        dd_buyer.DataBind();
        conn.Close();
    }

    private void Binddd_crusr_group()
    {
        //dd_crusr_group.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select UsrGID,UsrGName FROM Tbl_UsrGroup WHERE UsrGID='3'", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dd_crusr_group.DataSource = ds;
        dd_crusr_group.DataTextField = "UsrGName";
        dd_crusr_group.DataValueField = "UsrGID";
        dd_crusr_group.DataBind();
        conn.Close();
    }



    protected void Binddd_crusr_dpt()
    {

        dd_crusr_dpt.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select dpt_nm,dpt_id FROM DeptTab order by dpt_nm ASC", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dd_crusr_dpt.DataSource = ds;
        dd_crusr_dpt.DataTextField = "dpt_nm";
        dd_crusr_dpt.DataValueField = "dpt_id";
        dd_crusr_dpt.DataBind();
        conn.Close();

    }

    protected void Binddd_crusr_com()
    {

        dd_crusr_com.AppendDataBoundItems = true;
        conn.Open();
        SqlCommand Syscmd = new SqlCommand("Select Fact_nm,Fact_id FROM Factory_Tab", conn);
        SqlDataAdapter da = new SqlDataAdapter(Syscmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dd_crusr_com.DataSource = ds;
        dd_crusr_com.DataTextField = "Fact_nm";
        dd_crusr_com.DataValueField = "Fact_id";
        dd_crusr_com.DataBind();
        conn.Close();

    }


    protected void btn_crusr_sv_Click(object sender, EventArgs e)
    {



        int UserId = 0;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        using (SqlConnection con = new SqlConnection(DbConnect.x))
        {
            using (SqlCommand Syscmd = new SqlCommand("Insert_User"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    Syscmd.CommandType = CommandType.StoredProcedure;
                    Syscmd.Parameters.AddWithValue("@Username", uid.Text.Trim());
                    Syscmd.Parameters.AddWithValue("@Password", pwd.Text.Trim());
                    Syscmd.Parameters.AddWithValue("@Email", eml.Text.Trim());
                    Syscmd.Parameters.AddWithValue("@usrnm", unm.Text.Trim());
                    Syscmd.Parameters.AddWithValue("@Mobile", txtmobile.Text.Trim());
                    Syscmd.Parameters.AddWithValue("@UsrDpt", dd_crusr_dpt.SelectedValue);
                    Syscmd.Parameters.AddWithValue("@UsrCom", dd_crusr_com.SelectedValue);
                    Syscmd.Parameters.AddWithValue("@UsrGroup", dd_crusr_group.SelectedValue);
                    Syscmd.Parameters.AddWithValue("@UsrTyp", dd_buyer.SelectedValue);
                    Syscmd.Connection = con;
                    con.Open();
                    UserId = Convert.ToInt32(Syscmd.ExecuteScalar());
                    con.Close();
                }

            }
            string message = string.Empty;
            unm.Text = string.Empty;
            uid.Text = string.Empty;
            txtmobile.Text = string.Empty;
            //eml.Text = string.Empty;
            switch (UserId)
            {
                case -1:
                    this.lbltext.Visible = true;
                    //message = "Username already exists.\\nPlease choose a different username.";
                    lbltext.Text = "Username already exists.Please choose a different username.";
                    break;
                case -2:
                    this.lbltext3.Visible = true;
                    lbltext3.Text = "Supplied email address has already been used.";
                   
                    break;
                default:
                    this.lbltext2.Visible = true;
                    lbltext2.Text = "Successful. Activation email has been sent to your email.";
                   
                    SendActivationEmail(UserId);
                    SendUserCreateEmail(UserId);
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }

    }

    //User Account Request sent to systems@nz-bd.com 
    private void SendUserCreateEmail(int UserId)
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        string activationCode = Guid.NewGuid().ToString();

        using (MailMessage mm = new MailMessage("info@nz-bd.com", "systems@nz-bd.com"))
        {
            mm.Subject = "User Has Created";
            string body = "Hello Support Team";
            body += "<br /><br />-------------------------------------------";
            body += "<br /><br />A New User Request has Procced";
            body += "<br />USER ID:  " + uid.Text.Trim() + ",";
            body += "<br />Department:  " + dd_crusr_dpt.SelectedItem + ",";
            body += "<br /><br />Please Confirm and Activate This OTS Login Account";

            body += "<br /><br />Thanks";
            body += "<br /><br />Database Administrator";
            body += "<br />Order Tracking System";
            body += "<br />NZ GROUP";
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.nz-bd.com";
            smtp.EnableSsl = false;
            NetworkCredential NetworkCred = new NetworkCredential("info@nz-bd.com", "<NZGroup#321>");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 25;
            smtp.Send(mm);
        }
    }



    #region "UserActivation"
    private void SendActivationEmail(int UserId)
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        string activationCode = Guid.NewGuid().ToString();
        using (SqlConnection con = new SqlConnection(DbConnect.x))
        {
            //using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
            using (SqlCommand cmd = new SqlCommand("Sp_UserActivation"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        using (MailMessage mm = new MailMessage("info@nz-bd.com", eml.Text))
        {
            mm.Subject = "Account Activation";
            string body = "Hello Mr." + uid.Text.Trim() + ",";
            body += "<br /><br />-------------------------------------------";
            body += "<br /><br />Your Request has accepted";
            body += "<br /><br />Please click the following link to activate your OTS account";
            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("UserRegister.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
            body += "<br /><br />You will get second notification to access the system shortly";
            body += "<br /><br />Thanks";
            body += "<br /><br />Database Administrator";
            body += "<br />Order Tracking System";
            body += "<br />NZ GROUP";
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.nz-bd.com";
            smtp.EnableSsl = false;
            NetworkCredential NetworkCred = new NetworkCredential("info@nz-bd.com", "<NZGroup#321>");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 25;
            smtp.Send(mm);
        }
    }
    #endregion 

    protected void btnbak_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIn.aspx");
    }
}
