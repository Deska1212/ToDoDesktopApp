using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal interface IDatabaseConnection
    {
        void InitialiseDatabase();
        bool LoadTasksFromDatabase(out List<TaskItem> tList);
        bool AddTaskToDatabase(int index, string taskName, bool isChecked);
        bool RemoveTaskFromDatabase(int index);
        int ClearAllTasksFromDatabase();
        bool ModifyTaskInDatabase(TaskItem task, int index);
        bool DatabaseExists();
        void CreateDatabase();
        void CreateTasksTable();
    }
}
