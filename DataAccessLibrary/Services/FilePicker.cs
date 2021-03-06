﻿using DataAccessLibrary.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary.Services
{
    public class FilePicker
    {

        public static async Task<string> FilePickerAsync()
        {
            string pictureName = null;
            try
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".png");

                StorageFile file = await picker.PickSingleFileAsync();
                
                StorageFolder mainFolder = ApplicationData.Current.LocalFolder;

                Guid guid = Guid.NewGuid();
                StorageFile file2 = await file.CopyAsync(mainFolder, guid.ToString());

                pictureName = await AzureStorageService.UploadPictureAsync(file2);

                await file2.DeleteAsync();

            }
            catch { }
            return pictureName;
        }


    }
}
