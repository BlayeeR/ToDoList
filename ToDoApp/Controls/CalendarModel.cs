using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Controls
{
    public class CalendarModel : ICalendarModel
    {
        private DateTime selectedDate;

        public DateTime SelectedDate
        {
            get => selectedDate; set
            {
                selectedDate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedDate"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
