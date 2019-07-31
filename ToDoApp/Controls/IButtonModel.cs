using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoApp.Main;

namespace ToDoApp.Controls
{
    public interface IButtonModel : IModel
    {
        string Content { get; set; }
        Visibility Visibility { get; set; }
    }
}
