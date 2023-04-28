using JsonCreator.PropertyModels;
using System.Windows.Forms;

namespace JsonCreator.UserControls
{
    public partial class VectorPropertyUserControl : PropertyUserControl
    {
        private VectorProperty vectorProperty;

        public VectorPropertyUserControl(VectorProperty vectorProperty)
        {
            InitializeComponent();

            this.vectorProperty = vectorProperty;
            property = vectorProperty;

            InitializePropertyControls();
        }

        void InitializePropertyControls()
        {
            TitleLabel.Text = vectorProperty.title;
            xTextBox.Text = vectorProperty.values.x.ToString();
            yTextBox.Text = vectorProperty.values.y.ToString();
            zTextBox.Text = vectorProperty.values.z.ToString();
            ShowToolTip(TitleLabel, vectorProperty.description);
            ShowToolTip(xTextBox, vectorProperty.description);
            ShowToolTip(yTextBox, vectorProperty.description);
            ShowToolTip(zTextBox, vectorProperty.description);
            xTextBox.KeyPress += TextBox_KeyPress;
            yTextBox.KeyPress += TextBox_KeyPress;
            xTextBox.KeyPress += TextBox_KeyPress;
        }

        public Label getTitle()
        {
            return TitleLabel;
        }
        public Label getxLabel()
        {
            return xLabel;
        }
        public TextBox getxTextBox()
        {
            return xTextBox;
        }
        public Label getyLabel()
        {
            return yLabel;
        }
        public TextBox getyTextBox()
        {
            return yTextBox;
        }
        public Label getzLabel()
        {
            return zLabel;
        }
        public TextBox getzTextBox()
        {
            return zTextBox;
        }
    }
}
