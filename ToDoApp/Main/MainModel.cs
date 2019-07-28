using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;

namespace ToDoApp.Main
{
    public class MainModel : IMainModel
    {
        public IButtonModel FirstButton { get; set; }
        public IButtonModel SecondButton { get; set; }
        public IButtonModel ThirdButton { get; set; }
        public ICalendarModel Calendar { get; set; }
        public MainModel(IButtonModel firstButton, IButtonModel secondButton, IButtonModel thirdButton, ICalendarModel calendar)
        {
            FirstButton = firstButton;
            SecondButton = secondButton;
            ThirdButton = thirdButton;
            Calendar = calendar;
        }
    }
}
