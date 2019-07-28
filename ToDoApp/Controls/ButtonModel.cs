using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoApp.Controls
{
    public class ButtonModel : IButtonModel, INotifyPropertyChanged
    {
        private string content;
        private Visibility visibility;

        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Content"));
            }
        }
        public Visibility Visibility
        {
            get => visibility;
            set
            {
                visibility = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Visibility"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
