using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class OrderMonthJanuary17 : System.Web.UI.Page
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

        ReportDataSource dsJanuary17 = new ReportDataSource("DataSet1", GetJanuary17());
        ReportDataSource dsFebruary17 = new ReportDataSource("DataSet2", GetFebruary17());
        ReportDataSource dsMarch17 = new ReportDataSource("DataSet3", GetMarch17());
        ReportDataSource dsApril17 = new ReportDataSource("DataSet4", GetApril17());
        ReportDataSource dsMay17 = new ReportDataSource("DataSet5", GetMay17());
        ReportDataSource dsJune17 = new ReportDataSource("DataSet6", GetJune17());
        ReportDataSource dsJuly17 = new ReportDataSource("DataSet7", GetJuly17());
        ReportDataSource dsAugust17 = new ReportDataSource("DataSet8", GetAugust17());
        ReportDataSource dsSemtember17 = new ReportDataSource("DataSet9", GetSeptember17());
        ReportDataSource dsOctober17 = new ReportDataSource("DataSet10", GetOctober17());
        ReportDataSource dsNovember17 = new ReportDataSource("DataSet11", GetNovember17());
        ReportDataSource dsDecember17 = new ReportDataSource("DataSet12", GetDecember17());
        //ReportDataSource dsAugust4th = new ReportDataSource("DataSet4", GetAugust4th());

        ReportViewer1.LocalReport.DataSources.Add(dsJanuary17);
        ReportViewer1.LocalReport.DataSources.Add(dsFebruary17);
        ReportViewer1.LocalReport.DataSources.Add(dsMarch17);
        ReportViewer1.LocalReport.DataSources.Add(dsApril17);
        ReportViewer1.LocalReport.DataSources.Add(dsMay17);
        ReportViewer1.LocalReport.DataSources.Add(dsJune17);
        ReportViewer1.LocalReport.DataSources.Add(dsJuly17);
        ReportViewer1.LocalReport.DataSources.Add(dsAugust17);
        ReportViewer1.LocalReport.DataSources.Add(dsSemtember17);
        ReportViewer1.LocalReport.DataSources.Add(dsOctober17);
        ReportViewer1.LocalReport.DataSources.Add(dsNovember17);
        ReportViewer1.LocalReport.DataSources.Add(dsDecember17);
        //ReportViewer1.LocalReport.DataSources.Add(dsAugust4th);


        ReportViewer1.LocalReport.ReportPath = "reports/ReportMonthJanuary17.rdlc";

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

    private DataTable GetJanuary17()
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
where targetDate  between '2017-01-01' and '2017-01-31' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-01-01' and '2017-01-31' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2016-12-01' and '2016-12-31'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-01-01' and '2017-01-31'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }

    private DataTable GetFebruary17()
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
where targetDate  between '2017-02-01' and '2017-02-28' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-02-01' and '2017-02-28' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-01-01' and '2017-01-31'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-02-01' and '2017-02-28'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }


    private DataTable GetMarch17()
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
where targetDate  between '2017-03-01' and '2017-03-31' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-03-01' and '2017-03-31' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-02-01' and '2017-02-28'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-03-01' and '2017-03-31'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }


    private DataTable GetApril17()
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
where targetDate  between '2017-04-01' and '2017-04-30' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-04-01' and '2017-04-30' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-03-01' and '2017-03-31'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-04-01' and '2017-04-30'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }


    private DataTable GetMay17()
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
where targetDate  between '2017-05-01' and '2017-05-31' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-05-01' and '2017-05-31' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-04-01' and '2017-04-30'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-05-01' and '2017-05-31'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }


    private DataTable GetJune17()
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
where targetDate  between '2017-06-01' and '2017-06-30' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-06-01' and '2017-06-30' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-05-01' and '2017-05-31'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-06-01' and '2017-06-30'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }

    private DataTable GetJuly17()
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
where targetDate  between '2017-07-01' and '2017-07-31' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-07-01' and '2017-07-31' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-06-01' and '2017-06-30'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-07-01' and '2017-07-31'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }

    private DataTable GetAugust17()
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
where targetDate  between '2017-08-01' and '2017-08-31' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-08-01' and '2017-08-31' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-07-01' and '2017-07-31'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-08-01' and '2017-08-31'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }


    private DataTable GetSeptember17()
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
where targetDate  between '2017-09-01' and '2017-09-30' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-09-01' and '2017-09-30' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-08-01' and '2017-08-31'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-09-01' and '2017-09-30'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }


    private DataTable GetOctober17()
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
where targetDate  between '2017-10-01' and '2017-10-31' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-10-01' and '2017-10-31' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-09-01' and '2017-09-30'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-10-01' and '2017-10-31'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }


    private DataTable GetNovember17()
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
where targetDate  between '2017-11-01' and '2017-11-30' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-11-01' and '2017-11-30' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-10-01' and '2017-10-31'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-11-01' and '2017-11-30'
group by pm.ord_buyer,pm.po_no,pm.po_price) a
join Buyer_Tab bt on a.ord_buyer=bt.byr_id
group by bt.byr_nm) ss  on c.byr_nm=ss.byr_nm", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        return dt;
    }


    private DataTable GetDecember17()
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
where targetDate  between '2017-12-01' and '2017-12-31' 
group by c.byr_nm) as c left join
(select b.byr_nm,sum(b.po_quantity) as po_quantity,sum(a.Totalprice) as Totalprice,avg(b.po_price) as po_price,avg(isnull(a.Smv,0)) as smv
from View_OrderInhand b join View_Tna_Plan a on b.byr_nm=a.byr_nm and  b.po_no=a.po_no and b.ord_no=a.ord_no
where b.po_xfactory between '2017-12-01' and '2017-12-31' AND a.PO_Ship_Date is NULL AND b.ActiveOrder='1' AND b.TnAapproved IS NOT NULL 
group by b.byr_nm) b on c.byr_nm=b.byr_nm  left join
(select bt.byr_nm, sum(sd.ship_remain) as remainQty
from tblShipmentDetails sd join (PO_Master pm join Buyer_Tab bt on pm.ord_buyer=bt.byr_id) on sd.po_no=pm.po_no 
where sd.ship_date between '2017-11-01' and '2017-11-30'
group by bt.byr_nm) sd on c.byr_nm=sd.byr_nm left join
(SELECT bt.byr_nm,sum(a.ship_quantity) as ship_quantity,sum(a.ship_tprice) as ship_tprice
from (SELECT pm.ord_buyer,pm.po_no,sum(sd.ship_quantity) as ship_quantity,(pm.po_price*sum(sd.ship_quantity)) as ship_tprice 
from tblShipmentDetails sd join PO_Master pm on sd.po_no=pm.po_no where sd.ship_date between '2017-12-01' and '2017-12-31'
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