using DataAccessLibrary.Services;
using DataAccessLibrary.ViewModels;
using DatalagringUpg2.Views;
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

        public MainPage()
        {
            this.InitializeComponent();
        }

       

        private void navigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewFrame.Navigate(typeof(StartingAppView));
        }

        private void navigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ViewFrame.Navigate(typeof(SettingsView));
            }
            else
            {
                NavigationViewItem view = args.SelectedItem as NavigationViewItem;

                switch (view.Tag.ToString())
                {
                    case "LoadIssuesView":
                        ViewFrame.Navigate(typeof(LoadIssuesView));
                        navigationView.IsPaneOpen = false;
                        break;

                    case "AddIssueView":
                        ViewFrame.Navigate(typeof(AddIssueView));
                        navigationView.IsPaneOpen = false;
                        break;
                }


            }


        }

        
     
    }
}
