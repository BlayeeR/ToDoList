using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.EditTask;

namespace ToDoApp.ViewTasks
{
    public class ViewTasksViewModel : IViewTasksViewModel
    {
        public IViewModel Get()
        {
            return this;
        }
    }
}
