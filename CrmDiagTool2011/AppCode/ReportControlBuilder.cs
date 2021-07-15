using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace CrmDiagTool2011.AppCode
{
    /// <summary>
    /// This class helps to build HTML controls to be included in the report
    /// </summary>
    class ReportControlBuilder
    {
        /// <summary>
        /// Creates a header div and return the content div that follows the header one
        /// </summary>
        /// <param name="parentControl">Parent control</param>
        /// <param name="text">Header text</param>
        /// <returns>Content div</returns>
        internal HtmlGenericControl AddHeader(HtmlContainerControl parentControl, string text)
        {
            HtmlGenericControl headerControl = new HtmlGenericControl("div");
            headerControl.Attributes["class"] = "headerPart";

            HtmlGenericControl headerDescriptionControl = new HtmlGenericControl("div");
            headerDescriptionControl.InnerText = text;
            headerDescriptionControl.Attributes["class"] = "headerDescription";
            
            HtmlGenericControl contentControl = new HtmlGenericControl("div");
            contentControl.Attributes["class"] = "contentPart";

            parentControl.Controls.Add(headerControl);
            headerControl.Controls.Add(headerDescriptionControl);
            headerControl.Controls.Add(contentControl);
            parentControl.Controls.Add(new LiteralControl("<br/>"));
            
            return contentControl;
        }

        /// <summary>
        /// Create a header that looks like a tab text in a CRM 2011 form
        /// </summary>
        /// <param name="parentControl">Parent control</param>
        /// <param name="text">Header text</param>
        internal void AddTabHeader(HtmlContainerControl parentControl, string text)
        {
            parentControl.Controls.Add(new LiteralControl("<br/>"));

            HtmlGenericControl headerControl = new HtmlGenericControl("div");
            headerControl.InnerText = text;
            headerControl.Attributes["class"] = "headerTabPart";

            parentControl.Controls.Add(headerControl);
        }
        
        /// <summary>
        /// Create a header that looks like a section text in a CRM 2011 form
        /// </summary>
        /// <param name="parentControl">Parent control</param>
        /// <param name="text">Header text</param>
        internal void AddSectionHeader(HtmlContainerControl parentControl, string text)
        {
            parentControl.Controls.Add(new LiteralControl("<br/>"));

            HtmlGenericControl headerControl = new HtmlGenericControl("div");
            headerControl.InnerText = text;
            headerControl.Attributes["class"] = "headerSectionPart";
        
            parentControl.Controls.Add(headerControl);
        }

        /// <summary>
        /// Creates a HTML table in the specified control
        /// </summary>
        /// <param name="parentControl">Parent control</param>
        /// <param name="columns">Header columns text</param>
        /// <param name="values">Data values</param>
        internal void AddTable(HtmlContainerControl parentControl, string[] columns, Dictionary<string, string> values)
        {
            parentControl.Controls.Add(new LiteralControl("<br/>"));

            HtmlTable table = new HtmlTable();
            table.Attributes["class"] = "table";
            table.CellPadding = 0;
            table.CellSpacing = 0;

            HtmlTableRow headerRow = new HtmlTableRow();

            foreach (string column in columns)
            {
                HtmlTableCell cell = new HtmlTableCell();
                cell.Attributes["class"] = "headerRow";
                cell.InnerText = column;
                headerRow.Cells.Add(cell);
            }

            table.Rows.Add(headerRow);

            foreach (string key in values.Keys)
            {
                HtmlTableRow contentRow = new HtmlTableRow();
                
                HtmlTableCell cell1 = new HtmlTableCell();
                cell1.Attributes["class"] = "contentRow";
                cell1.InnerHtml = key;
                contentRow.Cells.Add(cell1);

                HtmlTableCell cell2 = new HtmlTableCell();
                cell2.Attributes["class"] = "contentRow";
                cell2.InnerHtml = values[key] != null && values[key].Length > 0 ? HttpUtility.HtmlEncode(values[key]).Replace("\r\n","<br/>") : "&nbsp;";
                contentRow.Cells.Add(cell2);

                table.Rows.Add(contentRow);
            }

            parentControl.Controls.Add(table);
            parentControl.Controls.Add(new LiteralControl("<br/>"));
        }

        /// <summary>
        /// Creates a HTML table in the specified control
        /// </summary>
        /// <param name="parentControl">Parent control</param>
        /// <param name="dataTable">Data values</param>
        internal void AddTable(HtmlContainerControl parentControl, DataTable dataTable)
        {
            parentControl.Controls.Add(new LiteralControl("<br/>"));

            HtmlTable table = new HtmlTable();
            table.Attributes["class"] = "table";
            table.CellPadding = 0;
            table.CellSpacing = 0;

            HtmlTableRow headerRow = new HtmlTableRow();

            foreach (DataColumn column in dataTable.Columns)
            {
                HtmlTableCell cell = new HtmlTableCell();
                cell.Attributes["class"] = "headerRow";
                cell.InnerHtml = column.ColumnName.Length > 0 ? column.ColumnName : "&nbsp;";
             
                headerRow.Cells.Add(cell);
            }

            table.Rows.Add(headerRow);

            foreach (DataRow row in dataTable.Rows)
            {
                HtmlTableRow contentRow = new HtmlTableRow();

                foreach (DataColumn column in dataTable.Columns)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    cell.Attributes["class"] = "contentRow";
                    cell.InnerHtml = row[column].ToString().Length > 0 ? HttpUtility.HtmlEncode(row[column].ToString()).Replace("\r\n","<br/>") : "&nbsp;";
                    contentRow.Cells.Add(cell);

                    table.Rows.Add(contentRow);
                }
            }

            parentControl.Controls.Add(table);
            parentControl.Controls.Add(new LiteralControl("<br/>"));
        }

        /// <summary>
        /// Creates a table in the specified control by transposing a single row 
        /// into values displayed in columns
        /// </summary>
        /// <param name="parentControl">Parent control</param>
        /// <param name="row">Data row</param>
        internal void AddTransposedTableRow(HtmlContainerControl parentControl, DataRow row)
        {
            parentControl.Controls.Add(new LiteralControl("<br/>"));

            HtmlTable table = new HtmlTable();
            table.Attributes["class"] = "table";
            table.CellPadding = 0;
            table.CellSpacing = 0;

            HtmlTableRow headerRow = new HtmlTableRow();

            HtmlTableCell cell = new HtmlTableCell();
            cell.Attributes["class"] = "headerRow";
            cell.InnerHtml = "Key";
            headerRow.Cells.Add(cell);

            cell = new HtmlTableCell();
            cell.Attributes["class"] = "headerRow";
            cell.InnerHtml = "Value";
            headerRow.Cells.Add(cell);

            table.Rows.Add(headerRow);

            foreach (DataColumn column in row.Table.Columns)
            {
                HtmlTableRow contentRow = new HtmlTableRow();

                cell = new HtmlTableCell();
                cell.Attributes["class"] = "contentRow";
                //cell.InnerHtml = row[column].ToString().Length > 0 ? HttpUtility.HtmlEncode(row[column].ToString()) : "&nbsp;";
                cell.InnerHtml = column.ColumnName;
                contentRow.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.Attributes["class"] = "contentRow";
                //cell.InnerHtml = row[column].ToString().Length > 0 ? HttpUtility.HtmlEncode(row[column].ToString()) : "&nbsp;";
                cell.InnerHtml = row[column.ColumnName] == null || row[column.ColumnName].ToString().Length == 0 ? "&nbsp;" : row[column.ColumnName].ToString();
                contentRow.Cells.Add(cell);

                table.Rows.Add(contentRow);
            }

            parentControl.Controls.Add(table);

            parentControl.Controls.Add(new LiteralControl("<br/>"));
        }

        /// <summary>
        /// Adds a single line of text in the specified control
        /// </summary>
        /// <param name="parentControl">Parent control</param>
        /// <param name="value">Text to add</param>
        internal void AddSingleLineOfText(HtmlContainerControl parentControl, string value)
        {
            parentControl.Controls.Add(new LiteralControl(value.Replace("\r\n","<br/>")));
            parentControl.Controls.Add(new LiteralControl("<br/>"));
            parentControl.Controls.Add(new LiteralControl("<br/>"));
        }
    }
}
