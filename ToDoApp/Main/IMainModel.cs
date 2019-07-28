using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;

namespace ToDoApp.Main
{
    public interface IMainModel
    {
        IButtonModel FirstButton { get; set; }
        IButtonModel SecondButton { get; set; }
        IButtonModel ThirdButton { get; set; }
        ICalendarModel Calendar { get; set; }
    }
}
