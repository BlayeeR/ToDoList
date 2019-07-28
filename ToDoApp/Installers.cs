using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Controls;
using ToDoApp.EditTask;
using ToDoApp.Main;
using ToDoApp.ViewTasks;

namespace ToDoApp
{
    public class Installers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<ICalendarModel>().ImplementedBy<CalendarModel>().LifestyleTransient())
                .Register(Component.For<IButtonModel>().ImplementedBy<ButtonModel>().LifestyleTransient())
                .Register(Component.For<IEditTaskModel>().ImplementedBy<EditTaskModel>().LifestyleTransient())
                .Register(Component.For<IViewTasksModel>().ImplementedBy<ViewTasksModel>().LifestyleTransient())
                .Register(Component.For<IEditTaskViewModel>().ImplementedBy<EditTaskViewModel>().LifestyleTransient())
                .Register(Component.For<IViewTasksViewModel>().ImplementedBy<ViewTasksViewModel>().LifestyleTransient())
                .Register(Component.For<IMainModel>().ImplementedBy<MainModel>().LifestyleTransient())
                .Register(Component.For<IMainViewModel>().ImplementedBy<MainViewModel>().LifestyleTransient())
                .Register(Component.For<IShell>().ImplementedBy<Shell>().LifestyleTransient())
                .Register(Component.For<MainView>().LifestyleTransient());
        }
    }
}
