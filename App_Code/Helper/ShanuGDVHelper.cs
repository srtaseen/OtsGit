using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/// <summary>
/// Author      : Shanu
/// Create date : 2014-11-24
/// Description : ASP.Net Grid View
/// Latest
/// Modifier    : Shanu
/// Modify date :2014-11-24
/// </summary>
public class ShanuGDVHelper
{
	public ShanuGDVHelper()
	{}

    //Set all the telerik Grid layout
    #region Layout
    public static void Layouts(GridView grid, int height, int width, Boolean widthtype, Boolean allowpaging, Boolean allowsorting, Boolean ShowHeader, Boolean ShowFooter)
    {
        grid.AutoGenerateColumns = false; // set the auto genrated columns as false           
        grid.AllowSorting = allowsorting; // Set Sorting for a grid
        grid.HeaderStyle.Wrap = false;
        grid.GridLines = GridLines.Both;
        grid.AllowPaging = allowpaging;
        //grid.HeaderStyle.CssClass = "locked";
        //grid.HeaderStyle.CssClass = "GridviewScrollHeader";
        //grid.RowStyle.CssClass = "GridviewScrollItem";
        //grid.PagerStyle.CssClass = "GridviewScrollPager";
        grid.HeaderStyle.BackColor = System.Drawing.Color.SteelBlue;
        grid.HeaderStyle.ForeColor = System.Drawing.Color.White;
        grid.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
        grid.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EFF4F5"); 
        grid.BorderColor = System.Drawing.ColorTranslator.FromHtml("#006699");
        grid.BorderStyle = BorderStyle.Solid;
        grid.BorderWidth = 1;

        grid.Height = height; //Set the height of the grid  in % or in pixcel
        if (width > 0)
        {
            if (widthtype == false)
            {
                grid.Width = width; // set the Width of the grid  in % or in pixcel
            }
            else
            {
                grid.Width = Unit.Percentage(width);
            }
        }
        grid.ShowHeader = ShowHeader; // show header of the grid true or false
        grid.ShowFooter = ShowFooter; // show header of the grid true or false
    }

    #endregion
    #region DataBind
    public static void DataBinds(GridView grid, DataTable dataTable, Boolean needdatasource)
    {


        grid.DataSource = dataTable;
        grid.DataBind();
    }
    public static void DataBinds(GridView grid, DataSet dataSet, Boolean needdatasource)
    {
        DataBinds(grid, dataSet.Tables[0], needdatasource);
    }
    #endregion

    #region gridColumnType
    //Bound column is used to display the data 
    #region BoundColumn
    public static void BoundColumnFormat(GridView grid, String HeaderText, String datafield,  HorizontalAlign Alignment, int Width, String Aggregate, String FooterText, Boolean AllowFiltering, Boolean colDisplay, VerticalAlign verticalAlignment, HorizontalAlign itemAlignment)
    {
        BoundField boundColumn;
        boundColumn = new BoundField();
        boundColumn.DataField = datafield;
        boundColumn.HeaderText = HeaderText;
        boundColumn.HeaderStyle.HorizontalAlign = Alignment;
        boundColumn.HeaderStyle.VerticalAlign = verticalAlignment;
        boundColumn.ItemStyle.HorizontalAlign = itemAlignment;
        boundColumn.Visible = colDisplay;       // changed by Ferdousi
        //boundColumn.
        if (Width > 0)
        {
            boundColumn.HeaderStyle.Width = Width;
            boundColumn.ItemStyle.Width = Width;
        }

        grid.Columns.Add(boundColumn);
    }
    #endregion

    //Template Column In this column we can add Textbox,Lable,Check Box,Dropdown box,LinkButton,button,Image Button,numeric textbox and etc
    #region Templatecolumn

