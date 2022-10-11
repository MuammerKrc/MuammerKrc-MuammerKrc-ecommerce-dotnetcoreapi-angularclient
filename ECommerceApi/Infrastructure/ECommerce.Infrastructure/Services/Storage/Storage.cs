using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Storage;
using ECommerce.Infrastructure.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace ECommerce.Infrastructure.Services.Storage
{
    public class Storage
    {
        public string FileRenameAsync(string path, string fileName)
        {
            int index = 0;
            string extension = Path.GetExtension(fileName);
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            string seaoFriendlyName = HelperClass.SeoFriendly(oldName);
            string newFileName = $"{HelperClass.SeoFriendly(seaoFriendlyName)}{extension}";

            while (true)
            {
                index++;
                if (File.Exists(Path.Combine(path, newFileName)))
                    newFileName = seaoFriendlyName + $"-{index}{extension}";
                else
                    break;
            }
            return newFileName;
        }
    }
}
