using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ToDo
{

    /// <summary>
    /// View class for form task display and input handling
    /// </summary>
    public partial class Form1 : Form
    {
        private TaskManager taskManager;
        private int selectedTaskIndex = -1;
        

        public Form1()
        {
            InitializeComponent();
            taskManager = new TaskManager(new SQLiteDatabaseConnection());
            Console.WriteLine("Form1 constructor called");

            if(taskManager.Tasks.Count != 0)
            {            
                RefreshTaskDisplay();
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Refreshes the task display by clearing it and then adding all tasks from the task manager
        /// </summary>
        private void RefreshTaskDisplay()
        {
            ClearTaskDisplay();
                       
           for(int i = 0; i < taskManager.Tasks.Count; ++i)
           {
                TaskListDisplay.Items.Add(taskManager.Tasks[i], taskManager.Tasks[i].IsChecked);
           }  
        }
            
        private void ClearTaskDisplay()
        {
            TaskListDisplay.Items.Clear();
        }

        /// <summary>
        /// Event handler for when the selected index of the task list changes
        /// </summary>
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        { 
            if(TaskListDisplay.SelectedIndex == -1)
            {
                return;
            }
            selectedTaskIndex = TaskListDisplay.SelectedIndex;
            SelectedIndexLabel.Text = $"Selected Index: {selectedTaskIndex}";
            SelectedTaskName.Text = $"Selected Task Name: {taskManager.Tasks[selectedTaskIndex].TaskName}";
            
        }

        /// <summary>
        /// Event handler for when an item in the task list is checked or unchecked
        /// </summary>
        private void OnItemChecked(object sender, ItemCheckEventArgs e)
        {
            bool newValue = e.NewValue == CheckState.Checked;
            taskManager.SetTaskCheckState(e.Index, newValue);
        }

        /// <summary>
        /// Event handler for when the add task button is clicked
        /// </summary>
        private void OnAddTaskButtonClick(object sender, EventArgs e)
        {
            string taskName = TaskNameInputTextBox.Text;
            if(string.IsNullOrWhiteSpace(taskName))
            {
                MessageBox.Show("Please enter a task name!");
                return;
            }

            taskManager.AddTask(taskName);
            RefreshTaskDisplay();
            ClearTaskNameInput();
        }

        /// <summary>
        /// Clears the text box the user uses to input a task name
        /// </summary>
        private void ClearTaskNameInput()
        {
            TaskNameInputTextBox.Clear();
        }
        
        /// <summary>
        /// Event handler for when the user presses a key while the task name input text box is selected
        /// Add task behaviour only called if the key pressed is enter
        /// </summary>
        private void OnTaskNameInputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string taskName = TaskNameInputTextBox.Text;                
                if(string.IsNullOrWhiteSpace(taskName))
                {
                    MessageBox.Show("Please enter a task name!");
                    return;
                }

                taskManager.AddTask(taskName);
                RefreshTaskDisplay();
                ClearTaskNameInput();
            }
        }

        /// <summary>
        /// Event handler for when the remove task button is clicked
        /// </summary>
        private void OnRemoveTaskButtonClick(object sender, EventArgs e)
        {
            if (selectedTaskIndex != -1)
            {
                taskManager.RemoveTask(selectedTaskIndex);
                RefreshTaskDisplay();
            }
        }

        /// <summary>
        /// Event handler for when the clear task button is clicked
        /// </summary>
        private void OnClearTaskButtonClick(object sender, EventArgs e)
        {
            taskManager.ClearAllTasks();
            RefreshTaskDisplay();
            MessageBox.Show("All tasks cleared!");
        }   

    }


}
