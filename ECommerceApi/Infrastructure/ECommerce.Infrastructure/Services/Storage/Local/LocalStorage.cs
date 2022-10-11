using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private IWebHostEnvironment environment;

        public LocalStorage(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        private async Task<bool> CopyFileAsync(string fullPath, IFormFile file)
        {
            try
            {
                await using FileStream fs = new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(fs);
                await fs.FlushAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("CopyFile exeption");
                //todo log
            }
        }
        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            string rootPath = Path.Combine(environment.WebRootPath, pathOrContainerName);

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            List<(string fileName, string pathOrContainerName)> datas = new();
            foreach (IFormFile formFile in files)
            {
                string seoFileName = FileRenameAsync(rootPath, formFile.FileName);
                var fullPath = Path.Combine(rootPath, seoFileName);
                var result = await CopyFileAsync(fullPath, formFile);

                datas.Add(new(seoFileName, fullPath));
            }
            return datas;
        }

        public async Task DeleteAsync(string pathOrContainerName, string fileName) =>
             File.Delete($"{pathOrContainerName}\\{fileName}");


        public List<string> GetFiles(string pathOrContainerName)
        {
            DirectoryInfo directory = new(pathOrContainerName);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}\\{fileName}");
    }
}
