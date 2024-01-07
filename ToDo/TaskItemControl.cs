using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo
{
    public partial class TaskItemControl : UserControl
    {
        TaskItem taskItem;

        public event EventHandler<TaskDeleteEventArgs> DeleteButtonClick;


        public TaskItemControl(TaskItem tItem)
        {
            InitializeComponent();
            this.taskItem = tItem;
            UpdateTaskItemControlData(tItem);
        }

        public void UpdateTaskItemControlData(TaskItem newTaskItem)
        {
            this.taskItem = newTaskItem;
            TaskNameBox.Text = taskItem.TaskName;
            TaskCheckBox.Checked = taskItem.IsChecked;
            // TODO: Implement due date
            // TODO: Implement Drag'n'drog handle and colour of handle to represent task completeness
        }

        private void TaskDeleteButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Deleting Task Item Control");
            RaiseTaskDeleteButtonClickEvent(); // This is an event invoking another event?
            
        }

        private void RaiseTaskDeleteButtonClickEvent()
        {
            if (DeleteButtonClick != null)
            {
                TaskDeleteEventArgs args = new TaskDeleteEventArgs(this);
                DeleteButtonClick(this, args);
            }
        }
    }
}
