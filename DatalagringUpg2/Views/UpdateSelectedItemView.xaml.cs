using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
    public sealed partial class UpdateSelectedItemView : Page
    {
        private static int detailId { get; set; }
        private static string cmbCustom { get; set; }
        private static string cmbSit { get; set; }
        private static string cmbCat { get; set; }
        private static string tbxIs { get; set; }

        public UpdateSelectedItemView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            detailId = (int)e.Parameter;
            GetIssue(detailId);
        }

        private void GetIssue(int detailId)
        {
            try
            {
                cmbLoaderAsync().GetAwaiter();
                List<Issue> issue = GetDataService.GetIssueDetailsAsync(detailId).GetAwaiter().GetResult();

                foreach (var i in issue)
                {
                    tbxId.Text = $"Issue id: {i.IssueId}";
                    tbxIssue.Text = i.Issue1;
                    cmbCustomer.SelectedItem = i.Customer.CustomerName;
                    cmbCategory.SelectedItem = i.Category.Category1;
                    cmbSituation.SelectedItem = i.Situation.Situation1;

                    cmbCustom = i.Customer.CustomerName;
                    cmbSit = i.Situation.Situation1;
                    cmbCat = i.Category.Category1;
                    tbxIs = i.Issue1;
                }
            }
            catch { }

        }

        #region Loading Combobox info
        private async Task cmbLoaderAsync()
        {
            await cmbCustomersAddAsync();
            await cmbCategorysAddAsync();
            await cmbSituationsAddAsync();
        }

        private async Task cmbCustomersAddAsync()
        {
            cmbCustomer.ItemsSource = await GetDataService.GetCustomersAsync();
        }
        private async Task cmbCategorysAddAsync()
        {
            cmbCategory.ItemsSource = await GetDataService.GetCategorysAsync();
        }
        private async Task cmbSituationsAddAsync()
        {
            cmbSituation.ItemsSource = await GetDataService.GetSituationsAsync();
        }


        #endregion

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string customerText = null;
                string situationText = null;
                string categoryText = null;
                string issueText = null;

                if (cmbCustomer.SelectedItem.ToString() != cmbCustom)
                {
                    customerText = cmbCustomer.SelectedItem.ToString();
                }

                if (cmbSituation.SelectedItem.ToString() != cmbSit)
                {
                    situationText = cmbSituation.SelectedItem.ToString();
                }
                if (cmbCategory.SelectedItem.ToString() != cmbCat)
                {
                    categoryText = cmbCategory.SelectedItem.ToString();
                }
                if (tbxIssue.Text != tbxIs)
                {
                    issueText = tbxIssue.Text;
                }

                string response = await AddDataService.UpdateCustomerAsync(issueText, customerText, situationText, categoryText, detailId);
                btnUpdateContent(response);
            }
            catch { }
 
        }

        private async void btnAddComment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbxAddComment.Text == null)
                {
                    string response = await AddDataService.AddCommentToIssueAsync(detailId, tbxAddComment.Text, DateTime.Now);
                    btnCommentContent(response);
                    tbxAddComment.Text = "";
                }
                else
                {
                    tbxAddCommentText();
                }
                
            }
            catch { }
        }

        public async void tbxAddCommentText()
        {
            tbxAddComment.Text = "Please write something before clicking the button...";
            await Task.Delay(3000);
            tbxAddComment.Text = "";
        }

        public async void btnCommentContent(string text)
        {
            btnAddComment.Content = text;
            await Task.Delay(3000);
            btnAddComment.Content = "Add Comment";
        }

        public async void btnUpdateContent(string text)
        {
            btnUpdate.Content = text;
            await Task.Delay(3000);
            btnUpdate.Content = "Update issue";
        }
    }
}
