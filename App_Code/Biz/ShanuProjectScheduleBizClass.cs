using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
/// <summary>
/// /// ShanuProjectScheduleBizClass
/// Author      : Shanu
/// Create date : 2014-11-24
/// Description : ASP.Net Grid View
/// Latest
/// Modifier    : Shanu
/// Modify date :2014-11-24
/// </summary>

public class ShanuProjectScheduleBizClass : BizBase
{
	public ShanuProjectScheduleBizClass()
	{}


    //to return the dataset
    public DataSet SelectList(SortedDictionary<string, string> sd)
    {
        try
        {
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "usp_ProjectSchedule", GetSdParameter(sd));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    //Schedul;e with Shedule End Date check Status to return the dataset
    public DataSet SelectList_endDate(SortedDictionary<string, string> sd)
    {
        try
        {
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "usp_ProjectSchedule_FNStatus", GetSdParameter(sd));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //To Insert ,Update and Delete we can use the below procedure
}