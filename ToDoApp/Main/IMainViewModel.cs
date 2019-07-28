using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.EditTask;
using ToDoApp.ViewTasks;

namespace ToDoApp.Main
{
    public interface IMainViewModel
    {
        IMainModel MainModel { get; set; }
        IViewModel CurrentChildViewModel { get; set; }
        IMainViewModel Get();
    }
}
