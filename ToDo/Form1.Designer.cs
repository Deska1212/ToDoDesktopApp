namespace ToDo
{
    partial class Form1
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
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.TaskNameInputTextBox = new System.Windows.Forms.TextBox();
            this.TaskNameLabel = new System.Windows.Forms.Label();
            this.ClearTasksButton = new System.Windows.Forms.Button();
            this.RemoveTaskButton = new System.Windows.Forms.Button();
            this.TaskListDisplay = new System.Windows.Forms.CheckedListBox();
            this.SelectedIndexLabel = new System.Windows.Forms.Label();
            this.SelectedTaskName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Location = new System.Drawing.Point(407, 12);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(243, 80);
            this.AddTaskButton.TabIndex = 0;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.OnAddTaskButtonClick);
            // 
            // TaskNameInputTextBox
            // 
            this.TaskNameInputTextBox.Location = new System.Drawing.Point(503, 99);
            this.TaskNameInputTextBox.Name = "TaskNameInputTextBox";
            this.TaskNameInputTextBox.Size = new System.Drawing.Size(147, 22);
            this.TaskNameInputTextBox.TabIndex = 1;
            this.TaskNameInputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTaskNameInputKeyDown);
            // 
            // TaskNameLabel
            // 
            this.TaskNameLabel.AutoSize = true;
            this.TaskNameLabel.Location = new System.Drawing.Point(404, 105);
            this.TaskNameLabel.Name = "TaskNameLabel";
            this.TaskNameLabel.Size = new System.Drawing.Size(78, 16);
            this.TaskNameLabel.TabIndex = 2;
            this.TaskNameLabel.Text = "Task Name";
            // 
            // ClearTasksButton
            // 
            this.ClearTasksButton.Location = new System.Drawing.Point(407, 294);
            this.ClearTasksButton.Name = "ClearTasksButton";
            this.ClearTasksButton.Size = new System.Drawing.Size(243, 80);
            this.ClearTasksButton.TabIndex = 3;
            this.ClearTasksButton.Text = "Clear Tasks";
            this.ClearTasksButton.UseVisualStyleBackColor = true;
            this.ClearTasksButton.Click += new System.EventHandler(this.OnClearTaskButtonClick);
            // 
            // RemoveTaskButton
            // 
            this.RemoveTaskButton.Location = new System.Drawing.Point(407, 208);
            this.RemoveTaskButton.Name = "RemoveTaskButton";
            this.RemoveTaskButton.Size = new System.Drawing.Size(243, 80);
            this.RemoveTaskButton.TabIndex = 4;
            this.RemoveTaskButton.Text = "Remove Task";
            this.RemoveTaskButton.UseVisualStyleBackColor = true;
            this.RemoveTaskButton.Click += new System.EventHandler(this.OnRemoveTaskButtonClick);
            // 
            // TaskListDisplay
            // 
            this.TaskListDisplay.FormattingEnabled = true;
            this.TaskListDisplay.Location = new System.Drawing.Point(12, 13);
            this.TaskListDisplay.Name = "TaskListDisplay";
            this.TaskListDisplay.Size = new System.Drawing.Size(386, 361);
            this.TaskListDisplay.TabIndex = 6;
            this.TaskListDisplay.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            this.TaskListDisplay.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnItemChecked);

            // 
            // SelectedIndexLabel
            // 
            this.SelectedIndexLabel.AutoSize = true;
            this.SelectedIndexLabel.Location = new System.Drawing.Point(407, 125);
            this.SelectedIndexLabel.Name = "SelectedIndexLabel";
            this.SelectedIndexLabel.Size = new System.Drawing.Size(87, 16);
            this.SelectedIndexLabel.TabIndex = 7;
            this.SelectedIndexLabel.Text = "Selected Idx: ";
            // 
            // SelectedTaskName
            // 
            this.SelectedTaskName.AutoSize = true;
            this.SelectedTaskName.Location = new System.Drawing.Point(407, 150);
            this.SelectedTaskName.Name = "SelectedTaskName";
            this.SelectedTaskName.Size = new System.Drawing.Size(141, 16);
            this.SelectedTaskName.TabIndex = 8;
            this.SelectedTaskName.Text = "Selected Task Name: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 395);
            this.Controls.Add(this.SelectedTaskName);
            this.Controls.Add(this.SelectedIndexLabel);
            this.Controls.Add(this.TaskListDisplay);
            this.Controls.Add(this.RemoveTaskButton);
            this.Controls.Add(this.ClearTasksButton);
            this.Controls.Add(this.TaskNameLabel);
            this.Controls.Add(this.TaskNameInputTextBox);
            this.Controls.Add(this.AddTaskButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.TextBox TaskNameInputTextBox;
        private System.Windows.Forms.Label TaskNameLabel;
        private System.Windows.Forms.Button ClearTasksButton;
        private System.Windows.Forms.Button RemoveTaskButton;
        private System.Windows.Forms.Label SelectedIndexLabel;
        private System.Windows.Forms.CheckedListBox TaskListDisplay;
        private System.Windows.Forms.Label SelectedTaskName;
    }
}

