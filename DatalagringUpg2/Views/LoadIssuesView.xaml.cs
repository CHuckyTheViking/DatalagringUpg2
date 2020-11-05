﻿using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using DataAccessLibrary.ViewModels;
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

        public StartedViewModel startedViewModel { get; set; }
        public CompletedViewModel completedViewModel { get; set; }

        public LoadIssuesView()
        {
            this.InitializeComponent();
            startedViewModel = new StartedViewModel();
            completedViewModel = new CompletedViewModel();
            LoadIssues().GetAwaiter();
        }

        private async Task LoadIssues()
        {
            var issues = await GetDataService.contextissues();
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


       

        private void lvCompletedIssue_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            dynamic Cissue = lvCompletedIssue.SelectedItem;

            id = Cissue.IssueId;


            SelectedFrame.Navigate(typeof(SelectedItemView), id);
        }

        private void lvStartedIssue_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            dynamic Sissue = lvStartedIssue.SelectedItem;

            id = Sissue.IssueId;

            SelectedFrame.Navigate(typeof(SelectedItemView), id);
            id = -1;
        }
    }
}
