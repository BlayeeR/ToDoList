using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IWindsorContainer container;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            container = new WindsorContainer();
            container.Install(FromAssembly.This());

            var start = container.Resolve<IShell>();
            start.Run();
            container.Release(start);
        }
    }
}
