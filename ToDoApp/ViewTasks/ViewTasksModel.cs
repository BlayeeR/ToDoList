using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;

namespace ToDoApp.ViewTasks
{
    public class ViewTasksModel : IViewTasksModel
    {
        public IListViewModel ListView { get; set; }

        public ViewTasksModel(IListViewModel listView)
        {
            this.ListView = listView;
        }
    }
}
