using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;

namespace ToDoApp.EditTask
{
    public class EditTaskModel : IEditTaskModel
    {
        public ITextBoxModel DateTextBox { get; set; }
        public ITextBoxModel DescriptionTextBox { get; set; }

        public EditTaskModel(ITextBoxModel dateTextBox, ITextBoxModel descriptionTextBox)
        {
            this.DateTextBox = dateTextBox;
            this.DescriptionTextBox = descriptionTextBox;
        }
    }
}
