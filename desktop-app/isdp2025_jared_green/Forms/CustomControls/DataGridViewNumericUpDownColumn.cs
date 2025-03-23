using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Forms.CustomControls
{
    using Azure;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel;
    using System.Diagnostics.Metrics;
    using System.Globalization;
    using System.Windows.Forms;

    public class DataGridViewNumericUpDownColumn : DataGridViewColumn
    {
        public DataGridViewNumericUpDownColumn() : base(new DataGridViewNumericUpDownCell())
        {
        }

        // The new DataGridViewNumericUpDownCell() passed to the base creates a new cell template. 
        // Adding a helper property allows me to retrieve the property to use below.
        private DataGridViewNumericUpDownCell NumericUpDownCellTemplate
        {
            get { return this.CellTemplate as DataGridViewNumericUpDownCell; }
        }

        [
            Category("Appearance"),
            DefaultValue(0),
            Description("Indicates the number of decimal places to display.")
        
        ]
        public int DecimalPlaces
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.DecimalPlaces;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                // Update the template cell so that subsequent cloned cells use the new value.
                this.NumericUpDownCellTemplate.DecimalPlaces = value;
                if (this.DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        DataGridViewNumericUpDownCell dataGridViewCell =
                                  dataGridViewRow.Cells[this.Index] as DataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the 
                            //property to avoid invalidation
                            // of each cell. The whole column is invalidated later in a single 
                            //          operation for better performance.
                    dataGridViewCell.SetDecimalPlaces(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);

                }
            }
        }

        // Returns a standard compact string representation of the column.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(100);
            sb.Append("DataGridViewNumericUpDownColumn { Name=");
            sb.Append(this.Name);
            sb.Append(", Index=");
            sb.Append(this.Index.ToString(CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }

        // MyDataGridView.OnGlobalColumnAutoSize implementation
        public void OnGlobalColumnAutoSize(int columnIndex)
        {
            if (this.DataGridView == null)
            {
                throw new InvalidOperationException("This column is not associated with a DataGridView.");
            }

            if (columnIndex < -1 || columnIndex >= this.DataGridView.Columns.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(columnIndex));
            }

            // Retrieve the column
            DataGridViewColumn column = this.DataGridView.Columns[columnIndex];

            // Force the column to refresh its default style
            column.DefaultCellStyle = new DataGridViewCellStyle(column.DefaultCellStyle);

            // Invalidate the column to apply the changes
            this.DataGridView.InvalidateColumn(columnIndex);
        }

        [
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                DataGridViewNumericUpDownCell dataGridViewNumericUpDownCell = value as DataGridViewNumericUpDownCell;
                if (value != null && dataGridViewNumericUpDownCell == null)
                {
                    throw new InvalidCastException("Value provided for CellTemplate must be of type DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell or derive from it.");
                }
                base.CellTemplate = value;
            }
        }
    }
}
