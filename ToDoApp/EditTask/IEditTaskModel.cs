using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;

namespace ToDoApp.EditTask
{
    public interface IEditTaskModel
    {
        ITextBoxModel DateTextBox { get; set; }
        ITextBoxModel DescriptionTextBox { get; set; }

    }
}
