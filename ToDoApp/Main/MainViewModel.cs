using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.EditTask;
using ToDoApp.ViewTasks;

namespace ToDoApp.Main
{
    public class MainViewModel : IMainViewModel
    {
        public IMainModel MainModel { get; set; }
        public IViewModel CurrentChildViewModel { get; set; }
        public IEditTaskViewModel EditTaskViewModel { get; set; }
        public IViewTasksViewModel ViewTasksViewModel { get; set; }

        public MainViewModel(IMainModel mainModel, IEditTaskViewModel editTaskViewModel, IViewTasksViewModel viewTasksViewModel)
        {
            this.MainModel = mainModel;
            this.EditTaskViewModel = editTaskViewModel;
            this.ViewTasksViewModel = viewTasksViewModel;
        }

        public IMainViewModel Get()
        {
            CurrentChildViewModel = ViewTasksViewModel;
            MainModel.FirstButton.Content = "Dodaj zadanie";
            MainModel.SecondButton.Content = "Modyfikuj zadanie";
            MainModel.ThirdButton.Content = "Usuń zadanie";
            return this;
        }
    }
}
