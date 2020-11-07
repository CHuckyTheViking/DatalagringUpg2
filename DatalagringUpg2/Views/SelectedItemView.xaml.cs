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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using muxc = Microsoft.UI.Xaml.Controls;

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
            Frame.Visibility = Visibility.Visible;
        }
        private void issueView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewIssueFrame.Navigate(typeof(ItemDetailView), detailId);
        }

        private void issueView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem view = args.SelectedItem as NavigationViewItem;

            try
            {
               
                switch (view.Tag.ToString())
                {

                    case "GoBack":
                        Frame parentFrame = Window.Current.Content as Frame;
                        parentFrame.Navigate(typeof(MainPage));
                        
                        break;
                    case "ItemDetailView":
                        ViewIssueFrame.Navigate(typeof(ItemDetailView), detailId);
                        break;

                    case "UpdateSelectedItemView":
                        ViewIssueFrame.Navigate(typeof(UpdateSelectedItemView), detailId);
                        break;
                }
            }
            catch { }

        }
       
    }
}
