using JsonCreator.PropertyModels;
using System;
using System.Windows.Forms;
using static JsonCreator.SceneProperties;

namespace JsonCreator.UserControls
{
    public partial class ComboPropertyUserControl : PropertyUserControl
    {
        ComboProperty comboProperty;

        public ComboPropertyUserControl(ComboProperty comboProperty)
        {
            InitializeComponent();

            this.comboProperty = comboProperty;
            property = comboProperty;

            InitializePropertyControls();
        }

        void InitializePropertyControls()
        {
            TitleLabel.Text = comboProperty.title;
            foreach (string value in comboProperty.optionValues)
            {
                ComboBox.Items.Add(value);
            }
            if (!comboProperty.unique)
                ComboBox.SelectedItem = ComboBox.Items[0];
            else
                ComboBox.SelectedItem = ComboBox.Items[1];
            ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            ShowToolTip(TitleLabel, comboProperty.description);
            ShowToolTip(ComboBox, comboProperty.description);
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        public ControlCollection getItems()
        {
            return Controls;
        }

        public Label getTitle()
        {
            return TitleLabel;
        }
        public ComboBox getComboBox()
        {
            return ComboBox;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditPropertiesVisibility();
        }

        void EditPropertiesVisibility()
        {
            if (Parent != null)
            {
                EditPropertyChildrenVisibility();
                EditOtherPropertiesVisibilityIfUnique();
                EditPropertiesVisibilityByDimension();

                SetVisibility();
            }
        }

        public void SetVisibility()
        {
            if (Parent.Parent.Parent != null)
            {
                foreach (CategoryUserControl categoryUserControl in Parent.Parent.Parent.Controls)
                {
                    foreach (PropertyUserControl propertyUserControl in categoryUserControl.getFlowLayoutPanel().Controls)
                        if (propertyUserControl != this)
                            propertyUserControl.setVisibility();

                    //categoryUserControl.Height = 0;
                }
            }
        }

        void EditPropertyChildrenVisibility()
        {
            if (comboProperty.children != null && comboProperty.children.Count > 0)
                foreach (PropertyUserControl propertyUserControl in ((CategoryUserControl)Parent.Parent).getFlowLayoutPanel().Controls)
                    if (propertyUserControl != this)
                        if (comboProperty.children.Contains(propertyUserControl.property.name))
                            if (ComboBox.SelectedIndex == 1)
                                propertyUserControl.visibilityChecks[VisibilityTypes.childrenVisibility] = false;
                            else
                                propertyUserControl.visibilityChecks[VisibilityTypes.childrenVisibility] = true;
        }

        void EditOtherPropertiesVisibilityIfUnique()
        {
            if (comboProperty.unique)
                foreach (CategoryUserControl categoryUserControl in Parent.Parent.Parent.Controls)
                    foreach (PropertyUserControl propertyUserControl in categoryUserControl.getFlowLayoutPanel().Controls)
                        if (propertyUserControl != this && propertyUserControl.property.name == property.name)
                            if (ComboBox.SelectedIndex == 0)
                            {
                                propertyUserControl.visibilityChecks[VisibilityTypes.uniqueVisibility] = false;
                            }
                            else
                                propertyUserControl.visibilityChecks[VisibilityTypes.uniqueVisibility] = true;
        }

        public void EditPropertiesVisibilityByDimension()
        {
            if (property.name == PropertyNames.dimension)
                foreach (CategoryUserControl categoryUserControl in Parent.Parent.Parent.Controls)
                    foreach (PropertyUserControl propertyUserControl in categoryUserControl.getFlowLayoutPanel().Controls)
                        if (propertyUserControl != this)
                            if (propertyUserControl.property.dimension.ToString() == "both" || propertyUserControl.property.dimension.ToString() == "_" + ComboBox.Text.ToLower())
                                propertyUserControl.visibilityChecks[VisibilityTypes.dimetnionVisibility] = true;
                            else
                                propertyUserControl.visibilityChecks[VisibilityTypes.dimetnionVisibility] = false;
        }

        private void ComboBoxProperty_VisibleChanged(object sender, EventArgs e)
        {
            EditPropertyChildrenVisibility();
            SetVisibility();
        }

        private void EditPropertiesVisibilityTimer_Tick(object sender, EventArgs e)
        {
            EditPropertiesVisibilityByDimension();
            EditPropertyChildrenVisibility();
            SetVisibility();
        }
    }
}
