
namespace JsonCreator
{
    partial class CategoryUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CategoryFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.XButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.BlackPanel = new System.Windows.Forms.Panel();
            this.CategoryTitleLabel = new System.Windows.Forms.Label();
            this.ResizeTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CategoryFlowLayoutPanel
            // 
            this.CategoryFlowLayoutPanel.AutoSize = true;
            this.CategoryFlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.CategoryFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CategoryFlowLayoutPanel.Location = new System.Drawing.Point(0, 119);
            this.CategoryFlowLayoutPanel.Name = "CategoryFlowLayoutPanel";
            this.CategoryFlowLayoutPanel.Size = new System.Drawing.Size(586, 0);
            this.CategoryFlowLayoutPanel.TabIndex = 0;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.BackColor = System.Drawing.Color.White;
            this.TitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleTextBox.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TitleTextBox.Location = new System.Drawing.Point(0, 89);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(586, 30);
            this.TitleTextBox.TabIndex = 3;
            this.TitleTextBox.Text = "MyObject";
            this.TitleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.AddButton.ForeColor = System.Drawing.Color.Firebrick;
            this.AddButton.Location = new System.Drawing.Point(0, 408);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(586, 36);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "ADD ANOTHER OBJECT";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // XButton
            // 
            this.XButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XButton.BackColor = System.Drawing.Color.Red;
            this.XButton.Font = new System.Drawing.Font("Arial Black", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.XButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.XButton.Location = new System.Drawing.Point(538, 33);
            this.XButton.Name = "XButton";
            this.XButton.Size = new System.Drawing.Size(22, 22);
            this.XButton.TabIndex = 5;
            this.XButton.Text = "X";
            this.XButton.UseVisualStyleBackColor = false;
            this.XButton.Click += new System.EventHandler(this.XButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLabel.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.TitleLabel.Location = new System.Drawing.Point(0, 65);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(586, 24);
            this.TitleLabel.TabIndex = 6;
            this.TitleLabel.Text = "Object Name";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BlackPanel
            // 
            this.BlackPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BlackPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BlackPanel.Location = new System.Drawing.Point(0, 0);
            this.BlackPanel.Name = "BlackPanel";
            this.BlackPanel.Size = new System.Drawing.Size(586, 20);
            this.BlackPanel.TabIndex = 2;
            // 
            // CategoryTitleLabel
            // 
            this.CategoryTitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(54)))));
            this.CategoryTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CategoryTitleLabel.Font = new System.Drawing.Font("Nirmala UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.CategoryTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.CategoryTitleLabel.Location = new System.Drawing.Point(0, 20);
            this.CategoryTitleLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.CategoryTitleLabel.Name = "CategoryTitleLabel";
            this.CategoryTitleLabel.Size = new System.Drawing.Size(586, 45);
            this.CategoryTitleLabel.TabIndex = 7;
            this.CategoryTitleLabel.Text = "Model #1";
            this.CategoryTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResizeTimer
            // 
            this.ResizeTimer.Enabled = true;
            this.ResizeTimer.Interval = 1000;
            this.ResizeTimer.Tick += new System.EventHandler(this.ResizeTimer_Tick);
            // 
            // CategoryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.XButton);
            this.Controls.Add(this.CategoryFlowLayoutPanel);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CategoryTitleLabel);
            this.Controls.Add(this.BlackPanel);
            this.Name = "CategoryUserControl";
            this.Size = new System.Drawing.Size(586, 444);
            this.Resize += new System.EventHandler(this.Category_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel CategoryFlowLayoutPanel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button XButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Panel BlackPanel;
        private System.Windows.Forms.Label CategoryTitleLabel;
        private System.Windows.Forms.Timer ResizeTimer;
    }
}
