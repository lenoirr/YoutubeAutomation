using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAutomation
{
    public class AppConfig
    {
        public string FfmpegRelativePath { get; set; }
        public string FfmpegLocalPath { get; set; }

        private static string workingDirectory = Environment.CurrentDirectory;

        public string projectPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        public string FfmpegFullPath => Path.Combine(projectPath, FfmpegRelativePath);
    }

    public class ConfigurationLoader
    {
        public static AppConfig LoadConfiguration()
        {
            var config = new AppConfig
            {
                FfmpegRelativePath = ConfigurationManager.AppSettings["FfmpegRelativePath"],
                FfmpegLocalPath = ConfigurationManager.AppSettings["FfmpegLocalPath"]
            };
            return config;
        }
    }
    

}
