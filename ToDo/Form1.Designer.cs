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
            this.TaskFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Location = new System.Drawing.Point(305, 10);
            this.AddTaskButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(182, 65);
            this.AddTaskButton.TabIndex = 0;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.OnAddTaskButtonClick);
            // 
            // TaskNameInputTextBox
            // 
            this.TaskNameInputTextBox.Location = new System.Drawing.Point(377, 80);
            this.TaskNameInputTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TaskNameInputTextBox.Name = "TaskNameInputTextBox";
            this.TaskNameInputTextBox.Size = new System.Drawing.Size(111, 20);
            this.TaskNameInputTextBox.TabIndex = 1;
            this.TaskNameInputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTaskNameInputKeyDown);
            // 
            // TaskNameLabel
            // 
            this.TaskNameLabel.AutoSize = true;
            this.TaskNameLabel.Location = new System.Drawing.Point(303, 85);
            this.TaskNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TaskNameLabel.Name = "TaskNameLabel";
            this.TaskNameLabel.Size = new System.Drawing.Size(62, 13);
            this.TaskNameLabel.TabIndex = 2;
            this.TaskNameLabel.Text = "Task Name";
            // 
            // ClearTasksButton
            // 
            this.ClearTasksButton.Location = new System.Drawing.Point(308, 251);
            this.ClearTasksButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClearTasksButton.Name = "ClearTasksButton";
            this.ClearTasksButton.Size = new System.Drawing.Size(182, 65);
            this.ClearTasksButton.TabIndex = 3;
            this.ClearTasksButton.Text = "Clear Tasks";
            this.ClearTasksButton.UseVisualStyleBackColor = true;
            this.ClearTasksButton.Click += new System.EventHandler(this.OnClearTaskButtonClick);
            // 
            // RemoveTaskButton
            // 
            this.RemoveTaskButton.Location = new System.Drawing.Point(308, 182);
            this.RemoveTaskButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RemoveTaskButton.Name = "RemoveTaskButton";
            this.RemoveTaskButton.Size = new System.Drawing.Size(182, 65);
            this.RemoveTaskButton.TabIndex = 4;
            this.RemoveTaskButton.Text = "Remove Task";
            this.RemoveTaskButton.UseVisualStyleBackColor = true;
            this.RemoveTaskButton.Click += new System.EventHandler(this.OnRemoveTaskButtonClick);
            // 
            // TaskListDisplay
            // 
            this.TaskListDisplay.FormattingEnabled = true;
            this.TaskListDisplay.Location = new System.Drawing.Point(308, 144);
            this.TaskListDisplay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TaskListDisplay.Name = "TaskListDisplay";
            this.TaskListDisplay.Size = new System.Drawing.Size(182, 34);
            this.TaskListDisplay.TabIndex = 6;
            this.TaskListDisplay.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnItemChecked);
            this.TaskListDisplay.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            // 
            // SelectedIndexLabel
            // 
            this.SelectedIndexLabel.AutoSize = true;
            this.SelectedIndexLabel.Location = new System.Drawing.Point(305, 102);
            this.SelectedIndexLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SelectedIndexLabel.Name = "SelectedIndexLabel";
            this.SelectedIndexLabel.Size = new System.Drawing.Size(72, 13);
            this.SelectedIndexLabel.TabIndex = 7;
            this.SelectedIndexLabel.Text = "Selected Idx: ";
            // 
            // SelectedTaskName
            // 
            this.SelectedTaskName.AutoSize = true;
            this.SelectedTaskName.Location = new System.Drawing.Point(305, 122);
            this.SelectedTaskName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SelectedTaskName.Name = "SelectedTaskName";
            this.SelectedTaskName.Size = new System.Drawing.Size(113, 13);
            this.SelectedTaskName.TabIndex = 8;
            this.SelectedTaskName.Text = "Selected Task Name: ";
            // 
            // TaskFlowPanel
            // 
            this.TaskFlowPanel.AllowDrop = true;
            this.TaskFlowPanel.AutoScroll = true;
            this.TaskFlowPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TaskFlowPanel.Location = new System.Drawing.Point(12, 16);
            this.TaskFlowPanel.Name = "TaskFlowPanel";
            this.TaskFlowPanel.Size = new System.Drawing.Size(286, 300);
            this.TaskFlowPanel.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 321);
            this.Controls.Add(this.TaskFlowPanel);
            this.Controls.Add(this.SelectedTaskName);
            this.Controls.Add(this.SelectedIndexLabel);
            this.Controls.Add(this.TaskListDisplay);
            this.Controls.Add(this.RemoveTaskButton);
            this.Controls.Add(this.ClearTasksButton);
            this.Controls.Add(this.TaskNameLabel);
            this.Controls.Add(this.TaskNameInputTextBox);
            this.Controls.Add(this.AddTaskButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Label SelectedTaskName;
        private System.Windows.Forms.FlowLayoutPanel TaskFlowPanel;
        protected System.Windows.Forms.CheckedListBox TaskListDisplay;
    }
}

