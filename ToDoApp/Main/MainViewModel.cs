using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoApp.Controls;
using ToDoApp.EditTask;
using ToDoApp.Repositiories;
using ToDoApp.ViewTasks;

namespace ToDoApp.Main
{
    public class MainViewModel : IMainViewModel, INotifyPropertyChanged
    {
        public IMainModel MainModel { get; set; }
        public IViewModel CurrentChildViewModel
        {
            get => currentChildViewModel;
            set
            {
                currentChildViewModel = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentChildViewModel"));
                InvokeButtonsCanExecuteChanged();
            }
        }
        private readonly IEditTaskViewModel editTaskViewModel;
        private readonly IViewTasksViewModel viewTasksViewModel;
        private IViewModel currentChildViewModel;

        private readonly ITaskRepository TaskService;

        public ICommand FirstButtonCommand { get; private set; }
        public ICommand SecondButtonCommand { get; private set; }
        public ICommand ThirdButtonCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel(IMainModel mainModel, IEditTaskViewModel editTaskViewModel, IViewTasksViewModel viewTasksViewModel, ITaskRepository taskService)
        {
            this.MainModel = mainModel;
            this.editTaskViewModel = editTaskViewModel;
            this.viewTasksViewModel = viewTasksViewModel;
            this.TaskService = taskService;
        }

        public IViewModel Get()
        {
            CurrentChildViewModel = viewTasksViewModel;
            MainModel.FirstButton.Content = "Utwórz zadanie";
            MainModel.SecondButton.Content = "Modyfikuj zadanie";
            MainModel.ThirdButton.Content = "Usuń zadanie";
            MainModel.Calendar.SelectedDate = DateTime.Today;
            viewTasksViewModel.ViewTasksModel.ListView.ListViewItems = new ObservableCollection<TaskEntity>(TaskService.GetTasks(MainModel.Calendar.SelectedDate));

            editTaskViewModel.EditTaskModel.EditedTask = new TaskEntity();
            editTaskViewModel.EditTaskModel.PropertyChanged += EditTaskModel_PropertyChanged;
            MainModel.Calendar.PropertyChanged += Calendar_PropertyChanged;
            viewTasksViewModel.ViewTasksModel.ListView.PropertyChanged += ListView_PropertyChanged;

            FirstButtonCommand = new DelegateCommand(OnFirstButtonClicked, CanExecuteFirstButtonCommand);
            SecondButtonCommand = new DelegateCommand(OnSecondButtonClicked, CanExecuteSecondButtonCommand);
            ThirdButtonCommand = new DelegateCommand(OnThirdButtonClicked, CanExecuteThirdButtonCommand);
            return this;
        }

