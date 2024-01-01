using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ToDo
{
    // TODO: create and use DTO's for database methods

    /// <summary>
    /// Controller class to handle database connection
    /// </summary>
    internal class SQLiteDatabaseConnection : IDatabaseConnection
    {
        private const string databaseFileName = "TasksDatabase.db";
        private string connectionString = $"Data Source={databaseFileName};Version=3;";
        
        
        public event EventHandler TasksLoaded;
        public event EventHandler TaskAdded;
        public event EventHandler TaskRemoved;
        public event EventHandler TasksCleared;

        public SQLiteDatabaseConnection()
        {
            Console.WriteLine("DatabaseConnectionManager constructor called");
            InitialiseDatabase();
        }

        public void InitialiseDatabase()
        {
            if(!DatabaseExists())
            {
                Console.WriteLine("Database does not exist, creating...");
                CreateTasksTable();
            }
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
                            // TODO: Is there a way I can parse this as a whole chunk instead of reading each
                            // column row individually?
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
                    command.Parameters.AddWithValue("@Id", index); // TODO: Surely theres a setting in SQLite to have an auto idx/id??
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

        #region Event Invokers 
        // TODO: Needs to be implemented

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

        private void RaiseTasksClearedEvent()
        {
            TasksCleared?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public bool DatabaseExists()
        {
            return File.Exists(databaseFileName);
        }

        public void CreateDatabase()
        {
            SQLiteConnection.CreateFile(databaseFileName);
        }

        public void CreateTasksTable()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Tasks (Id INTEGER, TaskName TEXT, IsChecked INTEGER);", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
