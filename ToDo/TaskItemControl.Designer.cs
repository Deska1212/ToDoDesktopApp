namespace ToDo
{
    partial class TaskItemControl
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
            this.TaskCheckBox = new System.Windows.Forms.CheckBox();
            this.TaskDeleteButton = new System.Windows.Forms.PictureBox();
            this.TaskNameBox = new System.Windows.Forms.TextBox();
            this.TaskDueDateBox = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDeleteButton)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskCheckBox
            // 
            this.TaskCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TaskCheckBox.AutoSize = true;
            this.TaskCheckBox.Location = new System.Drawing.Point(196, 22);
            this.TaskCheckBox.Name = "TaskCheckBox";
            this.TaskCheckBox.Size = new System.Drawing.Size(15, 14);
            this.TaskCheckBox.TabIndex = 3;
            this.TaskCheckBox.UseVisualStyleBackColor = true;
            // 
            // TaskDeleteButton
            // 
            this.TaskDeleteButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.TaskDeleteButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TaskDeleteButton.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.TaskDeleteButton.Location = new System.Drawing.Point(227, 3);
            this.TaskDeleteButton.Name = "TaskDeleteButton";
            this.TaskDeleteButton.Size = new System.Drawing.Size(18, 20);
            this.TaskDeleteButton.TabIndex = 4;
            this.TaskDeleteButton.TabStop = false;
            this.TaskDeleteButton.Click += new System.EventHandler(this.TaskDeleteButton_Click);
            // 
            // TaskNameBox
            // 
            this.TaskNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TaskNameBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TaskNameBox.Location = new System.Drawing.Point(9, 3);
            this.TaskNameBox.Name = "TaskNameBox";
            this.TaskNameBox.Size = new System.Drawing.Size(181, 20);
            this.TaskNameBox.TabIndex = 0;
            // 
            // TaskDueDateBox
            // 
            this.TaskDueDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TaskDueDateBox.Location = new System.Drawing.Point(9, 35);
            this.TaskDueDateBox.Name = "TaskDueDateBox";
            this.TaskDueDateBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TaskDueDateBox.Size = new System.Drawing.Size(181, 20);
            this.TaskDueDateBox.TabIndex = 2;
            // 
            // TaskItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TaskDeleteButton);
            this.Controls.Add(this.TaskCheckBox);
            this.Controls.Add(this.TaskDueDateBox);
            this.Controls.Add(this.TaskNameBox);
            this.Name = "TaskItemControl";
            this.Size = new System.Drawing.Size(248, 58);
            ((System.ComponentModel.ISupportInitialize)(this.TaskDeleteButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox TaskCheckBox;
        private System.Windows.Forms.PictureBox TaskDeleteButton;
        private System.Windows.Forms.TextBox TaskNameBox;
        private System.Windows.Forms.DateTimePicker TaskDueDateBox;
    }
}
