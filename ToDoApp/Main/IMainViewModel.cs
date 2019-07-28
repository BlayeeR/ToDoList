using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Main
{
    public interface IMainViewModel
    {
        IMainModel MainModel { get; set; }
        IMainViewModel Get();
    }
}
