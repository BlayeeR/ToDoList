using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Main;

namespace ToDoApp.Controls
{
    public interface ICalendarModel : INotifyPropertyChanged, IModel
    {
        DateTime SelectedDate { get; set; }
    }
}
