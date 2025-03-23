using idsp2025_jared_green.Forms.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;

public class DataGridViewNumericUpDownCell : DataGridViewTextBoxCell
{
    private int decimalPlaces;
    private static Type defaultEditType = typeof(DataGridViewNumericUpDownEditingControl);
    private static Type defaultValueType = typeof(System.Decimal);
    private int increment;
    private int minimum;
    private int maximum;
    private bool thousandsSeparator;
    // Will resize dynamically in the paint method when needed.
    // private static Bitmap renderingBitmap = new Bitmap(1, 1);
    private static readonly NumericUpDown paintingNumericUpDown = new NumericUpDown();


    [DllImport("user32.dll")]
    public static extern short VkKeyScan(char ch);

    public DataGridViewNumericUpDownCell()
    {
        this.increment = 1;
        this.minimum = 0;
        this.maximum = 10000;
        this.decimalPlaces = 0;
        this.thousandsSeparator = false;
    }

    [DefaultValue(1)]
    public int Increment
    {
        get { return increment; }
        set 
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The increment must be greater than 0.");
            }
            if (increment != value) 
            {
                SetIncrement(this.RowIndex, value);
                RefreshCellUI();
            }
        }
    }

    internal void SetIncrement(int rowIndex, int value)
    {
        this.increment = value;
        if (OwnsEditingNumericUpDown(rowIndex))
        {
            this.EditingNumericUpDown.Increment = Convert.ToDecimal(value);
        }
    }


    [DefaultValue(0)]
    public int Minimum
    {
        get { return minimum; }
        set 
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentOutOfRangeException("The minimum property cannot be smaller than 0 or larger than 10000.");
            }
            if (minimum != value)
            {
                SetMinimum(this.RowIndex, value);
                // Assure that the cell or column gets repainted and auto sized if needed
                RefreshCellUI();
            }
        }
    }

    [DefaultValue(0)]
    internal void SetMinimum(int rowIndex, int value)
    {
        this.minimum = value;
        if (OwnsEditingNumericUpDown(rowIndex))
        {
            this.EditingNumericUpDown.Minimum = Convert.ToDecimal(value);
        }
    }

    [DefaultValue(10000)]
    public int Maximum
    {
        get { return maximum; }
        set
        {
            if (value < minimum)
            {
                throw new ArgumentOutOfRangeException("Maximum must be greater than or equal to Minimum.");
            }
            if (maximum != value)
            {
                maximum = value;
                if (DataGridView != null)
                {
                    foreach (DataGridViewRow row in DataGridView.Rows)
                    {
                        if (row.Cells[ColumnIndex] is DataGridViewNumericUpDownCell cell)
                        {
                            cell.SetMaximum(row.Index, value);
                        }
                    }
                    DataGridView.InvalidateColumn(ColumnIndex); // Ensure UI updates
                }
            }
        }
    }
    internal void SetMaximum(int rowIndex, int value)
    {
        this.maximum = value;
        if (OwnsEditingNumericUpDown(rowIndex))
        {
            this.EditingNumericUpDown.Maximum = Convert.ToDecimal(value);
        }
    }

    [DefaultValue(false)]
    public bool ThousandsSeparator
    {
        get { return thousandsSeparator; }
        set { }
    }

    internal void SetThousandsSeparator(int rowIndex, bool useSeparator)
    {
        this.thousandsSeparator = useSeparator;
        if (OwnsEditingNumericUpDown(rowIndex))
        {
            this.EditingNumericUpDown.ThousandsSeparator = useSeparator;
        }
    }

    [DefaultValue(0)]
    public int DecimalPlaces
    {
        get
        {
            return this.decimalPlaces;
        }

        set
        {
            if (value < 0 || value > 99)
            {
                throw new ArgumentOutOfRangeException("The DecimalPlaces property cannot be smaller than 0 or larger than 99.");
            }
            if (this.decimalPlaces != value)
            {
                SetDecimalPlaces(this.RowIndex, value);
                // Assure that the cell or column gets repainted and auto sized if needed
                RefreshCellUI();
            }
        }
    }

    private void RefreshCellUI()
    {
        if (DataGridView != null)
        {
            DataGridView.InvalidateCell(this); // Refresh the cell
            DataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells); // Optional: Resize
        }
    }

    // Checks if the DataGridView exists(to avoid null errors).
    // Ensures the rowIndex is valid(avoiding -1 errors).
    // Verifies that the editing control is active and matches the row being edited.
    internal void SetDecimalPlaces(int rowIndex, int value)
    {
        this.decimalPlaces = value;
        if (OwnsEditingNumericUpDown(rowIndex))
        {
            this.EditingNumericUpDown.DecimalPlaces = value;
        }
    }

    private bool OwnsEditingNumericUpDown(int rowIndex)
    {
        if (rowIndex == -1 || DataGridView == null)
            return false;

        NumericUpDown editingControl = DataGridView.EditingControl as NumericUpDown;

        return editingControl != null &&
               rowIndex == DataGridView.CurrentCellAddress.Y &&
               DataGridView.CurrentCellAddress.X == this.ColumnIndex;
    }

    // Retrieves the active editing control only if it is a NumericUpDownEditingControl.
    // Prevents crashes by returning null if no editing control is active.
    private DataGridViewNumericUpDownEditingControl EditingNumericUpDown
    {
        get
        {
            return DataGridView?.EditingControl as DataGridViewNumericUpDownEditingControl;
        }
    }

    public override Type EditType
    {
        get
        {
            return defaultEditType; // the type is DataGridViewNumericUpDownEditingControl
        }
    }

    public override Type ValueType
    {
        get
        {
            Type valueType = base.ValueType;
            if (valueType != null)
            {
                return valueType;
            }
            return defaultValueType;
        }
    }

    public override object Clone()
    {
        DataGridViewNumericUpDownCell dataGridViewCell = base.Clone() as DataGridViewNumericUpDownCell;
        if (dataGridViewCell != null)
        {
            dataGridViewCell.DecimalPlaces = this.DecimalPlaces;
            dataGridViewCell.Increment = this.Increment;
            dataGridViewCell.Maximum = this.Maximum;
            dataGridViewCell.Minimum = this.Minimum;
            dataGridViewCell.ThousandsSeparator = this.ThousandsSeparator;
        }
        return dataGridViewCell;
    }

    public override bool KeyEntersEditMode(KeyEventArgs e)
    {
        NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
        Keys negativeSignKey = Keys.None;
        string negativeSignStr = numberFormatInfo.NegativeSign;
        if (!string.IsNullOrEmpty(negativeSignStr) && negativeSignStr.Length == 1)
        {
            negativeSignKey = (Keys)(VkKeyScan(negativeSignStr[0]));
        }

        if ((char.IsDigit((char)e.KeyCode) ||
            (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
            negativeSignKey == e.KeyCode ||
            Keys.Subtract == e.KeyCode) &&
            !e.Shift && !e.Alt && !e.Control)
        {
            return true;
        }
        return false;
    }

    public override void InitializeEditingControl(int rowIndex,
        object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        NumericUpDown numericUpDown = this.DataGridView.EditingControl as NumericUpDown;
        if (numericUpDown != null)
        {
            numericUpDown.BorderStyle = BorderStyle.None;
            numericUpDown.DecimalPlaces = this.DecimalPlaces;
            numericUpDown.Increment = this.Increment;
            numericUpDown.Maximum = this.Maximum;
            numericUpDown.Minimum = this.Minimum;
            numericUpDown.ThousandsSeparator = this.ThousandsSeparator;
            string initialFormattedValueStr = initialFormattedValue as string;
            if (initialFormattedValueStr == null)
            {
                numericUpDown.Text = string.Empty;
            }
            else
            {
                numericUpDown.Text = initialFormattedValueStr;
            }
        }
    }

    private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds,
                    DataGridViewCellStyle cellStyle)
    {
        // Add a 1 pixel padding on the left and right of the editing control
        editingControlBounds.X += 1;
        editingControlBounds.Width = Math.Max(0, editingControlBounds.Width - 2);

        // Adjust the vertical location of the editing control:
        int preferredHeight = cellStyle.Font.Height + 3;
        if (preferredHeight < editingControlBounds.Height)
        {
            switch (cellStyle.Alignment)
            {
                case DataGridViewContentAlignment.MiddleLeft:
                case DataGridViewContentAlignment.MiddleCenter:
                case DataGridViewContentAlignment.MiddleRight:
                    editingControlBounds.Y += (editingControlBounds.Height - preferredHeight) / 2;
                    break;
                case DataGridViewContentAlignment.BottomLeft:
                case DataGridViewContentAlignment.BottomCenter:
                case DataGridViewContentAlignment.BottomRight:
                    editingControlBounds.Y += editingControlBounds.Height - preferredHeight;
                    break;
            }
        }
        return editingControlBounds;
    }

    public override void PositionEditingControl(bool setLocation,
                                                bool setSize,
                                                Rectangle cellBounds,
                                                Rectangle cellClip,
                                                DataGridViewCellStyle cellStyle,
                                                bool singleVerticalBorderAdded,
                                                bool singleHorizontalBorderAdded,
                                                bool isFirstDisplayedColumn,
                                                bool isFirstDisplayedRow)
    {
        Rectangle editingControlBounds = PositionEditingPanel(cellBounds,
                                                              cellClip,
                                                              cellStyle,
                                                              singleVerticalBorderAdded,
                                                              singleHorizontalBorderAdded,
                                                              isFirstDisplayedColumn,
                                                              isFirstDisplayedRow);
        editingControlBounds = GetAdjustedEditingControlBounds(editingControlBounds, cellStyle);
        this.DataGridView.EditingControl.Location = new Point(editingControlBounds.X, editingControlBounds.Y);
        this.DataGridView.EditingControl.Size = new Size(editingControlBounds.Width, editingControlBounds.Height);
    }

    [
    EditorBrowsable(EditorBrowsableState.Advanced)
    ]

    public override void DetachEditingControl()
    {
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView == null || dataGridView.EditingControl == null)
        {
            throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
        }

        NumericUpDown numericUpDown = dataGridView.EditingControl as NumericUpDown;
        if (numericUpDown != null)
        {
            // Editing controls get recycled. Indeed, when a DataGridViewNumericUpDownCell cell gets edited
            // after another DataGridViewNumericUpDownCell cell, the same editing control gets reused for 
            // performance reasons (to avoid an unnecessary control destruction and creation). 
            // Here the undo buffer of the TextBox inside the NumericUpDown control gets cleared to avoid
            // interferences between the editing sessions.
            TextBox textBox = numericUpDown.Controls[1] as TextBox;
            if (textBox != null)
            {
                textBox.ClearUndo();
            }
        }

        base.DetachEditingControl();
    }

    protected override Size GetPreferredSize(Graphics graphics,
               DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
    {
        if (this.DataGridView == null)
        {
            return new Size(-1, -1);
        }

        Size preferredSize = base.GetPreferredSize(graphics, cellStyle, rowIndex,
                   constraintSize);
        if (constraintSize.Width == 0)
        {
            const int ButtonsWidth = 16; // Account for the width of the up/down buttons.
            const int ButtonMargin = 8;  // Account for some blank pixels between the text and buttons.
            preferredSize.Width += ButtonsWidth + ButtonMargin;
        }
        return preferredSize;
    }

    protected override Rectangle GetErrorIconBounds(Graphics graphics,
                     DataGridViewCellStyle cellStyle, int rowIndex)
    {
        const int ButtonsWidth = 16;

        Rectangle errorIconBounds = base.GetErrorIconBounds(graphics, cellStyle, rowIndex);
        if (this.DataGridView.RightToLeft == RightToLeft.Yes)
        {
            errorIconBounds.X = errorIconBounds.Left + ButtonsWidth;
        }
        else
        {
            errorIconBounds.X = errorIconBounds.Left - ButtonsWidth;
        }
        return errorIconBounds;
    }

    protected override void Paint(Graphics graphics, Rectangle clipBounds,
                    Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
                              object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle,
                              DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
        if (this.DataGridView == null)
        {
            return;
        }

        // First paint the borders and background of the cell.
        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
                   formattedValue, errorText, cellStyle, advancedBorderStyle,
                   paintParts & ~(DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.ContentForeground));

        Point ptCurrentCell = this.DataGridView.CurrentCellAddress;
        bool cellCurrent = ptCurrentCell.X == this.ColumnIndex && ptCurrentCell.Y == rowIndex;
        bool cellEdited = cellCurrent && this.DataGridView.EditingControl != null;

        // If the cell is in editing mode, there is nothing else to paint
        if (!cellEdited)
        {
            if (PartPainted(paintParts, DataGridViewPaintParts.ContentForeground))
            {
                // Paint a NumericUpDown control
                // Take the borders into account
                Rectangle borderWidths = BorderWidths(advancedBorderStyle);
                Rectangle valBounds = cellBounds;
                valBounds.Offset(borderWidths.X, borderWidths.Y);
                valBounds.Width -= borderWidths.Right;
                valBounds.Height -= borderWidths.Bottom;
                // Also take the padding into account
                if (cellStyle.Padding != Padding.Empty)
                {
                    if (this.DataGridView.RightToLeft == RightToLeft.Yes)
                    {
                        valBounds.Offset(cellStyle.Padding.Right, cellStyle.Padding.Top);
                    }
                    else
                    {
                        valBounds.Offset(cellStyle.Padding.Left, cellStyle.Padding.Top);
                    }
                    valBounds.Width -= cellStyle.Padding.Horizontal;
                    valBounds.Height -= cellStyle.Padding.Vertical;
                }
                // Determine the NumericUpDown control location
                valBounds = GetAdjustedEditingControlBounds(valBounds, cellStyle);

                bool cellSelected = (cellState & DataGridViewElementStates.Selected) != 0;
                Bitmap renderingBitmap = new Bitmap(valBounds.Width, valBounds.Height);

                if (renderingBitmap.Width < valBounds.Width ||
                    renderingBitmap.Height < valBounds.Height)
                {
                    // The static bitmap is too small, a bigger one needs to be allocated.
                    renderingBitmap.Dispose();
                    renderingBitmap = new Bitmap(valBounds.Width, valBounds.Height);
                }
                // Make sure the NumericUpDown control is parented to a visible control
                if (paintingNumericUpDown.Parent == null || !paintingNumericUpDown.Parent.Visible)
                {
                    paintingNumericUpDown.Parent = this.DataGridView;
                }
                // Set all the relevant properties
                paintingNumericUpDown.TextAlign = TranslateAlignment(cellStyle.Alignment);
                paintingNumericUpDown.DecimalPlaces = this.DecimalPlaces;
                paintingNumericUpDown.ThousandsSeparator = this.ThousandsSeparator;
                paintingNumericUpDown.Font = cellStyle.Font;
                paintingNumericUpDown.Width = valBounds.Width;
                paintingNumericUpDown.Height = valBounds.Height;
                paintingNumericUpDown.RightToLeft = this.DataGridView.RightToLeft;
                paintingNumericUpDown.Location = new Point(0, -paintingNumericUpDown.Height - 100);
                paintingNumericUpDown.Maximum = this.Maximum;
                paintingNumericUpDown.Text = formattedValue as string;

                Color backColor;
                if (PartPainted(paintParts, DataGridViewPaintParts.SelectionBackground) && cellSelected)
                {
                    backColor = cellStyle.SelectionBackColor;
                }
                else
                {
                    backColor = cellStyle.BackColor;
                }
                if (PartPainted(paintParts, DataGridViewPaintParts.Background))
                {
                    if (backColor.A < 255)
                    {
                        // The NumericUpDown control does not support transparent back colors
                        backColor = Color.FromArgb(255, backColor);
                    }
                    paintingNumericUpDown.BackColor = backColor;
                }
                // Finally paint the NumericUpDown control
                Rectangle srcRect = new Rectangle(0, 0, valBounds.Width, valBounds.Height);
                if (srcRect.Width > 0 && srcRect.Height > 0)
                {
                    paintingNumericUpDown.DrawToBitmap(renderingBitmap, srcRect);
                    graphics.DrawImage(renderingBitmap, new Rectangle(valBounds.Location, valBounds.Size),
                                       srcRect, GraphicsUnit.Pixel);
                }
            }
            if (PartPainted(paintParts, DataGridViewPaintParts.ErrorIcon))
            {
                // Paint the potential error icon on top of the NumericUpDown control
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
                           value, formattedValue, errorText,
                           cellStyle, advancedBorderStyle, DataGridViewPaintParts.ErrorIcon);
            }
        }
    }

    private static HorizontalAlignment TranslateAlignment(DataGridViewContentAlignment align)
    {
        switch (align)
        {
            case DataGridViewContentAlignment.MiddleLeft:
            case DataGridViewContentAlignment.TopLeft:
            case DataGridViewContentAlignment.BottomLeft:
                return HorizontalAlignment.Left;

            case DataGridViewContentAlignment.MiddleCenter:
            case DataGridViewContentAlignment.TopCenter:
            case DataGridViewContentAlignment.BottomCenter:
                return HorizontalAlignment.Center;

            case DataGridViewContentAlignment.MiddleRight:
            case DataGridViewContentAlignment.TopRight:
            case DataGridViewContentAlignment.BottomRight:
                return HorizontalAlignment.Right;

            default:
                return HorizontalAlignment.Left; // Default fallback
        }
    }


    private bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
    {
        return (paintParts & paintPart) == paintPart;
    }


    public override string ToString()
    {
        string returnString = "";
        returnString += "DataGridViewNumericUpDownCell { ColumnIndex=" + ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex = " + RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
        return returnString;
    }

}

