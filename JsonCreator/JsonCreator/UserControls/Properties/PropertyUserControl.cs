using JsonCreator.PropertyModels;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JsonCreator.UserControls
{
    public class PropertyUserControl : UserControl
    {
        public Property property;

        public enum VisibilityTypes
        {
            childrenVisibility,
            uniqueVisibility,
            dimetnionVisibility
        }

        public Dictionary<VisibilityTypes, bool> visibilityChecks = new Dictionary<VisibilityTypes, bool>() { { VisibilityTypes.childrenVisibility, true }, { VisibilityTypes.uniqueVisibility, true }, { VisibilityTypes.dimetnionVisibility, true } };

        public void setVisibility()
        {
            bool visible = true;
            foreach (KeyValuePair<VisibilityTypes, bool> visibilityCheck in visibilityChecks)
                visible &= visibilityCheck.Value;

            if (visible)
                Show();
            else
                Hide();
        }

        protected void ShowToolTip(Control uc, string text)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip = new ToolTip
            {
                // Set up the delays for the ToolTip.
                InitialDelay = 1,
                ReshowDelay = 5,
                // Force the ToolTip text to be displayed whether or not the form is active.
                ShowAlways = true,
                IsBalloon = true
            };

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip.SetToolTip(uc, text);
        }

        protected void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
                e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            // only allow one minus symbol
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
                e.Handled = true;
        }
    }
}
