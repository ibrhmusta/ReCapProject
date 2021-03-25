using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Utilities.Business.FileManager
{
    public class CarImagesFileHelper
    {
        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        static string path = @"Images\";
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newFileName = Guid.NewGuid().ToString("N") + extension;
            if (!Directory.Exists(directory + path))
            {
                Directory.CreateDirectory(directory + path);
            }
            using (FileStream fileStream = File.Create(directory + path + newFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return (path + newFileName).Replace("\\", "/");
        }

        public static void Update(IFormFile file, string OldPath)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            using (FileStream fileStream = File.Open(OldPath.Replace("/", "\\"), FileMode.Open))
            {
                file.CopyToAsync(fileStream);
                fileStream.Flush();
            }
        }

        public static void Delete(string ImagePath)
        {
            if (File.Exists(ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath) != "default.png")
            {
                File.Delete(ImagePath.Replace("/", "\\"));
            }
        }

        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N") + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
        }
    }
}