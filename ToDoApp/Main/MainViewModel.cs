using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoApp.Controls;
using ToDoApp.EditTask;
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
            }
        }
        private readonly IEditTaskViewModel editTaskViewModel;
        private readonly IViewTasksViewModel viewTasksViewModel;
        private IViewModel currentChildViewModel;

        public ICommand FirstButtonCommand { get; private set; }
        public ICommand SecondButtonCommand { get; private set; }
        public ICommand ThirdButtonCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel(IMainModel mainModel, IEditTaskViewModel editTaskViewModel, IViewTasksViewModel viewTasksViewModel)
        {
            this.MainModel = mainModel;
            this.editTaskViewModel = editTaskViewModel;
            this.viewTasksViewModel = viewTasksViewModel;
        }

        public IMainViewModel Get()
        {
            CurrentChildViewModel = viewTasksViewModel;
            MainModel.FirstButton.Content = "Utwórz zadanie";
            MainModel.SecondButton.Content = "Modyfikuj zadanie";
            MainModel.ThirdButton.Content = "Usuń zadanie";
            MainModel.Calendar.PropertyChanged += Calendar_PropertyChanged;
            FirstButtonCommand = new DelegateCommand(OnFirstButtonClicked, CanExecuteFirstButtonCommand);
            SecondButtonCommand = new DelegateCommand(OnSecondButtonClicked, CanExecuteSecondButtonCommand);
            ThirdButtonCommand = new DelegateCommand(OnThirdButtonClicked, CanExecuteThirdButtonCommand);
            return this;
        }

        private void Calendar_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedDate"))
            {
                (SecondButtonCommand as DelegateCommand).InvokeCanExecuteChanged();
                (ThirdButtonCommand as DelegateCommand).InvokeCanExecuteChanged();
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
                    //TODO: Check if textboxes arent empty
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
                    //TODO: check if current child is viewtasks and if listview has selected item
                    return true;
                }
                else if (CurrentChildViewModel == editTaskViewModel)
                    return false;
            }
            return false;
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
                CurrentChildViewModel = editTaskViewModel;
            }
            else
            {
                //TODO: Add/edit task in database
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
                //delete from database
            }
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
