﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;

namespace ToDoApp.ViewTasks
{
    public interface IViewTasksModel
    {
        IListViewModel ListView { get; set; }
    }
}
