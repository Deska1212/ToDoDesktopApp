using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    /// <summary>
    /// Controller class for managing client side task list and database connection
    /// </summary>
    internal class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        public IDatabaseConnection databaseConnectionManager;

        public List<TaskItem> Tasks { get => tasks; }

        public TaskManager(IDatabaseConnection dbConnection)
        {
            // TODO: Implement dependency injection for the database connection
            databaseConnectionManager = dbConnection;
            // Will likely add an ApplicationConfig class to handle this
            bool validConnection = databaseConnectionManager.LoadTasksFromDatabase(out tasks);
        }

        /// <summary>
        /// View method for adding a new task to the task list, task check state is defaulted to false, index is handled by the task manager
        /// </summary>
        /// <param name="taskName">Task name to add</param>
        public void AddTask(string taskName)
        {
            TaskItem task = new TaskItem(taskName);
            tasks.Add(task);
            databaseConnectionManager.AddTaskToDatabase(tasks.Count - 1, taskName, false);
        }

        /// <summary>
        /// View method for removing a task from the task list
        /// </summary>
        /// <param name="index">Index to remove task at</param>
        public void RemoveTask(int index)
        {
            if (tasks.ElementAtOrDefault(index) != null)
            {
                tasks.RemoveAt(index);
                databaseConnectionManager.RemoveTaskFromDatabase(index);
            }
        }

        /// <summary>
        /// View method for clearing all tasks from the task list
        /// </summary>
        public void ClearAllTasks()
        {
            tasks.Clear();
            int rowsAffected = databaseConnectionManager.ClearAllTasksFromDatabase();
            Console.Write(rowsAffected + " rows affected");
        }

        /// <summary>
        /// View method for setting the check state of a task
        /// </summary>
        /// <param name="index">Index to set the next check state</param>
        /// <param name="newState">New check state to set to</param>
        public void SetTaskCheckState(int index, bool newState)
        {
            tasks[index].IsChecked = newState;
            TaskItem newTaskItem = tasks[index];
            databaseConnectionManager.ModifyTaskInDatabase(newTaskItem, index);
        }
    }
}
