using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.EditTask;

namespace ToDoApp.ViewTasks
{
    public interface IViewTasksViewModel : IViewModel
    {
        IViewTasksModel ViewTasksModel { get; set; }
    }
}
