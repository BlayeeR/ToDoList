using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;
using ToDoApp.Main;

namespace ToDoApp.ViewTasks
{
    public interface IViewTasksModel : IModel
    {
        IListViewModel ListView { get; set; }
    }
}
