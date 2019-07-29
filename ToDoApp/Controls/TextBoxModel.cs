using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Controls
{
    public class TextBoxModel : ITextBoxModel, INotifyPropertyChanged
    {
        private string text;

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Content"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
