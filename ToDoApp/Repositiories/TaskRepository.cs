using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Repositiories
{
    public class TaskRepository : ITaskRepository
    {
        public ICollection<TaskEntity> GetTasks()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Tasks.ToList();
            }
        }

        public ICollection<TaskEntity> GetTasks(DateTime date)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Tasks.Where(x => x.Date.Year == date.Year
                       && x.Date.Month == date.Month
                       && x.Date.Day == date.Day).ToList();
            }
        }

        public void AddOrUpdateTask(TaskEntity task)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                try
                {
                    TaskEntity temp = context.Tasks.Single(x => x.Id == task.Id);
                    temp.Description = task.Description;
                    temp.Name = task.Name;
                    temp.Date = task.Date;
                    temp.Completed = task.Completed;
                }
                catch (InvalidOperationException)
                {
                    context.Tasks.Add(task);
                }
                context.SaveChanges();
            }
        }

        public void RemoveTask(TaskEntity task)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Tasks.Attach(task);
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
        }
    }
}
