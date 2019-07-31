using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;

namespace ToDoApp.EditTask
{
    public class EditTaskModel : IEditTaskModel
    {
        private TaskEntity editedTask;

        public ITextBoxModel NameTextBox { get; set; }
        public ITextBoxModel DescriptionTextBox { get; set; }
        public TaskEntity EditedTask
        {
            get => editedTask;
            set
            {
                editedTask = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EditedTask"));
            }
        }

        public EditTaskModel(ITextBoxModel nameTextBox, ITextBoxModel descriptionTextBox)
        {
            this.NameTextBox = nameTextBox;
            this.DescriptionTextBox = descriptionTextBox;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
