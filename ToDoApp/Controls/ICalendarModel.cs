﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Controls
{
    public interface ICalendarModel
    {
        DateTime SelectedDate { get; set; }
    }
}