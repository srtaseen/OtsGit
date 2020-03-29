using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HP5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bindddlorder();
        
    }


    private void Bindddlorder()
    {
        drpPO.AppendDataBoundItems = true;
        drpPO.Items.Add(new ListItem("-", ""));
        SqlConnection conn = new SqlConnection(DbConnect.x);
        String strQuery = "select po_no from Line_Booking order by po_no ASC ";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            drpPO.DataSource = cmd.ExecuteReader();
            drpPO.DataTextField = "po_no";
            drpPO.DataValueField = "po_no";

            drpPO.DataBind();
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

    protected void drpPO_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtFactory.Text = "NAZ Bangldesh Ltd";
        drpLine.Items.Clear();

        drpLine.Items.Add(new ListItem("-", ""));
        drpLine.AppendDataBoundItems = true;
        SqlConnection conn = new SqlConnection(DbConnect.x);
        try
        {
            String strQuery = "select DISTINCT line_no FROM Line_Booking where po_no='" + drpPO.SelectedItem.Text + "' ";
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = conn;

            conn.Open();
            drpLine.DataSource = cmd.ExecuteReader();
            drpLine.DataTextField = "line_no";
            drpLine.DataValueField = "line_no";
            drpLine.DataBind();
            if (drpLine.Items.Count > 1)
                drpLine.Enabled = true;
            else
                drpLine.Enabled = false;

            //DataTable dtOrder = (DataTable)ViewState["Order"];
            //DataView vwOrder = dtOrder.DefaultView;
            //vwOrder.RowFilter = "ord_no = '" + GetStn.SelectedValue + "'";
            //GetGType.Text = vwOrder[0][2].ToString();
            //GetFactory.Text = vwOrder[0][4].ToString();
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






    protected void drpLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(DbConnect.x);
        try
        {
            DataTable dt = new DataTable();
            String strQuery = "select DISTINCT ord_no,ord_buyer,target_hr,plan_hr,target_dy,ord_factory from Line_Booking where po_no='" + drpPO.SelectedItem.Text + "' and line_no='" + drpLine.SelectedItem.Text + "' ";
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
                
                txtOrder.Text= dt.Rows[0]["ord_no"].ToString();
                txtBuyer.Text = dt.Rows[0]["ord_buyer"].ToString();
                txtTargerHr.Text = dt.Rows[0]["target_hr"].ToString();
                txtPlanHr.Text = dt.Rows[0]["plan_hr"].ToString();
                txtTargetDy.Text = dt.Rows[0]["target_dy"].ToString();
                txtOrdFactory.Text = dt.Rows[0]["ord_factory"].ToString();
                

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


    protected void Btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(DbConnect.x);

            SqlCommand Syscmd = new SqlCommand();
            Syscmd.CommandType = CommandType.StoredProcedure;
            Syscmd.CommandText = "Sp_Plan_Data2";

            DateTime entDate = DateTime.ParseExact(txtentdt.Text, "d", null);
            Syscmd.Parameters.AddWithValue("@ent_date", entDate);
            string line = drpLine.SelectedValue.ToString();
            Syscmd.Parameters.AddWithValue("@line_no", line);
            Syscmd.Parameters.AddWithValue("@ord_no", txtOrder.Text.Trim());
            Syscmd.Parameters.AddWithValue("@po_no", drpPO.SelectedValue.ToString());
            Syscmd.Parameters.AddWithValue("@ord_buyer", txtBuyer.Text.Trim());
            Syscmd.Parameters.AddWithValue("@target_hr", int.Parse(txtTargerHr.Text.Trim()));
            Syscmd.Parameters.AddWithValue("@target_dy", int.Parse(txtTargetDy.Text.Trim()));
            Syscmd.Parameters.AddWithValue("@ord_factory", txtOrdFactory.Text.Trim());

            Syscmd.Parameters.AddWithValue("@plan_hr", int.Parse(txtPlanHr.Text.Trim()));
            int prodHr = int.Parse(drpHour.SelectedValue.ToString());
            Syscmd.Parameters.AddWithValue("@prodHr", prodHr);
            int hrValue = int.Parse(txtHour.Text.Trim());
            Syscmd.Parameters.AddWithValue("@hrValue", hrValue);

            Syscmd.Connection = conn;
            conn.Open();

            Syscmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
        }

        drpHour.ClearSelection();
        txtHour.Text = string.Empty;
        //Response.Redirect(Request.RawUrl); //page refreash
    }


}