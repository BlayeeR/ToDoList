using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;

namespace ToDoApp.EditTask
{
    public interface IEditTaskModel : INotifyPropertyChanged
    {
        ITextBoxModel NameTextBox { get; set; }
        ITextBoxModel DescriptionTextBox { get; set; }
        TaskEntity EditedTask { get; set; }

    }
}
