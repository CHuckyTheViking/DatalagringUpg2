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
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
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

            try
            {
                string cstmer = null;
                string issue = tbxissue.Text;
                DateTime datetime = DateTime.Now;
                string comment = tbxcomment.Text;
                byte[] picture = image;

                if (cmbCustomers.SelectedItem == null)
                {
                    cstmer = tbxcustomer.Text;
                }
               
                string category = cmbCategory.SelectedValue.ToString();
                string situation = cmbSituation.SelectedValue.ToString();

                AddDataService.AddIssueToDBAsync(issue, datetime, comment, picture, cstmer, category, situation).GetAwaiter();
                ClearFields();
            }
            catch { }

        }
        private void ClearFields()
        {
            tbxissue.Text = "";
            tbxcomment.Text = "";
            tbxcustomer.Text = "";
            cmbCustomers.SelectedItem = null;
            cmbCategory.SelectedItem = null;
            cmbSituation.SelectedItem = null;
        }



        private async Task cmbLoaderAsync()
        {
            try
            {
                await cmbCustomersAddAsync();
                await cmbCategorysAddAsync();
                await cmbSituationsAddAsync();
            }
            catch { }

        }

        private async Task cmbCustomersAddAsync()
        {
            try
            {
                cmbCustomers.ItemsSource = await GetDataService.GetCustomersAsync();
            }
            catch { }
        }
        private async Task cmbCategorysAddAsync()
        {
            try
            {
                cmbCategory.ItemsSource = await GetDataService.GetCategorysAsync();
            }
            catch { }
        }
        private async Task cmbSituationsAddAsync()
        {
            try
            {
                cmbSituation.ItemsSource = await GetDataService.GetSituationsAsync();
            }
            catch { }
        }

        private async void btnAddPicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                image = await FilePicker.FilePickerAsync();
                if (image != null)
                {
                    imageAdd.Source = ByteArrayToImageAsync(image).Result;
                }
            }
            catch { }
        }

        public async Task<BitmapImage> ByteArrayToImageAsync(byte[] pixeByte)
        {
            BitmapImage image = new BitmapImage();
            try
            {
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    
                    await stream.WriteAsync(pixeByte.AsBuffer());
                    stream.Seek(0);
                    image.SetSource(stream);
                    
                }
            }
            catch { }
            return image;
        }

        private void btnClearCustomer_Click(object sender, RoutedEventArgs e)
        {
            cmbCustomers.SelectedItem = null;
        }
    }
}
