using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DatalagringUpg2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoadIssuesView : Page
    {
        public static int id { get; set; }

        List<Issue> startedIssues = new List<Issue>();
        List<Issue> completedIssues = new List<Issue>();

        List<Issue> _startedIssues = new List<Issue>();
        List<Issue> _completedIssues = new List<Issue>();

        public LoadIssuesView()
        {
            this.InitializeComponent();
            LoadIssues().GetAwaiter();
            
        }

        public async Task LoadIssues()
        {
            
            var issues = await GetDataService.LoadAllIssuesAsync();
            foreach (var issue in issues)
            {
                if (issue.SituationId == 4)
                {
                    _completedIssues.Add(issue);
                }
                else
                {
                    _startedIssues.Add(issue);
                }
            }

            completedIssues = _completedIssues.Take(App.maxRows).ToList();
            startedIssues = _startedIssues.Take(App.maxRows).ToList();
        }

        private void dataGridCompleted_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            dynamic Cissue = dataGridCompleted.SelectedItem;

            id = Cissue.IssueId;
            
            SelectedFrame.Navigate(typeof(SelectedItemView), id);
            id = -1;
        }

        private void dataGridStarted_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            dynamic Sissue = dataGridStarted.SelectedItem;

            id = Sissue.IssueId;
            
            SelectedFrame.Navigate(typeof(SelectedItemView), id);
            id = -1;
        }
    }
}
