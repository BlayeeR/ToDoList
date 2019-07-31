using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Repositiories
{
    public interface ITaskRepository : IRepository
    {
        ICollection<TaskEntity> GetTasks();
        ICollection<TaskEntity> GetTasks(DateTime date);

        void AddOrUpdateTask(TaskEntity task);
        void RemoveTask(TaskEntity task);
    }
}
