using Mahtan.Assets.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Mahtan.Services
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, string pathToSave, string preFileToRemove = null);
        void Delete(string pathToFile, string fileToRemove);
    }

    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadAsync(IFormFile file, string pathToSave, string preFileToRemove = null)
        {
            try
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var fileToCreateFullPath = Path.Combine(_webHostEnvironment.WebRootPath, pathToSave, fileName);

                using (var fileStream = new FileStream(fileToCreateFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                if (!preFileToRemove.IsNullOrWhitespace())
                    Delete(pathToSave, preFileToRemove);

                return fileName;
            }
            catch
            {
                return "";
            }
        }

        public void Delete(string pathToFile, string fileToRemove)
        {
            try
            {
                var fileToRemoveFullPath = Path.Combine(_webHostEnvironment.WebRootPath, pathToFile, fileToRemove);
                File.Delete(fileToRemoveFullPath);
            }
            catch { }
        }
    }
}
