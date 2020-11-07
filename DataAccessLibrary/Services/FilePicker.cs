using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DataAccessLibrary.Services
{
    public class FilePicker
    {
        public static StorageFile file;
        public static byte[] bytes { get; set; }
        public static async Task<byte[]> FilePickerAsync()
        {
            
            try
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".png");


                file = await picker.PickSingleFileAsync();

                var buffer = await FileIO.ReadBufferAsync(file);
                using (MemoryStream mstream = new MemoryStream())
                {
                    await buffer.AsStream().CopyToAsync(mstream);
                    bytes = mstream.ToArray();

                }

            }
            catch {  }
            return bytes;
        }

    }
}
