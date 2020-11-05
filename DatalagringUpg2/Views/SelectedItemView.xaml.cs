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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DatalagringUpg2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectedItemView : Page
    {
        private static int detailId { get; set; }
        public SelectedItemView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            detailId = (int)e.Parameter;
        }
        private void issueView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewIssueFrame.Navigate(typeof(ItemDetailView2), detailId);
        }

        private void issueView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem view = args.SelectedItem as NavigationViewItem;

            try
            {
               
                switch (view.Tag.ToString())
                {
                    
                    case "ItemDetailView2":
                        ViewIssueFrame.Navigate(typeof(ItemDetailView2), detailId);
                        break;

                    case "StartingAppView":
                        ViewIssueFrame.Navigate(typeof(StartingAppView));
                        break;
                }
            }
            catch
            {

            }
        }

        private void issueView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            

        }
    }
}
