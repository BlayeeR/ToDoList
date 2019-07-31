using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.EditTask
{
    public class EditTaskViewModel : IEditTaskViewModel
    {
        public IEditTaskModel EditTaskModel { get; set; }

        public EditTaskViewModel(IEditTaskModel editTaskModel)
        {
            this.EditTaskModel = editTaskModel;
        }

        public IViewModel Get()
        {
            return this;
        }
    }
}
