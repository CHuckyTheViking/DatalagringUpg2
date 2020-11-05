using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.ViewModels
{
    public class CompletedViewModel
    {
        
       
        public ObservableCollection<Issue> completed { get; set; }

        public CompletedViewModel()
        {
            completed = new ObservableCollection<Issue>();

        }


    }
}
