using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Main;

namespace ToDoApp
{
    public class Shell : IShell
    {
        public MainView View { get; set; }

        public Shell(MainView view)
        {
            this.View = view;
        }

        public void Run()
        {
            View.Show();
        }
    }
}
