using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Controls
{
    public class ListViewModel : IListViewModel
    {
        private TaskEntity selectedTask;

        public ObservableCollection<TaskEntity> ListViewItems { get; set; }

        public ListViewModel()
        {
            ListViewItems = new ObservableCollection<TaskEntity>();
        }

        public TaskEntity SelectedTask
        {
            get => selectedTask;
            set
            {
                selectedTask = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedTask"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
