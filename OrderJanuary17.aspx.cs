using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
public partial class OrderAugust : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowReport();
        }
    }

    private void ShowReport()
    {
        ReportViewer1.Reset();

        ReportDataSource dsAugust1st = new ReportDataSource("DataSet1", GetAugust1st());
        ReportDataSource dsAugust2nd = new ReportDataSource("DataSet2", GetAugust2nd());
        ReportDataSource dsAugust3rd = new ReportDataSource("DataSet3", GetAugust3rd());
        ReportDataSource dsAugust4th = new ReportDataSource("DataSet4", GetAugust4th());
        //ReportDataSource dsShip1st = new ReportDataSource("DataSet5", GetShip1st());
        //ReportDataSource dsShip2nd = new ReportDataSource("DataSet6", GetShip1st());
        //ReportDataSource dsShip3rd = new ReportDataSource("DataSet7", GetShip1st());
        //ReportDataSource dsShip4th = new ReportDataSource("DataSet8", GetShip1st());

        ReportViewer1.LocalReport.DataSources.Add(dsAugust1st);
        ReportViewer1.LocalReport.DataSources.Add(dsAugust2nd);
        ReportViewer1.LocalReport.DataSources.Add(dsAugust3rd);
        ReportViewer1.LocalReport.DataSources.Add(dsAugust4th);
        //ReportViewer1.LocalReport.DataSources.Add(dsShip1st);
        //ReportViewer1.LocalReport.DataSources.Add(dsShip2nd);
        //ReportViewer1.LocalReport.DataSources.Add(dsShip3rd);
        //ReportViewer1.LocalReport.DataSources.Add(dsShip4th);


        ReportViewer1.LocalReport.ReportPath = "reports/ReportJanuary'17.rdlc";

        //ReportViewer1.LocalReport.Refresh();


        //testing pdf

        var bytes = ReportViewer1.LocalReport.Render("PDF");
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "inline;attachment; filename=Sample.pdf");
        Response.BinaryWrite(bytes);
        Response.Flush(); // send it to the client to download
        Response.Clear();

    }

    private DataTable GetAugust1st()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand(@"select c.byr_nm,c.targetQty as targetQty,(isnull(b.po_quantity,0) + isnull(sd.remainQty,0)) as QtyInHand,isnull(sd.remainQty,0) as LastWkRemain,((isnull(c.targetQty,0))-(isnull(b.po_quantity,0))) as BalanceQty,cast(round((isnull(c.targetQty,0)*isnull(c.targetFob,0)),2) as numeric(36,2)) as TargetValue, 
cast(round(isnull(b.Totalprice,0),2) as numeric(36,2)) as ValueInHand,cast(round(((isnull(c.targetQty,0))*(isnull(c.targetFob,0))-(isnull(b.Totalprice,0))),2) as numeric(36,2)) as BalanceValue,cast(round((isnull(c.targetFob,0)),2) as numeric(36,2)) as targetFob  ,
cast(round(isnull(b.po_price,0),2) as numeric(36,2)) as AchieveFob,cast(round((isnull(c.targetSmv,0)),2) as numeric(36,2)) as targetSmv,
cast(round(isnull(b.Smv,0),2) as numeric(36,2)) as AchieveSmv,cast(round(isnull(c.targetSmv,0)-(isnull(b.smv,0)),2) as numeric(36,2)) as BalanceSmv,cast(round((isnull(ss.ship_quantity,0)),2) as numeric(36,2)) as ship_quantity,cast(round((isnull(ss.ship_tprice,0)),2) as numeric(36,2)) as ship_tprice
from 
(select c.byr_nm,sum(targetQty) as targetQty,avg(targetFob) as targetFob,avg(targetSmv) as targetSmv
from tblOrderTarget c
where targetDate  between '2017-01-01' and '2017-01-07' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-01-01' and '2017-01-07' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2016-12-22' and '2016-12-31'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-01-01' and '2017-01-07'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm 
", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }

    private DataTable GetAugust2nd()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand(@"select c.byr_nm,c.targetQty as targetQty,(isnull(b.po_quantity,0) + isnull(sd.remainQty,0)) as QtyInHand,isnull(sd.remainQty,0) as LastWkRemain,((isnull(c.targetQty,0))-(isnull(b.po_quantity,0))) as BalanceQty,cast(round((isnull(c.targetQty,0)*isnull(c.targetFob,0)),2) as numeric(36,2)) as TargetValue, 
cast(round(isnull(b.Totalprice,0),2) as numeric(36,2)) as ValueInHand,cast(round(((isnull(c.targetQty,0))*(isnull(c.targetFob,0))-(isnull(b.Totalprice,0))),2) as numeric(36,2)) as BalanceValue,cast(round((isnull(c.targetFob,0)),2) as numeric(36,2)) as targetFob  ,
cast(round(isnull(b.po_price,0),2) as numeric(36,2)) as AchieveFob,cast(round((isnull(c.targetSmv,0)),2) as numeric(36,2)) as targetSmv,
cast(round(isnull(b.Smv,0),2) as numeric(36,2)) as AchieveSmv,cast(round(isnull(c.targetSmv,0)-(isnull(b.smv,0)),2) as numeric(36,2)) as BalanceSmv,cast(round((isnull(ss.ship_quantity,0)),2) as numeric(36,2)) as ship_quantity,cast(round((isnull(ss.ship_tprice,0)),2) as numeric(36,2)) as ship_tprice
from 
(select c.byr_nm,sum(targetQty) as targetQty,avg(targetFob) as targetFob,avg(targetSmv) as targetSmv
from tblOrderTarget c
where targetDate  between '2017-01-08' and '2017-01-14' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-01-08' and '2017-01-14' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-01-01' and '2017-01-07'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-01-08' and '2017-01-14'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }

    private DataTable GetAugust3rd()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand(@"select c.byr_nm,c.targetQty as targetQty,(isnull(b.po_quantity,0) + isnull(sd.remainQty,0)) as QtyInHand,isnull(sd.remainQty,0) as LastWkRemain,((isnull(c.targetQty,0))-(isnull(b.po_quantity,0))) as BalanceQty,cast(round((isnull(c.targetQty,0)*isnull(c.targetFob,0)),2) as numeric(36,2)) as TargetValue, 
cast(round(isnull(b.Totalprice,0),2) as numeric(36,2)) as ValueInHand,cast(round(((isnull(c.targetQty,0))*(isnull(c.targetFob,0))-(isnull(b.Totalprice,0))),2) as numeric(36,2)) as BalanceValue,cast(round((isnull(c.targetFob,0)),2) as numeric(36,2)) as targetFob  ,
cast(round(isnull(b.po_price,0),2) as numeric(36,2)) as AchieveFob,cast(round((isnull(c.targetSmv,0)),2) as numeric(36,2)) as targetSmv,
cast(round(isnull(b.Smv,0),2) as numeric(36,2)) as AchieveSmv,cast(round(isnull(c.targetSmv,0)-(isnull(b.smv,0)),2) as numeric(36,2)) as BalanceSmv,cast(round((isnull(ss.ship_quantity,0)),2) as numeric(36,2)) as ship_quantity,cast(round((isnull(ss.ship_tprice,0)),2) as numeric(36,2)) as ship_tprice
from 
(select c.byr_nm,sum(targetQty) as targetQty,avg(targetFob) as targetFob,avg(targetSmv) as targetSmv
from tblOrderTarget c
where targetDate  between '2017-01-15' and '2017-01-21' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-01-15' and '2017-01-21' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-01-08' and '2017-01-14'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-01-15' and '2017-01-21'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }

    private DataTable GetAugust4th()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(DbConnect.x))
        {
            SqlCommand cmd = new SqlCommand(@"select c.byr_nm,c.targetQty as targetQty,(isnull(b.po_quantity,0) + isnull(sd.remainQty,0)) as QtyInHand,isnull(sd.remainQty,0) as LastWkRemain,((isnull(c.targetQty,0))-(isnull(b.po_quantity,0))) as BalanceQty,cast(round((isnull(c.targetQty,0)*isnull(c.targetFob,0)),2) as numeric(36,2)) as TargetValue, 
cast(round(isnull(b.Totalprice,0),2) as numeric(36,2)) as ValueInHand,cast(round(((isnull(c.targetQty,0))*(isnull(c.targetFob,0))-(isnull(b.Totalprice,0))),2) as numeric(36,2)) as BalanceValue,cast(round((isnull(c.targetFob,0)),2) as numeric(36,2)) as targetFob  ,
cast(round(isnull(b.po_price,0),2) as numeric(36,2)) as AchieveFob,cast(round((isnull(c.targetSmv,0)),2) as numeric(36,2)) as targetSmv,
cast(round(isnull(b.Smv,0),2) as numeric(36,2)) as AchieveSmv,cast(round(isnull(c.targetSmv,0)-(isnull(b.smv,0)),2) as numeric(36,2)) as BalanceSmv,cast(round((isnull(ss.ship_quantity,0)),2) as numeric(36,2)) as ship_quantity,cast(round((isnull(ss.ship_tprice,0)),2) as numeric(36,2)) as ship_tprice
from 
(select c.byr_nm,sum(targetQty) as targetQty,avg(targetFob) as targetFob,avg(targetSmv) as targetSmv
from tblOrderTarget c
where targetDate  between '2017-01-22' and '2017-01-31' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-01-22' and '2017-01-31' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-01-15' and '2017-01-21'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-01-22' and '2017-01-31'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }

}
//    private DataTable GetShip1st()
//    {
//        DataTable dt = new DataTable();

//        using (SqlConnection conn = new SqlConnection(DbConnect.x))
//        {
//            SqlCommand cmd = new SqlCommand(@"SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
//                                            from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,
//                                            (pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
//                                            from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-01-01' and '2017-01-07'
//                                            group by pm.ord_buyer,pm.po_no,pm.po_price) a
//                                            join Buyer_Tab bt on a.ord_buyer=bt.byr_id
//                                            group by bt.byr_nm", conn);
//            conn.Open();

//            SqlDataReader reader = cmd.ExecuteReader();
//            dt.Load(reader);
//        }
//        return dt;
//    }

//    private DataTable GetShip2nd()
//    {
//        DataTable dt = new DataTable();

//        using (SqlConnection conn = new SqlConnection(DbConnect.x))
//        {
//            SqlCommand cmd = new SqlCommand(@"SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
//                                            from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,
//                                            (pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
//                                            from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-01-08' and '2017-01-14'
//                                            group by pm.ord_buyer,pm.po_no,pm.po_price) a
//                                            join Buyer_Tab bt on a.ord_buyer=bt.byr_id
//                                            group by bt.byr_nm", conn);
//            conn.Open();

//            SqlDataReader reader = cmd.ExecuteReader();
//            dt.Load(reader);
//        }
//        return dt;
//    }
//    private DataTable GetShip3rd()
//    {
//        DataTable dt = new DataTable();

//        using (SqlConnection conn = new SqlConnection(DbConnect.x))
//        {
//            SqlCommand cmd = new SqlCommand(@"SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
//                                            from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,
//                                            (pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
//                                            from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-01-15' and '2017-01-21'
//                                            group by pm.ord_buyer,pm.po_no,pm.po_price) a
//                                            join Buyer_Tab bt on a.ord_buyer=bt.byr_id
//                                            group by bt.byr_nm", conn);
//            conn.Open();

//            SqlDataReader reader = cmd.ExecuteReader();
//            dt.Load(reader);
//        }
//        return dt;
//    }
//    private DataTable GetShip4th()
//    {
//        DataTable dt = new DataTable();

//        using (SqlConnection conn = new SqlConnection(DbConnect.x))
//        {
//            SqlCommand cmd = new SqlCommand(@"SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
//                                            from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,
//                                            (pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
//                                            from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-01-22' and '2017-01-31'
//                                            group by pm.ord_buyer,pm.po_no,pm.po_price) a
//                                            join Buyer_Tab bt on a.ord_buyer=bt.byr_id
//                                            group by bt.byr_nm", conn);
//            conn.Open();

//            SqlDataReader reader = cmd.ExecuteReader();
//            dt.Load(reader);
//        }
//        return dt;
//    }



//    private DataTable GetAugust()
//    {
//        DataTable dt = new DataTable();

//        using (SqlConnection conn = new SqlConnection(DbConnect.x))
//        {
//            SqlCommand cmd = new SqlCommand(@"select sum(b.po_quantity) as QtyInHand,sum(b.Totalprice) as ValueInHand from View_Tna_Plan a 
//                                            join View_OrderInhand b on a.po_no=b.po_no where b.byr_nm='ALDI(GP)' and b.po_xfactory between '2016-08-01' and '2016-08-31' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL", conn);
//            conn.Open();

//            SqlDataReader reader = cmd.ExecuteReader();
//            dt.Load(reader);
//        }
//        return dt;
//    }

//    private DataTable GetSeptember()
//    {
//        DataTable dt = new DataTable();

//        using (SqlConnection conn = new SqlConnection(DbConnect.x))
//        {
//            SqlCommand cmd = new SqlCommand(@"select sum(b.po_quantity) as QtyInHand,sum(b.Totalprice) as ValueInHand from View_Tna_Plan a 
//                                            join View_OrderInhand b on a.po_no=b.po_no where b.byr_nm='ALDI(GP)' and b.po_xfactory between '2016-09-01' and '2016-09-30' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL", conn);
//            conn.Open();

//            SqlDataReader reader = cmd.ExecuteReader();
//            dt.Load(reader);
//        }
//        return dt;
//    }







//select c.byr_nm,c.targetQty as targetQty,(isnull(b.po_quantity,0) + isnull(sd.remainQty,0)) as QtyInHand,((isnull(c.targetQty,0))-(isnull(b.po_quantity,0))) as BalanceQty,cast(round((isnull(c.targetQty,0)*isnull(c.targetFob,0)),2) as numeric(36,2)) as TargetValue, 
//cast(round(isnull(b.Totalprice,0),2) as numeric(36,2)) as ValueInHand,cast(round(((isnull(c.targetQty,0))*(isnull(c.targetFob,0))-(isnull(b.Totalprice,0))),2) as numeric(36,2)) as BalanceValue,cast(round((isnull(c.targetFob,0)),2) as numeric(36,2)) as targetFob  ,
//cast(round(isnull(b.po_price,0),2) as numeric(36,2)) as AchieveFob,cast(round((isnull(c.targetSmv,0)),2) as numeric(36,2)) as targetSmv,
//cast(round(isnull(b.Smv,0),2) as numeric(36,2)) as AchieveSmv,cast(round(isnull(c.targetSmv,0)-(isnull(b.smv,0)),2) as numeric(36,2)) as BalanceSmv 
//from 
//(select c.byr_nm,sum(targetQty) as targetQty,avg(targetFob) as targetFob,avg(targetSmv) as targetSmv
//from tblOrderTarget c
//where targetDate  between '2017-01-15' and '2017-01-21' 
//group by c.byr_nm) as c left join
//(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
//from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
//where b.po_xfactory between '2017-01-15' and '2017-01-21' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
//group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
//(select bt.byr_nm, sum(sd.ship_remain) as remainQty
//from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
//where sd.ship_date between '2017-01-08' and '2017-01-14'
//group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm