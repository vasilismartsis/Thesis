
namespace JsonCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CategoriesPanel = new System.Windows.Forms.Panel();
            this.CreateGamePackageButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CategoriesPanel
            // 
            this.CategoriesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoriesPanel.AutoScroll = true;
            this.CategoriesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CategoriesPanel.Location = new System.Drawing.Point(12, 88);
            this.CategoriesPanel.Name = "CategoriesPanel";
            this.CategoriesPanel.Size = new System.Drawing.Size(610, 326);
            this.CategoriesPanel.TabIndex = 1;
            // 
            // CreateGamePackageButton
            // 
            this.CreateGamePackageButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CreateGamePackageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.CreateGamePackageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.CreateGamePackageButton.ForeColor = System.Drawing.Color.Maroon;
            this.CreateGamePackageButton.Location = new System.Drawing.Point(172, 28);
            this.CreateGamePackageButton.Name = "CreateGamePackageButton";
            this.CreateGamePackageButton.Size = new System.Drawing.Size(291, 34);
            this.CreateGamePackageButton.TabIndex = 2;
            this.CreateGamePackageButton.Text = "Create Your Unity Package";
            this.CreateGamePackageButton.UseVisualStyleBackColor = true;
            this.CreateGamePackageButton.Click += new System.EventHandler(this.CreateGamePackageButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.BackColor = System.Drawing.Color.Red;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.White;
            this.ErrorLabel.Location = new System.Drawing.Point(216, 65);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(206, 17);
            this.ErrorLabel.TabIndex = 3;
            this.ErrorLabel.Text = "Some inputs are left empty!";
            this.ErrorLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(634, 426);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.CreateGamePackageButton);
            this.Controls.Add(this.CategoriesPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel CategoriesPanel;
        private System.Windows.Forms.Button CreateGamePackageButton;
        private System.Windows.Forms.Label ErrorLabel;
    }
}