    public static void Templatecolumn(GridView grid, String HeaderText, String datafield, HorizontalAlign Alignment, int Width, GDVControlType gridColumntype, String FooterText,  Boolean colDisplay, VerticalAlign verticalAlignment, HorizontalAlign itemAlignment)
    {
      
        TemplateField templateColumn;
        templateColumn = new TemplateField();
        templateColumn.HeaderTemplate = new GridViewTemplateColumn(ListItemType.Header, HeaderText);
        templateColumn.ItemTemplate = new GridViewTemplateColumn(ListItemType.Item, HeaderText);
        templateColumn.HeaderText = HeaderText;
        templateColumn.HeaderStyle.HorizontalAlign = Alignment;
        templateColumn.HeaderStyle.VerticalAlign = verticalAlignment;
        templateColumn.ItemStyle.HorizontalAlign = itemAlignment;
        if (Width > 0)
        {
            templateColumn.HeaderStyle.Width = Width;
            templateColumn.ItemStyle.Width = Width;
        }


        grid.Columns.Add(templateColumn);
    }
    #endregion

    #endregion
}
//This class is created to bind the controls to the Template Columns here in our example now we are using only the Placeholdre user can change it to your requirements

public class GridViewTemplateColumn : ITemplate
{
    ListItemType templateItemType;
    string DataFieldName;

    //Constructor where we define the template type and column name.

    public GridViewTemplateColumn(ListItemType type, string DataFieldNames)
    {
        //Stores the template type.
        templateItemType = type;
        //Stores the column name.
        DataFieldName = DataFieldNames;

    }

    void ITemplate.InstantiateIn(System.Web.UI.Control container)
    {
        switch (templateItemType)
        {
            case ListItemType.Header:
                Label lbl = new Label();      
                lbl.Text = DataFieldName;  
                container.Controls.Add(lbl); 
                break;

            case ListItemType.Item:

                //Creates a new text box control and add it to the container.

                PlaceHolder plcHolder = new PlaceHolder();

                plcHolder.DataBinding += new EventHandler(plcHolder_DataBinding); 

                // tb1.Columns = 4;      

                container.Controls.Add(plcHolder);  

                break;

            case ListItemType.EditItem:
             //...
                break;
                
            case ListItemType.Footer:
               //...
                break;

        }

    }

    void plcHolder_DataBinding(object sender, EventArgs e)
    {

        PlaceHolder txtdata = (PlaceHolder)sender;
        GridViewRow container = (GridViewRow)txtdata.NamingContainer;
        object dataValue = DataBinder.Eval(container.DataItem, DataFieldName);
        object dataValue1 = DataBinder.Eval(container.DataItem, "viewtype");  // here I have used this column as static user can change this to work with your program .here i have used this to check for Project type status and load the images
        object dataValue2 = DataBinder.Eval(container.DataItem, "Status");        // Changes done by Srila

        Image img = new Image();
        if (Convert.ToInt32(dataValue) == 1)
        {
            img.ImageUrl = GetImage(dataValue1.ToString(), int.Parse(dataValue2.ToString()));
        }
        else if (Convert.ToInt32(dataValue) == 2)
        {
            img.ImageUrl = GetImage_ScdEnd(dataValue1.ToString());
        }
        else
        {
            img.ImageUrl = "~/Images/blanks.jpg";
        }
        
        img.Style["float"] = "center";
        txtdata.Controls.Add(img);

    }

    private string GetImage(string value, int missed)           // Changes done by Ferdousi
    {
        if (value == "1-Scd")
        {
            return "~/Images/green_new1.jpg";
        }
        else if (value == "2-Act" && missed==0)
        {
            return "~/Images/blue_new1.jpg";
        }
        else
        {
            return "~/Images/red_new1.jpg";
        }
    }

    private string GetImage_ScdEnd(string value)
    {
        if (value == "1-Scd")
        {
            return "~/Images/star_red.png";
        }
        else if (value == "2-Act")
        {
            return "~/Images/star_Violet.png";
        }
        else
        {
            return "~/Images/star_green.png";
        }
    }

}

public enum GDVControlType { TextBox, ComboBox, CheckBox, LinkButton, SearchTextBox, placeholder, NumericTextBox, RadDatePicker, Label, None, DIV, Image }
