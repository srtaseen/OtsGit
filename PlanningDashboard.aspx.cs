using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PlanningDashboard : System.Web.UI.Page
{
    #region Variables
    //GridView Grid1 = new GridView();
    Boolean headerControl = false;
    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        //Grid1.Controls.Clear();
        //Grid1.ID = "Grid1";
        //this.divgrid.Controls.Add(Grid1);

        if (!IsPostBack)
        {
            SelectList();
        }
    }
    protected void Page_Init(object source, System.EventArgs e)
    {
        InitializeGridControl();
    }

    protected void InitializeGridControl()
    {

        ShanuGDVHelper.Layouts(Grid1, 25, 99, true, false, false, true, true);

        ShanuGDVHelper.BoundColumnFormat(Grid1, "Line No.", "ProjectName", HorizontalAlign.Left, 0, "", "", false, true, VerticalAlign.Middle, HorizontalAlign.Left);
        ShanuGDVHelper.BoundColumnFormat(Grid1, "View Type", "viewtype", HorizontalAlign.Left, 0, "", "", false, true, VerticalAlign.Middle, HorizontalAlign.Left);
        ShanuGDVHelper.BoundColumnFormat(Grid1, "PO No.", "ProjectType", HorizontalAlign.Left, 0, "", "", false, true, VerticalAlign.Middle, HorizontalAlign.Left);
        ShanuGDVHelper.BoundColumnFormat(Grid1, "Status", "Status", HorizontalAlign.Center, 0, "", "", false, false, VerticalAlign.Middle, HorizontalAlign.Left);     //Done by Ferdousi
        //CheckBox Column
        ////ShanuGDVHelper.Templatecolumn(Grid1, "", "chk", "chk", "", HorizontalAlign.Left, 20, false, TelerikControlType.CheckBox, "chkID", "", false, HorizontalAlign.Left, true);

        SortedDictionary<string, string> sd = new SortedDictionary<string, string>() { };
        //sd.Add("@projectId", txtProjectID.Text.Trim());

        DataSet ds = new DataSet();
        ds = new ShanuProjectScheduleBizClass().SelectList(sd);

        for (int i = 3; i < ds.Tables[0].Columns.Count; i++)
        {
            ShanuGDVHelper.Templatecolumn(Grid1, ds.Tables[0].Columns[i].ColumnName, ds.Tables[0].Columns[i].ColumnName, HorizontalAlign.Center, 0, GDVControlType.placeholder, "", true, VerticalAlign.Middle, HorizontalAlign.Left);
        }
        
        //grid events
        ////////Grid1.RowCommand+=new GridViewCommandEventHandler(Grid1_RowCommand);
        //////// Grid1.RowCreated+=new GridViewRowEventHandler(Grid1_RowCreated);
    }
    # endregion

    #region Method

    public void SelectList()
    {
        SortedDictionary<string, string> sd = new SortedDictionary<string, string>() { };
        sd.Add("@projectId", txtProjectID.Text.Trim());

        DataSet ds = new DataSet();
        ds = new ShanuProjectScheduleBizClass().SelectList(sd);

        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ShanuGDVHelper.DataBinds(Grid1, ds, false);
            }
        }


    }

    # endregion

    #region Events
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SelectList();
    }

    # endregion
}