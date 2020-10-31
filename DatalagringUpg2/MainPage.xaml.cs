using DataAccessLibrary.Services;
using DataAccessLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DatalagringUpg2
{
   
    public sealed partial class MainPage : Page
    {
        private static string connectionString =
            @"Server=tcp:jesper-sqldatabase.database.windows.net,1433;Initial Catalog=upg2dbjesper;Persist Security Info=False;User ID=SqlAdmin;Password=XXXXXXX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static string ConnectionString { get => connectionString; set => connectionString = value; }

        public StartedViewModel startedViewModel { get; set; }
        public CompletedViewModel completedViewModel { get; set; }







        public MainPage()
        {
            this.InitializeComponent();

            startedViewModel = new StartedViewModel();
            completedViewModel = new CompletedViewModel();
        }

        private void btnAddIssue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowIssues_Click(object sender, RoutedEventArgs e)
        {
            //var issues = GetDataService.GetGoodIssue(connectionString);
            var issues = GetDataService.contextissues();
            foreach (var issue in issues)
            {
                if (issue.SituationId == 4)
                {
                    completedViewModel.completed.Add(issue);
                }
                else
                {
                    startedViewModel.started.Add(issue);
                }
            }

        }
    }
}
