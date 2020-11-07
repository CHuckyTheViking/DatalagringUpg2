using DataAccessLibrary.Services;
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


        private void navigationMenu_Loaded(object sender, RoutedEventArgs e)
        {
                  
            MainFrame.Navigate(typeof(LoadIssuesView));
            navigationMenu.IsPaneOpen = false;
        }

        private void navigationMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            try
            {
                if (args.IsSettingsSelected)
                {
                    MainFrame.Navigate(typeof(SettingsView));
                }
                else
                {
                    NavigationViewItem view = args.SelectedItem as NavigationViewItem;

                    switch (view.Tag.ToString())
                    {
                        case "LoadIssuesView":
                            MainFrame.Navigate(typeof(LoadIssuesView));
                            navigationMenu.IsPaneOpen = false;
                            break;

                        case "AddIssueView":
                            MainFrame.Navigate(typeof(AddIssueView));
                            navigationMenu.IsPaneOpen = false;
                            break;
                    }

                }
            }
            catch { }
       

        }
     
    }
}
