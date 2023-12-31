using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ToDo
{
    internal class DatabaseConnectionManager
    {
        private const string connectionString = "Data Source=TasksDatabase.db;Version=3;";

        public event EventHandler TasksLoaded;
        public event EventHandler TaskAdded;
        public event EventHandler TaskRemoved;

        public DatabaseConnectionManager()
        {
            Console.WriteLine("DatabaseConnectionManager constructor called");
            
        }

        public bool LoadTasksFromDatabase(out List<TaskItem> tList)
        {
            tList = new List<TaskItem>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                if(connection.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Failed to open database connection");
                    return false;
                }

                using (var command = new SQLiteCommand("SELECT * FROM Tasks", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string taskName = reader["TaskName"].ToString();
                            bool isChecked = reader["IsChecked"].ToString() == "1" ? true : false;
                            TaskItem newTask = new TaskItem(taskName, isChecked);
                            tList.Add(newTask);
                        }
                    }
                }
            }

            return true;
        }

        public bool AddTaskToDatabase(int index, string taskName, bool isChecked)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Failed to open database connection");
                    return false;
                }

                using (var command = new SQLiteCommand("INSERT INTO Tasks (Id, TaskName, IsChecked) VALUES (@Id, @TaskName, @IsChecked)", connection))
                {
                    command.Parameters.AddWithValue("@Id", index);
                    command.Parameters.AddWithValue("@TaskName", taskName);
                    command.Parameters.AddWithValue("@IsChecked", isChecked ? 1 : 0);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            return true;
        }

        public bool RemoveTaskFromDatabase(int taskIndex)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Failed to open database connection");
                    return false;
                }

                using (var command = new SQLiteCommand("DELETE FROM Tasks WHERE Id = @taskIndex", connection))
                {
                    command.Parameters.AddWithValue("@taskIndex", taskIndex);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    { 
                        Console.WriteLine("Failed to find task to remove - " + rowsAffected + " rows affected");
                        connection.Close();
                        return false;
                    }
                    connection.Close();
                    return true;
                }
            }
        }

        public int ClearAllTasksFromDatabase()
        { 
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Failed to open database connection");
                    return 0;
                }

                using (var command = new SQLiteCommand("DELETE FROM Tasks", connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ModifyTaskInDatabase(TaskItem newTaskItem, int indexToModify)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Failed to open database connection");
                    return false;
                }

                using (var command = new SQLiteCommand("UPDATE Tasks SET TaskName = @NewTaskName, IsChecked = @NewIsChecked WHERE Id = @IndexToModify", connection))
                {
                    command.Parameters.AddWithValue("@NewTaskName", newTaskItem.TaskName);
                    command.Parameters.AddWithValue("@NewIsChecked", newTaskItem.IsChecked ? 1 : 0);
                    command.Parameters.AddWithValue("@IndexToModify", indexToModify);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Failed to find task to modify");
                        connection.Close();
                        return false;
                    }
                    connection.Close();
                    return true;
                }
            }
        }

        private void RaiseTasksLoadedEvent()
        {
            TasksLoaded?.Invoke(this, EventArgs.Empty);
        }

        private void RaiseTaskAddedEvent()
        { 
            TaskAdded?.Invoke(this, EventArgs.Empty);
        }

        private void RaiseTaskRemovedEvent()
        { 
            TaskRemoved?.Invoke(this, EventArgs.Empty);
        }
    }
}
