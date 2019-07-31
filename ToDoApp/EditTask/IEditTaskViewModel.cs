using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Main;

namespace ToDoApp.EditTask
{
    public interface IEditTaskViewModel : IViewModel
    {
        IEditTaskModel EditTaskModel { get; set; }
    }
}
