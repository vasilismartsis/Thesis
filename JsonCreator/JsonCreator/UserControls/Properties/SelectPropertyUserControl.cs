using JsonCreator.PropertyModels;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Forms;

namespace JsonCreator.UserControls
{
    public partial class SelectPropertyUserControl : PropertyUserControl
    {
        private SelectProperty selectProperty;

        public SelectPropertyUserControl(SelectProperty selectProperty)
        {
            InitializeComponent();

            this.selectProperty = selectProperty;
            property = selectProperty;

            InitializePropertyControls();
        }

        void InitializePropertyControls()
        {
            TitleLabel.Text = selectProperty.title;
            ChooseButton.Text = selectProperty.buttonName;

            ShowToolTip(TitleLabel, selectProperty.description);
            ShowToolTip(TextBox, selectProperty.description);
        }

        public Label getTitle()
        {
            return TitleLabel;
        }

        public TextBox getTextBox()
        {
            return TextBox;
        }

        public Button getButton()
        {
            return ChooseButton;
        }

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            if (selectProperty.selectType == SelectProperty.SelectType.file)
            {
                string filterString = "Model files (";
                foreach (SelectProperty.FileFilter fileFilter in selectProperty.fileFilters)
                {
                    filterString += "*." + fileFilter.ToString() + ";";
                }
                filterString += ")|";
                foreach (SelectProperty.FileFilter fileFilter in selectProperty.fileFilters)
                {
                    filterString += "*." + fileFilter.ToString() + ";";
                }

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = filterString.Remove(filterString.Length - 1, 1),
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = "",
                    Title = selectProperty.title,
                    CheckFileExists = true,
                    CheckPathExists = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    TextBox.Text = openFileDialog.FileName;
            }
            else
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                dialog.EnsureFileExists = true;
                dialog.EnsurePathExists = true;
                dialog.Title = selectProperty.title;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                    TextBox.Text = dialog.FileName;
            }
        }
    }
}
