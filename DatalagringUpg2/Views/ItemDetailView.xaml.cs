﻿using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Core;
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
    public sealed partial class ItemDetailView : Page
    {
        List<Comment> comments = new List<Comment>();
        private static string tbxIs { get; set; }
        private static int detailId { get; set; }
        public ItemDetailView()
        {
            
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {            

            detailId = (int)e.Parameter;
            GetIssue(detailId);
            Frame.Visibility = Visibility.Visible;
        }


        private void GetIssue(int detailId)
        {
            try
            {
                List<Issue> issue = GetDataService.GetIssueDetailsAsync(detailId).GetAwaiter().GetResult();

                foreach (var i in issue)
                {
                    List<Picture> picture = new List<Picture>();
                    tbxIssue.Text = i.Issue1;
                    tbxIssueDate.Text = i.IssueTime.ToString();
                    tbxCustomer.Text = i.Customer.CustomerName;
                    tbxId.Text = $"Issue id: {i.IssueId}"; ;
                    tbxCategory.Text = i.Category.Category1;
                    tbxSituation.Text = i.Situation.Situation1;

                    picture = i.Picture.ToList();
                    if (picture != null)
                    {
                        foreach (var p in picture)
                        {
                            imageDetail.Source = ByteArrayToImageAsync(p.Picture1).Result;
                        }
                    }

                    var comms = i.Comment.ToList();
                    if (comms != null)
                    {
                        foreach (var c in comms)
                        {
                            comments.Add(c);
                        }
                    }

                }
            }
            catch 
            {
            }
           
        }

        public async Task<BitmapImage> ByteArrayToImageAsync(byte[] pixeByte)
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                BitmapImage image = new BitmapImage();
                await stream.WriteAsync(pixeByte.AsBuffer());
                stream.Seek(0);
                image.SetSource(stream);
                return image;
            }
        }

        private void btnCloseIssue_Click(object sender, RoutedEventArgs e)
        {

            

        }

        private void btnUpdateIssue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void issueView_Loaded(object sender, RoutedEventArgs e)
        {

        }


    }
    

}
