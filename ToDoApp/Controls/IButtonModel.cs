using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoApp.Controls
{
    public interface IButtonModel
    {
        string Content { get; set; }
        Visibility Visibility { get; set; }
    }
}
