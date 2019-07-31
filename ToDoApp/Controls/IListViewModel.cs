using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Main;

namespace ToDoApp.Controls
{
    public interface IListViewModel : INotifyPropertyChanged, IModel
    {
        ObservableCollection<TaskEntity> ListViewItems { get; set; }
        TaskEntity SelectedTask { get; set; }
    }
}
