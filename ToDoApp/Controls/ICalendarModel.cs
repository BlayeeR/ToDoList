using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Controls
{
    public interface ICalendarModel : INotifyPropertyChanged
    {
        DateTime SelectedDate { get; set; }
    }
}
