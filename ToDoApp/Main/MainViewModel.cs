using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Main
{
    public class MainViewModel : IMainViewModel
    {
        public IMainModel MainModel { get; set; }
        public MainViewModel(IMainModel mainModel)
        {
            this.MainModel = mainModel;
        }

        public IMainViewModel Get()
        {
            return this;
        }
    }
}
