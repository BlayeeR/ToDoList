using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Main;

namespace ToDoApp
{
    public class Installers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<IMainModel>().ImplementedBy<MainModel>().LifestyleTransient())
                .Register(Component.For<IMainViewModel>().ImplementedBy<MainViewModel>().LifestyleTransient())
                .Register(Component.For<IShell>().ImplementedBy<Shell>().LifestyleTransient())
                .Register(Component.For<MainView>().LifestyleTransient());
        }
    }
}