        private void EditTaskModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("EditedTask"))
            {
                editTaskViewModel.EditTaskModel.EditedTask.PropertyChanged += EditedTask_PropertyChanged;
            }
        }

        private void EditedTask_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Name") || e.PropertyName.Equals("Description"))
            {
                InvokeButtonsCanExecuteChanged();
            }
        }

        private void ListView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedTask"))
            {
                InvokeButtonsCanExecuteChanged();
            }
        }

        private void Calendar_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedDate"))
            {
                viewTasksViewModel.ViewTasksModel.ListView.ListViewItems = new ObservableCollection<TaskEntity>(TaskService.GetTasks(MainModel.Calendar.SelectedDate));
                InvokeButtonsCanExecuteChanged();
            }
        }

        private bool CanExecuteFirstButtonCommand(object commandParameter)
        {
            if (this.MainModel.FirstButton.Visibility == Visibility.Visible)
            {
                if (CurrentChildViewModel == viewTasksViewModel)
                    return true;
                else if (CurrentChildViewModel == editTaskViewModel)
                {
                    if (String.IsNullOrEmpty(editTaskViewModel.EditTaskModel.EditedTask.Description) || String.IsNullOrEmpty(editTaskViewModel.EditTaskModel.EditedTask.Name))
                        return false;
                    return true;
                }
            }
            return false;
        }

        private bool CanExecuteSecondButtonCommand(object commandParameter)
        {
            if (this.MainModel.FirstButton.Visibility == Visibility.Visible)
            {
                if (CurrentChildViewModel == viewTasksViewModel)
                {
                    if (this.MainModel.Calendar.SelectedDate == DateTime.MinValue)
                        return false;
                    if (viewTasksViewModel.ViewTasksModel.ListView.SelectedTask == null)
                        return false;
                    return true;
                }
                else if (CurrentChildViewModel == editTaskViewModel)
                    return true;
            }
            return false;
        }

        private bool CanExecuteThirdButtonCommand(object commandParameter)
        {
            if (this.MainModel.FirstButton.Visibility == Visibility.Visible)
            {
                if (CurrentChildViewModel == viewTasksViewModel)
                {
                    if (this.MainModel.Calendar.SelectedDate == DateTime.MinValue)
                        return false;
                    if (((ViewTasksViewModel)CurrentChildViewModel).ViewTasksModel.ListView.SelectedTask == null)
                        return false;
                    return true;
                }
                else if (CurrentChildViewModel == editTaskViewModel)
                    return false;
            }
            return false;
        }

        private void InvokeButtonsCanExecuteChanged()
        {
            try
            {
                (FirstButtonCommand as DelegateCommand).InvokeCanExecuteChanged();
                (SecondButtonCommand as DelegateCommand).InvokeCanExecuteChanged();
                (ThirdButtonCommand as DelegateCommand).InvokeCanExecuteChanged();
            }
            catch { }
        }

        private void OnFirstButtonClicked(object commandParameter)
        {
            if (CurrentChildViewModel is ViewTasksViewModel)
            {
                if (MainModel.Calendar.SelectedDate == DateTime.MinValue)
                    MainModel.Calendar.SelectedDate = DateTime.Today;
                MainModel.FirstButton.Content = "Dodaj zadanie";
                MainModel.SecondButton.Content = "Anuluj";
                MainModel.ThirdButton.Visibility = Visibility.Collapsed;
                editTaskViewModel.EditTaskModel.EditedTask = new TaskEntity();
                CurrentChildViewModel = editTaskViewModel;
            }
            else
            {
                MainModel.FirstButton.Content = "Utwórz zadanie";
                MainModel.SecondButton.Content = "Modyfikuj zadanie";
                MainModel.ThirdButton.Visibility = Visibility.Visible;
                editTaskViewModel.EditTaskModel.EditedTask.Date = MainModel.Calendar.SelectedDate;
                TaskService.AddOrUpdateTask(editTaskViewModel.EditTaskModel.EditedTask);
                editTaskViewModel.EditTaskModel.EditedTask = new TaskEntity();
                viewTasksViewModel.ViewTasksModel.ListView.ListViewItems = new ObservableCollection<TaskEntity>(TaskService.GetTasks(MainModel.Calendar.SelectedDate));
                CurrentChildViewModel = viewTasksViewModel;
            }

        }

        private void OnSecondButtonClicked(object commandParameter)
        {
            if (CurrentChildViewModel is ViewTasksViewModel)
            {
                MainModel.FirstButton.Content = "Zapisz zmiany";
                MainModel.SecondButton.Content = "Anuluj";
                MainModel.ThirdButton.Visibility = Visibility.Collapsed;
                editTaskViewModel.EditTaskModel.EditedTask = viewTasksViewModel.ViewTasksModel.ListView.SelectedTask;
                CurrentChildViewModel = editTaskViewModel;
            }
            else
            {
                MainModel.FirstButton.Content = "Utwórz zadanie";
                MainModel.SecondButton.Content = "Modyfikuj zadanie";
                MainModel.ThirdButton.Visibility = Visibility.Visible;
                CurrentChildViewModel = viewTasksViewModel;
            }
        }

        private void OnThirdButtonClicked(object commandParameter)
        {
            if (CurrentChildViewModel is ViewTasksViewModel)
            {
                if(viewTasksViewModel.ViewTasksModel.ListView.SelectedTask != null)
                {
                    TaskService.RemoveTask(viewTasksViewModel.ViewTasksModel.ListView.SelectedTask);
                    viewTasksViewModel.ViewTasksModel.ListView.ListViewItems.Remove(viewTasksViewModel.ViewTasksModel.ListView.SelectedTask);
                    viewTasksViewModel.ViewTasksModel.ListView.SelectedTask = null;
                }
            }
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
