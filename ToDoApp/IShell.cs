using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Main;

namespace ToDoApp
{
    public interface IShell
    {
        MainView View { get; set; }
        void Run();
    }
}
