using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.ViewModels
{
    public class StartedViewModel
    {
        public ObservableCollection<Issue> started { get; set; }

        public StartedViewModel()
        {
            started = new ObservableCollection<Issue>();
        }

    }
}
