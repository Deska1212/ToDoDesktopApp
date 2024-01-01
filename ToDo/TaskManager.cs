using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    /// <summary>
    /// 
    /// </summary>
    internal class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        public IDatabaseConnection databaseConnectionManager = new DatabaseConnection();

        public List<TaskItem> Tasks
        {
            get
            {
                return tasks;
            }
        }

        public TaskManager()
        {
            // TODO: Implement dependancy injection
            bool validConnection = databaseConnectionManager.LoadTasksFromDatabase(out tasks);
        }

        public void AddTask(string taskName)
        {
            TaskItem task = new TaskItem(taskName);
            tasks.Add(task);
            databaseConnectionManager.AddTaskToDatabase(tasks.Count - 1, taskName, false);
        }

        public void RemoveTask(int index)
        {
            tasks.RemoveAt(index);
            databaseConnectionManager.RemoveTaskFromDatabase(index);
        }

        public void ClearAllTasks()
        {
            tasks.Clear();
            int rowsAffected = databaseConnectionManager.ClearAllTasksFromDatabase();
            Console.Write(rowsAffected + " rows affected");
        }

        public void SetTaskCheckState(int index, bool newState)
        {
            tasks[index].IsChecked = newState;
            TaskItem newTaskItem = tasks[index];
            databaseConnectionManager.ModifyTaskInDatabase(newTaskItem, index);
        }
    }
}
