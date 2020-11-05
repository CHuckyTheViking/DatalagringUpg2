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
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DatalagringUpg2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddIssueView : Page
    {
        public static byte[] image { get; set; }
        public static string path { get; set; }


        public AddIssueView()
        {
            this.InitializeComponent();
            cmbLoaderAsync().GetAwaiter();
            
        }

        private void btnAddIssue_Click(object sender, RoutedEventArgs e)
        {
            
            string issue = tbxissue.Text;
            DateTime datetime = DateTime.Now;
            string comment = tbxcomment.Text;
            byte[] picture = image;

            string cstmer = cmbCustomers.SelectedValue.ToString();

            string category = cmbCategory.SelectedValue.ToString();          
            string situation = cmbSituation.SelectedValue.ToString();
        
            AddDataService.AddIssueToDBAsync(issue,datetime,comment,picture,cstmer,category,situation).GetAwaiter();
            ClearFields();
        }
        private void ClearFields()
        {
            tbxissue.Text = "";
            tbxcomment.Text = "";
            //imageAdd.ClearValue();
            cmbCustomers.SelectedItem = null;
            cmbCategory.SelectedItem = null;
            cmbSituation.SelectedItem = null;
        }



        private async Task cmbLoaderAsync()
        {
            await cmbCustomersAddAsync();
            await cmbCategorysAddAsync();
            await cmbSituationsAddAsync();
        }

        private async Task cmbCustomersAddAsync()
        {
            cmbCustomers.ItemsSource = await GetDataService.GetCustomersAsync();
        }
        private async Task cmbCategorysAddAsync()
        {
            cmbCategory.ItemsSource = await GetDataService.GetCategorysAsync();
        }
        private async Task cmbSituationsAddAsync()
        {
            cmbSituation.ItemsSource = await GetDataService.GetSituationsAsync();
        }

        private async void btnAddPicture_Click(object sender, RoutedEventArgs e)
        {
            image = await FilePicker.FilePickerAsync();
            //path = await FilePicker.GetPictureUri();
            //LoadPicture(path);
            
            
        }
        private async void LoadPicture(string path)
        {
           


            //var uri = new Uri(path);
            //var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            //Image img = new Image();
            //img.Source = file.;
            //imageAdd.u;
            //imageAdd.Source = new BitmapImage(new Uri(path));
        }
    }
}
