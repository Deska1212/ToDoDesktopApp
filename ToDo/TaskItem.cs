using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo
{
    internal class TaskItem
    {
        public string TaskName { get; set; }
        public bool IsChecked { get; set; }

        public TaskItem(string taskName, bool checkState)
        {
            TaskName = taskName;
            IsChecked = checkState;
        }

        public TaskItem(string taskName)
        {
            TaskName = taskName;
            IsChecked = false;
        }

        public override string ToString()
        {
            Console.WriteLine(TaskName);
            return TaskName;
        }
    }
}
