using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Controls
{
    public interface IListViewModel : INotifyPropertyChanged
    {
        ObservableCollection<TaskEntity> ListViewItems { get; set; }
        TaskEntity SelectedTask { get; set; }
    }
}
