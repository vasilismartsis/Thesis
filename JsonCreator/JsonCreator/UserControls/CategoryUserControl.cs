using JsonCreator.PropertyModels;
using JsonCreator.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JsonCreator
{
    public partial class CategoryUserControl : UserControl
    {
        public bool isProjectPropertiesCategory;

        public CategoryUserControl(bool isProjectPropertiesCategory = false)
        {
            InitializeComponent();

            this.isProjectPropertiesCategory = isProjectPropertiesCategory;

            InitializeCategoryControls();
            LoadPropertiesControls();
        }

        void InitializeCategoryControls()
        {
            if (isProjectPropertiesCategory)
            {
                CategoryTitleLabel.Text = "Project Properties";
                TitleLabel.Visible = false;
                TitleTextBox.Visible = false;
                BlackPanel.Visible = false;
                Controls.Remove(XButton);
                Controls.Remove(AddButton);
            }
            else
            {
                TitleLabel.Text = "Model Name";
                TitleTextBox.Text = "MyObject" + new Random().Next(0, 1000);
                ShowToolTip(TitleTextBox, "The name of the final object");
            }
        }

        void LoadPropertiesControls()
        {
            List<Property> properties;
            if (isProjectPropertiesCategory)
                properties = SceneProperties.getProjectProperties();
            else
                properties = SceneProperties.getModelProperties();

            foreach (Property property in properties)
            {
                PropertyUserControl puc;

                if (property.GetType() == typeof(ComboProperty))
                    puc = new ComboPropertyUserControl((ComboProperty)property);
                else if (property.GetType() == typeof(TextProperty))
                    puc = new TextPropertyUserControl((TextProperty)property);
                else if (property.GetType() == typeof(VectorProperty))
                    puc = new VectorPropertyUserControl((VectorProperty)property);
                else
                    puc = new SelectPropertyUserControl((SelectProperty)property);

                CategoryFlowLayoutPanel.Controls.Add(puc);
            }
        }

        void ShowToolTip(Control uc, string text)
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = (MainForm)ParentForm;
            mainForm.AddCategory();
        }

        private void XButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = (MainForm)ParentForm;
            mainForm.RemoveCategory(this);
        }

        public FlowLayoutPanel getFlowLayoutPanel()
        {
            return CategoryFlowLayoutPanel;
        }

        public Label getCategoryTitleLabel()
        {
            return CategoryTitleLabel;
        }

        public Label getTitle()
        {
            return TitleLabel;
        }

        public TextBox getTextBox()
        {
            return TitleTextBox;
        }

        public void Category_Resize(object sender, EventArgs e)
        {
            //Width = Parent.Width;
            if (!isProjectPropertiesCategory)
                Height = CategoryFlowLayoutPanel.Height + 163;
            else
                Height = CategoryFlowLayoutPanel.Height + 52;
            //CategoryFlowLayoutPanel.Location = new Point(0, 72);
            //CategoryFlowLayoutPanel.Height = 0;
            //CategoryFlowLayoutPanel.Width = Width;
        }

        private void ResizeTimer_Tick(object sender, EventArgs e)
        {
            Category_Resize(sender, e);
        }
    }
}
