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
    public partial class Form1 : Form
    {
        private TaskManager taskManager = new TaskManager();
        private int selectedTaskIndex = -1;
        

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("Form1 constructor called");

            RefreshTaskDisplay();
         }

        

        private void DEPRECIATED_InitializeTestDatabase()
        {
            using (var connection = new SQLiteConnection(""))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                // Create a table if it doesn't exist
                using (var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Tasks (TaskName TEXT);", connection))
                {
                    command.ExecuteNonQuery();
                }




                // -- Test Insert a row into the table--

                //using (var command = new SQLiteCommand("INSERT INTO Tasks (TaskName) VALUES (@TaskName)", connection))
                //{
                //    command.Parameters.AddWithValue("@TaskName", "Test Task");
                //    command.ExecuteNonQuery();
                //}
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

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

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        { 
            selectedTaskIndex = TaskListDisplay.SelectedIndex;
            SelectedIndexLabel.Text = $"Selected Index: {selectedTaskIndex}";
            SelectedTaskName.Text = $"Selected Task Name: {taskManager.Tasks[selectedTaskIndex].TaskName}";
            
        }

        private void OnItemChecked(object sender, ItemCheckEventArgs e)
        {
            bool newValue = e.NewValue == CheckState.Checked;
            taskManager.SetTaskCheckState(e.Index, newValue);
        }

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

        private void ClearTaskNameInput()
        {
            TaskNameInputTextBox.Clear();
        }

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

        private void OnRemoveTaskButtonClick(object sender, EventArgs e)
        {
            if (selectedTaskIndex != -1)
            {
                taskManager.RemoveTask(selectedTaskIndex);
                RefreshTaskDisplay();
            }
        }

        private void OnClearTaskButtonClick(object sender, EventArgs e)
        {
            taskManager.ClearAllTasks();
            RefreshTaskDisplay();
            MessageBox.Show("All tasks cleared!");
        }   

    }


}
