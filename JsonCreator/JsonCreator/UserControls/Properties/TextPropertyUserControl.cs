using JsonCreator.PropertyModels;
using System.Windows.Forms;

namespace JsonCreator.UserControls
{
    public partial class TextPropertyUserControl : PropertyUserControl
    {
        private TextProperty textProperty;

        public TextPropertyUserControl(TextProperty textProperty)
        {
            InitializeComponent();

            this.textProperty = textProperty;
            property = textProperty;

            InitializePropertyControls();
        }

        void InitializePropertyControls()
        {
            TitleLabel.Text = textProperty.title;
            TextBox.Text = textProperty.value;
            ShowToolTip(TitleLabel, textProperty.description);
            ShowToolTip(TextBox, textProperty.description);
            if (textProperty.valueType == TextProperty.ValueType.numeric)
                TextBox.KeyPress += TextBox_KeyPress;
        }

        public Label getTitle()
        {
            return TitleLabel;
        }
        public TextBox getTextBox()
        {
            return TextBox;
        }
    }
}
