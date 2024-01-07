using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo
{
    internal class TaskFlowLayoutPanel : FlowLayoutPanel
    {
        private List<TaskItemControl> taskItemControls = new List<TaskItemControl>();

        public TaskFlowLayoutPanel()
        {
            
        }

        public void BindTaskDeleteEvents()
        { 
            foreach (var item in taskItemControls) 
            {
                item.DeleteButtonClick += TaskItemControl_DeleteButtonClick;
            }
        }

        public void ClearTaskDeleteEventBindings()
        { 
            
        }

        private void TaskItemControl_DeleteButtonClick(object sender, TaskDeleteEventArgs e)
        {
            TaskItemControl controlToDelete = e.TaskItemControl;
            int idx = taskItemControls.FindIndex(control => control == controlToDelete);

            if(idx != -1)
            {
                RemoveTaskItemFromDisplay(idx);
            }
        }

        public void AddTaskItemToDisplay(TaskItem task)
        {
            // Create a new taskItemControl and add the task parameters
            // Add that taskItemControl to the List<TaskItemControl> so we can keep track of it
            TaskItemControl taskItemControl = new TaskItemControl(task);
            taskItemControls.Add(taskItemControl);
            Controls.Add(taskItemControl);
        }

        public bool RemoveTaskItemFromDisplay(int index)
        {
            // Remove a task element from the display
            // Return true if successful and false if unsuccessful or couldn't find element
            if (taskItemControls.ElementAtOrDefault(index) != null)
            { 
                taskItemControls.RemoveAt(index);
                return true;
            }

            return false;
        }

        public int ClearTaskItemDisplay()
        {
            // Clear the entire display - Remove all of the display elements
            // Return the amount of display items removed
            int rowsAffected = taskItemControls.Count;
            taskItemControls.Clear();
            return rowsAffected;
        }

        public bool UpdateTaskItemControl(int index, TaskItem newData)
        {
            // Update a particular item control with new information 
            // Return true if we successfully updated the item and false if we couldn't find or update the item
            if (taskItemControls.ElementAtOrDefault(index) != null)
            {
                taskItemControls[index].UpdateTaskItemControlData(newData);
                return true;
            }

            return false;
        }
    }
}
