using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;

namespace idsp2025_jared_green.Forms.CustomControls
{
    public class DataGridViewNumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        private bool valueChanged = false;
        DataGridView dataGridView;
        int rowIndex;

        public DataGridViewNumericUpDownEditingControl()
        {
            this.TabStop = false;
        }

        public DataGridView? EditingControlDataGridView 
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }
        public object EditingControlFormattedValue
        {
            get
            {
                // Always return a string representation of the value
                return this.Value.ToString();
            }
            set
            {
                if (value is string stringValue)
                {
                    if (decimal.TryParse(stringValue, out decimal result))
                    {
                        this.Value = result; // Convert and assign
                                             // EnsureIsMultipleOfIncrement();
                        this.Refresh();
                    }
                    else
                    {
                        this.Value = this.Minimum; // Fallback to minimum if parsing fails
                    }
                }
                else if (value is decimal || value is int)
                {
                    this.Value = Convert.ToDecimal(value); // Assign directly if numeric
                    // EnsureIsMultipleOfIncrement();
                }
                else
                {
                    this.Value = this.Minimum; // Fallback for unexpected types
                }
            }
        }

        public int EditingControlRowIndex 
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        public bool EditingControlValueChanged 
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;

                case Keys.Enter:
                case Keys.Tab:
                case Keys.Shift:
                case Keys.Escape:
                    return false;

                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation right now.
            this.Select(0,0);
        }

        /* 
         * Often an editing control must override protected virtual methods to be notified of the content 
         * changes and be able to forward the information to the grid. In this particular case, 
         * the DataGridViewNumericUpDownEditingControl overrides two methods: 
         */

        // This method detects when a user types inside the control.
        // It notifies the DataGridView that the value is changing.
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }

        // This method is triggered when the NumericUpDown value changes.
        // It notifies the DataGridView to commit the new value.
        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Select(0, this.Text.Length); 
        }

        protected override void OnValidated(EventArgs e)
        {
            EnsureIsMultipleOfIncrement();
            if (this.EditingControlDataGridView != null)
            {
                this.EditingControlDataGridView.CurrentCell.Value = this.Value;
            }
            base.OnValidated(e);
        }

        private void EnsureIsMultipleOfIncrement()
        {
            if (this.Increment > 0)
            {
                decimal remainder = this.Value % this.Increment;
                if (remainder != 0)
                {
                    this.Value -= remainder;
                    this.Text = this.Value.ToString();
                    this.EditingControlFormattedValue = this.Text;
                    this.EditingControlDataGridView?.NotifyCurrentCellDirty(true);
                }
            }
        }

        // Property Explanations:

        /*
         // Property which caches the grid that uses this editing control
            public virtual DataGridView EditingControlDataGridView

            // Property which represents the current formatted value of the editing control
            public virtual object EditingControlFormattedValue

            // Property which represents the row in which the editing control resides
            public virtual int EditingControlRowIndex

            // Property which indicates whether the value of the editing control has changed or not
            public virtual bool EditingControlValueChanged

            // Property which determines which cursor must be used for the editing panel, 
            i.e. the parent of the editing control.
            public virtual Cursor EditingPanelCursor

            // Property which indicates whether the editing control needs to be repositioned when its value changes.
            public virtual bool RepositionEditingControlOnValueChange

            // Method called by the grid before the editing control is shown so it can adapt to the provided cell style.
            public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)

            // Method called by the grid on keystrokes to determine if the editing control is interested in the key or not.
            public virtual bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)

            // Returns the current value of the editing control.
            public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)

            // Called by the grid to give the editing control a chance to prepare itself for the editing session.
            public virtual void PrepareEditingControlForEdit(bool selectAll)
        */
    }
}
