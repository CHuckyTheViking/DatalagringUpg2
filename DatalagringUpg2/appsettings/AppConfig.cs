using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace DatalagringUpg2.appsettings
{
    public class AppConfig
    {

        private readonly IConfigurationRoot _configurationRoot;

        public AppConfig()
        {
            var builder = new ConfigurationBuilder()  //Package.Current.InstalledLocation.Path
                .SetBasePath(Package.Current.InstalledLocation.Path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configurationRoot = builder.Build();
        }
       

        public AppSettings appSettings => GetSection<AppSettings>(nameof(AppSettings));
        private T GetSection<T>(string key) => _configurationRoot.GetSection(key).Get<T>();

    }
}
