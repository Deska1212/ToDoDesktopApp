using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    public class TaskDeleteEventArgs : EventArgs
    {
        public TaskItemControl TaskItemControl { get; set; }

        public TaskDeleteEventArgs(TaskItemControl control)
        {
            TaskItemControl = control;
        }
    }
}
