using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Services
{
    public interface ITaskService
    {
        ICollection<TaskEntity> GetTasks();
        ICollection<TaskEntity> GetTasks(DateTime date);

        void InsertTask(TaskEntity task);
        void RemoveTask(TaskEntity task);
    }
}
